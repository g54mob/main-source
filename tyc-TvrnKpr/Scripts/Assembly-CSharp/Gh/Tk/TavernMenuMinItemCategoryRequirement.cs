using System;

namespace Gh.Tk
{
	public class TavernMenuMinItemCategoryRequirement : Requirement
	{
		private readonly int _minAmount;

		private readonly string _itemCategory;

		protected TavernMenuMinItemCategoryRequirement()
		{
		}

		public TavernMenuMinItemCategoryRequirement(string titleKey, string itemCategory, int minAmount)
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
