using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.InputSources.SDL2;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class zWPkUtSGvOgInpdmaKYzxHsbJAyr : PlatformInputManager
{
	private class elhFAIfVKvQFWaQKTojBNMnedwlEA : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int tMlFMbbnSDaAYEdgwltrYDupMlKyA;

		private int ouIAxHJkHCqySFVaXBWVUCAlcjwjA;

		public Guid dfkNjaPwXkaeRLYwmoTrUJWHbEfc;

		public string dOwZfeJoWhhATUmPdsXZbdgVvtHW;

		public HaOkodQgKHTDiFuGZKtkAaEJxnaG dUxVIgaadrfqJWSzRpXGORZlkMqp;

		public xMczuBVVFCuEcbmnmSBpCriNqRRM mgfmGZeLtXcIMfABdmrEeVZBiEBOB;

		public string lBggkBnQrnGmLonsLyCRpnRHYBpi;

		public string snGLuuyMCPOtXxLfVtXHzWVouQKy;

		public int ZEcFSCcanLCalchLYPeeGgIDBkJOc;

		public int lbWMRbOepNXIBicDWdlXEMxnAbpmA;

		public Guid QrLkiuceluZEPMOcjJiYcdnvZQtl;

		public PidVid tNjxagUrcnyzWbSOsVMIFxUTEAOE;

		public Guid iFObMCUaUQUnWzybrqxSRAVRTBWI;

		public int SdthoJItTfcAKBEUPFiNJgcraHGZA;

		public int UDFcKRicGfzUGfNrRKCnISkDnKMVb;

		public int FkOzkpBIpGDDNocsckZjSKLgiIVv;

		public int HhqbiwBXcDTULYOwmAYexUsXBMtCA;

		public int MCDKyUJlmhQXfeayeJmoXfaHcWfiA;

		public int nyDAXJEHgHLCMlTZKpdDYCOIRSQr;

		public bool jrbdcQFpFxHLlTlwtpmmDUBJcizi;

		public bool SFHEoLFtkmPWaGuXCKXjAhXIeZUVA;

		public int JRVaqxBKatYgbGYyeEJbKTzddNthb;

		private float[] dydcbiMQDPlMCvQZIVaFxWCilYKQ;

		private bool[] JkLuaNrBfUjBFJFAynrFZsuAKJMTA;

		private HardwareJoystickMap_InputManager hJeYXuujpZcIHhUzFngZZNyaunJy;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> NBBGEOVRvneYDcFdnaoIhuFHZZKyB;

		private bool YCkiTXGFGImEpYaQgYLZkdDBKpFdb;

		private bool zGsfYreSUFOtjBTyHnkmVUNXLXYnA;

		[CompilerGenerated]
		private Controller.Extension wkKLTZPqxJeoYeWOgYoOpAFbTpVS;

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
		public string name => dOwZfeJoWhhATUmPdsXZbdgVvtHW;

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
		public Guid instanceGuid => QrLkiuceluZEPMOcjJiYcdnvZQtl;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return wkKLTZPqxJeoYeWOgYoOpAFbTpVS;
			}
			[CompilerGenerated]
			set
			{
				wkKLTZPqxJeoYeWOgYoOpAFbTpVS = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			dUxVIgaadrfqJWSzRpXGORZlkMqp.SSYDhArzaqosllxWhbucIiAwdyFZ(motorIndex, amount, false);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public elhFAIfVKvQFWaQKTojBNMnedwlEA(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			NBBGEOVRvneYDcFdnaoIhuFHZZKyB = P_0;
			ouIAxHJkHCqySFVaXBWVUCAlcjwjA = -1;
			tMlFMbbnSDaAYEdgwltrYDupMlKyA = -1;
		}

		public void OKLfbagyaudIxlHWyOTBXIXfgzkUA()
		{
			iFObMCUaUQUnWzybrqxSRAVRTBWI = MiscTools.CreateGuidHashSHA1(lBggkBnQrnGmLonsLyCRpnRHYBpi + tNjxagUrcnyzWbSOsVMIFxUTEAOE.ToProductGuid().ToString());
			UDFcKRicGfzUGfNrRKCnISkDnKMVb = HhqbiwBXcDTULYOwmAYexUsXBMtCA;
			FkOzkpBIpGDDNocsckZjSKLgiIVv = MCDKyUJlmhQXfeayeJmoXfaHcWfiA + nyDAXJEHgHLCMlTZKpdDYCOIRSQr * 8;
			bfkxPXlKJejmTALFktyasdIIxRKhA();
			dfkNjaPwXkaeRLYwmoTrUJWHbEfc = hJeYXuujpZcIHhUzFngZZNyaunJy.hardwareMapIdentifier.guid;
			dOwZfeJoWhhATUmPdsXZbdgVvtHW = hJeYXuujpZcIHhUzFngZZNyaunJy.controllerName;
			YCkiTXGFGImEpYaQgYLZkdDBKpFdb = ((dfkNjaPwXkaeRLYwmoTrUJWHbEfc == Guid.Empty) ? true : false);
			dydcbiMQDPlMCvQZIVaFxWCilYKQ = new float[UDFcKRicGfzUGfNrRKCnISkDnKMVb];
			JkLuaNrBfUjBFJFAynrFZsuAKJMTA = new bool[FkOzkpBIpGDDNocsckZjSKLgiIVv];
			Update();
		}

		public void OLfmjaYQlzgJtGmEIVCoLPHHLIfZ(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0)
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
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			yznGbdDyUyOPfduhykPAGCjaQExNc();
			RdPFzuLpsssVUfJbWIHhRQPBGScT();
			if (!zGsfYreSUFOtjBTyHnkmVUNXLXYnA && dUxVIgaadrfqJWSzRpXGORZlkMqp.LnexytcRMRFtiQTXussUvARXgQwf)
			{
				zGsfYreSUFOtjBTyHnkmVUNXLXYnA = true;
			}
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

		public int sKPmsOwrsqQUGaDeDiygzRJgUHm(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0)
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
			if (P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl == QrLkiuceluZEPMOcjJiYcdnvZQtl)
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

		private void yznGbdDyUyOPfduhykPAGCjaQExNc()
		{
			if (UDFcKRicGfzUGfNrRKCnISkDnKMVb <= 0 || hJeYXuujpZcIHhUzFngZZNyaunJy.map.platform != InputPlatform.SDL2)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL2_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					fnaaXRUCVpwvwWRollOpWEKUdiW(axes_orig[i], i);
				}
			}
		}

		private void RdPFzuLpsssVUfJbWIHhRQPBGScT()
		{
			if (FkOzkpBIpGDDNocsckZjSKLgiIVv <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL2_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					fMcAkgWDJulDGPRxZIXwdBJxCLsGA(buttons_orig[i], i);
				}
			}
		}

		private void fnaaXRUCVpwvwWRollOpWEKUdiW(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= UDFcKRicGfzUGfNrRKCnISkDnKMVb)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			dydcbiMQDPlMCvQZIVaFxWCilYKQ[P_1] = mkqEwjEWKTccoblNpohIPzhMuvaL(P_0);
		}

		private void fMcAkgWDJulDGPRxZIXwdBJxCLsGA(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= FkOzkpBIpGDDNocsckZjSKLgiIVv)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			JkLuaNrBfUjBFJFAynrFZsuAKJMTA[P_1] = MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0);
		}

		private float mkqEwjEWKTccoblNpohIPzhMuvaL(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= HhqbiwBXcDTULYOwmAYexUsXBMtCA || sourceAxis >= 56)
				{
					return 0f;
				}
				return dUxVIgaadrfqJWSzRpXGORZlkMqp.mkqEwjEWKTccoblNpohIPzhMuvaL(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= MCDKyUJlmhQXfeayeJmoXfaHcWfiA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!dUxVIgaadrfqJWSzRpXGORZlkMqp.MSdCYQsaMwqrghCGBIFNcNtyaXdm(sourceButton))
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
				int num = dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat);
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
			return 0f;
		}

		private bool MSdCYQsaMwqrghCGBIFNcNtyaXdm(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (dUxVIgaadrfqJWSzRpXGORZlkMqp.MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!dUxVIgaadrfqJWSzRpXGORZlkMqp.MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= MCDKyUJlmhQXfeayeJmoXfaHcWfiA || sourceButton >= 256)
				{
					return false;
				}
				return dUxVIgaadrfqJWSzRpXGORZlkMqp.MSdCYQsaMwqrghCGBIFNcNtyaXdm(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= HhqbiwBXcDTULYOwmAYexUsXBMtCA || sourceAxis >= 56)
				{
					return false;
				}
				float num = dUxVIgaadrfqJWSzRpXGORZlkMqp.mkqEwjEWKTccoblNpohIPzhMuvaL(sourceAxis);
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
					return AEmeApyTXmVHqZHavQCdsWjXewZB(dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return AEmeApyTXmVHqZHavQCdsWjXewZB(dUxVIgaadrfqJWSzRpXGORZlkMqp.bwSacbDVxuNnabflxysnTdPFpaBB(sourceHat), 7, P_0.sourceHatType);
				}
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

		private ControlDeviceType glbeGVKgDjVchnlnRJUVEcYFDXSL(xMczuBVVFCuEcbmnmSBpCriNqRRM P_0)
		{
			switch (P_0)
			{
			case xMczuBVVFCuEcbmnmSBpCriNqRRM.Joystick:
				return ControlDeviceType.Joystick;
			case xMczuBVVFCuEcbmnmSBpCriNqRRM.Gamepad:
				return ControlDeviceType.Gamepad;
			case xMczuBVVFCuEcbmnmSBpCriNqRRM.Keyboard:
				return ControlDeviceType.Keyboard;
			case xMczuBVVFCuEcbmnmSBpCriNqRRM.Mouse:
				return ControlDeviceType.Mouse;
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
			if (hJeYXuujpZcIHhUzFngZZNyaunJy.useSystemName)
			{
				if (!string.IsNullOrEmpty(snGLuuyMCPOtXxLfVtXHzWVouQKy))
				{
					string text = Regex.Replace(snGLuuyMCPOtXxLfVtXHzWVouQKy, "\\s+", " ");
					text = text.Trim();
					if (!string.IsNullOrEmpty(text))
					{
						hJeYXuujpZcIHhUzFngZZNyaunJy.controllerName = text;
					}
				}
				if (hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.parentKeys[0]))
				{
					string a = hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.parentKeys[0];
					string text2 = string.Format("{0}:{1}", dUxVIgaadrfqJWSzRpXGORZlkMqp.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA.vendorId.ToString("x4"), dUxVIgaadrfqJWSzRpXGORZlkMqp.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA.productId.ToString("x4"));
					hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.InsertParentKey(0, LocalizationManager.AppendToKeyAsPath(a, text2));
					if (!string.IsNullOrEmpty(dUxVIgaadrfqJWSzRpXGORZlkMqp.oWpCUWdTGUxPJhGLprVHSmZsZZYBA))
					{
						hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.InsertParentKey(1, LocalizationManager.AppendToKeyAsPath(a, dUxVIgaadrfqJWSzRpXGORZlkMqp.oWpCUWdTGUxPJhGLprVHSmZsZZYBA));
					}
					if (!string.IsNullOrEmpty(dUxVIgaadrfqJWSzRpXGORZlkMqp.oWpCUWdTGUxPJhGLprVHSmZsZZYBA))
					{
						hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.additionalIdentifyingInformation = $"{dUxVIgaadrfqJWSzRpXGORZlkMqp.oWpCUWdTGUxPJhGLprVHSmZsZZYBA} [{text2}]";
					}
					else
					{
						hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
					}
				}
			}
			UDFcKRicGfzUGfNrRKCnISkDnKMVb = hJeYXuujpZcIHhUzFngZZNyaunJy.axisCount;
			FkOzkpBIpGDDNocsckZjSKLgiIVv = hJeYXuujpZcIHhUzFngZZNyaunJy.buttonCount;
		}

		private string pSdBCmdydqRtEhPXXoHSKfoiLscd()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{dUxVIgaadrfqJWSzRpXGORZlkMqp.ETYQlWrHMsDuymSvhSEBrhZjAPnu}{lBggkBnQrnGmLonsLyCRpnRHYBpi}{ZEcFSCcanLCalchLYPeeGgIDBkJOc}{tNjxagUrcnyzWbSOsVMIFxUTEAOE.ToProductGuid()}");
		}

		private void QEJmtREKifDoriOcevlcZbMJbDfL(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = dUxVIgaadrfqJWSzRpXGORZlkMqp.ETYQlWrHMsDuymSvhSEBrhZjAPnu;
			P_0.deviceType = glbeGVKgDjVchnlnRJUVEcYFDXSL(mgfmGZeLtXcIMfABdmrEeVZBiEBOB);
			P_0.hardwareIdentifier = pSdBCmdydqRtEhPXXoHSKfoiLscd();
			P_0.hardwareAxisCount = HhqbiwBXcDTULYOwmAYexUsXBMtCA;
			P_0.hardwareButtonCount = MCDKyUJlmhQXfeayeJmoXfaHcWfiA;
			P_0.hardwareHatCount = nyDAXJEHgHLCMlTZKpdDYCOIRSQr;
			P_0.hw_productName = lBggkBnQrnGmLonsLyCRpnRHYBpi;
			P_0.hw_deviceGuid = QrLkiuceluZEPMOcjJiYcdnvZQtl;
			P_0.hw_productId = ZEcFSCcanLCalchLYPeeGgIDBkJOc;
			P_0.hw_pidVid = tNjxagUrcnyzWbSOsVMIFxUTEAOE;
			P_0.hw_isBluetoothDevice = jrbdcQFpFxHLlTlwtpmmDUBJcizi;
			P_0.hw_bluetoothDeviceName = lBggkBnQrnGmLonsLyCRpnRHYBpi;
			P_0.hw_systemDeviceName = lBggkBnQrnGmLonsLyCRpnRHYBpi;
			P_0.hw_supportsVibration = SFHEoLFtkmPWaGuXCKXjAhXIeZUVA;
			P_0.hw_isSDL2Gamepad = dUxVIgaadrfqJWSzRpXGORZlkMqp.KpLgfiTwKVmJnHrLykvAtjznonIo == xMczuBVVFCuEcbmnmSBpCriNqRRM.Gamepad;
			P_0.hw_localVibrationMotorCount = JRVaqxBKatYgbGYyeEJbKTzddNthb;
		}

		private void QEJmtREKifDoriOcevlcZbMJbDfL(BridgedController P_0)
		{
			QEJmtREKifDoriOcevlcZbMJbDfL((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = hJeYXuujpZcIHhUzFngZZNyaunJy.ToGameHardwareControllerMap();
			P_0.instanceName = lBggkBnQrnGmLonsLyCRpnRHYBpi;
			P_0.productName = lBggkBnQrnGmLonsLyCRpnRHYBpi;
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

		public static int ejhPQanSJmRJtgOzIiIJfBzXGfjcA(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0, elhFAIfVKvQFWaQKTojBNMnedwlEA P_1)
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

		public static int iPBJsEMpHEalRFrTLHdxePyElzOJA(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0, elhFAIfVKvQFWaQKTojBNMnedwlEA P_1)
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

	private class VcNxTWIAMgulAmpBIELyqcVVNpNV
	{
		public enum cAWkESLMSLWUAeMnmeERbVTEdMyn
		{
			Exact = 0,
			Approximate = 1
		}

		public class aAnBMLEiUSFWWYowWvJkUZUPtUgN
		{
			public int yezDqSCRWxhlxMjsXiQKzSGNMhog;

			public Guid auRhMsSNSGdZKHBllYUoMazgzoCbA;

			public Guid iFObMCUaUQUnWzybrqxSRAVRTBWI;

			public int wsDsfjzHKLzCJcIILWEhQVQklLQu;

			public int HhqbiwBXcDTULYOwmAYexUsXBMtCA;

			public int MCDKyUJlmhQXfeayeJmoXfaHcWfiA;

			public int nyDAXJEHgHLCMlTZKpdDYCOIRSQr;

			public bool sKPmsOwrsqQUGaDeDiygzRJgUHm(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0, cAWkESLMSLWUAeMnmeERbVTEdMyn P_1)
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
				case cAWkESLMSLWUAeMnmeERbVTEdMyn.Exact:
					return auRhMsSNSGdZKHBllYUoMazgzoCbA == P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl;
				case cAWkESLMSLWUAeMnmeERbVTEdMyn.Approximate:
					return iFObMCUaUQUnWzybrqxSRAVRTBWI == P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class QbizQZPJIxfLbpdFElttJpdtTmBO : IDisposable, IEnumerable<aAnBMLEiUSFWWYowWvJkUZUPtUgN>, IEnumerator<aAnBMLEiUSFWWYowWvJkUZUPtUgN>, IEnumerable, IEnumerator
		{
			private int GaDEmGeAzDwcrUimnTDVbqDAEmMs;

			private aAnBMLEiUSFWWYowWvJkUZUPtUgN QZXFulaBJncjPFMoGHDkxBzfgAJM;

			private int nKWKxUHpZxraWHSPSgSgtAFyHyvHA;

			public VcNxTWIAMgulAmpBIELyqcVVNpNV AtldvTEkDsEewBZFaEtbawltdqhzb;

			private elhFAIfVKvQFWaQKTojBNMnedwlEA wdbQxUuPsPgPKZuWmNEeMjEvEqweA;

			public elhFAIfVKvQFWaQKTojBNMnedwlEA KhdNMFEMmEAnBXbdNduCAUxxihfib;

			private cAWkESLMSLWUAeMnmeERbVTEdMyn XLaGCVhWSRFSHLsBcqOHnsPKrQmbA;

			public cAWkESLMSLWUAeMnmeERbVTEdMyn dPhbrgyjusQglwefgNYQseZkRnSN;

			private int NOddPDAtCADIsFnzlqGZAJmYYyoN;

			private int yJsBQJRPgsSANFiCNsLHwmcurxe;

			aAnBMLEiUSFWWYowWvJkUZUPtUgN IEnumerator<aAnBMLEiUSFWWYowWvJkUZUPtUgN>.Current
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
			public QbizQZPJIxfLbpdFElttJpdtTmBO(int P_0)
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
				VcNxTWIAMgulAmpBIELyqcVVNpNV atldvTEkDsEewBZFaEtbawltdqhzb = AtldvTEkDsEewBZFaEtbawltdqhzb;
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
			IEnumerator<aAnBMLEiUSFWWYowWvJkUZUPtUgN> IEnumerable<aAnBMLEiUSFWWYowWvJkUZUPtUgN>.GetEnumerator()
			{
				QbizQZPJIxfLbpdFElttJpdtTmBO qbizQZPJIxfLbpdFElttJpdtTmBO;
				if (GaDEmGeAzDwcrUimnTDVbqDAEmMs == -2 && nKWKxUHpZxraWHSPSgSgtAFyHyvHA == Thread.CurrentThread.ManagedThreadId)
				{
					GaDEmGeAzDwcrUimnTDVbqDAEmMs = 0;
					qbizQZPJIxfLbpdFElttJpdtTmBO = this;
				}
				else
				{
					qbizQZPJIxfLbpdFElttJpdtTmBO = new QbizQZPJIxfLbpdFElttJpdtTmBO(0);
					qbizQZPJIxfLbpdFElttJpdtTmBO.AtldvTEkDsEewBZFaEtbawltdqhzb = AtldvTEkDsEewBZFaEtbawltdqhzb;
				}
				qbizQZPJIxfLbpdFElttJpdtTmBO.wdbQxUuPsPgPKZuWmNEeMjEvEqweA = KhdNMFEMmEAnBXbdNduCAUxxihfib;
				qbizQZPJIxfLbpdFElttJpdtTmBO.XLaGCVhWSRFSHLsBcqOHnsPKrQmbA = dPhbrgyjusQglwefgNYQseZkRnSN;
				return qbizQZPJIxfLbpdFElttJpdtTmBO;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<aAnBMLEiUSFWWYowWvJkUZUPtUgN>)this).GetEnumerator();
			}
		}

		private List<aAnBMLEiUSFWWYowWvJkUZUPtUgN> ZDXhulnhGZktqkrQbgcQqMUrEhoFA;

		public VcNxTWIAMgulAmpBIELyqcVVNpNV()
		{
			ZDXhulnhGZktqkrQbgcQqMUrEhoFA = new List<aAnBMLEiUSFWWYowWvJkUZUPtUgN>();
		}

		public void HgZeolIOSfnlKNNDACCahiudRKNec(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].sKPmsOwrsqQUGaDeDiygzRJgUHm(P_0, cAWkESLMSLWUAeMnmeERbVTEdMyn.Exact))
				{
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].yezDqSCRWxhlxMjsXiQKzSGNMhog = P_0.rewiredId;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].auRhMsSNSGdZKHBllYUoMazgzoCbA = P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].iFObMCUaUQUnWzybrqxSRAVRTBWI = P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].wsDsfjzHKLzCJcIILWEhQVQklLQu = P_0.inputManagerId;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].HhqbiwBXcDTULYOwmAYexUsXBMtCA = P_0.HhqbiwBXcDTULYOwmAYexUsXBMtCA;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].MCDKyUJlmhQXfeayeJmoXfaHcWfiA = P_0.MCDKyUJlmhQXfeayeJmoXfaHcWfiA;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].nyDAXJEHgHLCMlTZKpdDYCOIRSQr = P_0.nyDAXJEHgHLCMlTZKpdDYCOIRSQr;
					rCRVlSgjPAfuPiLiTvQLcokniobBb(P_0.rewiredId, P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl, i);
					return;
				}
			}
			ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Add(new aAnBMLEiUSFWWYowWvJkUZUPtUgN
			{
				yezDqSCRWxhlxMjsXiQKzSGNMhog = P_0.rewiredId,
				auRhMsSNSGdZKHBllYUoMazgzoCbA = P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl,
				iFObMCUaUQUnWzybrqxSRAVRTBWI = P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI,
				wsDsfjzHKLzCJcIILWEhQVQklLQu = P_0.inputManagerId,
				HhqbiwBXcDTULYOwmAYexUsXBMtCA = P_0.HhqbiwBXcDTULYOwmAYexUsXBMtCA,
				MCDKyUJlmhQXfeayeJmoXfaHcWfiA = P_0.MCDKyUJlmhQXfeayeJmoXfaHcWfiA,
				nyDAXJEHgHLCMlTZKpdDYCOIRSQr = P_0.nyDAXJEHgHLCMlTZKpdDYCOIRSQr
			});
			rCRVlSgjPAfuPiLiTvQLcokniobBb(P_0.rewiredId, P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl, ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count - 1);
		}

		public bool ecSZEwttGfkQfToParxnBfHCGISs(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0, cAWkESLMSLWUAeMnmeERbVTEdMyn P_1)
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

		public IEnumerable<aAnBMLEiUSFWWYowWvJkUZUPtUgN> OoDdjwkheCaHvrmPJPlqsPWCeYVtA(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0, cAWkESLMSLWUAeMnmeERbVTEdMyn P_1)
		{
			return new QbizQZPJIxfLbpdFElttJpdtTmBO(-2)
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
	}

	internal const bool WGlNBIhJcIGDWjLeSNucZQTmthIZ = true;

	private IInputSource foDLtBVrOMOFjBdRYkqwdKevGmTw;

	private List<elhFAIfVKvQFWaQKTojBNMnedwlEA> uhsZTQOPiTWQesgStEowZrhIaYfdA;

	private int DUhRAPCUFyXuQrAMVOAIBoZHcooH;

	private VcNxTWIAMgulAmpBIELyqcVVNpNV dFjjWhTvzPgWCbHejcNwKYxKBSaM;

	private bool fKdECYTEMkHBabIJrseQcfdKSMfsA;

	private Action<int, ControllerDataUpdater> qTPyWiiAzgfhSZUfTOhfkrKlxaVL;

	private PlatformInputManager cenkEFLNjUadqCYJhKRRkUtIKUYNA;

	private readonly bool FmjIfSbbZQGmwOGQxbLsdNcTtdJv;

	private readonly bool xNlCJqFHDDPBFbzaNwmArLLBCiYx;

	private readonly bool MqObAwOsakkeKyBGuZsgrIetfdvr;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> NBBGEOVRvneYDcFdnaoIhuFHZZKyB;

	private readonly Func<int> OlamnlbqCRkOUMBSkakeUghSoraE;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => DUhRAPCUFyXuQrAMVOAIBoZHcooH;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => cenkEFLNjUadqCYJhKRRkUtIKUYNA;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => foDLtBVrOMOFjBdRYkqwdKevGmTw;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.SDL2;

	public zWPkUtSGvOgInpdmaKYzxHsbJAyr(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
	{
		try
		{
			NBBGEOVRvneYDcFdnaoIhuFHZZKyB = P_1;
			OlamnlbqCRkOUMBSkakeUghSoraE = P_2;
			FmjIfSbbZQGmwOGQxbLsdNcTtdJv = P_3;
			xNlCJqFHDDPBFbzaNwmArLLBCiYx = P_4;
			MqObAwOsakkeKyBGuZsgrIetfdvr = P_5;
			cenkEFLNjUadqCYJhKRRkUtIKUYNA = this;
			foDLtBVrOMOFjBdRYkqwdKevGmTw = new SDL2InputSource(P_0.updateLoop, P_3, P_3, P_4, P_5);
			qTPyWiiAzgfhSZUfTOhfkrKlxaVL = UpdateControllerData;
			foDLtBVrOMOFjBdRYkqwdKevGmTw.DeviceChangedEvent += fWOvjsdUWzlIfgNewWPaBUhsoFwp;
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
		if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
		{
			dFjjWhTvzPgWCbHejcNwKYxKBSaM = new VcNxTWIAMgulAmpBIELyqcVVNpNV();
			wVvzxdrDDEaQGilyJYsnhosKfeoBb();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (foDLtBVrOMOFjBdRYkqwdKevGmTw != null)
		{
			foDLtBVrOMOFjBdRYkqwdKevGmTw.Update();
		}
		if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
		{
			if (fKdECYTEMkHBabIJrseQcfdKSMfsA)
			{
				oLMAfMOqqnxFSVFKsojLREXbEDdfA();
			}
			if (foDLtBVrOMOFjBdRYkqwdKevGmTw != null)
			{
				for (int i = 0; i < DUhRAPCUFyXuQrAMVOAIBoZHcooH; i++)
				{
					uhsZTQOPiTWQesgStEowZrhIaYfdA[i]?.dUxVIgaadrfqJWSzRpXGORZlkMqp.Update(updateLoop);
				}
				foDLtBVrOMOFjBdRYkqwdKevGmTw.UpdateDevices(updateLoop);
			}
			HuQMjaeKUlhtoxviEIRhkVYsSmvt();
			if (foDLtBVrOMOFjBdRYkqwdKevGmTw != null)
			{
				foDLtBVrOMOFjBdRYkqwdKevGmTw.UpdateFinished();
				for (int j = 0; j < DUhRAPCUFyXuQrAMVOAIBoZHcooH; j++)
				{
					uhsZTQOPiTWQesgStEowZrhIaYfdA[j]?.dUxVIgaadrfqJWSzRpXGORZlkMqp.UpdateFinished();
				}
			}
		}
		_ = xNlCJqFHDDPBFbzaNwmArLLBCiYx;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (uhsZTQOPiTWQesgStEowZrhIaYfdA != null)
		{
			int count = uhsZTQOPiTWQesgStEowZrhIaYfdA.Count;
			for (int i = 0; i < count; i++)
			{
				if (uhsZTQOPiTWQesgStEowZrhIaYfdA[i] != null)
				{
					uhsZTQOPiTWQesgStEowZrhIaYfdA[i].dUxVIgaadrfqJWSzRpXGORZlkMqp?.zobeSpTCoofGnipPFjpZGNzdwEoE();
				}
			}
		}
		if (foDLtBVrOMOFjBdRYkqwdKevGmTw != null)
		{
			foDLtBVrOMOFjBdRYkqwdKevGmTw.Dispose();
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
		if (!FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
		{
			return;
		}
		for (int i = 0; i < DUhRAPCUFyXuQrAMVOAIBoZHcooH; i++)
		{
			if (uhsZTQOPiTWQesgStEowZrhIaYfdA[i].inputManagerId == inputManagerId)
			{
				uhsZTQOPiTWQesgStEowZrhIaYfdA[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
		{
			fKdECYTEMkHBabIJrseQcfdKSMfsA = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
		{
			fKdECYTEMkHBabIJrseQcfdKSMfsA = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = FmjIfSbbZQGmwOGQxbLsdNcTtdJv;
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

	private void wVvzxdrDDEaQGilyJYsnhosKfeoBb()
	{
		wVvzxdrDDEaQGilyJYsnhosKfeoBb(dYbvqqqQyxutNZhTNNywxlOJSeMV());
	}

	private void wVvzxdrDDEaQGilyJYsnhosKfeoBb(IList<HaOkodQgKHTDiFuGZKtkAaEJxnaG> P_0)
	{
		int num = 0;
		List<elhFAIfVKvQFWaQKTojBNMnedwlEA> list = uhsZTQOPiTWQesgStEowZrhIaYfdA;
		int dUhRAPCUFyXuQrAMVOAIBoZHcooH = DUhRAPCUFyXuQrAMVOAIBoZHcooH;
		uhsZTQOPiTWQesgStEowZrhIaYfdA = new List<elhFAIfVKvQFWaQKTojBNMnedwlEA>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				HaOkodQgKHTDiFuGZKtkAaEJxnaG haOkodQgKHTDiFuGZKtkAaEJxnaG = P_0[i];
				elhFAIfVKvQFWaQKTojBNMnedwlEA elhFAIfVKvQFWaQKTojBNMnedwlEA2 = new elhFAIfVKvQFWaQKTojBNMnedwlEA(NBBGEOVRvneYDcFdnaoIhuFHZZKyB);
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.dUxVIgaadrfqJWSzRpXGORZlkMqp = haOkodQgKHTDiFuGZKtkAaEJxnaG;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.QrLkiuceluZEPMOcjJiYcdnvZQtl = haOkodQgKHTDiFuGZKtkAaEJxnaG.SCGcrIIDMjURHdkJjDIzHoMbvWQHA;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.lBggkBnQrnGmLonsLyCRpnRHYBpi = haOkodQgKHTDiFuGZKtkAaEJxnaG.oWpCUWdTGUxPJhGLprVHSmZsZZYBA;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.snGLuuyMCPOtXxLfVtXHzWVouQKy = haOkodQgKHTDiFuGZKtkAaEJxnaG.bJlExhcGSCNZLtkOAOXaAJlyUSBEA;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.tNjxagUrcnyzWbSOsVMIFxUTEAOE = haOkodQgKHTDiFuGZKtkAaEJxnaG.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.ZEcFSCcanLCalchLYPeeGgIDBkJOc = haOkodQgKHTDiFuGZKtkAaEJxnaG.nKaqOeNeXtRFQyIiPrSeMOBlIXKe;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.lbWMRbOepNXIBicDWdlXEMxnAbpmA = haOkodQgKHTDiFuGZKtkAaEJxnaG.rQMHGWBVRINpDkLJvWbkZIiKbMlE;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.mgfmGZeLtXcIMfABdmrEeVZBiEBOB = haOkodQgKHTDiFuGZKtkAaEJxnaG.KpLgfiTwKVmJnHrLykvAtjznonIo;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.SdthoJItTfcAKBEUPFiNJgcraHGZA = haOkodQgKHTDiFuGZKtkAaEJxnaG.BEwuJlSgrzvnNiHAkXqrckJVpxbD;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.HhqbiwBXcDTULYOwmAYexUsXBMtCA = haOkodQgKHTDiFuGZKtkAaEJxnaG.OnAwGKsEQkUZSJUZVquvqkbDyaWo;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.MCDKyUJlmhQXfeayeJmoXfaHcWfiA = haOkodQgKHTDiFuGZKtkAaEJxnaG.JVqCHAvnctFGSlUdMoFcLkcNXrDA;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.nyDAXJEHgHLCMlTZKpdDYCOIRSQr = haOkodQgKHTDiFuGZKtkAaEJxnaG.nHDbLoGMognNLMuWpWyCEHRJaNibA;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.jrbdcQFpFxHLlTlwtpmmDUBJcizi = haOkodQgKHTDiFuGZKtkAaEJxnaG.MpuQBNhsGfnlifDQFONVPCMzxEIi;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.SFHEoLFtkmPWaGuXCKXjAhXIeZUVA = haOkodQgKHTDiFuGZKtkAaEJxnaG.GyVGdsIndLTpvrLADCCAkUuuHcpPA;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.JRVaqxBKatYgbGYyeEJbKTzddNthb = haOkodQgKHTDiFuGZKtkAaEJxnaG.mQGqvjNlLCuPxjMYjDijVbHRpnmk;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.extension = haOkodQgKHTDiFuGZKtkAaEJxnaG.ORFGGDZXMYwdSxkLZdpeDghCakvhb;
				haOkodQgKHTDiFuGZKtkAaEJxnaG.qqTnUdwDLRDdijbuOGAyBhNivyaqA();
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.OKLfbagyaudIxlHWyOTBXIXfgzkUA();
				uhsZTQOPiTWQesgStEowZrhIaYfdA.Add(elhFAIfVKvQFWaQKTojBNMnedwlEA2);
				num++;
			}
		}
		DUhRAPCUFyXuQrAMVOAIBoZHcooH = num;
		yCerSzlhCsNqVTmGzxfvEztWrZKJ(dUhRAPCUFyXuQrAMVOAIBoZHcooH, num, list, uhsZTQOPiTWQesgStEowZrhIaYfdA);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(uhsZTQOPiTWQesgStEowZrhIaYfdA[j]));
			}
		}
		lZhwEqQAMUuThvcqBsjRFkkUsOxO(list, uhsZTQOPiTWQesgStEowZrhIaYfdA, false);
		lZhwEqQAMUuThvcqBsjRFkkUsOxO(uhsZTQOPiTWQesgStEowZrhIaYfdA, list, true);
	}

	private void HuQMjaeKUlhtoxviEIRhkVYsSmvt()
	{
		for (int i = 0; i < DUhRAPCUFyXuQrAMVOAIBoZHcooH; i++)
		{
			uhsZTQOPiTWQesgStEowZrhIaYfdA[i]?.Update();
		}
	}

	private bool qNRFgbeBPuuxzAiRNMsKAqIJVAFxA(vcOJddXuBPMFeykHjUusxGIgBCDEA P_0)
	{
		try
		{
			return P_0.TvxYbbeLRgfpxOLIlIeWEDFewZTKA();
		}
		catch
		{
			return false;
		}
	}

	private IList<HaOkodQgKHTDiFuGZKtkAaEJxnaG> dYbvqqqQyxutNZhTNNywxlOJSeMV()
	{
		return foDLtBVrOMOFjBdRYkqwdKevGmTw.GetJoysticks<HaOkodQgKHTDiFuGZKtkAaEJxnaG>();
	}

	private void yCerSzlhCsNqVTmGzxfvEztWrZKJ(int P_0, int P_1, List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_2, List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(elhFAIfVKvQFWaQKTojBNMnedwlEA.iPBJsEMpHEalRFrTLHdxePyElzOJA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			wuaCIwaEhsQfxmqZgODZijGGOoeHb(P_1, P_3, P_0, P_2, VcNxTWIAMgulAmpBIELyqcVVNpNV.cAWkESLMSLWUAeMnmeERbVTEdMyn.Exact);
			wuaCIwaEhsQfxmqZgODZijGGOoeHb(P_1, P_3, P_0, P_2, VcNxTWIAMgulAmpBIELyqcVVNpNV.cAWkESLMSLWUAeMnmeERbVTEdMyn.Approximate);
		}
		smcCiZysONMbkSQvFgYTXeMDHzls(P_1, P_3, VcNxTWIAMgulAmpBIELyqcVVNpNV.cAWkESLMSLWUAeMnmeERbVTEdMyn.Exact);
		smcCiZysONMbkSQvFgYTXeMDHzls(P_1, P_3, VcNxTWIAMgulAmpBIELyqcVVNpNV.cAWkESLMSLWUAeMnmeERbVTEdMyn.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			elhFAIfVKvQFWaQKTojBNMnedwlEA elhFAIfVKvQFWaQKTojBNMnedwlEA2 = P_3[i];
			if (elhFAIfVKvQFWaQKTojBNMnedwlEA2 != null && elhFAIfVKvQFWaQKTojBNMnedwlEA2.inputManagerId < 0)
			{
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.inputManagerId = LPWxxllcQTgkueLabuveIFxjmWShA(P_3);
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.rewiredId = OlamnlbqCRkOUMBSkakeUghSoraE();
				dFjjWhTvzPgWCbHejcNwKYxKBSaM.HgZeolIOSfnlKNNDACCahiudRKNec(elhFAIfVKvQFWaQKTojBNMnedwlEA2);
			}
		}
		P_3.Sort(elhFAIfVKvQFWaQKTojBNMnedwlEA.ejhPQanSJmRJtgOzIiIJfBzXGfjcA);
	}

	private void NcHJyIKkRfIZStZZRCRMlYNzGMob(List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_0, int P_1, int P_2)
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

	private bool FbgGsqaEobfojdDLkZawNsMubCOvA(List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_0, int P_1)
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

	private int LPWxxllcQTgkueLabuveIFxjmWShA(List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_0)
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

	private bool DfAHMpnyMaKopMatiqeimNyLHtBb(List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_0, int P_1)
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

	private void wuaCIwaEhsQfxmqZgODZijGGOoeHb(int P_0, List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_1, int P_2, List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_3, VcNxTWIAMgulAmpBIELyqcVVNpNV.cAWkESLMSLWUAeMnmeERbVTEdMyn P_4)
	{
		int num = ((P_4 != VcNxTWIAMgulAmpBIELyqcVVNpNV.cAWkESLMSLWUAeMnmeERbVTEdMyn.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			elhFAIfVKvQFWaQKTojBNMnedwlEA elhFAIfVKvQFWaQKTojBNMnedwlEA2 = P_1[i];
			if (elhFAIfVKvQFWaQKTojBNMnedwlEA2 == null || elhFAIfVKvQFWaQKTojBNMnedwlEA2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				elhFAIfVKvQFWaQKTojBNMnedwlEA elhFAIfVKvQFWaQKTojBNMnedwlEA3 = P_3[j];
				if (elhFAIfVKvQFWaQKTojBNMnedwlEA3 != null && !DfAHMpnyMaKopMatiqeimNyLHtBb(P_1, elhFAIfVKvQFWaQKTojBNMnedwlEA3.rewiredId) && elhFAIfVKvQFWaQKTojBNMnedwlEA2.sKPmsOwrsqQUGaDeDiygzRJgUHm(elhFAIfVKvQFWaQKTojBNMnedwlEA3) >= num)
				{
					elhFAIfVKvQFWaQKTojBNMnedwlEA2.OLfmjaYQlzgJtGmEIVCoLPHHLIfZ(elhFAIfVKvQFWaQKTojBNMnedwlEA3);
					dFjjWhTvzPgWCbHejcNwKYxKBSaM.HgZeolIOSfnlKNNDACCahiudRKNec(elhFAIfVKvQFWaQKTojBNMnedwlEA2);
				}
			}
		}
	}

	private void smcCiZysONMbkSQvFgYTXeMDHzls(int P_0, List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_1, VcNxTWIAMgulAmpBIELyqcVVNpNV.cAWkESLMSLWUAeMnmeERbVTEdMyn P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			elhFAIfVKvQFWaQKTojBNMnedwlEA elhFAIfVKvQFWaQKTojBNMnedwlEA2 = P_1[i];
			if (elhFAIfVKvQFWaQKTojBNMnedwlEA2 == null || elhFAIfVKvQFWaQKTojBNMnedwlEA2.inputManagerId >= 0)
			{
				continue;
			}
			VcNxTWIAMgulAmpBIELyqcVVNpNV.aAnBMLEiUSFWWYowWvJkUZUPtUgN aAnBMLEiUSFWWYowWvJkUZUPtUgN = null;
			foreach (VcNxTWIAMgulAmpBIELyqcVVNpNV.aAnBMLEiUSFWWYowWvJkUZUPtUgN item in dFjjWhTvzPgWCbHejcNwKYxKBSaM.OoDdjwkheCaHvrmPJPlqsPWCeYVtA(elhFAIfVKvQFWaQKTojBNMnedwlEA2, P_2))
			{
				if (!DfAHMpnyMaKopMatiqeimNyLHtBb(P_1, item.yezDqSCRWxhlxMjsXiQKzSGNMhog) && item.wsDsfjzHKLzCJcIILWEhQVQklLQu >= 0)
				{
					aAnBMLEiUSFWWYowWvJkUZUPtUgN = item;
					break;
				}
			}
			if (aAnBMLEiUSFWWYowWvJkUZUPtUgN != null)
			{
				int num = aAnBMLEiUSFWWYowWvJkUZUPtUgN.wsDsfjzHKLzCJcIILWEhQVQklLQu;
				if (!FbgGsqaEobfojdDLkZawNsMubCOvA(P_1, num))
				{
					num = (aAnBMLEiUSFWWYowWvJkUZUPtUgN.wsDsfjzHKLzCJcIILWEhQVQklLQu = LPWxxllcQTgkueLabuveIFxjmWShA(P_1));
				}
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.inputManagerId = num;
				elhFAIfVKvQFWaQKTojBNMnedwlEA2.rewiredId = aAnBMLEiUSFWWYowWvJkUZUPtUgN.yezDqSCRWxhlxMjsXiQKzSGNMhog;
				dFjjWhTvzPgWCbHejcNwKYxKBSaM.HgZeolIOSfnlKNNDACCahiudRKNec(elhFAIfVKvQFWaQKTojBNMnedwlEA2);
			}
		}
	}

	private void oLMAfMOqqnxFSVFKsojLREXbEDdfA()
	{
		IList<HaOkodQgKHTDiFuGZKtkAaEJxnaG> list = dYbvqqqQyxutNZhTNNywxlOJSeMV();
		wVvzxdrDDEaQGilyJYsnhosKfeoBb(list);
		fKdECYTEMkHBabIJrseQcfdKSMfsA = false;
	}

	private bool ZQeObJRNMFLkBQHlsgdMEEcsbbjcb(IList<HaOkodQgKHTDiFuGZKtkAaEJxnaG> P_0)
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
			if (uhsZTQOPiTWQesgStEowZrhIaYfdA[j] != null && !xqJQtvnljRCODgaLQIhgcKPevtxLb(P_0, uhsZTQOPiTWQesgStEowZrhIaYfdA[j].QrLkiuceluZEPMOcjJiYcdnvZQtl))
			{
				return true;
			}
		}
		return false;
	}

	private bool KbBeKArMJduJpEIezPVKEIfBUzIm(Guid P_0)
	{
		int count = uhsZTQOPiTWQesgStEowZrhIaYfdA.Count;
		for (int i = 0; i < count; i++)
		{
			if (uhsZTQOPiTWQesgStEowZrhIaYfdA[i] != null && uhsZTQOPiTWQesgStEowZrhIaYfdA[i].QrLkiuceluZEPMOcjJiYcdnvZQtl == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool xqJQtvnljRCODgaLQIhgcKPevtxLb(IList<HaOkodQgKHTDiFuGZKtkAaEJxnaG> P_0, Guid P_1)
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

	private void lZhwEqQAMUuThvcqBsjRFkkUsOxO(List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_0, List<elhFAIfVKvQFWaQKTojBNMnedwlEA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			elhFAIfVKvQFWaQKTojBNMnedwlEA elhFAIfVKvQFWaQKTojBNMnedwlEA2 = P_0[i];
			if (elhFAIfVKvQFWaQKTojBNMnedwlEA2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					elhFAIfVKvQFWaQKTojBNMnedwlEA elhFAIfVKvQFWaQKTojBNMnedwlEA3 = P_1[j];
					if (elhFAIfVKvQFWaQKTojBNMnedwlEA3 != null && elhFAIfVKvQFWaQKTojBNMnedwlEA2.QrLkiuceluZEPMOcjJiYcdnvZQtl == elhFAIfVKvQFWaQKTojBNMnedwlEA3.QrLkiuceluZEPMOcjJiYcdnvZQtl)
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

	private void VTTdBYSqcQzDyOFRkPCEjraxYldu(elhFAIfVKvQFWaQKTojBNMnedwlEA P_0, bool P_1)
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

	private void fWOvjsdUWzlIfgNewWPaBUhsoFwp()
	{
		if (FmjIfSbbZQGmwOGQxbLsdNcTtdJv)
		{
			fKdECYTEMkHBabIJrseQcfdKSMfsA = true;
		}
		SystemDeviceConnected();
	}
}
