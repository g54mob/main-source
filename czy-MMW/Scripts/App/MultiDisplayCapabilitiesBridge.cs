using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class MultiDisplayCapabilitiesBridge
{
	public const string LibraryName = "dpcPlatform";

	public static int GetDisplayCount()
	{
		try
		{
			return GetDisplayCountNative();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			return 1;
		}
	}

	public static int GetActiveDisplayIndex()
	{
		try
		{
			return GetActiveDisplayIndexNative();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			return 1;
		}
	}

	public static bool SetActiveDisplayIndex(int index)
	{
		try
		{
			return SetActiveDisplayIndexNative(index);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			return false;
		}
	}

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetDisplayCount")]
	private static extern int GetDisplayCountNative();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "GetActiveDisplayIndex")]
	private static extern int GetActiveDisplayIndexNative();

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "SetActiveDisplay")]
	private static extern bool SetActiveDisplayIndexNative(int displayIndex);
}
