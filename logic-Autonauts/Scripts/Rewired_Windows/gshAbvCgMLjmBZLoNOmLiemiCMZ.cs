using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Libraries.SharpDX.XInput;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

internal class gshAbvCgMLjmBZLoNOmLiemiCMZ : PlatformInputManager
{
	private class JzLztiRQalmgMwsfOXIrZxwEBhm : IDisposable, IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private bool kyXDAPEfIOTZaUhOSDjXBLRcGSRu;

		private int XKdkawtumCxPyKPVBrWIuFkhbmb;

		private readonly int XVBtlXdsFBPLTxCoYRWKsbfhcUk;

		public Guid REezjTFCollnzcnDXouNnLNDkjk;

		public string HMaFDzCZyyJZjLhcCpVmgIggZoam;

		public Guid cBDIfdqFvdWzxrFEMJqjLvTvIpG;

		public Rewired.Libraries.SharpDX.XInput.DeviceType EtxqgYqtVAKZanAwGgrhAaDqdDaM;

		public XInputDeviceSubType cAssXnoeVmNPesYNhboKrFdgyng;

		public bool mqRCOGhpUhuJIDFwlHJQROPEFMrC;

		public bool vXFtSrFAbNgEaZCWOqIoweOfchwg;

		public readonly ySDWWGGPdsWqyEKpVarmlIJfpv eunhnaovDRiEguPGzwjEMBJUohX;

		public bool kgieqVsAMEifkgIdGxDGFnaOKZc;

		public bool UmCIkDDfhBkELrnhrBsuDuBUIECd;

		private int RaIckZJZsSLUbCnZyafyMyzctmC;

		private int KJdBVvDcrdFbXCYaMGYmWKQSOKQt;

		private int jHaYXdTXWAJNlfIRTMsRGaqNBpK;

		private int qOBHYZBCAkYYTJoRDdsZoTyTELA;

		private readonly float[] ZRzHEnKZrARTmYSqzudcOoQkFLn;

		private readonly bool[] vqZyMIbiZNaMpemrDPhgsXmGAKrY;

		private HardwareJoystickMap_InputManager VjkWjnwoPItHtAfScAsiHywgzcu;

		private readonly ySDWWGGPdsWqyEKpVarmlIJfpv uOtbqKcpjlZbLMgCJgbgAHYfvYsv;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lzXAqTcTNwGXhyoMQqetZTTNJGjM;

		private Action lZKxEZhZedfFzXCyfpSbNNLgSFy;

		private bool bajsMqGhZRtVJqqeQtegeORbUav;

		private bool VOmckskOqMXuJcSBuIcPcvDRBIhH;

		private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

		public string instanceName
		{
			get
			{
				string text = productName;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				return text + " " + XVBtlXdsFBPLTxCoYRWKsbfhcUk;
			}
		}

		public string productName
		{
			get
			{
				if (!isConnected)
				{
					return string.Empty;
				}
				return cAssXnoeVmNPesYNhboKrFdgyng.ToString();
			}
		}

