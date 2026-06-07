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
using Rewired.Utils;

internal class lwbDySfvDdBYvtcCsmSJyxKynhnkA : PlatformInputManager
{
	private class nlzbjZAvSssoBrApgKesFqzjEAomb : IInputManagerJoystick, IInputManagerJoystickPublic
	{
		private int jnTUNQIkgqcKCiEAwbMZLHIeGqRG;

		private int wyitjeizprUCYMqORpWhWzygUUjQ;

		public Guid nOQoHZoiWPrSFIsmqagvEKvWBGDT;

		public string dOGnZNaneIcyRDqppLkltFGQCCGS;

		public LjmiwQfcsmzrgAYaHEMKGLaOgKjY ncRBPRILXKISRDXTTSTeRKtkNzpTA;

		public dFGwIisbtfHayiNXiRBRWpMCngGv wJPUkuHTqymwMXfAhpTmRxulvPYC;

		public string nbKggyiWHSGiLRrSVVgtjzhItnkxA;

		public string gmqqHFPaRiTEZeJkDNWhtfnzrJWc;

		public int BKKOorJJLcGhpuCjWgkAccaWERACA;

		public int fSoHPUfJCksYThdbElmhKTIwCwuC;

		public Guid MylEsDRFVVMhBJcGlgRgFyDkQeeGA;

		public PidVid vlTmvRjRFWNOQgJwigVyGNNOHdJoA;

		public Guid aNminznnktfeQocLrbuweRfSqoPUA;

		public int MWTsUklfcAgeGMkkXeelyIScauFs;

		public int QSpGKgLcmMquAQaJHOvZChGmidDs;

		public int FgsfjAsbPvufPzyUsqZHIojbhTAk;

		public int ZOKwwFcsWkTiJJjAiZAUzxSOgfuw;

		public int KhjwbdgYSYxylvAtecxIBSkYrjgD;

		public int tExvLgldQmooUgcbIXdhChsHLlXN;

		public bool bfLhflgotMGznpKGludAuLlKnFsRA;

		public bool QgfiOqAqKFgNutFnAbZVtqhHbmPt;

		public int TvfyCOtyYKIlzJHUmJzZBRLesBkj;

		private float[] rODUhFvDvuNqUagvIByzDzydddPVA;

		private bool[] JspBooWrPbsrHYagyhvvwXCFhuHz;

		private HardwareJoystickMap_InputManager jnGTQDFeNsixRwgRJcghDqCbQWSP;

		private Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> PbxKItkpDEopHKcLvkuqqKvGveJM;

		private bool MTITHegngzqezjYeaLtznfvMAJKL;

		private bool pfESQMflewZfzKfYXhoSMGpQFgFkA;

		[CompilerGenerated]
		private Controller.Extension iPcZkmwJRmUSAfoquojmjvjiIcCf;

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
		public string name => dOGnZNaneIcyRDqppLkltFGQCCGS;

		[CustomObfuscation(rename = false)]
		public long? systemId
		{
			get
			{
				if (wyitjeizprUCYMqORpWhWzygUUjQ < 0)
				{
					return null;
				}
				return wyitjeizprUCYMqORpWhWzygUUjQ;
			}
		}

		[CustomObfuscation(rename = false)]
		public int unityId => 0;

		[CustomObfuscation(rename = false)]
		public Guid instanceGuid => MylEsDRFVVMhBJcGlgRgFyDkQeeGA;

		[CustomObfuscation(rename = false)]
		public Guid persistentGuid => instanceGuid;

		[CustomObfuscation(rename = false)]
		public Controller.Extension extension
		{
			[CompilerGenerated]
			get
			{
				return iPcZkmwJRmUSAfoquojmjvjiIcCf;
			}
			[CompilerGenerated]
			set
			{
				iPcZkmwJRmUSAfoquojmjvjiIcCf = value;
			}
		}

		[CustomObfuscation(rename = false)]
		public void SetVibration(float amount, int motorIndex)
		{
			ncRBPRILXKISRDXTTSTeRKtkNzpTA.SAqdclOMATYYvqgcnuQOYdcnXKML(motorIndex, amount, false);
		}

		[CustomObfuscation(rename = false)]
		public void StopVibration()
		{
		}

		public nlzbjZAvSssoBrApgKesFqzjEAomb(Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_0)
		{
			PbxKItkpDEopHKcLvkuqqKvGveJM = P_0;
			wyitjeizprUCYMqORpWhWzygUUjQ = -1;
			jnTUNQIkgqcKCiEAwbMZLHIeGqRG = -1;
		}

		public void MlxxoBHQWLcsxCtqgDqxENlqGClK()
		{
			aNminznnktfeQocLrbuweRfSqoPUA = MiscTools.CreateGuidHashSHA1(nbKggyiWHSGiLRrSVVgtjzhItnkxA + vlTmvRjRFWNOQgJwigVyGNNOHdJoA.ToProductGuid().ToString());
			QSpGKgLcmMquAQaJHOvZChGmidDs = ZOKwwFcsWkTiJJjAiZAUzxSOgfuw;
			FgsfjAsbPvufPzyUsqZHIojbhTAk = KhjwbdgYSYxylvAtecxIBSkYrjgD + tExvLgldQmooUgcbIXdhChsHLlXN * 8;
			fyKHXiGInVfATQTtqFcElaiTdiLdA();
			nOQoHZoiWPrSFIsmqagvEKvWBGDT = jnGTQDFeNsixRwgRJcghDqCbQWSP.hardwareMapIdentifier.guid;
			dOGnZNaneIcyRDqppLkltFGQCCGS = jnGTQDFeNsixRwgRJcghDqCbQWSP.controllerName;
			MTITHegngzqezjYeaLtznfvMAJKL = ((nOQoHZoiWPrSFIsmqagvEKvWBGDT == Guid.Empty) ? true : false);
			rODUhFvDvuNqUagvIByzDzydddPVA = new float[QSpGKgLcmMquAQaJHOvZChGmidDs];
			JspBooWrPbsrHYagyhvvwXCFhuHz = new bool[FgsfjAsbPvufPzyUsqZHIojbhTAk];
			Update();
		}

		public void MoPxkLbXJUzTnvkSIWUSBnnSbase(nlzbjZAvSssoBrApgKesFqzjEAomb P_0)
		{
			if (P_0 != null)
			{
				wyitjeizprUCYMqORpWhWzygUUjQ = P_0.wyitjeizprUCYMqORpWhWzygUUjQ;
				jnTUNQIkgqcKCiEAwbMZLHIeGqRG = P_0.jnTUNQIkgqcKCiEAwbMZLHIeGqRG;
				for (int i = 0; i < MathTools.Min(JspBooWrPbsrHYagyhvvwXCFhuHz.Length, P_0.JspBooWrPbsrHYagyhvvwXCFhuHz.Length); i++)
				{
					JspBooWrPbsrHYagyhvvwXCFhuHz[i] = P_0.JspBooWrPbsrHYagyhvvwXCFhuHz[i];
				}
				for (int j = 0; j < MathTools.Min(rODUhFvDvuNqUagvIByzDzydddPVA.Length, P_0.rODUhFvDvuNqUagvIByzDzydddPVA.Length); j++)
				{
					rODUhFvDvuNqUagvIByzDzydddPVA[j] = P_0.rODUhFvDvuNqUagvIByzDzydddPVA[j];
				}
				pfESQMflewZfzKfYXhoSMGpQFgFkA = P_0.pfESQMflewZfzKfYXhoSMGpQFgFkA;
			}
		}

