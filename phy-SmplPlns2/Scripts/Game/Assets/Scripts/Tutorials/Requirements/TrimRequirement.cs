using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Trim")]
	public class TrimRequirement : TargetValueRequirement
	{
		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			return base.ComparisonOperator switch
			{
				ComparisonOperatorType.GreaterThan => "Set the trim to more than {2:P0}.", 
				ComparisonOperatorType.GreaterThanOrEqual => "Set the trim to at least {2:P0}.", 
				ComparisonOperatorType.LessThan => "Set the trim to less than {3:P0}.", 
				ComparisonOperatorType.LessThanOrEqual => "Set the trim to no more than {3:P0}.", 
				ComparisonOperatorType.Equal => "Set the trim to {0:P0}.", 
				ComparisonOperatorType.NotEqual => "Set the trim below {2} or above {3}.", 
				_ => throw new NotSupportedException(), 
			};
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			return playerAircraft.Controls.Trim;
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightInteractablePartsByInput("Trim");
			HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes.TrimIndicator);
		}
	}
}
