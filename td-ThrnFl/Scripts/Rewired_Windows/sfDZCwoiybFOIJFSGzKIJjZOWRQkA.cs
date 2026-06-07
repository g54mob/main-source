using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class sfDZCwoiybFOIJFSGzKIJjZOWRQkA
{
	private readonly List<Delegate> dOjjimZhqvpuMcaqpXLVAyFyDvhU;

	private readonly IntPtr AqCZCgzOwSrJRVcLnBtxBcGjhydHA;

	public IntPtr xBcoZGNgjFHBlnBwrrDhjDjpecwDA => AqCZCgzOwSrJRVcLnBtxBcGjhydHA;

	public sfDZCwoiybFOIJFSGzKIJjZOWRQkA(int P_0)
	{
		AqCZCgzOwSrJRVcLnBtxBcGjhydHA = Marshal.AllocHGlobal(IntPtr.Size * P_0);
		dOjjimZhqvpuMcaqpXLVAyFyDvhU = new List<Delegate>();
	}

	public unsafe void PQJKqVukAwaEaAcjMrGxrtSOFQxb(Delegate P_0)
	{
		int count = dOjjimZhqvpuMcaqpXLVAyFyDvhU.Count;
		dOjjimZhqvpuMcaqpXLVAyFyDvhU.Add(P_0);
		((IntPtr*)(void*)AqCZCgzOwSrJRVcLnBtxBcGjhydHA)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
