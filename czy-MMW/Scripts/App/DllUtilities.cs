using System;
using System.Runtime.InteropServices;
using UnityEngine;

public static class DllUtilities
{
	public const string InternalLibraryName = "__Internal";

	public const string LibraryName = "dpcPlatform";

	public const string AudioLibraryName = "decompressAudio";

	public const string ArcadeLibraryName = "arcadex";

	public static bool AreLibrariesLoaded(out string missingLibraryFilename)
	{
		missingLibraryFilename = null;
		try
		{
			EmptyAudioLibraryFunction();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			missingLibraryFilename = "decompressAudio";
		}
		try
		{
			EmptyLibraryFunction();
		}
		catch (Exception exception2)
		{
			Debug.LogException(exception2);
			missingLibraryFilename = "dpcPlatform";
		}
		if (missingLibraryFilename != null)
		{
			missingLibraryFilename += ".dll";
			return false;
		}
		return true;
	}

	[DllImport("dpcPlatform", CallingConvention = CallingConvention.Cdecl, EntryPoint = "EmptyFunction")]
	private static extern int EmptyLibraryFunction();

	[DllImport("decompressAudio", CallingConvention = CallingConvention.Cdecl, EntryPoint = "EmptyFunction")]
	private static extern int EmptyAudioLibraryFunction();
}
