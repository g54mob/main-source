using System.Collections.Generic;

namespace Gh.Tk
{
	public interface INeedsIngredients_Job
	{
		int Priority { get; set; }

		IngredientTemplate ItemTemplate { get; }

		GameObjectX Owner { get; set; }

		GameObjectX Target { get; }

		bool IsCheckingInputsEnabled();

		bool IsPaused();

		IEnumerable<Tuple<GameItemTemplate, int>> GetNeededItemAmounts();

		void SetOnHold(bool onHold);

		IEnumerable<string> GetIssues();

		void ClearInputIssues();

		void AddInputIssue(string inputNameKey);

		void RemoveInputIssue(string inputNameKey);

		bool CheckIsValid(bool forceRefresh = false);
	}
}
