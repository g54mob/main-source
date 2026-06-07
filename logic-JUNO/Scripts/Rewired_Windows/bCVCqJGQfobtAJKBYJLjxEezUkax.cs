using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class bCVCqJGQfobtAJKBYJLjxEezUkax
{
	[CompilerGenerated]
	private string xVhCyOeTbnaWvauRaHERepXKCukdA;

	[CompilerGenerated]
	private HLIHggermciamhEKNxfavGKToBMk UkqfeVHvqzyNCZSTAUmGeAqmcOQj;

	[CompilerGenerated]
	private IntPtr daqPmdvZEIwhEPfWwnYWpfXodNws;

	public string nTwUtsGqgBIXvwUvMRUuOqdUZYfU
	{
		[CompilerGenerated]
		get
		{
			return xVhCyOeTbnaWvauRaHERepXKCukdA;
		}
		[CompilerGenerated]
		set
		{
			xVhCyOeTbnaWvauRaHERepXKCukdA = text;
		}
	}

	public HLIHggermciamhEKNxfavGKToBMk WxlEpCSGaGkICilIDDWXFDjBLMBS
	{
		[CompilerGenerated]
		get
		{
			return UkqfeVHvqzyNCZSTAUmGeAqmcOQj;
		}
		[CompilerGenerated]
		set
		{
			UkqfeVHvqzyNCZSTAUmGeAqmcOQj = ukqfeVHvqzyNCZSTAUmGeAqmcOQj;
		}
	}

	public IntPtr IeNrJeflhidrgFBoJfNwkXPGRpdW
	{
		[CompilerGenerated]
		get
		{
			return daqPmdvZEIwhEPfWwnYWpfXodNws;
		}
		[CompilerGenerated]
		set
		{
			daqPmdvZEIwhEPfWwnYWpfXodNws = intPtr;
		}
	}

	public bCVCqJGQfobtAJKBYJLjxEezUkax()
	{
	}

	internal bCVCqJGQfobtAJKBYJLjxEezUkax(ref buMUyDRZYHJJFRsRWOsUCuVWuBBq P_0, string P_1, IntPtr P_2)
	{
		nTwUtsGqgBIXvwUvMRUuOqdUZYfU = P_1;
		IeNrJeflhidrgFBoJfNwkXPGRpdW = P_2;
		WxlEpCSGaGkICilIDDWXFDjBLMBS = P_0.lSUporQnnwFKheUjawfSiQMdpuWaA;
	}

	internal static bCVCqJGQfobtAJKBYJLjxEezUkax FZnMfANDWEApWgeljPRjthaMldXSA(ref buMUyDRZYHJJFRsRWOsUCuVWuBBq P_0, string P_1, IntPtr P_2)
	{
		bCVCqJGQfobtAJKBYJLjxEezUkax bCVCqJGQfobtAJKBYJLjxEezUkax2 = null;
		return P_0.lSUporQnnwFKheUjawfSiQMdpuWaA switch
		{
			HLIHggermciamhEKNxfavGKToBMk.HumanInputDevice => new nyEvhzfRtSEWllouYFPGmjQMSfbn(ref P_0, P_1, P_2), 
			HLIHggermciamhEKNxfavGKToBMk.Keyboard => new tcEJjcarSSOuYnfjLbYvLqDfCsncA(ref P_0, P_1, P_2), 
			HLIHggermciamhEKNxfavGKToBMk.Mouse => new toTdNCDgWamwLDVyeHjZdQmwvMthc(ref P_0, P_1, P_2), 
			_ => throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unsupported Device Type [{0}]", (int)P_0.lSUporQnnwFKheUjawfSiQMdpuWaA)), 
		};
	}
}
