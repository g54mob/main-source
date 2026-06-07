using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.HID;
using Rewired.HID.Drivers;
using Rewired.Interfaces;
using Rewired.Internal;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class ToVVOkLlyfGfCymNVHdVmAohoaz : IDisposable, IInputSource
{
	private class HfOXhgFiWMTOLZBIPHwwgRxkVVR
	{
		public ushort VfQrZFkNhsBFVqeAJfawWJPrDJJk;

		public ushort MeLDyEcqVTWfdnfanPQSRAutDZEf;

		public HfOXhgFiWMTOLZBIPHwwgRxkVVR(ushort usagePage, ushort usage)
		{
			VfQrZFkNhsBFVqeAJfawWJPrDJJk = usagePage;
			MeLDyEcqVTWfdnfanPQSRAutDZEf = usage;
		}
	}

	private struct GtawubPQBOfYCfwssEJkXmAmxgu
	{
		public ushort ChVuJmqNQNkcCxPIAUfevOTNKRb;

		public ushort MtVcQGDaERwZYukISEeCDevOehH;

		public int pShanBKDpoPUyQsbLLJHCsXlpFm;

		public IntPtr CjWLJXcsJnNkBoCEJPPcqKZhHlc;

		public static int SizeInBytes
		{
			get
			{
				return 8 + IntPtr.Size;
			}
		}

		public static GtawubPQBOfYCfwssEJkXmAmxgu VDtEOeGzisZcsHFkztWReNtxOeY(IntPtr P_0)
		{
			GtawubPQBOfYCfwssEJkXmAmxgu result = default(GtawubPQBOfYCfwssEJkXmAmxgu);
			int num2 = default(int);
			while (true)
			{
				int num = -1873154994;
				while (true)
				{
					switch (num ^ -1873154996)
					{
					case 0:
						break;
					case 2:
						num2 = 0;
						num = -1873154995;
						continue;
					case 1:
						result.ChVuJmqNQNkcCxPIAUfevOTNKRb = (ushort)Marshal.ReadInt16(P_0);
						num2 += 2;
						result.MtVcQGDaERwZYukISEeCDevOehH = (ushort)Marshal.ReadInt16(P_0, num2);
						num2 += 2;
						result.pShanBKDpoPUyQsbLLJHCsXlpFm = Marshal.ReadInt32(P_0, num2);
						num2 += 4;
						num = -1873154993;
						continue;
					case 3:
						result.CjWLJXcsJnNkBoCEJPPcqKZhHlc = Marshal.ReadIntPtr(P_0, num2);
						num = -1873155000;
						continue;
					default:
						return result;
					}
					break;
				}
			}
		}
	}

	private class bjAxebfRiGbIVzjHaHIXEDBqdakN : NativeBuffer
	{
		private int VRrYuWhqLZyvLZOfxGPpATuedcOz;

		private int wuYLiLoEoOVEraWIHPGeMNVtqmu;

		public int maxDevices
		{
			get
			{
				return VRrYuWhqLZyvLZOfxGPpATuedcOz;
			}
		}

		public int structSize
		{
			get
			{
				return wuYLiLoEoOVEraWIHPGeMNVtqmu;
			}
		}

		public bjAxebfRiGbIVzjHaHIXEDBqdakN(int structSize, int maxDevices)
			: base(structSize * maxDevices)
		{
			wuYLiLoEoOVEraWIHPGeMNVtqmu = structSize;
			VRrYuWhqLZyvLZOfxGPpATuedcOz = maxDevices;
		}
	}

	private sealed class orYScRugRUADejUzxfWthtKGQAuV
	{
		public IList<qRcrmPWSlvohNRTlmCdEtNVJlYH.RxfJJCYGwNNaCbrUpFZUeAqgADb> XNQjHrxQJZefvzqREwpBuExFDYr;
	}

	private sealed class VHtVuPAivbwMHvjkMkIYnOPIEFU
	{
		public orYScRugRUADejUzxfWthtKGQAuV QqEtBZOpjaBCidCqPPQAIZEsIbDn;

		public int MUAHVYLsMgIewmcSDHiEbwPhABm;

		public bool PdEhTiTmlFDEzFrBLlMXeHCsrCW(string P_0)
		{
			return P_0.Equals(QqEtBZOpjaBCidCqPPQAIZEsIbDn.XNQjHrxQJZefvzqREwpBuExFDYr[MUAHVYLsMgIewmcSDHiEbwPhABm].GefOHkcRWvlvfGDHXVfHFyOtXRG, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class ixOyxPMuWLOGhlpqBIxqSiDvTwI
	{
		public IQFNbAfLsEWvVnPpdRQbxxyYJpW AJlDPsHPQTLBEgPkegReOzzgnoEK;

		public bool oNCcLhDhqwbAPAxxzPwGqIGESUOd(IQFNbAfLsEWvVnPpdRQbxxyYJpW P_0)
		{
			return P_0.InstanceGuid == AJlDPsHPQTLBEgPkegReOzzgnoEK.InstanceGuid;
		}
	}

	private sealed class uuxxMFbsLpyZJqLYesSeumTNMsW
	{
		public bool EwdPnLtqRjqBkGDPmYhvkTVfwXF;

		public ToVVOkLlyfGfCymNVHdVmAohoaz cRVMYqVhdfyBTxGUMpvYUoxDjzC;

		public void oddDUkFZJKqneqxuKUdONQhAwwh()
		{
			try
			{
				VOKYYXeSrTNcxqiBdXkszjcZECO.OPeBwNJuyLgSnnDIVayAdkOIhUT((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)4, bOdwDzAnhsIqiAryPanDtXoAcAs.rGSRjlwECClcefsxEVvtdpdgwU, cRVMYqVhdfyBTxGUMpvYUoxDjzC.AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle);
				VOKYYXeSrTNcxqiBdXkszjcZECO.OPeBwNJuyLgSnnDIVayAdkOIhUT((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)5, bOdwDzAnhsIqiAryPanDtXoAcAs.rGSRjlwECClcefsxEVvtdpdgwU, cRVMYqVhdfyBTxGUMpvYUoxDjzC.AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle);
				VOKYYXeSrTNcxqiBdXkszjcZECO.OPeBwNJuyLgSnnDIVayAdkOIhUT((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)8, bOdwDzAnhsIqiAryPanDtXoAcAs.rGSRjlwECClcefsxEVvtdpdgwU, cRVMYqVhdfyBTxGUMpvYUoxDjzC.AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle);
				VOKYYXeSrTNcxqiBdXkszjcZECO.OPeBwNJuyLgSnnDIVayAdkOIhUT((jecGQgwwbSBPcbpFdlWHOdRmzoLm)12, (EhXVMuEUmFUPbhgQBdPoKkpbnup)1, bOdwDzAnhsIqiAryPanDtXoAcAs.rGSRjlwECClcefsxEVvtdpdgwU, cRVMYqVhdfyBTxGUMpvYUoxDjzC.AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle);
			}
			catch
			{
				EwdPnLtqRjqBkGDPmYhvkTVfwXF = true;
			}
		}
	}

	private sealed class ameveNoWSwHClQApwkSIgFMxIhr
	{
		public bool EwdPnLtqRjqBkGDPmYhvkTVfwXF;

		public void DsvtRlRzncausPYaMIfUAOecJbk()
		{
			try
			{
				VOKYYXeSrTNcxqiBdXkszjcZECO.pDQAQXlWZjsnqUEwdSpBwnNhkbC((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)4);
				VOKYYXeSrTNcxqiBdXkszjcZECO.pDQAQXlWZjsnqUEwdSpBwnNhkbC((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)5);
				VOKYYXeSrTNcxqiBdXkszjcZECO.pDQAQXlWZjsnqUEwdSpBwnNhkbC((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)8);
				VOKYYXeSrTNcxqiBdXkszjcZECO.pDQAQXlWZjsnqUEwdSpBwnNhkbC((jecGQgwwbSBPcbpFdlWHOdRmzoLm)12, (EhXVMuEUmFUPbhgQBdPoKkpbnup)1);
			}
			catch
			{
				EwdPnLtqRjqBkGDPmYhvkTVfwXF = true;
			}
		}
	}

	private sealed class OnQDrJgfVbcFgptrUrilTlaydHV
	{
		public bool EwdPnLtqRjqBkGDPmYhvkTVfwXF;

		public void BcMMfMKsZXAVCChVgiHcbHFsbVa()
		{
			try
			{
				VOKYYXeSrTNcxqiBdXkszjcZECO.pDQAQXlWZjsnqUEwdSpBwnNhkbC((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)2);
			}
			catch
			{
				EwdPnLtqRjqBkGDPmYhvkTVfwXF = true;
			}
		}
	}

	private sealed class iFdoZTbFtHpwxojkbmmayLkpgOE
	{
		public bool EwdPnLtqRjqBkGDPmYhvkTVfwXF;

		public ToVVOkLlyfGfCymNVHdVmAohoaz cRVMYqVhdfyBTxGUMpvYUoxDjzC;

		public void XcJWKXnabQYlKCoDoBEvdSMBVMQ()
		{
			try
			{
				VOKYYXeSrTNcxqiBdXkszjcZECO.OPeBwNJuyLgSnnDIVayAdkOIhUT((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)2, bOdwDzAnhsIqiAryPanDtXoAcAs.rGSRjlwECClcefsxEVvtdpdgwU, cRVMYqVhdfyBTxGUMpvYUoxDjzC.AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle);
			}
			catch
			{
				EwdPnLtqRjqBkGDPmYhvkTVfwXF = true;
			}
		}
	}

	private sealed class cWaetSvzgXfSYkCFvkJRqUBzEmH
	{
		public bool EwdPnLtqRjqBkGDPmYhvkTVfwXF;

		public ToVVOkLlyfGfCymNVHdVmAohoaz cRVMYqVhdfyBTxGUMpvYUoxDjzC;

		public void QKmPiHRelVfePjYzodQhkjWavNu()
		{
			try
			{
				VOKYYXeSrTNcxqiBdXkszjcZECO.OPeBwNJuyLgSnnDIVayAdkOIhUT((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)6, bOdwDzAnhsIqiAryPanDtXoAcAs.rGSRjlwECClcefsxEVvtdpdgwU, cRVMYqVhdfyBTxGUMpvYUoxDjzC.AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle);
			}
			catch
			{
				EwdPnLtqRjqBkGDPmYhvkTVfwXF = true;
			}
		}
	}

	private sealed class AUERozoKdUDccMvHkDVttkjdxC
	{
		public bool EwdPnLtqRjqBkGDPmYhvkTVfwXF;

		public void RTeBiOdsImTiRskWOOlxHGaHXtLO()
		{
			try
			{
				VOKYYXeSrTNcxqiBdXkszjcZECO.pDQAQXlWZjsnqUEwdSpBwnNhkbC((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)6);
			}
			catch
			{
				EwdPnLtqRjqBkGDPmYhvkTVfwXF = true;
			}
		}
	}

	private sealed class AdfeYKFWawuDgtamWAiAnTDXYYp
	{
		public bool EwdPnLtqRjqBkGDPmYhvkTVfwXF;

		public ToVVOkLlyfGfCymNVHdVmAohoaz cRVMYqVhdfyBTxGUMpvYUoxDjzC;

		public oJzlKgBJFvkxDtiZFeeJNOxpEWjF.hfDaZXAAPxoiaBGsKlTjnWHAqWhT nVbbHsrhsDuAPMckDpoOnVikFsZ;

		public void kwTFNjIXEShbekSwpWQPWJxaHBQA()
		{
			try
			{
				cRVMYqVhdfyBTxGUMpvYUoxDjzC.AqyFYviMZqTkWhMuRjGjFjIZHiFn = aMmdNykEzQKcddKLeTinMSRGBwdy(nVbbHsrhsDuAPMckDpoOnVikFsZ);
				if (cRVMYqVhdfyBTxGUMpvYUoxDjzC.AqyFYviMZqTkWhMuRjGjFjIZHiFn != null)
				{
					return;
				}
				while (true)
				{
					switch (-438081276 ^ -438081275)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						throw new Exception();
					case 0:
						return;
					}
				}
			}
			catch
			{
				while (true)
				{
					int num = -438081276;
					while (true)
					{
						switch (num ^ -438081275)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_006f;
						case 0:
							return;
						}
						break;
						IL_006f:
						EwdPnLtqRjqBkGDPmYhvkTVfwXF = true;
						num = -438081275;
					}
				}
			}
		}
	}

	private const float aHdDVwJLLgSyhlcZpcaFcdongVJ = 0.25f;

	private const int wsTDatHFsqDTjyBfhUbPtkCPkZKp = 100;

	private List<IQFNbAfLsEWvVnPpdRQbxxyYJpW> SECqOtxIJCMtDAXMpkZHtbqiXBU;

	private List<IQFNbAfLsEWvVnPpdRQbxxyYJpW> rEdFPeLXxsEAqeEeIMfCezIcblhj;

	private ReadOnlyCollection<IQFNbAfLsEWvVnPpdRQbxxyYJpW> fwlhFjFXqOqgYuKNMysXtFZsmjX;

	private BJiZlRFcXwALLpIPzfTIrXROVHG uGZJUPuGpjulAlhmkpLUpKdhAOX;

	private hIrefywNUPTTqDhngBJCNezwczv FQpwlxSyQDBewuXylJgyNhavnUa;

	private ConfigVars KdNsUfQYehHKnbEfgCkEKVkPfoEV;

	private UpdateLoopSetting UQQWcNHYFojpbLDbwsmqFyOjcft;

	private readonly bool XLllKnmXxalIfXYFEZdgaXYuqSR;

	private readonly bool bkNLtfWXdHFQHoTBrLDLPyyblom;

	private readonly bool ZmPsgTeJvSmZcVdpLFarBeNhUvt;

	private readonly bool iogeGVrPSlgmncKTwvFLvDcZvoCk;

	private readonly bool pQTSwLfppqslPVLmBQAFNfWSPkN;

	private bool WmfqkBrowMInNmlPDQHqVkSbQIK;

	private bool yotJUIWzRvQIeDbCbXOEoJFXkdA;

	private bool giUbzOrKxWRSPwPkGPpPECaExSx;

	private int BXzFFudKimmXUVpYPUMmQcRLDZj;

	private readonly object yDULJbaHRMBmgbLqIPaaJjpltAxL = new object();

	private readonly fwSDbmxzJHEgpqiBxmtyhNGAiOQ sGrrOqPxwhXpccaMEbccHCxmoJP;

	private int tBMuklPmLuskwRZbpculYhjWHNA = -1;

	private bjAxebfRiGbIVzjHaHIXEDBqdakN xnEGQEKBPLbZZJEnEIcSLPKhcAVg;

	private IntPtr ADrIYbhIDwaerYoILbFxBtRlhXPJ;

	private IntPtr ErlSgUfDONXRFdBocCDaiuaaSrLX;

	private ValueWatcher<IntPtr> IgRJWiNDrSwmVSoAKUABDlEEwTk;

	private ValueWatcher[] qTPRxrhFdHRtmpnaIrPBFeahyeB;

	private oJzlKgBJFvkxDtiZFeeJNOxpEWjF AqyFYviMZqTkWhMuRjGjFjIZHiFn;

	private BZhaPXEqBMloCcPWGQQLFvlNNpRW GFxfkOxKNHgnwgzDzQOwZakwvXV;

	private static SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP qwoahfCnzIshPTDhdKotXKCwAajG;

	private SbNYhPrwpuilnaawmyzrqxOYOrb.xPIZmsiJWcOKbvMDvhnNNsuhCYqg IenHZVXSMSoYMzBEkjMEHSVTpBtZ;

	private NativeBuffer fepWnSEENaRrxhEcdGQKnhwRitj;

	private static Rewired.Internal.GUIText LDKqLLcIGHzuOzXrSGbqlOKuSxW;

	private static HfOXhgFiWMTOLZBIPHwwgRxkVVR[] rFYFKOaXmiQNphVEWiUUorpMPnao = new HfOXhgFiWMTOLZBIPHwwgRxkVVR[4]
	{
		new HfOXhgFiWMTOLZBIPHwwgRxkVVR(1, 4),
		new HfOXhgFiWMTOLZBIPHwwgRxkVVR(1, 5),
		new HfOXhgFiWMTOLZBIPHwwgRxkVVR(1, 8),
		new HfOXhgFiWMTOLZBIPHwwgRxkVVR(12, 1)
	};

	private readonly QhgacJjSXHFhQASuQzRIauYnlslQ grQICiGqElIDIeHEzCWABLXtjvf = new QhgacJjSXHFhQASuQzRIauYnlslQ();

	private readonly znchxtogvsCwUJelEblQFvJYOmG fvfJzXdOMattcRPmXDHHKoADYtrf = new znchxtogvsCwUJelEblQFvJYOmG();

	private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

	[CompilerGenerated]
	private static Action<IQFNbAfLsEWvVnPpdRQbxxyYJpW> UECpLeLmHUagZRbzfOBTobTuuPU;

	public static Rewired.Internal.GUIText guiText
	{
		get
		{
			if (LDKqLLcIGHzuOzXrSGbqlOKuSxW != null)
			{
				goto IL_000d;
			}
			GameObject gameObject = GameObject.Find("DebugScreenLog");
			int num;
			if (gameObject != null)
			{
				LDKqLLcIGHzuOzXrSGbqlOKuSxW = gameObject.GetComponent<Rewired.Internal.GUIText>();
				num = -1940118633;
				goto IL_0012;
			}
			goto IL_0066;
			IL_0012:
			while (true)
			{
				switch (num ^ -1940118637)
				{
				case 0:
					break;
				case 3:
					return LDKqLLcIGHzuOzXrSGbqlOKuSxW;
				case 1:
					goto IL_0066;
				case 5:
					LDKqLLcIGHzuOzXrSGbqlOKuSxW = gameObject.AddComponent<Rewired.Internal.GUIText>();
					LDKqLLcIGHzuOzXrSGbqlOKuSxW.anchor = TextAnchor.LowerLeft;
					num = -1940118639;
					continue;
				case 2:
					LDKqLLcIGHzuOzXrSGbqlOKuSxW.alignment = TextAlignment.Left;
					num = -1940118633;
					continue;
				default:
					return LDKqLLcIGHzuOzXrSGbqlOKuSxW;
				}
				break;
			}
			goto IL_000d;
			IL_0066:
			gameObject = new GameObject("DebugScreenLog");
			gameObject.transform.position = Vector3.zero;
			num = -1940118634;
			goto IL_0012;
			IL_000d:
			num = -1940118640;
			goto IL_0012;
		}
	}

	public event Action DeviceChangedEvent
	{
		add
		{
			throw new NotImplementedException();
		}
		remove
		{
			throw new NotImplementedException();
		}
	}

	public ToVVOkLlyfGfCymNVHdVmAohoaz(ConfigVars configVars, bool handleJoysticks, bool useCustomDrivers, BJiZlRFcXwALLpIPzfTIrXROVHG unifiedMouse, hIrefywNUPTTqDhngBJCNezwczv unifiedKeyboard)
	{
		try
		{
			KdNsUfQYehHKnbEfgCkEKVkPfoEV = configVars;
			UQQWcNHYFojpbLDbwsmqFyOjcft = configVars.updateLoop;
			IgRJWiNDrSwmVSoAKUABDlEEwTk = new ValueWatcher<IntPtr>(FTnXWfjUOcgIwWIoVmLFTvfzpAl.TVCFgKdOWgSUzFpIsdssfCZqoVc(), FTnXWfjUOcgIwWIoVmLFTvfzpAl.TVCFgKdOWgSUzFpIsdssfCZqoVc, true);
			IgRJWiNDrSwmVSoAKUABDlEEwTk.ChangedEvent += EVuZtFUcjyVsQSJtBSZjyUvpdLY;
			qTPRxrhFdHRtmpnaIrPBFeahyeB = new ValueWatcher[1] { IgRJWiNDrSwmVSoAKUABDlEEwTk };
			bkNLtfWXdHFQHoTBrLDLPyyblom = handleJoysticks;
			pQTSwLfppqslPVLmBQAFNfWSPkN = useCustomDrivers;
			uGZJUPuGpjulAlhmkpLUpKdhAOX = unifiedMouse;
			FQpwlxSyQDBewuXylJgyNhavnUa = unifiedKeyboard;
			ZmPsgTeJvSmZcVdpLFarBeNhUvt = unifiedMouse != null;
			iogeGVrPSlgmncKTwvFLvDcZvoCk = unifiedKeyboard != null;
			XLllKnmXxalIfXYFEZdgaXYuqSR = ReInput.isEditor;
			SECqOtxIJCMtDAXMpkZHtbqiXBU = new List<IQFNbAfLsEWvVnPpdRQbxxyYJpW>();
			fwlhFjFXqOqgYuKNMysXtFZsmjX = new ReadOnlyCollection<IQFNbAfLsEWvVnPpdRQbxxyYJpW>(SECqOtxIJCMtDAXMpkZHtbqiXBU);
			rEdFPeLXxsEAqeEeIMfCezIcblhj = new List<IQFNbAfLsEWvVnPpdRQbxxyYJpW>();
			qwoahfCnzIshPTDhdKotXKCwAajG = new SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP
			{
				SbvjKtRMAnhJrOoaSiNhtdqQEdlB = (uint)Marshal.SizeOf(typeof(SbNYhPrwpuilnaawmyzrqxOYOrb.ijmFMIGSvWXIvotifQvkDuUFLNiP)),
				MVhcMlblbUmneTVbxkiaQoRZAMWk = true,
				ZoqJQJdXDyPOhbaEzzCXFpAmLJP = true,
				pSyGmyrRIjyeqJdRkiTbKpzlJgE = false,
				ITogQjdhtEXaYFpYMBbmOJpSDYS = true,
				oFEyQdclJsciZibUoJTArgJtqmj = IntPtr.Zero
			};
			IenHZVXSMSoYMzBEkjMEHSVTpBtZ = SbNYhPrwpuilnaawmyzrqxOYOrb.xPIZmsiJWcOKbvMDvhnNNsuhCYqg.QGMHznQHkHQnTPTBloqkWdrurHv();
			fepWnSEENaRrxhEcdGQKnhwRitj = new NativeBuffer((int)IenHZVXSMSoYMzBEkjMEHSVTpBtZ.SbvjKtRMAnhJrOoaSiNhtdqQEdlB);
			fepWnSEENaRrxhEcdGQKnhwRitj.Write(IenHZVXSMSoYMzBEkjMEHSVTpBtZ.SbvjKtRMAnhJrOoaSiNhtdqQEdlB, 0);
			if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
			{
				jEQHjTBCSSQEWmNbLMWqAevCDGT(PcUtzkkDpdrFQNeiojMbsnsRxgX);
				LZHMiMVBaoPEvTfuMgXoHaxzRGb();
			}
			if (handleJoysticks)
			{
				try
				{
					DMfhdqyulvaioEsLYapLXkOfYyU();
					XMDkDPlGBUZUFwIqAEzNWyjXhAU(ref SECqOtxIJCMtDAXMpkZHtbqiXBU, mwoeYZHVMrsZkMDpLOuDtLFAFiv(true));
				}
				catch (Exception ex)
				{
					if (ex.Data != null && ex.Data.Contains(1))
					{
						string text = ex.Data[1] as string;
						if (text == "sandbox")
						{
							Rewired.Logger.LogWarning("Detected possible sandbox. Raw Input does not work correctly in a sandbox with default security settings.");
						}
					}
					throw;
				}
			}
			mEMEbLlrmTneioqQIxYbqaTMcOWe();
			ReInput.ApplicationIsFullScreenChangedEvent += HMtfCJwGeNeFjSxUAtHKrUpYJAc;
		}
		catch (Exception ex2)
		{
			Dispose();
			throw ex2;
		}
	}

	public void DMfhdqyulvaioEsLYapLXkOfYyU()
	{
	}

	public void eqvmwAShmUUBmsObQvgMthAoiBP()
	{
		if (bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			lock (yDULJbaHRMBmgbLqIPaaJjpltAxL)
			{
				XMDkDPlGBUZUFwIqAEzNWyjXhAU(ref SECqOtxIJCMtDAXMpkZHtbqiXBU, rEdFPeLXxsEAqeEeIMfCezIcblhj);
				rEdFPeLXxsEAqeEeIMfCezIcblhj.Clear();
			}
		}
		if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
		{
			yDaQRNPCLgYvPsiYXvHTWuqYLaL();
		}
		giUbzOrKxWRSPwPkGPpPECaExSx = false;
	}

	public bool IfslcLnhMkosBnmwoPSIUoBSVMZ()
	{
		bool result = default(bool);
		lock (yDULJbaHRMBmgbLqIPaaJjpltAxL)
		{
			if (CwGjVESmwrepLGmWTeaqgihDSYcj())
			{
				goto IL_0015;
			}
			goto IL_0044;
			IL_0015:
			int num = 1992470661;
			goto IL_001a;
			IL_001a:
			while (true)
			{
				switch (num ^ 0x76C2B087)
				{
				case 0:
					break;
				default:
					goto end_IL_000d;
				case 3:
					result = true;
					num = 1992470659;
					continue;
				case 1:
					goto IL_0044;
				case 2:
					Thread.Sleep(250);
					num = 1992470662;
					continue;
				case 4:
					goto end_IL_000d;
				}
				break;
			}
			goto IL_0015;
			IL_0044:
			rEdFPeLXxsEAqeEeIMfCezIcblhj = mwoeYZHVMrsZkMDpLOuDtLFAFiv(false);
			num = 1992470660;
			goto IL_001a;
			end_IL_000d:;
		}
		return result;
	}

	public bool eNOnPlLjwNbOfIUjAqxYoQZqABfY()
	{
		int num = EgEjAUhxDiCIDqLRLKYENeXGoQHA();
		if (num == BXzFFudKimmXUVpYPUMmQcRLDZj)
		{
			return false;
		}
		BXzFFudKimmXUVpYPUMmQcRLDZj = num;
		return true;
	}

	public bool CwGjVESmwrepLGmWTeaqgihDSYcj()
	{
		try
		{
			return qRcrmPWSlvohNRTlmCdEtNVJlYH.CwGjVESmwrepLGmWTeaqgihDSYcj();
		}
		catch
		{
		}
		return false;
	}

	public void SystemDeviceDisconnected()
	{
		if (bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			giUbzOrKxWRSPwPkGPpPECaExSx = true;
		}
	}

	public void SystemDeviceConnected()
	{
		if (bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			giUbzOrKxWRSPwPkGPpPECaExSx = true;
		}
	}

	public void Update()
	{
		int num = 0;
		while (true)
		{
			IL_0047:
			if (num < qTPRxrhFdHRtmpnaIrPBFeahyeB.Length)
			{
				goto IL_002e;
			}
			int num2;
			if (tBMuklPmLuskwRZbpculYhjWHNA >= 0)
			{
				sbFnlIobbXszKiPljXeTfLsmAsr();
				num2 = -1414130681;
				goto IL_0009;
			}
			goto IL_0068;
			IL_0068:
			if (!XLllKnmXxalIfXYFEZdgaXYuqSR || tBMuklPmLuskwRZbpculYhjWHNA >= 0)
			{
				break;
			}
			if (!iogeGVrPSlgmncKTwvFLvDcZvoCk)
			{
				int num3;
				if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
				{
					num2 = -1414130684;
					num3 = num2;
				}
				else
				{
					num2 = -1414130683;
					num3 = num2;
				}
				goto IL_0009;
			}
			goto IL_009d;
			IL_009d:
			TQBasBbhkcjlGGZtiepUfxWOjzql();
			num2 = -1414130683;
			goto IL_0009;
			IL_002e:
			qTPRxrhFdHRtmpnaIrPBFeahyeB[num].Update();
			num++;
			num2 = -1414130685;
			goto IL_0009;
			IL_0009:
			while (true)
			{
				switch (num2 ^ -1414130681)
				{
				case 5:
					num2 = -1414130682;
					continue;
				default:
					return;
				case 1:
					break;
				case 4:
					goto IL_0047;
				case 0:
					goto IL_0068;
				case 3:
					goto IL_009d;
				case 2:
					return;
				}
				break;
			}
			goto IL_002e;
		}
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (!bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			return;
		}
		CRXrBgggAdrpYwIPGGrSdEyGnoQt cRXrBgggAdrpYwIPGGrSdEyGnoQt = default(CRXrBgggAdrpYwIPGGrSdEyGnoQt);
		int num2 = default(int);
		while (true)
		{
			int count = SECqOtxIJCMtDAXMpkZHtbqiXBU.Count;
			int num = -1411569501;
			while (true)
			{
				switch (num ^ -1411569498)
				{
				case 2:
					num = -1411569497;
					continue;
				case 0:
				{
					cRXrBgggAdrpYwIPGGrSdEyGnoQt = SECqOtxIJCMtDAXMpkZHtbqiXBU[num2];
					int num3;
					if (cRXrBgggAdrpYwIPGGrSdEyGnoQt != null)
					{
						num = -1411569503;
						num3 = num;
					}
					else
					{
						num = -1411569504;
						num3 = num;
					}
					continue;
				}
				case 6:
					num2++;
					num = -1411569499;
					continue;
				case 7:
					cRXrBgggAdrpYwIPGGrSdEyGnoQt.Update(updateLoop);
					num = -1411569504;
					continue;
				case 4:
					num = -1411569499;
					continue;
				case 1:
					break;
				case 5:
					num2 = 0;
					num = -1411569502;
					continue;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 0;
				}
				break;
			}
		}
	}

	public void UpdateFinished()
	{
		if (!bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			return;
		}
		CRXrBgggAdrpYwIPGGrSdEyGnoQt cRXrBgggAdrpYwIPGGrSdEyGnoQt = default(CRXrBgggAdrpYwIPGGrSdEyGnoQt);
		while (true)
		{
			int count = SECqOtxIJCMtDAXMpkZHtbqiXBU.Count;
			int num = 0;
			int num2 = 1698336742;
			while (true)
			{
				switch (num2 ^ 0x653A8FE5)
				{
				case 5:
					num2 = 1698336743;
					continue;
				case 2:
					break;
				case 1:
				{
					cRXrBgggAdrpYwIPGGrSdEyGnoQt = SECqOtxIJCMtDAXMpkZHtbqiXBU[num];
					int num3;
					if (cRXrBgggAdrpYwIPGGrSdEyGnoQt == null)
					{
						num2 = 1698336737;
						num3 = num2;
					}
					else
					{
						num2 = 1698336741;
						num3 = num2;
					}
					continue;
				}
				case 0:
					cRXrBgggAdrpYwIPGGrSdEyGnoQt.UpdateFinished();
					num2 = 1698336737;
					continue;
				case 4:
					num++;
					num2 = 1698336742;
					continue;
				default:
					if (num >= count)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return fwlhFjFXqOqgYuKNMysXtFZsmjX as IList<T>;
	}

	private List<IQFNbAfLsEWvVnPpdRQbxxyYJpW> mwoeYZHVMrsZkMDpLOuDtLFAFiv(bool P_0)
	{
		orYScRugRUADejUzxfWthtKGQAuV orYScRugRUADejUzxfWthtKGQAuV2 = new orYScRugRUADejUzxfWthtKGQAuV();
		if (!bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			return new List<IQFNbAfLsEWvVnPpdRQbxxyYJpW>();
		}
		EhXSNhmGrFwpwLZqHqjvpVcMidO();
		List<bURkZovRhaRlbJuBnqAqELdHxri> list = null;
		List<IQFNbAfLsEWvVnPpdRQbxxyYJpW> list2 = new List<IQFNbAfLsEWvVnPpdRQbxxyYJpW>();
		BXzFFudKimmXUVpYPUMmQcRLDZj = HIkPJtbWWObAhkrSSfSrcmWEaokf();
		if (0 == 0)
		{
			list = VOKYYXeSrTNcxqiBdXkszjcZECO.rvvpMXixmrFdADnAFBDJZozCGUyF(P_0);
			bool flag = true;
		}
		if (list == null)
		{
			list = new List<bURkZovRhaRlbJuBnqAqELdHxri>();
		}
		try
		{
			orYScRugRUADejUzxfWthtKGQAuV2.XNQjHrxQJZefvzqREwpBuExFDYr = qRcrmPWSlvohNRTlmCdEtNVJlYH.CKeYpxOimceVqdsqIUoFDSUCpMms();
		}
		catch (Exception ex)
		{
			orYScRugRUADejUzxfWthtKGQAuV2.XNQjHrxQJZefvzqREwpBuExFDYr = new List<qRcrmPWSlvohNRTlmCdEtNVJlYH.RxfJJCYGwNNaCbrUpFZUeAqgADb>();
			Rewired.Logger.LogError("Exception getting HID device list.\n" + ex);
		}
		List<string> list3 = new List<string>();
		int num2 = default(int);
		dQKGNKOGnMQxAfhybGNXHfXiiDv dQKGNKOGnMQxAfhybGNXHfXiiDv2 = default(dQKGNKOGnMQxAfhybGNXHfXiiDv);
		int num4 = default(int);
		Predicate<string> predicate = default(Predicate<string>);
		VHtVuPAivbwMHvjkMkIYnOPIEFU vHtVuPAivbwMHvjkMkIYnOPIEFU = default(VHtVuPAivbwMHvjkMkIYnOPIEFU);
		while (true)
		{
			int num = 1332207553;
			while (true)
			{
				int num5;
				int num6;
				switch (num ^ 0x4F67DFC0)
				{
				case 0:
					break;
				case 1:
					goto IL_009c;
				default:
				{
					IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW = null;
					try
					{
						bURkZovRhaRlbJuBnqAqELdHxri bURkZovRhaRlbJuBnqAqELdHxri2 = list[num2];
						while (true)
						{
							IL_00c2:
							int num3 = 1332207553;
							while (true)
							{
								switch (num3 ^ 0x4F67DFC0)
								{
								case 6:
									break;
								case 1:
									if (list[num2] == null)
									{
										goto end_IL_00c7;
									}
									goto case 0;
								case 0:
									if (bURkZovRhaRlbJuBnqAqELdHxri2.DeviceType == TUEeiLGHzyEyJIpYufytZOXrNfMo.UAeiRUQTBSvtMZfpSWbrqScgDKu)
									{
										goto IL_0152;
									}
									goto end_IL_00c7;
								case 3:
									iQFNbAfLsEWvVnPpdRQbxxyYJpW = tOMzqpxKknrDgbcIOepQohsMjNS(bURkZovRhaRlbJuBnqAqELdHxri2.Handle, dQKGNKOGnMQxAfhybGNXHfXiiDv2, orYScRugRUADejUzxfWthtKGQAuV2.XNQjHrxQJZefvzqREwpBuExFDYr, list3, num4);
									if (iQFNbAfLsEWvVnPpdRQbxxyYJpW == null)
									{
										goto end_IL_00c7;
									}
									goto default;
								case 4:
									if (dQKGNKOGnMQxAfhybGNXHfXiiDv2 == null)
									{
										goto end_IL_00c7;
									}
									goto case 3;
								case 2:
									goto IL_0152;
								default:
									list2.Add(iQFNbAfLsEWvVnPpdRQbxxyYJpW);
									num4++;
									goto end_IL_00c7;
								}
								goto IL_00c2;
								IL_0152:
								dQKGNKOGnMQxAfhybGNXHfXiiDv2 = bURkZovRhaRlbJuBnqAqELdHxri2 as dQKGNKOGnMQxAfhybGNXHfXiiDv;
								num3 = 1332207556;
								continue;
								end_IL_00c7:
								break;
							}
							break;
						}
					}
					catch (Exception ex2)
					{
						Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional.\n" + ex2.Message);
					}
					num2++;
					goto IL_0195;
				}
				case 3:
					goto IL_01b7;
					IL_02f3:
					return list2;
					IL_0195:
					num5 = 1332207555;
					goto IL_019a;
					IL_019a:
					switch (num5 ^ 0x4F67DFC0)
					{
					case 0:
						break;
					case 3:
						goto IL_01b7;
					case 1:
						predicate = null;
						vHtVuPAivbwMHvjkMkIYnOPIEFU = new VHtVuPAivbwMHvjkMkIYnOPIEFU();
						vHtVuPAivbwMHvjkMkIYnOPIEFU.QqEtBZOpjaBCidCqPPQAIZEsIbDn = orYScRugRUADejUzxfWthtKGQAuV2;
						vHtVuPAivbwMHvjkMkIYnOPIEFU.MUAHVYLsMgIewmcSDHiEbwPhABm = 0;
						goto IL_02d4;
					default:
						{
							IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW2 = null;
							try
							{
								if (predicate == null)
								{
									predicate = vHtVuPAivbwMHvjkMkIYnOPIEFU.PdEhTiTmlFDEzFrBLlMXeHCsrCW;
								}
								if (string.IsNullOrEmpty(list3.Find(predicate)))
								{
									goto IL_0253;
								}
								while (true)
								{
									switch (0x4F67DFC2 ^ 0x4F67DFC0)
									{
									case 0:
										break;
									case 2:
										goto end_IL_0228;
									case 1:
										goto IL_0253;
									default:
										goto IL_027d;
									}
									continue;
									end_IL_0228:
									break;
								}
								goto end_IL_0205;
								IL_0253:
								iQFNbAfLsEWvVnPpdRQbxxyYJpW2 = ZlLEsogUoDRpUqePcjmTVfgEnhva(orYScRugRUADejUzxfWthtKGQAuV2.XNQjHrxQJZefvzqREwpBuExFDYr[vHtVuPAivbwMHvjkMkIYnOPIEFU.MUAHVYLsMgIewmcSDHiEbwPhABm], num4);
								if (iQFNbAfLsEWvVnPpdRQbxxyYJpW2 != null)
								{
									goto IL_027d;
								}
								goto end_IL_0205;
								IL_027d:
								list2.Add(iQFNbAfLsEWvVnPpdRQbxxyYJpW2);
								num4++;
								end_IL_0205:;
							}
							catch (Exception ex3)
							{
								Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional." + ex3.Message);
							}
							vHtVuPAivbwMHvjkMkIYnOPIEFU.MUAHVYLsMgIewmcSDHiEbwPhABm++;
							goto IL_02b6;
						}
						IL_02d4:
						if (vHtVuPAivbwMHvjkMkIYnOPIEFU.MUAHVYLsMgIewmcSDHiEbwPhABm < orYScRugRUADejUzxfWthtKGQAuV2.XNQjHrxQJZefvzqREwpBuExFDYr.Count)
						{
							goto default;
						}
						num6 = 1332207554;
						goto IL_02bb;
						IL_02b6:
						num6 = 1332207553;
						goto IL_02bb;
						IL_02bb:
						switch (num6 ^ 0x4F67DFC0)
						{
						case 0:
							break;
						case 1:
							goto IL_02d4;
						default:
							goto IL_02f3;
						}
						goto IL_02b6;
					}
					goto IL_0195;
					IL_01b7:
					if (num2 < list.Count)
					{
						goto default;
					}
					if (!KdNsUfQYehHKnbEfgCkEKVkPfoEV.useXInput)
					{
						num5 = 1332207553;
						goto IL_019a;
					}
					goto IL_02f3;
				}
				break;
				IL_009c:
				num4 = 0;
				num2 = 0;
				num = 1332207555;
			}
		}
	}

	private static void XMDkDPlGBUZUFwIqAEzNWyjXhAU(ref List<IQFNbAfLsEWvVnPpdRQbxxyYJpW> P_0, List<IQFNbAfLsEWvVnPpdRQbxxyYJpW> P_1)
	{
		if (P_0 == null)
		{
			P_0 = new List<IQFNbAfLsEWvVnPpdRQbxxyYJpW>();
			goto IL_000e;
		}
		goto IL_01dc;
		IL_00e9:
		if (P_1.Count == 0)
		{
			P_0.ForEach(delegate(IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW)
			{
				iQFNbAfLsEWvVnPpdRQbxxyYJpW.Dispose();
			});
			P_0.Clear();
			return;
		}
		goto IL_01bd;
		IL_000e:
		int num = 855635660;
		goto IL_0013;
		IL_0013:
		int num2 = default(int);
		int count = default(int);
		int num3 = default(int);
		IQFNbAfLsEWvVnPpdRQbxxyYJpW[] array = default(IQFNbAfLsEWvVnPpdRQbxxyYJpW[]);
		ixOyxPMuWLOGhlpqBIxqSiDvTwI ixOyxPMuWLOGhlpqBIxqSiDvTwI2 = default(ixOyxPMuWLOGhlpqBIxqSiDvTwI);
		int count2 = default(int);
		while (true)
		{
			switch (num ^ 0x32FFF6C1)
			{
			case 8:
				break;
			default:
				return;
			case 3:
				goto IL_0063;
			case 15:
				if (num2 >= count)
				{
					P_0.Clear();
					num3 = 0;
					num = 855635652;
					continue;
				}
				goto case 9;
			case 12:
				if (array[num3] != null)
				{
					array[num3].SetJoystickId(num3);
					P_0.Add(array[num3]);
					num = 855635655;
					continue;
				}
				goto case 6;
			case 5:
				num = 855635650;
				continue;
			case 4:
				if (array.Length > 0)
				{
					Array.Sort(array, BjgEbMKSLplvtRjDXAyeOHfnYmuf);
					num = 855635658;
					continue;
				}
				goto case 11;
			case 1:
				goto IL_00e9;
			case 6:
				num3++;
				num = 855635650;
				continue;
			case 9:
				ixOyxPMuWLOGhlpqBIxqSiDvTwI2 = new ixOyxPMuWLOGhlpqBIxqSiDvTwI();
				ixOyxPMuWLOGhlpqBIxqSiDvTwI2.AJlDPsHPQTLBEgPkegReOzzgnoEK = P_0[num2];
				if (ixOyxPMuWLOGhlpqBIxqSiDvTwI2.AJlDPsHPQTLBEgPkegReOzzgnoEK != null)
				{
					goto IL_0159;
				}
				goto case 0;
			case 2:
				count = P_0.Count;
				array = P_1.ToArray();
				num = 855635653;
				continue;
			case 11:
				num2 = 0;
				num = 855635662;
				continue;
			case 7:
				ixOyxPMuWLOGhlpqBIxqSiDvTwI2.AJlDPsHPQTLBEgPkegReOzzgnoEK.Dispose();
				num = 855635649;
				continue;
			case 14:
				goto IL_01bd;
			case 0:
				num2++;
				num = 855635662;
				continue;
			case 13:
				goto IL_01dc;
			case 10:
				return;
			}
			break;
			IL_0159:
			int num4;
			if (Array.Find(array, ixOyxPMuWLOGhlpqBIxqSiDvTwI2.oNCcLhDhqwbAPAxxzPwGqIGESUOd) != null)
			{
				num = 855635649;
				num4 = num;
			}
			else
			{
				num = 855635654;
				num4 = num;
			}
			continue;
			IL_0063:
			int num5;
			if (num3 < count2)
			{
				num = 855635661;
				num5 = num;
			}
			else
			{
				num = 855635659;
				num5 = num;
			}
		}
		goto IL_000e;
		IL_01bd:
		count2 = P_1.Count;
		num = 855635651;
		goto IL_0013;
		IL_01dc:
		if (P_1 == null)
		{
			P_1 = new List<IQFNbAfLsEWvVnPpdRQbxxyYJpW>();
			num = 855635648;
			goto IL_0013;
		}
		goto IL_00e9;
	}

	private List<bURkZovRhaRlbJuBnqAqELdHxri> eBNOUgZuTmqnkKHoxowndBLcjeYg()
	{
		List<bURkZovRhaRlbJuBnqAqELdHxri> list = new List<bURkZovRhaRlbJuBnqAqELdHxri>();
		try
		{
			foreach (hdKCmGlHttTBdcjeWBCjBOXCTjJ item in qRcrmPWSlvohNRTlmCdEtNVJlYH.FUYFkvWvvKHbFHzKCEkoUnCiWIh())
			{
				try
				{
					list.Add(new dQKGNKOGnMQxAfhybGNXHfXiiDv
					{
						DeviceName = isyWZdfASARGiqSOyowogCitxgy.mdjbOJAFekxDexxXsJTFbOIEzzlC(item.DevicePath),
						DeviceType = TUEeiLGHzyEyJIpYufytZOXrNfMo.UAeiRUQTBSvtMZfpSWbrqScgDKu,
						Handle = IntPtr.Zero,
						ProductId = item.Attributes.ProductId,
						VendorId = item.Attributes.VendorId,
						VersionNumber = item.Attributes.Version,
						UsagePage = (jecGQgwwbSBPcbpFdlWHOdRmzoLm)item.Capabilities.UsagePage,
						Usage = (EhXVMuEUmFUPbhgQBdPoKkpbnup)item.Capabilities.Usage
					});
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	private IQFNbAfLsEWvVnPpdRQbxxyYJpW tOMzqpxKknrDgbcIOepQohsMjNS(IntPtr P_0, dQKGNKOGnMQxAfhybGNXHfXiiDv P_1, IList<qRcrmPWSlvohNRTlmCdEtNVJlYH.RxfJJCYGwNNaCbrUpFZUeAqgADb> P_2, List<string> P_3, int P_4)
	{
		ushort num = (ushort)P_1.UsagePage;
		ushort num2 = (ushort)P_1.Usage;
		string deviceName = P_1.DeviceName;
		if (!lDCfBZQMGkOpmjKNPLbtWjyILKL(num, num2))
		{
			return null;
		}
		string text = isyWZdfASARGiqSOyowogCitxgy.mdjbOJAFekxDexxXsJTFbOIEzzlC(deviceName);
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		P_3.Add(text);
		hdKCmGlHttTBdcjeWBCjBOXCTjJ hdKCmGlHttTBdcjeWBCjBOXCTjJ2 = qRcrmPWSlvohNRTlmCdEtNVJlYH.mmTeSZfIZImoGtQuiwmicVAHNuf(P_2, text, StringComparison.OrdinalIgnoreCase);
		if (hdKCmGlHttTBdcjeWBCjBOXCTjJ2 == null)
		{
			return null;
		}
		string text2 = hdKCmGlHttTBdcjeWBCjBOXCTjJ2.ReadProductName();
		string bluetoothDeviceName = hdKCmGlHttTBdcjeWBCjBOXCTjJ2.BluetoothDeviceName;
		Guid guid = MiscTools.CreateHIDProductGuid(hdKCmGlHttTBdcjeWBCjBOXCTjJ2.Attributes.VendorId, hdKCmGlHttTBdcjeWBCjBOXCTjJ2.Attributes.ProductId);
		if (ZBdWqjRRrpMQStGZMBFtHgnrSdp.DijjflnEZpcmHhIbjbklhBFlhtP(guid, text2, bluetoothDeviceName))
		{
			P_3.RemoveAt(P_3.Count - 1);
			return null;
		}
		return iFHhfFcedqPfzBCwJfWgOeCwkwu(iGRvmBZykBTTuGmotZKeBVybDl.gEeoScnGnXjjkhsxJYSeSFZsobvI, hdKCmGlHttTBdcjeWBCjBOXCTjJ2, P_0, num, num2, P_4);
	}

	private IQFNbAfLsEWvVnPpdRQbxxyYJpW ZlLEsogUoDRpUqePcjmTVfgEnhva(qRcrmPWSlvohNRTlmCdEtNVJlYH.RxfJJCYGwNNaCbrUpFZUeAqgADb P_0, int P_1)
	{
		hdKCmGlHttTBdcjeWBCjBOXCTjJ hdKCmGlHttTBdcjeWBCjBOXCTjJ2 = qRcrmPWSlvohNRTlmCdEtNVJlYH.gQMyXuzcFWHDzrQuZAUeBNMALfuE(P_0);
		if (hdKCmGlHttTBdcjeWBCjBOXCTjJ2 == null)
		{
			return null;
		}
		ushort num = (ushort)hdKCmGlHttTBdcjeWBCjBOXCTjJ2.Capabilities.UsagePage;
		ushort num2 = (ushort)hdKCmGlHttTBdcjeWBCjBOXCTjJ2.Capabilities.Usage;
		if (!lDCfBZQMGkOpmjKNPLbtWjyILKL(num, num2))
		{
			return null;
		}
		if (!ZBdWqjRRrpMQStGZMBFtHgnrSdp.DijjflnEZpcmHhIbjbklhBFlhtP(MiscTools.CreateHIDProductGuid(hdKCmGlHttTBdcjeWBCjBOXCTjJ2.Attributes.VendorId, hdKCmGlHttTBdcjeWBCjBOXCTjJ2.Attributes.ProductId), hdKCmGlHttTBdcjeWBCjBOXCTjJ2.ReadProductName(), hdKCmGlHttTBdcjeWBCjBOXCTjJ2.BluetoothDeviceName))
		{
			return null;
		}
		return iFHhfFcedqPfzBCwJfWgOeCwkwu(iGRvmBZykBTTuGmotZKeBVybDl.UDfbScXooChQeUQXcObQPckklzw, hdKCmGlHttTBdcjeWBCjBOXCTjJ2, IntPtr.Zero, num, num2, P_1);
	}

	private IQFNbAfLsEWvVnPpdRQbxxyYJpW iFHhfFcedqPfzBCwJfWgOeCwkwu(iGRvmBZykBTTuGmotZKeBVybDl P_0, hdKCmGlHttTBdcjeWBCjBOXCTjJ P_1, IntPtr P_2, ushort P_3, ushort P_4, int P_5)
	{
		bool flag = P_3 != 1 || !YzxJnJDUJemCSpIExExEhMbbJDhC.RbxJnFXlJPdDFafaxXgQcNqRmmpt.GIEmArGveRarwCHyVGRpClwSoFCj(P_4);
		string text = P_1.ReadProductName();
		string bluetoothDeviceName = P_1.BluetoothDeviceName;
		Guid guid = MiscTools.CreateHIDProductGuid(P_1.Attributes.VendorId, P_1.Attributes.ProductId);
		if (KdNsUfQYehHKnbEfgCkEKVkPfoEV.useXInput && khPCPJgtQFokObAEkJKNQbaUfSZG.FAFAhPjbbBwAOnGLLyaOWiEzWeM(P_1.DevicePath, text, bluetoothDeviceName, guid))
		{
			return null;
		}
		IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW = JBDwnHGtveOtleSDodUIgpPyeayk(P_0, P_2, P_5, P_1, SECqOtxIJCMtDAXMpkZHtbqiXBU, flag);
		if (iQFNbAfLsEWvVnPpdRQbxxyYJpW == null || !iQFNbAfLsEWvVnPpdRQbxxyYJpW.HasElements)
		{
			if (iQFNbAfLsEWvVnPpdRQbxxyYJpW != null && !iQFNbAfLsEWvVnPpdRQbxxyYJpW.HasElements)
			{
				iQFNbAfLsEWvVnPpdRQbxxyYJpW.Dispose();
			}
			return null;
		}
		return iQFNbAfLsEWvVnPpdRQbxxyYJpW;
	}

	private bool lDCfBZQMGkOpmjKNPLbtWjyILKL(ushort P_0, ushort P_1)
	{
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num >= rFYFKOaXmiQNphVEWiUUorpMPnao.Length)
			{
				num2 = 1734363681;
				num3 = num2;
			}
			else
			{
				num2 = 1734363685;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x67604A21)
				{
				case 5:
					num2 = 1734363685;
					continue;
				case 4:
					if (rFYFKOaXmiQNphVEWiUUorpMPnao[num].VfQrZFkNhsBFVqeAJfawWJPrDJJk == P_0)
					{
						num2 = 1734363680;
						continue;
					}
					goto IL_005c;
				case 1:
					if (rFYFKOaXmiQNphVEWiUUorpMPnao[num].MeLDyEcqVTWfdnfanPQSRAutDZEf == P_1)
					{
						num2 = 1734363683;
						continue;
					}
					goto IL_005c;
				case 2:
					return true;
				case 3:
					break;
				default:
					{
						return false;
					}
					IL_005c:
					num++;
					num2 = 1734363682;
					continue;
				}
				break;
			}
		}
	}

	private int HIkPJtbWWObAhkrSSfSrcmWEaokf()
	{
		try
		{
			return qRcrmPWSlvohNRTlmCdEtNVJlYH.POIApcAGjfOoBdAvKfLhVcSifKmd();
		}
		catch
		{
			return 0;
		}
	}

	private int EgEjAUhxDiCIDqLRLKYENeXGoQHA()
	{
		try
		{
			return qRcrmPWSlvohNRTlmCdEtNVJlYH.POIApcAGjfOoBdAvKfLhVcSifKmd(ref qwoahfCnzIshPTDhdKotXKCwAajG, fepWnSEENaRrxhEcdGQKnhwRitj);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	private IQFNbAfLsEWvVnPpdRQbxxyYJpW JBDwnHGtveOtleSDodUIgpPyeayk(iGRvmBZykBTTuGmotZKeBVybDl P_0, IntPtr P_1, int P_2, hdKCmGlHttTBdcjeWBCjBOXCTjJ P_3, List<IQFNbAfLsEWvVnPpdRQbxxyYJpW> P_4, bool P_5)
	{
		if (P_5 && !pQTSwLfppqslPVLmBQAFNfWSPkN)
		{
			return null;
		}
		try
		{
			if (pQTSwLfppqslPVLmBQAFNfWSPkN)
			{
				if (P_4 != null)
				{
					for (int i = 0; i < P_4.Count; i++)
					{
						bbhCXrFCupJGnHGvLurGZgdOxuXJ bbhCXrFCupJGnHGvLurGZgdOxuXJ2 = P_4[i] as bbhCXrFCupJGnHGvLurGZgdOxuXJ;
						if (bbhCXrFCupJGnHGvLurGZgdOxuXJ2 != null && bbhCXrFCupJGnHGvLurGZgdOxuXJ2.Driver != null && !(P_3.InstanceId != bbhCXrFCupJGnHGvLurGZgdOxuXJ2.HidDevice.InstanceId))
						{
							bbhCXrFCupJGnHGvLurGZgdOxuXJ2.SetJoystickId(P_2);
							return bbhCXrFCupJGnHGvLurGZgdOxuXJ2;
						}
					}
				}
				int num = HIDDeviceDriver.FindDriverId(P_3.Attributes.VendorId, P_3.Attributes.ProductId);
				if (num >= 0)
				{
					HidOutputReportHandler hidOutputReportHandler = new HidOutputReportHandler(P_3.CEPHoICJTpvBcaKQEZxqBoQoXgq);
					HIDDeviceDriver driver = HIDDeviceDriver.GetDriver(num, new HIDDeviceDriver.InitArgs(UQQWcNHYFojpbLDbwsmqFyOjcft, (!P_3.IsBluetoothDevice) ? DeviceConnectionType.WhXePeloiwLHrxaldRYhnNKmxhu : DeviceConnectionType.qsDfuTzZaVPhIJLeNOadBBAjTAI, 65535, -65535, -1, 4500, P_3.Capabilities.InputReportByteLength, P_3.Capabilities.OutputReportByteLength, P_3.CEPHoICJTpvBcaKQEZxqBoQoXgq, hidOutputReportHandler.WriteReport));
					if (driver != null)
					{
						return new bbhCXrFCupJGnHGvLurGZgdOxuXJ(P_2, P_0, P_1, P_3, driver, hidOutputReportHandler);
					}
				}
				if (P_5)
				{
					return null;
				}
			}
		}
		catch
		{
			Rewired.Logger.LogWarning("Exception creating custom driver joystick. Will fall back to normal HID joystick.");
		}
		try
		{
			if (P_4 != null)
			{
				for (int j = 0; j < P_4.Count; j++)
				{
					eLhSQQinbiEEdCMMucMDEndjKKNi eLhSQQinbiEEdCMMucMDEndjKKNi2 = P_4[j] as eLhSQQinbiEEdCMMucMDEndjKKNi;
					if (eLhSQQinbiEEdCMMucMDEndjKKNi2 != null && !(P_3.InstanceId != eLhSQQinbiEEdCMMucMDEndjKKNi2.HidDevice.InstanceId))
					{
						eLhSQQinbiEEdCMMucMDEndjKKNi2.SetJoystickId(P_2);
						return eLhSQQinbiEEdCMMucMDEndjKKNi2;
					}
				}
			}
			return new eLhSQQinbiEEdCMMucMDEndjKKNi(P_2, P_0, P_1, P_3);
		}
		catch
		{
			return null;
		}
	}

	private IQFNbAfLsEWvVnPpdRQbxxyYJpW ifjmqIuvIjyxKzwJeKzGVFReqT(iGRvmBZykBTTuGmotZKeBVybDl P_0, IntPtr P_1)
	{
		if (SECqOtxIJCMtDAXMpkZHtbqiXBU == null)
		{
			return null;
		}
		int num = 0;
		IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW = default(IQFNbAfLsEWvVnPpdRQbxxyYJpW);
		while (true)
		{
			int num2;
			int num3;
			if (num < SECqOtxIJCMtDAXMpkZHtbqiXBU.Count)
			{
				num2 = 1172719459;
				num3 = num2;
			}
			else
			{
				num2 = 1172719461;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x45E64766)
				{
				case 2:
					num2 = 1172719459;
					continue;
				case 5:
					iQFNbAfLsEWvVnPpdRQbxxyYJpW = SECqOtxIJCMtDAXMpkZHtbqiXBU[num];
					num2 = 1172719462;
					continue;
				case 0:
					if (iQFNbAfLsEWvVnPpdRQbxxyYJpW.JoystickSourceType == P_0 && !(iQFNbAfLsEWvVnPpdRQbxxyYJpW.JoystickSourceHandle != P_1))
					{
						num2 = 1172719458;
						continue;
					}
					num++;
					num2 = 1172719463;
					continue;
				case 1:
					break;
				case 4:
					return iQFNbAfLsEWvVnPpdRQbxxyYJpW;
				default:
					return null;
				}
				break;
			}
		}
	}

	private unsafe IQFNbAfLsEWvVnPpdRQbxxyYJpW fvEvLnqBucOaCFNWYfeUhtVpoGvm(IntPtr P_0)
	{
		uint num;
		FTnXWfjUOcgIwWIoVmLFTvfzpAl.ZjwBSLABDoLfBCBkAfqQKMRjLKkx(P_0, 536870919u, IntPtr.Zero, out num);
		if (num == 0)
		{
			return null;
		}
		char* value = stackalloc char[(int)num];
		FTnXWfjUOcgIwWIoVmLFTvfzpAl.ZjwBSLABDoLfBCBkAfqQKMRjLKkx(P_0, 536870919u, new IntPtr(value), out num);
		int length = (int)(((int)num > 0) ? (num - 1) : 0);
		string text = new string(value, 0, length);
		if (text.Length == 0)
		{
			text = string.Empty;
			goto IL_0059;
		}
		goto IL_00e6;
		IL_0059:
		int num2 = -1630100724;
		goto IL_005e;
		IL_00e6:
		int num3 = default(int);
		if (SECqOtxIJCMtDAXMpkZHtbqiXBU != null)
		{
			text = isyWZdfASARGiqSOyowogCitxgy.mdjbOJAFekxDexxXsJTFbOIEzzlC(text);
			num3 = 0;
			num2 = -1630100728;
		}
		else
		{
			num2 = -1630100726;
		}
		goto IL_005e;
		IL_005e:
		IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW = default(IQFNbAfLsEWvVnPpdRQbxxyYJpW);
		while (true)
		{
			switch (num2 ^ -1630100728)
			{
			case 5:
				break;
			case 1:
				goto IL_0083;
			case 2:
				return null;
			case 3:
				iQFNbAfLsEWvVnPpdRQbxxyYJpW.SetJoystickSourceHandle(P_0);
				return iQFNbAfLsEWvVnPpdRQbxxyYJpW;
			case 4:
				goto IL_00e6;
			default:
				if (num3 >= SECqOtxIJCMtDAXMpkZHtbqiXBU.Count)
				{
					return null;
				}
				goto IL_0083;
			}
			break;
			IL_0083:
			iQFNbAfLsEWvVnPpdRQbxxyYJpW = SECqOtxIJCMtDAXMpkZHtbqiXBU[num3];
			if (iQFNbAfLsEWvVnPpdRQbxxyYJpW.JoystickSourceType == iGRvmBZykBTTuGmotZKeBVybDl.gEeoScnGnXjjkhsxJYSeSFZsobvI && iQFNbAfLsEWvVnPpdRQbxxyYJpW.HidDevice.DevicePathStripped.Equals(text, StringComparison.OrdinalIgnoreCase))
			{
				num2 = -1630100725;
				continue;
			}
			num3++;
			num2 = -1630100728;
		}
		goto IL_0059;
	}

	private static int BjgEbMKSLplvtRjDXAyeOHfnYmuf(IQFNbAfLsEWvVnPpdRQbxxyYJpW P_0, IQFNbAfLsEWvVnPpdRQbxxyYJpW P_1)
	{
		if (!P_0.HidDevice.HasLocationInfo)
		{
			goto IL_000d;
		}
		if (!P_1.HidDevice.HasLocationInfo)
		{
			return -1;
		}
		int hubId = P_0.HidDevice.HubId;
		int num = -1587139629;
		goto IL_0012;
		IL_000d:
		num = -1587139626;
		goto IL_0012;
		IL_0012:
		int hubId2 = default(int);
		while (true)
		{
			switch (num ^ -1587139629)
			{
			case 3:
				break;
			case 5:
				return 1;
			case 4:
				return 1;
			case 0:
				hubId2 = P_1.HidDevice.HubId;
				num = -1587139631;
				continue;
			case 2:
				if (hubId < hubId2)
				{
					return -1;
				}
				if (hubId <= hubId2)
				{
					int portId = P_0.HidDevice.PortId;
					int portId2 = P_1.HidDevice.PortId;
					if (portId >= portId2)
					{
						if (portId > portId2)
						{
							return 1;
						}
						return 0;
					}
					num = -1587139630;
				}
				else
				{
					num = -1587139625;
				}
				continue;
			default:
				return -1;
			}
			break;
		}
		goto IL_000d;
	}

	private void EhXSNhmGrFwpwLZqHqjvpVcMidO()
	{
		uuxxMFbsLpyZJqLYesSeumTNMsW uuxxMFbsLpyZJqLYesSeumTNMsW2 = new uuxxMFbsLpyZJqLYesSeumTNMsW();
		while (true)
		{
			int num = 249266090;
			while (true)
			{
				switch (num ^ 0xEDB7FAB)
				{
				case 5:
					break;
				default:
					return;
				case 1:
				{
					uuxxMFbsLpyZJqLYesSeumTNMsW2.cRVMYqVhdfyBTxGUMpvYUoxDjzC = this;
					int num2;
					if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
					{
						num = 249266095;
						num2 = num;
					}
					else
					{
						num = 249266088;
						num2 = num;
					}
					continue;
				}
				case 0:
					bbZDgsDUycFCLLPWbmUiyPPYllKZ(uuxxMFbsLpyZJqLYesSeumTNMsW2.oddDUkFZJKqneqxuKUdONQhAwwh, true);
					if (uuxxMFbsLpyZJqLYesSeumTNMsW2.EwdPnLtqRjqBkGDPmYhvkTVfwXF)
					{
						Rewired.Logger.LogError("Failed to register HID devices.", true);
						num = 249266089;
						continue;
					}
					return;
				case 4:
					return;
				case 3:
					uuxxMFbsLpyZJqLYesSeumTNMsW2.EwdPnLtqRjqBkGDPmYhvkTVfwXF = false;
					num = 249266091;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}

	private void KWErwodoMrWJAKpXktpKHtLQKMj()
	{
		ameveNoWSwHClQApwkSIgFMxIhr ameveNoWSwHClQApwkSIgFMxIhr2 = new ameveNoWSwHClQApwkSIgFMxIhr();
		if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			goto IL_000e;
		}
		goto IL_0038;
		IL_000e:
		int num = 263212662;
		goto IL_0013;
		IL_0013:
		switch (num ^ 0xFB04E75)
		{
		case 0:
			break;
		default:
			return;
		case 3:
			return;
		case 1:
			goto IL_0038;
		case 2:
			return;
		}
		goto IL_000e;
		IL_0038:
		ameveNoWSwHClQApwkSIgFMxIhr2.EwdPnLtqRjqBkGDPmYhvkTVfwXF = false;
		bbZDgsDUycFCLLPWbmUiyPPYllKZ(ameveNoWSwHClQApwkSIgFMxIhr2.DsvtRlRzncausPYaMIfUAOecJbk, true);
		if (ameveNoWSwHClQApwkSIgFMxIhr2.EwdPnLtqRjqBkGDPmYhvkTVfwXF)
		{
			Rewired.Logger.LogError("Failed to unregister HID devices.", true);
			num = 263212663;
			goto IL_0013;
		}
	}

	private void TQBasBbhkcjlGGZtiepUfxWOjzql()
	{
		if (!ReInput.isAllowedEditorWindowFocused)
		{
			goto IL_0107;
		}
		uint num = default(uint);
		IntPtr aDrIYbhIDwaerYoILbFxBtRlhXPJ = default(IntPtr);
		if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			hyXCInTsFRbuYDvtlexSlnriFjW(xnEGQEKBPLbZZJEnEIcSLPKhcAVg, out num);
			if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
			{
				bool flag = !toYcUIFhKtaPrrWIeXXbNLucKvN(ControllerType.Mouse, xnEGQEKBPLbZZJEnEIcSLPKhcAVg, num, out aDrIYbhIDwaerYoILbFxBtRlhXPJ);
				if (!WmfqkBrowMInNmlPDQHqVkSbQIK)
				{
					goto IL_00ca;
				}
				if (!flag)
				{
					goto IL_0051;
				}
			}
			goto IL_011f;
		}
		goto IL_016d;
		IL_011f:
		bool flag2 = default(bool);
		IntPtr erlSgUfDONXRFdBocCDaiuaaSrLX = default(IntPtr);
		int num2;
		if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
		{
			flag2 = !toYcUIFhKtaPrrWIeXXbNLucKvN(ControllerType.Keyboard, xnEGQEKBPLbZZJEnEIcSLPKhcAVg, num, out erlSgUfDONXRFdBocCDaiuaaSrLX);
			num2 = -776229214;
			goto IL_0056;
		}
		return;
		IL_018d:
		if (yotJUIWzRvQIeDbCbXOEoJFXkdA)
		{
			jpbKVDCyEWfEuacrQkizlyQCIxm();
			num2 = -776229203;
			goto IL_0056;
		}
		return;
		IL_016d:
		if (ZmPsgTeJvSmZcVdpLFarBeNhUvt && !WmfqkBrowMInNmlPDQHqVkSbQIK)
		{
			muasqxRUarOiYlzmIRiEsTLQbAZ();
			num2 = -776229216;
			goto IL_0056;
		}
		goto IL_0149;
		IL_00ca:
		if (aDrIYbhIDwaerYoILbFxBtRlhXPJ == IntPtr.Zero)
		{
			aDrIYbhIDwaerYoILbFxBtRlhXPJ = ADrIYbhIDwaerYoILbFxBtRlhXPJ;
			num2 = -776229209;
			goto IL_0056;
		}
		goto IL_01c8;
		IL_0051:
		num2 = -776229202;
		goto IL_0056;
		IL_0056:
		while (true)
		{
			switch (num2 ^ -776229205)
			{
			case 7:
				break;
			default:
				return;
			case 4:
				erlSgUfDONXRFdBocCDaiuaaSrLX = ErlSgUfDONXRFdBocCDaiuaaSrLX;
				num2 = -776229205;
				continue;
			case 2:
				goto IL_00ac;
			case 5:
				goto IL_00ca;
			case 0:
				OffMAowvrajhoKJIuNWUERPsFMU(erlSgUfDONXRFdBocCDaiuaaSrLX);
				num2 = -776229215;
				continue;
			case 10:
				return;
			case 1:
				goto IL_0107;
			case 3:
				goto IL_011f;
			case 11:
				goto IL_0149;
			case 13:
				goto IL_016d;
			case 8:
				goto IL_018d;
			case 9:
				goto IL_01a5;
			case 12:
				goto IL_01c8;
			case 6:
				return;
			}
			break;
			IL_01a5:
			if (yotJUIWzRvQIeDbCbXOEoJFXkdA)
			{
				int num3;
				if (flag2)
				{
					num2 = -776229203;
					num3 = num2;
				}
				else
				{
					num2 = -776229207;
					num3 = num2;
				}
				continue;
			}
			goto IL_00ac;
			IL_00ac:
			int num4;
			if (erlSgUfDONXRFdBocCDaiuaaSrLX == IntPtr.Zero)
			{
				num2 = -776229201;
				num4 = num2;
			}
			else
			{
				num2 = -776229205;
				num4 = num2;
			}
		}
		goto IL_0051;
		IL_01c8:
		hxSrTmswlRvtoAerrDaawcVHFTWk(aDrIYbhIDwaerYoILbFxBtRlhXPJ);
		num2 = -776229208;
		goto IL_0056;
		IL_0107:
		if (WmfqkBrowMInNmlPDQHqVkSbQIK)
		{
			CoAZtooNHgCRIGsaqsIeVIOvlSip();
			num2 = -776229213;
			goto IL_0056;
		}
		goto IL_018d;
		IL_0149:
		if (iogeGVrPSlgmncKTwvFLvDcZvoCk && !yotJUIWzRvQIeDbCbXOEoJFXkdA)
		{
			yDaQRNPCLgYvPsiYXvHTWuqYLaL();
		}
	}

	private void WBYIXFCxPsdOJYJFyIgjBROxuPib()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			uint num;
			hyXCInTsFRbuYDvtlexSlnriFjW(xnEGQEKBPLbZZJEnEIcSLPKhcAVg, out num);
			IntPtr intPtr;
			if (ZmPsgTeJvSmZcVdpLFarBeNhUvt && toYcUIFhKtaPrrWIeXXbNLucKvN(ControllerType.Mouse, xnEGQEKBPLbZZJEnEIcSLPKhcAVg, num, out intPtr))
			{
				if (WmfqkBrowMInNmlPDQHqVkSbQIK)
				{
					WmfqkBrowMInNmlPDQHqVkSbQIK = false;
					goto IL_0046;
				}
				goto IL_007f;
			}
			return;
		}
		goto IL_008d;
		IL_0046:
		int num2 = 1975693176;
		goto IL_004b;
		IL_004b:
		while (true)
		{
			switch (num2 ^ 0x75C2AF7B)
			{
			case 4:
				break;
			default:
				return;
			case 3:
				uGZJUPuGpjulAlhmkpLUpKdhAOX.nqaoNwwONUjhhEBlzroSZxPTdDV(false);
				num2 = 1975693178;
				continue;
			case 1:
				goto IL_007f;
			case 2:
				goto IL_008d;
			case 0:
				return;
			}
			break;
		}
		goto IL_0046;
		IL_007f:
		SZnTQLnvmxyVyMMMrDRJbbSUeae();
		return;
		IL_008d:
		if (ZmPsgTeJvSmZcVdpLFarBeNhUvt && !WmfqkBrowMInNmlPDQHqVkSbQIK)
		{
			muasqxRUarOiYlzmIRiEsTLQbAZ();
			num2 = 1975693179;
			goto IL_004b;
		}
	}

	private void CoAZtooNHgCRIGsaqsIeVIOvlSip()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			AaJocGDkzdAFRohVEWIoqxBpmWm.cMQaLhUVHuHLPtRsHkWfBmasoUo(false);
			XQIrUvIcoQDYowELOgJxEzJqbVGH();
			goto IL_0014;
		}
		goto IL_0032;
		IL_0032:
		WmfqkBrowMInNmlPDQHqVkSbQIK = false;
		int num = 462438246;
		goto IL_0019;
		IL_0014:
		num = 462438245;
		goto IL_0019;
		IL_0019:
		switch (num ^ 0x1B903F67)
		{
		case 0:
			break;
		case 2:
			goto IL_0032;
		default:
			uGZJUPuGpjulAlhmkpLUpKdhAOX.nqaoNwwONUjhhEBlzroSZxPTdDV(false);
			return;
		}
		goto IL_0014;
	}

	private void XQIrUvIcoQDYowELOgJxEzJqbVGH()
	{
		if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
		{
			if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
			{
				goto IL_0013;
			}
			goto IL_004f;
		}
		return;
		IL_00b2:
		IntPtr intPtr = default(IntPtr);
		if (intPtr != IntPtr.Zero)
		{
			bool flag = false;
			try
			{
				VOKYYXeSrTNcxqiBdXkszjcZECO.OPeBwNJuyLgSnnDIVayAdkOIhUT((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)2, bOdwDzAnhsIqiAryPanDtXoAcAs.rGSRjlwECClcefsxEVvtdpdgwU, intPtr);
			}
			catch
			{
				flag = true;
			}
			if (flag)
			{
				Rewired.Logger.LogError("Failed to unregister mouse.", true);
			}
			return;
		}
		OnQDrJgfVbcFgptrUrilTlaydHV onQDrJgfVbcFgptrUrilTlaydHV = default(OnQDrJgfVbcFgptrUrilTlaydHV);
		while (true)
		{
			int num;
			int num2;
			if (!WmfqkBrowMInNmlPDQHqVkSbQIK)
			{
				num = 475251484;
				num2 = num;
			}
			else
			{
				num = 475251485;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x1C53C31C)
				{
				case 4:
					num = 475251487;
					continue;
				default:
					return;
				case 3:
					break;
				case 1:
					onQDrJgfVbcFgptrUrilTlaydHV = new OnQDrJgfVbcFgptrUrilTlaydHV();
					onQDrJgfVbcFgptrUrilTlaydHV.EwdPnLtqRjqBkGDPmYhvkTVfwXF = false;
					num = 475251486;
					continue;
				case 2:
					bbZDgsDUycFCLLPWbmUiyPPYllKZ(onQDrJgfVbcFgptrUrilTlaydHV.BcMMfMKsZXAVCChVgiHcbHFsbVa, true);
					if (onQDrJgfVbcFgptrUrilTlaydHV.EwdPnLtqRjqBkGDPmYhvkTVfwXF)
					{
						Rewired.Logger.LogError("Failed to unregister mouse.", true);
						num = 475251484;
						continue;
					}
					return;
				case 0:
					return;
				}
				break;
			}
		}
		IL_0013:
		int num3 = 475251485;
		goto IL_0018;
		IL_0018:
		while (true)
		{
			switch (num3 ^ 0x1C53C31C)
			{
			case 0:
				break;
			case 3:
				intPtr = ADrIYbhIDwaerYoILbFxBtRlhXPJ;
				num3 = 475251482;
				continue;
			case 4:
				goto IL_004f;
			case 2:
			{
				uint num4;
				hyXCInTsFRbuYDvtlexSlnriFjW(xnEGQEKBPLbZZJEnEIcSLPKhcAVg, out num4);
				IntPtr aDrIYbhIDwaerYoILbFxBtRlhXPJ;
				if (toYcUIFhKtaPrrWIeXXbNLucKvN(ControllerType.Mouse, xnEGQEKBPLbZZJEnEIcSLPKhcAVg, num4, out aDrIYbhIDwaerYoILbFxBtRlhXPJ))
				{
					ADrIYbhIDwaerYoILbFxBtRlhXPJ = aDrIYbhIDwaerYoILbFxBtRlhXPJ;
					num3 = 475251487;
					continue;
				}
				goto case 3;
			}
			case 1:
				return;
			case 5:
				intPtr = FTnXWfjUOcgIwWIoVmLFTvfzpAl.TVCFgKdOWgSUzFpIsdssfCZqoVc();
				num3 = 475251482;
				continue;
			default:
				goto IL_00b2;
			}
			break;
		}
		goto IL_0013;
		IL_004f:
		int num5;
		if (!XLllKnmXxalIfXYFEZdgaXYuqSR)
		{
			num3 = 475251481;
			num5 = num3;
		}
		else
		{
			num3 = 475251486;
			num5 = num3;
		}
		goto IL_0018;
	}

	private void hxSrTmswlRvtoAerrDaawcVHFTWk(IntPtr P_0)
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			return;
		}
		while (true)
		{
			muasqxRUarOiYlzmIRiEsTLQbAZ();
			if (!(P_0 != IntPtr.Zero) || !(P_0 != AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle))
			{
				break;
			}
			ADrIYbhIDwaerYoILbFxBtRlhXPJ = P_0;
			AaJocGDkzdAFRohVEWIoqxBpmWm.IUJslnkktbdLVkokufwqBHSgoQQ(ADrIYbhIDwaerYoILbFxBtRlhXPJ, true);
			int num = -1625524529;
			while (true)
			{
				switch (num ^ -1625524530)
				{
				case 0:
					goto IL_0009;
				default:
					return;
				case 2:
					break;
				case 1:
					return;
				}
				break;
				IL_0009:
				num = -1625524532;
			}
		}
	}

	private void SZnTQLnvmxyVyMMMrDRJbbSUeae()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			goto IL_0008;
		}
		goto IL_0046;
		IL_0008:
		int num = -1233423324;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -1233423328)
			{
			case 3:
				break;
			default:
				return;
			case 0:
				AaJocGDkzdAFRohVEWIoqxBpmWm.IUJslnkktbdLVkokufwqBHSgoQQ(IgRJWiNDrSwmVSoAKUABDlEEwTk.value, true);
				num = -1233423327;
				continue;
			case 2:
				goto IL_0046;
			case 4:
				return;
			case 1:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0046:
		muasqxRUarOiYlzmIRiEsTLQbAZ();
		num = -1233423328;
		goto IL_000d;
	}

	private void muasqxRUarOiYlzmIRiEsTLQbAZ()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			goto IL_0008;
		}
		goto IL_0051;
		IL_0008:
		int num = -802489717;
		goto IL_000d;
		IL_000d:
		iFdoZTbFtHpwxojkbmmayLkpgOE iFdoZTbFtHpwxojkbmmayLkpgOE2 = default(iFdoZTbFtHpwxojkbmmayLkpgOE);
		while (true)
		{
			switch (num ^ -802489719)
			{
			case 5:
				break;
			default:
				return;
			case 2:
				iFdoZTbFtHpwxojkbmmayLkpgOE2 = new iFdoZTbFtHpwxojkbmmayLkpgOE();
				iFdoZTbFtHpwxojkbmmayLkpgOE2.cRVMYqVhdfyBTxGUMpvYUoxDjzC = this;
				num = -802489715;
				continue;
			case 0:
				goto IL_0051;
			case 4:
				iFdoZTbFtHpwxojkbmmayLkpgOE2.EwdPnLtqRjqBkGDPmYhvkTVfwXF = false;
				bbZDgsDUycFCLLPWbmUiyPPYllKZ(iFdoZTbFtHpwxojkbmmayLkpgOE2.XcJWKXnabQYlKCoDoBEvdSMBVMQ, true);
				num = -802489714;
				continue;
			case 7:
				if (iFdoZTbFtHpwxojkbmmayLkpgOE2.EwdPnLtqRjqBkGDPmYhvkTVfwXF)
				{
					Rewired.Logger.LogError("Failed to register mouse.", true);
					num = -802489718;
					continue;
				}
				goto IL_0051;
			case 3:
				WmfqkBrowMInNmlPDQHqVkSbQIK = false;
				uGZJUPuGpjulAlhmkpLUpKdhAOX.nqaoNwwONUjhhEBlzroSZxPTdDV(false);
				return;
			case 1:
				WmfqkBrowMInNmlPDQHqVkSbQIK = true;
				uGZJUPuGpjulAlhmkpLUpKdhAOX.nqaoNwwONUjhhEBlzroSZxPTdDV(true);
				num = -802489713;
				continue;
			case 6:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0051:
		int num2;
		if (!WmfqkBrowMInNmlPDQHqVkSbQIK)
		{
			num = -802489720;
			num2 = num;
		}
		else
		{
			num = -802489713;
			num2 = num;
		}
		goto IL_000d;
	}

	private bool hyXCInTsFRbuYDvtlexSlnriFjW(bjAxebfRiGbIVzjHaHIXEDBqdakN P_0, out uint P_1)
	{
		P_1 = 0u;
		if (P_0 == null)
		{
			return false;
		}
		uint maxDevices = (uint)P_0.maxDevices;
		P_1 = FTnXWfjUOcgIwWIoVmLFTvfzpAl.hyXCInTsFRbuYDvtlexSlnriFjW(P_0, ref maxDevices, (uint)P_0.structSize);
		return P_1 != 0;
	}

	private bool toYcUIFhKtaPrrWIeXXbNLucKvN(ControllerType P_0, bjAxebfRiGbIVzjHaHIXEDBqdakN P_1, uint P_2, out IntPtr P_3)
	{
		P_3 = IntPtr.Zero;
		int num2 = default(int);
		GtawubPQBOfYCfwssEJkXmAmxgu gtawubPQBOfYCfwssEJkXmAmxgu = default(GtawubPQBOfYCfwssEJkXmAmxgu);
		while (true)
		{
			int num = 173326877;
			while (true)
			{
				switch (num ^ 0xA54C219)
				{
				case 9:
					break;
				case 6:
					return true;
				case 3:
					goto IL_0056;
				case 4:
					if (P_1 == null)
					{
						num = 173326876;
						continue;
					}
					num2 = 0;
					num = 173326878;
					continue;
				case 5:
					return false;
				case 8:
				{
					IntPtr pointer = P_1.GetPointer(num2 * P_1.structSize);
					gtawubPQBOfYCfwssEJkXmAmxgu = GtawubPQBOfYCfwssEJkXmAmxgu.VDtEOeGzisZcsHFkztWReNtxOeY(pointer);
					switch (P_0)
					{
					case ControllerType.Keyboard:
						goto IL_0056;
					case ControllerType.Mouse:
						goto IL_00a6;
					}
					goto IL_004b;
				}
				case 1:
					if (gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc != IntPtr.Zero)
					{
						num = 173326875;
						continue;
					}
					goto IL_004b;
				case 2:
					if (gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc != AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle)
					{
						P_3 = gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc;
						num = 173326879;
						continue;
					}
					goto IL_004b;
				case 0:
					if (gtawubPQBOfYCfwssEJkXmAmxgu.MtVcQGDaERwZYukISEeCDevOehH == 2)
					{
						num = 173326872;
						continue;
					}
					goto IL_004b;
				default:
					{
						if (num2 >= P_2)
						{
							return false;
						}
						goto case 8;
					}
					IL_004b:
					num2++;
					num = 173326878;
					continue;
					IL_00a6:
					if (gtawubPQBOfYCfwssEJkXmAmxgu.ChVuJmqNQNkcCxPIAUfevOTNKRb == 1)
					{
						num = 173326873;
						continue;
					}
					goto IL_004b;
					IL_0056:
					if (gtawubPQBOfYCfwssEJkXmAmxgu.ChVuJmqNQNkcCxPIAUfevOTNKRb == 1 && gtawubPQBOfYCfwssEJkXmAmxgu.MtVcQGDaERwZYukISEeCDevOehH == 6 && gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc != IntPtr.Zero && gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc != AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle)
					{
						P_3 = gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc;
						return true;
					}
					goto IL_004b;
				}
				break;
			}
		}
	}

	private IntPtr mvPyZKXCFenVnCaMUfwKxeIZESR()
	{
		bjAxebfRiGbIVzjHaHIXEDBqdakN bjAxebfRiGbIVzjHaHIXEDBqdakN2 = new bjAxebfRiGbIVzjHaHIXEDBqdakN(GtawubPQBOfYCfwssEJkXmAmxgu.SizeInBytes, 100);
		uint maxDevices = (uint)bjAxebfRiGbIVzjHaHIXEDBqdakN2.maxDevices;
		uint num = FTnXWfjUOcgIwWIoVmLFTvfzpAl.hyXCInTsFRbuYDvtlexSlnriFjW(bjAxebfRiGbIVzjHaHIXEDBqdakN2, ref maxDevices, (uint)bjAxebfRiGbIVzjHaHIXEDBqdakN2.structSize);
		if (num == 0)
		{
			return IntPtr.Zero;
		}
		int num2 = 0;
		IntPtr pointer = default(IntPtr);
		GtawubPQBOfYCfwssEJkXmAmxgu gtawubPQBOfYCfwssEJkXmAmxgu = default(GtawubPQBOfYCfwssEJkXmAmxgu);
		while (true)
		{
			int num3 = 441860188;
			while (true)
			{
				switch (num3 ^ 0x1A56405D)
				{
				case 3:
					break;
				case 1:
					num3 = 441860187;
					continue;
				case 9:
					pointer = bjAxebfRiGbIVzjHaHIXEDBqdakN2.GetPointer(num2 * bjAxebfRiGbIVzjHaHIXEDBqdakN2.structSize);
					num3 = 441860185;
					continue;
				case 5:
					if (gtawubPQBOfYCfwssEJkXmAmxgu.ChVuJmqNQNkcCxPIAUfevOTNKRb == 1 && gtawubPQBOfYCfwssEJkXmAmxgu.MtVcQGDaERwZYukISEeCDevOehH == 2)
					{
						num3 = 441860189;
						continue;
					}
					goto IL_0121;
				case 2:
					Rewired.Logger.Log("usage = " + gtawubPQBOfYCfwssEJkXmAmxgu.MtVcQGDaERwZYukISEeCDevOehH);
					Rewired.Logger.Log("usagePage = " + gtawubPQBOfYCfwssEJkXmAmxgu.ChVuJmqNQNkcCxPIAUfevOTNKRb);
					num3 = 441860181;
					continue;
				case 0:
					if (gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc != IntPtr.Zero && gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc != AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle)
					{
						return gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc;
					}
					goto IL_0121;
				case 4:
					gtawubPQBOfYCfwssEJkXmAmxgu = GtawubPQBOfYCfwssEJkXmAmxgu.VDtEOeGzisZcsHFkztWReNtxOeY(pointer);
					num3 = 441860186;
					continue;
				case 8:
					Rewired.Logger.Log("flags = " + gtawubPQBOfYCfwssEJkXmAmxgu.pShanBKDpoPUyQsbLLJHCsXlpFm);
					Rewired.Logger.Log("target = " + gtawubPQBOfYCfwssEJkXmAmxgu.CjWLJXcsJnNkBoCEJPPcqKZhHlc);
					num3 = 441860184;
					continue;
				case 7:
					Rewired.Logger.Log("RI DEVICE " + num2);
					num3 = 441860191;
					continue;
				default:
					{
						if (num2 >= num)
						{
							return IntPtr.Zero;
						}
						goto case 9;
					}
					IL_0121:
					num2++;
					num3 = 441860187;
					continue;
				}
				break;
			}
		}
	}

	private void OffMAowvrajhoKJIuNWUERPsFMU(IntPtr P_0)
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			return;
		}
		while (true)
		{
			yDaQRNPCLgYvPsiYXvHTWuqYLaL();
			int num = -301645064;
			while (true)
			{
				switch (num ^ -301645061)
				{
				case 0:
					num = -301645058;
					continue;
				default:
					return;
				case 5:
					break;
				case 1:
				{
					int num3;
					if (P_0 != AqyFYviMZqTkWhMuRjGjFjIZHiFn.Handle)
					{
						num = -301645057;
						num3 = num;
					}
					else
					{
						num = -301645063;
						num3 = num;
					}
					continue;
				}
				case 3:
				{
					int num2;
					if (!(P_0 != IntPtr.Zero))
					{
						num = -301645063;
						num2 = num;
					}
					else
					{
						num = -301645062;
						num2 = num;
					}
					continue;
				}
				case 4:
					ErlSgUfDONXRFdBocCDaiuaaSrLX = P_0;
					num = -301645063;
					continue;
				case 2:
					return;
				}
				break;
			}
		}
	}

	private void xutqjGKFRrjQAOJnifZUIBldbhJi()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			yDaQRNPCLgYvPsiYXvHTWuqYLaL();
		}
	}

	private void yDaQRNPCLgYvPsiYXvHTWuqYLaL()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			cWaetSvzgXfSYkCFvkJRqUBzEmH cWaetSvzgXfSYkCFvkJRqUBzEmH2 = new cWaetSvzgXfSYkCFvkJRqUBzEmH();
			cWaetSvzgXfSYkCFvkJRqUBzEmH2.cRVMYqVhdfyBTxGUMpvYUoxDjzC = this;
			cWaetSvzgXfSYkCFvkJRqUBzEmH2.EwdPnLtqRjqBkGDPmYhvkTVfwXF = false;
			bbZDgsDUycFCLLPWbmUiyPPYllKZ(cWaetSvzgXfSYkCFvkJRqUBzEmH2.QKmPiHRelVfePjYzodQhkjWavNu, true);
			if (cWaetSvzgXfSYkCFvkJRqUBzEmH2.EwdPnLtqRjqBkGDPmYhvkTVfwXF)
			{
				goto IL_0037;
			}
		}
		goto IL_007e;
		IL_007e:
		int num;
		int num2;
		if (!yotJUIWzRvQIeDbCbXOEoJFXkdA)
		{
			num = -1840320197;
			num2 = num;
		}
		else
		{
			num = -1840320193;
			num2 = num;
		}
		goto IL_003c;
		IL_0037:
		num = -1840320194;
		goto IL_003c;
		IL_003c:
		while (true)
		{
			switch (num ^ -1840320193)
			{
			case 5:
				break;
			default:
				return;
			case 1:
				Rewired.Logger.LogError("Failed to register keyboard.", true);
				yotJUIWzRvQIeDbCbXOEoJFXkdA = false;
				num = -1840320196;
				continue;
			case 2:
				goto IL_007e;
			case 3:
				FQpwlxSyQDBewuXylJgyNhavnUa.nqaoNwwONUjhhEBlzroSZxPTdDV(false);
				return;
			case 4:
				yotJUIWzRvQIeDbCbXOEoJFXkdA = true;
				num = -1840320199;
				continue;
			case 6:
				FQpwlxSyQDBewuXylJgyNhavnUa.nqaoNwwONUjhhEBlzroSZxPTdDV(true);
				num = -1840320193;
				continue;
			case 0:
				return;
			}
			break;
		}
		goto IL_0037;
	}

	private void jpbKVDCyEWfEuacrQkizlyQCIxm()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			nWzixKHsgxILgDIAgVeSjhRmDGVH();
			goto IL_000e;
		}
		goto IL_002c;
		IL_002c:
		yotJUIWzRvQIeDbCbXOEoJFXkdA = false;
		int num = -682942130;
		goto IL_0013;
		IL_000e:
		num = -682942131;
		goto IL_0013;
		IL_0013:
		switch (num ^ -682942132)
		{
		case 0:
			break;
		case 1:
			goto IL_002c;
		default:
			FQpwlxSyQDBewuXylJgyNhavnUa.nqaoNwwONUjhhEBlzroSZxPTdDV(false);
			return;
		}
		goto IL_000e;
	}

	private void nWzixKHsgxILgDIAgVeSjhRmDGVH()
	{
		if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
		{
			if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
			{
				goto IL_0013;
			}
			goto IL_0065;
		}
		return;
		IL_0065:
		uint num = default(uint);
		int num2;
		if (XLllKnmXxalIfXYFEZdgaXYuqSR)
		{
			hyXCInTsFRbuYDvtlexSlnriFjW(xnEGQEKBPLbZZJEnEIcSLPKhcAVg, out num);
			num2 = -1781584374;
			goto IL_0018;
		}
		goto IL_0083;
		IL_0013:
		num2 = -1781584375;
		goto IL_0018;
		IL_0018:
		IntPtr intPtr = default(IntPtr);
		while (true)
		{
			int num3;
			switch (num2 ^ -1781584373)
			{
			case 0:
				break;
			case 1:
			{
				IntPtr erlSgUfDONXRFdBocCDaiuaaSrLX;
				if (toYcUIFhKtaPrrWIeXXbNLucKvN(ControllerType.Keyboard, xnEGQEKBPLbZZJEnEIcSLPKhcAVg, num, out erlSgUfDONXRFdBocCDaiuaaSrLX))
				{
					ErlSgUfDONXRFdBocCDaiuaaSrLX = erlSgUfDONXRFdBocCDaiuaaSrLX;
					num2 = -1781584371;
					continue;
				}
				goto case 6;
			}
			case 3:
				goto IL_0065;
			case 5:
				goto IL_0083;
			case 2:
				return;
			case 6:
				intPtr = ErlSgUfDONXRFdBocCDaiuaaSrLX;
				num2 = -1781584369;
				continue;
			case 4:
				num2 = -1781584372;
				continue;
			default:
				{
					if (intPtr != IntPtr.Zero)
					{
						bool flag = false;
						try
						{
							VOKYYXeSrTNcxqiBdXkszjcZECO.OPeBwNJuyLgSnnDIVayAdkOIhUT((jecGQgwwbSBPcbpFdlWHOdRmzoLm)1, (EhXVMuEUmFUPbhgQBdPoKkpbnup)6, bOdwDzAnhsIqiAryPanDtXoAcAs.rGSRjlwECClcefsxEVvtdpdgwU, intPtr);
						}
						catch
						{
							flag = true;
						}
						if (!flag)
						{
							return;
						}
						goto IL_00d9;
					}
					goto IL_010e;
				}
				IL_00d9:
				num3 = -1781584374;
				goto IL_00de;
				IL_010e:
				if (yotJUIWzRvQIeDbCbXOEoJFXkdA)
				{
					AUERozoKdUDccMvHkDVttkjdxC aUERozoKdUDccMvHkDVttkjdxC = new AUERozoKdUDccMvHkDVttkjdxC();
					aUERozoKdUDccMvHkDVttkjdxC.EwdPnLtqRjqBkGDPmYhvkTVfwXF = false;
					bbZDgsDUycFCLLPWbmUiyPPYllKZ(aUERozoKdUDccMvHkDVttkjdxC.RTeBiOdsImTiRskWOOlxHGaHXtLO, true);
					if (aUERozoKdUDccMvHkDVttkjdxC.EwdPnLtqRjqBkGDPmYhvkTVfwXF)
					{
						Rewired.Logger.LogError("Failed to unregister keyboard.", true);
						num3 = -1781584373;
						goto IL_00de;
					}
					return;
				}
				return;
				IL_00de:
				switch (num3 ^ -1781584373)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					Rewired.Logger.LogError("Failed to unregister keyboard.", true);
					return;
				case 2:
					goto IL_010e;
				case 0:
					return;
				}
				goto IL_00d9;
			}
			break;
		}
		goto IL_0013;
		IL_0083:
		intPtr = FTnXWfjUOcgIwWIoVmLFTvfzpAl.TVCFgKdOWgSUzFpIsdssfCZqoVc();
		num2 = -1781584372;
		goto IL_0018;
	}

	private void EqhixzfGKnSWqKsIDxelDETGNFV()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP == fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			goto IL_0008;
		}
		goto IL_0074;
		IL_0008:
		int num = 1693282634;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x64ED714B)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
				{
					CoAZtooNHgCRIGsaqsIeVIOvlSip();
					num = 1693282635;
					continue;
				}
				goto IL_0047;
			case 0:
				goto IL_0047;
			case 3:
				jpbKVDCyEWfEuacrQkizlyQCIxm();
				return;
			case 4:
				goto IL_0074;
			case 5:
				return;
			}
			break;
			IL_0047:
			KWErwodoMrWJAKpXktpKHtLQKMj();
			int num2;
			if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
			{
				num = 1693282632;
				num2 = num;
			}
			else
			{
				num = 1693282638;
				num2 = num;
			}
		}
		goto IL_0008;
		IL_0074:
		if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
		{
			CoAZtooNHgCRIGsaqsIeVIOvlSip();
			num = 1693282638;
			goto IL_000d;
		}
	}

	private void mEMEbLlrmTneioqQIxYbqaTMcOWe()
	{
		if (bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			VOKYYXeSrTNcxqiBdXkszjcZECO.RawInput += HuQXajgiPcHuBisytDaQtpSbFjQ;
			goto IL_0019;
		}
		goto IL_003b;
		IL_005b:
		int num;
		if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
		{
			VOKYYXeSrTNcxqiBdXkszjcZECO.KeyboardInput += dKuGsRGpYvPUTwUoiQfcpjjHWQx;
			num = 1714139411;
			goto IL_001e;
		}
		return;
		IL_0019:
		num = 1714139409;
		goto IL_001e;
		IL_001e:
		switch (num ^ 0x662BB112)
		{
		case 0:
			break;
		default:
			return;
		case 3:
			goto IL_003b;
		case 2:
			goto IL_005b;
		case 1:
			return;
		}
		goto IL_0019;
		IL_003b:
		if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
		{
			VOKYYXeSrTNcxqiBdXkszjcZECO.MouseInput += BZMpHQwmBqikOAvXFJlCYgYOHNzo;
			num = 1714139408;
			goto IL_001e;
		}
		goto IL_005b;
	}

	private void VZfrfLZiQeGliKhOgcDvMpqAZDue()
	{
		if (bkNLtfWXdHFQHoTBrLDLPyyblom)
		{
			goto IL_0008;
		}
		goto IL_0082;
		IL_0008:
		int num = 1752764290;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x68790F84)
			{
			case 3:
				break;
			default:
				return;
			case 6:
				VOKYYXeSrTNcxqiBdXkszjcZECO.RawInput -= HuQXajgiPcHuBisytDaQtpSbFjQ;
				num = 1752764293;
				continue;
			case 0:
				VOKYYXeSrTNcxqiBdXkszjcZECO.KeyboardInput -= dKuGsRGpYvPUTwUoiQfcpjjHWQx;
				num = 1752764288;
				continue;
			case 2:
				goto IL_0069;
			case 1:
				goto IL_0082;
			case 5:
				VOKYYXeSrTNcxqiBdXkszjcZECO.MouseInput -= BZMpHQwmBqikOAvXFJlCYgYOHNzo;
				num = 1752764294;
				continue;
			case 4:
				return;
			}
			break;
			IL_0069:
			int num2;
			if (!iogeGVrPSlgmncKTwvFLvDcZvoCk)
			{
				num = 1752764288;
				num2 = num;
			}
			else
			{
				num = 1752764292;
				num2 = num;
			}
		}
		goto IL_0008;
		IL_0082:
		int num3;
		if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
		{
			num = 1752764289;
			num3 = num;
		}
		else
		{
			num = 1752764294;
			num3 = num;
		}
		goto IL_000d;
	}

	private void jEQHjTBCSSQEWmNbLMWqAevCDGT(oJzlKgBJFvkxDtiZFeeJNOxpEWjF.hfDaZXAAPxoiaBGsKlTjnWHAqWhT P_0)
	{
		AdfeYKFWawuDgtamWAiAnTDXYYp adfeYKFWawuDgtamWAiAnTDXYYp = new AdfeYKFWawuDgtamWAiAnTDXYYp();
		while (true)
		{
			int num = 1194282258;
			while (true)
			{
				switch (num ^ 0x472F4D13)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					adfeYKFWawuDgtamWAiAnTDXYYp.nVbbHsrhsDuAPMckDpoOnVikFsZ = P_0;
					num = 1194282263;
					continue;
				case 5:
					bbZDgsDUycFCLLPWbmUiyPPYllKZ(adfeYKFWawuDgtamWAiAnTDXYYp.kwTFNjIXEShbekSwpWQPWJxaHBQA, true);
					num = 1194282257;
					continue;
				case 2:
					if (adfeYKFWawuDgtamWAiAnTDXYYp.EwdPnLtqRjqBkGDPmYhvkTVfwXF)
					{
						throw new Exception("Error creating message window.");
					}
					return;
				case 4:
					adfeYKFWawuDgtamWAiAnTDXYYp.cRVMYqVhdfyBTxGUMpvYUoxDjzC = this;
					adfeYKFWawuDgtamWAiAnTDXYYp.EwdPnLtqRjqBkGDPmYhvkTVfwXF = false;
					num = 1194282262;
					continue;
				case 3:
					return;
				}
				break;
			}
		}
	}

	private static oJzlKgBJFvkxDtiZFeeJNOxpEWjF aMmdNykEzQKcddKLeTinMSRGBwdy(oJzlKgBJFvkxDtiZFeeJNOxpEWjF.hfDaZXAAPxoiaBGsKlTjnWHAqWhT P_0)
	{
		oJzlKgBJFvkxDtiZFeeJNOxpEWjF oJzlKgBJFvkxDtiZFeeJNOxpEWjF2 = new oJzlKgBJFvkxDtiZFeeJNOxpEWjF("RewiredMesssageWindow", true, P_0);
		while (true)
		{
			int num = 227690424;
			while (true)
			{
				switch (num ^ 0xD9247B9)
				{
				case 2:
					break;
				case 1:
					if (oJzlKgBJFvkxDtiZFeeJNOxpEWjF2.Handle == IntPtr.Zero)
					{
						goto IL_003d;
					}
					return oJzlKgBJFvkxDtiZFeeJNOxpEWjF2;
				default:
					oJzlKgBJFvkxDtiZFeeJNOxpEWjF2.Dispose();
					return null;
				}
				break;
				IL_003d:
				num = 227690425;
			}
		}
	}

	private void LZHMiMVBaoPEvTfuMgXoHaxzRGb()
	{
		if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			return;
		}
		while (true)
		{
			AaJocGDkzdAFRohVEWIoqxBpmWm.OXxfSVQgpwyQzMSlFTkamYYmQrW();
			int num;
			int num2;
			if (!bkNLtfWXdHFQHoTBrLDLPyyblom)
			{
				num = 1000478624;
				num2 = num;
			}
			else
			{
				num = 1000478626;
				num2 = num;
			}
			while (true)
			{
				switch (num ^ 0x3BA217A9)
				{
				case 10:
					num = 1000478625;
					continue;
				default:
					return;
				case 9:
				{
					int num5;
					if (!ZmPsgTeJvSmZcVdpLFarBeNhUvt)
					{
						num = 1000478638;
						num5 = num;
					}
					else
					{
						num = 1000478637;
						num5 = num;
					}
					continue;
				}
				case 5:
					GFxfkOxKNHgnwgzDzQOwZakwvXV = AaJocGDkzdAFRohVEWIoqxBpmWm.lMCZhdTqjocsqSftNDyzeUBkxvZk();
					num = 1000478639;
					continue;
				case 3:
					if (XLllKnmXxalIfXYFEZdgaXYuqSR)
					{
						tBMuklPmLuskwRZbpculYhjWHNA = 1;
						num = 1000478636;
						continue;
					}
					goto case 0;
				case 7:
				{
					int num4;
					if (!iogeGVrPSlgmncKTwvFLvDcZvoCk)
					{
						num = 1000478636;
						num4 = num;
					}
					else
					{
						num = 1000478637;
						num4 = num;
					}
					continue;
				}
				case 11:
					EhXSNhmGrFwpwLZqHqjvpVcMidO();
					num = 1000478624;
					continue;
				case 8:
					break;
				case 4:
					xnEGQEKBPLbZZJEnEIcSLPKhcAVg = new bjAxebfRiGbIVzjHaHIXEDBqdakN(GtawubPQBOfYCfwssEJkXmAmxgu.SizeInBytes, 100);
					num = 1000478634;
					continue;
				case 0:
				{
					int num3;
					if (!ZmPsgTeJvSmZcVdpLFarBeNhUvt)
					{
						num = 1000478635;
						num3 = num;
					}
					else
					{
						num = 1000478632;
						num3 = num;
					}
					continue;
				}
				case 2:
					if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
					{
						xutqjGKFRrjQAOJnifZUIBldbhJi();
						num = 1000478636;
						continue;
					}
					goto case 5;
				case 1:
					SZnTQLnvmxyVyMMMrDRJbbSUeae();
					num = 1000478635;
					continue;
				case 6:
					return;
				}
				break;
			}
		}
	}

	private void sbFnlIobbXszKiPljXeTfLsmAsr()
	{
		if (!XLllKnmXxalIfXYFEZdgaXYuqSR)
		{
			goto IL_000b;
		}
		goto IL_00f6;
		IL_000b:
		int num = 1575293300;
		goto IL_0010;
		IL_0010:
		uint num2 = default(uint);
		while (true)
		{
			switch (num ^ 0x5DE5117C)
			{
			case 7:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
				{
					IntPtr intPtr2;
					toYcUIFhKtaPrrWIeXXbNLucKvN(ControllerType.Keyboard, xnEGQEKBPLbZZJEnEIcSLPKhcAVg, num2, out intPtr2);
					OffMAowvrajhoKJIuNWUERPsFMU(intPtr2);
					num = 1575293306;
					continue;
				}
				goto case 6;
			case 5:
				hyXCInTsFRbuYDvtlexSlnriFjW(xnEGQEKBPLbZZJEnEIcSLPKhcAVg, out num2);
				if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
				{
					IntPtr intPtr;
					toYcUIFhKtaPrrWIeXXbNLucKvN(ControllerType.Mouse, xnEGQEKBPLbZZJEnEIcSLPKhcAVg, num2, out intPtr);
					hxSrTmswlRvtoAerrDaawcVHFTWk(intPtr);
					num = 1575293310;
					continue;
				}
				goto case 2;
			case 4:
				tBMuklPmLuskwRZbpculYhjWHNA--;
				num = 1575293309;
				continue;
			case 6:
				tBMuklPmLuskwRZbpculYhjWHNA = -1;
				num = 1575293308;
				continue;
			case 3:
				goto IL_00d9;
			case 9:
				goto IL_00f6;
			case 8:
				return;
			case 0:
				return;
			}
			break;
		}
		goto IL_000b;
		IL_00f6:
		if (sGrrOqPxwhXpccaMEbccHCxmoJP != fwSDbmxzJHEgpqiBxmtyhNGAiOQ.JMasRUpLLsVANDgYWPOZcBqFhpS)
		{
			return;
		}
		goto IL_00d9;
		IL_00d9:
		int num3;
		if (tBMuklPmLuskwRZbpculYhjWHNA > 0)
		{
			num = 1575293304;
			num3 = num;
		}
		else
		{
			num = 1575293305;
			num3 = num;
		}
		goto IL_0010;
	}

	private void HMtfCJwGeNeFjSxUAtHKrUpYJAc(bool P_0)
	{
		if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
		{
			goto IL_0008;
		}
		goto IL_0037;
		IL_0008:
		int num = -612659312;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -612659309)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				SZnTQLnvmxyVyMMMrDRJbbSUeae();
				num = -612659311;
				continue;
			case 2:
				goto IL_0037;
			case 1:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0037:
		if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
		{
			yDaQRNPCLgYvPsiYXvHTWuqYLaL();
			num = -612659310;
			goto IL_000d;
		}
	}

	private void EVuZtFUcjyVsQSJtBSZjyUvpdLY(IntPtr P_0)
	{
		if (!XLllKnmXxalIfXYFEZdgaXYuqSR)
		{
			if (ZmPsgTeJvSmZcVdpLFarBeNhUvt)
			{
				SZnTQLnvmxyVyMMMrDRJbbSUeae();
				goto IL_0016;
			}
			goto IL_0034;
		}
		return;
		IL_001b:
		int num;
		switch (num ^ -946992368)
		{
		case 0:
			break;
		default:
			return;
		case 1:
			goto IL_0034;
		case 2:
			return;
		}
		goto IL_0016;
		IL_0034:
		if (iogeGVrPSlgmncKTwvFLvDcZvoCk)
		{
			xutqjGKFRrjQAOJnifZUIBldbhJi();
			num = -946992366;
			goto IL_001b;
		}
		return;
		IL_0016:
		num = -946992367;
		goto IL_001b;
	}

	private IntPtr PcUtzkkDpdrFQNeiojMbsnsRxgX(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			return IntPtr.Zero;
		}
		if (GFxfkOxKNHgnwgzDzQOwZakwvXV != null)
		{
			while (true)
			{
				int num = 1058839496;
				while (true)
				{
					switch (num ^ 0x3F1C9BC9)
					{
					case 0:
						break;
					case 1:
						GFxfkOxKNHgnwgzDzQOwZakwvXV(P_0, P_1, P_2, P_3);
						num = 1058839499;
						continue;
					default:
						goto end_IL_0016;
					}
					break;
				}
				continue;
				end_IL_0016:
				break;
			}
		}
		return IntPtr.Zero;
	}

	private void bbZDgsDUycFCLLPWbmUiyPPYllKZ(Action P_0, bool P_1)
	{
		if (P_0 != null)
		{
			P_0();
		}
	}

	private void HuQXajgiPcHuBisytDaQtpSbFjQ(uWaovIOcoCFNjfHzcSVlEieiyJx P_0)
	{
		try
		{
			IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW = ifjmqIuvIjyxKzwJeKzGVFReqT(iGRvmBZykBTTuGmotZKeBVybDl.gEeoScnGnXjjkhsxJYSeSFZsobvI, P_0.JAPGXbnGLEVcKvOepfYKLDmQrgU);
			if (iQFNbAfLsEWvVnPpdRQbxxyYJpW != null)
			{
				iQFNbAfLsEWvVnPpdRQbxxyYJpW.UpdateValue(P_0.RawDataPtr, P_0.RawDataBytes, P_0.IckFjyUuHaWCpzSJYswmjKnqtfg, P_0.rrotJhvUrwqPbiAeUWvpTADfTUB, 0f);
			}
		}
		catch
		{
		}
	}

	private void iSUmcfbxlAoAriNKOHsVZeFoqVX(GLzyIRewfmBGJsslOWFzMMCgpdy P_0)
	{
		try
		{
			IQFNbAfLsEWvVnPpdRQbxxyYJpW iQFNbAfLsEWvVnPpdRQbxxyYJpW = ifjmqIuvIjyxKzwJeKzGVFReqT(iGRvmBZykBTTuGmotZKeBVybDl.gEeoScnGnXjjkhsxJYSeSFZsobvI, P_0.UeiaKwgLiLeqifNVDDUvMWoyekkM);
			if (iQFNbAfLsEWvVnPpdRQbxxyYJpW != null)
			{
				iQFNbAfLsEWvVnPpdRQbxxyYJpW.UpdateValue(P_0.rawDataPtr, P_0.mcvNcYMLxBkSfamdHQEyAGayQAk, P_0.LlGSLitmKucTsjicFBqvdrBawTmD, P_0.IyvcKixWElCzgzODoKSDpEliHZP, P_0.gAbgMDARYaozsswqDxujSecdOGy);
			}
		}
		catch
		{
		}
	}

	private void BZMpHQwmBqikOAvXFJlCYgYOHNzo(UVUcwbjoCUbEuhneeFIgITKaUkT P_0)
	{
		grQICiGqElIDIeHEzCWABLXtjvf.RtgGaDkSVkhbZAgNmFrINPvRAMMC(ref P_0);
		jeEhWScmKOqcOAXhEPIRNWDfPGj(grQICiGqElIDIeHEzCWABLXtjvf);
	}

	private void jeEhWScmKOqcOAXhEPIRNWDfPGj(QhgacJjSXHFhQASuQzRIauYnlslQ P_0)
	{
		try
		{
			uGZJUPuGpjulAlhmkpLUpKdhAOX.gWtxRrjxTpaISzgdnjvOGVfdZlUV(P_0);
		}
		catch (Exception)
		{
		}
	}

	private void dKuGsRGpYvPUTwUoiQfcpjjHWQx(zMsttlFczJzlFOjdoboKAHjcWCm P_0)
	{
		fvfJzXdOMattcRPmXDHHKoADYtrf.RtgGaDkSVkhbZAgNmFrINPvRAMMC(ref P_0);
		gtTDjuNcoXCQkojlDxgutTLxuRr(fvfJzXdOMattcRPmXDHHKoADYtrf);
	}

	private void gtTDjuNcoXCQkojlDxgutTLxuRr(znchxtogvsCwUJelEblQFvJYOmG P_0)
	{
		try
		{
			FQpwlxSyQDBewuXylJgyNhavnUa.gWtxRrjxTpaISzgdnjvOGVfdZlUV(P_0);
		}
		catch
		{
		}
	}

	public void Dispose()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
		GC.SuppressFinalize(this);
	}

	~ToVVOkLlyfGfCymNVHdVmAohoaz()
	{
		JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
	}

	protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
	{
		if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
		{
			return;
		}
		int num3 = default(int);
		while (true)
		{
			VZfrfLZiQeGliKhOgcDvMpqAZDue();
			ReInput.ApplicationIsFullScreenChangedEvent -= HMtfCJwGeNeFjSxUAtHKrUpYJAc;
			int num = -1298748869;
			while (true)
			{
				switch (num ^ -1298748871)
				{
				case 0:
					goto IL_0009;
				case 1:
					break;
				default:
					lock (yDULJbaHRMBmgbLqIPaaJjpltAxL)
					{
						if (P_0 && SECqOtxIJCMtDAXMpkZHtbqiXBU != null)
						{
							goto IL_005d;
						}
						goto IL_009a;
						IL_0131:
						AaJocGDkzdAFRohVEWIoqxBpmWm.JGfOaxGMMubjxaprhTWpWgtvAPZ();
						int num2 = -1298748868;
						goto IL_0062;
						IL_005d:
						num2 = -1298748880;
						goto IL_0062;
						IL_0062:
						while (true)
						{
							switch (num2 ^ -1298748871)
							{
							case 0:
								break;
							default:
								goto end_IL_0052;
							case 7:
								goto IL_009a;
							case 8:
								goto IL_00c4;
							case 6:
								if (SECqOtxIJCMtDAXMpkZHtbqiXBU[num3] != null)
								{
									SECqOtxIJCMtDAXMpkZHtbqiXBU[num3].Unacquire();
									SECqOtxIJCMtDAXMpkZHtbqiXBU[num3].Dispose();
									num2 = -1298748867;
									continue;
								}
								goto case 4;
							case 4:
								num3++;
								num2 = -1298748872;
								continue;
							case 3:
								goto IL_0131;
							case 2:
								goto IL_0140;
							case 1:
								goto IL_016b;
							case 9:
								num3 = 0;
								num2 = -1298748872;
								continue;
							case 5:
								goto end_IL_0052;
							}
							break;
							IL_016b:
							int num4;
							if (num3 >= SECqOtxIJCMtDAXMpkZHtbqiXBU.Count)
							{
								num2 = -1298748866;
								num4 = num2;
							}
							else
							{
								num2 = -1298748865;
								num4 = num2;
							}
						}
						goto IL_005d;
						IL_00c4:
						if (iogeGVrPSlgmncKTwvFLvDcZvoCk && FQpwlxSyQDBewuXylJgyNhavnUa != null)
						{
							FQpwlxSyQDBewuXylJgyNhavnUa.Dispose();
							num2 = -1298748870;
							goto IL_0062;
						}
						goto IL_0131;
						IL_009a:
						EqhixzfGKnSWqKsIDxelDETGNFV();
						if (AqyFYviMZqTkWhMuRjGjFjIZHiFn != null)
						{
							AqyFYviMZqTkWhMuRjGjFjIZHiFn.Dispose();
							AqyFYviMZqTkWhMuRjGjFjIZHiFn = null;
							num2 = -1298748869;
							goto IL_0062;
						}
						goto IL_0140;
						IL_0140:
						if (ZmPsgTeJvSmZcVdpLFarBeNhUvt && uGZJUPuGpjulAlhmkpLUpKdhAOX != null)
						{
							uGZJUPuGpjulAlhmkpLUpKdhAOX.Dispose();
							num2 = -1298748879;
							goto IL_0062;
						}
						goto IL_00c4;
						end_IL_0052:;
					}
					nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
					return;
				}
				break;
				IL_0009:
				num = -1298748872;
			}
		}
	}

	[CompilerGenerated]
	private static void TbhLuQGjgRIZpXneUYVwYpkhvzJ(IQFNbAfLsEWvVnPpdRQbxxyYJpW P_0)
	{
		P_0.Dispose();
	}
}
