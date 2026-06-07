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

internal class khPCPJgtQFokObAEkJKNQbaUfSZG : PlatformInputManager
{
	private class KqZijOiESkOKxmSFgvxVuYITJco : IDisposable, IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private bool iWbTStEEwSUFdVmxbhFLIRLEWpP;

		private int LHBzfOUukEAojNhzqhOUdcqBelx;

		private readonly int TWjeabUqVFYvGwCMtNtEvCvRMXi;

		public Guid FHAzoTozCrisunLDoLyimqNbdex;

		public string DHGYnLayswGyOaWIxJecDoLngmm;

		public Guid mtlDBDFXTzxHqeXjvCJbhGtTMUCC;

		public Rewired.Libraries.SharpDX.XInput.DeviceType AgFzIkLgLYjOlqPCtjppfuTCSDg;

		public XInputDeviceSubType ynSMEBTXNkIOhxNnIkeAyVvAtyw;

		public bool uyjBbcIhGzMpDSyGYNhGPPRoYdp;

		public bool twjPaZyadPbHzhImzNWmBlIILpqn;

		public readonly VXjTLrVLbRqsejihSLeLmdPOFyL kYVEkOHTXBhxnrAeWMuOTcRgNeH;

		public bool ySKRlxVNISomhhIFpvZEYocyuLo;

		public bool GBctTtambVDrGmgNSbmaIAPqDQOB;

		private int DNqovhkJyMGDmjBrJizqLZxIBwWP;

		private int ElNlKPkIldnwOTDKjHUmDVOsEYGs;

		private int dhEQLHuCYYGQwdehmJKXAJgttVWs;

		private int aCdTArmyUaJIYSBpkbuJpDufgNGc;

		private readonly float[] HwRqYBlbrIoKtVDOMNmmVOGCrNt;

		private readonly bool[] xrmDwADRXdFsenTurfwlUsqsAvb;

		private HardwareJoystickMap_InputManager XCAyIFRJbEWUeBcnVweevmqWqtw;

		private readonly VXjTLrVLbRqsejihSLeLmdPOFyL wkHhrcUhfnaPWbRoirggYGSZaIe;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lvntcpgdZsSbabccpIcfMpTzYYr;

		private Action dRmTcpOPHjzqmIsaGEdrISZApWy;

		private bool tNTCfSzrXJZuOnbCfNhelnFFgApE;

		private bool RZErYKzcoEvfMnhtHeFDeTWjAxp;

		private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

		public string instanceName
		{
			get
			{
				string text = productName;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				return text + " " + TWjeabUqVFYvGwCMtNtEvCvRMXi;
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
				return ynSMEBTXNkIOhxNnIkeAyVvAtyw.ToString();
			}
		}

		public bool isConnected
		{
			get
			{
				if (kYVEkOHTXBhxnrAeWMuOTcRgNeH != null)
				{
					while (true)
					{
						int num = -1426118270;
						while (true)
						{
							switch (num ^ -1426118266)
							{
							case 3:
								break;
							case 4:
								goto IL_002e;
							case 1:
								goto end_IL_0008;
							case 0:
								if (!YBZlTXMnqpGUbbncpNABrgZQwyGs(ORvCMajzfaKsgomdBGYGJVUcbwQ.FQKPhyZCKUPSsUOKuvozgXhfOSh))
								{
									oJScKMoyuMjmQLXNPZrQqtfkrPP();
									num = -1426118268;
									continue;
								}
								goto default;
							default:
								return tNTCfSzrXJZuOnbCfNhelnFFgApE;
							}
							break;
							IL_002e:
							int num2;
							if (!GBctTtambVDrGmgNSbmaIAPqDQOB)
							{
								num = -1426118265;
							}
							else if (!tNTCfSzrXJZuOnbCfNhelnFFgApE)
							{
								num = -1426118268;
								num2 = num;
							}
							else
							{
								num = -1426118266;
								num2 = num;
							}
						}
						continue;
						end_IL_0008:
						break;
					}
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return LHBzfOUukEAojNhzqhOUdcqBelx;
			}
			set
			{
				LHBzfOUukEAojNhzqhOUdcqBelx = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return TWjeabUqVFYvGwCMtNtEvCvRMXi;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (iWbTStEEwSUFdVmxbhFLIRLEWpP)
				{
					return ynSMEBTXNkIOhxNnIkeAyVvAtyw.ToString() + " " + (TWjeabUqVFYvGwCMtNtEvCvRMXi + 1);
				}
				return "XInput " + ynSMEBTXNkIOhxNnIkeAyVvAtyw.ToString() + " " + (TWjeabUqVFYvGwCMtNtEvCvRMXi + 1);
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				return TWjeabUqVFYvGwCMtNtEvCvRMXi;
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
				return mtlDBDFXTzxHqeXjvCJbhGtTMUCC;
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
			kYVEkOHTXBhxnrAeWMuOTcRgNeH.wSwWZlMaWbyLCJABzuaHkvKQzPs(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			kYVEkOHTXBhxnrAeWMuOTcRgNeH.bWQnirdkyrnHUiWahNqkBCTSTtg();
		}

		public KqZijOiESkOKxmSFgvxVuYITJco(int systemId, bool isWin8AppStore, VXjTLrVLbRqsejihSLeLmdPOFyL sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Action deviceDisconnectedDelegate)
		{
			wkHhrcUhfnaPWbRoirggYGSZaIe = sourceJoystick;
			iWbTStEEwSUFdVmxbhFLIRLEWpP = isWin8AppStore;
			TWjeabUqVFYvGwCMtNtEvCvRMXi = systemId;
			kYVEkOHTXBhxnrAeWMuOTcRgNeH = sourceJoystick;
			lvntcpgdZsSbabccpIcfMpTzYYr = getHardwareJoystickMap_InputManager;
			dRmTcpOPHjzqmIsaGEdrISZApWy = deviceDisconnectedDelegate;
			LHBzfOUukEAojNhzqhOUdcqBelx = -1;
			DNqovhkJyMGDmjBrJizqLZxIBwWP = 6;
			ElNlKPkIldnwOTDKjHUmDVOsEYGs = 15;
			dhEQLHuCYYGQwdehmJKXAJgttVWs = DNqovhkJyMGDmjBrJizqLZxIBwWP;
			aCdTArmyUaJIYSBpkbuJpDufgNGc = ElNlKPkIldnwOTDKjHUmDVOsEYGs;
			HwRqYBlbrIoKtVDOMNmmVOGCrNt = new float[DNqovhkJyMGDmjBrJizqLZxIBwWP];
			xrmDwADRXdFsenTurfwlUsqsAvb = new bool[ElNlKPkIldnwOTDKjHUmDVOsEYGs];
			HtHLkuicvegUyNveVCXdfijLKttU();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			wkHhrcUhfnaPWbRoirggYGSZaIe.WRFQiHBTiHTxzhBXcGRzCalCNF();
			bool[] currentButtonValues = wkHhrcUhfnaPWbRoirggYGSZaIe.CurrentButtonValues;
			IsHEPGDcapJjIIIwabNlagrgYHK(currentButtonValues, ref wkHhrcUhfnaPWbRoirggYGSZaIe.ABeDBrDOYXRyETwPWnmCRizVbzMK);
			xEfKEFgwOpPyjRLoWJIEfoNdBYF(currentButtonValues, ref wkHhrcUhfnaPWbRoirggYGSZaIe.ABeDBrDOYXRyETwPWnmCRizVbzMK);
			wkHhrcUhfnaPWbRoirggYGSZaIe.aqqkTdOMGLHPIIcYrYTpjUXAOZk();
		}

		public void RqHCbyiiVyEbSIUfQhpdTCYEkDrI(bool P_0)
		{
			if (kYVEkOHTXBhxnrAeWMuOTcRgNeH != null)
			{
				ySKRlxVNISomhhIFpvZEYocyuLo = P_0;
			}
		}

		public bool YBZlTXMnqpGUbbncpNABrgZQwyGs(ORvCMajzfaKsgomdBGYGJVUcbwQ P_0)
		{
			EdjfbdZXMSCKwbFpugHrEingasfK(HlMyyMcEdYUuBguZHQkVQBAbFAp(P_0));
			return tNTCfSzrXJZuOnbCfNhelnFFgApE;
		}

		public bool HlMyyMcEdYUuBguZHQkVQBAbFAp(ORvCMajzfaKsgomdBGYGJVUcbwQ P_0)
		{
			if (kYVEkOHTXBhxnrAeWMuOTcRgNeH == null)
			{
				return false;
			}
			return kYVEkOHTXBhxnrAeWMuOTcRgNeH.HlMyyMcEdYUuBguZHQkVQBAbFAp(P_0);
		}

		public void EdjfbdZXMSCKwbFpugHrEingasfK(bool P_0)
		{
			tNTCfSzrXJZuOnbCfNhelnFFgApE = P_0;
		}

		public void sfDOplJRzfcojkfvLAoYhXyNNVJ()
		{
			if (GBctTtambVDrGmgNSbmaIAPqDQOB)
			{
				if (vcawkshliBvtQTtuAhyvIKjPeHz())
				{
					goto IL_0010;
				}
				goto IL_0048;
			}
			goto IL_0069;
			IL_0048:
			int num;
			if (GBctTtambVDrGmgNSbmaIAPqDQOB)
			{
				int num2;
				if (!tNTCfSzrXJZuOnbCfNhelnFFgApE)
				{
					num = -691060517;
					num2 = num;
				}
				else
				{
					num = -691060520;
					num2 = num;
				}
				goto IL_0015;
			}
			return;
			IL_0010:
			num = -691060518;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ -691060517)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					wkHhrcUhfnaPWbRoirggYGSZaIe.OPrDnVhLcontoTptCznHaDrwNsAh();
					num = -691060517;
					continue;
				case 4:
					goto IL_0048;
				case 1:
					goto IL_0069;
				case 0:
					return;
				}
				break;
			}
			goto IL_0010;
			IL_0069:
			HtHLkuicvegUyNveVCXdfijLKttU();
			num = -691060513;
			goto IL_0015;
		}

