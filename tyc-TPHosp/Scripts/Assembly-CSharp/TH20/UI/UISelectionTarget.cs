#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20.UI
{
	public class UISelectionTarget : Selectable
	{
		public Action<BaseEventData> OnSelected;

		public Action<BaseEventData> OnDeselected;

		public override void OnSelect(BaseEventData eventData)
		{
			base.OnSelect(eventData);
			Logging.Info("SELECTED UISelectionTarget");
			OnSelected.InvokeSafe(eventData);
		}

		public override void OnDeselect(BaseEventData eventData)
		{
			base.OnDeselect(eventData);
			Logging.Info("DESELECTED UISelectionTarget");
			OnDeselected.InvokeSafe(eventData);
		}
	}
}
