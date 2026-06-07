using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class zOtkPkinsgzlVzMersRmaerBFJMH
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int GdYWXtfbqjzLfChAbrvZpCkGaYMHA(void* deviceInstance, IntPtr data);

	private readonly IntPtr IaPhmwkNZgWinhXGQzfLxGYdnGmoA;

	private readonly GdYWXtfbqjzLfChAbrvZpCkGaYMHA OKZTVSSaXkWCKmHgHrfBGIPNRgrj;

	[CompilerGenerated]
	private List<zxeoTygAWuodzEbOIdaTbdNJPkfzA> vesLGBaSoCBPKhWOSHLpPPhlRazlA;

	public IntPtr jkODiUVAJjIruAMPmutfpBUhNvll => IaPhmwkNZgWinhXGQzfLxGYdnGmoA;

	public List<zxeoTygAWuodzEbOIdaTbdNJPkfzA> FYHcTdISVqiTQFaNDJzXRfgKgsCJ
	{
		[CompilerGenerated]
		get
		{
			return vesLGBaSoCBPKhWOSHLpPPhlRazlA;
		}
		[CompilerGenerated]
		private set
		{
			vesLGBaSoCBPKhWOSHLpPPhlRazlA = list;
		}
	}

	public unsafe zOtkPkinsgzlVzMersRmaerBFJMH()
	{
		OKZTVSSaXkWCKmHgHrfBGIPNRgrj = qZEkUqJqfXgaEcWnvKwPkzQdJDiWA;
		IaPhmwkNZgWinhXGQzfLxGYdnGmoA = Marshal.GetFunctionPointerForDelegate(OKZTVSSaXkWCKmHgHrfBGIPNRgrj);
		FYHcTdISVqiTQFaNDJzXRfgKgsCJ = new List<zxeoTygAWuodzEbOIdaTbdNJPkfzA>();
	}

	[MonoPInvokeCallback(typeof(GdYWXtfbqjzLfChAbrvZpCkGaYMHA))]
	private unsafe static int qZEkUqJqfXgaEcWnvKwPkzQdJDiWA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<zOtkPkinsgzlVzMersRmaerBFJMH>(instanceId, out var instance))
		{
			return 1;
		}
		zxeoTygAWuodzEbOIdaTbdNJPkfzA zxeoTygAWuodzEbOIdaTbdNJPkfzA2 = new zxeoTygAWuodzEbOIdaTbdNJPkfzA();
		zxeoTygAWuodzEbOIdaTbdNJPkfzA2.dABcEXiyGJomkHenDQryLpERqodj(ref *(zxeoTygAWuodzEbOIdaTbdNJPkfzA.wFQnUqukSPIOCDVHAYNZYntURaGJ*)P_0);
		instance.FYHcTdISVqiTQFaNDJzXRfgKgsCJ.Add(zxeoTygAWuodzEbOIdaTbdNJPkfzA2);
		return 1;
	}
}
