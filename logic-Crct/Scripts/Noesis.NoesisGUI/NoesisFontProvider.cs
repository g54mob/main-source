using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Noesis;

public class NoesisFontProvider : FontProvider
{
	private struct Face
	{
		public int index;

		public string family;

		public FontWeight weight;

		public FontStyle style;

		public FontStretch stretch;
	}

	private delegate void LockFontCallback(string folder, string filename, out IntPtr handle, out IntPtr addr, out int length);

	private delegate void UnlockFontCallback(IntPtr handle);

	public struct Value
	{
		public int refs;

		public NoesisFont font;
	}

	private static LockFontCallback _lockFont;

	private static UnlockFontCallback _unlockFont;

	public static NoesisFontProvider instance;

	private Dictionary<string, Value> _fonts;

	private NoesisFontProvider()
		: base((IntPtr)0, cMemoryOwn: false)
	{
	}

	public void Register(string uri, NoesisFont font)
	{
	}

	public void Unregister(string uri)
	{
	}

	public void ReloadFont(string uri)
	{
	}

	[MonoPInvokeCallback(typeof(LockFontCallback))]
	private static void LockFont(string folder, string filename, out IntPtr handle, out IntPtr addr, out int length)
	{
		handle = default(IntPtr);
		addr = default(IntPtr);
		length = default(int);
	}

	[MonoPInvokeCallback(typeof(UnlockFontCallback))]
	private static void UnlockFont(IntPtr handle)
	{
	}

	internal new static IntPtr Extend(string typeName)
	{
		return (IntPtr)0;
	}

	[PreserveSig]
	private static extern IntPtr Noesis_FontProviderExtend(IntPtr typeName);

	[PreserveSig]
	private static extern void Noesis_FontProviderSetLockUnlockCallbacks(LockFontCallback lockFont, UnlockFontCallback unlockFont);
}
