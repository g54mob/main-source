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
		private const int JJscheDTRLEAImCcKoiYREnSjCML = 0;

		private const int gRZHpLODtWeGSKdTnKNPWSnuUJPG = 1;

		private IInputManagerJoystickPublic FpiBbVxDPXwNPsxBjglRbalnBLv;

		private readonly JoystickType[] GDWHhjsPeLInlJOqRnGxhFOGequs;

		private readonly ReadOnlyCollection<JoystickType> paRisdaLrNhPDEhLifsjQgAqkOzb;

		private readonly bool FKavmUmzhTUsUTKzquAriSPWQHJ;

		private readonly bool fztGCZBGsqoPPyFMeCOIVvuEZcGl;

		private readonly bool mmLUkGZDydUSQpXRkpspktGwiQq;

		private readonly int OghBLRYgZfoobrhKTgbGSFSmSFh;

		private readonly float[] nqDgXahbomLmqDfwtwIMtWJyibK;

		private readonly TimerAbs[] hSQNpPKVQzqmHXsYXWEnRBjAPph;

		private readonly int wluJKdumRlvAwdKGuMIsACqyRqz;

		private readonly Hat[] kZRWBYoAxtUAijchebMlYejYoBq;

		private readonly ReadOnlyCollection<Hat> YrIJNJMxeHIsHLwCsMYyIwjItMc;

		internal IList<JoystickType> joystickTypes
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return paRisdaLrNhPDEhLifsjQgAqkOzb;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1L;
				}
				return FpiBbVxDPXwNPsxBjglRbalnBLv.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return FpiBbVxDPXwNPsxBjglRbalnBLv.unityId;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Guid.Empty;
				}
				return FpiBbVxDPXwNPsxBjglRbalnBLv.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return false;
				}
				return FKavmUmzhTUsUTKzquAriSPWQHJ;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0f;
				}
				if (!FKavmUmzhTUsUTKzquAriSPWQHJ)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 0)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!fztGCZBGsqoPPyFMeCOIVvuEZcGl)
				{
					return 0f;
				}
				if (OghBLRYgZfoobrhKTgbGSFSmSFh > 0)
				{
					return nqDgXahbomLmqDfwtwIMtWJyibK[0];
				}
				return 0f;
			}
			set
			{
				if (FKavmUmzhTUsUTKzquAriSPWQHJ)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 0)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (fztGCZBGsqoPPyFMeCOIVvuEZcGl && 0 < OghBLRYgZfoobrhKTgbGSFSmSFh)
					{
						uLUSHqqlyIwztrGtwuJOCAwLAej(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0f;
				}
				if (!FKavmUmzhTUsUTKzquAriSPWQHJ)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 1)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!fztGCZBGsqoPPyFMeCOIVvuEZcGl)
				{
					return 0f;
				}
				if (OghBLRYgZfoobrhKTgbGSFSmSFh > 1)
				{
					return nqDgXahbomLmqDfwtwIMtWJyibK[1];
				}
				return 0f;
			}
			set
			{
				if (FKavmUmzhTUsUTKzquAriSPWQHJ)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 1)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (fztGCZBGsqoPPyFMeCOIVvuEZcGl && 1 < OghBLRYgZfoobrhKTgbGSFSmSFh)
					{
						uLUSHqqlyIwztrGtwuJOCAwLAej(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return OghBLRYgZfoobrhKTgbGSFSmSFh;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return wluJKdumRlvAwdKGuMIsACqyRqz;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return YrIJNJMxeHIsHLwCsMYyIwjItMc;
			}
		}

		internal int inputManagerId => FpiBbVxDPXwNPsxBjglRbalnBLv.inputManagerId;

		internal HardwareControllerMapIdentifier hardwareJoystickMapIdentifier
		{
			get
			{
				if (rEqQznEUmYwtoLNJsErzjlKjjYY == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return rEqQznEUmYwtoLNJsErzjlKjjYY.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController controller)
			: this(controller.sourceJoystick.rewiredId, controller.inputSource, controller.sourceJoystick.name, (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName)) ? controller.hw_bluetoothDeviceName : controller.productName, controller.hardwareIdentifier, controller.controllerTypeGuid, controller.axisCount, controller.buttonCount, controller.isButtonPressureSensitive, controller.gameHardwareMap, controller.controllerExtension, new ControllerDataUpdater(controller.inputManagerSource, controller.axisCount, controller.buttonCount, controller.unknownControllerHats))
		{
			FpiBbVxDPXwNPsxBjglRbalnBLv = controller.sourceJoystick;
			FKavmUmzhTUsUTKzquAriSPWQHJ = controller.hw_supportsVibration;
			mmLUkGZDydUSQpXRkpspktGwiQq = controller.hw_supportsVoice;
			OghBLRYgZfoobrhKTgbGSFSmSFh = ((!(controller.controllerExtension is IControllerVibrator)) ? controller.hw_localVibrationMotorCount : 0);
			if (FKavmUmzhTUsUTKzquAriSPWQHJ && OghBLRYgZfoobrhKTgbGSFSmSFh > 0)
			{
				nqDgXahbomLmqDfwtwIMtWJyibK = new float[OghBLRYgZfoobrhKTgbGSFSmSFh];
				hSQNpPKVQzqmHXsYXWEnRBjAPph = new TimerAbs[OghBLRYgZfoobrhKTgbGSFSmSFh];
				ArrayTools.Populate(hSQNpPKVQzqmHXsYXWEnRBjAPph, 0, OghBLRYgZfoobrhKTgbGSFSmSFh);
				fztGCZBGsqoPPyFMeCOIVvuEZcGl = true;
			}
			if (whqrPnRNEDctHvdjThUpHsqpUGr != Guid.Empty)
			{
				IList<HardwareJoystickTemplateMap> list = ReInput.GUXvLJGdwZfIpEERnhhUakZVWei(whqrPnRNEDctHvdjThUpHsqpUGr);
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
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(hardwareJoystickTemplateMap.Guid, new ControllerTemplate.vJpxyzAPgFJpoYbgmnjsfIfNSQv(this, hardwareJoystickTemplateMap));
							if (controllerTemplate == null)
							{
								throw new Exception(string.Concat("Controller Template for guid ", hardwareJoystickTemplateMap.Guid, " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?"));
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
						VPmIumURnacprhihAJMOLbDiKmb(list2.ToArray());
					}
				}
			}
			ANKdbHXpmTNShTcixGbSxMIpqJK();
		}

		private Joystick(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Joystick, hardwareTypeGuid, axisCount, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			if (hardwareMap == null || hardwareMap.joystickTypes == null || hardwareMap.joystickTypes.Length == 0)
			{
				JoystickType[] gDWHhjsPeLInlJOqRnGxhFOGequs = new JoystickType[1];
				GDWHhjsPeLInlJOqRnGxhFOGequs = gDWHhjsPeLInlJOqRnGxhFOGequs;
			}
			else
			{
				GDWHhjsPeLInlJOqRnGxhFOGequs = hardwareMap.joystickTypes;
			}
			paRisdaLrNhPDEhLifsjQgAqkOzb = new ReadOnlyCollection<JoystickType>(GDWHhjsPeLInlJOqRnGxhFOGequs);
			wluJKdumRlvAwdKGuMIsACqyRqz = hardwareMap.hatCount;
			kZRWBYoAxtUAijchebMlYejYoBq = new Hat[wluJKdumRlvAwdKGuMIsACqyRqz];
			for (int i = 0; i < wluJKdumRlvAwdKGuMIsACqyRqz; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = hardwareMap.GetHatData(i);
				if (hatData == null)
				{
					Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
					kZRWBYoAxtUAijchebMlYejYoBq[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					continue;
				}
				List<Button> list = new List<Button>();
				List<int> list2 = new List<int>();
				for (int j = 0; j < hatData.elementCount; j++)
				{
					int componentElementIdentifierId = hatData.GetComponentElementIdentifierId(j);
					if (!ArrayTools.Contains(hardwareMap.buttonElementIdentifierIds, componentElementIdentifierId))
					{
						list.Add(null);
						list2.Add(-1);
						continue;
					}
					int buttonIndex = hardwareMap.GetButtonIndex(componentElementIdentifierId);
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
					kZRWBYoAxtUAijchebMlYejYoBq[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
				}
				catch
				{
					Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
					kZRWBYoAxtUAijchebMlYejYoBq[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
				}
			}
			YrIJNJMxeHIsHLwCsMYyIwjItMc = new ReadOnlyCollection<Hat>(kZRWBYoAxtUAijchebMlYejYoBq);
		}

		internal bool waUEGujjJRujuipJzDNtBBYbLtUd(JoystickType P_0)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int num = GDWHhjsPeLInlJOqRnGxhFOGequs.Length;
			for (int i = 0; i < num; i++)
			{
				if (GDWHhjsPeLInlJOqRnGxhFOGequs[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else
			{
				if (!FKavmUmzhTUsUTKzquAriSPWQHJ)
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
				if (fztGCZBGsqoPPyFMeCOIVvuEZcGl)
				{
					if (OghBLRYgZfoobrhKTgbGSFSmSFh > 0)
					{
						uLUSHqqlyIwztrGtwuJOCAwLAej(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (OghBLRYgZfoobrhKTgbGSFSmSFh > 1)
					{
						uLUSHqqlyIwztrGtwuJOCAwLAej(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					MswCOiBoxSXbPAaqPSkaEnLrZRsW();
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else if (FKavmUmzhTUsUTKzquAriSPWQHJ && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (fztGCZBGsqoPPyFMeCOIVvuEZcGl && motorIndex < OghBLRYgZfoobrhKTgbGSFSmSFh)
				{
					uLUSHqqlyIwztrGtwuJOCAwLAej(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0f;
			}
			if (!FKavmUmzhTUsUTKzquAriSPWQHJ || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!fztGCZBGsqoPPyFMeCOIVvuEZcGl)
			{
				return 0f;
			}
			if (motorIndex >= OghBLRYgZfoobrhKTgbGSFSmSFh)
			{
				return 0f;
			}
			return nqDgXahbomLmqDfwtwIMtWJyibK[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
			}
			else
			{
				if (!FKavmUmzhTUsUTKzquAriSPWQHJ)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (fztGCZBGsqoPPyFMeCOIVvuEZcGl)
				{
					Array.Clear(nqDgXahbomLmqDfwtwIMtWJyibK, 0, nqDgXahbomLmqDfwtwIMtWJyibK.Length);
					for (int i = 0; i < OghBLRYgZfoobrhKTgbGSFSmSFh; i++)
					{
						hSQNpPKVQzqmHXsYXWEnRBjAPph[i].Clear();
					}
				}
				if (FpiBbVxDPXwNPsxBjglRbalnBLv != null)
				{
					FpiBbVxDPXwNPsxBjglRbalnBLv.StopVibration();
				}
			}
		}

		internal override void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
			base.KcNfORqUkjxfSzjWExwXXCRKlZu(P_0);
			for (int i = 0; i < wluJKdumRlvAwdKGuMIsACqyRqz; i++)
			{
				if (kZRWBYoAxtUAijchebMlYejYoBq[i] != null)
				{
					kZRWBYoAxtUAijchebMlYejYoBq[i].VEShBtNHGklmRUxZTegSZNXZpDo(P_0, QlXkhNBHPYUNWwhKurdwrqFgWTf);
				}
			}
			AdgerJOJHeELnHnJdXbVLfbiaXX();
		}

		internal void FMngbHlSISVmcoIhmlrHQoUqlno(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				FMngbHlSISVmcoIhmlrHQoUqlno(P_0.sourceJoystick);
			}
		}

		internal void FMngbHlSISVmcoIhmlrHQoUqlno(BridgedController P_0)
		{
			if (P_0 != null)
			{
				FMngbHlSISVmcoIhmlrHQoUqlno(P_0.sourceJoystick);
			}
		}

		private void FMngbHlSISVmcoIhmlrHQoUqlno(IInputManagerJoystickPublic P_0)
		{
			FpiBbVxDPXwNPsxBjglRbalnBLv = P_0;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					MaqBxIfsVBIKoTpaiokNgulHaUMu(P_0.extension);
				}
				else
				{
					MQlLBrEAWyhDmoKqYimFKMGgKUX(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal override void VcHhfbFqwxAmqhwBHKVJpDjlfufe()
		{
			base.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			StopVibration();
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (fztGCZBGsqoPPyFMeCOIVvuEZcGl)
			{
				Array.Clear(nqDgXahbomLmqDfwtwIMtWJyibK, 0, nqDgXahbomLmqDfwtwIMtWJyibK.Length);
				for (int i = 0; i < OghBLRYgZfoobrhKTgbGSFSmSFh; i++)
				{
					hSQNpPKVQzqmHXsYXWEnRBjAPph[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void AdgerJOJHeELnHnJdXbVLfbiaXX()
		{
			if (!FKavmUmzhTUsUTKzquAriSPWQHJ || !fztGCZBGsqoPPyFMeCOIVvuEZcGl)
			{
				return;
			}
			for (int i = 0; i < OghBLRYgZfoobrhKTgbGSFSmSFh; i++)
			{
				if (hSQNpPKVQzqmHXsYXWEnRBjAPph[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void uLUSHqqlyIwztrGtwuJOCAwLAej(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!fztGCZBGsqoPPyFMeCOIVvuEZcGl || P_0 < 0 || P_0 >= OghBLRYgZfoobrhKTgbGSFSmSFh)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(nqDgXahbomLmqDfwtwIMtWJyibK, 0, nqDgXahbomLmqDfwtwIMtWJyibK.Length);
				for (int i = 0; i < OghBLRYgZfoobrhKTgbGSFSmSFh; i++)
				{
					hSQNpPKVQzqmHXsYXWEnRBjAPph[i].Clear();
				}
			}
			nqDgXahbomLmqDfwtwIMtWJyibK[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				hSQNpPKVQzqmHXsYXWEnRBjAPph[P_0].Clear();
			}
			else
			{
				hSQNpPKVQzqmHXsYXWEnRBjAPph[P_0].Start(P_2);
			}
			if (P_4)
			{
				MswCOiBoxSXbPAaqPSkaEnLrZRsW();
			}
		}

		private void MswCOiBoxSXbPAaqPSkaEnLrZRsW()
		{
			if (FKavmUmzhTUsUTKzquAriSPWQHJ && fztGCZBGsqoPPyFMeCOIVvuEZcGl && FpiBbVxDPXwNPsxBjglRbalnBLv != null)
			{
				for (int i = 0; i < nqDgXahbomLmqDfwtwIMtWJyibK.Length; i++)
				{
					FpiBbVxDPXwNPsxBjglRbalnBLv.SetVibration(nqDgXahbomLmqDfwtwIMtWJyibK[i], i);
				}
			}
		}

		private void wrBtfHDpnuDzlIjZsTomwvhcGcB()
		{
		}

		internal static int GjOtUikaRXonJoEqPEQUwdULwhf(Joystick P_0, Joystick P_1)
		{
			if (P_0.inputManagerId < P_1.inputManagerId)
			{
				return -1;
			}
			if (P_0.inputManagerId > P_1.inputManagerId)
			{
				return 1;
			}
			return 0;
		}
	}
}
