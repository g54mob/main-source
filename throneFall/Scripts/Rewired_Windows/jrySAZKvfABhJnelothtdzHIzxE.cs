using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class jrySAZKvfABhJnelothtdzHIzxE
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int gEKgaDAsgcIEgsxQjCKwTvIZFGlEb(void* deviceInstance, IntPtr data);

	private readonly IntPtr tksLKJJgdoGLgdEOkiBvAeTMrZTGA;

	private readonly gEKgaDAsgcIEgsxQjCKwTvIZFGlEb BlkWypoWRolwyWolWnQBNTzhoYMt;

	[CompilerGenerated]
	private List<RCJiVKRenmELQcrTMnxzVKkmwYvj> hlsgpVQhEoSOSVYLKMxBhjrHKSCl;

	public IntPtr DetpvIEtyNSQAKtucubyUpyPYLmo => tksLKJJgdoGLgdEOkiBvAeTMrZTGA;

	public List<RCJiVKRenmELQcrTMnxzVKkmwYvj> yNXjmtxYBoZbIvJPSlrLrRpLxNmd
	{
		[CompilerGenerated]
		get
		{
			return hlsgpVQhEoSOSVYLKMxBhjrHKSCl;
		}
		[CompilerGenerated]
		private set
		{
			hlsgpVQhEoSOSVYLKMxBhjrHKSCl = list;
		}
	}

	public unsafe jrySAZKvfABhJnelothtdzHIzxE()
	{
		BlkWypoWRolwyWolWnQBNTzhoYMt = qbtcefEgjSlmkQgspOSxrxStJOTo;
		tksLKJJgdoGLgdEOkiBvAeTMrZTGA = Marshal.GetFunctionPointerForDelegate(BlkWypoWRolwyWolWnQBNTzhoYMt);
		yNXjmtxYBoZbIvJPSlrLrRpLxNmd = new List<RCJiVKRenmELQcrTMnxzVKkmwYvj>();
	}

	[MonoPInvokeCallback(typeof(gEKgaDAsgcIEgsxQjCKwTvIZFGlEb))]
	private unsafe static int qbtcefEgjSlmkQgspOSxrxStJOTo(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<jrySAZKvfABhJnelothtdzHIzxE>(instanceId, out var instance))
		{
			return 1;
		}
		RCJiVKRenmELQcrTMnxzVKkmwYvj rCJiVKRenmELQcrTMnxzVKkmwYvj = new RCJiVKRenmELQcrTMnxzVKkmwYvj();
		rCJiVKRenmELQcrTMnxzVKkmwYvj.kwtjFmruJabGTXBZGHShOLBCaAyo(ref *(RCJiVKRenmELQcrTMnxzVKkmwYvj.OdxcxoccmmgnEcydGIBPoPdLbRcPA*)P_0);
		instance.yNXjmtxYBoZbIvJPSlrLrRpLxNmd.Add(rCJiVKRenmELQcrTMnxzVKkmwYvj);
		return 1;
	}
}
