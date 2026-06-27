using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class PZsFMmXHheVqstajtBljRfqfenhs : IControllerExtensionSource
		{
			public const int fOWNcnhDrASfAiBjSGayVlBmpFlL = 4;

			public yNLniFhzsLYZmKMWkhKgLEHXMCSk DXMcJaUhRHHAPXUVfkhwpGuaGGHfA;

			public readonly IXboxOneInputSource vDywrLhbxsQLqloYpbguESqvrsvl;

			public readonly bool crrUCMhHqbdBRkMOsCqFjyiHXZW;

			public PZsFMmXHheVqstajtBljRfqfenhs(bool P_0, IXboxOneInputSource P_1, yNLniFhzsLYZmKMWkhKgLEHXMCSk P_2)
			{
				DXMcJaUhRHHAPXUVfkhwpGuaGGHfA = P_2;
				vDywrLhbxsQLqloYpbguESqvrsvl = P_1;
				crrUCMhHqbdBRkMOsCqFjyiHXZW = P_0;
			}
		}

		private PZsFMmXHheVqstajtBljRfqfenhs kZrcBxsjvGdbIPAcWpfAXaZvuWCr;

		private TimerAbs[] LUMbJpVOpiIxOsgubAHyWAgArBqD;

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
				if (kZrcBxsjvGdbIPAcWpfAXaZvuWCr.vDywrLhbxsQLqloYpbguESqvrsvl == null || joystick == null)
				{
					return -1;
				}
				return kZrcBxsjvGdbIPAcWpfAXaZvuWCr.vDywrLhbxsQLqloYpbguESqvrsvl.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
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
			: base(new PZsFMmXHheVqstajtBljRfqfenhs(P_0, P_1, default(yNLniFhzsLYZmKMWkhKgLEHXMCSk)))
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			LUMbJpVOpiIxOsgubAHyWAgArBqD = new TimerAbs[4];
			ArrayTools.Populate(LUMbJpVOpiIxOsgubAHyWAgArBqD, 0, LUMbJpVOpiIxOsgubAHyWAgArBqD.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
			: base(P_0)
		{
			LUMbJpVOpiIxOsgubAHyWAgArBqD = new TimerAbs[4];
			ArrayTools.Populate(LUMbJpVOpiIxOsgubAHyWAgArBqD, 0, LUMbJpVOpiIxOsgubAHyWAgArBqD.Length);
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
			if (!kZrcBxsjvGdbIPAcWpfAXaZvuWCr.crrUCMhHqbdBRkMOsCqFjyiHXZW)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.iCrNVIiOZwKXKjELknTunTyJvTgh, 
				1 => kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.boxZMiGLtgltLtpvZJfHNwFvucWc, 
				2 => kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.noPDJfaAqhjyBpJKgtVhidaOISrP, 
				3 => kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.BMEPmFFAWXEgneYJnPyVuURYsOlH, 
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
			if (!kZrcBxsjvGdbIPAcWpfAXaZvuWCr.crrUCMhHqbdBRkMOsCqFjyiHXZW)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.iCrNVIiOZwKXKjELknTunTyJvTgh, 
				XboxOneGamepadMotorType.RightMotor => kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.boxZMiGLtgltLtpvZJfHNwFvucWc, 
				XboxOneGamepadMotorType.LeftTriggerMotor => kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.noPDJfaAqhjyBpJKgtVhidaOISrP, 
				XboxOneGamepadMotorType.RightTriggerMotor => kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.BMEPmFFAWXEgneYJnPyVuURYsOlH, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (kZrcBxsjvGdbIPAcWpfAXaZvuWCr.crrUCMhHqbdBRkMOsCqFjyiHXZW)
			{
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.JDaTkcAMYMZASnBFBYStFhYxsadp();
				for (int i = 0; i < 4; i++)
				{
					LUMbJpVOpiIxOsgubAHyWAgArBqD[i].Clear();
				}
				CciBzdpbzHgMbtmZDENIOUOCdWoU();
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
				if (!kZrcBxsjvGdbIPAcWpfAXaZvuWCr.crrUCMhHqbdBRkMOsCqFjyiHXZW)
				{
					return;
				}
				if (stopOtherMotors)
				{
					kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.JDaTkcAMYMZASnBFBYStFhYxsadp();
					for (int i = 0; i < 4; i++)
					{
						LUMbJpVOpiIxOsgubAHyWAgArBqD[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.iCrNVIiOZwKXKjELknTunTyJvTgh = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.boxZMiGLtgltLtpvZJfHNwFvucWc = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.noPDJfaAqhjyBpJKgtVhidaOISrP = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.BMEPmFFAWXEgneYJnPyVuURYsOlH = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				xJldGgGPGqkIUmoYmamheBsxoEdT(motor, motorLevel, duration);
				CciBzdpbzHgMbtmZDENIOUOCdWoU();
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
				if (!kZrcBxsjvGdbIPAcWpfAXaZvuWCr.crrUCMhHqbdBRkMOsCqFjyiHXZW)
				{
					return;
				}
				if (stopOtherMotors)
				{
					kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.JDaTkcAMYMZASnBFBYStFhYxsadp();
					for (int i = 0; i < 4; i++)
					{
						LUMbJpVOpiIxOsgubAHyWAgArBqD[i].Clear();
					}
				}
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.TDSjYeqeAuMGucHdLLGqgbzgOAsM = xboxOneJoystickId;
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.iCrNVIiOZwKXKjELknTunTyJvTgh = MathTools.Clamp01(leftMotorLevel);
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.boxZMiGLtgltLtpvZJfHNwFvucWc = MathTools.Clamp01(rightMotorLevel);
				LUMbJpVOpiIxOsgubAHyWAgArBqD[0].Clear();
				LUMbJpVOpiIxOsgubAHyWAgArBqD[1].Clear();
				CciBzdpbzHgMbtmZDENIOUOCdWoU();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (kZrcBxsjvGdbIPAcWpfAXaZvuWCr.crrUCMhHqbdBRkMOsCqFjyiHXZW)
			{
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.TDSjYeqeAuMGucHdLLGqgbzgOAsM = xboxOneJoystickId;
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.iCrNVIiOZwKXKjELknTunTyJvTgh = MathTools.Clamp01(leftMotorLevel);
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.boxZMiGLtgltLtpvZJfHNwFvucWc = MathTools.Clamp01(rightMotorLevel);
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.noPDJfaAqhjyBpJKgtVhidaOISrP = MathTools.Clamp01(leftTriggerLevel);
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA.BMEPmFFAWXEgneYJnPyVuURYsOlH = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					LUMbJpVOpiIxOsgubAHyWAgArBqD[i].Clear();
				}
				CciBzdpbzHgMbtmZDENIOUOCdWoU();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && kZrcBxsjvGdbIPAcWpfAXaZvuWCr.crrUCMhHqbdBRkMOsCqFjyiHXZW)
			{
				xJldGgGPGqkIUmoYmamheBsxoEdT(motor, 0f, 0f);
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.vDywrLhbxsQLqloYpbguESqvrsvl.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			OFPcEzuuiMekNBEJdOmMoqijTuEGA();
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			kZrcBxsjvGdbIPAcWpfAXaZvuWCr = source as PZsFMmXHheVqstajtBljRfqfenhs;
		}

		internal override Controller.Extension Clone()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void OFPcEzuuiMekNBEJdOmMoqijTuEGA()
		{
			if (!kZrcBxsjvGdbIPAcWpfAXaZvuWCr.crrUCMhHqbdBRkMOsCqFjyiHXZW)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (LUMbJpVOpiIxOsgubAHyWAgArBqD[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void xJldGgGPGqkIUmoYmamheBsxoEdT(XboxOneGamepadMotorType P_0, float P_1, float P_2)
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
				LUMbJpVOpiIxOsgubAHyWAgArBqD[num].Clear();
			}
			else
			{
				LUMbJpVOpiIxOsgubAHyWAgArBqD[num].Start(P_2);
			}
		}

		private void CciBzdpbzHgMbtmZDENIOUOCdWoU()
		{
			if (base.isJoystickConnected)
			{
				kZrcBxsjvGdbIPAcWpfAXaZvuWCr.vDywrLhbxsQLqloYpbguESqvrsvl.SetXboxOneVibration(xboxOneJoystickId, kZrcBxsjvGdbIPAcWpfAXaZvuWCr.DXMcJaUhRHHAPXUVfkhwpGuaGGHfA);
			}
		}
	}
}
