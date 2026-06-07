using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class MealProviderInventoryItemUIElement : InventoryItemUIElement
	{
		private bool _isInPreparation;

		[SerializeField]
		private Transform _inPreparation;

		public void SetIsInPreparation(bool inPreparation)
		{
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}
	}
}
