using System;
using Rewired.Data.Mapping;
using Rewired.Utils.Classes.Data;

internal abstract class MJyJuisFiOmfspJhIRvXPkFSAPFT : ORSKUsFUQMFbVqzYDhEFDxAETxpN
{
	public class KfCaaLlObYTUDkWbubUmFxrKFkZ
	{
		public readonly AxisDirection? oPBcZcQLcCCmxHLvqEJHDmGGNjVsB;

		public KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection? P_0)
		{
			oPBcZcQLcCCmxHLvqEJHDmGGNjVsB = P_0;
		}
	}

	public class eSrXtKMIUZjpxRfWzNHzGoDkUsXw
	{
		private readonly AList<KfCaaLlObYTUDkWbubUmFxrKFkZ> VxeGWSdXUEylBAsFtczShIvnCJQw;

		public readonly int gOGhhRRzbMztvfVGNQkYpoWayxzi;

		public eSrXtKMIUZjpxRfWzNHzGoDkUsXw(AList<KfCaaLlObYTUDkWbubUmFxrKFkZ> P_0)
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
			VxeGWSdXUEylBAsFtczShIvnCJQw = P_0;
			gOGhhRRzbMztvfVGNQkYpoWayxzi = VxeGWSdXUEylBAsFtczShIvnCJQw._count;
		}

		public KfCaaLlObYTUDkWbubUmFxrKFkZ nKOMQWpKurFAtKeCjgKJcJeqAbqFA(int P_0)
		{
			return VxeGWSdXUEylBAsFtczShIvnCJQw._items[P_0];
		}

		public int lFBHGOjGPnfslATwiJdyghyJDnFxA(AxisDirection P_0)
		{
			for (int i = 0; i < VxeGWSdXUEylBAsFtczShIvnCJQw._count; i++)
			{
				if (VxeGWSdXUEylBAsFtczShIvnCJQw[i].oPBcZcQLcCCmxHLvqEJHDmGGNjVsB.HasValue && VxeGWSdXUEylBAsFtczShIvnCJQw[i].oPBcZcQLcCCmxHLvqEJHDmGGNjVsB.Value == P_0)
				{
					return i;
				}
			}
			return -1;
		}
	}

	public enum rCaSuhSWufhFquqeuhJWSlKJKnNk
	{
		None = 0,
		Names = 1,
		Keys = 2,
		All = -1
	}

	public enum JWyGUUsjYeTFhAbDNEOqGDnqBiaw
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

	public enum jZSMnsLXoBDMhquJQKqHviQNprmC
	{
		Axis = 0,
		Button = 1,
		CompoundElement = 100,
		Unknown = int.MaxValue
	}

	public enum GtxbKiHSwksUKuQYeAEqHnCDMtFmA
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

	private static readonly ADictionary<int, eSrXtKMIUZjpxRfWzNHzGoDkUsXw> NDrFyVfOksNtiXcWHDPTGmrhGroJ = new ADictionary<int, eSrXtKMIUZjpxRfWzNHzGoDkUsXw>
	{
		{
			4,
			new eSrXtKMIUZjpxRfWzNHzGoDkUsXw(new AList<KfCaaLlObYTUDkWbubUmFxrKFkZ>
			{
				new KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection.Horizontal),
				new KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection.Vertical)
			})
		},
		{
			1,
			new eSrXtKMIUZjpxRfWzNHzGoDkUsXw(new AList<KfCaaLlObYTUDkWbubUmFxrKFkZ>
			{
				new KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection.Horizontal),
				new KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection.Vertical)
			})
		},
		{
			5,
			new eSrXtKMIUZjpxRfWzNHzGoDkUsXw(new AList<KfCaaLlObYTUDkWbubUmFxrKFkZ>
			{
				new KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection.Horizontal),
				new KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection.Vertical)
			})
		},
		{
			3,
			new eSrXtKMIUZjpxRfWzNHzGoDkUsXw(new AList<KfCaaLlObYTUDkWbubUmFxrKFkZ>
			{
				new KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection.Horizontal),
				new KfCaaLlObYTUDkWbubUmFxrKFkZ(AxisDirection.Vertical)
			})
		}
	};

	private jZSMnsLXoBDMhquJQKqHviQNprmC bZroxTLkcwHEkZPLGCTNFrMfiujVA;

	private GtxbKiHSwksUKuQYeAEqHnCDMtFmA RNUzzJeqeayIcDvfibERJmzpMKRJ;

	public jZSMnsLXoBDMhquJQKqHviQNprmC wmxpDuCFjDeAdhOVfyzrBCCDpMkT
	{
		get
		{
			return bZroxTLkcwHEkZPLGCTNFrMfiujVA;
		}
		set
		{
			if (jZSMnsLXoBDMhquJQKqHviQNprmC2 != bZroxTLkcwHEkZPLGCTNFrMfiujVA)
			{
				bZroxTLkcwHEkZPLGCTNFrMfiujVA = jZSMnsLXoBDMhquJQKqHviQNprmC2;
				if (base.YTNjhucxZBUFPcapkZGsvkaAnMyM)
				{
					skyFfjckDgbaQKrnxTdoqMuNhEKiA();
				}
			}
		}
	}

	public GtxbKiHSwksUKuQYeAEqHnCDMtFmA kwfjWgpYavMRDMfyekVhYczFHBCY
	{
		get
		{
			return RNUzzJeqeayIcDvfibERJmzpMKRJ;
		}
		set
		{
			if (gtxbKiHSwksUKuQYeAEqHnCDMtFmA != RNUzzJeqeayIcDvfibERJmzpMKRJ)
			{
				RNUzzJeqeayIcDvfibERJmzpMKRJ = gtxbKiHSwksUKuQYeAEqHnCDMtFmA;
				if (base.YTNjhucxZBUFPcapkZGsvkaAnMyM)
				{
					skyFfjckDgbaQKrnxTdoqMuNhEKiA();
				}
			}
		}
	}

	public static bool yzssAvNAWgRZfJKNdgmvMuNHsBFU(GtxbKiHSwksUKuQYeAEqHnCDMtFmA P_0, out eSrXtKMIUZjpxRfWzNHzGoDkUsXw P_1)
	{
		return NDrFyVfOksNtiXcWHDPTGmrhGroJ.TryGetValue((int)P_0, out P_1);
	}

	public static int WFlgMaYJJpzOhusNWIdstVGKtOzl(jZSMnsLXoBDMhquJQKqHviQNprmC P_0, GtxbKiHSwksUKuQYeAEqHnCDMtFmA P_1)
	{
		if (P_0 != jZSMnsLXoBDMhquJQKqHviQNprmC.CompoundElement)
		{
			return 0;
		}
		if (!NDrFyVfOksNtiXcWHDPTGmrhGroJ.TryGetValue((int)P_1, out var value))
		{
			return 0;
		}
		return value.gOGhhRRzbMztvfVGNQkYpoWayxzi;
	}

	protected MJyJuisFiOmfspJhIRvXPkFSAPFT(jZSMnsLXoBDMhquJQKqHviQNprmC P_0, GtxbKiHSwksUKuQYeAEqHnCDMtFmA P_1)
	{
		bZroxTLkcwHEkZPLGCTNFrMfiujVA = P_0;
		RNUzzJeqeayIcDvfibERJmzpMKRJ = P_1;
	}

	protected MJyJuisFiOmfspJhIRvXPkFSAPFT(sZLAxvZSvDRmVjMjTVRhHfujppQp P_0, jZSMnsLXoBDMhquJQKqHviQNprmC P_1, GtxbKiHSwksUKuQYeAEqHnCDMtFmA P_2)
		: base(P_0)
	{
		if (P_0 == null)
		{
			throw new ArgumentNullException("dataSource");
		}
		bZroxTLkcwHEkZPLGCTNFrMfiujVA = P_1;
		RNUzzJeqeayIcDvfibERJmzpMKRJ = P_2;
	}

	protected virtual void VnWBKSRlXtnXrnYpEZchoRflOLED()
	{
		base.WJgJSaKVvFKuFOPjyWQQoEbqvZtr();
		sxIwjwSDkhWegJoWETHTsxpgJcOb();
	}

	public virtual void JCAXBBaNFkTsJKtXzRPvwKXTRcrq()
	{
		base.jTMhRUfClbiJAQhjtilGfcBvyqwjA();
		sxIwjwSDkhWegJoWETHTsxpgJcOb(rCaSuhSWufhFquqeuhJWSlKJKnNk.Names);
	}

	public virtual void lEtBlPkzIphsonzxFzbxmYcymXxrA()
	{
		base.yrhZMBOdOtpQsbmxygSzAaWtnMDfb();
		sxIwjwSDkhWegJoWETHTsxpgJcOb(rCaSuhSWufhFquqeuhJWSlKJKnNk.Keys);
	}

	public virtual void PrNwNZQjnpbVpCDFcfWeAzZDdkoPc()
	{
		base.XIvHPuMcrskwDDbqHcWqpyJRLTkr();
		sxIwjwSDkhWegJoWETHTsxpgJcOb(rCaSuhSWufhFquqeuhJWSlKJKnNk.Names);
	}

	public virtual bool IDvCTHHzFaiwfZeoUqzJwjFbvlWj(ORSKUsFUQMFbVqzYDhEFDxAETxpN P_0, bool P_1)
	{
		MJyJuisFiOmfspJhIRvXPkFSAPFT mJyJuisFiOmfspJhIRvXPkFSAPFT = P_0 as MJyJuisFiOmfspJhIRvXPkFSAPFT;
		if (mJyJuisFiOmfspJhIRvXPkFSAPFT != null)
		{
			return false;
		}
		if (!base.INYrIPNPQGAfMACMHLnoinKxNIiHb(P_0, P_1))
		{
			return false;
		}
		return bZroxTLkcwHEkZPLGCTNFrMfiujVA == mJyJuisFiOmfspJhIRvXPkFSAPFT.wmxpDuCFjDeAdhOVfyzrBCCDpMkT;
	}

	protected virtual void vlOKPjAaaycgGQlEQhKKEoxzutTJA()
	{
		base.xeScNvMrWqLAFnQRTFynDfdfMKqv();
		VnJKWKTgMlanDqXyFDmtdQZNvhXV(JWyGUUsjYeTFhAbDNEOqGDnqBiaw.All);
	}

	protected virtual void sxIwjwSDkhWegJoWETHTsxpgJcOb(rCaSuhSWufhFquqeuhJWSlKJKnNk P_0 = rCaSuhSWufhFquqeuhJWSlKJKnNk.None)
	{
		if (P_0 != rCaSuhSWufhFquqeuhJWSlKJKnNk.None)
		{
			EgPXEePMBPwrguQXNiOTQPOOZewv(P_0);
		}
		sZLAxvZSvDRmVjMjTVRhHfujppQp sZLAxvZSvDRmVjMjTVRhHfujppQp2 = ezuBKWkznYBOSXRGpqYrdiJDWPLoA();
		if (sZLAxvZSvDRmVjMjTVRhHfujppQp2 != null && (sZLAxvZSvDRmVjMjTVRhHfujppQp2.autoGeneratedValueFlags & 1) == 0 && string.IsNullOrEmpty(sZLAxvZSvDRmVjMjTVRhHfujppQp2.nonLocalizedDescriptiveName) && !string.IsNullOrEmpty(sZLAxvZSvDRmVjMjTVRhHfujppQp2.scriptingName))
		{
			sZLAxvZSvDRmVjMjTVRhHfujppQp2.nonLocalizedDescriptiveName = sZLAxvZSvDRmVjMjTVRhHfujppQp2.scriptingName;
			sZLAxvZSvDRmVjMjTVRhHfujppQp2.autoGeneratedValueFlags |= 1;
			XFdvjghozpLZsrvkWgkIQqPrTeDD(1);
		}
	}

	protected virtual void cVMvEDhKgQjlKMpEgAzMKinFBrgd(int P_0)
	{
		base.ayoecbXLiRWxJCIQLeYmNzGLaduo(P_0);
		VnJKWKTgMlanDqXyFDmtdQZNvhXV((JWyGUUsjYeTFhAbDNEOqGDnqBiaw)P_0);
	}

	protected virtual void VnJKWKTgMlanDqXyFDmtdQZNvhXV(JWyGUUsjYeTFhAbDNEOqGDnqBiaw P_0)
	{
		sZLAxvZSvDRmVjMjTVRhHfujppQp sZLAxvZSvDRmVjMjTVRhHfujppQp2 = ezuBKWkznYBOSXRGpqYrdiJDWPLoA();
		if (sZLAxvZSvDRmVjMjTVRhHfujppQp2 != null && ((uint)sZLAxvZSvDRmVjMjTVRhHfujppQp2.autoGeneratedValueFlags & (uint)P_0) != 0 && (P_0 & JWyGUUsjYeTFhAbDNEOqGDnqBiaw.DescriptiveName) != JWyGUUsjYeTFhAbDNEOqGDnqBiaw.None && (sZLAxvZSvDRmVjMjTVRhHfujppQp2.autoGeneratedValueFlags & 1) != 0)
		{
			if (ezuBKWkznYBOSXRGpqYrdiJDWPLoA() != null)
			{
				ezuBKWkznYBOSXRGpqYrdiJDWPLoA().nonLocalizedDescriptiveName = null;
			}
			XFdvjghozpLZsrvkWgkIQqPrTeDD(1);
			sZLAxvZSvDRmVjMjTVRhHfujppQp2.autoGeneratedValueFlags &= -2;
		}
	}

	private void EgPXEePMBPwrguQXNiOTQPOOZewv(rCaSuhSWufhFquqeuhJWSlKJKnNk P_0)
	{
		JWyGUUsjYeTFhAbDNEOqGDnqBiaw jWyGUUsjYeTFhAbDNEOqGDnqBiaw = JNsVFFfxWgmUyGiKpTpjZfmbKYeB(P_0);
		if (jWyGUUsjYeTFhAbDNEOqGDnqBiaw != JWyGUUsjYeTFhAbDNEOqGDnqBiaw.None)
		{
			VnJKWKTgMlanDqXyFDmtdQZNvhXV(jWyGUUsjYeTFhAbDNEOqGDnqBiaw);
		}
	}

	protected virtual JWyGUUsjYeTFhAbDNEOqGDnqBiaw JNsVFFfxWgmUyGiKpTpjZfmbKYeB(rCaSuhSWufhFquqeuhJWSlKJKnNk P_0)
	{
		JWyGUUsjYeTFhAbDNEOqGDnqBiaw jWyGUUsjYeTFhAbDNEOqGDnqBiaw = JWyGUUsjYeTFhAbDNEOqGDnqBiaw.None;
		if ((P_0 & rCaSuhSWufhFquqeuhJWSlKJKnNk.Names) != rCaSuhSWufhFquqeuhJWSlKJKnNk.None)
		{
			jWyGUUsjYeTFhAbDNEOqGDnqBiaw |= JWyGUUsjYeTFhAbDNEOqGDnqBiaw.DescriptiveName;
		}
		return jWyGUUsjYeTFhAbDNEOqGDnqBiaw;
	}

	protected virtual void NbDPXWlaZpogZcLLEYqCGRinHQWq()
	{
		base.paWEUOeYeWwEdUjOyvrRqUYOiDfOA();
		jriVMgSVfNhJUCcVjmEMYoZYjhGW(1, new ZfSdyTfpTJoTlWfkGbXUdYyHUehp
		{
			NmUmjFVjvsfeLKeuxcGWcsbAUoEx = nWuWHQKnzOaKYbmQWDumXtCiKAUgb
		});
	}
}
