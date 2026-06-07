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
		private const int TFUNNCCCyzBDrrswlncQsEnSWCUL = 0;

		private const int iCtLorZPIuLejEOFCYfTkebcDBJy = 1;

		private IInputManagerJoystickPublic NGGCdldmafityAXNOqnLyBtdiZjMA;

		private readonly JoystickType[] GtuZnRzQDnsBOtlkoBXzhuSGsEkI;

		private readonly ReadOnlyCollection<JoystickType> lRfYWZQUDjSxqUJUThllESUuCGfe;

		private readonly bool NlEsLwrKCjqFrmBfZfjrECLGFIHGb;

		private readonly bool xqNirlJBkMOaswGvDBOGRgkMgEUD;

		private readonly bool cixQEmCLnZZSfYFIBpbjKDCkSZqF;

		private readonly int AsTPrhBOwVirWSiSaPkYiBYwYVtV;

		private readonly float[] dilbvUiHtYfgLWwVSNTAVBZchSxc;

		private readonly TimerAbs[] hesHthBSpPCxecJCoIHxlTtAsZpM;

		private readonly int afMIxBrXmXrqVGpSHUPmcKwoLJjm;

		private readonly Hat[] osjcmqtxfDATJKIlJrinuyrAIscRA;

		private readonly ReadOnlyCollection<Hat> OfarxzVBZhlkkqfWJTviiLzKGtyg;

		internal IList<JoystickType> gblvScfyvozvFqGbesEpZxqIczti
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return lRfYWZQUDjSxqUJUThllESUuCGfe;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return -1L;
				}
				return NGGCdldmafityAXNOqnLyBtdiZjMA.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return -1;
				}
				return NGGCdldmafityAXNOqnLyBtdiZjMA.unityId;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Guid.Empty;
				}
				return NGGCdldmafityAXNOqnLyBtdiZjMA.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return false;
				}
				return NlEsLwrKCjqFrmBfZfjrECLGFIHGb;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0f;
				}
				if (!NlEsLwrKCjqFrmBfZfjrECLGFIHGb)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!xqNirlJBkMOaswGvDBOGRgkMgEUD)
				{
					return 0f;
				}
				if (AsTPrhBOwVirWSiSaPkYiBYwYVtV > 0)
				{
					return dilbvUiHtYfgLWwVSNTAVBZchSxc[0];
				}
				return 0f;
			}
			set
			{
				if (NlEsLwrKCjqFrmBfZfjrECLGFIHGb)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >0 } controllerVibrator)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (xqNirlJBkMOaswGvDBOGRgkMgEUD && 0 < AsTPrhBOwVirWSiSaPkYiBYwYVtV)
					{
						eckYuhrQGmhxKCkKPQpDiTCNKwwK(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0f;
				}
				if (!NlEsLwrKCjqFrmBfZfjrECLGFIHGb)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!xqNirlJBkMOaswGvDBOGRgkMgEUD)
				{
					return 0f;
				}
				if (AsTPrhBOwVirWSiSaPkYiBYwYVtV > 1)
				{
					return dilbvUiHtYfgLWwVSNTAVBZchSxc[1];
				}
				return 0f;
			}
			set
			{
				if (NlEsLwrKCjqFrmBfZfjrECLGFIHGb)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator { vibrationMotorCount: >1 } controllerVibrator)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (xqNirlJBkMOaswGvDBOGRgkMgEUD && 1 < AsTPrhBOwVirWSiSaPkYiBYwYVtV)
					{
						eckYuhrQGmhxKCkKPQpDiTCNKwwK(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return AsTPrhBOwVirWSiSaPkYiBYwYVtV;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return afMIxBrXmXrqVGpSHUPmcKwoLJjm;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return OfarxzVBZhlkkqfWJTviiLzKGtyg;
			}
		}

		internal int qaWdomDkXYbyYcgkBEEJSjidPqMv => NGGCdldmafityAXNOqnLyBtdiZjMA.inputManagerId;

		internal HardwareControllerMapIdentifier QffiBMTMryEswOxOSXKFrNXqjHhj
		{
			get
			{
				if (jnGTQDFeNsixRwgRJcghDqCbQWSP == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return jnGTQDFeNsixRwgRJcghDqCbQWSP.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController P_0)
			: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
		{
			NGGCdldmafityAXNOqnLyBtdiZjMA = P_0.sourceJoystick;
			NlEsLwrKCjqFrmBfZfjrECLGFIHGb = P_0.hw_supportsVibration;
			cixQEmCLnZZSfYFIBpbjKDCkSZqF = P_0.hw_supportsVoice;
			AsTPrhBOwVirWSiSaPkYiBYwYVtV = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
			if (NlEsLwrKCjqFrmBfZfjrECLGFIHGb && AsTPrhBOwVirWSiSaPkYiBYwYVtV > 0)
			{
				dilbvUiHtYfgLWwVSNTAVBZchSxc = new float[AsTPrhBOwVirWSiSaPkYiBYwYVtV];
				hesHthBSpPCxecJCoIHxlTtAsZpM = new TimerAbs[AsTPrhBOwVirWSiSaPkYiBYwYVtV];
				ArrayTools.Populate(hesHthBSpPCxecJCoIHxlTtAsZpM, 0, AsTPrhBOwVirWSiSaPkYiBYwYVtV);
				xqNirlJBkMOaswGvDBOGRgkMgEUD = true;
			}
			if (ajOkBXCGxlWjiAJvaOHxjyadfWfu != Guid.Empty)
			{
				IList<HardwareJoystickTemplateMap> list = ReInput.UUdaBjbHBlTkYdRHEciSYTDLHKiz(ajOkBXCGxlWjiAJvaOHxjyadfWfu);
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
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(hardwareJoystickTemplateMap.Guid, new ControllerTemplate.feVKXHBPShqNDdopDgaTXfGJMrbc(this, hardwareJoystickTemplateMap));
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
						TGYesMFrSMGpMWYtbuUUruLunOlp(list2.ToArray());
					}
				}
			}
			WCmnBnYePrGAMdoiUNBATVOhqgEEA();
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
		{
			if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
			{
				GtuZnRzQDnsBOtlkoBXzhuSGsEkI = new JoystickType[1];
			}
			else
			{
				GtuZnRzQDnsBOtlkoBXzhuSGsEkI = P_9.joystickTypes;
			}
			lRfYWZQUDjSxqUJUThllESUuCGfe = new ReadOnlyCollection<JoystickType>(GtuZnRzQDnsBOtlkoBXzhuSGsEkI);
			afMIxBrXmXrqVGpSHUPmcKwoLJjm = P_9.hatCount;
			osjcmqtxfDATJKIlJrinuyrAIscRA = new Hat[afMIxBrXmXrqVGpSHUPmcKwoLJjm];
			for (int i = 0; i < afMIxBrXmXrqVGpSHUPmcKwoLJjm; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						osjcmqtxfDATJKIlJrinuyrAIscRA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
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
						osjcmqtxfDATJKIlJrinuyrAIscRA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
						osjcmqtxfDATJKIlJrinuyrAIscRA[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					}
				}
				finally
				{
					zHkFavizqbDuYMnEoaQQxVsTmUceA(osjcmqtxfDATJKIlJrinuyrAIscRA[i]);
				}
			}
			OfarxzVBZhlkkqfWJTviiLzKGtyg = new ReadOnlyCollection<Hat>(osjcmqtxfDATJKIlJrinuyrAIscRA);
		}

		internal bool uvcoqQqmrleBNYXAMWMhdWdTvgQg(JoystickType P_0)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return false;
			}
			int num = GtuZnRzQDnsBOtlkoBXzhuSGsEkI.Length;
			for (int i = 0; i < num; i++)
			{
				if (GtuZnRzQDnsBOtlkoBXzhuSGsEkI[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
			}
			else
			{
				if (!NlEsLwrKCjqFrmBfZfjrECLGFIHGb)
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
				if (xqNirlJBkMOaswGvDBOGRgkMgEUD)
				{
					if (AsTPrhBOwVirWSiSaPkYiBYwYVtV > 0)
					{
						eckYuhrQGmhxKCkKPQpDiTCNKwwK(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (AsTPrhBOwVirWSiSaPkYiBYwYVtV > 1)
					{
						eckYuhrQGmhxKCkKPQpDiTCNKwwK(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					MZSgYGhYocewiTaTylarBTZjLmac();
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
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
			}
			else if (NlEsLwrKCjqFrmBfZfjrECLGFIHGb && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (xqNirlJBkMOaswGvDBOGRgkMgEUD && motorIndex < AsTPrhBOwVirWSiSaPkYiBYwYVtV)
				{
					eckYuhrQGmhxKCkKPQpDiTCNKwwK(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0f;
			}
			if (!NlEsLwrKCjqFrmBfZfjrECLGFIHGb || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!xqNirlJBkMOaswGvDBOGRgkMgEUD)
			{
				return 0f;
			}
			if (motorIndex >= AsTPrhBOwVirWSiSaPkYiBYwYVtV)
			{
				return 0f;
			}
			return dilbvUiHtYfgLWwVSNTAVBZchSxc[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
			}
			else
			{
				if (!NlEsLwrKCjqFrmBfZfjrECLGFIHGb)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (xqNirlJBkMOaswGvDBOGRgkMgEUD)
				{
					Array.Clear(dilbvUiHtYfgLWwVSNTAVBZchSxc, 0, dilbvUiHtYfgLWwVSNTAVBZchSxc.Length);
					for (int i = 0; i < AsTPrhBOwVirWSiSaPkYiBYwYVtV; i++)
					{
						hesHthBSpPCxecJCoIHxlTtAsZpM[i].Clear();
					}
				}
				if (NGGCdldmafityAXNOqnLyBtdiZjMA != null)
				{
					NGGCdldmafityAXNOqnLyBtdiZjMA.StopVibration();
				}
			}
		}

		internal override void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
			base.OPzMeptHNTMsrWdWvslRxoVUdTujA(P_0);
			for (int i = 0; i < afMIxBrXmXrqVGpSHUPmcKwoLJjm; i++)
			{
				if (osjcmqtxfDATJKIlJrinuyrAIscRA[i] != null)
				{
					osjcmqtxfDATJKIlJrinuyrAIscRA[i].HKmEXBOMtGYkijZBmPdErwHXVruq(P_0, WlduKdCdymfJzhLxPcswpRugJOzgb);
				}
			}
			AMMeAhkLwOBFGwkLSkKJbpphoqDmc();
		}

		internal void VbVBYliTbuvVNPetPsBZqFKmHxco(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				VbVBYliTbuvVNPetPsBZqFKmHxco(P_0.sourceJoystick);
			}
		}

		internal void VbVBYliTbuvVNPetPsBZqFKmHxco(BridgedController P_0)
		{
			if (P_0 != null)
			{
				VbVBYliTbuvVNPetPsBZqFKmHxco(P_0.sourceJoystick);
			}
		}

		private void VbVBYliTbuvVNPetPsBZqFKmHxco(IInputManagerJoystickPublic P_0)
		{
			NGGCdldmafityAXNOqnLyBtdiZjMA = P_0;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					KCCLiPpizAZVlUwLGfVBUliUUOBb(P_0.extension);
				}
				else
				{
					AgRSpBTkpMroZBOUrPrqgqIkOGWn(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal override void HnrFpPpHGPbrJRZcbYcTrFvnwjvi()
		{
			base.HnrFpPpHGPbrJRZcbYcTrFvnwjvi();
			StopVibration();
		}

		internal override void ciqEMkdNIetcwAdDEzSvXOVSVQfM(bool P_0)
		{
			base.ciqEMkdNIetcwAdDEzSvXOVSVQfM(P_0);
			if (!P_0 && !ReInput.applicationRunInBackground)
			{
				StopVibration();
			}
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (xqNirlJBkMOaswGvDBOGRgkMgEUD)
			{
				Array.Clear(dilbvUiHtYfgLWwVSNTAVBZchSxc, 0, dilbvUiHtYfgLWwVSNTAVBZchSxc.Length);
				for (int i = 0; i < AsTPrhBOwVirWSiSaPkYiBYwYVtV; i++)
				{
					hesHthBSpPCxecJCoIHxlTtAsZpM[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void AMMeAhkLwOBFGwkLSkKJbpphoqDmc()
		{
			if (!NlEsLwrKCjqFrmBfZfjrECLGFIHGb || !xqNirlJBkMOaswGvDBOGRgkMgEUD)
			{
				return;
			}
			for (int i = 0; i < AsTPrhBOwVirWSiSaPkYiBYwYVtV; i++)
			{
				if (hesHthBSpPCxecJCoIHxlTtAsZpM[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void eckYuhrQGmhxKCkKPQpDiTCNKwwK(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!xqNirlJBkMOaswGvDBOGRgkMgEUD || P_0 < 0 || P_0 >= AsTPrhBOwVirWSiSaPkYiBYwYVtV)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(dilbvUiHtYfgLWwVSNTAVBZchSxc, 0, dilbvUiHtYfgLWwVSNTAVBZchSxc.Length);
				for (int i = 0; i < AsTPrhBOwVirWSiSaPkYiBYwYVtV; i++)
				{
					hesHthBSpPCxecJCoIHxlTtAsZpM[i].Clear();
				}
			}
			dilbvUiHtYfgLWwVSNTAVBZchSxc[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				hesHthBSpPCxecJCoIHxlTtAsZpM[P_0].Clear();
			}
			else
			{
				hesHthBSpPCxecJCoIHxlTtAsZpM[P_0].Start(P_2);
			}
			if (P_4)
			{
				MZSgYGhYocewiTaTylarBTZjLmac();
			}
		}

		private void MZSgYGhYocewiTaTylarBTZjLmac()
		{
			if (NlEsLwrKCjqFrmBfZfjrECLGFIHGb && xqNirlJBkMOaswGvDBOGRgkMgEUD && NGGCdldmafityAXNOqnLyBtdiZjMA != null)
			{
				for (int i = 0; i < dilbvUiHtYfgLWwVSNTAVBZchSxc.Length; i++)
				{
					NGGCdldmafityAXNOqnLyBtdiZjMA.SetVibration(dilbvUiHtYfgLWwVSNTAVBZchSxc[i], i);
				}
			}
		}

		private void cWtBAxEKfCaXWlJKNdpiEdvygRFd()
		{
		}

		internal static int IlwjNInzmxvVcBXkwDzCSGORdgzi(Joystick P_0, Joystick P_1)
		{
			if (P_0.qaWdomDkXYbyYcgkBEEJSjidPqMv < P_1.qaWdomDkXYbyYcgkBEEJSjidPqMv)
			{
				return -1;
			}
			if (P_0.qaWdomDkXYbyYcgkBEEJSjidPqMv > P_1.qaWdomDkXYbyYcgkBEEJSjidPqMv)
			{
				return 1;
			}
			return 0;
		}
	}
}
