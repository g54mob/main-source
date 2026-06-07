using System.Collections.Generic;

namespace Gh.Tk
{
	public abstract class CraftIngredient_Job : Craft_Job
	{
		private bool _cleanedUp;

		protected CraftIngredient_Job()
		{
		}

		public CraftIngredient_Job(GameObjectX source, IngredientTemplate template)
		{
		}

		protected override bool CheckIsValidInternal()
		{
			return false;
		}

		public override IEnumerable<string> GetIssues()
		{
			return null;
		}

		public override IEnumerable<Tuple<GameItemTemplate, int>> GetNeededItemAmounts()
		{
			return null;
		}

		protected override void OnCleanupInternal()
		{
		}

		private void ClearTargetInventory()
		{
		}

		protected override void OnAbortedInternal()
		{
		}
	}
}
