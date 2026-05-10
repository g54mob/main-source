using System;
using System.Collections.Generic;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.BBT
{
	public sealed class StationDrink : WorkerFurnitureInteractor, IManageableFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		[Inject(false)]
		private Collider _selfCollider;

		private static NamedLayerMask _itemSlotMask = new NamedLayerMask("ItemSlot");

		public static readonly Func<StationDrink, RoomBuilding, int, bool> HasEnoughSlots = delegate(StationDrink station, RoomBuilding room, int count)
		{
			if (!station.ServeAllRooms && station.Furniture.RoomObject.CurrentRoom != room)
			{
				return false;
			}
			int num = 0;
			ItemSlot[] itemSlots = station.ItemSlots;
			for (int i = 0; i < itemSlots.Length; i++)
			{
				if (!itemSlots[i].InUse)
				{
					num++;
				}
				if (num >= count)
				{
					return true;
				}
			}
			return false;
		};

		[field: SerializeField]
		public Transform PumpSlot { get; private set; }

		[field: SerializeField]
		public UsableFurnituresCategoriesSO UsableFurnitureCategoryData { get; private set; }

		public bool ServeAllRooms { get; private set; } = true;

		[field: InjectScope(EGetScope.Children)]
		[field: Inject(false)]
		public ItemSlot[] ItemSlots { get; } = Array.Empty<ItemSlot>();

		public int SlotCount => ItemSlots.Length;

		public event Action ServeRoomChanged;

		public void SetServeAllRooms(bool serveAllRooms)
		{
			if (serveAllRooms != ServeAllRooms)
			{
				ServeAllRooms = serveAllRooms;
				this.ServeRoomChanged?.Invoke();
			}
		}

		protected override void OnFurnitureBecameUnavailable()
		{
			ItemSlot[] itemSlots = ItemSlots;
			for (int i = 0; i < itemSlots.Length; i++)
			{
				itemSlots[i].ClearSlot();
			}
			base.OnFurnitureBecameUnavailable();
		}

		public bool TryGetSlots(int count, List<ItemSlot> outSlots)
		{
			_ = outSlots.Count;
			outSlots.Clear();
			List<ItemSlot> list = new List<ItemSlot>(ItemSlots);
			ItemSlot itemSlot = null;
			while (list.Count > 0)
			{
				int randomIndex = list.GetRandomIndex();
				if (list[randomIndex].InUse)
				{
					list.RemoveAt(randomIndex);
					continue;
				}
				itemSlot = list[randomIndex];
				break;
			}
			if (!itemSlot)
			{
				return false;
			}
			itemSlot.SetUsed(null);
			outSlots.Add(itemSlot);
			Vector3 position = itemSlot.transform.position;
			bool flag = true;
			for (int i = 1; i < count; i++)
			{
				if (TryGetNearestFreeSlot(out var outSlot, position))
				{
					outSlot.SetUsed(null);
					outSlots.Add(outSlot);
					continue;
				}
				flag = false;
				break;
			}
			if (flag)
			{
				return true;
			}
			foreach (ItemSlot outSlot2 in outSlots)
			{
				outSlot2.SetUnused();
			}
			return false;
		}

		private bool TryGetNearestFreeSlot(out ItemSlot outSlot, Vector3 pos)
		{
			outSlot = null;
			float num = float.MaxValue;
			ItemSlot[] itemSlots = ItemSlots;
			foreach (ItemSlot itemSlot in itemSlots)
			{
				if (!itemSlot.InUse)
				{
					float sqrMagnitude = (itemSlot.transform.position - pos).sqrMagnitude;
					if (sqrMagnitude < num)
					{
						num = sqrMagnitude;
						outSlot = itemSlot;
					}
				}
			}
			return outSlot;
		}
	}
}
