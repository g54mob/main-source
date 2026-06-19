using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class odNSpYIDqgLwBwGmBqaGUrGQpMUi
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int opQQfGEAAGZLaKGZolZiZCBdSjXx(void* deviceInstance, IntPtr data);

	private readonly IntPtr kaeftyeJtyhNpdNZbwPBdObMjuxFA;

	private readonly opQQfGEAAGZLaKGZolZiZCBdSjXx dfdFlchIaSmKNsFPiuzrKbWpzmP;

	[CompilerGenerated]
	private List<dtZDbMajlFOwudnnFjTFezFoRgHgA> kJbkuKJpxGqcqPBHSeOxkiTXNztz;

	public IntPtr HGTCnzijxbyyyaofGbvgjmcGcxnFb => kaeftyeJtyhNpdNZbwPBdObMjuxFA;

	public List<dtZDbMajlFOwudnnFjTFezFoRgHgA> cTXcEvReRGKgXqVbgSxdYHcdsyen
	{
		[CompilerGenerated]
		get
		{
			return kJbkuKJpxGqcqPBHSeOxkiTXNztz;
		}
		[CompilerGenerated]
		private set
		{
			kJbkuKJpxGqcqPBHSeOxkiTXNztz = list;
		}
	}

	public unsafe odNSpYIDqgLwBwGmBqaGUrGQpMUi()
	{
		dfdFlchIaSmKNsFPiuzrKbWpzmP = NfFxwYBNTsnYXgYxZyjVVFKfmkNj;
		kaeftyeJtyhNpdNZbwPBdObMjuxFA = Marshal.GetFunctionPointerForDelegate(dfdFlchIaSmKNsFPiuzrKbWpzmP);
		cTXcEvReRGKgXqVbgSxdYHcdsyen = new List<dtZDbMajlFOwudnnFjTFezFoRgHgA>();
	}

	[MonoPInvokeCallback(typeof(opQQfGEAAGZLaKGZolZiZCBdSjXx))]
	private unsafe static int NfFxwYBNTsnYXgYxZyjVVFKfmkNj(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<odNSpYIDqgLwBwGmBqaGUrGQpMUi>(instanceId, out var instance))
		{
			return 1;
		}
		dtZDbMajlFOwudnnFjTFezFoRgHgA dtZDbMajlFOwudnnFjTFezFoRgHgA2 = new dtZDbMajlFOwudnnFjTFezFoRgHgA();
		dtZDbMajlFOwudnnFjTFezFoRgHgA2.FmleOpWzGVWAyGtcKgaYoIEImuct(ref *(dtZDbMajlFOwudnnFjTFezFoRgHgA.NHpAzAmkBDcaIIessXgNaGEeXrVcA*)P_0);
		instance.cTXcEvReRGKgXqVbgSxdYHcdsyen.Add(dtZDbMajlFOwudnnFjTFezFoRgHgA2);
		return 1;
	}
}
