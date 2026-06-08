using System;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Utility;
using UnityEngine;

namespace Rewired
{
	public sealed class Mouse : ControllerWithAxes
	{
		private TimerAbs mouseAxisPollingTimer;

		private float[] cumulativeMousePollingAxes;

		private Vector2 _screenPosition;

		private Vector2 _screenPositionPrev;

		private int _lastScreenPositionUpdateFrame;

		private readonly IUnifiedMouseSource _source;

		private static Guid s_deviceInstanceGuid;

		public Vector2 screenPosition
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Vector2.zero;
				}
				return _screenPosition;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Vector2.zero;
				}
				return _screenPositionPrev;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Vector2.zero;
				}
				return _screenPosition - _screenPositionPrev;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return Guid.Empty;
				}
				return s_deviceInstanceGuid;
			}
		}

		internal Mouse(string name, IUnifiedMouseSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.axisCount, source.buttonCount, source.hardwareMap, source?.controllerExtension, new ControllerDataUpdater(source.inputSource, source.axisCount, source.buttonCount, null))
		{
			_source = source;
			s_deviceInstanceGuid = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			aNzXPWgGkyjIHrJsRxlIZSjJoXv();
		}

		private Mouse(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
		}

		internal void UpdateData(UpdateLoopType updateLoop)
		{
			_source.UpdateInputData(cMcAtEwaThLpgGZfIIRmVCJQjDU);
			while (true)
			{
				int num = -1581147128;
				while (true)
				{
					switch (num ^ -1581147127)
					{
					case 2:
						break;
					case 1:
						goto IL_002f;
					default:
						RecordMouseScreenPosition();
						return;
					}
					break;
					IL_002f:
					kckuoUXEwQcigNbCseRHnXueOkT(updateLoop);
					num = -1581147127;
				}
			}
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			float num3 = default(float);
			while (true)
			{
				int num = 811389276;
				while (true)
				{
					switch (num ^ 0x305CD158)
					{
					case 2:
						break;
					case 0:
						if (MathTools.Abs(num3) <= axes[index].effectivePollingDeadZone)
						{
							num = 811389277;
							continue;
						}
						pole = ((!(num3 >= 0f)) ? Pole.Negative : Pole.Positive);
						num = 811389265;
						continue;
					case 11:
						cumulativeMousePollingAxes = new float[_axisCount];
						num = 811389269;
						continue;
					case 6:
						if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI && !ReInput.configVars.GetPlatformVar_useNativeMouse())
						{
							cumulativeMousePollingAxes[index] += axes[index].valueRaw * 0.5f;
							num = 811389266;
							continue;
						}
						goto case 1;
					case 7:
						num3 = cumulativeMousePollingAxes[index];
						num = 811389272;
						continue;
					case 9:
						elementIdentifierId = REZiFujnwfIcWniRKvMxDxhPHlx.axisElementIdentifierIds[index];
						if (elementIdentifierId < 0)
						{
							num = 811389264;
							continue;
						}
						mouseAxisPollingTimer.running = false;
						return true;
					case 4:
					{
						elementIdentifierId = -1;
						int num4;
						if (cumulativeMousePollingAxes == null)
						{
							num = 811389267;
							num4 = num;
						}
						else
						{
							num = 811389269;
							num4 = num;
						}
						continue;
					}
					case 13:
						if (mouseAxisPollingTimer == null)
						{
							mouseAxisPollingTimer = new TimerAbs(1.0);
							num = 811389275;
							continue;
						}
						goto case 3;
					case 12:
						mouseAxisPollingTimer.Start();
						Array.Clear(cumulativeMousePollingAxes, 0, cumulativeMousePollingAxes.Length);
						num = 811389278;
						continue;
					case 1:
						cumulativeMousePollingAxes[index] += axes[index].valueRaw;
						num = 811389279;
						continue;
					case 5:
						return false;
					case 3:
						if (!mouseAxisPollingTimer.Update())
						{
							int num2;
							if (mouseAxisPollingTimer.running)
							{
								num = 811389278;
								num2 = num;
							}
							else
							{
								num = 811389268;
								num2 = num;
							}
							continue;
						}
						goto case 12;
					case 10:
						num = 811389279;
						continue;
					default:
						return false;
					}
					break;
				}
			}
		}

		internal void Clear()
		{
			tAgADqjTsMUxSqYXeDyJIdETYRAp();
			if (mouseAxisPollingTimer != null)
			{
				mouseAxisPollingTimer.Clear();
				goto IL_0019;
			}
			goto IL_0037;
			IL_0037:
			_screenPosition = Vector2.zero;
			_screenPositionPrev = Vector2.zero;
			int num = 690820575;
			goto IL_001e;
			IL_0019:
			num = 690820572;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x292D15DD)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0037;
			case 2:
				return;
			}
			goto IL_0019;
		}

		internal bool SetEnabled(bool state)
		{
			if (!base.wytyBiLPSMGfQbbdKPNlzybFrlR(state))
			{
				return false;
			}
			if (state)
			{
				RecordMouseScreenPosition();
				while (true)
				{
					int num = 1418053323;
					while (true)
					{
						switch (num ^ 0x5485C6CA)
						{
						case 0:
							break;
						case 1:
							_screenPositionPrev = screenPosition;
							num = 1418053320;
							continue;
						default:
							goto end_IL_0014;
						}
						break;
					}
					continue;
					end_IL_0014:
					break;
				}
			}
			return true;
		}

		private void RecordMouseScreenPosition()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame == _lastScreenPositionUpdateFrame)
			{
				return;
			}
			while (true)
			{
				int num = -1759124251;
				while (true)
				{
					switch (num ^ -1759124249)
					{
					case 0:
						break;
					default:
						return;
					case 2:
						goto IL_002d;
					case 1:
						return;
					}
					break;
					IL_002d:
					_screenPositionPrev = _screenPosition;
					_screenPosition = _source.mousePosition;
					_lastScreenPositionUpdateFrame = currentUnityFrame;
					num = -1759124250;
				}
			}
		}
	}
}
