using System;
using System.Globalization;

internal struct uMUapQiOtEJQDeUWlACobRssefZG : IEquatable<uMUapQiOtEJQDeUWlACobRssefZG>
{
	private float ThZEbijbhiKEJZfbMgDnjCVkxNW;

	private float YCLBNaaDqGmHRkFwnIjDxhInBVn;

	private float rcqIjPaTlZixKXrxflAqaJhRJSF;

	private float jdGSnpzwUkxJTiBvUleGluHpIjM;

	public static readonly uMUapQiOtEJQDeUWlACobRssefZG SJrQUGUtdqpchWfNvrmkSxmfMhd;

	public static readonly uMUapQiOtEJQDeUWlACobRssefZG yXRejdyHgjTEFkTodXJjLVAvEZh;

	public float Left
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

	public float Top
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

	public float Right
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

	public float Bottom
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

	public float X
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

	public float Y
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

	public float Width
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

	public float Height
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

	public pVSuHyNJvyUxaJEgntzLugvbPrW Location
	{
		get
		{
			return new pVSuHyNJvyUxaJEgntzLugvbPrW(X, Y);
		}
		set
		{
			X = value.lSOdwKYaTJSJyAWJnADwkSPKwkp;
			Y = value.ZqYMkLdonrbLPbHprxydzkIAizSD;
		}
	}

	public pVSuHyNJvyUxaJEgntzLugvbPrW Center => new pVSuHyNJvyUxaJEgntzLugvbPrW(X + Width / 2f, Y + Height / 2f);

	public bool IsEmpty
	{
		get
		{
			if (Width == 0f && Height == 0f && X == 0f)
			{
				return Y == 0f;
			}
			return false;
		}
	}

	public dYYJxlUxNJicubyXxoDOlMElKaa Size
	{
		get
		{
			return new dYYJxlUxNJicubyXxoDOlMElKaa(Width, Height);
		}
		set
		{
			Width = value.QIDJORADMNDkZNLUlhSScEskOfQ;
			Height = value.apBqzPMqEBuPCuPyDzYnqmgbHni;
		}
	}

	public pVSuHyNJvyUxaJEgntzLugvbPrW TopLeft => new pVSuHyNJvyUxaJEgntzLugvbPrW(ThZEbijbhiKEJZfbMgDnjCVkxNW, YCLBNaaDqGmHRkFwnIjDxhInBVn);

	public pVSuHyNJvyUxaJEgntzLugvbPrW TopRight => new pVSuHyNJvyUxaJEgntzLugvbPrW(rcqIjPaTlZixKXrxflAqaJhRJSF, YCLBNaaDqGmHRkFwnIjDxhInBVn);

	public pVSuHyNJvyUxaJEgntzLugvbPrW BottomLeft => new pVSuHyNJvyUxaJEgntzLugvbPrW(ThZEbijbhiKEJZfbMgDnjCVkxNW, jdGSnpzwUkxJTiBvUleGluHpIjM);

	public pVSuHyNJvyUxaJEgntzLugvbPrW BottomRight => new pVSuHyNJvyUxaJEgntzLugvbPrW(rcqIjPaTlZixKXrxflAqaJhRJSF, jdGSnpzwUkxJTiBvUleGluHpIjM);

	static uMUapQiOtEJQDeUWlACobRssefZG()
	{
		SJrQUGUtdqpchWfNvrmkSxmfMhd = default(uMUapQiOtEJQDeUWlACobRssefZG);
		yXRejdyHgjTEFkTodXJjLVAvEZh = new uMUapQiOtEJQDeUWlACobRssefZG
		{
			Left = float.NegativeInfinity,
			Top = float.NegativeInfinity,
			Right = float.PositiveInfinity,
			Bottom = float.PositiveInfinity
		};
	}

	public uMUapQiOtEJQDeUWlACobRssefZG(float x, float y, float width, float height)
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

