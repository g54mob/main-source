using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Rewired;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Windows.DirectInput;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using Rewired.Utils.Classes.Utility;

internal class nHYtgmYZbuslvbwvuThTQLBbdmkB : PlatformInputManager, EbCVMtZcbYODojUXzIyunqpRvZvf
{
	private class zIwrdIIRBqtGNAiinYdFLQeQHQkI : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int tMlFMbbnSDaAYEdgwltrYDupMlKyA;

		private int ouIAxHJkHCqySFVaXBWVUCAlcjwjA;

		public Guid dfkNjaPwXkaeRLYwmoTrUJWHbEfc;

		public string dOwZfeJoWhhATUmPdsXZbdgVvtHW;

		public readonly xNSYRpDpIMbnNUHRXFGqeEMHBNJH UztXDfeobYvTILthUwbphNPSdKam;

		public VrUjHkyKwlgfxGiNlmxxLiWLUcYKA EJqnnacIsWkFjtZCidzSDEtnLNNd;

		public EjGdcVAZLVxPojHVzcAqTOhubwDQ IUYnzsCagvejGAzueeqerINTTALG;

		public string QPMKBEqKVaycLpEwnGlOkcMWLImdb;

		public string kdNvziqmWoxIlwtlUVdLVjQQNpFi;

		public int ZEcFSCcanLCalchLYPeeGgIDBkJOc;

		public Guid QrLkiuceluZEPMOcjJiYcdnvZQtl;

		public Guid OBMqGlmYgvImeZtYwRTuJWDjlzBA;

		public Guid iFObMCUaUQUnWzybrqxSRAVRTBWI;

		public int SdthoJItTfcAKBEUPFiNJgcraHGZA;

		public bool jrbdcQFpFxHLlTlwtpmmDUBJcizi;

		public string fCTsNqmwahVpnfulngJdKbKIGXmfA;

		public string AFhwApQSkQsoTcVBZLsyueSffmzg;

		public int UDFcKRicGfzUGfNrRKCnISkDnKMVb;

		public int FkOzkpBIpGDDNocsckZjSKLgiIVv;

		public int HhqbiwBXcDTULYOwmAYexUsXBMtCA;

		public int MCDKyUJlmhQXfeayeJmoXfaHcWfiA;

		public int nyDAXJEHgHLCMlTZKpdDYCOIRSQr;

		public bool RHlGZiMcaSyNapvNcioouCFOtJwP;

		public Controller.Extension wViVLSadDnEGnqutnjEyjJuLOUiq;

		private float[] dydcbiMQDPlMCvQZIVaFxWCilYKQ;

		private bool[] JkLuaNrBfUjBFJFAynrFZsuAKJMTA;

		private HardwareJoystickMap_InputManager hJeYXuujpZcIHhUzFngZZNyaunJy;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> NBBGEOVRvneYDcFdnaoIhuFHZZKyB;

		private bool YCkiTXGFGImEpYaQgYLZkdDBKpFdb;

		private bool zGsfYreSUFOtjBTyHnkmVUNXLXYnA;

		private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

