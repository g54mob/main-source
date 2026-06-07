using System.Collections.Generic;
using Rewired.Utils;

internal class gHDldKZwkuMzyeVpZkScEkEvRLzo : QHiAClADbJnDqzrVZKYXIrwOCrSLA
{
	private List<JtVAFdAAqFdeeKKhACKIgTugRqqQA> YiYcCugHmLWFWXSADtReRLdHYEAn;

	private JtVAFdAAqFdeeKKhACKIgTugRqqQA[] kbKQaqyheIIFakeEfNbHWetJgXum;

	private bool kFiCfGAGJREDEdKpMFnZHSmBjxbqA;

	public gHDldKZwkuMzyeVpZkScEkEvRLzo()
	{
		YiYcCugHmLWFWXSADtReRLdHYEAn = new List<JtVAFdAAqFdeeKKhACKIgTugRqqQA>();
	}

	public virtual void UtMdPHfObVYidrLXhQiTanKYjYUZ(JtVAFdAAqFdeeKKhACKIgTugRqqQA P_0)
	{
		YiYcCugHmLWFWXSADtReRLdHYEAn.Add(P_0);
	}

	public float JsdLJuvJFWtMNMRkkyWGxZdvTLbL(int P_0)
	{
		if (P_0 < 0 || P_0 >= kbKQaqyheIIFakeEfNbHWetJgXum.Length)
		{
			return 0f;
		}
		return wzFoeTliGlHddemqyvcbdqFxpMFrA(kbKQaqyheIIFakeEfNbHWetJgXum[P_0].aPgattFaGImnDxtPdSTDfqicLFbcA);
	}

	public int wOBdZzzDmWRbEIeJdqAwLuVvhCDL(int P_0)
	{
		if (P_0 < 0 || P_0 >= kbKQaqyheIIFakeEfNbHWetJgXum.Length)
		{
			return 0;
		}
		return (int)kbKQaqyheIIFakeEfNbHWetJgXum[P_0].nvjcgGHAtWufLZzsxbbTKGYPGqlS;
	}

	public virtual void BmWDAIaaRMqhnMnSPpAfgaQVStYXA()
	{
		if (!kFiCfGAGJREDEdKpMFnZHSmBjxbqA)
		{
			kFiCfGAGJREDEdKpMFnZHSmBjxbqA = true;
			kbKQaqyheIIFakeEfNbHWetJgXum = YiYcCugHmLWFWXSADtReRLdHYEAn.ToArray();
			YiYcCugHmLWFWXSADtReRLdHYEAn = null;
		}
	}

	private static float wzFoeTliGlHddemqyvcbdqFxpMFrA(int P_0)
	{
		if (P_0 == 0)
		{
			return 0f;
		}
		return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
	}
}
