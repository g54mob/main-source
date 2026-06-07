using System;
using System.Runtime.InteropServices;

internal struct lJCiuwBkqTmesdSukyCbJDJeTRC
{
	private IntPtr eXcLIaXlAsTxIjAKdPxtiZbpLYx;

	private int ZqrCYTDAAMNixgdHYwfgZDgVKYpy;

	private IntPtr xnKZtIRzwkVIEMTguSMZpQxliZT;

	private IntPtr hsrgYOHNDNBIuqHmybhncgbOcEI;

	private IntPtr MHsSrBUymsbJfVzgJxNQlwZVcIl;

	public IntPtr HWnd
	{
		get
		{
			return eXcLIaXlAsTxIjAKdPxtiZbpLYx;
		}
		set
		{
			eXcLIaXlAsTxIjAKdPxtiZbpLYx = value;
		}
	}

	public int Msg
	{
		get
		{
			return ZqrCYTDAAMNixgdHYwfgZDgVKYpy;
		}
		set
		{
			ZqrCYTDAAMNixgdHYwfgZDgVKYpy = value;
		}
	}

	public IntPtr WParam
	{
		get
		{
			return xnKZtIRzwkVIEMTguSMZpQxliZT;
		}
		set
		{
			xnKZtIRzwkVIEMTguSMZpQxliZT = value;
		}
	}

	public IntPtr LParam
	{
		get
		{
			return hsrgYOHNDNBIuqHmybhncgbOcEI;
		}
		set
		{
			hsrgYOHNDNBIuqHmybhncgbOcEI = value;
		}
	}

	public IntPtr Result
	{
		get
		{
			return MHsSrBUymsbJfVzgJxNQlwZVcIl;
		}
		set
		{
			MHsSrBUymsbJfVzgJxNQlwZVcIl = value;
		}
	}

	public object oatXbRRgIWIJXtnnotRJmAsbBAq(Type P_0)
	{
		return Marshal.PtrToStructure(hsrgYOHNDNBIuqHmybhncgbOcEI, P_0);
	}

	public static lJCiuwBkqTmesdSukyCbJDJeTRC AMeJMNvnyBBLKGPtCVsgJOjWefz(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3)
	{
		return new lJCiuwBkqTmesdSukyCbJDJeTRC
		{
			eXcLIaXlAsTxIjAKdPxtiZbpLYx = P_0,
			ZqrCYTDAAMNixgdHYwfgZDgVKYpy = P_1,
			xnKZtIRzwkVIEMTguSMZpQxliZT = P_2,
			hsrgYOHNDNBIuqHmybhncgbOcEI = P_3,
			MHsSrBUymsbJfVzgJxNQlwZVcIl = IntPtr.Zero
		};
	}

	public override bool Equals(object o)
	{
		if (!(o is lJCiuwBkqTmesdSukyCbJDJeTRC))
		{
			return false;
		}
		lJCiuwBkqTmesdSukyCbJDJeTRC lJCiuwBkqTmesdSukyCbJDJeTRC2 = (lJCiuwBkqTmesdSukyCbJDJeTRC)o;
		if (eXcLIaXlAsTxIjAKdPxtiZbpLYx == lJCiuwBkqTmesdSukyCbJDJeTRC2.eXcLIaXlAsTxIjAKdPxtiZbpLYx && ZqrCYTDAAMNixgdHYwfgZDgVKYpy == lJCiuwBkqTmesdSukyCbJDJeTRC2.ZqrCYTDAAMNixgdHYwfgZDgVKYpy && xnKZtIRzwkVIEMTguSMZpQxliZT == lJCiuwBkqTmesdSukyCbJDJeTRC2.xnKZtIRzwkVIEMTguSMZpQxliZT && hsrgYOHNDNBIuqHmybhncgbOcEI == lJCiuwBkqTmesdSukyCbJDJeTRC2.hsrgYOHNDNBIuqHmybhncgbOcEI)
		{
			return MHsSrBUymsbJfVzgJxNQlwZVcIl == lJCiuwBkqTmesdSukyCbJDJeTRC2.MHsSrBUymsbJfVzgJxNQlwZVcIl;
		}
		return false;
	}

	public static bool operator !=(lJCiuwBkqTmesdSukyCbJDJeTRC a, lJCiuwBkqTmesdSukyCbJDJeTRC b)
	{
		return !a.Equals(b);
	}

	public static bool operator ==(lJCiuwBkqTmesdSukyCbJDJeTRC a, lJCiuwBkqTmesdSukyCbJDJeTRC b)
	{
		return a.Equals(b);
	}

	public override int GetHashCode()
	{
		return ((int)eXcLIaXlAsTxIjAKdPxtiZbpLYx << 4) | ZqrCYTDAAMNixgdHYwfgZDgVKYpy;
	}

	public override string ToString()
	{
		return string.Empty;
	}
}
