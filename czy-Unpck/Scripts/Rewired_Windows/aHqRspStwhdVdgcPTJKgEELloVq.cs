using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class aHqRspStwhdVdgcPTJKgEELloVq : global::hUKGPbfBxUOZywKzQaehXkEGSiKp<EPvwwpdyUaBsbxdbBoHDARLdbNL, JiCMCYibPFCCsnNoYEvegAANhdJ>
{
	[CompilerGenerated]
	private int OueiNXHiIUeoSHcpvTKkEUUMXzE;

	[CompilerGenerated]
	private int TGkQcqpQzimTtGPjmrEkCouUcMX;

	[CompilerGenerated]
	private int fPnfbtKhngzeCRNaiWkZEmUEleB;

	[CompilerGenerated]
	private bool[] LJdbycvMYUDEPCDgJmPCAEaptAU;

	public int X
	{
		[CompilerGenerated]
		get
		{
			return OueiNXHiIUeoSHcpvTKkEUUMXzE;
		}
		[CompilerGenerated]
		set
		{
			OueiNXHiIUeoSHcpvTKkEUUMXzE = value;
		}
	}

	public int Y
	{
		[CompilerGenerated]
		get
		{
			return TGkQcqpQzimTtGPjmrEkCouUcMX;
		}
		[CompilerGenerated]
		set
		{
			TGkQcqpQzimTtGPjmrEkCouUcMX = value;
		}
	}

	public int Z
	{
		[CompilerGenerated]
		get
		{
			return fPnfbtKhngzeCRNaiWkZEmUEleB;
		}
		[CompilerGenerated]
		set
		{
			fPnfbtKhngzeCRNaiWkZEmUEleB = value;
		}
	}

	public bool[] Buttons
	{
		[CompilerGenerated]
		get
		{
			return LJdbycvMYUDEPCDgJmPCAEaptAU;
		}
		[CompilerGenerated]
		private set
		{
			LJdbycvMYUDEPCDgJmPCAEaptAU = value;
		}
	}

	public aHqRspStwhdVdgcPTJKgEELloVq()
	{
		Buttons = new bool[8];
	}

	public void FFYEDujhZPZIRSsDbLkeXQkxTZI(JiCMCYibPFCCsnNoYEvegAANhdJ P_0)
	{
		int value = P_0.Value;
		switch (P_0.Offset)
		{
		case JyGPXuuGnWQnEiWwiRmuNcSKdlm.wrxROzSuvTCIlUkzpetQcPCiLlim:
			X = value;
			return;
		case JyGPXuuGnWQnEiWwiRmuNcSKdlm.OmnFwaftRtPzAJrBzVkXEvVueKV:
			Y = value;
			return;
		case JyGPXuuGnWQnEiWwiRmuNcSKdlm.EexeVaafwjvMkVEaSmPrguqfFdfH:
			Z = value;
			return;
		}
		int num = (int)(P_0.Offset - 12);
		if (num >= 0 && num < 8)
		{
			Buttons[num] = (value & 0x80) != 0;
		}
	}

	void global::hUKGPbfBxUOZywKzQaehXkEGSiKp<EPvwwpdyUaBsbxdbBoHDARLdbNL, JiCMCYibPFCCsnNoYEvegAANhdJ>.FFYEDujhZPZIRSsDbLkeXQkxTZI(JiCMCYibPFCCsnNoYEvegAANhdJ P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in FFYEDujhZPZIRSsDbLkeXQkxTZI
		this.FFYEDujhZPZIRSsDbLkeXQkxTZI(P_0);
	}

	public unsafe void wybJdAhTpvWqyyOomZLOcLcMQJK(IntPtr P_0)
	{
		EPvwwpdyUaBsbxdbBoHDARLdbNL* ptr = (EPvwwpdyUaBsbxdbBoHDARLdbNL*)(void*)P_0;
		X = ptr->wrxROzSuvTCIlUkzpetQcPCiLlim;
		Y = ptr->OmnFwaftRtPzAJrBzVkXEvVueKV;
		Z = ptr->EexeVaafwjvMkVEaSmPrguqfFdfH;
		void* ptr2 = &ptr->kvgxnwcmXJfPwIpDErgyOXIkVzq;
		fixed (bool* buttons = Buttons)
		{
			for (int i = 0; i < 8; i++)
			{
				buttons[i] = (((byte*)ptr2)[i] & 0x80) != 0;
			}
		}
	}

	void global::hUKGPbfBxUOZywKzQaehXkEGSiKp<EPvwwpdyUaBsbxdbBoHDARLdbNL, JiCMCYibPFCCsnNoYEvegAANhdJ>.wybJdAhTpvWqyyOomZLOcLcMQJK(IntPtr P_0)
	{
		//ILSpy generated this explicit interface implementation from .override directive in wybJdAhTpvWqyyOomZLOcLcMQJK
		this.wybJdAhTpvWqyyOomZLOcLcMQJK(P_0);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}, Buttons: {3}", X, Y, Z, XhNUbpKnHPBQaARiBNUpPFpGECJ.KPhjBJDiNhyYzqyhMKgYdCkZDgj(";", Buttons));
	}
}
