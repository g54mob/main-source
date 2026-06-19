using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class kdmWXnHVsVHmScWjLKNqHCEQouxe
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int TxDNvqMhLUrzeZzsVKPRCJPPPrhs(void* deviceInstance, IntPtr data);

	private readonly IntPtr FsKFElcXkRvSeKIgyVDHpVjmqjBo;

	private readonly TxDNvqMhLUrzeZzsVKPRCJPPPrhs HBElENbHHJovFhcxlJtXxWqOoPKH;

	[CompilerGenerated]
	private List<oAfWbvFtzBgLaRIiknILWPaYvJGR> oUjYmYBWZxTjNLpkgdhbmuKgfNEdA;

	public IntPtr sIJhiVmkXETPbBrPMCFxWDzykSUF => FsKFElcXkRvSeKIgyVDHpVjmqjBo;

	public List<oAfWbvFtzBgLaRIiknILWPaYvJGR> WvAQncrgLZGBROlMxdSLyZxZRGdC
	{
		[CompilerGenerated]
		get
		{
			return oUjYmYBWZxTjNLpkgdhbmuKgfNEdA;
		}
		[CompilerGenerated]
		private set
		{
			oUjYmYBWZxTjNLpkgdhbmuKgfNEdA = list;
		}
	}

	public unsafe kdmWXnHVsVHmScWjLKNqHCEQouxe()
	{
		HBElENbHHJovFhcxlJtXxWqOoPKH = nTFAajGqQcuGVMBVBrCXoApqIiNSA;
		FsKFElcXkRvSeKIgyVDHpVjmqjBo = Marshal.GetFunctionPointerForDelegate(HBElENbHHJovFhcxlJtXxWqOoPKH);
		WvAQncrgLZGBROlMxdSLyZxZRGdC = new List<oAfWbvFtzBgLaRIiknILWPaYvJGR>();
	}

	[MonoPInvokeCallback(typeof(TxDNvqMhLUrzeZzsVKPRCJPPPrhs))]
	private unsafe static int nTFAajGqQcuGVMBVBrCXoApqIiNSA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<kdmWXnHVsVHmScWjLKNqHCEQouxe>(instanceId, out var instance))
		{
			return 1;
		}
		oAfWbvFtzBgLaRIiknILWPaYvJGR oAfWbvFtzBgLaRIiknILWPaYvJGR2 = new oAfWbvFtzBgLaRIiknILWPaYvJGR();
		oAfWbvFtzBgLaRIiknILWPaYvJGR2.imUUvWRnmsYlpMDrzabawdVYZpGd(ref *(oAfWbvFtzBgLaRIiknILWPaYvJGR.vnHXvrJdtmisFICpieEVdEOHConr*)P_0);
		instance.WvAQncrgLZGBROlMxdSLyZxZRGdC.Add(oAfWbvFtzBgLaRIiknILWPaYvJGR2);
		return 1;
	}
}
