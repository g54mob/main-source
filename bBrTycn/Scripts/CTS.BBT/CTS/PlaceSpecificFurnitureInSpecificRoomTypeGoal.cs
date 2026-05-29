using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;

namespace CTS
{
	public class PlaceSpecificFurnitureInSpecificRoomTypeGoal<T> : BaseSpecificRoomTypeNumericalGoal where T : FurnitureInteractor
	{
		private List<Furniture> _furnitures = new List<Furniture>();

		public PlaceSpecificFurnitureInSpecificRoomTypeGoal(Quest quest, int entryID, string variableName, string targetVariableName, params NavigationArea[] navigationAreas)
			: base(quest, entryID, variableName, targetVariableName, navigationAreas)
		{
		}

		public override void StopObserving()
		{
			Furniture.FurniturePlaced -= OnFurniturePlaced;
			Furniture.FurnitureSold -= OnFurnitureSold;
		}

		public override void StartObserving()
		{
			foreach (T item in CTSSingleton<LevelParameters>.Instance.Furnitures.Enumerate<T>())
			{
				CheckFurniture(item.Furniture);
			}
			UpdateVariable();
			Furniture.FurniturePlaced += OnFurniturePlaced;
			Furniture.FurnitureSold += OnFurnitureSold;
		}

		private void OnFurnitureSold(Furniture furniture)
		{
			_furnitures.Remove(furniture);
			UpdateVariable();
		}

		private void OnFurniturePlaced(Furniture furniture)
		{
			CheckFurniture(furniture);
			UpdateVariable();
		}

		private void CheckFurniture(Furniture furniture)
		{
			if (furniture.Interactor is T)
			{
				if (!base.RoomTypes.Contains(furniture.RoomObject.CurrentRoom.NavArea))
				{
					_furnitures.Remove(furniture);
				}
				else if (!_furnitures.Contains(furniture))
				{
					_furnitures.Add(furniture);
				}
			}
		}

		private void UpdateVariable()
		{
			SetGoalVariable(_furnitures.Count);
		}
	}
}