		public void NKgsBiDlHITBqDhOIKmBBlFELzQ()
		{
			LHBzfOUukEAojNhzqhOUdcqBelx = -1;
			GBctTtambVDrGmgNSbmaIAPqDQOB = false;
			wkHhrcUhfnaPWbRoirggYGSZaIe.xqyuuQSofyjoJulEXgAcFSYaDtu();
			while (true)
			{
				int num = 2079225912;
				while (true)
				{
					switch (num ^ 0x7BEE7839)
					{
					case 0:
						break;
					case 1:
						goto IL_0037;
					default:
						Array.Clear(xrmDwADRXdFsenTurfwlUsqsAvb, 0, xrmDwADRXdFsenTurfwlUsqsAvb.Length);
						return;
					}
					break;
					IL_0037:
					Array.Clear(HwRqYBlbrIoKtVDOMNmmVOGCrNt, 0, HwRqYBlbrIoKtVDOMNmmVOGCrNt.Length);
					num = 2079225915;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (DNqovhkJyMGDmjBrJizqLZxIBwWP == dataUpdater.axisCount)
			{
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = -440706133;
					while (true)
					{
						switch (num ^ -440706144)
						{
						case 9:
							break;
						default:
							return;
						case 0:
							if (num2 >= ElNlKPkIldnwOTDKjHUmDVOsEYGs)
							{
								goto IL_005f;
							}
							goto case 8;
						case 5:
							goto end_IL_000e;
						case 3:
							num3 = 0;
							num = -440706137;
							continue;
						case 1:
							dataUpdater.hasReceivedInput = true;
							num = -440706134;
							continue;
						case 7:
							goto IL_00b5;
						case 4:
							dataUpdater.axisValues[num3] = HwRqYBlbrIoKtVDOMNmmVOGCrNt[num3];
							num = -440706142;
							continue;
						case 2:
							num3++;
							num = -440706137;
							continue;
						case 6:
							num2 = 0;
							num = -440706144;
							continue;
						case 8:
							dataUpdater.buttonValues[num2] = xrmDwADRXdFsenTurfwlUsqsAvb[num2];
							num2++;
							num = -440706144;
							continue;
						case 11:
							goto IL_0124;
						case 10:
							return;
						}
						break;
						IL_0124:
						int num4;
						if (ElNlKPkIldnwOTDKjHUmDVOsEYGs != dataUpdater.buttonCount)
						{
							num = -440706139;
							num4 = num;
						}
						else
						{
							num = -440706141;
							num4 = num;
						}
						continue;
						IL_005f:
						if (RZErYKzcoEvfMnhtHeFDeTWjAxp)
						{
							int num5;
							if (dataUpdater.hasReceivedInput)
							{
								num = -440706134;
								num5 = num;
							}
							else
							{
								num = -440706143;
								num5 = num;
							}
							continue;
						}
						return;
						IL_00b5:
						int num6;
						if (num3 >= DNqovhkJyMGDmjBrJizqLZxIBwWP)
						{
							num = -440706138;
							num6 = num;
						}
						else
						{
							num = -440706140;
							num6 = num;
						}
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			throw new Exception("This controller signature does not match the data object!");
		}

		public BridgedControllerHWInfo PJFgAzlnjXDIFtIVMtyxcOgBHLL()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			while (true)
			{
				int num = 246722046;
				while (true)
				{
					switch (num ^ 0xEB4ADFF)
					{
					case 0:
						break;
					case 1:
						goto IL_0024;
					default:
						return bridgedControllerHWInfo;
					}
					break;
					IL_0024:
					qLdgPikrSeiPWSEbkkdRitWDfeYu(bridgedControllerHWInfo);
					num = 246722045;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			while (true)
			{
				int num = -2121951239;
				while (true)
				{
					switch (num ^ -2121951237)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						return bridgedController;
					}
					break;
					IL_0024:
					qLdgPikrSeiPWSEbkkdRitWDfeYu(bridgedController);
					num = -2121951238;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(LHBzfOUukEAojNhzqhOUdcqBelx);
		}

		private void HtHLkuicvegUyNveVCXdfijLKttU()
		{
			if (kYVEkOHTXBhxnrAeWMuOTcRgNeH == null)
			{
				return;
			}
			XoPqnCWhcOFBqhsrkYMQVcYhaLt xoPqnCWhcOFBqhsrkYMQVcYhaLt = default(XoPqnCWhcOFBqhsrkYMQVcYhaLt);
			while (true)
			{
				int num = -404380137;
				while (true)
				{
					switch (num ^ -404380138)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						if (!YBZlTXMnqpGUbbncpNABrgZQwyGs(ORvCMajzfaKsgomdBGYGJVUcbwQ.tskJsIsvmUkbpEjaLqwjCFbCKtP))
						{
							goto IL_002f;
						}
						try
						{
							DuiBNPJQcTzXqAtfuXBMeKaYDztR();
							while (true)
							{
								int num2 = -404380137;
								while (true)
								{
									switch (num2 ^ -404380138)
									{
									case 5:
										break;
									case 1:
									{
										xoPqnCWhcOFBqhsrkYMQVcYhaLt = kYVEkOHTXBhxnrAeWMuOTcRgNeH.adAqkIwrnbCGtQfPxaJibXYUYAC.UvoOzGyPpIiOKjPdACIwhmqNGejm(eJugPclBScbZVNDoYEaDBafLGUP.cwQIdAteaakFdnBRIwaCoHcYVYW);
										AgFzIkLgLYjOlqPCtjppfuTCSDg = xoPqnCWhcOFBqhsrkYMQVcYhaLt.XRAgRlviNYwGByvwryzeCXzsCcj;
										ynSMEBTXNkIOhxNnIkeAyVvAtyw = (XInputDeviceSubType)xoPqnCWhcOFBqhsrkYMQVcYhaLt.DLzRyYqWGLjrgTYAJeSnPonxGbzC;
										int num3;
										if (!kYVEkOHTXBhxnrAeWMuOTcRgNeH.adAqkIwrnbCGtQfPxaJibXYUYAC.wSwWZlMaWbyLCJABzuaHkvKQzPs(default(PTYoizLivOqKtIIuCrxoWaiEvuN)).Success)
										{
											num2 = -404380139;
											num3 = num2;
										}
										else
										{
											num2 = -404380138;
											num3 = num2;
										}
										continue;
									}
									case 4:
										DHGYnLayswGyOaWIxJecDoLngmm = XCAyIFRJbEWUeBcnVweevmqWqtw.controllerName;
										num2 = -404380140;
										continue;
									case 0:
										uyjBbcIhGzMpDSyGYNhGPPRoYdp = true;
										num2 = -404380139;
										continue;
									case 3:
										twjPaZyadPbHzhImzNWmBlIILpqn = (xoPqnCWhcOFBqhsrkYMQVcYhaLt.pShanBKDpoPUyQsbLLJHCsXlpFm & ziCLsONbOSGfrJdnEBafLIHmvsGt.NrHjfDDuFIeVhpRLVIEKTsNCafz) == ziCLsONbOSGfrJdnEBafLIHmvsGt.NrHjfDDuFIeVhpRLVIEKTsNCafz;
										XCEcogOtFbmhupWduawPDMqkEjv();
										FHAzoTozCrisunLDoLyimqNbdex = XCAyIFRJbEWUeBcnVweevmqWqtw.hardwareMapIdentifier.guid;
										num2 = -404380142;
										continue;
									default:
										wkHhrcUhfnaPWbRoirggYGSZaIe.OPrDnVhLcontoTptCznHaDrwNsAh();
										mtlDBDFXTzxHqeXjvCJbhGtTMUCC = MiscTools.CreateGuidHashSHA1(string.Concat(AgFzIkLgLYjOlqPCtjppfuTCSDg, ynSMEBTXNkIOhxNnIkeAyVvAtyw, TWjeabUqVFYvGwCMtNtEvCvRMXi));
										GBctTtambVDrGmgNSbmaIAPqDQOB = true;
										return;
									}
									break;
								}
							}
						}
						catch (Exception)
						{
							GBctTtambVDrGmgNSbmaIAPqDQOB = false;
							tNTCfSzrXJZuOnbCfNhelnFFgApE = false;
							mtlDBDFXTzxHqeXjvCJbhGtTMUCC = Guid.Empty;
							return;
						}
					case 2:
						return;
					}
					break;
					IL_002f:
					num = -404380140;
				}
			}
		}

		private bool vcawkshliBvtQTtuAhyvIKjPeHz()
		{
			try
			{
				if (ynSMEBTXNkIOhxNnIkeAyVvAtyw != (XInputDeviceSubType)kYVEkOHTXBhxnrAeWMuOTcRgNeH.adAqkIwrnbCGtQfPxaJibXYUYAC.UvoOzGyPpIiOKjPdACIwhmqNGejm(eJugPclBScbZVNDoYEaDBafLGUP.cwQIdAteaakFdnBRIwaCoHcYVYW).DLzRyYqWGLjrgTYAJeSnPonxGbzC)
				{
					return true;
				}
			}
			catch
			{
			}
			return false;
		}

		private void DuiBNPJQcTzXqAtfuXBMeKaYDztR()
		{
			twjPaZyadPbHzhImzNWmBlIILpqn = false;
			uyjBbcIhGzMpDSyGYNhGPPRoYdp = false;
			ySKRlxVNISomhhIFpvZEYocyuLo = false;
			GBctTtambVDrGmgNSbmaIAPqDQOB = false;
		}

		private void oJScKMoyuMjmQLXNPZrQqtfkrPP()
		{
			if (dRmTcpOPHjzqmIsaGEdrISZApWy != null)
			{
				dRmTcpOPHjzqmIsaGEdrISZApWy();
			}
			wkHhrcUhfnaPWbRoirggYGSZaIe.xqyuuQSofyjoJulEXgAcFSYaDtu();
		}

		private void IsHEPGDcapJjIIIwabNlagrgYHK(bool[] P_0, ref iwXeIxFxATgRjwLZBDdojwPflAL P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= DNqovhkJyMGDmjBrJizqLZxIBwWP)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				HwRqYBlbrIoKtVDOMNmmVOGCrNt[i] = QkOJeQjNoGuvJJcCjzkxhFnepjH(axes_orig[i], P_0, ref P_1);
				if (!RZErYKzcoEvfMnhtHeFDeTWjAxp && HwRqYBlbrIoKtVDOMNmmVOGCrNt[i] != 0f)
				{
					RZErYKzcoEvfMnhtHeFDeTWjAxp = true;
				}
			}
		}

		private void xEfKEFgwOpPyjRLoWJIEfoNdBYF(bool[] P_0, ref iwXeIxFxATgRjwLZBDdojwPflAL P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)XCAyIFRJbEWUeBcnVweevmqWqtw.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= ElNlKPkIldnwOTDKjHUmDVOsEYGs)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				xrmDwADRXdFsenTurfwlUsqsAvb[i] = eRRRbnNJkvBkNLMFRFRiaMhIthSB(buttons_orig[i], P_0, ref P_1);
				if (!RZErYKzcoEvfMnhtHeFDeTWjAxp && xrmDwADRXdFsenTurfwlUsqsAvb[i])
				{
					RZErYKzcoEvfMnhtHeFDeTWjAxp = true;
				}
			}
		}