	public void vWDCHhwuXPHeHeeYshRgNHYNPtE(pVSuHyNJvyUxaJEgntzLugvbPrW P_0)
	{
		vWDCHhwuXPHeHeeYshRgNHYNPtE(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public void vWDCHhwuXPHeHeeYshRgNHYNPtE(float P_0, float P_1)
	{
		X += P_0;
		Y += P_1;
	}

	public void AxcOLCRGJuaFOWYknVxKIFRdpaa(float P_0, float P_1)
	{
		X -= P_0;
		Y -= P_1;
		Width += P_0 * 2f;
		Height += P_1 * 2f;
	}

	public void WDMRBLdLaAepmasexhLgbGtHkMQT(ref pVSuHyNJvyUxaJEgntzLugvbPrW P_0, out bool P_1)
	{
		P_1 = X <= P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp && P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp < Right && Y <= P_0.ZqYMkLdonrbLPbHprxydzkIAizSD && P_0.ZqYMkLdonrbLPbHprxydzkIAizSD < Bottom;
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(rncEercGnjpucdJpCpbguGjftHc P_0)
	{
		if (X <= (float)P_0.X && (float)P_0.Right <= Right && Y <= (float)P_0.Y)
		{
			return (float)P_0.Bottom <= Bottom;
		}
		return false;
	}

	public void WDMRBLdLaAepmasexhLgbGtHkMQT(ref uMUapQiOtEJQDeUWlACobRssefZG P_0, out bool P_1)
	{
		P_1 = X <= P_0.X && P_0.Right <= Right && Y <= P_0.Y && P_0.Bottom <= Bottom;
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(float P_0, float P_1)
	{
		if (P_0 >= ThZEbijbhiKEJZfbMgDnjCVkxNW && P_0 <= rcqIjPaTlZixKXrxflAqaJhRJSF && P_1 >= YCLBNaaDqGmHRkFwnIjDxhInBVn)
		{
			return P_1 <= jdGSnpzwUkxJTiBvUleGluHpIjM;
		}
		return false;
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(pVSuHyNJvyUxaJEgntzLugvbPrW P_0)
	{
		return WDMRBLdLaAepmasexhLgbGtHkMQT(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public bool WDMRBLdLaAepmasexhLgbGtHkMQT(HrmeACHhkFViOCUaklECPkUAoFB P_0)
	{
		return WDMRBLdLaAepmasexhLgbGtHkMQT(P_0.lSOdwKYaTJSJyAWJnADwkSPKwkp, P_0.ZqYMkLdonrbLPbHprxydzkIAizSD);
	}

	public bool vYQbeYUpljOblENwRVwghDkWxrG(uMUapQiOtEJQDeUWlACobRssefZG P_0)
	{
		vYQbeYUpljOblENwRVwghDkWxrG(ref P_0, out var result);
		return result;
	}

	public void vYQbeYUpljOblENwRVwghDkWxrG(ref uMUapQiOtEJQDeUWlACobRssefZG P_0, out bool P_1)
	{
		P_1 = P_0.X < Right && X < P_0.Right && P_0.Y < Bottom && Y < P_0.Bottom;
	}

	public static uMUapQiOtEJQDeUWlACobRssefZG XEkSOwjZgaKSVPNXXMsLTdHNdfF(uMUapQiOtEJQDeUWlACobRssefZG P_0, uMUapQiOtEJQDeUWlACobRssefZG P_1)
	{
		XEkSOwjZgaKSVPNXXMsLTdHNdfF(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void XEkSOwjZgaKSVPNXXMsLTdHNdfF(ref uMUapQiOtEJQDeUWlACobRssefZG P_0, ref uMUapQiOtEJQDeUWlACobRssefZG P_1, out uMUapQiOtEJQDeUWlACobRssefZG P_2)
	{
		float num = ((P_0.X > P_1.X) ? P_0.X : P_1.X);
		float num2 = ((P_0.Y > P_1.Y) ? P_0.Y : P_1.Y);
		float num3 = ((P_0.Right < P_1.Right) ? P_0.Right : P_1.Right);
		float num4 = ((P_0.Bottom < P_1.Bottom) ? P_0.Bottom : P_1.Bottom);
		if (num3 > num && num4 > num2)
		{
			P_2 = new uMUapQiOtEJQDeUWlACobRssefZG(num, num2, num3 - num, num4 - num2);
		}
		else
		{
			P_2 = SJrQUGUtdqpchWfNvrmkSxmfMhd;
		}
	}

	public static uMUapQiOtEJQDeUWlACobRssefZG SCyEoyGDwTfBmcxjcGkvKUUJLrem(uMUapQiOtEJQDeUWlACobRssefZG P_0, uMUapQiOtEJQDeUWlACobRssefZG P_1)
	{
		SCyEoyGDwTfBmcxjcGkvKUUJLrem(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void SCyEoyGDwTfBmcxjcGkvKUUJLrem(ref uMUapQiOtEJQDeUWlACobRssefZG P_0, ref uMUapQiOtEJQDeUWlACobRssefZG P_1, out uMUapQiOtEJQDeUWlACobRssefZG P_2)
	{
		float num = Math.Min(P_0.Left, P_1.Left);
		float num2 = Math.Max(P_0.Right, P_1.Right);
		float num3 = Math.Min(P_0.Top, P_1.Top);
		float num4 = Math.Max(P_0.Bottom, P_1.Bottom);
		P_2 = new uMUapQiOtEJQDeUWlACobRssefZG(num, num3, num2 - num, num4 - num3);
	}

	public override bool Equals(object obj)
	{
		if (object.ReferenceEquals(null, obj))
		{
			return false;
		}
		if ((object)obj.GetType() != typeof(uMUapQiOtEJQDeUWlACobRssefZG))
		{
			return false;
		}
		return Equals((uMUapQiOtEJQDeUWlACobRssefZG)obj);
	}

	public bool Equals(uMUapQiOtEJQDeUWlACobRssefZG other)
	{
		if (ZvnBPrLKFiDHPIhVHtaZiLpeksK.zRKPPfiBPYeKnjHUBnDeSKiuiIX(other.Left, Left) && ZvnBPrLKFiDHPIhVHtaZiLpeksK.zRKPPfiBPYeKnjHUBnDeSKiuiIX(other.Right, Right) && ZvnBPrLKFiDHPIhVHtaZiLpeksK.zRKPPfiBPYeKnjHUBnDeSKiuiIX(other.Top, Top))
		{
			return ZvnBPrLKFiDHPIhVHtaZiLpeksK.zRKPPfiBPYeKnjHUBnDeSKiuiIX(other.Bottom, Bottom);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int hashCode = ThZEbijbhiKEJZfbMgDnjCVkxNW.GetHashCode();
		hashCode = (hashCode * 397) ^ YCLBNaaDqGmHRkFwnIjDxhInBVn.GetHashCode();
		hashCode = (hashCode * 397) ^ rcqIjPaTlZixKXrxflAqaJhRJSF.GetHashCode();
		return (hashCode * 397) ^ jdGSnpzwUkxJTiBvUleGluHpIjM.GetHashCode();
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X:{0} Y:{1} Width:{2} Height:{3}", X, Y, Width, Height);
	}

	public static bool operator ==(uMUapQiOtEJQDeUWlACobRssefZG left, uMUapQiOtEJQDeUWlACobRssefZG right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(uMUapQiOtEJQDeUWlACobRssefZG left, uMUapQiOtEJQDeUWlACobRssefZG right)
	{
		return !(left == right);
	}

	public static explicit operator rncEercGnjpucdJpCpbguGjftHc(uMUapQiOtEJQDeUWlACobRssefZG value)
	{
		return new rncEercGnjpucdJpCpbguGjftHc((int)value.X, (int)value.Y, (int)value.Width, (int)value.Height);
	}
}
