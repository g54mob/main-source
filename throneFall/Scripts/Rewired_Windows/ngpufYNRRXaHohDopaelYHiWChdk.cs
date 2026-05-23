using System;
using System.Runtime.CompilerServices;

internal struct ngpufYNRRXaHohDopaelYHiWChdk : IEquatable<ngpufYNRRXaHohDopaelYHiWChdk>
{
	public static readonly ngpufYNRRXaHohDopaelYHiWChdk LRTYjdbVlLlXPrtpBdwdZcLWQVMy = new ngpufYNRRXaHohDopaelYHiWChdk(0, 0);

	public int xQgLbylfuywBiAguRyVjlnuKcbJF;

	public int euLEnZgsCaanHAtLgKzxKWnDHSgwB;

	public ngpufYNRRXaHohDopaelYHiWChdk(int P_0, int P_1)
	{
		xQgLbylfuywBiAguRyVjlnuKcbJF = P_0;
		euLEnZgsCaanHAtLgKzxKWnDHSgwB = P_1;
	}

	public bool Equals(ngpufYNRRXaHohDopaelYHiWChdk other)
	{
		if (other.xQgLbylfuywBiAguRyVjlnuKcbJF == xQgLbylfuywBiAguRyVjlnuKcbJF)
		{
			return other.euLEnZgsCaanHAtLgKzxKWnDHSgwB == euLEnZgsCaanHAtLgKzxKWnDHSgwB;
		}
		return false;
	}

	bool IEquatable<ngpufYNRRXaHohDopaelYHiWChdk>.Equals(ngpufYNRRXaHohDopaelYHiWChdk other)
	{
		//ILSpy generated this explicit interface implementation from .override directive in Equals
		return this.Equals(other);
	}

	public bool FmtbzsSinicFJoOKGBtOfHIbpGyjA(object P_0)
	{
		if (P_0 == null)
		{
			return false;
		}
		if (P_0.GetType() != typeof(ngpufYNRRXaHohDopaelYHiWChdk))
		{
			return false;
		}
		return Equals((ngpufYNRRXaHohDopaelYHiWChdk)P_0);
	}

	public int gtqoAJDDrPlDysOafNUSVmPNcdIgA()
	{
		return (xQgLbylfuywBiAguRyVjlnuKcbJF * 397) ^ euLEnZgsCaanHAtLgKzxKWnDHSgwB;
	}

	[SpecialName]
	public static bool qRGIYGQLKyddLywugaQKYlbHWlbc(ngpufYNRRXaHohDopaelYHiWChdk P_0, ngpufYNRRXaHohDopaelYHiWChdk P_1)
	{
		return P_0.Equals(P_1);
	}

	[SpecialName]
	public static bool AgPaJybHiTeWMAgWvgxcIXinDMiMA(ngpufYNRRXaHohDopaelYHiWChdk P_0, ngpufYNRRXaHohDopaelYHiWChdk P_1)
	{
		return !P_0.Equals(P_1);
	}

	public string jMJeHSwNgwTNoPqRhOPwERGbVBts()
	{
		return $"({xQgLbylfuywBiAguRyVjlnuKcbJF},{euLEnZgsCaanHAtLgKzxKWnDHSgwB})";
	}
}
