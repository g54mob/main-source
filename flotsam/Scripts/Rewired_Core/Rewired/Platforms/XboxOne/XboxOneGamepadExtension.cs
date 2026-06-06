using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class YJNbFvDEwoMjPUVhEFonHijaYLMyA : IControllerExtensionSource
		{
			public const int gPjdJsCoQUwudNEdhZrskuYLDXOnA = 4;

			public nqksfUukzDEiLaSMNzYesOWcFujw AGjRwxRZCZHmuxgHKLCqIadBJcsJA;

			public readonly IXboxOneInputSource mzJbOisqRevLkVIEMZehprhOPCsc;

			public readonly bool dOSyCLcKCiVTaMBUxtxaKknJjsoK;

			public YJNbFvDEwoMjPUVhEFonHijaYLMyA(bool P_0, IXboxOneInputSource P_1, nqksfUukzDEiLaSMNzYesOWcFujw P_2)
			{
				AGjRwxRZCZHmuxgHKLCqIadBJcsJA = P_2;
				mzJbOisqRevLkVIEMZehprhOPCsc = P_1;
				dOSyCLcKCiVTaMBUxtxaKknJjsoK = P_0;
			}
		}

		private YJNbFvDEwoMjPUVhEFonHijaYLMyA teILFkdByIkNhhsqbBACosIGKspV;

		private TimerAbs[] OmvStyMhNsEerSkiEAbsKpPhnJDWA;

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
				if (teILFkdByIkNhhsqbBACosIGKspV.mzJbOisqRevLkVIEMZehprhOPCsc == null || joystick == null)
				{
					return -1;
				}
				return teILFkdByIkNhhsqbBACosIGKspV.mzJbOisqRevLkVIEMZehprhOPCsc.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
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
			: base(new YJNbFvDEwoMjPUVhEFonHijaYLMyA(P_0, P_1, default(nqksfUukzDEiLaSMNzYesOWcFujw)))
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			OmvStyMhNsEerSkiEAbsKpPhnJDWA = new TimerAbs[4];
			ArrayTools.Populate(OmvStyMhNsEerSkiEAbsKpPhnJDWA, 0, OmvStyMhNsEerSkiEAbsKpPhnJDWA.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
			: base(P_0)
		{
			OmvStyMhNsEerSkiEAbsKpPhnJDWA = new TimerAbs[4];
			ArrayTools.Populate(OmvStyMhNsEerSkiEAbsKpPhnJDWA, 0, OmvStyMhNsEerSkiEAbsKpPhnJDWA.Length);
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
			if (!teILFkdByIkNhhsqbBACosIGKspV.dOSyCLcKCiVTaMBUxtxaKknJjsoK)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.jeShRHvcUevipPLBBhMsISnyTRTRA, 
				1 => teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.kwYGRnFHWuvFyeFtyRydpubGPMRLA, 
				2 => teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.eQgRXqzfrjqGsBKYDIMdLCjlIuAx, 
				3 => teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.CRlQHOKRLHxOSIkFANHLFGKjTKAM, 
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
			if (!teILFkdByIkNhhsqbBACosIGKspV.dOSyCLcKCiVTaMBUxtxaKknJjsoK)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.jeShRHvcUevipPLBBhMsISnyTRTRA, 
				XboxOneGamepadMotorType.RightMotor => teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.kwYGRnFHWuvFyeFtyRydpubGPMRLA, 
				XboxOneGamepadMotorType.LeftTriggerMotor => teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.eQgRXqzfrjqGsBKYDIMdLCjlIuAx, 
				XboxOneGamepadMotorType.RightTriggerMotor => teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.CRlQHOKRLHxOSIkFANHLFGKjTKAM, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (teILFkdByIkNhhsqbBACosIGKspV.dOSyCLcKCiVTaMBUxtxaKknJjsoK)
			{
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.SETsnxBxLMonjTEZclepqkLIMiMk();
				for (int i = 0; i < 4; i++)
				{
					OmvStyMhNsEerSkiEAbsKpPhnJDWA[i].Clear();
				}
				RgLPhoydiRtaMJzLuhqUnvXxdaVR();
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
				if (!teILFkdByIkNhhsqbBACosIGKspV.dOSyCLcKCiVTaMBUxtxaKknJjsoK)
				{
					return;
				}
				if (stopOtherMotors)
				{
					teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.SETsnxBxLMonjTEZclepqkLIMiMk();
					for (int i = 0; i < 4; i++)
					{
						OmvStyMhNsEerSkiEAbsKpPhnJDWA[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.jeShRHvcUevipPLBBhMsISnyTRTRA = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.kwYGRnFHWuvFyeFtyRydpubGPMRLA = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.eQgRXqzfrjqGsBKYDIMdLCjlIuAx = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.CRlQHOKRLHxOSIkFANHLFGKjTKAM = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				ouElOxPvNgfwlWnMVPtzNZpEsaOj(motor, motorLevel, duration);
				RgLPhoydiRtaMJzLuhqUnvXxdaVR();
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
				if (!teILFkdByIkNhhsqbBACosIGKspV.dOSyCLcKCiVTaMBUxtxaKknJjsoK)
				{
					return;
				}
				if (stopOtherMotors)
				{
					teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.SETsnxBxLMonjTEZclepqkLIMiMk();
					for (int i = 0; i < 4; i++)
					{
						OmvStyMhNsEerSkiEAbsKpPhnJDWA[i].Clear();
					}
				}
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.QEhANnvMVuiBZMMdwzooLceDqEBH = xboxOneJoystickId;
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.jeShRHvcUevipPLBBhMsISnyTRTRA = MathTools.Clamp01(leftMotorLevel);
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.kwYGRnFHWuvFyeFtyRydpubGPMRLA = MathTools.Clamp01(rightMotorLevel);
				OmvStyMhNsEerSkiEAbsKpPhnJDWA[0].Clear();
				OmvStyMhNsEerSkiEAbsKpPhnJDWA[1].Clear();
				RgLPhoydiRtaMJzLuhqUnvXxdaVR();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (teILFkdByIkNhhsqbBACosIGKspV.dOSyCLcKCiVTaMBUxtxaKknJjsoK)
			{
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.QEhANnvMVuiBZMMdwzooLceDqEBH = xboxOneJoystickId;
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.jeShRHvcUevipPLBBhMsISnyTRTRA = MathTools.Clamp01(leftMotorLevel);
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.kwYGRnFHWuvFyeFtyRydpubGPMRLA = MathTools.Clamp01(rightMotorLevel);
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.eQgRXqzfrjqGsBKYDIMdLCjlIuAx = MathTools.Clamp01(leftTriggerLevel);
				teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA.CRlQHOKRLHxOSIkFANHLFGKjTKAM = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					OmvStyMhNsEerSkiEAbsKpPhnJDWA[i].Clear();
				}
				RgLPhoydiRtaMJzLuhqUnvXxdaVR();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && teILFkdByIkNhhsqbBACosIGKspV.dOSyCLcKCiVTaMBUxtxaKknJjsoK)
			{
				ouElOxPvNgfwlWnMVPtzNZpEsaOj(motor, 0f, 0f);
				teILFkdByIkNhhsqbBACosIGKspV.mzJbOisqRevLkVIEMZehprhOPCsc.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			XykWfobGjYQMsoZRIVKWZQtCAVzh();
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			teILFkdByIkNhhsqbBACosIGKspV = source as YJNbFvDEwoMjPUVhEFonHijaYLMyA;
		}

		internal override Controller.Extension Clone()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void XykWfobGjYQMsoZRIVKWZQtCAVzh()
		{
			if (!teILFkdByIkNhhsqbBACosIGKspV.dOSyCLcKCiVTaMBUxtxaKknJjsoK)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (OmvStyMhNsEerSkiEAbsKpPhnJDWA[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void ouElOxPvNgfwlWnMVPtzNZpEsaOj(XboxOneGamepadMotorType P_0, float P_1, float P_2)
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
				OmvStyMhNsEerSkiEAbsKpPhnJDWA[num].Clear();
			}
			else
			{
				OmvStyMhNsEerSkiEAbsKpPhnJDWA[num].Start(P_2);
			}
		}

		private void RgLPhoydiRtaMJzLuhqUnvXxdaVR()
		{
			if (base.isJoystickConnected)
			{
				teILFkdByIkNhhsqbBACosIGKspV.mzJbOisqRevLkVIEMZehprhOPCsc.SetXboxOneVibration(xboxOneJoystickId, teILFkdByIkNhhsqbBACosIGKspV.AGjRwxRZCZHmuxgHKLCqIadBJcsJA);
			}
		}
	}
}
