// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

.assembly extern legacy library mscorlib {}
.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
  .ver 4:0:0:0
}
.assembly ILGEN_0xe4b49040 {}
.class ILGEN_0xe4b49040 {
.method static int32 Method_0x11ee88a1(native int Arg_0xb) {
.maxstack	9
    ldc.i4 0x1c7bf391
    ldarg Arg_0xb
    ldc.i4.4
   mul
    ldarg Arg_0xb
   conv.ovf.u4
  add
 xor
pop

 ldc.i4 255
 ret
}
.method static int32 Main() {
.entrypoint
.maxstack	28
 ldc.i4 0x2b153640 conv.i
 call int32 ILGEN_0xe4b49040::Method_0x11ee88a1(native int Arg_0xb)
 conv.i4
 ldc.i4 155
 sub
 ret
}
}