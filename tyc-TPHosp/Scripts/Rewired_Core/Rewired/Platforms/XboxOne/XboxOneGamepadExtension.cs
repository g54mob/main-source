using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class KstFUXfEPhNFgNBspdhTJCbZqUlm : IControllerExtensionSource
		{
			public const int hFnuhMXoYvgyCariIlYOShuWnqMq = 4;

			public baObqiGLCEnOuOsTehPAyECzcjCx TQAyhasxYSEqNOhYUcJhDqThtQM;

			public readonly IXboxOneInputSource vAVhDYFvBNuhmsbAOtkNPykcPBVB;

			public readonly bool swbwxminWkIfPLDNkfAOLJChHuv;

			public KstFUXfEPhNFgNBspdhTJCbZqUlm(bool supportsVibration, IXboxOneInputSource xboxOneInputSource, baObqiGLCEnOuOsTehPAyECzcjCx vibrationData)
			{
				TQAyhasxYSEqNOhYUcJhDqThtQM = vibrationData;
				vAVhDYFvBNuhmsbAOtkNPykcPBVB = xboxOneInputSource;
				swbwxminWkIfPLDNkfAOLJChHuv = supportsVibration;
			}
		}

		private KstFUXfEPhNFgNBspdhTJCbZqUlm UdjCSEOPIRsTIjnUgCiPBbbzKWS;

		private TimerAbs[] xZuKFmRpvbeqPEKkNilOfJfximjg;

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
				if (UdjCSEOPIRsTIjnUgCiPBbbzKWS.vAVhDYFvBNuhmsbAOtkNPykcPBVB == null || joystick == null)
				{
					return -1;
				}
				return UdjCSEOPIRsTIjnUgCiPBbbzKWS.vAVhDYFvBNuhmsbAOtkNPykcPBVB.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
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

		public int vibrationMotorCount
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

		internal XboxOneGamepadExtension(bool supportsVibration, IXboxOneInputSource xboxOneInputSource)
			: base(new KstFUXfEPhNFgNBspdhTJCbZqUlm(supportsVibration, xboxOneInputSource, default(baObqiGLCEnOuOsTehPAyECzcjCx)))
		{
			if (xboxOneInputSource == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			xZuKFmRpvbeqPEKkNilOfJfximjg = new TimerAbs[4];
			ArrayTools.Populate(xZuKFmRpvbeqPEKkNilOfJfximjg, 0, xZuKFmRpvbeqPEKkNilOfJfximjg.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension source)
			: base(source)
		{
			xZuKFmRpvbeqPEKkNilOfJfximjg = new TimerAbs[4];
			ArrayTools.Populate(xZuKFmRpvbeqPEKkNilOfJfximjg, 0, xZuKFmRpvbeqPEKkNilOfJfximjg.Length);
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

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!UdjCSEOPIRsTIjnUgCiPBbbzKWS.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.FHARfJwFjGtAuCfaZbvefjItCedM, 
				1 => UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.VeKfSmItNnzdreClITSFcjrOIjxR, 
				2 => UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.DMzcBQLYYkiJcgrOwMazRMaZAhZ, 
				3 => UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.UmoUBOZzTtSynwTGPqDEjhbOphz, 
				_ => 0f, 
			};
		}

		public float GetVibration(XboxOneGamepadMotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!UdjCSEOPIRsTIjnUgCiPBbbzKWS.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.FHARfJwFjGtAuCfaZbvefjItCedM, 
				XboxOneGamepadMotorType.RightMotor => UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.VeKfSmItNnzdreClITSFcjrOIjxR, 
				XboxOneGamepadMotorType.LeftTriggerMotor => UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.DMzcBQLYYkiJcgrOwMazRMaZAhZ, 
				XboxOneGamepadMotorType.RightTriggerMotor => UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.UmoUBOZzTtSynwTGPqDEjhbOphz, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (UdjCSEOPIRsTIjnUgCiPBbbzKWS.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.ngEKoYyxUGodAKfoPQHHZqbMHif();
				for (int i = 0; i < 4; i++)
				{
					xZuKFmRpvbeqPEKkNilOfJfximjg[i].Clear();
				}
				FTTJqtAeIYMhathjVZJTuwkkzMp();
			}
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
				if (!UdjCSEOPIRsTIjnUgCiPBbbzKWS.swbwxminWkIfPLDNkfAOLJChHuv)
				{
					return;
				}
				if (stopOtherMotors)
				{
					UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.ngEKoYyxUGodAKfoPQHHZqbMHif();
					for (int i = 0; i < 4; i++)
					{
						xZuKFmRpvbeqPEKkNilOfJfximjg[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.FHARfJwFjGtAuCfaZbvefjItCedM = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.VeKfSmItNnzdreClITSFcjrOIjxR = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.DMzcBQLYYkiJcgrOwMazRMaZAhZ = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.UmoUBOZzTtSynwTGPqDEjhbOphz = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				PrmctIckVmyxTVxTdzKFusfbJqiG(motor, motorLevel, duration);
				FTTJqtAeIYMhathjVZJTuwkkzMp();
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
				if (!UdjCSEOPIRsTIjnUgCiPBbbzKWS.swbwxminWkIfPLDNkfAOLJChHuv)
				{
					return;
				}
				if (stopOtherMotors)
				{
					UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.ngEKoYyxUGodAKfoPQHHZqbMHif();
					for (int i = 0; i < 4; i++)
					{
						xZuKFmRpvbeqPEKkNilOfJfximjg[i].Clear();
					}
				}
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.nkMCePccQAPzIEBezpVgpCnQDhf = xboxOneJoystickId;
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.FHARfJwFjGtAuCfaZbvefjItCedM = MathTools.Clamp01(leftMotorLevel);
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.VeKfSmItNnzdreClITSFcjrOIjxR = MathTools.Clamp01(rightMotorLevel);
				xZuKFmRpvbeqPEKkNilOfJfximjg[0].Clear();
				xZuKFmRpvbeqPEKkNilOfJfximjg[1].Clear();
				FTTJqtAeIYMhathjVZJTuwkkzMp();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (UdjCSEOPIRsTIjnUgCiPBbbzKWS.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.nkMCePccQAPzIEBezpVgpCnQDhf = xboxOneJoystickId;
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.FHARfJwFjGtAuCfaZbvefjItCedM = MathTools.Clamp01(leftMotorLevel);
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.VeKfSmItNnzdreClITSFcjrOIjxR = MathTools.Clamp01(rightMotorLevel);
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.DMzcBQLYYkiJcgrOwMazRMaZAhZ = MathTools.Clamp01(leftTriggerLevel);
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM.UmoUBOZzTtSynwTGPqDEjhbOphz = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					xZuKFmRpvbeqPEKkNilOfJfximjg[i].Clear();
				}
				FTTJqtAeIYMhathjVZJTuwkkzMp();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && UdjCSEOPIRsTIjnUgCiPBbbzKWS.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				PrmctIckVmyxTVxTdzKFusfbJqiG(motor, 0f, 0f);
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.vAVhDYFvBNuhmsbAOtkNPykcPBVB.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
			iqIALhjYezdflYrpgSZUFTUYBiz();
		}

		internal void tmEnLTdHsRVxaDmExqmMETendBa(IControllerExtensionSource P_0)
		{
			UdjCSEOPIRsTIjnUgCiPBbbzKWS = P_0 as KstFUXfEPhNFgNBspdhTJCbZqUlm;
		}

		internal Controller.Extension AqgeNRkgwzpPIRfsEjgMCeSKqLh()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void iqIALhjYezdflYrpgSZUFTUYBiz()
		{
			if (!UdjCSEOPIRsTIjnUgCiPBbbzKWS.swbwxminWkIfPLDNkfAOLJChHuv)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (xZuKFmRpvbeqPEKkNilOfJfximjg[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void PrmctIckVmyxTVxTdzKFusfbJqiG(XboxOneGamepadMotorType P_0, float P_1, float P_2)
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
				xZuKFmRpvbeqPEKkNilOfJfximjg[num].Clear();
			}
			else
			{
				xZuKFmRpvbeqPEKkNilOfJfximjg[num].Start(P_2);
			}
		}

		private void FTTJqtAeIYMhathjVZJTuwkkzMp()
		{
			if (base.isJoystickConnected)
			{
				UdjCSEOPIRsTIjnUgCiPBbbzKWS.vAVhDYFvBNuhmsbAOtkNPykcPBVB.SetXboxOneVibration(xboxOneJoystickId, UdjCSEOPIRsTIjnUgCiPBbbzKWS.TQAyhasxYSEqNOhYUcJhDqThtQM);
			}
		}
	}
}
