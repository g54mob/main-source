using DV.HUD;
using DV.Interaction.Inputs;
using DV.RailDriver;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class MouseScrollKeyboardInput : AKeyboardInput
	{
		private enum MouseScrollStates
		{
			NotPressed = 0,
			HoldingNoAction = 1,
			HoldingPeriodicalTap = 2
		}

		private struct MouseScrollStateData
		{
			public MouseScrollStates state;

			public float stateTimer;

			public float scrollReleaseTimer;
		}

		public const float TAP_PERIOD_MOUSE_SCROLL = 0.125f;

		private const float NO_ACTION_HOLD_PERIOD_MOUSE_SCROLL = 0.25f;

		private const float SCROLL_SPEED_UP_MULTIPLIER = 2f;

		public ActionReference scrollAction;

		public bool onlyScrollOnce;

		private MouseScrollStateData stateData;

		private bool _isScrollingInProgress;

		public bool IsScrollingInProgress => _isScrollingInProgress;

		public override bool FixedUpdateTick => false;

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			scrollAction.Initialize(interiorControlsManager);
		}

		private void Scroll(IScrollable scrollable, ScrollAction action)
		{
			scrollable?.Scroll(action);
			RailDriverDisplayDV.DisplayNotification((action == ScrollAction.ScrollUp) ? DV.RailDriver.RailDriver.DisplayBuffer.UP : DV.RailDriver.RailDriver.DisplayBuffer.DN);
		}

		public override void Tick(float deltaTime)
		{
			bool flag = InputManager.NewPlayer.GetButton(scrollAction.id);
			bool flag2 = InputManager.NewPlayer.GetNegativeButton(scrollAction.id);
			if (scrollAction.flip)
			{
				bool num = flag2;
				bool flag3 = flag;
				flag = num;
				flag2 = flag3;
			}
			if ((flag2 || flag) && PlayerCanReach())
			{
				_isScrollingInProgress = true;
				bool button = InputManager.NewPlayer.GetButton(InputManager.Actions.Run);
				switch (stateData.state)
				{
				case MouseScrollStates.NotPressed:
				{
					IScrollable component3 = base.gameObject.GetComponent<IScrollable>();
					Scroll(component3, flag ? ScrollAction.ScrollUp : ScrollAction.ScrollDown);
					stateData.stateTimer = (onlyScrollOnce ? float.MaxValue : 0.25f);
					stateData.state = MouseScrollStates.HoldingNoAction;
					break;
				}
				case MouseScrollStates.HoldingNoAction:
					if (button)
					{
						deltaTime *= 2f;
					}
					stateData.stateTimer -= deltaTime;
					if (stateData.stateTimer <= 0f)
					{
						IScrollable component2 = base.gameObject.GetComponent<IScrollable>();
						Scroll(component2, flag ? ScrollAction.ScrollUp : ScrollAction.ScrollDown);
						stateData.stateTimer = 0.125f;
						stateData.state = MouseScrollStates.HoldingPeriodicalTap;
					}
					break;
				case MouseScrollStates.HoldingPeriodicalTap:
					if (button)
					{
						deltaTime *= 2f;
					}
					stateData.stateTimer -= deltaTime;
					if (stateData.stateTimer <= 0f)
					{
						IScrollable component = base.gameObject.GetComponent<IScrollable>();
						Scroll(component, flag ? ScrollAction.ScrollUp : ScrollAction.ScrollDown);
						stateData.stateTimer = 0.125f;
					}
					break;
				default:
					Debug.LogError(string.Format("Unexpected state: Unhandled {0}: {1}", "MouseScrollStates", stateData.state));
					break;
				}
				stateData.scrollReleaseTimer = 0f;
				return;
			}
			if (stateData.state != MouseScrollStates.NotPressed)
			{
				stateData.scrollReleaseTimer = 0.3f;
				stateData.state = MouseScrollStates.NotPressed;
				return;
			}
			float scrollReleaseTimer = stateData.scrollReleaseTimer;
			if (scrollReleaseTimer > 0f)
			{
				scrollReleaseTimer -= deltaTime;
				if (scrollReleaseTimer <= 0f)
				{
					base.gameObject.GetComponent<IScrollable>()?.Scroll(ScrollAction.Release);
					_isScrollingInProgress = false;
				}
				stateData.scrollReleaseTimer = scrollReleaseTimer;
			}
		}
	}
}
