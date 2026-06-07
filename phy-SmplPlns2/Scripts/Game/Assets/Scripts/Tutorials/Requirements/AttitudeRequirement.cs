using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Attitude")]
	public class AttitudeRequirement : TargetValueRequirement
	{
		public enum AttitudeType
		{
			Pitch = 0,
			Roll = 1
		}

		public AttitudeType Type { get; set; }

		public AttitudeRequirement()
		{
		}

		public AttitudeRequirement(AttitudeType type)
		{
			Type = type;
		}

		protected override float ConvertValueForDisplay(float value)
		{
			return Mathf.Abs(base.ConvertValueForDisplay(value));
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("type", Type);
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			switch (base.ComparisonOperator)
			{
			case ComparisonOperatorType.GreaterThan:
			case ComparisonOperatorType.GreaterThanOrEqual:
				if (Type == AttitudeType.Pitch)
				{
					if (!(base.TargetValue < 0f))
					{
						return "Pitch upward at an angle greater than {0:F0} degrees.";
					}
					return "Pitch downward at an angle less than {0:F0} degrees.";
				}
				if (!(base.TargetValue < 0f))
				{
					return "Roll to the right at an angle of at least {0:F0} degrees.";
				}
				return "Roll to the left at an angle less than {0:F0} degrees.";
			case ComparisonOperatorType.LessThan:
			case ComparisonOperatorType.LessThanOrEqual:
				if (Type == AttitudeType.Pitch)
				{
					if (!(base.TargetValue < 0f))
					{
						return "Pitch upward at an angle less than {0:F0} degrees.";
					}
					return "Pitch downward at an angle greater than {0:F0} degrees.";
				}
				if (!(base.TargetValue < 0f))
				{
					return "Roll to the right at an angle less than {0:F0} degrees.";
				}
				return "Roll to the left at an angle of at least {0:F0} degrees.";
			case ComparisonOperatorType.Equal:
				if (Type == AttitudeType.Pitch)
				{
					if (!Mathf.Approximately(base.TargetValue, 0f))
					{
						return "Maintain " + ((base.TargetValue < 0f) ? "a downward" : "an upward") + " pitch angle between {2:F0} and {3:F0} degrees.";
					}
					return "Level out the pitch angle of the craft";
				}
				if (!Mathf.Approximately(base.TargetValue, 0f))
				{
					return "Maintain a " + ((base.TargetValue < 0f) ? "left" : "right") + " roll angle between {2:F0} and {3:F0} degrees.";
				}
				return "Level out the roll angle of the craft";
			case ComparisonOperatorType.NotEqual:
				if (Type == AttitudeType.Pitch)
				{
					if (!(base.TargetValue < 0f))
					{
						return "Maintain an upward pitch angle below {2:F0} or above {3:F0} degrees.";
					}
					return "Maintain a downward pitch angle below {2:F0} or above {3:F0} degrees.";
				}
				if (!(base.TargetValue < 0f))
				{
					return "Maintain a right roll angle below {2:F0} or above {3:F0} degrees.";
				}
				return "Maintain a left roll angle below {2:F0} or above {3:F0} degrees.";
			default:
				throw new NotSupportedException();
			}
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			if (Type == AttitudeType.Pitch)
			{
				float x = playerAircraft.Rotation.x;
				return (x > 180f) ? (0f - (x - 360f)) : (0f - x);
			}
			if (Type == AttitudeType.Roll)
			{
				float z = playerAircraft.Rotation.z;
				return (z > 180f) ? (360f - z) : (0f - z);
			}
			return null;
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightPartsWithModifier<AttitudeBallData>();
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			Type = xml.GetEnumAttribute("type", AttitudeType.Pitch);
		}
	}
}
