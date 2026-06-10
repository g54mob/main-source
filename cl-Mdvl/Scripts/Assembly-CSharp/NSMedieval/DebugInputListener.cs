using NSEipix.Base;
using NSMedieval.Components;
using NSMedieval.DevConsole;
using NSMedieval.State.Timers;
using UnityEngine;

namespace NSMedieval
{
	public class DebugInputListener : InputListener
	{
		private UnscaledTimer unscaledTimer;

		public DebugInputListener()
			: base(InputListenerType.Debug)
		{
			unscaledTimer = new UnscaledTimer(0.5f);
			unscaledTimer.SetRestartOnEnd(value: true);
			unscaledTimer.AddCallback(MonoSingleton<DebugInputController>.Instance.Tick);
		}

		public override void Dispose()
		{
			base.Dispose();
			unscaledTimer?.Dispose();
			unscaledTimer = null;
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			if (button == 1)
			{
				MonoSingleton<DebugInputController>.Instance.RightMouseDown();
			}
			else
			{
				MonoSingleton<DebugInputController>.Instance.MouseDown();
			}
			base.MouseButtonDown(button, position);
		}

		public override void MouseButtonUp(int button, Vector3 position)
		{
			if (button != 1)
			{
				MonoSingleton<DebugInputController>.Instance.MouseUp();
			}
			base.MouseButtonUp(button, position);
		}

		public override bool IsStopEventPropagation()
		{
			return MonoSingleton<DeveloperConsoleController>.Instance.MouseInputBlocked;
		}
	}
}
