using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class RoomModifierRequiredStaff : RoomModifier
	{
		[SerializeField]
		private StaffRequired _staffRequired;

		public StaffRequired StaffRequired => _staffRequired;

		public void Apply(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (floorPlan.OwningRoom != null)
			{
				floorPlan.OwningRoom.AddOptionalStaffJob(_staffRequired);
			}
		}

		public void Remove(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (floorPlan.OwningRoom != null)
			{
				floorPlan.OwningRoom.RemoveOptionalStaffJob(_staffRequired);
			}
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
