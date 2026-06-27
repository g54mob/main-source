using System;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;

internal abstract class RyDiYtnCdYRqXXpxvIjJeSOrrroG : LppKwrUfVUBJkUZWgjBXcdVtfTUS
{
	public class LLQyitedXdJjpWTUSIIKkzaSfjTu
	{
		public readonly AxisDirection? xouJkbRahCYnGvJzReGTTdDcXqiH;

		public LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection? P_0)
		{
			xouJkbRahCYnGvJzReGTTdDcXqiH = P_0;
		}
	}

	public class lAczHHLPNKZSpdQQYyjLdOHCMoNA
	{
		private readonly AList<LLQyitedXdJjpWTUSIIKkzaSfjTu> UHVCJLsRMAJBysFGEWQUYyOOrCpf;

		public readonly int xtbdPMQWwGZVQBAuqlgMIDVLKKAK;

		public lAczHHLPNKZSpdQQYyjLdOHCMoNA(AList<LLQyitedXdJjpWTUSIIKkzaSfjTu> P_0)
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
			UHVCJLsRMAJBysFGEWQUYyOOrCpf = P_0;
			xtbdPMQWwGZVQBAuqlgMIDVLKKAK = UHVCJLsRMAJBysFGEWQUYyOOrCpf._count;
		}

		public LLQyitedXdJjpWTUSIIKkzaSfjTu cSngAPaBzrRrYucECUhFZadVCXFiA(int P_0)
		{
			return UHVCJLsRMAJBysFGEWQUYyOOrCpf._items[P_0];
		}

		public int mByCwRcQCdCUMfVqHYHqASbsHfmL(AxisDirection P_0)
		{
			for (int i = 0; i < UHVCJLsRMAJBysFGEWQUYyOOrCpf._count; i++)
			{
				if (UHVCJLsRMAJBysFGEWQUYyOOrCpf[i].xouJkbRahCYnGvJzReGTTdDcXqiH.HasValue && UHVCJLsRMAJBysFGEWQUYyOOrCpf[i].xouJkbRahCYnGvJzReGTTdDcXqiH.Value == P_0)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public enum aePIIoVXbbnFXSmuBBCQkjRgryklA
	{
		None = 0,
		Names = 1,
		Keys = 2,
		All = -1
	}

	public enum OKDfONxCXupdMmVNgSzknasBOGLo
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

	public enum wDdhIfgQYXRpSeEwrBrHOItkwVRlA
	{
		Axis = 0,
		Button = 1,
		CompoundElement = 100,
		Unknown = int.MaxValue
	}

	public enum NpYWoxDajscclIyARrpcWpXeFhgi
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

	private static readonly ADictionary<int, lAczHHLPNKZSpdQQYyjLdOHCMoNA> IyQfDEcHbcRbFdLEmCeBdvgStyHy = new ADictionary<int, lAczHHLPNKZSpdQQYyjLdOHCMoNA>
	{
		{
			4,
			new lAczHHLPNKZSpdQQYyjLdOHCMoNA(new AList<LLQyitedXdJjpWTUSIIKkzaSfjTu>
			{
				new LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection.Horizontal),
				new LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection.Vertical)
			})
		},
		{
			1,
			new lAczHHLPNKZSpdQQYyjLdOHCMoNA(new AList<LLQyitedXdJjpWTUSIIKkzaSfjTu>
			{
				new LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection.Horizontal),
				new LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection.Vertical)
			})
		},
		{
			5,
			new lAczHHLPNKZSpdQQYyjLdOHCMoNA(new AList<LLQyitedXdJjpWTUSIIKkzaSfjTu>
			{
				new LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection.Horizontal),
				new LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection.Vertical)
			})
		},
		{
			3,
			new lAczHHLPNKZSpdQQYyjLdOHCMoNA(new AList<LLQyitedXdJjpWTUSIIKkzaSfjTu>
			{
				new LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection.Horizontal),
				new LLQyitedXdJjpWTUSIIKkzaSfjTu(AxisDirection.Vertical)
			})
		}
	};

	private wDdhIfgQYXRpSeEwrBrHOItkwVRlA mkOafOYppyTsDzsPfewPgCRKTYSQA;

	private NpYWoxDajscclIyARrpcWpXeFhgi MonElCxxjoGWRdFpJBQNsDaWfewHA;

	public wDdhIfgQYXRpSeEwrBrHOItkwVRlA dUUDrzPkiDVoUVOJOYUjkoDyEkRM
	{
		get
		{
			return mkOafOYppyTsDzsPfewPgCRKTYSQA;
		}
		set
		{
			if (wDdhIfgQYXRpSeEwrBrHOItkwVRlA2 != mkOafOYppyTsDzsPfewPgCRKTYSQA)
			{
				mkOafOYppyTsDzsPfewPgCRKTYSQA = wDdhIfgQYXRpSeEwrBrHOItkwVRlA2;
				if (base.TOobdfzwKXpykUqhHfSiEudxcfZi)
				{
					vtJxVkbxQgQVbPknOGkynGbiyVxG();
				}
			}
		}
	}

	public NpYWoxDajscclIyARrpcWpXeFhgi dHGEbniTxxezwgeoRPphhEiirMrL
	{
		get
		{
			return MonElCxxjoGWRdFpJBQNsDaWfewHA;
		}
		set
		{
			if (npYWoxDajscclIyARrpcWpXeFhgi != MonElCxxjoGWRdFpJBQNsDaWfewHA)
			{
				MonElCxxjoGWRdFpJBQNsDaWfewHA = npYWoxDajscclIyARrpcWpXeFhgi;
				if (base.TOobdfzwKXpykUqhHfSiEudxcfZi)
				{
					vtJxVkbxQgQVbPknOGkynGbiyVxG();
				}
			}
		}
	}

	public static bool xeTKhmONIypEUlLsOBJlnkOmtBsK(NpYWoxDajscclIyARrpcWpXeFhgi P_0, out lAczHHLPNKZSpdQQYyjLdOHCMoNA P_1)
	{
		return IyQfDEcHbcRbFdLEmCeBdvgStyHy.TryGetValue((int)P_0, out P_1);
	}

	public static int LdCDypFhAhzHGQMVrcvuiORltJYJA(wDdhIfgQYXRpSeEwrBrHOItkwVRlA P_0, NpYWoxDajscclIyARrpcWpXeFhgi P_1)
	{
		if (P_0 != wDdhIfgQYXRpSeEwrBrHOItkwVRlA.CompoundElement)
		{
			return 0;
		}
		if (!IyQfDEcHbcRbFdLEmCeBdvgStyHy.TryGetValue((int)P_1, out var value))
		{
			return 0;
		}
		return value.xtbdPMQWwGZVQBAuqlgMIDVLKKAK;
	}

	protected RyDiYtnCdYRqXXpxvIjJeSOrrroG(wDdhIfgQYXRpSeEwrBrHOItkwVRlA P_0, NpYWoxDajscclIyARrpcWpXeFhgi P_1)
	{
		mkOafOYppyTsDzsPfewPgCRKTYSQA = P_0;
		MonElCxxjoGWRdFpJBQNsDaWfewHA = P_1;
	}

	protected RyDiYtnCdYRqXXpxvIjJeSOrrroG(leeNpeIpkRWAaDYnewmtyKpQcRpw P_0, wDdhIfgQYXRpSeEwrBrHOItkwVRlA P_1, NpYWoxDajscclIyARrpcWpXeFhgi P_2)
		: base(P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		mkOafOYppyTsDzsPfewPgCRKTYSQA = P_1;
		MonElCxxjoGWRdFpJBQNsDaWfewHA = P_2;
	}

	protected virtual void OrdbNTaQcjaBQxLMdluxgJOFKkbub()
	{
		base.VYBYejVSaBMrimVrXfEODZmJvEUk();
		lEdwygNfSpgwTzispGoDRYgTIvVM();
	}

	public virtual void YazFMUpYRqUkNsDWQojsBWEkIGnc()
	{
		base.sOnpvTwKynHrpiShYVQEZXEQqQDP();
		lEdwygNfSpgwTzispGoDRYgTIvVM(aePIIoVXbbnFXSmuBBCQkjRgryklA.Names);
	}

	public virtual void uMjlOiAVfMPZZTxyUgttpxJlFOI()
	{
		base.rGfGCTURtYyLPalJfxlbNDAOsgNA();
		lEdwygNfSpgwTzispGoDRYgTIvVM(aePIIoVXbbnFXSmuBBCQkjRgryklA.Keys);
	}

	public virtual void IqoVWAHoSrrYVzZuLlcwKCvGONKc()
	{
		base.GvKqFlBIauBSccpqkijaDCUIwlHHB();
		lEdwygNfSpgwTzispGoDRYgTIvVM(aePIIoVXbbnFXSmuBBCQkjRgryklA.Names);
	}

	public virtual bool TESrEAMoQgmAGpmixcVZFHEEcPry(LppKwrUfVUBJkUZWgjBXcdVtfTUS P_0, bool P_1)
	{
		RyDiYtnCdYRqXXpxvIjJeSOrrroG ryDiYtnCdYRqXXpxvIjJeSOrrroG = P_0 as RyDiYtnCdYRqXXpxvIjJeSOrrroG;
		if (ryDiYtnCdYRqXXpxvIjJeSOrrroG != null)
		{
			return false;
		}
		if (!base.TUhOKAWZDSFHneJYgWLgWaTMqqZh(P_0, P_1))
		{
			return false;
		}
		return mkOafOYppyTsDzsPfewPgCRKTYSQA == ryDiYtnCdYRqXXpxvIjJeSOrrroG.dUUDrzPkiDVoUVOJOYUjkoDyEkRM;
	}

	protected virtual void eXbqIgJPhccQlGcAzglSFZyAfNobb()
	{
		base.wFfoRsDxLwNowTPNgDVrqLmCaiRN();
		YUwOCHUyJxCFkSJimUFzGTYalFwo(OKDfONxCXupdMmVNgSzknasBOGLo.All);
	}

	protected virtual void lEdwygNfSpgwTzispGoDRYgTIvVM(aePIIoVXbbnFXSmuBBCQkjRgryklA P_0 = aePIIoVXbbnFXSmuBBCQkjRgryklA.None)
	{
		if (P_0 != aePIIoVXbbnFXSmuBBCQkjRgryklA.None)
		{
			BBqGhIMUbRZiDWTYcjMNnJuvKTRc(P_0);
		}
		leeNpeIpkRWAaDYnewmtyKpQcRpw leeNpeIpkRWAaDYnewmtyKpQcRpw2 = teLIlNgcmKaxxnoSUdIdFnYabJsF();
		if (leeNpeIpkRWAaDYnewmtyKpQcRpw2 != null && (leeNpeIpkRWAaDYnewmtyKpQcRpw2.autoGeneratedValueFlags & 1) == 0 && string.IsNullOrEmpty(leeNpeIpkRWAaDYnewmtyKpQcRpw2.nonLocalizedDescriptiveName) && !string.IsNullOrEmpty(leeNpeIpkRWAaDYnewmtyKpQcRpw2.scriptingName))
		{
			leeNpeIpkRWAaDYnewmtyKpQcRpw2.nonLocalizedDescriptiveName = leeNpeIpkRWAaDYnewmtyKpQcRpw2.scriptingName;
			leeNpeIpkRWAaDYnewmtyKpQcRpw2.autoGeneratedValueFlags |= 1;
			SxOitnieunZrHDRnvKLWhqjMgpgjA(1);
		}
	}

	protected virtual void hnzSvOeaLUaBzCehTkrYVvngvzVtA(int P_0)
	{
		base.vDXiXmAQfZsHayWOczPuqqRqFqLh(P_0);
		YUwOCHUyJxCFkSJimUFzGTYalFwo((OKDfONxCXupdMmVNgSzknasBOGLo)P_0);
	}

	protected virtual void YUwOCHUyJxCFkSJimUFzGTYalFwo(OKDfONxCXupdMmVNgSzknasBOGLo P_0)
	{
		leeNpeIpkRWAaDYnewmtyKpQcRpw leeNpeIpkRWAaDYnewmtyKpQcRpw2 = teLIlNgcmKaxxnoSUdIdFnYabJsF();
		if (leeNpeIpkRWAaDYnewmtyKpQcRpw2 != null && ((uint)leeNpeIpkRWAaDYnewmtyKpQcRpw2.autoGeneratedValueFlags & (uint)P_0) != 0 && (P_0 & OKDfONxCXupdMmVNgSzknasBOGLo.DescriptiveName) != OKDfONxCXupdMmVNgSzknasBOGLo.None && (leeNpeIpkRWAaDYnewmtyKpQcRpw2.autoGeneratedValueFlags & 1) != 0)
		{
			if (teLIlNgcmKaxxnoSUdIdFnYabJsF() != null)
			{
				teLIlNgcmKaxxnoSUdIdFnYabJsF().nonLocalizedDescriptiveName = null;
			}
			SxOitnieunZrHDRnvKLWhqjMgpgjA(1);
			leeNpeIpkRWAaDYnewmtyKpQcRpw2.autoGeneratedValueFlags &= -2;
		}
	}

	private void BBqGhIMUbRZiDWTYcjMNnJuvKTRc(aePIIoVXbbnFXSmuBBCQkjRgryklA P_0)
	{
		OKDfONxCXupdMmVNgSzknasBOGLo oKDfONxCXupdMmVNgSzknasBOGLo = UoJwXOylmiqEhqxsCJajaPgEbybQ(P_0);
		if (oKDfONxCXupdMmVNgSzknasBOGLo != OKDfONxCXupdMmVNgSzknasBOGLo.None)
		{
			YUwOCHUyJxCFkSJimUFzGTYalFwo(oKDfONxCXupdMmVNgSzknasBOGLo);
		}
	}

	protected virtual OKDfONxCXupdMmVNgSzknasBOGLo UoJwXOylmiqEhqxsCJajaPgEbybQ(aePIIoVXbbnFXSmuBBCQkjRgryklA P_0)
	{
		OKDfONxCXupdMmVNgSzknasBOGLo oKDfONxCXupdMmVNgSzknasBOGLo = OKDfONxCXupdMmVNgSzknasBOGLo.None;
		if ((P_0 & aePIIoVXbbnFXSmuBBCQkjRgryklA.Names) != aePIIoVXbbnFXSmuBBCQkjRgryklA.None)
		{
			oKDfONxCXupdMmVNgSzknasBOGLo |= OKDfONxCXupdMmVNgSzknasBOGLo.DescriptiveName;
		}
		return oKDfONxCXupdMmVNgSzknasBOGLo;
	}

	protected virtual void GhaBPZesKjYUwADBlcVAdYlUEshX()
	{
		base.mihKjZDhhUkcOPuQLYqTvHJntkEi();
		wqTWbHLiuJlbKmBHEbeWhODjBobC(1, new YZnlcOeKAPoAAuserPoAYphkWGQw
		{
			AXfBaIhEmyMRigckhEzKRLsOfWfHc = emHVZONsYrynZSEjcDgeCDhHqttB
		});
	}
}
