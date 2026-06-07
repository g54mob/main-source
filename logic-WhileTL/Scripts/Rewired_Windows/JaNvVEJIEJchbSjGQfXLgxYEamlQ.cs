using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Size = 4)]
internal struct JaNvVEJIEJchbSjGQfXLgxYEamlQ : IEquatable<JaNvVEJIEJchbSjGQfXLgxYEamlQ>
{
	private int mKAfSTkCrjcidjhQJzezQKbLNbjmA;

	public JaNvVEJIEJchbSjGQfXLgxYEamlQ(bool P_0)
	{
		mKAfSTkCrjcidjhQJzezQKbLNbjmA = (P_0 ? 1 : 0);
	}

	public bool Equals(JaNvVEJIEJchbSjGQfXLgxYEamlQ other)
	{
		return mKAfSTkCrjcidjhQJzezQKbLNbjmA == other.mKAfSTkCrjcidjhQJzezQKbLNbjmA;
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0 is JaNvVEJIEJchbSjGQfXLgxYEamlQ)
		{
			return Equals((JaNvVEJIEJchbSjGQfXLgxYEamlQ)P_0);
		}
		return false;
	}

	public int bmOcwbrzltTGalVFCIlUiIeugfGh()
	{
		return mKAfSTkCrjcidjhQJzezQKbLNbjmA;
	}

	[SpecialName]
	public static bool UxzrDeMrBdIYZHmpHMJBdoPkTemL(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0, JaNvVEJIEJchbSjGQfXLgxYEamlQ P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool ymVlplVHAhddfhnAkCmAWabpGMPgb(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0, JaNvVEJIEJchbSjGQfXLgxYEamlQ P_1)
	{
		return !P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool hWHeOZGaMchoUxcjVNFKgCLOCcPd(JaNvVEJIEJchbSjGQfXLgxYEamlQ P_0)
	{
		return P_0.mKAfSTkCrjcidjhQJzezQKbLNbjmA != 0;
	}

	[SpecialName]
	public static JaNvVEJIEJchbSjGQfXLgxYEamlQ hWHeOZGaMchoUxcjVNFKgCLOCcPd(bool P_0)
	{
		return new JaNvVEJIEJchbSjGQfXLgxYEamlQ(P_0);
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return $"{mKAfSTkCrjcidjhQJzezQKbLNbjmA != 0}";
	}
}
