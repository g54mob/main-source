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
		private const int mCMUGLmnInCoNCCSUSNgihGFqEMKA = 0;

		private const int FmjSOwbMokGiNxBnzYwlfCYxXHBr = 1;

		private IInputManagerJoystickPublic sJYuLwOzGzQTUeJrpPcpOnCeVEnI;

		private readonly JoystickType[] xPcXISTlhxsDsMaSLXpJwnxLOayq;

		private readonly ReadOnlyCollection<JoystickType> EOvoJIiWohpdQthpmdZTeFttoAlTA;

		private readonly bool eOQMBxZDovuMPZyZcDkTHGyJSrJh;

		private readonly bool EnVnfcvQhSgfIeBiodnktGRTTcWwA;

		private readonly bool ZrjgZjgYjFQsFxKzyKHPNsdbCTqK;

		private readonly int tvLmdwjBQRIzuxGiJKLklibxFRtQ;

		private readonly float[] SEfOkNGFxAoEhrhEfYpwOoinBtWx;

		private readonly TimerAbs[] MkjighmVJSIGRMmHAjXytYPDBfgA;

		private readonly int FVQafKJYWTPLttkpgxhUfJgzZmve;

		private readonly Hat[] VvbrMtXdRZHsnfmJqdEFbOCJgVil;

		private readonly ReadOnlyCollection<Hat> fckwwcxajtgQCDXwcVhCVbKJFYibb;

		private readonly int LoFmjIAShhtUkjfRApFcVaVcmXOl;

		private readonly DirectionalPad[] PGdRThSxiZknfEMHzGmTQkzpAErk;

		private readonly ReadOnlyCollection<DirectionalPad> gzxCiRIjIKYlEXcYmKbkFEaZfxey;

		internal IList<JoystickType> DKzAktiVBghArlPHRlOZeKDXsgpoA
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<JoystickType>.EmptyReadOnlyIListT;
				}
				return EOvoJIiWohpdQthpmdZTeFttoAlTA;
			}
		}

		public long? systemId
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1L;
				}
				return sJYuLwOzGzQTUeJrpPcpOnCeVEnI.systemId;
			}
		}

		public int unityId
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return -1;
				}
				return sJYuLwOzGzQTUeJrpPcpOnCeVEnI.unityId;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Guid.Empty;
				}
				return sJYuLwOzGzQTUeJrpPcpOnCeVEnI.persistentGuid;
			}
		}

		public bool supportsVibration
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				return eOQMBxZDovuMPZyZcDkTHGyJSrJh;
			}
		}

		public float vibrationLeftMotor
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0f;
				}
				if (!eOQMBxZDovuMPZyZcDkTHGyJSrJh)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 0)
				{
					return controllerVibrator.GetVibration(0);
				}
				if (!EnVnfcvQhSgfIeBiodnktGRTTcWwA)
				{
					return 0f;
				}
				if (tvLmdwjBQRIzuxGiJKLklibxFRtQ > 0)
				{
					return SEfOkNGFxAoEhrhEfYpwOoinBtWx[0];
				}
				return 0f;
			}
			set
			{
				if (eOQMBxZDovuMPZyZcDkTHGyJSrJh)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 0)
					{
						controllerVibrator.SetVibration(0, value);
					}
					else if (EnVnfcvQhSgfIeBiodnktGRTTcWwA && 0 < tvLmdwjBQRIzuxGiJKLklibxFRtQ)
					{
						JSujtuTpayGuilHcgZKbphdSUXgF(0, value, 0f, false, true);
					}
				}
			}
		}

		public float vibrationRightMotor
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0f;
				}
				if (!eOQMBxZDovuMPZyZcDkTHGyJSrJh)
				{
					return 0f;
				}
				if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 1)
				{
					return controllerVibrator.GetVibration(1);
				}
				if (!EnVnfcvQhSgfIeBiodnktGRTTcWwA)
				{
					return 0f;
				}
				if (tvLmdwjBQRIzuxGiJKLklibxFRtQ > 1)
				{
					return SEfOkNGFxAoEhrhEfYpwOoinBtWx[1];
				}
				return 0f;
			}
			set
			{
				if (eOQMBxZDovuMPZyZcDkTHGyJSrJh)
				{
					value = MathTools.Clamp(value, 0f, 1f);
					if (base.extension is IControllerVibrator controllerVibrator && controllerVibrator.vibrationMotorCount > 1)
					{
						controllerVibrator.SetVibration(1, value);
					}
					else if (EnVnfcvQhSgfIeBiodnktGRTTcWwA && 1 < tvLmdwjBQRIzuxGiJKLklibxFRtQ)
					{
						JSujtuTpayGuilHcgZKbphdSUXgF(1, value, 0f, false, true);
					}
				}
			}
		}

		public int vibrationMotorCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				if (base.extension is IControllerVibrator)
				{
					return (base.extension as IControllerVibrator).vibrationMotorCount;
				}
				return tvLmdwjBQRIzuxGiJKLklibxFRtQ;
			}
		}

		public int hatCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return FVQafKJYWTPLttkpgxhUfJgzZmve;
			}
		}

		public IList<Hat> Hats
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<Hat>.EmptyReadOnlyIListT;
				}
				return fckwwcxajtgQCDXwcVhCVbKJFYibb;
			}
		}

		public int directionalPadCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return LoFmjIAShhtUkjfRApFcVaVcmXOl;
			}
		}

		public IList<DirectionalPad> DirectionalPads
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<DirectionalPad>.EmptyReadOnlyIListT;
				}
				return gzxCiRIjIKYlEXcYmKbkFEaZfxey;
			}
		}

		internal int LxOFdbFfzMSZsGHKiEkdFHVjeyWVB => sJYuLwOzGzQTUeJrpPcpOnCeVEnI.inputManagerId;

		internal HardwareControllerMapIdentifier bjQMBlBXcRlCreyzIvpwhaxSthq
		{
			get
			{
				if (AWCbIECppuLDtCThiwONsElGeIEub == null)
				{
					return default(HardwareControllerMapIdentifier);
				}
				return AWCbIECppuLDtCThiwONsElGeIEub.hardwareMapIdentifier;
			}
		}

		internal Joystick(BridgedController P_0)
			: this(P_0.sourceJoystick.rewiredId, P_0.inputSource, P_0.sourceJoystick.name, (P_0.hw_isBluetoothDevice && !string.IsNullOrEmpty(P_0.hw_bluetoothDeviceName)) ? P_0.hw_bluetoothDeviceName : P_0.productName, P_0.hardwareIdentifier, P_0.controllerTypeGuid, P_0.axisCount, P_0.buttonCount, P_0.isButtonPressureSensitive, P_0.gameHardwareMap, P_0.controllerExtension, new ControllerDataUpdater(P_0.inputManagerSource, P_0.axisCount, P_0.buttonCount, P_0.unknownControllerHats))
		{
			sJYuLwOzGzQTUeJrpPcpOnCeVEnI = P_0.sourceJoystick;
			base.sVSDTFomzlOsrCOaJQrEEeONMSjt = sJYuLwOzGzQTUeJrpPcpOnCeVEnI as ITryGetLocalizedName;
			eOQMBxZDovuMPZyZcDkTHGyJSrJh = P_0.hw_supportsVibration;
			ZrjgZjgYjFQsFxKzyKHPNsdbCTqK = P_0.hw_supportsVoice;
			tvLmdwjBQRIzuxGiJKLklibxFRtQ = ((!(P_0.controllerExtension is IControllerVibrator)) ? P_0.hw_localVibrationMotorCount : 0);
			if (eOQMBxZDovuMPZyZcDkTHGyJSrJh && tvLmdwjBQRIzuxGiJKLklibxFRtQ > 0)
			{
				SEfOkNGFxAoEhrhEfYpwOoinBtWx = new float[tvLmdwjBQRIzuxGiJKLklibxFRtQ];
				MkjighmVJSIGRMmHAjXytYPDBfgA = new TimerAbs[tvLmdwjBQRIzuxGiJKLklibxFRtQ];
				ArrayTools.Populate(MkjighmVJSIGRMmHAjXytYPDBfgA, 0, tvLmdwjBQRIzuxGiJKLklibxFRtQ);
				EnVnfcvQhSgfIeBiodnktGRTTcWwA = true;
			}
			if (FZUSYXsTFrKCEfDGTdZDqHMyUGhC != Guid.Empty)
			{
				IList<OkTaTaYFMOwbkgTtCFcCRyxWNNrJ> list = ReInput.vlnaYafgxhpVmEZvfuGkVTwUsQmr(FZUSYXsTFrKCEfDGTdZDqHMyUGhC);
				if (list != null)
				{
					List<IControllerTemplate> list2 = null;
					for (int i = 0; i < list.Count; i++)
					{
						OkTaTaYFMOwbkgTtCFcCRyxWNNrJ okTaTaYFMOwbkgTtCFcCRyxWNNrJ = list[i];
						if (okTaTaYFMOwbkgTtCFcCRyxWNNrJ == null)
						{
							continue;
						}
						IControllerTemplate controllerTemplate;
						try
						{
							controllerTemplate = UnityTools.externalTools.CreateControllerTemplate(okTaTaYFMOwbkgTtCFcCRyxWNNrJ.eaLeFvhBFvatmpsmBiVAbiuICkILc, new ControllerTemplate.WnRFFOvtjruZdEfEoBGUCWCAbWhO(this, okTaTaYFMOwbkgTtCFcCRyxWNNrJ));
							if (controllerTemplate == null)
							{
								throw new Exception("Controller Template for guid " + okTaTaYFMOwbkgTtCFcCRyxWNNrJ.eaLeFvhBFvatmpsmBiVAbiuICkILc.ToString() + " was not found. If you are using custom Controller Templates, did you export the Controller Templates from the Controller Data Files inspector?");
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
						wALdDCrmIvSwBbNGOseksiAhYCjC(list2.ToArray());
					}
				}
			}
			pggOEkcvhxxBuBDIbrJuSafugeIK();
		}

		private Joystick(int P_0, InputSource P_1, string P_2, string P_3, string P_4, Guid P_5, int P_6, int P_7, bool[] P_8, HardwareControllerMap_Game P_9, Extension P_10, ControllerDataUpdater P_11)
			: base(P_0, P_1, P_2, P_3, P_4, ControllerType.Joystick, P_5, P_6, P_7, P_8, P_9, P_10, P_11)
		{
			if (P_9 == null || P_9.joystickTypes == null || P_9.joystickTypes.Length == 0)
			{
				xPcXISTlhxsDsMaSLXpJwnxLOayq = new JoystickType[1];
			}
			else
			{
				xPcXISTlhxsDsMaSLXpJwnxLOayq = P_9.joystickTypes;
			}
			EOvoJIiWohpdQthpmdZTeFttoAlTA = new ReadOnlyCollection<JoystickType>(xPcXISTlhxsDsMaSLXpJwnxLOayq);
			FVQafKJYWTPLttkpgxhUfJgzZmve = P_9.hatCount;
			VvbrMtXdRZHsnfmJqdEFbOCJgVil = new Hat[FVQafKJYWTPLttkpgxhUfJgzZmve];
			for (int i = 0; i < FVQafKJYWTPLttkpgxhUfJgzZmve; i++)
			{
				HardwareJoystickMap.CompoundElement hatData = P_9.GetHatData(i);
				try
				{
					if (hatData == null)
					{
						Logger.LogError("Error creating Hat from hardware map! CompoundElement is null!");
						VvbrMtXdRZHsnfmJqdEFbOCJgVil[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
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
						VvbrMtXdRZHsnfmJqdEFbOCJgVil[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, list.ToArray(), list2.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating Hat from hardware map! Exception thrown when creating Hat.");
						VvbrMtXdRZHsnfmJqdEFbOCJgVil[i] = new Hat(this, hatData.elementIdentifier, "Hat " + i, new Button[0], new int[0]);
					}
				}
				finally
				{
					YyaDpuFfMbbFmjWsPsiaQKFYXYeIA(VvbrMtXdRZHsnfmJqdEFbOCJgVil[i]);
				}
			}
			fckwwcxajtgQCDXwcVhCVbKJFYibb = new ReadOnlyCollection<Hat>(VvbrMtXdRZHsnfmJqdEFbOCJgVil);
			LoFmjIAShhtUkjfRApFcVaVcmXOl = P_9.dpadCount;
			PGdRThSxiZknfEMHzGmTQkzpAErk = new DirectionalPad[LoFmjIAShhtUkjfRApFcVaVcmXOl];
			for (int k = 0; k < LoFmjIAShhtUkjfRApFcVaVcmXOl; k++)
			{
				HardwareJoystickMap.CompoundElement dPadData = P_9.GetDPadData(k);
				try
				{
					if (dPadData == null)
					{
						Logger.LogError("Error creating D-Pad from hardware map! CompoundElement is null!");
						PGdRThSxiZknfEMHzGmTQkzpAErk[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
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
						PGdRThSxiZknfEMHzGmTQkzpAErk[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, list3.ToArray(), list4.ToArray());
					}
					catch
					{
						Logger.LogError("Error creating D-Pad from hardware map! Exception thrown when creating D-Pad.");
						PGdRThSxiZknfEMHzGmTQkzpAErk[k] = new DirectionalPad(this, dPadData.elementIdentifier, "D-Pad " + k, new Button[0], new int[0]);
					}
				}
				finally
				{
					YyaDpuFfMbbFmjWsPsiaQKFYXYeIA(PGdRThSxiZknfEMHzGmTQkzpAErk[k]);
				}
			}
			gzxCiRIjIKYlEXcYmKbkFEaZfxey = new ReadOnlyCollection<DirectionalPad>(PGdRThSxiZknfEMHzGmTQkzpAErk);
		}

		internal bool VEonhHORAluHldqnhduNdqlMcpCMA(JoystickType P_0)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int num = xPcXISTlhxsDsMaSLXpJwnxLOayq.Length;
			for (int i = 0; i < num; i++)
			{
				if (xPcXISTlhxsDsMaSLXpJwnxLOayq[i] == P_0)
				{
					return true;
				}
			}
			return false;
		}

		public JoystickCalibrationMapSaveData GetCalibrationMapSaveData()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return new JoystickCalibrationMapSaveData(base.calibrationMap, _type, _hardwareIdentifier, base.hardwareTypeGuid);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else
			{
				SetVibration(leftMotorLevel, rightMotorLevel, 0f, 0f);
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftMotorDuration, float rightMotorDuration)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else
			{
				if (!eOQMBxZDovuMPZyZcDkTHGyJSrJh)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					int num = controllerVibrator.vibrationMotorCount;
					if (num > 0)
					{
						controllerVibrator.SetVibration(0, leftMotorLevel, leftMotorDuration);
					}
					if (num > 1)
					{
						controllerVibrator.SetVibration(1, rightMotorLevel, rightMotorDuration);
					}
				}
				if (EnVnfcvQhSgfIeBiodnktGRTTcWwA)
				{
					if (tvLmdwjBQRIzuxGiJKLklibxFRtQ > 0)
					{
						JSujtuTpayGuilHcgZKbphdSUXgF(0, leftMotorLevel, leftMotorDuration, false, false);
					}
					if (tvLmdwjBQRIzuxGiJKLklibxFRtQ > 1)
					{
						JSujtuTpayGuilHcgZKbphdSUXgF(1, rightMotorLevel, rightMotorDuration, false, false);
					}
					dWGRtJBbesyTMweMBrPICzkqnFmn();
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else if (eOQMBxZDovuMPZyZcDkTHGyJSrJh && motorIndex >= 0)
			{
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
				}
				if (EnVnfcvQhSgfIeBiodnktGRTTcWwA && motorIndex < tvLmdwjBQRIzuxGiJKLklibxFRtQ)
				{
					JSujtuTpayGuilHcgZKbphdSUXgF(motorIndex, motorLevel, duration, stopOtherMotors, true);
				}
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0f;
			}
			if (!eOQMBxZDovuMPZyZcDkTHGyJSrJh || motorIndex < 0)
			{
				return 0f;
			}
			if (base.extension is IControllerVibrator controllerVibrator && motorIndex < controllerVibrator.vibrationMotorCount)
			{
				return controllerVibrator.GetVibration(motorIndex);
			}
			if (!EnVnfcvQhSgfIeBiodnktGRTTcWwA)
			{
				return 0f;
			}
			if (motorIndex >= tvLmdwjBQRIzuxGiJKLklibxFRtQ)
			{
				return 0f;
			}
			return SEfOkNGFxAoEhrhEfYpwOoinBtWx[motorIndex];
		}

		public void StopVibration()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
			}
			else
			{
				if (!eOQMBxZDovuMPZyZcDkTHGyJSrJh)
				{
					return;
				}
				if (base.extension is IControllerVibrator controllerVibrator)
				{
					controllerVibrator.StopVibration();
				}
				if (EnVnfcvQhSgfIeBiodnktGRTTcWwA)
				{
					Array.Clear(SEfOkNGFxAoEhrhEfYpwOoinBtWx, 0, SEfOkNGFxAoEhrhEfYpwOoinBtWx.Length);
					for (int i = 0; i < tvLmdwjBQRIzuxGiJKLklibxFRtQ; i++)
					{
						MkjighmVJSIGRMmHAjXytYPDBfgA[i].Clear();
					}
				}
				if (sJYuLwOzGzQTUeJrpPcpOnCeVEnI != null)
				{
					sJYuLwOzGzQTUeJrpPcpOnCeVEnI.StopVibration();
				}
			}
		}

		internal override void tglbagDKhFNyJrooYNWfohsJFQmi(UpdateLoopType P_0)
		{
			base.tglbagDKhFNyJrooYNWfohsJFQmi(P_0);
			for (int i = 0; i < FVQafKJYWTPLttkpgxhUfJgzZmve; i++)
			{
				if (VvbrMtXdRZHsnfmJqdEFbOCJgVil[i] != null)
				{
					VvbrMtXdRZHsnfmJqdEFbOCJgVil[i].sboEOQazNCgVCSWpNHHosMaWIvev(P_0, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
				}
			}
			for (int j = 0; j < LoFmjIAShhtUkjfRApFcVaVcmXOl; j++)
			{
				if (PGdRThSxiZknfEMHzGmTQkzpAErk[j] != null)
				{
					PGdRThSxiZknfEMHzGmTQkzpAErk[j].sboEOQazNCgVCSWpNHHosMaWIvev(P_0, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
				}
			}
			pPYHierAOCbwuFIlzImlapEvgaTbA();
		}

		internal void oyDZOcYKDiGWhgaXqxIvhjzjLvaDb(UpdateControllerInfoEventArgs P_0)
		{
			if (P_0 != null)
			{
				oyDZOcYKDiGWhgaXqxIvhjzjLvaDb(P_0.sourceJoystick);
			}
		}

		internal void oyDZOcYKDiGWhgaXqxIvhjzjLvaDb(BridgedController P_0)
		{
			if (P_0 != null)
			{
				oyDZOcYKDiGWhgaXqxIvhjzjLvaDb(P_0.sourceJoystick);
			}
		}

		private void oyDZOcYKDiGWhgaXqxIvhjzjLvaDb(IInputManagerJoystickPublic P_0)
		{
			sJYuLwOzGzQTUeJrpPcpOnCeVEnI = P_0;
			base.sVSDTFomzlOsrCOaJQrEEeONMSjt = P_0 as ITryGetLocalizedName;
			if (P_0 != null)
			{
				if (base.extension != null)
				{
					bnAGYzRVKdkQjrhYaXRbXTEfQVEh(P_0.extension);
				}
				else
				{
					nWDsfQvWLSZHvoAkYNmOnDtxCKYR(P_0.extension);
				}
				if (P_0.name != string.Empty)
				{
					_name = P_0.name;
				}
			}
		}

		internal override void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			base.wJjPIIRJfHhEbGedUconecGfiwzgB();
			StopVibration();
		}

		internal override void LkQTpFBeyUXMAddalyNJQqSBAfDB(bool P_0)
		{
			base.LkQTpFBeyUXMAddalyNJQqSBAfDB(P_0);
			if (!P_0 && !ReInput.applicationRunInBackground)
			{
				StopVibration();
			}
		}

		protected override void Disconnected()
		{
			base.Disconnected();
			if (EnVnfcvQhSgfIeBiodnktGRTTcWwA)
			{
				Array.Clear(SEfOkNGFxAoEhrhEfYpwOoinBtWx, 0, SEfOkNGFxAoEhrhEfYpwOoinBtWx.Length);
				for (int i = 0; i < tvLmdwjBQRIzuxGiJKLklibxFRtQ; i++)
				{
					MkjighmVJSIGRMmHAjXytYPDBfgA[i].Clear();
				}
			}
			if (base.extension is IControllerVibrator controllerVibrator)
			{
				controllerVibrator.StopVibration();
			}
		}

		private void pPYHierAOCbwuFIlzImlapEvgaTbA()
		{
			if (!eOQMBxZDovuMPZyZcDkTHGyJSrJh || !EnVnfcvQhSgfIeBiodnktGRTTcWwA)
			{
				return;
			}
			for (int i = 0; i < tvLmdwjBQRIzuxGiJKLklibxFRtQ; i++)
			{
				if (MkjighmVJSIGRMmHAjXytYPDBfgA[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void JSujtuTpayGuilHcgZKbphdSUXgF(int P_0, float P_1, float P_2, bool P_3, bool P_4)
		{
			if (!EnVnfcvQhSgfIeBiodnktGRTTcWwA || P_0 < 0 || P_0 >= tvLmdwjBQRIzuxGiJKLklibxFRtQ)
			{
				return;
			}
			if (P_3)
			{
				Array.Clear(SEfOkNGFxAoEhrhEfYpwOoinBtWx, 0, SEfOkNGFxAoEhrhEfYpwOoinBtWx.Length);
				for (int i = 0; i < tvLmdwjBQRIzuxGiJKLklibxFRtQ; i++)
				{
					MkjighmVJSIGRMmHAjXytYPDBfgA[i].Clear();
				}
			}
			SEfOkNGFxAoEhrhEfYpwOoinBtWx[P_0] = MathTools.Clamp01(P_1);
			if (P_1 <= 0f || P_2 <= 0f)
			{
				MkjighmVJSIGRMmHAjXytYPDBfgA[P_0].Clear();
			}
			else
			{
				MkjighmVJSIGRMmHAjXytYPDBfgA[P_0].Start(P_2);
			}
			if (P_4)
			{
				dWGRtJBbesyTMweMBrPICzkqnFmn();
			}
		}

		private void dWGRtJBbesyTMweMBrPICzkqnFmn()
		{
			if (eOQMBxZDovuMPZyZcDkTHGyJSrJh && EnVnfcvQhSgfIeBiodnktGRTTcWwA && sJYuLwOzGzQTUeJrpPcpOnCeVEnI != null)
			{
				for (int i = 0; i < SEfOkNGFxAoEhrhEfYpwOoinBtWx.Length; i++)
				{
					sJYuLwOzGzQTUeJrpPcpOnCeVEnI.SetVibration(SEfOkNGFxAoEhrhEfYpwOoinBtWx[i], i);
				}
			}
		}

		private void VFbkSiakwCTVyIsjeqLMFvCvAsZn()
		{
		}

		internal static int tokKHgLQblWASmEMXrniBxPYzYjd(Joystick P_0, Joystick P_1)
		{
			if (P_0.LxOFdbFfzMSZsGHKiEkdFHVjeyWVB < P_1.LxOFdbFfzMSZsGHKiEkdFHVjeyWVB)
			{
				return -1;
			}
			if (P_0.LxOFdbFfzMSZsGHKiEkdFHVjeyWVB > P_1.LxOFdbFfzMSZsGHKiEkdFHVjeyWVB)
			{
				return 1;
			}
			return 0;
		}
	}
}
