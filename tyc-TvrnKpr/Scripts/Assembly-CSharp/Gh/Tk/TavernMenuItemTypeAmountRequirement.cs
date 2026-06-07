using System;

namespace Gh.Tk
{
	public class TavernMenuItemTypeAmountRequirement : Requirement
	{
		private readonly string _itemCategory;

		private readonly int _amount;

		protected TavernMenuItemTypeAmountRequirement()
		{
		}

		public TavernMenuItemTypeAmountRequirement(string titleKey, string itemCategory, int amount)
		{
		}

		private void OnTavernMenuChanged(object sender, EventArgs e)
		{
		}

		protected override void CheckIfDoneInternal()
		{
		}

		protected override void AttachListeners()
		{
		}

		protected override void DetachListeners()
		{
		}
	}
}
