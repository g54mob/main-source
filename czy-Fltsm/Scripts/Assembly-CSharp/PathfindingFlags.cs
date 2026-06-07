using System;

[Flags]
public enum PathfindingFlags
{
	None = 0,
	Query0_Open = 1,
	Query0_Closed = 2,
	Query1_Open = 4,
	Query1_Closed = 8,
	Query2_Open = 0x10,
	Query2_Closed = 0x20,
	Query3_Open = 0x40,
	Query3_Closed = 0x80,
	Query4_Open = 0x100,
	Query4_Closed = 0x200,
	Query5_Open = 0x400,
	Query5_Closed = 0x800,
	Query6_Open = 0x1000,
	Query6_Closed = 0x2000,
	Query7_Open = 0x4000,
	Query7_Closed = 0x8000,
	Query8_Open = 0x10000,
	Query8_Closed = 0x20000,
	Query9_Open = 0x40000,
	Query9_Closed = 0x80000,
	Query10_Open = 0x100000,
	Query10_Closed = 0x200000,
	Query11_Open = 0x400000,
	Query11_Closed = 0x800000,
	Query12_Open = 0x1000000,
	Query12_Closed = 0x2000000,
	Query13_Open = 0x4000000,
	Query13_Closed = 0x8000000,
	Query14_Open = 0x10000000,
	Query14_Closed = 0x20000000,
	DebugQuery_Open = 0x40000000,
	DebugQuery_Closed = int.MinValue
}
