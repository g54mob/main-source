using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class uEPTddGYssCmuAzGsWrYKWYpGIF : IControllerExtensionSource
		{
			public const int HSFfOkgYdavTAaqGDaWBzgNaSgu = 4;

			public PTwkXEwshTTlutazpmTDEohBwzi jkgFNANzzVnkPVadHkvqToyPfIk;

			public readonly IXboxOneInputSource BUdQscCMwKGSuqgsNqkEchPKHLhG;

			public readonly bool GkLKAMFRzbMjZIZtziMXVcnFggPj;

			public uEPTddGYssCmuAzGsWrYKWYpGIF(bool supportsVibration, IXboxOneInputSource xboxOneInputSource, PTwkXEwshTTlutazpmTDEohBwzi vibrationData)
			{
				jkgFNANzzVnkPVadHkvqToyPfIk = vibrationData;
				BUdQscCMwKGSuqgsNqkEchPKHLhG = xboxOneInputSource;
				GkLKAMFRzbMjZIZtziMXVcnFggPj = supportsVibration;
			}
		}

		private uEPTddGYssCmuAzGsWrYKWYpGIF ahVlanlbOCBOWeBnfSIFVGtHSeq;

		private TimerAbs[] ZmIYmGkyAuhZVDRUIGpXvAIJRaR;

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
				if (ahVlanlbOCBOWeBnfSIFVGtHSeq.BUdQscCMwKGSuqgsNqkEchPKHLhG == null || joystick == null)
				{
					return -1;
				}
				return ahVlanlbOCBOWeBnfSIFVGtHSeq.BUdQscCMwKGSuqgsNqkEchPKHLhG.GetXboxOneUserIdFromUnityJoystick(joystick.unityId);
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
			: base(new uEPTddGYssCmuAzGsWrYKWYpGIF(supportsVibration, xboxOneInputSource, default(PTwkXEwshTTlutazpmTDEohBwzi)))
		{
			if (xboxOneInputSource == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			ZmIYmGkyAuhZVDRUIGpXvAIJRaR = new TimerAbs[4];
			ArrayTools.Populate(ZmIYmGkyAuhZVDRUIGpXvAIJRaR, 0, ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension source)
			: base(source)
		{
			ZmIYmGkyAuhZVDRUIGpXvAIJRaR = new TimerAbs[4];
			ArrayTools.Populate(ZmIYmGkyAuhZVDRUIGpXvAIJRaR, 0, ZmIYmGkyAuhZVDRUIGpXvAIJRaR.Length);
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
			if (!ahVlanlbOCBOWeBnfSIFVGtHSeq.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.puceKrRUGBErqiVMCwppzwpRjqTf, 
				1 => ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.vxkobSKBkcBUtCRJJqCIkpCuzxH, 
				2 => ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.jaJiGacwlrqHibbqpcmmFARfBpbh, 
				3 => ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.ufAhusuFicIPpijaSRFDChWgqhTK, 
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
			if (!ahVlanlbOCBOWeBnfSIFVGtHSeq.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.puceKrRUGBErqiVMCwppzwpRjqTf, 
				XboxOneGamepadMotorType.RightMotor => ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.vxkobSKBkcBUtCRJJqCIkpCuzxH, 
				XboxOneGamepadMotorType.LeftTriggerMotor => ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.jaJiGacwlrqHibbqpcmmFARfBpbh, 
				XboxOneGamepadMotorType.RightTriggerMotor => ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.ufAhusuFicIPpijaSRFDChWgqhTK, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (ahVlanlbOCBOWeBnfSIFVGtHSeq.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.PSaWHiLijZBSALXCCjFOGTEwpmNj();
				for (int i = 0; i < 4; i++)
				{
					ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Clear();
				}
				xqtwvAdtBRryiuQHYPOGgcLUzgV();
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
				if (!ahVlanlbOCBOWeBnfSIFVGtHSeq.GkLKAMFRzbMjZIZtziMXVcnFggPj)
				{
					return;
				}
				if (stopOtherMotors)
				{
					ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.PSaWHiLijZBSALXCCjFOGTEwpmNj();
					for (int i = 0; i < 4; i++)
					{
						ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.puceKrRUGBErqiVMCwppzwpRjqTf = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.vxkobSKBkcBUtCRJJqCIkpCuzxH = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.jaJiGacwlrqHibbqpcmmFARfBpbh = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.ufAhusuFicIPpijaSRFDChWgqhTK = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				vAQoCgVfelQQROodmbOGmxKBFeC(motor, motorLevel, duration);
				xqtwvAdtBRryiuQHYPOGgcLUzgV();
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
				if (!ahVlanlbOCBOWeBnfSIFVGtHSeq.GkLKAMFRzbMjZIZtziMXVcnFggPj)
				{
					return;
				}
				if (stopOtherMotors)
				{
					ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.PSaWHiLijZBSALXCCjFOGTEwpmNj();
					for (int i = 0; i < 4; i++)
					{
						ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Clear();
					}
				}
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.DXkLrtBzTDQcMNiWexxrfcIejhD = xboxOneJoystickId;
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.puceKrRUGBErqiVMCwppzwpRjqTf = MathTools.Clamp01(leftMotorLevel);
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.vxkobSKBkcBUtCRJJqCIkpCuzxH = MathTools.Clamp01(rightMotorLevel);
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR[0].Clear();
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR[1].Clear();
				xqtwvAdtBRryiuQHYPOGgcLUzgV();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (ahVlanlbOCBOWeBnfSIFVGtHSeq.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.DXkLrtBzTDQcMNiWexxrfcIejhD = xboxOneJoystickId;
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.puceKrRUGBErqiVMCwppzwpRjqTf = MathTools.Clamp01(leftMotorLevel);
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.vxkobSKBkcBUtCRJJqCIkpCuzxH = MathTools.Clamp01(rightMotorLevel);
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.jaJiGacwlrqHibbqpcmmFARfBpbh = MathTools.Clamp01(leftTriggerLevel);
				ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk.ufAhusuFicIPpijaSRFDChWgqhTK = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Clear();
				}
				xqtwvAdtBRryiuQHYPOGgcLUzgV();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && ahVlanlbOCBOWeBnfSIFVGtHSeq.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				vAQoCgVfelQQROodmbOGmxKBFeC(motor, 0f, 0f);
				ahVlanlbOCBOWeBnfSIFVGtHSeq.BUdQscCMwKGSuqgsNqkEchPKHLhG.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal void KcNfORqUkjxfSzjWExwXXCRKlZu(UpdateLoopType P_0)
		{
			AdgerJOJHeELnHnJdXbVLfbiaXX();
		}

		internal void FIsQjdAAyWEysCgIuJuNAowHchI(IControllerExtensionSource P_0)
		{
			ahVlanlbOCBOWeBnfSIFVGtHSeq = P_0 as uEPTddGYssCmuAzGsWrYKWYpGIF;
		}

		internal Controller.Extension cGSBTlPoJoSUBEuZRjRzMJDgwjh()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void AdgerJOJHeELnHnJdXbVLfbiaXX()
		{
			if (!ahVlanlbOCBOWeBnfSIFVGtHSeq.GkLKAMFRzbMjZIZtziMXVcnFggPj)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (ZmIYmGkyAuhZVDRUIGpXvAIJRaR[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void vAQoCgVfelQQROodmbOGmxKBFeC(XboxOneGamepadMotorType P_0, float P_1, float P_2)
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
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR[num].Clear();
			}
			else
			{
				ZmIYmGkyAuhZVDRUIGpXvAIJRaR[num].Start(P_2);
			}
		}

		private void xqtwvAdtBRryiuQHYPOGgcLUzgV()
		{
			if (base.isJoystickConnected)
			{
				ahVlanlbOCBOWeBnfSIFVGtHSeq.BUdQscCMwKGSuqgsNqkEchPKHLhG.SetXboxOneVibration(xboxOneJoystickId, ahVlanlbOCBOWeBnfSIFVGtHSeq.jkgFNANzzVnkPVadHkvqToyPfIk);
			}
		}
	}
}
