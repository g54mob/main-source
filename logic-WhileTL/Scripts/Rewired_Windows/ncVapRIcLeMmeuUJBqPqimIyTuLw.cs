using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;
using Rewired.Windows.RawInput;

internal class ncVapRIcLeMmeuUJBqPqimIyTuLw : PlatformInputManager, InpDmQfQABlCOUIizbBrrTlTjrHt
{
	private class UebDdpmoIIdJuxGjNGokDpNzqIzJA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int xvLwpzRxEqetsJjstnBxHhLaFxQp;

		private int oIwIqNbDPpBbcpjyUoyJOCjctEwH;

		public Guid dPMadqhvuBRgljDGjUtDIjoGIjQT;

		public string duWoKglBKGEpffcLstnRbzVStlDhA;

		private readonly asRdKzmHUeOfEtnumeRYNLFtgVpi rCJaKsAexMPepwMrQdSYEBasCTuF;

		private readonly DeviceType zAUqhzxUFxqJuedphcqKckrxZrTB;

		public string QamwaQQOPPlBpZemmRFSsepNDSwgA;

		public string amzBQgIbgHOYPYUlHRjTPwlDSBVT;

		public string fnndwwSKqCfOVgTxiofbCSvdZVaFB;

		public int PXSwjWYIheQFLZmFNDKaEapYvqTQA;

		public int njswgvuMzcLnpKZRHaLNQVEaolpQ;

		public Guid MLvLlmCarLCofsbmoqbKmtCymXhQ;

		public Guid CDvRASMfYBfpSfdfDAtTJlxQyhrm;

		public Guid sPqIFOmgKdKnaJgxkNEYZxiINXMO;

		public int ImHZXPeiZINzqbSIYeCFsHJmGRICA;

		public int YlthzTIXIGbxaxevGySzSFhuWDCG;

		public int DcoIvrxxhbgCbABcrHbjOpmzeOXy;

		public int VoWZngliXonIzcwhdgDwbBjKENjE;

		public int QuzTRGrrwUDmZKKoxoEmRnZQaQrEA;

		public int xflwuDqqdyfLyLTsZZPVSflXIYOc;

		public bool qkOoPnxESVYPHGjWZGnaEIgYMrWN;

		public bool hzRMSivHdAwVXtgeyFCyPwVEqCvC;

		public bool CxdmZJFkiTFxYWsHLfVdndaLjLIp;

		public int XGxqJjeMmWaLNdigbGxrFJMAqZbac;

		private float[] lMBOzesBmklbuZRpFYcRpzoxCCSg;

		private float[] FSlHLPPornJarrBYtTZNwaDNeTEy;

		private bool[] KefcfUpJsbrddeOWVTtdWXzlOygA;

		private HardwareJoystickMap_InputManager hrWFokKRfePnjNhvOPIDFxJfIhDv;

		private BWhlahGgwqzZnsKWAMzsCpuXBaYA rENRiuJsaTUuZiPQKEZjwreEyAYl;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> TGhMfMpddOgpnflvcRUCHgmAPREiA;

		private bool OHUncRdpKbQtPCKUpXfRpjuMazFGA;

		private bool xVYllnapIihKZtPcCvQiCCkKaTWz;

		[CompilerGenerated]
		private Controller.Extension mtaCcFBxxyANyfCGJpKGlbawqhJec;

		private bool TExNvhkEWsBWipIUjadCDaTpNNDG;

