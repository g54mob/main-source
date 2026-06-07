using System;
using Rewired.Utils;

internal class AhIGwJhtRkfPmaiXDLmmxmUKsJmG : IDisposable
{
	private readonly DCzMZYjZMZbSBuYhLKaUQoUIzoZ MGmVOJiswkwnBAbvbGQwLtBdeEt;

	private readonly int GztFpxeGTJzsZcxGfxebDvBnDPSg;

	private long vQFulaNkvjnckpTdoihIXncZcEV;

	private long wmPgjXakHipweIbeQMqHZcPsfZsg;

	private int cskzKjxFjQXhWlJpejfbDDJDiEIe;

	private bool MCnimEpUpXNvLgZkStdgtCQrFmj;

	private uint DovbIGEplXmMVDngFoemCTegrgON;

	private bool euujVPFzGztViWDbYvUutBvFQFP;

	public int Capacity => GztFpxeGTJzsZcxGfxebDvBnDPSg;

	public int BytesInBuffer => cskzKjxFjQXhWlJpejfbDDJDiEIe;

	public bool BufferOverrun => MCnimEpUpXNvLgZkStdgtCQrFmj;

	public AhIGwJhtRkfPmaiXDLmmxmUKsJmG(int capacity)
	{
		GztFpxeGTJzsZcxGfxebDvBnDPSg = capacity;
		if (capacity <= 0)
		{
			throw new ArgumentOutOfRangeException("sizeInBytes");
		}
		MGmVOJiswkwnBAbvbGQwLtBdeEt = new DCzMZYjZMZbSBuYhLKaUQoUIzoZ(capacity);
	}

