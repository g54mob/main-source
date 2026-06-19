using System;
using UnityEngine;

namespace TH20
{
	public class MaintenanceDataView : IDataViewMode
	{
		private ObjectAttributes.Type _currentObjectType;

		private readonly VisualManager _visualManager;

		private readonly WorldState _worldState;

		private readonly BuildEvents _buildEvents;

		private readonly DataViewManager.Config _config;

		public MaintenanceDataView(DataViewManager.Config config, VisualManager visualManager, WorldState worldState, BuildEvents buildEvents)
		{
			_worldState = worldState;
			_buildEvents = buildEvents;
			_visualManager = visualManager;
			_config = config;
		}

		public void Enable(DataViewManager.Mode mode)
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Combine(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			_currentObjectType = ObjectAttributes.Type.Maintenance;
			_visualManager.RoomLightingManager.EnableDesaturatedHospital();
			DataViewManager.EnableValueMaterialOnObjectsWithObjectAttribute(_currentObjectType, _worldState);
		}

		public void Disable()
		{
			BuildEvents buildEvents = _buildEvents;
			buildEvents.OnRoomItemAdded = (Action<RoomItem, FloorPlan>)Delegate.Remove(buildEvents.OnRoomItemAdded, new Action<RoomItem, FloorPlan>(OnRoomItemAdded));
			DataViewManager.DisableValueMaterialOnObjects(_worldState);
		}

		public void Update()
		{
			if (!_config.ObjectAttributeVisualisations.TryGetValue(_currentObjectType, out var value))
			{
				return;
			}
			foreach (Room allRoom in _worldState.AllRooms)
			{
				foreach (RoomItem item in allRoom.FloorPlan.Items)
				{
					SetObjectValueColor(item, _currentObjectType, value);
				}
			}
		}

		public void OnRoomItemAdded(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (roomItem.Visual != null)
			{
				roomItem.Visual.EnableValueMaterial();
			}
		}

		private static void SetObjectValueColor(RoomItem roomItem, ObjectAttributes.Type attributeType, DataViewManager.Config.ObjectAttributeVisualisation objectAttributeVisualisation)
		{
			AttributeFloat attributeFloat = null;
			if (roomItem.GetAttributes() != null)
			{
				attributeFloat = roomItem.GetAttributes().GetAttribute((int)attributeType);
			}
			if (attributeFloat != null)
			{
				float num = attributeFloat.Value();
				num /= objectAttributeVisualisation.MaxValue;
				Color valueMaterial = objectAttributeVisualisation.Gradient.Evaluate(num);
				roomItem.Visual.SetValueMaterial(valueMaterial);
			}
			else
			{
				roomItem.Visual.SetValueMaterial(Color.white);
			}
		}
	}
}
