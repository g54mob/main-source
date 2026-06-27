using Restory.Data.Elements.Condition;
using Restory.Gameplay.Elements;
using Restory.UI.Presenters.Notepad;
using UnityEngine;

namespace Restory.Gameplay.Tooltips
{
	public class GUI_NotepadElementItemTooltipActivator : LocalizedTooltipActivator, ITooltipActivatorWithCondition
	{
		[SerializeField]
		private GUI_NotepadElementItem elementItem;

		[SerializeField]
		private string missedElementLocalizationKey;

		public bool ShouldTooltipBeShown()
		{
			if (elementItem.View.IsElementMissed)
			{
				tooltipLocalizationKey = missedElementLocalizationKey;
				return true;
			}
			ElementData elementData = elementItem.ElementData;
			if (elementData == null || !elementData.IsInspected)
			{
				return false;
			}
			tooltipLocalizationKey = elementItem.ElementData.Condition.NameLocalizationKey;
			return !(elementItem.ElementData.Condition is PerfectElementCondition);
		}
	}
}