		public bool isConnected
		{
			get
			{
				int num;
				if (eunhnaovDRiEguPGzwjEMBJUohX != null)
				{
					if (!UmCIkDDfhBkELrnhrBsuDuBUIECd)
					{
						goto IL_0010;
					}
					int num2;
					if (bajsMqGhZRtVJqqeQtegeORbUav)
					{
						num = -229862780;
						num2 = num;
					}
					else
					{
						num = -229862781;
						num2 = num;
					}
					goto IL_0015;
				}
				goto IL_0036;
				IL_0015:
				while (true)
				{
					switch (num ^ -229862777)
					{
					case 2:
						break;
					case 1:
						goto IL_0036;
					case 0:
						wNeUtkPKiMwcJCOpioDApbbYSjJ();
						num = -229862781;
						continue;
					case 3:
						goto IL_005e;
					default:
						return bajsMqGhZRtVJqqeQtegeORbUav;
					}
					break;
					IL_005e:
					int num3;
					if (!GqjCXvxcolTNemJQCMpXfQRqmSW(fcDzwnYZhuXlXPrsIuHeDFPrMbB.LhswARgbUCmSNPGkHIfoknXLeIQl))
					{
						num = -229862777;
						num3 = num;
					}
					else
					{
						num = -229862781;
						num3 = num;
					}
				}
				goto IL_0010;
				IL_0010:
				num = -229862778;
				goto IL_0015;
				IL_0036:
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return XKdkawtumCxPyKPVBrWIuFkhbmb;
			}
			set
			{
				XKdkawtumCxPyKPVBrWIuFkhbmb = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return XVBtlXdsFBPLTxCoYRWKsbfhcUk;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (kyXDAPEfIOTZaUhOSDjXBLRcGSRu)
				{
					return cAssXnoeVmNPesYNhboKrFdgyng.ToString() + " " + (XVBtlXdsFBPLTxCoYRWKsbfhcUk + 1);
				}
				return "XInput " + cAssXnoeVmNPesYNhboKrFdgyng.ToString() + " " + (XVBtlXdsFBPLTxCoYRWKsbfhcUk + 1);
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				return XVBtlXdsFBPLTxCoYRWKsbfhcUk;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId
		{
			get
			{
				return 0;
			}
		}

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			get
			{
				return null;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid
		{
			get
			{
				return cBDIfdqFvdWzxrFEMJqjLvTvIpG;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				return instanceGuid;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			eunhnaovDRiEguPGzwjEMBJUohX.qyYjHBxpYngdRISxCzkNrXWsFda(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			eunhnaovDRiEguPGzwjEMBJUohX.twqdzZItwjGSDbACYpwwOvJauhq();
		}

		public JzLztiRQalmgMwsfOXIrZxwEBhm(int systemId, bool isWin8AppStore, ySDWWGGPdsWqyEKpVarmlIJfpv sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Action deviceDisconnectedDelegate)
		{
			while (true)
			{
				int num = 1151701884;
				while (true)
				{
					switch (num ^ 0x44A5937D)
					{
					case 2:
						break;
					default:
						return;
					case 3:
						KJdBVvDcrdFbXCYaMGYmWKQSOKQt = 15;
						num = 1151701883;
						continue;
					case 0:
						kyXDAPEfIOTZaUhOSDjXBLRcGSRu = isWin8AppStore;
						num = 1151701881;
						continue;
					case 7:
						RaIckZJZsSLUbCnZyafyMyzctmC = 6;
						num = 1151701886;
						continue;
					case 1:
						uOtbqKcpjlZbLMgCJgbgAHYfvYsv = sourceJoystick;
						num = 1151701885;
						continue;
					case 6:
						jHaYXdTXWAJNlfIRTMsRGaqNBpK = RaIckZJZsSLUbCnZyafyMyzctmC;
						qOBHYZBCAkYYTJoRDdsZoTyTELA = KJdBVvDcrdFbXCYaMGYmWKQSOKQt;
						ZRzHEnKZrARTmYSqzudcOoQkFLn = new float[RaIckZJZsSLUbCnZyafyMyzctmC];
						vqZyMIbiZNaMpemrDPhgsXmGAKrY = new bool[KJdBVvDcrdFbXCYaMGYmWKQSOKQt];
						XvxBvKVGveXRrGWIkrDzfJlxpVl();
						num = 1151701880;
						continue;
					case 4:
						XVBtlXdsFBPLTxCoYRWKsbfhcUk = systemId;
						eunhnaovDRiEguPGzwjEMBJUohX = sourceJoystick;
						lzXAqTcTNwGXhyoMQqetZTTNJGjM = getHardwareJoystickMap_InputManager;
						lZKxEZhZedfFzXCyfpSbNNLgSFy = deviceDisconnectedDelegate;
						XKdkawtumCxPyKPVBrWIuFkhbmb = -1;
						num = 1151701882;
						continue;
					case 5:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			uOtbqKcpjlZbLMgCJgbgAHYfvYsv.MvfYUGonPatKegPtmGgJekuNwNXV();
			bool[] currentButtonValues = default(bool[]);
			while (true)
			{
				int num = 359974145;
				while (true)
				{
					switch (num ^ 0x1574C502)
					{
					case 2:
						break;
					case 3:
						currentButtonValues = uOtbqKcpjlZbLMgCJgbgAHYfvYsv.CurrentButtonValues;
						QwjbBaCiqpyATADIBvDzRnxExBKA(currentButtonValues, ref uOtbqKcpjlZbLMgCJgbgAHYfvYsv.ATGKCPfHAZxJXbfdvecSrbrpGhQ);
						num = 359974146;
						continue;
					case 0:
						ntHkZnBwItpIoEGMjrBEabLTXFJ(currentButtonValues, ref uOtbqKcpjlZbLMgCJgbgAHYfvYsv.ATGKCPfHAZxJXbfdvecSrbrpGhQ);
						num = 359974147;
						continue;
					default:
						uOtbqKcpjlZbLMgCJgbgAHYfvYsv.cHQDtHxqOBHMTeDoAMAnUqYwlCyL();
						return;
					}
					break;
				}
			}
		}

		public void TDhMyCVOXumsPZkPzjnhTYSijVh(bool P_0)
		{
			if (eunhnaovDRiEguPGzwjEMBJUohX == null)
			{
				while (true)
				{
					switch (-877623912 ^ -877623911)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			kgieqVsAMEifkgIdGxDGFnaOKZc = P_0;
		}

		public bool GqjCXvxcolTNemJQCMpXfQRqmSW(fcDzwnYZhuXlXPrsIuHeDFPrMbB P_0)
		{
			IoRhsFepSGWHfwqPDUFnFopALib(RCiftshFYYSPMlrQqCGkWNDViXru(P_0));
			return bajsMqGhZRtVJqqeQtegeORbUav;
		}

		public bool RCiftshFYYSPMlrQqCGkWNDViXru(fcDzwnYZhuXlXPrsIuHeDFPrMbB P_0)
		{
			if (eunhnaovDRiEguPGzwjEMBJUohX == null)
			{
				return false;
			}
			return eunhnaovDRiEguPGzwjEMBJUohX.RCiftshFYYSPMlrQqCGkWNDViXru(P_0);
		}

		public void IoRhsFepSGWHfwqPDUFnFopALib(bool P_0)
		{
			bajsMqGhZRtVJqqeQtegeORbUav = P_0;
		}

		public void eUhcWFiyldrGwnCXsarMqbyjZIF()
		{
			if (!UmCIkDDfhBkELrnhrBsuDuBUIECd)
			{
				goto IL_0032;
			}
			if (xVSjIrGwKDoPDOAjdcHjFdonFcd())
			{
				goto IL_0010;
			}
			goto IL_003f;
			IL_003f:
			int num;
			if (UmCIkDDfhBkELrnhrBsuDuBUIECd && bajsMqGhZRtVJqqeQtegeORbUav)
			{
				uOtbqKcpjlZbLMgCJgbgAHYfvYsv.MyJyGjmCwusbhiQFfrODGPnUwSK();
				num = -1369291597;
				goto IL_0015;
			}
			return;
			IL_0010:
			num = -1369291599;
			goto IL_0015;
			IL_0015:
			switch (num ^ -1369291600)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0032;
			case 2:
				goto IL_003f;
			case 3:
				return;
			}
			goto IL_0010;
			IL_0032:
			XvxBvKVGveXRrGWIkrDzfJlxpVl();
			num = -1369291598;
			goto IL_0015;
		}

		public void JNYJbGcDBYoOlEQixheXYxPaAtWg()
		{
			XKdkawtumCxPyKPVBrWIuFkhbmb = -1;
			UmCIkDDfhBkELrnhrBsuDuBUIECd = false;
			while (true)
			{
				int num = -33186350;
				while (true)
				{
					switch (num ^ -33186349)
					{
					case 3:
						break;
					default:
						return;
					case 1:
						uOtbqKcpjlZbLMgCJgbgAHYfvYsv.zHIDjadCrmciEDxyqlukcUUEQZwZ();
						Array.Clear(ZRzHEnKZrARTmYSqzudcOoQkFLn, 0, ZRzHEnKZrARTmYSqzudcOoQkFLn.Length);
						num = -33186351;
						continue;
					case 2:
						Array.Clear(vqZyMIbiZNaMpemrDPhgsXmGAKrY, 0, vqZyMIbiZNaMpemrDPhgsXmGAKrY.Length);
						num = -33186349;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (RaIckZJZsSLUbCnZyafyMyzctmC != dataUpdater.axisCount)
			{
				goto IL_0060;
			}
			if (KJdBVvDcrdFbXCYaMGYmWKQSOKQt != dataUpdater.buttonCount)
			{
				goto IL_001f;
			}
			goto IL_00f3;
			IL_00f3:
			int num = 0;
			int num2 = 445132922;
			goto IL_0024;
			IL_001f:
			num2 = 445132926;
			goto IL_0024;
			IL_0024:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x1A88307D)
				{
				case 4:
					break;
				default:
					return;
				case 3:
					goto IL_0060;
				case 1:
					dataUpdater.buttonValues[num3] = vqZyMIbiZNaMpemrDPhgsXmGAKrY[num3];
					num2 = 445132925;
					continue;
				case 10:
					num2 = 445132920;
					continue;
				case 7:
					if (num >= RaIckZJZsSLUbCnZyafyMyzctmC)
					{
						num3 = 0;
						num2 = 445132919;
						continue;
					}
					goto case 9;
				case 9:
					dataUpdater.axisValues[num] = ZRzHEnKZrARTmYSqzudcOoQkFLn[num];
					num++;
					num2 = 445132922;
					continue;
				case 0:
					num3++;
					num2 = 445132920;
					continue;
				case 5:
					if (num3 < KJdBVvDcrdFbXCYaMGYmWKQSOKQt)
					{
						goto case 1;
					}
					goto IL_00d7;
				case 2:
					goto IL_00f3;
				case 6:
					if (!dataUpdater.hasReceivedInput)
					{
						dataUpdater.hasReceivedInput = true;
						num2 = 445132917;
						continue;
					}
					return;
				case 8:
					return;
				}
				break;
				IL_00d7:
				int num4;
				if (VOmckskOqMXuJcSBuIcPcvDRBIhH)
				{
					num2 = 445132923;
					num4 = num2;
				}
				else
				{
					num2 = 445132917;
					num4 = num2;
				}
			}
			goto IL_001f;
			IL_0060:
			throw new Exception("This controller signature does not match the data object!");
		}

		public BridgedControllerHWInfo XNhjnTKDnPIWYdspfSxvjnotCFBk()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			qHHYDYGCGqOhLRBRJCdFmLOJpwE(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			while (true)
			{
				int num = 465607842;
				while (true)
				{
					switch (num ^ 0x1BC09CA3)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						return bridgedController;
					}
					break;
					IL_0024:
					qHHYDYGCGqOhLRBRJCdFmLOJpwE(bridgedController);
					num = 465607843;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(XKdkawtumCxPyKPVBrWIuFkhbmb);
		}

		private void XvxBvKVGveXRrGWIkrDzfJlxpVl()
		{
			if (eunhnaovDRiEguPGzwjEMBJUohX == null || !GqjCXvxcolTNemJQCMpXfQRqmSW(fcDzwnYZhuXlXPrsIuHeDFPrMbB.vFKDQmBwmKblyNfAgMsjJydmupF))
			{
				return;
			}
			try
			{
				XzWKSnlcoLMDpyHPRRSMRDouGpb();
				DfxwvZbLdGnSpowODnIMWDoFhcBh dfxwvZbLdGnSpowODnIMWDoFhcBh = eunhnaovDRiEguPGzwjEMBJUohX.yjkWpiVqthNVaZbTIWscsnTcXMY.QeSmWiVbtADVRggFnFOczMgnEet(olWbvGAQLilkGAutbhCRAOmvEGTw.sqctTwSLyaqlwqFnrOcMfkscgZQH);
				EtxqgYqtVAKZanAwGgrhAaDqdDaM = dfxwvZbLdGnSpowODnIMWDoFhcBh.PFyVjnGpmOklNfqHTmcjHyNFdUs;
				cAssXnoeVmNPesYNhboKrFdgyng = (XInputDeviceSubType)dfxwvZbLdGnSpowODnIMWDoFhcBh.HIHzooTCAXAerAvaerAnYHfZurx;
				if (eunhnaovDRiEguPGzwjEMBJUohX.yjkWpiVqthNVaZbTIWscsnTcXMY.qyYjHBxpYngdRISxCzkNrXWsFda(default(NukZzVajpShfwNPSbPfmPusaDdN)).Success)
				{
					mqRCOGhpUhuJIDFwlHJQROPEFMrC = true;
					goto IL_0071;
				}
				goto IL_011b;
				IL_011b:
				vXFtSrFAbNgEaZCWOqIoweOfchwg = (dfxwvZbLdGnSpowODnIMWDoFhcBh.rgNOkrpmhiGBrLTBaaLZBGFVYBc & nrsBruuMMMLgmcpXzEwnTNNAoaI.BcfyYxgZWOKjasGlwGPGSyPcjCv) == nrsBruuMMMLgmcpXzEwnTNNAoaI.BcfyYxgZWOKjasGlwGPGSyPcjCv;
				int num = -154333145;
				goto IL_0076;
				IL_0071:
				num = -154333148;
				goto IL_0076;
				IL_0076:
				while (true)
				{
					switch (num ^ -154333146)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						uOtbqKcpjlZbLMgCJgbgAHYfvYsv.MyJyGjmCwusbhiQFfrODGPnUwSK();
						cBDIfdqFvdWzxrFEMJqjLvTvIpG = MiscTools.CreateGuidHashSHA1(string.Concat(EtxqgYqtVAKZanAwGgrhAaDqdDaM, cAssXnoeVmNPesYNhboKrFdgyng, XVBtlXdsFBPLTxCoYRWKsbfhcUk));
						UmCIkDDfhBkELrnhrBsuDuBUIECd = true;
						num = -154333150;
						continue;
					case 1:
						HUcWpSluxhNdngRwNRiLQuUWiQb();
						REezjTFCollnzcnDXouNnLNDkjk = VjkWjnwoPItHtAfScAsiHywgzcu.hardwareMapIdentifier.guid;
						HMaFDzCZyyJZjLhcCpVmgIggZoam = VjkWjnwoPItHtAfScAsiHywgzcu.controllerName;
						num = -154333147;
						continue;
					case 2:
						goto IL_011b;
					case 4:
						return;
					}
					break;
				}
				goto IL_0071;
			}
			catch (Exception)
			{
				UmCIkDDfhBkELrnhrBsuDuBUIECd = false;
				bajsMqGhZRtVJqqeQtegeORbUav = false;
				cBDIfdqFvdWzxrFEMJqjLvTvIpG = Guid.Empty;
			}
		}

		private bool xVSjIrGwKDoPDOAjdcHjFdonFcd()
		{
			try
			{
				if (cAssXnoeVmNPesYNhboKrFdgyng != (XInputDeviceSubType)eunhnaovDRiEguPGzwjEMBJUohX.yjkWpiVqthNVaZbTIWscsnTcXMY.QeSmWiVbtADVRggFnFOczMgnEet(olWbvGAQLilkGAutbhCRAOmvEGTw.sqctTwSLyaqlwqFnrOcMfkscgZQH).HIHzooTCAXAerAvaerAnYHfZurx)
				{
					bool result = default(bool);
					while (true)
					{
						IL_001e:
						int num = -1955315795;
						while (true)
						{
							switch (num ^ -1955315793)
							{
							case 3:
								break;
							default:
								goto end_IL_0023;
							case 2:
								goto IL_0040;
							case 0:
								goto end_IL_0023;
							case 1:
								return result;
							}
							goto IL_001e;
							IL_0040:
							result = true;
							num = -1955315794;
							continue;
							end_IL_0023:
							break;
						}
						break;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		private void XzWKSnlcoLMDpyHPRRSMRDouGpb()
		{
			vXFtSrFAbNgEaZCWOqIoweOfchwg = false;
			mqRCOGhpUhuJIDFwlHJQROPEFMrC = false;
			kgieqVsAMEifkgIdGxDGFnaOKZc = false;
			UmCIkDDfhBkELrnhrBsuDuBUIECd = false;
		}

		private void wNeUtkPKiMwcJCOpioDApbbYSjJ()
		{
			if (lZKxEZhZedfFzXCyfpSbNNLgSFy != null)
			{
				while (true)
				{
					int num = 1349027027;
					while (true)
					{
						switch (num ^ 0x506884D2)
						{
						case 0:
							break;
						case 1:
							lZKxEZhZedfFzXCyfpSbNNLgSFy();
							num = 1349027024;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			uOtbqKcpjlZbLMgCJgbgAHYfvYsv.zHIDjadCrmciEDxyqlukcUUEQZwZ();
		}

		private void QwjbBaCiqpyATADIBvDzRnxExBKA(bool[] P_0, ref ayborLoqEFdrihRvqaFsDcJPQpXP P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= RaIckZJZsSLUbCnZyafyMyzctmC)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				ZRzHEnKZrARTmYSqzudcOoQkFLn[i] = MnqkSgUruMGpGEncQArrqhjEHzFC(axes_orig[i], P_0, ref P_1);
				if (!VOmckskOqMXuJcSBuIcPcvDRBIhH && ZRzHEnKZrARTmYSqzudcOoQkFLn[i] != 0f)
				{
					VOmckskOqMXuJcSBuIcPcvDRBIhH = true;
				}
			}
		}

		private void ntHkZnBwItpIoEGMjrBEabLTXFJ(bool[] P_0, ref ayborLoqEFdrihRvqaFsDcJPQpXP P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)VjkWjnwoPItHtAfScAsiHywgzcu.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= KJdBVvDcrdFbXCYaMGYmWKQSOKQt)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				vqZyMIbiZNaMpemrDPhgsXmGAKrY[i] = odpuOJgHmnilGWRhqHPsTzrkUnQ(buttons_orig[i], P_0, ref P_1);
				if (!VOmckskOqMXuJcSBuIcPcvDRBIhH && vqZyMIbiZNaMpemrDPhgsXmGAKrY[i])
				{
					VOmckskOqMXuJcSBuIcPcvDRBIhH = true;
				}
			}
		}

		private float MnqkSgUruMGpGEncQArrqhjEHzFC(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref ayborLoqEFdrihRvqaFsDcJPQpXP P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return MnqkSgUruMGpGEncQArrqhjEHzFC(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!odpuOJgHmnilGWRhqHPsTzrkUnQ(P_0.sourceButton, P_1))
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			return 0f;
		}

		private float MnqkSgUruMGpGEncQArrqhjEHzFC(XInputAxis P_0, ref ayborLoqEFdrihRvqaFsDcJPQpXP P_1)
		{
			switch (P_0)
			{
			case XInputAxis.LeftThumbX:
				return lmyenCPLmUeYnxIapmEbpOtJtXT(P_1.oYHlhbXDqwAqrhpOOCyvEiICdu);
			case XInputAxis.LeftThumbY:
				return lmyenCPLmUeYnxIapmEbpOtJtXT(P_1.QbcRewlkYVZXRLHCjZALhrWmVQy);
			case XInputAxis.RightThumbX:
				return lmyenCPLmUeYnxIapmEbpOtJtXT(P_1.KGwEbXeLVVoiPpONhnWYTbqiufjT);
			case XInputAxis.RightThumbY:
				return lmyenCPLmUeYnxIapmEbpOtJtXT(P_1.cSXTilLSxeGVdTDsiRTfoahqJoK);
			case XInputAxis.LeftTrigger:
				return snOrnsUdHJtthuWkaKWpcRqxkzv(P_1.UYEBsUiHJbJlgjjUBiLbUaeBFlvQ);
			case XInputAxis.RightTrigger:
				return snOrnsUdHJtthuWkaKWpcRqxkzv(P_1.qTOBfWKAUjaowetdZNGVOCxQeEW);
			default:
				return 0f;
			}
		}

		private bool odpuOJgHmnilGWRhqHPsTzrkUnQ(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref ayborLoqEFdrihRvqaFsDcJPQpXP P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return odpuOJgHmnilGWRhqHPsTzrkUnQ(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = MnqkSgUruMGpGEncQArrqhjEHzFC(P_0.sourceAxis, ref P_2);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return false;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return false;
					}
				}
				else if (num > 0f)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		private bool odpuOJgHmnilGWRhqHPsTzrkUnQ(XInputButton P_0, bool[] P_1)
		{
			switch (P_0)
			{
			case XInputButton.DPadUp:
				return P_1[0];
			case XInputButton.DPadDown:
				return P_1[1];
			case XInputButton.DPadLeft:
				return P_1[2];
			case XInputButton.DPadRight:
				return P_1[3];
			case XInputButton.Start:
				return P_1[4];
			case XInputButton.Back:
				return P_1[5];
			case XInputButton.LeftThumb:
				return P_1[6];
			case XInputButton.RightThumb:
				return P_1[7];
			case XInputButton.LeftShoulder:
				return P_1[8];
			case XInputButton.RightShoulder:
				return P_1[9];
			case XInputButton.Guide:
				return P_1[10];
			case XInputButton.A:
				return P_1[11];
			case XInputButton.B:
				return P_1[12];
			case XInputButton.X:
				return P_1[13];
			case XInputButton.Y:
				return P_1[14];
			default:
				return false;
			}
		}

		private float lmyenCPLmUeYnxIapmEbpOtJtXT(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float snOrnsUdHJtthuWkaKWpcRqxkzv(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private void HUcWpSluxhNdngRwNRiLQuUWiQb()
		{
			VjkWjnwoPItHtAfScAsiHywgzcu = lzXAqTcTNwGXhyoMQqetZTTNJGjM(XNhjnTKDnPIWYdspfSxvjnotCFBk());
			while (true)
			{
				int num = 945638880;
				while (true)
				{
					switch (num ^ 0x385D4DE1)
					{
					case 0:
						break;
					case 1:
					{
						int num2;
						if (VjkWjnwoPItHtAfScAsiHywgzcu == null)
						{
							num = 945638883;
							num2 = num;
						}
						else
						{
							num = 945638882;
							num2 = num;
						}
						continue;
					}
					case 2:
						Rewired.Logger.LogError("Default hardware map not found!");
						return;
					default:
						RaIckZJZsSLUbCnZyafyMyzctmC = VjkWjnwoPItHtAfScAsiHywgzcu.axisCount;
						KJdBVvDcrdFbXCYaMGYmWKQSOKQt = VjkWjnwoPItHtAfScAsiHywgzcu.buttonCount;
						return;
					}
					break;
				}
			}
		}

		private bool FDHDSzmBAJfsXahTMWZnlodQdvG(ref NukZzVajpShfwNPSbPfmPusaDdN P_0)
		{
			if (P_0.DPaDJEhlEDJgWTYuHJcZIwaNMgWK > 0 || P_0.EPkXRCwGNsdvAiiPyrxDTYdhuEpd > 0)
			{
				return true;
			}
			return false;
		}

		private void iehGpnaTpLnFWNqRgcGeWmBvWYq(ref NukZzVajpShfwNPSbPfmPusaDdN P_0)
		{
			P_0.DPaDJEhlEDJgWTYuHJcZIwaNMgWK = 0;
			P_0.EPkXRCwGNsdvAiiPyrxDTYdhuEpd = 0;
		}

		private void mSMxzaMmHfEDJlsfIaKGakPTyGu(ref NukZzVajpShfwNPSbPfmPusaDdN P_0, ref NukZzVajpShfwNPSbPfmPusaDdN P_1)
		{
			P_1.DPaDJEhlEDJgWTYuHJcZIwaNMgWK = P_0.DPaDJEhlEDJgWTYuHJcZIwaNMgWK;
			P_1.EPkXRCwGNsdvAiiPyrxDTYdhuEpd = P_0.EPkXRCwGNsdvAiiPyrxDTYdhuEpd;
		}

		private string VUjBBLGxogalucNHZqXfeETbZbu()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", ReInput.currentPlatform.ToString(), InputSource.XInput.ToString(), EtxqgYqtVAKZanAwGgrhAaDqdDaM.ToString(), cAssXnoeVmNPesYNhboKrFdgyng.ToString()));
		}

		private void qHHYDYGCGqOhLRBRJCdFmLOJpwE(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			while (true)
			{
				int num = -754014894;
				while (true)
				{
					switch (num ^ -754014895)
					{
					case 4:
						break;
					case 3:
						P_0.inputSource = P_0.inputManagerSource;
						P_0.deviceType = ControlDeviceType.XYhwUwaOlrfFTKoMRqftWpJVYyOD;
						P_0.hardwareIdentifier = VUjBBLGxogalucNHZqXfeETbZbu();
						P_0.hardwareAxisCount = jHaYXdTXWAJNlfIRTMsRGaqNBpK;
						P_0.hardwareButtonCount = qOBHYZBCAkYYTJoRDdsZoTyTELA;
						P_0.hardwareHatCount = 0;
						num = -754014895;
						continue;
					case 1:
						P_0.hw_supportsVibration = mqRCOGhpUhuJIDFwlHJQROPEFMrC;
						num = -754014893;
						continue;
					case 0:
						P_0.hw_productName = productName;
						P_0.hw_supportsVoice = vXFtSrFAbNgEaZCWOqIoweOfchwg;
						num = -754014896;
						continue;
					default:
						P_0.hw_localVibrationMotorCount = (mqRCOGhpUhuJIDFwlHJQROPEFMrC ? 2 : 0);
						P_0.hw_xInputSubType = cAssXnoeVmNPesYNhboKrFdgyng;
						return;
					}
					break;
				}
			}
		}

		private void qHHYDYGCGqOhLRBRJCdFmLOJpwE(BridgedController P_0)
		{
			qHHYDYGCGqOhLRBRJCdFmLOJpwE((BridgedControllerHWInfo)P_0);
			while (true)
			{
				int num = -1494073274;
				while (true)
				{
					switch (num ^ -1494073273)
					{
					case 2:
						break;
					case 1:
						goto IL_0025;
					default:
						P_0.controllerExtension = extension;
						return;
					}
					break;
					IL_0025:
					P_0.sourceJoystick = this;
					P_0.gameHardwareMap = VjkWjnwoPItHtAfScAsiHywgzcu.ToGameHardwareControllerMap();
					P_0.instanceName = "XInput " + instanceName;
					P_0.productName = "XInput " + productName;
					P_0.isXInputDevice = true;
					P_0.axisCount = RaIckZJZsSLUbCnZyafyMyzctmC;
					P_0.buttonCount = KJdBVvDcrdFbXCYaMGYmWKQSOKQt;
					P_0.controllerTypeGuid = REezjTFCollnzcnDXouNnLNDkjk;
					num = -1494073273;
				}
			}
		}

		public void Dispose()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
			GC.SuppressFinalize(this);
		}

		~JzLztiRQalmgMwsfOXIrZxwEBhm()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
		}

		protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
		{
			if (nNxUslIcGUpqKgpPZYhuimcvWyC)
			{
				goto IL_0008;
			}
			goto IL_0048;
			IL_0008:
			int num = -124321162;
			goto IL_000d;
			IL_000d:
			switch (num ^ -124321163)
			{
			case 2:
				break;
			case 4:
				goto IL_002e;
			case 0:
				goto IL_0048;
			case 3:
				return;
			default:
				goto IL_006d;
			}
			goto IL_0008;
			IL_0048:
			if (P_0)
			{
				if (isConnected)
				{
					eunhnaovDRiEguPGzwjEMBJUohX.SmEOyGUtyQqtDzngFJYOnFznBDL();
					num = -124321167;
					goto IL_000d;
				}
				goto IL_002e;
			}
			goto IL_006d;
			IL_002e:
			if (uOtbqKcpjlZbLMgCJgbgAHYfvYsv != null)
			{
				uOtbqKcpjlZbLMgCJgbgAHYfvYsv.Dispose();
				num = -124321164;
				goto IL_000d;
			}
			goto IL_006d;
			IL_006d:
			nNxUslIcGUpqKgpPZYhuimcvWyC = true;
		}
	}

	private class lvDbdcLHueAlljPWbkKVIHQOHsNx
	{
		private class qsDTpjCACQIglYuHYlciMNVArTm
		{
			public bool dVwXxAVqNuHPFGxnnWCtCREgMUc;

			public int InzpRLWBzesgNjVGacynCIMBDnJ;

			public XInputDeviceSubType cAssXnoeVmNPesYNhboKrFdgyng;

			public void EhlPnfprjfkehAbDLrDcQKRlXmc(JzLztiRQalmgMwsfOXIrZxwEBhm P_0, bool P_1)
			{
				dVwXxAVqNuHPFGxnnWCtCREgMUc = P_1;
				InzpRLWBzesgNjVGacynCIMBDnJ = P_0.rewiredId;
				cAssXnoeVmNPesYNhboKrFdgyng = P_0.cAssXnoeVmNPesYNhboKrFdgyng;
			}

			public qsDTpjCACQIglYuHYlciMNVArTm(int rewiredId, XInputDeviceSubType deviceSubType)
			{
				InzpRLWBzesgNjVGacynCIMBDnJ = rewiredId;
				cAssXnoeVmNPesYNhboKrFdgyng = deviceSubType;
			}
		}

		private List<qsDTpjCACQIglYuHYlciMNVArTm> hrPXQonAeODgYLqpGRybHDStLgN;

		public lvDbdcLHueAlljPWbkKVIHQOHsNx()
		{
			hrPXQonAeODgYLqpGRybHDStLgN = new List<qsDTpjCACQIglYuHYlciMNVArTm>();
		}

		public void jliAkyhXYLFmufXDnDmKKgJgNiqD(JzLztiRQalmgMwsfOXIrZxwEBhm P_0, bool P_1)
		{
			int num = KITOQlhBKIDpAjmntFCXekgANGKd(P_0.rewiredId, P_0.cAssXnoeVmNPesYNhboKrFdgyng, true);
			if (num >= 0)
			{
				return;
			}
			while (true)
			{
				qsDTpjCACQIglYuHYlciMNVArTm qsDTpjCACQIglYuHYlciMNVArTm2 = new qsDTpjCACQIglYuHYlciMNVArTm(P_0.rewiredId, P_0.cAssXnoeVmNPesYNhboKrFdgyng);
				qsDTpjCACQIglYuHYlciMNVArTm2.dVwXxAVqNuHPFGxnnWCtCREgMUc = P_1;
				int num2 = -434201077;
				while (true)
				{
					switch (num2 ^ -434201078)
					{
					case 0:
						goto IL_0019;
					case 2:
						break;
					default:
						hrPXQonAeODgYLqpGRybHDStLgN.Add(qsDTpjCACQIglYuHYlciMNVArTm2);
						return;
					}
					break;
					IL_0019:
					num2 = -434201080;
				}
			}
		}

		public void EhlPnfprjfkehAbDLrDcQKRlXmc(int P_0, JzLztiRQalmgMwsfOXIrZxwEBhm P_1, bool P_2)
		{
			if (P_0 < 0)
			{
				return;
			}
			while (true)
			{
				int num = -1760467364;
				while (true)
				{
					switch (num ^ -1760467368)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						hrPXQonAeODgYLqpGRybHDStLgN[P_0].EhlPnfprjfkehAbDLrDcQKRlXmc(P_1, P_2);
						num = -1760467366;
						continue;
					case 1:
						return;
					case 4:
					{
						int num2;
						if (P_0 < hrPXQonAeODgYLqpGRybHDStLgN.Count)
						{
							num = -1760467365;
							num2 = num;
						}
						else
						{
							num = -1760467367;
							num2 = num;
						}
						continue;
					}
					case 2:
						return;
					}
					break;
				}
			}
		}

		public int fwygEPpcpveWeQzcAVDjgDMGEFMA(XInputDeviceSubType P_0, bool P_1)
		{
			int count = hrPXQonAeODgYLqpGRybHDStLgN.Count;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < count)
				{
					num2 = 34964466;
					num3 = num2;
				}
				else
				{
					num2 = 34964464;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x21583F1)
					{
					case 0:
						num2 = 34964466;
						continue;
					case 4:
						break;
					case 2:
						if (hrPXQonAeODgYLqpGRybHDStLgN[num].cAssXnoeVmNPesYNhboKrFdgyng == P_0)
						{
							return num;
						}
						goto IL_0061;
					case 3:
						if (P_1)
						{
							goto case 2;
						}
						if (!hrPXQonAeODgYLqpGRybHDStLgN[num].dVwXxAVqNuHPFGxnnWCtCREgMUc)
						{
							num2 = 34964467;
							continue;
						}
						goto IL_0061;
					default:
						{
							return -1;
						}
						IL_0061:
						num++;
						num2 = 34964469;
						continue;
					}
					break;
				}
			}
		}

		public int KITOQlhBKIDpAjmntFCXekgANGKd(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = hrPXQonAeODgYLqpGRybHDStLgN.Count;
			int num = 0;
			while (true)
			{
				int num2 = -1679260798;
				while (true)
				{
					switch (num2 ^ -1679260797)
					{
					case 7:
						break;
					case 1:
						num2 = -1679260797;
						continue;
					case 2:
						if (hrPXQonAeODgYLqpGRybHDStLgN[num].cAssXnoeVmNPesYNhboKrFdgyng == P_1)
						{
							num2 = -1679260800;
							continue;
						}
						goto IL_007e;
					case 5:
						if (!hrPXQonAeODgYLqpGRybHDStLgN[num].dVwXxAVqNuHPFGxnnWCtCREgMUc)
						{
							num2 = -1679260795;
							continue;
						}
						goto IL_007e;
					case 3:
						return num;
					case 6:
						if (hrPXQonAeODgYLqpGRybHDStLgN[num].InzpRLWBzesgNjVGacynCIMBDnJ == P_0)
						{
							num2 = -1679260799;
							continue;
						}
						goto IL_007e;
					case 4:
					{
						int num3;
						if (P_2)
						{
							num2 = -1679260795;
							num3 = num2;
						}
						else
						{
							num2 = -1679260794;
							num3 = num2;
						}
						continue;
					}
					default:
						{
							if (num >= count)
							{
								return -1;
							}
							goto case 4;
						}
						IL_007e:
						num++;
						num2 = -1679260797;
						continue;
					}
					break;
				}
			}
		}

		public int AorMfEkkphQTeBvmTowgNfiQUaE(int P_0)
		{
			if (P_0 >= 0)
			{
				if (P_0 < hrPXQonAeODgYLqpGRybHDStLgN.Count)
				{
					goto IL_003d;
				}
				while (true)
				{
					switch (-1246028074 ^ -1246028073)
					{
					case 2:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_003d;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException();
			IL_003d:
			return hrPXQonAeODgYLqpGRybHDStLgN[P_0].InzpRLWBzesgNjVGacynCIMBDnJ;
		}

		public void rUjptlIopneRBgzUeABrKiqGdFeA(int P_0, bool P_1)
		{
			if (P_0 < 0)
			{
				return;
			}
			if (P_0 >= hrPXQonAeODgYLqpGRybHDStLgN.Count)
			{
				while (true)
				{
					switch (0x7A7F5458 ^ 0x7A7F5459)
					{
					case 2:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			hrPXQonAeODgYLqpGRybHDStLgN[P_0].dVwXxAVqNuHPFGxnnWCtCREgMUc = P_1;
		}
	}

	private class ZirjvElZWjDyRjonaCKSvekzpby
	{
		public bool SEOWqHHueXUaCMIsxuROCmYrdqtC;

		private float GFZGajkyxPdVAyJIenWsllrpVti;

		public float whPwJIwNtiomGJkXdcTTKttjbnRA;

		public ZirjvElZWjDyRjonaCKSvekzpby()
		{
		}

		public ZirjvElZWjDyRjonaCKSvekzpby(float inLength)
		{
			whPwJIwNtiomGJkXdcTTKttjbnRA = inLength;
		}

		public void JLNyGUJfqBkWKpBQUvTKmlQdbACH()
		{
			SEOWqHHueXUaCMIsxuROCmYrdqtC = true;
			GFZGajkyxPdVAyJIenWsllrpVti = whPwJIwNtiomGJkXdcTTKttjbnRA + ReInput.unscaledTime;
		}

		public void JLNyGUJfqBkWKpBQUvTKmlQdbACH(float P_0)
		{
			SEOWqHHueXUaCMIsxuROCmYrdqtC = true;
			while (true)
			{
				int num = 1431012948;
				while (true)
				{
					switch (num ^ 0x554B8656)
					{
					case 0:
						break;
					case 2:
						goto IL_0025;
					default:
						GFZGajkyxPdVAyJIenWsllrpVti = whPwJIwNtiomGJkXdcTTKttjbnRA + ReInput.unscaledTime;
						return;
					}
					break;
					IL_0025:
					whPwJIwNtiomGJkXdcTTKttjbnRA = P_0;
					num = 1431012951;
				}
			}
		}

		public bool EhlPnfprjfkehAbDLrDcQKRlXmc()
		{
			if (!SEOWqHHueXUaCMIsxuROCmYrdqtC)
			{
				return false;
			}
			if (ReInput.unscaledTime >= GFZGajkyxPdVAyJIenWsllrpVti)
			{
				while (true)
				{
					int num = 512956354;
					while (true)
					{
						switch (num ^ 0x1E9317C0)
						{
						case 0:
							break;
						case 2:
							goto IL_0035;
						default:
							return true;
						}
						break;
						IL_0035:
						SEOWqHHueXUaCMIsxuROCmYrdqtC = false;
						num = 512956353;
					}
				}
			}
			return false;
		}

		public void bVJfbjSJHtCUhxVYYaQYFCJuPMDE()
		{
			SEOWqHHueXUaCMIsxuROCmYrdqtC = false;
			GFZGajkyxPdVAyJIenWsllrpVti = 0f;
		}

		public void AkdfdZYOWrieepQwxzGNBEEnDSX(float P_0)
		{
			whPwJIwNtiomGJkXdcTTKttjbnRA = P_0;
		}

		public ZirjvElZWjDyRjonaCKSvekzpby IJIFfnfKkokRYXSERsHqJLnlOWZ()
		{
			return (ZirjvElZWjDyRjonaCKSvekzpby)MemberwiseClone();
		}
	}

	public class ySDWWGGPdsWqyEKpVarmlIJfpv : IDisposable
	{
		private readonly ButtonLoopSet pXAzDifhoXFJwfIXqMsgHECKSEm;

		private readonly DualRingReportBuffer qvuNgTOqQqzmDTdOGQncQRLIaXZ;

		public readonly aCvDNJpOutIyvBpeyJROsQvlGXr yjkWpiVqthNVaZbTIWscsnTcXMY;

		public ayborLoqEFdrihRvqaFsDcJPQpXP ATGKCPfHAZxJXbfdvecSrbrpGhQ;

		private int KarmEyeNNTzJXTMwbnmvDMELiApj;

		private bool bajsMqGhZRtVJqqeQtegeORbUav;

		private bool VNHrYcFWkCOkbtIQnyQPocJIFaD;

		private byte[] lvyljsZgCBtZevhOgnmgCOEgXrB;

		private byte[] skskEOIStmEVWAKpJbMnFOIehkPH;

		private RingBuffer<NukZzVajpShfwNPSbPfmPusaDdN> MFtQvseoKmZZYXCKtalyEtJiJUvF = new RingBuffer<NukZzVajpShfwNPSbPfmPusaDdN>(5);

		private RingBuffer<NukZzVajpShfwNPSbPfmPusaDdN> YhsgPgLYtkfrDZkJQYrgdcvzRpL = new RingBuffer<NukZzVajpShfwNPSbPfmPusaDdN>(5);

		private readonly object ukmYjsOnSzIqIvSXTnwqajZqYPO = new object();

		private readonly object vHZuLDBknikVXyhWKkAEupXnoQp = new object();

		private NukZzVajpShfwNPSbPfmPusaDdN TdGDLxzpHeGFLhjpZkivOojlLwc;

		private float fyenBAFSFKqzksyOaeeGPREsMfp;

		private bool nNxUslIcGUpqKgpPZYhuimcvWyC;

		public bool[] CurrentButtonValues
		{
			get
			{
				return pXAzDifhoXFJwfIXqMsgHECKSEm.Current.effectiveValue;
			}
		}

		public ySDWWGGPdsWqyEKpVarmlIJfpv(int controllerIndex, UpdateLoopSetting updateLoops)
		{
			while (true)
			{
				int num = 2020495644;
				while (true)
				{
					switch (num ^ 0x786E511D)
					{
					case 0:
						break;
					case 1:
						goto IL_0052;
					default:
						pXAzDifhoXFJwfIXqMsgHECKSEm = new ButtonLoopSet(updateLoops, 15);
						skskEOIStmEVWAKpJbMnFOIehkPH = new byte[18];
						return;
					}
					break;
					IL_0052:
					yjkWpiVqthNVaZbTIWscsnTcXMY = new aCvDNJpOutIyvBpeyJROsQvlGXr((WtjqgLIkFLAJFJjXVXqKjcKlFDpa)controllerIndex);
					qvuNgTOqQqzmDTdOGQncQRLIaXZ = new DualRingReportBuffer(18, 25);
					lvyljsZgCBtZevhOgnmgCOEgXrB = qvuNgTOqQqzmDTdOGQncQRLIaXZ.ReadBuffer;
					num = 2020495647;
				}
			}
		}

		public void MvfYUGonPatKegPtmGgJekuNwNXV()
		{
			pXAzDifhoXFJwfIXqMsgHECKSEm.SetUpdateLoop(ReInput.currentUpdateLoop);
			EtrcXKvScAfFafMGLFgNRyxmjvLb(ref ATGKCPfHAZxJXbfdvecSrbrpGhQ);
		}

		public void cHQDtHxqOBHMTeDoAMAnUqYwlCyL()
		{
			zMMEwkTfLcDfiGeDweeiltwslDYY();
			pXAzDifhoXFJwfIXqMsgHECKSEm.Current.ClearWasTrueThisFrame();
		}

		public void MyJyGjmCwusbhiQFfrODGPnUwSK()
		{
			UsuwPiqVitnNRnZALvWAYQYnQRS();
			bajsMqGhZRtVJqqeQtegeORbUav = true;
			VNHrYcFWkCOkbtIQnyQPocJIFaD = yjkWpiVqthNVaZbTIWscsnTcXMY.IsConnected;
		}

		public void zHIDjadCrmciEDxyqlukcUUEQZwZ()
		{
			bajsMqGhZRtVJqqeQtegeORbUav = false;
			VNHrYcFWkCOkbtIQnyQPocJIFaD = false;
			UsuwPiqVitnNRnZALvWAYQYnQRS();
		}

		public bool RCiftshFYYSPMlrQqCGkWNDViXru(fcDzwnYZhuXlXPrsIuHeDFPrMbB P_0)
		{
			switch (P_0)
			{
			case fcDzwnYZhuXlXPrsIuHeDFPrMbB.vFKDQmBwmKblyNfAgMsjJydmupF:
				return VNHrYcFWkCOkbtIQnyQPocJIFaD = yjkWpiVqthNVaZbTIWscsnTcXMY.IsConnected;
			case fcDzwnYZhuXlXPrsIuHeDFPrMbB.LhswARgbUCmSNPGkHIfoknXLeIQl:
				return VNHrYcFWkCOkbtIQnyQPocJIFaD;
			default:
				throw new NotImplementedException();
			}
		}

		public void qyYjHBxpYngdRISxCzkNrXWsFda(float P_0, int P_1)
		{
			if (P_1 == 0)
			{
				goto IL_0003;
			}
			goto IL_0029;
			IL_0003:
			int num = -399167287;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -399167285)
				{
				case 4:
					break;
				case 3:
					goto IL_0029;
				case 1:
					num = -399167285;
					continue;
				case 2:
					TdGDLxzpHeGFLhjpZkivOojlLwc.DPaDJEhlEDJgWTYuHJcZIwaNMgWK = (ushort)(MathTools.Clamp01(P_0) * 65535f);
					num = -399167286;
					continue;
				default:
					goto IL_0072;
				}
				break;
			}
			goto IL_0003;
			IL_0029:
			if (P_1 == 1)
			{
				TdGDLxzpHeGFLhjpZkivOojlLwc.EPkXRCwGNsdvAiiPyrxDTYdhuEpd = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				num = -399167285;
				goto IL_0008;
			}
			goto IL_0072;
			IL_0072:
			ezxgfYjABLVYoAdxFSBKrbuBYdfI();
		}

		public void twqdzZItwjGSDbACYpwwOvJauhq()
		{
			TdGDLxzpHeGFLhjpZkivOojlLwc.DPaDJEhlEDJgWTYuHJcZIwaNMgWK = 0;
			while (true)
			{
				int num = 1710106818;
				while (true)
				{
					switch (num ^ 0x65EE28C3)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_002a;
					case 2:
						return;
					}
					break;
					IL_002a:
					TdGDLxzpHeGFLhjpZkivOojlLwc.EPkXRCwGNsdvAiiPyrxDTYdhuEpd = 0;
					ezxgfYjABLVYoAdxFSBKrbuBYdfI();
					num = 1710106817;
				}
			}
		}

		public void SmEOyGUtyQqtDzngFJYOnFznBDL()
		{
			TdGDLxzpHeGFLhjpZkivOojlLwc.DPaDJEhlEDJgWTYuHJcZIwaNMgWK = 0;
			TdGDLxzpHeGFLhjpZkivOojlLwc.EPkXRCwGNsdvAiiPyrxDTYdhuEpd = 0;
			lock (vHZuLDBknikVXyhWKkAEupXnoQp)
			{
				lock (ukmYjsOnSzIqIvSXTnwqajZqYPO)
				{
					MFtQvseoKmZZYXCKtalyEtJiJUvF.Clear();
					YhsgPgLYtkfrDZkJQYrgdcvzRpL.Clear();
					PYRUxEbHwNTGfoaNfDJkfKZluPg(yjkWpiVqthNVaZbTIWscsnTcXMY, TdGDLxzpHeGFLhjpZkivOojlLwc, ref fyenBAFSFKqzksyOaeeGPREsMfp);
				}
			}
		}

		public void BrLAxHHjvlPoCcONDSVtDukgzmD()
		{
			if (!bajsMqGhZRtVJqqeQtegeORbUav || !VNHrYcFWkCOkbtIQnyQPocJIFaD)
			{
				return;
			}
			ObUyRDnZkprNrHfwzvWOcaficyNA obUyRDnZkprNrHfwzvWOcaficyNA;
			float realTime;
			try
			{
				if (!yjkWpiVqthNVaZbTIWscsnTcXMY.wWMbNYiuIkwExnSyGPZGmzJCIReK(out obUyRDnZkprNrHfwzvWOcaficyNA))
				{
					VNHrYcFWkCOkbtIQnyQPocJIFaD = false;
					return;
				}
				while (true)
				{
					IL_0048:
					realTime = ReInput.realTime;
					int num = -566767525;
					while (true)
					{
						switch (num ^ -566767526)
						{
						case 0:
							goto IL_002a;
						default:
							goto end_IL_002f;
						case 2:
							break;
						case 1:
							goto end_IL_002f;
						}
						goto IL_0048;
						IL_002a:
						num = -566767528;
						continue;
						end_IL_002f:
						break;
					}
					break;
				}
			}
			catch
			{
				VNHrYcFWkCOkbtIQnyQPocJIFaD = false;
				return;
			}
			LjyqLzcPWucrNefKXazrGCxMVHHG(ref obUyRDnZkprNrHfwzvWOcaficyNA.vSwPcNwgbxwAqGIFeDWVMWWlXXr, realTime, skskEOIStmEVWAKpJbMnFOIehkPH);
			qvuNgTOqQqzmDTdOGQncQRLIaXZ.Write(skskEOIStmEVWAKpJbMnFOIehkPH, 18);
		}

		public void aHEcUMrJtWeCSrMHbulnzpNFhEtd()
		{
			if (!bajsMqGhZRtVJqqeQtegeORbUav || !VNHrYcFWkCOkbtIQnyQPocJIFaD || ReInput.realTime < fyenBAFSFKqzksyOaeeGPREsMfp + 0.01f)
			{
				return;
			}
			lock (vHZuLDBknikVXyhWKkAEupXnoQp)
			{
				lock (ukmYjsOnSzIqIvSXTnwqajZqYPO)
				{
					MiscTools.Swap(ref MFtQvseoKmZZYXCKtalyEtJiJUvF, ref YhsgPgLYtkfrDZkJQYrgdcvzRpL);
				}
				nBmGEQDrQGlbTAAijrBtVEXaxMDT(YhsgPgLYtkfrDZkJQYrgdcvzRpL, yjkWpiVqthNVaZbTIWscsnTcXMY, ref fyenBAFSFKqzksyOaeeGPREsMfp);
			}
		}

		private void zMMEwkTfLcDfiGeDweeiltwslDYY()
		{
			OroPksYxoViEEqhiJHSNcvIhqiBG();
		}

		private void OroPksYxoViEEqhiJHSNcvIhqiBG()
		{
			if (!(ReInput.realTime < fyenBAFSFKqzksyOaeeGPREsMfp + 1.5f) && (!Mathf.Approximately((int)TdGDLxzpHeGFLhjpZkivOojlLwc.DPaDJEhlEDJgWTYuHJcZIwaNMgWK, 0f) || !Mathf.Approximately((int)TdGDLxzpHeGFLhjpZkivOojlLwc.EPkXRCwGNsdvAiiPyrxDTYdhuEpd, 0f)))
			{
				ezxgfYjABLVYoAdxFSBKrbuBYdfI();
			}
		}

		private void ezxgfYjABLVYoAdxFSBKrbuBYdfI()
		{
			lock (ukmYjsOnSzIqIvSXTnwqajZqYPO)
			{
				MFtQvseoKmZZYXCKtalyEtJiJUvF.Enqueue(TdGDLxzpHeGFLhjpZkivOojlLwc);
			}
		}

		private static void nBmGEQDrQGlbTAAijrBtVEXaxMDT(RingBuffer<NukZzVajpShfwNPSbPfmPusaDdN> P_0, aCvDNJpOutIyvBpeyJROsQvlGXr P_1, ref float P_2)
		{
			if (P_0.Count > 0)
			{
				PYRUxEbHwNTGfoaNfDJkfKZluPg(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void PYRUxEbHwNTGfoaNfDJkfKZluPg(aCvDNJpOutIyvBpeyJROsQvlGXr P_0, NukZzVajpShfwNPSbPfmPusaDdN P_1, ref float P_2)
		{
			try
			{
				P_0.qyYjHBxpYngdRISxCzkNrXWsFda(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private unsafe void EtrcXKvScAfFafMGLFgNRyxmjvLb(ref ayborLoqEFdrihRvqaFsDcJPQpXP P_0)
		{
			int num = qvuNgTOqQqzmDTdOGQncQRLIaXZ.StartRead() / 18;
			if (num == 0)
			{
				return;
			}
			while (qvuNgTOqQqzmDTdOGQncQRLIaXZ.Read() > 0)
			{
				int num2;
				if (num > 1)
				{
					num2 = BitConverter.ToInt32(lvyljsZgCBtZevhOgnmgCOEgXrB, 0);
				}
				else
				{
					EOrKOCUuETUykCNEHCWvPdtJZpV(lvyljsZgCBtZevhOgnmgCOEgXrB, ref P_0);
					num2 = (int)P_0.MUjLXcXSkaSGwgaKBHQZCsppZvco;
				}
				float timestamp;
				fixed (byte* ptr = lvyljsZgCBtZevhOgnmgCOEgXrB)
				{
					timestamp = *(float*)(ptr + 14);
				}
				for (int i = 0; i < 15; i++)
				{
					pXAzDifhoXFJwfIXqMsgHECKSEm.SetValue(i, odpuOJgHmnilGWRhqHPsTzrkUnQ(num2, i), timestamp);
				}
				num--;
			}
			KarmEyeNNTzJXTMwbnmvDMELiApj = (int)P_0.MUjLXcXSkaSGwgaKBHQZCsppZvco;
		}

		private void EOrKOCUuETUykCNEHCWvPdtJZpV(byte[] P_0, ref ayborLoqEFdrihRvqaFsDcJPQpXP P_1)
		{
			P_1.MUjLXcXSkaSGwgaKBHQZCsppZvco = (pobAfqHAYRiEOjDDKZgSfKsHbQSs)BitConverter.ToInt32(P_0, 0);
			P_1.oYHlhbXDqwAqrhpOOCyvEiICdu = BitConverter.ToInt16(P_0, 4);
			P_1.QbcRewlkYVZXRLHCjZALhrWmVQy = BitConverter.ToInt16(P_0, 6);
			P_1.UYEBsUiHJbJlgjjUBiLbUaeBFlvQ = P_0[8];
			P_1.KGwEbXeLVVoiPpONhnWYTbqiufjT = BitConverter.ToInt16(P_0, 9);
			P_1.cSXTilLSxeGVdTDsiRTfoahqJoK = BitConverter.ToInt16(P_0, 11);
			P_1.qTOBfWKAUjaowetdZNGVOCxQeEW = P_0[13];
		}

		private unsafe void LjyqLzcPWucrNefKXazrGCxMVHHG(ref ayborLoqEFdrihRvqaFsDcJPQpXP P_0, float P_1, byte[] P_2)
		{
			int mUjLXcXSkaSGwgaKBHQZCsppZvco = (int)P_0.MUjLXcXSkaSGwgaKBHQZCsppZvco;
			P_2[0] = (byte)mUjLXcXSkaSGwgaKBHQZCsppZvco;
			P_2[1] = (byte)(mUjLXcXSkaSGwgaKBHQZCsppZvco >> 8);
			P_2[2] = (byte)(mUjLXcXSkaSGwgaKBHQZCsppZvco >> 16);
			P_2[3] = (byte)(mUjLXcXSkaSGwgaKBHQZCsppZvco >> 24);
			short oYHlhbXDqwAqrhpOOCyvEiICdu = P_0.oYHlhbXDqwAqrhpOOCyvEiICdu;
			P_2[4] = (byte)oYHlhbXDqwAqrhpOOCyvEiICdu;
			P_2[5] = (byte)(oYHlhbXDqwAqrhpOOCyvEiICdu >> 8);
			short qbcRewlkYVZXRLHCjZALhrWmVQy = P_0.QbcRewlkYVZXRLHCjZALhrWmVQy;
			P_2[6] = (byte)qbcRewlkYVZXRLHCjZALhrWmVQy;
			P_2[7] = (byte)(qbcRewlkYVZXRLHCjZALhrWmVQy >> 8);
			P_2[8] = P_0.UYEBsUiHJbJlgjjUBiLbUaeBFlvQ;
			short kGwEbXeLVVoiPpONhnWYTbqiufjT = P_0.KGwEbXeLVVoiPpONhnWYTbqiufjT;
			P_2[9] = (byte)kGwEbXeLVVoiPpONhnWYTbqiufjT;
			P_2[10] = (byte)(kGwEbXeLVVoiPpONhnWYTbqiufjT >> 8);
			short cSXTilLSxeGVdTDsiRTfoahqJoK = P_0.cSXTilLSxeGVdTDsiRTfoahqJoK;
			P_2[11] = (byte)cSXTilLSxeGVdTDsiRTfoahqJoK;
			P_2[12] = (byte)(cSXTilLSxeGVdTDsiRTfoahqJoK >> 8);
			P_2[13] = P_0.qTOBfWKAUjaowetdZNGVOCxQeEW;
			fixed (byte* ptr = P_2)
			{
				byte* ptr2 = ptr + 14;
				*(float*)ptr2 = P_1;
			}
		}

		private bool odpuOJgHmnilGWRhqHPsTzrkUnQ(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void UsuwPiqVitnNRnZALvWAYQYnQRS()
		{
			ATGKCPfHAZxJXbfdvecSrbrpGhQ = default(ayborLoqEFdrihRvqaFsDcJPQpXP);
			pXAzDifhoXFJwfIXqMsgHECKSEm.Clear();
			qvuNgTOqQqzmDTdOGQncQRLIaXZ.Clear();
			lock (lvyljsZgCBtZevhOgnmgCOEgXrB)
			{
				Array.Clear(lvyljsZgCBtZevhOgnmgCOEgXrB, 0, lvyljsZgCBtZevhOgnmgCOEgXrB.Length);
			}
			lock (skskEOIStmEVWAKpJbMnFOIehkPH)
			{
				Array.Clear(skskEOIStmEVWAKpJbMnFOIehkPH, 0, skskEOIStmEVWAKpJbMnFOIehkPH.Length);
			}
			KarmEyeNNTzJXTMwbnmvDMELiApj = 0;
		}

		public void Dispose()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(true);
			GC.SuppressFinalize(this);
		}

		~ySDWWGGPdsWqyEKpVarmlIJfpv()
		{
			HtJdxRxaGggkmaMTSWUpHqjZLDV(false);
		}

		protected virtual void HtJdxRxaGggkmaMTSWUpHqjZLDV(bool P_0)
		{
			if (!nNxUslIcGUpqKgpPZYhuimcvWyC)
			{
				nNxUslIcGUpqKgpPZYhuimcvWyC = true;
			}
		}
	}

	public enum fcDzwnYZhuXlXPrsIuHeDFPrMbB
	{
		vFKDQmBwmKblyNfAgMsjJydmupF = 0,
		LhswARgbUCmSNPGkHIfoknXLeIQl = 1
	}

	public const int WcTfhiCeyOtPPlwGXcDWaMdzPiF = 4;

	public const int qxSurOaPGBTrxoaSWjvAShoUERlC = 32768;

	public const int tmdObZMhwxWoecVwAuKrPutyhqM = -32768;

	public const int baxALusosKlnKAVPwHbbvhxObCK = 255;

	public const int GDxNJcOFfWoCAwLqEDVfDITwsdN = 0;

	public const int DvjGLpgLltFFYWKNfdyYlftiJNQU = 18;

	public const int mkkPnwiLLXibqCKRxZncAlbdnPt = 14;

	public const int ZHaxIGaKfhXEcnyXdKvnTtydpPK = 6;

	public const int kcCoAAGQmgZkWPWJCvbtYMpWPKA = 15;

	private JzLztiRQalmgMwsfOXIrZxwEBhm[] dCsSZFFJulKpOQMtYKhXiIgJRAo;

	private bool EpGYtfwyZOkOCWfNPwLsXVkpNCz;

	private ZirjvElZWjDyRjonaCKSvekzpby gagBDAdXKeeubxYwSPGDMfUhpDq;

	private lvDbdcLHueAlljPWbkKVIHQOHsNx ifKUMGJfwFlLcbHReXCcTfgpjtH;

	private global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<bool> sFMJuNkEjRgiflkDeBTrYjCaAcmb;

	private bool[] cfgVfCiyCDpMfGBlDmjncZyhACL;

	private bool[] JPErpSvlnaJjqbyxdnfqTvgUloMk;

	private bool kyXDAPEfIOTZaUhOSDjXBLRcGSRu;

	private readonly bool ITDqEGcMeikxZdcAYAUVeGWeLQiE;

	private readonly UpdateLoopSetting EAqhhnqHsgswgIHwTkugMMEPdAp;

	private UpdateLoopType bNtzSzCDFZEjMEUOpnAuIIeaiSG;

	private UpdateLoopType DhTBRXWAiiemIfmjgnLSMXvAYXrk;

	private Action<int, ControllerDataUpdater> YALIvlsEVxFcouIKiMIOBoKrdos;

	private bool HQDrRnWbIjHcDuyCJBqkpSHKNzw;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lzXAqTcTNwGXhyoMQqetZTTNJGjM;

	private Func<int> sbyIXavKIUtCermoZwGVxaaQFdB;

	private static Guid[] oFeCovRicvhFrbMdNjsnHoAoXihd;

	private static string[] MJwMGsfMBxXPeELumuRMGFgcwqL;

	private static string[] AfculJwIAcEQdCHdUpueqHDEcVph;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = -2022920090;
				while (true)
				{
					switch (num3 ^ -2022920089)
					{
					case 4:
						break;
					case 3:
						num2++;
						num3 = -2022920094;
						continue;
					case 2:
					{
						int num4;
						if (!dCsSZFFJulKpOQMtYKhXiIgJRAo[num2].isConnected)
						{
							num3 = -2022920092;
							num4 = num3;
						}
						else
						{
							num3 = -2022920089;
							num4 = num3;
						}
						continue;
					}
					case 1:
						num3 = -2022920094;
						continue;
					case 0:
						num++;
						num3 = -2022920092;
						continue;
					default:
						if (num2 >= 4)
						{
							return num;
						}
						goto case 2;
					}
					break;
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager
	{
		get
		{
			return this;
		}
	}

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource
	{
		get
		{
			return null;
		}
	}

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType
	{
		get
		{
			return InputSource.XInput;
		}
	}

	public gshAbvCgMLjmBZLoNOmLiemiCMZ(bool isWin10AUHack, UpdateLoopSetting updateLoop, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		ITDqEGcMeikxZdcAYAUVeGWeLQiE = isWin10AUHack;
		EAqhhnqHsgswgIHwTkugMMEPdAp = updateLoop;
		HQDrRnWbIjHcDuyCJBqkpSHKNzw = true;
		try
		{
			if (!ReInput.isEditor)
			{
				Rewired.Logger.Log("Searching for compatible XInput library...");
			}
			FZLWxQmQzwLaQGKEhOiRyzHAEuI fZLWxQmQzwLaQGKEhOiRyzHAEuI;
			string text;
			int num;
			if (!DbBzCsDOVGLEomDEwbzsHlJbmLN.XvxBvKVGveXRrGWIkrDzfJlxpVl(out fZLWxQmQzwLaQGKEhOiRyzHAEuI, out text, out num))
			{
				throw new Exception("XInput is not available.");
			}
			if (!ReInput.isEditor)
			{
				Rewired.Logger.Log("Found " + text + ".");
			}
			if (fZLWxQmQzwLaQGKEhOiRyzHAEuI < FZLWxQmQzwLaQGKEhOiRyzHAEuI.EodwXJfYKYiuzZlizavcwDHLpeA)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				int num3 = 4;
			}
			lzXAqTcTNwGXhyoMQqetZTTNJGjM = getHardwareJoystickMap_InputManager;
			sbyIXavKIUtCermoZwGVxaaQFdB = getNewJoystickId;
			kyXDAPEfIOTZaUhOSDjXBLRcGSRu = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(EAqhhnqHsgswgIHwTkugMMEPdAp, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					DhTBRXWAiiemIfmjgnLSMXvAYXrk = list[num2];
				}
			}
			sFMJuNkEjRgiflkDeBTrYjCaAcmb = new global::JgMCJJMlgdaaIpbxNKhHxTGJyrJ<bool>(true, uUQmCejJOOcsxXArmGhPktwkoDN);
			cfgVfCiyCDpMfGBlDmjncZyhACL = new bool[4];
			JPErpSvlnaJjqbyxdnfqTvgUloMk = new bool[4];
			YALIvlsEVxFcouIKiMIOBoKrdos = UpdateControllerData;
			if (kyXDAPEfIOTZaUhOSDjXBLRcGSRu)
			{
				hXpHtBuijEDJvGwJAKyobUHfOXu();
			}
		}
		catch (Exception)
		{
			OnDestroy();
			throw;
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Initialize()
	{
		if (HQDrRnWbIjHcDuyCJBqkpSHKNzw)
		{
			gagBDAdXKeeubxYwSPGDMfUhpDq = new ZirjvElZWjDyRjonaCKSvekzpby(1f);
			goto IL_001b;
		}
		goto IL_0098;
		IL_0098:
		ifKUMGJfwFlLcbHReXCcTfgpjtH = new lvDbdcLHueAlljPWbkKVIHQOHsNx();
		int num = -2106827739;
		goto IL_0020;
		IL_001b:
		num = -2106827740;
		goto IL_0020;
		IL_0020:
		int num2 = default(int);
		ySDWWGGPdsWqyEKpVarmlIJfpv ySDWWGGPdsWqyEKpVarmlIJfpv2 = default(ySDWWGGPdsWqyEKpVarmlIJfpv);
		while (true)
		{
			switch (num ^ -2106827737)
			{
			case 0:
				break;
			case 8:
				goto IL_0054;
			case 5:
				dCsSZFFJulKpOQMtYKhXiIgJRAo[num2] = new JzLztiRQalmgMwsfOXIrZxwEBhm(num2, kyXDAPEfIOTZaUhOSDjXBLRcGSRu, ySDWWGGPdsWqyEKpVarmlIJfpv2, lzXAqTcTNwGXhyoMQqetZTTNJGjM, SystemDeviceDisconnected);
				num = -2106827741;
				continue;
			case 3:
				goto IL_0098;
			case 4:
				num2++;
				num = -2106827729;
				continue;
			case 2:
				if (dCsSZFFJulKpOQMtYKhXiIgJRAo == null)
				{
					dCsSZFFJulKpOQMtYKhXiIgJRAo = new JzLztiRQalmgMwsfOXIrZxwEBhm[4];
					num2 = 0;
					num = -2106827729;
					continue;
				}
				goto default;
			case 6:
				rdYCGoWOpFzeWopaszcDvgrUprf.joystickInputThread.ThreadUpdateEvent += ySDWWGGPdsWqyEKpVarmlIJfpv2.BrLAxHHjvlPoCcONDSVtDukgzmD;
				rdYCGoWOpFzeWopaszcDvgrUprf.joystickOutputThread.ThreadUpdateEvent += ySDWWGGPdsWqyEKpVarmlIJfpv2.aHEcUMrJtWeCSrMHbulnzpNFhEtd;
				num = -2106827742;
				continue;
			case 1:
				ySDWWGGPdsWqyEKpVarmlIJfpv2 = new ySDWWGGPdsWqyEKpVarmlIJfpv(num2, EAqhhnqHsgswgIHwTkugMMEPdAp);
				num = -2106827743;
				continue;
			default:
				oZesqonNstqzxnWIyDGjQJMxlMo(true);
				Update(UpdateLoopType.Update);
				return;
			}
			break;
			IL_0054:
			int num3;
			if (num2 < 4)
			{
				num = -2106827738;
				num3 = num;
			}
			else
			{
				num = -2106827744;
				num3 = num;
			}
		}
		goto IL_001b;
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		bNtzSzCDFZEjMEUOpnAuIIeaiSG = currentUpdateLoop;
		rlecVsIXXYBuTWpNWMljozzsJsK();
		int num = 0;
		while (true)
		{
			int num2 = 1195666890;
			while (true)
			{
				switch (num2 ^ 0x47446DC9)
				{
				case 0:
					break;
				case 4:
					num++;
					num2 = 1195666891;
					continue;
				case 1:
					if (dCsSZFFJulKpOQMtYKhXiIgJRAo[num] != null && dCsSZFFJulKpOQMtYKhXiIgJRAo[num].isConnected)
					{
						dCsSZFFJulKpOQMtYKhXiIgJRAo[num].Update();
						num2 = 1195666893;
						continue;
					}
					goto case 4;
				case 3:
					num2 = 1195666891;
					continue;
				default:
					if (num >= 4)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (sFMJuNkEjRgiflkDeBTrYjCaAcmb != null)
		{
			sFMJuNkEjRgiflkDeBTrYjCaAcmb.HtJdxRxaGggkmaMTSWUpHqjZLDV();
			goto IL_0016;
		}
		goto IL_008d;
		IL_008d:
		int num = default(int);
		int num2;
		if (dCsSZFFJulKpOQMtYKhXiIgJRAo != null)
		{
			num = 0;
			num2 = 2025336717;
			goto IL_001b;
		}
		goto IL_0121;
		IL_0016:
		num2 = 2025336707;
		goto IL_001b;
		IL_001b:
		while (true)
		{
			switch (num2 ^ 0x78B82F8B)
			{
			case 2:
				break;
			case 6:
				goto IL_004f;
			case 4:
				rdYCGoWOpFzeWopaszcDvgrUprf.joystickOutputThread.ThreadUpdateEvent -= dCsSZFFJulKpOQMtYKhXiIgJRAo[num].eunhnaovDRiEguPGzwjEMBJUohX.aHEcUMrJtWeCSrMHbulnzpNFhEtd;
				num2 = 2025336714;
				continue;
			case 8:
				goto IL_008d;
			case 7:
				if (dCsSZFFJulKpOQMtYKhXiIgJRAo[num] != null)
				{
					if (rdYCGoWOpFzeWopaszcDvgrUprf.joystickInputThread != null)
					{
						rdYCGoWOpFzeWopaszcDvgrUprf.joystickInputThread.ThreadUpdateEvent -= dCsSZFFJulKpOQMtYKhXiIgJRAo[num].eunhnaovDRiEguPGzwjEMBJUohX.BrLAxHHjvlPoCcONDSVtDukgzmD;
						num2 = 2025336718;
						continue;
					}
					goto IL_00e1;
				}
				goto case 0;
			case 5:
				goto IL_00e1;
			case 1:
				dCsSZFFJulKpOQMtYKhXiIgJRAo[num].Dispose();
				num2 = 2025336715;
				continue;
			case 0:
				num++;
				num2 = 2025336717;
				continue;
			default:
				goto IL_0121;
			}
			break;
			IL_00e1:
			int num3;
			if (rdYCGoWOpFzeWopaszcDvgrUprf.joystickOutputThread == null)
			{
				num2 = 2025336714;
				num3 = num2;
			}
			else
			{
				num2 = 2025336719;
				num3 = num2;
			}
			continue;
			IL_004f:
			int num4;
			if (num >= 4)
			{
				num2 = 2025336712;
				num4 = num2;
			}
			else
			{
				num2 = 2025336716;
				num4 = num2;
			}
		}
		goto IL_0016;
		IL_0121:
		DbBzCsDOVGLEomDEwbzsHlJbmLN.rHTnynWrPbsjkOsiGUEBtmUNgDv();
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return YALIvlsEVxFcouIKiMIOBoKrdos;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		dCsSZFFJulKpOQMtYKhXiIgJRAo[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		oZesqonNstqzxnWIyDGjQJMxlMo(true);
		while (true)
		{
			int num = 1666208982;
			while (true)
			{
				switch (num ^ 0x635054D5)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					irEPpFPqZklBkHfTgYTjOqDWGILF();
					num = 1666208981;
					continue;
				case 0:
					if (_SystemDeviceConnectedEvent != null)
					{
						_SystemDeviceConnectedEvent();
						num = 1666208980;
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

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		oZesqonNstqzxnWIyDGjQJMxlMo(true);
		irEPpFPqZklBkHfTgYTjOqDWGILF();
		while (true)
		{
			int num = 365073211;
			while (true)
			{
				switch (num ^ 0x15C29339)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					if (_SystemDeviceDisconnectedEvent != null)
					{
						goto IL_0033;
					}
					return;
				case 1:
					return;
				}
				break;
				IL_0033:
				_SystemDeviceDisconnectedEvent();
				num = 365073208;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return null;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return null;
	}

	private bool AArKSCcfULusNbJcCDjWHTNICaIL()
	{
		if (bNtzSzCDFZEjMEUOpnAuIIeaiSG != DhTBRXWAiiemIfmjgnLSMXvAYXrk)
		{
			return false;
		}
		bool flag = gagBDAdXKeeubxYwSPGDMfUhpDq.EhlPnfprjfkehAbDLrDcQKRlXmc();
		if (flag)
		{
			oZesqonNstqzxnWIyDGjQJMxlMo(true);
		}
		return flag;
	}

	private void oZesqonNstqzxnWIyDGjQJMxlMo(bool P_0)
	{
		EpGYtfwyZOkOCWfNPwLsXVkpNCz = P_0;
		while (true)
		{
			int num = -24971027;
			while (true)
			{
				switch (num ^ -24971028)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					if (HQDrRnWbIjHcDuyCJBqkpSHKNzw)
					{
						goto IL_002d;
					}
					return;
				case 0:
					return;
				}
				break;
				IL_002d:
				gagBDAdXKeeubxYwSPGDMfUhpDq.JLNyGUJfqBkWKpBQUvTKmlQdbACH();
				num = -24971028;
			}
		}
	}

	private void irEPpFPqZklBkHfTgYTjOqDWGILF()
	{
		if (sFMJuNkEjRgiflkDeBTrYjCaAcmb != null)
		{
			sFMJuNkEjRgiflkDeBTrYjCaAcmb.bVJfbjSJHtCUhxVYYaQYFCJuPMDE();
		}
	}

	private void hXpHtBuijEDJvGwJAKyobUHfOXu()
	{
		aCvDNJpOutIyvBpeyJROsQvlGXr aCvDNJpOutIyvBpeyJROsQvlGXr2 = new aCvDNJpOutIyvBpeyJROsQvlGXr();
		bool isConnected = aCvDNJpOutIyvBpeyJROsQvlGXr2.IsConnected;
	}

	private void rlecVsIXXYBuTWpNWMljozzsJsK()
	{
		bool flag = false;
		if (HQDrRnWbIjHcDuyCJBqkpSHKNzw)
		{
			goto IL_000a;
		}
		goto IL_0058;
		IL_000a:
		int num = 228017993;
		goto IL_000f;
		IL_000f:
		while (true)
		{
			switch (num ^ 0xD97474B)
			{
			case 7:
				break;
			default:
				return;
			case 5:
				goto IL_003f;
			case 3:
				goto IL_0058;
			case 6:
				DYXOSuUNEXtEAxrLMyQgtEjEnNO();
				num = 228017995;
				continue;
			case 1:
				irEPpFPqZklBkHfTgYTjOqDWGILF();
				return;
			case 2:
				flag = AArKSCcfULusNbJcCDjWHTNICaIL();
				num = 228017992;
				continue;
			case 0:
				if (sFMJuNkEjRgiflkDeBTrYjCaAcmb.isRunning && sFMJuNkEjRgiflkDeBTrYjCaAcmb.xHkLCHGKEGSLVNAFPpLRGAkaRJs())
				{
					SzxmDjxbrUAggcZJTsvgnNMpYtvn();
					num = 228017999;
					continue;
				}
				return;
			case 4:
				return;
			}
			break;
		}
		goto IL_000a;
		IL_0058:
		if (!flag && EpGYtfwyZOkOCWfNPwLsXVkpNCz)
		{
			KAKYkmPmrokmlaePtljicZCrPlX(aPRApWooRUgrbNlZuDdjghmBGLwX());
			oZesqonNstqzxnWIyDGjQJMxlMo(false);
			num = 228017994;
			goto IL_000f;
		}
		goto IL_003f;
		IL_003f:
		int num2;
		if (!EpGYtfwyZOkOCWfNPwLsXVkpNCz)
		{
			num = 228017995;
			num2 = num;
		}
		else
		{
			num = 228017997;
			num2 = num;
		}
		goto IL_000f;
	}

	private void DYXOSuUNEXtEAxrLMyQgtEjEnNO()
	{
		EpGYtfwyZOkOCWfNPwLsXVkpNCz = false;
		if (!sFMJuNkEjRgiflkDeBTrYjCaAcmb.isRunning)
		{
			sFMJuNkEjRgiflkDeBTrYjCaAcmb.CNNCNIEIEPKDJVWLdcWrLrRIbyb();
		}
	}

	private void SzxmDjxbrUAggcZJTsvgnNMpYtvn()
	{
		lock (cfgVfCiyCDpMfGBlDmjncZyhACL)
		{
			Array.Copy(cfgVfCiyCDpMfGBlDmjncZyhACL, JPErpSvlnaJjqbyxdnfqTvgUloMk, 4);
		}
		KAKYkmPmrokmlaePtljicZCrPlX(JPErpSvlnaJjqbyxdnfqTvgUloMk);
	}

	private bool uUQmCejJOOcsxXArmGhPktwkoDN()
	{
		lock (cfgVfCiyCDpMfGBlDmjncZyhACL)
		{
			int num = 0;
			while (true)
			{
				IL_000f:
				int num2 = -1624856190;
				while (true)
				{
					switch (num2 ^ -1624856189)
					{
					case 2:
						break;
					case 4:
						num++;
						num2 = -1624856192;
						continue;
					case 0:
						if (dCsSZFFJulKpOQMtYKhXiIgJRAo[num] != null)
						{
							cfgVfCiyCDpMfGBlDmjncZyhACL[num] = dCsSZFFJulKpOQMtYKhXiIgJRAo[num].RCiftshFYYSPMlrQqCGkWNDViXru(fcDzwnYZhuXlXPrsIuHeDFPrMbB.vFKDQmBwmKblyNfAgMsjJydmupF);
							num2 = -1624856185;
							continue;
						}
						goto case 4;
					case 1:
						num2 = -1624856192;
						continue;
					default:
						if (num >= 4)
						{
							goto end_IL_0014;
						}
						goto case 0;
					}
					goto IL_000f;
					continue;
					end_IL_0014:
					break;
				}
				break;
			}
		}
		return true;
	}

	private bool[] aPRApWooRUgrbNlZuDdjghmBGLwX()
	{
		int num = 0;
		while (true)
		{
			int num2 = -1302259851;
			while (true)
			{
				switch (num2 ^ -1302259852)
				{
				case 0:
					break;
				case 1:
					num2 = -1302259856;
					continue;
				case 2:
					JPErpSvlnaJjqbyxdnfqTvgUloMk[num] = dCsSZFFJulKpOQMtYKhXiIgJRAo[num].RCiftshFYYSPMlrQqCGkWNDViXru(fcDzwnYZhuXlXPrsIuHeDFPrMbB.vFKDQmBwmKblyNfAgMsjJydmupF);
					num++;
					num2 = -1302259856;
					continue;
				case 4:
				{
					int num3;
					if (num < 4)
					{
						num2 = -1302259850;
						num3 = num2;
					}
					else
					{
						num2 = -1302259849;
						num3 = num2;
					}
					continue;
				}
				default:
					return JPErpSvlnaJjqbyxdnfqTvgUloMk;
				}
				break;
			}
		}
	}

	private void KAKYkmPmrokmlaePtljicZCrPlX(bool[] P_0)
	{
		int num = 0;
		int num2 = 0;
		int num5 = default(int);
		int num6 = default(int);
		bool flag = default(bool);
		bool flag2 = default(bool);
		while (true)
		{
			int num3;
			int num4;
			if (num2 >= 4)
			{
				num3 = -1296062561;
				num4 = num3;
			}
			else
			{
				num3 = -1296062571;
				num4 = num3;
			}
			while (true)
			{
				int num8;
				int num7;
				switch (num3 ^ -1296062567)
				{
				case 14:
					num3 = -1296062571;
					continue;
				case 9:
					break;
				case 10:
					num5++;
					num3 = -1296062567;
					continue;
				case 7:
				{
					int num9;
					if (num6 >= 4)
					{
						num3 = -1296062570;
						num9 = num3;
					}
					else
					{
						num3 = -1296062563;
						num9 = num3;
					}
					continue;
				}
				case 11:
					num6++;
					num3 = -1296062562;
					continue;
				case 5:
					num3 = -1296062567;
					continue;
				case 6:
					num6 = 0;
					num3 = -1296062562;
					continue;
				case 4:
					if (dCsSZFFJulKpOQMtYKhXiIgJRAo[num6] != null && !dCsSZFFJulKpOQMtYKhXiIgJRAo[num6].kgieqVsAMEifkgIdGxDGFnaOKZc)
					{
						flag = P_0[num6];
						num3 = -1296062575;
						continue;
					}
					goto case 11;
				case 13:
					num8 = 1 << num5;
					goto IL_00eb;
				case 2:
					if (dCsSZFFJulKpOQMtYKhXiIgJRAo[num5] == null)
					{
						goto case 10;
					}
					if (num5 == 0)
					{
						num8 = 1;
						goto IL_00eb;
					}
					num3 = -1296062572;
					continue;
				case 3:
					if (!flag2)
					{
						rVPjnRIbMLDOGrkwREudCiotksA(dCsSZFFJulKpOQMtYKhXiIgJRAo[num2], false);
						num3 = -1296062568;
						continue;
					}
					goto case 1;
				case 15:
					num5 = 0;
					num3 = -1296062564;
					continue;
				case 1:
					num2++;
					num3 = -1296062576;
					continue;
				case 12:
					if (dCsSZFFJulKpOQMtYKhXiIgJRAo[num2] != null && dCsSZFFJulKpOQMtYKhXiIgJRAo[num2].kgieqVsAMEifkgIdGxDGFnaOKZc)
					{
						flag2 = P_0[num2];
						dCsSZFFJulKpOQMtYKhXiIgJRAo[num2].IoRhsFepSGWHfwqPDUFnFopALib(flag2);
						num3 = -1296062566;
						continue;
					}
					goto case 1;
				case 8:
					dCsSZFFJulKpOQMtYKhXiIgJRAo[num6].IoRhsFepSGWHfwqPDUFnFopALib(flag);
					if (flag && !rVPjnRIbMLDOGrkwREudCiotksA(dCsSZFFJulKpOQMtYKhXiIgJRAo[num6], true))
					{
						num |= ((num6 == 0) ? 1 : (1 << num6));
						num3 = -1296062574;
						continue;
					}
					goto case 11;
				default:
					{
						if (num5 >= 4)
						{
							return;
						}
						goto case 2;
					}
					IL_00eb:
					num7 = num8;
					if ((num & num7) != 1 << num5)
					{
						dCsSZFFJulKpOQMtYKhXiIgJRAo[num5].TDhMyCVOXumsPZkPzjnhTYSijVh(P_0[num5]);
						num3 = -1296062573;
						continue;
					}
					goto case 10;
				}
				break;
			}
		}
	}

	private bool rVPjnRIbMLDOGrkwREudCiotksA(JzLztiRQalmgMwsfOXIrZxwEBhm P_0, bool P_1)
	{
		int num = default(int);
		int num2;
		if (P_1)
		{
			P_0.eUhcWFiyldrGwnCXsarMqbyjZIF();
			if (!P_0.UmCIkDDfhBkELrnhrBsuDuBUIECd)
			{
				goto IL_0014;
			}
			num = ifKUMGJfwFlLcbHReXCcTfgpjtH.fwygEPpcpveWeQzcAVDjgDMGEFMA(P_0.cAssXnoeVmNPesYNhboKrFdgyng, false);
			if (num >= 0)
			{
				P_0.rewiredId = ifKUMGJfwFlLcbHReXCcTfgpjtH.AorMfEkkphQTeBvmTowgNfiQUaE(num);
				num2 = 1381419405;
				goto IL_0019;
			}
			goto IL_0087;
		}
		goto IL_00af;
		IL_0019:
		int num3 = default(int);
		ControllerDisconnectedEventArgs obj = default(ControllerDisconnectedEventArgs);
		while (true)
		{
			switch (num2 ^ 0x5256C98F)
			{
			case 5:
				break;
			case 1:
				return false;
			case 6:
				goto IL_0087;
			case 0:
				goto IL_00af;
			case 7:
				ifKUMGJfwFlLcbHReXCcTfgpjtH.rUjptlIopneRBgzUeABrKiqGdFeA(num3, false);
				num2 = 1381419403;
				continue;
			case 4:
				obj = P_0.ToControllerDisconnectedEventArgs();
				P_0.JNYJbGcDBYoOlEQixheXYxPaAtWg();
				num2 = 1381419404;
				continue;
			case 3:
				if (_DeviceDisconnectedEvent != null)
				{
					_DeviceDisconnectedEvent(obj);
					num2 = 1381419397;
					continue;
				}
				goto default;
			case 8:
			{
				BridgedController obj2 = P_0.ToBridgedController();
				if (_DeviceConnectedEvent != null)
				{
					_DeviceConnectedEvent(obj2);
					num2 = 1381419397;
					continue;
				}
				goto default;
			}
			case 2:
				ifKUMGJfwFlLcbHReXCcTfgpjtH.EhlPnfprjfkehAbDLrDcQKRlXmc(num, P_0, true);
				num2 = 1381419398;
				continue;
			case 9:
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
					num2 = 1381419399;
					continue;
				}
				goto case 8;
			default:
				return true;
			}
			break;
		}
		goto IL_0014;
		IL_00af:
		num3 = ifKUMGJfwFlLcbHReXCcTfgpjtH.KITOQlhBKIDpAjmntFCXekgANGKd(P_0.rewiredId, P_0.cAssXnoeVmNPesYNhboKrFdgyng, true);
		int num4;
		if (num3 >= 0)
		{
			num2 = 1381419400;
			num4 = num2;
		}
		else
		{
			num2 = 1381419403;
			num4 = num2;
		}
		goto IL_0019;
		IL_0087:
		P_0.rewiredId = sbyIXavKIUtCermoZwGVxaaQFdB();
		ifKUMGJfwFlLcbHReXCcTfgpjtH.jliAkyhXYLFmufXDnDmKKgJgNiqD(P_0, true);
		num2 = 1381419398;
		goto IL_0019;
		IL_0014:
		num2 = 1381419406;
		goto IL_0019;
	}

	static gshAbvCgMLjmBZLoNOmLiemiCMZ()
	{
		Guid[] array = new Guid[2];
		string[] mJwMGsfMBxXPeELumuRMGFgcwqL = default(string[]);
		while (true)
		{
			int num = 1374813596;
			while (true)
			{
				switch (num ^ 0x51F1FD9F)
				{
				case 4:
					break;
				case 3:
					array[0] = new Guid("72100955-0000-0000-0000-504944564944");
					num = 1374813598;
					continue;
				case 2:
					MJwMGsfMBxXPeELumuRMGFgcwqL = mJwMGsfMBxXPeELumuRMGFgcwqL;
					num = 1374813599;
					continue;
				case 1:
					array[1] = new Guid("02e0045e-0000-0000-0000-504944564944");
					oFeCovRicvhFrbMdNjsnHoAoXihd = array;
					mJwMGsfMBxXPeELumuRMGFgcwqL = new string[1] { "Xbox Bluetooth Gamepad" };
					num = 1374813597;
					continue;
				default:
					AfculJwIAcEQdCHdUpueqHDEcVph = new string[1] { "Xbox Wireless Controller.*" };
					return;
				}
				break;
			}
		}
	}

	public static bool NYbPexEJvLXtDiZpusQEVKSFkTK(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(oFeCovRicvhFrbMdNjsnHoAoXihd, P_3))
		{
			return true;
		}
		int num = default(int);
		if (!string.IsNullOrEmpty(P_1))
		{
			num = 0;
			goto IL_001c;
		}
		goto IL_00c9;
		IL_0105:
		P_0 = P_0.ToLower();
		int num2 = P_0.IndexOf("vid_");
		if (num2 < 0)
		{
			return false;
		}
		if (P_0.IndexOf("ig_") < num2)
		{
			return false;
		}
		return true;
		IL_00c9:
		int num3;
		int num4;
		if (!string.IsNullOrEmpty(P_2))
		{
			num3 = -1965411246;
			num4 = num3;
		}
		else
		{
			num3 = -1965411239;
			num4 = num3;
		}
		goto IL_0021;
		IL_001c:
		num3 = -1965411245;
		goto IL_0021;
		IL_0021:
		int num5 = default(int);
		while (true)
		{
			switch (num3 ^ -1965411248)
			{
			case 6:
				break;
			case 5:
				return true;
			case 8:
				goto IL_0066;
			case 1:
				goto IL_007d;
			case 3:
				num3 = -1965411247;
				continue;
			case 4:
				goto IL_009f;
			case 2:
				num5 = 0;
				num3 = -1965411244;
				continue;
			case 0:
				goto IL_00c9;
			case 7:
				goto IL_00e5;
			default:
				goto IL_0105;
			}
			break;
			IL_00e5:
			if (P_1.Equals(MJwMGsfMBxXPeELumuRMGFgcwqL[num], StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			num++;
			num3 = -1965411247;
			continue;
			IL_007d:
			int num6;
			if (num < MJwMGsfMBxXPeELumuRMGFgcwqL.Length)
			{
				num3 = -1965411241;
				num6 = num3;
			}
			else
			{
				num3 = -1965411248;
				num6 = num3;
			}
			continue;
			IL_0066:
			if (!Regex.IsMatch(P_2, AfculJwIAcEQdCHdUpueqHDEcVph[num5], RegexOptions.IgnoreCase))
			{
				num5++;
				num3 = -1965411244;
			}
			else
			{
				num3 = -1965411243;
			}
			continue;
			IL_009f:
			int num7;
			if (num5 >= AfculJwIAcEQdCHdUpueqHDEcVph.Length)
			{
				num3 = -1965411239;
				num7 = num3;
			}
			else
			{
				num3 = -1965411240;
				num7 = num3;
			}
		}
		goto IL_001c;
	}
}
