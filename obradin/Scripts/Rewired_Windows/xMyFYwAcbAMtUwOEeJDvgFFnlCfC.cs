using System;
using System.Globalization;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
internal struct xMyFYwAcbAMtUwOEeJDvgFFnlCfC : IEquatable<xMyFYwAcbAMtUwOEeJDvgFFnlCfC>, IFormattable
{
	public static readonly int TPHeZSOEtgycJMidzDLLgUARTBGg = Marshal.SizeOf(typeof(xMyFYwAcbAMtUwOEeJDvgFFnlCfC));

	public static readonly xMyFYwAcbAMtUwOEeJDvgFFnlCfC rMIFSTyyRdDLwOqbnprfBfzxivL = default(xMyFYwAcbAMtUwOEeJDvgFFnlCfC);

	public static readonly xMyFYwAcbAMtUwOEeJDvgFFnlCfC MdPJmUzLlkBicGKYmlUWdFXBivcn = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(1f, 0f);

	public static readonly xMyFYwAcbAMtUwOEeJDvgFFnlCfC nJXnqGqfkubUTOzSqJCObetHMNI = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(0f, 1f);

	public static readonly xMyFYwAcbAMtUwOEeJDvgFFnlCfC VoFjnFWSZvLkFqDfOHnHheWaQCRu = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(1f, 1f);

	public float xIuDTKizXrGdQWHryFwOfDhIWfYh;

	public float BnoOLWClHLapgAPysAHqWqcOkax;

	public bool IsNormalized
	{
		get
		{
			return FpTrbTgRASLmrLSXGJpSPdrcCzX.TWMkiEMWWONvvROhUgrOMizDDTmE(xIuDTKizXrGdQWHryFwOfDhIWfYh * xIuDTKizXrGdQWHryFwOfDhIWfYh + BnoOLWClHLapgAPysAHqWqcOkax * BnoOLWClHLapgAPysAHqWqcOkax);
		}
	}

	public bool IsZero
	{
		get
		{
			if (xIuDTKizXrGdQWHryFwOfDhIWfYh == 0f)
			{
				return BnoOLWClHLapgAPysAHqWqcOkax == 0f;
			}
			return false;
		}
	}

