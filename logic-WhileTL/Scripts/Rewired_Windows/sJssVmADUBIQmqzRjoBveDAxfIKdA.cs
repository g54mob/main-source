using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal class sJssVmADUBIQmqzRjoBveDAxfIKdA
{
	public IntPtr kWRTOHULzKpCRgNuSFABYNYVScy;

	public sJssVmADUBIQmqzRjoBveDAxfIKdA(IntPtr P_0)
	{
		kWRTOHULzKpCRgNuSFABYNYVScy = P_0;
	}

	public unsafe sJssVmADUBIQmqzRjoBveDAxfIKdA(void* P_0)
	{
		kWRTOHULzKpCRgNuSFABYNYVScy = new IntPtr(P_0);
	}

	[SpecialName]
	public static IntPtr EhlIBZuRXpPFFALwqxqKexCFDuzb(sJssVmADUBIQmqzRjoBveDAxfIKdA P_0)
	{
		return P_0.kWRTOHULzKpCRgNuSFABYNYVScy;
	}

	[SpecialName]
	public static sJssVmADUBIQmqzRjoBveDAxfIKdA hWHeOZGaMchoUxcjVNFKgCLOCcPd(IntPtr P_0)
	{
		return new sJssVmADUBIQmqzRjoBveDAxfIKdA(P_0);
	}

	[SpecialName]
	public unsafe static void* hWHeOZGaMchoUxcjVNFKgCLOCcPd(sJssVmADUBIQmqzRjoBveDAxfIKdA P_0)
	{
		return (void*)P_0.kWRTOHULzKpCRgNuSFABYNYVScy;
	}

	[SpecialName]
	public unsafe static sJssVmADUBIQmqzRjoBveDAxfIKdA EhlIBZuRXpPFFALwqxqKexCFDuzb(void* P_0)
	{
		return new sJssVmADUBIQmqzRjoBveDAxfIKdA(P_0);
	}

	public virtual string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { kWRTOHULzKpCRgNuSFABYNYVScy });
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "{0}", new object[1] { kWRTOHULzKpCRgNuSFABYNYVScy.ToString(P_0) });
	}

	public virtual int bmOcwbrzltTGalVFCIlUiIeugfGh()
	{
		return kWRTOHULzKpCRgNuSFABYNYVScy.ToInt32();
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(sJssVmADUBIQmqzRjoBveDAxfIKdA P_0)
	{
		return kWRTOHULzKpCRgNuSFABYNYVScy == P_0.kWRTOHULzKpCRgNuSFABYNYVScy;
	}

	public virtual bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if ((object)P_0.GetType() != typeof(sJssVmADUBIQmqzRjoBveDAxfIKdA))
		{
			return false;
		}
		return XGTrzxcWbPBiyHnRYfIhrjXAmNvN((sJssVmADUBIQmqzRjoBveDAxfIKdA)P_0);
	}
}