		[CustomObfuscation(rename = false)]
		public void Update()
		{
			sMDjzCJDeBvhrbyByBjiYGZTdvid();
			NmpnNBiKKVbSAuwNMDZPPwvGzdji();
			if (!pfESQMflewZfzKfYXhoSMGpQFgFkA && ncRBPRILXKISRDXTTSTeRKtkNzpTA.BFKBjOiPeqPvmoXfkMsienbYNVrOA)
			{
				pfESQMflewZfzKfYXhoSMGpQFgFkA = true;
			}
		}

		[CustomObfuscation(rename = false)]
		public void FillData(ControllerDataUpdater dataUpdater)
		{
			if (QSpGKgLcmMquAQaJHOvZChGmidDs != dataUpdater.axisCount || FgsfjAsbPvufPzyUsqZHIojbhTAk != dataUpdater.buttonCount)
			{
				throw new Exception("This controller signature does not match the data object!");
			}
			for (int i = 0; i < QSpGKgLcmMquAQaJHOvZChGmidDs; i++)
			{
				dataUpdater.axisValues[i] = rODUhFvDvuNqUagvIByzDzydddPVA[i];
			}
			for (int j = 0; j < FgsfjAsbPvufPzyUsqZHIojbhTAk; j++)
			{
				dataUpdater.buttonValues[j] = JspBooWrPbsrHYagyhvvwXCFhuHz[j];
			}
			if (pfESQMflewZfzKfYXhoSMGpQFgFkA && !dataUpdater.hasReceivedInput)
			{
				dataUpdater.hasReceivedInput = true;
			}
		}

		public int eRcrgXtiJZnEILPhcaiUyTnAFTCn(nlzbjZAvSssoBrApgKesFqzjEAomb P_0)
		{
			if (P_0.jnTUNQIkgqcKCiEAwbMZLHIeGqRG == jnTUNQIkgqcKCiEAwbMZLHIeGqRG)
			{
				return 2;
			}
			if (ZOKwwFcsWkTiJJjAiZAUzxSOgfuw != P_0.ZOKwwFcsWkTiJJjAiZAUzxSOgfuw)
			{
				return 0;
			}
			if (KhjwbdgYSYxylvAtecxIBSkYrjgD != P_0.KhjwbdgYSYxylvAtecxIBSkYrjgD)
			{
				return 0;
			}
			if (tExvLgldQmooUgcbIXdhChsHLlXN != P_0.tExvLgldQmooUgcbIXdhChsHLlXN)
			{
				return 0;
			}
			if (P_0.MylEsDRFVVMhBJcGlgRgFyDkQeeGA == MylEsDRFVVMhBJcGlgRgFyDkQeeGA)
			{
				return 2;
			}
			if (P_0.aNminznnktfeQocLrbuweRfSqoPUA == aNminznnktfeQocLrbuweRfSqoPUA)
			{
				return 1;
			}
			return 0;
		}

		private BridgedControllerHWInfo dRJFQxxbJtbamMAsWxKyOgWwHrhW()
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
			if (QSpGKgLcmMquAQaJHOvZChGmidDs <= 0 || jnGTQDFeNsixRwgRJcghDqCbQWSP.map.platform != InputPlatform.SDL2)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Axis[] axes_orig = ((HardwareJoystickMap.Platform_SDL2_Base)jnGTQDFeNsixRwgRJcghDqCbQWSP.map).Axes_orig;
			if (axes_orig != null)
			{
				for (int i = 0; i < axes_orig.Length; i++)
				{
					juLqoowiyoMAjtnfwbjmGxuRFIrOA(axes_orig[i], i);
				}
			}
		}

		private void NmpnNBiKKVbSAuwNMDZPPwvGzdji()
		{
			if (FgsfjAsbPvufPzyUsqZHIojbhTAk <= 0)
			{
				return;
			}
			HardwareJoystickMap.Platform_SDL2_Base.Button[] buttons_orig = ((HardwareJoystickMap.Platform_SDL2_Base)jnGTQDFeNsixRwgRJcghDqCbQWSP.map).Buttons_orig;
			if (buttons_orig != null)
			{
				for (int i = 0; i < buttons_orig.Length; i++)
				{
					pkUXwBretLNzGAWVJCXEjdnqYwlO(buttons_orig[i], i);
				}
			}
		}

		private void juLqoowiyoMAjtnfwbjmGxuRFIrOA(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0, int P_1)
		{
			if (P_1 >= QSpGKgLcmMquAQaJHOvZChGmidDs)
			{
				throw new Exception("Number of axes in hardware map does not match number of axes found in controller!");
			}
			rODUhFvDvuNqUagvIByzDzydddPVA[P_1] = oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(P_0);
		}

