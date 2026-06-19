using System.Collections.Generic;

namespace TH20
{
	public class UGCDefinitionsFixUp
	{
		private List<RoomItemDefinitionUGC> _roomItems;

		private List<WallVisualOverrideDefinitionUGC> _wallVisualOverrides;

		private List<FloorVisualOverrideDefinitionUGC> _floorVisualOverrides;

		public UGCDefinitionsFixUp()
		{
			_roomItems = new List<RoomItemDefinitionUGC>();
			_wallVisualOverrides = new List<WallVisualOverrideDefinitionUGC>();
			_floorVisualOverrides = new List<FloorVisualOverrideDefinitionUGC>();
		}

		public void AddRoomItem(RoomItemDefinitionUGC roomItem)
		{
			if (!_roomItems.Contains(roomItem))
			{
				_roomItems.Add(roomItem);
			}
		}

		public void AddWallVisualOverride(WallVisualOverrideDefinitionUGC wallVisualOverride)
		{
			if (!_wallVisualOverrides.Contains(wallVisualOverride))
			{
				_wallVisualOverrides.Add(wallVisualOverride);
			}
		}

		public void AddFloorVisualOverride(FloorVisualOverrideDefinitionUGC floorVisualOverride)
		{
			if (!_floorVisualOverrides.Contains(floorVisualOverride))
			{
				_floorVisualOverrides.Add(floorVisualOverride);
			}
		}

		public FloorVisualOverrideDefinitionUGC FindFloorVisualOverride(string contentID)
		{
			foreach (FloorVisualOverrideDefinitionUGC floorVisualOverride in _floorVisualOverrides)
			{
				if (floorVisualOverride.ContentID == contentID)
				{
					return floorVisualOverride;
				}
			}
			return null;
		}

		public WallVisualOverrideDefinitionUGC FindWallVisualOverride(string contentID)
		{
			foreach (WallVisualOverrideDefinitionUGC wallVisualOverride in _wallVisualOverrides)
			{
				if (wallVisualOverride.ContentID == contentID)
				{
					return wallVisualOverride;
				}
			}
			return null;
		}

		public RoomItemDefinitionUGC FindRoomItem(string contentID)
		{
			foreach (RoomItemDefinitionUGC roomItem in _roomItems)
			{
				if (roomItem.ContentID == contentID)
				{
					return roomItem;
				}
			}
			return null;
		}

		public void RestoreRoomItemsFromSave(UGCRuntimePrefabManager ugcFakePrefabManager, UGCRoomItemDefinitionDatabase ugcRoomItemDefinitionDatabase)
		{
			if (_roomItems == null)
			{
				_roomItems = new List<RoomItemDefinitionUGC>();
			}
			foreach (RoomItemDefinitionUGC roomItem in _roomItems)
			{
				roomItem.RestoreFromSave(ugcFakePrefabManager, ugcRoomItemDefinitionDatabase);
			}
		}

		public void RestoreWallVisualOverrideFromSave(UGCWallVisualOverrideDefinitionDatabase database)
		{
			if (_wallVisualOverrides == null)
			{
				_wallVisualOverrides = new List<WallVisualOverrideDefinitionUGC>();
			}
			foreach (WallVisualOverrideDefinitionUGC wallVisualOverride in _wallVisualOverrides)
			{
				wallVisualOverride.RestoreFromSave(database);
			}
		}

		public void RestoreFloorVisualOverrideFromSave(UGCFloorVisualOverrideDefinitionDatabase database)
		{
			if (_floorVisualOverrides == null)
			{
				_floorVisualOverrides = new List<FloorVisualOverrideDefinitionUGC>();
			}
			foreach (FloorVisualOverrideDefinitionUGC floorVisualOverride in _floorVisualOverrides)
			{
				floorVisualOverride.RestoreFromSave(database);
			}
		}
	}
}
