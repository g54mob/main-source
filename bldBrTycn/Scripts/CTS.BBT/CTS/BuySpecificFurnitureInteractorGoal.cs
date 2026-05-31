using CTS.BBT;
using CTS.Core;

namespace CTS
{
	public class BuySpecificFurnitureInteractorGoal<T> : QuestGoal where T : FurnitureInteractor
	{
		public BuySpecificFurnitureInteractorGoal(Quest quest, int entryID)
			: base(quest, entryID)
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
		}

		private void OnFurnitureBought(Furniture furniture)
		{
			if (furniture.Interactor is T)
			{
				SetGoalState(success: true);
			}
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			if (CTSSingleton<LevelParameters>.InstanceExists() && !CTSSingleton<LevelParameters>.Instance.Furnitures.IsAnyAvailable<T>())
			{
				SetGoalState(success: false);
			}
		}
	}
}
