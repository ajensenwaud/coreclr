// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

.assembly extern legacy library mscorlib {}
.assembly extern System.Console
{
  .publickeytoken = (B0 3F 5F 7F 11 D5 0A 3A )
  .ver 4:0:0:0
}
.assembly ILGEN_0x22bcffe4 {}
.class ILGEN_0x22bcffe4 {
.field static	unsigned int16[] field_0x0
.method static int32 Main() {
.entrypoint
.maxstack	20
 ldc.i4 255
 newarr [mscorlib]System.UInt16 
 stsfld unsigned int16[] ILGEN_0x22bcffe4::field_0x0
Start_Orphan_0:
 ldsfld unsigned int16[] ILGEN_0x22bcffe4::field_0x0
 ldc.i4.5
 ldelem.u2
 conv.i8
 conv.u1
Start_Orphan_1f:
 ldsfld unsigned int16[] ILGEN_0x22bcffe4::field_0x0
 ldc.i4.5
 ldelem.u2
 pop
End_Orphan_1f:
 ldc.i4 1
 add.ovf
 pop
End_Orphan_0:
ldc.i4 100
ret
}
}