	public unsafe int xwyOTGiXUEnQReUfdMBlfOwNgvM(byte* P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		P_3 = (int)vQFulaNkvjnckpTdoihIXncZcEV;
		P_4 = DovbIGEplXmMVDngFoemCTegrgON;
		if (P_0 == null || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		int num = MGmVOJiswkwnBAbvbGQwLtBdeEt.dpRzKpmKAUkiSitZiXveOkUIvfw(P_0, P_1, P_2, (int)vQFulaNkvjnckpTdoihIXncZcEV);
		if (num == 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += MGmVOJiswkwnBAbvbGQwLtBdeEt.dpRzKpmKAUkiSitZiXveOkUIvfw(P_0 + num, P_1 - num, P_2 - num);
		}
		QTdbsyOrrhxcautpMLmBEDPEQrH(num);
		return num;
	}

	public unsafe int xwyOTGiXUEnQReUfdMBlfOwNgvM(IntPtr P_0, int P_1, int P_2, out int P_3, out uint P_4)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			P_3 = (int)vQFulaNkvjnckpTdoihIXncZcEV;
			P_4 = DovbIGEplXmMVDngFoemCTegrgON;
			return 0;
		}
		return xwyOTGiXUEnQReUfdMBlfOwNgvM((byte*)(void*)P_0, P_1, P_2, out P_3, out P_4);
	}

	public unsafe int xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0, int P_1, out int P_2, out uint P_3)
	{
		if (P_0 == null || P_1 <= 0)
		{
			P_2 = (int)vQFulaNkvjnckpTdoihIXncZcEV;
			P_3 = DovbIGEplXmMVDngFoemCTegrgON;
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return xwyOTGiXUEnQReUfdMBlfOwNgvM(ptr, P_0.Length, P_1, out P_2, out P_3);
		}
	}

	public unsafe int xwyOTGiXUEnQReUfdMBlfOwNgvM(byte* P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return xwyOTGiXUEnQReUfdMBlfOwNgvM(P_0, P_1, P_2, out num, out num2);
	}

	public int xwyOTGiXUEnQReUfdMBlfOwNgvM(IntPtr P_0, int P_1, int P_2)
	{
		int num;
		uint num2;
		return xwyOTGiXUEnQReUfdMBlfOwNgvM(P_0, P_1, P_2, out num, out num2);
	}

	public int xwyOTGiXUEnQReUfdMBlfOwNgvM(byte[] P_0, int P_1)
	{
		int num;
		uint num2;
		return xwyOTGiXUEnQReUfdMBlfOwNgvM(P_0, P_1, out num, out num2);
	}

	public unsafe int OyoZWUuiamgvSVRBhbJZhjZZxdr(byte* P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || cskzKjxFjQXhWlJpejfbDDJDiEIe == 0)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > cskzKjxFjQXhWlJpejfbDDJDiEIe)
		{
			P_2 = cskzKjxFjQXhWlJpejfbDDJDiEIe;
		}
		int num = MGmVOJiswkwnBAbvbGQwLtBdeEt.PomFOnmcQgClBNCxQerVwIDHIlac(P_0, P_1, P_2, (int)wmPgjXakHipweIbeQMqHZcPsfZsg);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += MGmVOJiswkwnBAbvbGQwLtBdeEt.PomFOnmcQgClBNCxQerVwIDHIlac(P_0 + num, P_1 - num, P_2 - num);
		}
		cdpRyVbLWPRjKxkYETezLJmJYYU(num);
		return num;
	}

	public unsafe int OyoZWUuiamgvSVRBhbJZhjZZxdr(byte[] P_0, int P_1)
	{
		if (P_0 == null || P_1 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return OyoZWUuiamgvSVRBhbJZhjZZxdr(ptr, P_0.Length, P_1);
		}
	}

	public unsafe int OyoZWUuiamgvSVRBhbJZhjZZxdr(IntPtr P_0, int P_1, int P_2)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		return OyoZWUuiamgvSVRBhbJZhjZZxdr((byte*)(void*)P_0, P_1, P_2);
	}

	public unsafe int dXCYFuvCOffJxmSZZzDGbmRkFBM(byte* P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == null || P_1 <= 0 || P_2 <= 0 || cskzKjxFjQXhWlJpejfbDDJDiEIe == 0 || P_3 < 0 || P_3 >= GztFpxeGTJzsZcxGfxebDvBnDPSg)
		{
			return 0;
		}
		if (P_2 > P_1)
		{
			P_2 = P_1;
		}
		if (P_2 > cskzKjxFjQXhWlJpejfbDDJDiEIe)
		{
			P_2 = cskzKjxFjQXhWlJpejfbDDJDiEIe;
		}
		int num = MGmVOJiswkwnBAbvbGQwLtBdeEt.PomFOnmcQgClBNCxQerVwIDHIlac(P_0, P_1, P_2, P_3);
		if (num <= 0)
		{
			return 0;
		}
		if (num < P_2)
		{
			num += MGmVOJiswkwnBAbvbGQwLtBdeEt.PomFOnmcQgClBNCxQerVwIDHIlac(P_0 + num, P_1 - num, P_2 - num);
		}
		return num;
	}

	public unsafe int dXCYFuvCOffJxmSZZzDGbmRkFBM(byte[] P_0, int P_1, int P_2)
	{
		if (P_0 == null || P_1 <= 0 || P_1 <= 0 || P_2 <= 0)
		{
			return 0;
		}
		fixed (byte* ptr = P_0)
		{
			return dXCYFuvCOffJxmSZZzDGbmRkFBM(ptr, P_0.Length, P_1, P_2);
		}
	}

	public unsafe int dXCYFuvCOffJxmSZZzDGbmRkFBM(IntPtr P_0, int P_1, int P_2, int P_3)
	{
		if (P_0 == IntPtr.Zero || P_1 <= 0 || P_2 <= 0 || P_3 <= 0)
		{
			return 0;
		}
		return dXCYFuvCOffJxmSZZzDGbmRkFBM((byte*)(void*)P_0, P_1, P_2, P_3);
	}

	public bool eDbsbVnTYvcfzlIKIuPEqDQASxg(int P_0, uint P_1)
	{
		if (P_0 < 0 || P_0 >= GztFpxeGTJzsZcxGfxebDvBnDPSg)
		{
			return false;
		}
		if (P_0 < vQFulaNkvjnckpTdoihIXncZcEV)
		{
			if (P_1 == DovbIGEplXmMVDngFoemCTegrgON)
			{
				return true;
			}
		}
		else if (P_0 >= vQFulaNkvjnckpTdoihIXncZcEV)
		{
			if (DovbIGEplXmMVDngFoemCTegrgON == 0)
			{
				return false;
			}
			if (DovbIGEplXmMVDngFoemCTegrgON - 1 == P_1)
			{
				return true;
			}
		}
		return false;
	}

	public void JqSXKgZspIzlwNxbIhfPpoqGbbz()
	{
		vQFulaNkvjnckpTdoihIXncZcEV = 0L;
		wmPgjXakHipweIbeQMqHZcPsfZsg = 0L;
		cskzKjxFjQXhWlJpejfbDDJDiEIe = 0;
		MCnimEpUpXNvLgZkStdgtCQrFmj = false;
		DovbIGEplXmMVDngFoemCTegrgON = 0u;
	}

	private void QTdbsyOrrhxcautpMLmBEDPEQrH(int P_0)
	{
		if (P_0 <= 0)
		{
			return;
		}
		int num = (int)vQFulaNkvjnckpTdoihIXncZcEV;
		vQFulaNkvjnckpTdoihIXncZcEV += P_0;
		bool flag = false;
		if (num < wmPgjXakHipweIbeQMqHZcPsfZsg)
		{
			if (vQFulaNkvjnckpTdoihIXncZcEV > wmPgjXakHipweIbeQMqHZcPsfZsg)
			{
				flag = true;
			}
		}
		else if (num > wmPgjXakHipweIbeQMqHZcPsfZsg)
		{
			if (vQFulaNkvjnckpTdoihIXncZcEV - GztFpxeGTJzsZcxGfxebDvBnDPSg > wmPgjXakHipweIbeQMqHZcPsfZsg)
			{
				flag = true;
			}
		}
		else if (cskzKjxFjQXhWlJpejfbDDJDiEIe > 0)
		{
			flag = true;
		}
		if (flag)
		{
			MCnimEpUpXNvLgZkStdgtCQrFmj = true;
			wmPgjXakHipweIbeQMqHZcPsfZsg = vQFulaNkvjnckpTdoihIXncZcEV;
			if (wmPgjXakHipweIbeQMqHZcPsfZsg >= GztFpxeGTJzsZcxGfxebDvBnDPSg)
			{
				wmPgjXakHipweIbeQMqHZcPsfZsg -= GztFpxeGTJzsZcxGfxebDvBnDPSg;
			}
		}
		if (vQFulaNkvjnckpTdoihIXncZcEV >= GztFpxeGTJzsZcxGfxebDvBnDPSg)
		{
			vQFulaNkvjnckpTdoihIXncZcEV -= GztFpxeGTJzsZcxGfxebDvBnDPSg;
			kMnsMPrfxGZdOdLKDzpqasVOeHJ();
		}
		cskzKjxFjQXhWlJpejfbDDJDiEIe = (int)MathTools.Clamp((long)cskzKjxFjQXhWlJpejfbDDJDiEIe + (long)P_0, 0L, GztFpxeGTJzsZcxGfxebDvBnDPSg);
	}

	private void cdpRyVbLWPRjKxkYETezLJmJYYU(int P_0)
	{
		if (P_0 > 0)
		{
			if (MCnimEpUpXNvLgZkStdgtCQrFmj)
			{
				MCnimEpUpXNvLgZkStdgtCQrFmj = false;
			}
			wmPgjXakHipweIbeQMqHZcPsfZsg += P_0;
			if (wmPgjXakHipweIbeQMqHZcPsfZsg >= GztFpxeGTJzsZcxGfxebDvBnDPSg)
			{
				wmPgjXakHipweIbeQMqHZcPsfZsg -= GztFpxeGTJzsZcxGfxebDvBnDPSg;
			}
			long num = (long)cskzKjxFjQXhWlJpejfbDDJDiEIe - (long)P_0;
			cskzKjxFjQXhWlJpejfbDDJDiEIe = (int)((num >= 0) ? num : 0);
		}
	}

	private void kMnsMPrfxGZdOdLKDzpqasVOeHJ()
	{
		if (DovbIGEplXmMVDngFoemCTegrgON == uint.MaxValue)
		{
			DovbIGEplXmMVDngFoemCTegrgON = 0u;
		}
		else
		{
			DovbIGEplXmMVDngFoemCTegrgON++;
		}
	}

	public void Dispose()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(true);
		GC.SuppressFinalize(this);
	}

	~AhIGwJhtRkfPmaiXDLmmxmUKsJmG()
	{
		KRgasgBmyLeCeDGJhNGqwMeOqCwJ(false);
	}

	protected void KRgasgBmyLeCeDGJhNGqwMeOqCwJ(bool P_0)
	{
		if (!euujVPFzGztViWDbYvUutBvFQFP)
		{
			if (P_0 && MGmVOJiswkwnBAbvbGQwLtBdeEt != null)
			{
				MGmVOJiswkwnBAbvbGQwLtBdeEt.Dispose();
			}
			euujVPFzGztViWDbYvUutBvFQFP = true;
		}
	}
}
