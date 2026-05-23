using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class tTrGcLgKrymoOBoiCaYQNkQlmDVOB : IControllerExtensionSource
		{
			public const int FDDfwSEoLGPhukzoXSFPuqrdaRJqA = 4;

			public KgGMEagteNevMTqZxNiFmnfMLmqQ hJPPLVZuDDrdnCtCsCmLKMUtAaleA;

			public readonly IXboxOneInputSource FIbMqDwnIouUAwLvafXJrUhaBZcc;

			public readonly bool SooSblySTknYdpzLTrHBSjAdTfdo;

			public tTrGcLgKrymoOBoiCaYQNkQlmDVOB(bool P_0, IXboxOneInputSource P_1, KgGMEagteNevMTqZxNiFmnfMLmqQ P_2)
			{
				hJPPLVZuDDrdnCtCsCmLKMUtAaleA = P_2;
				FIbMqDwnIouUAwLvafXJrUhaBZcc = P_1;
				SooSblySTknYdpzLTrHBSjAdTfdo = P_0;
			}
		}

		private tTrGcLgKrymoOBoiCaYQNkQlmDVOB EswPsQdpzQsSkUMxTkkfyErsoyuO;

		private TimerAbs[] bqVySYIFKmalgCjpcgNZehugLTKjB;

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
				if (EswPsQdpzQsSkUMxTkkfyErsoyuO.FIbMqDwnIouUAwLvafXJrUhaBZcc == null || joystick == null)
				{
					return -1;
				}
				return EswPsQdpzQsSkUMxTkkfyErsoyuO.FIbMqDwnIouUAwLvafXJrUhaBZcc.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
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
			: base(new tTrGcLgKrymoOBoiCaYQNkQlmDVOB(P_0, P_1, default(KgGMEagteNevMTqZxNiFmnfMLmqQ)))
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			bqVySYIFKmalgCjpcgNZehugLTKjB = new TimerAbs[4];
			ArrayTools.Populate(bqVySYIFKmalgCjpcgNZehugLTKjB, 0, bqVySYIFKmalgCjpcgNZehugLTKjB.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
			: base(P_0)
		{
			bqVySYIFKmalgCjpcgNZehugLTKjB = new TimerAbs[4];
			ArrayTools.Populate(bqVySYIFKmalgCjpcgNZehugLTKjB, 0, bqVySYIFKmalgCjpcgNZehugLTKjB.Length);
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
			if (!EswPsQdpzQsSkUMxTkkfyErsoyuO.SooSblySTknYdpzLTrHBSjAdTfdo)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.CvwHglzUZuhzsoZOhImBUWMCQBQO, 
				1 => EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NiubcHdDBepKtIgmJISGleYgqCUoB, 
				2 => EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NfSnkUzCafbXlFqDvkoSyZOLbkXcA, 
				3 => EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.vELleuCdIVXBPfpEqAfiTuxLSsLL, 
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
			if (!EswPsQdpzQsSkUMxTkkfyErsoyuO.SooSblySTknYdpzLTrHBSjAdTfdo)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.CvwHglzUZuhzsoZOhImBUWMCQBQO, 
				XboxOneGamepadMotorType.RightMotor => EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NiubcHdDBepKtIgmJISGleYgqCUoB, 
				XboxOneGamepadMotorType.LeftTriggerMotor => EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NfSnkUzCafbXlFqDvkoSyZOLbkXcA, 
				XboxOneGamepadMotorType.RightTriggerMotor => EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.vELleuCdIVXBPfpEqAfiTuxLSsLL, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (EswPsQdpzQsSkUMxTkkfyErsoyuO.SooSblySTknYdpzLTrHBSjAdTfdo)
			{
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.rSxdJPPjQQudimmOACZIuuqepYNO();
				for (int i = 0; i < 4; i++)
				{
					bqVySYIFKmalgCjpcgNZehugLTKjB[i].Clear();
				}
				wuhpUUqQvZplBoDAMiEjbtaJioUhA();
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
				if (!EswPsQdpzQsSkUMxTkkfyErsoyuO.SooSblySTknYdpzLTrHBSjAdTfdo)
				{
					return;
				}
				if (stopOtherMotors)
				{
					EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.rSxdJPPjQQudimmOACZIuuqepYNO();
					for (int i = 0; i < 4; i++)
					{
						bqVySYIFKmalgCjpcgNZehugLTKjB[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.CvwHglzUZuhzsoZOhImBUWMCQBQO = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NiubcHdDBepKtIgmJISGleYgqCUoB = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NfSnkUzCafbXlFqDvkoSyZOLbkXcA = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.vELleuCdIVXBPfpEqAfiTuxLSsLL = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				TViQnDBjMeNpyzWDhRtYVYCykgVr(motor, motorLevel, duration);
				wuhpUUqQvZplBoDAMiEjbtaJioUhA();
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
				if (!EswPsQdpzQsSkUMxTkkfyErsoyuO.SooSblySTknYdpzLTrHBSjAdTfdo)
				{
					return;
				}
				if (stopOtherMotors)
				{
					EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.rSxdJPPjQQudimmOACZIuuqepYNO();
					for (int i = 0; i < 4; i++)
					{
						bqVySYIFKmalgCjpcgNZehugLTKjB[i].Clear();
					}
				}
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.xRPzRFlLIwbuElvmUDWLRBVpcUYj = xboxOneJoystickId;
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.CvwHglzUZuhzsoZOhImBUWMCQBQO = MathTools.Clamp01(leftMotorLevel);
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NiubcHdDBepKtIgmJISGleYgqCUoB = MathTools.Clamp01(rightMotorLevel);
				bqVySYIFKmalgCjpcgNZehugLTKjB[0].Clear();
				bqVySYIFKmalgCjpcgNZehugLTKjB[1].Clear();
				wuhpUUqQvZplBoDAMiEjbtaJioUhA();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (EswPsQdpzQsSkUMxTkkfyErsoyuO.SooSblySTknYdpzLTrHBSjAdTfdo)
			{
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.xRPzRFlLIwbuElvmUDWLRBVpcUYj = xboxOneJoystickId;
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.CvwHglzUZuhzsoZOhImBUWMCQBQO = MathTools.Clamp01(leftMotorLevel);
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NiubcHdDBepKtIgmJISGleYgqCUoB = MathTools.Clamp01(rightMotorLevel);
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.NfSnkUzCafbXlFqDvkoSyZOLbkXcA = MathTools.Clamp01(leftTriggerLevel);
				EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA.vELleuCdIVXBPfpEqAfiTuxLSsLL = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					bqVySYIFKmalgCjpcgNZehugLTKjB[i].Clear();
				}
				wuhpUUqQvZplBoDAMiEjbtaJioUhA();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && EswPsQdpzQsSkUMxTkkfyErsoyuO.SooSblySTknYdpzLTrHBSjAdTfdo)
			{
				TViQnDBjMeNpyzWDhRtYVYCykgVr(motor, 0f, 0f);
				EswPsQdpzQsSkUMxTkkfyErsoyuO.FIbMqDwnIouUAwLvafXJrUhaBZcc.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			cLGxdMfkyWZjhZhAydkzVCIgCQqV();
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			EswPsQdpzQsSkUMxTkkfyErsoyuO = source as tTrGcLgKrymoOBoiCaYQNkQlmDVOB;
		}

		internal override Controller.Extension Clone()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void cLGxdMfkyWZjhZhAydkzVCIgCQqV()
		{
			if (!EswPsQdpzQsSkUMxTkkfyErsoyuO.SooSblySTknYdpzLTrHBSjAdTfdo)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (bqVySYIFKmalgCjpcgNZehugLTKjB[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void TViQnDBjMeNpyzWDhRtYVYCykgVr(XboxOneGamepadMotorType P_0, float P_1, float P_2)
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
				bqVySYIFKmalgCjpcgNZehugLTKjB[num].Clear();
			}
			else
			{
				bqVySYIFKmalgCjpcgNZehugLTKjB[num].Start(P_2);
			}
		}

		private void wuhpUUqQvZplBoDAMiEjbtaJioUhA()
		{
			if (base.isJoystickConnected)
			{
				EswPsQdpzQsSkUMxTkkfyErsoyuO.FIbMqDwnIouUAwLvafXJrUhaBZcc.SetXboxOneVibration(xboxOneJoystickId, EswPsQdpzQsSkUMxTkkfyErsoyuO.hJPPLVZuDDrdnCtCsCmLKMUtAaleA);
			}
		}
	}
}
