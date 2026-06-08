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

internal class zzOqSwMfghlPxHdUtRXPrOVahKl : PlatformInputManager
{
	private class ffbtxKjczkhhcRJvRcraJnuRplQ : IDisposable, IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private bool pYyCCSzbscAnMJCcoGoTaGejmCpy;

		private int EXConJjMyypIPGpmnoMnbRhdgLW;

		private readonly int GcgavUExxzLtdjvIyZAYSvQzSQGl;

		public Guid UfFFvwXyyVSVFqRBlSrwmIuVpoX;

		public string AAVbVyNqUOuvZbdAweQkkZTDvgMS;

		public Guid duuMMyqFfJAeBAlnwwCpaWGlBUgO;

		public Rewired.Libraries.SharpDX.XInput.DeviceType NFWkKVadxwbCQrERooxxfmzuRkO;

		public XInputDeviceSubType bTBTDemkrYriKgIjLkfUkGMaAvIh;

		public bool fIkYGLxAqHefuTpANtEKPdaCbCFc;

		public bool wQwAboBPPjjgGSJaiJRyszjjytEb;

		public bool dNRDkMmUisYLGkOPcoQAKmRWFZI;

		public bool HazcIAHTRnlmnxxFXuxuOGyUDSkF;

		private int QMnEsACVScZyDUQxQkggDLSJgosZ;

		private int XdSfLcARZHURntIAczNgAJxSPUsa;

		private int qhBaQiBUaifpRBvldoZTqTDFPFqY;

		private int lenAIRsoOFqjBdbpibHDlBXGVmR;

		private readonly float[] UeCdPcJARqFdGACIKPtkWZxawHVX;

		private readonly bool[] mCgSEFdyltyHHshVpCgaWFFUiOPJ;

		private HardwareJoystickMap_InputManager UDBtEeitridwJAiaUtqcfFDaFaI;

		public readonly dAheZJcYloMwsIkRLXzIraBXTDWq bBSBxriglpnOAawkfBpKCJgyYmdh;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qnewRYFCzYevHqfqyatlbQmZFOFg;

		private Action catKhKhWzHbPVNmsBgmnOSioCMU;

		private bool aMKqqzErhtNXhyxSwjqcdYmpEMF;

		private bool YhPoJfQiAmHSpianQZbJomoJUOB;

		private bool inweGjIgYacXYohFlYRlpMFkgKMi;

		public string instanceName
		{
			get
			{
				string text = productName;
				if (text == string.Empty)
				{
					return string.Empty;
				}
				return text + " " + GcgavUExxzLtdjvIyZAYSvQzSQGl;
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
				return bTBTDemkrYriKgIjLkfUkGMaAvIh.ToString();
			}
		}

