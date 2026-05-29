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

internal class DyxPIAguqliRStlMaxHqlaZTglf : IDisposable, IInputSource
{
	private class axxcxfwiAhKGHMtboHrNGJrQfYoB
	{
		public ushort DHoHwlVAbcMQAlRasQeiXZFPkPJ;

		public ushort EqdtfgTALHwKuieEEBOUWzyDHNC;

		public axxcxfwiAhKGHMtboHrNGJrQfYoB(ushort usagePage, ushort usage)
		{
			DHoHwlVAbcMQAlRasQeiXZFPkPJ = usagePage;
			EqdtfgTALHwKuieEEBOUWzyDHNC = usage;
		}
	}

	private struct jwHOncCOjHkdhQeuQmvUMQnzhjy
	{
		public ushort WmtUGOFEZXlJDeownvmsmDErLwz;

		public ushort CZzFxmqlmJjjVIdYppEAiCkwSwBD;

		public int rgNOkrpmhiGBrLTBaaLZBGFVYBc;

		public IntPtr WiqjKtJlNziKSgjomSJyKjDHuTe;

		public static int SizeInBytes
		{
			get
			{
				return 8 + IntPtr.Size;
			}
		}

		public static jwHOncCOjHkdhQeuQmvUMQnzhjy PvNFXGvQnaaWthCSEipVjxZGLEKc(IntPtr P_0)
		{
			jwHOncCOjHkdhQeuQmvUMQnzhjy result = default(jwHOncCOjHkdhQeuQmvUMQnzhjy);
			int num = 0;
			while (true)
			{
				int num2 = 107250682;
				while (true)
				{
					switch (num2 ^ 0x66483FB)
					{
					case 2:
						break;
					case 1:
						goto IL_0028;
					default:
						result.CZzFxmqlmJjjVIdYppEAiCkwSwBD = (ushort)Marshal.ReadInt16(P_0, num);
						num += 2;
						result.rgNOkrpmhiGBrLTBaaLZBGFVYBc = Marshal.ReadInt32(P_0, num);
						num += 4;
						result.WiqjKtJlNziKSgjomSJyKjDHuTe = Marshal.ReadIntPtr(P_0, num);
						return result;
					}
					break;
					IL_0028:
					result.WmtUGOFEZXlJDeownvmsmDErLwz = (ushort)Marshal.ReadInt16(P_0);
					num += 2;
					num2 = 107250683;
				}
			}
		}
	}

	private class ngaXGIsZAMbpNYRErIyxdcfTICS : NativeBuffer
	{
		private int RLxsZCLWDuSvMPCWBzrOaaSsYg;

		private int iXkuGfDCSKYMDxImkFRciNDDpkaD;

		public int maxDevices
		{
			get
			{
				return RLxsZCLWDuSvMPCWBzrOaaSsYg;
			}
		}

		public int structSize
		{
			get
			{
				return iXkuGfDCSKYMDxImkFRciNDDpkaD;
			}
		}

		public ngaXGIsZAMbpNYRErIyxdcfTICS(int structSize, int maxDevices)
			: base(structSize * maxDevices)
		{
			iXkuGfDCSKYMDxImkFRciNDDpkaD = structSize;
			RLxsZCLWDuSvMPCWBzrOaaSsYg = maxDevices;
		}
	}

	private sealed class aTrCJwWIGVmMqShuJeadqdxvqWA
	{
		public IList<eCKdLvtfldigSEOJNAhOjiRdUQDt.CmkCdjhTVEAFSgsBBqCkKyeFEian> ZdkImXCjZLQxeepndIgXxojjIMf;
	}

	private sealed class OfnCYzfWcJGmSbGsBiIYTfCRKgCQ
	{
		public aTrCJwWIGVmMqShuJeadqdxvqWA AwcECvjpNwTdNXMwiQWaEGQQzNu;

		public int IZgeEsAcywOFlSvSuaDMZooDRAeH;

		public bool HbXBqtIasfOCJjCJJubKttVEibYT(string P_0)
		{
			return P_0.Equals(AwcECvjpNwTdNXMwiQWaEGQQzNu.ZdkImXCjZLQxeepndIgXxojjIMf[IZgeEsAcywOFlSvSuaDMZooDRAeH].ITHKTCHmKdRkkVyheKJDWPIFBBWE, StringComparison.OrdinalIgnoreCase);
		}
	}

	private sealed class wwISNOGfSnERhIgYYOqiDRqxybdP
	{
		public KchbyaIpiOUwIuFRWQOhqCekrdI KfBMsKmKSFAAFWYvFXjacifOooO;

		public bool ylcmAZqcimcRSKwVQRuQMREyPCEd(KchbyaIpiOUwIuFRWQOhqCekrdI P_0)
		{
			return P_0.InstanceGuid == KfBMsKmKSFAAFWYvFXjacifOooO.InstanceGuid;
		}
	}

	private sealed class znkFUkAEkkohtdMtANnQwSpjwsZy
	{
		public bool SWFAUtHYklQthaDjRqSllRDLXqH;

		public DyxPIAguqliRStlMaxHqlaZTglf iidCZOgulnzjWMumhFnWTPbnqlMV;

		public void wpTNtAwNZMybdpNAlzIYOwzggph()
		{
			try
			{
				VirXhLPnLrtadNhOAiqyporSIM.MyYGSzGiuRyxsicfgFoCuyusEhZU((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)4, vXVSNJdznuphRZYiycRXyyfwiqm.zTozNJMwCSwBpjmMUpCdiPrRSkY, iidCZOgulnzjWMumhFnWTPbnqlMV.KJUTrRbTQqneRBOioInbwQPtaIX.Handle);
				VirXhLPnLrtadNhOAiqyporSIM.MyYGSzGiuRyxsicfgFoCuyusEhZU((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)5, vXVSNJdznuphRZYiycRXyyfwiqm.zTozNJMwCSwBpjmMUpCdiPrRSkY, iidCZOgulnzjWMumhFnWTPbnqlMV.KJUTrRbTQqneRBOioInbwQPtaIX.Handle);
				VirXhLPnLrtadNhOAiqyporSIM.MyYGSzGiuRyxsicfgFoCuyusEhZU((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)8, vXVSNJdznuphRZYiycRXyyfwiqm.zTozNJMwCSwBpjmMUpCdiPrRSkY, iidCZOgulnzjWMumhFnWTPbnqlMV.KJUTrRbTQqneRBOioInbwQPtaIX.Handle);
				VirXhLPnLrtadNhOAiqyporSIM.MyYGSzGiuRyxsicfgFoCuyusEhZU((rkWDFIFhfEYYfewtCEiNcoZAcHX)12, (MfbJCQtTuFJHamEmynNyXrrBdib)1, vXVSNJdznuphRZYiycRXyyfwiqm.zTozNJMwCSwBpjmMUpCdiPrRSkY, iidCZOgulnzjWMumhFnWTPbnqlMV.KJUTrRbTQqneRBOioInbwQPtaIX.Handle);
			}
			catch
			{
				SWFAUtHYklQthaDjRqSllRDLXqH = true;
			}
		}
	}

	private sealed class irvcWpZXiTIEtdwCkRPhjxekASK
	{
		public bool SWFAUtHYklQthaDjRqSllRDLXqH;

