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
		private const int oKIynMeWIAtVNwKXSGZMuhIIiJZDA = 0;

		private const int PdbGzYglHcQiTdQQaWWDefVAtbkOb = 1;

		private IInputManagerJoystickPublic NVGEHflIDtxDGvwhVSzufgYYaoJB;

		private readonly JoystickType[] XOQOdyZkEFUMeNSKxddCGUPAZRlDA;

		private readonly ReadOnlyCollection<JoystickType> dxiLmWSHHxEkIjppgPnSgPvHRhFKB;

		private readonly bool CUqklykKdKvJuabqCdroEUnhJwHO;

		private readonly bool TTDeSvcsQdtArpPkaLFKwgKLptJk;

		private readonly bool qOjTGFyFAQzsqMpmfITKqFFNjyRE;

		private readonly int FXtjOkULjhAuCtkqbdnPsmbnbQVC;

		private readonly float[] olmuTIeXKIYlGthkRadJmNRcdnIg;

		private readonly TimerAbs[] LkxFjylSwGwWMcoYxJaRQmPwuIeh;

		private readonly int PCMElJOfmiHAxwqTuzlhYSAvimBN;

		private readonly Hat[] PRaHkwlkuWnLWGjRzcViILzRyvTn;

		private readonly ReadOnlyCollection<Hat> YlXxtrDmjxcrprxuDDMCAnUylePP;

		private readonly int DMgLlhsZoPKQvMDtKteLIwSaEMwl;

		private readonly DirectionalPad[] jHjpPzpIhHGghaiHtdSleHrkeeLjA;

		private readonly ReadOnlyCollection<DirectionalPad> cRlddgsohJJTJIGDKhgaxMVTgmZbA;

		internal IList<JoystickType> OuzMprDlFaGYqOCWESCxWExXFeFdA
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return dxiLmWSHHxEkIjppgPnSgPvHRhFKB;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return -1L;
				}
				return NVGEHflIDtxDGvwhVSzufgYYaoJB.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return -1;
				}
				return NVGEHflIDtxDGvwhVSzufgYYaoJB.unityId;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return Guid.Empty;
				}
				return NVGEHflIDtxDGvwhVSzufgYYaoJB.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return false;
				}
				return CUqklykKdKvJuabqCdroEUnhJwHO;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0f;
				}
				if (!CUqklykKdKvJuabqCdroEUnhJwHO)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!TTDeSvcsQdtArpPkaLFKwgKLptJk)
				{
					return 0f;
				}
				if (FXtjOkULjhAuCtkqbdnPsmbnbQVC > 0)
				{
					return olmuTIeXKIYlGthkRadJmNRcdnIg[0];
				}
				return 0f;
			}
			set
			{
				if (CUqklykKdKvJuabqCdroEUnhJwHO)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (TTDeSvcsQdtArpPkaLFKwgKLptJk && 0 < FXtjOkULjhAuCtkqbdnPsmbnbQVC)
					{
						UiuYNWkXuNbiHRmcwCydSRgPcsDx(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0f;
				}
				if (!CUqklykKdKvJuabqCdroEUnhJwHO)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!TTDeSvcsQdtArpPkaLFKwgKLptJk)
				{
					return 0f;
				}
				if (FXtjOkULjhAuCtkqbdnPsmbnbQVC > 1)
				{
					return olmuTIeXKIYlGthkRadJmNRcdnIg[1];
				}
				return 0f;
			}
			set
			{
				if (CUqklykKdKvJuabqCdroEUnhJwHO)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (TTDeSvcsQdtArpPkaLFKwgKLptJk && 1 < FXtjOkULjhAuCtkqbdnPsmbnbQVC)
					{
						UiuYNWkXuNbiHRmcwCydSRgPcsDx(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return FXtjOkULjhAuCtkqbdnPsmbnbQVC;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0;
				}
				return PCMElJOfmiHAxwqTuzlhYSAvimBN;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return YlXxtrDmjxcrprxuDDMCAnUylePP;
			}
		}

		public int directionalPadCount
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return 0;
				}
				return DMgLlhsZoPKQvMDtKteLIwSaEMwl;
			}
		}

		public IList<DirectionalPad> DirectionalPads
		{
			get
			{
				if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
				{
					ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
					return EmptyObjects<DirectionalPad>.EmptyReadOnlyIListT;
				}
				return cRlddgsohJJTJIGDKhgaxMVTgmZbA;
			}
		}

		internal int TWprnxczdgloAAhDGCiNApfzfnlx => NVGEHflIDtxDGvwhVSzufgYYaoJB.inputManagerId;

		internal HardwareControllerMapIdentifier LzsnegTLQWBrmlNOuxzsmKwkuQvn
		{
			get
			{
				if (UzVdrXbKoYScsNhLYrSoTUeynXDBb == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return UzVdrXbKoYScsNhLYrSoTUeynXDBb.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController P_0)
			: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
		{
			NVGEHflIDtxDGvwhVSzufgYYaoJB = P_0.sourceJoystick;
			base.SUbfQRFbPzwGnnrqYMULqgcOxeVP = NVGEHflIDtxDGvwhVSzufgYYaoJB as ITryGetLocalizedName;
			CUqklykKdKvJuabqCdroEUnhJwHO = P_0.hw_supportsVibration;
			qOjTGFyFAQzsqMpmfITKqFFNjyRE = P_0.hw_supportsVoice;
			FXtjOkULjhAuCtkqbdnPsmbnbQVC = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
			if (CUqklykKdKvJuabqCdroEUnhJwHO && FXtjOkULjhAuCtkqbdnPsmbnbQVC > 0)
			{
				olmuTIeXKIYlGthkRadJmNRcdnIg = new float[FXtjOkULjhAuCtkqbdnPsmbnbQVC];
				LkxFjylSwGwWMcoYxJaRQmPwuIeh = new TimerAbs[FXtjOkULjhAuCtkqbdnPsmbnbQVC];
				ArrayTools.Populate(LkxFjylSwGwWMcoYxJaRQmPwuIeh, 0, FXtjOkULjhAuCtkqbdnPsmbnbQVC);
				TTDeSvcsQdtArpPkaLFKwgKLptJk = true;
			}
			if (lcQyDEaPLwhlbiUKrOtQaptBTwRjc != Guid.Empty)
			{
				IList<WRScrEekSojpdBXyEFARqvkVFcPPb> list = ReInput.NtqZxOyXKuhMtTRYHuwqvdGuUYMH(lcQyDEaPLwhlbiUKrOtQaptBTwRjc);
				if (list != null)
				{
					List<IControllerTemplate> list2 = null;
					for (int i = 0; i < list.Count; i++)
					{
						WRScrEekSojpdBXyEFARqvkVFcPPb wRScrEekSojpdBXyEFARqvkVFcPPb = list[i];
						if (wRScrEekSojpdBXyEFARqvkVFcPPb == null)
						{
							continue;
						}
						IControllerTemplate controllerTemplate;
						try
						{
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(wRScrEekSojpdBXyEFARqvkVFcPPb.COqSQlZfVhAWYFhKLGoDBewypKFs, new ControllerTemplate.GUKOveDlcFMNwdJUlVOLoRWDnPND(this, wRScrEekSojpdBXyEFARqvkVFcPPb));
							if (controllerTemplate == null)
							{
								throw new Exception("Controller Template for guid " + wRScrEekSojpdBXyEFARqvkVFcPPb.COqSQlZfVhAWYFhKLGoDBewypKFs.ToString() + " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?");
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
						MamxKOLmQtiBsJFosXLuYlRIOZOF(list2.ToArray());
					}
				}
			}
			yAFKgfmSqcdzYvwLywJEIeWPEynEA();
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
		{
			if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
			{
				XOQOdyZkEFUMeNSKxddCGUPAZRlDA = new JoystickType[1];
			}
			else
			{
				XOQOdyZkEFUMeNSKxddCGUPAZRlDA = P_9.joystickTypes;
			}
			dxiLmWSHHxEkIjppgPnSgPvHRhFKB = new ReadOnlyCollection<JoystickType>(XOQOdyZkEFUMeNSKxddCGUPAZRlDA);
			PCMElJOfmiHAxwqTuzlhYSAvimBN = P_9.hatCount;
			PRaHkwlkuWnLWGjRzcViILzRyvTn = new Hat[PCMElJOfmiHAxwqTuzlhYSAvimBN];
			for (int i = 0; i < PCMElJOfmiHAxwqTuzlhYSAvimBN; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						PRaHkwlkuWnLWGjRzcViILzRyvTn[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
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
						PRaHkwlkuWnLWGjRzcViILzRyvTn[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
						PRaHkwlkuWnLWGjRzcViILzRyvTn[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					}
				}
				finally
				{
					oKeADPnZuMDqfiFDYZDUysjhzVIH(PRaHkwlkuWnLWGjRzcViILzRyvTn[i]);
				}
			}
			YlXxtrDmjxcrprxuDDMCAnUylePP = new ReadOnlyCollection<Hat>(PRaHkwlkuWnLWGjRzcViILzRyvTn);
			DMgLlhsZoPKQvMDtKteLIwSaEMwl = P_9.dpadCount;
			jHjpPzpIhHGghaiHtdSleHrkeeLjA = new DirectionalPad[DMgLlhsZoPKQvMDtKteLIwSaEMwl];
			for (int k = 0; k < DMgLlhsZoPKQvMDtKteLIwSaEMwl; k++)
			{
				HardwareJoystickMap.CompoundElement dPadData = P_9.GetDPadData(k);
				try
				{
					if (dPadData == null)
					{
						Logger.LogError("Error creating D-Pad from hardware map! CompoundElement is null!");
						jHjpPzpIhHGghaiHtdSleHrkeeLjA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
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
						jHjpPzpIhHGghaiHtdSleHrkeeLjA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, list3.ToArray(), list4.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating D-Pad from hardware map! Exception thrown when creating D-Pad.");
						jHjpPzpIhHGghaiHtdSleHrkeeLjA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
					}
				}
				finally
				{
					oKeADPnZuMDqfiFDYZDUysjhzVIH(jHjpPzpIhHGghaiHtdSleHrkeeLjA[k]);
				}
			}
			cRlddgsohJJTJIGDKhgaxMVTgmZbA = new ReadOnlyCollection<DirectionalPad>(jHjpPzpIhHGghaiHtdSleHrkeeLjA);
		}

		internal bool NuhNfxeiumvgdaNIZcIOURZcHIUg(JoystickType P_0)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return false;
			}
			int num = XOQOdyZkEFUMeNSKxddCGUPAZRlDA.Length;
			for (int i = 0; i < num; i++)
			{
				if (XOQOdyZkEFUMeNSKxddCGUPAZRlDA[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else
			{
				if (!CUqklykKdKvJuabqCdroEUnhJwHO)
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
				if (TTDeSvcsQdtArpPkaLFKwgKLptJk)
				{
					if (FXtjOkULjhAuCtkqbdnPsmbnbQVC > 0)
					{
						UiuYNWkXuNbiHRmcwCydSRgPcsDx(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (FXtjOkULjhAuCtkqbdnPsmbnbQVC > 1)
					{
						UiuYNWkXuNbiHRmcwCydSRgPcsDx(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					cpDLccMCroBokKvQQWQLIfsrcESYA();
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
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else if (CUqklykKdKvJuabqCdroEUnhJwHO && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (TTDeSvcsQdtArpPkaLFKwgKLptJk && motorIndex < FXtjOkULjhAuCtkqbdnPsmbnbQVC)
				{
					UiuYNWkXuNbiHRmcwCydSRgPcsDx(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
				return 0f;
			}
			if (!CUqklykKdKvJuabqCdroEUnhJwHO || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!TTDeSvcsQdtArpPkaLFKwgKLptJk)
			{
				return 0f;
			}
			if (motorIndex >= FXtjOkULjhAuCtkqbdnPsmbnbQVC)
			{
				return 0f;
			}
			return olmuTIeXKIYlGthkRadJmNRcdnIg[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != AxoBCjPHwoqMddBzfEGmrNYYGhxf)
			{
				ReInput.CheckInitialized(AxoBCjPHwoqMddBzfEGmrNYYGhxf);
			}
			else
			{
				if (!CUqklykKdKvJuabqCdroEUnhJwHO)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (TTDeSvcsQdtArpPkaLFKwgKLptJk)
				{
					Array.Clear(olmuTIeXKIYlGthkRadJmNRcdnIg, 0, olmuTIeXKIYlGthkRadJmNRcdnIg.Length);
					for (int i = 0; i < FXtjOkULjhAuCtkqbdnPsmbnbQVC; i++)
					{
						LkxFjylSwGwWMcoYxJaRQmPwuIeh[i].Clear();
					}
				}
				if (NVGEHflIDtxDGvwhVSzufgYYaoJB != null)
				{
					NVGEHflIDtxDGvwhVSzufgYYaoJB.StopVibration();
				}
			}
		}

		internal virtual void ADqTmxwgIPkprtfJLjYwdJhoLtzV(UpdateLoopType P_0)
		{
			TSIxZIyTztOcgIdRmpQWGcNoDGCV(P_0);
			for (int i = 0; i < PCMElJOfmiHAxwqTuzlhYSAvimBN; i++)
			{
				if (PRaHkwlkuWnLWGjRzcViILzRyvTn[i] != null)
				{
					PRaHkwlkuWnLWGjRzcViILzRyvTn[i].FcSXuOndlWHpztANWEJhDzbfTjTp(P_0, ucqtfsuOTseRsybfPGjEFawPmfNK);
				}
			}
			for (int j = 0; j < DMgLlhsZoPKQvMDtKteLIwSaEMwl; j++)
			{
				if (jHjpPzpIhHGghaiHtdSleHrkeeLjA[j] != null)
				{
					jHjpPzpIhHGghaiHtdSleHrkeeLjA[j].dHkBwjvAUaFVUFLrpHTfjtnrnknu(P_0, ucqtfsuOTseRsybfPGjEFawPmfNK);
				}
			}
			lsOgGLAELyrmMdASEFporUKZWsbl();
		}

		internal void UWknkCEkhjstkPKKGHTFOZkVrLTI(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				cOEejKTMvKxTGxhHJNdusyFFOABk(P_0.sourceJoystick);
			}
		}

		internal void BgROjKityvfsHuKfsJPWHhgGErrIA(BridgedController P_0)
		{
			if (P_0 != null)
			{
				cOEejKTMvKxTGxhHJNdusyFFOABk(P_0.sourceJoystick);
			}
		}

		private void cOEejKTMvKxTGxhHJNdusyFFOABk(IInputManagerJoystickPublic P_0)
		{
			NVGEHflIDtxDGvwhVSzufgYYaoJB = P_0;
			base.SUbfQRFbPzwGnnrqYMULqgcOxeVP = P_0 as ITryGetLocalizedName;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					UONPvyrtOdqCGVHocvgcaZuNlxxv(P_0.extension);
				}
				else
				{
					CHBwbEmfRmAQRKzmfrZoSkBSuoot(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal virtual void IIrzBNKInnDHUUFVYYFjemlzHKQl()
		{
			pMAKFseXyurQXsyyUSZmzSuwdMXR();
			StopVibration();
		}

		internal virtual void SckmUdJDPMQWaohDljMNAzQYOyVF(bool P_0)
		{
			base.lpGHWOOJdXrtWGgitYfjarUifXfB(P_0);
			if (!P_0 && !ReInput.applicationRunInBackground)
			{
				StopVibration();
			}
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (TTDeSvcsQdtArpPkaLFKwgKLptJk)
			{
				Array.Clear(olmuTIeXKIYlGthkRadJmNRcdnIg, 0, olmuTIeXKIYlGthkRadJmNRcdnIg.Length);
				for (int i = 0; i < FXtjOkULjhAuCtkqbdnPsmbnbQVC; i++)
				{
					LkxFjylSwGwWMcoYxJaRQmPwuIeh[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void lsOgGLAELyrmMdASEFporUKZWsbl()
		{
			if (!CUqklykKdKvJuabqCdroEUnhJwHO || !TTDeSvcsQdtArpPkaLFKwgKLptJk)
			{
				return;
			}
			for (int i = 0; i < FXtjOkULjhAuCtkqbdnPsmbnbQVC; i++)
			{
				if (LkxFjylSwGwWMcoYxJaRQmPwuIeh[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void UiuYNWkXuNbiHRmcwCydSRgPcsDx(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!TTDeSvcsQdtArpPkaLFKwgKLptJk || P_0 < 0 || P_0 >= FXtjOkULjhAuCtkqbdnPsmbnbQVC)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(olmuTIeXKIYlGthkRadJmNRcdnIg, 0, olmuTIeXKIYlGthkRadJmNRcdnIg.Length);
				for (int i = 0; i < FXtjOkULjhAuCtkqbdnPsmbnbQVC; i++)
				{
					LkxFjylSwGwWMcoYxJaRQmPwuIeh[i].Clear();
				}
			}
			olmuTIeXKIYlGthkRadJmNRcdnIg[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				LkxFjylSwGwWMcoYxJaRQmPwuIeh[P_0].Clear();
			}
			else
			{
				LkxFjylSwGwWMcoYxJaRQmPwuIeh[P_0].Start(P_2);
			}
			if (P_4)
			{
				cpDLccMCroBokKvQQWQLIfsrcESYA();
			}
		}

		private void cpDLccMCroBokKvQQWQLIfsrcESYA()
		{
			if (CUqklykKdKvJuabqCdroEUnhJwHO && TTDeSvcsQdtArpPkaLFKwgKLptJk && NVGEHflIDtxDGvwhVSzufgYYaoJB != null)
			{
				for (int i = 0; i < olmuTIeXKIYlGthkRadJmNRcdnIg.Length; i++)
				{
					NVGEHflIDtxDGvwhVSzufgYYaoJB.SetVibration(olmuTIeXKIYlGthkRadJmNRcdnIg[i], i);
				}
			}
		}

		private void SjzexUtdWdIMrEQQdWtbASFXcpMdA()
		{
		}

		internal static int sWtIoQSuiBNDCogUhCFavMKBjnaL(Joystick P_0, Joystick P_1)
		{
			if (P_0.TWprnxczdgloAAhDGCiNApfzfnlx < P_1.TWprnxczdgloAAhDGCiNApfzfnlx)
			{
				return -1;
			}
			if (P_0.TWprnxczdgloAAhDGCiNApfzfnlx > P_1.TWprnxczdgloAAhDGCiNApfzfnlx)
			{
				return 1;
			}
			return 0;
		}
	}
}
