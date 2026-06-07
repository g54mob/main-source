using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
[DefaultMember("Item")]
internal struct XfoaMXfmJeVEJMaHvLpQbVkQtNSs : IEquatable<XfoaMXfmJeVEJMaHvLpQbVkQtNSs>, IFormattable
{
	public static readonly int lwTdNjZaJEAVUfCumMdaTkxkySpdA = Marshal.SizeOf(typeof(XfoaMXfmJeVEJMaHvLpQbVkQtNSs));

	public static readonly XfoaMXfmJeVEJMaHvLpQbVkQtNSs DNUQeQhbcXahkIqZaBMMfAOQscLb = default(XfoaMXfmJeVEJMaHvLpQbVkQtNSs);

	public static readonly XfoaMXfmJeVEJMaHvLpQbVkQtNSs qTEixNsRSXPxkOPpIwlbhsasgVTb = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(1f, 0f);

	public static readonly XfoaMXfmJeVEJMaHvLpQbVkQtNSs JJFIbFBZXUHUJPMyTedvwdDAbXyAA = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(0f, 1f);

	public static readonly XfoaMXfmJeVEJMaHvLpQbVkQtNSs bZwvuyPlZMPWIqePTDogIzTlXgBA = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(1f, 1f);

	public float RCyEFnmMbZQABDUevMWhbVQzTujo;

	public float fUeJOoPRVduJmSWUtOameNDdhtWbA;

	public bool ZokArmGvlcROsZVIJlywLtENNTxq => laJhGkdCaiBLmLLAZjPpjIUPwiaL.xkWsphDwssSoMVmHJXhDoSUiCNZb(RCyEFnmMbZQABDUevMWhbVQzTujo * RCyEFnmMbZQABDUevMWhbVQzTujo + fUeJOoPRVduJmSWUtOameNDdhtWbA * fUeJOoPRVduJmSWUtOameNDdhtWbA);

	public bool nntnaKAzJxegDOjKkABLlAJrUNQh
	{
		get
		{
			if (RCyEFnmMbZQABDUevMWhbVQzTujo == 0f)
			{
				return fUeJOoPRVduJmSWUtOameNDdhtWbA == 0f;
			}
			return false;
		}
	}

	public float uwmaNFaseKnqmacVHofPxXyRyWCh
	{
		get
		{
			return P_0 switch
			{
				0 => RCyEFnmMbZQABDUevMWhbVQzTujo, 
				1 => fUeJOoPRVduJmSWUtOameNDdhtWbA, 
				_ => throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive."), 
			};
		}
		set
		{
			switch (num)
			{
			case 0:
				RCyEFnmMbZQABDUevMWhbVQzTujo = rCyEFnmMbZQABDUevMWhbVQzTujo;
				break;
			case 1:
				fUeJOoPRVduJmSWUtOameNDdhtWbA = rCyEFnmMbZQABDUevMWhbVQzTujo;
				break;
			default:
				throw new ArgumentOutOfRangeException("index", "Indices for Vector2 run from 0 to 1, inclusive.");
			}
		}
	}

	public XfoaMXfmJeVEJMaHvLpQbVkQtNSs(float P_0)
	{
		RCyEFnmMbZQABDUevMWhbVQzTujo = P_0;
		fUeJOoPRVduJmSWUtOameNDdhtWbA = P_0;
	}

	public XfoaMXfmJeVEJMaHvLpQbVkQtNSs(float P_0, float P_1)
	{
		RCyEFnmMbZQABDUevMWhbVQzTujo = P_0;
		fUeJOoPRVduJmSWUtOameNDdhtWbA = P_1;
	}

