using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	public class ItemSpawnLimits : MustCallDestroy
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class Category
		{
			public int MaxCount;
		}

		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public SharedInstance<Category>[] Categories;
		}

		private Level _level;

		private Dictionary<SharedInstance<Category>, int> _records;

		public ItemSpawnLimits(Config config, Level level)
		{
			_level = level;
			_records = new Dictionary<SharedInstance<Category>, int>();
			SharedInstance<Category>[] categories = config.Categories;
			foreach (SharedInstance<Category> key in categories)
			{
				_records.Add(key, 0);
			}
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
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _level.BuildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = _level.BuildEvents;
			buildEvents2.OnRoomItemRemoved = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents2.OnRoomItemRemoved, new Action<RoomItem, FloorPlan>(OnRoomItemRemoved));
			base.Destroy();
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.Definition.SpawnLimitCategory.NotNull())
			{
				_records[roomItem.Definition.SpawnLimitCategory]++;
			}
		}

		private void OnRoomItemRemoved(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.Definition.SpawnLimitCategory.NotNull())
			{
				_records[roomItem.Definition.SpawnLimitCategory]--;
			}
		}

		public bool MaxReached(RoomItemDefinition definition)
		{
			if (definition.SpawnLimitCategory.NotNull())
			{
				SharedInstance<Category> spawnLimitCategory = definition.SpawnLimitCategory;
				if (_records[spawnLimitCategory] >= spawnLimitCategory.Instance.MaxCount)
				{
					return true;
				}
			}
			return false;
		}
	}
}
