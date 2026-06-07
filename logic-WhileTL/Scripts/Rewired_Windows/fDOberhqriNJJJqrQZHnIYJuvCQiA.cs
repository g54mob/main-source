using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class fDOberhqriNJJJqrQZHnIYJuvCQiA
{
	[CompilerGenerated]
	private DateTime DhNAFgbNCBJUlepTqjPaHgYTcviOA;

	[CompilerGenerated]
	private WeakReference pkADjdAFTOiSpcInXfWgtqqQjjuuA;

	[CompilerGenerated]
	private string GacvcSGGEmyIwwJOXKtAgeuPDDmu;

	public DateTime AmsBvXjBEgcrxtFSlfOEzSoEnxHe
	{
		[CompilerGenerated]
		get
		{
			return DhNAFgbNCBJUlepTqjPaHgYTcviOA;
		}
		[CompilerGenerated]
		private set
		{
			DhNAFgbNCBJUlepTqjPaHgYTcviOA = dhNAFgbNCBJUlepTqjPaHgYTcviOA;
		}
	}

	public WeakReference bIukRKkLMcBYSITRuOxHqcCZXzvr
	{
		[CompilerGenerated]
		get
		{
			return pkADjdAFTOiSpcInXfWgtqqQjjuuA;
		}
		[CompilerGenerated]
		private set
		{
			pkADjdAFTOiSpcInXfWgtqqQjjuuA = weakReference;
		}
	}

	public string AJKCgrntGsFrRsAFgfpZkmSDTthIA
	{
		[CompilerGenerated]
		get
		{
			return GacvcSGGEmyIwwJOXKtAgeuPDDmu;
		}
		[CompilerGenerated]
		private set
		{
			GacvcSGGEmyIwwJOXKtAgeuPDDmu = gacvcSGGEmyIwwJOXKtAgeuPDDmu;
		}
	}

	public bool lNhWqqclxSiPHTFkYKuBLfxZoItw => bIukRKkLMcBYSITRuOxHqcCZXzvr.IsAlive;

	public fDOberhqriNJJJqrQZHnIYJuvCQiA(DateTime P_0, AJRifcVCqqldPIiAPgwvytGljCrw P_1, string P_2)
	{
		AmsBvXjBEgcrxtFSlfOEzSoEnxHe = P_0;
		bIukRKkLMcBYSITRuOxHqcCZXzvr = new WeakReference(P_1, trackResurrection: true);
		AJKCgrntGsFrRsAFgfpZkmSDTthIA = P_2;
	}

	public virtual string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
	{
		if (!(bIukRKkLMcBYSITRuOxHqcCZXzvr.Target is AJRifcVCqqldPIiAPgwvytGljCrw aJRifcVCqqldPIiAPgwvytGljCrw))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", aJRifcVCqqldPIiAPgwvytGljCrw.EEEaoiMKSwLCOBgsTjMBeDlbgYMaA.ToInt64(), aJRifcVCqqldPIiAPgwvytGljCrw.GetType().FullName, AmsBvXjBEgcrxtFSlfOEzSoEnxHe, AJKCgrntGsFrRsAFgfpZkmSDTthIA).AppendLine();
		return stringBuilder.ToString();
	}
}
