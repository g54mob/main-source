using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class VYfhACxgxAXMxQiecFSoBdpeZCZbA : IControllerExtensionSource
		{
			public const int gExXpPJRmQHjBkMeRNtbKgelRgwx = 4;

			public oZISafBoibILjjNTfBebbZKKoxsR MrKaopeGkzONQNlEVfHYwTZCXvaY;

			public readonly IXboxOneInputSource aALDJNitdiBmlfyAATNyPDyqVXdKB;

			public readonly bool rPrsppgJoLZNESoZrflzwqCEQiFO;

			public VYfhACxgxAXMxQiecFSoBdpeZCZbA(bool P_0, IXboxOneInputSource P_1, oZISafBoibILjjNTfBebbZKKoxsR P_2)
			{
				MrKaopeGkzONQNlEVfHYwTZCXvaY = P_2;
				aALDJNitdiBmlfyAATNyPDyqVXdKB = P_1;
				rPrsppgJoLZNESoZrflzwqCEQiFO = P_0;
			}
		}

		private VYfhACxgxAXMxQiecFSoBdpeZCZbA HXvQzPApsqliDaJnhjuqaWlQGmel;

		private TimerAbs[] yekhXxBxPOvvGNgoOsAvEoxWLuBV;

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
				if (HXvQzPApsqliDaJnhjuqaWlQGmel.aALDJNitdiBmlfyAATNyPDyqVXdKB == null || joystick == null)
				{
					return -1;
				}
				return HXvQzPApsqliDaJnhjuqaWlQGmel.aALDJNitdiBmlfyAATNyPDyqVXdKB.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
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

		internal XboxOneGamepadExtension(bool P_0, IXboxOneInputSource P_1)
			: base(new VYfhACxgxAXMxQiecFSoBdpeZCZbA(P_0, P_1, default(oZISafBoibILjjNTfBebbZKKoxsR)))
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			yekhXxBxPOvvGNgoOsAvEoxWLuBV = new TimerAbs[4];
			ArrayTools.Populate(yekhXxBxPOvvGNgoOsAvEoxWLuBV, 0, yekhXxBxPOvvGNgoOsAvEoxWLuBV.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
			: base(P_0)
		{
			yekhXxBxPOvvGNgoOsAvEoxWLuBV = new TimerAbs[4];
			ArrayTools.Populate(yekhXxBxPOvvGNgoOsAvEoxWLuBV, 0, yekhXxBxPOvvGNgoOsAvEoxWLuBV.Length);
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
				XboxOneGamepadMotorType motor;
				switch (motorIndex)
				{
				case 0:
					motor = XboxOneGamepadMotorType.LeftMotor;
					break;
				case 1:
					motor = XboxOneGamepadMotorType.RightMotor;
					break;
				case 2:
					motor = XboxOneGamepadMotorType.LeftTriggerMotor;
					break;
				case 3:
					motor = XboxOneGamepadMotorType.RightTriggerMotor;
					break;
				default:
					throw new NotImplementedException();
				}
				SetVibration(motor, motorLevel, duration, stopOtherMotors);
			}
		}

		public float GetVibration(int motorIndex)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!HXvQzPApsqliDaJnhjuqaWlQGmel.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				return 0f;
			}
			switch (motorIndex)
			{
			case 0:
				return HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.ANSllAkSZftTtPPwCpMZCmCIBuRO;
			case 1:
				return HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.IkABAjbftCiucaTpRdfywWfzUnFJA;
			case 2:
				return HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.SFpBtBRdiJiAxhAUtkLOqnyysxro;
			case 3:
				return HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.BoyyVZHBdUSvedrASSmfAWpjqvVr;
			default:
				return 0f;
			}
		}

		public float GetVibration(XboxOneGamepadMotorType motor)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return 0f;
			}
			if (!HXvQzPApsqliDaJnhjuqaWlQGmel.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				return 0f;
			}
			switch (motor)
			{
			case XboxOneGamepadMotorType.LeftMotor:
				return HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.ANSllAkSZftTtPPwCpMZCmCIBuRO;
			case XboxOneGamepadMotorType.RightMotor:
				return HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.IkABAjbftCiucaTpRdfywWfzUnFJA;
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				return HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.SFpBtBRdiJiAxhAUtkLOqnyysxro;
			case XboxOneGamepadMotorType.RightTriggerMotor:
				return HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.BoyyVZHBdUSvedrASSmfAWpjqvVr;
			default:
				throw new NotImplementedException();
			}
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (HXvQzPApsqliDaJnhjuqaWlQGmel.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.oKWeiHeoyjjgRFmiWtuagmbhQcJn();
				for (int i = 0; i < 4; i++)
				{
					yekhXxBxPOvvGNgoOsAvEoxWLuBV[i].Clear();
				}
				EFYPvUIGrgNnggtOtewXDuXlzVDA();
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
				if (!HXvQzPApsqliDaJnhjuqaWlQGmel.rPrsppgJoLZNESoZrflzwqCEQiFO)
				{
					return;
				}
				if (stopOtherMotors)
				{
					HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.oKWeiHeoyjjgRFmiWtuagmbhQcJn();
					for (int i = 0; i < 4; i++)
					{
						yekhXxBxPOvvGNgoOsAvEoxWLuBV[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.ANSllAkSZftTtPPwCpMZCmCIBuRO = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.IkABAjbftCiucaTpRdfywWfzUnFJA = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.SFpBtBRdiJiAxhAUtkLOqnyysxro = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.BoyyVZHBdUSvedrASSmfAWpjqvVr = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				QRwFzBEmhZLaKeUBoJxmNRlAhcSGb(motor, motorLevel, duration);
				EFYPvUIGrgNnggtOtewXDuXlzVDA();
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
				if (!HXvQzPApsqliDaJnhjuqaWlQGmel.rPrsppgJoLZNESoZrflzwqCEQiFO)
				{
					return;
				}
				if (stopOtherMotors)
				{
					HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.oKWeiHeoyjjgRFmiWtuagmbhQcJn();
					for (int i = 0; i < 4; i++)
					{
						yekhXxBxPOvvGNgoOsAvEoxWLuBV[i].Clear();
					}
				}
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.yiCquIkewnqONDDyeaYHMKnpPdZy = xboxOneJoystickId;
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.ANSllAkSZftTtPPwCpMZCmCIBuRO = MathTools.Clamp01(leftMotorLevel);
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.IkABAjbftCiucaTpRdfywWfzUnFJA = MathTools.Clamp01(rightMotorLevel);
				yekhXxBxPOvvGNgoOsAvEoxWLuBV[0].Clear();
				yekhXxBxPOvvGNgoOsAvEoxWLuBV[1].Clear();
				EFYPvUIGrgNnggtOtewXDuXlzVDA();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (HXvQzPApsqliDaJnhjuqaWlQGmel.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.yiCquIkewnqONDDyeaYHMKnpPdZy = xboxOneJoystickId;
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.ANSllAkSZftTtPPwCpMZCmCIBuRO = MathTools.Clamp01(leftMotorLevel);
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.IkABAjbftCiucaTpRdfywWfzUnFJA = MathTools.Clamp01(rightMotorLevel);
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.SFpBtBRdiJiAxhAUtkLOqnyysxro = MathTools.Clamp01(leftTriggerLevel);
				HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY.BoyyVZHBdUSvedrASSmfAWpjqvVr = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					yekhXxBxPOvvGNgoOsAvEoxWLuBV[i].Clear();
				}
				EFYPvUIGrgNnggtOtewXDuXlzVDA();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && HXvQzPApsqliDaJnhjuqaWlQGmel.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				QRwFzBEmhZLaKeUBoJxmNRlAhcSGb(motor, 0f, 0f);
				HXvQzPApsqliDaJnhjuqaWlQGmel.aALDJNitdiBmlfyAATNyPDyqVXdKB.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			pPYHierAOCbwuFIlzImlapEvgaTbA();
		}

		internal override void SourceUpdated(IControllerExtensionSource source)
		{
			HXvQzPApsqliDaJnhjuqaWlQGmel = source as VYfhACxgxAXMxQiecFSoBdpeZCZbA;
		}

		internal override Controller.Extension Clone()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void pPYHierAOCbwuFIlzImlapEvgaTbA()
		{
			if (!HXvQzPApsqliDaJnhjuqaWlQGmel.rPrsppgJoLZNESoZrflzwqCEQiFO)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (yekhXxBxPOvvGNgoOsAvEoxWLuBV[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void QRwFzBEmhZLaKeUBoJxmNRlAhcSGb(XboxOneGamepadMotorType P_0, float P_1, float P_2)
		{
			int num;
			switch (P_0)
			{
			case XboxOneGamepadMotorType.LeftMotor:
				num = 0;
				break;
			case XboxOneGamepadMotorType.RightMotor:
				num = 1;
				break;
			case XboxOneGamepadMotorType.LeftTriggerMotor:
				num = 2;
				break;
			case XboxOneGamepadMotorType.RightTriggerMotor:
				num = 3;
				break;
			default:
				throw new NotImplementedException();
			}
			if (P_1 <= 0f || P_2 <= 0f)
			{
				yekhXxBxPOvvGNgoOsAvEoxWLuBV[num].Clear();
			}
			else
			{
				yekhXxBxPOvvGNgoOsAvEoxWLuBV[num].Start(P_2);
			}
		}

		private void EFYPvUIGrgNnggtOtewXDuXlzVDA()
		{
			if (base.isJoystickConnected)
			{
				HXvQzPApsqliDaJnhjuqaWlQGmel.aALDJNitdiBmlfyAATNyPDyqVXdKB.SetXboxOneVibration(xboxOneJoystickId, HXvQzPApsqliDaJnhjuqaWlQGmel.MrKaopeGkzONQNlEVfHYwTZCXvaY);
			}
		}
	}
}
