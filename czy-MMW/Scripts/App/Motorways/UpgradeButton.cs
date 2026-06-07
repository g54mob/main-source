using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways
{
	[RequireComponent(typeof(UpgradeButtonStack))]
	public class UpgradeButton : TouchButton, IPointerDownHandler, IEventSystemHandler
	{
		public delegate void OnAssetButtonPressed(float pressTime, GameUIButtonType type, int pointerIndex, IController onController);

		public GameUIButtonType buttonType;

		public OnAssetButtonPressed onPressed;

		private UpgradeButtonStack _stack;

		public UpgradeIcon _upgradeIcon;

		public ButtonAnimationState state;

		protected override bool OverrideSelectedState => false;

		protected override void Awake()
		{
			base.Awake();
			_stack = GetComponent<UpgradeButtonStack>();
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (_stack.AccountedIconNumber != 0 && onPressed != null)
			{
				onPressed(eventData.clickTime, buttonType, eventData.pointerId, null);
			}
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			OnPointerUp(eventData);
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			base.OnSubmit(eventData);
			if (onPressed != null)
			{
				IController onController = null;
				if (eventData is ControllerInputEventData controllerInputEventData)
				{
					onController = controllerInputEventData.instigatingController;
				}
				onPressed(-1f, buttonType, -1, onController);
			}
		}

		public void DoStateTransition(ButtonAnimationState state, bool instant)
		{
			this.state = state;
			DoStateTransition((SelectionState)state, instant);
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			if (buttonType == GameUIButtonType.None)
			{
				return;
			}
			if (IsInteractable())
			{
				if (base.DeviceInputType == DeviceInputType.Touch && state == SelectionState.Highlighted)
				{
					state = SelectionState.Normal;
				}
			}
			else
			{
				state = SelectionState.Normal;
			}
			_stack?.DoStateTransition((ButtonAnimationState)state, instant);
			base.DoStateTransition(state, instant);
		}
	}
}
