using Factory;
using Motorways.Models;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Motorways.Views
{
	public class MotorwayHandleView : BaseMotorwayHandleView, IPointerDownHandler, IEventSystemHandler, ISubmitHandler
	{
		private MotorwayView _owningMotorway;

		private IScope _scope;

		private ClockModel _clockModel;

		private PlayerActionController _playerActionController;

		public void Initialize(IScope scope, MotorwayView owningMotorway, int motorwayNumber)
		{
			base.Initialize(scope, motorwayNumber);
			_owningMotorway = owningMotorway;
			_scope = scope;
			if (Diagnostics.Verify(_scope != null, "Scope invalid on MotorwayHandleView::Initialize"))
			{
				_playerActionController = _scope.Get<PlayerActionController>();
				_clockModel = _scope.Get<ClockModel>();
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			InputEvent inputEvent = ((eventData.pointerId >= 0) ? MotorwaysUIInputEvent.CreateTouchUIEvent(_scope, eventData.pointerId, InputEventButtonState.JustDown, GameUIButtonType.MotorwayHandle, _owningMotorway.Motorway.Id) : MotorwaysUIInputEvent.CreateMouseUIEvent(_scope, (InputEventMouseButtonType)(-eventData.pointerId - 1), InputEventButtonState.JustDown, GameUIButtonType.MotorwayHandle, _owningMotorway.Motorway.Id));
			_playerActionController.OnInputEvent(eventData.clickTime, inputEvent);
		}

		public void OnSubmit(BaseEventData eventData)
		{
			if (eventData is ControllerInputEventData { instigatingController: var instigatingController })
			{
				InputEvent inputEvent = MotorwaysUIInputEvent.CreateGenericUIEvent(_scope, 2, instigatingController.GetInputSource(), InputEventButtonState.JustDown, GameUIButtonType.MotorwayHandle, _owningMotorway.Motorway.Id);
				float timestamp = (float)_clockModel.Time;
				_playerActionController.OnInputEvent(timestamp, inputEvent);
			}
		}

		public void SetHandlePosition(Vector3 position)
		{
			base.transform.position = position;
			if (FeatureToggle.IsFeatureDisabled(Feature.BringMotorwaysToTopWhenEdited) && _owningMotorway != null)
			{
				_owningMotorway.Tilemap.ResortMotorwaysOnNextTick();
			}
		}
	}
}