		[CustomObfuscation(rename = false)]
		public int rewiredId
		{
			get
			{
				return tMlFMbbnSDaAYEdgwltrYDupMlKyA;
			}
			set
			{
				tMlFMbbnSDaAYEdgwltrYDupMlKyA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public int inputManagerId
		{
			get
			{
				return ouIAxHJkHCqySFVaXBWVUCAlcjwjA;
			}
			set
			{
				ouIAxHJkHCqySFVaXBWVUCAlcjwjA = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public string name
		{
			get
			{
				if (dOwZfeJoWhhATUmPdsXZbdgVvtHW != "Unknown Controller")
				{
					return dOwZfeJoWhhATUmPdsXZbdgVvtHW;
				}
				if (jrbdcQFpFxHLlTlwtpmmDUBJcizi && !string.IsNullOrEmpty(fCTsNqmwahVpnfulngJdKbKIGXmfA))
				{
					return fCTsNqmwahVpnfulngJdKbKIGXmfA;
				}
				return kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			}
		}

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (ouIAxHJkHCqySFVaXBWVUCAlcjwjA < 0)
				{
					return null;
				}
				return ouIAxHJkHCqySFVaXBWVUCAlcjwjA;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension => wViVLSadDnEGnqutnjEyjJuLOUiq;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => QrLkiuceluZEPMOcjJiYcdnvZQtl;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public zIwrdIIRBqtGNAiinYdFLQeQHQkI(xNSYRpDpIMbnNUHRXFGqeEMHBNJH P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1)
		{
			UztXDfeobYvTILthUwbphNPSdKam = P_0;
			NBBGEOVRvneYDcFdnaoIhuFHZZKyB = P_1;
			ouIAxHJkHCqySFVaXBWVUCAlcjwjA = -1;
			tMlFMbbnSDaAYEdgwltrYDupMlKyA = -1;
		}

		public void OKLfbagyaudIxlHWyOTBXIXfgzkUA()
		{
			string text = kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			Guid oBMqGlmYgvImeZtYwRTuJWDjlzBA = OBMqGlmYgvImeZtYwRTuJWDjlzBA;
			iFObMCUaUQUnWzybrqxSRAVRTBWI = MiscTools.CreateGuidHashSHA1(text + oBMqGlmYgvImeZtYwRTuJWDjlzBA.ToString());
			UDFcKRicGfzUGfNrRKCnISkDnKMVb = HhqbiwBXcDTULYOwmAYexUsXBMtCA;
			FkOzkpBIpGDDNocsckZjSKLgiIVv = MCDKyUJlmhQXfeayeJmoXfaHcWfiA + nyDAXJEHgHLCMlTZKpdDYCOIRSQr * 8;
			bfkxPXlKJejmTALFktyasdIIxRKhA();
			dfkNjaPwXkaeRLYwmoTrUJWHbEfc = hJeYXuujpZcIHhUzFngZZNyaunJy.hardwareMapIdentifier.guid;
			dOwZfeJoWhhATUmPdsXZbdgVvtHW = hJeYXuujpZcIHhUzFngZZNyaunJy.controllerName;
			YCkiTXGFGImEpYaQgYLZkdDBKpFdb = ((dfkNjaPwXkaeRLYwmoTrUJWHbEfc == Guid.Empty) ? true : false);
			dydcbiMQDPlMCvQZIVaFxWCilYKQ = new float[UDFcKRicGfzUGfNrRKCnISkDnKMVb];
			JkLuaNrBfUjBFJFAynrFZsuAKJMTA = new bool[FkOzkpBIpGDDNocsckZjSKLgiIVv];
			UztXDfeobYvTILthUwbphNPSdKam.unNSIaykSfpkHNEmGhtmxbrGklvQ();
			Update();
		}

		public void OLfmjaYQlzgJtGmEIVCoLPHHLIfZ(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0)
		{
			if (P_0 != null)
			{
				ouIAxHJkHCqySFVaXBWVUCAlcjwjA = P_0.ouIAxHJkHCqySFVaXBWVUCAlcjwjA;
				tMlFMbbnSDaAYEdgwltrYDupMlKyA = P_0.tMlFMbbnSDaAYEdgwltrYDupMlKyA;
				for (int i = 0; i < MathTools.Min(JkLuaNrBfUjBFJFAynrFZsuAKJMTA.Length, P_0.JkLuaNrBfUjBFJFAynrFZsuAKJMTA.Length); i++)
				{
					JkLuaNrBfUjBFJFAynrFZsuAKJMTA[i] = P_0.JkLuaNrBfUjBFJFAynrFZsuAKJMTA[i];
				}
				for (int j = 0; j < MathTools.Min(dydcbiMQDPlMCvQZIVaFxWCilYKQ.Length, P_0.dydcbiMQDPlMCvQZIVaFxWCilYKQ.Length); j++)
				{
					dydcbiMQDPlMCvQZIVaFxWCilYKQ[j] = P_0.dydcbiMQDPlMCvQZIVaFxWCilYKQ[j];
				}
				zGsfYreSUFOtjBTyHnkmVUNXLXYnA = P_0.zGsfYreSUFOtjBTyHnkmVUNXLXYnA;
				UztXDfeobYvTILthUwbphNPSdKam.OLfmjaYQlzgJtGmEIVCoLPHHLIfZ(P_0.UztXDfeobYvTILthUwbphNPSdKam);
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			UztXDfeobYvTILthUwbphNPSdKam.qfnucLqflxALQiRYVXsitLqJNSuab();
			bool[] array = UztXDfeobYvTILthUwbphNPSdKam.xJOAbibiwiGxgsdpcdMYjGrEAZZwb;
			int[] ywGnMOKwAHDLEyCOXcOpCjBCXpNK = UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.YwGnMOKwAHDLEyCOXcOpCjBCXpNK;
			yznGbdDyUyOPfduhykPAGCjaQExNc(array, ywGnMOKwAHDLEyCOXcOpCjBCXpNK);
			RdPFzuLpsssVUfJbWIHhRQPBGScT(array, ywGnMOKwAHDLEyCOXcOpCjBCXpNK);
			UztXDfeobYvTILthUwbphNPSdKam.MqQjLCryqEPDlgJVxyKAVvUubRHs();
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (UDFcKRicGfzUGfNrRKCnISkDnKMVb != dataUpdater.axisCount || FkOzkpBIpGDDNocsckZjSKLgiIVv != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < UDFcKRicGfzUGfNrRKCnISkDnKMVb; i++)
			{
				dataUpdater.axisValues[i] = dydcbiMQDPlMCvQZIVaFxWCilYKQ[i];
			}
			for (int j = 0; j < FkOzkpBIpGDDNocsckZjSKLgiIVv; j++)
			{
				dataUpdater.buttonValues[j] = JkLuaNrBfUjBFJFAynrFZsuAKJMTA[j];
			}
			if (zGsfYreSUFOtjBTyHnkmVUNXLXYnA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int sKPmsOwrsqQUGaDeDiygzRJgUHm(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0)
		{
			if (P_0.tMlFMbbnSDaAYEdgwltrYDupMlKyA == tMlFMbbnSDaAYEdgwltrYDupMlKyA)
			{
				return 2;
			}
			if (HhqbiwBXcDTULYOwmAYexUsXBMtCA != P_0.HhqbiwBXcDTULYOwmAYexUsXBMtCA)
			{
				return 0;
			}
			if (MCDKyUJlmhQXfeayeJmoXfaHcWfiA != P_0.MCDKyUJlmhQXfeayeJmoXfaHcWfiA)
			{
				return 0;
			}
			if (nyDAXJEHgHLCMlTZKpdDYCOIRSQr != P_0.nyDAXJEHgHLCMlTZKpdDYCOIRSQr)
			{
				return 0;
			}
			if (P_0.instanceGuid == instanceGuid)
			{
				return 2;
			}
			if (P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI == iFObMCUaUQUnWzybrqxSRAVRTBWI)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo ridDROClRSAZyaDKOnfYTSobXEmrA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
			QEJmtREKifDoriOcevlcZbMJbDfL(bridgedControllerHWInfo);
			return bridgedControllerHWInfo;
		}

		[CustomObfuscation(rename = false)]
		public BridgedController ToBridgedController()
		{
			BridgedController bridgedController = new BridgedController();
			QEJmtREKifDoriOcevlcZbMJbDfL(bridgedController);
			return bridgedController;
		}

		[CustomObfuscation(rename = false)]
		public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
		{
			return new ControllerDisconnectedEventArgs(tMlFMbbnSDaAYEdgwltrYDupMlKyA);
		}

		public bool qNRFgbeBPuuxzAiRNMsKAqIJVAFxA()
		{
			try
			{
				UztXDfeobYvTILthUwbphNPSdKam.gpRRWpNgaNJmzGbrEaNwChwYyxtY.HhEymAuINCPZjFafVJeIfvGauiKL();
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void qqTnUdwDLRDdijbuOGAyBhNivyaqA()
		{
			try
			{
				if (UztXDfeobYvTILthUwbphNPSdKam.gpRRWpNgaNJmzGbrEaNwChwYyxtY != null)
				{
					UztXDfeobYvTILthUwbphNPSdKam.gpRRWpNgaNJmzGbrEaNwChwYyxtY.qqTnUdwDLRDdijbuOGAyBhNivyaqA();
				}
			}
			catch
			{
			}
		}

		public void zobeSpTCoofGnipPFjpZGNzdwEoE()
		{
			try
			{
				if (UztXDfeobYvTILthUwbphNPSdKam.gpRRWpNgaNJmzGbrEaNwChwYyxtY != null)
				{
					UztXDfeobYvTILthUwbphNPSdKam.gpRRWpNgaNJmzGbrEaNwChwYyxtY.zobeSpTCoofGnipPFjpZGNzdwEoE();
				}
			}
			catch
			{
			}
		}

		private void yznGbdDyUyOPfduhykPAGCjaQExNc(bool[] P_0, int[] P_1)
		{
			if (UDFcKRicGfzUGfNrRKCnISkDnKMVb <= 0)
			{
				return;
			}
			switch (hJeYXuujpZcIHhUzFngZZNyaunJy.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Axis[] axes_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Axes_orig;
				if (axes_orig2 != null)
				{
					for (int j = 0; j < axes_orig2.Length; j++)
					{
						fnaaXRUCVpwvwWRollOpWEKUdiW(axes_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Axes_orig;
				if (axes_orig != null)
				{
					for (int i = 0; i < axes_orig.Length; i++)
					{
						fnaaXRUCVpwvwWRollOpWEKUdiW(axes_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void RdPFzuLpsssVUfJbWIHhRQPBGScT(bool[] P_0, int[] P_1)
		{
			if (FkOzkpBIpGDDNocsckZjSKLgiIVv <= 0)
			{
				return;
			}
			switch (hJeYXuujpZcIHhUzFngZZNyaunJy.map.platform)
			{
			case InputPlatform.WindowsRawInput:
			{
				HardwareJoystickMap.Platform_RawInput_Base.Button[] buttons_orig2 = ((HardwareJoystickMap.Platform_RawInput_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Buttons_orig;
				if (buttons_orig2 != null)
				{
					for (int j = 0; j < buttons_orig2.Length; j++)
					{
						fMcAkgWDJulDGPRxZIXwdBJxCLsGA(buttons_orig2[j], j, P_0, P_1);
					}
				}
				break;
			}
			case InputPlatform.WindowsDirectInput:
			{
				HardwareJoystickMap.Platform_DirectInput_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_DirectInput_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						fMcAkgWDJulDGPRxZIXwdBJxCLsGA(buttons_orig[i], i, P_0, P_1);
					}
				}
				break;
			}
			}
		}

		private void fnaaXRUCVpwvwWRollOpWEKUdiW(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= UDFcKRicGfzUGfNrRKCnISkDnKMVb)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			dydcbiMQDPlMCvQZIVaFxWCilYKQ[P_1] = mkqEwjEWKTccoblNpohIPzhMuvaL(P_0, P_2, P_3);
			if (!zGsfYreSUFOtjBTyHnkmVUNXLXYnA && dydcbiMQDPlMCvQZIVaFxWCilYKQ[P_1] != 0f)
			{
				zGsfYreSUFOtjBTyHnkmVUNXLXYnA = true;
			}
		}

		private void fMcAkgWDJulDGPRxZIXwdBJxCLsGA(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, int P_1, bool[] P_2, int[] P_3)
		{
			if (P_1 >= FkOzkpBIpGDDNocsckZjSKLgiIVv)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			JkLuaNrBfUjBFJFAynrFZsuAKJMTA[P_1] = MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0, P_2, P_3);
			if (!zGsfYreSUFOtjBTyHnkmVUNXLXYnA && JkLuaNrBfUjBFJFAynrFZsuAKJMTA[P_1])
			{
				zGsfYreSUFOtjBTyHnkmVUNXLXYnA = true;
			}
		}

		private float mkqEwjEWKTccoblNpohIPzhMuvaL(HardwareJoystickMap.Platform_RawOrDirectInput.Axis_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
				{
					return 0f;
				}
				return mkqEwjEWKTccoblNpohIPzhMuvaL((DirectInputAxis)P_0.sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= MCDKyUJlmhQXfeayeJmoXfaHcWfiA || sourceButton >= 128)
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
				if (sourceHat < 0 || sourceHat >= nyDAXJEHgHLCMlTZKpdDYCOIRSQr || sourceHat >= 4)
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
					num2 = XsgoxAZUZmkaOAsFfLvtnhLCckAS(num, AxisDirection.Horizontal);
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
					num2 = XsgoxAZUZmkaOAsFfLvtnhLCckAS(num, AxisDirection.Vertical);
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
					if (customCalculationSourceData[i] != null && customCalculationSourceData[i].sourceType == 1 && uXztzQXQbVitwatLmUgnACARdJbH(customCalculationSourceData[i], out var item))
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

		private float mkqEwjEWKTccoblNpohIPzhMuvaL(DirectInputAxis P_0)
		{
			switch (P_0)
			{
			case DirectInputAxis.X:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.XHAcjfYHxobupnkeqiFjdRtqsftl;
			case DirectInputAxis.Y:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.hOOUxyzjPSHmCugYimIocEeoCnOZ;
			case DirectInputAxis.Z:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.nXGdfezugKPnijHxPqSGMXNvieeu;
			case DirectInputAxis.RotationX:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.iVZXAatNNkoQhakyOcSvPZuywmil;
			case DirectInputAxis.RotationY:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA;
			case DirectInputAxis.RotationZ:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.uXFvVgVvAswDejLdlJrCamssAhoj;
			case DirectInputAxis.Slider0:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.YrVRqCBdYnMvpzdpuevFnfRkNtEB[0];
			case DirectInputAxis.Slider1:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.YrVRqCBdYnMvpzdpuevFnfRkNtEB[1];
			case DirectInputAxis.VelocityX:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.IVGASYlUTQmRAdogTdHGGGSkarzB;
			case DirectInputAxis.VelocityY:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.BokrrSjVfAhYkIQmhzfHRbuAwaHg;
			case DirectInputAxis.VelocityZ:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.irfbjzGcGIOFNuSIcxqNAnObMqwfA;
			case DirectInputAxis.AngularVelocityX:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.MIprVMIPkzUhwQMRTGRBJUKDOEHG;
			case DirectInputAxis.AngularVelocityY:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.gHFfmwgurBviMwjylTPNtvFERkueA;
			case DirectInputAxis.AngularVelocityZ:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.ZJzfzzVoBQcjSbQzJDLBesKHhgrd;
			case DirectInputAxis.VelocitySlider0:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.bcTvrKOzACMlcKbeYtQASNtoRYNF[0];
			case DirectInputAxis.VelocitySlider1:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.bcTvrKOzACMlcKbeYtQASNtoRYNF[1];
			case DirectInputAxis.AccelerationX:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.mLaQWAdMKFPMBUGNBffgLOgiOfei;
			case DirectInputAxis.AccelerationY:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.SwbkYdbTEUHqQhNPkvGRnQfJjnBM;
			case DirectInputAxis.AccelerationZ:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.jZdAQOYvoJwkNAKHfQVbsbezVfmW;
			case DirectInputAxis.AngularAccelerationX:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.ispeatToHywvYYMSuZWhkGwDnwYp;
			case DirectInputAxis.AngularAccelerationY:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.IpSfimgoprwpPbvvZHasGFLoyFpU;
			case DirectInputAxis.AngularAccelerationZ:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.vTBwIFSNkxHsobDCWeicqTmmUnIH;
			case DirectInputAxis.AccelerationSlider0:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.tkaAtqiNIrFwnbfhpfDKyViuRMGV[0];
			case DirectInputAxis.AccelerationSlider1:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.tkaAtqiNIrFwnbfhpfDKyViuRMGV[1];
			case DirectInputAxis.ForceX:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.taoHjuPyxajupaEHhgrYbSBkwtZo;
			case DirectInputAxis.ForceY:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.lsBdvuIbCnbembzorkupUPfpqrMG;
			case DirectInputAxis.ForceZ:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.qdgKtiruueifuNJqTMRtZTgjWvmn;
			case DirectInputAxis.TorqueX:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.jRBPLEpruUgsqCpLoBAvnjcDbnwlA;
			case DirectInputAxis.TorqueY:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.fMiDgiXVKZbDOKqlvGclhoBcUCoDB;
			case DirectInputAxis.TorqueZ:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.KdwAVnhDDPrFtJAllRAkceDPAadz;
			case DirectInputAxis.ForceSlider0:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.bbzjSUmzCpvKeztqjjpYuJViWzaP[0];
			case DirectInputAxis.ForceSlider1:
				return UztXDfeobYvTILthUwbphNPSdKam.OvLGkmnTcGacGJDgvbfNZOhTArsI.bbzjSUmzCpvKeztqjjpYuJViWzaP[1];
			default:
				return 0f;
			}
		}

		private bool MSdCYQsaMwqrghCGBIFNcNtyaXdm(HardwareJoystickMap.Platform_RawOrDirectInput.Button_Base P_0, bool[] P_1, int[] P_2)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (P_1[P_0.ignoreIfButtonsActiveButtons[i]])
						{
							return false;
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
							return false;
						}
						flag = true;
					}
					if (flag)
					{
						return true;
					}
					return false;
				}
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= MCDKyUJlmhQXfeayeJmoXfaHcWfiA || sourceButton >= 128)
				{
					return false;
				}
				return P_1[sourceButton];
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				if (P_0.sourceAxis <= 0 || P_0.sourceAxis > 32)
				{
					return false;
				}
				float num = mkqEwjEWKTccoblNpohIPzhMuvaL((DirectInputAxis)P_0.sourceAxis);
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
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Hat)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= nyDAXJEHgHLCMlTZKpdDYCOIRSQr || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(P_2[sourceHat], 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(P_2[sourceHat], 1, P_0.sourceHatType);
				case HatDirection.Right:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(P_2[sourceHat], 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(P_2[sourceHat], 3, P_0.sourceHatType);
				case HatDirection.Down:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(P_2[sourceHat], 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(P_2[sourceHat], 5, P_0.sourceHatType);
				case HatDirection.Left:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(P_2[sourceHat], 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(P_2[sourceHat], 7, P_0.sourceHatType);
				}
			}
			else if (P_0.sourceType == HardwareElementSourceTypeWithHat.Custom)
			{
				CustomCalculation customCalculation = P_0.customCalculation;
				if (customCalculation == null)
				{
					return false;
				}
				if (customCalculation.ResultType != TypeWrapper.DataType.Single)
				{
					return false;
				}
				HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData[] customCalculationSourceData = P_0.customCalculationSourceData;
				if (customCalculationSourceData == null)
				{
					return false;
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
						if (RqwYhTmXUnhosEPXTrOeqzqHgiOy(customCalculationSourceData[k], P_1, out var flag2))
						{
							customCalculation.AddData(flag2 ? 1f : 0f);
						}
						break;
					}
					case HardwareElementSourceTypeWithHat.Axis:
					{
						if (uXztzQXQbVitwatLmUgnACARdJbH(customCalculationSourceData[k], out var num2))
						{
							customCalculation.AddData((num2 != 0f) ? 1f : 0f);
						}
						break;
					}
					}
				}
				if (!customCalculation.Process())
				{
					return false;
				}
				if (customCalculation.Result.type != TypeWrapper.DataType.Single)
				{
					return false;
				}
				return (float)customCalculation.Result != 0f;
			}
			return false;
		}

		private bool AEmeApyTXmVHqZHavQCdsWjXewZB(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (hJeYXuujpZcIHhUzFngZZNyaunJy.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float XsgoxAZUZmkaOAsFfLvtnhLCckAS(int P_0, AxisDirection P_1)
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

		private bool RqwYhTmXUnhosEPXTrOeqzqHgiOy(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, bool[] P_1, out bool P_2)
		{
			P_2 = false;
			if (P_0.sourceType != 0)
			{
				return false;
			}
			int sourceButton = P_0.sourceButton;
			if (sourceButton < 0 || sourceButton >= MCDKyUJlmhQXfeayeJmoXfaHcWfiA || sourceButton >= 128)
			{
				return false;
			}
			P_2 = P_1[sourceButton];
			return true;
		}

		private bool uXztzQXQbVitwatLmUgnACARdJbH(HardwareJoystickMap.Platform_RawOrDirectInput.CustomCalculationSourceData P_0, out float P_1)
		{
			P_1 = 0f;
			if (P_0.sourceType != 1)
			{
				return false;
			}
			if (P_0.sourceAxis <= 0 || P_0.sourceAxis >= 32)
			{
				return false;
			}
			P_1 = mkqEwjEWKTccoblNpohIPzhMuvaL((DirectInputAxis)P_0.sourceAxis);
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

		private ControlDeviceType PfLATcrmHkHypsLBliPvAEDkGkxS(EjGdcVAZLVxPojHVzcAqTOhubwDQ P_0)
		{
			switch (P_0)
			{
			case EjGdcVAZLVxPojHVzcAqTOhubwDQ.Keyboard:
				return ControlDeviceType.Keyboard;
			case EjGdcVAZLVxPojHVzcAqTOhubwDQ.Joystick:
				return ControlDeviceType.Joystick;
			case EjGdcVAZLVxPojHVzcAqTOhubwDQ.Gamepad:
				return ControlDeviceType.Gamepad;
			case EjGdcVAZLVxPojHVzcAqTOhubwDQ.Mouse:
				return ControlDeviceType.Mouse;
			case EjGdcVAZLVxPojHVzcAqTOhubwDQ.Flight:
				return ControlDeviceType.Flight;
			case EjGdcVAZLVxPojHVzcAqTOhubwDQ.Driving:
				return ControlDeviceType.Wheel;
			default:
				return ControlDeviceType.Unknown;
			}
		}

		private void bfkxPXlKJejmTALFktyasdIIxRKhA()
		{
			hJeYXuujpZcIHhUzFngZZNyaunJy = NBBGEOVRvneYDcFdnaoIhuFHZZKyB(ridDROClRSAZyaDKOnfYTSobXEmrA());
			if (hJeYXuujpZcIHhUzFngZZNyaunJy == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			UDFcKRicGfzUGfNrRKCnISkDnKMVb = hJeYXuujpZcIHhUzFngZZNyaunJy.axisCount;
			FkOzkpBIpGDDNocsckZjSKLgiIVv = hJeYXuujpZcIHhUzFngZZNyaunJy.buttonCount;
		}

		private void SpAzXINIJVAiMxzjuwSHDfgePYC()
		{
		}

		private string pSdBCmdydqRtEhPXXoHSKfoiLscd()
		{
			return InputTools.FormatHardwareIdentifierString(string.Format("{0}{1}{2}{3}{4}", ReInput.currentPlatform.ToString(), InputSource.DirectInput, (jrbdcQFpFxHLlTlwtpmmDUBJcizi && !string.IsNullOrEmpty(fCTsNqmwahVpnfulngJdKbKIGXmfA)) ? fCTsNqmwahVpnfulngJdKbKIGXmfA : kdNvziqmWoxIlwtlUVdLVjQQNpFi, ZEcFSCcanLCalchLYPeeGgIDBkJOc.ToString("X4"), new PidVid(OBMqGlmYgvImeZtYwRTuJWDjlzBA).vendorId.ToString("X4")));
		}

		private void QEJmtREKifDoriOcevlcZbMJbDfL(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.DirectInput;
			P_0.inputSource = P_0.inputManagerSource;
			P_0.deviceType = PfLATcrmHkHypsLBliPvAEDkGkxS(IUYnzsCagvejGAzueeqerINTTALG);
			P_0.hardwareIdentifier = pSdBCmdydqRtEhPXXoHSKfoiLscd();
			P_0.hardwareAxisCount = HhqbiwBXcDTULYOwmAYexUsXBMtCA;
			P_0.hardwareButtonCount = MCDKyUJlmhQXfeayeJmoXfaHcWfiA;
			P_0.hardwareHatCount = nyDAXJEHgHLCMlTZKpdDYCOIRSQr;
			P_0.hw_productName = kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			P_0.hw_deviceGuid = instanceGuid;
			P_0.hw_productId = ZEcFSCcanLCalchLYPeeGgIDBkJOc;
			P_0.hw_pidVid = new PidVid(OBMqGlmYgvImeZtYwRTuJWDjlzBA);
			P_0.hw_isBluetoothDevice = jrbdcQFpFxHLlTlwtpmmDUBJcizi;
			P_0.hw_bluetoothDeviceName = ((!string.IsNullOrEmpty(fCTsNqmwahVpnfulngJdKbKIGXmfA)) ? fCTsNqmwahVpnfulngJdKbKIGXmfA : string.Empty);
			P_0.definitionMatchTag = AFhwApQSkQsoTcVBZLsyueSffmzg;
		}

		private void QEJmtREKifDoriOcevlcZbMJbDfL(BridgedController P_0)
		{
			QEJmtREKifDoriOcevlcZbMJbDfL((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = hJeYXuujpZcIHhUzFngZZNyaunJy.ToGameHardwareControllerMap();
			P_0.instanceName = QPMKBEqKVaycLpEwnGlOkcMWLImdb;
			P_0.productName = kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			P_0.isXInputDevice = RHlGZiMcaSyNapvNcioouCFOtJwP;
			P_0.axisCount = UDFcKRicGfzUGfNrRKCnISkDnKMVb;
			P_0.buttonCount = FkOzkpBIpGDDNocsckZjSKLgiIVv;
			P_0.unknownControllerHats = byrzdcexxneumZiIjICVRziDQXRT();
			P_0.controllerTypeGuid = dfkNjaPwXkaeRLYwmoTrUJWHbEfc;
			P_0.controllerExtension = extension;
		}

		private void yhHNwijDRgDwphgkEdcnAgVbjOgS()
		{
			for (int i = 0; i < FkOzkpBIpGDDNocsckZjSKLgiIVv; i++)
			{
				JkLuaNrBfUjBFJFAynrFZsuAKJMTA[i] = false;
			}
			for (int j = 0; j < UDFcKRicGfzUGfNrRKCnISkDnKMVb; j++)
			{
				dydcbiMQDPlMCvQZIVaFxWCilYKQ[j] = 0f;
			}
		}

		private UnknownControllerHat[] byrzdcexxneumZiIjICVRziDQXRT()
		{
			if (!YCkiTXGFGImEpYaQgYLZkdDBKpFdb)
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

		public void vCBFvIdHsbAnKBZkroQOsRrLIAyV()
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
		{
			try
			{
				vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
		{
			if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
			{
				if (P_0 && UztXDfeobYvTILthUwbphNPSdKam != null)
				{
					UztXDfeobYvTILthUwbphNPSdKam.Dispose();
				}
				JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
			}
		}

		public static int WoOaAbIBZmsaPWyNgRCmOFZeLysOA(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0, zIwrdIIRBqtGNAiinYdFLQeQHQkI P_1)
		{
			if (P_0.ouIAxHJkHCqySFVaXBWVUCAlcjwjA < P_1.ouIAxHJkHCqySFVaXBWVUCAlcjwjA)
			{
				return -1;
			}
			if (P_0.ouIAxHJkHCqySFVaXBWVUCAlcjwjA > P_1.ouIAxHJkHCqySFVaXBWVUCAlcjwjA)
			{
				return 1;
			}
			return 0;
		}

		public static int zwMWCtrjmRXclllojCXTsqEOCgiP(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0, zIwrdIIRBqtGNAiinYdFLQeQHQkI P_1)
		{
			if (P_0.SdthoJItTfcAKBEUPFiNJgcraHGZA < P_1.SdthoJItTfcAKBEUPFiNJgcraHGZA)
			{
				return -1;
			}
			if (P_0.SdthoJItTfcAKBEUPFiNJgcraHGZA > P_1.SdthoJItTfcAKBEUPFiNJgcraHGZA)
			{
				return 1;
			}
			return 0;
		}
	}

	private class xNSYRpDpIMbnNUHRXFGqeEMHBNJH : IDisposable
	{
		public class FCpTLLPNBFudwAHyuQPClGyXDyBCA
		{
			public float XHAcjfYHxobupnkeqiFjdRtqsftl;

			public float hOOUxyzjPSHmCugYimIocEeoCnOZ;

			public float nXGdfezugKPnijHxPqSGMXNvieeu;

			public float iVZXAatNNkoQhakyOcSvPZuywmil;

			public float fRKWXdIcjzUVKxBCLBAxjgTDzHXfA;

			public float uXFvVgVvAswDejLdlJrCamssAhoj;

			public float[] YrVRqCBdYnMvpzdpuevFnfRkNtEB;

			public readonly int[] YwGnMOKwAHDLEyCOXcOpCjBCXpNK;

			public readonly bool[] syxPbhBJItzVAVLveDKeKXtdjmVVA;

			public float IVGASYlUTQmRAdogTdHGGGSkarzB;

			public float BokrrSjVfAhYkIQmhzfHRbuAwaHg;

			public float irfbjzGcGIOFNuSIcxqNAnObMqwfA;

			public float MIprVMIPkzUhwQMRTGRBJUKDOEHG;

			public float gHFfmwgurBviMwjylTPNtvFERkueA;

			public float ZJzfzzVoBQcjSbQzJDLBesKHhgrd;

			public readonly float[] bcTvrKOzACMlcKbeYtQASNtoRYNF;

			public float mLaQWAdMKFPMBUGNBffgLOgiOfei;

			public float SwbkYdbTEUHqQhNPkvGRnQfJjnBM;

			public float jZdAQOYvoJwkNAKHfQVbsbezVfmW;

			public float ispeatToHywvYYMSuZWhkGwDnwYp;

			public float IpSfimgoprwpPbvvZHasGFLoyFpU;

			public float vTBwIFSNkxHsobDCWeicqTmmUnIH;

			public readonly float[] tkaAtqiNIrFwnbfhpfDKyViuRMGV;

			public float taoHjuPyxajupaEHhgrYbSBkwtZo;

			public float lsBdvuIbCnbembzorkupUPfpqrMG;

			public float qdgKtiruueifuNJqTMRtZTgjWvmn;

			public float jRBPLEpruUgsqCpLoBAvnjcDbnwlA;

			public float fMiDgiXVKZbDOKqlvGclhoBcUCoDB;

			public float KdwAVnhDDPrFtJAllRAkceDPAadz;

			public readonly float[] bbzjSUmzCpvKeztqjjpYuJViWzaP;

			public FCpTLLPNBFudwAHyuQPClGyXDyBCA()
			{
				YrVRqCBdYnMvpzdpuevFnfRkNtEB = new float[2];
				YwGnMOKwAHDLEyCOXcOpCjBCXpNK = new int[4];
				syxPbhBJItzVAVLveDKeKXtdjmVVA = new bool[128];
				bcTvrKOzACMlcKbeYtQASNtoRYNF = new float[2];
				tkaAtqiNIrFwnbfhpfDKyViuRMGV = new float[2];
				bbzjSUmzCpvKeztqjjpYuJViWzaP = new float[2];
			}

			public void DwNKXiEShimVDUzntAObjUXyaFmo()
			{
				XHAcjfYHxobupnkeqiFjdRtqsftl = 0f;
				hOOUxyzjPSHmCugYimIocEeoCnOZ = 0f;
				nXGdfezugKPnijHxPqSGMXNvieeu = 0f;
				iVZXAatNNkoQhakyOcSvPZuywmil = 0f;
				fRKWXdIcjzUVKxBCLBAxjgTDzHXfA = 0f;
				uXFvVgVvAswDejLdlJrCamssAhoj = 0f;
				for (int i = 0; i < YrVRqCBdYnMvpzdpuevFnfRkNtEB.Length; i++)
				{
					YrVRqCBdYnMvpzdpuevFnfRkNtEB[i] = 0f;
				}
				for (int j = 0; j < YwGnMOKwAHDLEyCOXcOpCjBCXpNK.Length; j++)
				{
					YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j] = 0;
				}
				for (int k = 0; k < syxPbhBJItzVAVLveDKeKXtdjmVVA.Length; k++)
				{
					syxPbhBJItzVAVLveDKeKXtdjmVVA[k] = false;
				}
				IVGASYlUTQmRAdogTdHGGGSkarzB = 0f;
				BokrrSjVfAhYkIQmhzfHRbuAwaHg = 0f;
				irfbjzGcGIOFNuSIcxqNAnObMqwfA = 0f;
				MIprVMIPkzUhwQMRTGRBJUKDOEHG = 0f;
				gHFfmwgurBviMwjylTPNtvFERkueA = 0f;
				ZJzfzzVoBQcjSbQzJDLBesKHhgrd = 0f;
				for (int l = 0; l < bcTvrKOzACMlcKbeYtQASNtoRYNF.Length; l++)
				{
					bcTvrKOzACMlcKbeYtQASNtoRYNF[l] = 0f;
				}
				mLaQWAdMKFPMBUGNBffgLOgiOfei = 0f;
				SwbkYdbTEUHqQhNPkvGRnQfJjnBM = 0f;
				jZdAQOYvoJwkNAKHfQVbsbezVfmW = 0f;
				ispeatToHywvYYMSuZWhkGwDnwYp = 0f;
				IpSfimgoprwpPbvvZHasGFLoyFpU = 0f;
				vTBwIFSNkxHsobDCWeicqTmmUnIH = 0f;
				for (int m = 0; m < tkaAtqiNIrFwnbfhpfDKyViuRMGV.Length; m++)
				{
					tkaAtqiNIrFwnbfhpfDKyViuRMGV[m] = 0f;
				}
				taoHjuPyxajupaEHhgrYbSBkwtZo = 0f;
				lsBdvuIbCnbembzorkupUPfpqrMG = 0f;
				qdgKtiruueifuNJqTMRtZTgjWvmn = 0f;
				jRBPLEpruUgsqCpLoBAvnjcDbnwlA = 0f;
				fMiDgiXVKZbDOKqlvGclhoBcUCoDB = 0f;
				KdwAVnhDDPrFtJAllRAkceDPAadz = 0f;
				for (int n = 0; n < bbzjSUmzCpvKeztqjjpYuJViWzaP.Length; n++)
				{
					bbzjSUmzCpvKeztqjjpYuJViWzaP[n] = 0f;
				}
			}

			public void xQEFQkhJhvnmwGSMyzYdziphFTng(FCpTLLPNBFudwAHyuQPClGyXDyBCA P_0)
			{
				XHAcjfYHxobupnkeqiFjdRtqsftl = P_0.XHAcjfYHxobupnkeqiFjdRtqsftl;
				hOOUxyzjPSHmCugYimIocEeoCnOZ = P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ;
				nXGdfezugKPnijHxPqSGMXNvieeu = P_0.nXGdfezugKPnijHxPqSGMXNvieeu;
				iVZXAatNNkoQhakyOcSvPZuywmil = P_0.iVZXAatNNkoQhakyOcSvPZuywmil;
				fRKWXdIcjzUVKxBCLBAxjgTDzHXfA = P_0.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA;
				uXFvVgVvAswDejLdlJrCamssAhoj = P_0.uXFvVgVvAswDejLdlJrCamssAhoj;
				for (int i = 0; i < YrVRqCBdYnMvpzdpuevFnfRkNtEB.Length; i++)
				{
					YrVRqCBdYnMvpzdpuevFnfRkNtEB[i] = P_0.YrVRqCBdYnMvpzdpuevFnfRkNtEB[i];
				}
				for (int j = 0; j < YwGnMOKwAHDLEyCOXcOpCjBCXpNK.Length; j++)
				{
					YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j] = P_0.YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j];
				}
				for (int k = 0; k < syxPbhBJItzVAVLveDKeKXtdjmVVA.Length; k++)
				{
					syxPbhBJItzVAVLveDKeKXtdjmVVA[k] = P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA[k];
				}
				IVGASYlUTQmRAdogTdHGGGSkarzB = P_0.IVGASYlUTQmRAdogTdHGGGSkarzB;
				BokrrSjVfAhYkIQmhzfHRbuAwaHg = P_0.BokrrSjVfAhYkIQmhzfHRbuAwaHg;
				irfbjzGcGIOFNuSIcxqNAnObMqwfA = P_0.irfbjzGcGIOFNuSIcxqNAnObMqwfA;
				MIprVMIPkzUhwQMRTGRBJUKDOEHG = P_0.MIprVMIPkzUhwQMRTGRBJUKDOEHG;
				gHFfmwgurBviMwjylTPNtvFERkueA = P_0.gHFfmwgurBviMwjylTPNtvFERkueA;
				ZJzfzzVoBQcjSbQzJDLBesKHhgrd = P_0.ZJzfzzVoBQcjSbQzJDLBesKHhgrd;
				for (int l = 0; l < bcTvrKOzACMlcKbeYtQASNtoRYNF.Length; l++)
				{
					bcTvrKOzACMlcKbeYtQASNtoRYNF[l] = P_0.bcTvrKOzACMlcKbeYtQASNtoRYNF[l];
				}
				mLaQWAdMKFPMBUGNBffgLOgiOfei = P_0.mLaQWAdMKFPMBUGNBffgLOgiOfei;
				SwbkYdbTEUHqQhNPkvGRnQfJjnBM = P_0.SwbkYdbTEUHqQhNPkvGRnQfJjnBM;
				jZdAQOYvoJwkNAKHfQVbsbezVfmW = P_0.jZdAQOYvoJwkNAKHfQVbsbezVfmW;
				ispeatToHywvYYMSuZWhkGwDnwYp = P_0.ispeatToHywvYYMSuZWhkGwDnwYp;
				IpSfimgoprwpPbvvZHasGFLoyFpU = P_0.IpSfimgoprwpPbvvZHasGFLoyFpU;
				vTBwIFSNkxHsobDCWeicqTmmUnIH = P_0.vTBwIFSNkxHsobDCWeicqTmmUnIH;
				for (int m = 0; m < tkaAtqiNIrFwnbfhpfDKyViuRMGV.Length; m++)
				{
					tkaAtqiNIrFwnbfhpfDKyViuRMGV[m] = P_0.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m];
				}
				taoHjuPyxajupaEHhgrYbSBkwtZo = P_0.taoHjuPyxajupaEHhgrYbSBkwtZo;
				lsBdvuIbCnbembzorkupUPfpqrMG = P_0.lsBdvuIbCnbembzorkupUPfpqrMG;
				qdgKtiruueifuNJqTMRtZTgjWvmn = P_0.qdgKtiruueifuNJqTMRtZTgjWvmn;
				jRBPLEpruUgsqCpLoBAvnjcDbnwlA = P_0.jRBPLEpruUgsqCpLoBAvnjcDbnwlA;
				fMiDgiXVKZbDOKqlvGclhoBcUCoDB = P_0.fMiDgiXVKZbDOKqlvGclhoBcUCoDB;
				KdwAVnhDDPrFtJAllRAkceDPAadz = P_0.KdwAVnhDDPrFtJAllRAkceDPAadz;
				for (int n = 0; n < bbzjSUmzCpvKeztqjjpYuJViWzaP.Length; n++)
				{
					bbzjSUmzCpvKeztqjjpYuJViWzaP[n] = P_0.bbzjSUmzCpvKeztqjjpYuJViWzaP[n];
				}
			}

			public unsafe void xQEFQkhJhvnmwGSMyzYdziphFTng(ref LowLevelInputEvent P_0)
			{
				for (int i = 0; i < 4; i++)
				{
					int num = *(int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_buttonsStart + i * 4);
					for (int j = 0; j < 32; j++)
					{
						syxPbhBJItzVAVLveDKeKXtdjmVVA[i * 32 + j] = (num & (1 << j)) != 0;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_0._buffer + P_0.byteIndex_axesStart);
				for (int k = 0; k < 2; k++)
				{
					tkaAtqiNIrFwnbfhpfDKyViuRMGV[k] = *ptr;
					ptr++;
				}
				mLaQWAdMKFPMBUGNBffgLOgiOfei = *ptr;
				ptr++;
				SwbkYdbTEUHqQhNPkvGRnQfJjnBM = *ptr;
				ptr++;
				jZdAQOYvoJwkNAKHfQVbsbezVfmW = *ptr;
				ptr++;
				ispeatToHywvYYMSuZWhkGwDnwYp = *ptr;
				ptr++;
				IpSfimgoprwpPbvvZHasGFLoyFpU = *ptr;
				ptr++;
				vTBwIFSNkxHsobDCWeicqTmmUnIH = *ptr;
				ptr++;
				MIprVMIPkzUhwQMRTGRBJUKDOEHG = *ptr;
				ptr++;
				gHFfmwgurBviMwjylTPNtvFERkueA = *ptr;
				ptr++;
				ZJzfzzVoBQcjSbQzJDLBesKHhgrd = *ptr;
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					bbzjSUmzCpvKeztqjjpYuJViWzaP[l] = *ptr;
					ptr++;
				}
				taoHjuPyxajupaEHhgrYbSBkwtZo = *ptr;
				ptr++;
				lsBdvuIbCnbembzorkupUPfpqrMG = *ptr;
				ptr++;
				qdgKtiruueifuNJqTMRtZTgjWvmn = *ptr;
				ptr++;
				iVZXAatNNkoQhakyOcSvPZuywmil = *ptr;
				ptr++;
				fRKWXdIcjzUVKxBCLBAxjgTDzHXfA = *ptr;
				ptr++;
				uXFvVgVvAswDejLdlJrCamssAhoj = *ptr;
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					YrVRqCBdYnMvpzdpuevFnfRkNtEB[m] = *ptr;
					ptr++;
				}
				jRBPLEpruUgsqCpLoBAvnjcDbnwlA = *ptr;
				ptr++;
				fMiDgiXVKZbDOKqlvGclhoBcUCoDB = *ptr;
				ptr++;
				KdwAVnhDDPrFtJAllRAkceDPAadz = *ptr;
				ptr++;
				for (int n = 0; n < 2; n++)
				{
					bcTvrKOzACMlcKbeYtQASNtoRYNF[n] = *ptr;
					ptr++;
				}
				IVGASYlUTQmRAdogTdHGGGSkarzB = *ptr;
				ptr++;
				BokrrSjVfAhYkIQmhzfHRbuAwaHg = *ptr;
				ptr++;
				irfbjzGcGIOFNuSIcxqNAnObMqwfA = *ptr;
				ptr++;
				XHAcjfYHxobupnkeqiFjdRtqsftl = *ptr;
				ptr++;
				hOOUxyzjPSHmCugYimIocEeoCnOZ = *ptr;
				ptr++;
				nXGdfezugKPnijHxPqSGMXNvieeu = *ptr;
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_0._buffer + P_0.byteIndex_hatsStart);
				for (int num2 = 0; num2 < 2; num2++)
				{
					YwGnMOKwAHDLEyCOXcOpCjBCXpNK[num2] = *ptr2;
					ptr2++;
				}
			}

			public unsafe static void GjUtnbOqtdoQjQdFRevOEBNRHwaJ(voxoBYAimrcIeQjtgwMxLKYrrGIu P_0, double P_1, LowLevelInputEvent P_2)
			{
				int[] array = P_0.YwGnMOKwAHDLEyCOXcOpCjBCXpNK;
				int[] array2 = P_0.tkaAtqiNIrFwnbfhpfDKyViuRMGV;
				int[] array3 = P_0.bbzjSUmzCpvKeztqjjpYuJViWzaP;
				int[] array4 = P_0.YrVRqCBdYnMvpzdpuevFnfRkNtEB;
				int[] array5 = P_0.bcTvrKOzACMlcKbeYtQASNtoRYNF;
				*(double*)((byte*)(void*)P_2._buffer + 4) = P_1;
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < 128; i++)
				{
					if (P_0.syxPbhBJItzVAVLveDKeKXtdjmVVA[i])
					{
						num |= 1 << num3;
					}
					num3++;
					if (num3 == 32)
					{
						*(int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_buttonsStart + num2 * 4) = num;
						num3 = 0;
						num = 0;
						num2++;
					}
				}
				float* ptr = (float*)((byte*)(void*)P_2._buffer + P_2.byteIndex_axesStart);
				for (int j = 0; j < 2; j++)
				{
					*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(array2[j]);
					ptr++;
				}
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.mLaQWAdMKFPMBUGNBffgLOgiOfei);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.SwbkYdbTEUHqQhNPkvGRnQfJjnBM);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.jZdAQOYvoJwkNAKHfQVbsbezVfmW);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.ispeatToHywvYYMSuZWhkGwDnwYp);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.IpSfimgoprwpPbvvZHasGFLoyFpU);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.vTBwIFSNkxHsobDCWeicqTmmUnIH);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.MIprVMIPkzUhwQMRTGRBJUKDOEHG);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.gHFfmwgurBviMwjylTPNtvFERkueA);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.ZJzfzzVoBQcjSbQzJDLBesKHhgrd);
				ptr++;
				for (int k = 0; k < 2; k++)
				{
					*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(array3[k]);
					ptr++;
				}
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.taoHjuPyxajupaEHhgrYbSBkwtZo);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.lsBdvuIbCnbembzorkupUPfpqrMG);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.qdgKtiruueifuNJqTMRtZTgjWvmn);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.iVZXAatNNkoQhakyOcSvPZuywmil);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.uXFvVgVvAswDejLdlJrCamssAhoj);
				ptr++;
				for (int l = 0; l < 2; l++)
				{
					*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(array4[l]);
					ptr++;
				}
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.jRBPLEpruUgsqCpLoBAvnjcDbnwlA);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.fMiDgiXVKZbDOKqlvGclhoBcUCoDB);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.KdwAVnhDDPrFtJAllRAkceDPAadz);
				ptr++;
				for (int m = 0; m < 2; m++)
				{
					*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(array5[m]);
					ptr++;
				}
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.IVGASYlUTQmRAdogTdHGGGSkarzB);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.BokrrSjVfAhYkIQmhzfHRbuAwaHg);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.irfbjzGcGIOFNuSIcxqNAnObMqwfA);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.XHAcjfYHxobupnkeqiFjdRtqsftl);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.hOOUxyzjPSHmCugYimIocEeoCnOZ);
				ptr++;
				*ptr = XkqINHLcERmXREsNUNSKIBnJXSoW(P_0.nXGdfezugKPnijHxPqSGMXNvieeu);
				ptr++;
				int* ptr2 = (int*)((byte*)(void*)P_2._buffer + P_2.byteIndex_hatsStart);
				for (int n = 0; n < 2; n++)
				{
					*ptr2 = array[n];
					ptr2++;
				}
			}
		}

		private const int ucdkDSAsvFmiooOjCIaxcErptgJ = 2;

		private const int UyBiQONKkfsvLkIQiPZDTPhYRIgn = 2;

		private const int zxygpBLWJDxddDSJGxykejiGutil = 128;

		private const int UnCPRCffFLOKTZlAqxGAyAMuGKmP = 32;

		private const int emHjgXhmElNJnQdjkoedmexatoLo = 0;

		private const int WIgtMvudrInuQxazYXJDhjopkICe = 264;

		private const int kZXkhralzsFlYtiNeYeGcEKbcCqq = 272;

		private readonly int XFqyuIXXwYtilNlsUDPnkhXyjWJHA;

		private readonly ButtonLoopSet NAMTrcvXYLWpIwbVCKZHcEYqDTzA;

		private readonly DualThreadLowLevelInputEventQueue DXVcjbZjUAQdtqWkXPrhBFajPqfl;

		private cGuhOUaeubOAAGZKGLYnrOlmnpRK ZOTLDrpquaRjWSBCcqvxSjwqOEas;

		private readonly voxoBYAimrcIeQjtgwMxLKYrrGIu obbqrfSOjLCiFaYBtKNTOLPrPRCCb;

		private readonly voxoBYAimrcIeQjtgwMxLKYrrGIu deSiYjaDIIirrpGiSlvWSkTulbJb;

		private readonly object BpzGDRTfGRflSHRbmBgWlnkTHLSfb;

		private bool TMhWxnShuMufpLHxxppPFLwtRKYC;

		public readonly TGMNVgEkzYRUJhRlmEORKKDOgVur gpRRWpNgaNJmzGbrEaNwChwYyxtY;

		private readonly FCpTLLPNBFudwAHyuQPClGyXDyBCA rYISxrxyWrFhSXQWWHQqsQJXZsYe;

		private bool JWXwfaUAOJsMCNExsMKmFgNcBZSc;

		public bool[] xJOAbibiwiGxgsdpcdMYjGrEAZZwb => NAMTrcvXYLWpIwbVCKZHcEYqDTzA.Current.effectiveValue;

		public FCpTLLPNBFudwAHyuQPClGyXDyBCA OvLGkmnTcGacGJDgvbfNZOhTArsI => rYISxrxyWrFhSXQWWHQqsQJXZsYe;

		public xNSYRpDpIMbnNUHRXFGqeEMHBNJH(TGMNVgEkzYRUJhRlmEORKKDOgVur P_0, UpdateLoopSetting P_1)
		{
			gpRRWpNgaNJmzGbrEaNwChwYyxtY = P_0;
			XFqyuIXXwYtilNlsUDPnkhXyjWJHA = P_0.gSKbQhPhCcxFkHCLeYWmJrvPjhbK.JVqCHAvnctFGSlUdMoFcLkcNXrDA;
			NAMTrcvXYLWpIwbVCKZHcEYqDTzA = new ButtonLoopSet(P_1, XFqyuIXXwYtilNlsUDPnkhXyjWJHA);
			DXVcjbZjUAQdtqWkXPrhBFajPqfl = new DualThreadLowLevelInputEventQueue((int)((float)YMIsqNPkWjrdLcJvEeLWjHNzddLY.BKENsSJCwPFOTXkHKUNFIlpBJfYC * 0.25f), 128, 32, 2);
			rYISxrxyWrFhSXQWWHQqsQJXZsYe = new FCpTLLPNBFudwAHyuQPClGyXDyBCA();
			obbqrfSOjLCiFaYBtKNTOLPrPRCCb = new voxoBYAimrcIeQjtgwMxLKYrrGIu();
			deSiYjaDIIirrpGiSlvWSkTulbJb = new voxoBYAimrcIeQjtgwMxLKYrrGIu();
			BpzGDRTfGRflSHRbmBgWlnkTHLSfb = new object();
			if (YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi != null)
			{
				YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi.ThreadUpdateEvent += dzbhUNdQxAXwmaJEOPDmDUFfjPaHc;
			}
		}

		public void qfnucLqflxALQiRYVXsitLqJNSuab()
		{
			NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetUpdateLoop(ReInput.currentUpdateLoop);
			tCefUHaBYCZBfMTVNnNrdcueqDoC();
		}

		public void MqQjLCryqEPDlgJVxyKAVvUubRHs()
		{
			NAMTrcvXYLWpIwbVCKZHcEYqDTzA.Current.ClearWasTrueThisFrame();
		}

		public void unNSIaykSfpkHNEmGhtmxbrGklvQ()
		{
			wSuERjejnukorMpeyvWlfiOlJujf();
			TMhWxnShuMufpLHxxppPFLwtRKYC = true;
		}

		public void VPIjVdphVhWzoYvDXKaLpKYEwKDW()
		{
			TMhWxnShuMufpLHxxppPFLwtRKYC = false;
			wSuERjejnukorMpeyvWlfiOlJujf();
		}

		public void OLfmjaYQlzgJtGmEIVCoLPHHLIfZ(xNSYRpDpIMbnNUHRXFGqeEMHBNJH P_0)
		{
			if (P_0 == null || P_0 == this || P_0.XFqyuIXXwYtilNlsUDPnkhXyjWJHA != XFqyuIXXwYtilNlsUDPnkhXyjWJHA)
			{
				return;
			}
			_ = ReInput.realTime;
			lock (BpzGDRTfGRflSHRbmBgWlnkTHLSfb)
			{
				lock (P_0.BpzGDRTfGRflSHRbmBgWlnkTHLSfb)
				{
					NAMTrcvXYLWpIwbVCKZHcEYqDTzA.Import(P_0.NAMTrcvXYLWpIwbVCKZHcEYqDTzA);
					rYISxrxyWrFhSXQWWHQqsQJXZsYe.xQEFQkhJhvnmwGSMyzYdziphFTng(P_0.rYISxrxyWrFhSXQWWHQqsQJXZsYe);
					obbqrfSOjLCiFaYBtKNTOLPrPRCCb.xQEFQkhJhvnmwGSMyzYdziphFTng(P_0.obbqrfSOjLCiFaYBtKNTOLPrPRCCb);
					deSiYjaDIIirrpGiSlvWSkTulbJb.xQEFQkhJhvnmwGSMyzYdziphFTng(P_0.deSiYjaDIIirrpGiSlvWSkTulbJb);
					DXVcjbZjUAQdtqWkXPrhBFajPqfl.ImportAll(P_0.DXVcjbZjUAQdtqWkXPrhBFajPqfl);
					ZOTLDrpquaRjWSBCcqvxSjwqOEas = cGuhOUaeubOAAGZKGLYnrOlmnpRK.jrORvPmqIXxRDMWmoCpPlTRUCXkg(P_0.ZOTLDrpquaRjWSBCcqvxSjwqOEas, obbqrfSOjLCiFaYBtKNTOLPrPRCCb);
					TMhWxnShuMufpLHxxppPFLwtRKYC = P_0.TMhWxnShuMufpLHxxppPFLwtRKYC;
				}
			}
		}

		public void xzjJyMPCOaiegrSPtDMBGgzXDynKA(int P_0, int P_1, int P_2, float P_3)
		{
			lock (BpzGDRTfGRflSHRbmBgWlnkTHLSfb)
			{
				ZOTLDrpquaRjWSBCcqvxSjwqOEas = new cGuhOUaeubOAAGZKGLYnrOlmnpRK(obbqrfSOjLCiFaYBtKNTOLPrPRCCb, P_0, P_1, P_2, P_3);
			}
		}

		private void dzbhUNdQxAXwmaJEOPDmDUFfjPaHc()
		{
			if (!TMhWxnShuMufpLHxxppPFLwtRKYC)
			{
				return;
			}
			double realTime;
			try
			{
				gpRRWpNgaNJmzGbrEaNwChwYyxtY.SAmxjpctAviGDToTcWBOijMRCsCC(obbqrfSOjLCiFaYBtKNTOLPrPRCCb);
				realTime = ReInput.realTime;
			}
			catch
			{
				return;
			}
			lock (BpzGDRTfGRflSHRbmBgWlnkTHLSfb)
			{
				if (ZOTLDrpquaRjWSBCcqvxSjwqOEas != null)
				{
					ZOTLDrpquaRjWSBCcqvxSjwqOEas.mefhGqvTkcrETnFSidhNngFjAYNV(realTime);
				}
				if (!obbqrfSOjLCiFaYBtKNTOLPrPRCCb.KaznOpFTaqhaZolaTsvdUUvLrdxT(deSiYjaDIIirrpGiSlvWSkTulbJb))
				{
					using (DualThreadLowLevelInputEventQueue.INewEventWrapper newEventWrapper = DXVcjbZjUAQdtqWkXPrhBFajPqfl.T_CreateEvent())
					{
						FCpTLLPNBFudwAHyuQPClGyXDyBCA.GjUtnbOqtdoQjQdFRevOEBNRHwaJ(obbqrfSOjLCiFaYBtKNTOLPrPRCCb, realTime, newEventWrapper.Event);
					}
					deSiYjaDIIirrpGiSlvWSkTulbJb.xQEFQkhJhvnmwGSMyzYdziphFTng(obbqrfSOjLCiFaYBtKNTOLPrPRCCb);
				}
			}
		}

		private void tCefUHaBYCZBfMTVNnNrdcueqDoC()
		{
			while (DXVcjbZjUAQdtqWkXPrhBFajPqfl.ProcessNewEvents())
			{
				rYISxrxyWrFhSXQWWHQqsQJXZsYe.xQEFQkhJhvnmwGSMyzYdziphFTng(ref DXVcjbZjUAQdtqWkXPrhBFajPqfl.currentEvent);
				for (int i = 0; i < XFqyuIXXwYtilNlsUDPnkhXyjWJHA; i++)
				{
					NAMTrcvXYLWpIwbVCKZHcEYqDTzA.SetValue(i, rYISxrxyWrFhSXQWWHQqsQJXZsYe.syxPbhBJItzVAVLveDKeKXtdjmVVA[i], DXVcjbZjUAQdtqWkXPrhBFajPqfl.currentEvent.GetTimestamp());
				}
			}
		}

		private void wSuERjejnukorMpeyvWlfiOlJujf()
		{
			rYISxrxyWrFhSXQWWHQqsQJXZsYe.DwNKXiEShimVDUzntAObjUXyaFmo();
			lock (BpzGDRTfGRflSHRbmBgWlnkTHLSfb)
			{
				obbqrfSOjLCiFaYBtKNTOLPrPRCCb.DwNKXiEShimVDUzntAObjUXyaFmo();
				deSiYjaDIIirrpGiSlvWSkTulbJb.DwNKXiEShimVDUzntAObjUXyaFmo();
				DXVcjbZjUAQdtqWkXPrhBFajPqfl.Clear();
			}
			NAMTrcvXYLWpIwbVCKZHcEYqDTzA.Clear();
		}

		public void Dispose()
		{
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
		{
			try
			{
				vCBFvIdHsbAnKBZkroQOsRrLIAyV(false);
			}
			finally
			{
				base.Finalize();
			}
		}

		protected virtual void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0)
		{
			if (!JWXwfaUAOJsMCNExsMKmFgNcBZSc)
			{
				if (P_0)
				{
					VPIjVdphVhWzoYvDXKaLpKYEwKDW();
					DXVcjbZjUAQdtqWkXPrhBFajPqfl.Dispose();
				}
				if (YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi != null)
				{
					YMIsqNPkWjrdLcJvEeLWjHNzddLY.RiiNBuDyqUdVNZGxijqmyUOsLcUi.ThreadUpdateEvent -= dzbhUNdQxAXwmaJEOPDmDUFfjPaHc;
				}
				JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
			}
		}

		private static float XkqINHLcERmXREsNUNSKIBnJXSoW(int P_0)
		{
			if (P_0 == 0)
			{
				return 0f;
			}
			return MathTools.Clamp((float)MathTools.Abs(P_0) / 65535f * (float)MathTools.Sign(P_0), -1f, 1f);
		}
	}

	private class cGuhOUaeubOAAGZKGLYnrOlmnpRK
	{
		private voxoBYAimrcIeQjtgwMxLKYrrGIu guiNwAixOsKxApddYjoviMgEnSKOA;

		private JpBrPaLLhhCkCkXZIhuyIfuSiSId MLLiNXkWwkpKJRSYzIpPOitplecO;

		private int szcIkdJDxXZYDHGDjgIpwtqvOBpC;

		private int xUrokfNAfSjawOQusZtPoAtDfjZd;

		private int xagFvTawRAxZTsxLRtaKXnBhNgDB;

		private float zXXOhfVZBYFbRNPpqkhrMdYfYpli;

		public voxoBYAimrcIeQjtgwMxLKYrrGIu PSXmUcWexXbxODmXGsTWpIwAjFVi => guiNwAixOsKxApddYjoviMgEnSKOA;

		public static cGuhOUaeubOAAGZKGLYnrOlmnpRK jrORvPmqIXxRDMWmoCpPlTRUCXkg(cGuhOUaeubOAAGZKGLYnrOlmnpRK P_0, voxoBYAimrcIeQjtgwMxLKYrrGIu P_1)
		{
			if (P_0 == null || P_1 == null)
			{
				return null;
			}
			return new cGuhOUaeubOAAGZKGLYnrOlmnpRK(P_0, P_1);
		}

		public cGuhOUaeubOAAGZKGLYnrOlmnpRK(voxoBYAimrcIeQjtgwMxLKYrrGIu P_0, int P_1, int P_2, int P_3, float P_4)
			: this(P_1, P_2, P_3, P_4)
		{
			MLLiNXkWwkpKJRSYzIpPOitplecO = new JpBrPaLLhhCkCkXZIhuyIfuSiSId(P_0);
			guiNwAixOsKxApddYjoviMgEnSKOA = new voxoBYAimrcIeQjtgwMxLKYrrGIu();
		}

		private cGuhOUaeubOAAGZKGLYnrOlmnpRK(cGuhOUaeubOAAGZKGLYnrOlmnpRK P_0, voxoBYAimrcIeQjtgwMxLKYrrGIu P_1)
			: this(P_1, P_0.szcIkdJDxXZYDHGDjgIpwtqvOBpC, P_0.xUrokfNAfSjawOQusZtPoAtDfjZd, P_0.xagFvTawRAxZTsxLRtaKXnBhNgDB, P_0.zXXOhfVZBYFbRNPpqkhrMdYfYpli)
		{
			xQEFQkhJhvnmwGSMyzYdziphFTng(P_0);
		}

		private cGuhOUaeubOAAGZKGLYnrOlmnpRK(int P_0, int P_1, int P_2, float P_3)
		{
			szcIkdJDxXZYDHGDjgIpwtqvOBpC = P_0;
			xUrokfNAfSjawOQusZtPoAtDfjZd = P_1;
			xagFvTawRAxZTsxLRtaKXnBhNgDB = P_2;
			zXXOhfVZBYFbRNPpqkhrMdYfYpli = P_3;
		}

		public void mefhGqvTkcrETnFSidhNngFjAYNV(double P_0)
		{
			MLLiNXkWwkpKJRSYzIpPOitplecO.mefhGqvTkcrETnFSidhNngFjAYNV(P_0);
			if (!MLLiNXkWwkpKJRSYzIpPOitplecO.CSTRaPUqVzKSxkzMvaKtahezTftG)
			{
				if (P_0 >= MLLiNXkWwkpKJRSYzIpPOitplecO.sJvCCTGiYfZdOviLWcudCLXCVAjpc + (double)zXXOhfVZBYFbRNPpqkhrMdYfYpli)
				{
					guiNwAixOsKxApddYjoviMgEnSKOA.DwNKXiEShimVDUzntAObjUXyaFmo();
				}
				return;
			}
			voxoBYAimrcIeQjtgwMxLKYrrGIu voxoBYAimrcIeQjtgwMxLKYrrGIu2 = MLLiNXkWwkpKJRSYzIpPOitplecO.pcoLavwDBumOxjIfcWueWRfkIfsc;
			voxoBYAimrcIeQjtgwMxLKYrrGIu voxoBYAimrcIeQjtgwMxLKYrrGIu3 = MLLiNXkWwkpKJRSYzIpPOitplecO.NgqgDrekKwzqajWTVjmaijPKShZJ;
			guiNwAixOsKxApddYjoviMgEnSKOA.XHAcjfYHxobupnkeqiFjdRtqsftl = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.XHAcjfYHxobupnkeqiFjdRtqsftl);
			guiNwAixOsKxApddYjoviMgEnSKOA.hOOUxyzjPSHmCugYimIocEeoCnOZ = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.hOOUxyzjPSHmCugYimIocEeoCnOZ);
			guiNwAixOsKxApddYjoviMgEnSKOA.nXGdfezugKPnijHxPqSGMXNvieeu = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.nXGdfezugKPnijHxPqSGMXNvieeu);
			guiNwAixOsKxApddYjoviMgEnSKOA.iVZXAatNNkoQhakyOcSvPZuywmil = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.iVZXAatNNkoQhakyOcSvPZuywmil);
			guiNwAixOsKxApddYjoviMgEnSKOA.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA);
			guiNwAixOsKxApddYjoviMgEnSKOA.uXFvVgVvAswDejLdlJrCamssAhoj = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.uXFvVgVvAswDejLdlJrCamssAhoj);
			for (int i = 0; i < guiNwAixOsKxApddYjoviMgEnSKOA.YrVRqCBdYnMvpzdpuevFnfRkNtEB.Length; i++)
			{
				guiNwAixOsKxApddYjoviMgEnSKOA.YrVRqCBdYnMvpzdpuevFnfRkNtEB[i] = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.YrVRqCBdYnMvpzdpuevFnfRkNtEB[i]);
			}
			for (int j = 0; j < guiNwAixOsKxApddYjoviMgEnSKOA.YwGnMOKwAHDLEyCOXcOpCjBCXpNK.Length; j++)
			{
				guiNwAixOsKxApddYjoviMgEnSKOA.YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j] = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j]);
			}
			for (int k = 0; k < guiNwAixOsKxApddYjoviMgEnSKOA.syxPbhBJItzVAVLveDKeKXtdjmVVA.Length; k++)
			{
				guiNwAixOsKxApddYjoviMgEnSKOA.syxPbhBJItzVAVLveDKeKXtdjmVVA[k] = voxoBYAimrcIeQjtgwMxLKYrrGIu3.syxPbhBJItzVAVLveDKeKXtdjmVVA[k];
			}
			guiNwAixOsKxApddYjoviMgEnSKOA.IVGASYlUTQmRAdogTdHGGGSkarzB = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.IVGASYlUTQmRAdogTdHGGGSkarzB);
			guiNwAixOsKxApddYjoviMgEnSKOA.BokrrSjVfAhYkIQmhzfHRbuAwaHg = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.BokrrSjVfAhYkIQmhzfHRbuAwaHg);
			guiNwAixOsKxApddYjoviMgEnSKOA.irfbjzGcGIOFNuSIcxqNAnObMqwfA = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.irfbjzGcGIOFNuSIcxqNAnObMqwfA);
			guiNwAixOsKxApddYjoviMgEnSKOA.MIprVMIPkzUhwQMRTGRBJUKDOEHG = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.MIprVMIPkzUhwQMRTGRBJUKDOEHG);
			guiNwAixOsKxApddYjoviMgEnSKOA.gHFfmwgurBviMwjylTPNtvFERkueA = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.gHFfmwgurBviMwjylTPNtvFERkueA);
			guiNwAixOsKxApddYjoviMgEnSKOA.ZJzfzzVoBQcjSbQzJDLBesKHhgrd = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.ZJzfzzVoBQcjSbQzJDLBesKHhgrd);
			for (int l = 0; l < guiNwAixOsKxApddYjoviMgEnSKOA.bcTvrKOzACMlcKbeYtQASNtoRYNF.Length; l++)
			{
				guiNwAixOsKxApddYjoviMgEnSKOA.bcTvrKOzACMlcKbeYtQASNtoRYNF[l] = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.bcTvrKOzACMlcKbeYtQASNtoRYNF[l]);
			}
			guiNwAixOsKxApddYjoviMgEnSKOA.mLaQWAdMKFPMBUGNBffgLOgiOfei = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.mLaQWAdMKFPMBUGNBffgLOgiOfei);
			guiNwAixOsKxApddYjoviMgEnSKOA.SwbkYdbTEUHqQhNPkvGRnQfJjnBM = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.SwbkYdbTEUHqQhNPkvGRnQfJjnBM);
			guiNwAixOsKxApddYjoviMgEnSKOA.jZdAQOYvoJwkNAKHfQVbsbezVfmW = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.jZdAQOYvoJwkNAKHfQVbsbezVfmW);
			guiNwAixOsKxApddYjoviMgEnSKOA.ispeatToHywvYYMSuZWhkGwDnwYp = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.ispeatToHywvYYMSuZWhkGwDnwYp);
			guiNwAixOsKxApddYjoviMgEnSKOA.IpSfimgoprwpPbvvZHasGFLoyFpU = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.IpSfimgoprwpPbvvZHasGFLoyFpU);
			guiNwAixOsKxApddYjoviMgEnSKOA.vTBwIFSNkxHsobDCWeicqTmmUnIH = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.vTBwIFSNkxHsobDCWeicqTmmUnIH);
			for (int m = 0; m < guiNwAixOsKxApddYjoviMgEnSKOA.tkaAtqiNIrFwnbfhpfDKyViuRMGV.Length; m++)
			{
				guiNwAixOsKxApddYjoviMgEnSKOA.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m] = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m]);
			}
			guiNwAixOsKxApddYjoviMgEnSKOA.taoHjuPyxajupaEHhgrYbSBkwtZo = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.taoHjuPyxajupaEHhgrYbSBkwtZo);
			guiNwAixOsKxApddYjoviMgEnSKOA.lsBdvuIbCnbembzorkupUPfpqrMG = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.lsBdvuIbCnbembzorkupUPfpqrMG);
			guiNwAixOsKxApddYjoviMgEnSKOA.qdgKtiruueifuNJqTMRtZTgjWvmn = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.qdgKtiruueifuNJqTMRtZTgjWvmn);
			guiNwAixOsKxApddYjoviMgEnSKOA.jRBPLEpruUgsqCpLoBAvnjcDbnwlA = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.jRBPLEpruUgsqCpLoBAvnjcDbnwlA);
			guiNwAixOsKxApddYjoviMgEnSKOA.fMiDgiXVKZbDOKqlvGclhoBcUCoDB = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.fMiDgiXVKZbDOKqlvGclhoBcUCoDB);
			guiNwAixOsKxApddYjoviMgEnSKOA.KdwAVnhDDPrFtJAllRAkceDPAadz = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.KdwAVnhDDPrFtJAllRAkceDPAadz);
			for (int n = 0; n < guiNwAixOsKxApddYjoviMgEnSKOA.bbzjSUmzCpvKeztqjjpYuJViWzaP.Length; n++)
			{
				guiNwAixOsKxApddYjoviMgEnSKOA.bbzjSUmzCpvKeztqjjpYuJViWzaP[n] = jscfCtZgjxOWqogeGaJrDCyvcuKp(voxoBYAimrcIeQjtgwMxLKYrrGIu2.bbzjSUmzCpvKeztqjjpYuJViWzaP[n]);
			}
		}

		public void xQEFQkhJhvnmwGSMyzYdziphFTng(cGuhOUaeubOAAGZKGLYnrOlmnpRK P_0)
		{
			guiNwAixOsKxApddYjoviMgEnSKOA.xQEFQkhJhvnmwGSMyzYdziphFTng(P_0.guiNwAixOsKxApddYjoviMgEnSKOA);
			MLLiNXkWwkpKJRSYzIpPOitplecO.xQEFQkhJhvnmwGSMyzYdziphFTng(P_0.MLLiNXkWwkpKJRSYzIpPOitplecO);
			szcIkdJDxXZYDHGDjgIpwtqvOBpC = P_0.szcIkdJDxXZYDHGDjgIpwtqvOBpC;
			xUrokfNAfSjawOQusZtPoAtDfjZd = P_0.xUrokfNAfSjawOQusZtPoAtDfjZd;
			xagFvTawRAxZTsxLRtaKXnBhNgDB = P_0.xagFvTawRAxZTsxLRtaKXnBhNgDB;
			zXXOhfVZBYFbRNPpqkhrMdYfYpli = P_0.zXXOhfVZBYFbRNPpqkhrMdYfYpli;
		}

		private int jscfCtZgjxOWqogeGaJrDCyvcuKp(int P_0)
		{
			return MathTools.ValueInNewRange(P_0, szcIkdJDxXZYDHGDjgIpwtqvOBpC, xUrokfNAfSjawOQusZtPoAtDfjZd, -65535, 65535);
		}
	}

	private class JpBrPaLLhhCkCkXZIhuyIfuSiSId
	{
		private double UqVPGpfdnnuOqMQpSlSNNcVildku;

		private voxoBYAimrcIeQjtgwMxLKYrrGIu zfHovgugniYvLghndOyJTDcnKzoO;

		private voxoBYAimrcIeQjtgwMxLKYrrGIu shFAPPkiCHZRcKxfmRBVTKAewSYx;

		private voxoBYAimrcIeQjtgwMxLKYrrGIu itCzAzqOcCXysVnBoAhkLGhLcgQA;

		private bool DWomFyPzgLCicGcgOetubtsKXbGy;

		private double NYncusvLyyjkTCoKlZBrZMuEuwoq;

		public voxoBYAimrcIeQjtgwMxLKYrrGIu NgqgDrekKwzqajWTVjmaijPKShZJ => zfHovgugniYvLghndOyJTDcnKzoO;

		public voxoBYAimrcIeQjtgwMxLKYrrGIu pcoLavwDBumOxjIfcWueWRfkIfsc => itCzAzqOcCXysVnBoAhkLGhLcgQA;

		public bool CSTRaPUqVzKSxkzMvaKtahezTftG => DWomFyPzgLCicGcgOetubtsKXbGy;

		public double sJvCCTGiYfZdOviLWcudCLXCVAjpc => NYncusvLyyjkTCoKlZBrZMuEuwoq;

		public JpBrPaLLhhCkCkXZIhuyIfuSiSId(voxoBYAimrcIeQjtgwMxLKYrrGIu P_0)
		{
			zfHovgugniYvLghndOyJTDcnKzoO = P_0;
			shFAPPkiCHZRcKxfmRBVTKAewSYx = new voxoBYAimrcIeQjtgwMxLKYrrGIu();
			itCzAzqOcCXysVnBoAhkLGhLcgQA = new voxoBYAimrcIeQjtgwMxLKYrrGIu();
		}

		public void mefhGqvTkcrETnFSidhNngFjAYNV(double P_0)
		{
			UqVPGpfdnnuOqMQpSlSNNcVildku = P_0;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.XHAcjfYHxobupnkeqiFjdRtqsftl = zfHovgugniYvLghndOyJTDcnKzoO.XHAcjfYHxobupnkeqiFjdRtqsftl - shFAPPkiCHZRcKxfmRBVTKAewSYx.XHAcjfYHxobupnkeqiFjdRtqsftl;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.hOOUxyzjPSHmCugYimIocEeoCnOZ = zfHovgugniYvLghndOyJTDcnKzoO.hOOUxyzjPSHmCugYimIocEeoCnOZ - shFAPPkiCHZRcKxfmRBVTKAewSYx.hOOUxyzjPSHmCugYimIocEeoCnOZ;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.nXGdfezugKPnijHxPqSGMXNvieeu = zfHovgugniYvLghndOyJTDcnKzoO.nXGdfezugKPnijHxPqSGMXNvieeu - shFAPPkiCHZRcKxfmRBVTKAewSYx.nXGdfezugKPnijHxPqSGMXNvieeu;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.iVZXAatNNkoQhakyOcSvPZuywmil = zfHovgugniYvLghndOyJTDcnKzoO.iVZXAatNNkoQhakyOcSvPZuywmil - shFAPPkiCHZRcKxfmRBVTKAewSYx.iVZXAatNNkoQhakyOcSvPZuywmil;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA = zfHovgugniYvLghndOyJTDcnKzoO.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA - shFAPPkiCHZRcKxfmRBVTKAewSYx.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.uXFvVgVvAswDejLdlJrCamssAhoj = zfHovgugniYvLghndOyJTDcnKzoO.uXFvVgVvAswDejLdlJrCamssAhoj - shFAPPkiCHZRcKxfmRBVTKAewSYx.uXFvVgVvAswDejLdlJrCamssAhoj;
			for (int i = 0; i < zfHovgugniYvLghndOyJTDcnKzoO.YrVRqCBdYnMvpzdpuevFnfRkNtEB.Length; i++)
			{
				itCzAzqOcCXysVnBoAhkLGhLcgQA.YrVRqCBdYnMvpzdpuevFnfRkNtEB[i] = zfHovgugniYvLghndOyJTDcnKzoO.YrVRqCBdYnMvpzdpuevFnfRkNtEB[i] - shFAPPkiCHZRcKxfmRBVTKAewSYx.YrVRqCBdYnMvpzdpuevFnfRkNtEB[i];
			}
			for (int j = 0; j < zfHovgugniYvLghndOyJTDcnKzoO.YwGnMOKwAHDLEyCOXcOpCjBCXpNK.Length; j++)
			{
				itCzAzqOcCXysVnBoAhkLGhLcgQA.YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j] = zfHovgugniYvLghndOyJTDcnKzoO.YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j] - shFAPPkiCHZRcKxfmRBVTKAewSYx.YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j];
			}
			for (int k = 0; k < zfHovgugniYvLghndOyJTDcnKzoO.syxPbhBJItzVAVLveDKeKXtdjmVVA.Length; k++)
			{
				itCzAzqOcCXysVnBoAhkLGhLcgQA.syxPbhBJItzVAVLveDKeKXtdjmVVA[k] = zfHovgugniYvLghndOyJTDcnKzoO.syxPbhBJItzVAVLveDKeKXtdjmVVA[k] != shFAPPkiCHZRcKxfmRBVTKAewSYx.syxPbhBJItzVAVLveDKeKXtdjmVVA[k];
			}
			itCzAzqOcCXysVnBoAhkLGhLcgQA.IVGASYlUTQmRAdogTdHGGGSkarzB = zfHovgugniYvLghndOyJTDcnKzoO.IVGASYlUTQmRAdogTdHGGGSkarzB - shFAPPkiCHZRcKxfmRBVTKAewSYx.IVGASYlUTQmRAdogTdHGGGSkarzB;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.BokrrSjVfAhYkIQmhzfHRbuAwaHg = zfHovgugniYvLghndOyJTDcnKzoO.BokrrSjVfAhYkIQmhzfHRbuAwaHg - shFAPPkiCHZRcKxfmRBVTKAewSYx.BokrrSjVfAhYkIQmhzfHRbuAwaHg;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.irfbjzGcGIOFNuSIcxqNAnObMqwfA = zfHovgugniYvLghndOyJTDcnKzoO.irfbjzGcGIOFNuSIcxqNAnObMqwfA - shFAPPkiCHZRcKxfmRBVTKAewSYx.irfbjzGcGIOFNuSIcxqNAnObMqwfA;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.MIprVMIPkzUhwQMRTGRBJUKDOEHG = zfHovgugniYvLghndOyJTDcnKzoO.MIprVMIPkzUhwQMRTGRBJUKDOEHG - shFAPPkiCHZRcKxfmRBVTKAewSYx.MIprVMIPkzUhwQMRTGRBJUKDOEHG;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.gHFfmwgurBviMwjylTPNtvFERkueA = zfHovgugniYvLghndOyJTDcnKzoO.gHFfmwgurBviMwjylTPNtvFERkueA - shFAPPkiCHZRcKxfmRBVTKAewSYx.gHFfmwgurBviMwjylTPNtvFERkueA;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.ZJzfzzVoBQcjSbQzJDLBesKHhgrd = zfHovgugniYvLghndOyJTDcnKzoO.ZJzfzzVoBQcjSbQzJDLBesKHhgrd - shFAPPkiCHZRcKxfmRBVTKAewSYx.ZJzfzzVoBQcjSbQzJDLBesKHhgrd;
			for (int l = 0; l < zfHovgugniYvLghndOyJTDcnKzoO.bcTvrKOzACMlcKbeYtQASNtoRYNF.Length; l++)
			{
				itCzAzqOcCXysVnBoAhkLGhLcgQA.bcTvrKOzACMlcKbeYtQASNtoRYNF[l] = zfHovgugniYvLghndOyJTDcnKzoO.bcTvrKOzACMlcKbeYtQASNtoRYNF[l] - shFAPPkiCHZRcKxfmRBVTKAewSYx.bcTvrKOzACMlcKbeYtQASNtoRYNF[l];
			}
			itCzAzqOcCXysVnBoAhkLGhLcgQA.mLaQWAdMKFPMBUGNBffgLOgiOfei = zfHovgugniYvLghndOyJTDcnKzoO.mLaQWAdMKFPMBUGNBffgLOgiOfei - shFAPPkiCHZRcKxfmRBVTKAewSYx.mLaQWAdMKFPMBUGNBffgLOgiOfei;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.SwbkYdbTEUHqQhNPkvGRnQfJjnBM = zfHovgugniYvLghndOyJTDcnKzoO.SwbkYdbTEUHqQhNPkvGRnQfJjnBM - shFAPPkiCHZRcKxfmRBVTKAewSYx.SwbkYdbTEUHqQhNPkvGRnQfJjnBM;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.jZdAQOYvoJwkNAKHfQVbsbezVfmW = zfHovgugniYvLghndOyJTDcnKzoO.jZdAQOYvoJwkNAKHfQVbsbezVfmW - shFAPPkiCHZRcKxfmRBVTKAewSYx.jZdAQOYvoJwkNAKHfQVbsbezVfmW;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.ispeatToHywvYYMSuZWhkGwDnwYp = zfHovgugniYvLghndOyJTDcnKzoO.ispeatToHywvYYMSuZWhkGwDnwYp - shFAPPkiCHZRcKxfmRBVTKAewSYx.ispeatToHywvYYMSuZWhkGwDnwYp;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.IpSfimgoprwpPbvvZHasGFLoyFpU = zfHovgugniYvLghndOyJTDcnKzoO.IpSfimgoprwpPbvvZHasGFLoyFpU - shFAPPkiCHZRcKxfmRBVTKAewSYx.IpSfimgoprwpPbvvZHasGFLoyFpU;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.vTBwIFSNkxHsobDCWeicqTmmUnIH = zfHovgugniYvLghndOyJTDcnKzoO.vTBwIFSNkxHsobDCWeicqTmmUnIH - shFAPPkiCHZRcKxfmRBVTKAewSYx.vTBwIFSNkxHsobDCWeicqTmmUnIH;
			for (int m = 0; m < zfHovgugniYvLghndOyJTDcnKzoO.tkaAtqiNIrFwnbfhpfDKyViuRMGV.Length; m++)
			{
				itCzAzqOcCXysVnBoAhkLGhLcgQA.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m] = zfHovgugniYvLghndOyJTDcnKzoO.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m] - shFAPPkiCHZRcKxfmRBVTKAewSYx.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m];
			}
			itCzAzqOcCXysVnBoAhkLGhLcgQA.taoHjuPyxajupaEHhgrYbSBkwtZo = zfHovgugniYvLghndOyJTDcnKzoO.taoHjuPyxajupaEHhgrYbSBkwtZo - shFAPPkiCHZRcKxfmRBVTKAewSYx.taoHjuPyxajupaEHhgrYbSBkwtZo;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.lsBdvuIbCnbembzorkupUPfpqrMG = zfHovgugniYvLghndOyJTDcnKzoO.lsBdvuIbCnbembzorkupUPfpqrMG - shFAPPkiCHZRcKxfmRBVTKAewSYx.lsBdvuIbCnbembzorkupUPfpqrMG;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.qdgKtiruueifuNJqTMRtZTgjWvmn = zfHovgugniYvLghndOyJTDcnKzoO.qdgKtiruueifuNJqTMRtZTgjWvmn - shFAPPkiCHZRcKxfmRBVTKAewSYx.qdgKtiruueifuNJqTMRtZTgjWvmn;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.jRBPLEpruUgsqCpLoBAvnjcDbnwlA = zfHovgugniYvLghndOyJTDcnKzoO.jRBPLEpruUgsqCpLoBAvnjcDbnwlA - shFAPPkiCHZRcKxfmRBVTKAewSYx.jRBPLEpruUgsqCpLoBAvnjcDbnwlA;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.fMiDgiXVKZbDOKqlvGclhoBcUCoDB = zfHovgugniYvLghndOyJTDcnKzoO.fMiDgiXVKZbDOKqlvGclhoBcUCoDB - shFAPPkiCHZRcKxfmRBVTKAewSYx.fMiDgiXVKZbDOKqlvGclhoBcUCoDB;
			itCzAzqOcCXysVnBoAhkLGhLcgQA.KdwAVnhDDPrFtJAllRAkceDPAadz = zfHovgugniYvLghndOyJTDcnKzoO.KdwAVnhDDPrFtJAllRAkceDPAadz - shFAPPkiCHZRcKxfmRBVTKAewSYx.KdwAVnhDDPrFtJAllRAkceDPAadz;
			for (int n = 0; n < zfHovgugniYvLghndOyJTDcnKzoO.bbzjSUmzCpvKeztqjjpYuJViWzaP.Length; n++)
			{
				itCzAzqOcCXysVnBoAhkLGhLcgQA.bbzjSUmzCpvKeztqjjpYuJViWzaP[n] = zfHovgugniYvLghndOyJTDcnKzoO.bbzjSUmzCpvKeztqjjpYuJViWzaP[n] - shFAPPkiCHZRcKxfmRBVTKAewSYx.bbzjSUmzCpvKeztqjjpYuJViWzaP[n];
			}
			DWomFyPzgLCicGcgOetubtsKXbGy = nlUpllWZvtUeKfIbPVofCFpKotIK();
			if (DWomFyPzgLCicGcgOetubtsKXbGy)
			{
				NYncusvLyyjkTCoKlZBrZMuEuwoq = P_0;
				shFAPPkiCHZRcKxfmRBVTKAewSYx.xQEFQkhJhvnmwGSMyzYdziphFTng(zfHovgugniYvLghndOyJTDcnKzoO);
			}
		}

		public void xQEFQkhJhvnmwGSMyzYdziphFTng(JpBrPaLLhhCkCkXZIhuyIfuSiSId P_0)
		{
			UqVPGpfdnnuOqMQpSlSNNcVildku = P_0.UqVPGpfdnnuOqMQpSlSNNcVildku;
			shFAPPkiCHZRcKxfmRBVTKAewSYx.xQEFQkhJhvnmwGSMyzYdziphFTng(P_0.shFAPPkiCHZRcKxfmRBVTKAewSYx);
			itCzAzqOcCXysVnBoAhkLGhLcgQA.xQEFQkhJhvnmwGSMyzYdziphFTng(P_0.itCzAzqOcCXysVnBoAhkLGhLcgQA);
		}

		private bool nlUpllWZvtUeKfIbPVofCFpKotIK()
		{
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.hOOUxyzjPSHmCugYimIocEeoCnOZ != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.nXGdfezugKPnijHxPqSGMXNvieeu != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.iVZXAatNNkoQhakyOcSvPZuywmil != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.fRKWXdIcjzUVKxBCLBAxjgTDzHXfA != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.uXFvVgVvAswDejLdlJrCamssAhoj != 0)
			{
				return true;
			}
			for (int i = 0; i < zfHovgugniYvLghndOyJTDcnKzoO.YrVRqCBdYnMvpzdpuevFnfRkNtEB.Length; i++)
			{
				if (itCzAzqOcCXysVnBoAhkLGhLcgQA.YrVRqCBdYnMvpzdpuevFnfRkNtEB[i] != 0)
				{
					return true;
				}
			}
			for (int j = 0; j < zfHovgugniYvLghndOyJTDcnKzoO.YwGnMOKwAHDLEyCOXcOpCjBCXpNK.Length; j++)
			{
				if (itCzAzqOcCXysVnBoAhkLGhLcgQA.YwGnMOKwAHDLEyCOXcOpCjBCXpNK[j] != 0)
				{
					return true;
				}
			}
			for (int k = 0; k < zfHovgugniYvLghndOyJTDcnKzoO.syxPbhBJItzVAVLveDKeKXtdjmVVA.Length; k++)
			{
				if (itCzAzqOcCXysVnBoAhkLGhLcgQA.syxPbhBJItzVAVLveDKeKXtdjmVVA[k])
				{
					return true;
				}
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.IVGASYlUTQmRAdogTdHGGGSkarzB != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.BokrrSjVfAhYkIQmhzfHRbuAwaHg != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.irfbjzGcGIOFNuSIcxqNAnObMqwfA != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.MIprVMIPkzUhwQMRTGRBJUKDOEHG != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.gHFfmwgurBviMwjylTPNtvFERkueA != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.ZJzfzzVoBQcjSbQzJDLBesKHhgrd != 0)
			{
				return true;
			}
			for (int l = 0; l < zfHovgugniYvLghndOyJTDcnKzoO.bcTvrKOzACMlcKbeYtQASNtoRYNF.Length; l++)
			{
				if (itCzAzqOcCXysVnBoAhkLGhLcgQA.bcTvrKOzACMlcKbeYtQASNtoRYNF[l] != 0)
				{
					return true;
				}
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.mLaQWAdMKFPMBUGNBffgLOgiOfei != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.SwbkYdbTEUHqQhNPkvGRnQfJjnBM != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.jZdAQOYvoJwkNAKHfQVbsbezVfmW != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.ispeatToHywvYYMSuZWhkGwDnwYp != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.IpSfimgoprwpPbvvZHasGFLoyFpU != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.vTBwIFSNkxHsobDCWeicqTmmUnIH != 0)
			{
				return true;
			}
			for (int m = 0; m < zfHovgugniYvLghndOyJTDcnKzoO.tkaAtqiNIrFwnbfhpfDKyViuRMGV.Length; m++)
			{
				itCzAzqOcCXysVnBoAhkLGhLcgQA.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m] = zfHovgugniYvLghndOyJTDcnKzoO.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m] - shFAPPkiCHZRcKxfmRBVTKAewSYx.tkaAtqiNIrFwnbfhpfDKyViuRMGV[m];
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.taoHjuPyxajupaEHhgrYbSBkwtZo != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.lsBdvuIbCnbembzorkupUPfpqrMG != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.qdgKtiruueifuNJqTMRtZTgjWvmn != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.jRBPLEpruUgsqCpLoBAvnjcDbnwlA != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.fMiDgiXVKZbDOKqlvGclhoBcUCoDB != 0)
			{
				return true;
			}
			if (itCzAzqOcCXysVnBoAhkLGhLcgQA.KdwAVnhDDPrFtJAllRAkceDPAadz != 0)
			{
				return true;
			}
			for (int n = 0; n < zfHovgugniYvLghndOyJTDcnKzoO.bbzjSUmzCpvKeztqjjpYuJViWzaP.Length; n++)
			{
				if (itCzAzqOcCXysVnBoAhkLGhLcgQA.bbzjSUmzCpvKeztqjjpYuJViWzaP[n] != 0)
				{
					return true;
				}
			}
			return false;
		}
	}

	private class PgmSPLMBJcejfXxSZvRcdpyniujo
	{
		public enum fivUglccsOGTfztFkSsrGApCQqxO
		{
			Exact = 0,
			Approximate = 1
		}

		public class RSKelmIKLSkjortusEGIyflVVuPS
		{
			public int yezDqSCRWxhlxMjsXiQKzSGNMhog;

			public Guid auRhMsSNSGdZKHBllYUoMazgzoCbA;

			public Guid iFObMCUaUQUnWzybrqxSRAVRTBWI;

			public int wsDsfjzHKLzCJcIILWEhQVQklLQu;

			public int HhqbiwBXcDTULYOwmAYexUsXBMtCA;

			public int MCDKyUJlmhQXfeayeJmoXfaHcWfiA;

			public int nyDAXJEHgHLCMlTZKpdDYCOIRSQr;

			public bool sKPmsOwrsqQUGaDeDiygzRJgUHm(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0, fivUglccsOGTfztFkSsrGApCQqxO P_1)
			{
				if (P_0.rewiredId == yezDqSCRWxhlxMjsXiQKzSGNMhog)
				{
					return true;
				}
				if (HhqbiwBXcDTULYOwmAYexUsXBMtCA != P_0.HhqbiwBXcDTULYOwmAYexUsXBMtCA)
				{
					return false;
				}
				if (MCDKyUJlmhQXfeayeJmoXfaHcWfiA != P_0.MCDKyUJlmhQXfeayeJmoXfaHcWfiA)
				{
					return false;
				}
				if (nyDAXJEHgHLCMlTZKpdDYCOIRSQr != P_0.nyDAXJEHgHLCMlTZKpdDYCOIRSQr)
				{
					return false;
				}
				switch (P_1)
				{
				case fivUglccsOGTfztFkSsrGApCQqxO.Exact:
					return auRhMsSNSGdZKHBllYUoMazgzoCbA == P_0.instanceGuid;
				case fivUglccsOGTfztFkSsrGApCQqxO.Approximate:
					return iFObMCUaUQUnWzybrqxSRAVRTBWI == P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI;
				default:
					throw new NotImplementedException();
				}
			}

			public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
			{
				string text = "" + "rewiredId = " + yezDqSCRWxhlxMjsXiQKzSGNMhog + "\n";
				Guid guid = auRhMsSNSGdZKHBllYUoMazgzoCbA;
				string text2 = text + "instanceGuid = " + guid.ToString() + "\n";
				guid = iFObMCUaUQUnWzybrqxSRAVRTBWI;
				return string.Concat(string.Concat(string.Concat(string.Concat(text2 + "typeIdentifierGuid = " + guid.ToString() + "\n", "lastInputManagerId = ", wsDsfjzHKLzCJcIILWEhQVQklLQu.ToString(), "\n"), "hardwareAxisCount = ", HhqbiwBXcDTULYOwmAYexUsXBMtCA.ToString(), "\n"), "hardwareButtonCount = ", MCDKyUJlmhQXfeayeJmoXfaHcWfiA.ToString(), "\n"), "hardwareHatCount = ", nyDAXJEHgHLCMlTZKpdDYCOIRSQr.ToString(), "\n");
			}
		}

		private sealed class nTBMtcThrqzsaWSDLebGBBBHLPbtA : IEnumerable<RSKelmIKLSkjortusEGIyflVVuPS>, IEnumerator<RSKelmIKLSkjortusEGIyflVVuPS>, IDisposable, IEnumerable, IEnumerator
		{
			private int GaDEmGeAzDwcrUimnTDVbqDAEmMs;

			private RSKelmIKLSkjortusEGIyflVVuPS QZXFulaBJncjPFMoGHDkxBzfgAJM;

			private int nKWKxUHpZxraWHSPSgSgtAFyHyvHA;

			public PgmSPLMBJcejfXxSZvRcdpyniujo AtldvTEkDsEewBZFaEtbawltdqhzb;

			private zIwrdIIRBqtGNAiinYdFLQeQHQkI wdbQxUuPsPgPKZuWmNEeMjEvEqweA;

			public zIwrdIIRBqtGNAiinYdFLQeQHQkI KhdNMFEMmEAnBXbdNduCAUxxihfib;

			private fivUglccsOGTfztFkSsrGApCQqxO XLaGCVhWSRFSHLsBcqOHnsPKrQmbA;

			public fivUglccsOGTfztFkSsrGApCQqxO dPhbrgyjusQglwefgNYQseZkRnSN;

			private int NOddPDAtCADIsFnzlqGZAJmYYyoN;

			private int yJsBQJRPgsSANFiCNsLHwmcurxe;

			RSKelmIKLSkjortusEGIyflVVuPS IEnumerator<RSKelmIKLSkjortusEGIyflVVuPS>.Current
			{
				[DebuggerHidden]
				get
				{
					return QZXFulaBJncjPFMoGHDkxBzfgAJM;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return QZXFulaBJncjPFMoGHDkxBzfgAJM;
				}
			}

			[DebuggerHidden]
			public nTBMtcThrqzsaWSDLebGBBBHLPbtA(int P_0)
			{
				GaDEmGeAzDwcrUimnTDVbqDAEmMs = P_0;
				nKWKxUHpZxraWHSPSgSgtAFyHyvHA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int gaDEmGeAzDwcrUimnTDVbqDAEmMs = GaDEmGeAzDwcrUimnTDVbqDAEmMs;
				PgmSPLMBJcejfXxSZvRcdpyniujo atldvTEkDsEewBZFaEtbawltdqhzb = AtldvTEkDsEewBZFaEtbawltdqhzb;
				if (gaDEmGeAzDwcrUimnTDVbqDAEmMs != 0)
				{
					if (gaDEmGeAzDwcrUimnTDVbqDAEmMs != 1)
					{
						return false;
					}
					GaDEmGeAzDwcrUimnTDVbqDAEmMs = -1;
					goto IL_0083;
				}
				GaDEmGeAzDwcrUimnTDVbqDAEmMs = -1;
				NOddPDAtCADIsFnzlqGZAJmYYyoN = atldvTEkDsEewBZFaEtbawltdqhzb.ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count;
				yJsBQJRPgsSANFiCNsLHwmcurxe = 0;
				goto IL_0093;
				IL_0083:
				yJsBQJRPgsSANFiCNsLHwmcurxe++;
				goto IL_0093;
				IL_0093:
				if (yJsBQJRPgsSANFiCNsLHwmcurxe < NOddPDAtCADIsFnzlqGZAJmYYyoN)
				{
					if (atldvTEkDsEewBZFaEtbawltdqhzb.ZDXhulnhGZktqkrQbgcQqMUrEhoFA[yJsBQJRPgsSANFiCNsLHwmcurxe].sKPmsOwrsqQUGaDeDiygzRJgUHm(wdbQxUuPsPgPKZuWmNEeMjEvEqweA, XLaGCVhWSRFSHLsBcqOHnsPKrQmbA))
					{
						QZXFulaBJncjPFMoGHDkxBzfgAJM = atldvTEkDsEewBZFaEtbawltdqhzb.ZDXhulnhGZktqkrQbgcQqMUrEhoFA[yJsBQJRPgsSANFiCNsLHwmcurxe];
						GaDEmGeAzDwcrUimnTDVbqDAEmMs = 1;
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
			IEnumerator<RSKelmIKLSkjortusEGIyflVVuPS> IEnumerable<RSKelmIKLSkjortusEGIyflVVuPS>.GetEnumerator()
			{
				nTBMtcThrqzsaWSDLebGBBBHLPbtA nTBMtcThrqzsaWSDLebGBBBHLPbtA2;
				if (GaDEmGeAzDwcrUimnTDVbqDAEmMs == -2 && nKWKxUHpZxraWHSPSgSgtAFyHyvHA == Thread.CurrentThread.ManagedThreadId)
				{
					GaDEmGeAzDwcrUimnTDVbqDAEmMs = 0;
					nTBMtcThrqzsaWSDLebGBBBHLPbtA2 = this;
				}
				else
				{
					nTBMtcThrqzsaWSDLebGBBBHLPbtA2 = new nTBMtcThrqzsaWSDLebGBBBHLPbtA(0);
					nTBMtcThrqzsaWSDLebGBBBHLPbtA2.AtldvTEkDsEewBZFaEtbawltdqhzb = AtldvTEkDsEewBZFaEtbawltdqhzb;
				}
				nTBMtcThrqzsaWSDLebGBBBHLPbtA2.wdbQxUuPsPgPKZuWmNEeMjEvEqweA = KhdNMFEMmEAnBXbdNduCAUxxihfib;
				nTBMtcThrqzsaWSDLebGBBBHLPbtA2.XLaGCVhWSRFSHLsBcqOHnsPKrQmbA = dPhbrgyjusQglwefgNYQseZkRnSN;
				return nTBMtcThrqzsaWSDLebGBBBHLPbtA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<RSKelmIKLSkjortusEGIyflVVuPS>)this).GetEnumerator();
			}
		}

		private List<RSKelmIKLSkjortusEGIyflVVuPS> ZDXhulnhGZktqkrQbgcQqMUrEhoFA;

		public PgmSPLMBJcejfXxSZvRcdpyniujo()
		{
			ZDXhulnhGZktqkrQbgcQqMUrEhoFA = new List<RSKelmIKLSkjortusEGIyflVVuPS>();
		}

		public void HgZeolIOSfnlKNNDACCahiudRKNec(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].sKPmsOwrsqQUGaDeDiygzRJgUHm(P_0, fivUglccsOGTfztFkSsrGApCQqxO.Exact))
				{
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].yezDqSCRWxhlxMjsXiQKzSGNMhog = P_0.rewiredId;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].auRhMsSNSGdZKHBllYUoMazgzoCbA = P_0.instanceGuid;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].iFObMCUaUQUnWzybrqxSRAVRTBWI = P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].wsDsfjzHKLzCJcIILWEhQVQklLQu = P_0.inputManagerId;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].HhqbiwBXcDTULYOwmAYexUsXBMtCA = P_0.HhqbiwBXcDTULYOwmAYexUsXBMtCA;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].MCDKyUJlmhQXfeayeJmoXfaHcWfiA = P_0.MCDKyUJlmhQXfeayeJmoXfaHcWfiA;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].nyDAXJEHgHLCMlTZKpdDYCOIRSQr = P_0.nyDAXJEHgHLCMlTZKpdDYCOIRSQr;
					rCRVlSgjPAfuPiLiTvQLcokniobBb(P_0.rewiredId, P_0.instanceGuid, i);
					return;
				}
			}
			ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Add(new RSKelmIKLSkjortusEGIyflVVuPS
			{
				yezDqSCRWxhlxMjsXiQKzSGNMhog = P_0.rewiredId,
				auRhMsSNSGdZKHBllYUoMazgzoCbA = P_0.instanceGuid,
				iFObMCUaUQUnWzybrqxSRAVRTBWI = P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI,
				wsDsfjzHKLzCJcIILWEhQVQklLQu = P_0.inputManagerId,
				HhqbiwBXcDTULYOwmAYexUsXBMtCA = P_0.HhqbiwBXcDTULYOwmAYexUsXBMtCA,
				MCDKyUJlmhQXfeayeJmoXfaHcWfiA = P_0.MCDKyUJlmhQXfeayeJmoXfaHcWfiA,
				nyDAXJEHgHLCMlTZKpdDYCOIRSQr = P_0.nyDAXJEHgHLCMlTZKpdDYCOIRSQr
			});
			rCRVlSgjPAfuPiLiTvQLcokniobBb(P_0.rewiredId, P_0.instanceGuid, ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count - 1);
		}

		public bool ecSZEwttGfkQfToParxnBfHCGISs(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0, fivUglccsOGTfztFkSsrGApCQqxO P_1)
		{
			int count = ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].sKPmsOwrsqQUGaDeDiygzRJgUHm(P_0, P_1))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<RSKelmIKLSkjortusEGIyflVVuPS> OoDdjwkheCaHvrmPJPlqsPWCeYVtA(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0, fivUglccsOGTfztFkSsrGApCQqxO P_1)
		{
			return new nTBMtcThrqzsaWSDLebGBBBHLPbtA(-2)
			{
				AtldvTEkDsEewBZFaEtbawltdqhzb = this,
				KhdNMFEMmEAnBXbdNduCAUxxihfib = P_0,
				dPhbrgyjusQglwefgNYQseZkRnSN = P_1
			};
		}

		private void rCRVlSgjPAfuPiLiTvQLcokniobBb(int P_0, Guid P_1, int P_2)
		{
			for (int num = ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (ZDXhulnhGZktqkrQbgcQqMUrEhoFA[num].yezDqSCRWxhlxMjsXiQKzSGNMhog == P_0 || ZDXhulnhGZktqkrQbgcQqMUrEhoFA[num].auRhMsSNSGdZKHBllYUoMazgzoCbA == P_1))
				{
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA.RemoveAt(num);
				}
			}
		}

		public virtual string GvNCmPFePpgwRPnXVCmFehxNQKcDb()
		{
			string text = "";
			text = text + "Joystick records: " + ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count + "\n";
			for (int i = 0; i < ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count; i++)
			{
				text = text + "Record " + i + ":\n";
				text = text + ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].ToString() + "\n\n";
			}
			return text;
		}
	}

	private class DQscgTnXpbHrcPbwtccrbMAGbZNS
	{
		public zIwrdIIRBqtGNAiinYdFLQeQHQkI dUxVIgaadrfqJWSzRpXGORZlkMqp;

		public VrUjHkyKwlgfxGiNlmxxLiWLUcYKA EJqnnacIsWkFjtZCidzSDEtnLNNd;

		public bool LOAKUriHGZEbByAroDTyQAHhOjqU
		{
			get
			{
				if (dUxVIgaadrfqJWSzRpXGORZlkMqp != null)
				{
					return EJqnnacIsWkFjtZCidzSDEtnLNNd != null;
				}
				return false;
			}
		}

		public DQscgTnXpbHrcPbwtccrbMAGbZNS(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0, VrUjHkyKwlgfxGiNlmxxLiWLUcYKA P_1)
		{
			dUxVIgaadrfqJWSzRpXGORZlkMqp = P_0;
			EJqnnacIsWkFjtZCidzSDEtnLNNd = P_1;
		}

		public static List<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> qCHcCyCziRquAonrFHNFoZicfYj(List<DQscgTnXpbHrcPbwtccrbMAGbZNS> P_0)
		{
			if (P_0 == null)
			{
				return new List<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA>();
			}
			List<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> list = new List<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA>();
			for (int i = 0; i < P_0.Count; i++)
			{
				if (P_0[i].LOAKUriHGZEbByAroDTyQAHhOjqU)
				{
					list.Add(P_0[i].EJqnnacIsWkFjtZCidzSDEtnLNNd);
				}
			}
			return list;
		}
	}

	private class YCDemxFzTOdTkTMHCruFXqRqgJYV
	{
		public TGMNVgEkzYRUJhRlmEORKKDOgVur KkYADSJoRXGQJCtucPuUsavrokODA;

		public YCDemxFzTOdTkTMHCruFXqRqgJYV(TGMNVgEkzYRUJhRlmEORKKDOgVur P_0)
		{
			KkYADSJoRXGQJCtucPuUsavrokODA = P_0;
		}
	}

	private class upOOWuuQjtoAgweGmiGDaFJdbuRDb
	{
		private RoPbzDYZWaFwxZTVbdHaodWtsqQT.hbmIYmqIIojXJghtnpbjoOrwRLPoA SKgdxtxZeRIKPrnbEsiJElKhRPQP;

		private RoPbzDYZWaFwxZTVbdHaodWtsqQT.AIfggiMMETAzgzxjciLVtINteqAB QVhkfFamoogcFqvoCTmykryiMJYA;

		private NativeBuffer uRGCJTfqMbkhEeNYkoYxJPKVCjQf;

		private int jyLoZzeEHQjZlxUjkiftZdyFYIdh;

		public upOOWuuQjtoAgweGmiGDaFJdbuRDb()
		{
			SKgdxtxZeRIKPrnbEsiJElKhRPQP = new RoPbzDYZWaFwxZTVbdHaodWtsqQT.hbmIYmqIIojXJghtnpbjoOrwRLPoA
			{
				wbLnUMyKaaTsCwbpQJZQBgoyosCw = (uint)Marshal.SizeOf(typeof(RoPbzDYZWaFwxZTVbdHaodWtsqQT.hbmIYmqIIojXJghtnpbjoOrwRLPoA)),
				yVVqlIQjFHspJjfivDoBggDzgZtAb = true,
				vkOnDoUxdzOmINgJjEByxoYKCJuj = true,
				TYCfbTOtxeEkPclGmokErynNDOfAA = false,
				wpWzkEEQHDuZppDDSjwLcknyRLrG = true,
				SNeaBIeJLhaaisYegaBzTLqBGfSnA = IntPtr.Zero
			};
			QVhkfFamoogcFqvoCTmykryiMJYA = RoPbzDYZWaFwxZTVbdHaodWtsqQT.AIfggiMMETAzgzxjciLVtINteqAB.slaemGzHKYWMylDIxBuXEinKYiIkA();
			uRGCJTfqMbkhEeNYkoYxJPKVCjQf = new NativeBuffer((int)QVhkfFamoogcFqvoCTmykryiMJYA.wbLnUMyKaaTsCwbpQJZQBgoyosCw);
			uRGCJTfqMbkhEeNYkoYxJPKVCjQf.Write(QVhkfFamoogcFqvoCTmykryiMJYA.wbLnUMyKaaTsCwbpQJZQBgoyosCw, 0);
		}

		public bool uEgWhdjcbXHGoErtZVrbrzEhnfJOA()
		{
			int num = sXebqbYIrtCmsrzOVQMzWGToHQyG();
			if (num == jyLoZzeEHQjZlxUjkiftZdyFYIdh)
			{
				return false;
			}
			jyLoZzeEHQjZlxUjkiftZdyFYIdh = num;
			return true;
		}

		public void UAyelYsfECWGarrXYrMPseXTcamJA(int P_0)
		{
			jyLoZzeEHQjZlxUjkiftZdyFYIdh = P_0;
		}

		private int sXebqbYIrtCmsrzOVQMzWGToHQyG()
		{
			try
			{
				return ASYbPqxUNkljqzCsqWpbFAZdrPyP.rhsMlLxHOmuNgyombZRSAAKPTRUc(ref SKgdxtxZeRIKPrnbEsiJElKhRPQP, uRGCJTfqMbkhEeNYkoYxJPKVCjQf);
			}
			catch
			{
				return 0;
			}
		}
	}

	private enum EjGdcVAZLVxPojHVzcAqTOhubwDQ
	{
		Device = 17,
		Mouse = 18,
		Keyboard = 19,
		Joystick = 20,
		Gamepad = 21,
		Driving = 22,
		Flight = 23,
		FirstPerson = 24,
		ControlDevice = 25,
		ScreenPointer = 26,
		Remote = 27,
		Supplemental = 28
	}

	private const pXLCPSuuAhzcgGmkJbVkDzXovEub RKkbMNaBejYcqlgKOpoTafDDsTovB = pXLCPSuuAhzcgGmkJbVkDzXovEub.GameControl;

	private const XsxUPjMGXXOzFHWjBirlaEPOLxzP ssVtxdLxvslrifkAHRhOqAOtOMB = XsxUPjMGXXOzFHWjBirlaEPOLxzP.AttachedOnly;

	private IntPtr EiBBsdJiTwHqmUCtjqJHAQyKnVevA;

	private YbMgkjmXpWdzgUKMqsjYZeXnSVzq VAyGDGfoHBoDUCWNaIhGjglCTLfid;

	private List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> uhsZTQOPiTWQesgStEowZrhIaYfdA;

	private int DUhRAPCUFyXuQrAMVOAIBoZHcooH;

	private PgmSPLMBJcejfXxSZvRcdpyniujo dFjjWhTvzPgWCbHejcNwKYxKBSaM;

	private bool fKdECYTEMkHBabIJrseQcfdKSMfsA;

	private MOkVWevpNUQwQWbUTpfVSRcmsAig RAJQEbAWyYwUFSCjMGPbkXoUvsyi;

	private UpdateLoopSetting vAHBpckJKHZCGJbcfbZblVlgtziD;

	private Action<int, ControllerDataUpdater> qTPyWiiAzgfhSZUfTOhfkrKlxaVL;

	private PlatformInputManager cenkEFLNjUadqCYJhKRRkUtIKUYNA;

	private TimerRealTime zBkbhvgUhZMSPzzdBzDLTpZfIlWHb;

	private hDKoCVALQkrmLGSpmGgwMOwPbsxB<bool> pKyFNjpvOBDhOkWFJuNZxIBQqVXf;

	private upOOWuuQjtoAgweGmiGDaFJdbuRDb OzVJhmrhdYiOIfqPxxcRStZoGEHab;

	private int swmRTJqVxWnOYVJrkoQeCdJBLAgi;

	private int qOHLZbBxOYueWNpQMJFtAwMWpUyg;

	private hDKoCVALQkrmLGSpmGgwMOwPbsxB<List<DQscgTnXpbHrcPbwtccrbMAGbZNS>> CIGbdCwzRSAhHGwgZNwOtaEqgfZw;

	private readonly object eTRoskBdTVJraCzYFXNyrUomeHqE = new object();

	private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> NBBGEOVRvneYDcFdnaoIhuFHZZKyB;

	private Func<int> OlamnlbqCRkOUMBSkakeUghSoraE;

	MOkVWevpNUQwQWbUTpfVSRcmsAig EbCVMtZcbYODojUXzIyunqpRvZvf.gEpmfiCrZuBIAUDisEAEyJZbwgaX
	{
		get
		{
			return RAJQEbAWyYwUFSCjMGPbkXoUvsyi;
		}
		set
		{
			RAJQEbAWyYwUFSCjMGPbkXoUvsyi = rAJQEbAWyYwUFSCjMGPbkXoUvsyi;
		}
	}

	[CustomObfuscation(rename = false)]
	public override int deviceCount => DUhRAPCUFyXuQrAMVOAIBoZHcooH;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => cenkEFLNjUadqCYJhKRRkUtIKUYNA;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => new InputSourceWrapper<YbMgkjmXpWdzgUKMqsjYZeXnSVzq>(VAyGDGfoHBoDUCWNaIhGjglCTLfid);

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.DirectInput;

	public nHYtgmYZbuslvbwvuThTQLBbdmkB(UpdateLoopSetting P_0, MOkVWevpNUQwQWbUTpfVSRcmsAig P_1, IntPtr P_2, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_3, Func<int> P_4)
	{
		try
		{
			vAHBpckJKHZCGJbcfbZblVlgtziD = P_0;
			RAJQEbAWyYwUFSCjMGPbkXoUvsyi = P_1;
			EiBBsdJiTwHqmUCtjqJHAQyKnVevA = P_2;
			NBBGEOVRvneYDcFdnaoIhuFHZZKyB = P_3;
			OlamnlbqCRkOUMBSkakeUghSoraE = P_4;
			cenkEFLNjUadqCYJhKRRkUtIKUYNA = this;
			VAyGDGfoHBoDUCWNaIhGjglCTLfid = new YbMgkjmXpWdzgUKMqsjYZeXnSVzq();
			qTPyWiiAzgfhSZUfTOhfkrKlxaVL = UpdateControllerData;
			OzVJhmrhdYiOIfqPxxcRStZoGEHab = new upOOWuuQjtoAgweGmiGDaFJdbuRDb();
			pKyFNjpvOBDhOkWFJuNZxIBQqVXf = new hDKoCVALQkrmLGSpmGgwMOwPbsxB<bool>(true, hlYThrhBPFAnHYctCqFGaKHosEGR);
			CIGbdCwzRSAhHGwgZNwOtaEqgfZw = new hDKoCVALQkrmLGSpmGgwMOwPbsxB<List<DQscgTnXpbHrcPbwtccrbMAGbZNS>>(true, () => OutlNjmPWwcZWCySkWmTCgJRlVBZA());
			TZzFLUwbDHyIHNkwrBcFIdPpLANSA();
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
		dFjjWhTvzPgWCbHejcNwKYxKBSaM = new PgmSPLMBJcejfXxSZvRcdpyniujo();
		zBkbhvgUhZMSPzzdBzDLTpZfIlWHb = new TimerRealTime(1.0);
		zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Start();
		AAGmHSjMDwQszCAmDVQTJjAYItxo();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		meWveRfpNpDrQcFmabCIAfAkjbIkB();
		FUnOAYKrPGQnYrEjeUvOZtyzGhVe();
		HuQMjaeKUlhtoxviEIRhkVYsSmvt();
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (CIGbdCwzRSAhHGwgZNwOtaEqgfZw != null)
		{
			CIGbdCwzRSAhHGwgZNwOtaEqgfZw.vCBFvIdHsbAnKBZkroQOsRrLIAyV();
		}
		if (pKyFNjpvOBDhOkWFJuNZxIBQqVXf != null)
		{
			pKyFNjpvOBDhOkWFJuNZxIBQqVXf.vCBFvIdHsbAnKBZkroQOsRrLIAyV();
		}
		if (uhsZTQOPiTWQesgStEowZrhIaYfdA == null)
		{
			return;
		}
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			for (int i = 0; i < uhsZTQOPiTWQesgStEowZrhIaYfdA.Count; i++)
			{
				if (uhsZTQOPiTWQesgStEowZrhIaYfdA[i] != null)
				{
					uhsZTQOPiTWQesgStEowZrhIaYfdA[i].zobeSpTCoofGnipPFjpZGNzdwEoE();
					uhsZTQOPiTWQesgStEowZrhIaYfdA[i].vCBFvIdHsbAnKBZkroQOsRrLIAyV();
				}
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return qTPyWiiAzgfhSZUfTOhfkrKlxaVL;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			for (int i = 0; i < DUhRAPCUFyXuQrAMVOAIBoZHcooH; i++)
			{
				if (uhsZTQOPiTWQesgStEowZrhIaYfdA[i].inputManagerId == inputManagerId)
				{
					uhsZTQOPiTWQesgStEowZrhIaYfdA[i].FillData(data);
					return;
				}
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		fKdECYTEMkHBabIJrseQcfdKSMfsA = true;
		zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Start();
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		fKdECYTEMkHBabIJrseQcfdKSMfsA = true;
		zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Start();
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
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

	private void meWveRfpNpDrQcFmabCIAfAkjbIkB()
	{
		if (pKyFNjpvOBDhOkWFJuNZxIBQqVXf.RTnbdebLTdTeohXHDoBoLyQGImfWA)
		{
			if (pKyFNjpvOBDhOkWFJuNZxIBQqVXf.TPcqcKWeqJnMdeNkqZXytbyidUBn() && !zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.running && !CIGbdCwzRSAhHGwgZNwOtaEqgfZw.RTnbdebLTdTeohXHDoBoLyQGImfWA)
			{
				if (pKyFNjpvOBDhOkWFJuNZxIBQqVXf.uSwyJUCsSdiGPcMJmfFpIGVFqnMMA)
				{
					fKdECYTEMkHBabIJrseQcfdKSMfsA = true;
				}
				zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Start();
			}
		}
		else if (!zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.running)
		{
			zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Start();
		}
		else if (zBkbhvgUhZMSPzzdBzDLTpZfIlWHb.Update())
		{
			pKyFNjpvOBDhOkWFJuNZxIBQqVXf.miPFrJiYaYbOloaoCfGOcsRcMhAoc();
		}
	}

	private List<DQscgTnXpbHrcPbwtccrbMAGbZNS> OutlNjmPWwcZWCySkWmTCgJRlVBZA()
	{
		List<DQscgTnXpbHrcPbwtccrbMAGbZNS> list = new List<DQscgTnXpbHrcPbwtccrbMAGbZNS>();
		IList<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> list2 = VhAqCbIcOZwXiyKvCEacyOgdnjqU();
		int count = list2.Count;
		for (int i = 0; i < count; i++)
		{
			if (list2[i] == null)
			{
				continue;
			}
			try
			{
				VrUjHkyKwlgfxGiNlmxxLiWLUcYKA vrUjHkyKwlgfxGiNlmxxLiWLUcYKA = list2[i];
				Guid sCGcrIIDMjURHdkJjDIzHoMbvWQHA = vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.SCGcrIIDMjURHdkJjDIzHoMbvWQHA;
				TGMNVgEkzYRUJhRlmEORKKDOgVur tGMNVgEkzYRUJhRlmEORKKDOgVur = new TGMNVgEkzYRUJhRlmEORKKDOgVur(VAyGDGfoHBoDUCWNaIhGjglCTLfid, sCGcrIIDMjURHdkJjDIzHoMbvWQHA);
				gpBLcVlZqGgKIWtsbZTXfOVfzRu gpBLcVlZqGgKIWtsbZTXfOVfzRu2 = tGMNVgEkzYRUJhRlmEORKKDOgVur.MRgfRfyrShjIzBYFIfiuqlDRKHEK;
				if (RAJQEbAWyYwUFSCjMGPbkXoUvsyi == null)
				{
					goto IL_00bd;
				}
				string text = vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.RqoeGgcphJkoXcPusfFTyPTciRntA.ToString();
				if (!RAJQEbAWyYwUFSCjMGPbkXoUvsyi.sGpbxaQopaOdreijKwIPSJCLFXaDA(gpBLcVlZqGgKIWtsbZTXfOVfzRu2.aGTEZUlonAkHkKOAbHOsSHTWgeRP, StringTools.SanitizeDeviceString(vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.mqjctEYgXEfZnYIDMMngJxDYpBhU), string.Empty, new PidVid(Convert.ToUInt16(text.Substring(0, 4), 16), Convert.ToUInt16(text.Substring(4, 4), 16))))
				{
					goto IL_00bd;
				}
				goto end_IL_0028;
				IL_00bd:
				if (GzUDgYjDOgnrtfxRQwsWQeValhgZA.uvhnxHbAUPoUSMfSJByuGIBPvWHt(InputSource.DirectInput, (ushort)gpBLcVlZqGgKIWtsbZTXfOVfzRu2.rQMHGWBVRINpDkLJvWbkZIiKbMlE, (ushort)gpBLcVlZqGgKIWtsbZTXfOVfzRu2.nKaqOeNeXtRFQyIiPrSeMOBlIXKe, (GzUDgYjDOgnrtfxRQwsWQeValhgZA.oTeeubsdtgUBkbEedSRoXqhHWiBd)3))
				{
					continue;
				}
				Guid guid = ((!string.IsNullOrEmpty(gpBLcVlZqGgKIWtsbZTXfOVfzRu2.aGTEZUlonAkHkKOAbHOsSHTWgeRP)) ? MiscTools.CreateGuidHashSHA256(gpBLcVlZqGgKIWtsbZTXfOVfzRu2.aGTEZUlonAkHkKOAbHOsSHTWgeRP) : vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.SCGcrIIDMjURHdkJjDIzHoMbvWQHA);
				bool flag = false;
				lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
				{
					if (uhsZTQOPiTWQesgStEowZrhIaYfdA != null)
					{
						for (int j = 0; j < uhsZTQOPiTWQesgStEowZrhIaYfdA.Count; j++)
						{
							if (uhsZTQOPiTWQesgStEowZrhIaYfdA[j] != null && uhsZTQOPiTWQesgStEowZrhIaYfdA[j].QrLkiuceluZEPMOcjJiYcdnvZQtl == guid)
							{
								tGMNVgEkzYRUJhRlmEORKKDOgVur = uhsZTQOPiTWQesgStEowZrhIaYfdA[j].UztXDfeobYvTILthUwbphNPSdKam.gpRRWpNgaNJmzGbrEaNwChwYyxtY;
								flag = true;
								break;
							}
						}
					}
				}
				zIwrdIIRBqtGNAiinYdFLQeQHQkI zIwrdIIRBqtGNAiinYdFLQeQHQkI2 = new zIwrdIIRBqtGNAiinYdFLQeQHQkI(new xNSYRpDpIMbnNUHRXFGqeEMHBNJH(tGMNVgEkzYRUJhRlmEORKKDOgVur, vAHBpckJKHZCGJbcfbZblVlgtziD), NBBGEOVRvneYDcFdnaoIhuFHZZKyB);
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.EJqnnacIsWkFjtZCidzSDEtnLNNd = vrUjHkyKwlgfxGiNlmxxLiWLUcYKA;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.QPMKBEqKVaycLpEwnGlOkcMWLImdb = vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.uDkFaTaDVTBjdRSJBdsDCFFkfZpzb;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.QrLkiuceluZEPMOcjJiYcdnvZQtl = guid;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.kdNvziqmWoxIlwtlUVdLVjQQNpFi = StringTools.SanitizeDeviceString(vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.mqjctEYgXEfZnYIDMMngJxDYpBhU);
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.OBMqGlmYgvImeZtYwRTuJWDjlzBA = vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.RqoeGgcphJkoXcPusfFTyPTciRntA;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.IUYnzsCagvejGAzueeqerINTTALG = (EjGdcVAZLVxPojHVzcAqTOhubwDQ)vrUjHkyKwlgfxGiNlmxxLiWLUcYKA.dTqvRoWTYLcyxOCegaoAeiVZAPTAb;
				LEfirOTPHLUuoddLAxYpKaFJbVcU lEfirOTPHLUuoddLAxYpKaFJbVcU = tGMNVgEkzYRUJhRlmEORKKDOgVur.gSKbQhPhCcxFkHCLeYWmJrvPjhbK;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.ZEcFSCcanLCalchLYPeeGgIDBkJOc = gpBLcVlZqGgKIWtsbZTXfOVfzRu2.nKaqOeNeXtRFQyIiPrSeMOBlIXKe;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.RHlGZiMcaSyNapvNcioouCFOtJwP = false;
				try
				{
					zIwrdIIRBqtGNAiinYdFLQeQHQkI2.SdthoJItTfcAKBEUPFiNJgcraHGZA = gpBLcVlZqGgKIWtsbZTXfOVfzRu2.BEwuJlSgrzvnNiHAkXqrckJVpxbD;
				}
				catch (Exception)
				{
					zIwrdIIRBqtGNAiinYdFLQeQHQkI2.SdthoJItTfcAKBEUPFiNJgcraHGZA = 0;
				}
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.HhqbiwBXcDTULYOwmAYexUsXBMtCA = lEfirOTPHLUuoddLAxYpKaFJbVcU.NqTKrVbLutsaVoXhctUGYVTTPWFS;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.MCDKyUJlmhQXfeayeJmoXfaHcWfiA = lEfirOTPHLUuoddLAxYpKaFJbVcU.JVqCHAvnctFGSlUdMoFcLkcNXrDA;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.nyDAXJEHgHLCMlTZKpdDYCOIRSQr = lEfirOTPHLUuoddLAxYpKaFJbVcU.gfDBhkyFyfyBIeMxjTnVOcGtibdX;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.wViVLSadDnEGnqutnjEyjJuLOUiq = new DirectInputControllerExtension(vrUjHkyKwlgfxGiNlmxxLiWLUcYKA, tGMNVgEkzYRUJhRlmEORKKDOgVur);
				ExAbibdcIBjCVVFBMYwefjdBwnAHA(zIwrdIIRBqtGNAiinYdFLQeQHQkI2, gpBLcVlZqGgKIWtsbZTXfOVfzRu2, out zIwrdIIRBqtGNAiinYdFLQeQHQkI2.AFhwApQSkQsoTcVBZLsyueSffmzg);
				try
				{
					string text2;
					try
					{
						text2 = gpBLcVlZqGgKIWtsbZTXfOVfzRu2.mqjctEYgXEfZnYIDMMngJxDYpBhU;
					}
					catch
					{
						text2 = zIwrdIIRBqtGNAiinYdFLQeQHQkI2.kdNvziqmWoxIlwtlUVdLVjQQNpFi;
					}
					if (oxnpOsktYNPBCHQjVFGasxxijJhX.eTXxmGUrhqkXkmIUddvNzHllUxBu((ushort)gpBLcVlZqGgKIWtsbZTXfOVfzRu2.rQMHGWBVRINpDkLJvWbkZIiKbMlE, (ushort)gpBLcVlZqGgKIWtsbZTXfOVfzRu2.nKaqOeNeXtRFQyIiPrSeMOBlIXKe, text2) && oxnpOsktYNPBCHQjVFGasxxijJhX.ioYfHYiwvxTlmMyRHoGOWMGGaVVYA((ushort)gpBLcVlZqGgKIWtsbZTXfOVfzRu2.rQMHGWBVRINpDkLJvWbkZIiKbMlE, (ushort)gpBLcVlZqGgKIWtsbZTXfOVfzRu2.nKaqOeNeXtRFQyIiPrSeMOBlIXKe, text2, out var num, out var num2, out var num3))
					{
						zIwrdIIRBqtGNAiinYdFLQeQHQkI2.UztXDfeobYvTILthUwbphNPSdKam.xzjJyMPCOaiegrSPtDMBGgzXDynKA(num, num2, num3, oxnpOsktYNPBCHQjVFGasxxijJhX.qLarYZTuGnoUYwrQVLgNACTZXFi((ushort)gpBLcVlZqGgKIWtsbZTXfOVfzRu2.rQMHGWBVRINpDkLJvWbkZIiKbMlE, (ushort)gpBLcVlZqGgKIWtsbZTXfOVfzRu2.nKaqOeNeXtRFQyIiPrSeMOBlIXKe, text2));
					}
				}
				catch (Exception)
				{
				}
				if (!flag)
				{
					IList<mGCtkWxfHNgipjpNJrPlMcYgiHAeb> list3 = tGMNVgEkzYRUJhRlmEORKKDOgVur.hQiEBbgKRTDSiRPBLPKoZEyKJffcb();
					if (list3 != null)
					{
						for (int k = 0; k < list3.Count; k++)
						{
							if ((list3[k].dYOWBIwnTrqHAAMOZUTcVjxMVIUK.PRRpOkhGRpmYTaxqZbRqgXTDKOHx & AZnevqKCIWQlsGzMgiuOiXlPUErU.Axis) != AZnevqKCIWQlsGzMgiuOiXlPUErU.All)
							{
								tGMNVgEkzYRUJhRlmEORKKDOgVur.MRgfRfyrShjIzBYFIfiuqlDRKHEK.WfXVhhnLaBVsKHneEGAORYsOycyh = new tQFeFLIIfwDkSIttciiqLHyRENsoB(-65535, 65535);
							}
						}
					}
					tGMNVgEkzYRUJhRlmEORKKDOgVur.MRgfRfyrShjIzBYFIfiuqlDRKHEK.jxfJmdiVXshlqKpBlHLQatSYpnVb = rbUZaVyNPbIDCREgPgYXbrfrepDHb.Absolute;
					tGMNVgEkzYRUJhRlmEORKKDOgVur.RyDgfJBKOoZHWSmNRzkfVdzloWnCb(EiBBsdJiTwHqmUCtjqJHAQyKnVevA, ALSHLCyZtschdcePilNaAgrSiFnt.NonExclusive | ALSHLCyZtschdcePilNaAgrSiFnt.Background);
					tGMNVgEkzYRUJhRlmEORKKDOgVur.qqTnUdwDLRDdijbuOGAyBhNivyaqA();
				}
				list.Add(new DQscgTnXpbHrcPbwtccrbMAGbZNS(zIwrdIIRBqtGNAiinYdFLQeQHQkI2, vrUjHkyKwlgfxGiNlmxxLiWLUcYKA));
				end_IL_0028:;
			}
			catch (Exception)
			{
			}
		}
		return list;
	}

	private void AAGmHSjMDwQszCAmDVQTJjAYItxo()
	{
		tphcAVwbEAgoLdXQLMrcJiwpwpbGA(OutlNjmPWwcZWCySkWmTCgJRlVBZA());
	}

	private void tphcAVwbEAgoLdXQLMrcJiwpwpbGA(List<DQscgTnXpbHrcPbwtccrbMAGbZNS> P_0)
	{
		List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> list = new List<zIwrdIIRBqtGNAiinYdFLQeQHQkI>();
		swmRTJqVxWnOYVJrkoQeCdJBLAgi = 0;
		int num = P_0?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			if (P_0[i] == null || !P_0[i].LOAKUriHGZEbByAroDTyQAHhOjqU)
			{
				continue;
			}
			try
			{
				zIwrdIIRBqtGNAiinYdFLQeQHQkI dUxVIgaadrfqJWSzRpXGORZlkMqp = P_0[i].dUxVIgaadrfqJWSzRpXGORZlkMqp;
				dUxVIgaadrfqJWSzRpXGORZlkMqp.OKLfbagyaudIxlHWyOTBXIXfgzkUA();
				if (dUxVIgaadrfqJWSzRpXGORZlkMqp.jrbdcQFpFxHLlTlwtpmmDUBJcizi)
				{
					swmRTJqVxWnOYVJrkoQeCdJBLAgi++;
				}
				list.Add(dUxVIgaadrfqJWSzRpXGORZlkMqp);
			}
			catch (Exception)
			{
			}
		}
		OzVJhmrhdYiOIfqPxxcRStZoGEHab.UAyelYsfECWGarrXYrMPseXTcamJA(swmRTJqVxWnOYVJrkoQeCdJBLAgi);
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> list2 = uhsZTQOPiTWQesgStEowZrhIaYfdA;
			int dUhRAPCUFyXuQrAMVOAIBoZHcooH = DUhRAPCUFyXuQrAMVOAIBoZHcooH;
			int count = list.Count;
			yCerSzlhCsNqVTmGzxfvEztWrZKJ(dUhRAPCUFyXuQrAMVOAIBoZHcooH, count, list2, list);
			for (int j = 0; j < count; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(list[j]));
				}
			}
			lZhwEqQAMUuThvcqBsjRFkkUsOxO(list2, list, false);
			lZhwEqQAMUuThvcqBsjRFkkUsOxO(list, list2, true);
			zkmoaYhFlntSTKXzHggUqIlLVyOB(list, list2);
			uhsZTQOPiTWQesgStEowZrhIaYfdA = list;
			DUhRAPCUFyXuQrAMVOAIBoZHcooH = list.Count;
		}
	}

	private void ExAbibdcIBjCVVFBMYwefjdBwnAHA(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0, gpBLcVlZqGgKIWtsbZTXfOVfzRu P_1, out string P_2)
	{
		P_2 = string.Empty;
		if (P_0 == null || P_1 == null)
		{
			return;
		}
		string text = lwshpSMnJWtuMNOqALbpKPklMmTj.KWVrgygWsvBoZLExmDoqwQDsyzMC(P_1.aGTEZUlonAkHkKOAbHOsSHTWgeRP);
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		try
		{
			VEavlBCjlwYFgIYiKEZpvYEuUTOH vEavlBCjlwYFgIYiKEZpvYEuUTOH = ASYbPqxUNkljqzCsqWpbFAZdrPyP.sfgSppgWvIxapBqNojhdhoVzjjRd(text.ToLower(CultureInfo.InvariantCulture));
			if (vEavlBCjlwYFgIYiKEZpvYEuUTOH != null)
			{
				P_0.jrbdcQFpFxHLlTlwtpmmDUBJcizi = vEavlBCjlwYFgIYiKEZpvYEuUTOH.MpuQBNhsGfnlifDQFONVPCMzxEIi;
				P_0.fCTsNqmwahVpnfulngJdKbKIGXmfA = vEavlBCjlwYFgIYiKEZpvYEuUTOH.iAlThlvTdFBnLFoKOqPsWaWpHQQV;
				P_2 = GzUDgYjDOgnrtfxRQwsWQeValhgZA.kxdzDxRnsrgfCvBzDwfkdynRPnCA(vEavlBCjlwYFgIYiKEZpvYEuUTOH, P_0.OBMqGlmYgvImeZtYwRTuJWDjlzBA, P_0.kdNvziqmWoxIlwtlUVdLVjQQNpFi, P_0.fCTsNqmwahVpnfulngJdKbKIGXmfA);
				vEavlBCjlwYFgIYiKEZpvYEuUTOH.Dispose();
			}
		}
		catch (Exception)
		{
		}
	}

	private void HuQMjaeKUlhtoxviEIRhkVYsSmvt()
	{
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			for (int i = 0; i < DUhRAPCUFyXuQrAMVOAIBoZHcooH; i++)
			{
				try
				{
					zIwrdIIRBqtGNAiinYdFLQeQHQkI zIwrdIIRBqtGNAiinYdFLQeQHQkI2 = uhsZTQOPiTWQesgStEowZrhIaYfdA[i];
					if (zIwrdIIRBqtGNAiinYdFLQeQHQkI2 != null && zIwrdIIRBqtGNAiinYdFLQeQHQkI2.qNRFgbeBPuuxzAiRNMsKAqIJVAFxA() && (gEpmfiCrZuBIAUDisEAEyJZbwgaX == null || !zIwrdIIRBqtGNAiinYdFLQeQHQkI2.RHlGZiMcaSyNapvNcioouCFOtJwP))
					{
						zIwrdIIRBqtGNAiinYdFLQeQHQkI2.Update();
					}
				}
				catch
				{
				}
			}
		}
	}

	private IList<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> VhAqCbIcOZwXiyKvCEacyOgdnjqU()
	{
		try
		{
			IList<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> list = VAyGDGfoHBoDUCWNaIhGjglCTLfid.LRVtwyTWSgrntlaZRBVqrFfsbLRz(pXLCPSuuAhzcgGmkJbVkDzXovEub.GameControl, XsxUPjMGXXOzFHWjBirlaEPOLxzP.AttachedOnly);
			qOHLZbBxOYueWNpQMJFtAwMWpUyg = list?.Count ?? 0;
			return list;
		}
		catch
		{
			Logger.LogError("Error getting devices from Direct Input!");
			qOHLZbBxOYueWNpQMJFtAwMWpUyg = 0;
			return EmptyObjects<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA>.EmptyReadOnlyIListT;
		}
	}

	private void TZzFLUwbDHyIHNkwrBcFIdPpLANSA()
	{
		VAyGDGfoHBoDUCWNaIhGjglCTLfid.LRVtwyTWSgrntlaZRBVqrFfsbLRz();
	}

	private void yCerSzlhCsNqVTmGzxfvEztWrZKJ(int P_0, int P_1, List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_2, List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(zIwrdIIRBqtGNAiinYdFLQeQHQkI.zwMWCtrjmRXclllojCXTsqEOCgiP);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			wuaCIwaEhsQfxmqZgODZijGGOoeHb(P_1, P_3, P_0, P_2, PgmSPLMBJcejfXxSZvRcdpyniujo.fivUglccsOGTfztFkSsrGApCQqxO.Exact);
		}
		smcCiZysONMbkSQvFgYTXeMDHzls(P_1, P_3, PgmSPLMBJcejfXxSZvRcdpyniujo.fivUglccsOGTfztFkSsrGApCQqxO.Exact);
		for (int i = 0; i < P_1; i++)
		{
			zIwrdIIRBqtGNAiinYdFLQeQHQkI zIwrdIIRBqtGNAiinYdFLQeQHQkI2 = P_3[i];
			if (zIwrdIIRBqtGNAiinYdFLQeQHQkI2 != null && zIwrdIIRBqtGNAiinYdFLQeQHQkI2.inputManagerId < 0)
			{
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.inputManagerId = LPWxxllcQTgkueLabuveIFxjmWShA(P_3);
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.rewiredId = OlamnlbqCRkOUMBSkakeUghSoraE();
				dFjjWhTvzPgWCbHejcNwKYxKBSaM.HgZeolIOSfnlKNNDACCahiudRKNec(zIwrdIIRBqtGNAiinYdFLQeQHQkI2);
			}
		}
		P_3.Sort(zIwrdIIRBqtGNAiinYdFLQeQHQkI.WoOaAbIBZmsaPWyNgRCmOFZeLysOA);
	}

	private void NcHJyIKkRfIZStZZRCRMlYNzGMob(List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_0, int P_1, int P_2)
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

	private bool FbgGsqaEobfojdDLkZawNsMubCOvA(List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_0, int P_1)
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

	private int LPWxxllcQTgkueLabuveIFxjmWShA(List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_0)
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

	private bool DfAHMpnyMaKopMatiqeimNyLHtBb(List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_0, int P_1)
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

	private void wuaCIwaEhsQfxmqZgODZijGGOoeHb(int P_0, List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_1, int P_2, List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_3, PgmSPLMBJcejfXxSZvRcdpyniujo.fivUglccsOGTfztFkSsrGApCQqxO P_4)
	{
		int num = ((P_4 != PgmSPLMBJcejfXxSZvRcdpyniujo.fivUglccsOGTfztFkSsrGApCQqxO.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			zIwrdIIRBqtGNAiinYdFLQeQHQkI zIwrdIIRBqtGNAiinYdFLQeQHQkI2 = P_1[i];
			if (zIwrdIIRBqtGNAiinYdFLQeQHQkI2 == null || zIwrdIIRBqtGNAiinYdFLQeQHQkI2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				zIwrdIIRBqtGNAiinYdFLQeQHQkI zIwrdIIRBqtGNAiinYdFLQeQHQkI3 = P_3[j];
				if (zIwrdIIRBqtGNAiinYdFLQeQHQkI3 != null && !DfAHMpnyMaKopMatiqeimNyLHtBb(P_1, zIwrdIIRBqtGNAiinYdFLQeQHQkI3.rewiredId) && zIwrdIIRBqtGNAiinYdFLQeQHQkI2.sKPmsOwrsqQUGaDeDiygzRJgUHm(zIwrdIIRBqtGNAiinYdFLQeQHQkI3) >= num)
				{
					zIwrdIIRBqtGNAiinYdFLQeQHQkI2.OLfmjaYQlzgJtGmEIVCoLPHHLIfZ(zIwrdIIRBqtGNAiinYdFLQeQHQkI3);
					dFjjWhTvzPgWCbHejcNwKYxKBSaM.HgZeolIOSfnlKNNDACCahiudRKNec(zIwrdIIRBqtGNAiinYdFLQeQHQkI2);
				}
			}
		}
	}

	private void smcCiZysONMbkSQvFgYTXeMDHzls(int P_0, List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_1, PgmSPLMBJcejfXxSZvRcdpyniujo.fivUglccsOGTfztFkSsrGApCQqxO P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			zIwrdIIRBqtGNAiinYdFLQeQHQkI zIwrdIIRBqtGNAiinYdFLQeQHQkI2 = P_1[i];
			if (zIwrdIIRBqtGNAiinYdFLQeQHQkI2 == null || zIwrdIIRBqtGNAiinYdFLQeQHQkI2.inputManagerId >= 0)
			{
				continue;
			}
			PgmSPLMBJcejfXxSZvRcdpyniujo.RSKelmIKLSkjortusEGIyflVVuPS rSKelmIKLSkjortusEGIyflVVuPS = null;
			foreach (PgmSPLMBJcejfXxSZvRcdpyniujo.RSKelmIKLSkjortusEGIyflVVuPS item in dFjjWhTvzPgWCbHejcNwKYxKBSaM.OoDdjwkheCaHvrmPJPlqsPWCeYVtA(zIwrdIIRBqtGNAiinYdFLQeQHQkI2, P_2))
			{
				if (!DfAHMpnyMaKopMatiqeimNyLHtBb(P_1, item.yezDqSCRWxhlxMjsXiQKzSGNMhog) && item.wsDsfjzHKLzCJcIILWEhQVQklLQu >= 0)
				{
					rSKelmIKLSkjortusEGIyflVVuPS = item;
					break;
				}
			}
			if (rSKelmIKLSkjortusEGIyflVVuPS != null)
			{
				int num = rSKelmIKLSkjortusEGIyflVVuPS.wsDsfjzHKLzCJcIILWEhQVQklLQu;
				if (!FbgGsqaEobfojdDLkZawNsMubCOvA(P_1, num))
				{
					num = (rSKelmIKLSkjortusEGIyflVVuPS.wsDsfjzHKLzCJcIILWEhQVQklLQu = LPWxxllcQTgkueLabuveIFxjmWShA(P_1));
				}
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.inputManagerId = num;
				zIwrdIIRBqtGNAiinYdFLQeQHQkI2.rewiredId = rSKelmIKLSkjortusEGIyflVVuPS.yezDqSCRWxhlxMjsXiQKzSGNMhog;
				dFjjWhTvzPgWCbHejcNwKYxKBSaM.HgZeolIOSfnlKNNDACCahiudRKNec(zIwrdIIRBqtGNAiinYdFLQeQHQkI2);
			}
		}
	}

	private void FUnOAYKrPGQnYrEjeUvOZtyzGhVe()
	{
		if (fKdECYTEMkHBabIJrseQcfdKSMfsA)
		{
			tPJeYtIjeCijeGcijckJYYtMscvw();
		}
		if (CIGbdCwzRSAhHGwgZNwOtaEqgfZw.RTnbdebLTdTeohXHDoBoLyQGImfWA && CIGbdCwzRSAhHGwgZNwOtaEqgfZw.TPcqcKWeqJnMdeNkqZXytbyidUBn())
		{
			qYzploxFNRIjWyUyiDlZFiYzKmCHb(CIGbdCwzRSAhHGwgZNwOtaEqgfZw.uSwyJUCsSdiGPcMJmfFpIGVFqnMMA);
		}
	}

	private void tPJeYtIjeCijeGcijckJYYtMscvw()
	{
		fKdECYTEMkHBabIJrseQcfdKSMfsA = false;
		if (!CIGbdCwzRSAhHGwgZNwOtaEqgfZw.RTnbdebLTdTeohXHDoBoLyQGImfWA)
		{
			CIGbdCwzRSAhHGwgZNwOtaEqgfZw.miPFrJiYaYbOloaoCfGOcsRcMhAoc();
		}
	}

	private void qYzploxFNRIjWyUyiDlZFiYzKmCHb(List<DQscgTnXpbHrcPbwtccrbMAGbZNS> P_0)
	{
		if (ZQeObJRNMFLkBQHlsgdMEEcsbbjcb(DQscgTnXpbHrcPbwtccrbMAGbZNS.qCHcCyCziRquAonrFHNFoZicfYj(P_0)))
		{
			tphcAVwbEAgoLdXQLMrcJiwpwpbGA(P_0);
		}
	}

	private bool ZQeObJRNMFLkBQHlsgdMEEcsbbjcb(IList<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> P_0)
	{
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i] != null && !KbBeKArMJduJpEIezPVKEIfBUzIm(P_0[i].SCGcrIIDMjURHdkJjDIzHoMbvWQHA))
				{
					return true;
				}
			}
			int count2 = uhsZTQOPiTWQesgStEowZrhIaYfdA.Count;
			for (int j = 0; j < count2; j++)
			{
				if (uhsZTQOPiTWQesgStEowZrhIaYfdA[j] != null && !xqJQtvnljRCODgaLQIhgcKPevtxLb(P_0, uhsZTQOPiTWQesgStEowZrhIaYfdA[j].instanceGuid))
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool KbBeKArMJduJpEIezPVKEIfBUzIm(Guid P_0)
	{
		lock (eTRoskBdTVJraCzYFXNyrUomeHqE)
		{
			int count = uhsZTQOPiTWQesgStEowZrhIaYfdA.Count;
			for (int i = 0; i < count; i++)
			{
				if (uhsZTQOPiTWQesgStEowZrhIaYfdA[i] != null && uhsZTQOPiTWQesgStEowZrhIaYfdA[i].instanceGuid == P_0)
				{
					return true;
				}
			}
		}
		return false;
	}

	private bool xqJQtvnljRCODgaLQIhgcKPevtxLb(IList<VrUjHkyKwlgfxGiNlmxxLiWLUcYKA> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].SCGcrIIDMjURHdkJjDIzHoMbvWQHA == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void lZhwEqQAMUuThvcqBsjRFkkUsOxO(List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_0, List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			zIwrdIIRBqtGNAiinYdFLQeQHQkI zIwrdIIRBqtGNAiinYdFLQeQHQkI2 = P_0[i];
			if (zIwrdIIRBqtGNAiinYdFLQeQHQkI2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					zIwrdIIRBqtGNAiinYdFLQeQHQkI zIwrdIIRBqtGNAiinYdFLQeQHQkI3 = P_1[j];
					if (zIwrdIIRBqtGNAiinYdFLQeQHQkI3 != null && zIwrdIIRBqtGNAiinYdFLQeQHQkI2.instanceGuid == zIwrdIIRBqtGNAiinYdFLQeQHQkI3.instanceGuid)
					{
						flag = true;
						break;
					}
				}
			}
			if (!flag)
			{
				VTTdBYSqcQzDyOFRkPCEjraxYldu(P_0[i], P_2);
			}
		}
	}

	private void VTTdBYSqcQzDyOFRkPCEjraxYldu(zIwrdIIRBqtGNAiinYdFLQeQHQkI P_0, bool P_1)
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

	private bool hlYThrhBPFAnHYctCqFGaKHosEGR()
	{
		int num = VAyGDGfoHBoDUCWNaIhGjglCTLfid.MAMHkSqdTslvpHFZqrSKDkgwpZrh(pXLCPSuuAhzcgGmkJbVkDzXovEub.GameControl, XsxUPjMGXXOzFHWjBirlaEPOLxzP.AttachedOnly);
		if (qOHLZbBxOYueWNpQMJFtAwMWpUyg != num)
		{
			qOHLZbBxOYueWNpQMJFtAwMWpUyg = num;
			return true;
		}
		if (swmRTJqVxWnOYVJrkoQeCdJBLAgi > 0 && OzVJhmrhdYiOIfqPxxcRStZoGEHab.uEgWhdjcbXHGoErtZVrbrzEhnfJOA())
		{
			return true;
		}
		return false;
	}

	private void zkmoaYhFlntSTKXzHggUqIlLVyOB(List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_0, List<zIwrdIIRBqtGNAiinYdFLQeQHQkI> P_1)
	{
		if (P_1 == null)
		{
			return;
		}
		for (int i = 0; i < P_1.Count; i++)
		{
			if (P_1[i] != null && (P_0 == null || !P_0.Contains(P_1[i])))
			{
				P_1[i].vCBFvIdHsbAnKBZkroQOsRrLIAyV();
			}
		}
	}

	[Conditional("DEBUGTHIS")]
	private void lwCBVDAbeaNaVmmdfPhLmMkrNgUe(string P_0)
	{
		Logger.Log(P_0);
	}

	[CompilerGenerated]
	private List<DQscgTnXpbHrcPbwtccrbMAGbZNS> iBLkymCXAAOxzwdHKFpgmHPBeZwC()
	{
		return OutlNjmPWwcZWCySkWmTCgJRlVBZA();
	}
}
