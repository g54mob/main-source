using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

internal class tRWrAqQFELdkPdRwaGBSevaiiZkVA
{
	[CompilerGenerated]
	private DateTime AvGegaBAhVlCOhYjfFQliheMBqBmA;

	[CompilerGenerated]
	private WeakReference zaiUvCKnyNJJxcQwgYxIaJEyLiBg;

	[CompilerGenerated]
	private string clLlpQmIxXxMBNvFqVpIXACZkeaC;

	public DateTime wNMEKysGhQIidowUSokMpjCblorf
	{
		[CompilerGenerated]
		get
		{
			return AvGegaBAhVlCOhYjfFQliheMBqBmA;
		}
		[CompilerGenerated]
		private set
		{
			AvGegaBAhVlCOhYjfFQliheMBqBmA = avGegaBAhVlCOhYjfFQliheMBqBmA;
		}
	}

	public WeakReference tfTXCCAHqxDXnaBDPHkhaWuIdhbT
	{
		[CompilerGenerated]
		get
		{
			return zaiUvCKnyNJJxcQwgYxIaJEyLiBg;
		}
		[CompilerGenerated]
		private set
		{
			zaiUvCKnyNJJxcQwgYxIaJEyLiBg = weakReference;
		}
	}

	public string txFeQUJqABgKbbKzDlDQQXhdgTERe
	{
		[CompilerGenerated]
		get
		{
			return clLlpQmIxXxMBNvFqVpIXACZkeaC;
		}
		[CompilerGenerated]
		private set
		{
			clLlpQmIxXxMBNvFqVpIXACZkeaC = text;
		}
	}

	public bool uafIYSdcbVUCZqfGxOkybPriLZRsb => tfTXCCAHqxDXnaBDPHkhaWuIdhbT.IsAlive;

	public tRWrAqQFELdkPdRwaGBSevaiiZkVA(DateTime P_0, WDLIqztsTFKKRNeHzsLEXCzxPiJg P_1, string P_2)
	{
		wNMEKysGhQIidowUSokMpjCblorf = P_0;
		tfTXCCAHqxDXnaBDPHkhaWuIdhbT = new WeakReference(P_1, trackResurrection: true);
		txFeQUJqABgKbbKzDlDQQXhdgTERe = P_2;
	}

	public virtual string YTrQZeYnpkBwJSJKdmgYnVsiZBtH()
	{
		if (!(tfTXCCAHqxDXnaBDPHkhaWuIdhbT.Target is WDLIqztsTFKKRNeHzsLEXCzxPiJg wDLIqztsTFKKRNeHzsLEXCzxPiJg))
		{
			return "";
		}
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "Active COM Object: [0x{0:X}] Class: [{1}] Time [{2}] Stack:\r\n{3}", wDLIqztsTFKKRNeHzsLEXCzxPiJg.sFCfjzNbPtpSBOIOUASCBueAerzc.ToInt64(), wDLIqztsTFKKRNeHzsLEXCzxPiJg.GetType().FullName, wNMEKysGhQIidowUSokMpjCblorf, txFeQUJqABgKbbKzDlDQQXhdgTERe).AppendLine();
		return stringBuilder.ToString();
	}
}
