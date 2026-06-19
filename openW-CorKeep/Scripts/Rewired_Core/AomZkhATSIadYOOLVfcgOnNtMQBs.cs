using System;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;

internal abstract class AomZkhATSIadYOOLVfcgOnNtMQBs : CrEdIhdRuEefdCHiQoLwiMECdkdvB
{
	public class YwzmRtByqrFysFGmymphUBfQOnwj
	{
		public readonly AxisDirection? aRBhJlmnGWnqDuvJhLAszIYobqRJA;

		public YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection? P_0)
		{
			aRBhJlmnGWnqDuvJhLAszIYobqRJA = P_0;
		}
	}

	public class oNzOlLehqVXtXsHwkBQOBMVHFvXX
	{
		private readonly AList<YwzmRtByqrFysFGmymphUBfQOnwj> HxseKFNCyEJxjlAboPyrgFjMOGUX;

		public readonly int cuUGbCcfPKjlHPEsWJJjgyCNRxpzA;

		public oNzOlLehqVXtXsHwkBQOBMVHFvXX(AList<YwzmRtByqrFysFGmymphUBfQOnwj> P_0)
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
			HxseKFNCyEJxjlAboPyrgFjMOGUX = P_0;
			cuUGbCcfPKjlHPEsWJJjgyCNRxpzA = HxseKFNCyEJxjlAboPyrgFjMOGUX._count;
		}

		public YwzmRtByqrFysFGmymphUBfQOnwj bnCCmDVASxNjXfAechLydAaZCcmeA(int P_0)
		{
			return HxseKFNCyEJxjlAboPyrgFjMOGUX._items[P_0];
		}

		public int dgHhUFDLdjRgLayKedeJuiwMegLub(AxisDirection P_0)
		{
			for (int i = 0; i < HxseKFNCyEJxjlAboPyrgFjMOGUX._count; i++)
			{
				if (HxseKFNCyEJxjlAboPyrgFjMOGUX[i].aRBhJlmnGWnqDuvJhLAszIYobqRJA.HasValue && HxseKFNCyEJxjlAboPyrgFjMOGUX[i].aRBhJlmnGWnqDuvJhLAszIYobqRJA.Value == P_0)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public enum lZwSneskMjdcCDRCpckhVVEyJnLl
	{
		None = 0,
		Names = 1,
		Keys = 2,
		All = -1
	}

	public enum FzqQtDWakuZFTntlWNdHXCvRdaki
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

	public enum fyQKArxdnRgBFXnCTGFifmqgwogRA
	{
		Axis = 0,
		Button = 1,
		CompoundElement = 100,
		Unknown = int.MaxValue
	}

	public enum OUxgQpuZIuwKyJEylNPLslOwBwNAA
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

	private static readonly ADictionary<int, oNzOlLehqVXtXsHwkBQOBMVHFvXX> ZgjPUULKYqRJAmaTIKtgBdICHIqF = new ADictionary<int, oNzOlLehqVXtXsHwkBQOBMVHFvXX>
	{
		{
			4,
			new oNzOlLehqVXtXsHwkBQOBMVHFvXX(new AList<YwzmRtByqrFysFGmymphUBfQOnwj>
			{
				new YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection.Horizontal),
				new YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection.Vertical)
			})
		},
		{
			1,
			new oNzOlLehqVXtXsHwkBQOBMVHFvXX(new AList<YwzmRtByqrFysFGmymphUBfQOnwj>
			{
				new YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection.Horizontal),
				new YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection.Vertical)
			})
		},
		{
			5,
			new oNzOlLehqVXtXsHwkBQOBMVHFvXX(new AList<YwzmRtByqrFysFGmymphUBfQOnwj>
			{
				new YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection.Horizontal),
				new YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection.Vertical)
			})
		},
		{
			3,
			new oNzOlLehqVXtXsHwkBQOBMVHFvXX(new AList<YwzmRtByqrFysFGmymphUBfQOnwj>
			{
				new YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection.Horizontal),
				new YwzmRtByqrFysFGmymphUBfQOnwj(AxisDirection.Vertical)
			})
		}
	};

	private fyQKArxdnRgBFXnCTGFifmqgwogRA xVlUjMlWUmFAMyUlFQUkgwYEkznm;

	private OUxgQpuZIuwKyJEylNPLslOwBwNAA XJMryQOSgsqlEmHpleiuMpPEPZRd;

	public fyQKArxdnRgBFXnCTGFifmqgwogRA sIxvbdiJJXGTPKMdgswAQFCeVOyI
	{
		get
		{
			return xVlUjMlWUmFAMyUlFQUkgwYEkznm;
		}
		set
		{
			if (fyQKArxdnRgBFXnCTGFifmqgwogRA2 != xVlUjMlWUmFAMyUlFQUkgwYEkznm)
			{
				xVlUjMlWUmFAMyUlFQUkgwYEkznm = fyQKArxdnRgBFXnCTGFifmqgwogRA2;
				if (base.WRFezhhGdRvZlGXJhyNRmimtWHenA)
				{
					ejeFbwGIxeayeqIPgvoDbHsqwDGGA();
				}
			}
		}
	}

	public OUxgQpuZIuwKyJEylNPLslOwBwNAA oAneKvBTUlXClxNArblEZzfmJYEU
	{
		get
		{
			return XJMryQOSgsqlEmHpleiuMpPEPZRd;
		}
		set
		{
			if (oUxgQpuZIuwKyJEylNPLslOwBwNAA != XJMryQOSgsqlEmHpleiuMpPEPZRd)
			{
				XJMryQOSgsqlEmHpleiuMpPEPZRd = oUxgQpuZIuwKyJEylNPLslOwBwNAA;
				if (base.WRFezhhGdRvZlGXJhyNRmimtWHenA)
				{
					ejeFbwGIxeayeqIPgvoDbHsqwDGGA();
				}
			}
		}
	}

	public static bool kvsrEyzaoorJFgijytjCTPHeGAViA(OUxgQpuZIuwKyJEylNPLslOwBwNAA P_0, out oNzOlLehqVXtXsHwkBQOBMVHFvXX P_1)
	{
		return ZgjPUULKYqRJAmaTIKtgBdICHIqF.TryGetValue((int)P_0, out P_1);
	}

	public static int YJjoDvcTlhdCNHOpHXbTafYtikvO(fyQKArxdnRgBFXnCTGFifmqgwogRA P_0, OUxgQpuZIuwKyJEylNPLslOwBwNAA P_1)
	{
		if (P_0 != fyQKArxdnRgBFXnCTGFifmqgwogRA.CompoundElement)
		{
			return 0;
		}
		if (!ZgjPUULKYqRJAmaTIKtgBdICHIqF.TryGetValue((int)P_1, out var value))
		{
			return 0;
		}
		return value.cuUGbCcfPKjlHPEsWJJjgyCNRxpzA;
	}

	protected AomZkhATSIadYOOLVfcgOnNtMQBs(fyQKArxdnRgBFXnCTGFifmqgwogRA P_0, OUxgQpuZIuwKyJEylNPLslOwBwNAA P_1)
	{
		xVlUjMlWUmFAMyUlFQUkgwYEkznm = P_0;
		XJMryQOSgsqlEmHpleiuMpPEPZRd = P_1;
	}

	protected AomZkhATSIadYOOLVfcgOnNtMQBs(gDrCmzJNXwFvGTMAYKGQspUqeYD P_0, fyQKArxdnRgBFXnCTGFifmqgwogRA P_1, OUxgQpuZIuwKyJEylNPLslOwBwNAA P_2)
		: base(P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		xVlUjMlWUmFAMyUlFQUkgwYEkznm = P_1;
		XJMryQOSgsqlEmHpleiuMpPEPZRd = P_2;
	}

	protected virtual void LkQRPNtLZxlSRESaPGkQjrNILfSL()
	{
		base.EOsBMvgyLZkglvtZbrXbItvVoQpDb();
		idImOmuzvdGLOotALUOanCfXIOuS();
	}

	public virtual void TDKmJIWOjsfmrjGxkDYGHhJupxzKA()
	{
		base.nSsfNaXHvQVyfjDkGwnFvNcSnmvb();
		idImOmuzvdGLOotALUOanCfXIOuS(lZwSneskMjdcCDRCpckhVVEyJnLl.Names);
	}

	public virtual void lhdOvYLoqhTkAKWLCfmALaqDPClT()
	{
		base.wmroSGiryndOGMmBfWDEbJMKrRBv();
		idImOmuzvdGLOotALUOanCfXIOuS(lZwSneskMjdcCDRCpckhVVEyJnLl.Keys);
	}

	public virtual void ZuTPVYqKXlOLLwmtxIVJsQJAbzqT()
	{
		base.TebLFfuNscsSdmSSCRmDmNccAdoF();
		idImOmuzvdGLOotALUOanCfXIOuS(lZwSneskMjdcCDRCpckhVVEyJnLl.Names);
	}

	public virtual bool AztKGIvbswaZWeSHBhgTxTXCcKLB(CrEdIhdRuEefdCHiQoLwiMECdkdvB P_0, bool P_1)
	{
		AomZkhATSIadYOOLVfcgOnNtMQBs aomZkhATSIadYOOLVfcgOnNtMQBs = P_0 as AomZkhATSIadYOOLVfcgOnNtMQBs;
		if (aomZkhATSIadYOOLVfcgOnNtMQBs != null)
		{
			return false;
		}
		if (!base.QlMvYOrrkGobkvjoAMgNaIOEePwJA(P_0, P_1))
		{
			return false;
		}
		return xVlUjMlWUmFAMyUlFQUkgwYEkznm == aomZkhATSIadYOOLVfcgOnNtMQBs.sIxvbdiJJXGTPKMdgswAQFCeVOyI;
	}

	protected virtual void rGEIdssYVmaHobuMTZpfrtsIoPZC()
	{
		base.fYXugwwcuInxCcvEfNIGnrIJqcf();
		HpPYiVrcZlpqpRSiAtDWiaBwavJF(FzqQtDWakuZFTntlWNdHXCvRdaki.All);
	}

	protected virtual void idImOmuzvdGLOotALUOanCfXIOuS(lZwSneskMjdcCDRCpckhVVEyJnLl P_0 = lZwSneskMjdcCDRCpckhVVEyJnLl.None)
	{
		if (P_0 != lZwSneskMjdcCDRCpckhVVEyJnLl.None)
		{
			EIZmEfxolJkrMXzzWhHkRWKpNhsT(P_0);
		}
		gDrCmzJNXwFvGTMAYKGQspUqeYD gDrCmzJNXwFvGTMAYKGQspUqeYD2 = qUiJUHBRFEvMwwcmkRXSpLZcYrJm();
		if (gDrCmzJNXwFvGTMAYKGQspUqeYD2 != null && (gDrCmzJNXwFvGTMAYKGQspUqeYD2.autoGeneratedValueFlags & 1) == 0 && string.IsNullOrEmpty(gDrCmzJNXwFvGTMAYKGQspUqeYD2.nonLocalizedDescriptiveName) && !string.IsNullOrEmpty(gDrCmzJNXwFvGTMAYKGQspUqeYD2.scriptingName))
		{
			gDrCmzJNXwFvGTMAYKGQspUqeYD2.nonLocalizedDescriptiveName = gDrCmzJNXwFvGTMAYKGQspUqeYD2.scriptingName;
			gDrCmzJNXwFvGTMAYKGQspUqeYD2.autoGeneratedValueFlags |= 1;
			ZHfrtfTBXdLnGOfNRdLnBGkKHMRQ(1);
		}
	}

	protected virtual void kaOzSSZzaQdiyvNJpVBnXCciAZeh(int P_0)
	{
		base.syiGaqDjCDHGvEfcaAPFXYWuRyyVA(P_0);
		HpPYiVrcZlpqpRSiAtDWiaBwavJF((FzqQtDWakuZFTntlWNdHXCvRdaki)P_0);
	}

	protected virtual void HpPYiVrcZlpqpRSiAtDWiaBwavJF(FzqQtDWakuZFTntlWNdHXCvRdaki P_0)
	{
		gDrCmzJNXwFvGTMAYKGQspUqeYD gDrCmzJNXwFvGTMAYKGQspUqeYD2 = qUiJUHBRFEvMwwcmkRXSpLZcYrJm();
		if (gDrCmzJNXwFvGTMAYKGQspUqeYD2 != null && ((uint)gDrCmzJNXwFvGTMAYKGQspUqeYD2.autoGeneratedValueFlags & (uint)P_0) != 0 && (P_0 & FzqQtDWakuZFTntlWNdHXCvRdaki.DescriptiveName) != FzqQtDWakuZFTntlWNdHXCvRdaki.None && (gDrCmzJNXwFvGTMAYKGQspUqeYD2.autoGeneratedValueFlags & 1) != 0)
		{
			if (qUiJUHBRFEvMwwcmkRXSpLZcYrJm() != null)
			{
				qUiJUHBRFEvMwwcmkRXSpLZcYrJm().nonLocalizedDescriptiveName = null;
			}
			ZHfrtfTBXdLnGOfNRdLnBGkKHMRQ(1);
			gDrCmzJNXwFvGTMAYKGQspUqeYD2.autoGeneratedValueFlags &= -2;
		}
	}

	private void EIZmEfxolJkrMXzzWhHkRWKpNhsT(lZwSneskMjdcCDRCpckhVVEyJnLl P_0)
	{
		FzqQtDWakuZFTntlWNdHXCvRdaki fzqQtDWakuZFTntlWNdHXCvRdaki = TMcNPOZjXahkaxuEqKMUWpjQbXCu(P_0);
		if (fzqQtDWakuZFTntlWNdHXCvRdaki != FzqQtDWakuZFTntlWNdHXCvRdaki.None)
		{
			HpPYiVrcZlpqpRSiAtDWiaBwavJF(fzqQtDWakuZFTntlWNdHXCvRdaki);
		}
	}

	protected virtual FzqQtDWakuZFTntlWNdHXCvRdaki TMcNPOZjXahkaxuEqKMUWpjQbXCu(lZwSneskMjdcCDRCpckhVVEyJnLl P_0)
	{
		FzqQtDWakuZFTntlWNdHXCvRdaki fzqQtDWakuZFTntlWNdHXCvRdaki = FzqQtDWakuZFTntlWNdHXCvRdaki.None;
		if ((P_0 & lZwSneskMjdcCDRCpckhVVEyJnLl.Names) != lZwSneskMjdcCDRCpckhVVEyJnLl.None)
		{
			fzqQtDWakuZFTntlWNdHXCvRdaki |= FzqQtDWakuZFTntlWNdHXCvRdaki.DescriptiveName;
		}
		return fzqQtDWakuZFTntlWNdHXCvRdaki;
	}

	protected virtual void DaTALLHXzryylPLlNnhlPKgOrTSO()
	{
		base.jvQfGRmIEUzWNCSwhlusRDAfCCjdA();
		nUmRSnqJXLfZyjJvcbTdXNBpBiEX(1, new BKckUJBjHlyNjLMNcSvupioWhbq
		{
			DjGcOGzVTgfPpfASudPfdptdepSkA = xReLXRqoDCNUkVraDkxZoEUHpFYT
		});
	}
}
