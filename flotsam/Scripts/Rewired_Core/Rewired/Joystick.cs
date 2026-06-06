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
		private const int jxipHItHdUvqRUTHhwWlFZajfewb = 0;

		private const int UbWjwFaYyuARmeOzXlFDUYXENAVC = 1;

		private IInputManagerJoystickPublic WMlVOIqcJvjDlLuwizdrKMzhfOLv;

		private readonly JoystickType[] WtzfTvSfDPJuLvdOSdKQkxIjMvYY;

		private readonly ReadOnlyCollection<JoystickType> kMRceHRDUpfSzGRhZqGEQsemTLoRA;

		private readonly bool NIRHghvNgUsVVKyefBMkrToGGSgt;

		private readonly bool CieGgodGVfnVCPneFgaKDjPoxLuT;

		private readonly bool hSYtNUpSIKfZTiOjKGvSHSGysRcV;

		private readonly int AmMgpngTIrgoddZweQGTnLfhILikC;

		private readonly float[] pSNOgFvsDIemjBoicAFHHFWRGTduA;

		private readonly TimerAbs[] KROhRxyKzEDQxCMAOEmPvrCXlMTo;

		private readonly int ObhuMEDKvmuoACPPZxSxhxTUfOuu;

		private readonly Hat[] OkBaMvqtbMfMnmaHOeaobRcwBJmi;

		private readonly ReadOnlyCollection<Hat> TqlvacKqglTYjDqiqrkGrXzVGKsd;

		private readonly int IRZrPilrhRPwWuabjaULzsPTgsTJA;

		private readonly DirectionalPad[] qzCgtiocmPTwEQPJENpdVByXeCmcA;

		private readonly ReadOnlyCollection<DirectionalPad> dsEllnxDcNQlkeqHphDqWYEgwQww;

		internal IList<JoystickType> XJQbxwEbMetkHwcSbUzxlPgywIsy
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return kMRceHRDUpfSzGRhZqGEQsemTLoRA;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return -1L;
				}
				return WMlVOIqcJvjDlLuwizdrKMzhfOLv.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return -1;
				}
				return WMlVOIqcJvjDlLuwizdrKMzhfOLv.unityId;
			}
		}

		Guid Controller.deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return Guid.Empty;
				}
				return WMlVOIqcJvjDlLuwizdrKMzhfOLv.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return false;
				}
				return NIRHghvNgUsVVKyefBMkrToGGSgt;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0f;
				}
				if (!NIRHghvNgUsVVKyefBMkrToGGSgt)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!CieGgodGVfnVCPneFgaKDjPoxLuT)
				{
					return 0f;
				}
				if (AmMgpngTIrgoddZweQGTnLfhILikC > 0)
				{
					return pSNOgFvsDIemjBoicAFHHFWRGTduA[0];
				}
				return 0f;
			}
			set
			{
				if (NIRHghvNgUsVVKyefBMkrToGGSgt)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (CieGgodGVfnVCPneFgaKDjPoxLuT && 0 < AmMgpngTIrgoddZweQGTnLfhILikC)
					{
						PVvFDnjrRGSemtgTYBpexziMOecA(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0f;
				}
				if (!NIRHghvNgUsVVKyefBMkrToGGSgt)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!CieGgodGVfnVCPneFgaKDjPoxLuT)
				{
					return 0f;
				}
				if (AmMgpngTIrgoddZweQGTnLfhILikC > 1)
				{
					return pSNOgFvsDIemjBoicAFHHFWRGTduA[1];
				}
				return 0f;
			}
			set
			{
				if (NIRHghvNgUsVVKyefBMkrToGGSgt)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (CieGgodGVfnVCPneFgaKDjPoxLuT && 1 < AmMgpngTIrgoddZweQGTnLfhILikC)
					{
						PVvFDnjrRGSemtgTYBpexziMOecA(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return AmMgpngTIrgoddZweQGTnLfhILikC;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0;
				}
				return ObhuMEDKvmuoACPPZxSxhxTUfOuu;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return TqlvacKqglTYjDqiqrkGrXzVGKsd;
			}
		}

		public int directionalPadCount
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0;
				}
				return IRZrPilrhRPwWuabjaULzsPTgsTJA;
			}
		}

		public IList<DirectionalPad> DirectionalPads
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<DirectionalPad>.EmptyReadOnlyIListT;
				}
				return dsEllnxDcNQlkeqHphDqWYEgwQww;
			}
		}

		internal int YHQQnmlLemgNtqWLdALHczyIyJWBA => WMlVOIqcJvjDlLuwizdrKMzhfOLv.inputManagerId;

		internal HardwareControllerMapIdentifier AfDBidYDTALZBDbSZzCaFMdBJkKeA
		{
			get
			{
				if (JEexZOPzSUUjNTHjvxywblgJdFqE == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return JEexZOPzSUUjNTHjvxywblgJdFqE.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController P_0)
			: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
		{
			WMlVOIqcJvjDlLuwizdrKMzhfOLv = P_0.sourceJoystick;
			base.NMAKxWWmUpwqQNWynrlTLJrvKLcF = WMlVOIqcJvjDlLuwizdrKMzhfOLv as ITryGetLocalizedName;
			NIRHghvNgUsVVKyefBMkrToGGSgt = P_0.hw_supportsVibration;
			hSYtNUpSIKfZTiOjKGvSHSGysRcV = P_0.hw_supportsVoice;
			AmMgpngTIrgoddZweQGTnLfhILikC = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
			if (NIRHghvNgUsVVKyefBMkrToGGSgt && AmMgpngTIrgoddZweQGTnLfhILikC > 0)
			{
				pSNOgFvsDIemjBoicAFHHFWRGTduA = new float[AmMgpngTIrgoddZweQGTnLfhILikC];
				KROhRxyKzEDQxCMAOEmPvrCXlMTo = new TimerAbs[AmMgpngTIrgoddZweQGTnLfhILikC];
				ArrayTools.Populate(KROhRxyKzEDQxCMAOEmPvrCXlMTo, 0, AmMgpngTIrgoddZweQGTnLfhILikC);
				CieGgodGVfnVCPneFgaKDjPoxLuT = true;
			}
			if (qapLJarKYePKdgQROGMwYujqCcvB != Guid.Empty)
			{
				IList<LrxjGZteHmJMKhKqexjHMLnoIwmG> list = ReInput.YQFpRZvpJcvRUtnWqBHgfALDautZA(qapLJarKYePKdgQROGMwYujqCcvB);
				if (list != null)
				{
					List<IControllerTemplate> list2 = null;
					for (int i = 0; i < list.Count; i++)
					{
						LrxjGZteHmJMKhKqexjHMLnoIwmG lrxjGZteHmJMKhKqexjHMLnoIwmG = list[i];
						if (lrxjGZteHmJMKhKqexjHMLnoIwmG == null)
						{
							continue;
						}
						IControllerTemplate controllerTemplate;
						try
						{
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(lrxjGZteHmJMKhKqexjHMLnoIwmG.ZTZpSgAAOhpivnKYmfHXcJrNdosn, new ControllerTemplate.RIlfAhFAiHguHKRVCvaLjBGmQLepA(this, lrxjGZteHmJMKhKqexjHMLnoIwmG));
							if (controllerTemplate == null)
							{
								throw new Exception("Controller Template for guid " + lrxjGZteHmJMKhKqexjHMLnoIwmG.ZTZpSgAAOhpivnKYmfHXcJrNdosn.ToString() + " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?");
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
						LfRezRHKhdxGDWbeNAqeGxEcxqvWb(list2.ToArray());
					}
				}
			}
			jcuaGkxKxwRQhPfLTgjWpYLcOGCK();
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
		{
			if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
			{
				WtzfTvSfDPJuLvdOSdKQkxIjMvYY = new JoystickType[1];
			}
			else
			{
				WtzfTvSfDPJuLvdOSdKQkxIjMvYY = P_9.joystickTypes;
			}
			kMRceHRDUpfSzGRhZqGEQsemTLoRA = new ReadOnlyCollection<JoystickType>(WtzfTvSfDPJuLvdOSdKQkxIjMvYY);
			ObhuMEDKvmuoACPPZxSxhxTUfOuu = P_9.hatCount;
			OkBaMvqtbMfMnmaHOeaobRcwBJmi = new Hat[ObhuMEDKvmuoACPPZxSxhxTUfOuu];
			for (int i = 0; i < ObhuMEDKvmuoACPPZxSxhxTUfOuu; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						OkBaMvqtbMfMnmaHOeaobRcwBJmi[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
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
						OkBaMvqtbMfMnmaHOeaobRcwBJmi[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
						OkBaMvqtbMfMnmaHOeaobRcwBJmi[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					}
				}
				finally
				{
					zSHDKCuszCZlCImNllcKJkiMDDjp(OkBaMvqtbMfMnmaHOeaobRcwBJmi[i]);
				}
			}
			TqlvacKqglTYjDqiqrkGrXzVGKsd = new ReadOnlyCollection<Hat>(OkBaMvqtbMfMnmaHOeaobRcwBJmi);
			IRZrPilrhRPwWuabjaULzsPTgsTJA = P_9.dpadCount;
			qzCgtiocmPTwEQPJENpdVByXeCmcA = new DirectionalPad[IRZrPilrhRPwWuabjaULzsPTgsTJA];
			for (int k = 0; k < IRZrPilrhRPwWuabjaULzsPTgsTJA; k++)
			{
				HardwareJoystickMap.CompoundElement dPadData = P_9.GetDPadData(k);
				try
				{
					if (dPadData == null)
					{
						Logger.LogError("Error creating D-Pad from hardware map! CompoundElement is null!");
						qzCgtiocmPTwEQPJENpdVByXeCmcA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
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
						qzCgtiocmPTwEQPJENpdVByXeCmcA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, list3.ToArray(), list4.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating D-Pad from hardware map! Exception thrown when creating D-Pad.");
						qzCgtiocmPTwEQPJENpdVByXeCmcA[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
					}
				}
				finally
				{
					zSHDKCuszCZlCImNllcKJkiMDDjp(qzCgtiocmPTwEQPJENpdVByXeCmcA[k]);
				}
			}
			dsEllnxDcNQlkeqHphDqWYEgwQww = new ReadOnlyCollection<DirectionalPad>(qzCgtiocmPTwEQPJENpdVByXeCmcA);
		}

		internal bool KlOdZsnHnciZEcCKsmXUonKPkvhkA(JoystickType P_0)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int num = WtzfTvSfDPJuLvdOSdKQkxIjMvYY.Length;
			for (int i = 0; i < num; i++)
			{
				if (WtzfTvSfDPJuLvdOSdKQkxIjMvYY[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else
			{
				if (!NIRHghvNgUsVVKyefBMkrToGGSgt)
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
				if (CieGgodGVfnVCPneFgaKDjPoxLuT)
				{
					if (AmMgpngTIrgoddZweQGTnLfhILikC > 0)
					{
						PVvFDnjrRGSemtgTYBpexziMOecA(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (AmMgpngTIrgoddZweQGTnLfhILikC > 1)
					{
						PVvFDnjrRGSemtgTYBpexziMOecA(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					dOwcgbVlweWYFHcInYpTMetKEkbHA();
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else if (NIRHghvNgUsVVKyefBMkrToGGSgt && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (CieGgodGVfnVCPneFgaKDjPoxLuT && motorIndex < AmMgpngTIrgoddZweQGTnLfhILikC)
				{
					PVvFDnjrRGSemtgTYBpexziMOecA(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0f;
			}
			if (!NIRHghvNgUsVVKyefBMkrToGGSgt || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!CieGgodGVfnVCPneFgaKDjPoxLuT)
			{
				return 0f;
			}
			if (motorIndex >= AmMgpngTIrgoddZweQGTnLfhILikC)
			{
				return 0f;
			}
			return pSNOgFvsDIemjBoicAFHHFWRGTduA[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
			}
			else
			{
				if (!NIRHghvNgUsVVKyefBMkrToGGSgt)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (CieGgodGVfnVCPneFgaKDjPoxLuT)
				{
					Array.Clear(pSNOgFvsDIemjBoicAFHHFWRGTduA, 0, pSNOgFvsDIemjBoicAFHHFWRGTduA.Length);
					for (int i = 0; i < AmMgpngTIrgoddZweQGTnLfhILikC; i++)
					{
						KROhRxyKzEDQxCMAOEmPvrCXlMTo[i].Clear();
					}
				}
				if (WMlVOIqcJvjDlLuwizdrKMzhfOLv != null)
				{
					WMlVOIqcJvjDlLuwizdrKMzhfOLv.StopVibration();
				}
			}
		}

		internal virtual void LANDToBtDTOECPXHgvbikQeVvTYpA(UpdateLoopType P_0)
		{
			QJtejDrikfTcXiOVZAOExcIHSejO(P_0);
			for (int i = 0; i < ObhuMEDKvmuoACPPZxSxhxTUfOuu; i++)
			{
				if (OkBaMvqtbMfMnmaHOeaobRcwBJmi[i] != null)
				{
					OkBaMvqtbMfMnmaHOeaobRcwBJmi[i].EArMTJqRkSEfGTyRdEqhcnqYDJcIA(P_0, vAJlxjrsCepUBGzroHjWcArmXQkU);
				}
			}
			for (int j = 0; j < IRZrPilrhRPwWuabjaULzsPTgsTJA; j++)
			{
				if (qzCgtiocmPTwEQPJENpdVByXeCmcA[j] != null)
				{
					qzCgtiocmPTwEQPJENpdVByXeCmcA[j].aWLpFkurNuwdzlIdEjapKEcEzIWm(P_0, vAJlxjrsCepUBGzroHjWcArmXQkU);
				}
			}
			oQlcsQDDWqlRpAPYzVAgZSHmUiILA();
		}

		internal void NmVbsZBAgbIDJdtUnWiZxNfwSFqX(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				jTniqFCscECNrLQJaGaaBOQoDuyY(P_0.sourceJoystick);
			}
		}

		internal void KewBnJhzvfHEwUjrZjkQaAjlCPMbA(BridgedController P_0)
		{
			if (P_0 != null)
			{
				jTniqFCscECNrLQJaGaaBOQoDuyY(P_0.sourceJoystick);
			}
		}

		private void jTniqFCscECNrLQJaGaaBOQoDuyY(IInputManagerJoystickPublic P_0)
		{
			WMlVOIqcJvjDlLuwizdrKMzhfOLv = P_0;
			base.NMAKxWWmUpwqQNWynrlTLJrvKLcF = P_0 as ITryGetLocalizedName;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					HTixuhiCTdJkvvseJKLoHkvavBYs(P_0.extension);
				}
				else
				{
					PzkesJfKCipiagKoQdaqklIjBMVzA(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal virtual void TTKTlWPmPzJjdmsPlFrzHDyAuxzN()
		{
			cubHyftKveceaSGovHckWjlTpqaN();
			StopVibration();
		}

		internal virtual void NhJCsoiIMOvaLOSBApINzlJrkmyab(bool P_0)
		{
			base.ynvWXRFBEHELOcvmGFbfaRmNjJwMA(P_0);
			if (!P_0 && !ReInput.applicationRunInBackground)
			{
				StopVibration();
			}
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (CieGgodGVfnVCPneFgaKDjPoxLuT)
			{
				Array.Clear(pSNOgFvsDIemjBoicAFHHFWRGTduA, 0, pSNOgFvsDIemjBoicAFHHFWRGTduA.Length);
				for (int i = 0; i < AmMgpngTIrgoddZweQGTnLfhILikC; i++)
				{
					KROhRxyKzEDQxCMAOEmPvrCXlMTo[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void oQlcsQDDWqlRpAPYzVAgZSHmUiILA()
		{
			if (!NIRHghvNgUsVVKyefBMkrToGGSgt || !CieGgodGVfnVCPneFgaKDjPoxLuT)
			{
				return;
			}
			for (int i = 0; i < AmMgpngTIrgoddZweQGTnLfhILikC; i++)
			{
				if (KROhRxyKzEDQxCMAOEmPvrCXlMTo[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void PVvFDnjrRGSemtgTYBpexziMOecA(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!CieGgodGVfnVCPneFgaKDjPoxLuT || P_0 < 0 || P_0 >= AmMgpngTIrgoddZweQGTnLfhILikC)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(pSNOgFvsDIemjBoicAFHHFWRGTduA, 0, pSNOgFvsDIemjBoicAFHHFWRGTduA.Length);
				for (int i = 0; i < AmMgpngTIrgoddZweQGTnLfhILikC; i++)
				{
					KROhRxyKzEDQxCMAOEmPvrCXlMTo[i].Clear();
				}
			}
			pSNOgFvsDIemjBoicAFHHFWRGTduA[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				KROhRxyKzEDQxCMAOEmPvrCXlMTo[P_0].Clear();
			}
			else
			{
				KROhRxyKzEDQxCMAOEmPvrCXlMTo[P_0].Start(P_2);
			}
			if (P_4)
			{
				dOwcgbVlweWYFHcInYpTMetKEkbHA();
			}
		}

		private void dOwcgbVlweWYFHcInYpTMetKEkbHA()
		{
			if (NIRHghvNgUsVVKyefBMkrToGGSgt && CieGgodGVfnVCPneFgaKDjPoxLuT && WMlVOIqcJvjDlLuwizdrKMzhfOLv != null)
			{
				for (int i = 0; i < pSNOgFvsDIemjBoicAFHHFWRGTduA.Length; i++)
				{
					WMlVOIqcJvjDlLuwizdrKMzhfOLv.SetVibration(pSNOgFvsDIemjBoicAFHHFWRGTduA[i], i);
				}
			}
		}

		private void LSSlZDepZrsZOgIIOEIzlwIcTWxj()
		{
		}

		internal static int fIMgGJVXnVEjrEUWSYjsiYRorXVmA(Joystick P_0, Joystick P_1)
		{
			if (P_0.YHQQnmlLemgNtqWLdALHczyIyJWBA < P_1.YHQQnmlLemgNtqWLdALHczyIyJWBA)
			{
				return -1;
			}
			if (P_0.YHQQnmlLemgNtqWLdALHczyIyJWBA > P_1.YHQQnmlLemgNtqWLdALHczyIyJWBA)
			{
				return 1;
			}
			return 0;
		}
	}
}
