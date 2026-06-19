using System;
using System.Globalization;

internal struct rncEercGnjpucdJpCpbguGjftHc : IEquatable<rncEercGnjpucdJpCpbguGjftHc>
{
	private int ThZEbijbhiKEJZfbMgDnjCVkxNW;

	private int YCLBNaaDqGmHRkFwnIjDxhInBVn;

	private int rcqIjPaTlZixKXrxflAqaJhRJSF;

	private int jdGSnpzwUkxJTiBvUleGluHpIjM;

	public static readonly rncEercGnjpucdJpCpbguGjftHc SJrQUGUtdqpchWfNvrmkSxmfMhd;

	public int Left
	{
		get
		{
			return ThZEbijbhiKEJZfbMgDnjCVkxNW;
		}
		set
		{
			ThZEbijbhiKEJZfbMgDnjCVkxNW = value;
		}
	}

	public int Top
	{
		get
		{
			return YCLBNaaDqGmHRkFwnIjDxhInBVn;
		}
		set
		{
			YCLBNaaDqGmHRkFwnIjDxhInBVn = value;
		}
	}

	public int Right
	{
		get
		{
			return rcqIjPaTlZixKXrxflAqaJhRJSF;
		}
		set
		{
			rcqIjPaTlZixKXrxflAqaJhRJSF = value;
		}
	}

	public int Bottom
	{
		get
		{
			return jdGSnpzwUkxJTiBvUleGluHpIjM;
		}
		set
		{
			jdGSnpzwUkxJTiBvUleGluHpIjM = value;
		}
	}

	public int X
	{
		get
		{
			return ThZEbijbhiKEJZfbMgDnjCVkxNW;
		}
		set
		{
			rcqIjPaTlZixKXrxflAqaJhRJSF = value + Width;
			ThZEbijbhiKEJZfbMgDnjCVkxNW = value;
		}
	}

	public int Y
	{
		get
		{
			return YCLBNaaDqGmHRkFwnIjDxhInBVn;
		}
		set
		{
			jdGSnpzwUkxJTiBvUleGluHpIjM = value + Height;
			YCLBNaaDqGmHRkFwnIjDxhInBVn = value;
		}
	}

	public int Width
	{
		get
		{
			return rcqIjPaTlZixKXrxflAqaJhRJSF - ThZEbijbhiKEJZfbMgDnjCVkxNW;
		}
		set
		{
			rcqIjPaTlZixKXrxflAqaJhRJSF = ThZEbijbhiKEJZfbMgDnjCVkxNW + value;
		}
	}

	public int Height
	{
		get
		{
			return jdGSnpzwUkxJTiBvUleGluHpIjM - YCLBNaaDqGmHRkFwnIjDxhInBVn;
		}
		set
		{
			jdGSnpzwUkxJTiBvUleGluHpIjM = YCLBNaaDqGmHRkFwnIjDxhInBVn + value;
		}
	}

	public HrmeACHhkFViOCUaklECPkUAoFB Location
	{
		get
		{
			return new HrmeACHhkFViOCUaklECPkUAoFB(X, Y);
		}
		set
		{
			X = value.lSOdwKYaTJSJyAWJnADwkSPKwkp;
			Y = value.ZqYMkLdonrbLPbHprxydzkIAizSD;
		}
	}

	public HrmeACHhkFViOCUaklECPkUAoFB Center => new HrmeACHhkFViOCUaklECPkUAoFB(X + Width / 2, Y + Height / 2);

	public bool IsEmpty
	{
		get
		{
			if (Width == 0 && Height == 0 && X == 0)
			{
				return Y == 0;
			}
			return false;
		}
	}

	public OoGfoAJaSrNIsLWextjgwWPSjLcW Size
	{
		get
		{
			return new OoGfoAJaSrNIsLWextjgwWPSjLcW(Width, Height);
		}
		set
		{
			Width = value.QIDJORADMNDkZNLUlhSScEskOfQ;
			Height = value.apBqzPMqEBuPCuPyDzYnqmgbHni;
		}
	}

	public HrmeACHhkFViOCUaklECPkUAoFB TopLeft => new HrmeACHhkFViOCUaklECPkUAoFB(ThZEbijbhiKEJZfbMgDnjCVkxNW, YCLBNaaDqGmHRkFwnIjDxhInBVn);

	public HrmeACHhkFViOCUaklECPkUAoFB TopRight => new HrmeACHhkFViOCUaklECPkUAoFB(rcqIjPaTlZixKXrxflAqaJhRJSF, YCLBNaaDqGmHRkFwnIjDxhInBVn);

