using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;

namespace Rewired.Platforms.XboxOne
{
	public sealed class XboxOneGamepadExtension : Controller.Extension, IControllerVibrator
	{
		private class STOXFeWabFkxmvzlZoIrrqpPpJvb : IControllerExtensionSource
		{
			public const int abcPIQuCdpbNImxhsnXPhPmWdLwb = 4;

			public buajiwwNvsvnjCGMEWoTzaPnJCiy AXbkYRZRUihmELHFTGiBFaoIfSpW;

			public readonly IXboxOneInputSource cYDgpiicsNiebhvOCRTLlgmdBdeHd;

			public readonly bool pQSQDdmkWLOfYumIsnmRDjiCFZhG;

			public STOXFeWabFkxmvzlZoIrrqpPpJvb(bool P_0, IXboxOneInputSource P_1, buajiwwNvsvnjCGMEWoTzaPnJCiy P_2)
			{
				AXbkYRZRUihmELHFTGiBFaoIfSpW = P_2;
				cYDgpiicsNiebhvOCRTLlgmdBdeHd = P_1;
				pQSQDdmkWLOfYumIsnmRDjiCFZhG = P_0;
			}
		}

		private STOXFeWabFkxmvzlZoIrrqpPpJvb tvSPcCbqqfEJVLJwmEInnPLZMpyh;

		private TimerAbs[] KcvzGSMjFFtkRqhsVzkFmnUyvwUi;

		private Joystick FqOJWPUnhgyQiAncKMsJkhrKzmzA => GetController<Joystick>();

