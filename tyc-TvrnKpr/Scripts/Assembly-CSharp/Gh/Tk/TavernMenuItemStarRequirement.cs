using System;

namespace Gh.Tk
{
	public class TavernMenuItemStarRequirement : Requirement
	{
		private readonly string[] _itemCategories;

		private readonly int _minStarRating;

		private readonly int _amount;

		protected TavernMenuItemStarRequirement()
		{
		}

		public TavernMenuItemStarRequirement(string titleKey, string[] itemCategories, int minStarRating = -1, int amount = 1)
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
