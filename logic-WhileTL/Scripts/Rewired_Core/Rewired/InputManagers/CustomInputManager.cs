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
		private class PGUxszrjKaIkSdjSOQUXhZtPeFVDb : IInputManagerJoystick, IInputManagerJoystickPublic
		{
			private readonly InputSource ieYluIwipVjyjzLjHAiijAxmNxsP;

			private readonly CustomInputSource fXBAjThahtZWUQWozYGDCBaeIgWMA;

			private readonly Controller.Extension twcsiuijVoCQoRBtCRDysXzVVTPD;

			private int jnTUNQIkgqcKCiEAwbMZLHIeGqRG;

			private int wyitjeizprUCYMqORpWhWzygUUjQ;

			private long? ruhDRnGUVdyexXxflaZPBlXwuqYl;

			private int kQhTCblAYSuvmyinRJJGwAKFBIfj;

			public Guid nOQoHZoiWPrSFIsmqagvEKvWBGDT;

			public string rHgEaSFzgHSoWwepyKWYxPExLsjvA;

			public string TRzLAFiYrqHcyEjZeQAnRWScznBf;

			private int jhazYdoXweuxJmcAJnlflvXbFGyT;

			private int yrHZhNoSpLMEzcgptuOphbaHHcuiA;

			private float[] rODUhFvDvuNqUagvIByzDzydddPVA;

			private bool[] JspBooWrPbsrHYagyhvvwXCFhuHz;

			private HardwareJoystickMap_InputManager jnGTQDFeNsixRwgRJcghDqCbQWSP;

			public CustomInputSource.Joystick GADAbmuGDurTUidNDbdzhlWRqZafb;

			private bool pfESQMflewZfzKfYXhoSMGpQFgFkA;

			private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> PbxKItkpDEopHKcLvkuqqKvGveJM;

			public int KhjwbdgYSYxylvAtecxIBSkYrjgD
			{
				get
				{
					if (GADAbmuGDurTUidNDbdzhlWRqZafb == null)
					{
						return 0;
					}
					return GADAbmuGDurTUidNDbdzhlWRqZafb.buttonCount;
				}
			}

			public int ZOKwwFcsWkTiJJjAiZAUzxSOgfuw
			{
				get
				{
					if (GADAbmuGDurTUidNDbdzhlWRqZafb == null)
					{
						return 0;
					}
					return GADAbmuGDurTUidNDbdzhlWRqZafb.axisCount;
				}
			}

			[CustomObfuscation(rename = false)]
			public int rewiredId
			{
				get
				{
					return jnTUNQIkgqcKCiEAwbMZLHIeGqRG;
				}
				set
				{
					jnTUNQIkgqcKCiEAwbMZLHIeGqRG = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public int inputManagerId
			{
				get
				{
					return wyitjeizprUCYMqORpWhWzygUUjQ;
				}
				set
				{
					wyitjeizprUCYMqORpWhWzygUUjQ = value;
				}
			}

			[CustomObfuscation(rename = false)]
			public string name
			{
				get
				{
					string text = ((!string.IsNullOrEmpty(GADAbmuGDurTUidNDbdzhlWRqZafb.customName)) ? GADAbmuGDurTUidNDbdzhlWRqZafb.customName : rHgEaSFzgHSoWwepyKWYxPExLsjvA);
					if (text == "Unknown Controller")
					{
						text = TRzLAFiYrqHcyEjZeQAnRWScznBf;
					}
					return text;
				}
			}

			[CustomObfuscation(rename = false)]
			public long? systemId => ruhDRnGUVdyexXxflaZPBlXwuqYl;

			[CustomObfuscation(rename = false)]
			public int unityId => kQhTCblAYSuvmyinRJJGwAKFBIfj;

			[CustomObfuscation(rename = false)]
			public Guid instanceGuid
			{
				get
				{
					if (!ruhDRnGUVdyexXxflaZPBlXwuqYl.HasValue)
					{
						return Guid.Empty;
					}
					return MiscTools.CreateGuidHashSHA1(name + "_" + ruhDRnGUVdyexXxflaZPBlXwuqYl);
				}
			}

			[CustomObfuscation(rename = false)]
			public Guid persistentGuid => instanceGuid;

			[CustomObfuscation(rename = false)]
			public Controller.Extension extension => twcsiuijVoCQoRBtCRDysXzVVTPD;

			[CustomObfuscation(rename = false)]
			public void SetVibration(float amount, int motorIndex)
			{
			}

			[CustomObfuscation(rename = false)]
			public void StopVibration()
			{
			}

			public PGUxszrjKaIkSdjSOQUXhZtPeFVDb(CustomInputSource P_0, long? P_1, int P_2, CustomInputSource.Joystick P_3, InputSource P_4, Controller.Extension P_5, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_6)
			{
				fXBAjThahtZWUQWozYGDCBaeIgWMA = P_0;
				ieYluIwipVjyjzLjHAiijAxmNxsP = P_4;
				ruhDRnGUVdyexXxflaZPBlXwuqYl = P_1;
				GADAbmuGDurTUidNDbdzhlWRqZafb = P_3;
				kQhTCblAYSuvmyinRJJGwAKFBIfj = P_2;
				twcsiuijVoCQoRBtCRDysXzVVTPD = P_5;
				PbxKItkpDEopHKcLvkuqqKvGveJM = P_6;
				wyitjeizprUCYMqORpWhWzygUUjQ = -1;
				jnTUNQIkgqcKCiEAwbMZLHIeGqRG = -1;
				jbHorPfUgCrtkMVLMOIulkOJUkxf();
				fyKHXiGInVfATQTtqFcElaiTdiLdA();
				nOQoHZoiWPrSFIsmqagvEKvWBGDT = jnGTQDFeNsixRwgRJcghDqCbQWSP.hardwareMapIdentifier.guid;
				rHgEaSFzgHSoWwepyKWYxPExLsjvA = jnGTQDFeNsixRwgRJcghDqCbQWSP.controllerName;
				rODUhFvDvuNqUagvIByzDzydddPVA = new float[jhazYdoXweuxJmcAJnlflvXbFGyT];
				JspBooWrPbsrHYagyhvvwXCFhuHz = new bool[yrHZhNoSpLMEzcgptuOphbaHHcuiA];
				Update();
			}

			public void jbHorPfUgCrtkMVLMOIulkOJUkxf()
			{
				TRzLAFiYrqHcyEjZeQAnRWScznBf = GADAbmuGDurTUidNDbdzhlWRqZafb.deviceName;
			}

			[CustomObfuscation(rename = false)]
			public void Update()
			{
				if (GADAbmuGDurTUidNDbdzhlWRqZafb.isConnected)
				{
					sMDjzCJDeBvhrbyByBjiYGZTdvid();
					NmpnNBiKKVbSAuwNMDZPPwvGzdji();
				}
			}

			public int eRcrgXtiJZnEILPhcaiUyTnAFTCn(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0)
			{
				if (P_0.TRzLAFiYrqHcyEjZeQAnRWScznBf == TRzLAFiYrqHcyEjZeQAnRWScznBf && P_0.ruhDRnGUVdyexXxflaZPBlXwuqYl == ruhDRnGUVdyexXxflaZPBlXwuqYl)
				{
					return 2;
				}
				if (P_0.TRzLAFiYrqHcyEjZeQAnRWScznBf == TRzLAFiYrqHcyEjZeQAnRWScznBf)
				{
					return 1;
				}
				return 0;
			}

			private void KonGcavNUOwjzblUmOrIFvgYlQaM(BridgedControllerHWInfo P_0)
			{
				P_0.inputManagerSource = ieYluIwipVjyjzLjHAiijAxmNxsP;
				P_0.inputSource = ieYluIwipVjyjzLjHAiijAxmNxsP;
				P_0.hardwareIdentifier = bCDcrddrcACOMFQMHyZkZRleWBKYA();
				P_0.hardwareAxisCount = jhazYdoXweuxJmcAJnlflvXbFGyT;
				P_0.hardwareButtonCount = yrHZhNoSpLMEzcgptuOphbaHHcuiA;
				P_0.hardwareHatCount = 0;
				P_0.hw_productName = TRzLAFiYrqHcyEjZeQAnRWScznBf;
				P_0.hw_supportsVibration = GADAbmuGDurTUidNDbdzhlWRqZafb.supportsVibration;
			}

			private void KonGcavNUOwjzblUmOrIFvgYlQaM(BridgedController P_0)
			{
				KonGcavNUOwjzblUmOrIFvgYlQaM((BridgedControllerHWInfo)P_0);
				P_0.sourceJoystick = this;
				P_0.gameHardwareMap = jnGTQDFeNsixRwgRJcghDqCbQWSP.ToGameHardwareControllerMap();
				P_0.instanceName = TRzLAFiYrqHcyEjZeQAnRWScznBf;
				P_0.productName = TRzLAFiYrqHcyEjZeQAnRWScznBf;
				P_0.isXInputDevice = false;
				P_0.axisCount = jhazYdoXweuxJmcAJnlflvXbFGyT;
				P_0.buttonCount = yrHZhNoSpLMEzcgptuOphbaHHcuiA;
				P_0.controllerTypeGuid = nOQoHZoiWPrSFIsmqagvEKvWBGDT;
				P_0.customInputSource = fXBAjThahtZWUQWozYGDCBaeIgWMA;
				P_0.controllerExtension = twcsiuijVoCQoRBtCRDysXzVVTPD;
			}

			[CustomObfuscation(rename = false)]
			public void FillData(ControllerDataUpdater dataUpdater)
			{
				if (jhazYdoXweuxJmcAJnlflvXbFGyT != dataUpdater.axisCount || yrHZhNoSpLMEzcgptuOphbaHHcuiA != dataUpdater.buttonCount)
				{
					throw new Exception("This controller signature does not match the data object!");
				}
				for (int i = 0; i < jhazYdoXweuxJmcAJnlflvXbFGyT; i++)
				{
					dataUpdater.axisValues[i] = rODUhFvDvuNqUagvIByzDzydddPVA[i];
				}
				for (int j = 0; j < yrHZhNoSpLMEzcgptuOphbaHHcuiA; j++)
				{
					dataUpdater.buttonValues[j] = JspBooWrPbsrHYagyhvvwXCFhuHz[j];
				}
				if (pfESQMflewZfzKfYXhoSMGpQFgFkA && !dataUpdater.hasReceivedInput)
				{
					dataUpdater.hasReceivedInput = true;
				}
			}

			public BridgedControllerHWInfo dRJFQxxbJtbamMAsWxKyOgWwHrhW()
			{
				BridgedControllerHWInfo bridgedControllerHWInfo = new BridgedControllerHWInfo();
				KonGcavNUOwjzblUmOrIFvgYlQaM(bridgedControllerHWInfo);
				return bridgedControllerHWInfo;
			}

			[CustomObfuscation(rename = false)]
			public BridgedController ToBridgedController()
			{
				BridgedController bridgedController = new BridgedController();
				KonGcavNUOwjzblUmOrIFvgYlQaM(bridgedController);
				return bridgedController;
			}

			[CustomObfuscation(rename = false)]
			public ControllerDisconnectedEventArgs ToControllerDisconnectedEventArgs()
			{
				return new ControllerDisconnectedEventArgs(jnTUNQIkgqcKCiEAwbMZLHIeGqRG);
			}

			private void sMDjzCJDeBvhrbyByBjiYGZTdvid()
			{
				HardwareJoystickMap.Platform_Custom.Axis[] axes = ((HardwareJoystickMap.Platform_Custom)jnGTQDFeNsixRwgRJcghDqCbQWSP.map).Axes;
				if (axes == null)
				{
					return;
				}
				for (int i = 0; i < axes.Length; i++)
				{
					if (axes[i] != null)
					{
						if (i >= jhazYdoXweuxJmcAJnlflvXbFGyT)
						{
							throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
						}
						rODUhFvDvuNqUagvIByzDzydddPVA[i] = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(axes[i]);
						if (!pfESQMflewZfzKfYXhoSMGpQFgFkA && rODUhFvDvuNqUagvIByzDzydddPVA[i] != 0f)
						{
							pfESQMflewZfzKfYXhoSMGpQFgFkA = true;
						}
					}
				}
			}

			private void NmpnNBiKKVbSAuwNMDZPPwvGzdji()
			{
				HardwareJoystickMap.Platform_Custom.Button[] buttons = ((HardwareJoystickMap.Platform_Custom)jnGTQDFeNsixRwgRJcghDqCbQWSP.map).Buttons;
				if (buttons == null)
				{
					return;
				}
				for (int i = 0; i < buttons.Length; i++)
				{
					if (i >= yrHZhNoSpLMEzcgptuOphbaHHcuiA)
					{
						throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
					}
					JspBooWrPbsrHYagyhvvwXCFhuHz[i] = QJBSSzPioDBMmqZkZEFzajPlEHwp(buttons[i]);
					if (!pfESQMflewZfzKfYXhoSMGpQFgFkA && JspBooWrPbsrHYagyhvvwXCFhuHz[i])
					{
						pfESQMflewZfzKfYXhoSMGpQFgFkA = true;
					}
				}
			}

			private bool QJBSSzPioDBMmqZkZEFzajPlEHwp(HardwareJoystickMap.Platform_Custom.Button P_0)
			{
				if (P_0.sourceType == 0)
				{
					return QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0.sourceButton);
				}
				if (P_0.sourceType == 1)
				{
					float num = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(P_0.sourceAxis);
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

			private bool hXBsbZHpUaIMKWjuSUkZhaLQekTj(float P_0, float P_1)
			{
				return MathTools.IsNear(P_1, P_0, 0.1f);
			}

			private float oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(HardwareJoystickMap.Platform_Custom.Axis P_0)
			{
				if (P_0.sourceType == 1)
				{
					return oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(P_0.sourceAxis);
				}
				if (P_0.sourceType == 0)
				{
					if (!QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0.sourceButton))
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

			private float oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(int P_0)
			{
				return GADAbmuGDurTUidNDbdzhlWRqZafb.GetAxisValue(P_0);
			}

			private bool QJBSSzPioDBMmqZkZEFzajPlEHwp(int P_0)
			{
				return GADAbmuGDurTUidNDbdzhlWRqZafb.GetButtonValue(P_0);
			}

			private void fyKHXiGInVfATQTtqFcElaiTdiLdA()
			{
				jnGTQDFeNsixRwgRJcghDqCbQWSP = PbxKItkpDEopHKcLvkuqqKvGveJM(dRJFQxxbJtbamMAsWxKyOgWwHrhW());
				if (jnGTQDFeNsixRwgRJcghDqCbQWSP == null)
				{
					Logger.LogError("Default hardware map not found!");
					return;
				}
				jhazYdoXweuxJmcAJnlflvXbFGyT = jnGTQDFeNsixRwgRJcghDqCbQWSP.axisCount;
				yrHZhNoSpLMEzcgptuOphbaHHcuiA = jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonCount;
			}

			private void ZbLJlCPrDufAoCXeGXMcwORfZBsBA()
			{
				Array.Clear(JspBooWrPbsrHYagyhvvwXCFhuHz, 0, JspBooWrPbsrHYagyhvvwXCFhuHz.Length);
				Array.Clear(rODUhFvDvuNqUagvIByzDzydddPVA, 0, rODUhFvDvuNqUagvIByzDzydddPVA.Length);
			}

			private string bCDcrddrcACOMFQMHyZkZRleWBKYA()
			{
				if (ReInput.currentPlatform == Platform.Webplayer)
				{
					return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ReInput.webplayerPlatform.ToString()}{ieYluIwipVjyjzLjHAiijAxmNxsP.ToString()}{TRzLAFiYrqHcyEjZeQAnRWScznBf}");
				}
				return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ieYluIwipVjyjzLjHAiijAxmNxsP.ToString()}{TRzLAFiYrqHcyEjZeQAnRWScznBf}");
			}

			public static int MOuKBWibvJbSJxUfatGKZFlrmTlW(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0, PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_1)
			{
				if (P_0.wyitjeizprUCYMqORpWhWzygUUjQ < P_1.wyitjeizprUCYMqORpWhWzygUUjQ)
				{
					return -1;
				}
				if (P_0.wyitjeizprUCYMqORpWhWzygUUjQ > P_1.wyitjeizprUCYMqORpWhWzygUUjQ)
				{
					return 1;
				}
				return 0;
			}

			public static int vuofIQgDSlhdCKBoaDUXEnwXBbBpA(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0, PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_1)
			{
				if (P_0.ruhDRnGUVdyexXxflaZPBlXwuqYl < P_1.ruhDRnGUVdyexXxflaZPBlXwuqYl)
				{
					return -1;
				}
				if (P_0.ruhDRnGUVdyexXxflaZPBlXwuqYl > P_1.ruhDRnGUVdyexXxflaZPBlXwuqYl)
				{
					return 1;
				}
				return 0;
			}
		}

		private class tXVtFHvxbmhPrKinpLaLLOmgZXXS
		{
			public enum IbysBjaqcnQOvEuKuNMcgqPXtFVf
			{
				Exact = 0,
				Approximate = 1
			}

			public class PkBFHgPRIzrSFZzDYSOfZgQXXsEC
			{
				public int wKTIDzdbnMqFnJlBBeomtbaWsxjR;

				public long? UEDsQXeYgzBobwVwWjzUMCJDSmip;

				public string oGNaWLprhBUnPveHBZCyLCclilfn;

				public int czjrOWhmqBwDdneXNALtIaxNwVzA;

				public int yrHZhNoSpLMEzcgptuOphbaHHcuiA;

				public int jhazYdoXweuxJmcAJnlflvXbFGyT;

				public PkBFHgPRIzrSFZzDYSOfZgQXXsEC(int P_0, long? P_1, string P_2, int P_3, int P_4, int P_5)
				{
					wKTIDzdbnMqFnJlBBeomtbaWsxjR = P_0;
					UEDsQXeYgzBobwVwWjzUMCJDSmip = P_1;
					oGNaWLprhBUnPveHBZCyLCclilfn = P_2;
					czjrOWhmqBwDdneXNALtIaxNwVzA = P_3;
					yrHZhNoSpLMEzcgptuOphbaHHcuiA = P_4;
					jhazYdoXweuxJmcAJnlflvXbFGyT = P_5;
				}

				public bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0, IbysBjaqcnQOvEuKuNMcgqPXtFVf P_1)
				{
					if (P_0.rewiredId == wKTIDzdbnMqFnJlBBeomtbaWsxjR)
					{
						return true;
					}
					if (P_0.KhjwbdgYSYxylvAtecxIBSkYrjgD != yrHZhNoSpLMEzcgptuOphbaHHcuiA)
					{
						return false;
					}
					if (P_0.ZOKwwFcsWkTiJJjAiZAUzxSOgfuw != jhazYdoXweuxJmcAJnlflvXbFGyT)
					{
						return false;
					}
					switch (P_1)
					{
					case IbysBjaqcnQOvEuKuNMcgqPXtFVf.Exact:
						if (UEDsQXeYgzBobwVwWjzUMCJDSmip == P_0.systemId)
						{
							return oGNaWLprhBUnPveHBZCyLCclilfn == P_0.TRzLAFiYrqHcyEjZeQAnRWScznBf;
						}
						return false;
					case IbysBjaqcnQOvEuKuNMcgqPXtFVf.Approximate:
						return oGNaWLprhBUnPveHBZCyLCclilfn == P_0.TRzLAFiYrqHcyEjZeQAnRWScznBf;
					default:
						throw new NotImplementedException();
					}
				}
			}

			private sealed class nhclcptaRQrIlpjUsyyWKNqNeQeS : IDisposable, IEnumerable, IEnumerator, IEnumerable<PkBFHgPRIzrSFZzDYSOfZgQXXsEC>, IEnumerator<PkBFHgPRIzrSFZzDYSOfZgQXXsEC>
			{
				private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

				private PkBFHgPRIzrSFZzDYSOfZgQXXsEC USjDTWbJtWhEBdYYYfLUglTcnnGrA;

				private int nOonfdwpqEUEASbbWObCvjhlCTmP;

				public tXVtFHvxbmhPrKinpLaLLOmgZXXS GZXxEqHwrHYIyUJtInpLwgTukJaY;

				private PGUxszrjKaIkSdjSOQUXhZtPeFVDb sgVxbuDAuevAQEggkQAcSuZkVnGc;

				public PGUxszrjKaIkSdjSOQUXhZtPeFVDb USZMaIxQjfLLMAXcFwImGLBkIAsG;

				private IbysBjaqcnQOvEuKuNMcgqPXtFVf NkWUjerweacIBvSdmEmpoCzRdbtX;

				public IbysBjaqcnQOvEuKuNMcgqPXtFVf pMHTdFHYEXVSjtXRwCWwwczjKiTJ;

				private int XoXSDiftyvAwyAXRnHGdMRIPCNdGA;

				private int eolRghqutZOOIGqvOFTzJOGfYTsn;

				PkBFHgPRIzrSFZzDYSOfZgQXXsEC IEnumerator<PkBFHgPRIzrSFZzDYSOfZgQXXsEC>.Current
				{
					[DebuggerHidden]
					get
					{
						return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
					}
				}

				object IEnumerator.Current
				{
					[DebuggerHidden]
					get
					{
						return USjDTWbJtWhEBdYYYfLUglTcnnGrA;
					}
				}

				[DebuggerHidden]
				public nhclcptaRQrIlpjUsyyWKNqNeQeS(int P_0)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = P_0;
					nOonfdwpqEUEASbbWObCvjhlCTmP = Thread.CurrentThread.ManagedThreadId;
				}

				[DebuggerHidden]
				void IDisposable.Dispose()
				{
				}

				private bool MoveNext()
				{
					int gwbUsvLqBorYvZEWvPDttSzVhFNo = GwbUsvLqBorYvZEWvPDttSzVhFNo;
					tXVtFHvxbmhPrKinpLaLLOmgZXXS gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 0)
					{
						if (gwbUsvLqBorYvZEWvPDttSzVhFNo != 1)
						{
							return false;
						}
						GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
						goto IL_0083;
					}
					GwbUsvLqBorYvZEWvPDttSzVhFNo = -1;
					XoXSDiftyvAwyAXRnHGdMRIPCNdGA = gZXxEqHwrHYIyUJtInpLwgTukJaY.LztWhAIbukRXonlavhcowoysBOjjA.Count;
					eolRghqutZOOIGqvOFTzJOGfYTsn = 0;
					goto IL_0093;
					IL_0083:
					eolRghqutZOOIGqvOFTzJOGfYTsn++;
					goto IL_0093;
					IL_0093:
					if (eolRghqutZOOIGqvOFTzJOGfYTsn < XoXSDiftyvAwyAXRnHGdMRIPCNdGA)
					{
						if (gZXxEqHwrHYIyUJtInpLwgTukJaY.LztWhAIbukRXonlavhcowoysBOjjA[eolRghqutZOOIGqvOFTzJOGfYTsn].eRcrgXtiJZnEILPhcaiUyTnAFTCn(sgVxbuDAuevAQEggkQAcSuZkVnGc, NkWUjerweacIBvSdmEmpoCzRdbtX))
						{
							USjDTWbJtWhEBdYYYfLUglTcnnGrA = gZXxEqHwrHYIyUJtInpLwgTukJaY.LztWhAIbukRXonlavhcowoysBOjjA[eolRghqutZOOIGqvOFTzJOGfYTsn];
							GwbUsvLqBorYvZEWvPDttSzVhFNo = 1;
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
				IEnumerator<PkBFHgPRIzrSFZzDYSOfZgQXXsEC> IEnumerable<PkBFHgPRIzrSFZzDYSOfZgQXXsEC>.GetEnumerator()
				{
					nhclcptaRQrIlpjUsyyWKNqNeQeS nhclcptaRQrIlpjUsyyWKNqNeQeS2;
					if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
					{
						GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
						nhclcptaRQrIlpjUsyyWKNqNeQeS2 = this;
					}
					else
					{
						nhclcptaRQrIlpjUsyyWKNqNeQeS2 = new nhclcptaRQrIlpjUsyyWKNqNeQeS(0);
						nhclcptaRQrIlpjUsyyWKNqNeQeS2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
					}
					nhclcptaRQrIlpjUsyyWKNqNeQeS2.sgVxbuDAuevAQEggkQAcSuZkVnGc = USZMaIxQjfLLMAXcFwImGLBkIAsG;
					nhclcptaRQrIlpjUsyyWKNqNeQeS2.NkWUjerweacIBvSdmEmpoCzRdbtX = pMHTdFHYEXVSjtXRwCWwwczjKiTJ;
					return nhclcptaRQrIlpjUsyyWKNqNeQeS2;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return ((IEnumerable<PkBFHgPRIzrSFZzDYSOfZgQXXsEC>)this).GetEnumerator();
				}
			}

			private List<PkBFHgPRIzrSFZzDYSOfZgQXXsEC> LztWhAIbukRXonlavhcowoysBOjjA;

			public int mueqHgIkLYeeWIkgOmnbTNFVJkWJ => LztWhAIbukRXonlavhcowoysBOjjA.Count;

			public tXVtFHvxbmhPrKinpLaLLOmgZXXS()
			{
				LztWhAIbukRXonlavhcowoysBOjjA = new List<PkBFHgPRIzrSFZzDYSOfZgQXXsEC>();
			}

			public void XwxmMWfpySNSMASbMCDIaCKEBrGP(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0)
			{
				if (P_0 == null)
				{
					return;
				}
				int count = LztWhAIbukRXonlavhcowoysBOjjA.Count;
				for (int i = 0; i < count; i++)
				{
					if (LztWhAIbukRXonlavhcowoysBOjjA[i].eRcrgXtiJZnEILPhcaiUyTnAFTCn(P_0, IbysBjaqcnQOvEuKuNMcgqPXtFVf.Exact))
					{
						LztWhAIbukRXonlavhcowoysBOjjA[i].wKTIDzdbnMqFnJlBBeomtbaWsxjR = P_0.rewiredId;
						LztWhAIbukRXonlavhcowoysBOjjA[i].UEDsQXeYgzBobwVwWjzUMCJDSmip = P_0.systemId;
						LztWhAIbukRXonlavhcowoysBOjjA[i].oGNaWLprhBUnPveHBZCyLCclilfn = P_0.TRzLAFiYrqHcyEjZeQAnRWScznBf;
						LztWhAIbukRXonlavhcowoysBOjjA[i].czjrOWhmqBwDdneXNALtIaxNwVzA = P_0.inputManagerId;
						LztWhAIbukRXonlavhcowoysBOjjA[i].yrHZhNoSpLMEzcgptuOphbaHHcuiA = P_0.KhjwbdgYSYxylvAtecxIBSkYrjgD;
						LztWhAIbukRXonlavhcowoysBOjjA[i].jhazYdoXweuxJmcAJnlflvXbFGyT = P_0.ZOKwwFcsWkTiJJjAiZAUzxSOgfuw;
						nPpArpXwftSAPCgODdQhbwKgoHcvA(P_0.rewiredId, i);
						return;
					}
				}
				LztWhAIbukRXonlavhcowoysBOjjA.Add(new PkBFHgPRIzrSFZzDYSOfZgQXXsEC(P_0.rewiredId, P_0.systemId, P_0.TRzLAFiYrqHcyEjZeQAnRWScznBf, P_0.inputManagerId, P_0.KhjwbdgYSYxylvAtecxIBSkYrjgD, P_0.ZOKwwFcsWkTiJJjAiZAUzxSOgfuw));
				nPpArpXwftSAPCgODdQhbwKgoHcvA(P_0.rewiredId, LztWhAIbukRXonlavhcowoysBOjjA.Count - 1);
			}

			public bool kUiCmZCewQfczGBdspnXBabLzrLy(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0, IbysBjaqcnQOvEuKuNMcgqPXtFVf P_1)
			{
				int count = LztWhAIbukRXonlavhcowoysBOjjA.Count;
				for (int i = 0; i < count; i++)
				{
					if (LztWhAIbukRXonlavhcowoysBOjjA[i].eRcrgXtiJZnEILPhcaiUyTnAFTCn(P_0, P_1))
					{
						return true;
					}
				}
				return false;
			}

			public IEnumerable<PkBFHgPRIzrSFZzDYSOfZgQXXsEC> EIllDHQFSlaxtdIhRTpOBXaXOnOQ(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0, IbysBjaqcnQOvEuKuNMcgqPXtFVf P_1)
			{
				return new nhclcptaRQrIlpjUsyyWKNqNeQeS(-2)
				{
					GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
					USZMaIxQjfLLMAXcFwImGLBkIAsG = P_0,
					pMHTdFHYEXVSjtXRwCWwwczjKiTJ = P_1
				};
			}

			public int oKnsZBCQtgEufGaLOKQQPSmAuaDB(PkBFHgPRIzrSFZzDYSOfZgQXXsEC P_0)
			{
				int count = LztWhAIbukRXonlavhcowoysBOjjA.Count;
				for (int i = 0; i < count; i++)
				{
					if (LztWhAIbukRXonlavhcowoysBOjjA[i] == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private void nPpArpXwftSAPCgODdQhbwKgoHcvA(int P_0, int P_1)
			{
				for (int num = LztWhAIbukRXonlavhcowoysBOjjA.Count - 1; num >= 0; num--)
				{
					if (num != P_1 && LztWhAIbukRXonlavhcowoysBOjjA[num].wKTIDzdbnMqFnJlBBeomtbaWsxjR == P_0)
					{
						LztWhAIbukRXonlavhcowoysBOjjA.RemoveAt(num);
					}
				}
			}
		}

		private List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> elKJbbxESyfcuzfcxFoUDTJZIhcJA;

		private int NcFhTqaznBUbORimVwWyLExKyNzx;

		private tXVtFHvxbmhPrKinpLaLLOmgZXXS boNSEKuFFoQzYuEJbTHAMBvFjgjG;

		private UpdateLoopType HvFDPHvQHhAdkasJMjRxfxqlAkaF;

		private Action<int, ControllerDataUpdater> aZjUoBTvFJqBWAfFXmCRkuewLIOx;

		private PlatformInputManager gfTEZguFOlDAmDChxHFfMUBZrqTl;

		private CustomInputSource fXBAjThahtZWUQWozYGDCBaeIgWMA;

		private bool vOBKVnebkBpKgLMbliSkdvNFpdei;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> PbxKItkpDEopHKcLvkuqqKvGveJM;

		private Func<int> UXKJcKCIAkFQAFXjwewUPGMLjJdmA;

		[CustomObfuscation(rename = false)]
		public override int deviceCount => NcFhTqaznBUbORimVwWyLExKyNzx;

		[CustomObfuscation(rename = false)]
		public override PlatformInputManager primaryInputManager => gfTEZguFOlDAmDChxHFfMUBZrqTl;

		[CustomObfuscation(rename = false)]
		public override IInputSource inputSource => null;

		[CustomObfuscation(rename = false)]
		public override InputSource inputSourceType => fXBAjThahtZWUQWozYGDCBaeIgWMA.ieYluIwipVjyjzLjHAiijAxmNxsP;

		public CustomInputManager(CustomInputSource P_0, UpdateLoopSetting P_1, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_2, Func<int> P_3)
		{
			fXBAjThahtZWUQWozYGDCBaeIgWMA = P_0;
			PbxKItkpDEopHKcLvkuqqKvGveJM = P_2;
			UXKJcKCIAkFQAFXjwewUPGMLjJdmA = P_3;
			gfTEZguFOlDAmDChxHFfMUBZrqTl = this;
			try
			{
				aZjUoBTvFJqBWAfFXmCRkuewLIOx = UpdateControllerData;
				P_0.HkgLSNgaikfVJMXFCOLwlYKoKjXn += SystemDeviceConnected;
				P_0.awbLkeOTVRZgLsHbnGFZWHDPJWeh += SystemDeviceDisconnected;
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
			boNSEKuFFoQzYuEJbTHAMBvFjgjG = new tXVtFHvxbmhPrKinpLaLLOmgZXXS();
			elKJbbxESyfcuzfcxFoUDTJZIhcJA = new List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb>();
			vOBKVnebkBpKgLMbliSkdvNFpdei = true;
		}

		[CustomObfuscation(rename = false)]
		public override void Update(UpdateLoopType updateLoop)
		{
			HvFDPHvQHhAdkasJMjRxfxqlAkaF = updateLoop;
			if (fXBAjThahtZWUQWozYGDCBaeIgWMA.isReady)
			{
				fXBAjThahtZWUQWozYGDCBaeIgWMA.Update();
				if (vOBKVnebkBpKgLMbliSkdvNFpdei)
				{
					alayrrvNCSZbAOTuonjpHkvoUumW();
				}
				DzgjBVFcaWDogqCKSBeRqdglJPai();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void OnDestroy()
		{
			if (fXBAjThahtZWUQWozYGDCBaeIgWMA != null)
			{
				fXBAjThahtZWUQWozYGDCBaeIgWMA.Dispose();
			}
		}

		[CustomObfuscation(rename = false)]
		public override Action<int, ControllerDataUpdater> GetInputDataUpdateDelegate()
		{
			return aZjUoBTvFJqBWAfFXmCRkuewLIOx;
		}

		[CustomObfuscation(rename = false)]
		public override void UpdateControllerData(int inputManagerId, ControllerDataUpdater data)
		{
			for (int i = 0; i < NcFhTqaznBUbORimVwWyLExKyNzx; i++)
			{
				if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].inputManagerId == inputManagerId)
				{
					elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].FillData(data);
					return;
				}
			}
			Logger.LogError("Invalid joystick Id " + inputManagerId + "!");
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceConnected()
		{
			vOBKVnebkBpKgLMbliSkdvNFpdei = true;
			if (_SystemDeviceConnectedEvent != null)
			{
				_SystemDeviceConnectedEvent();
			}
		}

		[CustomObfuscation(rename = false)]
		public override void SystemDeviceDisconnected()
		{
			vOBKVnebkBpKgLMbliSkdvNFpdei = true;
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

		private void arLxlEYGvjkvWuzMDsSNwJKRPbbl(CustomInputSource.Joystick[] P_0)
		{
			int num = 0;
			List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> list = elKJbbxESyfcuzfcxFoUDTJZIhcJA;
			int ncFhTqaznBUbORimVwWyLExKyNzx = NcFhTqaznBUbORimVwWyLExKyNzx;
			elKJbbxESyfcuzfcxFoUDTJZIhcJA = new List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb>();
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i] != null)
				{
					PGUxszrjKaIkSdjSOQUXhZtPeFVDb item = new PGUxszrjKaIkSdjSOQUXhZtPeFVDb(fXBAjThahtZWUQWozYGDCBaeIgWMA, P_0[i].systemId, P_0[i].unityId, P_0[i], fXBAjThahtZWUQWozYGDCBaeIgWMA.ieYluIwipVjyjzLjHAiijAxmNxsP, P_0[i].extension, PbxKItkpDEopHKcLvkuqqKvGveJM);
					elKJbbxESyfcuzfcxFoUDTJZIhcJA.Add(item);
					num++;
				}
			}
			NcFhTqaznBUbORimVwWyLExKyNzx = num;
			cqAGnKSmwNWnRODgdRfXOJTBoCZu(ncFhTqaznBUbORimVwWyLExKyNzx, num, list, elKJbbxESyfcuzfcxFoUDTJZIhcJA);
			for (int j = 0; j < num; j++)
			{
				if (_UpdateControllerInfoEvent != null)
				{
					_UpdateControllerInfoEvent(new UpdateControllerInfoEventArgs(elKJbbxESyfcuzfcxFoUDTJZIhcJA[j]));
				}
			}
			ndHGRVlfkxHhrsyODJjzLJITnfsX(list, elKJbbxESyfcuzfcxFoUDTJZIhcJA, false);
			ndHGRVlfkxHhrsyODJjzLJITnfsX(elKJbbxESyfcuzfcxFoUDTJZIhcJA, list, true);
		}

		private void DzgjBVFcaWDogqCKSBeRqdglJPai()
		{
			for (int i = 0; i < NcFhTqaznBUbORimVwWyLExKyNzx; i++)
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].Update();
			}
		}

		private void cqAGnKSmwNWnRODgdRfXOJTBoCZu(int P_0, int P_1, List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_2, List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_3)
		{
			if (P_1 > 0)
			{
				P_3.Sort(PGUxszrjKaIkSdjSOQUXhZtPeFVDb.vuofIQgDSlhdCKBoaDUXEnwXBbBpA);
			}
			if (P_0 > 0 && P_1 > 0)
			{
				uYUMbRdtPJBZfjrxwDzznOaHJQrI(P_1, P_3, P_0, P_2, tXVtFHvxbmhPrKinpLaLLOmgZXXS.IbysBjaqcnQOvEuKuNMcgqPXtFVf.Exact);
				if (fXBAjThahtZWUQWozYGDCBaeIgWMA.useApproximateMatching)
				{
					uYUMbRdtPJBZfjrxwDzznOaHJQrI(P_1, P_3, P_0, P_2, tXVtFHvxbmhPrKinpLaLLOmgZXXS.IbysBjaqcnQOvEuKuNMcgqPXtFVf.Approximate);
				}
			}
			qGASwmLKicpNuRMFZhYhTikWOtmL(P_1, P_3, tXVtFHvxbmhPrKinpLaLLOmgZXXS.IbysBjaqcnQOvEuKuNMcgqPXtFVf.Exact);
			if (fXBAjThahtZWUQWozYGDCBaeIgWMA.useApproximateMatching)
			{
				qGASwmLKicpNuRMFZhYhTikWOtmL(P_1, P_3, tXVtFHvxbmhPrKinpLaLLOmgZXXS.IbysBjaqcnQOvEuKuNMcgqPXtFVf.Approximate);
			}
			for (int i = 0; i < P_1; i++)
			{
				PGUxszrjKaIkSdjSOQUXhZtPeFVDb pGUxszrjKaIkSdjSOQUXhZtPeFVDb = P_3[i];
				if (pGUxszrjKaIkSdjSOQUXhZtPeFVDb != null && pGUxszrjKaIkSdjSOQUXhZtPeFVDb.inputManagerId < 0)
				{
					pGUxszrjKaIkSdjSOQUXhZtPeFVDb.inputManagerId = VdgvNWWcieHYaYPMzqzCHdZkirLp(P_3);
					pGUxszrjKaIkSdjSOQUXhZtPeFVDb.rewiredId = ReInput.GetNewJoystickId();
					boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(pGUxszrjKaIkSdjSOQUXhZtPeFVDb);
				}
			}
			P_3.Sort(PGUxszrjKaIkSdjSOQUXhZtPeFVDb.MOuKBWibvJbSJxUfatGKZFlrmTlW);
		}

		private void PXvhJlnAOWKmBwlhRDOltbukRfTW(List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_0, int P_1, int P_2)
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

		private bool RoQgGVBBIMEvxAlvsqmCkaytazLq(List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_0, int P_1)
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

		private int VdgvNWWcieHYaYPMzqzCHdZkirLp(List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_0)
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

		private bool XuZqBzKvCtCosuIEtcqGHmpxHywSA(List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_0, int P_1)
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

		private void uYUMbRdtPJBZfjrxwDzznOaHJQrI(int P_0, List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_1, int P_2, List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_3, tXVtFHvxbmhPrKinpLaLLOmgZXXS.IbysBjaqcnQOvEuKuNMcgqPXtFVf P_4)
		{
			int num = ((P_4 != tXVtFHvxbmhPrKinpLaLLOmgZXXS.IbysBjaqcnQOvEuKuNMcgqPXtFVf.Exact) ? 1 : 2);
			for (int i = 0; i < P_0; i++)
			{
				PGUxszrjKaIkSdjSOQUXhZtPeFVDb pGUxszrjKaIkSdjSOQUXhZtPeFVDb = P_1[i];
				if (pGUxszrjKaIkSdjSOQUXhZtPeFVDb == null || pGUxszrjKaIkSdjSOQUXhZtPeFVDb.inputManagerId >= 0)
				{
					continue;
				}
				for (int j = 0; j < P_2; j++)
				{
					PGUxszrjKaIkSdjSOQUXhZtPeFVDb pGUxszrjKaIkSdjSOQUXhZtPeFVDb2 = P_3[j];
					if (pGUxszrjKaIkSdjSOQUXhZtPeFVDb2 != null && !XuZqBzKvCtCosuIEtcqGHmpxHywSA(P_1, pGUxszrjKaIkSdjSOQUXhZtPeFVDb2.rewiredId) && pGUxszrjKaIkSdjSOQUXhZtPeFVDb.eRcrgXtiJZnEILPhcaiUyTnAFTCn(pGUxszrjKaIkSdjSOQUXhZtPeFVDb2) >= num)
					{
						pGUxszrjKaIkSdjSOQUXhZtPeFVDb.inputManagerId = pGUxszrjKaIkSdjSOQUXhZtPeFVDb2.inputManagerId;
						pGUxszrjKaIkSdjSOQUXhZtPeFVDb.rewiredId = pGUxszrjKaIkSdjSOQUXhZtPeFVDb2.rewiredId;
						boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(pGUxszrjKaIkSdjSOQUXhZtPeFVDb);
					}
				}
			}
		}

		private void qGASwmLKicpNuRMFZhYhTikWOtmL(int P_0, List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_1, tXVtFHvxbmhPrKinpLaLLOmgZXXS.IbysBjaqcnQOvEuKuNMcgqPXtFVf P_2)
		{
			for (int i = 0; i < P_0; i++)
			{
				PGUxszrjKaIkSdjSOQUXhZtPeFVDb pGUxszrjKaIkSdjSOQUXhZtPeFVDb = P_1[i];
				if (pGUxszrjKaIkSdjSOQUXhZtPeFVDb == null || pGUxszrjKaIkSdjSOQUXhZtPeFVDb.inputManagerId >= 0)
				{
					continue;
				}
				tXVtFHvxbmhPrKinpLaLLOmgZXXS.PkBFHgPRIzrSFZzDYSOfZgQXXsEC pkBFHgPRIzrSFZzDYSOfZgQXXsEC = null;
				foreach (tXVtFHvxbmhPrKinpLaLLOmgZXXS.PkBFHgPRIzrSFZzDYSOfZgQXXsEC item in boNSEKuFFoQzYuEJbTHAMBvFjgjG.EIllDHQFSlaxtdIhRTpOBXaXOnOQ(pGUxszrjKaIkSdjSOQUXhZtPeFVDb, P_2))
				{
					if (!XuZqBzKvCtCosuIEtcqGHmpxHywSA(P_1, item.wKTIDzdbnMqFnJlBBeomtbaWsxjR) && item.czjrOWhmqBwDdneXNALtIaxNwVzA >= 0)
					{
						pkBFHgPRIzrSFZzDYSOfZgQXXsEC = item;
						break;
					}
				}
				if (pkBFHgPRIzrSFZzDYSOfZgQXXsEC != null)
				{
					int num = pkBFHgPRIzrSFZzDYSOfZgQXXsEC.czjrOWhmqBwDdneXNALtIaxNwVzA;
					if (!RoQgGVBBIMEvxAlvsqmCkaytazLq(P_1, num))
					{
						num = (pkBFHgPRIzrSFZzDYSOfZgQXXsEC.czjrOWhmqBwDdneXNALtIaxNwVzA = VdgvNWWcieHYaYPMzqzCHdZkirLp(P_1));
					}
					pGUxszrjKaIkSdjSOQUXhZtPeFVDb.inputManagerId = num;
					pGUxszrjKaIkSdjSOQUXhZtPeFVDb.rewiredId = pkBFHgPRIzrSFZzDYSOfZgQXXsEC.wKTIDzdbnMqFnJlBBeomtbaWsxjR;
					boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(pGUxszrjKaIkSdjSOQUXhZtPeFVDb);
				}
			}
		}

		private void alayrrvNCSZbAOTuonjpHkvoUumW()
		{
			CustomInputSource.Joystick[] array = fXBAjThahtZWUQWozYGDCBaeIgWMA.UnZxRhjmPsfNFewaWfIuSCfLXlOVA();
			if (JCMhjgogkiAcRTHBcfVaOMUtSLyg(array))
			{
				arLxlEYGvjkvWuzMDsSNwJKRPbbl(array);
			}
			vOBKVnebkBpKgLMbliSkdvNFpdei = false;
		}

		private bool JCMhjgogkiAcRTHBcfVaOMUtSLyg(CustomInputSource.Joystick[] P_0)
		{
			int num = P_0.Length;
			int count = elKJbbxESyfcuzfcxFoUDTJZIhcJA.Count;
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
					if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[j] != null && systemId == elKJbbxESyfcuzfcxFoUDTJZIhcJA[j].systemId)
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
				if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[k] == null)
				{
					continue;
				}
				long? systemId2 = elKJbbxESyfcuzfcxFoUDTJZIhcJA[k].systemId;
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

		private void ndHGRVlfkxHhrsyODJjzLJITnfsX(List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_0, List<PGUxszrjKaIkSdjSOQUXhZtPeFVDb> P_1, bool P_2)
		{
			if (P_0 == null)
			{
				return;
			}
			int num = P_0?.Count ?? 0;
			int num2 = P_1?.Count ?? 0;
			for (int i = 0; i < num; i++)
			{
				PGUxszrjKaIkSdjSOQUXhZtPeFVDb pGUxszrjKaIkSdjSOQUXhZtPeFVDb = P_0[i];
				if (pGUxszrjKaIkSdjSOQUXhZtPeFVDb == null)
				{
					continue;
				}
				bool flag = false;
				if (P_1 != null)
				{
					for (int j = 0; j < num2; j++)
					{
						PGUxszrjKaIkSdjSOQUXhZtPeFVDb pGUxszrjKaIkSdjSOQUXhZtPeFVDb2 = P_1[j];
						if (pGUxszrjKaIkSdjSOQUXhZtPeFVDb2 != null && pGUxszrjKaIkSdjSOQUXhZtPeFVDb.rewiredId == pGUxszrjKaIkSdjSOQUXhZtPeFVDb2.rewiredId)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					TsntVxtlUhBxydDlwSYiTnYwbYkmA(P_0[i], P_2);
				}
			}
		}

		private void TsntVxtlUhBxydDlwSYiTnYwbYkmA(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0, bool P_1)
		{
			if (P_1)
			{
				P_0.jbHorPfUgCrtkMVLMOIulkOJUkxf();
			}
			mvOoSIBHcwImfFYDlkZNgApAXZXF(P_0, P_1);
		}

		private void mvOoSIBHcwImfFYDlkZNgApAXZXF(PGUxszrjKaIkSdjSOQUXhZtPeFVDb P_0, bool P_1)
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
