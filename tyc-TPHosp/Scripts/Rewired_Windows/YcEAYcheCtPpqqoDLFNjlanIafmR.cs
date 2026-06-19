using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

internal class YcEAYcheCtPpqqoDLFNjlanIafmR
{
	private readonly List<Delegate> CyqillXfhivJcbFZjinqnkrQwOe;

	private readonly IntPtr viRQXSJphhpVbWuXCcOnMOCcBIbJ;

	public IntPtr Pointer => viRQXSJphhpVbWuXCcOnMOCcBIbJ;

	public YcEAYcheCtPpqqoDLFNjlanIafmR(int numberOfCallbackMethods)
	{
		viRQXSJphhpVbWuXCcOnMOCcBIbJ = Marshal.AllocHGlobal(IntPtr.Size * numberOfCallbackMethods);
		CyqillXfhivJcbFZjinqnkrQwOe = new List<Delegate>();
	}

	public unsafe void aDcfFchGbJbrAnnMPQrMeekPAxdF(Delegate P_0)
	{
		int count = CyqillXfhivJcbFZjinqnkrQwOe.Count;
		CyqillXfhivJcbFZjinqnkrQwOe.Add(P_0);
		((IntPtr*)(void*)viRQXSJphhpVbWuXCcOnMOCcBIbJ)[count] = Marshal.GetFunctionPointerForDelegate(P_0);
	}
}
