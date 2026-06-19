using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class EeBjZomyKmhEjuvTDjsOpCttDOOo : IControllerExtensionSource
		{
			public const int srpKZbYsaMFiNrvNwdcVdSUysCCP = 4;

			public poqVdBSaRLeupdLkAXXVBdSVpptwA YkjSmunnuLFsEAShJXTRRjtmGbyIA;

			public readonly IXboxOneInputSource eDThpVCwUyxEzqcaXECHyUtjQQQk;

			public readonly bool dlIPCSMLwehPSpoyegaHRPfolceV;

			public EeBjZomyKmhEjuvTDjsOpCttDOOo(bool P_0, IXboxOneInputSource P_1, poqVdBSaRLeupdLkAXXVBdSVpptwA P_2)
			{
				YkjSmunnuLFsEAShJXTRRjtmGbyIA = P_2;
				eDThpVCwUyxEzqcaXECHyUtjQQQk = P_1;
				dlIPCSMLwehPSpoyegaHRPfolceV = P_0;
			}
		}

		private EeBjZomyKmhEjuvTDjsOpCttDOOo pCOzBpBBWWmVDIAMioRntaAhWrvU;

		private TimerAbs[] IjxrnbyVleHaHrBGBakXDyHMZGDvA;

		private Joystick joystick => GetController<Joystick>();

		public int xboxOneUserId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (pCOzBpBBWWmVDIAMioRntaAhWrvU.eDThpVCwUyxEzqcaXECHyUtjQQQk == null || joystick == null)
				{
					return -1;
				}
				return pCOzBpBBWWmVDIAMioRntaAhWrvU.eDThpVCwUyxEzqcaXECHyUtjQQQk.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
			}
		}

		public ulong xboxOneJoystickId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0uL;
				}
				if (joystick == null)
				{
					return 0uL;
				}
				long? systemId = joystick.systemId;
				if (!systemId.HasValue)
				{
					return 0uL;
				}
				return (ulong)systemId.Value;
			}
		}

		int IControllerVibrator.vibrationMotorCount
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return 0;
				}
				return 4;
			}
		}

		internal XboxOneGamepadExtension(bool P_0, IXboxOneInputSource P_1)
			: base(new EeBjZomyKmhEjuvTDjsOpCttDOOo(P_0, P_1, default(poqVdBSaRLeupdLkAXXVBdSVpptwA)))
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			IjxrnbyVleHaHrBGBakXDyHMZGDvA = new TimerAbs[4];
			ArrayTools.Populate(IjxrnbyVleHaHrBGBakXDyHMZGDvA, 0, IjxrnbyVleHaHrBGBakXDyHMZGDvA.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
			: base(P_0)
		{
			IjxrnbyVleHaHrBGBakXDyHMZGDvA = new TimerAbs[4];
			ArrayTools.Populate(IjxrnbyVleHaHrBGBakXDyHMZGDvA, 0, IjxrnbyVleHaHrBGBakXDyHMZGDvA.Length);
		}

		public void SetVibration(int motorIndex, float motorLevel)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors: false);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration)
		{
			SetVibration(motorIndex, motorLevel, duration, stopOtherMotors: false);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, duration);
		}

		public void SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motorIndex, motorLevel, 0f, stopOtherMotors);
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, stopOtherMotors);
		}

		public void SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (motorIndex >= 0 && motorIndex < 4)
			{
				SetVibration(motorIndex switch
				{
					0 => XboxOneGamepadMotorType.LeftMotor, 
					1 => XboxOneGamepadMotorType.RightMotor, 
					2 => XboxOneGamepadMotorType.LeftTriggerMotor, 
					3 => XboxOneGamepadMotorType.RightTriggerMotor, 
					_ => throw new NotImplementedException(), 
				}, motorLevel, duration, stopOtherMotors);
			}
		}

		void IControllerVibrator.SetVibration(int motorIndex, float motorLevel, float duration, bool stopOtherMotors)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetVibration
			this.SetVibration(motorIndex, motorLevel, duration, stopOtherMotors);
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!pCOzBpBBWWmVDIAMioRntaAhWrvU.dlIPCSMLwehPSpoyegaHRPfolceV)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.bEOhLSHRqiJuLektSoDLUZlXkOZQA, 
				1 => pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.cPChLwbpiiZBIuQBlJvAxqpxDPLO, 
				2 => pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.qnevNxPtBhgAOqRuMKBWKBbQvtEY, 
				3 => pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.OphWZZchpFiQqdMfPAIcGtIQDLQaA, 
				_ => 0f, 
			};
		}

		float IControllerVibrator.GetVibration(int motorIndex)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetVibration
			return this.GetVibration(motorIndex);
		}

		public float GetVibration(XboxOneGamepadMotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!pCOzBpBBWWmVDIAMioRntaAhWrvU.dlIPCSMLwehPSpoyegaHRPfolceV)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.bEOhLSHRqiJuLektSoDLUZlXkOZQA, 
				XboxOneGamepadMotorType.RightMotor => pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.cPChLwbpiiZBIuQBlJvAxqpxDPLO, 
				XboxOneGamepadMotorType.LeftTriggerMotor => pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.qnevNxPtBhgAOqRuMKBWKBbQvtEY, 
				XboxOneGamepadMotorType.RightTriggerMotor => pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.OphWZZchpFiQqdMfPAIcGtIQDLQaA, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (pCOzBpBBWWmVDIAMioRntaAhWrvU.dlIPCSMLwehPSpoyegaHRPfolceV)
			{
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.EARiAylzhIydBmnFvoJQpFQhHaQD();
				for (int i = 0; i < 4; i++)
				{
					IjxrnbyVleHaHrBGBakXDyHMZGDvA[i].Clear();
				}
				RELAbjdAGHpeucybhevvWwHIMvDPA();
			}
		}

		void IControllerVibrator.StopVibration()
		{
			//ILSpy generated this explicit interface implementation from .override directive in StopVibration
			this.StopVibration();
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors: false);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration)
		{
			SetVibration(motor, motorLevel, duration, stopOtherMotors: false);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, bool stopOtherMotors)
		{
			SetVibration(motor, motorLevel, 0f, stopOtherMotors);
		}

		public void SetVibration(XboxOneGamepadMotorType motor, float motorLevel, float duration, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				if (!pCOzBpBBWWmVDIAMioRntaAhWrvU.dlIPCSMLwehPSpoyegaHRPfolceV)
				{
					return;
				}
				if (stopOtherMotors)
				{
					pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.EARiAylzhIydBmnFvoJQpFQhHaQD();
					for (int i = 0; i < 4; i++)
					{
						IjxrnbyVleHaHrBGBakXDyHMZGDvA[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.bEOhLSHRqiJuLektSoDLUZlXkOZQA = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.cPChLwbpiiZBIuQBlJvAxqpxDPLO = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.qnevNxPtBhgAOqRuMKBWKBbQvtEY = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.OphWZZchpFiQqdMfPAIcGtIQDLQaA = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				qzEwUchLlqhkZdbmSlISIBrbOzGU(motor, motorLevel, duration);
				RELAbjdAGHpeucybhevvWwHIMvDPA();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel)
		{
			SetVibration(leftMotorLevel, rightMotorLevel, stopOtherMotors: false);
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, bool stopOtherMotors)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else
			{
				if (!pCOzBpBBWWmVDIAMioRntaAhWrvU.dlIPCSMLwehPSpoyegaHRPfolceV)
				{
					return;
				}
				if (stopOtherMotors)
				{
					pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.EARiAylzhIydBmnFvoJQpFQhHaQD();
					for (int i = 0; i < 4; i++)
					{
						IjxrnbyVleHaHrBGBakXDyHMZGDvA[i].Clear();
					}
				}
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.OAtKusHAncebvrSFtqRNYDekhOBj = xboxOneJoystickId;
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.bEOhLSHRqiJuLektSoDLUZlXkOZQA = MathTools.Clamp01(leftMotorLevel);
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.cPChLwbpiiZBIuQBlJvAxqpxDPLO = MathTools.Clamp01(rightMotorLevel);
				IjxrnbyVleHaHrBGBakXDyHMZGDvA[0].Clear();
				IjxrnbyVleHaHrBGBakXDyHMZGDvA[1].Clear();
				RELAbjdAGHpeucybhevvWwHIMvDPA();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (pCOzBpBBWWmVDIAMioRntaAhWrvU.dlIPCSMLwehPSpoyegaHRPfolceV)
			{
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.OAtKusHAncebvrSFtqRNYDekhOBj = xboxOneJoystickId;
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.bEOhLSHRqiJuLektSoDLUZlXkOZQA = MathTools.Clamp01(leftMotorLevel);
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.cPChLwbpiiZBIuQBlJvAxqpxDPLO = MathTools.Clamp01(rightMotorLevel);
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.qnevNxPtBhgAOqRuMKBWKBbQvtEY = MathTools.Clamp01(leftTriggerLevel);
				pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA.OphWZZchpFiQqdMfPAIcGtIQDLQaA = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					IjxrnbyVleHaHrBGBakXDyHMZGDvA[i].Clear();
				}
				RELAbjdAGHpeucybhevvWwHIMvDPA();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && pCOzBpBBWWmVDIAMioRntaAhWrvU.dlIPCSMLwehPSpoyegaHRPfolceV)
			{
				qzEwUchLlqhkZdbmSlISIBrbOzGU(motor, 0f, 0f);
				pCOzBpBBWWmVDIAMioRntaAhWrvU.eDThpVCwUyxEzqcaXECHyUtjQQQk.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			LCgMYtVgBCOLGVdnRDEtMYnbIZxq();
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			pCOzBpBBWWmVDIAMioRntaAhWrvU = source as EeBjZomyKmhEjuvTDjsOpCttDOOo;
		}

		internal override Controller.Extension Clone()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void LCgMYtVgBCOLGVdnRDEtMYnbIZxq()
		{
			if (!pCOzBpBBWWmVDIAMioRntaAhWrvU.dlIPCSMLwehPSpoyegaHRPfolceV)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (IjxrnbyVleHaHrBGBakXDyHMZGDvA[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void qzEwUchLlqhkZdbmSlISIBrbOzGU(XboxOneGamepadMotorType P_0, float P_1, float P_2)
		{
			int num = P_0 switch
			{
				XboxOneGamepadMotorType.LeftMotor => 0, 
				XboxOneGamepadMotorType.RightMotor => 1, 
				XboxOneGamepadMotorType.LeftTriggerMotor => 2, 
				XboxOneGamepadMotorType.RightTriggerMotor => 3, 
				_ => throw new NotImplementedException(), 
			};
			if (P_1 <= 0f || P_2 <= 0f)
			{
				IjxrnbyVleHaHrBGBakXDyHMZGDvA[num].Clear();
			}
			else
			{
				IjxrnbyVleHaHrBGBakXDyHMZGDvA[num].Start(P_2);
			}
		}

		private void RELAbjdAGHpeucybhevvWwHIMvDPA()
		{
			if (base.isJoystickConnected)
			{
				pCOzBpBBWWmVDIAMioRntaAhWrvU.eDThpVCwUyxEzqcaXECHyUtjQQQk.SetXboxOneVibration(xboxOneJoystickId, pCOzBpBBWWmVDIAMioRntaAhWrvU.YkjSmunnuLFsEAShJXTRRjtmGbyIA);
			}
		}
	}
}
