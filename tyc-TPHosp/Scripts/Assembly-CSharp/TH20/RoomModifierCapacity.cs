using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class RoomModifierCapacity : RoomModifier
	{
		[SerializeField]
		private int _capacity = 1;

		[SerializeField]
		private RoomModifierCondition _modifierCondition;

		public RoomModifierCondition ModifierCondition => _modifierCondition;

		public void Apply(RoomItem roomItem, FloorPlan floorPlan)
		{
			floorPlan.MaxCapacity += _capacity;
		}

		public void Remove(RoomItem roomItem, FloorPlan floorPlan)
		{
			floorPlan.MaxCapacity -= _capacity;
		}

		public string Description()
		{
			return null;
		}

		public RoomModifierCondition GetModifierCondition()
		{
			return _modifierCondition;
		}
	}
}