		private void pkUXwBretLNzGAWVJCXEjdnqYwlO(HardwareJoystickMap.Platform_SDL2_Base.Button P_0, int P_1)
		{
			if (P_1 >= FgsfjAsbPvufPzyUsqZHIojbhTAk)
			{
				throw new Exception("Number of buttons in hardware map does not match number of buttons found in controller!");
			}
			JspBooWrPbsrHYagyhvvwXCFhuHz[P_1] = QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0);
		}

		private float oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(HardwareJoystickMap.Platform_SDL2_Base.Axis P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis < 0 || sourceAxis >= ZOKwwFcsWkTiJJjAiZAUzxSOgfuw || sourceAxis >= 56)
				{
					return 0f;
				}
				return ncRBPRILXKISRDXTTSTeRKtkNzpTA.oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(sourceAxis);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				int sourceButton = P_0.sourceButton;
				if (sourceButton < 0 || sourceButton >= KhjwbdgYSYxylvAtecxIBSkYrjgD || sourceButton >= 256)
				{
					return 0f;
				}
				if (!ncRBPRILXKISRDXTTSTeRKtkNzpTA.QJBSSzPioDBMmqZkZEFzajPlEHwp(sourceButton))
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
				if (sourceHat < 0 || sourceHat >= tExvLgldQmooUgcbIXdhChsHLlXN || sourceHat >= 4)
				{
					return 0f;
				}
				int num = ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat);
				if (num < 0)
				{
					return 0f;
				}
				float num2;
				if (P_0.sourceHatDirection == AxisDirection.Horizontal)
				{
					num2 = RCNdvHclJxGSGFhhbfVHbzeRHDRC(num, AxisDirection.Horizontal);
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
					num2 = RCNdvHclJxGSGFhhbfVHbzeRHDRC(num, AxisDirection.Vertical);
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

		private bool QJBSSzPioDBMmqZkZEFzajPlEHwp(HardwareJoystickMap.Platform_SDL2_Base.Button P_0)
		{
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Button)
			{
				if (P_0.ignoreIfButtonsActive)
				{
					for (int i = 0; i < P_0.ignoreIfButtonsActiveButtons.Length; i++)
					{
						if (ncRBPRILXKISRDXTTSTeRKtkNzpTA.QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0.ignoreIfButtonsActiveButtons[i]))
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
						if (!ncRBPRILXKISRDXTTSTeRKtkNzpTA.QJBSSzPioDBMmqZkZEFzajPlEHwp(P_0.requiredButtons[j]))
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
				if (sourceButton < 0 || sourceButton >= KhjwbdgYSYxylvAtecxIBSkYrjgD || sourceButton >= 256)
				{
					return false;
				}
				return ncRBPRILXKISRDXTTSTeRKtkNzpTA.QJBSSzPioDBMmqZkZEFzajPlEHwp(sourceButton);
			}
			if (P_0.sourceType == HardwareElementSourceTypeWithHat.Axis)
			{
				int sourceAxis = P_0.sourceAxis;
				if (sourceAxis <= 0 || sourceAxis >= ZOKwwFcsWkTiJJjAiZAUzxSOgfuw || sourceAxis >= 56)
				{
					return false;
				}
				float num = ncRBPRILXKISRDXTTSTeRKtkNzpTA.oPUqHQlcsmYpoqEbnvDqDlLXDAzJ(sourceAxis);
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
				if (sourceHat < 0 || sourceHat >= tExvLgldQmooUgcbIXdhChsHLlXN || sourceHat >= 4)
				{
					return false;
				}
				switch (P_0.sourceHatDirection)
				{
				case HatDirection.Up:
					return OfOQgfXHvTxpXUVlmoWieJoSSLpN(ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat), 0, P_0.sourceHatType);
				case HatDirection.UpRight:
					return OfOQgfXHvTxpXUVlmoWieJoSSLpN(ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat), 1, P_0.sourceHatType);
				case HatDirection.Right:
					return OfOQgfXHvTxpXUVlmoWieJoSSLpN(ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat), 2, P_0.sourceHatType);
				case HatDirection.DownRight:
					return OfOQgfXHvTxpXUVlmoWieJoSSLpN(ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat), 3, P_0.sourceHatType);
				case HatDirection.Down:
					return OfOQgfXHvTxpXUVlmoWieJoSSLpN(ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat), 4, P_0.sourceHatType);
				case HatDirection.DownLeft:
					return OfOQgfXHvTxpXUVlmoWieJoSSLpN(ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat), 5, P_0.sourceHatType);
				case HatDirection.Left:
					return OfOQgfXHvTxpXUVlmoWieJoSSLpN(ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat), 6, P_0.sourceHatType);
				case HatDirection.UpLeft:
					return OfOQgfXHvTxpXUVlmoWieJoSSLpN(ncRBPRILXKISRDXTTSTeRKtkNzpTA.ndeoaPoctPAhxDaPbxgStFXOlGvAA(sourceHat), 7, P_0.sourceHatType);
				}
			}
			return false;
		}

		private bool OfOQgfXHvTxpXUVlmoWieJoSSLpN(int P_0, int P_1, HatType P_2)
		{
			if (P_0 < 0)
			{
				return false;
			}
			if (jnGTQDFeNsixRwgRJcghDqCbQWSP.isUnknownController && !InputTools.HandleForced4WayHatsOnUnknownControllers(P_1, ref P_2))
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

		private float RCNdvHclJxGSGFhhbfVHbzeRHDRC(int P_0, AxisDirection P_1)
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

		private ControlDeviceType koHKRulbxYQineSFTREjQmwGwNZi(dFGwIisbtfHayiNXiRBRWpMCngGv P_0)
		{
			return P_0 switch
			{
				dFGwIisbtfHayiNXiRBRWpMCngGv.Joystick => ControlDeviceType.Joystick, 
				dFGwIisbtfHayiNXiRBRWpMCngGv.Gamepad => ControlDeviceType.Gamepad, 
				dFGwIisbtfHayiNXiRBRWpMCngGv.Keyboard => ControlDeviceType.Keyboard, 
				dFGwIisbtfHayiNXiRBRWpMCngGv.Mouse => ControlDeviceType.Mouse, 
				_ => ControlDeviceType.Unknown, 
			};
		}

		private void fyKHXiGInVfATQTtqFcElaiTdiLdA()
		{
			jnGTQDFeNsixRwgRJcghDqCbQWSP = PbxKItkpDEopHKcLvkuqqKvGveJM(dRJFQxxbJtbamMAsWxKyOgWwHrhW());
			if (jnGTQDFeNsixRwgRJcghDqCbQWSP == null)
			{
				Logger.LogError("Default hardware map not found!");
				return;
			}
			if (jnGTQDFeNsixRwgRJcghDqCbQWSP.useSystemName && !string.IsNullOrEmpty(gmqqHFPaRiTEZeJkDNWhtfnzrJWc))
			{
				string text = Regex.Replace(gmqqHFPaRiTEZeJkDNWhtfnzrJWc, "\\s+", " ");
				text = text.Trim();
				if (!string.IsNullOrEmpty(text))
				{
					jnGTQDFeNsixRwgRJcghDqCbQWSP.controllerName = text;
				}
			}
			QSpGKgLcmMquAQaJHOvZChGmidDs = jnGTQDFeNsixRwgRJcghDqCbQWSP.axisCount;
			FgsfjAsbPvufPzyUsqZHIojbhTAk = jnGTQDFeNsixRwgRJcghDqCbQWSP.buttonCount;
		}

		private string rqVMPDKVQZpdOuobXSmsIePlFgdfA()
		{
			return InputTools.FormatHardwareIdentifierString($"{ReInput.currentPlatform.ToString()}{ncRBPRILXKISRDXTTSTeRKtkNzpTA.EPyfSrSomRsxmlVBttAjtBtiqyoN}{nbKggyiWHSGiLRrSVVgtjzhItnkxA}{BKKOorJJLcGhpuCjWgkAccaWERACA}{vlTmvRjRFWNOQgJwigVyGNNOHdJoA.ToProductGuid()}");
		}

		private void KonGcavNUOwjzblUmOrIFvgYlQaM(BridgedControllerHWInfo P_0)
		{
			P_0.inputManagerSource = InputSource.SDL2;
			P_0.inputSource = ncRBPRILXKISRDXTTSTeRKtkNzpTA.EPyfSrSomRsxmlVBttAjtBtiqyoN;
			P_0.deviceType = koHKRulbxYQineSFTREjQmwGwNZi(wJPUkuHTqymwMXfAhpTmRxulvPYC);
			P_0.hardwareIdentifier = rqVMPDKVQZpdOuobXSmsIePlFgdfA();
			P_0.hardwareAxisCount = ZOKwwFcsWkTiJJjAiZAUzxSOgfuw;
			P_0.hardwareButtonCount = KhjwbdgYSYxylvAtecxIBSkYrjgD;
			P_0.hardwareHatCount = tExvLgldQmooUgcbIXdhChsHLlXN;
			P_0.hw_productName = nbKggyiWHSGiLRrSVVgtjzhItnkxA;
			P_0.hw_deviceGuid = MylEsDRFVVMhBJcGlgRgFyDkQeeGA;
			P_0.hw_productId = BKKOorJJLcGhpuCjWgkAccaWERACA;
			P_0.hw_pidVid = vlTmvRjRFWNOQgJwigVyGNNOHdJoA;
			P_0.hw_isBluetoothDevice = bfLhflgotMGznpKGludAuLlKnFsRA;
			P_0.hw_bluetoothDeviceName = nbKggyiWHSGiLRrSVVgtjzhItnkxA;
			P_0.hw_systemDeviceName = nbKggyiWHSGiLRrSVVgtjzhItnkxA;
			P_0.hw_supportsVibration = QgfiOqAqKFgNutFnAbZVtqhHbmPt;
			P_0.hw_isSDL2Gamepad = ncRBPRILXKISRDXTTSTeRKtkNzpTA.EEplPFaDqevApKMrsfJwfNZsQAPK == dFGwIisbtfHayiNXiRBRWpMCngGv.Gamepad;
			P_0.hw_localVibrationMotorCount = TvfyCOtyYKIlzJHUmJzZBRLesBkj;
		}

		private void KonGcavNUOwjzblUmOrIFvgYlQaM(BridgedController P_0)
		{
			KonGcavNUOwjzblUmOrIFvgYlQaM((BridgedControllerHWInfo)P_0);
			P_0.sourceJoystick = this;
			P_0.gameHardwareMap = jnGTQDFeNsixRwgRJcghDqCbQWSP.ToGameHardwareControllerMap();
			P_0.instanceName = nbKggyiWHSGiLRrSVVgtjzhItnkxA;
			P_0.productName = nbKggyiWHSGiLRrSVVgtjzhItnkxA;
			P_0.axisCount = QSpGKgLcmMquAQaJHOvZChGmidDs;
			P_0.buttonCount = FgsfjAsbPvufPzyUsqZHIojbhTAk;
			P_0.unknownControllerHats = joZzGTZbJSBCyOgkhrCrVtMMMgWq();
			P_0.controllerTypeGuid = nOQoHZoiWPrSFIsmqagvEKvWBGDT;
			P_0.controllerExtension = extension;
		}

		private void yfxzVLOhjDOvlakUMiuXUazaFzrk()
		{
			for (int i = 0; i < FgsfjAsbPvufPzyUsqZHIojbhTAk; i++)
			{
				JspBooWrPbsrHYagyhvvwXCFhuHz[i] = false;
			}
			for (int j = 0; j < QSpGKgLcmMquAQaJHOvZChGmidDs; j++)
			{
				rODUhFvDvuNqUagvIByzDzydddPVA[j] = 0f;
			}
		}

		private UnknownControllerHat[] joZzGTZbJSBCyOgkhrCrVtMMMgWq()
		{
			if (!MTITHegngzqezjYeaLtznfvMAJKL)
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

		public static int gAVICXSdnXxsffZEYEplbVMUMWye(nlzbjZAvSssoBrApgKesFqzjEAomb P_0, nlzbjZAvSssoBrApgKesFqzjEAomb P_1)
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

		public static int wkdoWpvtUxXmFgxpXhhVZMrRMhTC(nlzbjZAvSssoBrApgKesFqzjEAomb P_0, nlzbjZAvSssoBrApgKesFqzjEAomb P_1)
		{
			if (P_0.MWTsUklfcAgeGMkkXeelyIScauFs < P_1.MWTsUklfcAgeGMkkXeelyIScauFs)
			{
				return -1;
			}
			if (P_0.MWTsUklfcAgeGMkkXeelyIScauFs > P_1.MWTsUklfcAgeGMkkXeelyIScauFs)
			{
				return 1;
			}
			return 0;
		}
	}

	private class RozOwVLgFiJtNMEEBHoaKKbBWGVKA
	{
		public enum yKmCNduCjIayAjwoLZNpvqGoAhzt
		{
			Exact = 0,
			Approximate = 1
		}

		public class snIpDycINffksHlwUESQBijhOFQdc
		{
			public int wKTIDzdbnMqFnJlBBeomtbaWsxjR;

			public Guid awxSkTpcezjBKKbDlCkGoGFlTnNK;

			public Guid aNminznnktfeQocLrbuweRfSqoPUA;

			public int czjrOWhmqBwDdneXNALtIaxNwVzA;

			public int ZOKwwFcsWkTiJJjAiZAUzxSOgfuw;

			public int KhjwbdgYSYxylvAtecxIBSkYrjgD;

			public int tExvLgldQmooUgcbIXdhChsHLlXN;

			public bool eRcrgXtiJZnEILPhcaiUyTnAFTCn(nlzbjZAvSssoBrApgKesFqzjEAomb P_0, yKmCNduCjIayAjwoLZNpvqGoAhzt P_1)
			{
				if (P_0.rewiredId == wKTIDzdbnMqFnJlBBeomtbaWsxjR)
				{
					return true;
				}
				if (ZOKwwFcsWkTiJJjAiZAUzxSOgfuw != P_0.ZOKwwFcsWkTiJJjAiZAUzxSOgfuw)
				{
					return false;
				}
				if (KhjwbdgYSYxylvAtecxIBSkYrjgD != P_0.KhjwbdgYSYxylvAtecxIBSkYrjgD)
				{
					return false;
				}
				if (tExvLgldQmooUgcbIXdhChsHLlXN != P_0.tExvLgldQmooUgcbIXdhChsHLlXN)
				{
					return false;
				}
				return P_1 switch
				{
					yKmCNduCjIayAjwoLZNpvqGoAhzt.Exact => awxSkTpcezjBKKbDlCkGoGFlTnNK == P_0.MylEsDRFVVMhBJcGlgRgFyDkQeeGA, 
					yKmCNduCjIayAjwoLZNpvqGoAhzt.Approximate => aNminznnktfeQocLrbuweRfSqoPUA == P_0.aNminznnktfeQocLrbuweRfSqoPUA, 
					_ => throw new NotImplementedException(), 
				};
			}
		}

		private sealed class oxzdFkpmsRBvAnBmKOLHzTuHQkWO : IDisposable, IEnumerable, IEnumerator, IEnumerable<snIpDycINffksHlwUESQBijhOFQdc>, IEnumerator<snIpDycINffksHlwUESQBijhOFQdc>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private snIpDycINffksHlwUESQBijhOFQdc USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public RozOwVLgFiJtNMEEBHoaKKbBWGVKA GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private nlzbjZAvSssoBrApgKesFqzjEAomb sgVxbuDAuevAQEggkQAcSuZkVnGc;

			public nlzbjZAvSssoBrApgKesFqzjEAomb USZMaIxQjfLLMAXcFwImGLBkIAsG;

			private yKmCNduCjIayAjwoLZNpvqGoAhzt NkWUjerweacIBvSdmEmpoCzRdbtX;

			public yKmCNduCjIayAjwoLZNpvqGoAhzt pMHTdFHYEXVSjtXRwCWwwczjKiTJ;

			private int XoXSDiftyvAwyAXRnHGdMRIPCNdGA;

			private int eolRghqutZOOIGqvOFTzJOGfYTsn;

			snIpDycINffksHlwUESQBijhOFQdc IEnumerator<snIpDycINffksHlwUESQBijhOFQdc>.Current
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
			public oxzdFkpmsRBvAnBmKOLHzTuHQkWO(int P_0)
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
				RozOwVLgFiJtNMEEBHoaKKbBWGVKA gZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
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
			IEnumerator<snIpDycINffksHlwUESQBijhOFQdc> IEnumerable<snIpDycINffksHlwUESQBijhOFQdc>.GetEnumerator()
			{
				oxzdFkpmsRBvAnBmKOLHzTuHQkWO oxzdFkpmsRBvAnBmKOLHzTuHQkWO2;
				if (GwbUsvLqBorYvZEWvPDttSzVhFNo == -2 && nOonfdwpqEUEASbbWObCvjhlCTmP == Thread.CurrentThread.ManagedThreadId)
				{
					GwbUsvLqBorYvZEWvPDttSzVhFNo = 0;
					oxzdFkpmsRBvAnBmKOLHzTuHQkWO2 = this;
				}
				else
				{
					oxzdFkpmsRBvAnBmKOLHzTuHQkWO2 = new oxzdFkpmsRBvAnBmKOLHzTuHQkWO(0);
					oxzdFkpmsRBvAnBmKOLHzTuHQkWO2.GZXxEqHwrHYIyUJtInpLwgTukJaY = GZXxEqHwrHYIyUJtInpLwgTukJaY;
				}
				oxzdFkpmsRBvAnBmKOLHzTuHQkWO2.sgVxbuDAuevAQEggkQAcSuZkVnGc = USZMaIxQjfLLMAXcFwImGLBkIAsG;
				oxzdFkpmsRBvAnBmKOLHzTuHQkWO2.NkWUjerweacIBvSdmEmpoCzRdbtX = pMHTdFHYEXVSjtXRwCWwwczjKiTJ;
				return oxzdFkpmsRBvAnBmKOLHzTuHQkWO2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<snIpDycINffksHlwUESQBijhOFQdc>)this).GetEnumerator();
			}
		}

		private List<snIpDycINffksHlwUESQBijhOFQdc> LztWhAIbukRXonlavhcowoysBOjjA;

		public RozOwVLgFiJtNMEEBHoaKKbBWGVKA()
		{
			LztWhAIbukRXonlavhcowoysBOjjA = new List<snIpDycINffksHlwUESQBijhOFQdc>();
		}

		public void XwxmMWfpySNSMASbMCDIaCKEBrGP(nlzbjZAvSssoBrApgKesFqzjEAomb P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			int count = LztWhAIbukRXonlavhcowoysBOjjA.Count;
			for (int i = 0; i < count; i++)
			{
				if (LztWhAIbukRXonlavhcowoysBOjjA[i].eRcrgXtiJZnEILPhcaiUyTnAFTCn(P_0, yKmCNduCjIayAjwoLZNpvqGoAhzt.Exact))
				{
					LztWhAIbukRXonlavhcowoysBOjjA[i].wKTIDzdbnMqFnJlBBeomtbaWsxjR = P_0.rewiredId;
					LztWhAIbukRXonlavhcowoysBOjjA[i].awxSkTpcezjBKKbDlCkGoGFlTnNK = P_0.MylEsDRFVVMhBJcGlgRgFyDkQeeGA;
					LztWhAIbukRXonlavhcowoysBOjjA[i].aNminznnktfeQocLrbuweRfSqoPUA = P_0.aNminznnktfeQocLrbuweRfSqoPUA;
					LztWhAIbukRXonlavhcowoysBOjjA[i].czjrOWhmqBwDdneXNALtIaxNwVzA = P_0.inputManagerId;
					LztWhAIbukRXonlavhcowoysBOjjA[i].ZOKwwFcsWkTiJJjAiZAUzxSOgfuw = P_0.ZOKwwFcsWkTiJJjAiZAUzxSOgfuw;
					LztWhAIbukRXonlavhcowoysBOjjA[i].KhjwbdgYSYxylvAtecxIBSkYrjgD = P_0.KhjwbdgYSYxylvAtecxIBSkYrjgD;
					LztWhAIbukRXonlavhcowoysBOjjA[i].tExvLgldQmooUgcbIXdhChsHLlXN = P_0.tExvLgldQmooUgcbIXdhChsHLlXN;
					nPpArpXwftSAPCgODdQhbwKgoHcvA(P_0.rewiredId, P_0.MylEsDRFVVMhBJcGlgRgFyDkQeeGA, i);
					return;
				}
			}
			LztWhAIbukRXonlavhcowoysBOjjA.Add(new snIpDycINffksHlwUESQBijhOFQdc
			{
				wKTIDzdbnMqFnJlBBeomtbaWsxjR = P_0.rewiredId,
				awxSkTpcezjBKKbDlCkGoGFlTnNK = P_0.MylEsDRFVVMhBJcGlgRgFyDkQeeGA,
				aNminznnktfeQocLrbuweRfSqoPUA = P_0.aNminznnktfeQocLrbuweRfSqoPUA,
				czjrOWhmqBwDdneXNALtIaxNwVzA = P_0.inputManagerId,
				ZOKwwFcsWkTiJJjAiZAUzxSOgfuw = P_0.ZOKwwFcsWkTiJJjAiZAUzxSOgfuw,
				KhjwbdgYSYxylvAtecxIBSkYrjgD = P_0.KhjwbdgYSYxylvAtecxIBSkYrjgD,
				tExvLgldQmooUgcbIXdhChsHLlXN = P_0.tExvLgldQmooUgcbIXdhChsHLlXN
			});
			nPpArpXwftSAPCgODdQhbwKgoHcvA(P_0.rewiredId, P_0.MylEsDRFVVMhBJcGlgRgFyDkQeeGA, LztWhAIbukRXonlavhcowoysBOjjA.Count - 1);
		}

		public bool kUiCmZCewQfczGBdspnXBabLzrLy(nlzbjZAvSssoBrApgKesFqzjEAomb P_0, yKmCNduCjIayAjwoLZNpvqGoAhzt P_1)
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

		public IEnumerable<snIpDycINffksHlwUESQBijhOFQdc> EIllDHQFSlaxtdIhRTpOBXaXOnOQ(nlzbjZAvSssoBrApgKesFqzjEAomb P_0, yKmCNduCjIayAjwoLZNpvqGoAhzt P_1)
		{
			return new oxzdFkpmsRBvAnBmKOLHzTuHQkWO(-2)
			{
				GZXxEqHwrHYIyUJtInpLwgTukJaY = this,
				USZMaIxQjfLLMAXcFwImGLBkIAsG = P_0,
				pMHTdFHYEXVSjtXRwCWwwczjKiTJ = P_1
			};
		}

		private void nPpArpXwftSAPCgODdQhbwKgoHcvA(int P_0, Guid P_1, int P_2)
		{
			for (int num = LztWhAIbukRXonlavhcowoysBOjjA.Count - 1; num >= 0; num--)
			{
				if (num != P_2 && (LztWhAIbukRXonlavhcowoysBOjjA[num].wKTIDzdbnMqFnJlBBeomtbaWsxjR == P_0 || LztWhAIbukRXonlavhcowoysBOjjA[num].awxSkTpcezjBKKbDlCkGoGFlTnNK == P_1))
				{
					LztWhAIbukRXonlavhcowoysBOjjA.RemoveAt(num);
				}
			}
		}
	}

	internal const bool QsHHfEAIztfGdACcAeeKYpjxYJXe = true;

	private IInputSource lIrFNebwcrngtQQhQmkKXzYuwXAQ;

	private List<nlzbjZAvSssoBrApgKesFqzjEAomb> elKJbbxESyfcuzfcxFoUDTJZIhcJA;

	private int NcFhTqaznBUbORimVwWyLExKyNzx;

	private RozOwVLgFiJtNMEEBHoaKKbBWGVKA boNSEKuFFoQzYuEJbTHAMBvFjgjG;

	private bool vOBKVnebkBpKgLMbliSkdvNFpdei;

	private Action<int, ControllerDataUpdater> aZjUoBTvFJqBWAfFXmCRkuewLIOx;

	private PlatformInputManager gfTEZguFOlDAmDChxHFfMUBZrqTl;

	private readonly bool BrFYCbSJfjRysPkarCLQvqAUmUSM;

	private readonly bool lEJSPZmAzmnnByCILEkerWjAiZZbA;

	private readonly bool KWqGvDitOLDGSIdkcqFCrbSWiIuhB;

	private readonly Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> PbxKItkpDEopHKcLvkuqqKvGveJM;

	private readonly Func<int> UXKJcKCIAkFQAFXjwewUPGMLjJdmA;

	[CustomObfuscation(rename = false)]
	public override int deviceCount => NcFhTqaznBUbORimVwWyLExKyNzx;

	[CustomObfuscation(rename = false)]
	public override PlatformInputManager primaryInputManager => gfTEZguFOlDAmDChxHFfMUBZrqTl;

	[CustomObfuscation(rename = false)]
	public override IInputSource inputSource => lIrFNebwcrngtQQhQmkKXzYuwXAQ;

	[CustomObfuscation(rename = false)]
	public override InputSource inputSourceType => InputSource.SDL2;

	public lwbDySfvDdBYvtcCsmSJyxKynhnkA(ConfigVars P_0, Func<BridgedControllerHWInfo, HardwareJoystickMap_InputManager> P_1, Func<int> P_2, bool P_3, bool P_4, bool P_5)
	{
		try
		{
			PbxKItkpDEopHKcLvkuqqKvGveJM = P_1;
			UXKJcKCIAkFQAFXjwewUPGMLjJdmA = P_2;
			BrFYCbSJfjRysPkarCLQvqAUmUSM = P_3;
			lEJSPZmAzmnnByCILEkerWjAiZZbA = P_4;
			KWqGvDitOLDGSIdkcqFCrbSWiIuhB = P_5;
			gfTEZguFOlDAmDChxHFfMUBZrqTl = this;
			lIrFNebwcrngtQQhQmkKXzYuwXAQ = new SDL2InputSource(P_0.updateLoop, P_3, P_3, P_4, P_5);
			aZjUoBTvFJqBWAfFXmCRkuewLIOx = UpdateControllerData;
			lIrFNebwcrngtQQhQmkKXzYuwXAQ.DeviceChangedEvent += hwwjnRKXeIqWzbCMqXmIXoNdgNdm;
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
		if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
		{
			boNSEKuFFoQzYuEJbTHAMBvFjgjG = new RozOwVLgFiJtNMEEBHoaKKbBWGVKA();
			arLxlEYGvjkvWuzMDsSNwJKRPbbl();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void Update(UpdateLoopType updateLoop)
	{
		if (lIrFNebwcrngtQQhQmkKXzYuwXAQ != null)
		{
			lIrFNebwcrngtQQhQmkKXzYuwXAQ.Update();
		}
		if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
		{
			if (vOBKVnebkBpKgLMbliSkdvNFpdei)
			{
				alayrrvNCSZbAOTuonjpHkvoUumW();
			}
			if (lIrFNebwcrngtQQhQmkKXzYuwXAQ != null)
			{
				for (int i = 0; i < NcFhTqaznBUbORimVwWyLExKyNzx; i++)
				{
					elKJbbxESyfcuzfcxFoUDTJZIhcJA[i]?.ncRBPRILXKISRDXTTSTeRKtkNzpTA.Update(updateLoop);
				}
				lIrFNebwcrngtQQhQmkKXzYuwXAQ.UpdateDevices(updateLoop);
			}
			DzgjBVFcaWDogqCKSBeRqdglJPai();
			if (lIrFNebwcrngtQQhQmkKXzYuwXAQ != null)
			{
				lIrFNebwcrngtQQhQmkKXzYuwXAQ.UpdateFinished();
				for (int j = 0; j < NcFhTqaznBUbORimVwWyLExKyNzx; j++)
				{
					elKJbbxESyfcuzfcxFoUDTJZIhcJA[j]?.ncRBPRILXKISRDXTTSTeRKtkNzpTA.UpdateFinished();
				}
			}
		}
		_ = lEJSPZmAzmnnByCILEkerWjAiZZbA;
	}

	[CustomObfuscation(rename = false)]
	public override void OnDestroy()
	{
		if (elKJbbxESyfcuzfcxFoUDTJZIhcJA != null)
		{
			int count = elKJbbxESyfcuzfcxFoUDTJZIhcJA.Count;
			for (int i = 0; i < count; i++)
			{
				if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[i] != null)
				{
					elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].ncRBPRILXKISRDXTTSTeRKtkNzpTA?.hURIyGqMeBiRpzMFHFnxYsncTLfn();
				}
			}
		}
		if (lIrFNebwcrngtQQhQmkKXzYuwXAQ != null)
		{
			lIrFNebwcrngtQQhQmkKXzYuwXAQ.Dispose();
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
		if (!BrFYCbSJfjRysPkarCLQvqAUmUSM)
		{
			return;
		}
		for (int i = 0; i < NcFhTqaznBUbORimVwWyLExKyNzx; i++)
		{
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].inputManagerId == inputManagerId)
			{
				elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].FillData(data);
				break;
			}
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceConnected()
	{
		if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
		{
			vOBKVnebkBpKgLMbliSkdvNFpdei = true;
		}
		if (_SystemDeviceConnectedEvent != null)
		{
			_SystemDeviceConnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SystemDeviceDisconnected()
	{
		if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
		{
			vOBKVnebkBpKgLMbliSkdvNFpdei = true;
		}
		if (_SystemDeviceDisconnectedEvent != null)
		{
			_SystemDeviceDisconnectedEvent();
		}
	}

	[CustomObfuscation(rename = false)]
	public override void SetUnityJoystickId(int joystickId, int unityJoystickId)
	{
		_ = BrFYCbSJfjRysPkarCLQvqAUmUSM;
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

	private void arLxlEYGvjkvWuzMDsSNwJKRPbbl()
	{
		arLxlEYGvjkvWuzMDsSNwJKRPbbl(dEDacTLbUGeNLFItRIwIDdmQaLDmA());
	}

	private void arLxlEYGvjkvWuzMDsSNwJKRPbbl(IList<LjmiwQfcsmzrgAYaHEMKGLaOgKjY> P_0)
	{
		int num = 0;
		List<nlzbjZAvSssoBrApgKesFqzjEAomb> list = elKJbbxESyfcuzfcxFoUDTJZIhcJA;
		int ncFhTqaznBUbORimVwWyLExKyNzx = NcFhTqaznBUbORimVwWyLExKyNzx;
		elKJbbxESyfcuzfcxFoUDTJZIhcJA = new List<nlzbjZAvSssoBrApgKesFqzjEAomb>();
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null)
			{
				LjmiwQfcsmzrgAYaHEMKGLaOgKjY ljmiwQfcsmzrgAYaHEMKGLaOgKjY = P_0[i];
				nlzbjZAvSssoBrApgKesFqzjEAomb nlzbjZAvSssoBrApgKesFqzjEAomb2 = new nlzbjZAvSssoBrApgKesFqzjEAomb(PbxKItkpDEopHKcLvkuqqKvGveJM);
				nlzbjZAvSssoBrApgKesFqzjEAomb2.ncRBPRILXKISRDXTTSTeRKtkNzpTA = ljmiwQfcsmzrgAYaHEMKGLaOgKjY;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.MylEsDRFVVMhBJcGlgRgFyDkQeeGA = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.YjwWdxpniAUnXgLflhIRHiikzpTbA;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.nbKggyiWHSGiLRrSVVgtjzhItnkxA = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.qwNYDhqQsztCTVRhdZwjwNfzyIPm;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.gmqqHFPaRiTEZeJkDNWhtfnzrJWc = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.nMBlNGdLybrwLdusELmERFPtBnKo;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.vlTmvRjRFWNOQgJwigVyGNNOHdJoA = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.NuQZJpGeEdiUTFqpDBffuuvvMZSKA;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.BKKOorJJLcGhpuCjWgkAccaWERACA = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.fYWkoLcUSETrKvloBAxKAUcwYzDqA;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.fSoHPUfJCksYThdbElmhKTIwCwuC = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.hjulZdwGnzqdVxpxdcOWARsBQSqz;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.wJPUkuHTqymwMXfAhpTmRxulvPYC = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.EEplPFaDqevApKMrsfJwfNZsQAPK;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.MWTsUklfcAgeGMkkXeelyIScauFs = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.ZKOJoCbGYCFJRapdwLXBYyKWqOaFA;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.ZOKwwFcsWkTiJJjAiZAUzxSOgfuw = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.QIkbAdXQeDUvOIbnNgsPKkBYsPNEA;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.KhjwbdgYSYxylvAtecxIBSkYrjgD = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.JVbQQuOQHNEfCeDatYqbXWSpjigo;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.tExvLgldQmooUgcbIXdhChsHLlXN = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.xllVtNnMCTvELjBoxAaiEMrUHepX;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.bfLhflgotMGznpKGludAuLlKnFsRA = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.WWYEEydAiSjZedciGRYfZZgUgSTLb;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.QgfiOqAqKFgNutFnAbZVtqhHbmPt = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.SbtzfDxIBuZljmbiVaEiEQCpEVsGA;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.TvfyCOtyYKIlzJHUmJzZBRLesBkj = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.qLmbaCEkldvAjdkmxMVJBJvKWSxZ;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.extension = ljmiwQfcsmzrgAYaHEMKGLaOgKjY.OXfETugsnzVfYmrRHpmEgDqFBTkD;
				ljmiwQfcsmzrgAYaHEMKGLaOgKjY.ichWnQXGruUPsgxGUtCKnXvtfVbo();
				nlzbjZAvSssoBrApgKesFqzjEAomb2.MlxxoBHQWLcsxCtqgDqxENlqGClK();
				elKJbbxESyfcuzfcxFoUDTJZIhcJA.Add(nlzbjZAvSssoBrApgKesFqzjEAomb2);
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
			elKJbbxESyfcuzfcxFoUDTJZIhcJA[i]?.Update();
		}
	}

	private bool uEfaGCunhVDlflMdXsrcgHsCvNIi(tGuhVMgjQuttsfzYtqPAxiAztnUe P_0)
	{
		try
		{
			return P_0.RHNlhOZBjLkLbRKmlCekFXbpaeAdb();
		}
		catch
		{
			return false;
		}
	}

	private IList<LjmiwQfcsmzrgAYaHEMKGLaOgKjY> dEDacTLbUGeNLFItRIwIDdmQaLDmA()
	{
		return lIrFNebwcrngtQQhQmkKXzYuwXAQ.GetJoysticks<LjmiwQfcsmzrgAYaHEMKGLaOgKjY>();
	}

	private void cqAGnKSmwNWnRODgdRfXOJTBoCZu(int P_0, int P_1, List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_2, List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_3)
	{
		if (P_1 > 0)
		{
			P_3.Sort(nlzbjZAvSssoBrApgKesFqzjEAomb.wkdoWpvtUxXmFgxpXhhVZMrRMhTC);
		}
		if (P_0 > 0 && P_1 > 0)
		{
			uYUMbRdtPJBZfjrxwDzznOaHJQrI(P_1, P_3, P_0, P_2, RozOwVLgFiJtNMEEBHoaKKbBWGVKA.yKmCNduCjIayAjwoLZNpvqGoAhzt.Exact);
			uYUMbRdtPJBZfjrxwDzznOaHJQrI(P_1, P_3, P_0, P_2, RozOwVLgFiJtNMEEBHoaKKbBWGVKA.yKmCNduCjIayAjwoLZNpvqGoAhzt.Approximate);
		}
		qGASwmLKicpNuRMFZhYhTikWOtmL(P_1, P_3, RozOwVLgFiJtNMEEBHoaKKbBWGVKA.yKmCNduCjIayAjwoLZNpvqGoAhzt.Exact);
		qGASwmLKicpNuRMFZhYhTikWOtmL(P_1, P_3, RozOwVLgFiJtNMEEBHoaKKbBWGVKA.yKmCNduCjIayAjwoLZNpvqGoAhzt.Approximate);
		for (int i = 0; i < P_1; i++)
		{
			nlzbjZAvSssoBrApgKesFqzjEAomb nlzbjZAvSssoBrApgKesFqzjEAomb2 = P_3[i];
			if (nlzbjZAvSssoBrApgKesFqzjEAomb2 != null && nlzbjZAvSssoBrApgKesFqzjEAomb2.inputManagerId < 0)
			{
				nlzbjZAvSssoBrApgKesFqzjEAomb2.inputManagerId = VdgvNWWcieHYaYPMzqzCHdZkirLp(P_3);
				nlzbjZAvSssoBrApgKesFqzjEAomb2.rewiredId = UXKJcKCIAkFQAFXjwewUPGMLjJdmA();
				boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(nlzbjZAvSssoBrApgKesFqzjEAomb2);
			}
		}
		P_3.Sort(nlzbjZAvSssoBrApgKesFqzjEAomb.gAVICXSdnXxsffZEYEplbVMUMWye);
	}

	private void PXvhJlnAOWKmBwlhRDOltbukRfTW(List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_0, int P_1, int P_2)
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

	private bool RoQgGVBBIMEvxAlvsqmCkaytazLq(List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_0, int P_1)
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

	private int VdgvNWWcieHYaYPMzqzCHdZkirLp(List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_0)
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

	private bool XuZqBzKvCtCosuIEtcqGHmpxHywSA(List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_0, int P_1)
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

	private void uYUMbRdtPJBZfjrxwDzznOaHJQrI(int P_0, List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_1, int P_2, List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_3, RozOwVLgFiJtNMEEBHoaKKbBWGVKA.yKmCNduCjIayAjwoLZNpvqGoAhzt P_4)
	{
		int num = ((P_4 != RozOwVLgFiJtNMEEBHoaKKbBWGVKA.yKmCNduCjIayAjwoLZNpvqGoAhzt.Exact) ? 1 : 2);
		for (int i = 0; i < P_0; i++)
		{
			nlzbjZAvSssoBrApgKesFqzjEAomb nlzbjZAvSssoBrApgKesFqzjEAomb2 = P_1[i];
			if (nlzbjZAvSssoBrApgKesFqzjEAomb2 == null || nlzbjZAvSssoBrApgKesFqzjEAomb2.inputManagerId >= 0)
			{
				continue;
			}
			for (int j = 0; j < P_2; j++)
			{
				nlzbjZAvSssoBrApgKesFqzjEAomb nlzbjZAvSssoBrApgKesFqzjEAomb3 = P_3[j];
				if (nlzbjZAvSssoBrApgKesFqzjEAomb3 != null && !XuZqBzKvCtCosuIEtcqGHmpxHywSA(P_1, nlzbjZAvSssoBrApgKesFqzjEAomb3.rewiredId) && nlzbjZAvSssoBrApgKesFqzjEAomb2.eRcrgXtiJZnEILPhcaiUyTnAFTCn(nlzbjZAvSssoBrApgKesFqzjEAomb3) >= num)
				{
					nlzbjZAvSssoBrApgKesFqzjEAomb2.MoPxkLbXJUzTnvkSIWUSBnnSbase(nlzbjZAvSssoBrApgKesFqzjEAomb3);
					boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(nlzbjZAvSssoBrApgKesFqzjEAomb2);
				}
			}
		}
	}

	private void qGASwmLKicpNuRMFZhYhTikWOtmL(int P_0, List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_1, RozOwVLgFiJtNMEEBHoaKKbBWGVKA.yKmCNduCjIayAjwoLZNpvqGoAhzt P_2)
	{
		for (int i = 0; i < P_0; i++)
		{
			nlzbjZAvSssoBrApgKesFqzjEAomb nlzbjZAvSssoBrApgKesFqzjEAomb2 = P_1[i];
			if (nlzbjZAvSssoBrApgKesFqzjEAomb2 == null || nlzbjZAvSssoBrApgKesFqzjEAomb2.inputManagerId >= 0)
			{
				continue;
			}
			RozOwVLgFiJtNMEEBHoaKKbBWGVKA.snIpDycINffksHlwUESQBijhOFQdc snIpDycINffksHlwUESQBijhOFQdc = null;
			foreach (RozOwVLgFiJtNMEEBHoaKKbBWGVKA.snIpDycINffksHlwUESQBijhOFQdc item in boNSEKuFFoQzYuEJbTHAMBvFjgjG.EIllDHQFSlaxtdIhRTpOBXaXOnOQ(nlzbjZAvSssoBrApgKesFqzjEAomb2, P_2))
			{
				if (!XuZqBzKvCtCosuIEtcqGHmpxHywSA(P_1, item.wKTIDzdbnMqFnJlBBeomtbaWsxjR) && item.czjrOWhmqBwDdneXNALtIaxNwVzA >= 0)
				{
					snIpDycINffksHlwUESQBijhOFQdc = item;
					break;
				}
			}
			if (snIpDycINffksHlwUESQBijhOFQdc != null)
			{
				int num = snIpDycINffksHlwUESQBijhOFQdc.czjrOWhmqBwDdneXNALtIaxNwVzA;
				if (!RoQgGVBBIMEvxAlvsqmCkaytazLq(P_1, num))
				{
					num = (snIpDycINffksHlwUESQBijhOFQdc.czjrOWhmqBwDdneXNALtIaxNwVzA = VdgvNWWcieHYaYPMzqzCHdZkirLp(P_1));
				}
				nlzbjZAvSssoBrApgKesFqzjEAomb2.inputManagerId = num;
				nlzbjZAvSssoBrApgKesFqzjEAomb2.rewiredId = snIpDycINffksHlwUESQBijhOFQdc.wKTIDzdbnMqFnJlBBeomtbaWsxjR;
				boNSEKuFFoQzYuEJbTHAMBvFjgjG.XwxmMWfpySNSMASbMCDIaCKEBrGP(nlzbjZAvSssoBrApgKesFqzjEAomb2);
			}
		}
	}

	private void alayrrvNCSZbAOTuonjpHkvoUumW()
	{
		IList<LjmiwQfcsmzrgAYaHEMKGLaOgKjY> list = dEDacTLbUGeNLFItRIwIDdmQaLDmA();
		arLxlEYGvjkvWuzMDsSNwJKRPbbl(list);
		vOBKVnebkBpKgLMbliSkdvNFpdei = false;
	}

	private bool JCMhjgogkiAcRTHBcfVaOMUtSLyg(IList<LjmiwQfcsmzrgAYaHEMKGLaOgKjY> P_0)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && !IVhuEdEWnUTxtZeIxmVsQIDElOBs(P_0[i].YjwWdxpniAUnXgLflhIRHiikzpTbA))
			{
				return true;
			}
		}
		int count2 = elKJbbxESyfcuzfcxFoUDTJZIhcJA.Count;
		for (int j = 0; j < count2; j++)
		{
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[j] != null && !jtWzCCGJuHaJKhfOljMOMxmqCyfb(P_0, elKJbbxESyfcuzfcxFoUDTJZIhcJA[j].MylEsDRFVVMhBJcGlgRgFyDkQeeGA))
			{
				return true;
			}
		}
		return false;
	}

	private bool IVhuEdEWnUTxtZeIxmVsQIDElOBs(Guid P_0)
	{
		int count = elKJbbxESyfcuzfcxFoUDTJZIhcJA.Count;
		for (int i = 0; i < count; i++)
		{
			if (elKJbbxESyfcuzfcxFoUDTJZIhcJA[i] != null && elKJbbxESyfcuzfcxFoUDTJZIhcJA[i].MylEsDRFVVMhBJcGlgRgFyDkQeeGA == P_0)
			{
				return true;
			}
		}
		return false;
	}

	private bool jtWzCCGJuHaJKhfOljMOMxmqCyfb(IList<LjmiwQfcsmzrgAYaHEMKGLaOgKjY> P_0, Guid P_1)
	{
		int count = P_0.Count;
		for (int i = 0; i < count; i++)
		{
			if (P_0[i] != null && P_0[i].YjwWdxpniAUnXgLflhIRHiikzpTbA == P_1)
			{
				return true;
			}
		}
		return false;
	}

	private void ndHGRVlfkxHhrsyODJjzLJITnfsX(List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_0, List<nlzbjZAvSssoBrApgKesFqzjEAomb> P_1, bool P_2)
	{
		if (P_0 == null)
		{
			return;
		}
		int num = P_0?.Count ?? 0;
		int num2 = P_1?.Count ?? 0;
		for (int i = 0; i < num; i++)
		{
			nlzbjZAvSssoBrApgKesFqzjEAomb nlzbjZAvSssoBrApgKesFqzjEAomb2 = P_0[i];
			if (nlzbjZAvSssoBrApgKesFqzjEAomb2 == null)
			{
				continue;
			}
			bool flag = false;
			if (P_1 != null)
			{
				for (int j = 0; j < num2; j++)
				{
					nlzbjZAvSssoBrApgKesFqzjEAomb nlzbjZAvSssoBrApgKesFqzjEAomb3 = P_1[j];
					if (nlzbjZAvSssoBrApgKesFqzjEAomb3 != null && nlzbjZAvSssoBrApgKesFqzjEAomb2.MylEsDRFVVMhBJcGlgRgFyDkQeeGA == nlzbjZAvSssoBrApgKesFqzjEAomb3.MylEsDRFVVMhBJcGlgRgFyDkQeeGA)
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

	private void TsntVxtlUhBxydDlwSYiTnYwbYkmA(nlzbjZAvSssoBrApgKesFqzjEAomb P_0, bool P_1)
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

	private void hwwjnRKXeIqWzbCMqXmIXoNdgNdm()
	{
		if (BrFYCbSJfjRysPkarCLQvqAUmUSM)
		{
			vOBKVnebkBpKgLMbliSkdvNFpdei = true;
		}
		SystemDeviceConnected();
	}
}
