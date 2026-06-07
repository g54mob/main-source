using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired;
using Rewired.Data;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;

internal class cUYFPgdmXySFZwutVlfquFdQOLaDb : PlatformInputManager
{
	private class AatiiCapDyGVJdTLYbTOWQftSuLMA : IDisposable, IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int tMlFMbbnSDaAYEdgwltrYDupMlKyA;

		private int ouIAxHJkHCqySFVaXBWVUCAlcjwjA;

		public Guid dfkNjaPwXkaeRLYwmoTrUJWHbEfc;

		public string dOwZfeJoWhhATUmPdsXZbdgVvtHW;

		public NPcbXYOMZTPjQpCotxkrcLlyrqWf dUxVIgaadrfqJWSzRpXGORZlkMqp;

		public string QPMKBEqKVaycLpEwnGlOkcMWLImdb;

		public string kdNvziqmWoxIlwtlUVdLVjQQNpFi;

		public Guid QrLkiuceluZEPMOcjJiYcdnvZQtl;

		public PidVid tNjxagUrcnyzWbSOsVMIFxUTEAOE;

		public Guid iFObMCUaUQUnWzybrqxSRAVRTBWI;

		public int SdthoJItTfcAKBEUPFiNJgcraHGZA;

		public int UDFcKRicGfzUGfNrRKCnISkDnKMVb;

		public int FkOzkpBIpGDDNocsckZjSKLgiIVv;

		public int HhqbiwBXcDTULYOwmAYexUsXBMtCA;

		public int MCDKyUJlmhQXfeayeJmoXfaHcWfiA;

		public int nyDAXJEHgHLCMlTZKpdDYCOIRSQr;

		public bool SFHEoLFtkmPWaGuXCKXjAhXIeZUVA;

		public int JRVaqxBKatYgbGYyeEJbKTzddNthb;

		private float[] dydcbiMQDPlMCvQZIVaFxWCilYKQ;

		private float[] JkLuaNrBfUjBFJFAynrFZsuAKJMTA;

		private bool[] IpOZqbqmHTCfHMnUXjufSdcsSLwi;

		private HardwareJoystickMap_InputManager hJeYXuujpZcIHhUzFngZZNyaunJy;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> NBBGEOVRvneYDcFdnaoIhuFHZZKyB;

		private bool YCkiTXGFGImEpYaQgYLZkdDBKpFdb;

		private bool zGsfYreSUFOtjBTyHnkmVUNXLXYnA;