	public float this[int index]
	{
		get
		{
			switch (index)
			{
			case 0:
				return xIuDTKizXrGdQWHryFwOfDhIWfYh;
			case 1:
				return BnoOLWClHLapgAPysAHqWqcOkax;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
		set
		{
			switch (index)
			{
			case 0:
				xIuDTKizXrGdQWHryFwOfDhIWfYh = value;
				break;
			case 1:
				BnoOLWClHLapgAPysAHqWqcOkax = value;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public xMyFYwAcbAMtUwOEeJDvgFFnlCfC(float value)
	{
		xIuDTKizXrGdQWHryFwOfDhIWfYh = value;
		BnoOLWClHLapgAPysAHqWqcOkax = value;
	}

	public xMyFYwAcbAMtUwOEeJDvgFFnlCfC(float x, float y)
	{
		xIuDTKizXrGdQWHryFwOfDhIWfYh = x;
		BnoOLWClHLapgAPysAHqWqcOkax = y;
	}

	public xMyFYwAcbAMtUwOEeJDvgFFnlCfC(float[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (values.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		xIuDTKizXrGdQWHryFwOfDhIWfYh = values[0];
		BnoOLWClHLapgAPysAHqWqcOkax = values[1];
	}

	public float GgrgjYMnvDtqaCsPUiELzdYULam()
	{
		return (float)Math.Sqrt(xIuDTKizXrGdQWHryFwOfDhIWfYh * xIuDTKizXrGdQWHryFwOfDhIWfYh + BnoOLWClHLapgAPysAHqWqcOkax * BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public float EacDcUuzBWUPyrMjNkbKHGuwzZc()
	{
		return xIuDTKizXrGdQWHryFwOfDhIWfYh * xIuDTKizXrGdQWHryFwOfDhIWfYh + BnoOLWClHLapgAPysAHqWqcOkax * BnoOLWClHLapgAPysAHqWqcOkax;
	}

	public void WDcsOwlrqtGfTBGZJoxpaJwXeQO()
	{
		float num = GgrgjYMnvDtqaCsPUiELzdYULam();
		if (!FpTrbTgRASLmrLSXGJpSPdrcCzX.LahgjnPpJFdJKSxqfeeqLYgAuZb(num))
		{
			float num2 = 1f / num;
			xIuDTKizXrGdQWHryFwOfDhIWfYh *= num2;
			BnoOLWClHLapgAPysAHqWqcOkax *= num2;
		}
	}

	public float[] radCjhHxtygljuQWbJpttLuwMERt()
	{
		return new float[2] { xIuDTKizXrGdQWHryFwOfDhIWfYh, BnoOLWClHLapgAPysAHqWqcOkax };
	}

	public static void yJykJjFMTtoOetvmLsZEDIsxDRE(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0.BnoOLWClHLapgAPysAHqWqcOkax + P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC yJykJjFMTtoOetvmLsZEDIsxDRE(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0.BnoOLWClHLapgAPysAHqWqcOkax + P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static void yJykJjFMTtoOetvmLsZEDIsxDRE(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref float P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_1, P_0.BnoOLWClHLapgAPysAHqWqcOkax + P_1);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC yJykJjFMTtoOetvmLsZEDIsxDRE(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, float P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_1, P_0.BnoOLWClHLapgAPysAHqWqcOkax + P_1);
	}

	public static void DjkENKXGnPDhRAjGJgGUstBdBCOP(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0.BnoOLWClHLapgAPysAHqWqcOkax - P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC DjkENKXGnPDhRAjGJgGUstBdBCOP(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0.BnoOLWClHLapgAPysAHqWqcOkax - P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static void DjkENKXGnPDhRAjGJgGUstBdBCOP(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref float P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_1, P_0.BnoOLWClHLapgAPysAHqWqcOkax - P_1);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC DjkENKXGnPDhRAjGJgGUstBdBCOP(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, float P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_1, P_0.BnoOLWClHLapgAPysAHqWqcOkax - P_1);
	}

	public static void DjkENKXGnPDhRAjGJgGUstBdBCOP(ref float P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0 - P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0 - P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC DjkENKXGnPDhRAjGJgGUstBdBCOP(float P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0 - P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0 - P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static void zzSIOcyVWZaMafgBLCQzBMBsfSZl(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, float P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh * P_1, P_0.BnoOLWClHLapgAPysAHqWqcOkax * P_1);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC zzSIOcyVWZaMafgBLCQzBMBsfSZl(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, float P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh * P_1, P_0.BnoOLWClHLapgAPysAHqWqcOkax * P_1);
	}

	public static void zzSIOcyVWZaMafgBLCQzBMBsfSZl(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0.BnoOLWClHLapgAPysAHqWqcOkax * P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC zzSIOcyVWZaMafgBLCQzBMBsfSZl(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0.BnoOLWClHLapgAPysAHqWqcOkax * P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static void vSpsSziyerCaBmdpPnxwAUeDTnc(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, float P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh / P_1, P_0.BnoOLWClHLapgAPysAHqWqcOkax / P_1);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC vSpsSziyerCaBmdpPnxwAUeDTnc(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, float P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh / P_1, P_0.BnoOLWClHLapgAPysAHqWqcOkax / P_1);
	}

	public static void vSpsSziyerCaBmdpPnxwAUeDTnc(float P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0 / P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0 / P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC vSpsSziyerCaBmdpPnxwAUeDTnc(float P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0 / P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_0 / P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static void MxyjShBfLuLuJFIQwqyGBFrlIWm(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		P_1 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(0f - P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh, 0f - P_0.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC MxyjShBfLuLuJFIQwqyGBFrlIWm(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(0f - P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh, 0f - P_0.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static void sleHaTqjgTRmMotcMEaFqVtwQiW(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2, float P_3, float P_4, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_5)
	{
		P_5 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_3 * (P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh) + P_4 * (P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh), P_0.BnoOLWClHLapgAPysAHqWqcOkax + P_3 * (P_1.BnoOLWClHLapgAPysAHqWqcOkax - P_0.BnoOLWClHLapgAPysAHqWqcOkax) + P_4 * (P_2.BnoOLWClHLapgAPysAHqWqcOkax - P_0.BnoOLWClHLapgAPysAHqWqcOkax));
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC sleHaTqjgTRmMotcMEaFqVtwQiW(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2, float P_3, float P_4)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		sleHaTqjgTRmMotcMEaFqVtwQiW(ref P_0, ref P_1, ref P_2, P_3, P_4, out result);
		return result;
	}

	public static void eRvgrQKEYYLWeelqFAkNsSSXlVf(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_3)
	{
		float num = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh;
		num = ((num > P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh) ? P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh : num);
		num = ((num < P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh) ? P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh : num);
		float bnoOLWClHLapgAPysAHqWqcOkax = P_0.BnoOLWClHLapgAPysAHqWqcOkax;
		bnoOLWClHLapgAPysAHqWqcOkax = ((bnoOLWClHLapgAPysAHqWqcOkax > P_2.BnoOLWClHLapgAPysAHqWqcOkax) ? P_2.BnoOLWClHLapgAPysAHqWqcOkax : bnoOLWClHLapgAPysAHqWqcOkax);
		bnoOLWClHLapgAPysAHqWqcOkax = ((bnoOLWClHLapgAPysAHqWqcOkax < P_1.BnoOLWClHLapgAPysAHqWqcOkax) ? P_1.BnoOLWClHLapgAPysAHqWqcOkax : bnoOLWClHLapgAPysAHqWqcOkax);
		P_3 = new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(num, bnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC eRvgrQKEYYLWeelqFAkNsSSXlVf(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		eRvgrQKEYYLWeelqFAkNsSSXlVf(ref P_0, ref P_1, ref P_2, out result);
		return result;
	}

	public void wixipVbBFdOUsTNPWyQZRHwVDatG()
	{
		xIuDTKizXrGdQWHryFwOfDhIWfYh = ((xIuDTKizXrGdQWHryFwOfDhIWfYh < 0f) ? 0f : ((xIuDTKizXrGdQWHryFwOfDhIWfYh > 1f) ? 1f : xIuDTKizXrGdQWHryFwOfDhIWfYh));
		BnoOLWClHLapgAPysAHqWqcOkax = ((BnoOLWClHLapgAPysAHqWqcOkax < 0f) ? 0f : ((BnoOLWClHLapgAPysAHqWqcOkax > 1f) ? 1f : BnoOLWClHLapgAPysAHqWqcOkax));
	}

	public static void pKOHQBFaDeFTbcdqZCfBdydnacMs(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out float P_2)
	{
		float num = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh;
		float num2 = P_0.BnoOLWClHLapgAPysAHqWqcOkax - P_1.BnoOLWClHLapgAPysAHqWqcOkax;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float pKOHQBFaDeFTbcdqZCfBdydnacMs(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		float num = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh;
		float num2 = P_0.BnoOLWClHLapgAPysAHqWqcOkax - P_1.BnoOLWClHLapgAPysAHqWqcOkax;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void QXBibPZKkzcbkzRyuUhNhrAwRNH(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out float P_2)
	{
		float num = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh;
		float num2 = P_0.BnoOLWClHLapgAPysAHqWqcOkax - P_1.BnoOLWClHLapgAPysAHqWqcOkax;
		P_2 = num * num + num2 * num2;
	}

	public static float QXBibPZKkzcbkzRyuUhNhrAwRNH(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		float num = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh;
		float num2 = P_0.BnoOLWClHLapgAPysAHqWqcOkax - P_1.BnoOLWClHLapgAPysAHqWqcOkax;
		return num * num + num2 * num2;
	}

	public static void IClYXeTzUulwksHAHYJNMWVljOy(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out float P_2)
	{
		P_2 = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_0.BnoOLWClHLapgAPysAHqWqcOkax * P_1.BnoOLWClHLapgAPysAHqWqcOkax;
	}

	public static float IClYXeTzUulwksHAHYJNMWVljOy(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		return P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_0.BnoOLWClHLapgAPysAHqWqcOkax * P_1.BnoOLWClHLapgAPysAHqWqcOkax;
	}

	public static void WDcsOwlrqtGfTBGZJoxpaJwXeQO(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		P_1 = P_0;
		P_1.WDcsOwlrqtGfTBGZJoxpaJwXeQO();
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC WDcsOwlrqtGfTBGZJoxpaJwXeQO(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0)
	{
		P_0.WDcsOwlrqtGfTBGZJoxpaJwXeQO();
		return P_0;
	}

	public static void adrMNLcHKjYDIKlOooDUcMtUrlW(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, float P_2, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_3)
	{
		P_3.xIuDTKizXrGdQWHryFwOfDhIWfYh = FpTrbTgRASLmrLSXGJpSPdrcCzX.adrMNLcHKjYDIKlOooDUcMtUrlW(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh, P_2);
		P_3.BnoOLWClHLapgAPysAHqWqcOkax = FpTrbTgRASLmrLSXGJpSPdrcCzX.adrMNLcHKjYDIKlOooDUcMtUrlW(P_0.BnoOLWClHLapgAPysAHqWqcOkax, P_1.BnoOLWClHLapgAPysAHqWqcOkax, P_2);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC adrMNLcHKjYDIKlOooDUcMtUrlW(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, float P_2)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		adrMNLcHKjYDIKlOooDUcMtUrlW(ref P_0, ref P_1, P_2, out result);
		return result;
	}

	public static void ucNEucCVASmHDajXOIPHVyosSoI(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, float P_2, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_3)
	{
		P_2 = FpTrbTgRASLmrLSXGJpSPdrcCzX.ucNEucCVASmHDajXOIPHVyosSoI(P_2);
		adrMNLcHKjYDIKlOooDUcMtUrlW(ref P_0, ref P_1, P_2, out P_3);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC ucNEucCVASmHDajXOIPHVyosSoI(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, float P_2)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		ucNEucCVASmHDajXOIPHVyosSoI(ref P_0, ref P_1, P_2, out result);
		return result;
	}

	public static void cEFsazevMkFbkUWDEcsWtqbSMow(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_3, float P_4, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.xIuDTKizXrGdQWHryFwOfDhIWfYh = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh * num3 + P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh * num4 + P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh * num5 + P_3.xIuDTKizXrGdQWHryFwOfDhIWfYh * num6;
		P_5.BnoOLWClHLapgAPysAHqWqcOkax = P_0.BnoOLWClHLapgAPysAHqWqcOkax * num3 + P_2.BnoOLWClHLapgAPysAHqWqcOkax * num4 + P_1.BnoOLWClHLapgAPysAHqWqcOkax * num5 + P_3.BnoOLWClHLapgAPysAHqWqcOkax * num6;
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC cEFsazevMkFbkUWDEcsWtqbSMow(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_3, float P_4)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		cEFsazevMkFbkUWDEcsWtqbSMow(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out result);
		return result;
	}

	public static void zZnoswGDsEqqVZSQRLrkCuNumiS(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_3, float P_4, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.xIuDTKizXrGdQWHryFwOfDhIWfYh = 0.5f * (2f * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh + (0f - P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh) * P_4 + (2f * P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - 5f * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh + 4f * P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh - P_3.xIuDTKizXrGdQWHryFwOfDhIWfYh) * num + (0f - P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh + 3f * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh - 3f * P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_3.xIuDTKizXrGdQWHryFwOfDhIWfYh) * num2);
		P_5.BnoOLWClHLapgAPysAHqWqcOkax = 0.5f * (2f * P_1.BnoOLWClHLapgAPysAHqWqcOkax + (0f - P_0.BnoOLWClHLapgAPysAHqWqcOkax + P_2.BnoOLWClHLapgAPysAHqWqcOkax) * P_4 + (2f * P_0.BnoOLWClHLapgAPysAHqWqcOkax - 5f * P_1.BnoOLWClHLapgAPysAHqWqcOkax + 4f * P_2.BnoOLWClHLapgAPysAHqWqcOkax - P_3.BnoOLWClHLapgAPysAHqWqcOkax) * num + (0f - P_0.BnoOLWClHLapgAPysAHqWqcOkax + 3f * P_1.BnoOLWClHLapgAPysAHqWqcOkax - 3f * P_2.BnoOLWClHLapgAPysAHqWqcOkax + P_3.BnoOLWClHLapgAPysAHqWqcOkax) * num2);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC zZnoswGDsEqqVZSQRLrkCuNumiS(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_3, float P_4)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		zZnoswGDsEqqVZSQRLrkCuNumiS(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out result);
		return result;
	}

	public static void xqcfcJTdNseNSglJRkAGUmQhJzBT(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh = ((P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh > P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh) ? P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh : P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh);
		P_2.BnoOLWClHLapgAPysAHqWqcOkax = ((P_0.BnoOLWClHLapgAPysAHqWqcOkax > P_1.BnoOLWClHLapgAPysAHqWqcOkax) ? P_0.BnoOLWClHLapgAPysAHqWqcOkax : P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC xqcfcJTdNseNSglJRkAGUmQhJzBT(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		xqcfcJTdNseNSglJRkAGUmQhJzBT(ref P_0, ref P_1, out result);
		return result;
	}

	public static void evPlRpJQfaSldUeTTdjaAJOLqLD(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh = ((P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh < P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh) ? P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh : P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh);
		P_2.BnoOLWClHLapgAPysAHqWqcOkax = ((P_0.BnoOLWClHLapgAPysAHqWqcOkax < P_1.BnoOLWClHLapgAPysAHqWqcOkax) ? P_0.BnoOLWClHLapgAPysAHqWqcOkax : P_1.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC evPlRpJQfaSldUeTTdjaAJOLqLD(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		evPlRpJQfaSldUeTTdjaAJOLqLD(ref P_0, ref P_1, out result);
		return result;
	}

	public static void EVsFORRHEZKhFBGuCFGktwpUaKq(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1, out xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_2)
	{
		float num = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh + P_0.BnoOLWClHLapgAPysAHqWqcOkax * P_1.BnoOLWClHLapgAPysAHqWqcOkax;
		P_2.xIuDTKizXrGdQWHryFwOfDhIWfYh = P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh - 2f * num * P_1.xIuDTKizXrGdQWHryFwOfDhIWfYh;
		P_2.BnoOLWClHLapgAPysAHqWqcOkax = P_0.BnoOLWClHLapgAPysAHqWqcOkax - 2f * num * P_1.BnoOLWClHLapgAPysAHqWqcOkax;
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC EVsFORRHEZKhFBGuCFGktwpUaKq(xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0, xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_1)
	{
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC result;
		EVsFORRHEZKhFBGuCFGktwpUaKq(ref P_0, ref P_1, out result);
		return result;
	}

	public static void DjCmIKRDVzrinKGslMVoVhNxcMa(xMyFYwAcbAMtUwOEeJDvgFFnlCfC[] P_0, params xMyFYwAcbAMtUwOEeJDvgFFnlCfC[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			xMyFYwAcbAMtUwOEeJDvgFFnlCfC xMyFYwAcbAMtUwOEeJDvgFFnlCfC2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				xMyFYwAcbAMtUwOEeJDvgFFnlCfC2 -= IClYXeTzUulwksHAHYJNMWVljOy(P_0[j], xMyFYwAcbAMtUwOEeJDvgFFnlCfC2) / IClYXeTzUulwksHAHYJNMWVljOy(P_0[j], P_0[j]) * P_0[j];
			}
			P_0[i] = xMyFYwAcbAMtUwOEeJDvgFFnlCfC2;
		}
	}

	public static void YrpgRKcsdfjUrfcrVCEeiaJtoAvo(xMyFYwAcbAMtUwOEeJDvgFFnlCfC[] P_0, params xMyFYwAcbAMtUwOEeJDvgFFnlCfC[] P_1)
	{
		if (P_1 == null)
		{
			throw new ArgumentNullException("source");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("destination");
		}
		if (P_0.Length < P_1.Length)
		{
			throw new ArgumentOutOfRangeException("destination", "The destination array must be of same length or larger length than the source array.");
		}
		for (int i = 0; i < P_1.Length; i++)
		{
			xMyFYwAcbAMtUwOEeJDvgFFnlCfC xMyFYwAcbAMtUwOEeJDvgFFnlCfC2 = P_1[i];
			for (int j = 0; j < i; j++)
			{
				xMyFYwAcbAMtUwOEeJDvgFFnlCfC2 -= IClYXeTzUulwksHAHYJNMWVljOy(P_0[j], xMyFYwAcbAMtUwOEeJDvgFFnlCfC2) * P_0[j];
			}
			xMyFYwAcbAMtUwOEeJDvgFFnlCfC2.WDcsOwlrqtGfTBGZJoxpaJwXeQO();
			P_0[i] = xMyFYwAcbAMtUwOEeJDvgFFnlCfC2;
		}
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator +(xMyFYwAcbAMtUwOEeJDvgFFnlCfC left, xMyFYwAcbAMtUwOEeJDvgFFnlCfC right)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(left.xIuDTKizXrGdQWHryFwOfDhIWfYh + right.xIuDTKizXrGdQWHryFwOfDhIWfYh, left.BnoOLWClHLapgAPysAHqWqcOkax + right.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator *(xMyFYwAcbAMtUwOEeJDvgFFnlCfC left, xMyFYwAcbAMtUwOEeJDvgFFnlCfC right)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(left.xIuDTKizXrGdQWHryFwOfDhIWfYh * right.xIuDTKizXrGdQWHryFwOfDhIWfYh, left.BnoOLWClHLapgAPysAHqWqcOkax * right.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator +(xMyFYwAcbAMtUwOEeJDvgFFnlCfC value)
	{
		return value;
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator -(xMyFYwAcbAMtUwOEeJDvgFFnlCfC left, xMyFYwAcbAMtUwOEeJDvgFFnlCfC right)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(left.xIuDTKizXrGdQWHryFwOfDhIWfYh - right.xIuDTKizXrGdQWHryFwOfDhIWfYh, left.BnoOLWClHLapgAPysAHqWqcOkax - right.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator -(xMyFYwAcbAMtUwOEeJDvgFFnlCfC value)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(0f - value.xIuDTKizXrGdQWHryFwOfDhIWfYh, 0f - value.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator *(float scale, xMyFYwAcbAMtUwOEeJDvgFFnlCfC value)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(value.xIuDTKizXrGdQWHryFwOfDhIWfYh * scale, value.BnoOLWClHLapgAPysAHqWqcOkax * scale);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator *(xMyFYwAcbAMtUwOEeJDvgFFnlCfC value, float scale)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(value.xIuDTKizXrGdQWHryFwOfDhIWfYh * scale, value.BnoOLWClHLapgAPysAHqWqcOkax * scale);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator /(xMyFYwAcbAMtUwOEeJDvgFFnlCfC value, float scale)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(value.xIuDTKizXrGdQWHryFwOfDhIWfYh / scale, value.BnoOLWClHLapgAPysAHqWqcOkax / scale);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator /(float scale, xMyFYwAcbAMtUwOEeJDvgFFnlCfC value)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(scale / value.xIuDTKizXrGdQWHryFwOfDhIWfYh, scale / value.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator /(xMyFYwAcbAMtUwOEeJDvgFFnlCfC value, xMyFYwAcbAMtUwOEeJDvgFFnlCfC scale)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(value.xIuDTKizXrGdQWHryFwOfDhIWfYh / scale.xIuDTKizXrGdQWHryFwOfDhIWfYh, value.BnoOLWClHLapgAPysAHqWqcOkax / scale.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator +(xMyFYwAcbAMtUwOEeJDvgFFnlCfC value, float scalar)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(value.xIuDTKizXrGdQWHryFwOfDhIWfYh + scalar, value.BnoOLWClHLapgAPysAHqWqcOkax + scalar);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator +(float scalar, xMyFYwAcbAMtUwOEeJDvgFFnlCfC value)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(scalar + value.xIuDTKizXrGdQWHryFwOfDhIWfYh, scalar + value.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator -(xMyFYwAcbAMtUwOEeJDvgFFnlCfC value, float scalar)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(value.xIuDTKizXrGdQWHryFwOfDhIWfYh - scalar, value.BnoOLWClHLapgAPysAHqWqcOkax - scalar);
	}

	public static xMyFYwAcbAMtUwOEeJDvgFFnlCfC operator -(float scalar, xMyFYwAcbAMtUwOEeJDvgFFnlCfC value)
	{
		return new xMyFYwAcbAMtUwOEeJDvgFFnlCfC(scalar - value.xIuDTKizXrGdQWHryFwOfDhIWfYh, scalar - value.BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public static bool operator ==(xMyFYwAcbAMtUwOEeJDvgFFnlCfC left, xMyFYwAcbAMtUwOEeJDvgFFnlCfC right)
	{
		return left.toLtuUpVSfLorNAOBqtEBqxdEiK(ref right);
	}

	public static bool operator !=(xMyFYwAcbAMtUwOEeJDvgFFnlCfC left, xMyFYwAcbAMtUwOEeJDvgFFnlCfC right)
	{
		return !left.toLtuUpVSfLorNAOBqtEBqxdEiK(ref right);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", xIuDTKizXrGdQWHryFwOfDhIWfYh, BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public string yRtDbyVDfwgkaXWMVmTyFkjlBxN(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", xIuDTKizXrGdQWHryFwOfDhIWfYh.ToString(P_0, CultureInfo.CurrentCulture), BnoOLWClHLapgAPysAHqWqcOkax.ToString(P_0, CultureInfo.CurrentCulture));
	}

	public string yRtDbyVDfwgkaXWMVmTyFkjlBxN(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", xIuDTKizXrGdQWHryFwOfDhIWfYh, BnoOLWClHLapgAPysAHqWqcOkax);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			yRtDbyVDfwgkaXWMVmTyFkjlBxN(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", xIuDTKizXrGdQWHryFwOfDhIWfYh.ToString(format, formatProvider), BnoOLWClHLapgAPysAHqWqcOkax.ToString(format, formatProvider));
	}

	public override int GetHashCode()
	{
		return (xIuDTKizXrGdQWHryFwOfDhIWfYh.GetHashCode() * 397) ^ BnoOLWClHLapgAPysAHqWqcOkax.GetHashCode();
	}

	public bool toLtuUpVSfLorNAOBqtEBqxdEiK(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC P_0)
	{
		if (FpTrbTgRASLmrLSXGJpSPdrcCzX.jGcirjVqFqRRNigbGIZUrCcmHfw(P_0.xIuDTKizXrGdQWHryFwOfDhIWfYh, xIuDTKizXrGdQWHryFwOfDhIWfYh))
		{
			return FpTrbTgRASLmrLSXGJpSPdrcCzX.jGcirjVqFqRRNigbGIZUrCcmHfw(P_0.BnoOLWClHLapgAPysAHqWqcOkax, BnoOLWClHLapgAPysAHqWqcOkax);
		}
		return false;
	}

	public bool Equals(xMyFYwAcbAMtUwOEeJDvgFFnlCfC other)
	{
		return toLtuUpVSfLorNAOBqtEBqxdEiK(ref other);
	}

	public override bool Equals(object value)
	{
		if (!(value is xMyFYwAcbAMtUwOEeJDvgFFnlCfC))
		{
			return false;
		}
		xMyFYwAcbAMtUwOEeJDvgFFnlCfC xMyFYwAcbAMtUwOEeJDvgFFnlCfC2 = (xMyFYwAcbAMtUwOEeJDvgFFnlCfC)value;
		return toLtuUpVSfLorNAOBqtEBqxdEiK(ref xMyFYwAcbAMtUwOEeJDvgFFnlCfC2);
	}
}