		private float QkOJeQjNoGuvJJcCjzkxhFnepjH(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref iwXeIxFxATgRjwLZBDdojwPflAL P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return QkOJeQjNoGuvJJcCjzkxhFnepjH(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!eRRRbnNJkvBkNLMFRFRiaMhIthSB(P_0.sourceButton, P_1))
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

		private float QkOJeQjNoGuvJJcCjzkxhFnepjH(XInputAxis P_0, ref iwXeIxFxATgRjwLZBDdojwPflAL P_1)
		{
			switch (P_0)
			{
			case XInputAxis.LeftThumbX:
				return dmOmXokuwYPeqkLCCIorsBnvJVN(P_1.gRiXSTKZXkAdtsQJdSQkmGuyYzm);
			case XInputAxis.LeftThumbY:
				return dmOmXokuwYPeqkLCCIorsBnvJVN(P_1.MsQbYKAWABPQCnImMvHHQwCCHRgR);
			case XInputAxis.RightThumbX:
				return dmOmXokuwYPeqkLCCIorsBnvJVN(P_1.SMQoXluLNVzmEZlKMMfCiegChTz);
			case XInputAxis.RightThumbY:
				return dmOmXokuwYPeqkLCCIorsBnvJVN(P_1.yzlvGLmdQaTKwYIbPTWvtxQUuqG);
			case XInputAxis.LeftTrigger:
				return iHwyjUtvRZuEyzLKTUFdpYqTrQn(P_1.MUsjsoeANpgntctmRPedxuentaz);
			case XInputAxis.RightTrigger:
				return iHwyjUtvRZuEyzLKTUFdpYqTrQn(P_1.eAmeSqdrQhJnhelLdgJVkVvecGcS);
			default:
				return 0f;
			}
		}

		private bool eRRRbnNJkvBkNLMFRFRiaMhIthSB(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref iwXeIxFxATgRjwLZBDdojwPflAL P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return eRRRbnNJkvBkNLMFRFRiaMhIthSB(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = QkOJeQjNoGuvJJcCjzkxhFnepjH(P_0.sourceAxis, ref P_2);
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

		private bool eRRRbnNJkvBkNLMFRFRiaMhIthSB(XInputButton P_0, bool[] P_1)
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

		private float dmOmXokuwYPeqkLCCIorsBnvJVN(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float iHwyjUtvRZuEyzLKTUFdpYqTrQn(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private void XCEcogOtFbmhupWduawPDMqkEjv()
		{
			XCAyIFRJbEWUeBcnVweevmqWqtw = lvntcpgdZsSbabccpIcfMpTzYYr(PJFgAzlnjXDIFtIVMtyxcOgBHLL());
			while (true)
			{
				switch (-843936832 ^ -843936830)
				{
				case 0:
					continue;
				case 2:
					if (XCAyIFRJbEWUeBcnVweevmqWqtw == null)
					{
						Rewired.Logger.LogError("Default hardware map not found!");
						return;
					}
					break;
				}
				break;
			}
			DNqovhkJyMGDmjBrJizqLZxIBwWP = XCAyIFRJbEWUeBcnVweevmqWqtw.axisCount;
			ElNlKPkIldnwOTDKjHUmDVOsEYGs = XCAyIFRJbEWUeBcnVweevmqWqtw.buttonCount;
		}

		private bool TkrDEJkZAVGkORzhjeCdTklgClMY(ref PTYoizLivOqKtIIuCrxoWaiEvuN P_0)
		{
			if (P_0.XYSEEeIHUHhvFRSAkwDJxVqpwQK > 0 || P_0.CKNOcVEDaeaBdjnHPbNoBjFMMhA > 0)
			{
				return true;
			}
			return false;
		}

		private void cVBFTRkNZRbeRlUCBycutPaJbAus(ref PTYoizLivOqKtIIuCrxoWaiEvuN P_0)
		{
			P_0.XYSEEeIHUHhvFRSAkwDJxVqpwQK = 0;
			P_0.CKNOcVEDaeaBdjnHPbNoBjFMMhA = 0;
		}

		private void qTmfkOrEBrsBIcoXzWoMvhPthwqE(ref PTYoizLivOqKtIIuCrxoWaiEvuN P_0, ref PTYoizLivOqKtIIuCrxoWaiEvuN P_1)
		{
			P_1.XYSEEeIHUHhvFRSAkwDJxVqpwQK = P_0.XYSEEeIHUHhvFRSAkwDJxVqpwQK;
			P_1.CKNOcVEDaeaBdjnHPbNoBjFMMhA = P_0.CKNOcVEDaeaBdjnHPbNoBjFMMhA;
		}

		private string RTTlCdhTqgSczdNjerRfpyDBDni()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}", ReInput.currentPlatform.ToString(), InputSource.XInput.ToString(), AgFzIkLgLYjOlqPCtjppfuTCSDg.ToString(), ynSMEBTXNkIOhxNnIkeAyVvAtyw.ToString()));
		}

		private void qLdgPikrSeiPWSEbkkdRitWDfeYu(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			while (true)
			{
				int num = 1902625855;
				while (true)
				{
					switch (num ^ 0x7167C43C)
					{
					case 5:
						break;
					case 4:
						P_0.hardwareButtonCount = aCdTArmyUaJIYSBpkbuJpDufgNGc;
						P_0.hardwareHatCount = 0;
						P_0.hw_productName = productName;
						num = 1902625852;
						continue;
					case 1:
						P_0.hardwareAxisCount = dhEQLHuCYYGQwdehmJKXAJgttVWs;
						num = 1902625848;
						continue;
					case 2:
						P_0.hardwareIdentifier = RTTlCdhTqgSczdNjerRfpyDBDni();
						num = 1902625853;
						continue;
					case 3:
						P_0.inputSource = P_0.inputManagerSource;
						P_0.deviceType = ControlDeviceType.srbgNzJMznryeuABhpjzUCNZxjJP;
						num = 1902625854;
						continue;
					default:
						P_0.hw_supportsVoice = twjPaZyadPbHzhImzNWmBlIILpqn;
						P_0.hw_supportsVibration = uyjBbcIhGzMpDSyGYNhGPPRoYdp;
						P_0.hw_localVibrationMotorCount = (uyjBbcIhGzMpDSyGYNhGPPRoYdp ? 2 : 0);
						P_0.hw_xInputSubType = ynSMEBTXNkIOhxNnIkeAyVvAtyw;
						return;
					}
					break;
				}
			}
		}

		private void qLdgPikrSeiPWSEbkkdRitWDfeYu(BridgedController P_0)
		{
			qLdgPikrSeiPWSEbkkdRitWDfeYu((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = XCAyIFRJbEWUeBcnVweevmqWqtw.ToGameHardwareControllerMap();
			P_0.instanceName = "XInput " + instanceName;
			P_0.productName = "XInput " + productName;
			P_0.isXInputDevice = true;
			P_0.axisCount = DNqovhkJyMGDmjBrJizqLZxIBwWP;
			P_0.buttonCount = ElNlKPkIldnwOTDKjHUmDVOsEYGs;
			P_0.controllerTypeGuid = FHAzoTozCrisunLDoLyimqNbdex;
			P_0.controllerExtension = extension;
		}

		public void Dispose()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
			GC.SuppressFinalize(this);
		}

		~KqZijOiESkOKxmSFgvxVuYITJco()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
		}

		protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
		{
			if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
			{
				goto IL_0008;
			}
			goto IL_004c;
			IL_0008:
			int num = 1488699037;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x58BBBE9E)
				{
				case 2:
					break;
				case 5:
					if (wkHhrcUhfnaPWbRoirggYGSZaIe != null)
					{
						wkHhrcUhfnaPWbRoirggYGSZaIe.Dispose();
						num = 1488699038;
						continue;
					}
					goto IL_0082;
				case 4:
					goto IL_004c;
				case 1:
					kYVEkOHTXBhxnrAeWMuOTcRgNeH.YaYZPAdPxkMvqsWTDGTUuXPRvJL();
					num = 1488699035;
					continue;
				case 3:
					return;
				default:
					goto IL_0082;
				}
				break;
			}
			goto IL_0008;
			IL_0082:
			nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
			return;
			IL_004c:
			if (P_0)
			{
				int num2;
				if (!isConnected)
				{
					num = 1488699035;
					num2 = num;
				}
				else
				{
					num = 1488699039;
					num2 = num;
				}
				goto IL_000d;
			}
			goto IL_0082;
		}
	}

	private class ATJiDUuWmuBrMMcYOUVUeBiTCms
	{
		private class OaoZkQvLNbFOhDZClkGhxcQcsAd
		{
			public bool dDECQoCkogpGGlPJKcKjORPQEEcW;

			public int OHBcezjWhuCjOisuXXaxDLGlnPLC;

			public XInputDeviceSubType ynSMEBTXNkIOhxNnIkeAyVvAtyw;

			public void OKHZGFMfxtklwLbZuCziRQFTDNac(KqZijOiESkOKxmSFgvxVuYITJco P_0, bool P_1)
			{
				dDECQoCkogpGGlPJKcKjORPQEEcW = P_1;
				OHBcezjWhuCjOisuXXaxDLGlnPLC = P_0.rewiredId;
				while (true)
				{
					int num = 376842167;
					while (true)
					{
						switch (num ^ 0x167627B6)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0031;
						case 2:
							return;
						}
						break;
						IL_0031:
						ynSMEBTXNkIOhxNnIkeAyVvAtyw = P_0.ynSMEBTXNkIOhxNnIkeAyVvAtyw;
						num = 376842164;
					}
				}
			}

			public OaoZkQvLNbFOhDZClkGhxcQcsAd(int rewiredId, XInputDeviceSubType deviceSubType)
			{
				OHBcezjWhuCjOisuXXaxDLGlnPLC = rewiredId;
				ynSMEBTXNkIOhxNnIkeAyVvAtyw = deviceSubType;
			}
		}

		private List<OaoZkQvLNbFOhDZClkGhxcQcsAd> hdvnYESDqWrpDISRbrulIlAPAqTj;

		public ATJiDUuWmuBrMMcYOUVUeBiTCms()
		{
			hdvnYESDqWrpDISRbrulIlAPAqTj = new List<OaoZkQvLNbFOhDZClkGhxcQcsAd>();
		}

