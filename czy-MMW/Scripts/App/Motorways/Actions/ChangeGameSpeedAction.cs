using Factory;
using Motorways.Audio;
using Motorways.Views;

namespace Motorways.Actions
{
	public class ChangeGameSpeedAction : MotorwaysPlayerAction
	{
		private GameUIScreen.TimeScaleMode _mode;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			if (Diagnostics.Verify(_gameUI != null, "GameUI is null on ChangeGameSpeedAction"))
			{
				switch (_mode)
				{
				case GameUIScreen.TimeScaleMode.Paused:
					_gameUI.OnPausePressed();
					AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Click, UIAudioProfile.Pause, -1f, condition: false));
					break;
				case GameUIScreen.TimeScaleMode.Play:
					_gameUI.OnPlayPressed();
					AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Click, UIAudioProfile.Play, -1f, condition: false));
					break;
				case GameUIScreen.TimeScaleMode.FastForward:
					_gameUI.OnFastForwardPressed();
					AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Click, UIAudioProfile.FastForward, -1f, condition: false));
					break;
				case GameUIScreen.TimeScaleMode.ExtraFastForward:
					_gameUI.OnExtraFastForwardPressed();
					AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Click, UIAudioProfile.FastForward, -1f, condition: false));
					break;
				}
			}
		}

		public override void Tick(float frameTime)
		{
			OnActionComplete();
		}

		public override void Reset()
		{
			base.Reset();
			_mode = GameUIScreen.TimeScaleMode.Paused;
		}

		public static ChangeGameSpeedAction CreateSpeedUp(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ChangeGameSpeedAction changeGameSpeedAction = Create(owningGroup, scope, timestamp);
			GameUIScreen.TimeScaleMode timeScaleMode = changeGameSpeedAction._gameUI.GetTimeScaleMode();
			changeGameSpeedAction._mode = timeScaleMode switch
			{
				GameUIScreen.TimeScaleMode.Paused => GameUIScreen.TimeScaleMode.Play, 
				GameUIScreen.TimeScaleMode.Play => GameUIScreen.TimeScaleMode.FastForward, 
				GameUIScreen.TimeScaleMode.FastForward => (!FeatureToggle.IsFeatureEnabled(Feature.ExtraFastForward)) ? timeScaleMode : GameUIScreen.TimeScaleMode.ExtraFastForward, 
				_ => timeScaleMode, 
			};
			changeGameSpeedAction.OnActionBegin(timestamp);
			return changeGameSpeedAction;
		}

		public static ChangeGameSpeedAction CreateSlowDown(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ChangeGameSpeedAction changeGameSpeedAction = Create(owningGroup, scope, timestamp);
			GameUIScreen.TimeScaleMode timeScaleMode = changeGameSpeedAction._gameUI.GetTimeScaleMode();
			changeGameSpeedAction._mode = timeScaleMode switch
			{
				GameUIScreen.TimeScaleMode.Play => GameUIScreen.TimeScaleMode.Paused, 
				GameUIScreen.TimeScaleMode.FastForward => GameUIScreen.TimeScaleMode.Play, 
				GameUIScreen.TimeScaleMode.ExtraFastForward => GameUIScreen.TimeScaleMode.FastForward, 
				_ => timeScaleMode, 
			};
			changeGameSpeedAction.OnActionBegin(timestamp);
			return changeGameSpeedAction;
		}

		public static ChangeGameSpeedAction CreateToggleSpeed(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ChangeGameSpeedAction changeGameSpeedAction = Create(owningGroup, scope, timestamp);
			GameUIScreen.TimeScaleMode mode = ((changeGameSpeedAction._gameUI.GetTimeScaleMode() == GameUIScreen.TimeScaleMode.Paused) ? changeGameSpeedAction._gameUI.GetUnpausedTimeScaleMode() : GameUIScreen.TimeScaleMode.Paused);
			changeGameSpeedAction._mode = mode;
			changeGameSpeedAction.OnActionBegin(timestamp);
			return changeGameSpeedAction;
		}

		public static ChangeGameSpeedAction CreatePauseSpeed(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ChangeGameSpeedAction changeGameSpeedAction = Create(owningGroup, scope, timestamp);
			changeGameSpeedAction._mode = GameUIScreen.TimeScaleMode.Paused;
			changeGameSpeedAction.OnActionBegin(timestamp);
			return changeGameSpeedAction;
		}

		public static ChangeGameSpeedAction CreatePlaySpeed(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ChangeGameSpeedAction changeGameSpeedAction = Create(owningGroup, scope, timestamp);
			changeGameSpeedAction._mode = GameUIScreen.TimeScaleMode.Play;
			changeGameSpeedAction.OnActionBegin(timestamp);
			return changeGameSpeedAction;
		}

		public static ChangeGameSpeedAction CreateFastForwardSpeed(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ChangeGameSpeedAction changeGameSpeedAction = Create(owningGroup, scope, timestamp);
			changeGameSpeedAction._mode = GameUIScreen.TimeScaleMode.FastForward;
			changeGameSpeedAction.OnActionBegin(timestamp);
			return changeGameSpeedAction;
		}

		public static ChangeGameSpeedAction CreateExtraFastForwardSpeed(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ChangeGameSpeedAction changeGameSpeedAction = Create(owningGroup, scope, timestamp);
			changeGameSpeedAction._mode = GameUIScreen.TimeScaleMode.ExtraFastForward;
			changeGameSpeedAction.OnActionBegin(timestamp);
			return changeGameSpeedAction;
		}

		private static ChangeGameSpeedAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ChangeGameSpeedAction changeGameSpeedAction = scope.Get<ChangeGameSpeedAction>();
			changeGameSpeedAction.InitializeAction(owningGroup, timestamp);
			return changeGameSpeedAction;
		}
	}
}
