using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class uptRKJBHvMfeBlIOJozAuQpvAiHC : IControllerExtensionSource
		{
			public const int TvfyCOtyYKIlzJHUmJzZBRLesBkj = 4;

			public ZCUdBedUUjmCBSWhOAJNcgvTbdyn hoAfdiKWUlDwsnckgUxcqroXXxspA;

			public readonly IXboxOneInputSource PDFWIWLxByJmLNGgoleQCPDSHRnj;

			public readonly bool QgfiOqAqKFgNutFnAbZVtqhHbmPt;

			public uptRKJBHvMfeBlIOJozAuQpvAiHC(bool P_0, IXboxOneInputSource P_1, ZCUdBedUUjmCBSWhOAJNcgvTbdyn P_2)
			{
				hoAfdiKWUlDwsnckgUxcqroXXxspA = P_2;
				PDFWIWLxByJmLNGgoleQCPDSHRnj = P_1;
				QgfiOqAqKFgNutFnAbZVtqhHbmPt = P_0;
			}
		}

		private uptRKJBHvMfeBlIOJozAuQpvAiHC yGdZHAmdUeDYveLTSINOCvUHtMoHA;

		private TimerAbs[] RmnWiflzWOKoiXCnMcRZqWFvqDq;

		private Joystick ncRBPRILXKISRDXTTSTeRKtkNzpTA => GetController<Joystick>();

		public int xboxOneUserId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (yGdZHAmdUeDYveLTSINOCvUHtMoHA.PDFWIWLxByJmLNGgoleQCPDSHRnj == null || ncRBPRILXKISRDXTTSTeRKtkNzpTA == null)
				{
					return -1;
				}
				return yGdZHAmdUeDYveLTSINOCvUHtMoHA.PDFWIWLxByJmLNGgoleQCPDSHRnj.GetXboxOneUserIdFromUnityJoystick(ncRBPRILXKISRDXTTSTeRKtkNzpTA.unityId);
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
				if (ncRBPRILXKISRDXTTSTeRKtkNzpTA == null)
				{
					return 0uL;
				}
				long? systemId = ncRBPRILXKISRDXTTSTeRKtkNzpTA.systemId;
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
			: base(new uptRKJBHvMfeBlIOJozAuQpvAiHC(P_0, P_1, default(ZCUdBedUUjmCBSWhOAJNcgvTbdyn)))
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			RmnWiflzWOKoiXCnMcRZqWFvqDq = new TimerAbs[4];
			ArrayTools.Populate(RmnWiflzWOKoiXCnMcRZqWFvqDq, 0, RmnWiflzWOKoiXCnMcRZqWFvqDq.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
			: base(P_0)
		{
			RmnWiflzWOKoiXCnMcRZqWFvqDq = new TimerAbs[4];
			ArrayTools.Populate(RmnWiflzWOKoiXCnMcRZqWFvqDq, 0, RmnWiflzWOKoiXCnMcRZqWFvqDq.Length);
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
			if (!yGdZHAmdUeDYveLTSINOCvUHtMoHA.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.beUkeDKrwnofPgcMxoPtNYdTwMZH, 
				1 => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.vAEFueFHPSFJQkEHuaLADFQgepXab, 
				2 => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.tplbEYhfSZWlVKMyULvknlZvqxfsA, 
				3 => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.srsKgIroRWEpEQdszGmVRBAkzWPH, 
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
			if (!yGdZHAmdUeDYveLTSINOCvUHtMoHA.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.beUkeDKrwnofPgcMxoPtNYdTwMZH, 
				XboxOneGamepadMotorType.RightMotor => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.vAEFueFHPSFJQkEHuaLADFQgepXab, 
				XboxOneGamepadMotorType.LeftTriggerMotor => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.tplbEYhfSZWlVKMyULvknlZvqxfsA, 
				XboxOneGamepadMotorType.RightTriggerMotor => yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.srsKgIroRWEpEQdszGmVRBAkzWPH, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (yGdZHAmdUeDYveLTSINOCvUHtMoHA.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.BBYfCVIGOfRdogGHxWUQvWvkoVpb();
				for (int i = 0; i < 4; i++)
				{
					RmnWiflzWOKoiXCnMcRZqWFvqDq[i].Clear();
				}
				tDTDGyidytaeDBuRxfECgSTChtLlA();
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
				if (!yGdZHAmdUeDYveLTSINOCvUHtMoHA.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
				{
					return;
				}
				if (stopOtherMotors)
				{
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.BBYfCVIGOfRdogGHxWUQvWvkoVpb();
					for (int i = 0; i < 4; i++)
					{
						RmnWiflzWOKoiXCnMcRZqWFvqDq[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.beUkeDKrwnofPgcMxoPtNYdTwMZH = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.vAEFueFHPSFJQkEHuaLADFQgepXab = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.tplbEYhfSZWlVKMyULvknlZvqxfsA = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.srsKgIroRWEpEQdszGmVRBAkzWPH = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				xUiySGACDBhDcbetVeBYjAQZgkWMA(motor, motorLevel, duration);
				tDTDGyidytaeDBuRxfECgSTChtLlA();
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
				if (!yGdZHAmdUeDYveLTSINOCvUHtMoHA.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
				{
					return;
				}
				if (stopOtherMotors)
				{
					yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.BBYfCVIGOfRdogGHxWUQvWvkoVpb();
					for (int i = 0; i < 4; i++)
					{
						RmnWiflzWOKoiXCnMcRZqWFvqDq[i].Clear();
					}
				}
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.ZRMbzBhMYzJNtcgMkDcxGPIdglGVe = xboxOneJoystickId;
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.beUkeDKrwnofPgcMxoPtNYdTwMZH = MathTools.Clamp01(leftMotorLevel);
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.vAEFueFHPSFJQkEHuaLADFQgepXab = MathTools.Clamp01(rightMotorLevel);
				RmnWiflzWOKoiXCnMcRZqWFvqDq[0].Clear();
				RmnWiflzWOKoiXCnMcRZqWFvqDq[1].Clear();
				tDTDGyidytaeDBuRxfECgSTChtLlA();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (yGdZHAmdUeDYveLTSINOCvUHtMoHA.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.ZRMbzBhMYzJNtcgMkDcxGPIdglGVe = xboxOneJoystickId;
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.beUkeDKrwnofPgcMxoPtNYdTwMZH = MathTools.Clamp01(leftMotorLevel);
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.vAEFueFHPSFJQkEHuaLADFQgepXab = MathTools.Clamp01(rightMotorLevel);
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.tplbEYhfSZWlVKMyULvknlZvqxfsA = MathTools.Clamp01(leftTriggerLevel);
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA.srsKgIroRWEpEQdszGmVRBAkzWPH = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					RmnWiflzWOKoiXCnMcRZqWFvqDq[i].Clear();
				}
				tDTDGyidytaeDBuRxfECgSTChtLlA();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && yGdZHAmdUeDYveLTSINOCvUHtMoHA.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				xUiySGACDBhDcbetVeBYjAQZgkWMA(motor, 0f, 0f);
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.PDFWIWLxByJmLNGgoleQCPDSHRnj.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal void OPzMeptHNTMsrWdWvslRxoVUdTujA(UpdateLoopType P_0)
		{
			AMMeAhkLwOBFGwkLSkKJbpphoqDmc();
		}

		internal void LPEqqRVtBurlVfmUZLbHuUeFxrWN(IControllerExtensionSource P_0)
		{
			yGdZHAmdUeDYveLTSINOCvUHtMoHA = P_0 as uptRKJBHvMfeBlIOJozAuQpvAiHC;
		}

		internal Controller.Extension whghpXSUuKbFknTBkNmxaxTkkihX()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void AMMeAhkLwOBFGwkLSkKJbpphoqDmc()
		{
			if (!yGdZHAmdUeDYveLTSINOCvUHtMoHA.QgfiOqAqKFgNutFnAbZVtqhHbmPt)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (RmnWiflzWOKoiXCnMcRZqWFvqDq[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void xUiySGACDBhDcbetVeBYjAQZgkWMA(XboxOneGamepadMotorType P_0, float P_1, float P_2)
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
				RmnWiflzWOKoiXCnMcRZqWFvqDq[num].Clear();
			}
			else
			{
				RmnWiflzWOKoiXCnMcRZqWFvqDq[num].Start(P_2);
			}
		}

		private void tDTDGyidytaeDBuRxfECgSTChtLlA()
		{
			if (base.isJoystickConnected)
			{
				yGdZHAmdUeDYveLTSINOCvUHtMoHA.PDFWIWLxByJmLNGgoleQCPDSHRnj.SetXboxOneVibration(xboxOneJoystickId, yGdZHAmdUeDYveLTSINOCvUHtMoHA.hoAfdiKWUlDwsnckgUxcqroXXxspA);
			}
		}
	}
}