		public void jjWrMKWdWPxSxeFhKeLSxKLMcPm(KqZijOiESkOKxmSFgvxVuYITJco P_0, bool P_1)
		{
			int num = QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0.rewiredId, P_0.ynSMEBTXNkIOhxNnIkeAyVvAtyw, true);
			if (num >= 0)
			{
				return;
			}
			while (true)
			{
				OaoZkQvLNbFOhDZClkGhxcQcsAd oaoZkQvLNbFOhDZClkGhxcQcsAd = new OaoZkQvLNbFOhDZClkGhxcQcsAd(P_0.rewiredId, P_0.ynSMEBTXNkIOhxNnIkeAyVvAtyw);
				oaoZkQvLNbFOhDZClkGhxcQcsAd.dDECQoCkogpGGlPJKcKjORPQEEcW = P_1;
				int num2 = -1299780986;
				while (true)
				{
					switch (num2 ^ -1299780988)
					{
					case 0:
						goto IL_0019;
					case 1:
						break;
					default:
						hdvnYESDqWrpDISRbrulIlAPAqTj.Add(oaoZkQvLNbFOhDZClkGhxcQcsAd);
						return;
					}
					break;
					IL_0019:
					num2 = -1299780987;
				}
			}
		}

		public void OKHZGFMfxtklwLbZuCziRQFTDNac(int P_0, KqZijOiESkOKxmSFgvxVuYITJco P_1, bool P_2)
		{
			if (P_0 < 0)
			{
				return;
			}
			if (P_0 >= hdvnYESDqWrpDISRbrulIlAPAqTj.Count)
			{
				while (true)
				{
					switch (0x43819679 ^ 0x4381967B)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			hdvnYESDqWrpDISRbrulIlAPAqTj[P_0].OKHZGFMfxtklwLbZuCziRQFTDNac(P_1, P_2);
		}

		public int nySNzzIwtpdDxNyGrJXbvkGigDI(XInputDeviceSubType P_0, bool P_1)
		{
			int count = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -913411624;
				while (true)
				{
					switch (num ^ -913411621)
					{
					case 4:
						break;
					case 0:
						if (hdvnYESDqWrpDISRbrulIlAPAqTj[num2].ynSMEBTXNkIOhxNnIkeAyVvAtyw == P_0)
						{
							return num2;
						}
						goto IL_004c;
					case 5:
						if (!hdvnYESDqWrpDISRbrulIlAPAqTj[num2].dDECQoCkogpGGlPJKcKjORPQEEcW)
						{
							num = -913411621;
							continue;
						}
						goto IL_004c;
					case 2:
					{
						int num3;
						if (!P_1)
						{
							num = -913411618;
							num3 = num;
						}
						else
						{
							num = -913411621;
							num3 = num;
						}
						continue;
					}
					case 3:
						num2 = 0;
						num = -913411622;
						continue;
					default:
						{
							if (num2 >= count)
							{
								return -1;
							}
							goto case 2;
						}
						IL_004c:
						num2++;
						num = -913411622;
						continue;
					}
					break;
				}
			}
		}

		public int QfvcPTCkQKNaHrLDCOXTjZcrUbW(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = hdvnYESDqWrpDISRbrulIlAPAqTj.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 1546958896;
				while (true)
				{
					switch (num ^ 0x5C34B831)
					{
					case 0:
						break;
					case 2:
						return num2;
					case 4:
						if (!P_2)
						{
							if (!hdvnYESDqWrpDISRbrulIlAPAqTj[num2].dDECQoCkogpGGlPJKcKjORPQEEcW)
							{
								num = 1546958898;
								continue;
							}
							goto IL_0038;
						}
						goto case 3;
					case 3:
						if (hdvnYESDqWrpDISRbrulIlAPAqTj[num2].OHBcezjWhuCjOisuXXaxDLGlnPLC == P_0 && hdvnYESDqWrpDISRbrulIlAPAqTj[num2].ynSMEBTXNkIOhxNnIkeAyVvAtyw == P_1)
						{
							num = 1546958899;
							continue;
						}
						goto IL_0038;
					case 1:
						num2 = 0;
						num = 1546958900;
						continue;
					default:
						{
							if (num2 >= count)
							{
								return -1;
							}
							goto case 4;
						}
						IL_0038:
						num2++;
						num = 1546958900;
						continue;
					}
					break;
				}
			}
		}

		public int GEZvNBPLipPRSGmXeewoWFjylAA(int P_0)
		{
			if (P_0 >= 0)
			{
				if (P_0 < hdvnYESDqWrpDISRbrulIlAPAqTj.Count)
				{
					goto IL_003d;
				}
				while (true)
				{
					switch (-1345081845 ^ -1345081846)
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
			return hdvnYESDqWrpDISRbrulIlAPAqTj[P_0].OHBcezjWhuCjOisuXXaxDLGlnPLC;
		}

		public void zENaiPxsdrQYCcJwFCLlhWcwhPs(int P_0, bool P_1)
		{
			if (P_0 < 0)
			{
				return;
			}
			if (P_0 >= hdvnYESDqWrpDISRbrulIlAPAqTj.Count)
			{
				while (true)
				{
					switch (-1369894815 ^ -1369894816)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			hdvnYESDqWrpDISRbrulIlAPAqTj[P_0].dDECQoCkogpGGlPJKcKjORPQEEcW = P_1;
		}
	}

	private class qengjbOJTbcstGAcYhwCcFXZOAx
	{
		public bool COqflciihFbHBTOXKDGWNMGXmBd;

		private float UmjvBLVJuPfyJElnLwpoBuvZSXcd;

		public float qQrMsIBjrmxBFOrAWHTVkrzFtPW;

		public qengjbOJTbcstGAcYhwCcFXZOAx()
		{
		}

		public qengjbOJTbcstGAcYhwCcFXZOAx(float inLength)
		{
			while (true)
			{
				int num = -743733854;
				while (true)
				{
					switch (num ^ -743733853)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0024;
					case 0:
						return;
					}
					break;
					IL_0024:
					qQrMsIBjrmxBFOrAWHTVkrzFtPW = inLength;
					num = -743733853;
				}
			}
		}

		public void JNpqtseTgVDsLidqlJBYdNCXmOC()
		{
			COqflciihFbHBTOXKDGWNMGXmBd = true;
			UmjvBLVJuPfyJElnLwpoBuvZSXcd = qQrMsIBjrmxBFOrAWHTVkrzFtPW + ReInput.unscaledTime;
		}

		public void JNpqtseTgVDsLidqlJBYdNCXmOC(float P_0)
		{
			COqflciihFbHBTOXKDGWNMGXmBd = true;
			qQrMsIBjrmxBFOrAWHTVkrzFtPW = P_0;
			UmjvBLVJuPfyJElnLwpoBuvZSXcd = qQrMsIBjrmxBFOrAWHTVkrzFtPW + ReInput.unscaledTime;
		}

		public bool OKHZGFMfxtklwLbZuCziRQFTDNac()
		{
			if (!COqflciihFbHBTOXKDGWNMGXmBd)
			{
				return false;
			}
			if (ReInput.unscaledTime >= UmjvBLVJuPfyJElnLwpoBuvZSXcd)
			{
				COqflciihFbHBTOXKDGWNMGXmBd = false;
				return true;
			}
			return false;
		}

		public void fWzuAFjFXxdRoqxypOAIFkBEHOX()
		{
			COqflciihFbHBTOXKDGWNMGXmBd = false;
			UmjvBLVJuPfyJElnLwpoBuvZSXcd = 0f;
		}

		public void GIDaaxxZCbnYhgIAGYWXSiQVKmZ(float P_0)
		{
			qQrMsIBjrmxBFOrAWHTVkrzFtPW = P_0;
		}

		public qengjbOJTbcstGAcYhwCcFXZOAx CfogEZDOkmkbFzEsmaaksGjLcEXi()
		{
			return (qengjbOJTbcstGAcYhwCcFXZOAx)MemberwiseClone();
		}
	}

	public class VXjTLrVLbRqsejihSLeLmdPOFyL : IDisposable
	{
		private readonly ButtonLoopSet lOmtwKWetNmUEsKoXlYsIGMqOSm;

		private readonly DualRingReportBuffer cEYnsvdZEgpKUOcsxEpoXmVeOaF;

		public readonly sqXlWvYVilwtaUcCZHHGGlfPRRvA adAqkIwrnbCGtQfPxaJibXYUYAC;

		public iwXeIxFxATgRjwLZBDdojwPflAL ABeDBrDOYXRyETwPWnmCRizVbzMK;

		private int KmBLcQHPTHOySGPCAaxzSCYlYmv;

		private bool tNTCfSzrXJZuOnbCfNhelnFFgApE;

		private bool FFnEkAKwASRJkcemYJaZjxghcDRP;

		private byte[] rXYbyQgsCXdWzmrqPlgwHHWWNvN;

		private byte[] siQVDcvmheIRNToTkUevWkMUmhZ;

		private RingBuffer<PTYoizLivOqKtIIuCrxoWaiEvuN> MNPoxUNBIoHOJYuqSchcmmLKCvt = new RingBuffer<PTYoizLivOqKtIIuCrxoWaiEvuN>(5);

		private RingBuffer<PTYoizLivOqKtIIuCrxoWaiEvuN> SMKszCeDnoFeSkYtjsCkTmdNpRDo = new RingBuffer<PTYoizLivOqKtIIuCrxoWaiEvuN>(5);

		private readonly object kCQIRYxDMpEDFbmesTbilzpEZGKa = new object();

		private readonly object nPnMjtypsaULEfwQdWFOxHTHSdp = new object();

		private PTYoizLivOqKtIIuCrxoWaiEvuN XumGSBOtDmBHAcuLwUkpNKtRaqga;

		private float tWWAQokJRAfwvjKkJsgWUeOOBrtG;

		private bool nYnvJCdSwCjafdvZoFKnjAkIRCs;

		public bool[] CurrentButtonValues
		{
			get
			{
				return lOmtwKWetNmUEsKoXlYsIGMqOSm.Current.effectiveValue;
			}
		}

		public VXjTLrVLbRqsejihSLeLmdPOFyL(int controllerIndex, UpdateLoopSetting updateLoops)
		{
			while (true)
			{
				int num = -375622201;
				while (true)
				{
					switch (num ^ -375622202)
					{
					case 0:
						break;
					case 1:
						adAqkIwrnbCGtQfPxaJibXYUYAC = new sqXlWvYVilwtaUcCZHHGGlfPRRvA((SgHhHlhiTXjIQWLzuswWgWKHHxp)controllerIndex);
						num = -375622204;
						continue;
					case 2:
						cEYnsvdZEgpKUOcsxEpoXmVeOaF = new DualRingReportBuffer(18, 25);
						rXYbyQgsCXdWzmrqPlgwHHWWNvN = cEYnsvdZEgpKUOcsxEpoXmVeOaF.ReadBuffer;
						lOmtwKWetNmUEsKoXlYsIGMqOSm = new ButtonLoopSet(updateLoops, 15);
						num = -375622203;
						continue;
					default:
						siQVDcvmheIRNToTkUevWkMUmhZ = new byte[18];
						return;
					}
					break;
				}
			}
		}

		public void WRFQiHBTiHTxzhBXcGRzCalCNF()
		{
			lOmtwKWetNmUEsKoXlYsIGMqOSm.SetUpdateLoop(ReInput.currentUpdateLoop);
			KBTYVaAcpOYdjReoasoHpzhCltL(ref ABeDBrDOYXRyETwPWnmCRizVbzMK);
		}

		public void aqqkTdOMGLHPIIcYrYTpjUXAOZk()
		{
			vHihLCoLHogytvjXNmhqwquSXsW();
			lOmtwKWetNmUEsKoXlYsIGMqOSm.Current.ClearWasTrueThisFrame();
		}

		public void OPrDnVhLcontoTptCznHaDrwNsAh()
		{
			IbWidGCHJzvyGGwvigfCOXYPcWYT();
			tNTCfSzrXJZuOnbCfNhelnFFgApE = true;
			FFnEkAKwASRJkcemYJaZjxghcDRP = adAqkIwrnbCGtQfPxaJibXYUYAC.IsConnected;
		}

		public void xqyuuQSofyjoJulEXgAcFSYaDtu()
		{
			tNTCfSzrXJZuOnbCfNhelnFFgApE = false;
			FFnEkAKwASRJkcemYJaZjxghcDRP = false;
			IbWidGCHJzvyGGwvigfCOXYPcWYT();
		}

		public bool HlMyyMcEdYUuBguZHQkVQBAbFAp(ORvCMajzfaKsgomdBGYGJVUcbwQ P_0)
		{
			switch (P_0)
			{
			case ORvCMajzfaKsgomdBGYGJVUcbwQ.tskJsIsvmUkbpEjaLqwjCFbCKtP:
				return FFnEkAKwASRJkcemYJaZjxghcDRP = adAqkIwrnbCGtQfPxaJibXYUYAC.IsConnected;
			case ORvCMajzfaKsgomdBGYGJVUcbwQ.FQKPhyZCKUPSsUOKuvozgXhfOSh:
				return FFnEkAKwASRJkcemYJaZjxghcDRP;
			default:
				throw new NotImplementedException();
			}
		}

		public void wSwWZlMaWbyLCJABzuaHkvKQzPs(float P_0, int P_1)
		{
			if (P_1 == 0)
			{
				goto IL_0003;
			}
			goto IL_0029;
			IL_0003:
			int num = -1760054431;
			goto IL_0008;
			IL_0008:
			while (true)
			{
				switch (num ^ -1760054432)
				{
				case 0:
					break;
				case 3:
					goto IL_0029;
				case 4:
					num = -1760054430;
					continue;
				case 1:
					XumGSBOtDmBHAcuLwUkpNKtRaqga.XYSEEeIHUHhvFRSAkwDJxVqpwQK = (ushort)(MathTools.Clamp01(P_0) * 65535f);
					num = -1760054428;
					continue;
				default:
					goto IL_0072;
				}
				break;
			}
			goto IL_0003;
			IL_0072:
			quDwTkfDUHRptmZLoNjMidyvjWp();
			return;
			IL_0029:
			if (P_1 == 1)
			{
				XumGSBOtDmBHAcuLwUkpNKtRaqga.CKNOcVEDaeaBdjnHPbNoBjFMMhA = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				num = -1760054430;
				goto IL_0008;
			}
			goto IL_0072;
		}

		public void bWQnirdkyrnHUiWahNqkBCTSTtg()
		{
			XumGSBOtDmBHAcuLwUkpNKtRaqga.XYSEEeIHUHhvFRSAkwDJxVqpwQK = 0;
			XumGSBOtDmBHAcuLwUkpNKtRaqga.CKNOcVEDaeaBdjnHPbNoBjFMMhA = 0;
			quDwTkfDUHRptmZLoNjMidyvjWp();
		}

		public void YaYZPAdPxkMvqsWTDGTUuXPRvJL()
		{
			XumGSBOtDmBHAcuLwUkpNKtRaqga.XYSEEeIHUHhvFRSAkwDJxVqpwQK = 0;
			XumGSBOtDmBHAcuLwUkpNKtRaqga.CKNOcVEDaeaBdjnHPbNoBjFMMhA = 0;
			lock (nPnMjtypsaULEfwQdWFOxHTHSdp)
			{
				lock (kCQIRYxDMpEDFbmesTbilzpEZGKa)
				{
					MNPoxUNBIoHOJYuqSchcmmLKCvt.Clear();
					SMKszCeDnoFeSkYtjsCkTmdNpRDo.Clear();
					XAxoPmIiiBwSythlCeJkKmZBQZka(adAqkIwrnbCGtQfPxaJibXYUYAC, XumGSBOtDmBHAcuLwUkpNKtRaqga, ref tWWAQokJRAfwvjKkJsgWUeOOBrtG);
				}
			}
		}

		public void ZvdjXtcKfvDQHpLlaUAbSkyMBtH()
		{
			if (!tNTCfSzrXJZuOnbCfNhelnFFgApE || !FFnEkAKwASRJkcemYJaZjxghcDRP)
			{
				return;
			}
			SqfIxCAexVGqxOUKUOOcddYeiFy sqfIxCAexVGqxOUKUOOcddYeiFy;
			float realTime;
			try
			{
				if (!adAqkIwrnbCGtQfPxaJibXYUYAC.ywaKScJKEmFggHYMfPPWqeLsEHa(out sqfIxCAexVGqxOUKUOOcddYeiFy))
				{
					FFnEkAKwASRJkcemYJaZjxghcDRP = false;
					while (true)
					{
						switch (-1822278195 ^ -1822278193)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				realTime = ReInput.realTime;
			}
			catch
			{
				FFnEkAKwASRJkcemYJaZjxghcDRP = false;
				return;
			}
			RJUGUPDzIskBIapwupNzLnvkTFJ(ref sqfIxCAexVGqxOUKUOOcddYeiFy.dhUtEzDFvpZQnDBlTeAFXyELNJz, realTime, siQVDcvmheIRNToTkUevWkMUmhZ);
			cEYnsvdZEgpKUOcsxEpoXmVeOaF.Write(siQVDcvmheIRNToTkUevWkMUmhZ, 18);
		}

		public void gmcOXeIgdAsLPqMfUtjnkGNbqSp()
		{
			if (!tNTCfSzrXJZuOnbCfNhelnFFgApE || !FFnEkAKwASRJkcemYJaZjxghcDRP || ReInput.realTime < tWWAQokJRAfwvjKkJsgWUeOOBrtG + 0.01f)
			{
				return;
			}
			lock (nPnMjtypsaULEfwQdWFOxHTHSdp)
			{
				lock (kCQIRYxDMpEDFbmesTbilzpEZGKa)
				{
					MiscTools.Swap(ref MNPoxUNBIoHOJYuqSchcmmLKCvt, ref SMKszCeDnoFeSkYtjsCkTmdNpRDo);
				}
				dySPSqOEuGqnOLKlSVadLGRUUgV(SMKszCeDnoFeSkYtjsCkTmdNpRDo, adAqkIwrnbCGtQfPxaJibXYUYAC, ref tWWAQokJRAfwvjKkJsgWUeOOBrtG);
			}
		}

		private void vHihLCoLHogytvjXNmhqwquSXsW()
		{
			YCSAbYlssPBTTpXQeYSVgeQPkgV();
		}

		private void YCSAbYlssPBTTpXQeYSVgeQPkgV()
		{
			if (!(ReInput.realTime < tWWAQokJRAfwvjKkJsgWUeOOBrtG + 1.5f) && (!Mathf.Approximately((int)XumGSBOtDmBHAcuLwUkpNKtRaqga.XYSEEeIHUHhvFRSAkwDJxVqpwQK, 0f) || !Mathf.Approximately((int)XumGSBOtDmBHAcuLwUkpNKtRaqga.CKNOcVEDaeaBdjnHPbNoBjFMMhA, 0f)))
			{
				quDwTkfDUHRptmZLoNjMidyvjWp();
			}
		}

		private void quDwTkfDUHRptmZLoNjMidyvjWp()
		{
			lock (kCQIRYxDMpEDFbmesTbilzpEZGKa)
			{
				MNPoxUNBIoHOJYuqSchcmmLKCvt.Enqueue(XumGSBOtDmBHAcuLwUkpNKtRaqga);
			}
		}

		private static void dySPSqOEuGqnOLKlSVadLGRUUgV(RingBuffer<PTYoizLivOqKtIIuCrxoWaiEvuN> P_0, sqXlWvYVilwtaUcCZHHGGlfPRRvA P_1, ref float P_2)
		{
			if (P_0.Count > 0)
			{
				XAxoPmIiiBwSythlCeJkKmZBQZka(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void XAxoPmIiiBwSythlCeJkKmZBQZka(sqXlWvYVilwtaUcCZHHGGlfPRRvA P_0, PTYoizLivOqKtIIuCrxoWaiEvuN P_1, ref float P_2)
		{
			try
			{
				P_0.wSwWZlMaWbyLCJABzuaHkvKQzPs(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private unsafe void KBTYVaAcpOYdjReoasoHpzhCltL(ref iwXeIxFxATgRjwLZBDdojwPflAL P_0)
		{
			int num = cEYnsvdZEgpKUOcsxEpoXmVeOaF.StartRead() / 18;
			if (num == 0)
			{
				return;
			}
			while (cEYnsvdZEgpKUOcsxEpoXmVeOaF.Read() > 0)
			{
				int num2;
				if (num > 1)
				{
					num2 = BitConverter.ToInt32(rXYbyQgsCXdWzmrqPlgwHHWWNvN, 0);
				}
				else
				{
					KjZFfqzMCDrSfHCekIzbKcfdxHT(rXYbyQgsCXdWzmrqPlgwHHWWNvN, ref P_0);
					num2 = (int)P_0.StZBYGkviapTxbBkcxUZtsvTSde;
				}
				float timestamp;
				fixed (byte* ptr = rXYbyQgsCXdWzmrqPlgwHHWWNvN)
				{
					timestamp = *(float*)(ptr + 14);
				}
				for (int i = 0; i < 15; i++)
				{
					lOmtwKWetNmUEsKoXlYsIGMqOSm.SetValue(i, eRRRbnNJkvBkNLMFRFRiaMhIthSB(num2, i), timestamp);
				}
				num--;
			}
			KmBLcQHPTHOySGPCAaxzSCYlYmv = (int)P_0.StZBYGkviapTxbBkcxUZtsvTSde;
		}

		private void KjZFfqzMCDrSfHCekIzbKcfdxHT(byte[] P_0, ref iwXeIxFxATgRjwLZBDdojwPflAL P_1)
		{
			P_1.StZBYGkviapTxbBkcxUZtsvTSde = (dlZmLSzbUNXGFOantBkGVKshfWMh)BitConverter.ToInt32(P_0, 0);
			P_1.gRiXSTKZXkAdtsQJdSQkmGuyYzm = BitConverter.ToInt16(P_0, 4);
			P_1.MsQbYKAWABPQCnImMvHHQwCCHRgR = BitConverter.ToInt16(P_0, 6);
			P_1.MUsjsoeANpgntctmRPedxuentaz = P_0[8];
			P_1.SMQoXluLNVzmEZlKMMfCiegChTz = BitConverter.ToInt16(P_0, 9);
			P_1.yzlvGLmdQaTKwYIbPTWvtxQUuqG = BitConverter.ToInt16(P_0, 11);
			P_1.eAmeSqdrQhJnhelLdgJVkVvecGcS = P_0[13];
		}

		private unsafe void RJUGUPDzIskBIapwupNzLnvkTFJ(ref iwXeIxFxATgRjwLZBDdojwPflAL P_0, float P_1, byte[] P_2)
		{
			int stZBYGkviapTxbBkcxUZtsvTSde = (int)P_0.StZBYGkviapTxbBkcxUZtsvTSde;
			P_2[0] = (byte)stZBYGkviapTxbBkcxUZtsvTSde;
			P_2[1] = (byte)(stZBYGkviapTxbBkcxUZtsvTSde >> 8);
			P_2[2] = (byte)(stZBYGkviapTxbBkcxUZtsvTSde >> 16);
			P_2[3] = (byte)(stZBYGkviapTxbBkcxUZtsvTSde >> 24);
			short gRiXSTKZXkAdtsQJdSQkmGuyYzm = P_0.gRiXSTKZXkAdtsQJdSQkmGuyYzm;
			P_2[4] = (byte)gRiXSTKZXkAdtsQJdSQkmGuyYzm;
			P_2[5] = (byte)(gRiXSTKZXkAdtsQJdSQkmGuyYzm >> 8);
			short msQbYKAWABPQCnImMvHHQwCCHRgR = P_0.MsQbYKAWABPQCnImMvHHQwCCHRgR;
			P_2[6] = (byte)msQbYKAWABPQCnImMvHHQwCCHRgR;
			P_2[7] = (byte)(msQbYKAWABPQCnImMvHHQwCCHRgR >> 8);
			P_2[8] = P_0.MUsjsoeANpgntctmRPedxuentaz;
			short sMQoXluLNVzmEZlKMMfCiegChTz = P_0.SMQoXluLNVzmEZlKMMfCiegChTz;
			P_2[9] = (byte)sMQoXluLNVzmEZlKMMfCiegChTz;
			P_2[10] = (byte)(sMQoXluLNVzmEZlKMMfCiegChTz >> 8);
			short yzlvGLmdQaTKwYIbPTWvtxQUuqG = P_0.yzlvGLmdQaTKwYIbPTWvtxQUuqG;
			P_2[11] = (byte)yzlvGLmdQaTKwYIbPTWvtxQUuqG;
			P_2[12] = (byte)(yzlvGLmdQaTKwYIbPTWvtxQUuqG >> 8);
			P_2[13] = P_0.eAmeSqdrQhJnhelLdgJVkVvecGcS;
			fixed (byte* ptr = P_2)
			{
				byte* ptr2 = ptr + 14;
				*(float*)ptr2 = P_1;
			}
		}

		private bool eRRRbnNJkvBkNLMFRFRiaMhIthSB(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void IbWidGCHJzvyGGwvigfCOXYPcWYT()
		{
			ABeDBrDOYXRyETwPWnmCRizVbzMK = default(iwXeIxFxATgRjwLZBDdojwPflAL);
			while (true)
			{
				int num = 10898194;
				while (true)
				{
					switch (num ^ 0xA64B13)
					{
					case 2:
						break;
					case 1:
						goto IL_002a;
					default:
						cEYnsvdZEgpKUOcsxEpoXmVeOaF.Clear();
						lock (rXYbyQgsCXdWzmrqPlgwHHWWNvN)
						{
							Array.Clear(rXYbyQgsCXdWzmrqPlgwHHWWNvN, 0, rXYbyQgsCXdWzmrqPlgwHHWWNvN.Length);
						}
						lock (siQVDcvmheIRNToTkUevWkMUmhZ)
						{
							Array.Clear(siQVDcvmheIRNToTkUevWkMUmhZ, 0, siQVDcvmheIRNToTkUevWkMUmhZ.Length);
						}
						KmBLcQHPTHOySGPCAaxzSCYlYmv = 0;
						return;
					}
					break;
					IL_002a:
					lOmtwKWetNmUEsKoXlYsIGMqOSm.Clear();
					num = 10898195;
				}
			}
		}

		public void Dispose()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(true);
			GC.SuppressFinalize(this);
		}

		~VXjTLrVLbRqsejihSLeLmdPOFyL()
		{
			JGfOaxGMMubjxaprhTWpWgtvAPZ(false);
		}

		protected virtual void JGfOaxGMMubjxaprhTWpWgtvAPZ(bool P_0)
		{
			if (nYnvJCdSwCjafdvZoFKnjAkIRCs)
			{
				return;
			}
			while (true)
			{
				int num = -933804731;
				while (true)
				{
					switch (num ^ -933804729)
					{
					case 0:
						num = -933804730;
						continue;
					default:
						return;
					case 1:
						break;
					case 2:
						nYnvJCdSwCjafdvZoFKnjAkIRCs = true;
						num = -933804732;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}
	}

	public enum ORvCMajzfaKsgomdBGYGJVUcbwQ
	{
		tskJsIsvmUkbpEjaLqwjCFbCKtP = 0,
		FQKPhyZCKUPSsUOKuvozgXhfOSh = 1
	}

	public const int KrfMeClKwKACGqUggoJMdmzDvwV = 4;

	public const int abyHpyXMAHLOkbXotwzKRHkwsHl = 32768;

	public const int zGFtTvfTdfdZfvKzjlybEygKkbU = -32768;

	public const int jyDhJCHRgUDuVVOhNFNjwUhoxYA = 255;

	public const int UkXCQKCttCZlHlzEpwDfeKTEogPC = 0;

	public const int VEPGURgfxdASVVpiQsYGelmKXeI = 18;

	public const int kKWaUGiJZRDttBBpJCDyrHtVTnnn = 14;

	public const int XqSRynZbEtVefepAGrLfKojJTGI = 6;

	public const int aQuJjuzBucKCVKHhdobvJOjyaVSD = 15;

	private KqZijOiESkOKxmSFgvxVuYITJco[] brCQInsIkpjgTRMVrMnDnNknICoE;

	private bool EcTqZRmFOUDNFBjyHNgaGcLICrl;

	private qengjbOJTbcstGAcYhwCcFXZOAx eOONEgCrUiObaqaYlRYHVxIBMZe;

	private ATJiDUuWmuBrMMcYOUVUeBiTCms yjuCHiamsFrchMyhFPFoVGeDabTa;

	private global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<bool> aigQAbLwpFCjkyEbDcZhCTMWhkgb;

	private bool[] aHOiAkZDEFxaeZxJowudjsiXmGP;

	private bool[] PkcynuGehmuUtpwHQbIcspooaFY;

	private bool iWbTStEEwSUFdVmxbhFLIRLEWpP;

	private readonly bool IFlZEiTccmkrKohcnBEDPQWAAOc;

	private readonly UpdateLoopSetting UQQWcNHYFojpbLDbwsmqFyOjcft;

	private UpdateLoopType hgLjcTavBVJFTsNgSkfipRAQlaYb;

	private UpdateLoopType ZLboOnzLswohXtoPNRLSWszkkNz;

	private Action<int, ControllerDataUpdater> OtrNTBJIBbQldvImDmKCAqMRnke;

	private bool JcdUyDxPOnbxUdUcqPoswEXulvi;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> lvntcpgdZsSbabccpIcfMpTzYYr;

	private Func<int> osCAPAIYOEZodlsEwtiFRgmwudTL;

	private static Guid[] miMOzRuEcrNUcmRFoIsrdaWYpod;

	private static string[] GlWCFMAyRhxGtHjWVsXUNsuOreV;

	private static string[] MuEQfhNWUuRFcJgZvxygdhZinBj;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			int num = 0;
			int num2 = 0;
			while (num2 < 4)
			{
				while (true)
				{
					int num3;
					if (brCQInsIkpjgTRMVrMnDnNknICoE[num2].isConnected)
					{
						num++;
						num3 = -315639941;
						goto IL_000b;
					}
					goto IL_0042;
					IL_000b:
					while (true)
					{
						switch (num3 ^ -315639943)
						{
						case 0:
							num3 = -315639944;
							continue;
						case 1:
							break;
						case 2:
							goto IL_0042;
						default:
							goto end_IL_0028;
						}
						break;
					}
					continue;
					IL_0042:
					num2++;
					num3 = -315639942;
					goto IL_000b;
					continue;
					end_IL_0028:
					break;
				}
			}
			return num;
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

	public khPCPJgtQFokObAEkJKNQbaUfSZG(bool isWin10AUHack, UpdateLoopSetting updateLoop, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		IFlZEiTccmkrKohcnBEDPQWAAOc = isWin10AUHack;
		UQQWcNHYFojpbLDbwsmqFyOjcft = updateLoop;
		JcdUyDxPOnbxUdUcqPoswEXulvi = true;
		try
		{
			if (!ReInput.isEditor)
			{
				Rewired.Logger.Log("Searching for compatible XInput library...");
			}
			DnqsiELfdajLMTaVEuZEtXPemKJ dnqsiELfdajLMTaVEuZEtXPemKJ;
			string text;
			int num;
			if (!ZTjdkWAkGMFOlwjyFpjqdQDLngXx.HtHLkuicvegUyNveVCXdfijLKttU(out dnqsiELfdajLMTaVEuZEtXPemKJ, out text, out num))
			{
				throw new Exception("XInput is not available.");
			}
			if (!ReInput.isEditor)
			{
				Rewired.Logger.Log("Found " + text + ".");
			}
			if (dnqsiELfdajLMTaVEuZEtXPemKJ < DnqsiELfdajLMTaVEuZEtXPemKJ.KELVzrMaIAKhlYYDGWmbhOVbFbcE)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				int num3 = 4;
			}
			lvntcpgdZsSbabccpIcfMpTzYYr = getHardwareJoystickMap_InputManager;
			osCAPAIYOEZodlsEwtiFRgmwudTL = getNewJoystickId;
			iWbTStEEwSUFdVmxbhFLIRLEWpP = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(UQQWcNHYFojpbLDbwsmqFyOjcft, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					ZLboOnzLswohXtoPNRLSWszkkNz = list[num2];
				}
			}
			aigQAbLwpFCjkyEbDcZhCTMWhkgb = new global::LLwWBrlwrzAzBgxVkRCTkMClAyJ<bool>(true, qTqcFGCDQYTxoCZPThbPnEgELZD);
			aHOiAkZDEFxaeZxJowudjsiXmGP = new bool[4];
			PkcynuGehmuUtpwHQbIcspooaFY = new bool[4];
			OtrNTBJIBbQldvImDmKCAqMRnke = UpdateControllerData;
			if (iWbTStEEwSUFdVmxbhFLIRLEWpP)
			{
				pVVycpDwxIAWedBpvsQuZHVXNEq();
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
		if (JcdUyDxPOnbxUdUcqPoswEXulvi)
		{
			goto IL_0008;
		}
		goto IL_0053;
		IL_0008:
		int num = 1614092807;
		goto IL_000d;
		IL_000d:
		VXjTLrVLbRqsejihSLeLmdPOFyL vXjTLrVLbRqsejihSLeLmdPOFyL = default(VXjTLrVLbRqsejihSLeLmdPOFyL);
		int num2 = default(int);
		while (true)
		{
			switch (num ^ 0x60351A04)
			{
			case 5:
				break;
			default:
				return;
			case 9:
				Update(UpdateLoopType.Update);
				num = 1614092806;
				continue;
			case 0:
				goto IL_0053;
			case 8:
				vXjTLrVLbRqsejihSLeLmdPOFyL = new VXjTLrVLbRqsejihSLeLmdPOFyL(num2, UQQWcNHYFojpbLDbwsmqFyOjcft);
				pJiWDIptILusPhrNPolPsYpexhh.joystickInputThread.ThreadUpdateEvent += vXjTLrVLbRqsejihSLeLmdPOFyL.ZvdjXtcKfvDQHpLlaUAbSkyMBtH;
				pJiWDIptILusPhrNPolPsYpexhh.joystickOutputThread.ThreadUpdateEvent += vXjTLrVLbRqsejihSLeLmdPOFyL.gmcOXeIgdAsLPqMfUtjnkGNbqSp;
				num = 1614092800;
				continue;
			case 1:
				brCQInsIkpjgTRMVrMnDnNknICoE = new KqZijOiESkOKxmSFgvxVuYITJco[4];
				num2 = 0;
				num = 1614092803;
				continue;
			case 7:
				goto IL_00d2;
			case 6:
				moCbSCIdctEwgaLiHsMbTrGDaOoJ(true);
				num = 1614092813;
				continue;
			case 4:
				brCQInsIkpjgTRMVrMnDnNknICoE[num2] = new KqZijOiESkOKxmSFgvxVuYITJco(num2, iWbTStEEwSUFdVmxbhFLIRLEWpP, vXjTLrVLbRqsejihSLeLmdPOFyL, lvntcpgdZsSbabccpIcfMpTzYYr, SystemDeviceDisconnected);
				num2++;
				num = 1614092803;
				continue;
			case 3:
				eOONEgCrUiObaqaYlRYHVxIBMZe = new qengjbOJTbcstGAcYhwCcFXZOAx(1f);
				num = 1614092804;
				continue;
			case 2:
				return;
			}
			break;
			IL_00d2:
			int num3;
			if (num2 < 4)
			{
				num = 1614092812;
				num3 = num;
			}
			else
			{
				num = 1614092802;
				num3 = num;
			}
		}
		goto IL_0008;
		IL_0053:
		yjuCHiamsFrchMyhFPFoVGeDabTa = new ATJiDUuWmuBrMMcYOUVUeBiTCms();
		int num4;
		if (brCQInsIkpjgTRMVrMnDnNknICoE != null)
		{
			num = 1614092802;
			num4 = num;
		}
		else
		{
			num = 1614092805;
			num4 = num;
		}
		goto IL_000d;
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		hgLjcTavBVJFTsNgSkfipRAQlaYb = currentUpdateLoop;
		fVTyjljPVNAOvCXNsxUbCrhFbJoi();
		int num = 0;
		while (true)
		{
			int num2 = 957354509;
			while (true)
			{
				switch (num2 ^ 0x3910120C)
				{
				case 2:
					break;
				case 1:
					num2 = 957354508;
					continue;
				case 4:
					num++;
					num2 = 957354508;
					continue;
				case 5:
					brCQInsIkpjgTRMVrMnDnNknICoE[num].Update();
					num2 = 957354504;
					continue;
				case 3:
					if (brCQInsIkpjgTRMVrMnDnNknICoE[num] != null)
					{
						int num3;
						if (brCQInsIkpjgTRMVrMnDnNknICoE[num].isConnected)
						{
							num2 = 957354505;
							num3 = num2;
						}
						else
						{
							num2 = 957354504;
							num3 = num2;
						}
						continue;
					}
					goto case 4;
				default:
					if (num >= 4)
					{
						return;
					}
					goto case 3;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (aigQAbLwpFCjkyEbDcZhCTMWhkgb != null)
		{
			aigQAbLwpFCjkyEbDcZhCTMWhkgb.JGfOaxGMMubjxaprhTWpWgtvAPZ();
			goto IL_0016;
		}
		goto IL_00a7;
		IL_0109:
		ZTjdkWAkGMFOlwjyFpjqdQDLngXx.bRtdbPdGDddcrbNGvrUXEsYzzDpm();
		return;
		IL_0016:
		int num = -1345271806;
		goto IL_001b;
		IL_001b:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -1345271805)
			{
			case 3:
				break;
			case 6:
				brCQInsIkpjgTRMVrMnDnNknICoE[num2].Dispose();
				num = -1345271805;
				continue;
			case 0:
				num2++;
				num = -1345271807;
				continue;
			case 4:
				if (brCQInsIkpjgTRMVrMnDnNknICoE[num2] == null)
				{
					goto case 0;
				}
				if (pJiWDIptILusPhrNPolPsYpexhh.joystickInputThread != null)
				{
					pJiWDIptILusPhrNPolPsYpexhh.joystickInputThread.ThreadUpdateEvent -= brCQInsIkpjgTRMVrMnDnNknICoE[num2].kYVEkOHTXBhxnrAeWMuOTcRgNeH.ZvdjXtcKfvDQHpLlaUAbSkyMBtH;
					num = -1345271802;
					continue;
				}
				goto case 5;
			case 1:
				goto IL_00a7;
			case 2:
				goto IL_00bb;
			case 5:
				if (pJiWDIptILusPhrNPolPsYpexhh.joystickOutputThread != null)
				{
					pJiWDIptILusPhrNPolPsYpexhh.joystickOutputThread.ThreadUpdateEvent -= brCQInsIkpjgTRMVrMnDnNknICoE[num2].kYVEkOHTXBhxnrAeWMuOTcRgNeH.gmcOXeIgdAsLPqMfUtjnkGNbqSp;
					num = -1345271803;
					continue;
				}
				goto case 6;
			default:
				goto IL_0109;
			}
			break;
			IL_00bb:
			int num3;
			if (num2 >= 4)
			{
				num = -1345271804;
				num3 = num;
			}
			else
			{
				num = -1345271801;
				num3 = num;
			}
		}
		goto IL_0016;
		IL_00a7:
		if (brCQInsIkpjgTRMVrMnDnNknICoE != null)
		{
			num2 = 0;
			num = -1345271807;
			goto IL_001b;
		}
		goto IL_0109;
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return OtrNTBJIBbQldvImDmKCAqMRnke;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		brCQInsIkpjgTRMVrMnDnNknICoE[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		moCbSCIdctEwgaLiHsMbTrGDaOoJ(true);
		while (true)
		{
			int num = -1099075521;
			while (true)
			{
				switch (num ^ -1099075522)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					ucwdqzwSVsTQfSkvVHuxTvTsQdR();
					num = -1099075523;
					continue;
				case 3:
					if (_SystemDeviceConnectedEvent != null)
					{
						_SystemDeviceConnectedEvent();
						num = -1099075522;
						continue;
					}
					return;
				case 0:
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		moCbSCIdctEwgaLiHsMbTrGDaOoJ(true);
		while (true)
		{
			int num = 1514967783;
			while (true)
			{
				switch (num ^ 0x5A4C92E5)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					ucwdqzwSVsTQfSkvVHuxTvTsQdR();
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
				num = 1514967780;
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

	private bool ULXNPsPOCXvyWsbGbxKCMMNksoO()
	{
		if (hgLjcTavBVJFTsNgSkfipRAQlaYb != ZLboOnzLswohXtoPNRLSWszkkNz)
		{
			goto IL_000e;
		}
		bool flag = eOONEgCrUiObaqaYlRYHVxIBMZe.OKHZGFMfxtklwLbZuCziRQFTDNac();
		int num = -21711964;
		goto IL_0013;
		IL_0013:
		while (true)
		{
			switch (num ^ -21711962)
			{
			case 0:
				break;
			case 3:
				return false;
			case 2:
				if (flag)
				{
					goto IL_0048;
				}
				goto default;
			default:
				return flag;
			}
			break;
			IL_0048:
			moCbSCIdctEwgaLiHsMbTrGDaOoJ(true);
			num = -21711961;
		}
		goto IL_000e;
		IL_000e:
		num = -21711963;
		goto IL_0013;
	}

	private void moCbSCIdctEwgaLiHsMbTrGDaOoJ(bool P_0)
	{
		EcTqZRmFOUDNFBjyHNgaGcLICrl = P_0;
		while (true)
		{
			int num = -1260550998;
			while (true)
			{
				switch (num ^ -1260550997)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					if (JcdUyDxPOnbxUdUcqPoswEXulvi)
					{
						goto IL_002d;
					}
					return;
				case 2:
					return;
				}
				break;
				IL_002d:
				eOONEgCrUiObaqaYlRYHVxIBMZe.JNpqtseTgVDsLidqlJBYdNCXmOC();
				num = -1260550999;
			}
		}
	}

	private void ucwdqzwSVsTQfSkvVHuxTvTsQdR()
	{
		if (aigQAbLwpFCjkyEbDcZhCTMWhkgb != null)
		{
			aigQAbLwpFCjkyEbDcZhCTMWhkgb.fWzuAFjFXxdRoqxypOAIFkBEHOX();
		}
	}

	private void pVVycpDwxIAWedBpvsQuZHVXNEq()
	{
		sqXlWvYVilwtaUcCZHHGGlfPRRvA sqXlWvYVilwtaUcCZHHGGlfPRRvA2 = new sqXlWvYVilwtaUcCZHHGGlfPRRvA();
		bool isConnected = sqXlWvYVilwtaUcCZHHGGlfPRRvA2.IsConnected;
	}

	private void fVTyjljPVNAOvCXNsxUbCrhFbJoi()
	{
		bool flag = false;
		if (JcdUyDxPOnbxUdUcqPoswEXulvi)
		{
			flag = ULXNPsPOCXvyWsbGbxKCMMNksoO();
			goto IL_0014;
		}
		goto IL_00bb;
		IL_0084:
		int num;
		int num2;
		if (!EcTqZRmFOUDNFBjyHNgaGcLICrl)
		{
			num = -1580798067;
			num2 = num;
		}
		else
		{
			num = -1580798065;
			num2 = num;
		}
		goto IL_0019;
		IL_0014:
		num = -1580798068;
		goto IL_0019;
		IL_0019:
		while (true)
		{
			switch (num ^ -1580798067)
			{
			case 7:
				break;
			default:
				return;
			case 6:
				if (aigQAbLwpFCjkyEbDcZhCTMWhkgb.xRKBBblbOUOOMSzhwnDVTLoUIDwi())
				{
					IVZQXBEcnUfnrWypyWboQvGXMjb();
					num = -1580798066;
					continue;
				}
				return;
			case 0:
				goto IL_0066;
			case 4:
				goto IL_0084;
			case 2:
				DOhDLCjrEVGqRuZllaswidbgatW();
				num = -1580798067;
				continue;
			case 5:
				return;
			case 1:
				goto IL_00bb;
			case 3:
				return;
			}
			break;
			IL_0066:
			int num3;
			if (!aigQAbLwpFCjkyEbDcZhCTMWhkgb.isRunning)
			{
				num = -1580798066;
				num3 = num;
			}
			else
			{
				num = -1580798069;
				num3 = num;
			}
		}
		goto IL_0014;
		IL_00bb:
		if (!flag && EcTqZRmFOUDNFBjyHNgaGcLICrl)
		{
			AcKhABurgQvielbBMbuhjCHLpjV(gelsyuHCPSmawCLfHhdlmdelsDm());
			moCbSCIdctEwgaLiHsMbTrGDaOoJ(false);
			ucwdqzwSVsTQfSkvVHuxTvTsQdR();
			num = -1580798072;
			goto IL_0019;
		}
		goto IL_0084;
	}

	private void DOhDLCjrEVGqRuZllaswidbgatW()
	{
		EcTqZRmFOUDNFBjyHNgaGcLICrl = false;
		if (!aigQAbLwpFCjkyEbDcZhCTMWhkgb.isRunning)
		{
			aigQAbLwpFCjkyEbDcZhCTMWhkgb.SFnUlcdGONKjYCbrEBAjYDBcYmz();
		}
	}

	private void IVZQXBEcnUfnrWypyWboQvGXMjb()
	{
		lock (aHOiAkZDEFxaeZxJowudjsiXmGP)
		{
			Array.Copy(aHOiAkZDEFxaeZxJowudjsiXmGP, PkcynuGehmuUtpwHQbIcspooaFY, 4);
		}
		AcKhABurgQvielbBMbuhjCHLpjV(PkcynuGehmuUtpwHQbIcspooaFY);
	}

	private bool qTqcFGCDQYTxoCZPThbPnEgELZD()
	{
		lock (aHOiAkZDEFxaeZxJowudjsiXmGP)
		{
			int num = 0;
			while (num < 4)
			{
				while (true)
				{
					int num2;
					if (brCQInsIkpjgTRMVrMnDnNknICoE[num] != null)
					{
						aHOiAkZDEFxaeZxJowudjsiXmGP[num] = brCQInsIkpjgTRMVrMnDnNknICoE[num].HlMyyMcEdYUuBguZHQkVQBAbFAp(ORvCMajzfaKsgomdBGYGJVUcbwQ.tskJsIsvmUkbpEjaLqwjCFbCKtP);
						num2 = 948071190;
						goto IL_0016;
					}
					goto IL_005a;
					IL_0016:
					while (true)
					{
						switch (num2 ^ 0x38826B16)
						{
						case 2:
							num2 = 948071189;
							continue;
						case 3:
							break;
						case 0:
							goto IL_005a;
						default:
							goto end_IL_0033;
						}
						break;
					}
					continue;
					IL_005a:
					num++;
					num2 = 948071191;
					goto IL_0016;
					continue;
					end_IL_0033:
					break;
				}
			}
		}
		return true;
	}

	private bool[] gelsyuHCPSmawCLfHhdlmdelsDm()
	{
		int num = 0;
		while (true)
		{
			int num2;
			int num3;
			if (num >= 4)
			{
				num2 = 550738262;
				num3 = num2;
			}
			else
			{
				num2 = 550738263;
				num3 = num2;
			}
			while (true)
			{
				switch (num2 ^ 0x20D39956)
				{
				case 3:
					num2 = 550738263;
					continue;
				case 1:
					PkcynuGehmuUtpwHQbIcspooaFY[num] = brCQInsIkpjgTRMVrMnDnNknICoE[num].HlMyyMcEdYUuBguZHQkVQBAbFAp(ORvCMajzfaKsgomdBGYGJVUcbwQ.tskJsIsvmUkbpEjaLqwjCFbCKtP);
					num++;
					num2 = 550738260;
					continue;
				case 2:
					break;
				default:
					return PkcynuGehmuUtpwHQbIcspooaFY;
				}
				break;
			}
		}
	}

	private void AcKhABurgQvielbBMbuhjCHLpjV(bool[] P_0)
	{
		int num = 0;
		int num8 = default(int);
		int num3 = default(int);
		bool flag2 = default(bool);
		int num5 = default(int);
		bool flag = default(bool);
		while (true)
		{
			int num2 = 1987893547;
			while (true)
			{
				int num7;
				int num9;
				int num10;
				switch (num2 ^ 0x767CD92F)
				{
				case 5:
					break;
				default:
					return;
				case 21:
					num8++;
					num2 = 1987893539;
					continue;
				case 6:
					num |= ((num8 == 0) ? 1 : (1 << num8));
					num2 = 1987893562;
					continue;
				case 13:
					num3 = 0;
					num2 = 1987893541;
					continue;
				case 3:
					brCQInsIkpjgTRMVrMnDnNknICoE[num8].EdjfbdZXMSCKwbFpugHrEingasfK(flag2);
					if (flag2)
					{
						int num15;
						if (!rXhRyzhbQTbXDGmMixSdjNyJMsQm(brCQInsIkpjgTRMVrMnDnNknICoE[num8], true))
						{
							num2 = 1987893545;
							num15 = num2;
						}
						else
						{
							num2 = 1987893562;
							num15 = num2;
						}
						continue;
					}
					goto case 21;
				case 4:
					num5 = 0;
					num2 = 1987893567;
					continue;
				case 19:
				{
					int num6;
					if (!brCQInsIkpjgTRMVrMnDnNknICoE[num5].ySKRlxVNISomhhIFpvZEYocyuLo)
					{
						num2 = 1987893544;
						num6 = num2;
					}
					else
					{
						num2 = 1987893560;
						num6 = num2;
					}
					continue;
				}
				case 2:
				{
					int num14;
					if (brCQInsIkpjgTRMVrMnDnNknICoE[num8].ySKRlxVNISomhhIFpvZEYocyuLo)
					{
						num2 = 1987893562;
						num14 = num2;
					}
					else
					{
						num2 = 1987893542;
						num14 = num2;
					}
					continue;
				}
				case 1:
				{
					int num11;
					if (brCQInsIkpjgTRMVrMnDnNknICoE[num5] == null)
					{
						num2 = 1987893544;
						num11 = num2;
					}
					else
					{
						num2 = 1987893564;
						num11 = num2;
					}
					continue;
				}
				case 22:
					brCQInsIkpjgTRMVrMnDnNknICoE[num3].RqHCbyiiVyEbSIUfQhpdTCYEkDrI(P_0[num3]);
					num2 = 1987893537;
					continue;
				case 7:
					num5++;
					num2 = 1987893567;
					continue;
				case 0:
					if (!flag)
					{
						rXhRyzhbQTbXDGmMixSdjNyJMsQm(brCQInsIkpjgTRMVrMnDnNknICoE[num5], false);
						num2 = 1987893544;
						continue;
					}
					goto case 7;
				case 23:
					flag = P_0[num5];
					brCQInsIkpjgTRMVrMnDnNknICoE[num5].EdjfbdZXMSCKwbFpugHrEingasfK(flag);
					num2 = 1987893551;
					continue;
				case 11:
				{
					int num16;
					if (brCQInsIkpjgTRMVrMnDnNknICoE[num8] == null)
					{
						num2 = 1987893562;
						num16 = num2;
					}
					else
					{
						num2 = 1987893549;
						num16 = num2;
					}
					continue;
				}
				case 16:
				{
					int num13;
					if (num5 >= 4)
					{
						num2 = 1987893563;
						num13 = num2;
					}
					else
					{
						num2 = 1987893550;
						num13 = num2;
					}
					continue;
				}
				case 12:
				{
					int num12;
					if (num8 < 4)
					{
						num2 = 1987893540;
						num12 = num2;
					}
					else
					{
						num2 = 1987893538;
						num12 = num2;
					}
					continue;
				}
				case 9:
					flag2 = P_0[num8];
					num2 = 1987893548;
					continue;
				case 20:
					num8 = 0;
					num2 = 1987893539;
					continue;
				case 17:
					num7 = 1 << num3;
					goto IL_0226;
				case 15:
					if (brCQInsIkpjgTRMVrMnDnNknICoE[num3] != null)
					{
						if (num3 == 0)
						{
							num7 = 1;
							goto IL_0226;
						}
						num2 = 1987893566;
						continue;
					}
					goto case 14;
				case 14:
					num3++;
					num2 = 1987893543;
					continue;
				case 8:
				{
					int num4;
					if (num3 < 4)
					{
						num2 = 1987893536;
						num4 = num2;
					}
					else
					{
						num2 = 1987893565;
						num4 = num2;
					}
					continue;
				}
				case 10:
					num2 = 1987893543;
					continue;
				case 18:
					return;
					IL_0226:
					num9 = num7;
					if ((num & num9) == 1 << num3)
					{
						num2 = 1987893537;
						num10 = num2;
					}
					else
					{
						num2 = 1987893561;
						num10 = num2;
					}
					continue;
				}
				break;
			}
		}
	}

	private bool rXhRyzhbQTbXDGmMixSdjNyJMsQm(KqZijOiESkOKxmSFgvxVuYITJco P_0, bool P_1)
	{
		if (P_1)
		{
			P_0.sfDOplJRzfcojkfvLAoYhXyNNVJ();
			goto IL_0009;
		}
		goto IL_007f;
		IL_007f:
		int num = yjuCHiamsFrchMyhFPFoVGeDabTa.QfvcPTCkQKNaHrLDCOXTjZcrUbW(P_0.rewiredId, P_0.ynSMEBTXNkIOhxNnIkeAyVvAtyw, true);
		int num2 = -1726106511;
		goto IL_000e;
		IL_0009:
		num2 = -1726106507;
		goto IL_000e;
		IL_000e:
		ControllerDisconnectedEventArgs obj = default(ControllerDisconnectedEventArgs);
		while (true)
		{
			switch (num2 ^ -1726106499)
			{
			case 3:
				break;
			case 0:
				obj = P_0.ToControllerDisconnectedEventArgs();
				P_0.NKgsBiDlHITBqDhOIKmBBlFELzQ();
				num2 = -1726106506;
				continue;
			case 12:
				goto IL_006a;
			case 1:
				goto IL_007f;
			case 13:
			{
				BridgedController obj2 = P_0.ToBridgedController();
				if (_DeviceConnectedEvent != null)
				{
					_DeviceConnectedEvent(obj2);
					num2 = -1726106504;
					continue;
				}
				goto default;
			}
			case 6:
				goto IL_00ca;
			case 7:
				return false;
			case 4:
				yjuCHiamsFrchMyhFPFoVGeDabTa.zENaiPxsdrQYCcJwFCLlhWcwhPs(num, false);
				num2 = -1726106499;
				continue;
			case 2:
				num2 = -1726106505;
				continue;
			case 9:
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
				num2 = -1726106512;
				continue;
			case 11:
				if (_DeviceDisconnectedEvent != null)
				{
					_DeviceDisconnectedEvent(obj);
					num2 = -1726106504;
					continue;
				}
				goto default;
			case 8:
				goto IL_018f;
			case 10:
				goto IL_01a4;
			default:
				return true;
			}
			break;
			IL_01a4:
			int num3;
			if (_UpdateControllerInfoEvent != null)
			{
				num2 = -1726106508;
				num3 = num2;
			}
			else
			{
				num2 = -1726106512;
				num3 = num2;
			}
			continue;
			IL_006a:
			int num4;
			if (num >= 0)
			{
				num2 = -1726106503;
				num4 = num2;
			}
			else
			{
				num2 = -1726106499;
				num4 = num2;
			}
			continue;
			IL_00ca:
			P_0.rewiredId = osCAPAIYOEZodlsEwtiFRgmwudTL();
			yjuCHiamsFrchMyhFPFoVGeDabTa.jjWrMKWdWPxSxeFhKeLSxKLMcPm(P_0, true);
			num2 = -1726106505;
			continue;
			IL_018f:
			if (P_0.GBctTtambVDrGmgNSbmaIAPqDQOB)
			{
				int num5 = yjuCHiamsFrchMyhFPFoVGeDabTa.nySNzzIwtpdDxNyGrJXbvkGigDI(P_0.ynSMEBTXNkIOhxNnIkeAyVvAtyw, false);
				if (num5 >= 0)
				{
					P_0.rewiredId = yjuCHiamsFrchMyhFPFoVGeDabTa.GEZvNBPLipPRSGmXeewoWFjylAA(num5);
					yjuCHiamsFrchMyhFPFoVGeDabTa.OKHZGFMfxtklwLbZuCziRQFTDNac(num5, P_0, true);
					num2 = -1726106497;
					continue;
				}
				goto IL_00ca;
			}
			num2 = -1726106502;
		}
		goto IL_0009;
	}

	static khPCPJgtQFokObAEkJKNQbaUfSZG()
	{
		Guid[] array = new Guid[2];
		while (true)
		{
			int num = -675655457;
			while (true)
			{
				switch (num ^ -675655458)
				{
				case 2:
					break;
				case 4:
					miMOzRuEcrNUcmRFoIsrdaWYpod = array;
					num = -675655458;
					continue;
				case 3:
					array[1] = new Guid("02e0045e-0000-0000-0000-504944564944");
					num = -675655462;
					continue;
				case 0:
					GlWCFMAyRhxGtHjWVsXUNsuOreV = new string[1] { "Xbox Bluetooth Gamepad" };
					num = -675655461;
					continue;
				case 1:
					array[0] = new Guid("72100955-0000-0000-0000-504944564944");
					num = -675655459;
					continue;
				default:
					MuEQfhNWUuRFcJgZvxygdhZinBj = new string[1] { "Xbox Wireless Controller.*" };
					return;
				}
				break;
			}
		}
	}

	public static bool FAFAhPjbbBwAOnGLLyaOWiEzWeM(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(miMOzRuEcrNUcmRFoIsrdaWYpod, P_3))
		{
			goto IL_000d;
		}
		int num = default(int);
		int num2;
		if (!string.IsNullOrEmpty(P_1))
		{
			num = 0;
			num2 = 2104659110;
			goto IL_0012;
		}
		goto IL_0080;
		IL_0116:
		P_0 = P_0.ToLower();
		int num3 = P_0.IndexOf("vid_");
		if (num3 >= 0)
		{
			if (P_0.IndexOf("ig_") >= num3)
			{
				return true;
			}
			num2 = 2104659116;
		}
		else
		{
			num2 = 2104659113;
		}
		goto IL_0012;
		IL_0080:
		int num4 = default(int);
		if (!string.IsNullOrEmpty(P_2))
		{
			num4 = 0;
			num2 = 2104659117;
			goto IL_0012;
		}
		goto IL_0116;
		IL_000d:
		num2 = 2104659109;
		goto IL_0012;
		IL_0012:
		while (true)
		{
			switch (num2 ^ 0x7D728CAE)
			{
			case 0:
				break;
			case 11:
				return true;
			case 1:
				goto IL_0065;
			case 5:
				goto IL_0080;
			case 10:
				goto IL_0097;
			case 4:
				goto IL_00b4;
			case 3:
				num2 = 2104659119;
				continue;
			case 8:
				goto IL_00de;
			case 7:
				return false;
			case 9:
				goto IL_0116;
			case 6:
				return true;
			default:
				return false;
			}
			break;
			IL_00de:
			int num5;
			if (num >= GlWCFMAyRhxGtHjWVsXUNsuOreV.Length)
			{
				num2 = 2104659115;
				num5 = num2;
			}
			else
			{
				num2 = 2104659108;
				num5 = num2;
			}
			continue;
			IL_0097:
			if (P_1.Equals(GlWCFMAyRhxGtHjWVsXUNsuOreV[num], StringComparison.OrdinalIgnoreCase))
			{
				num2 = 2104659112;
				continue;
			}
			num++;
			num2 = 2104659110;
			continue;
			IL_0065:
			int num6;
			if (num4 >= MuEQfhNWUuRFcJgZvxygdhZinBj.Length)
			{
				num2 = 2104659111;
				num6 = num2;
			}
			else
			{
				num2 = 2104659114;
				num6 = num2;
			}
			continue;
			IL_00b4:
			if (Regex.IsMatch(P_2, MuEQfhNWUuRFcJgZvxygdhZinBj[num4], RegexOptions.IgnoreCase))
			{
				return true;
			}
			num4++;
			num2 = 2104659119;
		}
		goto IL_000d;
	}
}