		public int xboxOneUserId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				if (tvSPcCbqqfEJVLJwmEInnPLZMpyh.cYDgpiicsNiebhvOCRTLlgmdBdeHd == null || FqOJWPUnhgyQiAncKMsJkhrKzmzA == null)
				{
					return -1;
				}
				return tvSPcCbqqfEJVLJwmEInnPLZMpyh.cYDgpiicsNiebhvOCRTLlgmdBdeHd.GetXboxOneUserIdFromUnityJoystick(FqOJWPUnhgyQiAncKMsJkhrKzmzA.unityId);
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
				if (FqOJWPUnhgyQiAncKMsJkhrKzmzA == null)
				{
					return 0uL;
				}
				long? systemId = FqOJWPUnhgyQiAncKMsJkhrKzmzA.systemId;
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
			: base(new STOXFeWabFkxmvzlZoIrrqpPpJvb(P_0, P_1, default(buajiwwNvsvnjCGMEWoTzaPnJCiy)))
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("xboxOneInputSource");
			}
			KcvzGSMjFFtkRqhsVzkFmnUyvwUi = new TimerAbs[4];
			ArrayTools.Populate(KcvzGSMjFFtkRqhsVzkFmnUyvwUi, 0, KcvzGSMjFFtkRqhsVzkFmnUyvwUi.Length);
		}

		private XboxOneGamepadExtension(XboxOneGamepadExtension P_0)
			: base(P_0)
		{
			KcvzGSMjFFtkRqhsVzkFmnUyvwUi = new TimerAbs[4];
			ArrayTools.Populate(KcvzGSMjFFtkRqhsVzkFmnUyvwUi, 0, KcvzGSMjFFtkRqhsVzkFmnUyvwUi.Length);
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
			if (!tvSPcCbqqfEJVLJwmEInnPLZMpyh.pQSQDdmkWLOfYumIsnmRDjiCFZhG)
			{
				return 0f;
			}
			return motorIndex switch
			{
				0 => tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.nkGBJlvyKZhoFpnZWQfPHualpOUh, 
				1 => tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.mWMDFmZETmIKjnpDjaSJhejRebQD, 
				2 => tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.yUaVmWdMhCVsKbfQAGaMOCioeCZx, 
				3 => tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.IvxJOwYmFiHKqkvRXNGcOlBmmONL, 
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
			if (!tvSPcCbqqfEJVLJwmEInnPLZMpyh.pQSQDdmkWLOfYumIsnmRDjiCFZhG)
			{
				return 0f;
			}
			return motor switch
			{
				XboxOneGamepadMotorType.LeftMotor => tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.nkGBJlvyKZhoFpnZWQfPHualpOUh, 
				XboxOneGamepadMotorType.RightMotor => tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.mWMDFmZETmIKjnpDjaSJhejRebQD, 
				XboxOneGamepadMotorType.LeftTriggerMotor => tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.yUaVmWdMhCVsKbfQAGaMOCioeCZx, 
				XboxOneGamepadMotorType.RightTriggerMotor => tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.IvxJOwYmFiHKqkvRXNGcOlBmmONL, 
				_ => throw new NotImplementedException(), 
			};
		}

		public void StopVibration()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (tvSPcCbqqfEJVLJwmEInnPLZMpyh.pQSQDdmkWLOfYumIsnmRDjiCFZhG)
			{
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.KZVecXJrVlsfVjKRzGvUfgEFdmViA();
				for (int i = 0; i < 4; i++)
				{
					KcvzGSMjFFtkRqhsVzkFmnUyvwUi[i].Clear();
				}
				DKBrxAwBckvhyvTJdiodcWYuSCSg();
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
				if (!tvSPcCbqqfEJVLJwmEInnPLZMpyh.pQSQDdmkWLOfYumIsnmRDjiCFZhG)
				{
					return;
				}
				if (stopOtherMotors)
				{
					tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.KZVecXJrVlsfVjKRzGvUfgEFdmViA();
					for (int i = 0; i < 4; i++)
					{
						KcvzGSMjFFtkRqhsVzkFmnUyvwUi[i].Clear();
					}
				}
				motorLevel = MathTools.Clamp01(motorLevel);
				switch (motor)
				{
				case XboxOneGamepadMotorType.LeftMotor:
					tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.nkGBJlvyKZhoFpnZWQfPHualpOUh = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightMotor:
					tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.mWMDFmZETmIKjnpDjaSJhejRebQD = motorLevel;
					break;
				case XboxOneGamepadMotorType.LeftTriggerMotor:
					tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.yUaVmWdMhCVsKbfQAGaMOCioeCZx = motorLevel;
					break;
				case XboxOneGamepadMotorType.RightTriggerMotor:
					tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.IvxJOwYmFiHKqkvRXNGcOlBmmONL = motorLevel;
					break;
				default:
					throw new NotImplementedException();
				}
				wlGQtRDwFPrlFyjISThQSdaFbOTw(motor, motorLevel, duration);
				DKBrxAwBckvhyvTJdiodcWYuSCSg();
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
				if (!tvSPcCbqqfEJVLJwmEInnPLZMpyh.pQSQDdmkWLOfYumIsnmRDjiCFZhG)
				{
					return;
				}
				if (stopOtherMotors)
				{
					tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.KZVecXJrVlsfVjKRzGvUfgEFdmViA();
					for (int i = 0; i < 4; i++)
					{
						KcvzGSMjFFtkRqhsVzkFmnUyvwUi[i].Clear();
					}
				}
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.SnfmOFbPDJHznhenxEpJMElQLIIFA = xboxOneJoystickId;
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.nkGBJlvyKZhoFpnZWQfPHualpOUh = MathTools.Clamp01(leftMotorLevel);
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.mWMDFmZETmIKjnpDjaSJhejRebQD = MathTools.Clamp01(rightMotorLevel);
				KcvzGSMjFFtkRqhsVzkFmnUyvwUi[0].Clear();
				KcvzGSMjFFtkRqhsVzkFmnUyvwUi[1].Clear();
				DKBrxAwBckvhyvTJdiodcWYuSCSg();
			}
		}

		public void SetVibration(float leftMotorLevel, float rightMotorLevel, float leftTriggerLevel, float rightTriggerLevel)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (tvSPcCbqqfEJVLJwmEInnPLZMpyh.pQSQDdmkWLOfYumIsnmRDjiCFZhG)
			{
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.SnfmOFbPDJHznhenxEpJMElQLIIFA = xboxOneJoystickId;
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.nkGBJlvyKZhoFpnZWQfPHualpOUh = MathTools.Clamp01(leftMotorLevel);
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.mWMDFmZETmIKjnpDjaSJhejRebQD = MathTools.Clamp01(rightMotorLevel);
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.yUaVmWdMhCVsKbfQAGaMOCioeCZx = MathTools.Clamp01(leftTriggerLevel);
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW.IvxJOwYmFiHKqkvRXNGcOlBmmONL = MathTools.Clamp01(rightTriggerLevel);
				for (int i = 0; i < 4; i++)
				{
					KcvzGSMjFFtkRqhsVzkFmnUyvwUi[i].Clear();
				}
				DKBrxAwBckvhyvTJdiodcWYuSCSg();
			}
		}

		public void PulseVibrateMotor(XboxOneGamepadMotorType motor, float startLevel, float endLevel, float duration)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
			}
			else if (base.isJoystickConnected && tvSPcCbqqfEJVLJwmEInnPLZMpyh.pQSQDdmkWLOfYumIsnmRDjiCFZhG)
			{
				wlGQtRDwFPrlFyjISThQSdaFbOTw(motor, 0f, 0f);
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.cYDgpiicsNiebhvOCRTLlgmdBdeHd.PulseVibrateMotor(xboxOneJoystickId, motor, startLevel, endLevel, duration);
			}
		}

		internal void QQZVSlFaMLDPmLsakVkgyTdojmoE(UpdateLoopType P_0)
		{
			NVgXOIpjrpNVKAQDTAXtKtaLFgidA();
		}

		internal void QGKPiofXEhAyISBkpeZEviRNCeOq(IControllerExtensionSource P_0)
		{
			tvSPcCbqqfEJVLJwmEInnPLZMpyh = P_0 as STOXFeWabFkxmvzlZoIrrqpPpJvb;
		}

		internal Controller.Extension xSpCjSihUEICTLAsWIvSCvshNnoGc()
		{
			return new XboxOneGamepadExtension(this);
		}

		private void NVgXOIpjrpNVKAQDTAXtKtaLFgidA()
		{
			if (!tvSPcCbqqfEJVLJwmEInnPLZMpyh.pQSQDdmkWLOfYumIsnmRDjiCFZhG)
			{
				return;
			}
			for (int i = 0; i < 4; i++)
			{
				if (KcvzGSMjFFtkRqhsVzkFmnUyvwUi[i].Update())
				{
					SetVibration(i, 0f, stopOtherMotors: false);
				}
			}
		}

		private void wlGQtRDwFPrlFyjISThQSdaFbOTw(XboxOneGamepadMotorType P_0, float P_1, float P_2)
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
				KcvzGSMjFFtkRqhsVzkFmnUyvwUi[num].Clear();
			}
			else
			{
				KcvzGSMjFFtkRqhsVzkFmnUyvwUi[num].Start(P_2);
			}
		}

		private void DKBrxAwBckvhyvTJdiodcWYuSCSg()
		{
			if (base.isJoystickConnected)
			{
				tvSPcCbqqfEJVLJwmEInnPLZMpyh.cYDgpiicsNiebhvOCRTLlgmdBdeHd.SetXboxOneVibration(xboxOneJoystickId, tvSPcCbqqfEJVLJwmEInnPLZMpyh.AXbkYRZRUihmELHFTGiBFaoIfSpW);
			}
		}
	}
}
