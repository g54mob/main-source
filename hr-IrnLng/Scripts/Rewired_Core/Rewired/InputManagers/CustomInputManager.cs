using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Platforms;
using Rewired.Platforms.Custom;
using Rewired.Utils;

namespace Rewired.InputManagers
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class CustomInputManager : PlatformInputManager
	{
		private class LheKHkshSClbCEWydXHLtjZwBFH : IInputManagerJoystickPublic, IInputManagerJoystick
		{
			private readonly InputSource iRyNPwfaIbylCKBnafrigDzkSzy;

			private readonly CustomInputSource xRpNKtzGEPLTrbhkANDVbgqmfgA;

			private readonly Controller.Extension hROuCGhdASTVBaBVhwSmSNLFQTP;

			private int jIpZegDsRCglpRpWZFkZhlMabSZS;

			private int sVCXCYtCFTJlHfQcwXhLqojaMtg;

			private long? zDPnjZHaLRdBKekxEKYFrQRqwLO;

			private int gfRejPemhyrlXBFjuSIUeEWTIFdB;

			public Guid ndgbjpxTbxrFsttqZvzramhIWKV;

			public string lHQYbisGVvjnzJpPFVbMlbKfupd;

			public string VEJFfjfzOWEETlpJFhPbxPYsRtZ;

			private int rGEuFEtJcMmFaLOCcsmbRHUjSpy;

			private int qrXpdbCUzFLCBfjCDTfPHyJCus;

			private float[] jzpVEtuClUvVjBdDtjXvLsbzhOL;

			private bool[] HgTlEIPAcVpesdxuHAohUBSLbkRC;

			private HardwareJoystickMap_InputManager rEqQznEUmYwtoLNJsErzjlKjjYY;

			public CustomInputSource.Joystick IXdpDSnwcKTGbFZJiEqtHrSPcPq;

			private bool lIckeksaZUISOlJWqVjEgKdCPmH;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> BtXgoZzfyixretGRKXdmAjlGRaR;

			public int hardwareButtonCount
			{
				get
				{
					if (IXdpDSnwcKTGbFZJiEqtHrSPcPq == null)
					{
						return 0;
					}
					return IXdpDSnwcKTGbFZJiEqtHrSPcPq.buttonCount;
				}
			}

			public int hardwareAxisCount
			{
				get
				{
					if (IXdpDSnwcKTGbFZJiEqtHrSPcPq == null)
					{
						return 0;
					}
					return IXdpDSnwcKTGbFZJiEqtHrSPcPq.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			public int rewiredId
			{
				get
				{
					return jIpZegDsRCglpRpWZFkZhlMabSZS;
				}
				set
				{
					jIpZegDsRCglpRpWZFkZhlMabSZS = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public int inputManagerId
			{
				get
				{
					return sVCXCYtCFTJlHfQcwXhLqojaMtg;
				}
				set
				{
					sVCXCYtCFTJlHfQcwXhLqojaMtg = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public string name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(IXdpDSnwcKTGbFZJiEqtHrSPcPq.customName)) ? IXdpDSnwcKTGbFZJiEqtHrSPcPq.customName : lHQYbisGVvjnzJpPFVbMlbKfupd);
					if (text == "Unknown Controller")
					{
						text = VEJFfjfzOWEETlpJFhPbxPYsRtZ;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			public long? systemId => zDPnjZHaLRdBKekxEKYFrQRqwLO;

			[CustomObfuscation(rename = false)]
			public int unityId => gfRejPemhyrlXBFjuSIUeEWTIFdB;

			[CustomObfuscation(rename = false)]
			public Guid instanceGuid
			{
				get
				{
					if (!zDPnjZHaLRdBKekxEKYFrQRqwLO.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(name + "_" + zDPnjZHaLRdBKekxEKYFrQRqwLO);
				}
			}

			[CustomObfuscation(rename = false)]
			public Guid persistentGuid => instanceGuid;

			[CustomObfuscation(rename = false)]
			public Controller.Extension extension => hROuCGhdASTVBaBVhwSmSNLFQTP;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			public LheKHkshSClbCEWydXHLtjZwBFH(CustomInputSource customInputSource, long? systemJoystickId, int unityJoystickId, CustomInputSource.Joystick joystick, InputSource inputSource, Controller.Extension controllerExtension, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager)
			{
				xRpNKtzGEPLTrbhkANDVbgqmfgA = customInputSource;
				iRyNPwfaIbylCKBnafrigDzkSzy = inputSource;
				zDPnjZHaLRdBKekxEKYFrQRqwLO = systemJoystickId;
				IXdpDSnwcKTGbFZJiEqtHrSPcPq = joystick;
				gfRejPemhyrlXBFjuSIUeEWTIFdB = unityJoystickId;
				hROuCGhdASTVBaBVhwSmSNLFQTP = controllerExtension;
				BtXgoZzfyixretGRKXdmAjlGRaR = getHardwareJoystickMap_InputManager;
				sVCXCYtCFTJlHfQcwXhLqojaMtg = -1;
				jIpZegDsRCglpRpWZFkZhlMabSZS = -1;
				htdHIzalDiucJbnRddXwJvCFuAb();
				nXglhCVRQvdNmlZfFNtWDSyReON();
				ndgbjpxTbxrFsttqZvzramhIWKV = rEqQznEUmYwtoLNJsErzjlKjjYY.hardwareMapIdentifier.guid;
				lHQYbisGVvjnzJpPFVbMlbKfupd = rEqQznEUmYwtoLNJsErzjlKjjYY.controllerName;
				jzpVEtuClUvVjBdDtjXvLsbzhOL = new float[rGEuFEtJcMmFaLOCcsmbRHUjSpy];
				HgTlEIPAcVpesdxuHAohUBSLbkRC = new bool[qrXpdbCUzFLCBfjCDTfPHyJCus];
				Update();
			}

			public void htdHIzalDiucJbnRddXwJvCFuAb()
			{
				VEJFfjfzOWEETlpJFhPbxPYsRtZ = IXdpDSnwcKTGbFZJiEqtHrSPcPq.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (IXdpDSnwcKTGbFZJiEqtHrSPcPq.isConnected)
				{
					eDxlTkEkZjIqIOaXTGEydwFFOfoR();
					DmLZJnvnrnNkrBYTnoYZbojIVhn();
				}
			}

			public int kGUAgzoWmpBJnomvNrYAMpbELMU(LheKHkshSClbCEWydXHLtjZwBFH P_0)
			{
				if (P_0.VEJFfjfzOWEETlpJFhPbxPYsRtZ == VEJFfjfzOWEETlpJFhPbxPYsRtZ && P_0.zDPnjZHaLRdBKekxEKYFrQRqwLO == zDPnjZHaLRdBKekxEKYFrQRqwLO)
				{
					return 2;
				}
				if (P_0.VEJFfjfzOWEETlpJFhPbxPYsRtZ == VEJFfjfzOWEETlpJFhPbxPYsRtZ)
				{
					return 1;
				}
				return 0;
			}

			private void OZHQiQgSzsqBMEXKRiXEjRuQMNq(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = iRyNPwfaIbylCKBnafrigDzkSzy;
				P_0.inputSource = iRyNPwfaIbylCKBnafrigDzkSzy;
				P_0.hardwareIdentifier = xtPTTEaBiKHldvKRyKuWbfwSXWZ();
				P_0.hardwareAxisCount = rGEuFEtJcMmFaLOCcsmbRHUjSpy;
				P_0.hardwareButtonCount = qrXpdbCUzFLCBfjCDTfPHyJCus;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = VEJFfjfzOWEETlpJFhPbxPYsRtZ;
				P_0.hw_supportsVibration = IXdpDSnwcKTGbFZJiEqtHrSPcPq.supportsVibration;
			}

			private void OZHQiQgSzsqBMEXKRiXEjRuQMNq(BridgedController P_0)
			{
				OZHQiQgSzsqBMEXKRiXEjRuQMNq((BridgedControllerHWInfo)P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = rEqQznEUmYwtoLNJsErzjlKjjYY.ToGameHardwareControllerMap();
				P_0.instanceName = VEJFfjfzOWEETlpJFhPbxPYsRtZ;
				P_0.productName = VEJFfjfzOWEETlpJFhPbxPYsRtZ;
				P_0.isXInputDevice = false;
				P_0.axisCount = rGEuFEtJcMmFaLOCcsmbRHUjSpy;
				P_0.buttonCount = qrXpdbCUzFLCBfjCDTfPHyJCus;
				P_0.controllerTypeGuid = ndgbjpxTbxrFsttqZvzramhIWKV;
				P_0.customInputSource = xRpNKtzGEPLTrbhkANDVbgqmfgA;
				P_0.controllerExtension = hROuCGhdASTVBaBVhwSmSNLFQTP;
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (rGEuFEtJcMmFaLOCcsmbRHUjSpy != dataUpdater.axisCount || qrXpdbCUzFLCBfjCDTfPHyJCus != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < rGEuFEtJcMmFaLOCcsmbRHUjSpy; i++)
				{
					dataUpdater.axisValues[i] = jzpVEtuClUvVjBdDtjXvLsbzhOL[i];
				}
				for (int j = 0; j < qrXpdbCUzFLCBfjCDTfPHyJCus; j++)
				{
					dataUpdater.buttonValues[j] = HgTlEIPAcVpesdxuHAohUBSLbkRC[j];
				}
				if (lIckeksaZUISOlJWqVjEgKdCPmH && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			public BridgedControllerHWInfo nGxBhPkTOZfyTEzcjVyqmmIgztnf()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				OZHQiQgSzsqBMEXKRiXEjRuQMNq(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				OZHQiQgSzsqBMEXKRiXEjRuQMNq(bridgedController);
				return bridgedController;
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(jIpZegDsRCglpRpWZFkZhlMabSZS);
			}

			private void eDxlTkEkZjIqIOaXTGEydwFFOfoR()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)rEqQznEUmYwtoLNJsErzjlKjjYY.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= rGEuFEtJcMmFaLOCcsmbRHUjSpy)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						jzpVEtuClUvVjBdDtjXvLsbzhOL[i] = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(axes[i]);
						if (!lIckeksaZUISOlJWqVjEgKdCPmH && jzpVEtuClUvVjBdDtjXvLsbzhOL[i] != 0f)
						{
							lIckeksaZUISOlJWqVjEgKdCPmH = true;
						}
					}
				}
			}

			private void DmLZJnvnrnNkrBYTnoYZbojIVhn()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)rEqQznEUmYwtoLNJsErzjlKjjYY.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= qrXpdbCUzFLCBfjCDTfPHyJCus)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					HgTlEIPAcVpesdxuHAohUBSLbkRC[i] = YkbkFPCFEvZkXFmauWArEBZdXhq(buttons[i]);
					if (!lIckeksaZUISOlJWqVjEgKdCPmH && HgTlEIPAcVpesdxuHAohUBSLbkRC[i])
					{
						lIckeksaZUISOlJWqVjEgKdCPmH = true;
					}
				}
			}

			private bool YkbkFPCFEvZkXFmauWArEBZdXhq(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0.sourceType == 0)
				{
					return YkbkFPCFEvZkXFmauWArEBZdXhq(P_0.sourceButton);
				}
				if (P_0.sourceType == 1)
				{
					float num = cgmAKoDiHUFFXhNnFYmsRnBjTDvK(P_0.sourceAxis);
					if (MathTools.Abs(num) <= P_0.axisDeadZone)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Positive && num < 0f)
					{
						return false;
					}
					if (P_0.sourceAxisPole == Pole.Negative && num > 0f)
					{
						return false;
					}
					return true;
				}
				return false;
			}

			private bool hzliQjSHnMiRjGzedHXXtVVWUcNG(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float cgmAKoDiHUFFXhNnFYmsRnBjTDvK(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return cgmAKoDiHUFFXhNnFYmsRnBjTDvK(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!YkbkFPCFEvZkXFmauWArEBZdXhq(P_0.sourceButton))
					{
						return 0f;
					}
					if (P_0.buttonAxisContribution == Pole.Positive)
					{
						return 1f;
					}
					return -1f;
				}
				throw new NotImplementedException();
			}

			private float cgmAKoDiHUFFXhNnFYmsRnBjTDvK(int P_0)
			{
				return IXdpDSnwcKTGbFZJiEqtHrSPcPq.GetAxisValue(P_0);
			}

			private bool YkbkFPCFEvZkXFmauWArEBZdXhq(int P_0)
			{
				return IXdpDSnwcKTGbFZJiEqtHrSPcPq.GetButtonValue(P_0);
			}

			private void nXglhCVRQvdNmlZfFNtWDSyReON()
			{
				rEqQznEUmYwtoLNJsErzjlKjjYY = BtXgoZzfyixretGRKXdmAjlGRaR(nGxBhPkTOZfyTEzcjVyqmmIgztnf());
				if (rEqQznEUmYwtoLNJsErzjlKjjYY == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				rGEuFEtJcMmFaLOCcsmbRHUjSpy = rEqQznEUmYwtoLNJsErzjlKjjYY.axisCount;
				qrXpdbCUzFLCBfjCDTfPHyJCus = rEqQznEUmYwtoLNJsErzjlKjjYY.buttonCount;
			}

			private void BMxTPkCTwKHaHoMkxNoqwTHvLfs()
			{
				Array.Clear(HgTlEIPAcVpesdxuHAohUBSLbkRC, 0, HgTlEIPAcVpesdxuHAohUBSLbkRC.Length);
				Array.Clear(jzpVEtuClUvVjBdDtjXvLsbzhOL, 0, jzpVEtuClUvVjBdDtjXvLsbzhOL.Length);
			}

			private string xtPTTEaBiKHldvKRyKuWbfwSXWZ()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{iRyNPwfaIbylCKBnafrigDzkSzy.ToString()}{VEJFfjfzOWEETlpJFhPbxPYsRtZ}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{iRyNPwfaIbylCKBnafrigDzkSzy.ToString()}{VEJFfjfzOWEETlpJFhPbxPYsRtZ}");
			}

			public static int CFEFaonWGdGHmSbxFpVUdBbnEVrf(LheKHkshSClbCEWydXHLtjZwBFH P_0, LheKHkshSClbCEWydXHLtjZwBFH P_1)
			{
				if (P_0.sVCXCYtCFTJlHfQcwXhLqojaMtg < P_1.sVCXCYtCFTJlHfQcwXhLqojaMtg)
				{
					return -1;
				}
				if (P_0.sVCXCYtCFTJlHfQcwXhLqojaMtg > P_1.sVCXCYtCFTJlHfQcwXhLqojaMtg)
				{
					return 1;
				}
				return 0;
			}

			public static int hvKqFsxqjJLqjzLgLcJXFSmRApL(LheKHkshSClbCEWydXHLtjZwBFH P_0, LheKHkshSClbCEWydXHLtjZwBFH P_1)
			{
				if (P_0.zDPnjZHaLRdBKekxEKYFrQRqwLO < P_1.zDPnjZHaLRdBKekxEKYFrQRqwLO)
				{
					return -1;
				}
				if (P_0.zDPnjZHaLRdBKekxEKYFrQRqwLO > P_1.zDPnjZHaLRdBKekxEKYFrQRqwLO)
				{
					return 1;
				}
				return 0;
			}
		}

		private class fShxzwqOAGEgUrfiWlQXhgrsPPX
		{
			public enum gJsRbqGvdvWejNYFiqbdNTMuOmn
			{
				JlcFwBXJAZQpAvmagfRVInsQEVib = 0,
				lkctGikYsLMhbYMEyImPMsrGWJw = 1
			}

			public class bQEDqubuXTnmWubThOeWblqnohsb
			{
				public int sjbjANsWQaKxKgfHgxDuZgoAatr;

				public long? EntwWxrzZPllKPrcjuNCcHXVawy;

				public string khvGMpkRQjhHiSkBkeSsdqkvyhn;

				public int kPTxDqHUNQFlgCKgmbPPsQsvVsL;

				public int qrXpdbCUzFLCBfjCDTfPHyJCus;

				public int rGEuFEtJcMmFaLOCcsmbRHUjSpy;

				public bQEDqubuXTnmWubThOeWblqnohsb(int rewiredId, long? systemId, string systemControllerName, int lastInputManagerId, int buttonCount, int axisCount)
				{
					sjbjANsWQaKxKgfHgxDuZgoAatr = rewiredId;
					EntwWxrzZPllKPrcjuNCcHXVawy = systemId;
					khvGMpkRQjhHiSkBkeSsdqkvyhn = systemControllerName;
					kPTxDqHUNQFlgCKgmbPPsQsvVsL = lastInputManagerId;
					qrXpdbCUzFLCBfjCDTfPHyJCus = buttonCount;
					rGEuFEtJcMmFaLOCcsmbRHUjSpy = axisCount;
				}

				public bool kGUAgzoWmpBJnomvNrYAMpbELMU(LheKHkshSClbCEWydXHLtjZwBFH P_0, gJsRbqGvdvWejNYFiqbdNTMuOmn P_1)
				{
					if (P_0.rewiredId == sjbjANsWQaKxKgfHgxDuZgoAatr)
					{
						return true;
					}
					if (P_0.hardwareButtonCount != qrXpdbCUzFLCBfjCDTfPHyJCus)
					{
						return false;
					}
					if (P_0.hardwareAxisCount != rGEuFEtJcMmFaLOCcsmbRHUjSpy)
					{
						return false;
					}
					switch (P_1)
					{
					case gJsRbqGvdvWejNYFiqbdNTMuOmn.JlcFwBXJAZQpAvmagfRVInsQEVib:
						if (EntwWxrzZPllKPrcjuNCcHXVawy == P_0.systemId)
						{
							return khvGMpkRQjhHiSkBkeSsdqkvyhn == P_0.VEJFfjfzOWEETlpJFhPbxPYsRtZ;
						}
						return false;
					case gJsRbqGvdvWejNYFiqbdNTMuOmn.lkctGikYsLMhbYMEyImPMsrGWJw:
						return khvGMpkRQjhHiSkBkeSsdqkvyhn == P_0.VEJFfjfzOWEETlpJFhPbxPYsRtZ;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class mGYekDExXYuetotljbIuaknfmmAg : IDisposable, IEnumerator, IEnumerable, IEnumerable<bQEDqubuXTnmWubThOeWblqnohsb>, IEnumerator<bQEDqubuXTnmWubThOeWblqnohsb>
			{
				private bQEDqubuXTnmWubThOeWblqnohsb WCNlIsEdYuVTqbNYvICUPcTebLU;

				private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

				private int dFCUHNznYmJZjnnffQJUVAprSDy;

				public fShxzwqOAGEgUrfiWlQXhgrsPPX GxphHAMqMhNBLjnlhXuBQmXaALiE;

				public LheKHkshSClbCEWydXHLtjZwBFH gHvYZHUarOaorfxsTfLYBukkoDdr;

				public LheKHkshSClbCEWydXHLtjZwBFH UbjxuEellXeMyafFoPliUyZkaWij;

				public gJsRbqGvdvWejNYFiqbdNTMuOmn NDuIiQmBXOqfkYsxTjDpIDbLijzg;

				public gJsRbqGvdvWejNYFiqbdNTMuOmn bHlBJlWzmhLdKSVRZFPkQzpzAEJ;

				public int EUAHsHUFMUtuEXeKfqlzycfQbCn;

				public int oBOFhxdKvEEGhfOjCxobcSPpBKcK;

				bQEDqubuXTnmWubThOeWblqnohsb IEnumerator<bQEDqubuXTnmWubThOeWblqnohsb>.Current
				{
					[DebuggerHidden]
					get
					{
						return WCNlIsEdYuVTqbNYvICUPcTebLU;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return WCNlIsEdYuVTqbNYvICUPcTebLU;
					}
				}

				[DebuggerHidden]
				IEnumerator<bQEDqubuXTnmWubThOeWblqnohsb> IEnumerable<bQEDqubuXTnmWubThOeWblqnohsb>.GetEnumerator()
				{
					mGYekDExXYuetotljbIuaknfmmAg mGYekDExXYuetotljbIuaknfmmAg2;
					if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
						mGYekDExXYuetotljbIuaknfmmAg2 = this;
					}
					else
					{
						mGYekDExXYuetotljbIuaknfmmAg2 = new mGYekDExXYuetotljbIuaknfmmAg(0);
						mGYekDExXYuetotljbIuaknfmmAg2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
					}
					mGYekDExXYuetotljbIuaknfmmAg2.gHvYZHUarOaorfxsTfLYBukkoDdr = UbjxuEellXeMyafFoPliUyZkaWij;
					mGYekDExXYuetotljbIuaknfmmAg2.NDuIiQmBXOqfkYsxTjDpIDbLijzg = bHlBJlWzmhLdKSVRZFPkQzpzAEJ;
					return mGYekDExXYuetotljbIuaknfmmAg2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<bQEDqubuXTnmWubThOeWblqnohsb>)this).GetEnumerator();
				}

				private bool MoveNext()
				{
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						EUAHsHUFMUtuEXeKfqlzycfQbCn = GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
						oBOFhxdKvEEGhfOjCxobcSPpBKcK = 0;
						goto IL_00a3;
					case 1:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
							goto IL_0095;
						}
						IL_00a3:
						if (oBOFhxdKvEEGhfOjCxobcSPpBKcK >= EUAHsHUFMUtuEXeKfqlzycfQbCn)
						{
							break;
						}
						if (GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv[oBOFhxdKvEEGhfOjCxobcSPpBKcK].kGUAgzoWmpBJnomvNrYAMpbELMU(gHvYZHUarOaorfxsTfLYBukkoDdr, NDuIiQmBXOqfkYsxTjDpIDbLijzg))
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = GxphHAMqMhNBLjnlhXuBQmXaALiE.DBNLceLJjOSJnIoFWvBsUwReOrv[oBOFhxdKvEEGhfOjCxobcSPpBKcK];
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							return true;
						}
						goto IL_0095;
						IL_0095:
						oBOFhxdKvEEGhfOjCxobcSPpBKcK++;
						goto IL_00a3;
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

				void IDisposable.Dispose()
				{
				}

				[DebuggerHidden]
				public mGYekDExXYuetotljbIuaknfmmAg(int _003C_003E1__state)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
					dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
				}
			}

			private List<bQEDqubuXTnmWubThOeWblqnohsb> DBNLceLJjOSJnIoFWvBsUwReOrv;

			public int Count => DBNLceLJjOSJnIoFWvBsUwReOrv.Count;

			public fShxzwqOAGEgUrfiWlQXhgrsPPX()
			{
				DBNLceLJjOSJnIoFWvBsUwReOrv = new List<bQEDqubuXTnmWubThOeWblqnohsb>();
			}

			public void TXPDIkiKZyOgtxZjjNIOUuEOnmW(LheKHkshSClbCEWydXHLtjZwBFH P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
				for (int i = 0; i < count; i++)
				{
					if (DBNLceLJjOSJnIoFWvBsUwReOrv[i].kGUAgzoWmpBJnomvNrYAMpbELMU(P_0, gJsRbqGvdvWejNYFiqbdNTMuOmn.JlcFwBXJAZQpAvmagfRVInsQEVib))
					{
						DBNLceLJjOSJnIoFWvBsUwReOrv[i].sjbjANsWQaKxKgfHgxDuZgoAatr = P_0.rewiredId;
						DBNLceLJjOSJnIoFWvBsUwReOrv[i].EntwWxrzZPllKPrcjuNCcHXVawy = P_0.systemId;
						DBNLceLJjOSJnIoFWvBsUwReOrv[i].khvGMpkRQjhHiSkBkeSsdqkvyhn = P_0.VEJFfjfzOWEETlpJFhPbxPYsRtZ;
						DBNLceLJjOSJnIoFWvBsUwReOrv[i].kPTxDqHUNQFlgCKgmbPPsQsvVsL = P_0.inputManagerId;
						DBNLceLJjOSJnIoFWvBsUwReOrv[i].qrXpdbCUzFLCBfjCDTfPHyJCus = P_0.hardwareButtonCount;
						DBNLceLJjOSJnIoFWvBsUwReOrv[i].rGEuFEtJcMmFaLOCcsmbRHUjSpy = P_0.hardwareAxisCount;
						fgJODZEmUJbPsdCEyOZvWvEmnPm(P_0.rewiredId, i);
						return;
					}
				}
				DBNLceLJjOSJnIoFWvBsUwReOrv.Add(new bQEDqubuXTnmWubThOeWblqnohsb(P_0.rewiredId, P_0.systemId, P_0.VEJFfjfzOWEETlpJFhPbxPYsRtZ, P_0.inputManagerId, P_0.hardwareButtonCount, P_0.hardwareAxisCount));
				fgJODZEmUJbPsdCEyOZvWvEmnPm(P_0.rewiredId, DBNLceLJjOSJnIoFWvBsUwReOrv.Count - 1);
			}

			public bool qUMsmxJoDabnMgpnPbuRnplJapZC(LheKHkshSClbCEWydXHLtjZwBFH P_0, gJsRbqGvdvWejNYFiqbdNTMuOmn P_1)
			{
				int count = DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
				for (int i = 0; i < count; i++)
				{
					if (DBNLceLJjOSJnIoFWvBsUwReOrv[i].kGUAgzoWmpBJnomvNrYAMpbELMU(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			public IEnumerable<bQEDqubuXTnmWubThOeWblqnohsb> SHNHDnJvrVJkCMTxccwUvluFGxE(LheKHkshSClbCEWydXHLtjZwBFH P_0, gJsRbqGvdvWejNYFiqbdNTMuOmn P_1)
			{
				mGYekDExXYuetotljbIuaknfmmAg mGYekDExXYuetotljbIuaknfmmAg2 = new mGYekDExXYuetotljbIuaknfmmAg(-2);
				mGYekDExXYuetotljbIuaknfmmAg2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
				mGYekDExXYuetotljbIuaknfmmAg2.UbjxuEellXeMyafFoPliUyZkaWij = P_0;
				mGYekDExXYuetotljbIuaknfmmAg2.bHlBJlWzmhLdKSVRZFPkQzpzAEJ = P_1;
				return mGYekDExXYuetotljbIuaknfmmAg2;
			}

			public int iFNXApJjlWtDZdwedJFKpfGAMok(bQEDqubuXTnmWubThOeWblqnohsb P_0)
			{
				int count = DBNLceLJjOSJnIoFWvBsUwReOrv.Count;
				for (int i = 0; i < count; i++)
				{
					if (DBNLceLJjOSJnIoFWvBsUwReOrv[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void fgJODZEmUJbPsdCEyOZvWvEmnPm(int P_0, int P_1)
			{
				for (int num = DBNLceLJjOSJnIoFWvBsUwReOrv.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && DBNLceLJjOSJnIoFWvBsUwReOrv[num].sjbjANsWQaKxKgfHgxDuZgoAatr == P_0)
					{
						DBNLceLJjOSJnIoFWvBsUwReOrv.RemoveAt(num);
					}
				}
			}
		}

		private List<LheKHkshSClbCEWydXHLtjZwBFH> kjwFdZmRbOPrZUBwYofYzTFLQnc;

		private int PntfPQsEGteZvXgyoThapnrOHwd;

		private fShxzwqOAGEgUrfiWlQXhgrsPPX zDjgwsHxmQpJhkRGMsAWvoTTUnrS;

		private UpdateLoopType TShjztsSqTidVVARtigrVGyvDKuC;

		private Action<int, ControllerDataUpdater> oUTSfLSyrhEhRjXHwJZwIeaqWEL;

		private PlatformInputManager ukvfaICvkVuAVKulQnApsyLNAjRD;

		private CustomInputSource xRpNKtzGEPLTrbhkANDVbgqmfgA;

		private bool vjxAyPbSJhAqNfkvQzrguHPZorgB;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> BtXgoZzfyixretGRKXdmAjlGRaR;

		private Func<int> CSyUdeDrhSRituolFvOGscMBBFl;

		[CustomObfuscation(rename = false)]
		public override int deviceCount => PntfPQsEGteZvXgyoThapnrOHwd;

		[CustomObfuscation(rename = false)]
		public override PlatformInputManager primaryInputManager => ukvfaICvkVuAVKulQnApsyLNAjRD;

		[CustomObfuscation(rename = false)]
		public override IInputSource inputSource => null;

		[CustomObfuscation(rename = false)]
		public override InputSource inputSourceType => xRpNKtzGEPLTrbhkANDVbgqmfgA.inputSource;

		public CustomInputManager(CustomInputSource customInputSource, UpdateLoopSetting updateLoopSetting, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> getHardwareJoystickMap_InputManager, Func<int> getNewJoystickId)
		{
			xRpNKtzGEPLTrbhkANDVbgqmfgA = customInputSource;
			BtXgoZzfyixretGRKXdmAjlGRaR = getHardwareJoystickMap_InputManager;
			CSyUdeDrhSRituolFvOGscMBBFl = getNewJoystickId;
			ukvfaICvkVuAVKulQnApsyLNAjRD = this;
			try
			{
				oUTSfLSyrhEhRjXHwJZwIeaqWEL = UpdateControllerData;
				customInputSource.JoystickConnectedEvent += SystemDeviceConnected;
				customInputSource.JoystickDisconnectedEvent += SystemDeviceDisconnected;
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
			zDjgwsHxmQpJhkRGMsAWvoTTUnrS = new fShxzwqOAGEgUrfiWlQXhgrsPPX();
			kjwFdZmRbOPrZUBwYofYzTFLQnc = new List<LheKHkshSClbCEWydXHLtjZwBFH>();
			vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			TShjztsSqTidVVARtigrVGyvDKuC = updateLoop;
			if (xRpNKtzGEPLTrbhkANDVbgqmfgA.isReady)
			{
				xRpNKtzGEPLTrbhkANDVbgqmfgA.Update();
				if (vjxAyPbSJhAqNfkvQzrguHPZorgB)
				{
					wfYVPLmhaoedujmiFqdMztEymuO();
				}
				XOMSRbIiPeAQLGFCfLGDNIijuZwC();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (xRpNKtzGEPLTrbhkANDVbgqmfgA != null)
			{
				xRpNKtzGEPLTrbhkANDVbgqmfgA.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return oUTSfLSyrhEhRjXHwJZwIeaqWEL;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < PntfPQsEGteZvXgyoThapnrOHwd; i++)
			{
				if (kjwFdZmRbOPrZUBwYofYzTFLQnc[i].inputManagerId == inputManagerId)
				{
					kjwFdZmRbOPrZUBwYofYzTFLQnc[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			vjxAyPbSJhAqNfkvQzrguHPZorgB = true;
			if (_SystemDeviceDisconnectedEvent != null)
			{
				_SystemDeviceDisconnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SetUnityJoystickId(int joystickId, int unityJoystickIndex)
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

		private void yAvsVgTTGDItlDdMcthFKeWXlDf(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<LheKHkshSClbCEWydXHLtjZwBFH> list = kjwFdZmRbOPrZUBwYofYzTFLQnc;
			int pntfPQsEGteZvXgyoThapnrOHwd = PntfPQsEGteZvXgyoThapnrOHwd;
			kjwFdZmRbOPrZUBwYofYzTFLQnc = new List<LheKHkshSClbCEWydXHLtjZwBFH>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					LheKHkshSClbCEWydXHLtjZwBFH item = new LheKHkshSClbCEWydXHLtjZwBFH(xRpNKtzGEPLTrbhkANDVbgqmfgA, P_0[i].systemId, P_0[i].unityId, P_0[i], xRpNKtzGEPLTrbhkANDVbgqmfgA.inputSource, P_0[i].extension, BtXgoZzfyixretGRKXdmAjlGRaR);
					kjwFdZmRbOPrZUBwYofYzTFLQnc.Add(item);
					num++;
				}
			}
			PntfPQsEGteZvXgyoThapnrOHwd = num;
			uayRUeBwFfgScjCqOBsLgfFLjQBi(pntfPQsEGteZvXgyoThapnrOHwd, num, list, kjwFdZmRbOPrZUBwYofYzTFLQnc);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(kjwFdZmRbOPrZUBwYofYzTFLQnc[j]));
				}
			}
			dvtoafoBVFcqUHDKsKmzitILBloS(list, kjwFdZmRbOPrZUBwYofYzTFLQnc, false);
			dvtoafoBVFcqUHDKsKmzitILBloS(kjwFdZmRbOPrZUBwYofYzTFLQnc, list, true);
		}

		private void XOMSRbIiPeAQLGFCfLGDNIijuZwC()
		{
			for (int i = 0; i < PntfPQsEGteZvXgyoThapnrOHwd; i++)
			{
				kjwFdZmRbOPrZUBwYofYzTFLQnc[i].Update();
			}
		}

		private void uayRUeBwFfgScjCqOBsLgfFLjQBi(int P_0, int P_1, List<LheKHkshSClbCEWydXHLtjZwBFH> P_2, List<LheKHkshSClbCEWydXHLtjZwBFH> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(LheKHkshSClbCEWydXHLtjZwBFH.hvKqFsxqjJLqjzLgLcJXFSmRApL);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				uvyHsbansrbOEFMvTGIzNDuVqFhl(P_1, P_3, P_0, P_2, fShxzwqOAGEgUrfiWlQXhgrsPPX.gJsRbqGvdvWejNYFiqbdNTMuOmn.JlcFwBXJAZQpAvmagfRVInsQEVib);
				if (xRpNKtzGEPLTrbhkANDVbgqmfgA.useApproximateMatching)
				{
					uvyHsbansrbOEFMvTGIzNDuVqFhl(P_1, P_3, P_0, P_2, fShxzwqOAGEgUrfiWlQXhgrsPPX.gJsRbqGvdvWejNYFiqbdNTMuOmn.lkctGikYsLMhbYMEyImPMsrGWJw);
				}
			}
			wPaQeUOLsWCfDaRkoDbzlEsIIQc(P_1, P_3, fShxzwqOAGEgUrfiWlQXhgrsPPX.gJsRbqGvdvWejNYFiqbdNTMuOmn.JlcFwBXJAZQpAvmagfRVInsQEVib);
			if (xRpNKtzGEPLTrbhkANDVbgqmfgA.useApproximateMatching)
			{
				wPaQeUOLsWCfDaRkoDbzlEsIIQc(P_1, P_3, fShxzwqOAGEgUrfiWlQXhgrsPPX.gJsRbqGvdvWejNYFiqbdNTMuOmn.lkctGikYsLMhbYMEyImPMsrGWJw);
			}
			for (int i = 0; i < P_1; i++)
			{
				LheKHkshSClbCEWydXHLtjZwBFH lheKHkshSClbCEWydXHLtjZwBFH = P_3[i];
				if (lheKHkshSClbCEWydXHLtjZwBFH != null && lheKHkshSClbCEWydXHLtjZwBFH.inputManagerId < 0)
				{
					lheKHkshSClbCEWydXHLtjZwBFH.inputManagerId = XsOsVyBtTACNZvhKSCqKhJNcObX(P_3);
					lheKHkshSClbCEWydXHLtjZwBFH.rewiredId = ReInput.GetNewJoystickId();
					zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(lheKHkshSClbCEWydXHLtjZwBFH);
				}
			}
			P_3.Sort(LheKHkshSClbCEWydXHLtjZwBFH.CFEFaonWGdGHmSbxFpVUdBbnEVrf);
		}

		private void ZYHxGNylvgpiiDGzmFDnBqagypH(List<LheKHkshSClbCEWydXHLtjZwBFH> P_0, int P_1, int P_2)
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

		private bool BHoDIxSSroZRExzlHLxMWTglSdB(List<LheKHkshSClbCEWydXHLtjZwBFH> P_0, int P_1)
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

		private int XsOsVyBtTACNZvhKSCqKhJNcObX(List<LheKHkshSClbCEWydXHLtjZwBFH> P_0)
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

		private bool TDbfjHTAtTEdVDROIPjYUelzQmc(List<LheKHkshSClbCEWydXHLtjZwBFH> P_0, int P_1)
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

		private void uvyHsbansrbOEFMvTGIzNDuVqFhl(int P_0, List<LheKHkshSClbCEWydXHLtjZwBFH> P_1, int P_2, List<LheKHkshSClbCEWydXHLtjZwBFH> P_3, fShxzwqOAGEgUrfiWlQXhgrsPPX.gJsRbqGvdvWejNYFiqbdNTMuOmn P_4)
		{
			int num = ((P_4 != fShxzwqOAGEgUrfiWlQXhgrsPPX.gJsRbqGvdvWejNYFiqbdNTMuOmn.JlcFwBXJAZQpAvmagfRVInsQEVib) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				LheKHkshSClbCEWydXHLtjZwBFH lheKHkshSClbCEWydXHLtjZwBFH = P_1[i];
				if (lheKHkshSClbCEWydXHLtjZwBFH == null || lheKHkshSClbCEWydXHLtjZwBFH.inputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					LheKHkshSClbCEWydXHLtjZwBFH lheKHkshSClbCEWydXHLtjZwBFH2 = P_3[j];
					if (lheKHkshSClbCEWydXHLtjZwBFH2 != null && !TDbfjHTAtTEdVDROIPjYUelzQmc(P_1, lheKHkshSClbCEWydXHLtjZwBFH2.rewiredId) && lheKHkshSClbCEWydXHLtjZwBFH.kGUAgzoWmpBJnomvNrYAMpbELMU(lheKHkshSClbCEWydXHLtjZwBFH2) >= num)
					{
						lheKHkshSClbCEWydXHLtjZwBFH.inputManagerId = lheKHkshSClbCEWydXHLtjZwBFH2.inputManagerId;
						lheKHkshSClbCEWydXHLtjZwBFH.rewiredId = lheKHkshSClbCEWydXHLtjZwBFH2.rewiredId;
						zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(lheKHkshSClbCEWydXHLtjZwBFH);
					}
				}
			}
		}

		private void wPaQeUOLsWCfDaRkoDbzlEsIIQc(int P_0, List<LheKHkshSClbCEWydXHLtjZwBFH> P_1, fShxzwqOAGEgUrfiWlQXhgrsPPX.gJsRbqGvdvWejNYFiqbdNTMuOmn P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				LheKHkshSClbCEWydXHLtjZwBFH lheKHkshSClbCEWydXHLtjZwBFH = P_1[i];
				if (lheKHkshSClbCEWydXHLtjZwBFH == null || lheKHkshSClbCEWydXHLtjZwBFH.inputManagerId >= 0)
				{
					continue;
				}
				fShxzwqOAGEgUrfiWlQXhgrsPPX.bQEDqubuXTnmWubThOeWblqnohsb bQEDqubuXTnmWubThOeWblqnohsb = null;
				foreach (fShxzwqOAGEgUrfiWlQXhgrsPPX.bQEDqubuXTnmWubThOeWblqnohsb item in zDjgwsHxmQpJhkRGMsAWvoTTUnrS.SHNHDnJvrVJkCMTxccwUvluFGxE(lheKHkshSClbCEWydXHLtjZwBFH, P_2))
				{
					if (!TDbfjHTAtTEdVDROIPjYUelzQmc(P_1, item.sjbjANsWQaKxKgfHgxDuZgoAatr) && item.kPTxDqHUNQFlgCKgmbPPsQsvVsL >= 0)
					{
						bQEDqubuXTnmWubThOeWblqnohsb = item;
						break;
					}
				}
				if (bQEDqubuXTnmWubThOeWblqnohsb != null)
				{
					int num = bQEDqubuXTnmWubThOeWblqnohsb.kPTxDqHUNQFlgCKgmbPPsQsvVsL;
					if (!BHoDIxSSroZRExzlHLxMWTglSdB(P_1, num))
					{
						num = (bQEDqubuXTnmWubThOeWblqnohsb.kPTxDqHUNQFlgCKgmbPPsQsvVsL = XsOsVyBtTACNZvhKSCqKhJNcObX(P_1));
					}
					lheKHkshSClbCEWydXHLtjZwBFH.inputManagerId = num;
					lheKHkshSClbCEWydXHLtjZwBFH.rewiredId = bQEDqubuXTnmWubThOeWblqnohsb.sjbjANsWQaKxKgfHgxDuZgoAatr;
					zDjgwsHxmQpJhkRGMsAWvoTTUnrS.TXPDIkiKZyOgtxZjjNIOUuEOnmW(lheKHkshSClbCEWydXHLtjZwBFH);
				}
			}
		}

		private void wfYVPLmhaoedujmiFqdMztEymuO()
		{
			CustomInputSource.Joystick[] array = xRpNKtzGEPLTrbhkANDVbgqmfgA.SbTdVeFiGmCkZpwtbZusMxZHtY();
			if (RlkwRQpOLQQDoeMFZRsoshUnDQsD(array))
			{
				yAvsVgTTGDItlDdMcthFKeWXlDf(array);
			}
			vjxAyPbSJhAqNfkvQzrguHPZorgB = false;
		}

		private bool RlkwRQpOLQQDoeMFZRsoshUnDQsD(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = kjwFdZmRbOPrZUBwYofYzTFLQnc.Count;
			if (num != count)
			{
				return true;
			}
			for (int i = 0; i < num; i++)
			{
				if (P_0[i] == null)
				{
					continue;
				}
				long? systemId = P_0[i].systemId;
				bool flag = false;
				for (int j = 0; j < count; j++)
				{
					if (kjwFdZmRbOPrZUBwYofYzTFLQnc[j] != null && systemId == kjwFdZmRbOPrZUBwYofYzTFLQnc[j].systemId)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return true;
				}
			}
			for (int k = 0; k < count; k++)
			{
				if (kjwFdZmRbOPrZUBwYofYzTFLQnc[k] == null)
				{
					continue;
				}
				long? systemId2 = kjwFdZmRbOPrZUBwYofYzTFLQnc[k].systemId;
				bool flag2 = false;
				for (int l = 0; l < num; l++)
				{
					if (P_0[l] != null && systemId2 == P_0[l].systemId)
					{
						flag2 = true;
						break;
					}
				}
				if (!flag2)
				{
					return true;
				}
			}
			return false;
		}

		private void dvtoafoBVFcqUHDKsKmzitILBloS(List<LheKHkshSClbCEWydXHLtjZwBFH> P_0, List<LheKHkshSClbCEWydXHLtjZwBFH> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				LheKHkshSClbCEWydXHLtjZwBFH lheKHkshSClbCEWydXHLtjZwBFH = P_0[i];
				if (lheKHkshSClbCEWydXHLtjZwBFH == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						LheKHkshSClbCEWydXHLtjZwBFH lheKHkshSClbCEWydXHLtjZwBFH2 = P_1[j];
						if (lheKHkshSClbCEWydXHLtjZwBFH2 != null && lheKHkshSClbCEWydXHLtjZwBFH.rewiredId == lheKHkshSClbCEWydXHLtjZwBFH2.rewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					FyZjHIebzTuXOypeVTeqTYZyKta(P_0[i], P_2);
				}
			}
		}

		private void FyZjHIebzTuXOypeVTeqTYZyKta(LheKHkshSClbCEWydXHLtjZwBFH P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.htdHIzalDiucJbnRddXwJvCFuAb();
			}
			ouqbAwAQVKUHKHkVArjZLUvWSTNi(P_0, P_1);
		}

		private void ouqbAwAQVKUHKHkVArjZLUvWSTNi(LheKHkshSClbCEWydXHLtjZwBFH P_0, bool P_1)
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
}
