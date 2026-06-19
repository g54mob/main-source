using System;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class RoomModifierResearchRate : RoomModifier
	{
		[InspectorTooltip("Increase Research Rate By X Percent")]
		public float Percentage;

		public void Apply(RoomItem roomItem, FloorPlan floorPlan)
		{
		}

		public void Remove(RoomItem roomItem, FloorPlan floorPlan)
		{
		}

		public string Description()
		{
			return ScriptLocalization.Room_Modifiers.Research_Description_CS.Replace("{[AMOUNT]}", StringUtils.FormatPercentageValue(Percentage / 100f, prefixPlus: true));
		}

		public RoomModifierCondition GetModifierCondition()
		{
			return RoomModifierCondition.None;
		}
	}
}
