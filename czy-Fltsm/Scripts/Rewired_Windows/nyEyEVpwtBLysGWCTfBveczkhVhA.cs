using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class nyEyEVpwtBLysGWCTfBveczkhVhA
{
	[CompilerGenerated]
	private DateTime UjkMxWddFxbrlbFJNygacukHOAel;

	[CompilerGenerated]
	private WeakReference hXKBkqGrArraGCNQKNyBMzKrkrcTA;

	[CompilerGenerated]
	private string qWnsJBZfaFPYnaCTGYdiAMEAySBY;

	public DateTime oAyHkEPAJaazKFNceGYHucKmwNYpA
	{
		[CompilerGenerated]
		get
		{
			return UjkMxWddFxbrlbFJNygacukHOAel;
		}
		[CompilerGenerated]
		private set
		{
			UjkMxWddFxbrlbFJNygacukHOAel = ujkMxWddFxbrlbFJNygacukHOAel;
		}
	}

	public WeakReference rSlZfmfBULwcGLLvbPCizKkFaROgA
	{
		[CompilerGenerated]
		get
		{
			return hXKBkqGrArraGCNQKNyBMzKrkrcTA;
		}
		[CompilerGenerated]
		private set
		{
			hXKBkqGrArraGCNQKNyBMzKrkrcTA = weakReference;
		}
	}

	public string bGjiwwFgerfoItCLRJbFWlnnOzoM
	{
		[CompilerGenerated]
		get
		{
			return qWnsJBZfaFPYnaCTGYdiAMEAySBY;
		}
		[CompilerGenerated]
		private set
		{
			qWnsJBZfaFPYnaCTGYdiAMEAySBY = text;
		}
	}

	public bool elXsmaTtFphLcMbeRALpWIxWnCoK => rSlZfmfBULwcGLLvbPCizKkFaROgA.IsAlive;

	public nyEyEVpwtBLysGWCTfBveczkhVhA(DateTime P_0, MndfuDfWnbszkTmnTPSZnWvaJpehA P_1, string P_2)
	{
		oAyHkEPAJaazKFNceGYHucKmwNYpA = P_0;
		rSlZfmfBULwcGLLvbPCizKkFaROgA = new WeakReference(P_1, trackResurrection: true);
		bGjiwwFgerfoItCLRJbFWlnnOzoM = P_2;
	}

	public virtual string YQTCoEIrTUxecUtuLZQLBuidLnIuA()
	{
		if (!(rSlZfmfBULwcGLLvbPCizKkFaROgA.Target is MndfuDfWnbszkTmnTPSZnWvaJpehA mndfuDfWnbszkTmnTPSZnWvaJpehA))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", mndfuDfWnbszkTmnTPSZnWvaJpehA.cOaLXRsqVRuSojLsgpkROlcJOCEr.ToInt64(), mndfuDfWnbszkTmnTPSZnWvaJpehA.GetType().FullName, oAyHkEPAJaazKFNceGYHucKmwNYpA, bGjiwwFgerfoItCLRJbFWlnnOzoM).AppendLine();
		return stringBuilder.ToString();
	}
}