		public void VZTMbPsxwonrvSCpdAMxPoeWFfc()
		{
			try
			{
				VirXhLPnLrtadNhOAiqyporSIM.fwmPPhYOFhoajBDSKGjVhfBVOlWK((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)4);
				VirXhLPnLrtadNhOAiqyporSIM.fwmPPhYOFhoajBDSKGjVhfBVOlWK((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)5);
				while (true)
				{
					int num = 393444731;
					while (true)
					{
						switch (num ^ 0x17737D7A)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							VirXhLPnLrtadNhOAiqyporSIM.fwmPPhYOFhoajBDSKGjVhfBVOlWK((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)8);
							num = 393444729;
							continue;
						case 3:
							VirXhLPnLrtadNhOAiqyporSIM.fwmPPhYOFhoajBDSKGjVhfBVOlWK((rkWDFIFhfEYYfewtCEiNcoZAcHX)12, (MfbJCQtTuFJHamEmynNyXrrBdib)1);
							num = 393444730;
							continue;
						case 0:
							return;
						}
						break;
					}
				}
			}
			catch
			{
				SWFAUtHYklQthaDjRqSllRDLXqH = true;
			}
		}
	}

	private sealed class vUUMKZtIgRrMCrRmCkytOxoQtYu
	{
		public bool SWFAUtHYklQthaDjRqSllRDLXqH;

		public void NreKXalMJBRVBZRrPKuowwTClRm()
		{
			try
			{
				VirXhLPnLrtadNhOAiqyporSIM.fwmPPhYOFhoajBDSKGjVhfBVOlWK((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)2);
			}
			catch
			{
				while (true)
				{
					int num = -1685672168;
					while (true)
					{
						switch (num ^ -1685672166)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0028;
						case 1:
							return;
						}
						break;
						IL_0028:
						SWFAUtHYklQthaDjRqSllRDLXqH = true;
						num = -1685672165;
					}
				}
			}
		}
	}

	private sealed class bFoKTBVyQFNLXnVXMumVNuLVvQe
	{
		public bool SWFAUtHYklQthaDjRqSllRDLXqH;

		public DyxPIAguqliRStlMaxHqlaZTglf iidCZOgulnzjWMumhFnWTPbnqlMV;

		public void TvhVFeIJgQNueTdENGPvaISxcZIG()
		{
			try
			{
				VirXhLPnLrtadNhOAiqyporSIM.MyYGSzGiuRyxsicfgFoCuyusEhZU((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)2, vXVSNJdznuphRZYiycRXyyfwiqm.zTozNJMwCSwBpjmMUpCdiPrRSkY, iidCZOgulnzjWMumhFnWTPbnqlMV.KJUTrRbTQqneRBOioInbwQPtaIX.Handle);
			}
			catch
			{
				SWFAUtHYklQthaDjRqSllRDLXqH = true;
			}
		}
	}

	private sealed class lFMPOQAqYwkNkIehJmGCLFAenXr
	{
		public bool SWFAUtHYklQthaDjRqSllRDLXqH;

		public DyxPIAguqliRStlMaxHqlaZTglf iidCZOgulnzjWMumhFnWTPbnqlMV;

		public void YOOqAbkltVAhEhqRTmSrdnACOXyF()
		{
			try
			{
				VirXhLPnLrtadNhOAiqyporSIM.MyYGSzGiuRyxsicfgFoCuyusEhZU((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)6, vXVSNJdznuphRZYiycRXyyfwiqm.zTozNJMwCSwBpjmMUpCdiPrRSkY, iidCZOgulnzjWMumhFnWTPbnqlMV.KJUTrRbTQqneRBOioInbwQPtaIX.Handle);
			}
			catch
			{
				while (true)
				{
					int num = -1099943691;
					while (true)
					{
						switch (num ^ -1099943689)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_003d;
						case 1:
							return;
						}
						break;
						IL_003d:
						SWFAUtHYklQthaDjRqSllRDLXqH = true;
						num = -1099943690;
					}
				}
			}
		}
	}

	private sealed class yjyRQIAAcHtekMhWABNssXHLbcXk
	{
		public bool SWFAUtHYklQthaDjRqSllRDLXqH;

		public void LzSzQyXaGupHItAkvjkfXCipJjH()
		{
			try
			{
				VirXhLPnLrtadNhOAiqyporSIM.fwmPPhYOFhoajBDSKGjVhfBVOlWK((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)6);
			}
			catch
			{
				SWFAUtHYklQthaDjRqSllRDLXqH = true;
			}
		}
	}

	private sealed class juPLKwiydNthFgwHKtmeOsZdDBB
	{
		public bool SWFAUtHYklQthaDjRqSllRDLXqH;

		public DyxPIAguqliRStlMaxHqlaZTglf iidCZOgulnzjWMumhFnWTPbnqlMV;

		public ypRryIywRrvtKyGzmsiTAVfBgMf.yRxsQBSSzqeDQDwfDLSsblxFeaei lwDuaACtnTDlAaZIkstOGaLKKJTi;

		public void eDpSQJbSeUcChVHIMSWBYAhQRiQ()
		{
			try
			{
				iidCZOgulnzjWMumhFnWTPbnqlMV.KJUTrRbTQqneRBOioInbwQPtaIX = yGMONCxAxAlxeTcfaiHrNqPbusn(lwDuaACtnTDlAaZIkstOGaLKKJTi);
				if (iidCZOgulnzjWMumhFnWTPbnqlMV.KJUTrRbTQqneRBOioInbwQPtaIX == null)
				{
					throw new Exception();
				}
			}
			catch
			{
				SWFAUtHYklQthaDjRqSllRDLXqH = true;
			}
		}
	}

	private const float yJBGAYieXcsRwuHvEFwTGpwZzVFS = 0.25f;

	private const int eAtnQLuiVwEBeEfVQbRNxGOnNeW = 100;

	private List<KchbyaIpiOUwIuFRWQOhqCekrdI> AvwfdLjWSYyRUfRbGOqVqadERNGK;

	private List<KchbyaIpiOUwIuFRWQOhqCekrdI> nJXMAKyHzuLPhLbOdddImvMYzNh;

	private ReadOnlyCollection<KchbyaIpiOUwIuFRWQOhqCekrdI> lWRYaJqtgGnnPbRvxaOVqiJCvAN;

	private RPMEArDcusoTOTamCEbKzwFcLDSI eMbIWzFttpTxHgsIHfnMqobNGATC;

	private hKTkpUPnMJRQrUCFJINGfAbSxtx HyJfhRFtuFqKrFdhDGBoOIpRRvkc;

	private ConfigVars UKtATHlOcpbLyohLTFgOWGklugI;

	private UpdateLoopSetting EAqhhnqHsgswgIHwTkugMMEPdAp;

	private readonly bool FgHZkoRGNeioFjCybKVqAjFHQgHv;

	private readonly bool jknBiNnVvBEJUrrzYJXBYRgRbau;

	private readonly bool RixhOtXDbSIOhYkJycehgIXDBbxD;

	private readonly bool iyGFwvImCbxxsRCfTTBNAxyjqRK;

	private readonly bool pGteRdEOtsppIWvKatYVMbCeEFX;

	private bool YHNnglSbiAkeQnlrirNsMoGVHKKC;

	private bool ejBBccpNHnJqlARgWISQviVttrU;

	private bool slwjymQzpUCqMhDMbTNJNEcsbph;

	private int ZVTiOQKemkBbFhYicwQiTVBfEZbK;

	private readonly object wqkcGFNfJIdbpgKOpqiqCmzTzGvA = new object();

	private readonly xVicVIItBLtQkfldKrNymeScMdI ihXRVCsIkdJEbzKinpeeMxhGLFZ;

	private int hMmfqHsFLqCphWyBKmofLIlkGHEC = -1;

	private ngaXGIsZAMbpNYRErIyxdcfTICS bAeUJildHBuOCKoLdjiIBEKHyMJH;

	private IntPtr YNNTIZOmHinEmVhkyBZxayFLrNX;

	private IntPtr IaXhnaMGCLQqOuWQHTvcfoKYvgL;

	private ValueWatcher<IntPtr> OGnBNGilhCjKIPhgnSWLQRSkDNe;

	private ValueWatcher[] aFneOXQWvPgGjcqCxDITYnwBaaV;

	private ypRryIywRrvtKyGzmsiTAVfBgMf KJUTrRbTQqneRBOioInbwQPtaIX;

	private BVXGzlTZEWpONAgpfKbBoJpvhbZ YhRjkeWsVRIxhnXdWIYqEbsIblLK;

	private static WjFybxMnkkesCfQZxtpFlEatAdf.rcpdAtthbgpUiTgtMOHNxoLoDjp yyMMqHvbhEwxCEbBQhujCMSMxmtH;

	private WjFybxMnkkesCfQZxtpFlEatAdf.FRMKwblNelYkUXtMZFDktdIAaAc UtRCOrctKOJcRmEkNISALOXfETl;

	private NativeBuffer dKPdDijfFqFYeTcSEqQOqomtNbtj;

	private static Rewired.Internal.GUIText FpgGUdBIMHJtJokNpTtswJOCfhAE;

	private static axxcxfwiAhKGHMtboHrNGJrQfYoB[] lnsZCaqDgeSluOroxStGchbmhSo;

	private readonly AnUlkbSKZTgtTTjCtVOCzQQXaiz ovctNKnlwffZNCdsOVAOWOHDZtnm = new AnUlkbSKZTgtTTjCtVOCzQQXaiz();

	private readonly bzEIwBRfuczFFAoUzMzCAMnmSUI tRNsaxGpUiytdGkUuLLXjMAtnUb = new bzEIwBRfuczFFAoUzMzCAMnmSUI();

	private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

	[CompilerGenerated]
	private static Action<KchbyaIpiOUwIuFRWQOhqCekrdI> GqwaMGqbPQUlQWZBIRHVzYJMuLI;

	public static Rewired.Internal.GUIText guiText
	{
		get
		{
			if (FpgGUdBIMHJtJokNpTtswJOCfhAE != null)
			{
				return FpgGUdBIMHJtJokNpTtswJOCfhAE;
			}
			GameObject gameObject = GameObject.Find("DebugScreenLog");
			if (gameObject != null)
			{
				goto IL_0027;
			}
			goto IL_006a;
			IL_006a:
			gameObject = new GameObject("DebugScreenLog");
			gameObject.transform.position = Vector3.zero;
			FpgGUdBIMHJtJokNpTtswJOCfhAE = gameObject.AddComponent<Rewired.Internal.GUIText>();
			int num = -2035414163;
			goto IL_002c;
			IL_0027:
			num = -2035414168;
			goto IL_002c;
			IL_002c:
			while (true)
			{
				switch (num ^ -2035414167)
				{
				case 0:
					break;
				case 4:
					FpgGUdBIMHJtJokNpTtswJOCfhAE.anchor = TextAnchor.LowerLeft;
					FpgGUdBIMHJtJokNpTtswJOCfhAE.alignment = TextAlignment.Left;
					num = -2035414166;
					continue;
				case 2:
					goto IL_006a;
				case 1:
					FpgGUdBIMHJtJokNpTtswJOCfhAE = gameObject.GetComponent<Rewired.Internal.GUIText>();
					num = -2035414166;
					continue;
				default:
					return FpgGUdBIMHJtJokNpTtswJOCfhAE;
				}
				break;
			}
			goto IL_0027;
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

	public DyxPIAguqliRStlMaxHqlaZTglf(ConfigVars configVars, bool handleJoysticks, bool useCustomDrivers, RPMEArDcusoTOTamCEbKzwFcLDSI unifiedMouse, hKTkpUPnMJRQrUCFJINGfAbSxtx unifiedKeyboard)
	{
		try
		{
			UKtATHlOcpbLyohLTFgOWGklugI = configVars;
			EAqhhnqHsgswgIHwTkugMMEPdAp = configVars.updateLoop;
			OGnBNGilhCjKIPhgnSWLQRSkDNe = new ValueWatcher<IntPtr>(JBXHRSYUePslTBUiRmNOkdLSed.BwcrcaWbYgaFuQmgRzzaiBJGcym(), JBXHRSYUePslTBUiRmNOkdLSed.BwcrcaWbYgaFuQmgRzzaiBJGcym, true);
			OGnBNGilhCjKIPhgnSWLQRSkDNe.ChangedEvent += SsSohntczkdFPRaVmVdpvXhJTUW;
			aFneOXQWvPgGjcqCxDITYnwBaaV = new ValueWatcher[1] { OGnBNGilhCjKIPhgnSWLQRSkDNe };
			jknBiNnVvBEJUrrzYJXBYRgRbau = handleJoysticks;
			pGteRdEOtsppIWvKatYVMbCeEFX = useCustomDrivers;
			eMbIWzFttpTxHgsIHfnMqobNGATC = unifiedMouse;
			HyJfhRFtuFqKrFdhDGBoOIpRRvkc = unifiedKeyboard;
			RixhOtXDbSIOhYkJycehgIXDBbxD = unifiedMouse != null;
			iyGFwvImCbxxsRCfTTBNAxyjqRK = unifiedKeyboard != null;
			FgHZkoRGNeioFjCybKVqAjFHQgHv = ReInput.isEditor;
			AvwfdLjWSYyRUfRbGOqVqadERNGK = new List<KchbyaIpiOUwIuFRWQOhqCekrdI>();
			lWRYaJqtgGnnPbRvxaOVqiJCvAN = new ReadOnlyCollection<KchbyaIpiOUwIuFRWQOhqCekrdI>(AvwfdLjWSYyRUfRbGOqVqadERNGK);
			nJXMAKyHzuLPhLbOdddImvMYzNh = new List<KchbyaIpiOUwIuFRWQOhqCekrdI>();
			yyMMqHvbhEwxCEbBQhujCMSMxmtH = new WjFybxMnkkesCfQZxtpFlEatAdf.rcpdAtthbgpUiTgtMOHNxoLoDjp
			{
				QLRVlFytItCyaRFAlVUdgmmmtSp = (uint)Marshal.SizeOf(typeof(WjFybxMnkkesCfQZxtpFlEatAdf.rcpdAtthbgpUiTgtMOHNxoLoDjp)),
				GxHmXZWzdGvanYuBUUcyBiDtmKS = true,
				FjOFcjStVwRNmyqmKMLXCBGUPiD = true,
				lVKAFIdYRtwxrSInZgyfaTvRaJMU = false,
				GeSBHHMvdGdoFMfwtcteVupmvCE = true,
				cOiFbHdZnaUpCAxRHhJSaewZoihe = IntPtr.Zero
			};
			UtRCOrctKOJcRmEkNISALOXfETl = WjFybxMnkkesCfQZxtpFlEatAdf.FRMKwblNelYkUXtMZFDktdIAaAc.AMeJMNvnyBBLKGPtCVsgJOjWefz();
			dKPdDijfFqFYeTcSEqQOqomtNbtj = new NativeBuffer((int)UtRCOrctKOJcRmEkNISALOXfETl.QLRVlFytItCyaRFAlVUdgmmmtSp);
			dKPdDijfFqFYeTcSEqQOqomtNbtj.Write(UtRCOrctKOJcRmEkNISALOXfETl.QLRVlFytItCyaRFAlVUdgmmmtSp, 0);
			if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
			{
				jMaxEjuUEYbFXfmvulQkNFoeuPX(FQwjqIFMlpBaZKMILwGdtlahNsN);
				FvjazacAeiGVqGiWbhHkbAbBTEz();
			}
			if (handleJoysticks)
			{
				try
				{
					DAHcyYLtplbGvPFjhfRFGgOFCmK();
					RgptrlAaWMkICxquhGMZCNadmpUx(ref AvwfdLjWSYyRUfRbGOqVqadERNGK, ivEVyniQUhUsxBGRygXPigFwcrn(true));
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
			mOmoxdImuRnVvdtslWhhxAJkIUQ();
			ReInput.ApplicationIsFullScreenChangedEvent += DLTFanHosVFQyNYyrhNCojhkrWu;
			ReInput.ApplicationFullScreenModeChangedEvent += LYEsvEzZuwjEBpzdFIeRSBbfrJR;
		}
		catch (Exception ex2)
		{
			Dispose();
			throw ex2;
		}
	}

	public void DAHcyYLtplbGvPFjhfRFGgOFCmK()
	{
	}

	public void gHTVzIhcnCDJODvwfVhwJwpSAkRd()
	{
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			lock (wqkcGFNfJIdbpgKOpqiqCmzTzGvA)
			{
				RgptrlAaWMkICxquhGMZCNadmpUx(ref AvwfdLjWSYyRUfRbGOqVqadERNGK, nJXMAKyHzuLPhLbOdddImvMYzNh);
				nJXMAKyHzuLPhLbOdddImvMYzNh.Clear();
			}
		}
		if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
		{
			mKKDHxcxLqHRKArgmNxVZDasEHXO();
			goto IL_0048;
		}
		goto IL_0066;
		IL_004d:
		int num;
		switch (num ^ 0x1CAA88D0)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_0066;
		case 1:
			return;
		}
		goto IL_0048;
		IL_0048:
		num = 480938194;
		goto IL_004d;
		IL_0066:
		slwjymQzpUCqMhDMbTNJNEcsbph = false;
		num = 480938193;
		goto IL_004d;
	}

	public bool IpIBfdAJGcUvYyxWHBACBnDwGIP()
	{
		bool result = default(bool);
		lock (wqkcGFNfJIdbpgKOpqiqCmzTzGvA)
		{
			if (SqeOzohDcbasINSacwUopwrhQii())
			{
				Thread.Sleep(250);
				goto IL_001f;
			}
			goto IL_0041;
			IL_0041:
			nJXMAKyHzuLPhLbOdddImvMYzNh = ivEVyniQUhUsxBGRygXPigFwcrn(false);
			int num = 61388793;
			goto IL_0024;
			IL_001f:
			num = 61388794;
			goto IL_0024;
			IL_0024:
			while (true)
			{
				switch (num ^ 0x3A8B7F9)
				{
				case 2:
					break;
				default:
					goto end_IL_000d;
				case 3:
					goto IL_0041;
				case 0:
					result = true;
					num = 61388792;
					continue;
				case 1:
					goto end_IL_000d;
				}
				break;
			}
			goto IL_001f;
			end_IL_000d:;
		}
		return result;
	}

	public bool kmodMVsDsXcZsNFRxGrEkPPKsBl()
	{
		int num = YnmFUkYTWeJEECfPsKiWpXwiYVJ();
		if (num == ZVTiOQKemkBbFhYicwQiTVBfEZbK)
		{
			return false;
		}
		ZVTiOQKemkBbFhYicwQiTVBfEZbK = num;
		return true;
	}

	public bool SqeOzohDcbasINSacwUopwrhQii()
	{
		try
		{
			return eCKdLvtfldigSEOJNAhOjiRdUQDt.SqeOzohDcbasINSacwUopwrhQii();
		}
		catch
		{
		}
		return false;
	}

	public void SystemDeviceDisconnected()
	{
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			slwjymQzpUCqMhDMbTNJNEcsbph = true;
		}
	}

	public void SystemDeviceConnected()
	{
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			slwjymQzpUCqMhDMbTNJNEcsbph = true;
		}
	}

	public void Update()
	{
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num < aFneOXQWvPgGjcqCxDITYnwBaaV.Length)
			{
				num2 = 365372234;
				num3 = num2;
			}
			else
			{
				num2 = 365372232;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x15C72348)
				{
				case 4:
					num2 = 365372234;
					continue;
				default:
					return;
				case 3:
					if (!iyGFwvImCbxxsRCfTTBNAxyjqRK)
					{
						int num5;
						if (!RixhOtXDbSIOhYkJycehgIXDBbxD)
						{
							num2 = 365372239;
							num5 = num2;
						}
						else
						{
							num2 = 365372238;
							num5 = num2;
						}
						continue;
					}
					goto case 6;
				case 1:
					break;
				case 6:
					PXpbKpEAawmhPIGNLJhQkxYTitg();
					num2 = 365372239;
					continue;
				case 5:
					if (FgHZkoRGNeioFjCybKVqAjFHQgHv)
					{
						int num4;
						if (hMmfqHsFLqCphWyBKmofLIlkGHEC >= 0)
						{
							num2 = 365372239;
							num4 = num2;
						}
						else
						{
							num2 = 365372235;
							num4 = num2;
						}
						continue;
					}
					return;
				case 0:
					if (hMmfqHsFLqCphWyBKmofLIlkGHEC >= 0)
					{
						iRpcqsJBbVYdTtvDMZLVmPmOBWjd();
						num2 = 365372237;
						continue;
					}
					goto case 5;
				case 2:
					aFneOXQWvPgGjcqCxDITYnwBaaV[num].Update();
					num++;
					num2 = 365372233;
					continue;
				case 7:
					return;
				}
				break;
			}
		}
	}

	public void UpdateDevices(UpdateLoopType updateLoop)
	{
		if (!jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			return;
		}
		MdvOMMNxWfcPHdPxtxTUTmquguI mdvOMMNxWfcPHdPxtxTUTmquguI = default(MdvOMMNxWfcPHdPxtxTUTmquguI);
		while (true)
		{
			int count = AvwfdLjWSYyRUfRbGOqVqadERNGK.Count;
			int num = 0;
			int num2 = -1519279933;
			while (true)
			{
				switch (num2 ^ -1519279935)
				{
				case 0:
					num2 = -1519279934;
					continue;
				case 3:
					break;
				case 4:
					num++;
					num2 = -1519279933;
					continue;
				case 5:
					if (mdvOMMNxWfcPHdPxtxTUTmquguI != null)
					{
						mdvOMMNxWfcPHdPxtxTUTmquguI.Update(updateLoop);
						num2 = -1519279931;
						continue;
					}
					goto case 4;
				case 1:
					mdvOMMNxWfcPHdPxtxTUTmquguI = AvwfdLjWSYyRUfRbGOqVqadERNGK[num];
					num2 = -1519279932;
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

	public void UpdateFinished()
	{
		if (!jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			return;
		}
		MdvOMMNxWfcPHdPxtxTUTmquguI mdvOMMNxWfcPHdPxtxTUTmquguI = default(MdvOMMNxWfcPHdPxtxTUTmquguI);
		while (true)
		{
			int count = AvwfdLjWSYyRUfRbGOqVqadERNGK.Count;
			int num = 0;
			int num2 = -2002581869;
			while (true)
			{
				switch (num2 ^ -2002581871)
				{
				case 5:
					num2 = -2002581872;
					continue;
				default:
					return;
				case 0:
					num++;
					num2 = -2002581869;
					continue;
				case 3:
					if (mdvOMMNxWfcPHdPxtxTUTmquguI != null)
					{
						mdvOMMNxWfcPHdPxtxTUTmquguI.UpdateFinished();
						num2 = -2002581871;
						continue;
					}
					goto case 0;
				case 4:
					mdvOMMNxWfcPHdPxtxTUTmquguI = AvwfdLjWSYyRUfRbGOqVqadERNGK[num];
					num2 = -2002581870;
					continue;
				case 2:
				{
					int num3;
					if (num < count)
					{
						num2 = -2002581867;
						num3 = num2;
					}
					else
					{
						num2 = -2002581865;
						num3 = num2;
					}
					continue;
				}
				case 1:
					break;
				case 6:
					return;
				}
				break;
			}
		}
	}

	public IList<T> GetJoysticks<T>() where T : class
	{
		return lWRYaJqtgGnnPbRvxaOVqiJCvAN as IList<T>;
	}

	private List<KchbyaIpiOUwIuFRWQOhqCekrdI> ivEVyniQUhUsxBGRygXPigFwcrn(bool P_0)
	{
		aTrCJwWIGVmMqShuJeadqdxvqWA aTrCJwWIGVmMqShuJeadqdxvqWA2 = new aTrCJwWIGVmMqShuJeadqdxvqWA();
		if (!jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			return new List<KchbyaIpiOUwIuFRWQOhqCekrdI>();
		}
		EnrFFHfVSHjlhXSpuPszsaBcZaGE();
		List<bSpOfYCKbuoGmWWdYWRaFTvxjqc> list = null;
		List<KchbyaIpiOUwIuFRWQOhqCekrdI> list2 = new List<KchbyaIpiOUwIuFRWQOhqCekrdI>();
		ZVTiOQKemkBbFhYicwQiTVBfEZbK = NfMdYBEiKIfRmzLmtdYlctMcSqmq();
		bool flag = default(bool);
		lIwaFwjjdUQVLpcKYjYFLGDSfyjR lIwaFwjjdUQVLpcKYjYFLGDSfyjR2 = default(lIwaFwjjdUQVLpcKYjYFLGDSfyjR);
		OfnCYzfWcJGmSbGsBiIYTfCRKgCQ ofnCYzfWcJGmSbGsBiIYTfCRKgCQ = default(OfnCYzfWcJGmSbGsBiIYTfCRKgCQ);
		Predicate<string> predicate = default(Predicate<string>);
		while (true)
		{
			int num = -401404319;
			while (true)
			{
				switch (num ^ -401404318)
				{
				case 0:
					break;
				case 3:
					flag = false;
					num = -401404317;
					continue;
				case 1:
					if (!flag)
					{
						list = VirXhLPnLrtadNhOAiqyporSIM.dEZaLpDqutBsXQHueZLTMvdeiKu(P_0);
						flag = true;
						num = -401404320;
						continue;
					}
					goto default;
				default:
				{
					if (list == null)
					{
						list = new List<bSpOfYCKbuoGmWWdYWRaFTvxjqc>();
					}
					try
					{
						aTrCJwWIGVmMqShuJeadqdxvqWA2.ZdkImXCjZLQxeepndIgXxojjIMf = eCKdLvtfldigSEOJNAhOjiRdUQDt.SGYaVQfaTgIvppUnhaZXBGFeEuM();
					}
					catch (Exception ex)
					{
						aTrCJwWIGVmMqShuJeadqdxvqWA2.ZdkImXCjZLQxeepndIgXxojjIMf = new List<eCKdLvtfldigSEOJNAhOjiRdUQDt.CmkCdjhTVEAFSgsBBqCkKyeFEian>();
						Rewired.Logger.LogError("Exception getting HID device list.\n" + ex);
					}
					List<string> list3 = new List<string>();
					int num2 = 0;
					int num3 = 0;
					while (true)
					{
						int num7;
						switch (-401404317 ^ -401404318)
						{
						case 0:
							break;
						default:
						{
							KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI = null;
							try
							{
								bSpOfYCKbuoGmWWdYWRaFTvxjqc bSpOfYCKbuoGmWWdYWRaFTvxjqc2 = list[num3];
								while (true)
								{
									IL_00e7:
									int num4 = -401404314;
									while (true)
									{
										switch (num4 ^ -401404318)
										{
										case 3:
											break;
										case 7:
										{
											lIwaFwjjdUQVLpcKYjYFLGDSfyjR2 = bSpOfYCKbuoGmWWdYWRaFTvxjqc2 as lIwaFwjjdUQVLpcKYjYFLGDSfyjR;
											int num6;
											if (lIwaFwjjdUQVLpcKYjYFLGDSfyjR2 != null)
											{
												num4 = -401404318;
												num6 = num4;
											}
											else
											{
												num4 = -401404316;
												num6 = num4;
											}
											continue;
										}
										case 6:
											goto end_IL_00ec;
										case 5:
											goto end_IL_00ec;
										case 4:
											if (list[num3] == null)
											{
												goto end_IL_00ec;
											}
											goto case 2;
										case 0:
											kchbyaIpiOUwIuFRWQOhqCekrdI = lEeIaDKUIfCqtBuwnuyOgxiuzjIh(bSpOfYCKbuoGmWWdYWRaFTvxjqc2.Handle, lIwaFwjjdUQVLpcKYjYFLGDSfyjR2, aTrCJwWIGVmMqShuJeadqdxvqWA2.ZdkImXCjZLQxeepndIgXxojjIMf, list3, num2);
											if (kchbyaIpiOUwIuFRWQOhqCekrdI == null)
											{
												goto end_IL_00ec;
											}
											goto default;
										case 2:
										{
											int num5;
											if (bSpOfYCKbuoGmWWdYWRaFTvxjqc2.DeviceType == ZzynUvmlKytKEgmTHiivLRYPjoE.AXISQqlTXCgqZMiVvlFxhvyEMxo)
											{
												num4 = -401404315;
												num5 = num4;
											}
											else
											{
												num4 = -401404313;
												num5 = num4;
											}
											continue;
										}
										default:
											list2.Add(kchbyaIpiOUwIuFRWQOhqCekrdI);
											num2++;
											goto end_IL_00ec;
										}
										goto IL_00e7;
										continue;
										end_IL_00ec:
										break;
									}
									break;
								}
							}
							catch (Exception ex2)
							{
								Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional.\n" + ex2.Message);
							}
							num3++;
							goto IL_01df;
						}
						case 1:
							goto IL_0243;
							IL_0243:
							if (num3 < list.Count)
							{
								goto default;
							}
							num7 = -401404317;
							goto IL_01e4;
							IL_01df:
							num7 = -401404320;
							goto IL_01e4;
							IL_01e4:
							while (true)
							{
								int num8;
								switch (num7 ^ -401404318)
								{
								case 0:
									break;
								case 3:
									ofnCYzfWcJGmSbGsBiIYTfCRKgCQ.IZgeEsAcywOFlSvSuaDMZooDRAeH = 0;
									goto IL_0329;
								case 1:
									if (!UKtATHlOcpbLyohLTFgOWGklugI.useXInput)
									{
										predicate = null;
										ofnCYzfWcJGmSbGsBiIYTfCRKgCQ = new OfnCYzfWcJGmSbGsBiIYTfCRKgCQ();
										ofnCYzfWcJGmSbGsBiIYTfCRKgCQ.AwcECvjpNwTdNXMwiQWaEGQQzNu = aTrCJwWIGVmMqShuJeadqdxvqWA2;
										num7 = -401404319;
										continue;
									}
									goto IL_0348;
								case 2:
									goto IL_0243;
								default:
									{
										KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI2 = null;
										try
										{
											if (predicate == null)
											{
												predicate = ofnCYzfWcJGmSbGsBiIYTfCRKgCQ.HbXBqtIasfOCJjCJJubKttVEibYT;
											}
											if (string.IsNullOrEmpty(list3.Find(predicate)))
											{
												while (true)
												{
													IL_02a1:
													kchbyaIpiOUwIuFRWQOhqCekrdI2 = ZhfzyQzwZXqoPxfMXyeFomWgdQx(aTrCJwWIGVmMqShuJeadqdxvqWA2.ZdkImXCjZLQxeepndIgXxojjIMf[ofnCYzfWcJGmSbGsBiIYTfCRKgCQ.IZgeEsAcywOFlSvSuaDMZooDRAeH], num2);
													int num9 = -401404317;
													while (true)
													{
														switch (num9 ^ -401404318)
														{
														case 0:
															goto IL_027f;
														case 3:
															break;
														case 1:
															if (kchbyaIpiOUwIuFRWQOhqCekrdI2 == null)
															{
																goto end_IL_0284;
															}
															goto default;
														default:
															list2.Add(kchbyaIpiOUwIuFRWQOhqCekrdI2);
															num2++;
															goto end_IL_0284;
														}
														goto IL_02a1;
														IL_027f:
														num9 = -401404319;
														continue;
														end_IL_0284:
														break;
													}
													break;
												}
											}
										}
										catch (Exception ex3)
										{
											Rewired.Logger.LogError("An exception occurred while initializing HID device! This device will be non-functional." + ex3.Message);
										}
										ofnCYzfWcJGmSbGsBiIYTfCRKgCQ.IZgeEsAcywOFlSvSuaDMZooDRAeH++;
										goto IL_030b;
									}
									IL_030b:
									num8 = -401404317;
									goto IL_0310;
									IL_0329:
									if (ofnCYzfWcJGmSbGsBiIYTfCRKgCQ.IZgeEsAcywOFlSvSuaDMZooDRAeH < aTrCJwWIGVmMqShuJeadqdxvqWA2.ZdkImXCjZLQxeepndIgXxojjIMf.Count)
									{
										goto default;
									}
									num8 = -401404318;
									goto IL_0310;
									IL_0310:
									switch (num8 ^ -401404318)
									{
									case 2:
										break;
									case 1:
										goto IL_0329;
									default:
										goto IL_0348;
									}
									goto IL_030b;
									IL_0348:
									return list2;
								}
								break;
							}
							goto IL_01df;
						}
					}
				}
				}
				break;
			}
		}
	}

	private static void RgptrlAaWMkICxquhGMZCNadmpUx(ref List<KchbyaIpiOUwIuFRWQOhqCekrdI> P_0, List<KchbyaIpiOUwIuFRWQOhqCekrdI> P_1)
	{
		if (P_0 == null)
		{
			P_0 = new List<KchbyaIpiOUwIuFRWQOhqCekrdI>();
			goto IL_000e;
		}
		goto IL_0126;
		IL_005b:
		int num = 0;
		int num2 = -854585910;
		goto IL_0013;
		IL_000e:
		num2 = -854585916;
		goto IL_0013;
		IL_0013:
		int num3 = default(int);
		KchbyaIpiOUwIuFRWQOhqCekrdI[] array = default(KchbyaIpiOUwIuFRWQOhqCekrdI[]);
		int count2 = default(int);
		int count = default(int);
		while (true)
		{
			switch (num2 ^ -854585918)
			{
			case 0:
				break;
			case 11:
				goto IL_005b;
			case 4:
				num3 = 0;
				num2 = -854585920;
				continue;
			case 12:
				goto IL_006e;
			case 3:
				num3++;
				num2 = -854585920;
				continue;
			case 13:
				return;
			case 1:
			{
				wwISNOGfSnERhIgYYOqiDRqxybdP wwISNOGfSnERhIgYYOqiDRqxybdP2 = new wwISNOGfSnERhIgYYOqiDRqxybdP();
				wwISNOGfSnERhIgYYOqiDRqxybdP2.KfBMsKmKSFAAFWYvFXjacifOooO = P_0[num];
				if (wwISNOGfSnERhIgYYOqiDRqxybdP2.KfBMsKmKSFAAFWYvFXjacifOooO != null && Array.Find(array, wwISNOGfSnERhIgYYOqiDRqxybdP2.ylcmAZqcimcRSKwVQRuQMREyPCEd) == null)
				{
					wwISNOGfSnERhIgYYOqiDRqxybdP2.KfBMsKmKSFAAFWYvFXjacifOooO.Dispose();
					num2 = -854585909;
					continue;
				}
				goto case 9;
			}
			case 7:
				P_0.Add(array[num3]);
				num2 = -854585919;
				continue;
			case 6:
				goto IL_0126;
			case 5:
				goto IL_013a;
			case 8:
				if (num >= count2)
				{
					P_0.Clear();
					num2 = -854585914;
					continue;
				}
				goto case 1;
			case 10:
				if (array[num3] != null)
				{
					array[num3].SetJoystickId(num3);
					num2 = -854585915;
					continue;
				}
				goto case 3;
			case 9:
				num++;
				num2 = -854585910;
				continue;
			default:
				if (num3 >= count)
				{
					return;
				}
				goto case 10;
			}
			break;
		}
		goto IL_000e;
		IL_006e:
		count = P_1.Count;
		count2 = P_0.Count;
		array = P_1.ToArray();
		if (array.Length > 0)
		{
			Array.Sort(array, BfAgYwhNsraJuulVuaUcOlZZqmg);
			num2 = -854585911;
			goto IL_0013;
		}
		goto IL_005b;
		IL_0126:
		if (P_1 == null)
		{
			P_1 = new List<KchbyaIpiOUwIuFRWQOhqCekrdI>();
			num2 = -854585913;
			goto IL_0013;
		}
		goto IL_013a;
		IL_013a:
		if (P_1.Count == 0)
		{
			P_0.ForEach(delegate(KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI)
			{
				kchbyaIpiOUwIuFRWQOhqCekrdI.Dispose();
			});
			P_0.Clear();
			num2 = -854585905;
			goto IL_0013;
		}
		goto IL_006e;
	}

	private List<bSpOfYCKbuoGmWWdYWRaFTvxjqc> kyhaLCwsBoravTDKSboncyFOeiMH()
	{
		List<bSpOfYCKbuoGmWWdYWRaFTvxjqc> list = new List<bSpOfYCKbuoGmWWdYWRaFTvxjqc>();
		try
		{
			foreach (bUiVDUOAHpFECnWVzgHAGOUkHLxZ item in eCKdLvtfldigSEOJNAhOjiRdUQDt.BXkSGMdgdGUWiGTXfCqwBYdKSjG())
			{
				try
				{
					list.Add(new lIwaFwjjdUQVLpcKYjYFLGDSfyjR
					{
						DeviceName = cHGdLHdUWUiYzPziDkeopfYJjxqa.gLUZjbmwgOCjnwzLLPDKLEevbpq(item.DevicePath),
						DeviceType = ZzynUvmlKytKEgmTHiivLRYPjoE.AXISQqlTXCgqZMiVvlFxhvyEMxo,
						Handle = IntPtr.Zero,
						ProductId = item.Attributes.ProductId,
						VendorId = item.Attributes.VendorId,
						VersionNumber = item.Attributes.Version,
						UsagePage = (rkWDFIFhfEYYfewtCEiNcoZAcHX)item.Capabilities.UsagePage,
						Usage = (MfbJCQtTuFJHamEmynNyXrrBdib)item.Capabilities.Usage
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

	private KchbyaIpiOUwIuFRWQOhqCekrdI lEeIaDKUIfCqtBuwnuyOgxiuzjIh(IntPtr P_0, lIwaFwjjdUQVLpcKYjYFLGDSfyjR P_1, IList<eCKdLvtfldigSEOJNAhOjiRdUQDt.CmkCdjhTVEAFSgsBBqCkKyeFEian> P_2, List<string> P_3, int P_4)
	{
		ushort num = (ushort)P_1.UsagePage;
		ushort num2 = (ushort)P_1.Usage;
		string deviceName = P_1.DeviceName;
		if (!njcVitbIGesZtwHikiZdPkfyKXO(num, num2))
		{
			return null;
		}
		string text = cHGdLHdUWUiYzPziDkeopfYJjxqa.gLUZjbmwgOCjnwzLLPDKLEevbpq(deviceName);
		if (string.IsNullOrEmpty(text))
		{
			return null;
		}
		P_3.Add(text);
		bUiVDUOAHpFECnWVzgHAGOUkHLxZ bUiVDUOAHpFECnWVzgHAGOUkHLxZ2 = eCKdLvtfldigSEOJNAhOjiRdUQDt.kGjBVhjBUAjGJsGQHgaitJYvwiz(P_2, text, StringComparison.OrdinalIgnoreCase);
		if (bUiVDUOAHpFECnWVzgHAGOUkHLxZ2 == null)
		{
			return null;
		}
		string text2 = bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.ReadProductName();
		string bluetoothDeviceName = bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.BluetoothDeviceName;
		Guid guid = MiscTools.CreateHIDProductGuid(bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.Attributes.VendorId, bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.Attributes.ProductId);
		if (XwFnLxypphHNgefilLFbGvPLvxl.RKPgaVeMTrfnKxgRCSrnhsVZRfTc(guid, text2, bluetoothDeviceName))
		{
			P_3.RemoveAt(P_3.Count - 1);
			return null;
		}
		return snfcllBbVsiMgTCyaAbqdMGGgNa(yOsYsEkRiyFUYfUQFHVYzKDYlZb.iqYXuMMzjBiMvzCNsYloUSNOfix, bUiVDUOAHpFECnWVzgHAGOUkHLxZ2, P_0, num, num2, P_4);
	}

	private KchbyaIpiOUwIuFRWQOhqCekrdI ZhfzyQzwZXqoPxfMXyeFomWgdQx(eCKdLvtfldigSEOJNAhOjiRdUQDt.CmkCdjhTVEAFSgsBBqCkKyeFEian P_0, int P_1)
	{
		bUiVDUOAHpFECnWVzgHAGOUkHLxZ bUiVDUOAHpFECnWVzgHAGOUkHLxZ2 = eCKdLvtfldigSEOJNAhOjiRdUQDt.aaWdYIFVCAJaobYwIykEIAmdvu(P_0);
		if (bUiVDUOAHpFECnWVzgHAGOUkHLxZ2 == null)
		{
			return null;
		}
		ushort num = (ushort)bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.Capabilities.UsagePage;
		ushort num2 = (ushort)bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.Capabilities.Usage;
		if (!njcVitbIGesZtwHikiZdPkfyKXO(num, num2))
		{
			return null;
		}
		if (!XwFnLxypphHNgefilLFbGvPLvxl.RKPgaVeMTrfnKxgRCSrnhsVZRfTc(MiscTools.CreateHIDProductGuid(bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.Attributes.VendorId, bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.Attributes.ProductId), bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.ReadProductName(), bUiVDUOAHpFECnWVzgHAGOUkHLxZ2.BluetoothDeviceName))
		{
			return null;
		}
		return snfcllBbVsiMgTCyaAbqdMGGgNa(yOsYsEkRiyFUYfUQFHVYzKDYlZb.YODNVIoCqWMJrVQvJphSGykANde, bUiVDUOAHpFECnWVzgHAGOUkHLxZ2, IntPtr.Zero, num, num2, P_1);
	}

	private KchbyaIpiOUwIuFRWQOhqCekrdI snfcllBbVsiMgTCyaAbqdMGGgNa(yOsYsEkRiyFUYfUQFHVYzKDYlZb P_0, bUiVDUOAHpFECnWVzgHAGOUkHLxZ P_1, IntPtr P_2, ushort P_3, ushort P_4, int P_5)
	{
		bool flag = P_3 != 1 || !GNFedjgvPcDOHkBgIivYujrHsRh.imVAMAHkvBNmmhDMJFTXvySdEGyb.ErecDRbrqVUabPMAuIVlqzuiKTW(P_4);
		string text = P_1.ReadProductName();
		string bluetoothDeviceName = P_1.BluetoothDeviceName;
		Guid guid = MiscTools.CreateHIDProductGuid(P_1.Attributes.VendorId, P_1.Attributes.ProductId);
		if (UKtATHlOcpbLyohLTFgOWGklugI.useXInput && gshAbvCgMLjmBZLoNOmLiemiCMZ.NYbPexEJvLXtDiZpusQEVKSFkTK(P_1.DevicePath, text, bluetoothDeviceName, guid))
		{
			return null;
		}
		KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI = HwvkvPnjOqoyDbpfPGGVhReEqko(P_0, P_2, P_5, P_1, AvwfdLjWSYyRUfRbGOqVqadERNGK, flag);
		if (kchbyaIpiOUwIuFRWQOhqCekrdI == null || !kchbyaIpiOUwIuFRWQOhqCekrdI.HasElements)
		{
			if (kchbyaIpiOUwIuFRWQOhqCekrdI != null && !kchbyaIpiOUwIuFRWQOhqCekrdI.HasElements)
			{
				kchbyaIpiOUwIuFRWQOhqCekrdI.Dispose();
			}
			return null;
		}
		return kchbyaIpiOUwIuFRWQOhqCekrdI;
	}

	private bool njcVitbIGesZtwHikiZdPkfyKXO(ushort P_0, ushort P_1)
	{
		int num = 0;
		while (num < lnsZCaqDgeSluOroxStGchbmhSo.Length)
		{
			while (true)
			{
				if (lnsZCaqDgeSluOroxStGchbmhSo[num].DHoHwlVAbcMQAlRasQeiXZFPkPJ == P_0 && lnsZCaqDgeSluOroxStGchbmhSo[num].EqdtfgTALHwKuieEEBOUWzyDHNC == P_1)
				{
					return true;
				}
				num++;
				int num2 = 534569307;
				while (true)
				{
					switch (num2 ^ 0x1FDCE15B)
					{
					case 2:
						num2 = 534569306;
						continue;
					case 1:
						break;
					default:
						goto end_IL_0022;
					}
					break;
				}
				continue;
				end_IL_0022:
				break;
			}
		}
		return false;
	}

	private int NfMdYBEiKIfRmzLmtdYlctMcSqmq()
	{
		try
		{
			return eCKdLvtfldigSEOJNAhOjiRdUQDt.RkwcnGfAdjnBAZpTGLprxXKBGMi();
		}
		catch
		{
			return 0;
		}
	}

	private int YnmFUkYTWeJEECfPsKiWpXwiYVJ()
	{
		try
		{
			return eCKdLvtfldigSEOJNAhOjiRdUQDt.RkwcnGfAdjnBAZpTGLprxXKBGMi(ref yyMMqHvbhEwxCEbBQhujCMSMxmtH, dKPdDijfFqFYeTcSEqQOqomtNbtj);
		}
		catch (Exception)
		{
			return 0;
		}
	}

	private KchbyaIpiOUwIuFRWQOhqCekrdI HwvkvPnjOqoyDbpfPGGVhReEqko(yOsYsEkRiyFUYfUQFHVYzKDYlZb P_0, IntPtr P_1, int P_2, bUiVDUOAHpFECnWVzgHAGOUkHLxZ P_3, List<KchbyaIpiOUwIuFRWQOhqCekrdI> P_4, bool P_5)
	{
		if (P_5 && !pGteRdEOtsppIWvKatYVMbCeEFX)
		{
			return null;
		}
		try
		{
			if (pGteRdEOtsppIWvKatYVMbCeEFX)
			{
				if (P_4 != null)
				{
					for (int i = 0; i < P_4.Count; i++)
					{
						rtJOzXjwulRDsZLuifHOdxmwsVQ rtJOzXjwulRDsZLuifHOdxmwsVQ2 = P_4[i] as rtJOzXjwulRDsZLuifHOdxmwsVQ;
						if (rtJOzXjwulRDsZLuifHOdxmwsVQ2 != null && rtJOzXjwulRDsZLuifHOdxmwsVQ2.Driver != null && !(P_3.InstanceId != rtJOzXjwulRDsZLuifHOdxmwsVQ2.HidDevice.InstanceId))
						{
							rtJOzXjwulRDsZLuifHOdxmwsVQ2.SetJoystickId(P_2);
							return rtJOzXjwulRDsZLuifHOdxmwsVQ2;
						}
					}
				}
				int num = HIDDeviceDriver.FindDriverId(P_3.Attributes.VendorId, P_3.Attributes.ProductId);
				if (num >= 0)
				{
					HidOutputReportHandler hidOutputReportHandler = new HidOutputReportHandler(P_3.KUtfYedqJpjatHrovgLeEWqEYLaw);
					HIDDeviceDriver driver = HIDDeviceDriver.GetDriver(num, new HIDDeviceDriver.InitArgs(EAqhhnqHsgswgIHwTkugMMEPdAp, (!P_3.IsBluetoothDevice) ? DeviceConnectionType.hVDlQvFZcgsGUNogPHqfKeAajkj : DeviceConnectionType.HkHOtQTdmHcCvbpbnishLoIlAPNG, 65535, -65535, -1, 4500, P_3.Capabilities.InputReportByteLength, P_3.Capabilities.OutputReportByteLength, P_3.KUtfYedqJpjatHrovgLeEWqEYLaw, hidOutputReportHandler.WriteReport));
					if (driver != null)
					{
						return new rtJOzXjwulRDsZLuifHOdxmwsVQ(P_2, P_0, P_1, P_3, driver, hidOutputReportHandler);
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
					ghVJoxJlbsXgoFcmZESJqvsJGsV ghVJoxJlbsXgoFcmZESJqvsJGsV2 = P_4[j] as ghVJoxJlbsXgoFcmZESJqvsJGsV;
					if (ghVJoxJlbsXgoFcmZESJqvsJGsV2 != null && !(P_3.InstanceId != ghVJoxJlbsXgoFcmZESJqvsJGsV2.HidDevice.InstanceId))
					{
						ghVJoxJlbsXgoFcmZESJqvsJGsV2.SetJoystickId(P_2);
						return ghVJoxJlbsXgoFcmZESJqvsJGsV2;
					}
				}
			}
			return new ghVJoxJlbsXgoFcmZESJqvsJGsV(P_2, P_0, P_1, P_3);
		}
		catch
		{
			return null;
		}
	}

	private KchbyaIpiOUwIuFRWQOhqCekrdI yUTXqGvFiWmswDlDoNizZARjOyD(yOsYsEkRiyFUYfUQFHVYzKDYlZb P_0, IntPtr P_1)
	{
		if (AvwfdLjWSYyRUfRbGOqVqadERNGK == null)
		{
			goto IL_0008;
		}
		int num = 0;
		int num2 = 1134157615;
		goto IL_000d;
		IL_000d:
		KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI = default(KchbyaIpiOUwIuFRWQOhqCekrdI);
		while (true)
		{
			switch (num2 ^ 0x4399DF2D)
			{
			case 3:
				break;
			case 4:
				return null;
			case 1:
				kchbyaIpiOUwIuFRWQOhqCekrdI = AvwfdLjWSYyRUfRbGOqVqadERNGK[num];
				if (kchbyaIpiOUwIuFRWQOhqCekrdI.JoystickSourceType == P_0 && !(kchbyaIpiOUwIuFRWQOhqCekrdI.JoystickSourceHandle != P_1))
				{
					num2 = 1134157613;
					continue;
				}
				num++;
				num2 = 1134157615;
				continue;
			case 0:
				return kchbyaIpiOUwIuFRWQOhqCekrdI;
			default:
				if (num >= AvwfdLjWSYyRUfRbGOqVqadERNGK.Count)
				{
					return null;
				}
				goto case 1;
			}
			break;
		}
		goto IL_0008;
		IL_0008:
		num2 = 1134157609;
		goto IL_000d;
	}

	private unsafe KchbyaIpiOUwIuFRWQOhqCekrdI zcwSNHDscsdPVOwuxoSIyZpBMzF(IntPtr P_0)
	{
		uint num;
		JBXHRSYUePslTBUiRmNOkdLSed.VqKTuzcRRekFAIbEWeGCVcXzFGv(P_0, 536870919u, IntPtr.Zero, out num);
		KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI = default(KchbyaIpiOUwIuFRWQOhqCekrdI);
		int num3 = default(int);
		string text = default(string);
		char* value = default(char*);
		int length = default(int);
		while (true)
		{
			int num2 = -1376856159;
			while (true)
			{
				switch (num2 ^ -1376856154)
				{
				case 8:
					break;
				case 4:
					kchbyaIpiOUwIuFRWQOhqCekrdI = AvwfdLjWSYyRUfRbGOqVqadERNGK[num3];
					if (kchbyaIpiOUwIuFRWQOhqCekrdI.JoystickSourceType == yOsYsEkRiyFUYfUQFHVYzKDYlZb.iqYXuMMzjBiMvzCNsYloUSNOfix && kchbyaIpiOUwIuFRWQOhqCekrdI.HidDevice.DevicePathStripped.Equals(text, StringComparison.OrdinalIgnoreCase))
					{
						num2 = -1376856160;
						continue;
					}
					num3++;
					num2 = -1376856156;
					continue;
				case 5:
					text = new string(value, 0, length);
					num2 = -1376856153;
					continue;
				case 6:
					kchbyaIpiOUwIuFRWQOhqCekrdI.SetJoystickSourceHandle(P_0);
					return kchbyaIpiOUwIuFRWQOhqCekrdI;
				case 1:
				{
					int num4;
					if (text.Length == 0)
					{
						num2 = -1376856155;
						num4 = num2;
					}
					else
					{
						num2 = -1376856154;
						num4 = num2;
					}
					continue;
				}
				case 3:
					text = string.Empty;
					num2 = -1376856154;
					continue;
				case 7:
					if (num == 0)
					{
						return null;
					}
					value = stackalloc char[(int)num];
					JBXHRSYUePslTBUiRmNOkdLSed.VqKTuzcRRekFAIbEWeGCVcXzFGv(P_0, 536870919u, new IntPtr(value), out num);
					length = (int)(((int)num > 0) ? (num - 1) : 0);
					num2 = -1376856157;
					continue;
				case 0:
					if (AvwfdLjWSYyRUfRbGOqVqadERNGK == null)
					{
						return null;
					}
					text = cHGdLHdUWUiYzPziDkeopfYJjxqa.gLUZjbmwgOCjnwzLLPDKLEevbpq(text);
					num3 = 0;
					num2 = -1376856156;
					continue;
				default:
					if (num3 >= AvwfdLjWSYyRUfRbGOqVqadERNGK.Count)
					{
						return null;
					}
					goto case 4;
				}
				break;
			}
		}
	}

	private static int BfAgYwhNsraJuulVuaUcOlZZqmg(KchbyaIpiOUwIuFRWQOhqCekrdI P_0, KchbyaIpiOUwIuFRWQOhqCekrdI P_1)
	{
		if (!P_0.HidDevice.HasLocationInfo)
		{
			return 1;
		}
		if (!P_1.HidDevice.HasLocationInfo)
		{
			return -1;
		}
		int hubId = P_0.HidDevice.HubId;
		int hubId2 = default(int);
		while (true)
		{
			int num = -700851216;
			while (true)
			{
				switch (num ^ -700851215)
				{
				case 0:
					break;
				case 3:
					return -1;
				case 4:
				{
					if (hubId < hubId2)
					{
						return -1;
					}
					if (hubId > hubId2)
					{
						return 1;
					}
					int portId = P_0.HidDevice.PortId;
					int portId2 = P_1.HidDevice.PortId;
					if (portId >= portId2)
					{
						if (portId <= portId2)
						{
							return 0;
						}
						num = -700851213;
					}
					else
					{
						num = -700851214;
					}
					continue;
				}
				case 1:
					hubId2 = P_1.HidDevice.HubId;
					num = -700851211;
					continue;
				default:
					return 1;
				}
				break;
			}
		}
	}

	private void EnrFFHfVSHjlhXSpuPszsaBcZaGE()
	{
		znkFUkAEkkohtdMtANnQwSpjwsZy znkFUkAEkkohtdMtANnQwSpjwsZy2 = new znkFUkAEkkohtdMtANnQwSpjwsZy();
		znkFUkAEkkohtdMtANnQwSpjwsZy2.iidCZOgulnzjWMumhFnWTPbnqlMV = this;
		while (true)
		{
			int num = 1631620179;
			while (true)
			{
				switch (num ^ 0x61408C52)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (ihXRVCsIkdJEbzKinpeeMxhGLFZ != xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
					{
						return;
					}
					goto case 0;
				case 0:
					znkFUkAEkkohtdMtANnQwSpjwsZy2.SWFAUtHYklQthaDjRqSllRDLXqH = false;
					rtbhfSljccJoGUdoSADgOEXcnrG(znkFUkAEkkohtdMtANnQwSpjwsZy2.wpTNtAwNZMybdpNAlzIYOwzggph, true);
					if (znkFUkAEkkohtdMtANnQwSpjwsZy2.SWFAUtHYklQthaDjRqSllRDLXqH)
					{
						goto IL_0061;
					}
					return;
				case 3:
					return;
				}
				break;
				IL_0061:
				Rewired.Logger.LogError("Failed to register HID devices.", true);
				num = 1631620177;
			}
		}
	}

	private void QrclNCSCIhUWTPexBHlYCsTcsYv()
	{
		irvcWpZXiTIEtdwCkRPhjxekASK irvcWpZXiTIEtdwCkRPhjxekASK2 = new irvcWpZXiTIEtdwCkRPhjxekASK();
		while (true)
		{
			int num = 1245486219;
			while (true)
			{
				switch (num ^ 0x4A3C9C8A)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (ihXRVCsIkdJEbzKinpeeMxhGLFZ != xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
					{
						return;
					}
					goto case 3;
				case 3:
					irvcWpZXiTIEtdwCkRPhjxekASK2.SWFAUtHYklQthaDjRqSllRDLXqH = false;
					rtbhfSljccJoGUdoSADgOEXcnrG(irvcWpZXiTIEtdwCkRPhjxekASK2.VZTMbPsxwonrvSCpdAMxPoeWFfc, true);
					if (irvcWpZXiTIEtdwCkRPhjxekASK2.SWFAUtHYklQthaDjRqSllRDLXqH)
					{
						goto IL_005a;
					}
					return;
				case 0:
					return;
				}
				break;
				IL_005a:
				Rewired.Logger.LogError("Failed to unregister HID devices.", true);
				num = 1245486218;
			}
		}
	}

	private void PXpbKpEAawmhPIGNLJhQkxYTitg()
	{
		if (!ReInput.isAllowedEditorWindowFocused)
		{
			goto IL_0067;
		}
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			goto IL_0012;
		}
		goto IL_0112;
		IL_0067:
		int num;
		int num2;
		if (!YHNnglSbiAkeQnlrirNsMoGVHKKC)
		{
			num = 1419661198;
			num2 = num;
		}
		else
		{
			num = 1419661194;
			num2 = num;
		}
		goto IL_0017;
		IL_0012:
		num = 1419661199;
		goto IL_0017;
		IL_0017:
		IntPtr iaXhnaMGCLQqOuWQHTvcfoKYvgL = default(IntPtr);
		uint num3 = default(uint);
		IntPtr yNNTIZOmHinEmVhkyBZxayFLrNX = default(IntPtr);
		bool flag = default(bool);
		while (true)
		{
			bool flag2;
			switch (num ^ 0x549E4F8B)
			{
			case 7:
				break;
			default:
				return;
			case 15:
				goto IL_0067;
			case 8:
				CmPUVIRubavozFqnLuRGJGPSvTK(iaXhnaMGCLQqOuWQHTvcfoKYvgL);
				return;
			case 0:
				flag2 = !zEwUhguYbtmfSmywTFwTYcHWGKn(ControllerType.Keyboard, bAeUJildHBuOCKoLdjiIBEKHyMJH, num3, out iaXhnaMGCLQqOuWQHTvcfoKYvgL);
				if (ejBBccpNHnJqlARgWISQviVttrU)
				{
					goto IL_00af;
				}
				goto case 9;
			case 1:
				OcbiQPzVmOYLvnIHKGeFOGDLIq();
				num = 1419661198;
				continue;
			case 6:
				goto IL_00d7;
			case 3:
				if (YHNnglSbiAkeQnlrirNsMoGVHKKC)
				{
					goto IL_00fb;
				}
				goto case 2;
			case 12:
				goto IL_0112;
			case 2:
				if (yNNTIZOmHinEmVhkyBZxayFLrNX == IntPtr.Zero)
				{
					yNNTIZOmHinEmVhkyBZxayFLrNX = YNNTIZOmHinEmVhkyBZxayFLrNX;
					num = 1419661190;
					continue;
				}
				goto case 13;
			case 10:
				if (!YHNnglSbiAkeQnlrirNsMoGVHKKC)
				{
					afYzpNmcevgfPcdKdrkMjkNalEP();
					num = 1419661184;
					continue;
				}
				goto case 11;
			case 9:
				if (iaXhnaMGCLQqOuWQHTvcfoKYvgL == IntPtr.Zero)
				{
					iaXhnaMGCLQqOuWQHTvcfoKYvgL = IaXhnaMGCLQqOuWQHTvcfoKYvgL;
					num = 1419661187;
					continue;
				}
				goto case 8;
			case 11:
				if (iyGFwvImCbxxsRCfTTBNAxyjqRK && !ejBBccpNHnJqlARgWISQviVttrU)
				{
					mKKDHxcxLqHRKArgmNxVZDasEHXO();
				}
				return;
			case 4:
				bVxMTZivDFHtTShPGrdWuAdCjlYb(bAeUJildHBuOCKoLdjiIBEKHyMJH, out num3);
				if (RixhOtXDbSIOhYkJycehgIXDBbxD)
				{
					flag = !zEwUhguYbtmfSmywTFwTYcHWGKn(ControllerType.Mouse, bAeUJildHBuOCKoLdjiIBEKHyMJH, num3, out yNNTIZOmHinEmVhkyBZxayFLrNX);
					num = 1419661192;
					continue;
				}
				goto IL_00d7;
			case 13:
				xraULGRhnRKydNbPOewejXVrdHIj(yNNTIZOmHinEmVhkyBZxayFLrNX);
				num = 1419661197;
				continue;
			case 5:
				if (ejBBccpNHnJqlARgWISQviVttrU)
				{
					hXRWTlpXcKqaJdsEdDugoHsavEv();
					num = 1419661189;
					continue;
				}
				return;
			case 14:
				return;
			}
			break;
			IL_00fb:
			int num4;
			if (!flag)
			{
				num = 1419661193;
				num4 = num;
			}
			else
			{
				num = 1419661197;
				num4 = num;
			}
			continue;
			IL_00d7:
			int num5;
			if (!iyGFwvImCbxxsRCfTTBNAxyjqRK)
			{
				num = 1419661189;
				num5 = num;
			}
			else
			{
				num = 1419661195;
				num5 = num;
			}
			continue;
			IL_00af:
			int num6;
			if (flag2)
			{
				num = 1419661189;
				num6 = num;
			}
			else
			{
				num = 1419661186;
				num6 = num;
			}
		}
		goto IL_0012;
		IL_0112:
		int num7;
		if (!RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			num = 1419661184;
			num7 = num;
		}
		else
		{
			num = 1419661185;
			num7 = num;
		}
		goto IL_0017;
	}

	private void IleEIrdVLyZuYHonLwgdSICNEFg()
	{
		uint num = default(uint);
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			bVxMTZivDFHtTShPGrdWuAdCjlYb(bAeUJildHBuOCKoLdjiIBEKHyMJH, out num);
			goto IL_0017;
		}
		goto IL_0048;
		IL_0048:
		int num2;
		if (RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			int num3;
			if (YHNnglSbiAkeQnlrirNsMoGVHKKC)
			{
				num2 = 320170914;
				num3 = num2;
			}
			else
			{
				num2 = 320170918;
				num3 = num2;
			}
			goto IL_001c;
		}
		return;
		IL_0017:
		num2 = 320170915;
		goto IL_001c;
		IL_001c:
		while (true)
		{
			switch (num2 ^ 0x13156BA2)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				goto IL_0048;
			case 6:
				UrLwCqSAbxQfYZKiCtLRgXryocm();
				return;
			case 4:
				afYzpNmcevgfPcdKdrkMjkNalEP();
				num2 = 320170914;
				continue;
			case 1:
				goto IL_0087;
			case 5:
			{
				IntPtr intPtr;
				if (zEwUhguYbtmfSmywTFwTYcHWGKn(ControllerType.Mouse, bAeUJildHBuOCKoLdjiIBEKHyMJH, num, out intPtr))
				{
					if (YHNnglSbiAkeQnlrirNsMoGVHKKC)
					{
						YHNnglSbiAkeQnlrirNsMoGVHKKC = false;
						eMbIWzFttpTxHgsIHfnMqobNGATC.pXUftSdREUzmyeRlCXpOKKdpgdHr(false);
						num2 = 320170916;
						continue;
					}
					goto case 6;
				}
				return;
			}
			case 0:
				return;
			}
			break;
			IL_0087:
			int num4;
			if (!RixhOtXDbSIOhYkJycehgIXDBbxD)
			{
				num2 = 320170914;
				num4 = num2;
			}
			else
			{
				num2 = 320170919;
				num4 = num2;
			}
		}
		goto IL_0017;
	}

	private void OcbiQPzVmOYLvnIHKGeFOGDLIq()
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			goto IL_0008;
		}
		goto IL_003d;
		IL_0008:
		int num = 1982781626;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x762ED8B8)
			{
			case 3:
				break;
			case 2:
				GShxhOuwmfAJMhFPtpGKfIpVzoG.sEujjRvkTwfWCepMeUilWQwGtay(false);
				TDgXMVtxgUDifdLtnHxfcPPEZSS();
				num = 1982781625;
				continue;
			case 1:
				goto IL_003d;
			default:
				eMbIWzFttpTxHgsIHfnMqobNGATC.pXUftSdREUzmyeRlCXpOKKdpgdHr(false);
				return;
			}
			break;
		}
		goto IL_0008;
		IL_003d:
		YHNnglSbiAkeQnlrirNsMoGVHKKC = false;
		num = 1982781624;
		goto IL_000d;
	}

	private void TDgXMVtxgUDifdLtnHxfcPPEZSS()
	{
		if (!RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			return;
		}
		IntPtr yNNTIZOmHinEmVhkyBZxayFLrNX = default(IntPtr);
		IntPtr intPtr = default(IntPtr);
		while (true)
		{
			int num = -2090292129;
			while (true)
			{
				int num5;
				switch (num ^ -2090292130)
				{
				case 5:
					break;
				case 2:
					if (FgHZkoRGNeioFjCybKVqAjFHQgHv)
					{
						uint num3;
						bVxMTZivDFHtTShPGrdWuAdCjlYb(bAeUJildHBuOCKoLdjiIBEKHyMJH, out num3);
						int num4;
						if (!zEwUhguYbtmfSmywTFwTYcHWGKn(ControllerType.Mouse, bAeUJildHBuOCKoLdjiIBEKHyMJH, num3, out yNNTIZOmHinEmVhkyBZxayFLrNX))
						{
							num = -2090292135;
							num4 = num;
						}
						else
						{
							num = -2090292130;
							num4 = num;
						}
						continue;
					}
					goto case 3;
				case 6:
					return;
				case 7:
					intPtr = YNNTIZOmHinEmVhkyBZxayFLrNX;
					num = -2090292134;
					continue;
				case 1:
				{
					int num2;
					if (ihXRVCsIkdJEbzKinpeeMxhGLFZ != xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
					{
						num = -2090292136;
						num2 = num;
					}
					else
					{
						num = -2090292132;
						num2 = num;
					}
					continue;
				}
				case 3:
					intPtr = JBXHRSYUePslTBUiRmNOkdLSed.BwcrcaWbYgaFuQmgRzzaiBJGcym();
					num = -2090292134;
					continue;
				case 0:
					YNNTIZOmHinEmVhkyBZxayFLrNX = yNNTIZOmHinEmVhkyBZxayFLrNX;
					num = -2090292135;
					continue;
				default:
					{
						if (intPtr != IntPtr.Zero)
						{
							bool flag = false;
							try
							{
								VirXhLPnLrtadNhOAiqyporSIM.MyYGSzGiuRyxsicfgFoCuyusEhZU((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)2, vXVSNJdznuphRZYiycRXyyfwiqm.zTozNJMwCSwBpjmMUpCdiPrRSkY, intPtr);
							}
							catch
							{
								flag = true;
							}
							if (!flag)
							{
								return;
							}
							goto IL_00f0;
						}
						goto IL_0125;
					}
					IL_0125:
					if (YHNnglSbiAkeQnlrirNsMoGVHKKC)
					{
						vUUMKZtIgRrMCrRmCkytOxoQtYu vUUMKZtIgRrMCrRmCkytOxoQtYu2 = new vUUMKZtIgRrMCrRmCkytOxoQtYu();
						vUUMKZtIgRrMCrRmCkytOxoQtYu2.SWFAUtHYklQthaDjRqSllRDLXqH = false;
						rtbhfSljccJoGUdoSADgOEXcnrG(vUUMKZtIgRrMCrRmCkytOxoQtYu2.NreKXalMJBRVBZRrPKuowwTClRm, true);
						if (vUUMKZtIgRrMCrRmCkytOxoQtYu2.SWFAUtHYklQthaDjRqSllRDLXqH)
						{
							Rewired.Logger.LogError("Failed to unregister mouse.", true);
							num5 = -2090292132;
							goto IL_00f5;
						}
						return;
					}
					return;
					IL_00f5:
					switch (num5 ^ -2090292130)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						Rewired.Logger.LogError("Failed to unregister mouse.", true);
						return;
					case 1:
						goto IL_0125;
					case 2:
						return;
					}
					goto IL_00f0;
					IL_00f0:
					num5 = -2090292131;
					goto IL_00f5;
				}
				break;
			}
		}
	}

	private void xraULGRhnRKydNbPOewejXVrdHIj(IntPtr P_0)
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ != xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			return;
		}
		while (true)
		{
			afYzpNmcevgfPcdKdrkMjkNalEP();
			if (!(P_0 != IntPtr.Zero) || !(P_0 != KJUTrRbTQqneRBOioInbwQPtaIX.Handle))
			{
				break;
			}
			YNNTIZOmHinEmVhkyBZxayFLrNX = P_0;
			int num = -994720414;
			while (true)
			{
				switch (num ^ -994720413)
				{
				case 0:
					num = -994720415;
					continue;
				default:
					return;
				case 2:
					break;
				case 1:
					GShxhOuwmfAJMhFPtpGKfIpVzoG.GfrwOJFipjEKGxtQVhueAoEKzWK(YNNTIZOmHinEmVhkyBZxayFLrNX, true);
					num = -994720416;
					continue;
				case 3:
					return;
				}
				break;
			}
		}
	}

	private void UrLwCqSAbxQfYZKiCtLRgXryocm()
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			afYzpNmcevgfPcdKdrkMjkNalEP();
			GShxhOuwmfAJMhFPtpGKfIpVzoG.GfrwOJFipjEKGxtQVhueAoEKzWK(OGnBNGilhCjKIPhgnSWLQRSkDNe.value, true);
		}
	}

	private void afYzpNmcevgfPcdKdrkMjkNalEP()
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			goto IL_000b;
		}
		goto IL_00c1;
		IL_000b:
		int num = 1755163970;
		goto IL_0010;
		IL_0010:
		bFoKTBVyQFNLXnVXMumVNuLVvQe bFoKTBVyQFNLXnVXMumVNuLVvQe2 = default(bFoKTBVyQFNLXnVXMumVNuLVvQe);
		while (true)
		{
			switch (num ^ 0x689DAD47)
			{
			case 3:
				break;
			default:
				return;
			case 7:
				Rewired.Logger.LogError("Failed to register mouse.", true);
				YHNnglSbiAkeQnlrirNsMoGVHKKC = false;
				num = 1755163973;
				continue;
			case 6:
				return;
			case 5:
				bFoKTBVyQFNLXnVXMumVNuLVvQe2 = new bFoKTBVyQFNLXnVXMumVNuLVvQe();
				bFoKTBVyQFNLXnVXMumVNuLVvQe2.iidCZOgulnzjWMumhFnWTPbnqlMV = this;
				bFoKTBVyQFNLXnVXMumVNuLVvQe2.SWFAUtHYklQthaDjRqSllRDLXqH = false;
				rtbhfSljccJoGUdoSADgOEXcnrG(bFoKTBVyQFNLXnVXMumVNuLVvQe2.TvhVFeIJgQNueTdENGPvaISxcZIG, true);
				num = 1755163974;
				continue;
			case 2:
				eMbIWzFttpTxHgsIHfnMqobNGATC.pXUftSdREUzmyeRlCXpOKKdpgdHr(false);
				num = 1755163969;
				continue;
			case 1:
				goto IL_00a5;
			case 4:
				goto IL_00c1;
			case 0:
				return;
			}
			break;
			IL_00a5:
			int num2;
			if (bFoKTBVyQFNLXnVXMumVNuLVvQe2.SWFAUtHYklQthaDjRqSllRDLXqH)
			{
				num = 1755163968;
				num2 = num;
			}
			else
			{
				num = 1755163971;
				num2 = num;
			}
		}
		goto IL_000b;
		IL_00c1:
		if (!YHNnglSbiAkeQnlrirNsMoGVHKKC)
		{
			YHNnglSbiAkeQnlrirNsMoGVHKKC = true;
			eMbIWzFttpTxHgsIHfnMqobNGATC.pXUftSdREUzmyeRlCXpOKKdpgdHr(true);
			num = 1755163975;
			goto IL_0010;
		}
	}

	private bool bVxMTZivDFHtTShPGrdWuAdCjlYb(ngaXGIsZAMbpNYRErIyxdcfTICS P_0, out uint P_1)
	{
		P_1 = 0u;
		if (P_0 == null)
		{
			return false;
		}
		uint maxDevices = (uint)P_0.maxDevices;
		P_1 = JBXHRSYUePslTBUiRmNOkdLSed.bVxMTZivDFHtTShPGrdWuAdCjlYb(P_0, ref maxDevices, (uint)P_0.structSize);
		return P_1 != 0;
	}

	private bool zEwUhguYbtmfSmywTFwTYcHWGKn(ControllerType P_0, ngaXGIsZAMbpNYRErIyxdcfTICS P_1, uint P_2, out IntPtr P_3)
	{
		P_3 = IntPtr.Zero;
		if (P_1 == null)
		{
			goto IL_000f;
		}
		int num = 0;
		int num2 = -1389628480;
		goto IL_0014;
		IL_0014:
		jwHOncCOjHkdhQeuQmvUMQnzhjy jwHOncCOjHkdhQeuQmvUMQnzhjy2 = default(jwHOncCOjHkdhQeuQmvUMQnzhjy);
		ControllerType controllerType = default(ControllerType);
		while (true)
		{
			switch (num2 ^ -1389628473)
			{
			case 0:
				break;
			case 4:
				return false;
			case 1:
				if (jwHOncCOjHkdhQeuQmvUMQnzhjy2.WmtUGOFEZXlJDeownvmsmDErLwz == 1)
				{
					num2 = -1389628479;
					continue;
				}
				goto IL_00ae;
			case 5:
				if (jwHOncCOjHkdhQeuQmvUMQnzhjy2.CZzFxmqlmJjjVIdYppEAiCkwSwBD == 2 && jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe != IntPtr.Zero && jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe != KJUTrRbTQqneRBOioInbwQPtaIX.Handle)
				{
					P_3 = jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe;
					return true;
				}
				goto IL_00ae;
			case 8:
				if (jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe != KJUTrRbTQqneRBOioInbwQPtaIX.Handle)
				{
					P_3 = jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe;
					return true;
				}
				goto IL_00ae;
			case 6:
				if (jwHOncCOjHkdhQeuQmvUMQnzhjy2.CZzFxmqlmJjjVIdYppEAiCkwSwBD == 6 && jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe != IntPtr.Zero)
				{
					num2 = -1389628465;
					continue;
				}
				goto IL_00ae;
			case 7:
			{
				int num3;
				if (num >= P_2)
				{
					num2 = -1389628476;
					num3 = num2;
				}
				else
				{
					num2 = -1389628475;
					num3 = num2;
				}
				continue;
			}
			case 2:
			{
				IntPtr pointer = P_1.GetPointer(num * P_1.structSize);
				jwHOncCOjHkdhQeuQmvUMQnzhjy2 = jwHOncCOjHkdhQeuQmvUMQnzhjy.PvNFXGvQnaaWthCSEipVjxZGLEKc(pointer);
				controllerType = P_0;
				num2 = -1389628466;
				continue;
			}
			case 9:
				switch (controllerType)
				{
				case ControllerType.Keyboard:
					break;
				default:
					goto IL_00ae;
				case ControllerType.Mouse:
					goto IL_00e5;
				}
				goto case 1;
			default:
				{
					return false;
				}
				IL_00e5:
				if (jwHOncCOjHkdhQeuQmvUMQnzhjy2.WmtUGOFEZXlJDeownvmsmDErLwz == 1)
				{
					num2 = -1389628478;
					continue;
				}
				goto IL_00ae;
				IL_00ae:
				num++;
				num2 = -1389628480;
				continue;
			}
			break;
		}
		goto IL_000f;
		IL_000f:
		num2 = -1389628477;
		goto IL_0014;
	}

	private IntPtr wbIpkocVmsqaDaopnUIqZQxSlJ()
	{
		ngaXGIsZAMbpNYRErIyxdcfTICS ngaXGIsZAMbpNYRErIyxdcfTICS2 = new ngaXGIsZAMbpNYRErIyxdcfTICS(jwHOncCOjHkdhQeuQmvUMQnzhjy.SizeInBytes, 100);
		jwHOncCOjHkdhQeuQmvUMQnzhjy jwHOncCOjHkdhQeuQmvUMQnzhjy2 = default(jwHOncCOjHkdhQeuQmvUMQnzhjy);
		uint num3 = default(uint);
		uint maxDevices = default(uint);
		int num2 = default(int);
		IntPtr pointer = default(IntPtr);
		while (true)
		{
			int num = -526072273;
			while (true)
			{
				switch (num ^ -526072276)
				{
				case 8:
					break;
				case 4:
					return jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe;
				case 7:
					Rewired.Logger.Log("flags = " + jwHOncCOjHkdhQeuQmvUMQnzhjy2.rgNOkrpmhiGBrLTBaaLZBGFVYBc);
					Rewired.Logger.Log("target = " + jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe);
					num = -526072283;
					continue;
				case 11:
					num3 = JBXHRSYUePslTBUiRmNOkdLSed.bVxMTZivDFHtTShPGrdWuAdCjlYb(ngaXGIsZAMbpNYRErIyxdcfTICS2, ref maxDevices, (uint)ngaXGIsZAMbpNYRErIyxdcfTICS2.structSize);
					if (num3 == 0)
					{
						return IntPtr.Zero;
					}
					num2 = 0;
					num = -526072274;
					continue;
				case 5:
					Rewired.Logger.Log("RI DEVICE " + num2);
					num = -526072275;
					continue;
				case 9:
					if (jwHOncCOjHkdhQeuQmvUMQnzhjy2.WmtUGOFEZXlJDeownvmsmDErLwz == 1 && jwHOncCOjHkdhQeuQmvUMQnzhjy2.CZzFxmqlmJjjVIdYppEAiCkwSwBD == 2)
					{
						num = -526072276;
						continue;
					}
					goto IL_005a;
				case 3:
					maxDevices = (uint)ngaXGIsZAMbpNYRErIyxdcfTICS2.maxDevices;
					num = -526072281;
					continue;
				case 10:
					pointer = ngaXGIsZAMbpNYRErIyxdcfTICS2.GetPointer(num2 * ngaXGIsZAMbpNYRErIyxdcfTICS2.structSize);
					num = -526072278;
					continue;
				case 0:
					if (jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe != IntPtr.Zero && jwHOncCOjHkdhQeuQmvUMQnzhjy2.WiqjKtJlNziKSgjomSJyKjDHuTe != KJUTrRbTQqneRBOioInbwQPtaIX.Handle)
					{
						num = -526072280;
						continue;
					}
					goto IL_005a;
				case 6:
					jwHOncCOjHkdhQeuQmvUMQnzhjy2 = jwHOncCOjHkdhQeuQmvUMQnzhjy.PvNFXGvQnaaWthCSEipVjxZGLEKc(pointer);
					num = -526072279;
					continue;
				case 1:
					Rewired.Logger.Log("usage = " + jwHOncCOjHkdhQeuQmvUMQnzhjy2.CZzFxmqlmJjjVIdYppEAiCkwSwBD);
					Rewired.Logger.Log("usagePage = " + jwHOncCOjHkdhQeuQmvUMQnzhjy2.WmtUGOFEZXlJDeownvmsmDErLwz);
					num = -526072277;
					continue;
				default:
					{
						if (num2 >= num3)
						{
							return IntPtr.Zero;
						}
						goto case 10;
					}
					IL_005a:
					num2++;
					num = -526072274;
					continue;
				}
				break;
			}
		}
	}

	private void CmPUVIRubavozFqnLuRGJGPSvTK(IntPtr P_0)
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ != xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			goto IL_0008;
		}
		goto IL_0064;
		IL_0008:
		int num = 2090304148;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x7C978295)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 4:
				if (P_0 != IntPtr.Zero && P_0 != KJUTrRbTQqneRBOioInbwQPtaIX.Handle)
				{
					IaXhnaMGCLQqOuWQHTvcfoKYvgL = P_0;
					num = 2090304151;
					continue;
				}
				return;
			case 0:
				goto IL_0064;
			case 2:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_0064:
		mKKDHxcxLqHRKArgmNxVZDasEHXO();
		num = 2090304145;
		goto IL_000d;
	}

	private void fYVQfmlzHrABPDELJdFEcFnDldZG()
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ != xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			goto IL_0008;
		}
		goto IL_0032;
		IL_0008:
		int num = 1250850476;
		goto IL_000d;
		IL_000d:
		switch (num ^ 0x4A8E76AD)
		{
		case 3:
			break;
		default:
			return;
		case 1:
			return;
		case 2:
			goto IL_0032;
		case 0:
			return;
		}
		goto IL_0008;
		IL_0032:
		mKKDHxcxLqHRKArgmNxVZDasEHXO();
		num = 1250850477;
		goto IL_000d;
	}

	private void mKKDHxcxLqHRKArgmNxVZDasEHXO()
	{
		lFMPOQAqYwkNkIehJmGCLFAenXr lFMPOQAqYwkNkIehJmGCLFAenXr2 = default(lFMPOQAqYwkNkIehJmGCLFAenXr);
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			lFMPOQAqYwkNkIehJmGCLFAenXr2 = new lFMPOQAqYwkNkIehJmGCLFAenXr();
			lFMPOQAqYwkNkIehJmGCLFAenXr2.iidCZOgulnzjWMumhFnWTPbnqlMV = this;
			lFMPOQAqYwkNkIehJmGCLFAenXr2.SWFAUtHYklQthaDjRqSllRDLXqH = false;
			rtbhfSljccJoGUdoSADgOEXcnrG(lFMPOQAqYwkNkIehJmGCLFAenXr2.YOOqAbkltVAhEhqRTmSrdnACOXyF, true);
			goto IL_002f;
		}
		goto IL_0059;
		IL_0059:
		int num;
		int num2;
		if (ejBBccpNHnJqlARgWISQviVttrU)
		{
			num = 536881275;
			num2 = num;
		}
		else
		{
			num = 536881274;
			num2 = num;
		}
		goto IL_0034;
		IL_002f:
		num = 536881278;
		goto IL_0034;
		IL_0034:
		while (true)
		{
			switch (num ^ 0x2000287F)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				goto IL_0059;
			case 5:
				ejBBccpNHnJqlARgWISQviVttrU = true;
				HyJfhRFtuFqKrFdhDGBoOIpRRvkc.pXUftSdREUzmyeRlCXpOKKdpgdHr(true);
				num = 536881275;
				continue;
			case 1:
				if (lFMPOQAqYwkNkIehJmGCLFAenXr2.SWFAUtHYklQthaDjRqSllRDLXqH)
				{
					Rewired.Logger.LogError("Failed to register keyboard.", true);
					ejBBccpNHnJqlARgWISQviVttrU = false;
					HyJfhRFtuFqKrFdhDGBoOIpRRvkc.pXUftSdREUzmyeRlCXpOKKdpgdHr(false);
					num = 536881279;
					continue;
				}
				goto IL_0059;
			case 0:
				return;
			case 4:
				return;
			}
			break;
		}
		goto IL_002f;
	}

	private void hXRWTlpXcKqaJdsEdDugoHsavEv()
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			nUXcUiuitlMdvAivRsCQyfNUQnZ();
			goto IL_000e;
		}
		goto IL_002c;
		IL_002c:
		ejBBccpNHnJqlARgWISQviVttrU = false;
		int num = 1444705769;
		goto IL_0013;
		IL_000e:
		num = 1444705770;
		goto IL_0013;
		IL_0013:
		switch (num ^ 0x561C75E8)
		{
		case 0:
			break;
		case 2:
			goto IL_002c;
		default:
			HyJfhRFtuFqKrFdhDGBoOIpRRvkc.pXUftSdREUzmyeRlCXpOKKdpgdHr(false);
			return;
		}
		goto IL_000e;
	}

	private void nUXcUiuitlMdvAivRsCQyfNUQnZ()
	{
		if (!iyGFwvImCbxxsRCfTTBNAxyjqRK)
		{
			return;
		}
		IntPtr intPtr = default(IntPtr);
		while (true)
		{
			int num = -289666407;
			while (true)
			{
				int num3;
				switch (num ^ -289666405)
				{
				case 0:
					break;
				case 1:
					intPtr = JBXHRSYUePslTBUiRmNOkdLSed.BwcrcaWbYgaFuQmgRzzaiBJGcym();
					num = -289666401;
					continue;
				case 3:
				{
					if (!FgHZkoRGNeioFjCybKVqAjFHQgHv)
					{
						goto case 1;
					}
					uint num4;
					bVxMTZivDFHtTShPGrdWuAdCjlYb(bAeUJildHBuOCKoLdjiIBEKHyMJH, out num4);
					IntPtr iaXhnaMGCLQqOuWQHTvcfoKYvgL;
					if (zEwUhguYbtmfSmywTFwTYcHWGKn(ControllerType.Keyboard, bAeUJildHBuOCKoLdjiIBEKHyMJH, num4, out iaXhnaMGCLQqOuWQHTvcfoKYvgL))
					{
						IaXhnaMGCLQqOuWQHTvcfoKYvgL = iaXhnaMGCLQqOuWQHTvcfoKYvgL;
						num = -289666403;
						continue;
					}
					goto case 6;
				}
				case 5:
					return;
				case 2:
				{
					int num2;
					if (ihXRVCsIkdJEbzKinpeeMxhGLFZ != xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
					{
						num = -289666402;
						num2 = num;
					}
					else
					{
						num = -289666408;
						num2 = num;
					}
					continue;
				}
				case 6:
					intPtr = IaXhnaMGCLQqOuWQHTvcfoKYvgL;
					num = -289666401;
					continue;
				default:
					{
						if (intPtr != IntPtr.Zero)
						{
							bool flag = false;
							try
							{
								VirXhLPnLrtadNhOAiqyporSIM.MyYGSzGiuRyxsicfgFoCuyusEhZU((rkWDFIFhfEYYfewtCEiNcoZAcHX)1, (MfbJCQtTuFJHamEmynNyXrrBdib)6, vXVSNJdznuphRZYiycRXyyfwiqm.zTozNJMwCSwBpjmMUpCdiPrRSkY, intPtr);
							}
							catch
							{
								flag = true;
							}
							if (!flag)
							{
								return;
							}
							goto IL_00d5;
						}
						goto IL_010a;
					}
					IL_010a:
					if (ejBBccpNHnJqlARgWISQviVttrU)
					{
						yjyRQIAAcHtekMhWABNssXHLbcXk yjyRQIAAcHtekMhWABNssXHLbcXk2 = new yjyRQIAAcHtekMhWABNssXHLbcXk();
						yjyRQIAAcHtekMhWABNssXHLbcXk2.SWFAUtHYklQthaDjRqSllRDLXqH = false;
						rtbhfSljccJoGUdoSADgOEXcnrG(yjyRQIAAcHtekMhWABNssXHLbcXk2.LzSzQyXaGupHItAkvjkfXCipJjH, true);
						if (yjyRQIAAcHtekMhWABNssXHLbcXk2.SWFAUtHYklQthaDjRqSllRDLXqH)
						{
							Rewired.Logger.LogError("Failed to unregister keyboard.", true);
							num3 = -289666408;
							goto IL_00da;
						}
						return;
					}
					return;
					IL_00da:
					switch (num3 ^ -289666405)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						Rewired.Logger.LogError("Failed to unregister keyboard.", true);
						return;
					case 1:
						goto IL_010a;
					case 3:
						return;
					}
					goto IL_00d5;
					IL_00d5:
					num3 = -289666407;
					goto IL_00da;
				}
				break;
			}
		}
	}

	private void QbJsDNKFKzcDzFTiuIarQfBqxTN()
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			if (RixhOtXDbSIOhYkJycehgIXDBbxD)
			{
				OcbiQPzVmOYLvnIHKGeFOGDLIq();
				goto IL_0016;
			}
			goto IL_0040;
		}
		goto IL_004d;
		IL_0040:
		QrclNCSCIhUWTPexBHlYCsTcsYv();
		int num = -276320974;
		goto IL_001b;
		IL_004d:
		if (RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			OcbiQPzVmOYLvnIHKGeFOGDLIq();
			num = -276320969;
			goto IL_001b;
		}
		return;
		IL_0016:
		num = -276320970;
		goto IL_001b;
		IL_001b:
		while (true)
		{
			switch (num ^ -276320973)
			{
			case 0:
				break;
			default:
				return;
			case 5:
				goto IL_0040;
			case 2:
				goto IL_004d;
			case 1:
				if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
				{
					hXRWTlpXcKqaJdsEdDugoHsavEv();
					num = -276320976;
					continue;
				}
				return;
			case 3:
				return;
			case 4:
				return;
			}
			break;
		}
		goto IL_0016;
	}

	private void mOmoxdImuRnVvdtslWhhxAJkIUQ()
	{
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			VirXhLPnLrtadNhOAiqyporSIM.RawInput += VAodYJDLRwaSItXUUwJAkGpZeTKg;
			goto IL_0019;
		}
		goto IL_003f;
		IL_003f:
		int num;
		int num2;
		if (!RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			num = 946822099;
			num2 = num;
		}
		else
		{
			num = 946822100;
			num2 = num;
		}
		goto IL_001e;
		IL_0019:
		num = 946822102;
		goto IL_001e;
		IL_001e:
		while (true)
		{
			switch (num ^ 0x386F5BD7)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_003f;
			case 4:
				if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
				{
					VirXhLPnLrtadNhOAiqyporSIM.KeyboardInput += niEDHflEIdWOQxqgXyEkcgptbIra;
					num = 946822101;
					continue;
				}
				return;
			case 3:
				VirXhLPnLrtadNhOAiqyporSIM.MouseInput += RZiOPwHADktvNaJjmFjYxVWqpFh;
				num = 946822099;
				continue;
			case 2:
				return;
			}
			break;
		}
		goto IL_0019;
	}

	private void DoDgndeIMkqVpmHuPeNxwhgyLBs()
	{
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			goto IL_0008;
		}
		goto IL_004e;
		IL_0008:
		int num = 461866814;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x1B87873F)
			{
			case 3:
				break;
			default:
				return;
			case 4:
				goto IL_002e;
			case 2:
				goto IL_004e;
			case 1:
				VirXhLPnLrtadNhOAiqyporSIM.RawInput -= VAodYJDLRwaSItXUUwJAkGpZeTKg;
				num = 461866813;
				continue;
			case 0:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_002e:
		if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
		{
			VirXhLPnLrtadNhOAiqyporSIM.KeyboardInput -= niEDHflEIdWOQxqgXyEkcgptbIra;
			num = 461866815;
			goto IL_000d;
		}
		return;
		IL_004e:
		if (RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			VirXhLPnLrtadNhOAiqyporSIM.MouseInput -= RZiOPwHADktvNaJjmFjYxVWqpFh;
			num = 461866811;
			goto IL_000d;
		}
		goto IL_002e;
	}

	private void jMaxEjuUEYbFXfmvulQkNFoeuPX(ypRryIywRrvtKyGzmsiTAVfBgMf.yRxsQBSSzqeDQDwfDLSsblxFeaei P_0)
	{
		juPLKwiydNthFgwHKtmeOsZdDBB juPLKwiydNthFgwHKtmeOsZdDBB2 = new juPLKwiydNthFgwHKtmeOsZdDBB();
		while (true)
		{
			int num = 1687429501;
			while (true)
			{
				switch (num ^ 0x6494217C)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					goto IL_0028;
				case 3:
					if (juPLKwiydNthFgwHKtmeOsZdDBB2.SWFAUtHYklQthaDjRqSllRDLXqH)
					{
						throw new Exception("Error creating message window.");
					}
					return;
				case 2:
					return;
				}
				break;
				IL_0028:
				juPLKwiydNthFgwHKtmeOsZdDBB2.lwDuaACtnTDlAaZIkstOGaLKKJTi = P_0;
				juPLKwiydNthFgwHKtmeOsZdDBB2.iidCZOgulnzjWMumhFnWTPbnqlMV = this;
				juPLKwiydNthFgwHKtmeOsZdDBB2.SWFAUtHYklQthaDjRqSllRDLXqH = false;
				rtbhfSljccJoGUdoSADgOEXcnrG(juPLKwiydNthFgwHKtmeOsZdDBB2.eDpSQJbSeUcChVHIMSWBYAhQRiQ, true);
				num = 1687429503;
			}
		}
	}

	private static ypRryIywRrvtKyGzmsiTAVfBgMf yGMONCxAxAlxeTcfaiHrNqPbusn(ypRryIywRrvtKyGzmsiTAVfBgMf.yRxsQBSSzqeDQDwfDLSsblxFeaei P_0)
	{
		ypRryIywRrvtKyGzmsiTAVfBgMf ypRryIywRrvtKyGzmsiTAVfBgMf2 = new ypRryIywRrvtKyGzmsiTAVfBgMf("RewiredMesssageWindow", true, P_0);
		if (ypRryIywRrvtKyGzmsiTAVfBgMf2.Handle == IntPtr.Zero)
		{
			ypRryIywRrvtKyGzmsiTAVfBgMf2.Dispose();
			return null;
		}
		return ypRryIywRrvtKyGzmsiTAVfBgMf2;
	}

	private void FvjazacAeiGVqGiWbhHkbAbBTEz()
	{
		if (ihXRVCsIkdJEbzKinpeeMxhGLFZ != xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			goto IL_0008;
		}
		goto IL_0057;
		IL_0008:
		int num = -1529805568;
		goto IL_000d;
		IL_000d:
		while (true)
		{
			switch (num ^ -1529805560)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				YhRjkeWsVRIxhnXdWIYqEbsIblLK = GShxhOuwmfAJMhFPtpGKfIpVzoG.liiqJcAxkRdvHiVaEyfRrNMtQJ();
				num = -1529805553;
				continue;
			case 6:
				goto IL_0057;
			case 9:
				goto IL_0071;
			case 5:
				if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
				{
					fYVQfmlzHrABPDELJdFEcFnDldZG();
					num = -1529805559;
					continue;
				}
				goto case 1;
			case 3:
				goto IL_00b4;
			case 8:
				return;
			case 4:
				goto IL_00e3;
			case 0:
				UrLwCqSAbxQfYZKiCtLRgXryocm();
				num = -1529805555;
				continue;
			case 7:
				return;
			}
			break;
		}
		goto IL_0008;
		IL_00b4:
		if (!RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			int num2;
			if (!iyGFwvImCbxxsRCfTTBNAxyjqRK)
			{
				num = -1529805559;
				num2 = num;
			}
			else
			{
				num = -1529805567;
				num2 = num;
			}
			goto IL_000d;
		}
		goto IL_0071;
		IL_0057:
		GShxhOuwmfAJMhFPtpGKfIpVzoG.GVPNrpnUrcRcuBVNsoUmnQYWdWW();
		if (jknBiNnVvBEJUrrzYJXBYRgRbau)
		{
			EnrFFHfVSHjlhXSpuPszsaBcZaGE();
			num = -1529805557;
			goto IL_000d;
		}
		goto IL_00b4;
		IL_00e3:
		int num3;
		if (RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			num = -1529805560;
			num3 = num;
		}
		else
		{
			num = -1529805555;
			num3 = num;
		}
		goto IL_000d;
		IL_0071:
		bAeUJildHBuOCKoLdjiIBEKHyMJH = new ngaXGIsZAMbpNYRErIyxdcfTICS(jwHOncCOjHkdhQeuQmvUMQnzhjy.SizeInBytes, 100);
		if (FgHZkoRGNeioFjCybKVqAjFHQgHv)
		{
			hMmfqHsFLqCphWyBKmofLIlkGHEC = 1;
			num = -1529805559;
			goto IL_000d;
		}
		goto IL_00e3;
	}

	private void iRpcqsJBbVYdTtvDMZLVmPmOBWjd()
	{
		if (!FgHZkoRGNeioFjCybKVqAjFHQgHv)
		{
			return;
		}
		while (ihXRVCsIkdJEbzKinpeeMxhGLFZ == xVicVIItBLtQkfldKrNymeScMdI.JEEknwYCLsZASYQuvIBRbmcdFjSC)
		{
			while (true)
			{
				if (hMmfqHsFLqCphWyBKmofLIlkGHEC > 0)
				{
					hMmfqHsFLqCphWyBKmofLIlkGHEC--;
					return;
				}
				while (true)
				{
					IL_0075:
					uint num;
					bVxMTZivDFHtTShPGrdWuAdCjlYb(bAeUJildHBuOCKoLdjiIBEKHyMJH, out num);
					int num2;
					if (RixhOtXDbSIOhYkJycehgIXDBbxD)
					{
						IntPtr intPtr;
						zEwUhguYbtmfSmywTFwTYcHWGKn(ControllerType.Mouse, bAeUJildHBuOCKoLdjiIBEKHyMJH, num, out intPtr);
						xraULGRhnRKydNbPOewejXVrdHIj(intPtr);
						num2 = 1834240862;
						goto IL_0011;
					}
					goto IL_003d;
					IL_0011:
					while (true)
					{
						switch (num2 ^ 0x6D544B5D)
						{
						case 6:
							num2 = 1834240860;
							continue;
						case 3:
							break;
						case 5:
							goto end_IL_0075;
						case 0:
							goto IL_0075;
						case 2:
						{
							IntPtr intPtr2;
							zEwUhguYbtmfSmywTFwTYcHWGKn(ControllerType.Keyboard, bAeUJildHBuOCKoLdjiIBEKHyMJH, num, out intPtr2);
							CmPUVIRubavozFqnLuRGJGPSvTK(intPtr2);
							num2 = 1834240857;
							continue;
						}
						case 1:
							goto end_IL_0056;
						default:
							hMmfqHsFLqCphWyBKmofLIlkGHEC = -1;
							return;
						}
						break;
					}
					goto IL_003d;
					IL_003d:
					int num3;
					if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
					{
						num2 = 1834240863;
						num3 = num2;
					}
					else
					{
						num2 = 1834240857;
						num3 = num2;
					}
					goto IL_0011;
					continue;
					end_IL_0075:
					break;
				}
				continue;
				end_IL_0056:
				break;
			}
		}
	}

	private void DLTFanHosVFQyNYyrhNCojhkrWu(bool P_0)
	{
		if (RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			UrLwCqSAbxQfYZKiCtLRgXryocm();
			goto IL_000e;
		}
		goto IL_002c;
		IL_002c:
		int num;
		if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
		{
			mKKDHxcxLqHRKArgmNxVZDasEHXO();
			num = 1930971680;
			goto IL_0013;
		}
		return;
		IL_000e:
		num = 1930971683;
		goto IL_0013;
		IL_0013:
		switch (num ^ 0x73184A21)
		{
		case 0:
			break;
		default:
			return;
		case 2:
			goto IL_002c;
		case 1:
			return;
		}
		goto IL_000e;
	}

	private void LYEsvEzZuwjEBpzdFIeRSBbfrJR(FullScreenMode P_0)
	{
		if (RixhOtXDbSIOhYkJycehgIXDBbxD)
		{
			IleEIrdVLyZuYHonLwgdSICNEFg();
		}
	}

	private void SsSohntczkdFPRaVmVdpvXhJTUW(IntPtr P_0)
	{
		if (FgHZkoRGNeioFjCybKVqAjFHQgHv)
		{
			return;
		}
		while (true)
		{
			int num = -1673090382;
			while (true)
			{
				switch (num ^ -1673090383)
				{
				case 0:
					break;
				default:
					return;
				case 3:
					if (RixhOtXDbSIOhYkJycehgIXDBbxD)
					{
						UrLwCqSAbxQfYZKiCtLRgXryocm();
						num = -1673090381;
						continue;
					}
					goto case 2;
				case 2:
					if (iyGFwvImCbxxsRCfTTBNAxyjqRK)
					{
						fYVQfmlzHrABPDELJdFEcFnDldZG();
						num = -1673090384;
						continue;
					}
					return;
				case 1:
					return;
				}
				break;
			}
		}
	}

	private IntPtr FQwjqIFMlpBaZKMILwGdtlahNsN(IntPtr P_0, uint P_1, IntPtr P_2, IntPtr P_3)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return IntPtr.Zero;
		}
		if (YhRjkeWsVRIxhnXdWIYqEbsIblLK != null)
		{
			YhRjkeWsVRIxhnXdWIYqEbsIblLK(P_0, P_1, P_2, P_3);
		}
		return IntPtr.Zero;
	}

	private void rtbhfSljccJoGUdoSADgOEXcnrG(Action P_0, bool P_1)
	{
		if (P_0 == null)
		{
			while (true)
			{
				switch (0x4325A35F ^ 0x4325A35D)
				{
				case 0:
					continue;
				case 2:
					return;
				}
				break;
			}
		}
		P_0();
	}

	private void VAodYJDLRwaSItXUUwJAkGpZeTKg(uAYVdHjoaOtSYwFnNuGXZtuOLmV P_0)
	{
		try
		{
			KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI = yUTXqGvFiWmswDlDoNizZARjOyD(yOsYsEkRiyFUYfUQFHVYzKDYlZb.iqYXuMMzjBiMvzCNsYloUSNOfix, P_0.ZWtEIVCLNCpVNyDISCnCWMsygkK);
			if (kchbyaIpiOUwIuFRWQOhqCekrdI != null)
			{
				kchbyaIpiOUwIuFRWQOhqCekrdI.UpdateValue(P_0.RawDataPtr, P_0.RawDataBytes, P_0.YqQgSSxjDeGHweRjvcaeaUtSPfk, P_0.fcUgsJEhpqEhkDbQnIYjZCBVQJTD, 0f);
			}
		}
		catch
		{
		}
	}

	private void ovucnVEJhChPcJhabdoJESJbCPNX(YbTjnhHlvsfCMxzJnRQxXqEUpng P_0)
	{
		try
		{
			KchbyaIpiOUwIuFRWQOhqCekrdI kchbyaIpiOUwIuFRWQOhqCekrdI = yUTXqGvFiWmswDlDoNizZARjOyD(yOsYsEkRiyFUYfUQFHVYzKDYlZb.iqYXuMMzjBiMvzCNsYloUSNOfix, P_0.AQmNOKwcTIznlOduiKbMFuOfccd);
			if (kchbyaIpiOUwIuFRWQOhqCekrdI == null)
			{
				while (true)
				{
					switch (-1325128264 ^ -1325128262)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			kchbyaIpiOUwIuFRWQOhqCekrdI.UpdateValue(P_0.rawDataPtr, P_0.gXZjrmdAjNIVunxHwEGaVPsMVEu, P_0.PiuIaEOMzaGghzEcmclrkXfALRi, P_0.KPVmBIOuClgsfuZzPSMLsXjYDNH, P_0.wWVJHrdPYiqspppSegjhJYwRUoy);
		}
		catch
		{
		}
	}

	private void RZiOPwHADktvNaJjmFjYxVWqpFh(YWumhJCpCQTVjskCTcIoILKEFuRI P_0)
	{
		ovctNKnlwffZNCdsOVAOWOHDZtnm.BbMlThpVHekUMrpjNzGQUGtzMyI(ref P_0);
		jiaXqoHGsOwbvPhprRRKOBOTpRS(ovctNKnlwffZNCdsOVAOWOHDZtnm);
	}

	private void jiaXqoHGsOwbvPhprRRKOBOTpRS(AnUlkbSKZTgtTTjCtVOCzQQXaiz P_0)
	{
		try
		{
			eMbIWzFttpTxHgsIHfnMqobNGATC.qDbCHnCDbcDTxgRYolAbQrAZfUj(P_0);
		}
		catch (Exception)
		{
		}
	}

	private void niEDHflEIdWOQxqgXyEkcgptbIra(fBMQoDqChRWkGFVFHdqCTvtYrQy P_0)
	{
		tRNsaxGpUiytdGkUuLLXjMAtnUb.BbMlThpVHekUMrpjNzGQUGtzMyI(ref P_0);
		qUlQCUoxgBTJhpjNkvymsDTJawlF(tRNsaxGpUiytdGkUuLLXjMAtnUb);
	}

	private void qUlQCUoxgBTJhpjNkvymsDTJawlF(bzEIwBRfuczFFAoUzMzCAMnmSUI P_0)
	{
		try
		{
			HyJfhRFtuFqKrFdhDGBoOIpRRvkc.qDbCHnCDbcDTxgRYolAbQrAZfUj(P_0);
		}
		catch
		{
		}
	}

	public void Dispose()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
		GC.SuppressFinalize(this);
	}

	~DyxPIAguqliRStlMaxHqlaZTglf()
	{
		HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
	}

	protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
	{
		if (nNxUslIcGUpqKgpPZYhuimcvWyC)
		{
			return;
		}
		int num2 = default(int);
		while (true)
		{
			DoDgndeIMkqVpmHuPeNxwhgyLBs();
			ReInput.ApplicationIsFullScreenChangedEvent -= DLTFanHosVFQyNYyrhNCojhkrWu;
			ReInput.ApplicationFullScreenModeChangedEvent -= LYEsvEzZuwjEBpzdFIeRSBbfrJR;
			int num = 1460533055;
			while (true)
			{
				switch (num ^ 0x570DF73D)
				{
				case 0:
					goto IL_0009;
				case 1:
					break;
				default:
					lock (wqkcGFNfJIdbpgKOpqiqCmzTzGvA)
					{
						if (P_0 && AvwfdLjWSYyRUfRbGOqVqadERNGK != null)
						{
							num2 = 0;
							goto IL_00c8;
						}
						goto IL_0146;
						IL_00b1:
						GShxhOuwmfAJMhFPtpGKfIpVzoG.HtJdxRxaGggkmaMTSWUpHqjZLDV();
						int num3 = 1460533055;
						goto IL_007d;
						IL_0146:
						QbJsDNKFKzcDzFTiuIarQfBqxTN();
						if (KJUTrRbTQqneRBOioInbwQPtaIX != null)
						{
							KJUTrRbTQqneRBOioInbwQPtaIX.Dispose();
							KJUTrRbTQqneRBOioInbwQPtaIX = null;
							num3 = 1460533045;
							goto IL_007d;
						}
						goto IL_0170;
						IL_00c8:
						int num4;
						if (num2 < AvwfdLjWSYyRUfRbGOqVqadERNGK.Count)
						{
							num3 = 1460533048;
							num4 = num3;
						}
						else
						{
							num3 = 1460533052;
							num4 = num3;
						}
						goto IL_007d;
						IL_00e7:
						if (iyGFwvImCbxxsRCfTTBNAxyjqRK && HyJfhRFtuFqKrFdhDGBoOIpRRvkc != null)
						{
							HyJfhRFtuFqKrFdhDGBoOIpRRvkc.Dispose();
							num3 = 1460533051;
							goto IL_007d;
						}
						goto IL_00b1;
						IL_0170:
						if (RixhOtXDbSIOhYkJycehgIXDBbxD && eMbIWzFttpTxHgsIHfnMqobNGATC != null)
						{
							eMbIWzFttpTxHgsIHfnMqobNGATC.Dispose();
							num3 = 1460533049;
							goto IL_007d;
						}
						goto IL_00e7;
						IL_007d:
						while (true)
						{
							switch (num3 ^ 0x570DF73D)
							{
							case 0:
								num3 = 1460533048;
								continue;
							case 6:
								goto IL_00b1;
							case 7:
								num2++;
								num3 = 1460533054;
								continue;
							case 3:
								goto IL_00c8;
							case 4:
								goto IL_00e7;
							case 5:
								if (AvwfdLjWSYyRUfRbGOqVqadERNGK[num2] != null)
								{
									AvwfdLjWSYyRUfRbGOqVqadERNGK[num2].Unacquire();
									AvwfdLjWSYyRUfRbGOqVqadERNGK[num2].Dispose();
									num3 = 1460533050;
									continue;
								}
								goto case 7;
							case 1:
								goto IL_0146;
							case 8:
								goto IL_0170;
							case 2:
								break;
							}
							break;
						}
					}
					nNxUslIcGUpqKgpPZYhuimcvWyC = true;
					return;
				}
				break;
				IL_0009:
				num = 1460533052;
			}
		}
	}

	[CompilerGenerated]
	private static void JRReKyhRyXxNqQGAxFAsaBqDWxBd(KchbyaIpiOUwIuFRWQOhqCekrdI P_0)
	{
		P_0.Dispose();
	}

	static DyxPIAguqliRStlMaxHqlaZTglf()
	{
		axxcxfwiAhKGHMtboHrNGJrQfYoB[] array = new axxcxfwiAhKGHMtboHrNGJrQfYoB[4];
		while (true)
		{
			int num = -167784353;
			while (true)
			{
				switch (num ^ -167784354)
				{
				case 0:
					break;
				case 1:
					goto IL_0025;
				default:
					array[3] = new axxcxfwiAhKGHMtboHrNGJrQfYoB(12, 1);
					lnsZCaqDgeSluOroxStGchbmhSo = array;
					return;
				}
				break;
				IL_0025:
				array[0] = new axxcxfwiAhKGHMtboHrNGJrQfYoB(1, 4);
				array[1] = new axxcxfwiAhKGHMtboHrNGJrQfYoB(1, 5);
				array[2] = new axxcxfwiAhKGHMtboHrNGJrQfYoB(1, 8);
				num = -167784356;
			}
		}
	}
}