		public bool isConnected
		{
			get
			{
				if (bBSBxriglpnOAawkfBpKCJgyYmdh == null)
				{
					goto IL_002e;
				}
				if (!HazcIAHTRnlmnxxFXuxuOGyUDSkF)
				{
					goto IL_0010;
				}
				int num;
				if (aMKqqzErhtNXhyxSwjqcdYmpEMF && !NcEVWylWMXgzWqJuiDvJafyidau(jOpoDMfJFRQnytamDfETJorBLMfI.AvTAFMisemgsvRrIxsvyceeNUYw))
				{
					poHnNfPpCyQQvWKHQQoSwCEKjzn();
					num = 597600863;
					goto IL_0015;
				}
				goto IL_004e;
				IL_0010:
				num = 597600860;
				goto IL_0015;
				IL_0015:
				switch (num ^ 0x239EAA5D)
				{
				case 0:
					break;
				case 1:
					goto IL_002e;
				default:
					goto IL_004e;
				}
				goto IL_0010;
				IL_002e:
				return false;
				IL_004e:
				return aMKqqzErhtNXhyxSwjqcdYmpEMF;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return EXConJjMyypIPGpmnoMnbRhdgLW;
			}
			set
			{
				EXConJjMyypIPGpmnoMnbRhdgLW = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId => GcgavUExxzLtdjvIyZAYSvQzSQGl;

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (pYyCCSzbscAnMJCcoGoTaGejmCpy)
				{
					return bTBTDemkrYriKgIjLkfUkGMaAvIh.ToString() + " " + (GcgavUExxzLtdjvIyZAYSvQzSQGl + 1);
				}
				return "XInput " + bTBTDemkrYriKgIjLkfUkGMaAvIh.ToString() + " " + (GcgavUExxzLtdjvIyZAYSvQzSQGl + 1);
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId => GcgavUExxzLtdjvIyZAYSvQzSQGl;

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => null;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => duuMMyqFfJAeBAlnwwCpaWGlBUgO;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh.fRjRQLlkBDDtsEXAcdZVyleqfJG(amount, motorIndex);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh.kVFDfWkCARYcrijgatdcVXgivtUE();
		}

		public ffbtxKjczkhhcRJvRcraJnuRplQ(int systemId, bool isWin8AppStore, dAheZJcYloMwsIkRLXzIraBXTDWq sourceJoystick, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Action deviceDisconnectedDelegate)
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh = sourceJoystick;
			pYyCCSzbscAnMJCcoGoTaGejmCpy = isWin8AppStore;
			GcgavUExxzLtdjvIyZAYSvQzSQGl = systemId;
			qnewRYFCzYevHqfqyatlbQmZFOFg = getHardwareJoystickMap_InputManager;
			catKhKhWzHbPVNmsBgmnOSioCMU = deviceDisconnectedDelegate;
			EXConJjMyypIPGpmnoMnbRhdgLW = -1;
			QMnEsACVScZyDUQxQkggDLSJgosZ = 6;
			XdSfLcARZHURntIAczNgAJxSPUsa = 15;
			qhBaQiBUaifpRBvldoZTqTDFPFqY = QMnEsACVScZyDUQxQkggDLSJgosZ;
			lenAIRsoOFqjBdbpibHDlBXGVmR = XdSfLcARZHURntIAczNgAJxSPUsa;
			UeCdPcJARqFdGACIKPtkWZxawHVX = new float[QMnEsACVScZyDUQxQkggDLSJgosZ];
			mCgSEFdyltyHHshVpCgaWFFUiOPJ = new bool[XdSfLcARZHURntIAczNgAJxSPUsa];
			IuACrRLSXYCxPAGoMIMpLuEdZtDH();
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			bBSBxriglpnOAawkfBpKCJgyYmdh.FHAWEJygpGBmQamZGcnJraVJkRh();
			bool[] currentButtonValues = bBSBxriglpnOAawkfBpKCJgyYmdh.CurrentButtonValues;
			while (true)
			{
				int num = -1520758234;
				while (true)
				{
					switch (num ^ -1520758233)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_0035;
					case 0:
						return;
					}
					break;
					IL_0035:
					TcQALxknWBDsjjDgfcKnpyWUiBqK(currentButtonValues, ref bBSBxriglpnOAawkfBpKCJgyYmdh.szvzTJksJVVSNdCaebZaVuBgpjQ);
					aGwDgiXyNNqhCEqcVEYQleQFBPn(currentButtonValues, ref bBSBxriglpnOAawkfBpKCJgyYmdh.szvzTJksJVVSNdCaebZaVuBgpjQ);
					bBSBxriglpnOAawkfBpKCJgyYmdh.fHvlAyzcxwcbEJYkeBnphlWsGSD();
					num = -1520758233;
				}
			}
		}

		public void WfQqfBBhdWYDnDEhJdivCjhwSVF(bool P_0)
		{
			if (bBSBxriglpnOAawkfBpKCJgyYmdh == null)
			{
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = 1129649590;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x435515B7)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				return;
			case 0:
				goto IL_0032;
			case 3:
				return;
			}
			goto IL_0008;
			IL_0032:
			dNRDkMmUisYLGkOPcoQAKmRWFZI = P_0;
			num = 1129649588;
			goto IL_000d;
		}

		public bool NcEVWylWMXgzWqJuiDvJafyidau(jOpoDMfJFRQnytamDfETJorBLMfI P_0)
		{
			TmPuAgvwmfrJaMdlQQbUAQUNyX(QkNBntJPimDfuflgKyTmAesTZBN(P_0));
			return aMKqqzErhtNXhyxSwjqcdYmpEMF;
		}

		public bool QkNBntJPimDfuflgKyTmAesTZBN(jOpoDMfJFRQnytamDfETJorBLMfI P_0)
		{
			if (bBSBxriglpnOAawkfBpKCJgyYmdh == null)
			{
				return false;
			}
			return bBSBxriglpnOAawkfBpKCJgyYmdh.QkNBntJPimDfuflgKyTmAesTZBN(P_0);
		}

		public void TmPuAgvwmfrJaMdlQQbUAQUNyX(bool P_0)
		{
			aMKqqzErhtNXhyxSwjqcdYmpEMF = P_0;
		}

		public void faOhmAGkRPXLQUdbAbvUvxXdvVxl()
		{
			if (!HazcIAHTRnlmnxxFXuxuOGyUDSkF)
			{
				goto IL_0032;
			}
			if (aBlnnFWqWfFUrYMcPDrhQuKhtTH())
			{
				goto IL_0010;
			}
			goto IL_003f;
			IL_0032:
			IuACrRLSXYCxPAGoMIMpLuEdZtDH();
			int num = 698848904;
			goto IL_0015;
			IL_0010:
			num = 698848907;
			goto IL_0015;
			IL_0015:
			switch (num ^ 0x29A79689)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0032;
			case 1:
				goto IL_003f;
			case 3:
				return;
			}
			goto IL_0010;
			IL_003f:
			if (HazcIAHTRnlmnxxFXuxuOGyUDSkF && aMKqqzErhtNXhyxSwjqcdYmpEMF)
			{
				bBSBxriglpnOAawkfBpKCJgyYmdh.ZLkRominQCKUBwwrVSwFZLKUpyk();
				num = 698848906;
				goto IL_0015;
			}
		}

		public void WZhxXqkljwkXfQWaTheVVynohNy()
		{
			EXConJjMyypIPGpmnoMnbRhdgLW = -1;
			HazcIAHTRnlmnxxFXuxuOGyUDSkF = false;
			bBSBxriglpnOAawkfBpKCJgyYmdh.qhdlbmvVPGSkmbKUCbanVffQNKm();
			Array.Clear(UeCdPcJARqFdGACIKPtkWZxawHVX, 0, UeCdPcJARqFdGACIKPtkWZxawHVX.Length);
			Array.Clear(mCgSEFdyltyHHshVpCgaWFFUiOPJ, 0, mCgSEFdyltyHHshVpCgaWFFUiOPJ.Length);
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (QMnEsACVScZyDUQxQkggDLSJgosZ != dataUpdater.axisCount)
			{
				goto IL_005c;
			}
			if (XdSfLcARZHURntIAczNgAJxSPUsa != dataUpdater.buttonCount)
			{
				goto IL_001f;
			}
			goto IL_00d2;
			IL_005c:
			throw new Exception("This controller signature does not match the data object!");
			IL_001f:
			int num = -204996959;
			goto IL_0024;
			IL_0024:
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -204996955)
				{
				case 5:
					break;
				default:
					return;
				case 4:
					goto IL_005c;
				case 6:
					num2++;
					num = -204996954;
					continue;
				case 7:
					goto IL_0079;
				case 1:
					dataUpdater.buttonValues[num3] = mCgSEFdyltyHHshVpCgaWFFUiOPJ[num3];
					num3++;
					num = -204996958;
					continue;
				case 0:
					if (YhPoJfQiAmHSpianQZbJomoJUOB && !dataUpdater.hasReceivedInput)
					{
						dataUpdater.hasReceivedInput = true;
						num = -204996953;
						continue;
					}
					return;
				case 8:
					goto IL_00d2;
				case 3:
					if (num2 >= QMnEsACVScZyDUQxQkggDLSJgosZ)
					{
						num3 = 0;
						num = -204996958;
						continue;
					}
					goto case 9;
				case 9:
					dataUpdater.axisValues[num2] = UeCdPcJARqFdGACIKPtkWZxawHVX[num2];
					num = -204996957;
					continue;
				case 2:
					return;
				}
				break;
				IL_0079:
				int num4;
				if (num3 < XdSfLcARZHURntIAczNgAJxSPUsa)
				{
					num = -204996956;
					num4 = num;
				}
				else
				{
					num = -204996955;
					num4 = num;
				}
			}
			goto IL_001f;
			IL_00d2:
			num2 = 0;
			num = -204996954;
			goto IL_0024;
		}

		public BridgedControllerHWInfo GcYjAXCLyrkmacLFLclUoLjdDBr()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			dGqnYVYWgCeqfZEbphqNBhbNleek(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			dGqnYVYWgCeqfZEbphqNBhbNleek(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(EXConJjMyypIPGpmnoMnbRhdgLW);
		}

		private void IuACrRLSXYCxPAGoMIMpLuEdZtDH()
		{
			if (bBSBxriglpnOAawkfBpKCJgyYmdh == null || !NcEVWylWMXgzWqJuiDvJafyidau(jOpoDMfJFRQnytamDfETJorBLMfI.oGbEtnPMuiBKqFepYfniGIKqdbx))
			{
				return;
			}
			try
			{
				UzxOAujmKzmwLuNvhfUCQbJyCzNc();
				oAEDXrvvcKPxxNzmMhHOiHFnkWH oAEDXrvvcKPxxNzmMhHOiHFnkWH2 = default(oAEDXrvvcKPxxNzmMhHOiHFnkWH);
				GcRlXKaXTkXGCNOcLcJaGHRyAbh gcRlXKaXTkXGCNOcLcJaGHRyAbh = default(GcRlXKaXTkXGCNOcLcJaGHRyAbh);
				MsOtDChTRicNVkqupHmQHuLPitd msOtDChTRicNVkqupHmQHuLPitd = default(MsOtDChTRicNVkqupHmQHuLPitd);
				while (true)
				{
					int num = -1892005524;
					while (true)
					{
						switch (num ^ -1892005522)
						{
						case 6:
							break;
						case 4:
							AAVbVyNqUOuvZbdAweQkkZTDvgMS = UDBtEeitridwJAiaUtqcfFDaFaI.controllerName;
							num = -1892005525;
							continue;
						case 1:
							oAEDXrvvcKPxxNzmMhHOiHFnkWH2 = bBSBxriglpnOAawkfBpKCJgyYmdh.zDBhefHwTJrJMTXpqzYmpRigMIa.fRjRQLlkBDDtsEXAcdZVyleqfJG(gcRlXKaXTkXGCNOcLcJaGHRyAbh);
							num = -1892005523;
							continue;
						case 2:
							msOtDChTRicNVkqupHmQHuLPitd = bBSBxriglpnOAawkfBpKCJgyYmdh.zDBhefHwTJrJMTXpqzYmpRigMIa.RWhccjhXZkbnrValNRDuetTtyeD(xKdAjFWSfKGIuJSLXJJHZXFdqYx.xWNBWlUBAKXzIwhJBhjUoaVcfBk);
							NFWkKVadxwbCQrERooxxfmzuRkO = msOtDChTRicNVkqupHmQHuLPitd.YTPnvkUhAkJQzxOddhUvMmmVSrU;
							bTBTDemkrYriKgIjLkfUkGMaAvIh = (XInputDeviceSubType)msOtDChTRicNVkqupHmQHuLPitd.CqsDpnkZiroODPAGQcZbXPGNunRV;
							gcRlXKaXTkXGCNOcLcJaGHRyAbh = default(GcRlXKaXTkXGCNOcLcJaGHRyAbh);
							num = -1892005521;
							continue;
						case 3:
							if (oAEDXrvvcKPxxNzmMhHOiHFnkWH2.Success)
							{
								fIkYGLxAqHefuTpANtEKPdaCbCFc = true;
								num = -1892005522;
								continue;
							}
							goto case 0;
						case 0:
							wQwAboBPPjjgGSJaiJRyszjjytEb = (msOtDChTRicNVkqupHmQHuLPitd.kukmWglJDUvMDZhbIGzDAcBZJRG & iKDfpvBaceDEOvcbRUhdTYyOHye.QIIvsyaHzqJsSwINYBLKJsiomjN) == iKDfpvBaceDEOvcbRUhdTYyOHye.QIIvsyaHzqJsSwINYBLKJsiomjN;
							UVFtCXlXPJBKXqaKnfwDHhlUFOJ();
							UfFFvwXyyVSVFqRBlSrwmIuVpoX = UDBtEeitridwJAiaUtqcfFDaFaI.hardwareMapIdentifier.guid;
							num = -1892005526;
							continue;
						default:
							bBSBxriglpnOAawkfBpKCJgyYmdh.ZLkRominQCKUBwwrVSwFZLKUpyk();
							duuMMyqFfJAeBAlnwwCpaWGlBUgO = MiscTools.CreateGuidHashSHA1(string.Concat(NFWkKVadxwbCQrERooxxfmzuRkO, bTBTDemkrYriKgIjLkfUkGMaAvIh, GcgavUExxzLtdjvIyZAYSvQzSQGl));
							HazcIAHTRnlmnxxFXuxuOGyUDSkF = true;
							return;
						}
						break;
					}
				}
			}
			catch (Exception)
			{
				HazcIAHTRnlmnxxFXuxuOGyUDSkF = false;
				aMKqqzErhtNXhyxSwjqcdYmpEMF = false;
				duuMMyqFfJAeBAlnwwCpaWGlBUgO = Guid.Empty;
			}
		}

		private bool aBlnnFWqWfFUrYMcPDrhQuKhtTH()
		{
			try
			{
				if (bTBTDemkrYriKgIjLkfUkGMaAvIh != (XInputDeviceSubType)bBSBxriglpnOAawkfBpKCJgyYmdh.zDBhefHwTJrJMTXpqzYmpRigMIa.RWhccjhXZkbnrValNRDuetTtyeD(xKdAjFWSfKGIuJSLXJJHZXFdqYx.xWNBWlUBAKXzIwhJBhjUoaVcfBk).CqsDpnkZiroODPAGQcZbXPGNunRV)
				{
					bool result = true;
					while (true)
					{
						switch (-1705950434 ^ -1705950433)
						{
						case 0:
							break;
						default:
							goto end_IL_0020;
						case 2:
							goto end_IL_0020;
						case 1:
							return result;
						}
						continue;
						end_IL_0020:
						break;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		private void UzxOAujmKzmwLuNvhfUCQbJyCzNc()
		{
			wQwAboBPPjjgGSJaiJRyszjjytEb = false;
			fIkYGLxAqHefuTpANtEKPdaCbCFc = false;
			dNRDkMmUisYLGkOPcoQAKmRWFZI = false;
			HazcIAHTRnlmnxxFXuxuOGyUDSkF = false;
		}

		private void poHnNfPpCyQQvWKHQQoSwCEKjzn()
		{
			if (catKhKhWzHbPVNmsBgmnOSioCMU != null)
			{
				catKhKhWzHbPVNmsBgmnOSioCMU();
				goto IL_0013;
			}
			goto IL_0031;
			IL_0031:
			bBSBxriglpnOAawkfBpKCJgyYmdh.qhdlbmvVPGSkmbKUCbanVffQNKm();
			int num = 949517438;
			goto IL_0018;
			IL_0013:
			num = 949517437;
			goto IL_0018;
			IL_0018:
			switch (num ^ 0x38987C7F)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0031;
			case 1:
				return;
			}
			goto IL_0013;
		}

		private void TcQALxknWBDsjjDgfcKnpyWUiBqK(bool[] P_0, ref tyUtJQcImzLjAriZAGfwxxkDlNn P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_XInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map).Axes_orig;
			if (axes_orig == null)
			{
				return;
			}
			for (int i = 0; i < axes_orig.Length; i++)
			{
				if (i >= QMnEsACVScZyDUQxQkggDLSJgosZ)
				{
					throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
				}
				UeCdPcJARqFdGACIKPtkWZxawHVX[i] = LaNWitWQqyZMqUSPioBpzBMOpwf(axes_orig[i], P_0, ref P_1);
				if (!YhPoJfQiAmHSpianQZbJomoJUOB && UeCdPcJARqFdGACIKPtkWZxawHVX[i] != 0f)
				{
					YhPoJfQiAmHSpianQZbJomoJUOB = true;
				}
			}
		}

		private void aGwDgiXyNNqhCEqcVEYQleQFBPn(bool[] P_0, ref tyUtJQcImzLjAriZAGfwxxkDlNn P_1)
		{
			HardwareJoystickMap.Platform_XInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_XInput_Base)UDBtEeitridwJAiaUtqcfFDaFaI.map).Buttons_orig;
			if (buttons_orig == null)
			{
				return;
			}
			for (int i = 0; i < buttons_orig.Length; i++)
			{
				if (i >= XdSfLcARZHURntIAczNgAJxSPUsa)
				{
					throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
				}
				mCgSEFdyltyHHshVpCgaWFFUiOPJ[i] = fjKDuIFmYPFHshMFIEKwpUOEovgL(buttons_orig[i], P_0, ref P_1);
				if (!YhPoJfQiAmHSpianQZbJomoJUOB && mCgSEFdyltyHHshVpCgaWFFUiOPJ[i])
				{
					YhPoJfQiAmHSpianQZbJomoJUOB = true;
				}
			}
		}

		private float LaNWitWQqyZMqUSPioBpzBMOpwf(HardwareJoystickMap.Platform_XInput_Base.Axis P_0, bool[] P_1, ref tyUtJQcImzLjAriZAGfwxxkDlNn P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return 0f;
				}
				return LaNWitWQqyZMqUSPioBpzBMOpwf(P_0.sourceAxis, ref P_2);
			}
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return 0f;
				}
				if (!fjKDuIFmYPFHshMFIEKwpUOEovgL(P_0.sourceButton, P_1))
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

		private float LaNWitWQqyZMqUSPioBpzBMOpwf(XInputAxis P_0, ref tyUtJQcImzLjAriZAGfwxxkDlNn P_1)
		{
			switch (P_0)
			{
			case XInputAxis.LeftThumbX:
				return dAheZJcYloMwsIkRLXzIraBXTDWq.oMNnXrBObsqXntKHDHpZyOhNBhe(P_1.fIhGRwxXdENEKpKVyjLgueXGkbI);
			case XInputAxis.LeftThumbY:
				return dAheZJcYloMwsIkRLXzIraBXTDWq.oMNnXrBObsqXntKHDHpZyOhNBhe(P_1.HaNRDfvvmnvtpVmiTDALwCvuuTW);
			case XInputAxis.RightThumbX:
				return dAheZJcYloMwsIkRLXzIraBXTDWq.oMNnXrBObsqXntKHDHpZyOhNBhe(P_1.ZNZBdONXtrnCjExlJMTSeNBwBtHC);
			case XInputAxis.RightThumbY:
				return dAheZJcYloMwsIkRLXzIraBXTDWq.oMNnXrBObsqXntKHDHpZyOhNBhe(P_1.rZqefgRVFUwuBJvSCAojnoGymzw);
			case XInputAxis.LeftTrigger:
				return dAheZJcYloMwsIkRLXzIraBXTDWq.rzftipSktlJlLuFMMFYxtgJffCT(P_1.TEvamTXrpBJZYnBiCkAjfkDTdlJa);
			case XInputAxis.RightTrigger:
				return dAheZJcYloMwsIkRLXzIraBXTDWq.rzftipSktlJlLuFMMFYxtgJffCT(P_1.naduVVWewZWUScMTpOYBLcUYfAcG);
			default:
				return 0f;
			}
		}

		private bool fjKDuIFmYPFHshMFIEKwpUOEovgL(HardwareJoystickMap.Platform_XInput_Base.Button P_0, bool[] P_1, ref tyUtJQcImzLjAriZAGfwxxkDlNn P_2)
		{
			if (P_0.sourceType == HardwareElementSourceType.Button)
			{
				if (P_0.sourceButton == XInputButton.None)
				{
					return false;
				}
				return fjKDuIFmYPFHshMFIEKwpUOEovgL(P_0.sourceButton, P_1);
			}
			if (P_0.sourceType == HardwareElementSourceType.Axis)
			{
				if (P_0.sourceAxis == XInputAxis.None)
				{
					return false;
				}
				float num = LaNWitWQqyZMqUSPioBpzBMOpwf(P_0.sourceAxis, ref P_2);
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

		private bool fjKDuIFmYPFHshMFIEKwpUOEovgL(XInputButton P_0, bool[] P_1)
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

		private void UVFtCXlXPJBKXqaKnfwDHhlUFOJ()
		{
			UDBtEeitridwJAiaUtqcfFDaFaI = qnewRYFCzYevHqfqyatlbQmZFOFg(GcYjAXCLyrkmacLFLclUoLjdDBr());
			if (UDBtEeitridwJAiaUtqcfFDaFaI == null)
			{
				while (true)
				{
					int num = -322140000;
					while (true)
					{
						switch (num ^ -322139999)
						{
						case 0:
							break;
						case 1:
							Rewired.Logger.LogError("Default hardware map not found!");
							num = -322139998;
							continue;
						case 3:
							return;
						default:
							goto end_IL_001f;
						}
						break;
					}
					continue;
					end_IL_001f:
					break;
				}
			}
			QMnEsACVScZyDUQxQkggDLSJgosZ = UDBtEeitridwJAiaUtqcfFDaFaI.axisCount;
			XdSfLcARZHURntIAczNgAJxSPUsa = UDBtEeitridwJAiaUtqcfFDaFaI.buttonCount;
		}

		private bool QqkRJscJsdRRrwMdaqJzakKIjni(ref GcRlXKaXTkXGCNOcLcJaGHRyAbh P_0)
		{
			if (P_0.GjZFpNbAkjiEsCvIrfpDljFPzug > 0 || P_0.VdXPUXskfWHHamFzWkAVHQAtUVR > 0)
			{
				return true;
			}
			return false;
		}

		private void dkSNUmyxptiHkNpEYijcXSNzgUQ(ref GcRlXKaXTkXGCNOcLcJaGHRyAbh P_0)
		{
			P_0.GjZFpNbAkjiEsCvIrfpDljFPzug = 0;
			P_0.VdXPUXskfWHHamFzWkAVHQAtUVR = 0;
		}

		private void btvWzbSvzPuydbVFmTjIfHmTsoK(ref GcRlXKaXTkXGCNOcLcJaGHRyAbh P_0, ref GcRlXKaXTkXGCNOcLcJaGHRyAbh P_1)
		{
			P_1.GjZFpNbAkjiEsCvIrfpDljFPzug = P_0.GjZFpNbAkjiEsCvIrfpDljFPzug;
			P_1.VdXPUXskfWHHamFzWkAVHQAtUVR = P_0.VdXPUXskfWHHamFzWkAVHQAtUVR;
		}

		private string SUOCLYiMCAFBYPeppWCzWhwrMxIS()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.XInput.ToString()}{NFWkKVadxwbCQrERooxxfmzuRkO.ToString()}{bTBTDemkrYriKgIjLkfUkGMaAvIh.ToString()}");
		}

		private void dGqnYVYWgCeqfZEbphqNBhbNleek(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.XInput;
			while (true)
			{
				int num = -1282797511;
				while (true)
				{
					switch (num ^ -1282797512)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						P_0.inputSource = P_0.inputManagerSource;
						P_0.deviceType = ControlDeviceType.mWddvsAGGdWECRlxCOhehpBItyh;
						P_0.hardwareIdentifier = SUOCLYiMCAFBYPeppWCzWhwrMxIS();
						P_0.hardwareAxisCount = qhBaQiBUaifpRBvldoZTqTDFPFqY;
						P_0.hardwareButtonCount = lenAIRsoOFqjBdbpibHDlBXGVmR;
						num = -1282797512;
						continue;
					case 0:
						P_0.hardwareHatCount = 0;
						P_0.hw_productName = productName;
						P_0.hw_supportsVoice = wQwAboBPPjjgGSJaiJRyszjjytEb;
						P_0.hw_supportsVibration = fIkYGLxAqHefuTpANtEKPdaCbCFc;
						P_0.hw_localVibrationMotorCount = (fIkYGLxAqHefuTpANtEKPdaCbCFc ? 2 : 0);
						P_0.hw_xInputSubType = bTBTDemkrYriKgIjLkfUkGMaAvIh;
						num = -1282797509;
						continue;
					case 3:
						return;
					}
					break;
				}
			}
		}

		private void dGqnYVYWgCeqfZEbphqNBhbNleek(BridgedController P_0)
		{
			dGqnYVYWgCeqfZEbphqNBhbNleek((BridgedControllerHWInfo)P_0);
			while (true)
			{
				int num = 1546291210;
				while (true)
				{
					switch (num ^ 0x5C2A880B)
					{
					case 2:
						break;
					case 1:
						P_0.sourceJoystick = this;
						num = 1546291208;
						continue;
					case 3:
						P_0.gameHardwareMap = UDBtEeitridwJAiaUtqcfFDaFaI.ToGameHardwareControllerMap();
						P_0.instanceName = "XInput " + instanceName;
						P_0.productName = "XInput " + productName;
						P_0.isXInputDevice = true;
						P_0.axisCount = QMnEsACVScZyDUQxQkggDLSJgosZ;
						num = 1546291211;
						continue;
					default:
						P_0.buttonCount = XdSfLcARZHURntIAczNgAJxSPUsa;
						P_0.controllerTypeGuid = UfFFvwXyyVSVFqRBlSrwmIuVpoX;
						P_0.controllerExtension = extension;
						return;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
			GC.SuppressFinalize(this);
		}

		~ffbtxKjczkhhcRJvRcraJnuRplQ()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
		}

		protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
		{
			if (inweGjIgYacXYohFlYRlpMFkgKMi)
			{
				return;
			}
			while (true)
			{
				IL_006c:
				int num;
				if (P_0)
				{
					if (isConnected)
					{
						bBSBxriglpnOAawkfBpKCJgyYmdh.TyHEIbUoHKcWBfdZEoIAkRohSFl();
						num = 1442403474;
						goto IL_000e;
					}
					goto IL_0045;
				}
				goto IL_005e;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x55F95491)
					{
					case 0:
						num = 1442403472;
						continue;
					default:
						return;
					case 4:
						bBSBxriglpnOAawkfBpKCJgyYmdh.Dispose();
						num = 1442403475;
						continue;
					case 3:
						break;
					case 2:
						goto IL_005e;
					case 1:
						goto IL_006c;
					case 5:
						return;
					}
					break;
				}
				goto IL_0045;
				IL_0045:
				int num2;
				if (bBSBxriglpnOAawkfBpKCJgyYmdh != null)
				{
					num = 1442403477;
					num2 = num;
				}
				else
				{
					num = 1442403475;
					num2 = num;
				}
				goto IL_000e;
				IL_005e:
				inweGjIgYacXYohFlYRlpMFkgKMi = true;
				num = 1442403476;
				goto IL_000e;
			}
		}
	}

	private class ojaoaGslfMZhMreoqLDKOowwnwZ
	{
		private class hpKpMAswgxdVdrBmUyeezIoYECw
		{
			public bool odXSRRHVUCSnzWqRRANpVIguISO;

			public int VGSrrWYLNAwIbrYoUwvzVCxXdRzc;

			public XInputDeviceSubType bTBTDemkrYriKgIjLkfUkGMaAvIh;

			public void FFYEDujhZPZIRSsDbLkeXQkxTZI(ffbtxKjczkhhcRJvRcraJnuRplQ P_0, bool P_1)
			{
				odXSRRHVUCSnzWqRRANpVIguISO = P_1;
				VGSrrWYLNAwIbrYoUwvzVCxXdRzc = P_0.rewiredId;
				bTBTDemkrYriKgIjLkfUkGMaAvIh = P_0.bTBTDemkrYriKgIjLkfUkGMaAvIh;
			}

			public hpKpMAswgxdVdrBmUyeezIoYECw(int rewiredId, XInputDeviceSubType deviceSubType)
			{
				VGSrrWYLNAwIbrYoUwvzVCxXdRzc = rewiredId;
				bTBTDemkrYriKgIjLkfUkGMaAvIh = deviceSubType;
			}
		}

		private List<hpKpMAswgxdVdrBmUyeezIoYECw> yyiFPljnUsCKsCDVIczjlInczmly;

		public ojaoaGslfMZhMreoqLDKOowwnwZ()
		{
			yyiFPljnUsCKsCDVIczjlInczmly = new List<hpKpMAswgxdVdrBmUyeezIoYECw>();
		}

		public void klTcSvpccfbAAbHlREdQKnourmGO(ffbtxKjczkhhcRJvRcraJnuRplQ P_0, bool P_1)
		{
			int num = LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0.rewiredId, P_0.bTBTDemkrYriKgIjLkfUkGMaAvIh, true);
			while (true)
			{
				int num2 = -556512864;
				while (true)
				{
					switch (num2 ^ -556512861)
					{
					case 2:
						break;
					default:
						return;
					case 1:
					{
						hpKpMAswgxdVdrBmUyeezIoYECw hpKpMAswgxdVdrBmUyeezIoYECw2 = new hpKpMAswgxdVdrBmUyeezIoYECw(P_0.rewiredId, P_0.bTBTDemkrYriKgIjLkfUkGMaAvIh);
						hpKpMAswgxdVdrBmUyeezIoYECw2.odXSRRHVUCSnzWqRRANpVIguISO = P_1;
						yyiFPljnUsCKsCDVIczjlInczmly.Add(hpKpMAswgxdVdrBmUyeezIoYECw2);
						num2 = -556512857;
						continue;
					}
					case 0:
						return;
					case 3:
					{
						int num3;
						if (num < 0)
						{
							num2 = -556512862;
							num3 = num2;
						}
						else
						{
							num2 = -556512861;
							num3 = num2;
						}
						continue;
					}
					case 4:
						return;
					}
					break;
				}
			}
		}

		public void FFYEDujhZPZIRSsDbLkeXQkxTZI(int P_0, ffbtxKjczkhhcRJvRcraJnuRplQ P_1, bool P_2)
		{
			if (P_0 < 0)
			{
				return;
			}
			while (true)
			{
				int num = -1747631678;
				while (true)
				{
					switch (num ^ -1747631677)
					{
					case 2:
						break;
					case 1:
					{
						int num2;
						if (P_0 < yyiFPljnUsCKsCDVIczjlInczmly.Count)
						{
							num = -1747631677;
							num2 = num;
						}
						else
						{
							num = -1747631680;
							num2 = num;
						}
						continue;
					}
					case 3:
						return;
					default:
						yyiFPljnUsCKsCDVIczjlInczmly[P_0].FFYEDujhZPZIRSsDbLkeXQkxTZI(P_1, P_2);
						return;
					}
					break;
				}
			}
		}

		public int wqFAoMkdRLEuIZUImAKtRfbOLLwG(XInputDeviceSubType P_0, bool P_1)
		{
			int count = yyiFPljnUsCKsCDVIczjlInczmly.Count;
			int num = 0;
			while (true)
			{
				int num2 = 1612039354;
				while (true)
				{
					switch (num2 ^ 0x6015C4B9)
					{
					case 2:
						break;
					case 3:
						num2 = 1612039353;
						continue;
					case 1:
						if (yyiFPljnUsCKsCDVIczjlInczmly[num].bTBTDemkrYriKgIjLkfUkGMaAvIh == P_0)
						{
							return num;
						}
						goto IL_0051;
					case 4:
						if (P_1)
						{
							goto case 1;
						}
						if (!yyiFPljnUsCKsCDVIczjlInczmly[num].odXSRRHVUCSnzWqRRANpVIguISO)
						{
							num2 = 1612039352;
							continue;
						}
						goto IL_0051;
					default:
						{
							if (num >= count)
							{
								return -1;
							}
							goto case 4;
						}
						IL_0051:
						num++;
						num2 = 1612039353;
						continue;
					}
					break;
				}
			}
		}

		public int LdeYUipgUiPUwsTmDLLPrLKDSEy(int P_0, XInputDeviceSubType P_1, bool P_2)
		{
			int count = yyiFPljnUsCKsCDVIczjlInczmly.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 1728732600;
				while (true)
				{
					switch (num ^ 0x670A5DBB)
					{
					case 4:
						break;
					case 3:
						num2 = 0;
						num = 1728732601;
						continue;
					case 1:
						if (yyiFPljnUsCKsCDVIczjlInczmly[num2].VGSrrWYLNAwIbrYoUwvzVCxXdRzc == P_0 && yyiFPljnUsCKsCDVIczjlInczmly[num2].bTBTDemkrYriKgIjLkfUkGMaAvIh == P_1)
						{
							return num2;
						}
						goto IL_0065;
					case 0:
						if (P_2)
						{
							goto case 1;
						}
						if (!yyiFPljnUsCKsCDVIczjlInczmly[num2].odXSRRHVUCSnzWqRRANpVIguISO)
						{
							num = 1728732602;
							continue;
						}
						goto IL_0065;
					default:
						{
							if (num2 >= count)
							{
								return -1;
							}
							goto case 0;
						}
						IL_0065:
						num2++;
						num = 1728732601;
						continue;
					}
					break;
				}
			}
		}

		public int BUQIKskPMHutvDgPrvtkGgMWGRi(int P_0)
		{
			if (P_0 >= 0)
			{
				while (true)
				{
					int num = 203834124;
					while (true)
					{
						switch (num ^ 0xC26430D)
						{
						case 3:
							break;
						case 1:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							return yyiFPljnUsCKsCDVIczjlInczmly[P_0].VGSrrWYLNAwIbrYoUwvzVCxXdRzc;
						}
						break;
						IL_0026:
						int num2;
						if (P_0 < yyiFPljnUsCKsCDVIczjlInczmly.Count)
						{
							num = 203834125;
							num2 = num;
						}
						else
						{
							num = 203834127;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		public void iuKtrqAKDXxOzbfyYKefhjTUEZQ(int P_0, bool P_1)
		{
			if (P_0 < 0)
			{
				return;
			}
			if (P_0 >= yyiFPljnUsCKsCDVIczjlInczmly.Count)
			{
				while (true)
				{
					switch (-839946635 ^ -839946636)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			yyiFPljnUsCKsCDVIczjlInczmly[P_0].odXSRRHVUCSnzWqRRANpVIguISO = P_1;
		}
	}

	private class sMSpCjRLIexIidKNbeILBVquoMd
	{
		public bool XsxgBWVsGjEmgWrCPKMGXShneKP;

		private double RRgjIoeCYjrDiuDjYCeqJeUrDVGd;

		public float hUwTEJiTTYCEmBhvJGYVudCpIpve;

		public sMSpCjRLIexIidKNbeILBVquoMd()
		{
		}

		public sMSpCjRLIexIidKNbeILBVquoMd(float inLength)
		{
			hUwTEJiTTYCEmBhvJGYVudCpIpve = inLength;
		}

		public void EsoCoViNGnlmiCnejoKMpfdflIEq()
		{
			XsxgBWVsGjEmgWrCPKMGXShneKP = true;
			RRgjIoeCYjrDiuDjYCeqJeUrDVGd = (double)hUwTEJiTTYCEmBhvJGYVudCpIpve + ReInput.unscaledTime;
		}

		public void EsoCoViNGnlmiCnejoKMpfdflIEq(float P_0)
		{
			XsxgBWVsGjEmgWrCPKMGXShneKP = true;
			hUwTEJiTTYCEmBhvJGYVudCpIpve = P_0;
			RRgjIoeCYjrDiuDjYCeqJeUrDVGd = (double)hUwTEJiTTYCEmBhvJGYVudCpIpve + ReInput.unscaledTime;
		}

		public bool FFYEDujhZPZIRSsDbLkeXQkxTZI()
		{
			if (!XsxgBWVsGjEmgWrCPKMGXShneKP)
			{
				return false;
			}
			if (ReInput.unscaledTime >= RRgjIoeCYjrDiuDjYCeqJeUrDVGd)
			{
				XsxgBWVsGjEmgWrCPKMGXShneKP = false;
				return true;
			}
			return false;
		}

		public void ibajyEOvcZaAVvqbaVIEPkwcIqx()
		{
			XsxgBWVsGjEmgWrCPKMGXShneKP = false;
			RRgjIoeCYjrDiuDjYCeqJeUrDVGd = 0.0;
		}

		public void DkGpUpAqHJWDSfAcLTpJUxNfWid(float P_0)
		{
			hUwTEJiTTYCEmBhvJGYVudCpIpve = P_0;
		}

		public sMSpCjRLIexIidKNbeILBVquoMd HJpMJonoGQYIyFospHxiSUKtvOj()
		{
			return (sMSpCjRLIexIidKNbeILBVquoMd)MemberwiseClone();
		}
	}

	public class dAheZJcYloMwsIkRLXzIraBXTDWq : IDisposable
	{
		public readonly tBYfLSCxOHBMTsBESxYMJzAlNDXv zDBhefHwTJrJMTXpqzYmpRigMIa;

		public tyUtJQcImzLjAriZAGfwxxkDlNn szvzTJksJVVSNdCaebZaVuBgpjQ;

		private bool aMKqqzErhtNXhyxSwjqcdYmpEMF;

		private readonly ButtonLoopSet kxhgtldiZvXtvpQoAQRmEtvWcQG;

		private tyUtJQcImzLjAriZAGfwxxkDlNn QHjYtINmLLlchvYcMCnuZZyQFbY;

		private bool GMsLdfFkmyTiNvDqVSrTjWHMbJh;

		private DualThreadLowLevelInputEventQueue qBsNOlJaQtsdnZAlQWMSpzDbRSm;

		private readonly object VscpWqBWzuDusblaKBCJNvlmplv;

		private RingBuffer<GcRlXKaXTkXGCNOcLcJaGHRyAbh> LLAxJxyDsQpxgHPiBmsiiDmyIQZ = new RingBuffer<GcRlXKaXTkXGCNOcLcJaGHRyAbh>(5);

		private RingBuffer<GcRlXKaXTkXGCNOcLcJaGHRyAbh> VOHDidBLBYEFzVJvkBFmLyEbhDpi = new RingBuffer<GcRlXKaXTkXGCNOcLcJaGHRyAbh>(5);

		private readonly object xkBtSdIwiHigcbDgfpkqheIkbCeI = new object();

		private readonly object sHmDpUHnBEzqhgSmmHSOprqfSmP = new object();

		private GcRlXKaXTkXGCNOcLcJaGHRyAbh UwhSLqfUtMmidtlFronzBbKnogI;

		private double slVHRRXbeiLbOaHwCrpAQJtgtdL;

		private bool inweGjIgYacXYohFlYRlpMFkgKMi;

		public bool[] CurrentButtonValues => kxhgtldiZvXtvpQoAQRmEtvWcQG.Current.effectiveValue;

		public dAheZJcYloMwsIkRLXzIraBXTDWq(int controllerIndex, UpdateLoopSetting updateLoops)
		{
			zDBhefHwTJrJMTXpqzYmpRigMIa = new tBYfLSCxOHBMTsBESxYMJzAlNDXv((VfKuNYEdnzrcpZelfpuSySpvNMH)controllerIndex);
			kxhgtldiZvXtvpQoAQRmEtvWcQG = new ButtonLoopSet(updateLoops, 15);
			VscpWqBWzuDusblaKBCJNvlmplv = new object();
			qBsNOlJaQtsdnZAlQWMSpzDbRSm = new DualThreadLowLevelInputEventQueue((int)((float)kpfkMpAFolETeEcXIDaJMkIYftRp.joystickRefreshRate * 0.25f), 15, 6, 0);
		}

		public void FHAWEJygpGBmQamZGcnJraVJkRh()
		{
			kxhgtldiZvXtvpQoAQRmEtvWcQG.SetUpdateLoop(ReInput.currentUpdateLoop);
			DuGcHBrhOeyrOEkefphPhCAwBjrg(ref szvzTJksJVVSNdCaebZaVuBgpjQ);
		}

		public void fHvlAyzcxwcbEJYkeBnphlWsGSD()
		{
			iajcadDIbUzRYqfxWkbquUVciTi();
			kxhgtldiZvXtvpQoAQRmEtvWcQG.Current.ClearWasTrueThisFrame();
		}

		public void ZLkRominQCKUBwwrVSwFZLKUpyk()
		{
			RFDPexajhTcXvizzpCmOkHbzMGox();
			aMKqqzErhtNXhyxSwjqcdYmpEMF = true;
			GMsLdfFkmyTiNvDqVSrTjWHMbJh = zDBhefHwTJrJMTXpqzYmpRigMIa.IsConnected;
		}

		public void qhdlbmvVPGSkmbKUCbanVffQNKm()
		{
			aMKqqzErhtNXhyxSwjqcdYmpEMF = false;
			GMsLdfFkmyTiNvDqVSrTjWHMbJh = false;
			RFDPexajhTcXvizzpCmOkHbzMGox();
		}

		public bool QkNBntJPimDfuflgKyTmAesTZBN(jOpoDMfJFRQnytamDfETJorBLMfI P_0)
		{
			switch (P_0)
			{
			case jOpoDMfJFRQnytamDfETJorBLMfI.oGbEtnPMuiBKqFepYfniGIKqdbx:
			{
				bool result = default(bool);
				while (true)
				{
					int num = -195340751;
					while (true)
					{
						switch (num ^ -195340752)
						{
						case 2:
							break;
						case 1:
							goto IL_0021;
						default:
							return result;
						}
						break;
						IL_0021:
						result = (GMsLdfFkmyTiNvDqVSrTjWHMbJh = zDBhefHwTJrJMTXpqzYmpRigMIa.IsConnected);
						num = -195340752;
					}
				}
			}
			case jOpoDMfJFRQnytamDfETJorBLMfI.AvTAFMisemgsvRrIxsvyceeNUYw:
				return GMsLdfFkmyTiNvDqVSrTjWHMbJh;
			default:
				throw new NotImplementedException();
			}
		}

		public void fRjRQLlkBDDtsEXAcdZVyleqfJG(float P_0, int P_1)
		{
			if (P_1 == 0)
			{
				UwhSLqfUtMmidtlFronzBbKnogI.GjZFpNbAkjiEsCvIrfpDljFPzug = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				goto IL_001b;
			}
			goto IL_0044;
			IL_0067:
			zSYazZCLfpEwQdvZlrQIiBZLlfH();
			return;
			IL_001b:
			int num = -369929186;
			goto IL_0020;
			IL_0020:
			while (true)
			{
				switch (num ^ -369929187)
				{
				case 0:
					break;
				case 3:
					num = -369929185;
					continue;
				case 1:
					goto IL_0044;
				default:
					goto IL_0067;
				}
				break;
			}
			goto IL_001b;
			IL_0044:
			if (P_1 == 1)
			{
				UwhSLqfUtMmidtlFronzBbKnogI.VdXPUXskfWHHamFzWkAVHQAtUVR = (ushort)(MathTools.Clamp01(P_0) * 65535f);
				num = -369929185;
				goto IL_0020;
			}
			goto IL_0067;
		}

		public void kVFDfWkCARYcrijgatdcVXgivtUE()
		{
			UwhSLqfUtMmidtlFronzBbKnogI.GjZFpNbAkjiEsCvIrfpDljFPzug = 0;
			UwhSLqfUtMmidtlFronzBbKnogI.VdXPUXskfWHHamFzWkAVHQAtUVR = 0;
			zSYazZCLfpEwQdvZlrQIiBZLlfH();
		}

		public void TyHEIbUoHKcWBfdZEoIAkRohSFl()
		{
			UwhSLqfUtMmidtlFronzBbKnogI.GjZFpNbAkjiEsCvIrfpDljFPzug = 0;
			UwhSLqfUtMmidtlFronzBbKnogI.VdXPUXskfWHHamFzWkAVHQAtUVR = 0;
			lock (sHmDpUHnBEzqhgSmmHSOprqfSmP)
			{
				lock (xkBtSdIwiHigcbDgfpkqheIkbCeI)
				{
					LLAxJxyDsQpxgHPiBmsiiDmyIQZ.Clear();
					VOHDidBLBYEFzVJvkBFmLyEbhDpi.Clear();
					EFehGBAtIxmpTjabGLYuUsmrxBWe(zDBhefHwTJrJMTXpqzYmpRigMIa, UwhSLqfUtMmidtlFronzBbKnogI, ref slVHRRXbeiLbOaHwCrpAQJtgtdL);
				}
			}
		}

		public void QDcVGGNdXBxpwkRxvJPlSDHeAfrj()
		{
			if (!aMKqqzErhtNXhyxSwjqcdYmpEMF || !GMsLdfFkmyTiNvDqVSrTjWHMbJh)
			{
				return;
			}
			DBlBEUzeGRAlBVSIViHWbmOkEipK dBlBEUzeGRAlBVSIViHWbmOkEipK;
			double realTime = default(double);
			try
			{
				if (!zDBhefHwTJrJMTXpqzYmpRigMIa.lenARNqJeUHoPYzKipGMyMkUhTG(out dBlBEUzeGRAlBVSIViHWbmOkEipK))
				{
					goto IL_0021;
				}
				goto IL_0055;
				IL_0021:
				int num = 1672536296;
				goto IL_0026;
				IL_0026:
				while (true)
				{
					switch (num ^ 0x63B0E0EC)
					{
					case 0:
						break;
					default:
						goto end_IL_0012;
					case 4:
						GMsLdfFkmyTiNvDqVSrTjWHMbJh = false;
						num = 1672536301;
						continue;
					case 2:
						goto IL_0055;
					case 1:
						return;
					case 3:
						goto end_IL_0012;
					}
					break;
				}
				goto IL_0021;
				IL_0055:
				realTime = ReInput.realTime;
				num = 1672536303;
				goto IL_0026;
				end_IL_0012:;
			}
			catch
			{
				GMsLdfFkmyTiNvDqVSrTjWHMbJh = false;
				return;
			}
			lock (VscpWqBWzuDusblaKBCJNvlmplv)
			{
				if (!GFhuAyJHZqtSqpgJiLGFVpCzEUaE(dBlBEUzeGRAlBVSIViHWbmOkEipK.egXeNSeaFVcDEGVdGFwVPDfpVJP, QHjYtINmLLlchvYcMCnuZZyQFbY))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = qBsNOlJaQtsdnZAlQWMSpzDbRSm.T_CreateEvent())
					{
						MIBFVdyqribayFWyUgyEdJvRlpUO(ref dBlBEUzeGRAlBVSIViHWbmOkEipK.egXeNSeaFVcDEGVdGFwVPDfpVJP, realTime, newEventWrapper.Event);
					}
					QHjYtINmLLlchvYcMCnuZZyQFbY = dBlBEUzeGRAlBVSIViHWbmOkEipK.egXeNSeaFVcDEGVdGFwVPDfpVJP;
				}
			}
		}

		public void dUrEQZivPwsiuRjrLFolumsPLOBe()
		{
			if (!aMKqqzErhtNXhyxSwjqcdYmpEMF)
			{
				return;
			}
			while (GMsLdfFkmyTiNvDqVSrTjWHMbJh)
			{
				while (true)
				{
					IL_003f:
					int num;
					int num2;
					if (ReInput.realTime < slVHRRXbeiLbOaHwCrpAQJtgtdL + 0.009999999776482582)
					{
						num = 906670305;
						num2 = num;
					}
					else
					{
						num = 906670306;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x360AB0E2)
						{
						case 4:
							num = 906670304;
							continue;
						case 2:
							break;
						case 1:
							goto IL_003f;
						case 3:
							return;
						default:
							lock (sHmDpUHnBEzqhgSmmHSOprqfSmP)
							{
								lock (xkBtSdIwiHigcbDgfpkqheIkbCeI)
								{
									MiscTools.Swap(ref LLAxJxyDsQpxgHPiBmsiiDmyIQZ, ref VOHDidBLBYEFzVJvkBFmLyEbhDpi);
								}
								gCFfGJpWasuVtGjYXZOlLlogEEpa(VOHDidBLBYEFzVJvkBFmLyEbhDpi, zDBhefHwTJrJMTXpqzYmpRigMIa, ref slVHRRXbeiLbOaHwCrpAQJtgtdL);
								return;
							}
						}
						break;
					}
					break;
				}
			}
		}

		private void iajcadDIbUzRYqfxWkbquUVciTi()
		{
			PSFwPfQWwjcCoefKhBBTeotpsaf();
		}

		private void PSFwPfQWwjcCoefKhBBTeotpsaf()
		{
			if (ReInput.realTime < slVHRRXbeiLbOaHwCrpAQJtgtdL + 1.5)
			{
				return;
			}
			while (!Mathf.Approximately((int)UwhSLqfUtMmidtlFronzBbKnogI.GjZFpNbAkjiEsCvIrfpDljFPzug, 0f) || !Mathf.Approximately((int)UwhSLqfUtMmidtlFronzBbKnogI.VdXPUXskfWHHamFzWkAVHQAtUVR, 0f))
			{
				while (true)
				{
					IL_0072:
					zSYazZCLfpEwQdvZlrQIiBZLlfH();
					int num = 445245257;
					while (true)
					{
						switch (num ^ 0x1A89E748)
						{
						case 0:
							num = 445245259;
							continue;
						default:
							return;
						case 3:
							break;
						case 2:
							goto IL_0072;
						case 1:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		private void zSYazZCLfpEwQdvZlrQIiBZLlfH()
		{
			lock (xkBtSdIwiHigcbDgfpkqheIkbCeI)
			{
				LLAxJxyDsQpxgHPiBmsiiDmyIQZ.Enqueue(UwhSLqfUtMmidtlFronzBbKnogI);
			}
		}

		private static void gCFfGJpWasuVtGjYXZOlLlogEEpa(RingBuffer<GcRlXKaXTkXGCNOcLcJaGHRyAbh> P_0, tBYfLSCxOHBMTsBESxYMJzAlNDXv P_1, ref double P_2)
		{
			if (P_0.Count > 0)
			{
				EFehGBAtIxmpTjabGLYuUsmrxBWe(P_1, P_0[P_0.Count - 1], ref P_2);
				P_0.Clear();
			}
		}

		private static void EFehGBAtIxmpTjabGLYuUsmrxBWe(tBYfLSCxOHBMTsBESxYMJzAlNDXv P_0, GcRlXKaXTkXGCNOcLcJaGHRyAbh P_1, ref double P_2)
		{
			try
			{
				P_0.fRjRQLlkBDDtsEXAcdZVyleqfJG(P_1);
			}
			catch
			{
			}
			P_2 = ReInput.realTime;
		}

		private void DuGcHBrhOeyrOEkefphPhCAwBjrg(ref tyUtJQcImzLjAriZAGfwxxkDlNn P_0)
		{
			while (qBsNOlJaQtsdnZAlQWMSpzDbRSm.ProcessNewEvents())
			{
				rDjoVSuOhyvhSAGbQUYBfaeaZDy(ref P_0, ref qBsNOlJaQtsdnZAlQWMSpzDbRSm.currentEvent);
				for (int i = 0; i < 15; i++)
				{
					kxhgtldiZvXtvpQoAQRmEtvWcQG.SetValue(i, fjKDuIFmYPFHshMFIEKwpUOEovgL((int)P_0.BbQZXfVAmQcAGiAipTBZtTMzfgS, i), qBsNOlJaQtsdnZAlQWMSpzDbRSm.currentEvent.GetTimestamp());
				}
			}
		}

		private void MIBFVdyqribayFWyUgyEdJvRlpUO(ref tyUtJQcImzLjAriZAGfwxxkDlNn P_0, double P_1, LowLevelInputEvent P_2)
		{
			P_2.SetTimestamp(P_1);
			int bbQZXfVAmQcAGiAipTBZtTMzfgS = (int)P_0.BbQZXfVAmQcAGiAipTBZtTMzfgS;
			P_2.SetButtonsBitMask((bbQZXfVAmQcAGiAipTBZtTMzfgS & 0x7FF) | ((bbQZXfVAmQcAGiAipTBZtTMzfgS & (bbQZXfVAmQcAGiAipTBZtTMzfgS & -4096)) >> 1), 0);
			P_2.SetAxisValue(0, oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.fIhGRwxXdENEKpKVyjLgueXGkbI));
			P_2.SetAxisValue(1, oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.HaNRDfvvmnvtpVmiTDALwCvuuTW));
			P_2.SetAxisValue(2, oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.ZNZBdONXtrnCjExlJMTSeNBwBtHC));
			P_2.SetAxisValue(3, oMNnXrBObsqXntKHDHpZyOhNBhe(P_0.rZqefgRVFUwuBJvSCAojnoGymzw));
			P_2.SetAxisValue(4, rzftipSktlJlLuFMMFYxtgJffCT(P_0.TEvamTXrpBJZYnBiCkAjfkDTdlJa));
			P_2.SetAxisValue(5, rzftipSktlJlLuFMMFYxtgJffCT(P_0.naduVVWewZWUScMTpOYBLcUYfAcG));
		}

		private void rDjoVSuOhyvhSAGbQUYBfaeaZDy(ref tyUtJQcImzLjAriZAGfwxxkDlNn P_0, ref LowLevelInputEvent P_1)
		{
			int buttonsBitMask = P_1.GetButtonsBitMask(0);
			P_0.BbQZXfVAmQcAGiAipTBZtTMzfgS = (ypAnunIeotFiiZUloInQJbJLvKk)((buttonsBitMask & 0x7FF) | ((buttonsBitMask & (buttonsBitMask & -2048)) << 1));
			P_0.fIhGRwxXdENEKpKVyjLgueXGkbI = (short)(P_1.GetAxisValue(0) * 32768f);
			P_0.HaNRDfvvmnvtpVmiTDALwCvuuTW = (short)(P_1.GetAxisValue(1) * 32768f);
			P_0.ZNZBdONXtrnCjExlJMTSeNBwBtHC = (short)(P_1.GetAxisValue(2) * 32768f);
			P_0.rZqefgRVFUwuBJvSCAojnoGymzw = (short)(P_1.GetAxisValue(3) * 32768f);
			P_0.TEvamTXrpBJZYnBiCkAjfkDTdlJa = (byte)(P_1.GetAxisValue(4) * 255f);
			P_0.naduVVWewZWUScMTpOYBLcUYfAcG = (byte)(P_1.GetAxisValue(5) * 255f);
		}

		private static bool fjKDuIFmYPFHshMFIEKwpUOEovgL(int P_0, int P_1)
		{
			if (P_1 > 10)
			{
				P_1++;
			}
			return (P_0 & (1 << P_1)) != 0;
		}

		private void RFDPexajhTcXvizzpCmOkHbzMGox()
		{
			lock (VscpWqBWzuDusblaKBCJNvlmplv)
			{
				szvzTJksJVVSNdCaebZaVuBgpjQ = default(tyUtJQcImzLjAriZAGfwxxkDlNn);
				QHjYtINmLLlchvYcMCnuZZyQFbY = default(tyUtJQcImzLjAriZAGfwxxkDlNn);
				kxhgtldiZvXtvpQoAQRmEtvWcQG.Clear();
				qBsNOlJaQtsdnZAlQWMSpzDbRSm.Clear();
			}
		}

		public void Dispose()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(true);
			GC.SuppressFinalize(this);
		}

		~dAheZJcYloMwsIkRLXzIraBXTDWq()
		{
			WYoEhOBxiSjIYKwbsCHdGOUBXDbi(false);
		}

		protected virtual void WYoEhOBxiSjIYKwbsCHdGOUBXDbi(bool P_0)
		{
			if (inweGjIgYacXYohFlYRlpMFkgKMi)
			{
				return;
			}
			while (P_0)
			{
				qBsNOlJaQtsdnZAlQWMSpzDbRSm.Dispose();
				int num = -1676274592;
				while (true)
				{
					switch (num ^ -1676274591)
					{
					case 0:
						num = -1676274589;
						continue;
					case 2:
						break;
					default:
						goto end_IL_0027;
					}
					break;
				}
				continue;
				end_IL_0027:
				break;
			}
			inweGjIgYacXYohFlYRlpMFkgKMi = true;
		}

		public static float oMNnXrBObsqXntKHDHpZyOhNBhe(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 32768f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		public static float rzftipSktlJlLuFMMFYxtgJffCT(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 255f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private static bool GFhuAyJHZqtSqpgJiLGFVpCzEUaE(tyUtJQcImzLjAriZAGfwxxkDlNn P_0, tyUtJQcImzLjAriZAGfwxxkDlNn P_1)
		{
			if (P_0.BbQZXfVAmQcAGiAipTBZtTMzfgS == P_1.BbQZXfVAmQcAGiAipTBZtTMzfgS && P_0.TEvamTXrpBJZYnBiCkAjfkDTdlJa == P_1.TEvamTXrpBJZYnBiCkAjfkDTdlJa && P_0.naduVVWewZWUScMTpOYBLcUYfAcG == P_1.naduVVWewZWUScMTpOYBLcUYfAcG && P_0.fIhGRwxXdENEKpKVyjLgueXGkbI == P_1.fIhGRwxXdENEKpKVyjLgueXGkbI && P_0.HaNRDfvvmnvtpVmiTDALwCvuuTW == P_1.HaNRDfvvmnvtpVmiTDALwCvuuTW && P_0.ZNZBdONXtrnCjExlJMTSeNBwBtHC == P_1.ZNZBdONXtrnCjExlJMTSeNBwBtHC)
			{
				return P_0.rZqefgRVFUwuBJvSCAojnoGymzw == P_1.rZqefgRVFUwuBJvSCAojnoGymzw;
			}
			return false;
		}
	}

	public enum jOpoDMfJFRQnytamDfETJorBLMfI
	{
		oGbEtnPMuiBKqFepYfniGIKqdbx = 0,
		AvTAFMisemgsvRrIxsvyceeNUYw = 1
	}

	public const int FcygrpFKUsixprpcvEMGAzAebyfP = 4;

	public const int ldnbgLgVcxdlBicqaWuSSRBYANHr = 32768;

	public const int agCjQGEGRBXwUqQjsQzrUCXogvwh = -32768;

	public const int ksQsOvsJAinTwQItQUWjiSKKlAy = 255;

	public const int XqWqRdAXBuWQyoQUweWhSfkqeird = 0;

	public const int AhKCBkHJRRohyELpNntKuxCmROq = 18;

	public const int xcJqNlcWxdDAEMltXKAwHiIvcpD = 14;

	public const int MuLMbFioNFaLOxUnLgzhInBtFba = 6;

	public const int hIjxaBAKWUZfsPNnovajTJUEoNe = 15;

	private ffbtxKjczkhhcRJvRcraJnuRplQ[] wwBVaANEURTduKhRyuNLjoVXKbM;

	private bool XbzbcwuataFawKtfrNWeCnJnlCV;

	private sMSpCjRLIexIidKNbeILBVquoMd jnPfJZIxaCWAXdjCcXXJCLbpwXIr;

	private ojaoaGslfMZhMreoqLDKOowwnwZ trjqOBRLCttJUhhhIESwIbDltrb;

	private global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<bool> bGpaBMieDdHAVIdvKMObQFtPsiSb;

	private bool[] btZyDNkwqxqDVUdJzBthbUJbYWv;

	private bool[] WBnnTLfBXGDCIssRXyVgcQZKeDq;

	private bool pYyCCSzbscAnMJCcoGoTaGejmCpy;

	private readonly bool PHqEoFqFIEFqhnOsiBIBRAbmAEG;

	private readonly UpdateLoopSetting BnNkbgybnGDKKbEtlthkxBlHLlXR;

	private UpdateLoopType sAEptuKjxdOkaGcmFDmiJBfawmaw;

	private UpdateLoopType AvcfHEaEWMhEwPmLOlCIAEKGwXFU;

	private Action<int, ControllerDataUpdater> NvqaCuAwnRtIQraiMLVUyKxjukSM;

	private bool GdwddehUiZXSrisittjcvysYhhOK;

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> qnewRYFCzYevHqfqyatlbQmZFOFg;

	private Func<int> faTqYhfgwuuVCbrIpddTkYZQAdf;

	private static Guid[] rTPGoqIPOByrNfSLzahfkxfsNwXF;

	private static string[] VjBGfxtErPtjOKxAUMLURTBckAt;

	private static string[] XmZcwMAieGTeNGQJgGvoSdqUjLNa;

	[CustomObfuscation(rename = false)]
	public override int deviceCount
	{
		get
		{
			int num = 0;
			int num2 = 0;
			while (true)
			{
				int num3 = -96759997;
				while (true)
				{
					switch (num3 ^ -96759999)
					{
					case 0:
						break;
					case 2:
						num3 = -96759995;
						continue;
					case 5:
						num2++;
						num3 = -96759995;
						continue;
					case 1:
						if (wwBVaANEURTduKhRyuNLjoVXKbM[num2].isConnected)
						{
							num++;
							num3 = -96759996;
							continue;
						}
						goto case 5;
					case 4:
					{
						int num4;
						if (num2 >= 4)
						{
							num3 = -96759998;
							num4 = num3;
						}
						else
						{
							num3 = -96760000;
							num4 = num3;
						}
						continue;
					}
					default:
						return num;
					}
					break;
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => this;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => null;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.XInput;

	public zzOqSwMfghlPxHdUtRXPrOVahKl(bool isWin10AUHack, UpdateLoopSetting updateLoop, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
	{
		PHqEoFqFIEFqhnOsiBIBRAbmAEG = isWin10AUHack;
		BnNkbgybnGDKKbEtlthkxBlHLlXR = updateLoop;
		GdwddehUiZXSrisittjcvysYhhOK = true;
		try
		{
			if (!KUyKlnXhioRvEgicKXqeSHavFyrH.IuACrRLSXYCxPAGoMIMpLuEdZtDH(out var oAuxmLkIZODWmArmNvxTfYwIyXw, out var text, out var _))
			{
				throw new Exception("XInput is not available.");
			}
			if (oAuxmLkIZODWmArmNvxTfYwIyXw < OAuxmLkIZODWmArmNvxTfYwIyXw.FUEIyIxOseqEKFCLVbnhblwBChYg)
			{
				Rewired.Logger.LogWarning("The version of XInput (" + text + ") detected on your system is out of date. Please update to the latest version of XInput. Input will still function, but all features may not be available. See the documentation for required dependencies.");
			}
			else
			{
				_ = 4;
			}
			qnewRYFCzYevHqfqyatlbQmZFOFg = getHardwareJoystickMap_InputManager;
			faTqYhfgwuuVCbrIpddTkYZQAdf = getNewJoystickId;
			pYyCCSzbscAnMJCcoGoTaGejmCpy = UnityTools.platform == Platform.WindowsAppStore;
			using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
			{
				List<UpdateLoopType> list = tList.list;
				EnumConverter.ToUpdateLoopTypes(BnNkbgybnGDKKbEtlthkxBlHLlXR, list);
				int num2 = 0;
				if (num2 < list.Count)
				{
					AvcfHEaEWMhEwPmLOlCIAEKGwXFU = list[num2];
				}
			}
			bGpaBMieDdHAVIdvKMObQFtPsiSb = new global::ETrJCGYDLNaYoirFtJFXTwjRwgvl<bool>(useSharedThread: true, tAhKjvlAmgSXVDSHImtFjlRkDNt);
			btZyDNkwqxqDVUdJzBthbUJbYWv = new bool[4];
			WBnnTLfBXGDCIssRXyVgcQZKeDq = new bool[4];
			NvqaCuAwnRtIQraiMLVUyKxjukSM = UpdateControllerData;
			if (pYyCCSzbscAnMJCcoGoTaGejmCpy)
			{
				sxQxgCaJOgfjVojnunfaRwUvZWW();
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
		if (GdwddehUiZXSrisittjcvysYhhOK)
		{
			jnPfJZIxaCWAXdjCcXXJCLbpwXIr = new sMSpCjRLIexIidKNbeILBVquoMd(1f);
			goto IL_001b;
		}
		goto IL_010b;
		IL_010b:
		trjqOBRLCttJUhhhIESwIbDltrb = new ojaoaGslfMZhMreoqLDKOowwnwZ();
		int num;
		int num2;
		if (wwBVaANEURTduKhRyuNLjoVXKbM == null)
		{
			num = -1478517489;
			num2 = num;
		}
		else
		{
			num = -1478517491;
			num2 = num;
		}
		goto IL_0020;
		IL_001b:
		num = -1478517494;
		goto IL_0020;
		IL_0020:
		int num3 = default(int);
		dAheZJcYloMwsIkRLXzIraBXTDWq dAheZJcYloMwsIkRLXzIraBXTDWq2 = default(dAheZJcYloMwsIkRLXzIraBXTDWq);
		while (true)
		{
			switch (num ^ -1478517490)
			{
			case 0:
				break;
			default:
				return;
			case 6:
				wwBVaANEURTduKhRyuNLjoVXKbM[num3] = new ffbtxKjczkhhcRJvRcraJnuRplQ(num3, pYyCCSzbscAnMJCcoGoTaGejmCpy, dAheZJcYloMwsIkRLXzIraBXTDWq2, qnewRYFCzYevHqfqyatlbQmZFOFg, SystemDeviceDisconnected);
				num3++;
				num = -1478517493;
				continue;
			case 8:
				dAheZJcYloMwsIkRLXzIraBXTDWq2 = new dAheZJcYloMwsIkRLXzIraBXTDWq(num3, BnNkbgybnGDKKbEtlthkxBlHLlXR);
				kpfkMpAFolETeEcXIDaJMkIYftRp.joystickInputThread.ThreadUpdateEvent += dAheZJcYloMwsIkRLXzIraBXTDWq2.QDcVGGNdXBxpwkRxvJPlSDHeAfrj;
				kpfkMpAFolETeEcXIDaJMkIYftRp.joystickOutputThread.ThreadUpdateEvent += dAheZJcYloMwsIkRLXzIraBXTDWq2.dUrEQZivPwsiuRjrLFolumsPLOBe;
				num = -1478517496;
				continue;
			case 1:
				wwBVaANEURTduKhRyuNLjoVXKbM = new ffbtxKjczkhhcRJvRcraJnuRplQ[4];
				num3 = 0;
				num = -1478517493;
				continue;
			case 3:
				puPadpxEAZDlHtkcOFBtTMbrMIK(true);
				num = -1478517492;
				continue;
			case 5:
				goto IL_00f3;
			case 4:
				goto IL_010b;
			case 2:
				Update(UpdateLoopType.Update);
				num = -1478517495;
				continue;
			case 7:
				return;
			}
			break;
			IL_00f3:
			int num4;
			if (num3 < 4)
			{
				num = -1478517498;
				num4 = num;
			}
			else
			{
				num = -1478517491;
				num4 = num;
			}
		}
		goto IL_001b;
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType currentUpdateLoop)
	{
		sAEptuKjxdOkaGcmFDmiJBfawmaw = currentUpdateLoop;
		int num2 = default(int);
		while (true)
		{
			int num = 1432339563;
			while (true)
			{
				switch (num ^ 0x555FC46A)
				{
				case 2:
					break;
				default:
					return;
				case 1:
					mdMggEGjjzmtQQVNrFFxxhYpDZIA();
					num2 = 0;
					num = 1432339561;
					continue;
				case 3:
				{
					int num4;
					if (num2 < 4)
					{
						num = 1432339567;
						num4 = num;
					}
					else
					{
						num = 1432339564;
						num4 = num;
					}
					continue;
				}
				case 0:
					num2++;
					num = 1432339561;
					continue;
				case 4:
					wwBVaANEURTduKhRyuNLjoVXKbM[num2].Update();
					num = 1432339562;
					continue;
				case 5:
					if (wwBVaANEURTduKhRyuNLjoVXKbM[num2] != null)
					{
						int num3;
						if (wwBVaANEURTduKhRyuNLjoVXKbM[num2].isConnected)
						{
							num = 1432339566;
							num3 = num;
						}
						else
						{
							num = 1432339562;
							num3 = num;
						}
						continue;
					}
					goto case 0;
				case 6:
					return;
				}
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (bGpaBMieDdHAVIdvKMObQFtPsiSb != null)
		{
			goto IL_000b;
		}
		goto IL_00d6;
		IL_000b:
		int num = -1079605171;
		goto IL_0010;
		IL_0010:
		int num2 = default(int);
		while (true)
		{
			switch (num ^ -1079605179)
			{
			case 4:
				break;
			case 0:
				if (wwBVaANEURTduKhRyuNLjoVXKbM[num2] != null)
				{
					if (kpfkMpAFolETeEcXIDaJMkIYftRp.joystickInputThread != null)
					{
						kpfkMpAFolETeEcXIDaJMkIYftRp.joystickInputThread.ThreadUpdateEvent -= wwBVaANEURTduKhRyuNLjoVXKbM[num2].bBSBxriglpnOAawkfBpKCJgyYmdh.QDcVGGNdXBxpwkRxvJPlSDHeAfrj;
						num = -1079605182;
						continue;
					}
					goto case 7;
				}
				goto case 2;
			case 6:
				wwBVaANEURTduKhRyuNLjoVXKbM[num2].Dispose();
				num = -1079605177;
				continue;
			case 7:
				if (kpfkMpAFolETeEcXIDaJMkIYftRp.joystickOutputThread != null)
				{
					kpfkMpAFolETeEcXIDaJMkIYftRp.joystickOutputThread.ThreadUpdateEvent -= wwBVaANEURTduKhRyuNLjoVXKbM[num2].bBSBxriglpnOAawkfBpKCJgyYmdh.dUrEQZivPwsiuRjrLFolumsPLOBe;
					num = -1079605181;
					continue;
				}
				goto case 6;
			case 2:
				num2++;
				num = -1079605178;
				continue;
			case 1:
				goto IL_00d6;
			case 8:
				bGpaBMieDdHAVIdvKMObQFtPsiSb.WYoEhOBxiSjIYKwbsCHdGOUBXDbi();
				num = -1079605180;
				continue;
			case 3:
				goto IL_00ff;
			default:
				goto IL_0117;
			}
			break;
			IL_00ff:
			int num3;
			if (num2 >= 4)
			{
				num = -1079605184;
				num3 = num;
			}
			else
			{
				num = -1079605179;
				num3 = num;
			}
		}
		goto IL_000b;
		IL_0117:
		KUyKlnXhioRvEgicKXqeSHavFyrH.ajesCsGIfLHpYQEAwTJNkBnVPHN();
		return;
		IL_00d6:
		if (wwBVaANEURTduKhRyuNLjoVXKbM != null)
		{
			num2 = 0;
			num = -1079605178;
			goto IL_0010;
		}
		goto IL_0117;
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return NvqaCuAwnRtIQraiMLVUyKxjukSM;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int assignedControllerId, ControllerDataUpdater data)
	{
		wwBVaANEURTduKhRyuNLjoVXKbM[assignedControllerId].FillData(data);
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		puPadpxEAZDlHtkcOFBtTMbrMIK(true);
		bJtnQMHnnUbaAZHpCKktFusCUrr();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		puPadpxEAZDlHtkcOFBtTMbrMIK(true);
		bJtnQMHnnUbaAZHpCKktFusCUrr();
		while (true)
		{
			int num = 966655103;
			while (true)
			{
				switch (num ^ 0x399DFC7D)
				{
				case 0:
					break;
				default:
					return;
				case 2:
				{
					int num2;
					if (_SystemDeviceDisconnectedEvent != null)
					{
						num = 966655100;
						num2 = num;
					}
					else
					{
						num = 966655102;
						num2 = num;
					}
					continue;
				}
				case 1:
					_SystemDeviceDisconnectedEvent();
					num = 966655102;
					continue;
				case 3:
					return;
				}
				break;
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

	private bool BiMSEVmslhWszzOYkumAKoIQmGs()
	{
		if (sAEptuKjxdOkaGcmFDmiJBfawmaw != AvcfHEaEWMhEwPmLOlCIAEKGwXFU)
		{
			goto IL_000e;
		}
		bool flag = jnPfJZIxaCWAXdjCcXXJCLbpwXIr.FFYEDujhZPZIRSsDbLkeXQkxTZI();
		int num;
		if (flag)
		{
			puPadpxEAZDlHtkcOFBtTMbrMIK(true);
			num = -1619437625;
			goto IL_0013;
		}
		goto IL_004b;
		IL_0013:
		switch (num ^ -1619437627)
		{
		case 0:
			break;
		case 1:
			return false;
		default:
			goto IL_004b;
		}
		goto IL_000e;
		IL_004b:
		return flag;
		IL_000e:
		num = -1619437628;
		goto IL_0013;
	}

	private void puPadpxEAZDlHtkcOFBtTMbrMIK(bool P_0)
	{
		XbzbcwuataFawKtfrNWeCnJnlCV = P_0;
		while (true)
		{
			int num = -734895308;
			while (true)
			{
				switch (num ^ -734895307)
				{
				case 0:
					break;
				default:
					return;
				case 1:
					if (GdwddehUiZXSrisittjcvysYhhOK)
					{
						goto IL_002d;
					}
					return;
				case 2:
					return;
				}
				break;
				IL_002d:
				jnPfJZIxaCWAXdjCcXXJCLbpwXIr.EsoCoViNGnlmiCnejoKMpfdflIEq();
				num = -734895305;
			}
		}
	}

	private void bJtnQMHnnUbaAZHpCKktFusCUrr()
	{
		if (bGpaBMieDdHAVIdvKMObQFtPsiSb != null)
		{
			bGpaBMieDdHAVIdvKMObQFtPsiSb.ibajyEOvcZaAVvqbaVIEPkwcIqx();
		}
	}

	private void sxQxgCaJOgfjVojnunfaRwUvZWW()
	{
		tBYfLSCxOHBMTsBESxYMJzAlNDXv tBYfLSCxOHBMTsBESxYMJzAlNDXv2 = new tBYfLSCxOHBMTsBESxYMJzAlNDXv();
		_ = tBYfLSCxOHBMTsBESxYMJzAlNDXv2.IsConnected;
	}

	private void mdMggEGjjzmtQQVNrFFxxhYpDZIA()
	{
		bool flag = false;
		if (GdwddehUiZXSrisittjcvysYhhOK)
		{
			flag = BiMSEVmslhWszzOYkumAKoIQmGs();
			goto IL_0011;
		}
		goto IL_0046;
		IL_0046:
		int num;
		if (!flag)
		{
			int num2;
			if (!XbzbcwuataFawKtfrNWeCnJnlCV)
			{
				num = -996101129;
				num2 = num;
			}
			else
			{
				num = -996101131;
				num2 = num;
			}
			goto IL_0016;
		}
		goto IL_00d4;
		IL_0011:
		num = -996101130;
		goto IL_0016;
		IL_0016:
		while (true)
		{
			switch (num ^ -996101132)
			{
			case 6:
				break;
			default:
				return;
			case 2:
				goto IL_0046;
			case 4:
				goto IL_0065;
			case 5:
				DMCTVklVuaMMWNhSreqsObOptgT();
				num = -996101132;
				continue;
			case 7:
				CxmVMvQkajwTqrDzartmooWUzWu();
				num = -996101136;
				continue;
			case 1:
				PctgqfHBVCdCLsYrTryalobpnzd(noibpRjahizXDRrdOxmtyGBJPRG());
				puPadpxEAZDlHtkcOFBtTMbrMIK(false);
				bJtnQMHnnUbaAZHpCKktFusCUrr();
				return;
			case 3:
				goto IL_00d4;
			case 0:
				return;
			}
			break;
			IL_0065:
			if (bGpaBMieDdHAVIdvKMObQFtPsiSb.isRunning)
			{
				int num3;
				if (bGpaBMieDdHAVIdvKMObQFtPsiSb.uIPQYCOyPijpbHfLzGABZERoRaI())
				{
					num = -996101135;
					num3 = num;
				}
				else
				{
					num = -996101132;
					num3 = num;
				}
				continue;
			}
			return;
		}
		goto IL_0011;
		IL_00d4:
		int num4;
		if (!XbzbcwuataFawKtfrNWeCnJnlCV)
		{
			num = -996101136;
			num4 = num;
		}
		else
		{
			num = -996101133;
			num4 = num;
		}
		goto IL_0016;
	}

	private void CxmVMvQkajwTqrDzartmooWUzWu()
	{
		XbzbcwuataFawKtfrNWeCnJnlCV = false;
		while (true)
		{
			switch (-1899320898 ^ -1899320897)
			{
			case 0:
				continue;
			case 1:
				if (bGpaBMieDdHAVIdvKMObQFtPsiSb.isRunning)
				{
					return;
				}
				break;
			}
			break;
		}
		bGpaBMieDdHAVIdvKMObQFtPsiSb.LgoJHLCBitFthTodNHJlYroGYaX();
	}

	private void DMCTVklVuaMMWNhSreqsObOptgT()
	{
		lock (btZyDNkwqxqDVUdJzBthbUJbYWv)
		{
			Array.Copy(btZyDNkwqxqDVUdJzBthbUJbYWv, WBnnTLfBXGDCIssRXyVgcQZKeDq, 4);
		}
		PctgqfHBVCdCLsYrTryalobpnzd(WBnnTLfBXGDCIssRXyVgcQZKeDq);
	}

	private bool tAhKjvlAmgSXVDSHImtFjlRkDNt()
	{
		lock (btZyDNkwqxqDVUdJzBthbUJbYWv)
		{
			int num = 0;
			while (num < 4)
			{
				while (true)
				{
					int num2;
					if (wwBVaANEURTduKhRyuNLjoVXKbM[num] != null)
					{
						btZyDNkwqxqDVUdJzBthbUJbYWv[num] = wwBVaANEURTduKhRyuNLjoVXKbM[num].QkNBntJPimDfuflgKyTmAesTZBN(jOpoDMfJFRQnytamDfETJorBLMfI.oGbEtnPMuiBKqFepYfniGIKqdbx);
						num2 = -534027482;
						goto IL_0016;
					}
					goto IL_005a;
					IL_0016:
					while (true)
					{
						switch (num2 ^ -534027484)
						{
						case 3:
							num2 = -534027483;
							continue;
						case 1:
							break;
						case 2:
							goto IL_005a;
						default:
							goto end_IL_0033;
						}
						break;
					}
					continue;
					IL_005a:
					num++;
					num2 = -534027484;
					goto IL_0016;
					continue;
					end_IL_0033:
					break;
				}
			}
		}
		return true;
	}

	private bool[] noibpRjahizXDRrdOxmtyGBJPRG()
	{
		int num = 0;
		while (num < 4)
		{
			while (true)
			{
				WBnnTLfBXGDCIssRXyVgcQZKeDq[num] = wwBVaANEURTduKhRyuNLjoVXKbM[num].QkNBntJPimDfuflgKyTmAesTZBN(jOpoDMfJFRQnytamDfETJorBLMfI.oGbEtnPMuiBKqFepYfniGIKqdbx);
				num++;
				int num2 = -1369823221;
				while (true)
				{
					switch (num2 ^ -1369823223)
					{
					case 0:
						num2 = -1369823224;
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
		return WBnnTLfBXGDCIssRXyVgcQZKeDq;
	}

	private void PctgqfHBVCdCLsYrTryalobpnzd(bool[] P_0)
	{
		int num = 0;
		int num2 = 0;
		int num3 = default(int);
		int num5 = default(int);
		bool flag = default(bool);
		while (true)
		{
			IL_01bd:
			int num4;
			if (num2 >= 4)
			{
				num3 = 0;
				num4 = 5131574;
				goto IL_000e;
			}
			goto IL_0086;
			IL_000e:
			while (true)
			{
				switch (num4 ^ 0x4E4D38)
				{
				case 13:
					num4 = 5131580;
					continue;
				default:
					return;
				case 7:
					break;
				case 1:
					num5++;
					num4 = 5131576;
					continue;
				case 12:
					num3++;
					num4 = 5131574;
					continue;
				case 4:
					goto end_IL_000e;
				case 14:
					if (num3 >= 4)
					{
						num5 = 0;
						num4 = 5131576;
						continue;
					}
					goto case 11;
				case 11:
					if (wwBVaANEURTduKhRyuNLjoVXKbM[num3] == null || wwBVaANEURTduKhRyuNLjoVXKbM[num3].dNRDkMmUisYLGkOPcoQAKmRWFZI)
					{
						goto case 12;
					}
					goto IL_00da;
				case 9:
					wwBVaANEURTduKhRyuNLjoVXKbM[num2].TmPuAgvwmfrJaMdlQQbUAQUNyX(flag);
					num4 = 5131583;
					continue;
				case 8:
					goto IL_011e;
				case 5:
					if (!wHkejOBKyruymhvApBBfcXZjNmgH(wwBVaANEURTduKhRyuNLjoVXKbM[num3], true))
					{
						num |= ((num3 == 0) ? 1 : (1 << num3));
						num4 = 5131572;
						continue;
					}
					goto case 12;
				case 2:
					wHkejOBKyruymhvApBBfcXZjNmgH(wwBVaANEURTduKhRyuNLjoVXKbM[num2], false);
					num4 = 5131568;
					continue;
				case 6:
					if (wwBVaANEURTduKhRyuNLjoVXKbM[num5] != null)
					{
						int num6 = ((num5 == 0) ? 1 : (1 << num5));
						if ((num & num6) != 1 << num5)
						{
							wwBVaANEURTduKhRyuNLjoVXKbM[num5].WfQqfBBhdWYDnDEhJdivCjhwSVF(P_0[num5]);
							num4 = 5131577;
							continue;
						}
					}
					goto case 1;
				case 3:
					goto IL_01bd;
				case 0:
					goto IL_01d0;
				case 10:
					return;
				}
				int num7;
				if (flag)
				{
					num4 = 5131568;
					num7 = num4;
				}
				else
				{
					num4 = 5131578;
					num7 = num4;
				}
				continue;
				IL_01d0:
				int num8;
				if (num5 < 4)
				{
					num4 = 5131582;
					num8 = num4;
				}
				else
				{
					num4 = 5131570;
					num8 = num4;
				}
				continue;
				IL_00da:
				bool flag2 = P_0[num3];
				wwBVaANEURTduKhRyuNLjoVXKbM[num3].TmPuAgvwmfrJaMdlQQbUAQUNyX(flag2);
				int num9;
				if (!flag2)
				{
					num4 = 5131572;
					num9 = num4;
				}
				else
				{
					num4 = 5131581;
					num9 = num4;
				}
				continue;
				end_IL_000e:
				break;
			}
			goto IL_0086;
			IL_0086:
			if (wwBVaANEURTduKhRyuNLjoVXKbM[num2] != null && wwBVaANEURTduKhRyuNLjoVXKbM[num2].dNRDkMmUisYLGkOPcoQAKmRWFZI)
			{
				flag = P_0[num2];
				num4 = 5131569;
				goto IL_000e;
			}
			goto IL_011e;
			IL_011e:
			num2++;
			num4 = 5131579;
			goto IL_000e;
		}
	}

	private bool wHkejOBKyruymhvApBBfcXZjNmgH(ffbtxKjczkhhcRJvRcraJnuRplQ P_0, bool P_1)
	{
		int num = default(int);
		if (P_1)
		{
			P_0.faOhmAGkRPXLQUdbAbvUvxXdvVxl();
			if (!P_0.HazcIAHTRnlmnxxFXuxuOGyUDSkF)
			{
				return false;
			}
			num = trjqOBRLCttJUhhhIESwIbDltrb.wqFAoMkdRLEuIZUImAKtRfbOLLwG(P_0.bTBTDemkrYriKgIjLkfUkGMaAvIh, false);
			goto IL_0029;
		}
		goto IL_0170;
		IL_002e:
		int num2;
		ControllerDisconnectedEventArgs obj = default(ControllerDisconnectedEventArgs);
		BridgedController obj2 = default(BridgedController);
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ 0x38B1D753)
			{
			case 5:
				break;
			case 0:
				goto IL_006e;
			case 10:
				obj = P_0.ToControllerDisconnectedEventArgs();
				P_0.WZhxXqkljwkXfQWaTheVVynohNy();
				num2 = 951179093;
				continue;
			case 4:
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(P_0));
					num2 = 951179091;
					continue;
				}
				goto IL_006e;
			case 7:
				_DeviceConnectedEvent(obj2);
				num2 = 951179099;
				continue;
			case 9:
				if (num >= 0)
				{
					P_0.rewiredId = trjqOBRLCttJUhhhIESwIbDltrb.BUQIKskPMHutvDgPrvtkGgMWGRi(num);
					num2 = 951179089;
					continue;
				}
				goto case 1;
			case 11:
				trjqOBRLCttJUhhhIESwIbDltrb.iuKtrqAKDXxOzbfyYKefhjTUEZQ(num3, false);
				num2 = 951179097;
				continue;
			case 1:
				P_0.rewiredId = faTqYhfgwuuVCbrIpddTkYZQAdf();
				trjqOBRLCttJUhhhIESwIbDltrb.klTcSvpccfbAAbHlREdQKnourmGO(P_0, true);
				num2 = 951179095;
				continue;
			case 6:
				if (_DeviceDisconnectedEvent != null)
				{
					_DeviceDisconnectedEvent(obj);
					num2 = 951179099;
					continue;
				}
				goto default;
			case 2:
				trjqOBRLCttJUhhhIESwIbDltrb.FFYEDujhZPZIRSsDbLkeXQkxTZI(num, P_0, true);
				num2 = 951179095;
				continue;
			case 3:
				goto IL_0170;
			default:
				return true;
			}
			break;
			IL_006e:
			obj2 = P_0.ToBridgedController();
			int num4;
			if (_DeviceConnectedEvent == null)
			{
				num2 = 951179099;
				num4 = num2;
			}
			else
			{
				num2 = 951179092;
				num4 = num2;
			}
		}
		goto IL_0029;
		IL_0170:
		num3 = trjqOBRLCttJUhhhIESwIbDltrb.LdeYUipgUiPUwsTmDLLPrLKDSEy(P_0.rewiredId, P_0.bTBTDemkrYriKgIjLkfUkGMaAvIh, true);
		int num5;
		if (num3 < 0)
		{
			num2 = 951179097;
			num5 = num2;
		}
		else
		{
			num2 = 951179096;
			num5 = num2;
		}
		goto IL_002e;
		IL_0029:
		num2 = 951179098;
		goto IL_002e;
	}

	static zzOqSwMfghlPxHdUtRXPrOVahKl()
	{
		rTPGoqIPOByrNfSLzahfkxfsNwXF = new Guid[2]
		{
			new Guid("72100955-0000-0000-0000-504944564944"),
			new Guid("02e0045e-0000-0000-0000-504944564944")
		};
		string[] vjBGfxtErPtjOKxAUMLURTBckAt = new string[1] { "Xbox Bluetooth Gamepad" };
		while (true)
		{
			int num = -224386910;
			while (true)
			{
				switch (num ^ -224386912)
				{
				case 0:
					break;
				case 2:
					goto IL_0066;
				default:
					XmZcwMAieGTeNGQJgGvoSdqUjLNa = new string[1] { "Xbox Wireless Controller.*" };
					return;
				}
				break;
				IL_0066:
				VjBGfxtErPtjOKxAUMLURTBckAt = vjBGfxtErPtjOKxAUMLURTBckAt;
				num = -224386911;
			}
		}
	}

	public static bool MaQsCwUpHxzwhotZWnHQMwdFcRm(string P_0, string P_1, string P_2, Guid P_3)
	{
		if (ArrayTools.Contains(rTPGoqIPOByrNfSLzahfkxfsNwXF, P_3))
		{
			return true;
		}
		int num = default(int);
		if (!string.IsNullOrEmpty(P_1))
		{
			num = 0;
			goto IL_0064;
		}
		goto IL_009c;
		IL_0023:
		int num2;
		int num4 = default(int);
		int num3 = default(int);
		while (true)
		{
			switch (num2 ^ 0x42324EF0)
			{
			case 7:
				num2 = 1110593269;
				continue;
			case 6:
				num4 = 0;
				num2 = 1110593264;
				continue;
			case 3:
				break;
			case 9:
				goto IL_007f;
			case 2:
				goto IL_009c;
			case 5:
				goto IL_00b8;
			case 1:
				num3 = P_0.IndexOf("vid_");
				num2 = 1110593272;
				continue;
			case 4:
				P_0 = P_0.ToLower();
				num2 = 1110593265;
				continue;
			case 0:
				goto IL_0100;
			default:
				goto IL_011e;
			}
			break;
			IL_0100:
			int num5;
			if (num4 >= XmZcwMAieGTeNGQJgGvoSdqUjLNa.Length)
			{
				num2 = 1110593268;
				num5 = num2;
			}
			else
			{
				num2 = 1110593273;
				num5 = num2;
			}
			continue;
			IL_00b8:
			if (P_1.Equals(VjBGfxtErPtjOKxAUMLURTBckAt[num], StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			num++;
			num2 = 1110593267;
			continue;
			IL_007f:
			if (Regex.IsMatch(P_2, XmZcwMAieGTeNGQJgGvoSdqUjLNa[num4], RegexOptions.IgnoreCase))
			{
				return true;
			}
			num4++;
			num2 = 1110593264;
		}
		goto IL_0064;
		IL_009c:
		int num6;
		if (!string.IsNullOrEmpty(P_2))
		{
			num2 = 1110593270;
			num6 = num2;
		}
		else
		{
			num2 = 1110593268;
			num6 = num2;
		}
		goto IL_0023;
		IL_0064:
		int num7;
		if (num >= VjBGfxtErPtjOKxAUMLURTBckAt.Length)
		{
			num2 = 1110593266;
			num7 = num2;
		}
		else
		{
			num2 = 1110593269;
			num7 = num2;
		}
		goto IL_0023;
		IL_011e:
		if (num3 < 0)
		{
			return false;
		}
		if (P_0.IndexOf("ig_") < num3)
		{
			return false;
		}
		return true;
	}
}
