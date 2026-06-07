using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class WECARHXrpdJjkraslGTFHlWQJsnm : IControllerExtensionSource
		{
			public const int qMuKAIzLXLKtEqpwWOwWJFdFZJti = 4;

			public xnlieJzaCUMurEZZmzCtThDssQyB IrydFFUHhUIwJJIDvxQOxMpFwHXE;

			public readonly IXboxOneInputSource gcMteqfazhzTelJDvbkUMlMQqVpr;

			public readonly bool hxHXxpdCZbCjTaFFCWIUjjEPEpXAA;

			public WECARHXrpdJjkraslGTFHlWQJsnm(bool P_0, IXboxOneInputSource P_1, xnlieJzaCUMurEZZmzCtThDssQyB P_2)
			{
				IrydFFUHhUIwJJIDvxQOxMpFwHXE = P_2;
				gcMteqfazhzTelJDvbkUMlMQqVpr = P_1;
				hxHXxpdCZbCjTaFFCWIUjjEPEpXAA = P_0;
			}
		}

		private WECARHXrpdJjkraslGTFHlWQJsnm tVrKCHirEHrUHNpVGjwqRxyQoYhc;

		private TimerAbs[] WYyqFEZgYpKIIiZvjUAWSqyzFiqf;

		private Joystick JupQeIMlwDDCDQyeYrLlIXXwLROI => GetController<Joystick>();

		public int xboxOneUserId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (tVrKCHirEHrUHNpVGjwqRxyQoYhc.gcMteqfazhzTelJDvbkUMlMQqVpr == null || JupQeIMlwDDCDQyeYrLlIXXwLROI == null)
				{
					return -1;
				}
				return tVrKCHirEHrUHNpVGjwqRxyQoYhc.gcMteqfazhzTelJDvbkUMlMQqVpr.GetXboxOneUserIdFromUnityJoystick(JupQeIMlwDDCDQyeYrLlIXXwLROI.unityId);
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
				if (JupQeIMlwDDCDQyeYrLlIXXwLROI == null)
				{
					return 0uL;
				}
				long? systemId = JupQeIMlwDDCDQyeYrLlIXXwLROI.systemId;
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
			: base(new WECARHXrpdJjkraslGTFHlWQJsnm(P_0, P_1, default(xnlieJzaCUMurEZZmzCtThDssQyB)))
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			WYyqFEZgYpKIIiZvjUAWSqyzFiqf = new TimerAbs[4];
			ArrayTools.Populate(WYyqFEZgYpKIIiZvjUAWSqyzFiqf, 0, WYyqFEZgYpKIIiZvjUAWSqyzFiqf.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
			: base(P_0)
		{
			WYyqFEZgYpKIIiZvjUAWSqyzFiqf = new TimerAbs[4];
			ArrayTools.Populate(WYyqFEZgYpKIIiZvjUAWSqyzFiqf, 0, WYyqFEZgYpKIIiZvjUAWSqyzFiqf.Length);
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
			if (!tVrKCHirEHrUHNpVGjwqRxyQoYhc.hxHXxpdCZbCjTaFFCWIUjjEPEpXAA)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.jDPYQbyTQhExOvKKsfXCvAmyZsed, 
				1 => tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.ytZUPBQOZznGXtnkHTiLZhSUIsqL, 
				2 => tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.qodKWCuyxkkNfhDHqpCReIPdozxc, 
				3 => tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.UOgMqeTGmCobbmEOrezAazhvCfnD, 
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
			if (!tVrKCHirEHrUHNpVGjwqRxyQoYhc.hxHXxpdCZbCjTaFFCWIUjjEPEpXAA)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.jDPYQbyTQhExOvKKsfXCvAmyZsed, 
				XboxOneGamepadMotorType.RightMotor => tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.ytZUPBQOZznGXtnkHTiLZhSUIsqL, 
				XboxOneGamepadMotorType.LeftTriggerMotor => tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.qodKWCuyxkkNfhDHqpCReIPdozxc, 
				XboxOneGamepadMotorType.RightTriggerMotor => tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.UOgMqeTGmCobbmEOrezAazhvCfnD, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (tVrKCHirEHrUHNpVGjwqRxyQoYhc.hxHXxpdCZbCjTaFFCWIUjjEPEpXAA)
			{
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.CgWwlZApSJfSQdPUHMYBRFgSDMfo();
				for (int i = 0; i < 4; i++)
				{
					WYyqFEZgYpKIIiZvjUAWSqyzFiqf[i].Clear();
				}
				PYieYhBxIaUvdLOXeRcQLqxWkky();
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
				if (!tVrKCHirEHrUHNpVGjwqRxyQoYhc.hxHXxpdCZbCjTaFFCWIUjjEPEpXAA)
				{
					return;
				}
				if (stopOtherMotors)
				{
					tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.CgWwlZApSJfSQdPUHMYBRFgSDMfo();
					for (int i = 0; i < 4; i++)
					{
						WYyqFEZgYpKIIiZvjUAWSqyzFiqf[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.jDPYQbyTQhExOvKKsfXCvAmyZsed = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.ytZUPBQOZznGXtnkHTiLZhSUIsqL = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.qodKWCuyxkkNfhDHqpCReIPdozxc = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.UOgMqeTGmCobbmEOrezAazhvCfnD = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				oEFZJSGIjRKOxmBcloXgmCYcgbAb(motor, motorLevel, duration);
				PYieYhBxIaUvdLOXeRcQLqxWkky();
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
				if (!tVrKCHirEHrUHNpVGjwqRxyQoYhc.hxHXxpdCZbCjTaFFCWIUjjEPEpXAA)
				{
					return;
				}
				if (stopOtherMotors)
				{
					tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.CgWwlZApSJfSQdPUHMYBRFgSDMfo();
					for (int i = 0; i < 4; i++)
					{
						WYyqFEZgYpKIIiZvjUAWSqyzFiqf[i].Clear();
					}
				}
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.OJcbVPEmEruGccyuBKYAguNBDimYA = xboxOneJoystickId;
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.jDPYQbyTQhExOvKKsfXCvAmyZsed = MathTools.Clamp01(leftMotorLevel);
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.ytZUPBQOZznGXtnkHTiLZhSUIsqL = MathTools.Clamp01(rightMotorLevel);
				WYyqFEZgYpKIIiZvjUAWSqyzFiqf[0].Clear();
				WYyqFEZgYpKIIiZvjUAWSqyzFiqf[1].Clear();
				PYieYhBxIaUvdLOXeRcQLqxWkky();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (tVrKCHirEHrUHNpVGjwqRxyQoYhc.hxHXxpdCZbCjTaFFCWIUjjEPEpXAA)
			{
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.OJcbVPEmEruGccyuBKYAguNBDimYA = xboxOneJoystickId;
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.jDPYQbyTQhExOvKKsfXCvAmyZsed = MathTools.Clamp01(leftMotorLevel);
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.ytZUPBQOZznGXtnkHTiLZhSUIsqL = MathTools.Clamp01(rightMotorLevel);
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.qodKWCuyxkkNfhDHqpCReIPdozxc = MathTools.Clamp01(leftTriggerLevel);
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE.UOgMqeTGmCobbmEOrezAazhvCfnD = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					WYyqFEZgYpKIIiZvjUAWSqyzFiqf[i].Clear();
				}
				PYieYhBxIaUvdLOXeRcQLqxWkky();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && tVrKCHirEHrUHNpVGjwqRxyQoYhc.hxHXxpdCZbCjTaFFCWIUjjEPEpXAA)
			{
				oEFZJSGIjRKOxmBcloXgmCYcgbAb(motor, 0f, 0f);
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.gcMteqfazhzTelJDvbkUMlMQqVpr.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal void UxMOKWMJhxaZYNSlMyUlEvpjDJCL(UpdateLoopType P_0)
		{
			XYfKHGwlsRAsDBKAlrqkUuYWUGMwA();
		}

		internal void CDLcnquVFFYZXAObRruDZJvWeEeKA(IControllerExtensionSource P_0)
		{
			tVrKCHirEHrUHNpVGjwqRxyQoYhc = P_0 as WECARHXrpdJjkraslGTFHlWQJsnm;
		}

		internal Controller.Extension lwgpeYwNFoApQEAzuZORPDUINXIeA()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void XYfKHGwlsRAsDBKAlrqkUuYWUGMwA()
		{
			if (!tVrKCHirEHrUHNpVGjwqRxyQoYhc.hxHXxpdCZbCjTaFFCWIUjjEPEpXAA)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (WYyqFEZgYpKIIiZvjUAWSqyzFiqf[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void oEFZJSGIjRKOxmBcloXgmCYcgbAb(XboxOneGamepadMotorType P_0, float P_1, float P_2)
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
				WYyqFEZgYpKIIiZvjUAWSqyzFiqf[num].Clear();
			}
			else
			{
				WYyqFEZgYpKIIiZvjUAWSqyzFiqf[num].Start(P_2);
			}
		}

		private void PYieYhBxIaUvdLOXeRcQLqxWkky()
		{
			if (base.isJoystickConnected)
			{
				tVrKCHirEHrUHNpVGjwqRxyQoYhc.gcMteqfazhzTelJDvbkUMlMQqVpr.SetXboxOneVibration(xboxOneJoystickId, tVrKCHirEHrUHNpVGjwqRxyQoYhc.IrydFFUHhUIwJJIDvxQOxMpFwHXE);
			}
		}
	}
}
