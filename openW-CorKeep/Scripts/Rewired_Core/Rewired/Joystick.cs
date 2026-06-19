using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired
{
	public class Joystick : ControllerWithAxes
	{
		private const int hWfBnSPofOUdUdaniFlrQrLEiowaA = 0;

		private const int IYEhBUSCqmfYAZDoSBmoiLCtTAPJA = 1;

		private IInputManagerJoystickPublic YOnsSFOclnGBDFuKbIiYbFdaMBFqB;

		private readonly JoystickType[] QpSjkdmdPhgvSSkZoHjgyQOzwSZ;

		private readonly ReadOnlyCollection<JoystickType> ggLqOSxkizADEwRkMXxstsHVEgoB;

		private readonly bool PNZEwgVmGACLpajSsIBPNeexSRoQA;

		private readonly bool QokgwpZEvnWNquAAWtpzOrHPlIuv;

		private readonly bool vVCPXPTfeCTJbRZHBGufOPGRqSiU;

		private readonly int MLAenslustnkTemKBbRkhGlvVCeWA;

		private readonly float[] rQBSyYDcdWosRoLInNOqIJIcyUtT;

		private readonly TimerAbs[] OrYZTyIxRWDQNzcaPsdkoFKwxLVn;

		private readonly int CFhvUFzIBojoyDllAKXEqNVreLoiA;

		private readonly Hat[] YnNmSaEJZChMVRgfZfVDwdgPGZsh;

		private readonly ReadOnlyCollection<Hat> FwkBjlyUEbAZkgiKrEyxwMTmlJcY;

		private readonly int QpNvPbTPDJegsGHPaHVoBuZFuhBSB;

		private readonly DirectionalPad[] eYKbpfaKCNTekvvdHLcWUSomCDaPA;

		private readonly ReadOnlyCollection<DirectionalPad> tVEwzkNRGJcxYHYjuiSNBnSPgNmkA;

		internal IList<JoystickType> FEKbnJymnikfjNsMweCqeaPTViqB
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return ggLqOSxkizADEwRkMXxstsHVEgoB;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return -1L;
				}
				return YOnsSFOclnGBDFuKbIiYbFdaMBFqB.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return -1;
				}
				return YOnsSFOclnGBDFuKbIiYbFdaMBFqB.unityId;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return Guid.Empty;
				}
				return YOnsSFOclnGBDFuKbIiYbFdaMBFqB.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return false;
				}
				return PNZEwgVmGACLpajSsIBPNeexSRoQA;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0f;
				}
				if (!PNZEwgVmGACLpajSsIBPNeexSRoQA)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!QokgwpZEvnWNquAAWtpzOrHPlIuv)
				{
					return 0f;
				}
				if (MLAenslustnkTemKBbRkhGlvVCeWA > 0)
				{
					return rQBSyYDcdWosRoLInNOqIJIcyUtT[0];
				}
				return 0f;
			}
			set
			{
				if (PNZEwgVmGACLpajSsIBPNeexSRoQA)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (QokgwpZEvnWNquAAWtpzOrHPlIuv && 0 < MLAenslustnkTemKBbRkhGlvVCeWA)
					{
						NuZdBOZqXPLKKQCOCoUQypjDcTmQ(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0f;
				}
				if (!PNZEwgVmGACLpajSsIBPNeexSRoQA)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!QokgwpZEvnWNquAAWtpzOrHPlIuv)
				{
					return 0f;
				}
				if (MLAenslustnkTemKBbRkhGlvVCeWA > 1)
				{
					return rQBSyYDcdWosRoLInNOqIJIcyUtT[1];
				}
				return 0f;
			}
			set
			{
				if (PNZEwgVmGACLpajSsIBPNeexSRoQA)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (QokgwpZEvnWNquAAWtpzOrHPlIuv && 1 < MLAenslustnkTemKBbRkhGlvVCeWA)
					{
						NuZdBOZqXPLKKQCOCoUQypjDcTmQ(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return MLAenslustnkTemKBbRkhGlvVCeWA;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0;
				}
				return CFhvUFzIBojoyDllAKXEqNVreLoiA;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return FwkBjlyUEbAZkgiKrEyxwMTmlJcY;
			}
		}

		public int directionalPadCount
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return 0;
				}
				return QpNvPbTPDJegsGHPaHVoBuZFuhBSB;
			}
		}

		public IList<DirectionalPad> DirectionalPads
		{
			get
			{
				if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
				{
					ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
					return EmptyObjects<DirectionalPad>.EmptyReadOnlyIListT;
				}
				return tVEwzkNRGJcxYHYjuiSNBnSPgNmkA;
			}
		}

		internal int AlMUvvTnIgrTRXyrwbEgurgdFIKr => YOnsSFOclnGBDFuKbIiYbFdaMBFqB.inputManagerId;

		internal HardwareControllerMapIdentifier YLCwakRxQZFrcauCaNHIKvwulUt
		{
			get
			{
				if (LJmpCFrENABMhmUxmGaTconkDyoGA == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return LJmpCFrENABMhmUxmGaTconkDyoGA.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController P_0)
			: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
		{
			YOnsSFOclnGBDFuKbIiYbFdaMBFqB = P_0.sourceJoystick;
			base.JjQEFVsgxnuheoCTguBsKAhENLgh = YOnsSFOclnGBDFuKbIiYbFdaMBFqB as ITryGetLocalizedName;
			PNZEwgVmGACLpajSsIBPNeexSRoQA = P_0.hw_supportsVibration;
			vVCPXPTfeCTJbRZHBGufOPGRqSiU = P_0.hw_supportsVoice;
			MLAenslustnkTemKBbRkhGlvVCeWA = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
			if (PNZEwgVmGACLpajSsIBPNeexSRoQA && MLAenslustnkTemKBbRkhGlvVCeWA > 0)
			{
				rQBSyYDcdWosRoLInNOqIJIcyUtT = new float[MLAenslustnkTemKBbRkhGlvVCeWA];
				OrYZTyIxRWDQNzcaPsdkoFKwxLVn = new TimerAbs[MLAenslustnkTemKBbRkhGlvVCeWA];
				ArrayTools.Populate(OrYZTyIxRWDQNzcaPsdkoFKwxLVn, 0, MLAenslustnkTemKBbRkhGlvVCeWA);
				QokgwpZEvnWNquAAWtpzOrHPlIuv = true;
			}
			if (savDJAJJykdFgIDmPSBdENeZaLumA != Guid.Empty)
			{
				IList<TOvbXCLGpcDMwICKloBsHgxZNTif> list = ReInput.OUHXRYZNzefNueQwdNMNXXZgdxrCA(savDJAJJykdFgIDmPSBdENeZaLumA);
				if (list != null)
				{
					List<IControllerTemplate> list2 = null;
					for (int i = 0; i < list.Count; i++)
					{
						TOvbXCLGpcDMwICKloBsHgxZNTif tOvbXCLGpcDMwICKloBsHgxZNTif = list[i];
						if (tOvbXCLGpcDMwICKloBsHgxZNTif == null)
						{
							continue;
						}
						IControllerTemplate controllerTemplate;
						try
						{
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(tOvbXCLGpcDMwICKloBsHgxZNTif.HRXSQfuoydCyPEFyrRKihBvmprmo, new ControllerTemplate.BkhfCqorSBgitkHzZknmENKJVMyO(this, tOvbXCLGpcDMwICKloBsHgxZNTif));
							if (controllerTemplate == null)
							{
								throw new Exception("Controller Template for guid " + tOvbXCLGpcDMwICKloBsHgxZNTif.HRXSQfuoydCyPEFyrRKihBvmprmo.ToString() + " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?");
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
						RzHJhWabHbaSteSMOQrRDwKIMbbdA(list2.ToArray());
					}
				}
			}
			vXguOrVHQgZdRgenIvihyjDDIBEO();
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
		{
			if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
			{
				QpSjkdmdPhgvSSkZoHjgyQOzwSZ = new JoystickType[1];
			}
			else
			{
				QpSjkdmdPhgvSSkZoHjgyQOzwSZ = P_9.joystickTypes;
			}
			ggLqOSxkizADEwRkMXxstsHVEgoB = new ReadOnlyCollection<JoystickType>(QpSjkdmdPhgvSSkZoHjgyQOzwSZ);
			CFhvUFzIBojoyDllAKXEqNVreLoiA = P_9.hatCount;
			YnNmSaEJZChMVRgfZfVDwdgPGZsh = new Hat[CFhvUFzIBojoyDllAKXEqNVreLoiA];
			for (int i = 0; i < CFhvUFzIBojoyDllAKXEqNVreLoiA; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						YnNmSaEJZChMVRgfZfVDwdgPGZsh[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
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
						YnNmSaEJZChMVRgfZfVDwdgPGZsh[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
						YnNmSaEJZChMVRgfZfVDwdgPGZsh[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					}
				}
				finally
				{
					byDDQTFCPCzrcWthyknzdKcxrYzZ(YnNmSaEJZChMVRgfZfVDwdgPGZsh[i]);
				}
			}
			FwkBjlyUEbAZkgiKrEyxwMTmlJcY = new ReadOnlyCollection<Hat>(YnNmSaEJZChMVRgfZfVDwdgPGZsh);
			QpNvPbTPDJegsGHPaHVoBuZFuhBSB = P_9.dpadCount;
			eYKbpfaKCNTekvvdHLcWUSomCDaPA = new DirectionalPad[QpNvPbTPDJegsGHPaHVoBuZFuhBSB];
			for (int k = 0; k < QpNvPbTPDJegsGHPaHVoBuZFuhBSB; k++)
			{
				HardwareJoystickMap.CompoundElement dPadData = P_9.GetDPadData(k);
				try
				{
					if (dPadData == null)
					{
						Logger.LogError("Error creating D-Pad from hardware map! CompoundElement is null!");
						eYKbpfaKCNTekvvdHLcWUSomCDaPA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
						continue;
					}
					List<Button> list3 = new List<Button>();
					List<int> list4 = new List<int>();
					for (int l = 0; l < dPadData.elementCount; l++)
					{
						int componentElementIdentifierId2 = dPadData.GetComponentElementIdentifierId(l);
						if (!ArrayTools.Contains(P_9.buttonElementIdentifierIds, componentElementIdentifierId2))
						{
							list3.Add(null);
							list4.Add(-1);
							continue;
						}
						int buttonIndex2 = P_9.GetButtonIndex(componentElementIdentifierId2);
						if (buttonIndex2 < 0)
						{
							list3.Add(null);
							list4.Add(-1);
						}
						else
						{
							list3.Add(buttons[buttonIndex2]);
							list4.Add(buttonIndex2);
						}
					}
					try
					{
						eYKbpfaKCNTekvvdHLcWUSomCDaPA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, list3.ToArray(), list4.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating D-Pad from hardware map! Exception thrown when creating D-Pad.");
						eYKbpfaKCNTekvvdHLcWUSomCDaPA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
					}
				}
				finally
				{
					byDDQTFCPCzrcWthyknzdKcxrYzZ(eYKbpfaKCNTekvvdHLcWUSomCDaPA[k]);
				}
			}
			tVEwzkNRGJcxYHYjuiSNBnSPgNmkA = new ReadOnlyCollection<DirectionalPad>(eYKbpfaKCNTekvvdHLcWUSomCDaPA);
		}

		internal bool WLMKJtRjRatHetQsbdWfctYeiQxJ(JoystickType P_0)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return false;
			}
			int num = QpSjkdmdPhgvSSkZoHjgyQOzwSZ.Length;
			for (int i = 0; i < num; i++)
			{
				if (QpSjkdmdPhgvSSkZoHjgyQOzwSZ[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else
			{
				if (!PNZEwgVmGACLpajSsIBPNeexSRoQA)
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
				if (QokgwpZEvnWNquAAWtpzOrHPlIuv)
				{
					if (MLAenslustnkTemKBbRkhGlvVCeWA > 0)
					{
						NuZdBOZqXPLKKQCOCoUQypjDcTmQ(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (MLAenslustnkTemKBbRkhGlvVCeWA > 1)
					{
						NuZdBOZqXPLKKQCOCoUQypjDcTmQ(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					ljiomptAjsUznqkqgqgOVterxabd();
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
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else if (PNZEwgVmGACLpajSsIBPNeexSRoQA && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (QokgwpZEvnWNquAAWtpzOrHPlIuv && motorIndex < MLAenslustnkTemKBbRkhGlvVCeWA)
				{
					NuZdBOZqXPLKKQCOCoUQypjDcTmQ(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
				return 0f;
			}
			if (!PNZEwgVmGACLpajSsIBPNeexSRoQA || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!QokgwpZEvnWNquAAWtpzOrHPlIuv)
			{
				return 0f;
			}
			if (motorIndex >= MLAenslustnkTemKBbRkhGlvVCeWA)
			{
				return 0f;
			}
			return rQBSyYDcdWosRoLInNOqIJIcyUtT[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != ZnRkLjoJZaBEcsqDJEgTJYVKjsWl)
			{
				ReInput.CheckInitialized(ZnRkLjoJZaBEcsqDJEgTJYVKjsWl);
			}
			else
			{
				if (!PNZEwgVmGACLpajSsIBPNeexSRoQA)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (QokgwpZEvnWNquAAWtpzOrHPlIuv)
				{
					Array.Clear(rQBSyYDcdWosRoLInNOqIJIcyUtT, 0, rQBSyYDcdWosRoLInNOqIJIcyUtT.Length);
					for (int i = 0; i < MLAenslustnkTemKBbRkhGlvVCeWA; i++)
					{
						OrYZTyIxRWDQNzcaPsdkoFKwxLVn[i].Clear();
					}
				}
				if (YOnsSFOclnGBDFuKbIiYbFdaMBFqB != null)
				{
					YOnsSFOclnGBDFuKbIiYbFdaMBFqB.StopVibration();
				}
			}
		}

		internal virtual void XwDjLxVKlXhYwsIpvkmJFmicLUYP(UpdateLoopType P_0)
		{
			OJfGzCVGKpDcleZnYjZrjqAkLxdVA(P_0);
			for (int i = 0; i < CFhvUFzIBojoyDllAKXEqNVreLoiA; i++)
			{
				if (YnNmSaEJZChMVRgfZfVDwdgPGZsh[i] != null)
				{
					YnNmSaEJZChMVRgfZfVDwdgPGZsh[i].UgddLAdEAQEziMqjonbAtbqlnGmIb(P_0, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
				}
			}
			for (int j = 0; j < QpNvPbTPDJegsGHPaHVoBuZFuhBSB; j++)
			{
				if (eYKbpfaKCNTekvvdHLcWUSomCDaPA[j] != null)
				{
					eYKbpfaKCNTekvvdHLcWUSomCDaPA[j].yuJSFlCtrohfJQsZVSpSHQkfnHWN(P_0, zfVdfqKDuqZKjafBdqgdinjRQNeGb);
				}
			}
			aSzJmTlgeyGJHagaiaFFaXPDDbEyb();
		}

		internal void LhNaCDtQBlFhlOmjcxEuebnJKMyh(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				xRpAqOCySAaRZouzzblBqIUVovimA(P_0.sourceJoystick);
			}
		}

		internal void IcncIVaTpJCUlQRYUlrjJjSEQQCA(BridgedController P_0)
		{
			if (P_0 != null)
			{
				xRpAqOCySAaRZouzzblBqIUVovimA(P_0.sourceJoystick);
			}
		}

		private void xRpAqOCySAaRZouzzblBqIUVovimA(IInputManagerJoystickPublic P_0)
		{
			YOnsSFOclnGBDFuKbIiYbFdaMBFqB = P_0;
			base.JjQEFVsgxnuheoCTguBsKAhENLgh = P_0 as ITryGetLocalizedName;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					PyspqJSprRuFBGASUIFHApFkWWbA(P_0.extension);
				}
				else
				{
					DZmGiQIHoiKqUDJAaBfHOkGkWHHvB(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal virtual void HxYnvZryrlHzHRyncfaQGKktJyvm()
		{
			cXfFDiJKTugPYjySyrZDVWvcbgyj();
			StopVibration();
		}

		internal virtual void XbFMivaDwWVcnvzrTgJmuhPIorgr(bool P_0)
		{
			base.crbQLMpBgFCTkCHGXdkEoAiefEsyA(P_0);
			if (!P_0 && !ReInput.applicationRunInBackground)
			{
				StopVibration();
			}
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (QokgwpZEvnWNquAAWtpzOrHPlIuv)
			{
				Array.Clear(rQBSyYDcdWosRoLInNOqIJIcyUtT, 0, rQBSyYDcdWosRoLInNOqIJIcyUtT.Length);
				for (int i = 0; i < MLAenslustnkTemKBbRkhGlvVCeWA; i++)
				{
					OrYZTyIxRWDQNzcaPsdkoFKwxLVn[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void aSzJmTlgeyGJHagaiaFFaXPDDbEyb()
		{
			if (!PNZEwgVmGACLpajSsIBPNeexSRoQA || !QokgwpZEvnWNquAAWtpzOrHPlIuv)
			{
				return;
			}
			for (int i = 0; i < MLAenslustnkTemKBbRkhGlvVCeWA; i++)
			{
				if (OrYZTyIxRWDQNzcaPsdkoFKwxLVn[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void NuZdBOZqXPLKKQCOCoUQypjDcTmQ(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!QokgwpZEvnWNquAAWtpzOrHPlIuv || P_0 < 0 || P_0 >= MLAenslustnkTemKBbRkhGlvVCeWA)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(rQBSyYDcdWosRoLInNOqIJIcyUtT, 0, rQBSyYDcdWosRoLInNOqIJIcyUtT.Length);
				for (int i = 0; i < MLAenslustnkTemKBbRkhGlvVCeWA; i++)
				{
					OrYZTyIxRWDQNzcaPsdkoFKwxLVn[i].Clear();
				}
			}
			rQBSyYDcdWosRoLInNOqIJIcyUtT[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				OrYZTyIxRWDQNzcaPsdkoFKwxLVn[P_0].Clear();
			}
			else
			{
				OrYZTyIxRWDQNzcaPsdkoFKwxLVn[P_0].Start(P_2);
			}
			if (P_4)
			{
				ljiomptAjsUznqkqgqgOVterxabd();
			}
		}

		private void ljiomptAjsUznqkqgqgOVterxabd()
		{
			if (PNZEwgVmGACLpajSsIBPNeexSRoQA && QokgwpZEvnWNquAAWtpzOrHPlIuv && YOnsSFOclnGBDFuKbIiYbFdaMBFqB != null)
			{
				for (int i = 0; i < rQBSyYDcdWosRoLInNOqIJIcyUtT.Length; i++)
				{
					YOnsSFOclnGBDFuKbIiYbFdaMBFqB.SetVibration(rQBSyYDcdWosRoLInNOqIJIcyUtT[i], i);
				}
			}
		}

		private void LvUpLKWhBbaPkPgQBNdEgWpVKxdD()
		{
		}

		internal static int dIAeAKtMNNvvJzlcRCiRITZPdWRXA(Joystick P_0, Joystick P_1)
		{
			if (P_0.AlMUvvTnIgrTRXyrwbEgurgdFIKr < P_1.AlMUvvTnIgrTRXyrwbEgurgdFIKr)
			{
				return -1;
			}
			if (P_0.AlMUvvTnIgrTRXyrwbEgurgdFIKr > P_1.AlMUvvTnIgrTRXyrwbEgurgdFIKr)
			{
				return 1;
			}
			return 0;
		}
	}
}
