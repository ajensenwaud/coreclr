// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// leave into fault from catch
// expect throw System.InvalidProgramException

.assembly extern mscorlib { }
.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
  .ver 4:0:0:0
}
.assembly test 
{
  .custom instance void [mscorlib]System.Security.AllowPartiallyTrustedCallersAttribute::.ctor() = ( 01 00 01 00 00 ) 

}


.module ver_fg_13.exe

.class private auto ansi beforefieldinit test
       extends [mscorlib]System.Object
{
  .method public static int32 Main() cil managed
  {
    .entrypoint
    .locals init (int32 retval)	
	.try
	{
		call       void test::test2()
		ldstr "Fail"
		call       void [System.Console]System.Console::WriteLine(string)
		ldc.i4 101
		stloc retval
		leave IL_01
	}

	catch [mscorlib]System.InvalidProgramException
	{
		pop
		ldstr "Pass"
		call       void [System.Console]System.Console::WriteLine(string)
		ldc.i4 100
		stloc retval
		leave IL_01
	}

		
    IL_01:  
	ldloc retval
	ret
  }

.method public hidebysig static void  test2() cil managed
  {
	.try
	{
		newobj     instance void [mscorlib]System.DivideByZeroException::.ctor()
		throw

		.try
		{
			ldstr "Test"
			pop			
			leave IL_03
		}
		
		fault
		{
			ldstr "fault"
			call       void [System.Console]System.Console::WriteLine(string)
			endfault			
		}

	IL_03:	leave IL_02
	}

	catch [mscorlib]System.DivideByZeroException
	{
		pop
		leave -22
		ldstr "Fail - b"
		call       void [System.Console]System.Console::WriteLine(string)
		leave IL_02
	}

		
    IL_02:  ret   

  }

}
