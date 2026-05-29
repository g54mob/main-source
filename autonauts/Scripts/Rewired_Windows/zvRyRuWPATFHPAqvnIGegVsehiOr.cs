using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class zvRyRuWPATFHPAqvnIGegVsehiOr : global::ohjCRaNdZyNtQMEVoWzrnLnKGkg<BkQwEgvlsCSKDfYVzMOZBdmxdLn, YGhFMZkyBxnaurqhujBtrEhHybr>
{
	[CompilerGenerated]
	private int PVBDGIFqKsSqusFCJRqoLzuAtCg;

	[CompilerGenerated]
	private int CtVIOvhamOVKbYClMacaHVRINcdQ;

	[CompilerGenerated]
	private int wWIqhySETAuFwPrUQTRBNUhQRrh;

	[CompilerGenerated]
	private bool[] CkWAybzdsgzitVtGrwCSXRRvKCo;

	public int X
	{
		[CompilerGenerated]
		get
		{
			return PVBDGIFqKsSqusFCJRqoLzuAtCg;
		}
		[CompilerGenerated]
		set
		{
			PVBDGIFqKsSqusFCJRqoLzuAtCg = value;
		}
	}

	public int Y
	{
		[CompilerGenerated]
		get
		{
			return CtVIOvhamOVKbYClMacaHVRINcdQ;
		}
		[CompilerGenerated]
		set
		{
			CtVIOvhamOVKbYClMacaHVRINcdQ = value;
		}
	}

	public int Z
	{
		[CompilerGenerated]
		get
		{
			return wWIqhySETAuFwPrUQTRBNUhQRrh;
		}
		[CompilerGenerated]
		set
		{
			wWIqhySETAuFwPrUQTRBNUhQRrh = value;
		}
	}

	public bool[] Buttons
	{
		[CompilerGenerated]
		get
		{
			return CkWAybzdsgzitVtGrwCSXRRvKCo;
		}
		[CompilerGenerated]
		private set
		{
			CkWAybzdsgzitVtGrwCSXRRvKCo = value;
		}
	}

	public zvRyRuWPATFHPAqvnIGegVsehiOr()
	{
		Buttons = new bool[8];
	}

	public void Update(YGhFMZkyBxnaurqhujBtrEhHybr P_0)
	{
		int value = P_0.Value;
		switch (P_0.Offset)
		{
		case ERjtNzmsJyamqiHKUeCoQVdEFzIc.xEUKPyQaTfqoROGHJowSWeletXA:
			X = value;
			return;
		case ERjtNzmsJyamqiHKUeCoQVdEFzIc.VeUXJbtopZnzuPExHBOZDuueBov:
			Y = value;
			return;
		case ERjtNzmsJyamqiHKUeCoQVdEFzIc.PsCVNjrFWDGyKCgOuJMnniLdbxT:
			Z = value;
			return;
		}
		int num = (int)(P_0.Offset - 12);
		if (num >= 0 && num < 8)
		{
			Buttons[num] = (value & 0x80) != 0;
		}
	}

	public unsafe void MarshalFrom(IntPtr P_0)
	{
		BkQwEgvlsCSKDfYVzMOZBdmxdLn* ptr = (BkQwEgvlsCSKDfYVzMOZBdmxdLn*)(void*)P_0;
		X = ptr->xEUKPyQaTfqoROGHJowSWeletXA;
		Y = ptr->VeUXJbtopZnzuPExHBOZDuueBov;
		Z = ptr->PsCVNjrFWDGyKCgOuJMnniLdbxT;
		void* ptr2 = &ptr->tCZBnjIanpTLMWOdmkssjTpuuZEF;
		fixed (bool* buttons = Buttons)
		{
			for (int i = 0; i < 8; i++)
			{
				buttons[i] = (((byte*)ptr2)[i] & 0x80) != 0;
			}
		}
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}, Buttons: {3}", X, Y, Z, QiyhMeApbloIAQYCjGAvUEQIhAz.JCYHSQHxbTyAHuDpgTGImGXDewF(";", Buttons));
	}
}
