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
		private const int AxLEjipGhWsenhEmPSUxFivTjTxe = 0;

		private const int poeQavyfDiZilNRDvXZwOtwoNdQh = 1;

		private IInputManagerJoystickPublic jJFXbiiTKdLKwmRtKNFKUzQXOQCK;

		private readonly JoystickType[] neVQSDEjCJnTWMvXgyAplExTHzDT;

		private readonly ReadOnlyCollection<JoystickType> ZKdRpnTHZbPriuEwtEutewFQqRfM;

		private readonly bool mftKFNrbrYbKWJxdZXmVdjBuNAnbA;

		private readonly bool xFGJFKtwEdVAHeZnxWYlLkyErLjo;

		private readonly bool YDoaumitDEYKIhNacTHfqHrEJXfNA;

		private readonly int bLweEBDuTdFjuawvcvyoTbIgCHddA;

		private readonly float[] IDrpRbxzYIsvwoWdQajkXmtzeTacA;

		private readonly TimerAbs[] fCsHqNqjwWbDiHfFyvSwuthvnCGEb;

		private readonly int tORnpyTuwqxkFnxEdksGlpmyKJxg;

		private readonly Hat[] hAvLsDgxaIsPmHHKsSXRfDRWkPjN;

		private readonly ReadOnlyCollection<Hat> qwYCUrMnnrEDHaxRGHdqruEnYzjB;

		private readonly int pElnqIjguFQfRLAiBngmfiatNmWp;

		private readonly DirectionalPad[] VZieQOendRljDvKAcbRENOJnyMrX;

		private readonly ReadOnlyCollection<DirectionalPad> UcgtYJdubFUuxLIGRVnTYlvOZQlQ;

		internal IList<JoystickType> wjcYKSYDFoArABXRZPBWdOPKaGdBA
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return ZKdRpnTHZbPriuEwtEutewFQqRfM;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return -1L;
				}
				return jJFXbiiTKdLKwmRtKNFKUzQXOQCK.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return -1;
				}
				return jJFXbiiTKdLKwmRtKNFKUzQXOQCK.unityId;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return Guid.Empty;
				}
				return jJFXbiiTKdLKwmRtKNFKUzQXOQCK.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return false;
				}
				return mftKFNrbrYbKWJxdZXmVdjBuNAnbA;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0f;
				}
				if (!mftKFNrbrYbKWJxdZXmVdjBuNAnbA)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!xFGJFKtwEdVAHeZnxWYlLkyErLjo)
				{
					return 0f;
				}
				if (bLweEBDuTdFjuawvcvyoTbIgCHddA > 0)
				{
					return IDrpRbxzYIsvwoWdQajkXmtzeTacA[0];
				}
				return 0f;
			}
			set
			{
				if (mftKFNrbrYbKWJxdZXmVdjBuNAnbA)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (xFGJFKtwEdVAHeZnxWYlLkyErLjo && 0 < bLweEBDuTdFjuawvcvyoTbIgCHddA)
					{
						yurkltfcKTBvdQhExdGGtKVOSipe(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0f;
				}
				if (!mftKFNrbrYbKWJxdZXmVdjBuNAnbA)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!xFGJFKtwEdVAHeZnxWYlLkyErLjo)
				{
					return 0f;
				}
				if (bLweEBDuTdFjuawvcvyoTbIgCHddA > 1)
				{
					return IDrpRbxzYIsvwoWdQajkXmtzeTacA[1];
				}
				return 0f;
			}
			set
			{
				if (mftKFNrbrYbKWJxdZXmVdjBuNAnbA)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (xFGJFKtwEdVAHeZnxWYlLkyErLjo && 1 < bLweEBDuTdFjuawvcvyoTbIgCHddA)
					{
						yurkltfcKTBvdQhExdGGtKVOSipe(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return bLweEBDuTdFjuawvcvyoTbIgCHddA;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0;
				}
				return tORnpyTuwqxkFnxEdksGlpmyKJxg;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return qwYCUrMnnrEDHaxRGHdqruEnYzjB;
			}
		}

		public int directionalPadCount
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0;
				}
				return pElnqIjguFQfRLAiBngmfiatNmWp;
			}
		}

		public IList<DirectionalPad> DirectionalPads
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<DirectionalPad>.EmptyReadOnlyIListT;
				}
				return UcgtYJdubFUuxLIGRVnTYlvOZQlQ;
			}
		}

		internal int dHkNCKpctgNGcHxUJklopMPghHBX => jJFXbiiTKdLKwmRtKNFKUzQXOQCK.inputManagerId;

		internal HardwareControllerMapIdentifier dinBxJIeEQJSCuYZfbsBDoWdOsLN
		{
			get
			{
				if (qfUAjoZEkUJBMcgOHFRLtyQzKjdR == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return qfUAjoZEkUJBMcgOHFRLtyQzKjdR.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController P_0)
			: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
		{
			jJFXbiiTKdLKwmRtKNFKUzQXOQCK = P_0.sourceJoystick;
			base.akwtvaGPrrlBPafWNXGoNkGZGapl = jJFXbiiTKdLKwmRtKNFKUzQXOQCK as ITryGetLocalizedName;
			mftKFNrbrYbKWJxdZXmVdjBuNAnbA = P_0.hw_supportsVibration;
			YDoaumitDEYKIhNacTHfqHrEJXfNA = P_0.hw_supportsVoice;
			bLweEBDuTdFjuawvcvyoTbIgCHddA = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
			if (mftKFNrbrYbKWJxdZXmVdjBuNAnbA && bLweEBDuTdFjuawvcvyoTbIgCHddA > 0)
			{
				IDrpRbxzYIsvwoWdQajkXmtzeTacA = new float[bLweEBDuTdFjuawvcvyoTbIgCHddA];
				fCsHqNqjwWbDiHfFyvSwuthvnCGEb = new TimerAbs[bLweEBDuTdFjuawvcvyoTbIgCHddA];
				ArrayTools.Populate(fCsHqNqjwWbDiHfFyvSwuthvnCGEb, 0, bLweEBDuTdFjuawvcvyoTbIgCHddA);
				xFGJFKtwEdVAHeZnxWYlLkyErLjo = true;
			}
			if (XoTulHbRfmGIRZBImccjILWCKOlE != Guid.Empty)
			{
				IList<aeTKcrzfQkODTQybGHqaOyCSCntK> list = ReInput.felssdrBYeMGPKlPWlzZWPgzaqeV(XoTulHbRfmGIRZBImccjILWCKOlE);
				if (list != null)
				{
					List<IControllerTemplate> list2 = null;
					for (int i = 0; i < list.Count; i++)
					{
						aeTKcrzfQkODTQybGHqaOyCSCntK aeTKcrzfQkODTQybGHqaOyCSCntK2 = list[i];
						if (aeTKcrzfQkODTQybGHqaOyCSCntK2 == null)
						{
							continue;
						}
						IControllerTemplate controllerTemplate;
						try
						{
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(aeTKcrzfQkODTQybGHqaOyCSCntK2.oGvOrMOLNvPxwQRPGVryuwYzGqbt, new ControllerTemplate.oJRdzPFCfZVnUquAeXOaQPbKAPnVA(this, aeTKcrzfQkODTQybGHqaOyCSCntK2));
							if (controllerTemplate == null)
							{
								throw new Exception("Controller Template for guid " + aeTKcrzfQkODTQybGHqaOyCSCntK2.oGvOrMOLNvPxwQRPGVryuwYzGqbt.ToString() + " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?");
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
						qunDYbEmcxgVAcWnvRKXfnxVfqgRA(list2.ToArray());
					}
				}
			}
			CpCVLCxmguYfwaCGdHOlxVqCpGLv();
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
		{
			if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
			{
				neVQSDEjCJnTWMvXgyAplExTHzDT = new JoystickType[1];
			}
			else
			{
				neVQSDEjCJnTWMvXgyAplExTHzDT = P_9.joystickTypes;
			}
			ZKdRpnTHZbPriuEwtEutewFQqRfM = new ReadOnlyCollection<JoystickType>(neVQSDEjCJnTWMvXgyAplExTHzDT);
			tORnpyTuwqxkFnxEdksGlpmyKJxg = P_9.hatCount;
			hAvLsDgxaIsPmHHKsSXRfDRWkPjN = new Hat[tORnpyTuwqxkFnxEdksGlpmyKJxg];
			for (int i = 0; i < tORnpyTuwqxkFnxEdksGlpmyKJxg; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						hAvLsDgxaIsPmHHKsSXRfDRWkPjN[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
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
						hAvLsDgxaIsPmHHKsSXRfDRWkPjN[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
						hAvLsDgxaIsPmHHKsSXRfDRWkPjN[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					}
				}
				finally
				{
					GVljbkeDoYqeJxOGVFEfBxBaaTiT(hAvLsDgxaIsPmHHKsSXRfDRWkPjN[i]);
				}
			}
			qwYCUrMnnrEDHaxRGHdqruEnYzjB = new ReadOnlyCollection<Hat>(hAvLsDgxaIsPmHHKsSXRfDRWkPjN);
			pElnqIjguFQfRLAiBngmfiatNmWp = P_9.dpadCount;
			VZieQOendRljDvKAcbRENOJnyMrX = new DirectionalPad[pElnqIjguFQfRLAiBngmfiatNmWp];
			for (int k = 0; k < pElnqIjguFQfRLAiBngmfiatNmWp; k++)
			{
				HardwareJoystickMap.CompoundElement dPadData = P_9.GetDPadData(k);
				try
				{
					if (dPadData == null)
					{
						Logger.LogError("Error creating D-Pad from hardware map! CompoundElement is null!");
						VZieQOendRljDvKAcbRENOJnyMrX[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
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
						VZieQOendRljDvKAcbRENOJnyMrX[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, list3.ToArray(), list4.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating D-Pad from hardware map! Exception thrown when creating D-Pad.");
						VZieQOendRljDvKAcbRENOJnyMrX[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
					}
				}
				finally
				{
					GVljbkeDoYqeJxOGVFEfBxBaaTiT(VZieQOendRljDvKAcbRENOJnyMrX[k]);
				}
			}
			UcgtYJdubFUuxLIGRVnTYlvOZQlQ = new ReadOnlyCollection<DirectionalPad>(VZieQOendRljDvKAcbRENOJnyMrX);
		}

		internal bool biefyIhtcqIAPIfDjShpWnpHrxwBB(JoystickType P_0)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int num = neVQSDEjCJnTWMvXgyAplExTHzDT.Length;
			for (int i = 0; i < num; i++)
			{
				if (neVQSDEjCJnTWMvXgyAplExTHzDT[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else
			{
				if (!mftKFNrbrYbKWJxdZXmVdjBuNAnbA)
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
				if (xFGJFKtwEdVAHeZnxWYlLkyErLjo)
				{
					if (bLweEBDuTdFjuawvcvyoTbIgCHddA > 0)
					{
						yurkltfcKTBvdQhExdGGtKVOSipe(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (bLweEBDuTdFjuawvcvyoTbIgCHddA > 1)
					{
						yurkltfcKTBvdQhExdGGtKVOSipe(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					KeEHOTVAbeITCkxFJERuAqKcbgqz();
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else if (mftKFNrbrYbKWJxdZXmVdjBuNAnbA && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (xFGJFKtwEdVAHeZnxWYlLkyErLjo && motorIndex < bLweEBDuTdFjuawvcvyoTbIgCHddA)
				{
					yurkltfcKTBvdQhExdGGtKVOSipe(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0f;
			}
			if (!mftKFNrbrYbKWJxdZXmVdjBuNAnbA || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!xFGJFKtwEdVAHeZnxWYlLkyErLjo)
			{
				return 0f;
			}
			if (motorIndex >= bLweEBDuTdFjuawvcvyoTbIgCHddA)
			{
				return 0f;
			}
			return IDrpRbxzYIsvwoWdQajkXmtzeTacA[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
			}
			else
			{
				if (!mftKFNrbrYbKWJxdZXmVdjBuNAnbA)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (xFGJFKtwEdVAHeZnxWYlLkyErLjo)
				{
					Array.Clear(IDrpRbxzYIsvwoWdQajkXmtzeTacA, 0, IDrpRbxzYIsvwoWdQajkXmtzeTacA.Length);
					for (int i = 0; i < bLweEBDuTdFjuawvcvyoTbIgCHddA; i++)
					{
						fCsHqNqjwWbDiHfFyvSwuthvnCGEb[i].Clear();
					}
				}
				if (jJFXbiiTKdLKwmRtKNFKUzQXOQCK != null)
				{
					jJFXbiiTKdLKwmRtKNFKUzQXOQCK.StopVibration();
				}
			}
		}

		internal virtual void qYregIhfIFmRDGaQOaNXDQBkjFPoc(UpdateLoopType P_0)
		{
			flHIGtttxvNnQVLUjNmdvPvlaaau(P_0);
			for (int i = 0; i < tORnpyTuwqxkFnxEdksGlpmyKJxg; i++)
			{
				if (hAvLsDgxaIsPmHHKsSXRfDRWkPjN[i] != null)
				{
					hAvLsDgxaIsPmHHKsSXRfDRWkPjN[i].boPEszaqjMauNhuIPQKKTkTcSDbPA(P_0, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
				}
			}
			for (int j = 0; j < pElnqIjguFQfRLAiBngmfiatNmWp; j++)
			{
				if (VZieQOendRljDvKAcbRENOJnyMrX[j] != null)
				{
					VZieQOendRljDvKAcbRENOJnyMrX[j].XZrncGkfKyxmiEqiyrYOSFVaQMPV(P_0, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
				}
			}
			ThNfFaBHFqzIekkNNDkBcSckWwDOB();
		}

		internal void cmhXjjVebxbKSEQPNNYgtRYAADvs(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				CFJHRzYlnECQkegAGuUPRNzAHwtFA(P_0.sourceJoystick);
			}
		}

		internal void pNUSRvhBkrTRvdFypEUlwmSFWRDy(BridgedController P_0)
		{
			if (P_0 != null)
			{
				CFJHRzYlnECQkegAGuUPRNzAHwtFA(P_0.sourceJoystick);
			}
		}

		private void CFJHRzYlnECQkegAGuUPRNzAHwtFA(IInputManagerJoystickPublic P_0)
		{
			jJFXbiiTKdLKwmRtKNFKUzQXOQCK = P_0;
			base.akwtvaGPrrlBPafWNXGoNkGZGapl = P_0 as ITryGetLocalizedName;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					ceQWwFmgSzavmOFjxsbVVXMSrRBU(P_0.extension);
				}
				else
				{
					wZAgFdpWTgDzbPAtkTSJvQdXLMMR(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal virtual void qXozUsLVMtlwoTKWVsHEDTLeBzus()
		{
			PVFaXVptkwbndlExJKIXMMEteizl();
			StopVibration();
		}

		internal virtual void eWndJMAUDEVvOGzMycuypzsLeitib(bool P_0)
		{
			base.LeLYmpHPVPCSNZNverFIBCLjUJnT(P_0);
			if (!P_0 && !ReInput.applicationRunInBackground)
			{
				StopVibration();
			}
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (xFGJFKtwEdVAHeZnxWYlLkyErLjo)
			{
				Array.Clear(IDrpRbxzYIsvwoWdQajkXmtzeTacA, 0, IDrpRbxzYIsvwoWdQajkXmtzeTacA.Length);
				for (int i = 0; i < bLweEBDuTdFjuawvcvyoTbIgCHddA; i++)
				{
					fCsHqNqjwWbDiHfFyvSwuthvnCGEb[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void ThNfFaBHFqzIekkNNDkBcSckWwDOB()
		{
			if (!mftKFNrbrYbKWJxdZXmVdjBuNAnbA || !xFGJFKtwEdVAHeZnxWYlLkyErLjo)
			{
				return;
			}
			for (int i = 0; i < bLweEBDuTdFjuawvcvyoTbIgCHddA; i++)
			{
				if (fCsHqNqjwWbDiHfFyvSwuthvnCGEb[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void yurkltfcKTBvdQhExdGGtKVOSipe(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!xFGJFKtwEdVAHeZnxWYlLkyErLjo || P_0 < 0 || P_0 >= bLweEBDuTdFjuawvcvyoTbIgCHddA)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(IDrpRbxzYIsvwoWdQajkXmtzeTacA, 0, IDrpRbxzYIsvwoWdQajkXmtzeTacA.Length);
				for (int i = 0; i < bLweEBDuTdFjuawvcvyoTbIgCHddA; i++)
				{
					fCsHqNqjwWbDiHfFyvSwuthvnCGEb[i].Clear();
				}
			}
			IDrpRbxzYIsvwoWdQajkXmtzeTacA[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				fCsHqNqjwWbDiHfFyvSwuthvnCGEb[P_0].Clear();
			}
			else
			{
				fCsHqNqjwWbDiHfFyvSwuthvnCGEb[P_0].Start(P_2);
			}
			if (P_4)
			{
				KeEHOTVAbeITCkxFJERuAqKcbgqz();
			}
		}

		private void KeEHOTVAbeITCkxFJERuAqKcbgqz()
		{
			if (mftKFNrbrYbKWJxdZXmVdjBuNAnbA && xFGJFKtwEdVAHeZnxWYlLkyErLjo && jJFXbiiTKdLKwmRtKNFKUzQXOQCK != null)
			{
				for (int i = 0; i < IDrpRbxzYIsvwoWdQajkXmtzeTacA.Length; i++)
				{
					jJFXbiiTKdLKwmRtKNFKUzQXOQCK.SetVibration(IDrpRbxzYIsvwoWdQajkXmtzeTacA[i], i);
				}
			}
		}

		private void ksaAiboqMrpcPZyPqmBUxwbQFBuh()
		{
		}

		internal static int GKwervGZyDvcatXJmzVFKsgIaTOeA(Joystick P_0, Joystick P_1)
		{
			if (P_0.dHkNCKpctgNGcHxUJklopMPghHBX < P_1.dHkNCKpctgNGcHxUJklopMPghHBX)
			{
				return -1;
			}
			if (P_0.dHkNCKpctgNGcHxUJklopMPghHBX > P_1.dHkNCKpctgNGcHxUJklopMPghHBX)
			{
				return 1;
			}
			return 0;
		}
	}
}
