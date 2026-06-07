using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	public class PopupSliderInputFieldController : MonoBehaviour, IPopupSubmitHandler
	{
		public Popup popup;

		public SliderDV slider;

		public void HandleAction(PopupClosedByAction action)
		{
			switch (action)
			{
			case PopupClosedByAction.Positive:
				RequestPositive();
				break;
			case PopupClosedByAction.Negative:
				RequestNegative();
				break;
			case PopupClosedByAction.Abortion:
				RequestAbortion();
				break;
			default:
				Debug.LogError($"Unhandled action {action}", this);
				break;
			}
		}

		private void RequestPositive()
		{
			popup.RequestClose(PopupClosedByAction.Positive, slider.value.ToString());
		}

		private void RequestNegative()
		{
			popup.RequestClose(PopupClosedByAction.Negative, null);
		}

		private void RequestAbortion()
		{
			popup.RequestClose(PopupClosedByAction.Abortion, null);
		}
	}
}
