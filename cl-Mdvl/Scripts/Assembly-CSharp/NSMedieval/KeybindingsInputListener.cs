using NSEipix.Base;
using NSMedieval.Components;
using NSMedieval.Manager;
using UnityEngine;

namespace NSMedieval
{
	public sealed class KeybindingsInputListener : InputListener
	{
		private float keyDownIntervalIgnoreTime = 0.4f;

		private float keyDownIntervalIgnorePassedTime;

		private float keyDownInterval = 0.03f;

		private float keyDownTimePassed;

		public KeybindingsInputListener()
			: base(InputListenerType.Keybinding)
		{
		}

		public override void KeyDown(KeyCode key)
		{
			MonoSingleton<KeybindingManager>.Instance.ExecuteKeybindingEvent(key);
			base.KeyDown(key);
		}

		public override void KeyDownTick(KeyCode key)
		{
			if (keyDownIntervalIgnorePassedTime < keyDownIntervalIgnoreTime)
			{
				keyDownIntervalIgnorePassedTime += Time.unscaledDeltaTime;
				return;
			}
			keyDownTimePassed += Time.unscaledDeltaTime;
			if (keyDownTimePassed >= keyDownInterval)
			{
				keyDownTimePassed = 0f;
				MonoSingleton<KeybindingManager>.Instance.ExecuteKeybindingIntervalEvent(key);
			}
			base.KeyDownTick(key);
		}

		public override void KeyUp(KeyCode key)
		{
			keyDownIntervalIgnorePassedTime = 0f;
			MonoSingleton<KeybindingManager>.Instance.ExecuteKeybindingUpEvent(key);
			base.KeyUp(key);
		}

		public override void MouseButtonDown(int button, Vector3 position)
		{
			if (button <= 2)
			{
				KeyCode keyCode = ((button == 0) ? KeyCode.Mouse0 : KeyCode.Mouse1);
				keyCode = ((button == 2) ? KeyCode.Mouse2 : keyCode);
				MonoSingleton<KeybindingManager>.Instance.ExecuteKeybindingEvent(keyCode);
				base.MouseButtonDown(button, position);
			}
		}
	}
}
