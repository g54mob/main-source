using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class pDdfcWqxDAHCEFuHEUpBobYCGVaf
{
	public struct aBGHUHfNCcVnSUkIQdHgprgokKHB
	{
		public string oVxSbHaHpvRZYaklsfQvDzfMTcD;

		public string LMaMbxUwpISaejpwpFWYBPvqSto;

		public string KRqkupszLekWneSYaJRgWgcUhKXj;

		public string fGsfPWVfUEfhuiTuPpGdhyOGOAp;

		public string WHlKfTMROhHBgIcjhkmoMPrOJjR;

		public string voKuAgAwcoheuJQGpUjgvflNCbU;

		public int auptTDHVOmASTvZhkJmzdogcpmI;

		public int EIeYcAynLBvlXHRIXYlrdokkZIS;

		public bool heXwfrmHSDfCSEmprtErtpPGQtYK;

		public string NsOPmXwmhbhcjIApsscIcyLQNEE;

		public aBGHUHfNCcVnSUkIQdHgprgokKHB(string path, string instanceId, string description, string manufacturer, string locationInfo, bool isBluetoothDevice, string bluetoothDeviceName)
		{
			oVxSbHaHpvRZYaklsfQvDzfMTcD = path;
			LMaMbxUwpISaejpwpFWYBPvqSto = rAvDGaRacvzwvLKmICojipXmaqJA.tuwHSClLIHVmrERzImLMMfFXOyY(path);
			KRqkupszLekWneSYaJRgWgcUhKXj = instanceId;
			fGsfPWVfUEfhuiTuPpGdhyOGOAp = description;
			WHlKfTMROhHBgIcjhkmoMPrOJjR = manufacturer;
			voKuAgAwcoheuJQGpUjgvflNCbU = locationInfo;
			EIeYcAynLBvlXHRIXYlrdokkZIS = -1;
			auptTDHVOmASTvZhkJmzdogcpmI = -1;
			heXwfrmHSDfCSEmprtErtpPGQtYK = isBluetoothDevice;
			NsOPmXwmhbhcjIApsscIcyLQNEE = bluetoothDeviceName;
			DEeAlLAfLNWCnIOipYaeNpcQzKKL();
		}

		private void DEeAlLAfLNWCnIOipYaeNpcQzKKL()
		{
			if (!string.IsNullOrEmpty(voKuAgAwcoheuJQGpUjgvflNCbU))
			{
				int num = voKuAgAwcoheuJQGpUjgvflNCbU.IndexOf("port_#", StringComparison.OrdinalIgnoreCase);
				int num2 = voKuAgAwcoheuJQGpUjgvflNCbU.IndexOf("hub_#", StringComparison.OrdinalIgnoreCase);
				if (num >= 0 && num2 >= 0)
				{
					int.TryParse(voKuAgAwcoheuJQGpUjgvflNCbU.Substring(num + 6, 4), out EIeYcAynLBvlXHRIXYlrdokkZIS);
					int.TryParse(voKuAgAwcoheuJQGpUjgvflNCbU.Substring(num2 + 5, 4), out auptTDHVOmASTvZhkJmzdogcpmI);
				}
			}
		}
	}

	private struct EelNQkQeVHlRWJFRcvgSvJHxZOI
	{
		public int CBHEEHCheltfwKetcFBASvdLJAiG;

		public uint ZdQFmPVZeqjJDVnuVeSIlwDUJcR;

		public string voKuAgAwcoheuJQGpUjgvflNCbU;

		public EelNQkQeVHlRWJFRcvgSvJHxZOI(int parentIndex, uint deviceInstanceHandle, string locationInfo)
		{
			CBHEEHCheltfwKetcFBASvdLJAiG = parentIndex;
			ZdQFmPVZeqjJDVnuVeSIlwDUJcR = deviceInstanceHandle;
			voKuAgAwcoheuJQGpUjgvflNCbU = locationInfo;
		}
	}

	private struct khIrpoIRkxMtxAkmeeBTMdULdHk
	{
		public readonly uint ZdQFmPVZeqjJDVnuVeSIlwDUJcR;

		public readonly string SLKbCNBoSkZmhfNjgiDKjDeRqIP;

		public khIrpoIRkxMtxAkmeeBTMdULdHk(uint deviceInstanceHandle, string friendlyName)
		{
			ZdQFmPVZeqjJDVnuVeSIlwDUJcR = deviceInstanceHandle;
			SLKbCNBoSkZmhfNjgiDKjDeRqIP = ((friendlyName == null) ? string.Empty : friendlyName);
		}
	}

	private sealed class BdxdwSjDpxTrMeUQgRBnEgKxfXq
	{
		public string YzMYiMBqggaIybXdLkmLGaVNuEL;

		public StringComparison iwOECUHfhNFyebtmTsvaDtKtQFY;

		public bool okKFiegnxkezlbwbFAECwGGypQIz(aBGHUHfNCcVnSUkIQdHgprgokKHB P_0)
		{
			return P_0.LMaMbxUwpISaejpwpFWYBPvqSto.Equals(YzMYiMBqggaIybXdLkmLGaVNuEL, iwOECUHfhNFyebtmTsvaDtKtQFY);
		}
	}

	private sealed class uhxCDJknCtZooJYpPsFJERjwBwHF
	{
		public string YzMYiMBqggaIybXdLkmLGaVNuEL;

		public bool JKFkdXWXPsWqMEMiqOYHBJZBTFh(aBGHUHfNCcVnSUkIQdHgprgokKHB P_0)
		{
			return P_0.LMaMbxUwpISaejpwpFWYBPvqSto == YzMYiMBqggaIybXdLkmLGaVNuEL;
		}
	}

	private sealed class fddlVHaCimxnpgKbQhruUkwbdxV
	{
		public int IqbmTkZzBzpzKtwCqxczmcnUnOd;

		public int[] vQoODYRgwNpsgLNCXDAXIqrKQIl;

		public bool vHPCCmBtYKnGXgDblTGpLjyieaI(oODKWlXjjUaKGJbFcHDHZKTTKwC P_0)
		{
			if (P_0.Attributes.VendorId == IqbmTkZzBzpzKtwCqxczmcnUnOd)
			{
				return vQoODYRgwNpsgLNCXDAXIqrKQIl.Contains(P_0.Attributes.ProductId);
			}
			return false;
		}
	}

	private sealed class iICZjlRCIxXdcHLavhHEcaPvcxy
	{
		public int IqbmTkZzBzpzKtwCqxczmcnUnOd;

		public bool ostlBizzgMYtlcZMTxsBlrvMMVn(oODKWlXjjUaKGJbFcHDHZKTTKwC P_0)
		{
			return P_0.Attributes.VendorId == IqbmTkZzBzpzKtwCqxczmcnUnOd;
		}
	}

	private const string QmrdvtMFRHmfdDqgVaRFFQntYUX = "BTHENUM";

	private static Guid adbsLJhcfygNKCfPONkgBlEtiIVE;

	private static List<oODKWlXjjUaKGJbFcHDHZKTTKwC> vcztzwUpLMcQCyPRorpOHawWiOo;

	private static List<EelNQkQeVHlRWJFRcvgSvJHxZOI> xQeRDoBFEJQyyzXIAOaKtyBIWjt;

	private static List<aBGHUHfNCcVnSUkIQdHgprgokKHB> rJVMsaaAUhaTuNwqxQJKvCLmuvl;

	private static List<khIrpoIRkxMtxAkmeeBTMdULdHk> DFJfxqenTZanGKsWjAixGEWqZSaL;

	private static HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA clnTlHcFMODxyrekOTPBhCkQVFw;

	private static HXWkpUXNXBBWqhDQUwrsnqNRnFAt.MWYmUsuSicgWFCQiFtwBtDnhPTs mCAhnQWyvkdoWagbEVjwkgtnNUz;

	private static NativeBuffer wBRQlyWMGsmoLyCRWBKIjoilmsD;

	[CompilerGenerated]
	private static Func<aBGHUHfNCcVnSUkIQdHgprgokKHB, oODKWlXjjUaKGJbFcHDHZKTTKwC> GZSnvtpxirvnygOeVRVsicFPuNy;

	[CompilerGenerated]
	private static Func<aBGHUHfNCcVnSUkIQdHgprgokKHB, oODKWlXjjUaKGJbFcHDHZKTTKwC> hpSHikJKiQlmruOEOBayRRKJCYng;

	[CompilerGenerated]
	private static Func<aBGHUHfNCcVnSUkIQdHgprgokKHB, oODKWlXjjUaKGJbFcHDHZKTTKwC> WBDSdZnXKmWranIcwBkxPoSoHrh;

	[CompilerGenerated]
	private static Func<aBGHUHfNCcVnSUkIQdHgprgokKHB, oODKWlXjjUaKGJbFcHDHZKTTKwC> zKDroMxYFDjMCncVseLFGVsMpBPq;

	private static Guid HidClassGuid
	{
		get
		{
			if (adbsLJhcfygNKCfPONkgBlEtiIVE.Equals(Guid.Empty))
			{
				MsdjFrwPRhtDqvryUwwfexLTAxz.MfKFXjsTSFvGTrLwwgkEIGymhus(ref adbsLJhcfygNKCfPONkgBlEtiIVE);
			}
			return adbsLJhcfygNKCfPONkgBlEtiIVE;
		}
	}

	static pDdfcWqxDAHCEFuHEUpBobYCGVaf()
	{
		adbsLJhcfygNKCfPONkgBlEtiIVE = Guid.Empty;
		vcztzwUpLMcQCyPRorpOHawWiOo = new List<oODKWlXjjUaKGJbFcHDHZKTTKwC>();
		xQeRDoBFEJQyyzXIAOaKtyBIWjt = new List<EelNQkQeVHlRWJFRcvgSvJHxZOI>();
		rJVMsaaAUhaTuNwqxQJKvCLmuvl = new List<aBGHUHfNCcVnSUkIQdHgprgokKHB>();
		DFJfxqenTZanGKsWjAixGEWqZSaL = new List<khIrpoIRkxMtxAkmeeBTMdULdHk>();
		clnTlHcFMODxyrekOTPBhCkQVFw = new HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA
		{
			LSkXGyldcGzcsniYgtVoxFzBUgQ = (uint)Marshal.SizeOf(typeof(HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA)),
			NxwKXiZZPzGfbqADNsYbSmCSZMr = true,
			SktzEWBrrBtdyOnqVaQOcPBxxEu = true,
			aWbSUhJDvCdVtkllSTkeGNeulCj = false,
			RfxaCqCTZtXRJOcskupfnYkFpXpO = true,
			jHDwUiAeZVEJETgBGdZFfndmbpOD = IntPtr.Zero
		};
		mCAhnQWyvkdoWagbEVjwkgtnNUz = HXWkpUXNXBBWqhDQUwrsnqNRnFAt.MWYmUsuSicgWFCQiFtwBtDnhPTs.XEZZaRuCBatWlcrdVaazQoMlqtI();
		wBRQlyWMGsmoLyCRWBKIjoilmsD = new NativeBuffer((int)mCAhnQWyvkdoWagbEVjwkgtnNUz.LSkXGyldcGzcsniYgtVoxFzBUgQ);
		wBRQlyWMGsmoLyCRWBKIjoilmsD.Write(mCAhnQWyvkdoWagbEVjwkgtnNUz.LSkXGyldcGzcsniYgtVoxFzBUgQ, 0);
	}

	public static bool svxfQKxBmGjUbuRBnlfmDjpLwkW(string P_0)
	{
		bool flag = false;
		Guid hidClassGuid = HidClassGuid;
		IntPtr intPtr = MsdjFrwPRhtDqvryUwwfexLTAxz.LAYGYSiIvqLiyHqOjVyzCqfTKAv(ref hidClassGuid, null, 0, 18);
		if (intPtr.ToInt64() != -1)
		{
			MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH dGNRmDXpzJiDJkKQWNDOXIauQoH = JEGEgwPkLeHLfdTNklJRSyURpVWl();
			int num = 0;
			while (MsdjFrwPRhtDqvryUwwfexLTAxz.JiCfhtFqxalhyhqcLabzZRkMXXa(intPtr, num, ref dGNRmDXpzJiDJkKQWNDOXIauQoH))
			{
				num++;
				MsdjFrwPRhtDqvryUwwfexLTAxz.orjEEElXCDaMDfYBGFbEVljpRnXQ orjEEElXCDaMDfYBGFbEVljpRnXQ = default(MsdjFrwPRhtDqvryUwwfexLTAxz.orjEEElXCDaMDfYBGFbEVljpRnXQ);
				orjEEElXCDaMDfYBGFbEVljpRnXQ.FiCOjoZBwCtdKUyAPRMEwwrEpPa = Marshal.SizeOf((object)orjEEElXCDaMDfYBGFbEVljpRnXQ);
				int num2 = 0;
				while (MsdjFrwPRhtDqvryUwwfexLTAxz.djZaUzsCrjMYiTmWtzrrXfyCdrN(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH, ref hidClassGuid, num2, ref orjEEElXCDaMDfYBGFbEVljpRnXQ))
				{
					num2++;
					if (P_0 == WkDXLlTYxREDlbAXIDDXBDwKcsEY(intPtr, orjEEElXCDaMDfYBGFbEVljpRnXQ))
					{
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
			}
			MsdjFrwPRhtDqvryUwwfexLTAxz.CAHfAtcusBgUIEqbUcjyietpNzD(intPtr);
		}
		return flag;
	}

	public static IList<aBGHUHfNCcVnSUkIQdHgprgokKHB> LnfKhouDKJmylVgEuDaGCcHLfNPD()
	{
		return xWVKyupQhKOoyevYBuLSLVxcxBW();
	}

	public static oODKWlXjjUaKGJbFcHDHZKTTKwC bNIMOAyNtrGFJOyEAeujsuLGPtG(IList<aBGHUHfNCcVnSUkIQdHgprgokKHB> P_0, string P_1, StringComparison P_2)
	{
		BdxdwSjDpxTrMeUQgRBnEgKxfXq bdxdwSjDpxTrMeUQgRBnEgKxfXq = new BdxdwSjDpxTrMeUQgRBnEgKxfXq();
		bdxdwSjDpxTrMeUQgRBnEgKxfXq.YzMYiMBqggaIybXdLkmLGaVNuEL = P_1;
		bdxdwSjDpxTrMeUQgRBnEgKxfXq.iwOECUHfhNFyebtmTsvaDtKtQFY = P_2;
		if (P_0 == null)
		{
			return null;
		}
		return dcBjHlFmnjNyuKVEzQrnFiVTbiH(P_0.FirstOrDefault(bdxdwSjDpxTrMeUQgRBnEgKxfXq.okKFiegnxkezlbwbFAECwGGypQIz));
	}

	public static oODKWlXjjUaKGJbFcHDHZKTTKwC dcBjHlFmnjNyuKVEzQrnFiVTbiH(aBGHUHfNCcVnSUkIQdHgprgokKHB P_0)
	{
		try
		{
			if (string.IsNullOrEmpty(P_0.LMaMbxUwpISaejpwpFWYBPvqSto))
			{
				return null;
			}
			return new oODKWlXjjUaKGJbFcHDHZKTTKwC(P_0.oVxSbHaHpvRZYaklsfQvDzfMTcD, P_0.KRqkupszLekWneSYaJRgWgcUhKXj, P_0.fGsfPWVfUEfhuiTuPpGdhyOGOAp, P_0.WHlKfTMROhHBgIcjhkmoMPrOJjR, P_0.auptTDHVOmASTvZhkJmzdogcpmI, P_0.EIeYcAynLBvlXHRIXYlrdokkZIS, P_0.heXwfrmHSDfCSEmprtErtpPGQtYK, P_0.NsOPmXwmhbhcjIApsscIcyLQNEE);
		}
		catch (Exception)
		{
			return null;
		}
	}

	public static oODKWlXjjUaKGJbFcHDHZKTTKwC ZmFojZlQEqlGHAKPEqdTPnbWmvR(string P_0)
	{
		return MyNVLpupPnuFmchFifIhQkijTHz(P_0).FirstOrDefault();
	}

	public static IEnumerable<oODKWlXjjUaKGJbFcHDHZKTTKwC> MyNVLpupPnuFmchFifIhQkijTHz()
	{
		return from P_0 in xWVKyupQhKOoyevYBuLSLVxcxBW()
			select new oODKWlXjjUaKGJbFcHDHZKTTKwC(P_0.oVxSbHaHpvRZYaklsfQvDzfMTcD, P_0.KRqkupszLekWneSYaJRgWgcUhKXj, P_0.fGsfPWVfUEfhuiTuPpGdhyOGOAp, P_0.WHlKfTMROhHBgIcjhkmoMPrOJjR, P_0.auptTDHVOmASTvZhkJmzdogcpmI, P_0.EIeYcAynLBvlXHRIXYlrdokkZIS, P_0.heXwfrmHSDfCSEmprtErtpPGQtYK, P_0.NsOPmXwmhbhcjIApsscIcyLQNEE);
	}

	public static IEnumerable<oODKWlXjjUaKGJbFcHDHZKTTKwC> MyNVLpupPnuFmchFifIhQkijTHz(string P_0)
	{
		uhxCDJknCtZooJYpPsFJERjwBwHF uhxCDJknCtZooJYpPsFJERjwBwHF2 = new uhxCDJknCtZooJYpPsFJERjwBwHF();
		uhxCDJknCtZooJYpPsFJERjwBwHF2.YzMYiMBqggaIybXdLkmLGaVNuEL = P_0;
		return from aBGHUHfNCcVnSUkIQdHgprgokKHB2 in xWVKyupQhKOoyevYBuLSLVxcxBW().Where(uhxCDJknCtZooJYpPsFJERjwBwHF2.JKFkdXWXPsWqMEMiqOYHBJZBTFh)
			select new oODKWlXjjUaKGJbFcHDHZKTTKwC(aBGHUHfNCcVnSUkIQdHgprgokKHB2.oVxSbHaHpvRZYaklsfQvDzfMTcD, aBGHUHfNCcVnSUkIQdHgprgokKHB2.KRqkupszLekWneSYaJRgWgcUhKXj, aBGHUHfNCcVnSUkIQdHgprgokKHB2.fGsfPWVfUEfhuiTuPpGdhyOGOAp, aBGHUHfNCcVnSUkIQdHgprgokKHB2.WHlKfTMROhHBgIcjhkmoMPrOJjR, aBGHUHfNCcVnSUkIQdHgprgokKHB2.auptTDHVOmASTvZhkJmzdogcpmI, aBGHUHfNCcVnSUkIQdHgprgokKHB2.EIeYcAynLBvlXHRIXYlrdokkZIS, aBGHUHfNCcVnSUkIQdHgprgokKHB2.heXwfrmHSDfCSEmprtErtpPGQtYK, aBGHUHfNCcVnSUkIQdHgprgokKHB2.NsOPmXwmhbhcjIApsscIcyLQNEE);
	}

	public static IEnumerable<oODKWlXjjUaKGJbFcHDHZKTTKwC> MyNVLpupPnuFmchFifIhQkijTHz(int P_0, params int[] P_1)
	{
		fddlVHaCimxnpgKbQhruUkwbdxV fddlVHaCimxnpgKbQhruUkwbdxV2 = new fddlVHaCimxnpgKbQhruUkwbdxV();
		fddlVHaCimxnpgKbQhruUkwbdxV2.IqbmTkZzBzpzKtwCqxczmcnUnOd = P_0;
		fddlVHaCimxnpgKbQhruUkwbdxV2.vQoODYRgwNpsgLNCXDAXIqrKQIl = P_1;
		return (from aBGHUHfNCcVnSUkIQdHgprgokKHB2 in xWVKyupQhKOoyevYBuLSLVxcxBW()
			select new oODKWlXjjUaKGJbFcHDHZKTTKwC(aBGHUHfNCcVnSUkIQdHgprgokKHB2.oVxSbHaHpvRZYaklsfQvDzfMTcD, aBGHUHfNCcVnSUkIQdHgprgokKHB2.KRqkupszLekWneSYaJRgWgcUhKXj, aBGHUHfNCcVnSUkIQdHgprgokKHB2.fGsfPWVfUEfhuiTuPpGdhyOGOAp, aBGHUHfNCcVnSUkIQdHgprgokKHB2.WHlKfTMROhHBgIcjhkmoMPrOJjR, aBGHUHfNCcVnSUkIQdHgprgokKHB2.auptTDHVOmASTvZhkJmzdogcpmI, aBGHUHfNCcVnSUkIQdHgprgokKHB2.EIeYcAynLBvlXHRIXYlrdokkZIS, aBGHUHfNCcVnSUkIQdHgprgokKHB2.heXwfrmHSDfCSEmprtErtpPGQtYK, aBGHUHfNCcVnSUkIQdHgprgokKHB2.NsOPmXwmhbhcjIApsscIcyLQNEE)).Where(fddlVHaCimxnpgKbQhruUkwbdxV2.vHPCCmBtYKnGXgDblTGpLjyieaI);
	}

	public static IEnumerable<oODKWlXjjUaKGJbFcHDHZKTTKwC> MyNVLpupPnuFmchFifIhQkijTHz(int P_0)
	{
		iICZjlRCIxXdcHLavhHEcaPvcxy iICZjlRCIxXdcHLavhHEcaPvcxy2 = new iICZjlRCIxXdcHLavhHEcaPvcxy();
		iICZjlRCIxXdcHLavhHEcaPvcxy2.IqbmTkZzBzpzKtwCqxczmcnUnOd = P_0;
		return (from aBGHUHfNCcVnSUkIQdHgprgokKHB2 in xWVKyupQhKOoyevYBuLSLVxcxBW()
			select new oODKWlXjjUaKGJbFcHDHZKTTKwC(aBGHUHfNCcVnSUkIQdHgprgokKHB2.oVxSbHaHpvRZYaklsfQvDzfMTcD, aBGHUHfNCcVnSUkIQdHgprgokKHB2.KRqkupszLekWneSYaJRgWgcUhKXj, aBGHUHfNCcVnSUkIQdHgprgokKHB2.fGsfPWVfUEfhuiTuPpGdhyOGOAp, aBGHUHfNCcVnSUkIQdHgprgokKHB2.WHlKfTMROhHBgIcjhkmoMPrOJjR, aBGHUHfNCcVnSUkIQdHgprgokKHB2.auptTDHVOmASTvZhkJmzdogcpmI, aBGHUHfNCcVnSUkIQdHgprgokKHB2.EIeYcAynLBvlXHRIXYlrdokkZIS, aBGHUHfNCcVnSUkIQdHgprgokKHB2.heXwfrmHSDfCSEmprtErtpPGQtYK, aBGHUHfNCcVnSUkIQdHgprgokKHB2.NsOPmXwmhbhcjIApsscIcyLQNEE)).Where(iICZjlRCIxXdcHLavhHEcaPvcxy2.ostlBizzgMYtlcZMTxsBlrvMMVn);
	}

	public static bool TXZUXNyRQGlUCbpyzSobuuiKWFX()
	{
		foreach (oODKWlXjjUaKGJbFcHDHZKTTKwC item in MyNVLpupPnuFmchFifIhQkijTHz())
		{
			if (item.IsBluetoothDevice)
			{
				return true;
			}
		}
		return false;
	}

	public static int QKVNtxkIRUoPMrJFRDZsguZgSVJi()
	{
		return QKVNtxkIRUoPMrJFRDZsguZgSVJi(ref clnTlHcFMODxyrekOTPBhCkQVFw, wBRQlyWMGsmoLyCRWBKIjoilmsD);
	}

	public static int QKVNtxkIRUoPMrJFRDZsguZgSVJi(ref HXWkpUXNXBBWqhDQUwrsnqNRnFAt.ngUcRBksuHlKjJHlEOnrIGPKCpNA P_0, NativeBuffer P_1)
	{
		int num = 0;
		try
		{
			IntPtr intPtr = HXWkpUXNXBBWqhDQUwrsnqNRnFAt.OGJUmgLjczQsaGPtZKmQxnpaeEz(ref P_0, P_1);
			while (intPtr != IntPtr.Zero)
			{
				if (P_1.ReadInt(20) > 0)
				{
					num++;
				}
				if (!HXWkpUXNXBBWqhDQUwrsnqNRnFAt.oCUhJAkuQysdzBmmiEnSPRNgoTE(intPtr, P_1))
				{
					HXWkpUXNXBBWqhDQUwrsnqNRnFAt.bnmFooVwGcrPRRIMomjZXBzrRLn(intPtr);
					break;
				}
			}
		}
		catch (Exception)
		{
		}
		return num;
	}

	private static IList<aBGHUHfNCcVnSUkIQdHgprgokKHB> xWVKyupQhKOoyevYBuLSLVxcxBW()
	{
		vcztzwUpLMcQCyPRorpOHawWiOo.Clear();
		rJVMsaaAUhaTuNwqxQJKvCLmuvl.Clear();
		Guid hidClassGuid = HidClassGuid;
		IntPtr intPtr = MsdjFrwPRhtDqvryUwwfexLTAxz.LAYGYSiIvqLiyHqOjVyzCqfTKAv(ref hidClassGuid, null, 0, 18);
		if (intPtr.ToInt64() != -1)
		{
			MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH dGNRmDXpzJiDJkKQWNDOXIauQoH = JEGEgwPkLeHLfdTNklJRSyURpVWl();
			int num = 0;
			xQeRDoBFEJQyyzXIAOaKtyBIWjt.Clear();
			DPFmqupCTJCHgAuNWHLuseDdLiDE(xQeRDoBFEJQyyzXIAOaKtyBIWjt);
			List<EelNQkQeVHlRWJFRcvgSvJHxZOI> list = xQeRDoBFEJQyyzXIAOaKtyBIWjt;
			DFJfxqenTZanGKsWjAixGEWqZSaL.Clear();
			List<khIrpoIRkxMtxAkmeeBTMdULdHk> dFJfxqenTZanGKsWjAixGEWqZSaL = DFJfxqenTZanGKsWjAixGEWqZSaL;
			while (MsdjFrwPRhtDqvryUwwfexLTAxz.JiCfhtFqxalhyhqcLabzZRkMXXa(intPtr, num, ref dGNRmDXpzJiDJkKQWNDOXIauQoH))
			{
				num++;
				MsdjFrwPRhtDqvryUwwfexLTAxz.orjEEElXCDaMDfYBGFbEVljpRnXQ orjEEElXCDaMDfYBGFbEVljpRnXQ = default(MsdjFrwPRhtDqvryUwwfexLTAxz.orjEEElXCDaMDfYBGFbEVljpRnXQ);
				orjEEElXCDaMDfYBGFbEVljpRnXQ.FiCOjoZBwCtdKUyAPRMEwwrEpPa = orjEEElXCDaMDfYBGFbEVljpRnXQ.NativeSize;
				int num2 = 0;
				while (MsdjFrwPRhtDqvryUwwfexLTAxz.djZaUzsCrjMYiTmWtzrrXfyCdrN(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH, ref hidClassGuid, num2, ref orjEEElXCDaMDfYBGFbEVljpRnXQ))
				{
					num2++;
					string text = WkDXLlTYxREDlbAXIDDXBDwKcsEY(intPtr, orjEEElXCDaMDfYBGFbEVljpRnXQ);
					string instanceId = ldwdivYbrNbHBjrUJiPJmoCarjzR(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH);
					string description = vCMdJferRnjIkVcSHTUWtgeRCKih(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH) ?? OYYHJKLktCucbtFlMqgDkGXuaRkf(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH);
					string manufacturer = TzwLluYiFvhfETLeOZtMRBRtEat(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH);
					string locationInfo = string.Empty;
					uint jjlbIPDXULTcdecEnMiYJfKKIoM = (uint)dGNRmDXpzJiDJkKQWNDOXIauQoH.JjlbIPDXULTcdecEnMiYJfKKIoM;
					int count = list.Count;
					for (int i = 0; i < count; i++)
					{
						if (list[i].ZdQFmPVZeqjJDVnuVeSIlwDUJcR == jjlbIPDXULTcdecEnMiYJfKKIoM)
						{
							int cBHEEHCheltfwKetcFBASvdLJAiG = list[i].CBHEEHCheltfwKetcFBASvdLJAiG;
							if (cBHEEHCheltfwKetcFBASvdLJAiG >= 0 && cBHEEHCheltfwKetcFBASvdLJAiG < count)
							{
								locationInfo = list[cBHEEHCheltfwKetcFBASvdLJAiG].voKuAgAwcoheuJQGpUjgvflNCbU;
								break;
							}
							Logger.LogError("USB device index out of range.");
						}
					}
					UnScwgKwfJQkrNmIbTIbZkJSUJA(jjlbIPDXULTcdecEnMiYJfKKIoM, ref dFJfxqenTZanGKsWjAixGEWqZSaL, out var flag, out var bluetoothDeviceName);
					bool flag2 = false;
					if (flag)
					{
						flag2 = !JDOsjHtrFWuIctXTTwOHhUZyjEv(text);
					}
					if (!flag2)
					{
						rJVMsaaAUhaTuNwqxQJKvCLmuvl.Add(new aBGHUHfNCcVnSUkIQdHgprgokKHB(text, instanceId, description, manufacturer, locationInfo, flag, bluetoothDeviceName));
					}
				}
			}
			MsdjFrwPRhtDqvryUwwfexLTAxz.CAHfAtcusBgUIEqbUcjyietpNzD(intPtr);
		}
		return rJVMsaaAUhaTuNwqxQJKvCLmuvl;
	}

	private static void DPFmqupCTJCHgAuNWHLuseDdLiDE(List<EelNQkQeVHlRWJFRcvgSvJHxZOI> P_0)
	{
		Guid gUID_DEVINTERFACE_USB_DEVICE = MsdjFrwPRhtDqvryUwwfexLTAxz.GUID_DEVINTERFACE_USB_DEVICE;
		IntPtr intPtr = MsdjFrwPRhtDqvryUwwfexLTAxz.LAYGYSiIvqLiyHqOjVyzCqfTKAv(ref gUID_DEVINTERFACE_USB_DEVICE, null, 0, 18);
		if (intPtr.ToInt64() == -1)
		{
			return;
		}
		MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH dGNRmDXpzJiDJkKQWNDOXIauQoH = JEGEgwPkLeHLfdTNklJRSyURpVWl();
		int num = 0;
		while (MsdjFrwPRhtDqvryUwwfexLTAxz.JiCfhtFqxalhyhqcLabzZRkMXXa(intPtr, num, ref dGNRmDXpzJiDJkKQWNDOXIauQoH))
		{
			num++;
			MsdjFrwPRhtDqvryUwwfexLTAxz.orjEEElXCDaMDfYBGFbEVljpRnXQ orjEEElXCDaMDfYBGFbEVljpRnXQ = default(MsdjFrwPRhtDqvryUwwfexLTAxz.orjEEElXCDaMDfYBGFbEVljpRnXQ);
			orjEEElXCDaMDfYBGFbEVljpRnXQ.FiCOjoZBwCtdKUyAPRMEwwrEpPa = orjEEElXCDaMDfYBGFbEVljpRnXQ.NativeSize;
			int num2 = 0;
			while (MsdjFrwPRhtDqvryUwwfexLTAxz.djZaUzsCrjMYiTmWtzrrXfyCdrN(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH, ref gUID_DEVINTERFACE_USB_DEVICE, num2, ref orjEEElXCDaMDfYBGFbEVljpRnXQ))
			{
				num2++;
				string locationInfo = SJbboJHnrqHzoRzDJymqGVcWOhNi(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH);
				P_0.Add(new EelNQkQeVHlRWJFRcvgSvJHxZOI(-1, (uint)dGNRmDXpzJiDJkKQWNDOXIauQoH.JjlbIPDXULTcdecEnMiYJfKKIoM, locationInfo));
				int parentIndex = P_0.Count - 1;
				List<uint> list = LjmlPVDcCCjKiwQgnANHlloUTTW((uint)dGNRmDXpzJiDJkKQWNDOXIauQoH.JjlbIPDXULTcdecEnMiYJfKKIoM);
				if (list != null)
				{
					for (int i = 0; i < list.Count; i++)
					{
						P_0.Add(new EelNQkQeVHlRWJFRcvgSvJHxZOI(parentIndex, list[i], null));
					}
				}
			}
		}
		MsdjFrwPRhtDqvryUwwfexLTAxz.CAHfAtcusBgUIEqbUcjyietpNzD(intPtr);
	}

	private static List<khIrpoIRkxMtxAkmeeBTMdULdHk> nGZBaHoVURDKcIhvNZbJslhFfQe(List<khIrpoIRkxMtxAkmeeBTMdULdHk> P_0)
	{
		Guid gUID_BluetoothClassGuid = MsdjFrwPRhtDqvryUwwfexLTAxz.GUID_BluetoothClassGuid;
		IntPtr intPtr = MsdjFrwPRhtDqvryUwwfexLTAxz.LAYGYSiIvqLiyHqOjVyzCqfTKAv(ref gUID_BluetoothClassGuid, null, 0, 2);
		if (intPtr.ToInt64() != -1)
		{
			MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH dGNRmDXpzJiDJkKQWNDOXIauQoH = JEGEgwPkLeHLfdTNklJRSyURpVWl();
			int num = 0;
			while (MsdjFrwPRhtDqvryUwwfexLTAxz.JiCfhtFqxalhyhqcLabzZRkMXXa(intPtr, num, ref dGNRmDXpzJiDJkKQWNDOXIauQoH))
			{
				num++;
				P_0.Add(new khIrpoIRkxMtxAkmeeBTMdULdHk((uint)dGNRmDXpzJiDJkKQWNDOXIauQoH.JjlbIPDXULTcdecEnMiYJfKKIoM, UcPiLOaWSaDyRtYalWvLWGXMbVxG(intPtr, ref dGNRmDXpzJiDJkKQWNDOXIauQoH)));
			}
			MsdjFrwPRhtDqvryUwwfexLTAxz.CAHfAtcusBgUIEqbUcjyietpNzD(intPtr);
		}
		return P_0;
	}

	private static string lCJzVkskFkRsMlErRdjWAfdJtmb(uint P_0)
	{
		string empty = string.Empty;
		lCJzVkskFkRsMlErRdjWAfdJtmb(P_0, 0, ref empty);
		return empty;
	}

	private static bool lCJzVkskFkRsMlErRdjWAfdJtmb(uint P_0, int P_1, ref string P_2)
	{
		List<uint> list = irJoiLYoqUYrgPifrlKcuDRHDkQf(P_0);
		if (list == null)
		{
			return false;
		}
		string text = "";
		for (int i = 0; i < P_1; i++)
		{
			text += "_____";
		}
		for (int j = 0; j < list.Count; j++)
		{
			object obj = P_2;
			P_2 = string.Concat(obj, text, "(", list[j], ") ", gFsXNoJUOotsrEveyoBJxGajuFZ(list[j]), "\n");
			lCJzVkskFkRsMlErRdjWAfdJtmb(list[j], P_1 + 1, ref P_2);
		}
		return true;
	}

	private static List<string> eBsIaKtHdZmUtkdwMCyFLdTQvkR(uint P_0)
	{
		List<uint> list = LjmlPVDcCCjKiwQgnANHlloUTTW(P_0);
		if (list == null)
		{
			return null;
		}
		List<string> list2 = new List<string>();
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(gFsXNoJUOotsrEveyoBJxGajuFZ(list[i]));
		}
		return list2;
	}

	private static List<uint> LjmlPVDcCCjKiwQgnANHlloUTTW(uint P_0)
	{
		List<uint> list = irJoiLYoqUYrgPifrlKcuDRHDkQf(P_0);
		if (list == null)
		{
			return null;
		}
		Queue<uint> queue = new Queue<uint>(list);
		List<uint> list2 = new List<uint>();
		while (queue.Count > 0)
		{
			uint num = queue.Dequeue();
			list2.Add(num);
			List<uint> list3 = irJoiLYoqUYrgPifrlKcuDRHDkQf(num);
			if (list3 != null)
			{
				for (int i = 0; i < list3.Count; i++)
				{
					queue.Enqueue(list3[i]);
				}
			}
		}
		return list2;
	}

	private static List<string> IekrcSaGoedtyKgQaqQbKOjkWXM(uint P_0)
	{
		if (MsdjFrwPRhtDqvryUwwfexLTAxz.plJFKXFdHQBtzXxdLTBicXsnUJkf(out var num, P_0, 0u) != 0)
		{
			return null;
		}
		List<string> list = new List<string>();
		list.Add(gFsXNoJUOotsrEveyoBJxGajuFZ(num));
		while (MsdjFrwPRhtDqvryUwwfexLTAxz.dQCUihKLPoquJkqGLqDEqzHCxfI(out num, num, 0u) == 0)
		{
			list.Add(gFsXNoJUOotsrEveyoBJxGajuFZ(num));
		}
		return list;
	}

	private static List<uint> irJoiLYoqUYrgPifrlKcuDRHDkQf(uint P_0)
	{
		if (MsdjFrwPRhtDqvryUwwfexLTAxz.plJFKXFdHQBtzXxdLTBicXsnUJkf(out var num, P_0, 0u) != 0)
		{
			return null;
		}
		List<uint> list = new List<uint>();
		list.Add(num);
		while (MsdjFrwPRhtDqvryUwwfexLTAxz.dQCUihKLPoquJkqGLqDEqzHCxfI(out num, num, 0u) == 0)
		{
			list.Add(num);
		}
		return list;
	}

	private static string gFsXNoJUOotsrEveyoBJxGajuFZ(uint P_0)
	{
		if (MsdjFrwPRhtDqvryUwwfexLTAxz.nDPwKVqWVsqWePTmNhuGNhFUqvT(out var num, P_0, 0u) != 0)
		{
			return string.Empty;
		}
		if (num == 0)
		{
			return string.Empty;
		}
		num++;
		int cb = (int)num * Marshal.SystemDefaultCharSize;
		IntPtr intPtr = Marshal.AllocHGlobal(cb);
		if (MsdjFrwPRhtDqvryUwwfexLTAxz.GauuqtCuALFGnFbykBdBuBdtGFB(P_0, intPtr, (int)num, 0u) != 0)
		{
			return string.Empty;
		}
		try
		{
			return Marshal.PtrToStringUni(intPtr, (int)num);
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
		}
	}

	private static bool JJDmUIquFywKsJLCylawuBewBdbi(uint P_0, uint P_1)
	{
		List<uint> list = LjmlPVDcCCjKiwQgnANHlloUTTW(P_0);
		if (list == null)
		{
			return false;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i] == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private static void UnScwgKwfJQkrNmIbTIbZkJSUJA(uint P_0, ref List<khIrpoIRkxMtxAkmeeBTMdULdHk> P_1, out bool P_2, out string P_3)
	{
		P_3 = string.Empty;
		try
		{
			if (!vfjRAZcrVMprSqhTxIJozCDJNYR(P_0, ref P_1, out P_2, out var num) || P_1 == null)
			{
				return;
			}
			for (int i = 0; i < P_1.Count; i++)
			{
				if (P_1[i].ZdQFmPVZeqjJDVnuVeSIlwDUJcR == num)
				{
					P_3 = P_1[i].SLKbCNBoSkZmhfNjgiDKjDeRqIP;
					break;
				}
			}
		}
		catch
		{
			P_2 = false;
		}
	}

	private static bool vfjRAZcrVMprSqhTxIJozCDJNYR(uint P_0, ref List<khIrpoIRkxMtxAkmeeBTMdULdHk> P_1, out bool P_2, out uint P_3)
	{
		P_2 = false;
		P_3 = 0u;
		if (XdSbRBitawcXFKdFmXamoeBTIaCJ(P_0, "BTHENUM", out var text, out var num))
		{
			P_2 = true;
			if (P_1.Count == 0)
			{
				nGZBaHoVURDKcIhvNZbJslhFfQe(P_1);
			}
			if (uawCbKAnxFeSvvRoXkMRaKDXQOw(text, out var text2) && usEHivjxjVTZILBkgcSCUtdICav(num, text2, out var num2))
			{
				P_3 = num2;
				return true;
			}
		}
		return false;
	}

	private static bool XdSbRBitawcXFKdFmXamoeBTIaCJ(uint P_0, string P_1, out string P_2, out uint P_3)
	{
		P_2 = string.Empty;
		P_3 = 0u;
		uint num = P_0;
		uint num2;
		while (MsdjFrwPRhtDqvryUwwfexLTAxz.bIrHaZZIAUCCriUAWDPfUAdXjHVb(out num2, num, 0u) == 0)
		{
			string text = gFsXNoJUOotsrEveyoBJxGajuFZ(num2);
			if (text == string.Empty)
			{
				break;
			}
			if (text.StartsWith(P_1, StringComparison.OrdinalIgnoreCase))
			{
				P_2 = text;
				P_3 = num2;
				return true;
			}
			num = num2;
		}
		return false;
	}

	private static bool uawCbKAnxFeSvvRoXkMRaKDXQOw(string P_0, out string P_1)
	{
		P_1 = null;
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		int num = P_0.LastIndexOf('\\');
		if (num <= 0 || num >= P_0.Length - 1)
		{
			return false;
		}
		string text = P_0.Substring(num + 1);
		num = text.LastIndexOf('_');
		if (num <= 0 || num >= text.Length - 1)
		{
			return false;
		}
		text = text.Substring(0, num);
		num = text.LastIndexOf('&');
		if (num <= 0 || num >= text.Length - 1)
		{
			return false;
		}
		text = text.Substring(num + 1);
		if (text.Length <= 1)
		{
			return false;
		}
		P_1 = text;
		return true;
	}

	private static bool usEHivjxjVTZILBkgcSCUtdICav(uint P_0, string P_1, out uint P_2)
	{
		P_2 = 0u;
		if (string.IsNullOrEmpty(P_1))
		{
			return false;
		}
		if (MsdjFrwPRhtDqvryUwwfexLTAxz.bIrHaZZIAUCCriUAWDPfUAdXjHVb(out var num, P_0, 0u) != 0)
		{
			return false;
		}
		if (MsdjFrwPRhtDqvryUwwfexLTAxz.plJFKXFdHQBtzXxdLTBicXsnUJkf(out var num2, num, 0u) != 0)
		{
			return false;
		}
		uint num3 = num2;
		if (num3 == P_0 && MsdjFrwPRhtDqvryUwwfexLTAxz.dQCUihKLPoquJkqGLqDEqzHCxfI(out num3, num3, 0u) != 0)
		{
			return false;
		}
		do
		{
			string text = gFsXNoJUOotsrEveyoBJxGajuFZ(num3);
			if (text == string.Empty)
			{
				return false;
			}
			if (text.EndsWith(P_1, StringComparison.OrdinalIgnoreCase))
			{
				P_2 = num3;
				return true;
			}
		}
		while (MsdjFrwPRhtDqvryUwwfexLTAxz.dQCUihKLPoquJkqGLqDEqzHCxfI(out num3, num3, 0u) == 0);
		return false;
	}

	private static bool JDOsjHtrFWuIctXTTwOHhUZyjEv(string P_0, bool P_1 = true)
	{
		bool flag = false;
		IntPtr intPtr = IntPtr.Zero;
		string text = string.Empty;
		try
		{
			intPtr = oODKWlXjjUaKGJbFcHDHZKTTKwC.JehbOJsOgzCQFhpbtBPOfczwQrhm(P_0, sSitzLtsLskxvjKvTBbkifCoAGX.cuTASueltitUKmsLGmZrmKPFLNb, 3221225472u, dcMHdvBJUgQSpaRiuINemzFFmMJU.ZllbRgxAcXAWxMqOuwSYWhYHMiK | dcMHdvBJUgQSpaRiuINemzFFmMJU.bclhlbwGCgFOPAmoBhtegdfNbtDd);
			if (intPtr != IntPtr.Zero)
			{
				text = oODKWlXjjUaKGJbFcHDHZKTTKwC.BRmxKCgUEwFrfmXPnrqBAXoQjAk(intPtr);
				flag = true;
			}
		}
		catch
		{
			if (intPtr != IntPtr.Zero)
			{
				oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(intPtr);
			}
			return false;
		}
		if (!flag)
		{
			return false;
		}
		if (string.IsNullOrEmpty(text))
		{
			if (intPtr != IntPtr.Zero)
			{
				oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(intPtr);
			}
			return true;
		}
		HXWkpUXNXBBWqhDQUwrsnqNRnFAt.oBlQzlNifswLqBhyKCDBWLaIfxxc oBlQzlNifswLqBhyKCDBWLaIfxxc = HXWkpUXNXBBWqhDQUwrsnqNRnFAt.oBlQzlNifswLqBhyKCDBWLaIfxxc.UZzAfTehmLohmtrgPNnrWAImXanN(text, out flag);
		if (!flag)
		{
			if (intPtr != IntPtr.Zero)
			{
				oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(intPtr);
			}
			return true;
		}
		bool flag2 = false;
		try
		{
			IntPtr intPtr2 = HXWkpUXNXBBWqhDQUwrsnqNRnFAt.OGJUmgLjczQsaGPtZKmQxnpaeEz(ref clnTlHcFMODxyrekOTPBhCkQVFw, ref mCAhnQWyvkdoWagbEVjwkgtnNUz);
			if (intPtr2 == IntPtr.Zero)
			{
			}
			while (intPtr2 != IntPtr.Zero)
			{
				if (mCAhnQWyvkdoWagbEVjwkgtnNUz.SEwRUjtEWPsSYwXsKGehRGiRtHC.ZBICqJjqhbFeihBjcOjisdQtEBdr(ref oBlQzlNifswLqBhyKCDBWLaIfxxc))
				{
					flag2 = mCAhnQWyvkdoWagbEVjwkgtnNUz.HdebjnqNFYwhrkazCCVJGZdBkQcl;
					HXWkpUXNXBBWqhDQUwrsnqNRnFAt.bnmFooVwGcrPRRIMomjZXBzrRLn(intPtr2);
					if (!P_1 || flag2)
					{
						break;
					}
					PgdfUoYursRcPXlvyPcuyFpZAtRc pgdfUoYursRcPXlvyPcuyFpZAtRc = oODKWlXjjUaKGJbFcHDHZKTTKwC.unkHHMbJizIemykrHyCvbWrmLzb(intPtr);
					if (pgdfUoYursRcPXlvyPcuyFpZAtRc.InputReportByteLength <= 0)
					{
						break;
					}
					int inputReportByteLength = pgdfUoYursRcPXlvyPcuyFpZAtRc.InputReportByteLength;
					IntPtr intPtr3 = Marshal.AllocHGlobal(inputReportByteLength);
					try
					{
						if (!MsdjFrwPRhtDqvryUwwfexLTAxz.TCMQiFUczKrYgqEfRjytSyLcJvY(intPtr, intPtr3, inputReportByteLength))
						{
							Marshal.WriteByte(intPtr3, 1);
							MsdjFrwPRhtDqvryUwwfexLTAxz.TCMQiFUczKrYgqEfRjytSyLcJvY(intPtr, intPtr3, inputReportByteLength);
						}
					}
					catch
					{
					}
					finally
					{
						Marshal.FreeHGlobal(intPtr3);
					}
					break;
				}
				if (!HXWkpUXNXBBWqhDQUwrsnqNRnFAt.oCUhJAkuQysdzBmmiEnSPRNgoTE(intPtr2, ref mCAhnQWyvkdoWagbEVjwkgtnNUz))
				{
					HXWkpUXNXBBWqhDQUwrsnqNRnFAt.bnmFooVwGcrPRRIMomjZXBzrRLn(intPtr2);
					break;
				}
			}
		}
		catch
		{
		}
		finally
		{
			if (intPtr != IntPtr.Zero)
			{
				oODKWlXjjUaKGJbFcHDHZKTTKwC.MVKfBoILRvLoMFefORPtodZdMnK(intPtr);
			}
		}
		return flag2;
	}

	private static MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH JEGEgwPkLeHLfdTNklJRSyURpVWl()
	{
		MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH result = default(MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH);
		result.FiCOjoZBwCtdKUyAPRMEwwrEpPa = result.NativeSize;
		result.JjlbIPDXULTcdecEnMiYJfKKIoM = 0;
		result.ZZihBPariuDxXHHnKSIzsWhgLba = Guid.Empty;
		result.golfAhyPZhuWoQFbknDEmDBxNl = IntPtr.Zero;
		return result;
	}

	private static string WkDXLlTYxREDlbAXIDDXBDwKcsEY(IntPtr P_0, MsdjFrwPRhtDqvryUwwfexLTAxz.orjEEElXCDaMDfYBGFbEVljpRnXQ P_1)
	{
		int num = 0;
		MsdjFrwPRhtDqvryUwwfexLTAxz.xYLmRHZEQnwRMXhwxGcljhEVZeXO xYLmRHZEQnwRMXhwxGcljhEVZeXO = new MsdjFrwPRhtDqvryUwwfexLTAxz.xYLmRHZEQnwRMXhwxGcljhEVZeXO
		{
			LFmyulvhyawdMpwOAdWQXdZXmuB = ((IntPtr.Size == 4) ? (4 + Marshal.SystemDefaultCharSize) : 8)
		};
		MsdjFrwPRhtDqvryUwwfexLTAxz.TwSgUetmLKcbfjIGjcXYriDuTul(P_0, ref P_1, IntPtr.Zero, 0, ref num, IntPtr.Zero);
		if (!MsdjFrwPRhtDqvryUwwfexLTAxz.TwSgUetmLKcbfjIGjcXYriDuTul(P_0, ref P_1, ref xYLmRHZEQnwRMXhwxGcljhEVZeXO, num, ref num, IntPtr.Zero))
		{
			return null;
		}
		return xYLmRHZEQnwRMXhwxGcljhEVZeXO.QmwzuUFspTVNpjtQzShXJbDkNCB;
	}

	private static string ldwdivYbrNbHBjrUJiPJmoCarjzR(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(MsdjFrwPRhtDqvryUwwfexLTAxz.MAX_DEVICE_ID_LEN_BufferSizeInBytes);
		uint len;
		string result = (MsdjFrwPRhtDqvryUwwfexLTAxz.nWqymwtcUIYVsKnVKaChnOznYWa(P_0, ref P_1, intPtr, (uint)MsdjFrwPRhtDqvryUwwfexLTAxz.MAX_DEVICE_ID_LEN_BufferSizeInChars, out len) ? Marshal.PtrToStringUni(intPtr, (int)len) : "FAILED");
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static string OYYHJKLktCucbtFlMqgDkGXuaRkf(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		return nGzbKKtWVxBoNhjjqbxbRFJJcExn(P_0, ref P_1, 0);
	}

	private static string UcPiLOaWSaDyRtYalWvLWGXMbVxG(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		return nGzbKKtWVxBoNhjjqbxbRFJJcExn(P_0, ref P_1, 12);
	}

	private static string qVljlOFbNSnBWVFLkwVbwPmJehs(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		return nGzbKKtWVxBoNhjjqbxbRFJJcExn(P_0, ref P_1, 14);
	}

	private static string RKIdBNDAziAoLjAxFNBUHnvahDen(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		return nGzbKKtWVxBoNhjjqbxbRFJJcExn(P_0, ref P_1, 28);
	}

	private static string xswyowvYRGxUdhlGJYFGOarwsur(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		return nGzbKKtWVxBoNhjjqbxbRFJJcExn(P_0, ref P_1, 21);
	}

	private static string uOomlWVVaubRRZiaCblmdKpwtlVn(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		return nGzbKKtWVxBoNhjjqbxbRFJJcExn(P_0, ref P_1, 1);
	}

	private static string SJbboJHnrqHzoRzDJymqGVcWOhNi(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		return nGzbKKtWVxBoNhjjqbxbRFJJcExn(P_0, ref P_1, 13);
	}

	private static string TzwLluYiFvhfETLeOZtMRBRtEat(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		return nGzbKKtWVxBoNhjjqbxbRFJJcExn(P_0, ref P_1, 11);
	}

	private static string nGzbKKtWVxBoNhjjqbxbRFJJcExn(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1, int P_2)
	{
		int num = 0;
		int num2 = 0;
		MsdjFrwPRhtDqvryUwwfexLTAxz.FXLGxTHtPgRpgUfiXExqzkmghbkh(P_0, ref P_1, P_2, ref num2, IntPtr.Zero, 0, ref num);
		if (num == 0)
		{
			return null;
		}
		int num3 = num;
		IntPtr intPtr = Marshal.AllocHGlobal(num3);
		string result = (MsdjFrwPRhtDqvryUwwfexLTAxz.FXLGxTHtPgRpgUfiXExqzkmghbkh(P_0, ref P_1, P_2, ref num2, intPtr, num3, ref num) ? SARHuwGwuKtRewMZVXYoOIdHfBmI.itjgMckwbuecTGgQTbroPEfZQrY(intPtr, num3) : string.Empty);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	private static string vCMdJferRnjIkVcSHTUWtgeRCKih(IntPtr P_0, ref MsdjFrwPRhtDqvryUwwfexLTAxz.dGNRmDXpzJiDJkKQWNDOXIauQoH P_1)
	{
		if (Environment.OSVersion.Version.Major <= 5)
		{
			return null;
		}
		ulong num = 0uL;
		int num2 = 0;
		MsdjFrwPRhtDqvryUwwfexLTAxz.gWqJBwlEuXIbNivTMJGudJfybOx(P_0, ref P_1, ref MsdjFrwPRhtDqvryUwwfexLTAxz.GASBcRYxmzlTsYkXdVKiyUduQDC, ref num, IntPtr.Zero, 0, ref num2, 0u);
		if (num2 == 0)
		{
			return string.Empty;
		}
		int num3 = num2;
		IntPtr intPtr = Marshal.AllocHGlobal(num3);
		string result = (MsdjFrwPRhtDqvryUwwfexLTAxz.gWqJBwlEuXIbNivTMJGudJfybOx(P_0, ref P_1, ref MsdjFrwPRhtDqvryUwwfexLTAxz.GASBcRYxmzlTsYkXdVKiyUduQDC, ref num, intPtr, num3, ref num2, 0u) ? SARHuwGwuKtRewMZVXYoOIdHfBmI.itjgMckwbuecTGgQTbroPEfZQrY(intPtr, num3) : null);
		Marshal.FreeHGlobal(intPtr);
		return result;
	}

	[CompilerGenerated]
	private static oODKWlXjjUaKGJbFcHDHZKTTKwC KzNDqValZOaKuPFjHgTJTrhjDGiX(aBGHUHfNCcVnSUkIQdHgprgokKHB P_0)
	{
		return new oODKWlXjjUaKGJbFcHDHZKTTKwC(P_0.oVxSbHaHpvRZYaklsfQvDzfMTcD, P_0.KRqkupszLekWneSYaJRgWgcUhKXj, P_0.fGsfPWVfUEfhuiTuPpGdhyOGOAp, P_0.WHlKfTMROhHBgIcjhkmoMPrOJjR, P_0.auptTDHVOmASTvZhkJmzdogcpmI, P_0.EIeYcAynLBvlXHRIXYlrdokkZIS, P_0.heXwfrmHSDfCSEmprtErtpPGQtYK, P_0.NsOPmXwmhbhcjIApsscIcyLQNEE);
	}

	[CompilerGenerated]
	private static oODKWlXjjUaKGJbFcHDHZKTTKwC kwQDIFQMSHigmvNQWNfgRaaSXAJ(aBGHUHfNCcVnSUkIQdHgprgokKHB P_0)
	{
		return new oODKWlXjjUaKGJbFcHDHZKTTKwC(P_0.oVxSbHaHpvRZYaklsfQvDzfMTcD, P_0.KRqkupszLekWneSYaJRgWgcUhKXj, P_0.fGsfPWVfUEfhuiTuPpGdhyOGOAp, P_0.WHlKfTMROhHBgIcjhkmoMPrOJjR, P_0.auptTDHVOmASTvZhkJmzdogcpmI, P_0.EIeYcAynLBvlXHRIXYlrdokkZIS, P_0.heXwfrmHSDfCSEmprtErtpPGQtYK, P_0.NsOPmXwmhbhcjIApsscIcyLQNEE);
	}

	[CompilerGenerated]
	private static oODKWlXjjUaKGJbFcHDHZKTTKwC qAROUbpQSQQFDvMJBDzjayyEkYK(aBGHUHfNCcVnSUkIQdHgprgokKHB P_0)
	{
		return new oODKWlXjjUaKGJbFcHDHZKTTKwC(P_0.oVxSbHaHpvRZYaklsfQvDzfMTcD, P_0.KRqkupszLekWneSYaJRgWgcUhKXj, P_0.fGsfPWVfUEfhuiTuPpGdhyOGOAp, P_0.WHlKfTMROhHBgIcjhkmoMPrOJjR, P_0.auptTDHVOmASTvZhkJmzdogcpmI, P_0.EIeYcAynLBvlXHRIXYlrdokkZIS, P_0.heXwfrmHSDfCSEmprtErtpPGQtYK, P_0.NsOPmXwmhbhcjIApsscIcyLQNEE);
	}

	[CompilerGenerated]
	private static oODKWlXjjUaKGJbFcHDHZKTTKwC VXkRewRwmMlpPTKWoCnYgqPQIAE(aBGHUHfNCcVnSUkIQdHgprgokKHB P_0)
	{
		return new oODKWlXjjUaKGJbFcHDHZKTTKwC(P_0.oVxSbHaHpvRZYaklsfQvDzfMTcD, P_0.KRqkupszLekWneSYaJRgWgcUhKXj, P_0.fGsfPWVfUEfhuiTuPpGdhyOGOAp, P_0.WHlKfTMROhHBgIcjhkmoMPrOJjR, P_0.auptTDHVOmASTvZhkJmzdogcpmI, P_0.EIeYcAynLBvlXHRIXYlrdokkZIS, P_0.heXwfrmHSDfCSEmprtErtpPGQtYK, P_0.NsOPmXwmhbhcjIApsscIcyLQNEE);
	}
}
