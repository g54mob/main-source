using System;
using System.Collections.Generic;

namespace TH20
{
	public class ReceptionManager : MustCallDestroy
	{
		public const string CheckInInteraction = "CheckIn";

		private readonly Level _level;

		private readonly List<RoomItem> _items = new List<RoomItem>();

		public List<RoomItem> Items => _items;

		public ReceptionManager(Level level)
		{
			_level = level;
			RegisterEvents();
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents4.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			BuildEvents buildEvents3 = _level.BuildEvents;
			buildEvents3.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents3.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents4 = _level.BuildEvents;
			buildEvents4.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents4.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			base.Destroy();
		}

		private static bool IsReception(RoomItem item)
		{
			return item.HasInterationWithName("CheckIn");
		}

		public void OnRoomBuiltEvent(Room room, int cost)
		{
			if (room.Definition._type != RoomDefinition.Type.Reception)
			{
				return;
			}
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				if (IsReception(item))
				{
					_items.AddUnique(item);
				}
			}
		}

		private void OnRoomDeleted(Room room)
		{
			if (room.Definition._type != RoomDefinition.Type.Reception)
			{
				return;
			}
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				if (IsReception(item))
				{
					_items.Remove(item);
				}
			}
		}

		public void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (IsReception(roomItem))
			{
				_items.AddUnique(roomItem);
			}
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			_items.Remove(roomItem);
		}

		public bool GetBestReception(Character character, out ObjectInteraction bestItem)
		{
			float num = float.MaxValue;
			bestItem = null;
			foreach (RoomItem item in _items)
			{
				if (item.IsFunctional())
				{
					float bestScore;
					ObjectInteraction bestInteractionByName = InteractionAlgorithms.GetBestInteractionByName(item, "CheckIn", character, out bestScore, evalAttractiveness: false, null);
					if (bestScore < num)
					{
						bestItem = bestInteractionByName;
						num = bestScore;
					}
				}
			}
			if (bestItem == null)
			{
				num = float.MaxValue;
				foreach (RoomItem item2 in _items)
				{
					if (!item2.IsFunctional())
					{
						float bestScore2;
						ObjectInteraction bestInteractionByName2 = InteractionAlgorithms.GetBestInteractionByName(item2, "CheckIn", character, out bestScore2, evalAttractiveness: false, null);
						if (bestScore2 < num)
						{
							bestItem = bestInteractionByName2;
							num = bestScore2;
						}
					}
				}
			}
			return bestItem != null;
		}

		public bool IsReceptionValid(out bool waitingForReceptionist)
		{
			waitingForReceptionist = false;
			if (_items.Count != 0)
			{
				bool flag = false;
				foreach (RoomItem item in _items)
				{
					if (item.IsFunctional())
					{
						flag = true;
					}
				}
				if (!flag)
				{
					waitingForReceptionist = true;
				}
				return true;
			}
			return false;
		}
	}
}
