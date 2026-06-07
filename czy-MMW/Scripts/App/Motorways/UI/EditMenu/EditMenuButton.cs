using Motorways.Views;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways.UI.EditMenu
{
	public class EditMenuButton : TouchButton
	{
		public enum ButtonState
		{
			Disabled = 0,
			Hidden = 1,
			Normal = 2
		}

		public delegate void OnAssetButtonPressed(float pressTime, EditMenuButtonType type, int pointerIndex, IController onController);

		public delegate void OnFocusPointerEnter(EditMenuButton button);

		public delegate void OnFocusPointerExit(EditMenuButton button);

		private static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("EditMenuButton");

		private const string AnimatorDisabledFlag = "Disabled";

		private const string AnimatorHiddenFlag = "Hidden";

		private const string AnimatorNormalFlag = "Normal";

		private static readonly int Disabled = Animator.StringToHash("Disabled");

		private static readonly int Hidden = Animator.StringToHash("Hidden");

		private static readonly int Normal = Animator.StringToHash("Normal");

		public EditMenuButtonType ButtonType;

		public OnAssetButtonPressed onPressed;

		public Image IconImage;

		public OnFocusPointerEnter onPointerEnter;

		public OnFocusPointerExit onPointerExit;

		public void SetButtonToState(ButtonState buttonState)
		{
			switch (buttonState)
			{
			case ButtonState.Normal:
				base.interactable = true;
				base.animator.ResetTrigger(Hidden);
				base.animator.ResetTrigger(Disabled);
				base.animator.SetTrigger(Normal);
				break;
			case ButtonState.Disabled:
				base.interactable = false;
				base.animator.ResetTrigger(Hidden);
				base.animator.ResetTrigger(Normal);
				base.animator.SetTrigger(Disabled);
				break;
			case ButtonState.Hidden:
				base.interactable = false;
				base.animator.ResetTrigger(Normal);
				base.animator.ResetTrigger(Disabled);
				base.animator.SetTrigger(Hidden);
				break;
			default:
				Log.Error("Only button states normal, hidden or disabled are handled by SetButtonToState!");
				break;
			}
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			if (onPressed != null)
			{
				onPressed(eventData.clickTime, ButtonType, eventData.pointerId, null);
			}
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			if (onPointerEnter != null)
			{
				onPointerEnter(this);
			}
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			if (onPointerExit != null)
			{
				onPointerExit(this);
			}
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
				onPressed(-1f, ButtonType, -1, onController);
			}
		}
	}
}
