using System;
using System.Runtime.CompilerServices;
using Rewired;

internal struct ebDaYFBaqVEVAHEpRPHAjwoJSXKbA : IEquatable<ebDaYFBaqVEVAHEpRPHAjwoJSXKbA>
{
	public KeyboardKeyCode MbIKsajrEcpOKixlUWQDVkKXZVmf;

	public ModifierKey ZVGBCFWwSMwrvkmhchYBDGexMRIz;

	public ModifierKey LzPuucCaNIZWYscruryVEDhQdpFI;

	public ModifierKey DxatfPgqxANQqxtOanFgOwEvkByI;

	public ebDaYFBaqVEVAHEpRPHAjwoJSXKbA(KeyboardKeyCode P_0, ModifierKey P_1, ModifierKey P_2, ModifierKey P_3)
	{
		MbIKsajrEcpOKixlUWQDVkKXZVmf = P_0;
		ZVGBCFWwSMwrvkmhchYBDGexMRIz = P_1;
		LzPuucCaNIZWYscruryVEDhQdpFI = P_2;
		DxatfPgqxANQqxtOanFgOwEvkByI = P_3;
	}

	public void yHXyLuusuMfPnwXjNnuARvkGcovj()
	{
		if (MbIKsajrEcpOKixlUWQDVkKXZVmf != KeyboardKeyCode.None)
		{
			MbIKsajrEcpOKixlUWQDVkKXZVmf = KeyboardKeyCode.None;
		}
		if (ZVGBCFWwSMwrvkmhchYBDGexMRIz != ModifierKey.None)
		{
			ZVGBCFWwSMwrvkmhchYBDGexMRIz = ModifierKey.None;
		}
		if (LzPuucCaNIZWYscruryVEDhQdpFI != ModifierKey.None)
		{
			LzPuucCaNIZWYscruryVEDhQdpFI = ModifierKey.None;
		}
		if (DxatfPgqxANQqxtOanFgOwEvkByI != ModifierKey.None)
		{
			DxatfPgqxANQqxtOanFgOwEvkByI = ModifierKey.None;
		}
	}

	public bool Equals(ebDaYFBaqVEVAHEpRPHAjwoJSXKbA other)
	{
		if (MbIKsajrEcpOKixlUWQDVkKXZVmf == other.MbIKsajrEcpOKixlUWQDVkKXZVmf && ZVGBCFWwSMwrvkmhchYBDGexMRIz == other.ZVGBCFWwSMwrvkmhchYBDGexMRIz && LzPuucCaNIZWYscruryVEDhQdpFI == other.LzPuucCaNIZWYscruryVEDhQdpFI)
		{
			return DxatfPgqxANQqxtOanFgOwEvkByI == other.DxatfPgqxANQqxtOanFgOwEvkByI;
		}
		return false;
	}

	bool IEquatable<ebDaYFBaqVEVAHEpRPHAjwoJSXKbA>.Equals(ebDaYFBaqVEVAHEpRPHAjwoJSXKbA other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool poHFbatWMCxOkMzItUouKPNxvKci(object P_0)
	{
		if (P_0 == null || !(P_0 is ebDaYFBaqVEVAHEpRPHAjwoJSXKbA))
		{
			return false;
		}
		return Equals((ebDaYFBaqVEVAHEpRPHAjwoJSXKbA)P_0);
	}

	public int wjdpmnxasxuzaWHQKrKZvgXZhjjH()
	{
		return (((17 * 29 + MbIKsajrEcpOKixlUWQDVkKXZVmf.GetHashCode()) * 29 + ZVGBCFWwSMwrvkmhchYBDGexMRIz.GetHashCode()) * 29 + LzPuucCaNIZWYscruryVEDhQdpFI.GetHashCode()) * 29 + DxatfPgqxANQqxtOanFgOwEvkByI.GetHashCode();
	}

	[SpecialName]
	public static bool ipRaTHhRHKhfJYmQCHVjNNCvebVDb(ebDaYFBaqVEVAHEpRPHAjwoJSXKbA P_0, ebDaYFBaqVEVAHEpRPHAjwoJSXKbA P_1)
	{
		if (P_0.MbIKsajrEcpOKixlUWQDVkKXZVmf == P_1.MbIKsajrEcpOKixlUWQDVkKXZVmf && P_0.ZVGBCFWwSMwrvkmhchYBDGexMRIz == P_1.ZVGBCFWwSMwrvkmhchYBDGexMRIz && P_0.LzPuucCaNIZWYscruryVEDhQdpFI == P_1.LzPuucCaNIZWYscruryVEDhQdpFI)
		{
			return P_0.DxatfPgqxANQqxtOanFgOwEvkByI == P_1.DxatfPgqxANQqxtOanFgOwEvkByI;
		}
		return false;
	}

	[SpecialName]
	public static bool eGfAhgwRmpifGljDtZgMFzxhLlzC(ebDaYFBaqVEVAHEpRPHAjwoJSXKbA P_0, ebDaYFBaqVEVAHEpRPHAjwoJSXKbA P_1)
	{
		return !ipRaTHhRHKhfJYmQCHVjNNCvebVDb(P_0, P_1);
	}
}
