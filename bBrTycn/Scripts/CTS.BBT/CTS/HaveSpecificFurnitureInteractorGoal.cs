using CTS.BBT;
using CTS.Core;

namespace CTS
{
	public class HaveSpecificFurnitureInteractorGoal<T> : QuestNumericGoal where T : class, IInteractiveFurniture
	{
		public HaveSpecificFurnitureInteractorGoal(Quest quest, int entryID, string variableName, string targetVariableName)
			: base(quest, entryID, variableName, targetVariableName)
		{
		}

		public override void StopObserving()
		{
			Furniture.FurnitureBought -= OnFurnitureBought;
			Furniture.FurnitureSold -= OnFurnitureSold;
		}

		public override void StartObserving()
		{
			Furniture.FurnitureBought += OnFurnitureBought;
			Furniture.FurnitureSold += OnFurnitureSold;
			UpdateGoalVariable();
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			if (!IsGoalSucceedeed && furniture.Interactor is T)
			{
				UpdateGoalVariable();
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (furniture.Interactor is T)
			{
				UpdateGoalVariable();
			}
		}

		private void UpdateGoalVariable()
		{
			if (CTSSingleton<LevelParameters>.InstanceExists())
			{
				SetGoalVariable(CTSSingleton<LevelParameters>.Instance.Furnitures.GetCount<T>());
			}
		}
	}
}
