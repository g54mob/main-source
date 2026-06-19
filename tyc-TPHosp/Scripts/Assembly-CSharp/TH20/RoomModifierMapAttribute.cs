using System;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class RoomModifierMapAttribute : RoomModifier
	{
		[SerializeField]
		private HospitalAttributeMap.Attribute _attribute;

		[SerializeField]
		private float _value = 1f;

		[SerializeField]
		private float _radiusInCells = 1f;

		[SerializeField]
		private float _maintenanceModifier;

		[InspectorTooltip("Start applying when maintenance level is ABOVE this value (0 - 100)")]
		[SerializeField]
		private float _startApplyingLevel;

		public HospitalAttributeMap.Attribute Attribute => _attribute;

		public float GetAttributeValue(RoomItem roomItem)
		{
			float num = _value;
			if (roomItem.MaintenanceLevel != null)
			{
				float num2 = roomItem.MaintenanceLevel.Value();
				if (num2 >= _startApplyingLevel)
				{
					num += _maintenanceModifier * (num2 / 100f);
				}
			}
			return num;
		}

		public void Apply(RoomItem roomItem, FloorPlan floorPlan)
		{
			float attributeValue = GetAttributeValue(roomItem);
			floorPlan.WorldState.HospitalAttributeMaps[(int)_attribute].AddMapAttribute(roomItem, _radiusInCells, attributeValue);
		}

		public void Refresh(RoomItem roomItem, FloorPlan floorPlan)
		{
			float attributeValue = GetAttributeValue(roomItem);
			floorPlan.WorldState.HospitalAttributeMaps[(int)_attribute].RefreshMapAttribute(roomItem, attributeValue);
		}

		public void Remove(RoomItem roomItem, FloorPlan floorPlan)
		{
			floorPlan.WorldState.HospitalAttributeMaps[(int)_attribute].RemoveMapAttribute(roomItem);
		}

		public string Description()
		{
			return null;
		}

		public RoomModifierCondition GetModifierCondition()
		{
			return RoomModifierCondition.None;
		}
	}
}
