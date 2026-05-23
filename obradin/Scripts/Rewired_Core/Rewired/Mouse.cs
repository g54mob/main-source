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
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Vector2.zero;
				}
				return _screenPosition;
			}
		}

		public Vector2 screenPositionPrev
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Vector2.zero;
				}
				return _screenPositionPrev;
			}
		}

		public Vector2 screenPositionDelta
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Vector2.zero;
				}
				return _screenPosition - _screenPositionPrev;
			}
		}

		public override Guid deviceInstanceGuid
		{
			get
			{
				if (ReInput._id != znFtIaPrJLvdjPGCwXFaaAeLKcr)
				{
					ReInput.CheckInitialized(znFtIaPrJLvdjPGCwXFaaAeLKcr);
					return Guid.Empty;
				}
				return s_deviceInstanceGuid;
			}
		}

		internal Mouse(string name, IUnifiedMouseSource source)
			: this(0, source.inputSource, name, InputTools.FormatHardwareIdentifierString(name), source.axisCount, source.buttonCount, source.hardwareMap, null, new ControllerDataUpdater(source.inputSource, source.axisCount, source.buttonCount, null))
		{
			_source = source;
			s_deviceInstanceGuid = MiscTools.CreateGuidHashSHA1("[Universal Mouse]");
			snpHjGkGVogejiySyWIFjoJWDLTS();
		}

		private Mouse(int controllerId, InputSource inputSource, string name, string hardwareIdentifier, int axisCount, int buttonCount, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, name, hardwareIdentifier, ControllerType.Mouse, Consts.hardwareTypeGuid_universalMouse, axisCount, buttonCount, null, hardwareMap, extension, dataUpdater)
		{
		}

		internal override void UpdateData(UpdateLoopType updateLoop)
		{
			_source.UpdateInputData(ybiZyKuVmvsrOHqZzdmfwidXkdm);
			while (true)
			{
				int num = 403621783;
				while (true)
				{
					switch (num ^ 0x180EC795)
					{
					case 0:
						break;
					case 2:
						goto IL_002f;
					default:
						RecordMouseScreenPosition();
						return;
					}
					break;
					IL_002f:
					base.UpdateData(updateLoop);
					num = 403621780;
				}
			}
		}

		protected override bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			if (cumulativeMousePollingAxes == null)
			{
				goto IL_0011;
			}
			goto IL_00ea;
			IL_0011:
			int num = -1214260963;
			goto IL_0016;
			IL_0016:
			float num3 = default(float);
			while (true)
			{
				switch (num ^ -1214260964)
				{
				case 5:
					break;
				case 9:
					return false;
				case 6:
					goto IL_006f;
				case 7:
					cumulativeMousePollingAxes[index] += axes[index].valueRaw;
					num = -1214260969;
					continue;
				case 8:
					cumulativeMousePollingAxes[index] += axes[index].valueRaw * 0.5f;
					num = -1214260969;
					continue;
				case 3:
					goto IL_00ea;
				case 11:
					goto IL_010c;
				case 0:
					goto IL_0126;
				case 1:
					cumulativeMousePollingAxes = new float[_axisCount];
					num = -1214260961;
					continue;
				case 4:
					if (ReInput.currentUpdateLoop != UpdateLoopType.OnGUI)
					{
						goto case 7;
					}
					goto IL_017a;
				case 10:
					goto IL_019a;
				default:
					return false;
				}
				break;
				IL_017a:
				int num2;
				if (ReInput.configVars.GetPlatformVar_useNativeMouse())
				{
					num = -1214260965;
					num2 = num;
				}
				else
				{
					num = -1214260972;
					num2 = num;
				}
				continue;
				IL_010c:
				num3 = cumulativeMousePollingAxes[index];
				if (index > 1)
				{
					if (MathTools.Abs(num3) <= 2f)
					{
						num = -1214260962;
						continue;
					}
					goto IL_01c5;
				}
				num = -1214260966;
				continue;
				IL_006f:
				if (MathTools.Abs(num3) <= 100f)
				{
					num = -1214260971;
					continue;
				}
				goto IL_01c5;
			}
			goto IL_0011;
			IL_01c5:
			pole = ((!(num3 >= 0f)) ? Pole.Negative : Pole.Positive);
			elementIdentifierId = RCNejcvnZtMAmgendVbiwgNYmdD.axisElementIdentifierIds[index];
			if (elementIdentifierId < 0)
			{
				return false;
			}
			mouseAxisPollingTimer.running = false;
			return true;
			IL_00ea:
			if (mouseAxisPollingTimer == null)
			{
				mouseAxisPollingTimer = new TimerAbs(1f);
				num = -1214260964;
				goto IL_0016;
			}
			goto IL_0126;
			IL_0126:
			if (!mouseAxisPollingTimer.Update())
			{
				int num4;
				if (mouseAxisPollingTimer.running)
				{
					num = -1214260968;
					num4 = num;
				}
				else
				{
					num = -1214260970;
					num4 = num;
				}
				goto IL_0016;
			}
			goto IL_019a;
			IL_019a:
			mouseAxisPollingTimer.Start();
			Array.Clear(cumulativeMousePollingAxes, 0, cumulativeMousePollingAxes.Length);
			num = -1214260968;
			goto IL_0016;
		}

		internal override void Clear()
		{
			base.Clear();
			while (true)
			{
				int num = -1960743046;
				while (true)
				{
					switch (num ^ -1960743045)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						if (mouseAxisPollingTimer != null)
						{
							mouseAxisPollingTimer.Clear();
							num = -1960743048;
							continue;
						}
						goto case 3;
					case 3:
						_screenPosition = Vector2.zero;
						_screenPositionPrev = Vector2.zero;
						num = -1960743045;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}

		internal override bool SetEnabled(bool state)
		{
			if (!base.SetEnabled(state))
			{
				return false;
			}
			if (state)
			{
				RecordMouseScreenPosition();
				_screenPositionPrev = screenPosition;
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
			_screenPositionPrev = _screenPosition;
			while (true)
			{
				int num = 248997772;
				while (true)
				{
					switch (num ^ 0xED7678D)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						_screenPosition = _source.mousePosition;
						num = 248997774;
						continue;
					case 3:
						_lastScreenPositionUpdateFrame = currentUnityFrame;
						num = 248997773;
						continue;
					case 0:
						return;
					}
					break;
				}
			}
		}
	}
}
