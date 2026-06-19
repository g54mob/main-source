using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class RoomModifierTreatment : RoomModifier
	{
		[SerializeField]
		[InspectorTooltip("Increase Treatment Effectiveness By X Percent")]
		private float _percentage;

		[SerializeField]
		[InspectorTooltip("Apply To All Treatments In The Room (** UPGRADES SHOULD BE FALSE **)")]
		private bool _roomWide = true;

		public bool RoomWide => _roomWide;

		public float Percentage => _percentage;

		public void Apply(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (_roomWide && floorPlan.OwningRoom != null)
			{
				floorPlan.OwningRoom.TreatmentModifier += _percentage / 100f;
			}
		}

		public void Remove(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (_roomWide && floorPlan.OwningRoom != null)
			{
				floorPlan.OwningRoom.TreatmentModifier -= _percentage / 100f;
			}
		}

		public string Description()
		{
			return ScriptLocalization.Room_Modifiers.Treatment_Description_CS.Replace("{[AMOUNT]}", StringUtils.FormatPercentageValue(Percentage / 100f, prefixPlus: true));
		}

		public RoomModifierCondition GetModifierCondition()
		{
			return RoomModifierCondition.None;
		}
	}
}
