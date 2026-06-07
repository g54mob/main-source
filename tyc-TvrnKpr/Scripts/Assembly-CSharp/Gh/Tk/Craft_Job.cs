using System.Collections.Generic;

namespace Gh.Tk
{
	public abstract class Craft_Job : StaffJob, INeedsIngredients_Job
	{
		[PersistenceOptIn]
		[PersistenceObjectReference]
		protected Ingredient _craftedItem;

		[PersistenceOptIn]
		private List<string> _issues;

		[PersistenceOptIn]
		[PersistenceObjectReference]
		public virtual IngredientTemplate ItemTemplate { get; private set; }

		protected Craft_Job()
		{
		}

		public Craft_Job(GameObjectX source, IngredientTemplate gameItemTemplate)
		{
		}

		protected override bool EnableValidityCheck()
		{
			return false;
		}

		public virtual IEnumerable<string> GetIssues()
		{
			return null;
		}

		private string GetTextForInputIssue(string inputNameKey)
		{
			return null;
		}

		public void AddInputIssue(string inputNameKey)
		{
		}

		public void RemoveInputIssue(string inputNameKey)
		{
		}

		public void ClearInputIssues()
		{
		}

		protected override void OnAbortedInternal()
		{
		}

		public abstract IEnumerable<Tuple<GameItemTemplate, int>> GetNeededItemAmounts();

		public abstract bool IsCheckingInputsEnabled();
	}
}
