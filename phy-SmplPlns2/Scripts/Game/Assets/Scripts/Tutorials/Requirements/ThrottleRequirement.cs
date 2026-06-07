using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Throttle")]
	public class ThrottleRequirement : TargetValueRequirement
	{
		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			return base.ComparisonOperator switch
			{
				ComparisonOperatorType.GreaterThan => "Set the throttle to more than {2:P0}.", 
				ComparisonOperatorType.GreaterThanOrEqual => "Set the throttle to at least {2:P0}.", 
				ComparisonOperatorType.LessThan => "Set the throttle to less than {3:P0}.", 
				ComparisonOperatorType.LessThanOrEqual => "Set the throttle to no more than {3:P0}.", 
				ComparisonOperatorType.Equal => "Set the throttle to {0:P0}.", 
				ComparisonOperatorType.NotEqual => "Set the throttle below {2} or above {3}.", 
				_ => throw new NotSupportedException(), 
			};
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			return playerAircraft.Controls.Throttle;
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightInteractablePartsByInput("Throttle");
			HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes.ThrottleIndicator);
		}
	}
}