		public bool oVGTkQyMINjfDtilToygxfKlAUDK
		{
			get
			{
				if (rCJaKsAexMPepwMrQdSYEBasCTuF == null)
				{
					return false;
				}
				return rCJaKsAexMPepwMrQdSYEBasCTuF.pOSToWoKPbQypFYQiUpDCTXdBGHb != null;
			}
		}

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return xvLwpzRxEqetsJjstnBxHhLaFxQp;
			}
			set
			{
				xvLwpzRxEqetsJjstnBxHhLaFxQp = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return oIwIqNbDPpBbcpjyUoyJOCjctEwH;
			}
			set
			{
				oIwIqNbDPpBbcpjyUoyJOCjctEwH = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (duWoKglBKGEpffcLstnRbzVStlDhA != "Unknown Controller")
				{
					return duWoKglBKGEpffcLstnRbzVStlDhA;
				}
				if (hzRMSivHdAwVXtgeyFCyPwVEqCvC && !string.IsNullOrEmpty(fnndwwSKqCfOVgTxiofbCSvdZVaFB))
				{
					return fnndwwSKqCfOVgTxiofbCSvdZVaFB;
				}
				return amzBQgIbgHOYPYUlHRjTPwlDSBVT;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (oIwIqNbDPpBbcpjyUoyJOCjctEwH < 0)
				{
					return null;
				}
				return oIwIqNbDPpBbcpjyUoyJOCjctEwH;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return mtaCcFBxxyANyfCGJpKGlbawqhJec;
			}
			[CompilerGenerated]
			set
			{
				mtaCcFBxxyANyfCGJpKGlbawqhJec = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => MLvLlmCarLCofsbmoqbKmtCymXhQ;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		public bool RWcjmtEWOihCnICrbgbyOHewqpcW
		{
			get
			{
				if (!TExNvhkEWsBWipIUjadCDaTpNNDG && rCJaKsAexMPepwMrQdSYEBasCTuF != null)
				{
					return rCJaKsAexMPepwMrQdSYEBasCTuF.RWcjmtEWOihCnICrbgbyOHewqpcW;
				}
				return false;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			_ = RWcjmtEWOihCnICrbgbyOHewqpcW;
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			_ = RWcjmtEWOihCnICrbgbyOHewqpcW;
		}

		public UebDdpmoIIdJuxGjNGokDpNzqIzJA(asRdKzmHUeOfEtnumeRYNLFtgVpi P_0, DeviceType P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2)
		{
			rCJaKsAexMPepwMrQdSYEBasCTuF = P_0;
			zAUqhzxUFxqJuedphcqKckrxZrTB = P_1;
			TGhMfMpddOgpnflvcRUCHgmAPREiA = P_2;
			oIwIqNbDPpBbcpjyUoyJOCjctEwH = -1;
			xvLwpzRxEqetsJjstnBxHhLaFxQp = -1;
		}

		public void GshLMkEsaZGvRxOGtfzVMnkiYxqS()
		{
			if (!RWcjmtEWOihCnICrbgbyOHewqpcW)
			{
				return;
			}
			string obj = ((!string.IsNullOrEmpty(fnndwwSKqCfOVgTxiofbCSvdZVaFB)) ? fnndwwSKqCfOVgTxiofbCSvdZVaFB : amzBQgIbgHOYPYUlHRjTPwlDSBVT);
			Guid cDvRASMfYBfpSfdfDAtTJlxQyhrm = CDvRASMfYBfpSfdfDAtTJlxQyhrm;
			sPqIFOmgKdKnaJgxkNEYZxiINXMO = MiscTools.CreateGuidHashSHA1(obj + cDvRASMfYBfpSfdfDAtTJlxQyhrm.ToString());
			YlthzTIXIGbxaxevGySzSFhuWDCG = VoWZngliXonIzcwhdgDwbBjKENjE;
			DcoIvrxxhbgCbABcrHbjOpmzeOXy = QuzTRGrrwUDmZKKoxoEmRnZQaQrEA + xflwuDqqdyfLyLTsZZPVSflXIYOc * 8;
			bKOJiVJxFDkRpxUXrQUwrkhXlNCR();
			dPMadqhvuBRgljDGjUtDIjoGIjQT = hrWFokKRfePnjNhvOPIDFxJfIhDv.hardwareMapIdentifier.guid;
			duWoKglBKGEpffcLstnRbzVStlDhA = hrWFokKRfePnjNhvOPIDFxJfIhDv.controllerName;
			OHUncRdpKbQtPCKUpXfRpjuMazFGA = ((dPMadqhvuBRgljDGjUtDIjoGIjQT == Guid.Empty) ? true : false);
			lMBOzesBmklbuZRpFYcRpzoxCCSg = new float[YlthzTIXIGbxaxevGySzSFhuWDCG];
			FSlHLPPornJarrBYtTZNwaDNeTEy = new float[DcoIvrxxhbgCbABcrHbjOpmzeOXy];
			KefcfUpJsbrddeOWVTtdWXzlOygA = new bool[DcoIvrxxhbgCbABcrHbjOpmzeOXy];
			if (hrWFokKRfePnjNhvOPIDFxJfIhDv != null && DcoIvrxxhbgCbABcrHbjOpmzeOXy > 0)
			{
				switch (hrWFokKRfePnjNhvOPIDFxJfIhDv.map.platform)
				{
				case InputPlatform.WindowsRawInput:
				{
					HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Buttons_orig;
					if (buttons_orig2 != null)
					{
						for (int j = 0; j < buttons_orig2.Length; j++)
						{
							KefcfUpJsbrddeOWVTtdWXzlOygA[j] = buttons_orig2[j].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				case InputPlatform.WindowsDirectInput:
				{
					HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Buttons_orig;
					if (buttons_orig != null)
					{
						for (int i = 0; i < buttons_orig.Length; i++)
						{
							KefcfUpJsbrddeOWVTtdWXzlOygA[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
						}
					}
					break;
				}
				}
			}
			rENRiuJsaTUuZiPQKEZjwreEyAYl = rCJaKsAexMPepwMrQdSYEBasCTuF.MTZhVIKBKRLScmMzBpiVZUsSQZVd;
			Update();
		}

		public void QWPcQcByrISmXcCAXpmwAVqOfKnab(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0)
		{
			if (RWcjmtEWOihCnICrbgbyOHewqpcW && P_0 != null)
			{
				oIwIqNbDPpBbcpjyUoyJOCjctEwH = P_0.oIwIqNbDPpBbcpjyUoyJOCjctEwH;
				xvLwpzRxEqetsJjstnBxHhLaFxQp = P_0.xvLwpzRxEqetsJjstnBxHhLaFxQp;
				for (int i = 0; i < MathTools.Min(FSlHLPPornJarrBYtTZNwaDNeTEy.Length, P_0.FSlHLPPornJarrBYtTZNwaDNeTEy.Length); i++)
				{
					FSlHLPPornJarrBYtTZNwaDNeTEy[i] = P_0.FSlHLPPornJarrBYtTZNwaDNeTEy[i];
				}
				for (int j = 0; j < MathTools.Min(KefcfUpJsbrddeOWVTtdWXzlOygA.Length, P_0.KefcfUpJsbrddeOWVTtdWXzlOygA.Length); j++)
				{
					KefcfUpJsbrddeOWVTtdWXzlOygA[j] = P_0.KefcfUpJsbrddeOWVTtdWXzlOygA[j];
				}
				for (int k = 0; k < MathTools.Min(lMBOzesBmklbuZRpFYcRpzoxCCSg.Length, P_0.lMBOzesBmklbuZRpFYcRpzoxCCSg.Length); k++)
				{
					lMBOzesBmklbuZRpFYcRpzoxCCSg[k] = P_0.lMBOzesBmklbuZRpFYcRpzoxCCSg[k];
				}
				xVYllnapIihKZtPcCvQiCCkKaTWz = P_0.xVYllnapIihKZtPcCvQiCCkKaTWz;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			if (RWcjmtEWOihCnICrbgbyOHewqpcW)
			{
				bool[] array = rCJaKsAexMPepwMrQdSYEBasCTuF.cSTdYhCfOIlkyjUlxiceJHSyagLSA;
				int[] array2 = rCJaKsAexMPepwMrQdSYEBasCTuF.IMSgnydiJRMbFOJZiuTORfgUwFavA;
				qQBpUfKcENfkDgKnrxrAJYEFaUtgb(array, array2);
				LypwQqzNcDJwwFDlDCnxBriUiWiHA(array, array2);
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (!RWcjmtEWOihCnICrbgbyOHewqpcW)
			{
				return;
			}
			if (YlthzTIXIGbxaxevGySzSFhuWDCG != dataUpdater.axisCount || DcoIvrxxhbgCbABcrHbjOpmzeOXy != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < YlthzTIXIGbxaxevGySzSFhuWDCG; i++)
			{
				dataUpdater.axisValues[i] = lMBOzesBmklbuZRpFYcRpzoxCCSg[i];
			}
			for (int j = 0; j < DcoIvrxxhbgCbABcrHbjOpmzeOXy; j++)
			{
				if (KefcfUpJsbrddeOWVTtdWXzlOygA[j])
				{
					dataUpdater.buttonPressureValues[j] = FSlHLPPornJarrBYtTZNwaDNeTEy[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = FSlHLPPornJarrBYtTZNwaDNeTEy[j] > 0f;
				}
			}
			if (xVYllnapIihKZtPcCvQiCCkKaTWz && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int oTaRposvbRJAiqTPfKKyqhkEgQHG(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0)
		{
			if (!RWcjmtEWOihCnICrbgbyOHewqpcW)
			{
				return 0;
			}
			if (P_0.xvLwpzRxEqetsJjstnBxHhLaFxQp == xvLwpzRxEqetsJjstnBxHhLaFxQp)
			{
				return 2;
			}
			if (VoWZngliXonIzcwhdgDwbBjKENjE != P_0.VoWZngliXonIzcwhdgDwbBjKENjE)
			{
				return 0;
			}
			if (QuzTRGrrwUDmZKKoxoEmRnZQaQrEA != P_0.QuzTRGrrwUDmZKKoxoEmRnZQaQrEA)
			{
				return 0;
			}
			if (xflwuDqqdyfLyLTsZZPVSflXIYOc != P_0.xflwuDqqdyfLyLTsZZPVSflXIYOc)
			{
				return 0;
			}
			if (oVGTkQyMINjfDtilToygxfKlAUDK != P_0.oVGTkQyMINjfDtilToygxfKlAUDK)
			{
				return 0;
			}
			if (P_0.instanceGuid == instanceGuid)
			{
				return 2;
			}
			if (P_0.sPqIFOmgKdKnaJgxkNEYZxiINXMO == sPqIFOmgKdKnaJgxkNEYZxiINXMO)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo rTVVkYwcBzPcSjgQNEJEDKXoKAcdA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			AnvVmXkzaGotHQSsrLViRKpQvMhJ(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			if (!RWcjmtEWOihCnICrbgbyOHewqpcW)
			{
				return null;
			}
			BridgedController bridgedController = new BridgedController();
			AnvVmXkzaGotHQSsrLViRKpQvMhJ(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(xvLwpzRxEqetsJjstnBxHhLaFxQp);
		}

		private void qQBpUfKcENfkDgKnrxrAJYEFaUtgb(bool[] P_0, int[] P_1)
		{
			if (YlthzTIXIGbxaxevGySzSFhuWDCG <= 0)
			{
				return;
			}
			switch (hrWFokKRfePnjNhvOPIDFxJfIhDv.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Axes_orig;
				if (axes_orig3 != null)
				{
					for (int k = 0; k < axes_orig3.Length; k++)
					{
						pqTPPLtqOsLbBAuHrXjQpqlVhJui(axes_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						pqTPPLtqOsLbBAuHrXjQpqlVhJui(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						lnmNNmAZgVMVdpYHhnfiKmBEoKcP(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void LypwQqzNcDJwwFDlDCnxBriUiWiHA(bool[] P_0, int[] P_1)
		{
			if (DcoIvrxxhbgCbABcrHbjOpmzeOXy <= 0)
			{
				return;
			}
			switch (hrWFokKRfePnjNhvOPIDFxJfIhDv.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig3 = ((HardwareJoystickMap.Platform_RawInput_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Buttons_orig;
				if (buttons_orig3 != null)
				{
					for (int k = 0; k < buttons_orig3.Length; k++)
					{
						bsGPtyaTjBebeztTOjZmvqlkTKaC(buttons_orig3[k], k, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_DirectInput_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						bsGPtyaTjBebeztTOjZmvqlkTKaC(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.InternalDriver:
			{
				HardwareJoystickMap.Platform_InternalDriver_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_InternalDriver_Base)hrWFokKRfePnjNhvOPIDFxJfIhDv.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						IaYdMEFIaXaMFQXbYzRhsRVRMjKXA(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void pqTPPLtqOsLbBAuHrXjQpqlVhJui(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= YlthzTIXIGbxaxevGySzSFhuWDCG)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			lMBOzesBmklbuZRpFYcRpzoxCCSg[P_1] = gtExFxcpYcZTABrBeLFEPTMTniaw(P_0, P_2, P_3);
			if (!xVYllnapIihKZtPcCvQiCCkKaTWz && lMBOzesBmklbuZRpFYcRpzoxCCSg[P_1] != 0f)
			{
				xVYllnapIihKZtPcCvQiCCkKaTWz = true;
			}
		}

		private void bsGPtyaTjBebeztTOjZmvqlkTKaC(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= DcoIvrxxhbgCbABcrHbjOpmzeOXy)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			FSlHLPPornJarrBYtTZNwaDNeTEy[P_1] = KXJdWAAUxLBpMBYcIbLVuKxtomne(P_0, P_2, P_3);
			if (!xVYllnapIihKZtPcCvQiCCkKaTWz && FSlHLPPornJarrBYtTZNwaDNeTEy[P_1] != 0f)
			{
				xVYllnapIihKZtPcCvQiCCkKaTWz = true;
			}
		}

		private float gtExFxcpYcZTABrBeLFEPTMTniaw(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				int num;
				switch (sourceAxis)
				{
				case 0:
					return 0f;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					num = 0;
					break;
				default:
					if (sourceAxis == 1000)
					{
						if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Axis axis))
						{
							return 0f;
						}
						num = axis.sourceOtherAxis;
						break;
					}
					return 0f;
				}
				return gtExFxcpYcZTABrBeLFEPTMTniaw((RawInputAxis)sourceAxis, num);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= QuzTRGrrwUDmZKKoxoEmRnZQaQrEA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= xflwuDqqdyfLyLTsZZPVSflXIYOc || sourceHat >= 4)
				{
					return 0f;
				}
				int num2 = P_2[sourceHat];
				if (num2 < 0)
				{
					return 0f;
				}
				float num3;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num3 = ZmMaCMFrDBLDkdiRsvJfMxgBzmUuA(num2, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num3 = ZmMaCMFrDBLDkdiRsvJfMxgBzmUuA(num2, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num3 < 0f)
							{
								return 0f;
							}
						}
						else if (num3 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num3 *= -1f;
				}
				return num3;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int i = 0; i < customCalculationSourceData.Length; i++)
				{
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && ifPQCHpvZgPCuYfLfyjLCfAIdFnd(customCalculationSourceData[i], out var item))
					{
						customCalculation.AddData(item);
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				return customCalculation.Result;
			}
			return 0f;
		}

		private float gtExFxcpYcZTABrBeLFEPTMTniaw(RawInputAxis P_0, int P_1)
		{
			return ZeCVkTdiUyWuvkSDDwvSKXKKMqkf((rENRiuJsaTUuZiPQKEZjwreEyAYl as YzhTkxbnAyFqHcHbqYnZZGjpbdcx).gtExFxcpYcZTABrBeLFEPTMTniaw(P_0, P_1));
		}

		private float KXJdWAAUxLBpMBYcIbLVuKxtomne(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
						{
							return 0f;
						}
					}
				}
				if (P_0.requireMultipleButtons)
				{
					bool flag = false;
					for (int j = 0; j < P_0.requiredButtons.Length; j++)
					{
						if (!P_1[P_0.requiredButtons[j]])
						{
							return 0f;
						}
						flag = true;
					}
					if (flag)
					{
						return 1f;
					}
					return 0f;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= QuzTRGrrwUDmZKKoxoEmRnZQaQrEA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				int num;
				switch (sourceAxis)
				{
				case 0:
					return 0f;
				case 1:
				case 2:
				case 3:
				case 4:
				case 5:
				case 6:
				case 7:
				case 8:
				case 9:
				case 10:
				case 11:
					num = 0;
					break;
				default:
					if (sourceAxis == 1000)
					{
						if (!(P_0 is HardwareJoystickMap.Platform_RawInput_Base.Button button))
						{
							return 0f;
						}
						num = button.sourceOtherAxis;
						break;
					}
					return 0f;
				}
				float num2 = gtExFxcpYcZTABrBeLFEPTMTniaw((RawInputAxis)sourceAxis, num);
				float num3 = MathTools.Abs(num2);
				if (num3 <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num2 < 0f)
					{
						return 0f;
					}
				}
				else if (num2 > 0f)
				{
					return 0f;
				}
				return num3;
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= xflwuDqqdyfLyLTsZZPVSflXIYOc || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return 0f;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return 0f;
				}
				for (int k = 0; k < customCalculationSourceData.Length; k++)
				{
					if (customCalculationSourceData[k] == null)
					{
						continue;
					}
					switch ((HardwareElementSourceTypeWithHat)customCalculationSourceData[k].sourceType)
					{
					case HardwareElementSourceTypeWithHat.Button:
					{
						if (TfUHUDISYYGXIbkDEFqgciTiIoGAc(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (ifPQCHpvZgPCuYfLfyjLCfAIdFnd(customCalculationSourceData[k], out var num4))
						{
							customCalculation.AddData((num4 != 0f) ? 1f : 0f);
						}
						break;
					}
					}
				}
				if (!customCalculation.Process())
				{
					return 0f;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return 0f;
				}
				if ((float)customCalculation.Result == 0f)
				{
					return 0f;
				}
				return 1f;
			}
			return 0f;
		}

		private float ZeCVkTdiUyWuvkSDDwvSKXKKMqkf(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}

		private float OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (hrWFokKRfePnjNhvOPIDFxJfIhDv.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
			{
				return 0f;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return 0f;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return 1f;
			}
			return 0f;
		}

		private float ZmMaCMFrDBLDkdiRsvJfMxgBzmUuA(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private bool TfUHUDISYYGXIbkDEFqgciTiIoGAc(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= QuzTRGrrwUDmZKKoxoEmRnZQaQrEA || sourceButton >= 256)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool ifPQCHpvZgPCuYfLfyjLCfAIdFnd(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis == 0)
			{
				return false;
			}
			P_1 = gtExFxcpYcZTABrBeLFEPTMTniaw((RawInputAxis)P_0.sourceAxis, P_0.sourceOtherAxis);
			switch (P_0.sourceAxisRange)
			{
			case AxisRange.Negative:
				if (P_1 > 0f)
				{
					P_1 = 0f;
				}
				break;
			case AxisRange.Positive:
				if (P_1 < 0f)
				{
					P_1 = 0f;
				}
				break;
			}
			if (P_0.axisCalibrationType == AxisCalibrationType.Default)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, -1f, 1f, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Custom)
			{
				P_1 = InputTools.GetCalibratedAxisValueClamped(P_1, P_0.axisZero, P_0.axisMin, P_0.axisMax, P_0.axisDeadZone, P_0.invert, applySensitivity: false, AxisSensitivityType.Multiplier, 1f, null);
			}
			else if (P_0.axisCalibrationType == AxisCalibrationType.Uncalibrated && P_0.axisDeadZone > 0f && MathTools.Abs(P_1) <= P_0.axisDeadZone)
			{
				P_1 = 0f;
			}
			return true;
		}

		private ControlDeviceType MtllQqYZIEpvITrpcHecLxvuFLde(DeviceType P_0)
		{
			return P_0 switch
			{
				DeviceType.Keyboard => ControlDeviceType.Keyboard, 
				DeviceType.Joystick => ControlDeviceType.Joystick, 
				DeviceType.Gamepad => ControlDeviceType.Gamepad, 
				DeviceType.Mouse => ControlDeviceType.Mouse, 
				DeviceType.MultiAxisController => ControlDeviceType.Joystick, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void lnmNNmAZgVMVdpYHhnfiKmBEoKcP(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= YlthzTIXIGbxaxevGySzSFhuWDCG)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			lMBOzesBmklbuZRpFYcRpzoxCCSg[P_1] = KziKleVdAtTVXSiVldemCMiJHBDc(P_0, P_2, P_3);
			if (!xVYllnapIihKZtPcCvQiCCkKaTWz && lMBOzesBmklbuZRpFYcRpzoxCCSg[P_1] != 0f)
			{
				xVYllnapIihKZtPcCvQiCCkKaTWz = true;
			}
		}

		private void IaYdMEFIaXaMFQXbYzRhsRVRMjKXA(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= DcoIvrxxhbgCbABcrHbjOpmzeOXy)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			FSlHLPPornJarrBYtTZNwaDNeTEy[P_1] = sbHZNHEZgtblLBVYxGsxpKTdJUDe(P_0, P_2, P_3);
			if (!xVYllnapIihKZtPcCvQiCCkKaTWz && FSlHLPPornJarrBYtTZNwaDNeTEy[P_1] != 0f)
			{
				xVYllnapIihKZtPcCvQiCCkKaTWz = true;
			}
		}

		private float KziKleVdAtTVXSiVldemCMiJHBDc(HardwareJoystickMap.Platform_InternalDriver_Base.Axis P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= VoWZngliXonIzcwhdgDwbBjKENjE || sourceAxis >= 56)
				{
					return 0f;
				}
				return KziKleVdAtTVXSiVldemCMiJHBDc(sourceAxis);
			}
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= QuzTRGrrwUDmZKKoxoEmRnZQaQrEA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				if (P_0.buttonAxisContribution == Pole.Positive)
				{
					return 1f;
				}
				return -1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= xflwuDqqdyfLyLTsZZPVSflXIYOc || sourceHat >= 4)
				{
					return 0f;
				}
				int num = P_2[sourceHat];
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = ZmMaCMFrDBLDkdiRsvJfMxgBzmUuA(num, AxisDirection.Horizontal);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				else
				{
					num2 = ZmMaCMFrDBLDkdiRsvJfMxgBzmUuA(num, AxisDirection.Vertical);
					if (P_0.sourceHatRange != AxisRange.Full)
					{
						if (P_0.sourceHatRange == AxisRange.Positive)
						{
							if (num2 < 0f)
							{
								return 0f;
							}
						}
						else if (num2 > 0f)
						{
							return 0f;
						}
					}
				}
				if (P_0.invert)
				{
					num2 *= -1f;
				}
				return num2;
			}
			return 0f;
		}

		private float KziKleVdAtTVXSiVldemCMiJHBDc(int P_0)
		{
			return (rENRiuJsaTUuZiPQKEZjwreEyAYl as EkjPPGtMfdCmBOwKmCFAiaihYVqrA).gtExFxcpYcZTABrBeLFEPTMTniaw(P_0);
		}

		private float sbHZNHEZgtblLBVYxGsxpKTdJUDe(HardwareJoystickMap.Platform_InternalDriver_Base.Button P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == 0)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= QuzTRGrrwUDmZKKoxoEmRnZQaQrEA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!P_1[sourceButton])
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= VoWZngliXonIzcwhdgDwbBjKENjE || sourceAxis >= 56)
				{
					return 0f;
				}
				float num = KziKleVdAtTVXSiVldemCMiJHBDc(sourceAxis);
				if (MathTools.Abs(num) <= P_0.axisDeadZone)
				{
					return 0f;
				}
				if (P_0.sourceAxisPole == Pole.Positive)
				{
					if (num < 0f)
					{
						return 0f;
					}
				}
				else if (num > 0f)
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= xflwuDqqdyfLyLTsZZPVSflXIYOc || sourceHat >= 4)
				{
					return 0f;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return OZIZaSWCLFcgxhZTfdeCgEjOAwyGA(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			return 0f;
		}

		private bool gqRJMbfNOJuuFXSAtVdnIRcTLHxi(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			int num = 4500 * P_1;
			if (P_2 == HatType.EightWay && P_0 != num)
			{
				return false;
			}
			int num2;
			int num3;
			if (P_2 == HatType.EightWay)
			{
				num2 = 31500;
				num3 = 4500;
			}
			else
			{
				num2 = 27000;
				num3 = 9000;
			}
			if (P_1 == 0 && P_0 > num2)
			{
				P_0 -= 36000;
			}
			if (P_0 < num + num3 && P_0 > num - num3)
			{
				return true;
			}
			return false;
		}

		private float rrfdcPwrpiFFwAaUxphqmjBHUPrn(int P_0, AxisDirection P_1)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (P_1 == AxisDirection.Vertical)
			{
				if (P_0 > 27000 || P_0 < 9000)
				{
					return 1f;
				}
				if (P_0 < 27000 && P_0 > 9000)
				{
					return -1f;
				}
				return 0f;
			}
			if (P_0 > 0 && P_0 < 18000)
			{
				return 1f;
			}
			if (P_0 > 18000)
			{
				return -1f;
			}
			return 0f;
		}

		private void bKOJiVJxFDkRpxUXrQUwrkhXlNCR()
		{
			hrWFokKRfePnjNhvOPIDFxJfIhDv = TGhMfMpddOgpnflvcRUCHgmAPREiA(rTVVkYwcBzPcSjgQNEJEDKXoKAcdA());
			if (hrWFokKRfePnjNhvOPIDFxJfIhDv == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			YlthzTIXIGbxaxevGySzSFhuWDCG = hrWFokKRfePnjNhvOPIDFxJfIhDv.axisCount;
			DcoIvrxxhbgCbABcrHbjOpmzeOXy = hrWFokKRfePnjNhvOPIDFxJfIhDv.buttonCount;
		}

		private string xBXCjGoFEAXUazpkvpqEVOgasIRK()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.RawInput}{((hzRMSivHdAwVXtgeyFCyPwVEqCvC && !string.IsNullOrEmpty(fnndwwSKqCfOVgTxiofbCSvdZVaFB)) ? fnndwwSKqCfOVgTxiofbCSvdZVaFB : amzBQgIbgHOYPYUlHRjTPwlDSBVT)}{PXSwjWYIheQFLZmFNDKaEapYvqTQA}{CDvRASMfYBfpSfdfDAtTJlxQyhrm}");
		}

		private void AnvVmXkzaGotHQSsrLViRKpQvMhJ(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.RawInput;
			P_0.inputSource = rCJaKsAexMPepwMrQdSYEBasCTuF.GLeftCVYEJwxAWmzwgPFppcqXovF;
			P_0.deviceType = MtllQqYZIEpvITrpcHecLxvuFLde(zAUqhzxUFxqJuedphcqKckrxZrTB);
			P_0.hardwareIdentifier = xBXCjGoFEAXUazpkvpqEVOgasIRK();
			P_0.hardwareAxisCount = VoWZngliXonIzcwhdgDwbBjKENjE;
			P_0.hardwareButtonCount = QuzTRGrrwUDmZKKoxoEmRnZQaQrEA;
			P_0.hardwareHatCount = xflwuDqqdyfLyLTsZZPVSflXIYOc;
			P_0.hw_productName = amzBQgIbgHOYPYUlHRjTPwlDSBVT;
			P_0.hw_deviceGuid = instanceGuid;
			P_0.hw_vendorId = njswgvuMzcLnpKZRHaLNQVEaolpQ;
			P_0.hw_productId = PXSwjWYIheQFLZmFNDKaEapYvqTQA;
			P_0.hw_pidVid = new PidVid(CDvRASMfYBfpSfdfDAtTJlxQyhrm);
			P_0.hw_isBluetoothDevice = hzRMSivHdAwVXtgeyFCyPwVEqCvC;
			P_0.hw_bluetoothDeviceName = fnndwwSKqCfOVgTxiofbCSvdZVaFB;
			P_0.hw_supportsVibration = CxdmZJFkiTFxYWsHLfVdndaLjLIp;
			P_0.hw_localVibrationMotorCount = XGxqJjeMmWaLNdigbGxrFJMAqZbac;
			P_0.definitionMatchTag = rCJaKsAexMPepwMrQdSYEBasCTuF.YVeDrMmVcyEAuKmHhlMorUHinlVfA;
		}

		private void AnvVmXkzaGotHQSsrLViRKpQvMhJ(BridgedController P_0)
		{
			AnvVmXkzaGotHQSsrLViRKpQvMhJ((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = hrWFokKRfePnjNhvOPIDFxJfIhDv.ToGameHardwareControllerMap();
			P_0.instanceName = QamwaQQOPPlBpZemmRFSsepNDSwgA;
			P_0.productName = amzBQgIbgHOYPYUlHRjTPwlDSBVT;
			P_0.isXInputDevice = qkOoPnxESVYPHGjWZGnaEIgYMrWN;
			P_0.axisCount = YlthzTIXIGbxaxevGySzSFhuWDCG;
			P_0.buttonCount = DcoIvrxxhbgCbABcrHbjOpmzeOXy;
			P_0.isButtonPressureSensitive = new bool[DcoIvrxxhbgCbABcrHbjOpmzeOXy];
			Array.Copy(KefcfUpJsbrddeOWVTtdWXzlOygA, P_0.isButtonPressureSensitive, DcoIvrxxhbgCbABcrHbjOpmzeOXy);
			P_0.unknownControllerHats = bPJHMqWQnWlPIziKwsuPVPHIURBs();
			P_0.controllerTypeGuid = dPMadqhvuBRgljDGjUtDIjoGIjQT;
			P_0.controllerExtension = extension;
		}

		private void gxfsLiXcBDuXLDgtPMfdWiweUquG()
		{
			for (int i = 0; i < DcoIvrxxhbgCbABcrHbjOpmzeOXy; i++)
			{
				FSlHLPPornJarrBYtTZNwaDNeTEy[i] = 0f;
			}
			for (int j = 0; j < YlthzTIXIGbxaxevGySzSFhuWDCG; j++)
			{
				lMBOzesBmklbuZRpFYcRpzoxCCSg[j] = 0f;
			}
		}

		private UnknownControllerHat[] bPJHMqWQnWlPIziKwsuPVPHIURBs()
		{
			if (!OHUncRdpKbQtPCKUpXfRpjuMazFGA)
			{
				return null;
			}
			UnknownControllerHat[] array = new UnknownControllerHat[2];
			for (int i = 0; i < 2; i++)
			{
				int num = 128 + i * 8;
				UnknownControllerHat.HatButtons hatButtons = new UnknownControllerHat.HatButtons(new int[8]
				{
					num,
					num + 1,
					num + 2,
					num + 3,
					num + 4,
					num + 5,
					num + 6,
					num + 7
				});
				array[i] = new UnknownControllerHat(hatButtons);
			}
			return array;
		}

		public void hIlanWXkrCYfgvCyascUuCUOCBcL()
		{
			hIlanWXkrCYfgvCyascUuCUOCBcL(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void jRFgxQCVBGrNmzQBGWfdjtLVACefA()
		{
			try
			{
				hIlanWXkrCYfgvCyascUuCUOCBcL(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void hIlanWXkrCYfgvCyascUuCUOCBcL(bool P_0)
		{
			if (!TExNvhkEWsBWipIUjadCDaTpNNDG)
			{
				TExNvhkEWsBWipIUjadCDaTpNNDG = true;
			}
		}

		public static int iBFIxaZTPTDoFJAxRzgRqbCWgxvIA(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0, UebDdpmoIIdJuxGjNGokDpNzqIzJA P_1)
		{
			if (P_0.oIwIqNbDPpBbcpjyUoyJOCjctEwH < P_1.oIwIqNbDPpBbcpjyUoyJOCjctEwH)
			{
				return -1;
			}
			if (P_0.oIwIqNbDPpBbcpjyUoyJOCjctEwH > P_1.oIwIqNbDPpBbcpjyUoyJOCjctEwH)
			{
				return 1;
			}
			return 0;
		}

		public static int sZdSFUquDzBWrPxLWBHhBGFJTjQQ(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0, UebDdpmoIIdJuxGjNGokDpNzqIzJA P_1)
		{
			if (P_0.ImHZXPeiZINzqbSIYeCFsHJmGRICA < P_1.ImHZXPeiZINzqbSIYeCFsHJmGRICA)
			{
				return -1;
			}
			if (P_0.ImHZXPeiZINzqbSIYeCFsHJmGRICA > P_1.ImHZXPeiZINzqbSIYeCFsHJmGRICA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class HYQEEobppRUEfDimovjlHnEnjdQG
	{
		public enum OMtLCsYewZBPCBypjoPXAcwViQfv
		{
			Exact = 0,
			Approximate = 1
		}

		public class VqcIVIMLdLralEMfpfPdmOGpVjrl
		{
			public int sxHAgKaSFAVQVcgbYbUKBppQIIupA;

			public Guid oonUpugAMbqyojmbgCaqkoIrdwQq;

			public Guid sPqIFOmgKdKnaJgxkNEYZxiINXMO;

			public int wCdDUvdBMwJpnsWACRshrMdvxPMIA;

			public int VoWZngliXonIzcwhdgDwbBjKENjE;

			public int QuzTRGrrwUDmZKKoxoEmRnZQaQrEA;

			public int xflwuDqqdyfLyLTsZZPVSflXIYOc;

			public int DcoIvrxxhbgCbABcrHbjOpmzeOXy;

			public int YlthzTIXIGbxaxevGySzSFhuWDCG;

			public bool oVGTkQyMINjfDtilToygxfKlAUDK;

			public bool oTaRposvbRJAiqTPfKKyqhkEgQHG(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0, OMtLCsYewZBPCBypjoPXAcwViQfv P_1)
			{
				if (VoWZngliXonIzcwhdgDwbBjKENjE != P_0.VoWZngliXonIzcwhdgDwbBjKENjE)
				{
					return false;
				}
				if (QuzTRGrrwUDmZKKoxoEmRnZQaQrEA != P_0.QuzTRGrrwUDmZKKoxoEmRnZQaQrEA)
				{
					return false;
				}
				if (xflwuDqqdyfLyLTsZZPVSflXIYOc != P_0.xflwuDqqdyfLyLTsZZPVSflXIYOc)
				{
					return false;
				}
				if (DcoIvrxxhbgCbABcrHbjOpmzeOXy != P_0.DcoIvrxxhbgCbABcrHbjOpmzeOXy)
				{
					return false;
				}
				if (YlthzTIXIGbxaxevGySzSFhuWDCG != P_0.YlthzTIXIGbxaxevGySzSFhuWDCG)
				{
					return false;
				}
				if (oVGTkQyMINjfDtilToygxfKlAUDK != P_0.oVGTkQyMINjfDtilToygxfKlAUDK)
				{
					return false;
				}
				if (P_0.rewiredId == sxHAgKaSFAVQVcgbYbUKBppQIIupA)
				{
					return true;
				}
				return P_1 switch
				{
					OMtLCsYewZBPCBypjoPXAcwViQfv.Exact => oonUpugAMbqyojmbgCaqkoIrdwQq == P_0.instanceGuid, 
					OMtLCsYewZBPCBypjoPXAcwViQfv.Approximate => sPqIFOmgKdKnaJgxkNEYZxiINXMO == P_0.sPqIFOmgKdKnaJgxkNEYZxiINXMO, 
					_ => throw new NotImplementedException(), 
				};
			}

			public virtual string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
			{
				string text = "" + "rewiredId = " + sxHAgKaSFAVQVcgbYbUKBppQIIupA + "\n";
				Guid guid = oonUpugAMbqyojmbgCaqkoIrdwQq;
				string text2 = text + "instanceGuid = " + guid.ToString() + "\n";
				guid = sPqIFOmgKdKnaJgxkNEYZxiINXMO;
				return string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + guid.ToString() + "\n", "lastInputManagerId = ", wCdDUvdBMwJpnsWACRshrMdvxPMIA.ToString(), "\n"), "hardwareAxisCount = ", VoWZngliXonIzcwhdgDwbBjKENjE.ToString(), "\n"), "hardwareButtonCount = ", QuzTRGrrwUDmZKKoxoEmRnZQaQrEA.ToString(), "\n"), "hardwareHatCount = ", xflwuDqqdyfLyLTsZZPVSflXIYOc.ToString(), "\n"), "gameButtonCount = ", DcoIvrxxhbgCbABcrHbjOpmzeOXy.ToString(), "\n"), "gameAxisCount = ", YlthzTIXIGbxaxevGySzSFhuWDCG.ToString(), "\n"), "hasDriver = ", oVGTkQyMINjfDtilToygxfKlAUDK.ToString(), "\n");
			}
		}

		private sealed class AnrMFNwjPsmkSskKkBADLVHySnYn : IEnumerable<VqcIVIMLdLralEMfpfPdmOGpVjrl>, IEnumerator<VqcIVIMLdLralEMfpfPdmOGpVjrl>, IDisposable, IEnumerable, IEnumerator
		{
			private int EfhNxMQfYmTJLognklCDrkwXaGWf;

			private VqcIVIMLdLralEMfpfPdmOGpVjrl EpvudvQLjALpvxcGTxFmzIIuSmBl;

			private int dTodMGxxFGGHcIzPNCocjhsvfqrrA;

			public HYQEEobppRUEfDimovjlHnEnjdQG CkJlODENHLjHOpVTJtFbwVYqcuvm;

			private UebDdpmoIIdJuxGjNGokDpNzqIzJA ivJaMYeMqcQocPjMdvikWExoKsgEb;

			public UebDdpmoIIdJuxGjNGokDpNzqIzJA AqFFbXhuorlOzBxjSWWECJOsZhlu;

			private OMtLCsYewZBPCBypjoPXAcwViQfv ZQGMhHqnKodXtYcLvIkDsosBkMcn;

			public OMtLCsYewZBPCBypjoPXAcwViQfv nUZUNmGcnHRYNOlrxaWkyeDhxeUE;

			private int JwJoTDiQqltrIxvpywMPIJrBmwxc;

			private int uTpVkEzpFJBtklHHHtYPJmRhkRpI;

			VqcIVIMLdLralEMfpfPdmOGpVjrl IEnumerator<VqcIVIMLdLralEMfpfPdmOGpVjrl>.Current
			{
				[DebuggerHidden]
				get
				{
					return EpvudvQLjALpvxcGTxFmzIIuSmBl;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EpvudvQLjALpvxcGTxFmzIIuSmBl;
				}
			}

			[DebuggerHidden]
			public AnrMFNwjPsmkSskKkBADLVHySnYn(int P_0)
			{
				EfhNxMQfYmTJLognklCDrkwXaGWf = P_0;
				dTodMGxxFGGHcIzPNCocjhsvfqrrA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int efhNxMQfYmTJLognklCDrkwXaGWf = EfhNxMQfYmTJLognklCDrkwXaGWf;
				HYQEEobppRUEfDimovjlHnEnjdQG ckJlODENHLjHOpVTJtFbwVYqcuvm = CkJlODENHLjHOpVTJtFbwVYqcuvm;
				if (efhNxMQfYmTJLognklCDrkwXaGWf != 0)
				{
					if (efhNxMQfYmTJLognklCDrkwXaGWf != 1)
					{
						return false;
					}
					EfhNxMQfYmTJLognklCDrkwXaGWf = -1;
					goto IL_0083;
				}
				EfhNxMQfYmTJLognklCDrkwXaGWf = -1;
				JwJoTDiQqltrIxvpywMPIJrBmwxc = ckJlODENHLjHOpVTJtFbwVYqcuvm.TLhELvHYSwEeYQEneYzAwjQcfGke.Count;
				uTpVkEzpFJBtklHHHtYPJmRhkRpI = 0;
				goto IL_0093;
				IL_0083:
				uTpVkEzpFJBtklHHHtYPJmRhkRpI++;
				goto IL_0093;
				IL_0093:
				if (uTpVkEzpFJBtklHHHtYPJmRhkRpI < JwJoTDiQqltrIxvpywMPIJrBmwxc)
				{
					if (ckJlODENHLjHOpVTJtFbwVYqcuvm.TLhELvHYSwEeYQEneYzAwjQcfGke[uTpVkEzpFJBtklHHHtYPJmRhkRpI].oTaRposvbRJAiqTPfKKyqhkEgQHG(ivJaMYeMqcQocPjMdvikWExoKsgEb, ZQGMhHqnKodXtYcLvIkDsosBkMcn))
					{
						EpvudvQLjALpvxcGTxFmzIIuSmBl = ckJlODENHLjHOpVTJtFbwVYqcuvm.TLhELvHYSwEeYQEneYzAwjQcfGke[uTpVkEzpFJBtklHHHtYPJmRhkRpI];
						EfhNxMQfYmTJLognklCDrkwXaGWf = 1;
						return true;
					}
					goto IL_0083;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<VqcIVIMLdLralEMfpfPdmOGpVjrl> IEnumerable<VqcIVIMLdLralEMfpfPdmOGpVjrl>.GetEnumerator()
			{
				AnrMFNwjPsmkSskKkBADLVHySnYn anrMFNwjPsmkSskKkBADLVHySnYn;
				if (EfhNxMQfYmTJLognklCDrkwXaGWf == -2 && dTodMGxxFGGHcIzPNCocjhsvfqrrA == Thread.CurrentThread.ManagedThreadId)
				{
					EfhNxMQfYmTJLognklCDrkwXaGWf = 0;
					anrMFNwjPsmkSskKkBADLVHySnYn = this;
				}
				else
				{
					anrMFNwjPsmkSskKkBADLVHySnYn = new AnrMFNwjPsmkSskKkBADLVHySnYn(0);
					anrMFNwjPsmkSskKkBADLVHySnYn.CkJlODENHLjHOpVTJtFbwVYqcuvm = CkJlODENHLjHOpVTJtFbwVYqcuvm;
				}
				anrMFNwjPsmkSskKkBADLVHySnYn.ivJaMYeMqcQocPjMdvikWExoKsgEb = AqFFbXhuorlOzBxjSWWECJOsZhlu;
				anrMFNwjPsmkSskKkBADLVHySnYn.ZQGMhHqnKodXtYcLvIkDsosBkMcn = nUZUNmGcnHRYNOlrxaWkyeDhxeUE;
				return anrMFNwjPsmkSskKkBADLVHySnYn;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<VqcIVIMLdLralEMfpfPdmOGpVjrl>)this).GetEnumerator();
			}
		}

		private List<VqcIVIMLdLralEMfpfPdmOGpVjrl> TLhELvHYSwEeYQEneYzAwjQcfGke;

		public HYQEEobppRUEfDimovjlHnEnjdQG()
		{
			TLhELvHYSwEeYQEneYzAwjQcfGke = new List<VqcIVIMLdLralEMfpfPdmOGpVjrl>();
		}

		public void DLhrLvkEIWtKcvePDdiqesFMQOXrA(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = TLhELvHYSwEeYQEneYzAwjQcfGke.Count;
			for (int i = 0; i < count; i++)
			{
				if (TLhELvHYSwEeYQEneYzAwjQcfGke[i].oTaRposvbRJAiqTPfKKyqhkEgQHG(P_0, OMtLCsYewZBPCBypjoPXAcwViQfv.Exact))
				{
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].sxHAgKaSFAVQVcgbYbUKBppQIIupA = P_0.rewiredId;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].oonUpugAMbqyojmbgCaqkoIrdwQq = P_0.instanceGuid;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].sPqIFOmgKdKnaJgxkNEYZxiINXMO = P_0.sPqIFOmgKdKnaJgxkNEYZxiINXMO;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].wCdDUvdBMwJpnsWACRshrMdvxPMIA = P_0.inputManagerId;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].VoWZngliXonIzcwhdgDwbBjKENjE = P_0.VoWZngliXonIzcwhdgDwbBjKENjE;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].QuzTRGrrwUDmZKKoxoEmRnZQaQrEA = P_0.QuzTRGrrwUDmZKKoxoEmRnZQaQrEA;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].xflwuDqqdyfLyLTsZZPVSflXIYOc = P_0.xflwuDqqdyfLyLTsZZPVSflXIYOc;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].DcoIvrxxhbgCbABcrHbjOpmzeOXy = P_0.DcoIvrxxhbgCbABcrHbjOpmzeOXy;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].YlthzTIXIGbxaxevGySzSFhuWDCG = P_0.YlthzTIXIGbxaxevGySzSFhuWDCG;
					TLhELvHYSwEeYQEneYzAwjQcfGke[i].oVGTkQyMINjfDtilToygxfKlAUDK = P_0.oVGTkQyMINjfDtilToygxfKlAUDK;
					nslIMGYCZltVtjlyEFaTyPZqIozo(P_0.rewiredId, P_0.instanceGuid, i);
					return;
				}
			}
			TLhELvHYSwEeYQEneYzAwjQcfGke.Add(new VqcIVIMLdLralEMfpfPdmOGpVjrl
			{
				sxHAgKaSFAVQVcgbYbUKBppQIIupA = P_0.rewiredId,
				oonUpugAMbqyojmbgCaqkoIrdwQq = P_0.instanceGuid,
				sPqIFOmgKdKnaJgxkNEYZxiINXMO = P_0.sPqIFOmgKdKnaJgxkNEYZxiINXMO,
				wCdDUvdBMwJpnsWACRshrMdvxPMIA = P_0.inputManagerId,
				VoWZngliXonIzcwhdgDwbBjKENjE = P_0.VoWZngliXonIzcwhdgDwbBjKENjE,
				QuzTRGrrwUDmZKKoxoEmRnZQaQrEA = P_0.QuzTRGrrwUDmZKKoxoEmRnZQaQrEA,
				xflwuDqqdyfLyLTsZZPVSflXIYOc = P_0.xflwuDqqdyfLyLTsZZPVSflXIYOc,
				DcoIvrxxhbgCbABcrHbjOpmzeOXy = P_0.DcoIvrxxhbgCbABcrHbjOpmzeOXy,
				YlthzTIXIGbxaxevGySzSFhuWDCG = P_0.YlthzTIXIGbxaxevGySzSFhuWDCG,
				oVGTkQyMINjfDtilToygxfKlAUDK = P_0.oVGTkQyMINjfDtilToygxfKlAUDK
			});
			nslIMGYCZltVtjlyEFaTyPZqIozo(P_0.rewiredId, P_0.instanceGuid, TLhELvHYSwEeYQEneYzAwjQcfGke.Count - 1);
		}

		public bool ghyGlwPuMUWtZfXZdoPpZMgHrCIp(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0, OMtLCsYewZBPCBypjoPXAcwViQfv P_1)
		{
			int count = TLhELvHYSwEeYQEneYzAwjQcfGke.Count;
			for (int i = 0; i < count; i++)
			{
				if (TLhELvHYSwEeYQEneYzAwjQcfGke[i].oTaRposvbRJAiqTPfKKyqhkEgQHG(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<VqcIVIMLdLralEMfpfPdmOGpVjrl> YwnqMsLuexCuVQYJMDRsVovDUWJR(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0, OMtLCsYewZBPCBypjoPXAcwViQfv P_1)
		{
			return new AnrMFNwjPsmkSskKkBADLVHySnYn(-2)
			{
				CkJlODENHLjHOpVTJtFbwVYqcuvm = this,
				AqFFbXhuorlOzBxjSWWECJOsZhlu = P_0,
				nUZUNmGcnHRYNOlrxaWkyeDhxeUE = P_1
			};
		}

		private void nslIMGYCZltVtjlyEFaTyPZqIozo(int P_0, Guid P_1, int P_2)
		{
			for (int num = TLhELvHYSwEeYQEneYzAwjQcfGke.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (TLhELvHYSwEeYQEneYzAwjQcfGke[num].sxHAgKaSFAVQVcgbYbUKBppQIIupA == P_0 || TLhELvHYSwEeYQEneYzAwjQcfGke[num].oonUpugAMbqyojmbgCaqkoIrdwQq == P_1))
				{
					TLhELvHYSwEeYQEneYzAwjQcfGke.RemoveAt(num);
				}
			}
		}

		public virtual string OJhLXNAKHQXunRxPQYyRrpGAUSuG()
		{
			string text = "";
			text = text + "Joystick records: " + TLhELvHYSwEeYQEneYzAwjQcfGke.Count + "\n";
			for (int i = 0; i < TLhELvHYSwEeYQEneYzAwjQcfGke.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + TLhELvHYSwEeYQEneYzAwjQcfGke[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private tVBWyZGsKPKvJuuMOPZiWmVEjMGK EXdAjdeIMCUCpAYTcjQKiDTfoUGY;

	private List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> uWSosEgJsgkpMAKKcDIgNPSXcUjN;

	private int DaRokZmTHTwcuZQGCefQZJgGqUaI;

	private HYQEEobppRUEfDimovjlHnEnjdQG pqVSpnpkpclTkJJcwLvoEFMRPYyp;

	private bool IcLNLRdCpTkoJewhoTNocaGsClnC;

	private TimerRealTime hGMiCfiVnsFbjNfzGWzPfIsunlMT;

	private rYcHdEeFHXdSOaPSvrmsYhfAgjun<bool> vSOshtJKkweEuYRmOAEBzwBHwgXF;

	private rYcHdEeFHXdSOaPSvrmsYhfAgjun<bool> ENyIOUKJlvWrpqqmOrdSzhznfOFI;

	private int LfQSCuogmscXTtPwpDcyAtRkgBmCb;

	private int kDLuuXocHmellknSGqLkFDHJXOakB;

	private ConfigVars cSZWuCPKlZpDsvKmbAnhrsZuzTnG;

	private bool WifAwnCJgySrsTplaidDmeutdShHA;

	private Action<int, ControllerDataUpdater> gIbTlsSrKDMpanbmCiYbwdiijXPD;

	private PlatformInputManager ewPuxDjadzNAGkyZuovLGXCJpSMn;

	private readonly nsyNNyWiKYljSllZmkTxRmqdSYbK omIdkDZBsoIjBXDalBSxCPDoovUi;

	private readonly BUhxiJjtuziclXjgrUdbrlURGoUW nppNiMaPnuedDOyGKnjiYvAFGcRn;

	private readonly bool FRZtBEZhJvvSCuItwxYyhFIWliTe;

	private readonly bool bCZaGudiPkublTQoYClKpSuIwxYG;

	private readonly bool EFkAaWgoIBLgqGMlxpKgpBzwhbHc;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> TGhMfMpddOgpnflvcRUCHgmAPREiA;

	private readonly Func<int> CGMcJfJcoaSZisGLhxSsARZLqayx;

	bool InpDmQfQABlCOUIizbBrrTlTjrHt.HTaEKrIPWfGKUsacwDGpMoKoMjfC
	{
		set
		{
			WifAwnCJgySrsTplaidDmeutdShHA = wifAwnCJgySrsTplaidDmeutdShHA;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => DaRokZmTHTwcuZQGCefQZJgGqUaI;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => ewPuxDjadzNAGkyZuovLGXCJpSMn;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => EXdAjdeIMCUCpAYTcjQKiDTfoUGY;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.RawInput;

	public ncVapRIcLeMmeuUJBqPqimIyTuLw(ConfigVars P_0, bool P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3, bool P_4, bool P_5, bool P_6, bool P_7)
	{
		try
		{
			cSZWuCPKlZpDsvKmbAnhrsZuzTnG = P_0;
			WifAwnCJgySrsTplaidDmeutdShHA = P_1;
			TGhMfMpddOgpnflvcRUCHgmAPREiA = P_2;
			CGMcJfJcoaSZisGLhxSsARZLqayx = P_3;
			FRZtBEZhJvvSCuItwxYyhFIWliTe = P_4;
			bCZaGudiPkublTQoYClKpSuIwxYG = P_5;
			EFkAaWgoIBLgqGMlxpKgpBzwhbHc = P_6;
			ewPuxDjadzNAGkyZuovLGXCJpSMn = this;
			UpdateLoopSetting updateLoop = P_0.updateLoop;
			if (P_6)
			{
				nppNiMaPnuedDOyGKnjiYvAFGcRn = new BUhxiJjtuziclXjgrUdbrlURGoUW(updateLoop);
			}
			if (P_5)
			{
				omIdkDZBsoIjBXDalBSxCPDoovUi = new nsyNNyWiKYljSllZmkTxRmqdSYbK(updateLoop);
			}
			EXdAjdeIMCUCpAYTcjQKiDTfoUGY = new tVBWyZGsKPKvJuuMOPZiWmVEjMGK(P_0, P_4, P_7, omIdkDZBsoIjBXDalBSxCPDoovUi, nppNiMaPnuedDOyGKnjiYvAFGcRn);
			gIbTlsSrKDMpanbmCiYbwdiijXPD = UpdateControllerData;
			vSOshtJKkweEuYRmOAEBzwBHwgXF = new rYcHdEeFHXdSOaPSvrmsYhfAgjun<bool>(true, lQiaYbPTcgQgpebxRjSGmqirYUAI);
			ENyIOUKJlvWrpqqmOrdSzhznfOFI = new rYcHdEeFHXdSOaPSvrmsYhfAgjun<bool>(true, EXdAjdeIMCUCpAYTcjQKiDTfoUGY.eWyawcueqKVpCrzvtgrvuspzFDoF);
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
		if (FRZtBEZhJvvSCuItwxYyhFIWliTe)
		{
			pqVSpnpkpclTkJJcwLvoEFMRPYyp = new HYQEEobppRUEfDimovjlHnEnjdQG();
			hGMiCfiVnsFbjNfzGWzPfIsunlMT = new TimerRealTime(1.0);
			hGMiCfiVnsFbjNfzGWzPfIsunlMT.Start();
			onXhEpRHNporuBJqKYvniXRZcrkg();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (FRZtBEZhJvvSCuItwxYyhFIWliTe)
		{
			aMwIXHXWJIFOajxmzwgKhqpkRtGq();
		}
		if (EXdAjdeIMCUCpAYTcjQKiDTfoUGY != null)
		{
			EXdAjdeIMCUCpAYTcjQKiDTfoUGY.Update();
		}
		RaHPaAjACtbxsdKiQCapydqspxGGb();
		if (FRZtBEZhJvvSCuItwxYyhFIWliTe)
		{
			if (EXdAjdeIMCUCpAYTcjQKiDTfoUGY != null)
			{
				EXdAjdeIMCUCpAYTcjQKiDTfoUGY.UpdateDevices(updateLoop);
			}
			HCqgEaiISGPKSuXeXdldwsbzGohuA();
			if (EXdAjdeIMCUCpAYTcjQKiDTfoUGY != null)
			{
				EXdAjdeIMCUCpAYTcjQKiDTfoUGY.UpdateFinished();
			}
		}
		if (bCZaGudiPkublTQoYClKpSuIwxYG)
		{
			omIdkDZBsoIjBXDalBSxCPDoovUi.cmTGFsRmXJEFbLoGhVUXbOoqUnNg(updateLoop);
		}
		if (EFkAaWgoIBLgqGMlxpKgpBzwhbHc)
		{
			nppNiMaPnuedDOyGKnjiYvAFGcRn.cmTGFsRmXJEFbLoGhVUXbOoqUnNg(updateLoop);
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (ENyIOUKJlvWrpqqmOrdSzhznfOFI != null)
		{
			ENyIOUKJlvWrpqqmOrdSzhznfOFI.hIlanWXkrCYfgvCyascUuCUOCBcL();
		}
		if (vSOshtJKkweEuYRmOAEBzwBHwgXF != null)
		{
			vSOshtJKkweEuYRmOAEBzwBHwgXF.hIlanWXkrCYfgvCyascUuCUOCBcL();
		}
		if (uWSosEgJsgkpMAKKcDIgNPSXcUjN != null)
		{
			int count = uWSosEgJsgkpMAKKcDIgNPSXcUjN.Count;
			for (int i = 0; i < count; i++)
			{
				if (uWSosEgJsgkpMAKKcDIgNPSXcUjN[i] != null)
				{
					uWSosEgJsgkpMAKKcDIgNPSXcUjN[i].hIlanWXkrCYfgvCyascUuCUOCBcL();
				}
			}
		}
		if (nppNiMaPnuedDOyGKnjiYvAFGcRn != null)
		{
			nppNiMaPnuedDOyGKnjiYvAFGcRn.Dispose();
		}
		if (omIdkDZBsoIjBXDalBSxCPDoovUi != null)
		{
			omIdkDZBsoIjBXDalBSxCPDoovUi.Dispose();
		}
		if (EXdAjdeIMCUCpAYTcjQKiDTfoUGY != null)
		{
			EXdAjdeIMCUCpAYTcjQKiDTfoUGY.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return gIbTlsSrKDMpanbmCiYbwdiijXPD;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		if (!FRZtBEZhJvvSCuItwxYyhFIWliTe)
		{
			return;
		}
		for (int i = 0; i < DaRokZmTHTwcuZQGCefQZJgGqUaI; i++)
		{
			if (uWSosEgJsgkpMAKKcDIgNPSXcUjN[i].inputManagerId == inputManagerId)
			{
				uWSosEgJsgkpMAKKcDIgNPSXcUjN[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		EXdAjdeIMCUCpAYTcjQKiDTfoUGY.SystemDeviceConnected();
		IcLNLRdCpTkoJewhoTNocaGsClnC = true;
		if (FRZtBEZhJvvSCuItwxYyhFIWliTe)
		{
			hGMiCfiVnsFbjNfzGWzPfIsunlMT.Start();
		}
		if (EFkAaWgoIBLgqGMlxpKgpBzwhbHc)
		{
			nppNiMaPnuedDOyGKnjiYvAFGcRn.oKZjJsUfdokwGiyKjHVaqyvEQkZs(true);
		}
		if (bCZaGudiPkublTQoYClKpSuIwxYG)
		{
			omIdkDZBsoIjBXDalBSxCPDoovUi.oKZjJsUfdokwGiyKjHVaqyvEQkZs(true);
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		EXdAjdeIMCUCpAYTcjQKiDTfoUGY.SystemDeviceDisconnected();
		IcLNLRdCpTkoJewhoTNocaGsClnC = true;
		if (FRZtBEZhJvvSCuItwxYyhFIWliTe)
		{
			hGMiCfiVnsFbjNfzGWzPfIsunlMT.Start();
		}
		if (EFkAaWgoIBLgqGMlxpKgpBzwhbHc)
		{
			nppNiMaPnuedDOyGKnjiYvAFGcRn.oKZjJsUfdokwGiyKjHVaqyvEQkZs(false);
		}
		if (bCZaGudiPkublTQoYClKpSuIwxYG)
		{
			omIdkDZBsoIjBXDalBSxCPDoovUi.oKZjJsUfdokwGiyKjHVaqyvEQkZs(false);
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = FRZtBEZhJvvSCuItwxYyhFIWliTe;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedMouseSource GetUnifiedMouseSource()
	{
		return omIdkDZBsoIjBXDalBSxCPDoovUi;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return nppNiMaPnuedDOyGKnjiYvAFGcRn;
	}

	public void hOkJQtYQxqLKALRbEqWBOBDxccbL(cQgVBZlYElNaPNVdQLmdvIVQeESs P_0, dyVeoCAoUcjBhEJcuxZySrWcjyQeA P_1)
	{
	}

	private void aMwIXHXWJIFOajxmzwgKhqpkRtGq()
	{
		if (vSOshtJKkweEuYRmOAEBzwBHwgXF.FjVRScdpFKyLClYRKhdeqgbPmktV)
		{
			if (vSOshtJKkweEuYRmOAEBzwBHwgXF.FAEdLIDaqiJrNwIazMvgidHfLWFNA() && !hGMiCfiVnsFbjNfzGWzPfIsunlMT.running && !ENyIOUKJlvWrpqqmOrdSzhznfOFI.FjVRScdpFKyLClYRKhdeqgbPmktV)
			{
				if (vSOshtJKkweEuYRmOAEBzwBHwgXF.sXGDgYySYSTzdUeJrjzbYAsUFvMdA)
				{
					IcLNLRdCpTkoJewhoTNocaGsClnC = true;
				}
				hGMiCfiVnsFbjNfzGWzPfIsunlMT.Start();
			}
		}
		else if (!hGMiCfiVnsFbjNfzGWzPfIsunlMT.running)
		{
			hGMiCfiVnsFbjNfzGWzPfIsunlMT.Start();
		}
		else if (hGMiCfiVnsFbjNfzGWzPfIsunlMT.Update())
		{
			vSOshtJKkweEuYRmOAEBzwBHwgXF.mPdlIFqjoxqpXUXmLokOkbcVfbGkA();
		}
	}

	private void onXhEpRHNporuBJqKYvniXRZcrkg()
	{
		onXhEpRHNporuBJqKYvniXRZcrkg(fDFEZeYKsGHCphPTALGmjdlCIiOJA());
	}

	private void onXhEpRHNporuBJqKYvniXRZcrkg(IList<asRdKzmHUeOfEtnumeRYNLFtgVpi> P_0)
	{
		int num = 0;
		List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> list = uWSosEgJsgkpMAKKcDIgNPSXcUjN;
		int daRokZmTHTwcuZQGCefQZJgGqUaI = DaRokZmTHTwcuZQGCefQZJgGqUaI;
		uWSosEgJsgkpMAKKcDIgNPSXcUjN = new List<UebDdpmoIIdJuxGjNGokDpNzqIzJA>();
		LfQSCuogmscXTtPwpDcyAtRkgBmCb = 0;
		List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> list2 = new List<UebDdpmoIIdJuxGjNGokDpNzqIzJA>();
		for (int num2 = daRokZmTHTwcuZQGCefQZJgGqUaI - 1; num2 >= 0; num2--)
		{
			if (list[num2] != null && !list[num2].RWcjmtEWOihCnICrbgbyOHewqpcW)
			{
				list2.Add(list[num2]);
				list.RemoveAt(num2);
			}
		}
		daRokZmTHTwcuZQGCefQZJgGqUaI = list?.Count ?? 0;
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] == null)
			{
				continue;
			}
			asRdKzmHUeOfEtnumeRYNLFtgVpi asRdKzmHUeOfEtnumeRYNLFtgVpi2 = P_0[i];
			if (asRdKzmHUeOfEtnumeRYNLFtgVpi2 != null)
			{
				UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA = new UebDdpmoIIdJuxGjNGokDpNzqIzJA(asRdKzmHUeOfEtnumeRYNLFtgVpi2, asRdKzmHUeOfEtnumeRYNLFtgVpi2.IahAEyAbGcjkThbPHvPGbvOCgtjYD, TGhMfMpddOgpnflvcRUCHgmAPREiA);
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.MLvLlmCarLCofsbmoqbKmtCymXhQ = asRdKzmHUeOfEtnumeRYNLFtgVpi2.UTgEnYwMzKwvhFVWmadoqnWiKGQb;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.QamwaQQOPPlBpZemmRFSsepNDSwgA = asRdKzmHUeOfEtnumeRYNLFtgVpi2.ohZDoCmVQxaTHsROXZdsVHeLPMzH;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.amzBQgIbgHOYPYUlHRjTPwlDSBVT = asRdKzmHUeOfEtnumeRYNLFtgVpi2.ohZDoCmVQxaTHsROXZdsVHeLPMzH;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.CDvRASMfYBfpSfdfDAtTJlxQyhrm = asRdKzmHUeOfEtnumeRYNLFtgVpi2.NYYrpoJmrmXNddXgbOtXNRapBPrR;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.PXSwjWYIheQFLZmFNDKaEapYvqTQA = asRdKzmHUeOfEtnumeRYNLFtgVpi2.tFEBVepOaIieiWoMKdBqOityhAYt;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.njswgvuMzcLnpKZRHaLNQVEaolpQ = asRdKzmHUeOfEtnumeRYNLFtgVpi2.lYkgFObpJbehzEgFocikXKvHajvX;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.ImHZXPeiZINzqbSIYeCFsHJmGRICA = asRdKzmHUeOfEtnumeRYNLFtgVpi2.RxKZVbiBiCgGxALXdDdboWTCwhnp;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.VoWZngliXonIzcwhdgDwbBjKENjE = asRdKzmHUeOfEtnumeRYNLFtgVpi2.QvqKvOEgWZFuaadBGEQbfeQgKqAic;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.QuzTRGrrwUDmZKKoxoEmRnZQaQrEA = asRdKzmHUeOfEtnumeRYNLFtgVpi2.RgbfDDRzjDqkoFkQgCKPVHBbPkbi;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.xflwuDqqdyfLyLTsZZPVSflXIYOc = asRdKzmHUeOfEtnumeRYNLFtgVpi2.jxpPyoeDgFhsnWYCemYCOPmWcJgn;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.qkOoPnxESVYPHGjWZGnaEIgYMrWN = false;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.hzRMSivHdAwVXtgeyFCyPwVEqCvC = asRdKzmHUeOfEtnumeRYNLFtgVpi2.MECbKJLKFUIoOBQeEkOXNtXmlPEC;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.fnndwwSKqCfOVgTxiofbCSvdZVaFB = asRdKzmHUeOfEtnumeRYNLFtgVpi2.sIXmVbVDtaBkdtQMVHYeWQdqUKYs;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.CxdmZJFkiTFxYWsHLfVdndaLjLIp = asRdKzmHUeOfEtnumeRYNLFtgVpi2.QilSUmixlaUGNRNSEsvWYvPjcmbG;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.XGxqJjeMmWaLNdigbGxrFJMAqZbac = asRdKzmHUeOfEtnumeRYNLFtgVpi2.iapBjjvBavFHeVEVkzzIPejErAeD;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.extension = asRdKzmHUeOfEtnumeRYNLFtgVpi2.MJbtjRjPGtkAuNCZKTPsyaWDEilhA;
				asRdKzmHUeOfEtnumeRYNLFtgVpi2.Acquire();
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.GshLMkEsaZGvRxOGtfzVMnkiYxqS();
				uWSosEgJsgkpMAKKcDIgNPSXcUjN.Add(uebDdpmoIIdJuxGjNGokDpNzqIzJA);
				num++;
				if (uebDdpmoIIdJuxGjNGokDpNzqIzJA.hzRMSivHdAwVXtgeyFCyPwVEqCvC)
				{
					LfQSCuogmscXTtPwpDcyAtRkgBmCb++;
				}
			}
		}
		DaRokZmTHTwcuZQGCefQZJgGqUaI = num;
		gNGSpbPyUVucdhvKmHvpGqQNtfAL(daRokZmTHTwcuZQGCefQZJgGqUaI, num, list, uWSosEgJsgkpMAKKcDIgNPSXcUjN);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(uWSosEgJsgkpMAKKcDIgNPSXcUjN[j]));
			}
		}
		list2.ForEach(delegate(UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA2)
		{
			RlrkdWyAazsPUoHZdgVMpdPwxjfg(uebDdpmoIIdJuxGjNGokDpNzqIzJA2, false);
		});
		thXFtgwjSpgmTGLiQtJBCJJLqGtz(list, uWSosEgJsgkpMAKKcDIgNPSXcUjN, false);
		thXFtgwjSpgmTGLiQtJBCJJLqGtz(uWSosEgJsgkpMAKKcDIgNPSXcUjN, list, true);
	}

	private void HCqgEaiISGPKSuXeXdldwsbzGohuA()
	{
		for (int i = 0; i < DaRokZmTHTwcuZQGCefQZJgGqUaI; i++)
		{
			UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA = uWSosEgJsgkpMAKKcDIgNPSXcUjN[i];
			if (uebDdpmoIIdJuxGjNGokDpNzqIzJA != null && (!WifAwnCJgySrsTplaidDmeutdShHA || !uebDdpmoIIdJuxGjNGokDpNzqIzJA.qkOoPnxESVYPHGjWZGnaEIgYMrWN))
			{
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.Update();
			}
		}
	}

	private bool gCznTdlEBBXAZUFXCyMUomxAIPBL(SRnIhfrvHWbNuOCVvgmuRJUUNhml P_0)
	{
		try
		{
			return P_0.IsAttached();
		}
		catch
		{
			return false;
		}
	}

	private IList<asRdKzmHUeOfEtnumeRYNLFtgVpi> fDFEZeYKsGHCphPTALGmjdlCIiOJA()
	{
		return EXdAjdeIMCUCpAYTcjQKiDTfoUGY.GetJoysticks<asRdKzmHUeOfEtnumeRYNLFtgVpi>();
	}

	private void gNGSpbPyUVucdhvKmHvpGqQNtfAL(int P_0, int P_1, List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_2, List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(UebDdpmoIIdJuxGjNGokDpNzqIzJA.sZdSFUquDzBWrPxLWBHhBGFJTjQQ);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			mjKLbsuXxNUQTKiNjhlFkblDhkqtA(P_1, P_3, P_0, P_2, HYQEEobppRUEfDimovjlHnEnjdQG.OMtLCsYewZBPCBypjoPXAcwViQfv.Exact);
		}
		ydGJhBOIAkWfCeoxUigVVlrApkxH(P_1, P_3, HYQEEobppRUEfDimovjlHnEnjdQG.OMtLCsYewZBPCBypjoPXAcwViQfv.Exact);
		for (int i = 0; i < P_1; i++)
		{
			UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA = P_3[i];
			if (uebDdpmoIIdJuxGjNGokDpNzqIzJA != null && uebDdpmoIIdJuxGjNGokDpNzqIzJA.inputManagerId < 0)
			{
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.inputManagerId = NEwGExLgAgWXGnbimuXuZqEmCSMt(P_3);
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.rewiredId = CGMcJfJcoaSZisGLhxSsARZLqayx();
				pqVSpnpkpclTkJJcwLvoEFMRPYyp.DLhrLvkEIWtKcvePDdiqesFMQOXrA(uebDdpmoIIdJuxGjNGokDpNzqIzJA);
			}
		}
		P_3.Sort(UebDdpmoIIdJuxGjNGokDpNzqIzJA.iBFIxaZTPTDoFJAxRzgRqbCWgxvIA);
	}

	private void FNfccIkqyKyjzVgDGbuRBptahEIMA(List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_0, int P_1, int P_2)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (i != P_1 && P_0[i] != null && P_0[i].inputManagerId == P_2)
			{
				P_0[i].inputManagerId = -1;
			}
		}
	}

	private bool ZTMXFqOdyKtNRlsRtSCgqobnUAKU(List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_0, int P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].inputManagerId == P_1)
			{
				return false;
			}
		}
		return true;
	}

	private int NEwGExLgAgWXGnbimuXuZqEmCSMt(List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_0)
	{
		int num = 0;
		while (true)
		{
			bool flag = false;
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && P_0[i].inputManagerId == num)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				break;
			}
			num++;
		}
		return num;
	}

	private bool RqBirYPrsxbrGVfkkMBwiasffHho(List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_0, int P_1)
	{
		if (P_0 == null)
		{
			return false;
		}
		for (int i = 0; i < P_0.Count; i++)
		{
			if (P_0[i].rewiredId == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void mjKLbsuXxNUQTKiNjhlFkblDhkqtA(int P_0, List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_1, int P_2, List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_3, HYQEEobppRUEfDimovjlHnEnjdQG.OMtLCsYewZBPCBypjoPXAcwViQfv P_4)
	{
		int num = ((P_4 != HYQEEobppRUEfDimovjlHnEnjdQG.OMtLCsYewZBPCBypjoPXAcwViQfv.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA = P_1[i];
			if (uebDdpmoIIdJuxGjNGokDpNzqIzJA == null || uebDdpmoIIdJuxGjNGokDpNzqIzJA.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA2 = P_3[j];
				if (uebDdpmoIIdJuxGjNGokDpNzqIzJA2 != null && !RqBirYPrsxbrGVfkkMBwiasffHho(P_1, uebDdpmoIIdJuxGjNGokDpNzqIzJA2.rewiredId) && uebDdpmoIIdJuxGjNGokDpNzqIzJA.oTaRposvbRJAiqTPfKKyqhkEgQHG(uebDdpmoIIdJuxGjNGokDpNzqIzJA2) >= num)
				{
					uebDdpmoIIdJuxGjNGokDpNzqIzJA.QWPcQcByrISmXcCAXpmwAVqOfKnab(uebDdpmoIIdJuxGjNGokDpNzqIzJA2);
					pqVSpnpkpclTkJJcwLvoEFMRPYyp.DLhrLvkEIWtKcvePDdiqesFMQOXrA(uebDdpmoIIdJuxGjNGokDpNzqIzJA);
				}
			}
		}
	}

	private void ydGJhBOIAkWfCeoxUigVVlrApkxH(int P_0, List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_1, HYQEEobppRUEfDimovjlHnEnjdQG.OMtLCsYewZBPCBypjoPXAcwViQfv P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA = P_1[i];
			if (uebDdpmoIIdJuxGjNGokDpNzqIzJA == null || uebDdpmoIIdJuxGjNGokDpNzqIzJA.inputManagerId >= 0)
			{
				continue;
			}
			HYQEEobppRUEfDimovjlHnEnjdQG.VqcIVIMLdLralEMfpfPdmOGpVjrl vqcIVIMLdLralEMfpfPdmOGpVjrl = null;
			foreach (HYQEEobppRUEfDimovjlHnEnjdQG.VqcIVIMLdLralEMfpfPdmOGpVjrl item in pqVSpnpkpclTkJJcwLvoEFMRPYyp.YwnqMsLuexCuVQYJMDRsVovDUWJR(uebDdpmoIIdJuxGjNGokDpNzqIzJA, P_2))
			{
				if (!RqBirYPrsxbrGVfkkMBwiasffHho(P_1, item.sxHAgKaSFAVQVcgbYbUKBppQIIupA) && item.wCdDUvdBMwJpnsWACRshrMdvxPMIA >= 0)
				{
					vqcIVIMLdLralEMfpfPdmOGpVjrl = item;
					break;
				}
			}
			if (vqcIVIMLdLralEMfpfPdmOGpVjrl != null)
			{
				int num = vqcIVIMLdLralEMfpfPdmOGpVjrl.wCdDUvdBMwJpnsWACRshrMdvxPMIA;
				if (!ZTMXFqOdyKtNRlsRtSCgqobnUAKU(P_1, num))
				{
					num = (vqcIVIMLdLralEMfpfPdmOGpVjrl.wCdDUvdBMwJpnsWACRshrMdvxPMIA = NEwGExLgAgWXGnbimuXuZqEmCSMt(P_1));
				}
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.inputManagerId = num;
				uebDdpmoIIdJuxGjNGokDpNzqIzJA.rewiredId = vqcIVIMLdLralEMfpfPdmOGpVjrl.sxHAgKaSFAVQVcgbYbUKBppQIIupA;
				pqVSpnpkpclTkJJcwLvoEFMRPYyp.DLhrLvkEIWtKcvePDdiqesFMQOXrA(uebDdpmoIIdJuxGjNGokDpNzqIzJA);
			}
		}
	}

	private void RaHPaAjACtbxsdKiQCapydqspxGGb()
	{
		if (EXdAjdeIMCUCpAYTcjQKiDTfoUGY.kOfWqcNUkdDXNVKvFcGRBXaKszAN(true))
		{
			IcLNLRdCpTkoJewhoTNocaGsClnC = true;
		}
		if (IcLNLRdCpTkoJewhoTNocaGsClnC)
		{
			XYNOljExdWvvXZsONKyBuPtmnTub();
		}
		if (FRZtBEZhJvvSCuItwxYyhFIWliTe && ENyIOUKJlvWrpqqmOrdSzhznfOFI.FjVRScdpFKyLClYRKhdeqgbPmktV && ENyIOUKJlvWrpqqmOrdSzhznfOFI.FAEdLIDaqiJrNwIazMvgidHfLWFNA())
		{
			ijTbKadNXkDMqiCyFnZVNwlMceYRb();
		}
	}

	private void XYNOljExdWvvXZsONKyBuPtmnTub()
	{
		IcLNLRdCpTkoJewhoTNocaGsClnC = false;
		if (!ENyIOUKJlvWrpqqmOrdSzhznfOFI.FjVRScdpFKyLClYRKhdeqgbPmktV)
		{
			EXdAjdeIMCUCpAYTcjQKiDTfoUGY.nUlrcPlTjJHtbIAbXDsafvKMxBdC();
			ENyIOUKJlvWrpqqmOrdSzhznfOFI.mPdlIFqjoxqpXUXmLokOkbcVfbGkA();
		}
	}

	private void ijTbKadNXkDMqiCyFnZVNwlMceYRb()
	{
		EXdAjdeIMCUCpAYTcjQKiDTfoUGY.WkjeqRDPLcdTKuiFPDuNZXCBvleH();
		if (FRZtBEZhJvvSCuItwxYyhFIWliTe)
		{
			IList<asRdKzmHUeOfEtnumeRYNLFtgVpi> list = fDFEZeYKsGHCphPTALGmjdlCIiOJA();
			if (XZKEYPGtOqwBxAeftnBMBCTfdpdjB(list))
			{
				onXhEpRHNporuBJqKYvniXRZcrkg(list);
			}
		}
	}

	private bool XZKEYPGtOqwBxAeftnBMBCTfdpdjB(IList<asRdKzmHUeOfEtnumeRYNLFtgVpi> P_0)
	{
		for (int i = 0; i < uWSosEgJsgkpMAKKcDIgNPSXcUjN.Count; i++)
		{
			if (uWSosEgJsgkpMAKKcDIgNPSXcUjN[i] != null && !uWSosEgJsgkpMAKKcDIgNPSXcUjN[i].RWcjmtEWOihCnICrbgbyOHewqpcW)
			{
				return true;
			}
		}
		int count = P_0.Count;
		for (int j = 0; j < count; j++)
		{
			if (P_0[j] != null && !QibnaSVFFCsdHeIqqlsQYeIUefWq(P_0[j].UTgEnYwMzKwvhFVWmadoqnWiKGQb))
			{
				return true;
			}
		}
		int count2 = uWSosEgJsgkpMAKKcDIgNPSXcUjN.Count;
		for (int k = 0; k < count2; k++)
		{
			if (uWSosEgJsgkpMAKKcDIgNPSXcUjN[k] != null && !hAzcCnBRjsZlxMWRPaRkoQykZfhfA(P_0, uWSosEgJsgkpMAKKcDIgNPSXcUjN[k].instanceGuid))
			{
				return true;
			}
		}
		return false;
	}

	private bool QibnaSVFFCsdHeIqqlsQYeIUefWq(Guid P_0)
	{
		int count = uWSosEgJsgkpMAKKcDIgNPSXcUjN.Count;
		for (int i = 0; i < count; i++)
		{
			if (uWSosEgJsgkpMAKKcDIgNPSXcUjN[i] != null && uWSosEgJsgkpMAKKcDIgNPSXcUjN[i].instanceGuid == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool hAzcCnBRjsZlxMWRPaRkoQykZfhfA(IList<asRdKzmHUeOfEtnumeRYNLFtgVpi> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].UTgEnYwMzKwvhFVWmadoqnWiKGQb == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void thXFtgwjSpgmTGLiQtJBCJJLqGtz(List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_0, List<UebDdpmoIIdJuxGjNGokDpNzqIzJA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA = P_0[i];
			if (uebDdpmoIIdJuxGjNGokDpNzqIzJA == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					UebDdpmoIIdJuxGjNGokDpNzqIzJA uebDdpmoIIdJuxGjNGokDpNzqIzJA2 = P_1[j];
					if (uebDdpmoIIdJuxGjNGokDpNzqIzJA2 != null && uebDdpmoIIdJuxGjNGokDpNzqIzJA.instanceGuid == uebDdpmoIIdJuxGjNGokDpNzqIzJA2.instanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				RlrkdWyAazsPUoHZdgVMpdPwxjfg(P_0[i], P_2);
			}
		}
	}

	private void RlrkdWyAazsPUoHZdgVMpdPwxjfg(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0, bool P_1)
	{
		if (P_1)
		{
			if (_DeviceConnectedEvent != null)
			{
				_DeviceConnectedEvent(P_0.ToBridgedController());
			}
		}
		else if (_DeviceDisconnectedEvent != null)
		{
			_DeviceDisconnectedEvent(P_0.ToControllerDisconnectedEventArgs());
		}
	}

	private bool lQiaYbPTcgQgpebxRjSGmqirYUAI()
	{
		try
		{
			int num = 0;
			YqWtGThGEbqWgpbNLISqdhKKOeWtA.hNvdifvMuydvvzHlJFkaHRZkfOLib(null, ref num, qUbotaSLZASADLtRbuWjzvVhFURA.xffaaffqlCQliyJdHalcXbRJNUcV<vKvFfEaUEqcCLatCfsioGxOBRYwwB>());
			if (kDLuuXocHmellknSGqLkFDHJXOakB != num)
			{
				kDLuuXocHmellknSGqLkFDHJXOakB = num;
				return true;
			}
		}
		catch (Exception ex)
		{
			Logger.Log("Exception getting Raw Input Device List.\n" + ex);
		}
		if (LfQSCuogmscXTtPwpDcyAtRkgBmCb > 0 && EXdAjdeIMCUCpAYTcjQKiDTfoUGY.QoUTfIQHGtlqqIJwZHVhymkDCoUF())
		{
			return true;
		}
		return false;
	}

	[Conditional("DEBUGTHIS")]
	private void feoodDwLzVyyOMlqcjSHqihuZlQI(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private void YQHdRiTpPEVSLfidPoToWpSvCNWJA(UebDdpmoIIdJuxGjNGokDpNzqIzJA P_0)
	{
		RlrkdWyAazsPUoHZdgVMpdPwxjfg(P_0, false);
	}
}
