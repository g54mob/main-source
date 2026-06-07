using System;
using Assets.Scripts.Craft;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Brake")]
	public class BrakeRequirement : TargetValueRequirement
	{
		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			bool flag = base.TargetValue - base.TargetValueTolerance > 0.9f;
			bool flag2 = base.TargetValue + base.TargetValueTolerance < 0.1f;
			switch (base.ComparisonOperator)
			{
			case ComparisonOperatorType.GreaterThan:
				if (!flag)
				{
					return "Set the brake to more than {2:P0}.";
				}
				return "Hit the brakes!";
			case ComparisonOperatorType.GreaterThanOrEqual:
				if (!flag)
				{
					return "Set the brake to at least {2:P0}.";
				}
				return "Hit the brakes!";
			case ComparisonOperatorType.LessThan:
				if (!flag2)
				{
					return "Set the brake to less than {3:P0}.";
				}
				return "Release the brakes.";
			case ComparisonOperatorType.LessThanOrEqual:
				if (!flag2)
				{
					return "Set the brake to no more than {3:P0}.";
				}
				return "Release the brakes.";
			case ComparisonOperatorType.Equal:
				if (!flag)
				{
					if (!flag2)
					{
						return "Set the brake to {0:P0}.";
					}
					return "Release the brakes.";
				}
				return "Hit the brakes!";
			case ComparisonOperatorType.NotEqual:
				return "Set the brake below {2} or above {3}.";
			default:
				throw new NotSupportedException();
			}
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			return playerAircraft.Controls.Brake;
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightInteractablePartsByInput("Brake");
		}
	}
}
