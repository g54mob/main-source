using Factory;
using UnityEngine;

namespace Motorways.Actions
{
	public class DoubleTapToggleDrawModeAction : MotorwaysPlayerAction
	{
		private const float MaxTimeBetweenTapsInSeconds = 0.5f;

		private const float NoMovementTimeAfterSecondTap = 0.1f;

		private const float MaxDistanceBetweenTaps = 0.2f;

		private const float MaxDistanceBetweenTapsSquared = 0.040000003f;

		private Vector2 _firstTapPosition = Vector2.zero;

		private float _firstTapTimestamp = float.MinValue;

		private Vector2 _secondTapPosition = Vector2.zero;

		private float _secondTapTimestamp = float.MinValue;

		public override bool IsInterruptible => true;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			_firstTapTimestamp = Time.time;
			_firstTapPosition = GetMoveFocusJoystickInputValue();
		}

		public override void OnActionComplete()
		{
			base.OnActionComplete();
			_gameUI.ToggleDrawMode();
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			Vector2 moveFocusJoystickInputValue = GetMoveFocusJoystickInputValue();
			if (_secondTapTimestamp <= float.MinValue)
			{
				if (moveFocusJoystickInputValue != Vector2.zero && !WithinRadius(moveFocusJoystickInputValue, _firstTapPosition, 0.040000003f))
				{
					OnActionCancel();
				}
				else if (Time.time - _firstTapTimestamp >= 0.5f)
				{
					OnActionCancel();
				}
			}
			else if (moveFocusJoystickInputValue == Vector2.zero)
			{
				OnActionComplete();
			}
			else if (Time.time - _secondTapTimestamp < 0.1f)
			{
				if (moveFocusJoystickInputValue != Vector2.zero && !WithinRadius(moveFocusJoystickInputValue, _secondTapPosition, 0.040000003f))
				{
					OnActionCancel();
				}
			}
			else
			{
				OnActionComplete();
			}
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			base.ObserveInput(timestamp, inputEvent, overUI);
			if (_secondTapTimestamp <= float.MinValue && Time.time - _firstTapTimestamp < 0.5f)
			{
				_secondTapTimestamp = Time.time;
				_secondTapPosition = GetMoveFocusJoystickInputValue();
			}
		}

		public override void Reset()
		{
			base.Reset();
			_firstTapPosition = Vector2.zero;
			_firstTapTimestamp = float.MinValue;
			_secondTapPosition = Vector2.zero;
			_secondTapTimestamp = float.MinValue;
		}

		private bool WithinRadius(Vector2 a, Vector2 b, float radiusSquared)
		{
			return (a - b).sqrMagnitude <= radiusSquared;
		}

		public static DoubleTapToggleDrawModeAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DoubleTapToggleDrawModeAction doubleTapToggleDrawModeAction = scope.Get<DoubleTapToggleDrawModeAction>();
			doubleTapToggleDrawModeAction.InitializeAction(owningGroup, timestamp);
			doubleTapToggleDrawModeAction.RegisterObserveInputEvent(InputEventFilter.CreateRemoteEventFilter(1, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			doubleTapToggleDrawModeAction.RegisterObserveInputEvent(InputEventFilter.CreateRemoteEventFilter(0, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			doubleTapToggleDrawModeAction.OnActionBegin(timestamp);
			return doubleTapToggleDrawModeAction;
		}
	}
}
