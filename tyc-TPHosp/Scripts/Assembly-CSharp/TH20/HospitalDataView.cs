#define LOG_LEVEL_VERBOSE
using System;
using UnityEngine;

namespace TH20
{
	public abstract class HospitalDataView : IDataViewMode
	{
		protected readonly DataViewManager.Config _config;

		[DontSave]
		private readonly HospitalMapAttributesVisualisation _mapAttributesVisualisation;

		private readonly WorldState _worldState;

		private readonly BuildEvents _buildEvents;

		protected abstract Color PositiveColor();

		protected abstract Color NegativeColor();

		protected abstract HospitalAttributeMap.Attribute AttributeToShow();

		protected HospitalDataView(DataViewManager.Config config, HospitalMapAttributesVisualisation mapAttributesVisualisation, WorldState worldState, BuildEvents buildEvents)
		{
			_config = config;
			_buildEvents = buildEvents;
			_mapAttributesVisualisation = mapAttributesVisualisation;
			_worldState = worldState;
		}

		public virtual void Enable(DataViewManager.Mode mode)
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Combine(buildEvents2.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			_mapAttributesVisualisation.ShowAttributeMap(AttributeToShow());
			DataViewManager.EnableValueMaterialOnObjectsWithMapModifier(AttributeToShow(), _worldState);
		}

		public virtual void Update()
		{
			HospitalAttributeMap.Attribute attribute = AttributeToShow();
			Color b = PositiveColor();
			Color a = NegativeColor();
			float num = _mapAttributesVisualisation.MinValue(attribute);
			float num2 = _mapAttributesVisualisation.MaxValue(attribute);
			float num3 = num2 - num;
			_mapAttributesVisualisation.Update();
			foreach (Room allRoom in _worldState.AllRooms)
			{
				if (allRoom.Definition.IsNoDataRoom)
				{
					continue;
				}
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					if (!DataViewManager.TryGetRoomItemMapModifierValue(item, attribute, out var value))
					{
						continue;
					}
					value = Mathf.Clamp01((Mathf.Clamp(value, num, num2) - num) / num3);
					if (item.Visual != null)
					{
						item.Visual.SetValueMaterial(Color.Lerp(a, b, value));
						continue;
					}
					string arg = "null";
					if (item.OwningRoom != null)
					{
						arg = item.OwningRoom.Definition._type.ToString();
					}
					string message = $"RoomItem {item.Name} does not have a RoomItemVisual object! Invalid Reason: {item.InvalidReasonDebug} OwningRoomType: {arg}";
					Logging.Error(LogChannels.Debug, message);
				}
			}
		}

		public virtual void Disable()
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			BuildEvents buildEvents2 = _buildEvents;
			buildEvents2.OnRoomBuiltEvent = (Action<Room, int>)Delegate.Remove(buildEvents2.OnRoomBuiltEvent, new Action<Room, int>(OnRoomBuiltEvent));
			DataViewManager.DisableValueMaterialOnObjects(_worldState);
		}

		private void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.Visual != null && !floorPlan.OwningRoom.Definition.IsNoDataRoom && DataViewManager.TryGetRoomItemMapModifierValue(roomItem, AttributeToShow(), out var _))
			{
				roomItem.Visual.EnableValueMaterial();
			}
		}

		private void OnRoomBuiltEvent(Room room, int cost)
		{
			foreach (RoomItem item in room.FloorPlan.Items)
			{
				if (item.Visual == null || room.Definition.IsNoDataRoom)
				{
					break;
				}
				if (DataViewManager.TryGetRoomItemMapModifierValue(item, AttributeToShow(), out var _))
				{
					item.Visual.EnableValueMaterial();
				}
			}
		}
	}
}
