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
		private const int fDEOOCmtiAjnQVMSDKaROuOqBUs = 0;

		private const int UhrYGflkUVCpGIspwUHIbYMQDVp = 1;

		private IInputManagerJoystickPublic rfIBadCiqSERTkpvqniWAnYLCXXE;

		private readonly JoystickType[] ykqwOHLxXUsGjTjGEXEcBnnchkC;

		private readonly ReadOnlyCollection<JoystickType> VTfsDFuJYGMyZgLlptqiapfYeEN;

		private readonly bool doEYUoXAmEtSKKXozywgwojoYnT;

		private readonly bool DSFrnfhuBjkcDQBixUGDxCBgvum;

		private readonly bool KPxEHuioHijbIqMdvxuweHbMWGK;

		private readonly int eTBgMjpiluJNdqaLMrEVSflKDLu;

		private readonly float[] TDnUqQIrBfLXectSumCTxAsKDpwD;

		private readonly TimerAbs[] VguqHjnxEkZmTEyWCCfqLOLgVpD;

		private readonly int SCZmXOZoaMKuAqgrKAbzOTWDVFF;

		private readonly Hat[] WVntsiLebwHbqyNTrPpgQlAewiE;

		private readonly ReadOnlyCollection<Hat> uxwxepdpDIkBDGPqjAYvcWOcQUYI;

		internal IList<JoystickType> joystickTypes
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return VTfsDFuJYGMyZgLlptqiapfYeEN;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1L;
				}
				return rfIBadCiqSERTkpvqniWAnYLCXXE.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return -1;
				}
				return rfIBadCiqSERTkpvqniWAnYLCXXE.unityId;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Guid.Empty;
				}
				return rfIBadCiqSERTkpvqniWAnYLCXXE.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return doEYUoXAmEtSKKXozywgwojoYnT;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0f;
				}
				if (!doEYUoXAmEtSKKXozywgwojoYnT)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 0)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!DSFrnfhuBjkcDQBixUGDxCBgvum)
				{
					return 0f;
				}
				if (eTBgMjpiluJNdqaLMrEVSflKDLu > 0)
				{
					return TDnUqQIrBfLXectSumCTxAsKDpwD[0];
				}
				return 0f;
			}
			set
			{
				if (doEYUoXAmEtSKKXozywgwojoYnT)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 0)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (DSFrnfhuBjkcDQBixUGDxCBgvum && 0 < eTBgMjpiluJNdqaLMrEVSflKDLu)
					{
						EYkdCfTrQXZtbmForkJGYfnnKPC(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0f;
				}
				if (!doEYUoXAmEtSKKXozywgwojoYnT)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 1)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!DSFrnfhuBjkcDQBixUGDxCBgvum)
				{
					return 0f;
				}
				if (eTBgMjpiluJNdqaLMrEVSflKDLu > 1)
				{
					return TDnUqQIrBfLXectSumCTxAsKDpwD[1];
				}
				return 0f;
			}
			set
			{
				if (doEYUoXAmEtSKKXozywgwojoYnT)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 1)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (DSFrnfhuBjkcDQBixUGDxCBgvum && 1 < eTBgMjpiluJNdqaLMrEVSflKDLu)
					{
						EYkdCfTrQXZtbmForkJGYfnnKPC(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return eTBgMjpiluJNdqaLMrEVSflKDLu;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return SCZmXOZoaMKuAqgrKAbzOTWDVFF;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return uxwxepdpDIkBDGPqjAYvcWOcQUYI;
			}
		}

		internal int inputManagerId => rfIBadCiqSERTkpvqniWAnYLCXXE.inputManagerId;

		internal HardwareControllerMapIdentifier hardwareJoystickMapIdentifier
		{
			get
			{
				if (ZBMEOTEbHBcUeYYftsfiohhXNEse == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return ZBMEOTEbHBcUeYYftsfiohhXNEse.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController controller)
			: this(controller.sourceJoystick.rewiredId, controller.inputSource, controller.sourceJoystick.name, (controller.hw_isBluetoothDevice && !string.IsNullOrEmpty(controller.hw_bluetoothDeviceName)) ? controller.hw_bluetoothDeviceName : controller.productName, controller.hardwareIdentifier, controller.controllerTypeGuid, controller.axisCount, controller.buttonCount, controller.isButtonPressureSensitive, controller.gameHardwareMap, controller.controllerExtension, new ControllerDataUpdater(controller.inputManagerSource, controller.axisCount, controller.buttonCount, controller.unknownControllerHats))
		{
			rfIBadCiqSERTkpvqniWAnYLCXXE = controller.sourceJoystick;
			doEYUoXAmEtSKKXozywgwojoYnT = controller.hw_supportsVibration;
			KPxEHuioHijbIqMdvxuweHbMWGK = controller.hw_supportsVoice;
			eTBgMjpiluJNdqaLMrEVSflKDLu = ((!(controller.controllerExtension is IControllerVibrator)) ? controller.hw_localVibrationMotorCount : 0);
			if (doEYUoXAmEtSKKXozywgwojoYnT && eTBgMjpiluJNdqaLMrEVSflKDLu > 0)
			{
				TDnUqQIrBfLXectSumCTxAsKDpwD = new float[eTBgMjpiluJNdqaLMrEVSflKDLu];
				VguqHjnxEkZmTEyWCCfqLOLgVpD = new TimerAbs[eTBgMjpiluJNdqaLMrEVSflKDLu];
				ArrayTools.Populate(VguqHjnxEkZmTEyWCCfqLOLgVpD, 0, eTBgMjpiluJNdqaLMrEVSflKDLu);
				DSFrnfhuBjkcDQBixUGDxCBgvum = true;
			}
			if (EAIQLWgbsQDNGcJuOWaoPBaXKTl != Guid.Empty)
			{
				IList<HardwareJoystickTemplateMap> list = ReInput.sQzbEhzfZYwQlNlpwwtVmsyxCQA(EAIQLWgbsQDNGcJuOWaoPBaXKTl);
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
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(hardwareJoystickTemplateMap.Guid, new ControllerTemplate.HuDhZDlXBAKGuPzYzBrjxzAdvGJ(this, hardwareJoystickTemplateMap));
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
						vSYvCCxGYdVIvgTuHTKLFuJCAuN(list2.ToArray());
					}
				}
			}
			guKElsGLCmgnAbWmxWZxRdTPwg();
		}

		private Joystick(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, ControllerType.Joystick, hardwareTypeGuid, axisCount, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			if (hardwareMap == null || hardwareMap.joystickTypes == null || hardwareMap.joystickTypes.Length == 0)
			{
				JoystickType[] array = new JoystickType[1];
				ykqwOHLxXUsGjTjGEXEcBnnchkC = array;
			}
			else
			{
				ykqwOHLxXUsGjTjGEXEcBnnchkC = hardwareMap.joystickTypes;
			}
			VTfsDFuJYGMyZgLlptqiapfYeEN = new ReadOnlyCollection<JoystickType>(ykqwOHLxXUsGjTjGEXEcBnnchkC);
			SCZmXOZoaMKuAqgrKAbzOTWDVFF = hardwareMap.hatCount;
			WVntsiLebwHbqyNTrPpgQlAewiE = new Hat[SCZmXOZoaMKuAqgrKAbzOTWDVFF];
			for (int i = 0; i < SCZmXOZoaMKuAqgrKAbzOTWDVFF; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = hardwareMap.GetHatData(i);
				if (hatData == null)
				{
					Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
					WVntsiLebwHbqyNTrPpgQlAewiE[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
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
					WVntsiLebwHbqyNTrPpgQlAewiE[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
				}
				catch
				{
					Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
					WVntsiLebwHbqyNTrPpgQlAewiE[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
				}
			}
			uxwxepdpDIkBDGPqjAYvcWOcQUYI = new ReadOnlyCollection<Hat>(WVntsiLebwHbqyNTrPpgQlAewiE);
		}

		internal bool UDyQnKGDoYgAigsbgQDqvJznKrgb(JoystickType P_0)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int num = ykqwOHLxXUsGjTjGEXEcBnnchkC.Length;
			for (int i = 0; i < num; i++)
			{
				if (ykqwOHLxXUsGjTjGEXEcBnnchkC[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else
			{
				if (!doEYUoXAmEtSKKXozywgwojoYnT)
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
				if (DSFrnfhuBjkcDQBixUGDxCBgvum)
				{
					if (eTBgMjpiluJNdqaLMrEVSflKDLu > 0)
					{
						EYkdCfTrQXZtbmForkJGYfnnKPC(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (eTBgMjpiluJNdqaLMrEVSflKDLu > 1)
					{
						EYkdCfTrQXZtbmForkJGYfnnKPC(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					qcWNbITQEHEKVzhAChafhEkDvHK();
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
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else if (doEYUoXAmEtSKKXozywgwojoYnT && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (DSFrnfhuBjkcDQBixUGDxCBgvum && motorIndex < eTBgMjpiluJNdqaLMrEVSflKDLu)
				{
					EYkdCfTrQXZtbmForkJGYfnnKPC(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0f;
			}
			if (!doEYUoXAmEtSKKXozywgwojoYnT || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!DSFrnfhuBjkcDQBixUGDxCBgvum)
			{
				return 0f;
			}
			if (motorIndex >= eTBgMjpiluJNdqaLMrEVSflKDLu)
			{
				return 0f;
			}
			return TDnUqQIrBfLXectSumCTxAsKDpwD[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
			}
			else
			{
				if (!doEYUoXAmEtSKKXozywgwojoYnT)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (DSFrnfhuBjkcDQBixUGDxCBgvum)
				{
					Array.Clear(TDnUqQIrBfLXectSumCTxAsKDpwD, 0, TDnUqQIrBfLXectSumCTxAsKDpwD.Length);
					for (int i = 0; i < eTBgMjpiluJNdqaLMrEVSflKDLu; i++)
					{
						VguqHjnxEkZmTEyWCCfqLOLgVpD[i].Clear();
					}
				}
				if (rfIBadCiqSERTkpvqniWAnYLCXXE != null)
				{
					rfIBadCiqSERTkpvqniWAnYLCXXE.StopVibration();
				}
			}
		}

		internal override void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
			base.qLvftnPJXcUYQsqiHkMAPRekFwO(P_0);
			for (int i = 0; i < SCZmXOZoaMKuAqgrKAbzOTWDVFF; i++)
			{
				if (WVntsiLebwHbqyNTrPpgQlAewiE[i] != null)
				{
					WVntsiLebwHbqyNTrPpgQlAewiE[i].zAgCsBucdziQVBRjAkuDNPybKpO(P_0, ebxBmtwxyRprAbJBnnRdvbVCKbL);
				}
			}
			iqIALhjYezdflYrpgSZUFTUYBiz();
		}

		internal void hzVtWbKoxBiVifQXnOxAGNpQbbY(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				hzVtWbKoxBiVifQXnOxAGNpQbbY(P_0.sourceJoystick);
			}
		}

		internal void hzVtWbKoxBiVifQXnOxAGNpQbbY(BridgedController P_0)
		{
			if (P_0 != null)
			{
				hzVtWbKoxBiVifQXnOxAGNpQbbY(P_0.sourceJoystick);
			}
		}

		private void hzVtWbKoxBiVifQXnOxAGNpQbbY(IInputManagerJoystickPublic P_0)
		{
			rfIBadCiqSERTkpvqniWAnYLCXXE = P_0;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					cTKkQwFScGrhoczGzTiQqMASUOy(P_0.extension);
				}
				else
				{
					yWNmUHhwhnWFmbWqRkbfWBhSgQq(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal override void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			base.dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			StopVibration();
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (DSFrnfhuBjkcDQBixUGDxCBgvum)
			{
				Array.Clear(TDnUqQIrBfLXectSumCTxAsKDpwD, 0, TDnUqQIrBfLXectSumCTxAsKDpwD.Length);
				for (int i = 0; i < eTBgMjpiluJNdqaLMrEVSflKDLu; i++)
				{
					VguqHjnxEkZmTEyWCCfqLOLgVpD[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void iqIALhjYezdflYrpgSZUFTUYBiz()
		{
			if (!doEYUoXAmEtSKKXozywgwojoYnT || !DSFrnfhuBjkcDQBixUGDxCBgvum)
			{
				return;
			}
			for (int i = 0; i < eTBgMjpiluJNdqaLMrEVSflKDLu; i++)
			{
				if (VguqHjnxEkZmTEyWCCfqLOLgVpD[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void EYkdCfTrQXZtbmForkJGYfnnKPC(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!DSFrnfhuBjkcDQBixUGDxCBgvum || P_0 < 0 || P_0 >= eTBgMjpiluJNdqaLMrEVSflKDLu)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(TDnUqQIrBfLXectSumCTxAsKDpwD, 0, TDnUqQIrBfLXectSumCTxAsKDpwD.Length);
				for (int i = 0; i < eTBgMjpiluJNdqaLMrEVSflKDLu; i++)
				{
					VguqHjnxEkZmTEyWCCfqLOLgVpD[i].Clear();
				}
			}
			TDnUqQIrBfLXectSumCTxAsKDpwD[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				VguqHjnxEkZmTEyWCCfqLOLgVpD[P_0].Clear();
			}
			else
			{
				VguqHjnxEkZmTEyWCCfqLOLgVpD[P_0].Start(P_2);
			}
			if (P_4)
			{
				qcWNbITQEHEKVzhAChafhEkDvHK();
			}
		}

		private void qcWNbITQEHEKVzhAChafhEkDvHK()
		{
			if (doEYUoXAmEtSKKXozywgwojoYnT && DSFrnfhuBjkcDQBixUGDxCBgvum && rfIBadCiqSERTkpvqniWAnYLCXXE != null)
			{
				for (int i = 0; i < TDnUqQIrBfLXectSumCTxAsKDpwD.Length; i++)
				{
					rfIBadCiqSERTkpvqniWAnYLCXXE.SetVibration(TDnUqQIrBfLXectSumCTxAsKDpwD[i], i);
				}
			}
		}

		private void EKtDMrmxIphQrLqdxsyfeKASUsr()
		{
		}

		internal static int mcKQGHDmIrJRGdYIDEXqqnlmnBU(Joystick P_0, Joystick P_1)
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
