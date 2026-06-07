using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired.Utils.Attributes;
using Rewired.Utils.Classes.Utility;

internal class wtOkVLdMGhWjfSkbJSibzpExKysk
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	private unsafe delegate int hNfmajFgNLEhpKHoPkUbTQIHQSBqA(void* deviceInstance, IntPtr data);

	private readonly IntPtr aKffcMUMWqBGbJZtjWBYKGAfVZBQA;

	private readonly hNfmajFgNLEhpKHoPkUbTQIHQSBqA sqeQfBIEarCePjxatBiYgtmxWKMTA;

	[CompilerGenerated]
	private List<bnkLdyjjEoEzbjlveySrcoiIPsMq> zrdqFDtfGyqccMqkrdCqQbrflXzb;

	public IntPtr OXENmPNvIcbSfjaOQQxMYfoTYnce => aKffcMUMWqBGbJZtjWBYKGAfVZBQA;

	public List<bnkLdyjjEoEzbjlveySrcoiIPsMq> doXnGDZNhMohjhsjrhHreZOfQIzW
	{
		[CompilerGenerated]
		get
		{
			return zrdqFDtfGyqccMqkrdCqQbrflXzb;
		}
		[CompilerGenerated]
		private set
		{
			zrdqFDtfGyqccMqkrdCqQbrflXzb = list;
		}
	}

	public unsafe wtOkVLdMGhWjfSkbJSibzpExKysk()
	{
		sqeQfBIEarCePjxatBiYgtmxWKMTA = VBXoIqbMKlJUlFnIjjqSbKeKWNRgA;
		aKffcMUMWqBGbJZtjWBYKGAfVZBQA = Marshal.GetFunctionPointerForDelegate(sqeQfBIEarCePjxatBiYgtmxWKMTA);
		doXnGDZNhMohjhsjrhHreZOfQIzW = new List<bnkLdyjjEoEzbjlveySrcoiIPsMq>();
	}

	[MonoPInvokeCallback(typeof(hNfmajFgNLEhpKHoPkUbTQIHQSBqA))]
	private unsafe static int VBXoIqbMKlJUlFnIjjqSbKeKWNRgA(void* P_0, IntPtr P_1)
	{
		uint instanceId = (uint)P_1.ToInt32();
		if (!ObjectInstanceTracker.Default.TryGetInstance<wtOkVLdMGhWjfSkbJSibzpExKysk>(instanceId, out var instance))
		{
			return 1;
		}
		bnkLdyjjEoEzbjlveySrcoiIPsMq item = new bnkLdyjjEoEzbjlveySrcoiIPsMq((IntPtr)P_0);
		instance.doXnGDZNhMohjhsjrhHreZOfQIzW.Add(item);
		return 1;
	}
}
