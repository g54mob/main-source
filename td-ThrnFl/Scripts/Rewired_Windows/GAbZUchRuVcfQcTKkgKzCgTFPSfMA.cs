using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class GAbZUchRuVcfQcTKkgKzCgTFPSfMA
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int PiCCnAHLjzqnCfhZsvqtvFRlicQhA(void* deviceInstance, IntPtr data);

	private readonly IntPtr QgExjnEWwYKOMnFQULpYZJJDJvSt;

	private readonly PiCCnAHLjzqnCfhZsvqtvFRlicQhA OYXcochMKJJecqJJEjSWQgtRAmZPA;

	[CompilerGenerated]
	private List<VIJcgXHrkGHvUNNEFomlijhwNULZA> JdKdFyzjFQgPTkqFQVtADqiTNvIJ;

	public IntPtr cfrWIcJYBWjnGDgLzgbORSahyxzH => QgExjnEWwYKOMnFQULpYZJJDJvSt;

	public List<VIJcgXHrkGHvUNNEFomlijhwNULZA> ZwaAFqDtVawjULOASUlzzQNFoagy
	{
		[CompilerGenerated]
		get
		{
			return JdKdFyzjFQgPTkqFQVtADqiTNvIJ;
		}
		[CompilerGenerated]
		private set
		{
			JdKdFyzjFQgPTkqFQVtADqiTNvIJ = jdKdFyzjFQgPTkqFQVtADqiTNvIJ;
		}
	}

	public unsafe GAbZUchRuVcfQcTKkgKzCgTFPSfMA()
	{
		OYXcochMKJJecqJJEjSWQgtRAmZPA = fjoaHVFvqXNOQRhnGBYOoXxmClWDb;
		QgExjnEWwYKOMnFQULpYZJJDJvSt = Marshal.GetFunctionPointerForDelegate(OYXcochMKJJecqJJEjSWQgtRAmZPA);
		ZwaAFqDtVawjULOASUlzzQNFoagy = new List<VIJcgXHrkGHvUNNEFomlijhwNULZA>();
	}

	[MonoPInvokeCallback(typeof(PiCCnAHLjzqnCfhZsvqtvFRlicQhA))]
	private unsafe static int fjoaHVFvqXNOQRhnGBYOoXxmClWDb(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<GAbZUchRuVcfQcTKkgKzCgTFPSfMA>(instanceId, out var instance))
		{
			return 1;
		}
		VIJcgXHrkGHvUNNEFomlijhwNULZA item = new VIJcgXHrkGHvUNNEFomlijhwNULZA((IntPtr)P_0);
		instance.ZwaAFqDtVawjULOASUlzzQNFoagy.Add(item);
		return 1;
	}
}
