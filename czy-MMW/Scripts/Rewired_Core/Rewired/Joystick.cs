using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int zlgMirevOPdXNiSMUWVmmOkpodBv = 0;

		private const int AFNDqxtiTxsUXUWNcQYvbDjQNumG = 1;

		private IInputManagerJoystickPublic IVsRjstBGeelOxobJMSRfZYbYrcf;

		private readonly JoystickType[] KUuXkRHmIAoEyHJVtDzeaQlrqhduA;

		private readonly ReadOnlyCollection<JoystickType> aAMYntOmPwceMrGimInobVNcNDZz;

		private readonly bool TRWrRZebpPhhkadPQvkAELaIUZPd;

		private readonly bool QrlvMAaIbmpXjxdIqBguceacVlND;

		private readonly bool nOFIxcqcDFtVmEIirEMawoniPrHK;

		private readonly int SxXaAJAfPoDKOfgvxNlhugQUrVFq;

		private readonly float[] tnQhfnaUoNWFSttXRarpevpPVaOf;

		private readonly TimerAbs[] WoPSPHhjuPurSqaHbFzpMEnDGJci;

		private readonly int CYaJkVOqLzCdIiSiSjXcYgISURzA;

		private readonly Hat[] KPWabJEnaBbNUyOUfNZAdGBouBDAA;

		private readonly ReadOnlyCollection<Hat> BmrMcYPHbwExlBbzFNEonIkJOUDdA;

		internal IList<JoystickType> HxRUyORuHtOQqEDPIvIFUEFwrUVP
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return aAMYntOmPwceMrGimInobVNcNDZz;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return -1L;
				}
				return IVsRjstBGeelOxobJMSRfZYbYrcf.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return -1;
				}
				return IVsRjstBGeelOxobJMSRfZYbYrcf.unityId;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return Guid.Empty;
				}
				return IVsRjstBGeelOxobJMSRfZYbYrcf.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return false;
				}
				return TRWrRZebpPhhkadPQvkAELaIUZPd;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0f;
				}
				if (!TRWrRZebpPhhkadPQvkAELaIUZPd)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!QrlvMAaIbmpXjxdIqBguceacVlND)
				{
					return 0f;
				}
				if (SxXaAJAfPoDKOfgvxNlhugQUrVFq > 0)
				{
					return tnQhfnaUoNWFSttXRarpevpPVaOf[0];
				}
				return 0f;
			}
			set
			{
				if (TRWrRZebpPhhkadPQvkAELaIUZPd)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (QrlvMAaIbmpXjxdIqBguceacVlND && 0 < SxXaAJAfPoDKOfgvxNlhugQUrVFq)
					{
						XIGmAteYiIRqHFLzwdcVStIcVEDY(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0f;
				}
				if (!TRWrRZebpPhhkadPQvkAELaIUZPd)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!QrlvMAaIbmpXjxdIqBguceacVlND)
				{
					return 0f;
				}
				if (SxXaAJAfPoDKOfgvxNlhugQUrVFq > 1)
				{
					return tnQhfnaUoNWFSttXRarpevpPVaOf[1];
				}
				return 0f;
			}
			set
			{
				if (TRWrRZebpPhhkadPQvkAELaIUZPd)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (QrlvMAaIbmpXjxdIqBguceacVlND && 1 < SxXaAJAfPoDKOfgvxNlhugQUrVFq)
					{
						XIGmAteYiIRqHFLzwdcVStIcVEDY(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return SxXaAJAfPoDKOfgvxNlhugQUrVFq;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return 0;
				}
				return CYaJkVOqLzCdIiSiSjXcYgISURzA;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
				{
					ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return BmrMcYPHbwExlBbzFNEonIkJOUDdA;
			}
		}

		internal int EtFueYsjftfBCOSfOwdxIAFSFqpL => IVsRjstBGeelOxobJMSRfZYbYrcf.inputManagerId;

		internal HardwareControllerMapIdentifier MVIXvXRFIZGrairRwhdIAgMZlsrWA
		{
			get
			{
				if (XRregwEugLWeubJCKxSQAwUDapNP == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return XRregwEugLWeubJCKxSQAwUDapNP.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController P_0)
			: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
		{
			IVsRjstBGeelOxobJMSRfZYbYrcf = P_0.sourceJoystick;
			TRWrRZebpPhhkadPQvkAELaIUZPd = P_0.hw_supportsVibration;
			nOFIxcqcDFtVmEIirEMawoniPrHK = P_0.hw_supportsVoice;
			SxXaAJAfPoDKOfgvxNlhugQUrVFq = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
			if (TRWrRZebpPhhkadPQvkAELaIUZPd && SxXaAJAfPoDKOfgvxNlhugQUrVFq > 0)
			{
				tnQhfnaUoNWFSttXRarpevpPVaOf = new float[SxXaAJAfPoDKOfgvxNlhugQUrVFq];
				WoPSPHhjuPurSqaHbFzpMEnDGJci = new TimerAbs[SxXaAJAfPoDKOfgvxNlhugQUrVFq];
				ArrayTools.Populate(WoPSPHhjuPurSqaHbFzpMEnDGJci, 0, SxXaAJAfPoDKOfgvxNlhugQUrVFq);
				QrlvMAaIbmpXjxdIqBguceacVlND = true;
			}
			if (sfymSjcVHxtWxMcRdJtqvPLgjYLfA != Guid.Empty)
			{
				IList<HardwareJoystickTemplateMap> list = ReInput.MESYpwQOnBfnKRZLJcWinuTHiKJA(sfymSjcVHxtWxMcRdJtqvPLgjYLfA);
				if (list != null)
				{
					List<IControllerTemplate> list2 = null;
					for (int i = 0; i < list.Count; i++)
					{
						HardwareJoystickTemplateMap hardwareJoystickTemplateMap = list[i];
						if (hardwareJoystickTemplateMap == null)
						{
							continue;
						}
						IControllerTemplate controllerTemplate;
						try
						{
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(hardwareJoystickTemplateMap.Guid, new ControllerTemplate.FuaTwFFsfWMPiruAlXyhgAnoRaLH(this, hardwareJoystickTemplateMap));
							if (controllerTemplate == null)
							{
								throw new Exception("Controller Template for guid " + hardwareJoystickTemplateMap.Guid.ToString() + " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?");
							}
						}
						catch (Exception ex)
						{
							Logger.LogErrorEditor(ex.Message);
							continue;
						}
						if (list2 == null)
						{
							list2 = new List<IControllerTemplate>();
						}
						list2.Add(controllerTemplate);
					}
					if (list2 != null)
					{
						RcKgGhVLmceQaZhbgGLMAQtdJoGw(list2.ToArray());
					}
				}
			}
			rHrZhWmlidFfQIdUaELuLMacpKhFA();
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
		{
			if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
			{
				KUuXkRHmIAoEyHJVtDzeaQlrqhduA = new JoystickType[1];
			}
			else
			{
				KUuXkRHmIAoEyHJVtDzeaQlrqhduA = P_9.joystickTypes;
			}
			aAMYntOmPwceMrGimInobVNcNDZz = new ReadOnlyCollection<JoystickType>(KUuXkRHmIAoEyHJVtDzeaQlrqhduA);
			CYaJkVOqLzCdIiSiSjXcYgISURzA = P_9.hatCount;
			KPWabJEnaBbNUyOUfNZAdGBouBDAA = new Hat[CYaJkVOqLzCdIiSiSjXcYgISURzA];
			for (int i = 0; i < CYaJkVOqLzCdIiSiSjXcYgISURzA; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						KPWabJEnaBbNUyOUfNZAdGBouBDAA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
						continue;
					}
					List<Button> list = new List<Button>();
					List<int> list2 = new List<int>();
					for (int j = 0; j < hatData.elementCount; j++)
					{
						int componentElementIdentifierId = hatData.GetComponentElementIdentifierId(j);
						if (!ArrayTools.Contains(P_9.buttonElementIdentifierIds, componentElementIdentifierId))
						{
							list.Add(null);
							list2.Add(-1);
							continue;
						}
						int buttonIndex = P_9.GetButtonIndex(componentElementIdentifierId);
						if (buttonIndex < 0)
						{
							list.Add(null);
							list2.Add(-1);
						}
						else
						{
							list.Add(buttons[buttonIndex]);
							list2.Add(buttonIndex);
						}
					}
					try
					{
						KPWabJEnaBbNUyOUfNZAdGBouBDAA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
						KPWabJEnaBbNUyOUfNZAdGBouBDAA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					}
				}
				finally
				{
					jfCHyspoaXTmfkKJWHiciLsUNkMe(KPWabJEnaBbNUyOUfNZAdGBouBDAA[i]);
				}
			}
			BmrMcYPHbwExlBbzFNEonIkJOUDdA = new ReadOnlyCollection<Hat>(KPWabJEnaBbNUyOUfNZAdGBouBDAA);
		}

		internal bool IsPAaIaWevnotqnNXeasYldHhdWk(JoystickType P_0)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return false;
			}
			int num = KUuXkRHmIAoEyHJVtDzeaQlrqhduA.Length;
			for (int i = 0; i < num; i++)
			{
				if (KUuXkRHmIAoEyHJVtDzeaQlrqhduA[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else
			{
				if (!TRWrRZebpPhhkadPQvkAELaIUZPd)
				{
					return;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: var num } controllerVibrator)
				{
					if (num > 0)
					{
						controllerVibrator.SetVibration(0, leftMotorLevel, leftMotorDuration);
					}
					if (num > 1)
					{
						controllerVibrator.SetVibration(1, rightMotorLevel, rightMotorDuration);
					}
				}
				if (QrlvMAaIbmpXjxdIqBguceacVlND)
				{
					if (SxXaAJAfPoDKOfgvxNlhugQUrVFq > 0)
					{
						XIGmAteYiIRqHFLzwdcVStIcVEDY(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (SxXaAJAfPoDKOfgvxNlhugQUrVFq > 1)
					{
						XIGmAteYiIRqHFLzwdcVStIcVEDY(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					bSjwpLIgjzQskrADAyYdvDCINcUO();
				}
			}
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else if (TRWrRZebpPhhkadPQvkAELaIUZPd && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (QrlvMAaIbmpXjxdIqBguceacVlND && motorIndex < SxXaAJAfPoDKOfgvxNlhugQUrVFq)
				{
					XIGmAteYiIRqHFLzwdcVStIcVEDY(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
				return 0f;
			}
			if (!TRWrRZebpPhhkadPQvkAELaIUZPd || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!QrlvMAaIbmpXjxdIqBguceacVlND)
			{
				return 0f;
			}
			if (motorIndex >= SxXaAJAfPoDKOfgvxNlhugQUrVFq)
			{
				return 0f;
			}
			return tnQhfnaUoNWFSttXRarpevpPVaOf[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != FtWUXMFFyhqCthzgjKfOhWsryipI)
			{
				ReInput.CheckInitialized(FtWUXMFFyhqCthzgjKfOhWsryipI);
			}
			else
			{
				if (!TRWrRZebpPhhkadPQvkAELaIUZPd)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (QrlvMAaIbmpXjxdIqBguceacVlND)
				{
					Array.Clear(tnQhfnaUoNWFSttXRarpevpPVaOf, 0, tnQhfnaUoNWFSttXRarpevpPVaOf.Length);
					for (int i = 0; i < SxXaAJAfPoDKOfgvxNlhugQUrVFq; i++)
					{
						WoPSPHhjuPurSqaHbFzpMEnDGJci[i].Clear();
					}
				}
				if (IVsRjstBGeelOxobJMSRfZYbYrcf != null)
				{
					IVsRjstBGeelOxobJMSRfZYbYrcf.StopVibration();
				}
			}
		}

		internal virtual void NHCOfIuvAUuMlpHSTCxGzVPRFzfi(UpdateLoopType P_0)
		{
			SVeqpnebqgINoIMLuzyySxsVmmWd(P_0);
			for (int i = 0; i < CYaJkVOqLzCdIiSiSjXcYgISURzA; i++)
			{
				if (KPWabJEnaBbNUyOUfNZAdGBouBDAA[i] != null)
				{
					KPWabJEnaBbNUyOUfNZAdGBouBDAA[i].MzwGgvxcdXTkxbOnWZcPZgFWBPVg(P_0, jaSaHPudVtcyecnoPKkgZIAqgGJr);
				}
			}
			goajwkEgDzjiQpaNSnDUrdkegwtt();
		}

		internal void XzSvdbMJroolkHnVGNshOjOwXTXk(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				jqipUlLaxBbxOntKHBsSqrfgiSJG(P_0.sourceJoystick);
			}
		}

		internal void SEtagtKmskjgNLgkgrRkPVYxsBbwA(BridgedController P_0)
		{
			if (P_0 != null)
			{
				jqipUlLaxBbxOntKHBsSqrfgiSJG(P_0.sourceJoystick);
			}
		}

		private void jqipUlLaxBbxOntKHBsSqrfgiSJG(IInputManagerJoystickPublic P_0)
		{
			IVsRjstBGeelOxobJMSRfZYbYrcf = P_0;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					RUfXaFdyAqfECHOzugcKayQiDLrw(P_0.extension);
				}
				else
				{
					DInnNpiFkzKPZEpYlRYtYfItQoMc(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal virtual void HgZkxsEGEseZGEhKWgQDyQHYOlOu()
		{
			ankcONBsyjJMRKuhOFZSQbGRfwHsA();
			StopVibration();
		}

		internal virtual void LfIdxGBcLLKaskFOvJrzCkodiaRkA(bool P_0)
		{
			base.kmaQpzOvBKrdjELpnQNLefZBEXTR(P_0);
			if (!P_0 && !ReInput.applicationRunInBackground)
			{
				StopVibration();
			}
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (QrlvMAaIbmpXjxdIqBguceacVlND)
			{
				Array.Clear(tnQhfnaUoNWFSttXRarpevpPVaOf, 0, tnQhfnaUoNWFSttXRarpevpPVaOf.Length);
				for (int i = 0; i < SxXaAJAfPoDKOfgvxNlhugQUrVFq; i++)
				{
					WoPSPHhjuPurSqaHbFzpMEnDGJci[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void goajwkEgDzjiQpaNSnDUrdkegwtt()
		{
			if (!TRWrRZebpPhhkadPQvkAELaIUZPd || !QrlvMAaIbmpXjxdIqBguceacVlND)
			{
				return;
			}
			for (int i = 0; i < SxXaAJAfPoDKOfgvxNlhugQUrVFq; i++)
			{
				if (WoPSPHhjuPurSqaHbFzpMEnDGJci[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void XIGmAteYiIRqHFLzwdcVStIcVEDY(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!QrlvMAaIbmpXjxdIqBguceacVlND || P_0 < 0 || P_0 >= SxXaAJAfPoDKOfgvxNlhugQUrVFq)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(tnQhfnaUoNWFSttXRarpevpPVaOf, 0, tnQhfnaUoNWFSttXRarpevpPVaOf.Length);
				for (int i = 0; i < SxXaAJAfPoDKOfgvxNlhugQUrVFq; i++)
				{
					WoPSPHhjuPurSqaHbFzpMEnDGJci[i].Clear();
				}
			}
			tnQhfnaUoNWFSttXRarpevpPVaOf[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				WoPSPHhjuPurSqaHbFzpMEnDGJci[P_0].Clear();
			}
			else
			{
				WoPSPHhjuPurSqaHbFzpMEnDGJci[P_0].Start(P_2);
			}
			if (P_4)
			{
				bSjwpLIgjzQskrADAyYdvDCINcUO();
			}
		}

		private void bSjwpLIgjzQskrADAyYdvDCINcUO()
		{
			if (TRWrRZebpPhhkadPQvkAELaIUZPd && QrlvMAaIbmpXjxdIqBguceacVlND && IVsRjstBGeelOxobJMSRfZYbYrcf != null)
			{
				for (int i = 0; i < tnQhfnaUoNWFSttXRarpevpPVaOf.Length; i++)
				{
					IVsRjstBGeelOxobJMSRfZYbYrcf.SetVibration(tnQhfnaUoNWFSttXRarpevpPVaOf[i], i);
				}
			}
		}

		private void DiRgslFvYqEGzTWNvQvLoSjakHKeA()
		{
		}

		internal static int ftXXApYEgGdVSoRHnPUWfbgwOPoT(Joystick P_0, Joystick P_1)
		{
			if (P_0.EtFueYsjftfBCOSfOwdxIAFSFqpL < P_1.EtFueYsjftfBCOSfOwdxIAFSFqpL)
			{
				return -1;
			}
			if (P_0.EtFueYsjftfBCOSfOwdxIAFSFqpL > P_1.EtFueYsjftfBCOSfOwdxIAFSFqpL)
			{
				return 1;
			}
			return 0;
		}
	}
}
