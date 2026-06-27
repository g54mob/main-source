using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class NeycCTVVKRmWmnFWlJbqKfOMisUG
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int yrRWVEANIWwIYIDfnnWJRVPTKrEU(void* deviceInstance, IntPtr data);

	private readonly IntPtr aVYEcPiwhVZfMTBnOGIHnifihlubb;

	private readonly yrRWVEANIWwIYIDfnnWJRVPTKrEU yVYRljpIoVRMvoqNRWYRcmZWgtpC;

	[CompilerGenerated]
	private List<RCbrBLDngHgaSCZnWWTNJSaCQXlM> JSlLMmLCIlgQbhAnQzejijQaMJhAA;

	public IntPtr NONTlfsBxKsVRGbeadDzXhtqeoxjA => aVYEcPiwhVZfMTBnOGIHnifihlubb;

	public List<RCbrBLDngHgaSCZnWWTNJSaCQXlM> ndGmeKxDnXGlvFkuLAaZpxVBKLUm
	{
		[CompilerGenerated]
		get
		{
			return JSlLMmLCIlgQbhAnQzejijQaMJhAA;
		}
		[CompilerGenerated]
		private set
		{
			JSlLMmLCIlgQbhAnQzejijQaMJhAA = jSlLMmLCIlgQbhAnQzejijQaMJhAA;
		}
	}

	public unsafe NeycCTVVKRmWmnFWlJbqKfOMisUG()
	{
		yVYRljpIoVRMvoqNRWYRcmZWgtpC = ElXJCDeCToBzrEwWlwVNLLnqCouIA;
		aVYEcPiwhVZfMTBnOGIHnifihlubb = Marshal.GetFunctionPointerForDelegate(yVYRljpIoVRMvoqNRWYRcmZWgtpC);
		ndGmeKxDnXGlvFkuLAaZpxVBKLUm = new List<RCbrBLDngHgaSCZnWWTNJSaCQXlM>();
	}

	[MonoPInvokeCallback(typeof(yrRWVEANIWwIYIDfnnWJRVPTKrEU))]
	private unsafe static int ElXJCDeCToBzrEwWlwVNLLnqCouIA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<NeycCTVVKRmWmnFWlJbqKfOMisUG>(instanceId, out var instance))
		{
			return 1;
		}
		RCbrBLDngHgaSCZnWWTNJSaCQXlM rCbrBLDngHgaSCZnWWTNJSaCQXlM = new RCbrBLDngHgaSCZnWWTNJSaCQXlM();
		rCbrBLDngHgaSCZnWWTNJSaCQXlM.HvEiqiTnwolUPTrIJvhsbabCJVvR(ref *(RCbrBLDngHgaSCZnWWTNJSaCQXlM.GvPvXBPjkiPEnFxkWjIXaCOLeNSJ*)P_0);
		instance.ndGmeKxDnXGlvFkuLAaZpxVBKLUm.Add(rCbrBLDngHgaSCZnWWTNJSaCQXlM);
		return 1;
	}
}
