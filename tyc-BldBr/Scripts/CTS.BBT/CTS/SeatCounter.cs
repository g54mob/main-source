using System;
using CTS.BBT;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(1)]
	public class SeatCounter : CTSSingleton<SeatCounter>
	{
		[SerializeField]
		private NavigationArea _workerOnlyArea;

		[SerializeField]
		private NavigationArea _vamprieArea;

		[SerializeField]
		private NavigationArea _everyoneArea;

		public int CurrentSeatCount => CurrentVampireSeatCount + CurrentWorkerOnlySeatCount + CurrentEveryoneSeatCount;

		public int CurrentValidForCustomersSeatCount => CurrentVampireSeatCount + CurrentEveryoneSeatCount;

		[field: ShowNonSerializedField]
		public int CurrentVampireSeatCount { get; private set; }

		[field: ShowNonSerializedField]
		public int CurrentWorkerOnlySeatCount { get; private set; }

		[field: ShowNonSerializedField]
		public int CurrentEveryoneSeatCount { get; private set; }

		[field: ShowNonSerializedField]
		public int CurrentUsedHumanSeatCount { get; private set; }

		[field: ShowNonSerializedField]
		public int CurrentUsedVampireSeatCount { get; private set; }

		public static event Action<int> SeatCountChanged;

		public static event Action<int, int> SeatOccupedCountChanged;

		protected override void SingletonAwake()
		{
			Furniture.FurniturePlaced += OnFurniturePlaced;
			Furniture.FurnitureSold += OnFurniturePlaced;
			FurnitureController.FurniturePickedUp += OnFurniturePickedUp;
			RoomAssingationMenu.OnRoomAssignationChanged += OnRoomAssignationChanged;
			Table.SeatCountChanged += OnTableSeatCountChanged;
		}

		protected override void OnSingletonDestroy()
		{
			Furniture.FurniturePlaced -= OnFurniturePlaced;
			Furniture.FurnitureSold -= OnFurniturePlaced;
			FurnitureController.FurniturePickedUp -= OnFurniturePickedUp;
			RoomAssingationMenu.OnRoomAssignationChanged -= OnRoomAssignationChanged;
			Table.SeatCountChanged -= OnTableSeatCountChanged;
		}

		private void OnTableSeatCountChanged()
		{
			Recalculate();
			SeatCounter.SeatOccupedCountChanged?.Invoke(CurrentUsedHumanSeatCount, CurrentUsedVampireSeatCount);
		}

		private void OnRoomAssignationChanged(RoomBuilding obj)
		{
			Recalculate();
		}

		private void OnFurniturePlaced(Furniture obj)
		{
			Recalculate();
		}

		private void OnFurniturePickedUp(FurnitureController obj)
		{
			Recalculate();
		}

		public void Recalculate()
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			if (CTSSingleton<LevelParameters>.InstanceExists())
			{
				foreach (Table item in CTSSingleton<LevelParameters>.Instance.Furnitures.Enumerate<Table>())
				{
					NavigationArea navArea = item.Furniture.RoomObject.CurrentRoom.NavArea;
					int seatCount = item.SeatCount;
					int usedSeatCount = item.UsedSeatCount;
					if (navArea == _workerOnlyArea)
					{
						num2 += seatCount;
					}
					else if (navArea == _vamprieArea)
					{
						num += seatCount;
						num5 += usedSeatCount;
					}
					else if (navArea == _everyoneArea)
					{
						num3 += seatCount;
						num4 += usedSeatCount;
					}
				}
			}
			if (CurrentVampireSeatCount != num || CurrentWorkerOnlySeatCount != num2 || CurrentEveryoneSeatCount != num3 || CurrentUsedHumanSeatCount != num4 || CurrentUsedVampireSeatCount != num5)
			{
				CurrentVampireSeatCount = num;
				CurrentWorkerOnlySeatCount = num2;
				CurrentEveryoneSeatCount = num3;
				CurrentUsedHumanSeatCount = num4;
				CurrentUsedVampireSeatCount = num5;
				SeatCounter.SeatCountChanged?.Invoke(CurrentSeatCount);
			}
		}
	}
}
