using System;
using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class HospitalAttributeMap : MustCallDestroy
	{
		public enum Attribute
		{
			None = -1,
			Temperature = 0,
			Attractiveness = 1,
			Hygiene = 2
		}

		private struct ItemValues
		{
			public float RadiusInCells;

			public float Value;
		}

		private Dictionary<RoomItem, ItemValues> _previousValues = new Dictionary<RoomItem, ItemValues>();

		private float _precision = 0.05f;

		private BuildEvents _buildEvents;

		private GridCoord _anchor;

		private int _width;

		private int _height;

		private UnionByteFloatArray _values;

		private float _initialValue;

		public Action OnMapUpdated;

		public Action OnCharacterUpdated;

		public float[] Floats => _values.Floats;

		public byte[] Bytes => _values.Bytes;

		public float NumOfFloats => (float)_values.Bytes.Length / 4f;

		public HospitalAttributeMap(GridCoord anchor, int width, int height, float initialValue, BuildEvents buildEvents)
		{
			_buildEvents = buildEvents;
			_anchor = anchor;
			_width = width;
			_height = height;
			_initialValue = initialValue;
			_values.Bytes = new byte[_width * _height * 4];
			ClearMap();
			RegisterEvents();
		}

		private void RegisterEvents()
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuilt));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Combine(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
		}

		public override void RestoreFromSave()
		{
			base.RestoreFromSave();
			RegisterEvents();
		}

		public void OverrideInitialValue(float value)
		{
			_initialValue = value;
			RefreshMap();
		}

		private void ClearMap()
		{
			int width = _width;
			int height = _height;
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					_values.Floats[j + i * width] = _initialValue;
				}
			}
		}

		private void OnRoomBuilt(Room room, int cost)
		{
			RefreshMap();
		}

		private void OnRoomDeleted(Room room)
		{
			RefreshMap();
		}

		private void RefreshMap()
		{
			ClearMap();
			foreach (KeyValuePair<RoomItem, ItemValues> previousValue in _previousValues)
			{
				ModifyMapAttribute(previousValue.Key, previousValue.Value.RadiusInCells, previousValue.Value.Value);
			}
			OnMapUpdated.InvokeSafe();
		}

		public void AddMapAttribute(RoomItem roomItem, float radiusInCells, float value)
		{
			_previousValues[roomItem] = new ItemValues
			{
				Value = value,
				RadiusInCells = radiusInCells
			};
			ModifyMapAttribute(roomItem, radiusInCells, value);
			OnMapUpdated.InvokeSafe();
		}

		public void RemoveMapAttribute(RoomItem roomItem)
		{
			if (_previousValues.TryGetValue(roomItem, out var value))
			{
				ModifyMapAttribute(roomItem, value.RadiusInCells, 0f - value.Value);
				_previousValues.Remove(roomItem);
				OnMapUpdated.InvokeSafe();
			}
		}

		private void ModifyMapAttribute(RoomItem roomItem, float radiusInCells, float value)
		{
			Vector3 worldPosition = roomItem.WorldPosition;
			worldPosition.x /= 2f;
			worldPosition.z /= 2f;
			worldPosition.x -= _anchor.X;
			worldPosition.z -= _anchor.Y;
			GridCoord gridCoord = roomItem.WorldPosition.ToGridCoord() - _anchor;
			int num = Mathf.Max(0, Mathf.FloorToInt((float)gridCoord.X - radiusInCells));
			int num2 = Mathf.Max(0, Mathf.FloorToInt((float)gridCoord.Y - radiusInCells));
			int num3 = Mathf.Min(_width, Mathf.CeilToInt((float)gridCoord.X + radiusInCells + 1f));
			int num4 = Mathf.Min(_height, Mathf.CeilToInt((float)gridCoord.Y + radiusInCells + 1f));
			Room owningRoom = roomItem.OwningRoom;
			HospitalMap hospitalMap = roomItem.FloorPlan.HospitalMap;
			FloorPlan floorPlan = hospitalMap.FloorPlan;
			Room[,] worldRooms = hospitalMap.WorldRooms;
			bool flag = owningRoom?.Definition.IsLowWallRoom() ?? false;
			bool flag2 = owningRoom?.Definition.IsHospitalOrBay ?? true;
			for (int i = num2; i < num4; i++)
			{
				for (int j = num; j < num3; j++)
				{
					Room room = worldRooms[j, i];
					bool flag3 = false;
					if (room == null && floorPlan[j, i])
					{
						room = hospitalMap.Room;
						flag3 = true;
					}
					bool flag4 = room == owningRoom;
					bool flag5 = room?.Definition.IsLowWallRoom() ?? false;
					if ((flag && flag3) || (flag2 && flag5) || (flag && flag5) || flag4)
					{
						float sqrMagnitude = new Vector2(worldPosition.x - (float)j, worldPosition.z - (float)i).sqrMagnitude;
						if (sqrMagnitude <= radiusInCells * radiusInCells)
						{
							_values.Floats[j + i * _width] += value * (1f - (float)Math.Sqrt(sqrMagnitude) / radiusInCells);
						}
					}
				}
			}
		}

		public float GetMapAttribute(Vector3 worldPosition)
		{
			GridCoord gridCoord = GridCoord.WorldPositionToGridCoord(worldPosition) - _anchor;
			return GetMapAttribute(gridCoord.X, gridCoord.Y);
		}

		public float GetMapAttribute(int x, int y)
		{
			int num = x + y * _width;
			if (num > 0 && (float)num < NumOfFloats)
			{
				return Floats[num];
			}
			return _initialValue;
		}

		public void RefreshMapAttribute(RoomItem roomItem, float value)
		{
			if (_previousValues.TryGetValue(roomItem, out var value2) && Mathf.Abs(value2.Value - value) > _precision)
			{
				_previousValues[roomItem] = new ItemValues
				{
					Value = value,
					RadiusInCells = value2.RadiusInCells
				};
				ModifyMapAttribute(roomItem, value2.RadiusInCells, value - value2.Value);
				OnMapUpdated.InvokeSafe();
			}
		}

		public override void Destroy()
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuilt));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomDeleted = (Action<Room>)Delegate.Remove(buildEvents2.OnRoomDeleted, new Action<Room>(OnRoomDeleted));
			base.Destroy();
		}

		public float CalculateAverageValue(FloorPlan floorPlan, float min, float max)
		{
			int numTiles = 0;
			float total = 0f;
			RoomAlgorithms.IterateAllRoomTiles(floorPlan, delegate(int x, int y, bool free)
			{
				if (free)
				{
					Vector3 worldPosition = (new GridCoord(x, y) + floorPlan.Anchor).ToWorldPosition();
					total += Mathf.Clamp(GetMapAttribute(worldPosition), min, max);
					numTiles++;
				}
			});
			return (total / (float)numTiles - min) / (max - min);
		}

		public float CalculateTotalValue(FloorPlan floorPlan, float min, float max)
		{
			float total = 0f;
			RoomAlgorithms.IterateAllRoomTiles(floorPlan, delegate(int x, int y, bool free)
			{
				if (free)
				{
					Vector3 worldPosition = (new GridCoord(x, y) + floorPlan.Anchor).ToWorldPosition();
					float mapAttribute = GetMapAttribute(worldPosition);
					total += (Mathf.Clamp(mapAttribute, min, max) + 1f) * 0.5f;
				}
			});
			return total;
		}
	}
}
