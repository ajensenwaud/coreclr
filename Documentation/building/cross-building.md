Cross Compilation for ARM on Linux
==================================

Through cross compilation, on Linux it is possible to build CoreCLR for arm or arm64.

Requirements
------------

You need a Debian based host and the following packages needs to be installed:

    ben@ubuntu ~/git/coreclr/ $ sudo apt-get install qemu qemu-user-static binfmt-support debootstrap

In addition, to cross compile CoreCLR the binutils for the target are required. So for arm you need:

    ben@ubuntu ~/git/coreclr/ $ sudo apt-get install binutils-arm-linux-gnueabihf

and conversely for arm64:

    ben@ubuntu ~/git/coreclr/ $ sudo apt-get install binutils-aarch64-linux-gnu


Generating the rootfs
---------------------
The `cross\build-rootfs.sh` script can be used to download the files needed for cross compilation. It will generate an Ubuntu 14.04 rootfs as this is what CoreCLR targets.

    Usage: build-rootfs.sh [BuildArch]
    BuildArch can be: arm, arm64

The `build-rootfs.sh` script must be run as root as it has to make some symlinks to the system, it will by default generate the rootfs in `cross\rootfs\<BuildArch>` however this can be changed by setting the `ROOTFS_DIR` environment variable.

For example, to generate an arm rootfs:

    ben@ubuntu ~/git/coreclr/ $ sudo ./cross/build-rootfs.sh arm

and if you wanted to generate the rootfs elsewhere:

    ben@ubuntu ~/git/coreclr/ $ sudo ROOTFS_DIR=/home/ben/coreclr-cross/arm ./build-rootfs.sh arm

Patching Urcu
-------------
After generating the rootfs, a final step is required before you can manage the cross compilation. The Urcu library in Ubuntu 14.04, the reference target, is incorrect and it needs a manual patching otherwise you will get the following errors:

```
In file included from ~/coreclr/cross/rootfs/arm/usr/include/urcu/uatomic.h:41:
~/coreclr/cross/rootfs/arm/usr/include/urcu/uatomic/generic.h:75:10: error: address
      argument to atomic builtin must be a pointer to integer or pointer ('void *' invalid)
                return __sync_val_compare_and_swap_4(addr, old, _new);
                       ^                             ~~~~
~/coreclr/cross/rootfs/arm/usr/include/urcu/uatomic/generic.h:112:3: error: address
      argument to atomic builtin must be a pointer to integer or pointer ('void *' invalid)
                __sync_and_and_fetch_4(addr, val);
                ^                      ~~~~
~/coreclr/cross/rootfs/arm/usr/include/urcu/uatomic/generic.h:151:3: error: address
      argument to atomic builtin must be a pointer to integer or pointer ('void *' invalid)
                __sync_or_and_fetch_4(addr, val);
                ^                     ~~~~
~/coreclr/cross/rootfs/arm/usr/include/urcu/uatomic/generic.h:190:10: error: address
      argument to atomic builtin must be a pointer to integer or pointer ('void *' invalid)
                return __sync_add_and_fetch_4(addr, val);
```

You can read more about this issue [here](http://lists.openembedded.org/pipermail/openembedded-core/2015-August/109294.html). The workaround is to use a more recent version of this [header file from the Urcu repository](https://github.com/urcu/userspace-rcu/blob/v0.7.15/urcu/uatomic/generic.h).

Cross compiling CoreCLR
-----------------------
Once the rootfs has been generated, it will be possible to cross compile CoreCLR. If `ROOTFS_DIR` was set when generating the rootfs, then it must also be set when running `build.sh`.

So, without `ROOTFS_DIR`:

    ben@ubuntu ~/git/coreclr/ $ ./build.sh arm debug verbose clean cross

And with:

    ben@ubuntu ~/git/coreclr/ $ ROOTFS_DIR=/home/ben/coreclr-cross/arm ./build.sh arm debug verbose clean cross

As usual the resulting binaries will be found in `bin/Product/BuildOS.BuildArch.BuildType/`

Cross Compilation for Linux, FreeBSD, or OS X
=============================================

It is also possible to use a Windows machine to build the managed components of CoreCLR or CoreFX for Linux or OS X.  This can be useful when the build on the target platform fails, for example due to Mono issues.

Build mscorlib on Windows
-------------------------
The following instructions assume you are on a Windows machine with a clone of the CoreCLR repo that has a correctly configured [environment](https://github.com/dotnet/coreclr/wiki/Windows-instructions#environment).

To build mscorlib for Linux, run the following command:

```
D:\git\coreclr> build.cmd linuxmscorlib
```

The arguments `freebsdmscorlib` and `osxmscorlib` can be used instead to build mscorlib for FreeBSD or OS X.

The output is at bin\Product\<BuildOS>.x64.Debug\mscorlib.dll.

The CoreCLR native components need to be built on the target platform.  This can be done with the following command:

```
ellismg@linux:~/git/coreclr$ ./build.sh skipmscorlib
```

Build the Framework Managed Components on Windows
-------------------------------------------------
The following instructions assume you are on a Windows machine with a clone of the CoreFX repo.

To build the CoreFX managed components for Linux, run the following command:

```
D:\git\corefx> build.cmd /p:OSGroup=Linux /p:SkipTests=true
```

`FreeBSD` and `OSX` can be used instead for the `OSGroup`.

The output is at bin\<BuildOS>.AnyCPU.Debug.

The CoreFX native components need to be built on the target platform.  This can be done with the following command:

```
ellismg@linux:~/git/corefx$ ./build.sh native
```
