using System;
using System.Globalization;
using System.Runtime.CompilerServices;

internal class TxhGYhiGmljUZdvKRsYRsTRcrEbh : OWNGqhbJvUXJOZIyMZKGGdWRctLr<povbvaRKcguLGqgcLuCkuJsaYBAD, sZDULQYftFuKusUEGWpSACQMTcYy>
{
	[CompilerGenerated]
	private int nAhSbPnXWEwjmfQodjwParCDofDk;

	[CompilerGenerated]
	private int cYdvBcZwCuRafBNOcCSNmJaVFdCu;

	[CompilerGenerated]
	private int GhoEgnHsreUpusSpqDboOyCJKoQvA;

	[CompilerGenerated]
	private bool[] sLmjSmDWPAIctGJlJgFrwBsgHtNL;

	public int RCyEFnmMbZQABDUevMWhbVQzTujo
	{
		[CompilerGenerated]
		get
		{
			return nAhSbPnXWEwjmfQodjwParCDofDk;
		}
		[CompilerGenerated]
		set
		{
			nAhSbPnXWEwjmfQodjwParCDofDk = num;
		}
	}

	public int fUeJOoPRVduJmSWUtOameNDdhtWbA
	{
		[CompilerGenerated]
		get
		{
			return cYdvBcZwCuRafBNOcCSNmJaVFdCu;
		}
		[CompilerGenerated]
		set
		{
			cYdvBcZwCuRafBNOcCSNmJaVFdCu = num;
		}
	}

	public int vmuQckHIsdYcQHmrIqHKUcokekox
	{
		[CompilerGenerated]
		get
		{
			return GhoEgnHsreUpusSpqDboOyCJKoQvA;
		}
		[CompilerGenerated]
		set
		{
			GhoEgnHsreUpusSpqDboOyCJKoQvA = ghoEgnHsreUpusSpqDboOyCJKoQvA;
		}
	}

	public bool[] cSTdYhCfOIlkyjUlxiceJHSyagLSA
	{
		[CompilerGenerated]
		get
		{
			return sLmjSmDWPAIctGJlJgFrwBsgHtNL;
		}
		[CompilerGenerated]
		private set
		{
			sLmjSmDWPAIctGJlJgFrwBsgHtNL = array;
		}
	}

	public TxhGYhiGmljUZdvKRsYRsTRcrEbh()
	{
		cSTdYhCfOIlkyjUlxiceJHSyagLSA = new bool[8];
	}

	public void Update(sZDULQYftFuKusUEGWpSACQMTcYy P_0)
	{
		int num = P_0.RtpBzFbXNdKlVQFqDSXaQVpGPMfd;
		switch (P_0.TTtgUKYgdZCFwfPnuEPtEhTwLbIn)
		{
		case kHBhKsUNpSdQkCldeakFexAEHujZB.X:
			RCyEFnmMbZQABDUevMWhbVQzTujo = num;
			return;
		case kHBhKsUNpSdQkCldeakFexAEHujZB.Y:
			fUeJOoPRVduJmSWUtOameNDdhtWbA = num;
			return;
		case kHBhKsUNpSdQkCldeakFexAEHujZB.Z:
			vmuQckHIsdYcQHmrIqHKUcokekox = num;
			return;
		}
		int num2 = (int)(P_0.TTtgUKYgdZCFwfPnuEPtEhTwLbIn - 12);
		if (num2 >= 0 && num2 < 8)
		{
			cSTdYhCfOIlkyjUlxiceJHSyagLSA[num2] = (num & 0x80) != 0;
		}
	}

	public unsafe void MarshalFrom(IntPtr P_0)
	{
		povbvaRKcguLGqgcLuCkuJsaYBAD* ptr = (povbvaRKcguLGqgcLuCkuJsaYBAD*)(void*)P_0;
		RCyEFnmMbZQABDUevMWhbVQzTujo = ptr->RCyEFnmMbZQABDUevMWhbVQzTujo;
		fUeJOoPRVduJmSWUtOameNDdhtWbA = ptr->fUeJOoPRVduJmSWUtOameNDdhtWbA;
		vmuQckHIsdYcQHmrIqHKUcokekox = ptr->vmuQckHIsdYcQHmrIqHKUcokekox;
		void* ptr2 = &ptr->JJfKayALNFDfEPXISAIBguWtTIbt;
		fixed (bool* ptr3 = cSTdYhCfOIlkyjUlxiceJHSyagLSA)
		{
			for (int i = 0; i < 8; i++)
			{
				ptr3[i] = (((byte*)ptr2)[i] & 0x80) != 0;
			}
		}
	}

	public virtual string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		return string.Format(CultureInfo.InvariantCulture, "X: {0}, Y: {1}, Z: {2}, Buttons: {3}", RCyEFnmMbZQABDUevMWhbVQzTujo, fUeJOoPRVduJmSWUtOameNDdhtWbA, vmuQckHIsdYcQHmrIqHKUcokekox, qUbotaSLZASADLtRbuWjzvVhFURA.tZoSuFzNBjWbBxKsAtWzHuoGlimg(";", cSTdYhCfOIlkyjUlxiceJHSyagLSA));
	}
}