	public XfoaMXfmJeVEJMaHvLpQbVkQtNSs(float[] P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("values");
		}
		if (P_0.Length != 2)
		{
			throw new ArgumentOutOfRangeException("values", "There must be two and only two input values for Vector2.");
		}
		RCyEFnmMbZQABDUevMWhbVQzTujo = P_0[0];
		fUeJOoPRVduJmSWUtOameNDdhtWbA = P_0[1];
	}

	public float eohFsdVkRvyEdEIhDuGsBlzpfOFx()
	{
		return (float)Math.Sqrt(RCyEFnmMbZQABDUevMWhbVQzTujo * RCyEFnmMbZQABDUevMWhbVQzTujo + fUeJOoPRVduJmSWUtOameNDdhtWbA * fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public float qLycillTjoEsxcpyWDLjFrBfDELGB()
	{
		return RCyEFnmMbZQABDUevMWhbVQzTujo * RCyEFnmMbZQABDUevMWhbVQzTujo + fUeJOoPRVduJmSWUtOameNDdhtWbA * fUeJOoPRVduJmSWUtOameNDdhtWbA;
	}

	public void mMsYaNaLSNDjIZJAKbAGUAXaYZzs()
	{
		float num = eohFsdVkRvyEdEIhDuGsBlzpfOFx();
		if (!laJhGkdCaiBLmLLAZjPpjIUPwiaL.nntnaKAzJxegDOjKkABLlAJrUNQh(num))
		{
			float num2 = 1f / num;
			RCyEFnmMbZQABDUevMWhbVQzTujo *= num2;
			fUeJOoPRVduJmSWUtOameNDdhtWbA *= num2;
		}
	}

	public float[] NRjbdIgLZSBUiMHFyBXCghNDOZwAb()
	{
		return new float[2] { RCyEFnmMbZQABDUevMWhbVQzTujo, fUeJOoPRVduJmSWUtOameNDdhtWbA };
	}

	public static void KAmAkAaMzPPJnhzrGYExFxVcAEdOb(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs KAmAkAaMzPPJnhzrGYExFxVcAEdOb(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static void KAmAkAaMzPPJnhzrGYExFxVcAEdOb(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref float P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_1);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs KAmAkAaMzPPJnhzrGYExFxVcAEdOb(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_1);
	}

	public static void jrqDdaILPfAExxJsMqlBZmlOZpKB(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs jrqDdaILPfAExxJsMqlBZmlOZpKB(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static void jrqDdaILPfAExxJsMqlBZmlOZpKB(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref float P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs jrqDdaILPfAExxJsMqlBZmlOZpKB(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1);
	}

	public static void jrqDdaILPfAExxJsMqlBZmlOZpKB(ref float P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0 - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0 - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs jrqDdaILPfAExxJsMqlBZmlOZpKB(float P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0 - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0 - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static void HiCCPUjuBrftehUAOoBYomJZBgSc(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs HiCCPUjuBrftehUAOoBYomJZBgSc(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1);
	}

	public static void HiCCPUjuBrftehUAOoBYomJZBgSc(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs HiCCPUjuBrftehUAOoBYomJZBgSc(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static void NqjPeClNYToxKqdiYsZHksZoGCDY(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo / P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA / P_1);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs NqjPeClNYToxKqdiYsZHksZoGCDY(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo / P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA / P_1);
	}

	public static void NqjPeClNYToxKqdiYsZHksZoGCDY(float P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0 / P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0 / P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs NqjPeClNYToxKqdiYsZHksZoGCDY(float P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0 / P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0 / P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static void wlmpdGYvtMqQGXzTbCwhpaUCBgJH(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		P_1 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(0f - P_0.RCyEFnmMbZQABDUevMWhbVQzTujo, 0f - P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs wlmpdGYvtMqQGXzTbCwhpaUCBgJH(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(0f - P_0.RCyEFnmMbZQABDUevMWhbVQzTujo, 0f - P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static void WVuILBdcZpPmhuMaTXqgGjwXPZvo(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2, float P_3, float P_4, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_5)
	{
		P_5 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + P_3 * (P_1.RCyEFnmMbZQABDUevMWhbVQzTujo - P_0.RCyEFnmMbZQABDUevMWhbVQzTujo) + P_4 * (P_2.RCyEFnmMbZQABDUevMWhbVQzTujo - P_0.RCyEFnmMbZQABDUevMWhbVQzTujo), P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_3 * (P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA) + P_4 * (P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA));
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs WVuILBdcZpPmhuMaTXqgGjwXPZvo(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2, float P_3, float P_4)
	{
		WVuILBdcZpPmhuMaTXqgGjwXPZvo(ref P_0, ref P_1, ref P_2, P_3, P_4, out var result);
		return result;
	}

	public static void OAfahxDzocbfhnPtCbWwEincbMSWA(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_3)
	{
		float rCyEFnmMbZQABDUevMWhbVQzTujo = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo;
		rCyEFnmMbZQABDUevMWhbVQzTujo = ((rCyEFnmMbZQABDUevMWhbVQzTujo > P_2.RCyEFnmMbZQABDUevMWhbVQzTujo) ? P_2.RCyEFnmMbZQABDUevMWhbVQzTujo : rCyEFnmMbZQABDUevMWhbVQzTujo);
		rCyEFnmMbZQABDUevMWhbVQzTujo = ((rCyEFnmMbZQABDUevMWhbVQzTujo < P_1.RCyEFnmMbZQABDUevMWhbVQzTujo) ? P_1.RCyEFnmMbZQABDUevMWhbVQzTujo : rCyEFnmMbZQABDUevMWhbVQzTujo);
		float num = P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA;
		num = ((num > P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA) ? P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA : num);
		num = ((num < P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA) ? P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA : num);
		P_3 = new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(rCyEFnmMbZQABDUevMWhbVQzTujo, num);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs OAfahxDzocbfhnPtCbWwEincbMSWA(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		OAfahxDzocbfhnPtCbWwEincbMSWA(ref P_0, ref P_1, ref P_2, out var result);
		return result;
	}

	public void IzdlKqwzhFtfhTOTLoAcvXtybcIe()
	{
		RCyEFnmMbZQABDUevMWhbVQzTujo = ((RCyEFnmMbZQABDUevMWhbVQzTujo < 0f) ? 0f : ((RCyEFnmMbZQABDUevMWhbVQzTujo > 1f) ? 1f : RCyEFnmMbZQABDUevMWhbVQzTujo));
		fUeJOoPRVduJmSWUtOameNDdhtWbA = ((fUeJOoPRVduJmSWUtOameNDdhtWbA < 0f) ? 0f : ((fUeJOoPRVduJmSWUtOameNDdhtWbA > 1f) ? 1f : fUeJOoPRVduJmSWUtOameNDdhtWbA));
	}

	public static void ZACHNwHYzWvkmeunENJwOCGCTnjgA(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out float P_2)
	{
		float num = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo;
		float num2 = P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA;
		P_2 = (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static float ZACHNwHYzWvkmeunENJwOCGCTnjgA(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		float num = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo;
		float num2 = P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA;
		return (float)Math.Sqrt(num * num + num2 * num2);
	}

	public static void yjPgksWzmZlPzrAUxwmoXkYFRKqX(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out float P_2)
	{
		float num = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo;
		float num2 = P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA;
		P_2 = num * num + num2 * num2;
	}

	public static float yjPgksWzmZlPzrAUxwmoXkYFRKqX(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		float num = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo;
		float num2 = P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA;
		return num * num + num2 * num2;
	}

	public static void kPvfCBCYmQgShosRKMcaHgeCxkVwA(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out float P_2)
	{
		P_2 = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo + P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA;
	}

	public static float kPvfCBCYmQgShosRKMcaHgeCxkVwA(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo + P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA;
	}

	public static void mMsYaNaLSNDjIZJAKbAGUAXaYZzs(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		P_1 = P_0;
		P_1.mMsYaNaLSNDjIZJAKbAGUAXaYZzs();
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs mMsYaNaLSNDjIZJAKbAGUAXaYZzs(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0)
	{
		P_0.mMsYaNaLSNDjIZJAKbAGUAXaYZzs();
		return P_0;
	}

	public static void OejXaIbuXVkFJWJtdnzyCCGhcnNB(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, float P_2, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_3)
	{
		P_3.RCyEFnmMbZQABDUevMWhbVQzTujo = laJhGkdCaiBLmLLAZjPpjIUPwiaL.OejXaIbuXVkFJWJtdnzyCCGhcnNB(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo, P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_2);
		P_3.fUeJOoPRVduJmSWUtOameNDdhtWbA = laJhGkdCaiBLmLLAZjPpjIUPwiaL.OejXaIbuXVkFJWJtdnzyCCGhcnNB(P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA, P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA, P_2);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs OejXaIbuXVkFJWJtdnzyCCGhcnNB(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, float P_2)
	{
		OejXaIbuXVkFJWJtdnzyCCGhcnNB(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void SPgKCLBBnmRVYcKoXlmspLTXGPTGA(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, float P_2, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_3)
	{
		P_2 = laJhGkdCaiBLmLLAZjPpjIUPwiaL.SPgKCLBBnmRVYcKoXlmspLTXGPTGA(P_2);
		OejXaIbuXVkFJWJtdnzyCCGhcnNB(ref P_0, ref P_1, P_2, out P_3);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs SPgKCLBBnmRVYcKoXlmspLTXGPTGA(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, float P_2)
	{
		SPgKCLBBnmRVYcKoXlmspLTXGPTGA(ref P_0, ref P_1, P_2, out var result);
		return result;
	}

	public static void UQReTWdmuCWVdWUJXCwrNQJdfmTd(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_3, float P_4, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		float num3 = 2f * num2 - 3f * num + 1f;
		float num4 = -2f * num2 + 3f * num;
		float num5 = num2 - 2f * num + P_4;
		float num6 = num2 - num;
		P_5.RCyEFnmMbZQABDUevMWhbVQzTujo = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * num3 + P_2.RCyEFnmMbZQABDUevMWhbVQzTujo * num4 + P_1.RCyEFnmMbZQABDUevMWhbVQzTujo * num5 + P_3.RCyEFnmMbZQABDUevMWhbVQzTujo * num6;
		P_5.fUeJOoPRVduJmSWUtOameNDdhtWbA = P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * num3 + P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA * num4 + P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA * num5 + P_3.fUeJOoPRVduJmSWUtOameNDdhtWbA * num6;
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs UQReTWdmuCWVdWUJXCwrNQJdfmTd(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_3, float P_4)
	{
		UQReTWdmuCWVdWUJXCwrNQJdfmTd(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void PBdasBNAngJmGBFmWPzZaaEBbOdC(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_3, float P_4, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_5)
	{
		float num = P_4 * P_4;
		float num2 = P_4 * num;
		P_5.RCyEFnmMbZQABDUevMWhbVQzTujo = 0.5f * (2f * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo + (0f - P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + P_2.RCyEFnmMbZQABDUevMWhbVQzTujo) * P_4 + (2f * P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - 5f * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo + 4f * P_2.RCyEFnmMbZQABDUevMWhbVQzTujo - P_3.RCyEFnmMbZQABDUevMWhbVQzTujo) * num + (0f - P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + 3f * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo - 3f * P_2.RCyEFnmMbZQABDUevMWhbVQzTujo + P_3.RCyEFnmMbZQABDUevMWhbVQzTujo) * num2);
		P_5.fUeJOoPRVduJmSWUtOameNDdhtWbA = 0.5f * (2f * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA + (0f - P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA) * P_4 + (2f * P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - 5f * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA + 4f * P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_3.fUeJOoPRVduJmSWUtOameNDdhtWbA) * num + (0f - P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + 3f * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA - 3f * P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_3.fUeJOoPRVduJmSWUtOameNDdhtWbA) * num2);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs PBdasBNAngJmGBFmWPzZaaEBbOdC(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_3, float P_4)
	{
		PBdasBNAngJmGBFmWPzZaaEBbOdC(ref P_0, ref P_1, ref P_2, ref P_3, P_4, out var result);
		return result;
	}

	public static void ZdmmgeUdFEkxZlQxGiRxWdrAiNuD(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2.RCyEFnmMbZQABDUevMWhbVQzTujo = ((P_0.RCyEFnmMbZQABDUevMWhbVQzTujo > P_1.RCyEFnmMbZQABDUevMWhbVQzTujo) ? P_0.RCyEFnmMbZQABDUevMWhbVQzTujo : P_1.RCyEFnmMbZQABDUevMWhbVQzTujo);
		P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA = ((P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA > P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA) ? P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA : P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs ZdmmgeUdFEkxZlQxGiRxWdrAiNuD(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		ZdmmgeUdFEkxZlQxGiRxWdrAiNuD(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void CiJUtCCwNSGzcEnSMOZVeAtsnGeQ(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		P_2.RCyEFnmMbZQABDUevMWhbVQzTujo = ((P_0.RCyEFnmMbZQABDUevMWhbVQzTujo < P_1.RCyEFnmMbZQABDUevMWhbVQzTujo) ? P_0.RCyEFnmMbZQABDUevMWhbVQzTujo : P_1.RCyEFnmMbZQABDUevMWhbVQzTujo);
		P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA = ((P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA < P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA) ? P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA : P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs CiJUtCCwNSGzcEnSMOZVeAtsnGeQ(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		CiJUtCCwNSGzcEnSMOZVeAtsnGeQ(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void ungOJuUWkhtbSFIvDRmXJWKzeDXt(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1, out XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_2)
	{
		float num = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo + P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA;
		P_2.RCyEFnmMbZQABDUevMWhbVQzTujo = P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - 2f * num * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo;
		P_2.fUeJOoPRVduJmSWUtOameNDdhtWbA = P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - 2f * num * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA;
	}

	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs ungOJuUWkhtbSFIvDRmXJWKzeDXt(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		ungOJuUWkhtbSFIvDRmXJWKzeDXt(ref P_0, ref P_1, out var result);
		return result;
	}

	public static void dEWiadACfLeGmGKNkFwTBvYhGlXJc(XfoaMXfmJeVEJMaHvLpQbVkQtNSs[] P_0, params XfoaMXfmJeVEJMaHvLpQbVkQtNSs[] P_1)
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
			XfoaMXfmJeVEJMaHvLpQbVkQtNSs xfoaMXfmJeVEJMaHvLpQbVkQtNSs = P_1[i];
			for (int j = 0; j < i; j++)
			{
				xfoaMXfmJeVEJMaHvLpQbVkQtNSs = tkmKOgKLQGxLUzGUyKiNKnvLeMXC(xfoaMXfmJeVEJMaHvLpQbVkQtNSs, cGyMudQfwKaaNkvxLZPjxHWJNzmqA(kPvfCBCYmQgShosRKMcaHgeCxkVwA(P_0[j], xfoaMXfmJeVEJMaHvLpQbVkQtNSs) / kPvfCBCYmQgShosRKMcaHgeCxkVwA(P_0[j], P_0[j]), P_0[j]));
			}
			P_0[i] = xfoaMXfmJeVEJMaHvLpQbVkQtNSs;
		}
	}

	public static void mxqXxjILXSpgzkuOqmVAZuQLNYs(XfoaMXfmJeVEJMaHvLpQbVkQtNSs[] P_0, params XfoaMXfmJeVEJMaHvLpQbVkQtNSs[] P_1)
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
			XfoaMXfmJeVEJMaHvLpQbVkQtNSs xfoaMXfmJeVEJMaHvLpQbVkQtNSs = P_1[i];
			for (int j = 0; j < i; j++)
			{
				xfoaMXfmJeVEJMaHvLpQbVkQtNSs = tkmKOgKLQGxLUzGUyKiNKnvLeMXC(xfoaMXfmJeVEJMaHvLpQbVkQtNSs, cGyMudQfwKaaNkvxLZPjxHWJNzmqA(kPvfCBCYmQgShosRKMcaHgeCxkVwA(P_0[j], xfoaMXfmJeVEJMaHvLpQbVkQtNSs), P_0[j]));
			}
			xfoaMXfmJeVEJMaHvLpQbVkQtNSs.mMsYaNaLSNDjIZJAKbAGUAXaYZzs();
			P_0[i] = xfoaMXfmJeVEJMaHvLpQbVkQtNSs;
		}
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs WNeeOBhThZWUtstxmFPWcdmeXhpxB(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs cGyMudQfwKaaNkvxLZPjxHWJNzmqA(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs LTGNnuygPnSYeawCAQqQRleqAFJe(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0)
	{
		return P_0;
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs tkmKOgKLQGxLUzGUyKiNKnvLeMXC(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs SRTuqJPkiLbnsiIKQPyGFVncgEamA(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(0f - P_0.RCyEFnmMbZQABDUevMWhbVQzTujo, 0f - P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs cGyMudQfwKaaNkvxLZPjxHWJNzmqA(float P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_1.RCyEFnmMbZQABDUevMWhbVQzTujo * P_0, P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_0);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs cGyMudQfwKaaNkvxLZPjxHWJNzmqA(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo * P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA * P_1);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs gqDoNkqOLGOhXAasEsswbcntcUqZ(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo / P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA / P_1);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs gqDoNkqOLGOhXAasEsswbcntcUqZ(float P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0 / P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0 / P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs gqDoNkqOLGOhXAasEsswbcntcUqZ(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo / P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA / P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs WNeeOBhThZWUtstxmFPWcdmeXhpxB(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo + P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA + P_1);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs WNeeOBhThZWUtstxmFPWcdmeXhpxB(float P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0 + P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0 + P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs tkmKOgKLQGxLUzGUyKiNKnvLeMXC(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, float P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo - P_1, P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA - P_1);
	}

	[SpecialName]
	public static XfoaMXfmJeVEJMaHvLpQbVkQtNSs tkmKOgKLQGxLUzGUyKiNKnvLeMXC(float P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return new XfoaMXfmJeVEJMaHvLpQbVkQtNSs(P_0 - P_1.RCyEFnmMbZQABDUevMWhbVQzTujo, P_0 - P_1.fUeJOoPRVduJmSWUtOameNDdhtWbA);
	}

	[SpecialName]
	public static bool UxzrDeMrBdIYZHmpHMJBdoPkTemL(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return P_0.XGTrzxcWbPBiyHnRYfIhrjXAmNvN(ref P_1);
	}

	[SpecialName]
	public static bool ymVlplVHAhddfhnAkCmAWabpGMPgb(XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0, XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_1)
	{
		return !P_0.XGTrzxcWbPBiyHnRYfIhrjXAmNvN(ref P_1);
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2] { RCyEFnmMbZQABDUevMWhbVQzTujo, fUeJOoPRVduJmSWUtOameNDdhtWbA });
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG(string P_0)
	{
		if (P_0 == null)
		{
			return ToString();
		}
		return string.Format(CultureInfo.CurrentCulture, "X:{0} Y:{1}", new object[2]
		{
			RCyEFnmMbZQABDUevMWhbVQzTujo.ToString(P_0, CultureInfo.CurrentCulture),
			fUeJOoPRVduJmSWUtOameNDdhtWbA.ToString(P_0, CultureInfo.CurrentCulture)
		});
	}

	public string OJhLXNAKHQXunRxPQYyRrpGAUSuG(IFormatProvider P_0)
	{
		return string.Format(P_0, "X:{0} Y:{1}", new object[2] { RCyEFnmMbZQABDUevMWhbVQzTujo, fUeJOoPRVduJmSWUtOameNDdhtWbA });
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format == null)
		{
			OJhLXNAKHQXunRxPQYyRrpGAUSuG(formatProvider);
		}
		return string.Format(formatProvider, "X:{0} Y:{1}", new object[2]
		{
			RCyEFnmMbZQABDUevMWhbVQzTujo.ToString(format, formatProvider),
			fUeJOoPRVduJmSWUtOameNDdhtWbA.ToString(format, formatProvider)
		});
	}

	public int bmOcwbrzltTGalVFCIlUiIeugfGh()
	{
		return (RCyEFnmMbZQABDUevMWhbVQzTujo.GetHashCode() * 397) ^ fUeJOoPRVduJmSWUtOameNDdhtWbA.GetHashCode();
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(ref XfoaMXfmJeVEJMaHvLpQbVkQtNSs P_0)
	{
		if (laJhGkdCaiBLmLLAZjPpjIUPwiaL.ZamnwYIndGkCTcqBBxfrPTgVuRVd(P_0.RCyEFnmMbZQABDUevMWhbVQzTujo, RCyEFnmMbZQABDUevMWhbVQzTujo))
		{
			return laJhGkdCaiBLmLLAZjPpjIUPwiaL.ZamnwYIndGkCTcqBBxfrPTgVuRVd(P_0.fUeJOoPRVduJmSWUtOameNDdhtWbA, fUeJOoPRVduJmSWUtOameNDdhtWbA);
		}
		return false;
	}

	public bool Equals(XfoaMXfmJeVEJMaHvLpQbVkQtNSs other)
	{
		return XGTrzxcWbPBiyHnRYfIhrjXAmNvN(ref other);
	}

	public bool XGTrzxcWbPBiyHnRYfIhrjXAmNvN(object P_0)
	{
		if (!(P_0 is XfoaMXfmJeVEJMaHvLpQbVkQtNSs xfoaMXfmJeVEJMaHvLpQbVkQtNSs))
		{
			return false;
		}
		return XGTrzxcWbPBiyHnRYfIhrjXAmNvN(ref xfoaMXfmJeVEJMaHvLpQbVkQtNSs);
	}
}
