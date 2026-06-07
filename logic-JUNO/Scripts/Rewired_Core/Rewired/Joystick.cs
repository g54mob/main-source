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
		private const int zHtantvtHzbkMdwTihwzbYUcbXvkA = 0;

		private const int OLYulxcwOLZQGKIYQEvkVcFPfrUKA = 1;

		private IInputManagerJoystickPublic AplOQouHnUScLdypvhSMLekkmwKd;

		private readonly JoystickType[] WojklLUGLyZfrLzKDcShivTelJJO;

		private readonly ReadOnlyCollection<JoystickType> sTBhefBJIUpFTrevGJEnhBtrefngA;

		private readonly bool ToZsiDtcuhaKfkQeeCWRwrzTcilgA;

		private readonly bool QNkmPErhHGhCazfsSZulEPAzarxfA;

		private readonly bool fiMBewtEVvCznCzuLndvKVIbvBff;

		private readonly int CAAjNRXYMAzZHdkKHOIcWcyXffrj;

		private readonly float[] fkJuYlzpPlhpJtxstXjcANJCvksi;

		private readonly TimerAbs[] IlGcTRmNlhYHHmDEFgecGmTSXwYKA;

		private readonly int KfbOXqFupJzzgeELIWfYeESVJwlS;

		private readonly Hat[] YSLMkVwJjvFkLKaFNdqNEavfEzzdb;

		private readonly ReadOnlyCollection<Hat> BIiahOgSmUMKiIjonvflHwChOifEB;

		internal IList<JoystickType> ZqQinQUvCPptjMvYuKlOathdsqlu
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return sTBhefBJIUpFTrevGJEnhBtrefngA;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return -1L;
				}
				return AplOQouHnUScLdypvhSMLekkmwKd.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return -1;
				}
				return AplOQouHnUScLdypvhSMLekkmwKd.unityId;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return Guid.Empty;
				}
				return AplOQouHnUScLdypvhSMLekkmwKd.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return false;
				}
				return ToZsiDtcuhaKfkQeeCWRwrzTcilgA;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0f;
				}
				if (!ToZsiDtcuhaKfkQeeCWRwrzTcilgA)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!QNkmPErhHGhCazfsSZulEPAzarxfA)
				{
					return 0f;
				}
				if (CAAjNRXYMAzZHdkKHOIcWcyXffrj > 0)
				{
					return fkJuYlzpPlhpJtxstXjcANJCvksi[0];
				}
				return 0f;
			}
			set
			{
				if (ToZsiDtcuhaKfkQeeCWRwrzTcilgA)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (QNkmPErhHGhCazfsSZulEPAzarxfA && 0 < CAAjNRXYMAzZHdkKHOIcWcyXffrj)
					{
						XfBbTzgdhwCJKuBkKZNWOiwdTgrfA(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0f;
				}
				if (!ToZsiDtcuhaKfkQeeCWRwrzTcilgA)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!QNkmPErhHGhCazfsSZulEPAzarxfA)
				{
					return 0f;
				}
				if (CAAjNRXYMAzZHdkKHOIcWcyXffrj > 1)
				{
					return fkJuYlzpPlhpJtxstXjcANJCvksi[1];
				}
				return 0f;
			}
			set
			{
				if (ToZsiDtcuhaKfkQeeCWRwrzTcilgA)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (QNkmPErhHGhCazfsSZulEPAzarxfA && 1 < CAAjNRXYMAzZHdkKHOIcWcyXffrj)
					{
						XfBbTzgdhwCJKuBkKZNWOiwdTgrfA(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return CAAjNRXYMAzZHdkKHOIcWcyXffrj;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0;
				}
				return KfbOXqFupJzzgeELIWfYeESVJwlS;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return BIiahOgSmUMKiIjonvflHwChOifEB;
			}
		}

		internal int MZCtZEbowVIlBMcZsRjgaqpVzpNg => AplOQouHnUScLdypvhSMLekkmwKd.inputManagerId;

		internal HardwareControllerMapIdentifier WYDKuDMKHxTQphWMOKOFEJkODYZEA
		{
			get
			{
				if (NOuTtyJvdlwLlfoBgXbDwbqIGPrIA == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController P_0)
			: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
		{
			AplOQouHnUScLdypvhSMLekkmwKd = P_0.sourceJoystick;
			ToZsiDtcuhaKfkQeeCWRwrzTcilgA = P_0.hw_supportsVibration;
			fiMBewtEVvCznCzuLndvKVIbvBff = P_0.hw_supportsVoice;
			CAAjNRXYMAzZHdkKHOIcWcyXffrj = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
			if (ToZsiDtcuhaKfkQeeCWRwrzTcilgA && CAAjNRXYMAzZHdkKHOIcWcyXffrj > 0)
			{
				fkJuYlzpPlhpJtxstXjcANJCvksi = new float[CAAjNRXYMAzZHdkKHOIcWcyXffrj];
				IlGcTRmNlhYHHmDEFgecGmTSXwYKA = new TimerAbs[CAAjNRXYMAzZHdkKHOIcWcyXffrj];
				ArrayTools.Populate(IlGcTRmNlhYHHmDEFgecGmTSXwYKA, 0, CAAjNRXYMAzZHdkKHOIcWcyXffrj);
				QNkmPErhHGhCazfsSZulEPAzarxfA = true;
			}
			if (gLbADvCdALkEcLIQPhWpjDrhhunKA != Guid.Empty)
			{
				IList<HardwareJoystickTemplateMap> list = ReInput.UUHFzppCZFYByNjKfJCDPBOGIIgQ(gLbADvCdALkEcLIQPhWpjDrhhunKA);
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
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(hardwareJoystickTemplateMap.Guid, new ControllerTemplate.JXzIHZYknkrhttLCHgUaUJTpbmvd(this, hardwareJoystickTemplateMap));
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
						FJbdfSohWJVrPumACiZyeTmvMgo(list2.ToArray());
					}
				}
			}
			blqnoKjqhVSIFnqRKLejmqEtdoFaA();
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
		{
			if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
			{
				WojklLUGLyZfrLzKDcShivTelJJO = new JoystickType[1];
			}
			else
			{
				WojklLUGLyZfrLzKDcShivTelJJO = P_9.joystickTypes;
			}
			sTBhefBJIUpFTrevGJEnhBtrefngA = new ReadOnlyCollection<JoystickType>(WojklLUGLyZfrLzKDcShivTelJJO);
			KfbOXqFupJzzgeELIWfYeESVJwlS = P_9.hatCount;
			YSLMkVwJjvFkLKaFNdqNEavfEzzdb = new Hat[KfbOXqFupJzzgeELIWfYeESVJwlS];
			for (int i = 0; i < KfbOXqFupJzzgeELIWfYeESVJwlS; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						YSLMkVwJjvFkLKaFNdqNEavfEzzdb[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
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
						YSLMkVwJjvFkLKaFNdqNEavfEzzdb[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
						YSLMkVwJjvFkLKaFNdqNEavfEzzdb[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					}
				}
				finally
				{
					bLPAYawLrzGccouFaIolYrjFjlkO(YSLMkVwJjvFkLKaFNdqNEavfEzzdb[i]);
				}
			}
			BIiahOgSmUMKiIjonvflHwChOifEB = new ReadOnlyCollection<Hat>(YSLMkVwJjvFkLKaFNdqNEavfEzzdb);
		}

		internal bool UGgBCkrbPQGaKqOnODjOuBCKLwyA(JoystickType P_0)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int num = WojklLUGLyZfrLzKDcShivTelJJO.Length;
			for (int i = 0; i < num; i++)
			{
				if (WojklLUGLyZfrLzKDcShivTelJJO[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else
			{
				if (!ToZsiDtcuhaKfkQeeCWRwrzTcilgA)
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
				if (QNkmPErhHGhCazfsSZulEPAzarxfA)
				{
					if (CAAjNRXYMAzZHdkKHOIcWcyXffrj > 0)
					{
						XfBbTzgdhwCJKuBkKZNWOiwdTgrfA(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (CAAjNRXYMAzZHdkKHOIcWcyXffrj > 1)
					{
						XfBbTzgdhwCJKuBkKZNWOiwdTgrfA(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					lVyGcBPEmNqRxzaEcwvsXGiLtYyR();
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else if (ToZsiDtcuhaKfkQeeCWRwrzTcilgA && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (QNkmPErhHGhCazfsSZulEPAzarxfA && motorIndex < CAAjNRXYMAzZHdkKHOIcWcyXffrj)
				{
					XfBbTzgdhwCJKuBkKZNWOiwdTgrfA(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0f;
			}
			if (!ToZsiDtcuhaKfkQeeCWRwrzTcilgA || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!QNkmPErhHGhCazfsSZulEPAzarxfA)
			{
				return 0f;
			}
			if (motorIndex >= CAAjNRXYMAzZHdkKHOIcWcyXffrj)
			{
				return 0f;
			}
			return fkJuYlzpPlhpJtxstXjcANJCvksi[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
			}
			else
			{
				if (!ToZsiDtcuhaKfkQeeCWRwrzTcilgA)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (QNkmPErhHGhCazfsSZulEPAzarxfA)
				{
					Array.Clear(fkJuYlzpPlhpJtxstXjcANJCvksi, 0, fkJuYlzpPlhpJtxstXjcANJCvksi.Length);
					for (int i = 0; i < CAAjNRXYMAzZHdkKHOIcWcyXffrj; i++)
					{
						IlGcTRmNlhYHHmDEFgecGmTSXwYKA[i].Clear();
					}
				}
				if (AplOQouHnUScLdypvhSMLekkmwKd != null)
				{
					AplOQouHnUScLdypvhSMLekkmwKd.StopVibration();
				}
			}
		}

		internal virtual void VJVCClZBoFzsnNDdhUTDtDUdLDC(UpdateLoopType P_0)
		{
			KcxabjhCuUxlxWHNCxIliMVWtSiM(P_0);
			for (int i = 0; i < KfbOXqFupJzzgeELIWfYeESVJwlS; i++)
			{
				if (YSLMkVwJjvFkLKaFNdqNEavfEzzdb[i] != null)
				{
					YSLMkVwJjvFkLKaFNdqNEavfEzzdb[i].UFbBRfchsdvuuneJoAcEJrzVqrlGb(P_0, rGVdhXruOTgLzoPtrwxfhKmroixX);
				}
			}
			qzHekPXMXgINWdSohUXxPSjvWXmA();
		}

		internal void FtXHkhBMwEbMbDPMsuoggYajIttx(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				zMfbszOhmlESTDjVxmsVISFhiEpnA(P_0.sourceJoystick);
			}
		}

		internal void EYikrxpnfSNNWknzAmyvpicqVjFt(BridgedController P_0)
		{
			if (P_0 != null)
			{
				zMfbszOhmlESTDjVxmsVISFhiEpnA(P_0.sourceJoystick);
			}
		}

		private void zMfbszOhmlESTDjVxmsVISFhiEpnA(IInputManagerJoystickPublic P_0)
		{
			AplOQouHnUScLdypvhSMLekkmwKd = P_0;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					JoyknPwzFMFtLFLmSnRJMZwhojDP(P_0.extension);
				}
				else
				{
					TfqwmlxgOXgbWEQiRooFmIJsIcEz(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal virtual void RjAdeuXeDQkhZEJJipGYMjjVDccl()
		{
			eQlPXXtIjTBbUuFweKqVJFyUmYbL();
			StopVibration();
		}

		internal virtual void VBPiQUjMtHvlaUXFjCuwKWaWHfl(bool P_0)
		{
			base.kPvFlhTMbqOrsGoGXbaCUFtGvwxE(P_0);
			if (!P_0 && !ReInput.applicationRunInBackground)
			{
				StopVibration();
			}
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (QNkmPErhHGhCazfsSZulEPAzarxfA)
			{
				Array.Clear(fkJuYlzpPlhpJtxstXjcANJCvksi, 0, fkJuYlzpPlhpJtxstXjcANJCvksi.Length);
				for (int i = 0; i < CAAjNRXYMAzZHdkKHOIcWcyXffrj; i++)
				{
					IlGcTRmNlhYHHmDEFgecGmTSXwYKA[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void qzHekPXMXgINWdSohUXxPSjvWXmA()
		{
			if (!ToZsiDtcuhaKfkQeeCWRwrzTcilgA || !QNkmPErhHGhCazfsSZulEPAzarxfA)
			{
				return;
			}
			for (int i = 0; i < CAAjNRXYMAzZHdkKHOIcWcyXffrj; i++)
			{
				if (IlGcTRmNlhYHHmDEFgecGmTSXwYKA[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void XfBbTzgdhwCJKuBkKZNWOiwdTgrfA(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!QNkmPErhHGhCazfsSZulEPAzarxfA || P_0 < 0 || P_0 >= CAAjNRXYMAzZHdkKHOIcWcyXffrj)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(fkJuYlzpPlhpJtxstXjcANJCvksi, 0, fkJuYlzpPlhpJtxstXjcANJCvksi.Length);
				for (int i = 0; i < CAAjNRXYMAzZHdkKHOIcWcyXffrj; i++)
				{
					IlGcTRmNlhYHHmDEFgecGmTSXwYKA[i].Clear();
				}
			}
			fkJuYlzpPlhpJtxstXjcANJCvksi[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				IlGcTRmNlhYHHmDEFgecGmTSXwYKA[P_0].Clear();
			}
			else
			{
				IlGcTRmNlhYHHmDEFgecGmTSXwYKA[P_0].Start(P_2);
			}
			if (P_4)
			{
				lVyGcBPEmNqRxzaEcwvsXGiLtYyR();
			}
		}

		private void lVyGcBPEmNqRxzaEcwvsXGiLtYyR()
		{
			if (ToZsiDtcuhaKfkQeeCWRwrzTcilgA && QNkmPErhHGhCazfsSZulEPAzarxfA && AplOQouHnUScLdypvhSMLekkmwKd != null)
			{
				for (int i = 0; i < fkJuYlzpPlhpJtxstXjcANJCvksi.Length; i++)
				{
					AplOQouHnUScLdypvhSMLekkmwKd.SetVibration(fkJuYlzpPlhpJtxstXjcANJCvksi[i], i);
				}
			}
		}

		private void VbAQvpaoHYjrqSvIFyUUqRZvtfkw()
		{
		}

		internal static int jWCAdlZlNkwPBoECLxmLBEvfnIId(Joystick P_0, Joystick P_1)
		{
			if (P_0.MZCtZEbowVIlBMcZsRjgaqpVzpNg < P_1.MZCtZEbowVIlBMcZsRjgaqpVzpNg)
			{
				return -1;
			}
			if (P_0.MZCtZEbowVIlBMcZsRjgaqpVzpNg > P_1.MZCtZEbowVIlBMcZsRjgaqpVzpNg)
			{
				return 1;
			}
			return 0;
		}
	}
}
