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
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Vector2.zero;
				}
				return _screenPosition;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Vector2.zero;
				}
				return _screenPositionPrev;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Vector2.zero;
				}
				return _screenPosition - _screenPositionPrev;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					while (true)
					{
						int num = 872541662;
						while (true)
						{
							switch (num ^ 0x3401EDDF)
							{
							case 2:
								break;
							case 1:
								goto IL_002b;
							default:
								return Guid.Empty;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 872541663;
						}
					}
				}
				return s_deviceInstanceGuid;
			}
		}

		internal Mouse(string name, IUnifiedMouseSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.axisCount, source.buttonCount, source.hardwareMap, null, new ControllerDataUpdater(source.inputSource, source.axisCount, source.buttonCount, null))
		{
			while (true)
			{
				int num = 158415379;
				while (true)
				{
					switch (num ^ 0x9713A10)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						_source = source;
						s_deviceInstanceGuid = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
						num = 158415378;
						continue;
					case 2:
						DRbMoDMaPuHTEfQNWMCHwDDCfEIB();
						num = 158415377;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		private Mouse(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			_source.UpdateInputData(ROoGdHjYclVKlAjCTYtzRRhBjqvj);
			base.UpdateData(updateLoop);
			RecordMouseScreenPosition();
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			float num2 = default(float);
			while (true)
			{
				int num = 925247177;
				while (true)
				{
					switch (num ^ 0x372626C3)
					{
					case 6:
						break;
					case 15:
						mouseAxisPollingTimer.Start();
						num = 925247183;
						continue;
					case 1:
					{
						int num3;
						if (cumulativeMousePollingAxes == null)
						{
							num = 925247168;
							num3 = num;
						}
						else
						{
							num = 925247171;
							num3 = num;
						}
						continue;
					}
					case 5:
						cumulativeMousePollingAxes[index] += axes[index].valueRaw * 0.5f;
						num = 925247169;
						continue;
					case 14:
						if (ReInput.currentUpdateLoop == UpdateLoopType.OnGUI)
						{
							int num4;
							if (ReInput.configVars.GetPlatformVar_useNativeMouse())
							{
								num = 925247176;
								num4 = num;
							}
							else
							{
								num = 925247174;
								num4 = num;
							}
							continue;
						}
						goto case 11;
					case 12:
						Array.Clear(cumulativeMousePollingAxes, 0, cumulativeMousePollingAxes.Length);
						num = 925247181;
						continue;
					case 13:
						if (index <= 1)
						{
							if (MathTools.Abs(num2) <= 100f)
							{
								return false;
							}
						}
						else if (MathTools.Abs(num2) <= 2f)
						{
							return false;
						}
						pole = ((!(num2 >= 0f)) ? Pole.Negative : Pole.Positive);
						num = 925247172;
						continue;
					case 0:
						if (mouseAxisPollingTimer == null)
						{
							mouseAxisPollingTimer = new TimerAbs(1f);
							num = 925247178;
							continue;
						}
						goto case 9;
					case 10:
						elementIdentifierId = -1;
						num = 925247170;
						continue;
					case 7:
						elementIdentifierId = kABaypBwJpdJPQfaNrcsDzJUopW.axisElementIdentifierIds[index];
						num = 925247179;
						continue;
					case 8:
						if (elementIdentifierId < 0)
						{
							return false;
						}
						mouseAxisPollingTimer.running = false;
						num = 925247175;
						continue;
					case 2:
						num2 = cumulativeMousePollingAxes[index];
						num = 925247182;
						continue;
					case 3:
						cumulativeMousePollingAxes = new float[_axisCount];
						num = 925247171;
						continue;
					case 9:
						if (!mouseAxisPollingTimer.Update())
						{
							int num5;
							if (mouseAxisPollingTimer.running)
							{
								num = 925247181;
								num5 = num;
							}
							else
							{
								num = 925247180;
								num5 = num;
							}
							continue;
						}
						goto case 15;
					case 11:
						cumulativeMousePollingAxes[index] += axes[index].valueRaw;
						num = 925247169;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		internal override void Clear()
		{
			base.Clear();
			if (mouseAxisPollingTimer != null)
			{
				while (true)
				{
					int num = -61240719;
					while (true)
					{
						switch (num ^ -61240720)
						{
						case 2:
							break;
						case 1:
							mouseAxisPollingTimer.Clear();
							num = -61240720;
							continue;
						default:
							goto end_IL_000e;
						}
						break;
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			_screenPosition = Vector2.zero;
			_screenPositionPrev = Vector2.zero;
		}

		internal override bool SetEnabled(bool state)
		{
			if (!base.SetEnabled(state))
			{
				return false;
			}
			if (state)
			{
				while (true)
				{
					int num = 1221967611;
					while (true)
					{
						switch (num ^ 0x48D5BEF9)
						{
						case 0:
							break;
						case 2:
							RecordMouseScreenPosition();
							_screenPositionPrev = screenPosition;
							num = 1221967608;
							continue;
						default:
							goto end_IL_000e;
						}
						break;
					}
					continue;
					end_IL_000e:
					break;
				}
			}
			return true;
		}

		private void RecordMouseScreenPosition()
		{
			int currentUnityFrame = ReInput.currentUnityFrame;
			if (currentUnityFrame != _lastScreenPositionUpdateFrame)
			{
				_screenPositionPrev = _screenPosition;
				_screenPosition = _source.mousePosition;
				_lastScreenPositionUpdateFrame = currentUnityFrame;
			}
		}
	}
}