	public HrmeACHhkFViOCUaklECPkUAoFB BottomLeft => new HrmeACHhkFViOCUaklECPkUAoFB(ThZEbijbhiKEJZfbMgDnjCVkxNW, jdGSnpzwUkxJTiBvUleGluHpIjM);

	public HrmeACHhkFViOCUaklECPkUAoFB BottomRight => new HrmeACHhkFViOCUaklECPkUAoFB(rcqIjPaTlZixKXrxflAqaJhRJSF, jdGSnpzwUkxJTiBvUleGluHpIjM);

	static rncEercGnjpucdJpCpbguGjftHc()
	{
		SJrQUGUtdqpchWfNvrmkSxmfMhd = default(rncEercGnjpucdJpCpbguGjftHc);
	}

	public rncEercGnjpucdJpCpbguGjftHc(int x, int y, int width, int height)
	{
		ThZEbijbhiKEJZfbMgDnjCVkxNW = x;
		YCLBNaaDqGmHRkFwnIjDxhInBVn = y;
		rcqIjPaTlZixKXrxflAqaJhRJSF = x + width;
		jdGSnpzwUkxJTiBvUleGluHpIjM = y + height;
	}

	public void vWDCHhwuXPHeHeeYshRgNHYNPtE(HrmeACHhkFViOCUaklECPkUAoFB P_0)
	{
		vWDCHhwuXPHeHeeYshRgNHYNPtE(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public void vWDCHhwuXPHeHeeYshRgNHYNPtE(int P_0, int P_1)
	{
		X += P_0;
		Y += P_1;
	}

	public void AxcOLCRGJuaFOWYknVxKIFRdpaa(int P_0, int P_1)
	{
		X -= P_0;
		Y -= P_1;
		Width += P_0 * 2;
		Height += P_1 * 2;
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(int P_0, int P_1)
	{
		if (X <= P_0 && P_0 < Right && Y <= P_1)
		{
			return P_1 < Bottom;
		}
		return false;
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(HrmeACHhkFViOCUaklECPkUAoFB P_0)
	{
		WDMRBLdLaAepmasexhLgbGtHkMQT(ref P_0, out var result);
		return result;
	}

	public void WDMRBLdLaAepmasexhLgbGtHkMQT(ref HrmeACHhkFViOCUaklECPkUAoFB P_0, out bool P_1)
	{
		P_1 = X <= P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp && P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp < Right && Y <= P_0.ZqYMkLdonrbLPbHprxydzkIAizSD && P_0.ZqYMkLdonrbLPbHprxydzkIAizSD < Bottom;
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(rncEercGnjpucdJpCpbguGjftHc P_0)
	{
		WDMRBLdLaAepmasexhLgbGtHkMQT(ref P_0, out var result);
		return result;
	}

	public void WDMRBLdLaAepmasexhLgbGtHkMQT(ref rncEercGnjpucdJpCpbguGjftHc P_0, out bool P_1)
	{
		P_1 = X <= P_0.X && P_0.Right <= Right && Y <= P_0.Y && P_0.Bottom <= Bottom;
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(float P_0, float P_1)
	{
		if (P_0 >= (float)ThZEbijbhiKEJZfbMgDnjCVkxNW && P_0 <= (float)rcqIjPaTlZixKXrxflAqaJhRJSF && P_1 >= (float)YCLBNaaDqGmHRkFwnIjDxhInBVn)
		{
			return P_1 <= (float)jdGSnpzwUkxJTiBvUleGluHpIjM;
		}
		return false;
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(pVSuHyNJvyUxaJEgntzLugvbPrW P_0)
	{
		return WDMRBLdLaAepmasexhLgbGtHkMQT(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public bool vYQbeYUpljOblENwRVwghDkWxrG(rncEercGnjpucdJpCpbguGjftHc P_0)
	{
		vYQbeYUpljOblENwRVwghDkWxrG(ref P_0, out var result);
		return result;
	}

	public void vYQbeYUpljOblENwRVwghDkWxrG(ref rncEercGnjpucdJpCpbguGjftHc P_0, out bool P_1)
	{
		P_1 = P_0.X < Right && X < P_0.Right && P_0.Y < Bottom && Y < P_0.Bottom;
	}

	public static rncEercGnjpucdJpCpbguGjftHc XEkSOwjZgaKSVPNXXMsLTdHNdfF(rncEercGnjpucdJpCpbguGjftHc P_0, rncEercGnjpucdJpCpbguGjftHc P_1)
	{
		XEkSOwjZgaKSVPNXXMsLTdHNdfF(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void XEkSOwjZgaKSVPNXXMsLTdHNdfF(ref rncEercGnjpucdJpCpbguGjftHc P_0, ref rncEercGnjpucdJpCpbguGjftHc P_1, out rncEercGnjpucdJpCpbguGjftHc P_2)
	{
		int num = ((P_0.X > P_1.X) ? P_0.X : P_1.X);
		int num2 = ((P_0.Y > P_1.Y) ? P_0.Y : P_1.Y);
		int num3 = ((P_0.Right < P_1.Right) ? P_0.Right : P_1.Right);
		int num4 = ((P_0.Bottom < P_1.Bottom) ? P_0.Bottom : P_1.Bottom);
		if (num3 > num && num4 > num2)
		{
			P_2 = new rncEercGnjpucdJpCpbguGjftHc(num, num2, num3 - num, num4 - num2);
		}
		else
		{
			P_2 = SJrQUGUtdqpchWfNvrmkSxmfMhd;
		}
	}

	public static rncEercGnjpucdJpCpbguGjftHc SCyEoyGDwTfBmcxjcGkvKUUJLrem(rncEercGnjpucdJpCpbguGjftHc P_0, rncEercGnjpucdJpCpbguGjftHc P_1)
	{
		SCyEoyGDwTfBmcxjcGkvKUUJLrem(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void SCyEoyGDwTfBmcxjcGkvKUUJLrem(ref rncEercGnjpucdJpCpbguGjftHc P_0, ref rncEercGnjpucdJpCpbguGjftHc P_1, out rncEercGnjpucdJpCpbguGjftHc P_2)
	{
		int num = Math.Min(P_0.Left, P_1.Left);
		int num2 = Math.Max(P_0.Right, P_1.Right);
		int num3 = Math.Min(P_0.Top, P_1.Top);
		int num4 = Math.Max(P_0.Bottom, P_1.Bottom);
		P_2 = new rncEercGnjpucdJpCpbguGjftHc(num, num3, num2 - num, num4 - num3);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(rncEercGnjpucdJpCpbguGjftHc))
		{
			return false;
		}
		return Equals((rncEercGnjpucdJpCpbguGjftHc)obj);
	}

	public bool Equals(rncEercGnjpucdJpCpbguGjftHc other)
	{
		if (other.ThZEbijbhiKEJZfbMgDnjCVkxNW == ThZEbijbhiKEJZfbMgDnjCVkxNW && other.YCLBNaaDqGmHRkFwnIjDxhInBVn == YCLBNaaDqGmHRkFwnIjDxhInBVn && other.rcqIjPaTlZixKXrxflAqaJhRJSF == rcqIjPaTlZixKXrxflAqaJhRJSF)
		{
			return other.jdGSnpzwUkxJTiBvUleGluHpIjM == jdGSnpzwUkxJTiBvUleGluHpIjM;
		}
		return false;
	}

	public override int GetHashCode()
	{
		int thZEbijbhiKEJZfbMgDnjCVkxNW = ThZEbijbhiKEJZfbMgDnjCVkxNW;
		thZEbijbhiKEJZfbMgDnjCVkxNW = (thZEbijbhiKEJZfbMgDnjCVkxNW * 397) ^ YCLBNaaDqGmHRkFwnIjDxhInBVn;
		thZEbijbhiKEJZfbMgDnjCVkxNW = (thZEbijbhiKEJZfbMgDnjCVkxNW * 397) ^ rcqIjPaTlZixKXrxflAqaJhRJSF;
		return (thZEbijbhiKEJZfbMgDnjCVkxNW * 397) ^ jdGSnpzwUkxJTiBvUleGluHpIjM;
	}

	public static bool operator ==(rncEercGnjpucdJpCpbguGjftHc left, rncEercGnjpucdJpCpbguGjftHc right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(rncEercGnjpucdJpCpbguGjftHc left, rncEercGnjpucdJpCpbguGjftHc right)
	{
		return !(left == right);
	}

	public static implicit operator uMUapQiOtEJQDeUWlACobRssefZG(rncEercGnjpucdJpCpbguGjftHc value)
	{
		return new uMUapQiOtEJQDeUWlACobRssefZG(value.X, value.Y, value.Width, value.Height);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Width:{2} Height:{3}", X, Y, Width, Height);
	}

	internal void OwVGqEFoQapeWQyyOGNtRgQgpfU()
	{
		rcqIjPaTlZixKXrxflAqaJhRJSF -= ThZEbijbhiKEJZfbMgDnjCVkxNW;
		jdGSnpzwUkxJTiBvUleGluHpIjM -= YCLBNaaDqGmHRkFwnIjDxhInBVn;
	}
}
