using System;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;

internal abstract class jjEiJGkdrKfqxJAsceTeoFkgoNMlA : xhsfjMHWBKokSPBLxdeojZhcJxoeA
{
	public class hRRFKErLSbMgVBVhVVXtNEkVPkde
	{
		public readonly AxisDirection? XdrIyCHSvCOtelgsOknkTmjdPjQPA;

		public hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection? P_0)
		{
			XdrIyCHSvCOtelgsOknkTmjdPjQPA = P_0;
		}
	}

	public class PEZtEoWUXFickyhTPzxGMRoQswOL
	{
		private readonly AList<hRRFKErLSbMgVBVhVVXtNEkVPkde> qVAbhiklBWHqSQhWTfDpcvQFTBVNb;

		public readonly int PewIUhZMyGUcqMDJtzetvXdUpuqS;

		public PEZtEoWUXFickyhTPzxGMRoQswOL(AList<hRRFKErLSbMgVBVhVVXtNEkVPkde> P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException();
			}
			for (int i = 0; i < P_0._count; i++)
			{
				if (P_0._items[i] == null)
				{
					throw new ArgumentNullException();
				}
			}
			qVAbhiklBWHqSQhWTfDpcvQFTBVNb = P_0;
			PewIUhZMyGUcqMDJtzetvXdUpuqS = qVAbhiklBWHqSQhWTfDpcvQFTBVNb._count;
		}

		public hRRFKErLSbMgVBVhVVXtNEkVPkde IaedbspyldSLenBPDisowZTAxgvk(int P_0)
		{
			return qVAbhiklBWHqSQhWTfDpcvQFTBVNb._items[P_0];
		}

		public int GufixudKIxAbkoThGnHLzHVrbpWbA(AxisDirection P_0)
		{
			for (int i = 0; i < qVAbhiklBWHqSQhWTfDpcvQFTBVNb._count; i++)
			{
				if (qVAbhiklBWHqSQhWTfDpcvQFTBVNb[i].XdrIyCHSvCOtelgsOknkTmjdPjQPA.HasValue && qVAbhiklBWHqSQhWTfDpcvQFTBVNb[i].XdrIyCHSvCOtelgsOknkTmjdPjQPA.Value == P_0)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public enum QtSxnZYSjrgthBpvYZqvQdRfKXUE
	{
		None = 0,
		Names = 1,
		Keys = 2,
		All = -1
	}

	public enum oTYnvuyaZmGssrtKlgjPUrEEwolk
	{
		None = 0,
		DescriptiveName = 1,
		PositiveDescriptiveName = 2,
		NegativeDescriptiveName = 4,
		PositiveKey = 8,
		NegativeKey = 16,
		SpecialDescrptiveName0 = 16384,
		SpecialDescrptiveName1 = 32768,
		SpecialDescrptiveName2 = 65536,
		SpecialDescrptiveName3 = 131072,
		SpecialDescrptiveName4 = 262144,
		SpecialDescrptiveName5 = 524288,
		SpecialDescrptiveName6 = 1048576,
		SpecialDescrptiveName7 = 2097152,
		SpecialDescrptiveName8 = 4194304,
		SpecialKey0 = 8388608,
		SpecialKey1 = 16777216,
		SpecialKey2 = 33554432,
		SpecialKey3 = 67108864,
		SpecialKey4 = 134217728,
		SpecialKey5 = 268435456,
		SpecialKey6 = 536870912,
		SpecialKey7 = 1073741824,
		SpecialKey8 = int.MinValue,
		All = -1
	}

	public enum AqybaYFDSFEDwBRnsokwpBTdIblQ
	{
		Axis = 0,
		Button = 1,
		CompoundElement = 100,
		Unknown = int.MaxValue
	}

	public enum veVjxECKraSLRuRJUJeBWprfCtQDb
	{
		None = 0,
		Axis2D = 1,
		Hat = 2,
		ThumbStick = 3,
		DPad = 4,
		Stick = 5,
		Stick6D = 6,
		Unknown = int.MaxValue
	}

	private static readonly ADictionary<int, PEZtEoWUXFickyhTPzxGMRoQswOL> ihLoJndPviGyrgqRhjvwELAXGJtf = new ADictionary<int, PEZtEoWUXFickyhTPzxGMRoQswOL>
	{
		{
			4,
			new PEZtEoWUXFickyhTPzxGMRoQswOL(new AList<hRRFKErLSbMgVBVhVVXtNEkVPkde>
			{
				new hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection.Horizontal),
				new hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection.Vertical)
			})
		},
		{
			1,
			new PEZtEoWUXFickyhTPzxGMRoQswOL(new AList<hRRFKErLSbMgVBVhVVXtNEkVPkde>
			{
				new hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection.Horizontal),
				new hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection.Vertical)
			})
		},
		{
			5,
			new PEZtEoWUXFickyhTPzxGMRoQswOL(new AList<hRRFKErLSbMgVBVhVVXtNEkVPkde>
			{
				new hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection.Horizontal),
				new hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection.Vertical)
			})
		},
		{
			3,
			new PEZtEoWUXFickyhTPzxGMRoQswOL(new AList<hRRFKErLSbMgVBVhVVXtNEkVPkde>
			{
				new hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection.Horizontal),
				new hRRFKErLSbMgVBVhVVXtNEkVPkde(AxisDirection.Vertical)
			})
		}
	};

	private AqybaYFDSFEDwBRnsokwpBTdIblQ MbNNGnVgbqdLlbuSatdmKxxBZagTA;

	private veVjxECKraSLRuRJUJeBWprfCtQDb udgOHheTdszbveYkMBLoVaIDWUQf;

	public AqybaYFDSFEDwBRnsokwpBTdIblQ LJXAbEKxmDHBiYmUZFbAJTxfIUxj
	{
		get
		{
			return MbNNGnVgbqdLlbuSatdmKxxBZagTA;
		}
		set
		{
			if (aqybaYFDSFEDwBRnsokwpBTdIblQ != MbNNGnVgbqdLlbuSatdmKxxBZagTA)
			{
				MbNNGnVgbqdLlbuSatdmKxxBZagTA = aqybaYFDSFEDwBRnsokwpBTdIblQ;
				if (base.tFnDIYcJYPjQABQySAwBboLweIfv)
				{
					DKMkEJwNUuDpLGWqVbXJUJJzEYRk();
				}
			}
		}
	}

	public veVjxECKraSLRuRJUJeBWprfCtQDb VsFDlKfYzzTTInlpCbOWcKKrmFZDA
	{
		get
		{
			return udgOHheTdszbveYkMBLoVaIDWUQf;
		}
		set
		{
			if (veVjxECKraSLRuRJUJeBWprfCtQDb2 != udgOHheTdszbveYkMBLoVaIDWUQf)
			{
				udgOHheTdszbveYkMBLoVaIDWUQf = veVjxECKraSLRuRJUJeBWprfCtQDb2;
				if (base.tFnDIYcJYPjQABQySAwBboLweIfv)
				{
					DKMkEJwNUuDpLGWqVbXJUJJzEYRk();
				}
			}
		}
	}

	public static bool BYUvlRLHXoZMeceCTjMMIYmbtBMmA(veVjxECKraSLRuRJUJeBWprfCtQDb P_0, out PEZtEoWUXFickyhTPzxGMRoQswOL P_1)
	{
		return ihLoJndPviGyrgqRhjvwELAXGJtf.TryGetValue((int)P_0, out P_1);
	}

	public static int zIFHYKIYFbwXaLMpuqkDbbnkpdiD(AqybaYFDSFEDwBRnsokwpBTdIblQ P_0, veVjxECKraSLRuRJUJeBWprfCtQDb P_1)
	{
		if (P_0 != AqybaYFDSFEDwBRnsokwpBTdIblQ.CompoundElement)
		{
			return 0;
		}
		if (!ihLoJndPviGyrgqRhjvwELAXGJtf.TryGetValue((int)P_1, out var value))
		{
			return 0;
		}
		return value.PewIUhZMyGUcqMDJtzetvXdUpuqS;
	}

	protected jjEiJGkdrKfqxJAsceTeoFkgoNMlA(AqybaYFDSFEDwBRnsokwpBTdIblQ P_0, veVjxECKraSLRuRJUJeBWprfCtQDb P_1)
	{
		MbNNGnVgbqdLlbuSatdmKxxBZagTA = P_0;
		udgOHheTdszbveYkMBLoVaIDWUQf = P_1;
	}

	protected jjEiJGkdrKfqxJAsceTeoFkgoNMlA(LnhaMJXLiFbdSGpizhhMTtFDjtXy P_0, AqybaYFDSFEDwBRnsokwpBTdIblQ P_1, veVjxECKraSLRuRJUJeBWprfCtQDb P_2)
		: base(P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		MbNNGnVgbqdLlbuSatdmKxxBZagTA = P_1;
		udgOHheTdszbveYkMBLoVaIDWUQf = P_2;
	}

	protected virtual void ocwkkmZurlqfuKPEalGIqdmTGdXI()
	{
		base.fJEGjYShwDhlCtKiGggxusMUCXuo();
		ZkeNHOSKcvJlBczdcxBaeQXQJqfE();
	}

	public virtual void uogVoxebOaalYvSMFHpEhkktkqiEA()
	{
		base.AeqSUmtDwbcYLrhaTtXtwzoJTozq();
		ZkeNHOSKcvJlBczdcxBaeQXQJqfE(QtSxnZYSjrgthBpvYZqvQdRfKXUE.Names);
	}

	public virtual void URVTChhdPhlphEvyvsHKScBWvFun()
	{
		base.VFHulbCONdrHnQmgMqwKyHtRlYIr();
		ZkeNHOSKcvJlBczdcxBaeQXQJqfE(QtSxnZYSjrgthBpvYZqvQdRfKXUE.Keys);
	}

	public virtual void qftzcdIEmdqKimJUMDyXdUwDdenEA()
	{
		base.wkNCiIKcomvvEiZxnJmXtmqxRPdW();
		ZkeNHOSKcvJlBczdcxBaeQXQJqfE(QtSxnZYSjrgthBpvYZqvQdRfKXUE.Names);
	}

	public virtual bool buRpSpFySsnOwisfqOOesjuLfQTJ(xhsfjMHWBKokSPBLxdeojZhcJxoeA P_0, bool P_1)
	{
		jjEiJGkdrKfqxJAsceTeoFkgoNMlA jjEiJGkdrKfqxJAsceTeoFkgoNMlA2 = P_0 as jjEiJGkdrKfqxJAsceTeoFkgoNMlA;
		if (jjEiJGkdrKfqxJAsceTeoFkgoNMlA2 != null)
		{
			return false;
		}
		if (!base.fnknzfXTJAiyPjhBrqRTlqnPySbr(P_0, P_1))
		{
			return false;
		}
		return MbNNGnVgbqdLlbuSatdmKxxBZagTA == jjEiJGkdrKfqxJAsceTeoFkgoNMlA2.LJXAbEKxmDHBiYmUZFbAJTxfIUxj;
	}

	protected virtual void UMcCdLWmjevbDnqFgUwpyXSLsnWp()
	{
		base.CNyaoPIDHcxPGQLQdSOKLsUXDKbN();
		yDzbfaLEJphcSkTjzHYGsryjYvCjA(oTYnvuyaZmGssrtKlgjPUrEEwolk.All);
	}

	protected virtual void ZkeNHOSKcvJlBczdcxBaeQXQJqfE(QtSxnZYSjrgthBpvYZqvQdRfKXUE P_0 = QtSxnZYSjrgthBpvYZqvQdRfKXUE.None)
	{
		if (P_0 != QtSxnZYSjrgthBpvYZqvQdRfKXUE.None)
		{
			bQzVdKHyATlezBVKtPmyOdfwiyfx(P_0);
		}
		LnhaMJXLiFbdSGpizhhMTtFDjtXy lnhaMJXLiFbdSGpizhhMTtFDjtXy = RZKDbaDlqKvZBfkLJCkUzoaxqLAwA();
		if (lnhaMJXLiFbdSGpizhhMTtFDjtXy != null && (lnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags & 1) == 0 && string.IsNullOrEmpty(lnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName) && !string.IsNullOrEmpty(lnhaMJXLiFbdSGpizhhMTtFDjtXy.scriptingName))
		{
			lnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName = lnhaMJXLiFbdSGpizhhMTtFDjtXy.scriptingName;
			lnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags |= 1;
			yEJKXEtRylKddSbgoiIxUFVZUTMX(1);
		}
	}

	protected virtual void RgkObNzZMEqRqxmYMkhwAXrzXlTA(int P_0)
	{
		base.PwEgDBNHpFGHYbdNfSmJVwtzcbhgA(P_0);
		yDzbfaLEJphcSkTjzHYGsryjYvCjA((oTYnvuyaZmGssrtKlgjPUrEEwolk)P_0);
	}

	protected virtual void yDzbfaLEJphcSkTjzHYGsryjYvCjA(oTYnvuyaZmGssrtKlgjPUrEEwolk P_0)
	{
		LnhaMJXLiFbdSGpizhhMTtFDjtXy lnhaMJXLiFbdSGpizhhMTtFDjtXy = RZKDbaDlqKvZBfkLJCkUzoaxqLAwA();
		if (lnhaMJXLiFbdSGpizhhMTtFDjtXy != null && ((uint)lnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags & (uint)P_0) != 0 && (P_0 & oTYnvuyaZmGssrtKlgjPUrEEwolk.DescriptiveName) != oTYnvuyaZmGssrtKlgjPUrEEwolk.None && (lnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags & 1) != 0)
		{
			if (RZKDbaDlqKvZBfkLJCkUzoaxqLAwA() != null)
			{
				RZKDbaDlqKvZBfkLJCkUzoaxqLAwA().nonLocalizedDescriptiveName = null;
			}
			yEJKXEtRylKddSbgoiIxUFVZUTMX(1);
			lnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags &= -2;
		}
	}

	private void bQzVdKHyATlezBVKtPmyOdfwiyfx(QtSxnZYSjrgthBpvYZqvQdRfKXUE P_0)
	{
		oTYnvuyaZmGssrtKlgjPUrEEwolk oTYnvuyaZmGssrtKlgjPUrEEwolk2 = yaKwzIfaeqvJqzbBTjbIPAiLOtPd(P_0);
		if (oTYnvuyaZmGssrtKlgjPUrEEwolk2 != oTYnvuyaZmGssrtKlgjPUrEEwolk.None)
		{
			yDzbfaLEJphcSkTjzHYGsryjYvCjA(oTYnvuyaZmGssrtKlgjPUrEEwolk2);
		}
	}

	protected virtual oTYnvuyaZmGssrtKlgjPUrEEwolk yaKwzIfaeqvJqzbBTjbIPAiLOtPd(QtSxnZYSjrgthBpvYZqvQdRfKXUE P_0)
	{
		oTYnvuyaZmGssrtKlgjPUrEEwolk oTYnvuyaZmGssrtKlgjPUrEEwolk2 = oTYnvuyaZmGssrtKlgjPUrEEwolk.None;
		if ((P_0 & QtSxnZYSjrgthBpvYZqvQdRfKXUE.Names) != QtSxnZYSjrgthBpvYZqvQdRfKXUE.None)
		{
			oTYnvuyaZmGssrtKlgjPUrEEwolk2 |= oTYnvuyaZmGssrtKlgjPUrEEwolk.DescriptiveName;
		}
		return oTYnvuyaZmGssrtKlgjPUrEEwolk2;
	}

	protected virtual void aZzOkurvWhsbADLEqQAdGQZVlQRx()
	{
		base.CDgdhocKjUGZulOPMnDajGfidFkIb();
		WfYxlWKheRqSPhxWVoclUcggslZQ(1, new eHmaJdrNOVirmgtpoujzQtBnLiexA
		{
			sigTNzHcEgiAMnBdNaAdaLOmuMJG = IgMwwqYoaShFZDOHgCAHernAcSRVA
		});
	}
}