		[CompilerGenerated]
		private Controller.Extension wkKLTZPqxJeoYeWOgYoOpAFbTpVS;

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
				if (!(dOwZfeJoWhhATUmPdsXZbdgVvtHW != "Unknown Controller"))
				{
					return kdNvziqmWoxIlwtlUVdLVjQQNpFi;
				}
				return dOwZfeJoWhhATUmPdsXZbdgVvtHW;
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
		public Guid instanceGuid => QrLkiuceluZEPMOcjJiYcdnvZQtl;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid
		{
			get
			{
				if (dUxVIgaadrfqJWSzRpXGORZlkMqp == null)
				{
					return Guid.Empty;
				}
				return dUxVIgaadrfqJWSzRpXGORZlkMqp.TpxToWJlqZRPrmoFrEejVulXkAtd;
			}
		}

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
			if (SFHEoLFtkmPWaGuXCKXjAhXIeZUVA)
			{
				dUxVIgaadrfqJWSzRpXGORZlkMqp.SetVibration(motorIndex, amount, stopOtherMotors: false);
			}
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
			if (SFHEoLFtkmPWaGuXCKXjAhXIeZUVA)
			{
				dUxVIgaadrfqJWSzRpXGORZlkMqp.StopVibration();
			}
		}

		public AatiiCapDyGVJdTLYbTOWQftSuLMA(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			NBBGEOVRvneYDcFdnaoIhuFHZZKyB = P_0;
			ouIAxHJkHCqySFVaXBWVUCAlcjwjA = -1;
			tMlFMbbnSDaAYEdgwltrYDupMlKyA = -1;
		}

		public void OKLfbagyaudIxlHWyOTBXIXfgzkUA()
		{
			iFObMCUaUQUnWzybrqxSRAVRTBWI = MiscTools.CreateGuidHashSHA1(kdNvziqmWoxIlwtlUVdLVjQQNpFi + tNjxagUrcnyzWbSOsVMIFxUTEAOE.ToProductGuid().ToString());
			UDFcKRicGfzUGfNrRKCnISkDnKMVb = HhqbiwBXcDTULYOwmAYexUsXBMtCA;
			FkOzkpBIpGDDNocsckZjSKLgiIVv = MCDKyUJlmhQXfeayeJmoXfaHcWfiA + nyDAXJEHgHLCMlTZKpdDYCOIRSQr * 8;
			bfkxPXlKJejmTALFktyasdIIxRKhA();
			dfkNjaPwXkaeRLYwmoTrUJWHbEfc = hJeYXuujpZcIHhUzFngZZNyaunJy.hardwareMapIdentifier.guid;
			dOwZfeJoWhhATUmPdsXZbdgVvtHW = hJeYXuujpZcIHhUzFngZZNyaunJy.controllerName;
			YCkiTXGFGImEpYaQgYLZkdDBKpFdb = ((dfkNjaPwXkaeRLYwmoTrUJWHbEfc == Guid.Empty) ? true : false);
			dydcbiMQDPlMCvQZIVaFxWCilYKQ = new float[UDFcKRicGfzUGfNrRKCnISkDnKMVb];
			JkLuaNrBfUjBFJFAynrFZsuAKJMTA = new float[FkOzkpBIpGDDNocsckZjSKLgiIVv];
			IpOZqbqmHTCfHMnUXjufSdcsSLwi = new bool[FkOzkpBIpGDDNocsckZjSKLgiIVv];
			if (FkOzkpBIpGDDNocsckZjSKLgiIVv > 0)
			{
				HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Buttons_orig;
				if (buttons_orig != null)
				{
					for (int i = 0; i < buttons_orig.Length; i++)
					{
						IpOZqbqmHTCfHMnUXjufSdcsSLwi[i] = buttons_orig[i].buttonInfo.isPressureSensitive;
					}
				}
			}
			Update();
		}

		public void OLfmjaYQlzgJtGmEIVCoLPHHLIfZ(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0)
		{
			if (P_0 != null)
			{
				ouIAxHJkHCqySFVaXBWVUCAlcjwjA = P_0.ouIAxHJkHCqySFVaXBWVUCAlcjwjA;
				tMlFMbbnSDaAYEdgwltrYDupMlKyA = P_0.tMlFMbbnSDaAYEdgwltrYDupMlKyA;
				for (int i = 0; i < MathTools.Min(JkLuaNrBfUjBFJFAynrFZsuAKJMTA.Length, P_0.JkLuaNrBfUjBFJFAynrFZsuAKJMTA.Length); i++)
				{
					JkLuaNrBfUjBFJFAynrFZsuAKJMTA[i] = P_0.JkLuaNrBfUjBFJFAynrFZsuAKJMTA[i];
				}
				for (int j = 0; j < MathTools.Min(IpOZqbqmHTCfHMnUXjufSdcsSLwi.Length, P_0.IpOZqbqmHTCfHMnUXjufSdcsSLwi.Length); j++)
				{
					IpOZqbqmHTCfHMnUXjufSdcsSLwi[j] = P_0.IpOZqbqmHTCfHMnUXjufSdcsSLwi[j];
				}
				for (int k = 0; k < MathTools.Min(dydcbiMQDPlMCvQZIVaFxWCilYKQ.Length, P_0.dydcbiMQDPlMCvQZIVaFxWCilYKQ.Length); k++)
				{
					dydcbiMQDPlMCvQZIVaFxWCilYKQ[k] = P_0.dydcbiMQDPlMCvQZIVaFxWCilYKQ[k];
				}
				zGsfYreSUFOtjBTyHnkmVUNXLXYnA = P_0.zGsfYreSUFOtjBTyHnkmVUNXLXYnA;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			yznGbdDyUyOPfduhykPAGCjaQExNc();
			RdPFzuLpsssVUfJbWIHhRQPBGScT();
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
				if (IpOZqbqmHTCfHMnUXjufSdcsSLwi[j])
				{
					dataUpdater.buttonPressureValues[j] = JkLuaNrBfUjBFJFAynrFZsuAKJMTA[j];
				}
				else
				{
					dataUpdater.buttonValues[j] = ((JkLuaNrBfUjBFJFAynrFZsuAKJMTA[j] > 0f) ? true : false);
				}
			}
			if (zGsfYreSUFOtjBTyHnkmVUNXLXYnA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int sKPmsOwrsqQUGaDeDiygzRJgUHm(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0)
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
			if (UDFcKRicGfzUGfNrRKCnISkDnKMVb <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_WindowsWGI_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Axes_orig;
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
			HardwareJoystickMap.Platform_WindowsWGI_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_WindowsWGI_Base)hJeYXuujpZcIHhUzFngZZNyaunJy.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					fMcAkgWDJulDGPRxZIXwdBJxCLsGA(buttons_orig[i], i);
				}
			}
		}

		private void fnaaXRUCVpwvwWRollOpWEKUdiW(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0, int P_1)
		{
			if (P_1 >= UDFcKRicGfzUGfNrRKCnISkDnKMVb)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			dydcbiMQDPlMCvQZIVaFxWCilYKQ[P_1] = mkqEwjEWKTccoblNpohIPzhMuvaL(P_0);
			if (!zGsfYreSUFOtjBTyHnkmVUNXLXYnA && dydcbiMQDPlMCvQZIVaFxWCilYKQ[P_1] != 0f)
			{
				zGsfYreSUFOtjBTyHnkmVUNXLXYnA = true;
			}
		}

		private void fMcAkgWDJulDGPRxZIXwdBJxCLsGA(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0, int P_1)
		{
			if (P_1 >= FkOzkpBIpGDDNocsckZjSKLgiIVv)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			JkLuaNrBfUjBFJFAynrFZsuAKJMTA[P_1] = MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0);
			if (!zGsfYreSUFOtjBTyHnkmVUNXLXYnA && JkLuaNrBfUjBFJFAynrFZsuAKJMTA[P_1] != 0f)
			{
				zGsfYreSUFOtjBTyHnkmVUNXLXYnA = true;
			}
		}

		private float mkqEwjEWKTccoblNpohIPzhMuvaL(HardwareJoystickMap.Platform_WindowsWGI_Base.Axis P_0)
		{
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				return mkqEwjEWKTccoblNpohIPzhMuvaL(sourceAxis);
			}
			if (P_0.sourceType == 0)
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
			if (P_0.sourceType == 2)
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

		private float mkqEwjEWKTccoblNpohIPzhMuvaL(int P_0)
		{
			if (P_0 < 0 || P_0 >= dUxVIgaadrfqJWSzRpXGORZlkMqp.OnAwGKsEQkUZSJUZVquvqkbDyaWo)
			{
				return 0f;
			}
			return dUxVIgaadrfqJWSzRpXGORZlkMqp.mkqEwjEWKTccoblNpohIPzhMuvaL(P_0);
		}

		private float MSdCYQsaMwqrghCGBIFNcNtyaXdm(HardwareJoystickMap.Platform_WindowsWGI_Base.Button P_0)
		{
			if (P_0.sourceType == 0)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (dUxVIgaadrfqJWSzRpXGORZlkMqp.MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!dUxVIgaadrfqJWSzRpXGORZlkMqp.MSdCYQsaMwqrghCGBIFNcNtyaXdm(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= MCDKyUJlmhQXfeayeJmoXfaHcWfiA || sourceButton >= 256)
				{
					return 0f;
				}
				if (!dUxVIgaadrfqJWSzRpXGORZlkMqp.MSdCYQsaMwqrghCGBIFNcNtyaXdm(sourceButton))
				{
					return 0f;
				}
				return 1f;
			}
			if (P_0.sourceType == 1)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0)
				{
					return 0f;
				}
				float num = mkqEwjEWKTccoblNpohIPzhMuvaL(sourceAxis);
				float num2 = MathTools.Abs(num);
				if (num2 <= P_0.axisDeadZone)
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
				return num2;
			}
			if (P_0.sourceType == 2)
			{
				int sourceHat = P_0.sourceHat;
				if (sourceHat < 0 || sourceHat >= nyDAXJEHgHLCMlTZKpdDYCOIRSQr || sourceHat >= 4)
				{
					return 0f;
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
			return 0f;
		}

		private float AEmeApyTXmVHqZHavQCdsWjXewZB(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return 0f;
			}
			if (hJeYXuujpZcIHhUzFngZZNyaunJy.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private void bfkxPXlKJejmTALFktyasdIIxRKhA()
		{
			BridgedControllerHWInfo bridgedControllerHWInfo = ridDROClRSAZyaDKOnfYTSobXEmrA();
			hJeYXuujpZcIHhUzFngZZNyaunJy = NBBGEOVRvneYDcFdnaoIhuFHZZKyB(bridgedControllerHWInfo);
			bool flag = false;
			bool flag2 = false;
			if (hJeYXuujpZcIHhUzFngZZNyaunJy == null || hJeYXuujpZcIHhUzFngZZNyaunJy.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
			{
				if (dUxVIgaadrfqJWSzRpXGORZlkMqp.kATsIGKujVXzLoucGAqkbVDjIxrA)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(4607, 10462);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					hJeYXuujpZcIHhUzFngZZNyaunJy = NBBGEOVRvneYDcFdnaoIhuFHZZKyB(bridgedControllerHWInfo);
					flag2 = true;
				}
				if (hJeYXuujpZcIHhUzFngZZNyaunJy == null || hJeYXuujpZcIHhUzFngZZNyaunJy.hardwareMapIdentifier.guid == Consts.joystickGuid_unknownController)
				{
					bridgedControllerHWInfo.hw_pidVid = new PidVid(736, 1118);
					bridgedControllerHWInfo.hw_productId = bridgedControllerHWInfo.hw_pidVid.productId;
					bridgedControllerHWInfo.hw_vendorId = bridgedControllerHWInfo.hw_pidVid.vendorId;
					bridgedControllerHWInfo.definitionMatchTag = string.Empty;
					hJeYXuujpZcIHhUzFngZZNyaunJy = NBBGEOVRvneYDcFdnaoIhuFHZZKyB(bridgedControllerHWInfo);
					flag = true;
				}
			}
			if (hJeYXuujpZcIHhUzFngZZNyaunJy == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (flag)
			{
				string text = string.Format("{0}:{1}", dUxVIgaadrfqJWSzRpXGORZlkMqp.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA.vendorId.ToString("x4"), dUxVIgaadrfqJWSzRpXGORZlkMqp.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA.productId.ToString("x4"));
				string key = LocalizationManager.AppendToKeyAsPath("windows_gaming_input_gamepad", text);
				hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.InsertParentKey(0, key);
				hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.InsertParentKey(1, "windows_gaming_input_gamepad");
				hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text}]";
			}
			else if (dUxVIgaadrfqJWSzRpXGORZlkMqp.kATsIGKujVXzLoucGAqkbVDjIxrA && (flag2 || hJeYXuujpZcIHhUzFngZZNyaunJy.hardwareMapIdentifier.guid == Consts.joystickGuid_steamController))
			{
				string text2 = string.Format("{0}:{1}", dUxVIgaadrfqJWSzRpXGORZlkMqp.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA.vendorId.ToString("x4"), dUxVIgaadrfqJWSzRpXGORZlkMqp.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA.productId.ToString("x4"));
				string key2 = LocalizationManager.AppendToKeyAsPath((hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.parentKeys.Count > 0 && !string.IsNullOrEmpty(hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.parentKeys[0])) ? hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.parentKeys[0] : "steam_controller", text2);
				hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.InsertParentKey(0, key2);
				hJeYXuujpZcIHhUzFngZZNyaunJy.deviceLocalizationInfo.additionalIdentifyingInformation = $"[{text2}]";
			}
			UDFcKRicGfzUGfNrRKCnISkDnKMVb = hJeYXuujpZcIHhUzFngZZNyaunJy.axisCount;
			FkOzkpBIpGDDNocsckZjSKLgiIVv = hJeYXuujpZcIHhUzFngZZNyaunJy.buttonCount;
		}

		private string pSdBCmdydqRtEhPXXoHSKfoiLscd()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{InputSource.WindowsGamingInput}{dUxVIgaadrfqJWSzRpXGORZlkMqp.mgfmGZeLtXcIMfABdmrEeVZBiEBOB}{kdNvziqmWoxIlwtlUVdLVjQQNpFi}{tNjxagUrcnyzWbSOsVMIFxUTEAOE.ToString()}");
		}

		private void QEJmtREKifDoriOcevlcZbMJbDfL(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.WindowsGamingInput;
			P_0.inputSource = dUxVIgaadrfqJWSzRpXGORZlkMqp.ETYQlWrHMsDuymSvhSEBrhZjAPnu;
			P_0.deviceType = (ControlDeviceType)dUxVIgaadrfqJWSzRpXGORZlkMqp.mgfmGZeLtXcIMfABdmrEeVZBiEBOB;
			P_0.hardwareIdentifier = pSdBCmdydqRtEhPXXoHSKfoiLscd();
			P_0.hardwareAxisCount = HhqbiwBXcDTULYOwmAYexUsXBMtCA;
			P_0.hardwareButtonCount = MCDKyUJlmhQXfeayeJmoXfaHcWfiA;
			P_0.hardwareHatCount = nyDAXJEHgHLCMlTZKpdDYCOIRSQr;
			if (dUxVIgaadrfqJWSzRpXGORZlkMqp.kATsIGKujVXzLoucGAqkbVDjIxrA)
			{
				P_0.definitionMatchTag = "[STEAMCONFIGURED]";
			}
			P_0.hw_productName = kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			P_0.hw_deviceGuid = QrLkiuceluZEPMOcjJiYcdnvZQtl;
			P_0.hw_productId = tNjxagUrcnyzWbSOsVMIFxUTEAOE.productId;
			P_0.hw_vendorId = tNjxagUrcnyzWbSOsVMIFxUTEAOE.vendorId;
			P_0.hw_pidVid = tNjxagUrcnyzWbSOsVMIFxUTEAOE;
			P_0.hw_isBluetoothDevice = false;
			P_0.hw_bluetoothDeviceName = kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			P_0.hw_supportsVibration = SFHEoLFtkmPWaGuXCKXjAhXIeZUVA;
			P_0.hw_localVibrationMotorCount = JRVaqxBKatYgbGYyeEJbKTzddNthb;
		}

		private void QEJmtREKifDoriOcevlcZbMJbDfL(BridgedController P_0)
		{
			QEJmtREKifDoriOcevlcZbMJbDfL((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = hJeYXuujpZcIHhUzFngZZNyaunJy.ToGameHardwareControllerMap();
			P_0.instanceName = QPMKBEqKVaycLpEwnGlOkcMWLImdb;
			P_0.productName = kdNvziqmWoxIlwtlUVdLVjQQNpFi;
			P_0.axisCount = UDFcKRicGfzUGfNrRKCnISkDnKMVb;
			P_0.buttonCount = FkOzkpBIpGDDNocsckZjSKLgiIVv;
			P_0.isButtonPressureSensitive = new bool[FkOzkpBIpGDDNocsckZjSKLgiIVv];
			Array.Copy(IpOZqbqmHTCfHMnUXjufSdcsSLwi, P_0.isButtonPressureSensitive, FkOzkpBIpGDDNocsckZjSKLgiIVv);
			P_0.unknownControllerHats = byrzdcexxneumZiIjICVRziDQXRT();
			P_0.controllerTypeGuid = dfkNjaPwXkaeRLYwmoTrUJWHbEfc;
			P_0.controllerExtension = extension;
		}

		private void yhHNwijDRgDwphgkEdcnAgVbjOgS()
		{
			for (int i = 0; i < FkOzkpBIpGDDNocsckZjSKLgiIVv; i++)
			{
				JkLuaNrBfUjBFJFAynrFZsuAKJMTA[i] = 0f;
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
				if (P_0 && dUxVIgaadrfqJWSzRpXGORZlkMqp != null)
				{
					dUxVIgaadrfqJWSzRpXGORZlkMqp.Dispose();
				}
				JWXwfaUAOJsMCNExsMKmFgNcBZSc = true;
			}
		}

		public static int ejhPQanSJmRJtgOzIiIJfBzXGfjcA(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0, AatiiCapDyGVJdTLYbTOWQftSuLMA P_1)
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

		public static int iPBJsEMpHEalRFrTLHdxePyElzOJA(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0, AatiiCapDyGVJdTLYbTOWQftSuLMA P_1)
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

	private class wmZOBnoLhlqzKIWfzKiVYjoWikYc
	{
		public enum UgYUIldjQWjQmnFRvxSwOgOLgMbGA
		{
			Exact = 0,
			Approximate = 1
		}

		public class kKyFrIjhyCnlPfGiSIwPOWBMStyz
		{
			public int yezDqSCRWxhlxMjsXiQKzSGNMhog;

			public Guid auRhMsSNSGdZKHBllYUoMazgzoCbA;

			public Guid iFObMCUaUQUnWzybrqxSRAVRTBWI;

			public int wsDsfjzHKLzCJcIILWEhQVQklLQu;

			public int HhqbiwBXcDTULYOwmAYexUsXBMtCA;

			public int MCDKyUJlmhQXfeayeJmoXfaHcWfiA;

			public int nyDAXJEHgHLCMlTZKpdDYCOIRSQr;

			public int FkOzkpBIpGDDNocsckZjSKLgiIVv;

			public int UDFcKRicGfzUGfNrRKCnISkDnKMVb;

			public bool sKPmsOwrsqQUGaDeDiygzRJgUHm(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0, UgYUIldjQWjQmnFRvxSwOgOLgMbGA P_1)
			{
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
				if (FkOzkpBIpGDDNocsckZjSKLgiIVv != P_0.FkOzkpBIpGDDNocsckZjSKLgiIVv)
				{
					return false;
				}
				if (UDFcKRicGfzUGfNrRKCnISkDnKMVb != P_0.UDFcKRicGfzUGfNrRKCnISkDnKMVb)
				{
					return false;
				}
				if (P_0.rewiredId == yezDqSCRWxhlxMjsXiQKzSGNMhog)
				{
					return true;
				}
				switch (P_1)
				{
				case UgYUIldjQWjQmnFRvxSwOgOLgMbGA.Exact:
					return auRhMsSNSGdZKHBllYUoMazgzoCbA == P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl;
				case UgYUIldjQWjQmnFRvxSwOgOLgMbGA.Approximate:
					return iFObMCUaUQUnWzybrqxSRAVRTBWI == P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI;
				default:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class zHCvrhwnlqeQzipzoZeFKkbJhRLRA : IEnumerable<kKyFrIjhyCnlPfGiSIwPOWBMStyz>, IEnumerator<kKyFrIjhyCnlPfGiSIwPOWBMStyz>, IDisposable, IEnumerable, IEnumerator
		{
			private int GaDEmGeAzDwcrUimnTDVbqDAEmMs;

			private kKyFrIjhyCnlPfGiSIwPOWBMStyz QZXFulaBJncjPFMoGHDkxBzfgAJM;

			private int nKWKxUHpZxraWHSPSgSgtAFyHyvHA;

			public wmZOBnoLhlqzKIWfzKiVYjoWikYc AtldvTEkDsEewBZFaEtbawltdqhzb;

			private AatiiCapDyGVJdTLYbTOWQftSuLMA wdbQxUuPsPgPKZuWmNEeMjEvEqweA;

			public AatiiCapDyGVJdTLYbTOWQftSuLMA KhdNMFEMmEAnBXbdNduCAUxxihfib;

			private UgYUIldjQWjQmnFRvxSwOgOLgMbGA XLaGCVhWSRFSHLsBcqOHnsPKrQmbA;

			public UgYUIldjQWjQmnFRvxSwOgOLgMbGA dPhbrgyjusQglwefgNYQseZkRnSN;

			private int NOddPDAtCADIsFnzlqGZAJmYYyoN;

			private int yJsBQJRPgsSANFiCNsLHwmcurxe;

			kKyFrIjhyCnlPfGiSIwPOWBMStyz IEnumerator<kKyFrIjhyCnlPfGiSIwPOWBMStyz>.Current
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
			public zHCvrhwnlqeQzipzoZeFKkbJhRLRA(int P_0)
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
				wmZOBnoLhlqzKIWfzKiVYjoWikYc atldvTEkDsEewBZFaEtbawltdqhzb = AtldvTEkDsEewBZFaEtbawltdqhzb;
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
			IEnumerator<kKyFrIjhyCnlPfGiSIwPOWBMStyz> IEnumerable<kKyFrIjhyCnlPfGiSIwPOWBMStyz>.GetEnumerator()
			{
				zHCvrhwnlqeQzipzoZeFKkbJhRLRA zHCvrhwnlqeQzipzoZeFKkbJhRLRA2;
				if (GaDEmGeAzDwcrUimnTDVbqDAEmMs == -2 && nKWKxUHpZxraWHSPSgSgtAFyHyvHA == Thread.CurrentThread.ManagedThreadId)
				{
					GaDEmGeAzDwcrUimnTDVbqDAEmMs = 0;
					zHCvrhwnlqeQzipzoZeFKkbJhRLRA2 = this;
				}
				else
				{
					zHCvrhwnlqeQzipzoZeFKkbJhRLRA2 = new zHCvrhwnlqeQzipzoZeFKkbJhRLRA(0);
					zHCvrhwnlqeQzipzoZeFKkbJhRLRA2.AtldvTEkDsEewBZFaEtbawltdqhzb = AtldvTEkDsEewBZFaEtbawltdqhzb;
				}
				zHCvrhwnlqeQzipzoZeFKkbJhRLRA2.wdbQxUuPsPgPKZuWmNEeMjEvEqweA = KhdNMFEMmEAnBXbdNduCAUxxihfib;
				zHCvrhwnlqeQzipzoZeFKkbJhRLRA2.XLaGCVhWSRFSHLsBcqOHnsPKrQmbA = dPhbrgyjusQglwefgNYQseZkRnSN;
				return zHCvrhwnlqeQzipzoZeFKkbJhRLRA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<kKyFrIjhyCnlPfGiSIwPOWBMStyz>)this).GetEnumerator();
			}
		}

		private List<kKyFrIjhyCnlPfGiSIwPOWBMStyz> ZDXhulnhGZktqkrQbgcQqMUrEhoFA;

		public wmZOBnoLhlqzKIWfzKiVYjoWikYc()
		{
			ZDXhulnhGZktqkrQbgcQqMUrEhoFA = new List<kKyFrIjhyCnlPfGiSIwPOWBMStyz>();
		}

		public void HgZeolIOSfnlKNNDACCahiudRKNec(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count;
			for (int i = 0; i < count; i++)
			{
				if (ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].sKPmsOwrsqQUGaDeDiygzRJgUHm(P_0, UgYUIldjQWjQmnFRvxSwOgOLgMbGA.Exact))
				{
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].yezDqSCRWxhlxMjsXiQKzSGNMhog = P_0.rewiredId;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].auRhMsSNSGdZKHBllYUoMazgzoCbA = P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].iFObMCUaUQUnWzybrqxSRAVRTBWI = P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].wsDsfjzHKLzCJcIILWEhQVQklLQu = P_0.inputManagerId;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].HhqbiwBXcDTULYOwmAYexUsXBMtCA = P_0.HhqbiwBXcDTULYOwmAYexUsXBMtCA;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].MCDKyUJlmhQXfeayeJmoXfaHcWfiA = P_0.MCDKyUJlmhQXfeayeJmoXfaHcWfiA;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].nyDAXJEHgHLCMlTZKpdDYCOIRSQr = P_0.nyDAXJEHgHLCMlTZKpdDYCOIRSQr;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].FkOzkpBIpGDDNocsckZjSKLgiIVv = P_0.FkOzkpBIpGDDNocsckZjSKLgiIVv;
					ZDXhulnhGZktqkrQbgcQqMUrEhoFA[i].UDFcKRicGfzUGfNrRKCnISkDnKMVb = P_0.UDFcKRicGfzUGfNrRKCnISkDnKMVb;
					rCRVlSgjPAfuPiLiTvQLcokniobBb(P_0.rewiredId, P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl, i);
					return;
				}
			}
			ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Add(new kKyFrIjhyCnlPfGiSIwPOWBMStyz
			{
				yezDqSCRWxhlxMjsXiQKzSGNMhog = P_0.rewiredId,
				auRhMsSNSGdZKHBllYUoMazgzoCbA = P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl,
				iFObMCUaUQUnWzybrqxSRAVRTBWI = P_0.iFObMCUaUQUnWzybrqxSRAVRTBWI,
				wsDsfjzHKLzCJcIILWEhQVQklLQu = P_0.inputManagerId,
				HhqbiwBXcDTULYOwmAYexUsXBMtCA = P_0.HhqbiwBXcDTULYOwmAYexUsXBMtCA,
				MCDKyUJlmhQXfeayeJmoXfaHcWfiA = P_0.MCDKyUJlmhQXfeayeJmoXfaHcWfiA,
				nyDAXJEHgHLCMlTZKpdDYCOIRSQr = P_0.nyDAXJEHgHLCMlTZKpdDYCOIRSQr,
				FkOzkpBIpGDDNocsckZjSKLgiIVv = P_0.FkOzkpBIpGDDNocsckZjSKLgiIVv,
				UDFcKRicGfzUGfNrRKCnISkDnKMVb = P_0.UDFcKRicGfzUGfNrRKCnISkDnKMVb
			});
			rCRVlSgjPAfuPiLiTvQLcokniobBb(P_0.rewiredId, P_0.QrLkiuceluZEPMOcjJiYcdnvZQtl, ZDXhulnhGZktqkrQbgcQqMUrEhoFA.Count - 1);
		}

		public bool ecSZEwttGfkQfToParxnBfHCGISs(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0, UgYUIldjQWjQmnFRvxSwOgOLgMbGA P_1)
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

		public IEnumerable<kKyFrIjhyCnlPfGiSIwPOWBMStyz> OoDdjwkheCaHvrmPJPlqsPWCeYVtA(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0, UgYUIldjQWjQmnFRvxSwOgOLgMbGA P_1)
		{
			return new zHCvrhwnlqeQzipzoZeFKkbJhRLRA(-2)
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

	private const bool JTkGnSrfZjbMIeikSgRPGVgBFcys = true;

	private pLEymDyHpxCWcoAHXjTDfEXGOdLCA VJqiKKXXamrBvKoHxFweMYRcVrUQ;

	private List<AatiiCapDyGVJdTLYbTOWQftSuLMA> exboENaiRtnmZhkKYPooaLjfzRgt;

	private int jyLoZzeEHQjZlxUjkiftZdyFYIdh;

	private wmZOBnoLhlqzKIWfzKiVYjoWikYc CeUmIOzWqsxenwcfmJvHQCMbWQXg;

	private bool mknBdDyOBGnVISyDYAUHfvJyjMmm;

	private ConfigVars PvkambuTKjFIBNOzasbZzZqscmHl;

	private Action<int, ControllerDataUpdater> ogoLdzNKsHvptwEnFfXlaACHoIJO;

	private PlatformInputManager cenkEFLNjUadqCYJhKRRkUtIKUYNA;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> EtLWzOxoiSdkpGOpmFcLCIXPfrDbb;

	private readonly Func<int> FkKAFEXjiJpbaBpOcYIALNvtByLEA;

	private Func<PidVid, bool> hHaeeNHMQpezjCnHXObXPxrEFduT;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => jyLoZzeEHQjZlxUjkiftZdyFYIdh;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => cenkEFLNjUadqCYJhKRRkUtIKUYNA;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => VJqiKKXXamrBvKoHxFweMYRcVrUQ;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.WindowsGamingInput;

	protected pLEymDyHpxCWcoAHXjTDfEXGOdLCA YlaYSjcpOVmfIsPYbyeGRNoSdHDS => VJqiKKXXamrBvKoHxFweMYRcVrUQ;

	public cUYFPgdmXySFZwutVlfquFdQOLaDb(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, Func<PidVid, bool> P_3)
	{
		try
		{
			PvkambuTKjFIBNOzasbZzZqscmHl = P_0;
			EtLWzOxoiSdkpGOpmFcLCIXPfrDbb = P_1;
			FkKAFEXjiJpbaBpOcYIALNvtByLEA = P_2;
			hHaeeNHMQpezjCnHXObXPxrEFduT = P_3;
			cenkEFLNjUadqCYJhKRRkUtIKUYNA = this;
			VJqiKKXXamrBvKoHxFweMYRcVrUQ = new pLEymDyHpxCWcoAHXjTDfEXGOdLCA(P_0, true, false, false);
			VJqiKKXXamrBvKoHxFweMYRcVrUQ.DeviceChangedEvent += SystemDeviceConnected;
			ogoLdzNKsHvptwEnFfXlaACHoIJO = UpdateControllerData;
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
		CeUmIOzWqsxenwcfmJvHQCMbWQXg = new wmZOBnoLhlqzKIWfzKiVYjoWikYc();
		VJqiKKXXamrBvKoHxFweMYRcVrUQ.WSPvZFdLBPLYaAvDOopBJcbIPhan();
		wVvzxdrDDEaQGilyJYsnhosKfeoBb();
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (VJqiKKXXamrBvKoHxFweMYRcVrUQ != null)
		{
			VJqiKKXXamrBvKoHxFweMYRcVrUQ.Update();
		}
		if (mknBdDyOBGnVISyDYAUHfvJyjMmm)
		{
			GEwSlAuVXDVcbvVaDgAKrWVRjpMi();
		}
		if (VJqiKKXXamrBvKoHxFweMYRcVrUQ != null)
		{
			VJqiKKXXamrBvKoHxFweMYRcVrUQ.UpdateDevices(updateLoop);
		}
		HuQMjaeKUlhtoxviEIRhkVYsSmvt();
		if (VJqiKKXXamrBvKoHxFweMYRcVrUQ != null)
		{
			VJqiKKXXamrBvKoHxFweMYRcVrUQ.UpdateFinished();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (exboENaiRtnmZhkKYPooaLjfzRgt != null)
		{
			int count = exboENaiRtnmZhkKYPooaLjfzRgt.Count;
			for (int i = 0; i < count; i++)
			{
				if (exboENaiRtnmZhkKYPooaLjfzRgt[i] != null)
				{
					exboENaiRtnmZhkKYPooaLjfzRgt[i].Dispose();
				}
			}
		}
		if (VJqiKKXXamrBvKoHxFweMYRcVrUQ != null)
		{
			VJqiKKXXamrBvKoHxFweMYRcVrUQ.Dispose();
		}
	}

	[CustomObfuscation(rename = false)]
	public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
	{
		return ogoLdzNKsHvptwEnFfXlaACHoIJO;
	}

	[CustomObfuscation(rename = false)]
	public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
	{
		for (int i = 0; i < jyLoZzeEHQjZlxUjkiftZdyFYIdh; i++)
		{
			if (exboENaiRtnmZhkKYPooaLjfzRgt[i].inputManagerId == inputManagerId)
			{
				exboENaiRtnmZhkKYPooaLjfzRgt[i].FillData(data);
				return;
			}
		}
		Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		mknBdDyOBGnVISyDYAUHfvJyjMmm = true;
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		mknBdDyOBGnVISyDYAUHfvJyjMmm = true;
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
		return VJqiKKXXamrBvKoHxFweMYRcVrUQ.EZQxJKKBmfLZMsxGaqwTRwIDnTEb;
	}

	[CustomObfuscation(rename = false)]
	public override IUnifiedKeyboardSource GetUnifiedKeyboardSource()
	{
		return VJqiKKXXamrBvKoHxFweMYRcVrUQ.adHBjcvEdNpHymhIkbHtEHAdbNujb;
	}

	protected bool KekVraEJcCwjAQkSbbSQjprgjzPW(PidVid P_0)
	{
		return hHaeeNHMQpezjCnHXObXPxrEFduT(P_0);
	}

	private void wVvzxdrDDEaQGilyJYsnhosKfeoBb()
	{
		wVvzxdrDDEaQGilyJYsnhosKfeoBb(dYbvqqqQyxutNZhTNNywxlOJSeMV());
	}

	private void wVvzxdrDDEaQGilyJYsnhosKfeoBb(IList<NPcbXYOMZTPjQpCotxkrcLlyrqWf> P_0)
	{
		int num = 0;
		List<AatiiCapDyGVJdTLYbTOWQftSuLMA> list = exboENaiRtnmZhkKYPooaLjfzRgt;
		int num2 = jyLoZzeEHQjZlxUjkiftZdyFYIdh;
		exboENaiRtnmZhkKYPooaLjfzRgt = new List<AatiiCapDyGVJdTLYbTOWQftSuLMA>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				NPcbXYOMZTPjQpCotxkrcLlyrqWf nPcbXYOMZTPjQpCotxkrcLlyrqWf = P_0[i];
				AatiiCapDyGVJdTLYbTOWQftSuLMA aatiiCapDyGVJdTLYbTOWQftSuLMA = new AatiiCapDyGVJdTLYbTOWQftSuLMA(EtLWzOxoiSdkpGOpmFcLCIXPfrDbb);
				aatiiCapDyGVJdTLYbTOWQftSuLMA.dUxVIgaadrfqJWSzRpXGORZlkMqp = nPcbXYOMZTPjQpCotxkrcLlyrqWf;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.QrLkiuceluZEPMOcjJiYcdnvZQtl = nPcbXYOMZTPjQpCotxkrcLlyrqWf.SCGcrIIDMjURHdkJjDIzHoMbvWQHA;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.QPMKBEqKVaycLpEwnGlOkcMWLImdb = nPcbXYOMZTPjQpCotxkrcLlyrqWf.ZyBJVlNnRXiQSTOwYGZhHQaVFLJNA;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.kdNvziqmWoxIlwtlUVdLVjQQNpFi = nPcbXYOMZTPjQpCotxkrcLlyrqWf.ZyBJVlNnRXiQSTOwYGZhHQaVFLJNA;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.tNjxagUrcnyzWbSOsVMIFxUTEAOE = nPcbXYOMZTPjQpCotxkrcLlyrqWf.XBuLKAjGqIEkVdiRHWjHoeXsEiVeA;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.SdthoJItTfcAKBEUPFiNJgcraHGZA = nPcbXYOMZTPjQpCotxkrcLlyrqWf.BEwuJlSgrzvnNiHAkXqrckJVpxbD;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.HhqbiwBXcDTULYOwmAYexUsXBMtCA = nPcbXYOMZTPjQpCotxkrcLlyrqWf.OnAwGKsEQkUZSJUZVquvqkbDyaWo;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.MCDKyUJlmhQXfeayeJmoXfaHcWfiA = nPcbXYOMZTPjQpCotxkrcLlyrqWf.JVqCHAvnctFGSlUdMoFcLkcNXrDA;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.nyDAXJEHgHLCMlTZKpdDYCOIRSQr = nPcbXYOMZTPjQpCotxkrcLlyrqWf.nHDbLoGMognNLMuWpWyCEHRJaNibA;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.SFHEoLFtkmPWaGuXCKXjAhXIeZUVA = nPcbXYOMZTPjQpCotxkrcLlyrqWf.SupportsVibration;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.JRVaqxBKatYgbGYyeEJbKTzddNthb = nPcbXYOMZTPjQpCotxkrcLlyrqWf.VibrationMotorCount;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.extension = nPcbXYOMZTPjQpCotxkrcLlyrqWf.ORFGGDZXMYwdSxkLZdpeDghCakvhb;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.dUxVIgaadrfqJWSzRpXGORZlkMqp = nPcbXYOMZTPjQpCotxkrcLlyrqWf;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.OKLfbagyaudIxlHWyOTBXIXfgzkUA();
				exboENaiRtnmZhkKYPooaLjfzRgt.Add(aatiiCapDyGVJdTLYbTOWQftSuLMA);
				num++;
			}
		}
		jyLoZzeEHQjZlxUjkiftZdyFYIdh = num;
		yCerSzlhCsNqVTmGzxfvEztWrZKJ(num2, num, list, exboENaiRtnmZhkKYPooaLjfzRgt);
		for (int j = 0; j < num; j++)
		{
			if (_UpdateControllerInfoEvent != null)
			{
				_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(exboENaiRtnmZhkKYPooaLjfzRgt[j]));
			}
		}
		lZhwEqQAMUuThvcqBsjRFkkUsOxO(list, exboENaiRtnmZhkKYPooaLjfzRgt, false);
		lZhwEqQAMUuThvcqBsjRFkkUsOxO(exboENaiRtnmZhkKYPooaLjfzRgt, list, true);
	}

	private void HuQMjaeKUlhtoxviEIRhkVYsSmvt()
	{
		for (int i = 0; i < jyLoZzeEHQjZlxUjkiftZdyFYIdh; i++)
		{
			exboENaiRtnmZhkKYPooaLjfzRgt[i]?.Update();
		}
	}

	private IList<NPcbXYOMZTPjQpCotxkrcLlyrqWf> dYbvqqqQyxutNZhTNNywxlOJSeMV()
	{
		return VJqiKKXXamrBvKoHxFweMYRcVrUQ.GetJoysticks<NPcbXYOMZTPjQpCotxkrcLlyrqWf>();
	}

	private void yCerSzlhCsNqVTmGzxfvEztWrZKJ(int P_0, int P_1, List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_2, List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(AatiiCapDyGVJdTLYbTOWQftSuLMA.iPBJsEMpHEalRFrTLHdxePyElzOJA);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			wuaCIwaEhsQfxmqZgODZijGGOoeHb(P_1, P_3, P_0, P_2, wmZOBnoLhlqzKIWfzKiVYjoWikYc.UgYUIldjQWjQmnFRvxSwOgOLgMbGA.Exact);
			wuaCIwaEhsQfxmqZgODZijGGOoeHb(P_1, P_3, P_0, P_2, wmZOBnoLhlqzKIWfzKiVYjoWikYc.UgYUIldjQWjQmnFRvxSwOgOLgMbGA.Approximate);
		}
		smcCiZysONMbkSQvFgYTXeMDHzls(P_1, P_3, wmZOBnoLhlqzKIWfzKiVYjoWikYc.UgYUIldjQWjQmnFRvxSwOgOLgMbGA.Exact);
		smcCiZysONMbkSQvFgYTXeMDHzls(P_1, P_3, wmZOBnoLhlqzKIWfzKiVYjoWikYc.UgYUIldjQWjQmnFRvxSwOgOLgMbGA.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			AatiiCapDyGVJdTLYbTOWQftSuLMA aatiiCapDyGVJdTLYbTOWQftSuLMA = P_3[i];
			if (aatiiCapDyGVJdTLYbTOWQftSuLMA != null && aatiiCapDyGVJdTLYbTOWQftSuLMA.inputManagerId < 0)
			{
				aatiiCapDyGVJdTLYbTOWQftSuLMA.inputManagerId = LPWxxllcQTgkueLabuveIFxjmWShA(P_3);
				aatiiCapDyGVJdTLYbTOWQftSuLMA.rewiredId = FkKAFEXjiJpbaBpOcYIALNvtByLEA();
				CeUmIOzWqsxenwcfmJvHQCMbWQXg.HgZeolIOSfnlKNNDACCahiudRKNec(aatiiCapDyGVJdTLYbTOWQftSuLMA);
			}
		}
		P_3.Sort(AatiiCapDyGVJdTLYbTOWQftSuLMA.ejhPQanSJmRJtgOzIiIJfBzXGfjcA);
	}

	private void NcHJyIKkRfIZStZZRCRMlYNzGMob(List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_0, int P_1, int P_2)
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

	private bool FbgGsqaEobfojdDLkZawNsMubCOvA(List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_0, int P_1)
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

	private int LPWxxllcQTgkueLabuveIFxjmWShA(List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_0)
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

	private bool DfAHMpnyMaKopMatiqeimNyLHtBb(List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_0, int P_1)
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

	private void wuaCIwaEhsQfxmqZgODZijGGOoeHb(int P_0, List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_1, int P_2, List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_3, wmZOBnoLhlqzKIWfzKiVYjoWikYc.UgYUIldjQWjQmnFRvxSwOgOLgMbGA P_4)
	{
		int num = ((P_4 != wmZOBnoLhlqzKIWfzKiVYjoWikYc.UgYUIldjQWjQmnFRvxSwOgOLgMbGA.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			AatiiCapDyGVJdTLYbTOWQftSuLMA aatiiCapDyGVJdTLYbTOWQftSuLMA = P_1[i];
			if (aatiiCapDyGVJdTLYbTOWQftSuLMA == null || aatiiCapDyGVJdTLYbTOWQftSuLMA.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				AatiiCapDyGVJdTLYbTOWQftSuLMA aatiiCapDyGVJdTLYbTOWQftSuLMA2 = P_3[j];
				if (aatiiCapDyGVJdTLYbTOWQftSuLMA2 != null && !DfAHMpnyMaKopMatiqeimNyLHtBb(P_1, aatiiCapDyGVJdTLYbTOWQftSuLMA2.rewiredId) && aatiiCapDyGVJdTLYbTOWQftSuLMA.sKPmsOwrsqQUGaDeDiygzRJgUHm(aatiiCapDyGVJdTLYbTOWQftSuLMA2) >= num)
				{
					aatiiCapDyGVJdTLYbTOWQftSuLMA.OLfmjaYQlzgJtGmEIVCoLPHHLIfZ(aatiiCapDyGVJdTLYbTOWQftSuLMA2);
					CeUmIOzWqsxenwcfmJvHQCMbWQXg.HgZeolIOSfnlKNNDACCahiudRKNec(aatiiCapDyGVJdTLYbTOWQftSuLMA);
				}
			}
		}
	}

	private void smcCiZysONMbkSQvFgYTXeMDHzls(int P_0, List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_1, wmZOBnoLhlqzKIWfzKiVYjoWikYc.UgYUIldjQWjQmnFRvxSwOgOLgMbGA P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			AatiiCapDyGVJdTLYbTOWQftSuLMA aatiiCapDyGVJdTLYbTOWQftSuLMA = P_1[i];
			if (aatiiCapDyGVJdTLYbTOWQftSuLMA == null || aatiiCapDyGVJdTLYbTOWQftSuLMA.inputManagerId >= 0)
			{
				continue;
			}
			wmZOBnoLhlqzKIWfzKiVYjoWikYc.kKyFrIjhyCnlPfGiSIwPOWBMStyz kKyFrIjhyCnlPfGiSIwPOWBMStyz = null;
			foreach (wmZOBnoLhlqzKIWfzKiVYjoWikYc.kKyFrIjhyCnlPfGiSIwPOWBMStyz item in CeUmIOzWqsxenwcfmJvHQCMbWQXg.OoDdjwkheCaHvrmPJPlqsPWCeYVtA(aatiiCapDyGVJdTLYbTOWQftSuLMA, P_2))
			{
				if (!DfAHMpnyMaKopMatiqeimNyLHtBb(P_1, item.yezDqSCRWxhlxMjsXiQKzSGNMhog) && item.wsDsfjzHKLzCJcIILWEhQVQklLQu >= 0)
				{
					kKyFrIjhyCnlPfGiSIwPOWBMStyz = item;
					break;
				}
			}
			if (kKyFrIjhyCnlPfGiSIwPOWBMStyz != null)
			{
				int num = kKyFrIjhyCnlPfGiSIwPOWBMStyz.wsDsfjzHKLzCJcIILWEhQVQklLQu;
				if (!FbgGsqaEobfojdDLkZawNsMubCOvA(P_1, num))
				{
					num = (kKyFrIjhyCnlPfGiSIwPOWBMStyz.wsDsfjzHKLzCJcIILWEhQVQklLQu = LPWxxllcQTgkueLabuveIFxjmWShA(P_1));
				}
				aatiiCapDyGVJdTLYbTOWQftSuLMA.inputManagerId = num;
				aatiiCapDyGVJdTLYbTOWQftSuLMA.rewiredId = kKyFrIjhyCnlPfGiSIwPOWBMStyz.yezDqSCRWxhlxMjsXiQKzSGNMhog;
				CeUmIOzWqsxenwcfmJvHQCMbWQXg.HgZeolIOSfnlKNNDACCahiudRKNec(aatiiCapDyGVJdTLYbTOWQftSuLMA);
			}
		}
	}

	private void GEwSlAuVXDVcbvVaDgAKrWVRjpMi()
	{
		VJqiKKXXamrBvKoHxFweMYRcVrUQ.WSPvZFdLBPLYaAvDOopBJcbIPhan();
		IList<NPcbXYOMZTPjQpCotxkrcLlyrqWf> list = dYbvqqqQyxutNZhTNNywxlOJSeMV();
		if (ZQeObJRNMFLkBQHlsgdMEEcsbbjcb(list))
		{
			wVvzxdrDDEaQGilyJYsnhosKfeoBb(list);
		}
		mknBdDyOBGnVISyDYAUHfvJyjMmm = false;
	}

	private bool ZQeObJRNMFLkBQHlsgdMEEcsbbjcb(IList<NPcbXYOMZTPjQpCotxkrcLlyrqWf> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !KbBeKArMJduJpEIezPVKEIfBUzIm(P_0[i].SCGcrIIDMjURHdkJjDIzHoMbvWQHA))
			{
				return true;
			}
		}
		int count2 = exboENaiRtnmZhkKYPooaLjfzRgt.Count;
		for (int j = 0; j < count2; j++)
		{
			if (exboENaiRtnmZhkKYPooaLjfzRgt[j] != null && !xqJQtvnljRCODgaLQIhgcKPevtxLb(P_0, exboENaiRtnmZhkKYPooaLjfzRgt[j].QrLkiuceluZEPMOcjJiYcdnvZQtl))
			{
				return true;
			}
		}
		return false;
	}

	private bool KbBeKArMJduJpEIezPVKEIfBUzIm(Guid P_0)
	{
		int count = exboENaiRtnmZhkKYPooaLjfzRgt.Count;
		for (int i = 0; i < count; i++)
		{
			if (exboENaiRtnmZhkKYPooaLjfzRgt[i] != null && exboENaiRtnmZhkKYPooaLjfzRgt[i].QrLkiuceluZEPMOcjJiYcdnvZQtl == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool xqJQtvnljRCODgaLQIhgcKPevtxLb(IList<NPcbXYOMZTPjQpCotxkrcLlyrqWf> P_0, Guid P_1)
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

	private void lZhwEqQAMUuThvcqBsjRFkkUsOxO(List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_0, List<AatiiCapDyGVJdTLYbTOWQftSuLMA> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			AatiiCapDyGVJdTLYbTOWQftSuLMA aatiiCapDyGVJdTLYbTOWQftSuLMA = P_0[i];
			if (aatiiCapDyGVJdTLYbTOWQftSuLMA == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					AatiiCapDyGVJdTLYbTOWQftSuLMA aatiiCapDyGVJdTLYbTOWQftSuLMA2 = P_1[j];
					if (aatiiCapDyGVJdTLYbTOWQftSuLMA2 != null && aatiiCapDyGVJdTLYbTOWQftSuLMA.QrLkiuceluZEPMOcjJiYcdnvZQtl == aatiiCapDyGVJdTLYbTOWQftSuLMA2.QrLkiuceluZEPMOcjJiYcdnvZQtl)
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

	private void VTTdBYSqcQzDyOFRkPCEjraxYldu(AatiiCapDyGVJdTLYbTOWQftSuLMA P_0, bool P_1)
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
}
