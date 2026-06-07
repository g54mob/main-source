using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("VTOL")]
	public class VtolRequirement : TargetValueRequirement
	{
		protected override float ConvertValueForDisplay(float value)
		{
			return value * 90f;
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			return base.ComparisonOperator switch
			{
				ComparisonOperatorType.GreaterThan => "Set the VTOL angle to more than {2:F0} degrees.", 
				ComparisonOperatorType.GreaterThanOrEqual => "Set the VTOL angle to at least {2:F0} degrees.", 
				ComparisonOperatorType.LessThan => "Set the VTOL angle to less than {3:F0} degrees.", 
				ComparisonOperatorType.LessThanOrEqual => "Set the VTOL angle to no more than {3:F0} degrees.", 
				ComparisonOperatorType.Equal => "Set the VTOL angle to {0:F0} degrees.", 
				ComparisonOperatorType.NotEqual => "Set the VTOL angle below {2:F0} degrees or above {3:F0} degrees.", 
				_ => throw new NotSupportedException(), 
			};
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			return playerAircraft.Controls.Vtol;
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightInteractablePartsByInput("VTOL");
			HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes.VTOLIndicator);
		}
	}
}
