using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Speed")]
	public class SpeedRequirement : TargetValueRequirement
	{
		[field: SerializeField]
		public AircraftScript.SpeedType SpeedType { get; set; }

		protected override UnitType? UnitType => Jundroo.Common.Math.UnitType.Speed;

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("speedType", (SpeedType != AircraftScript.SpeedType.IAS) ? new AircraftScript.SpeedType?(SpeedType) : ((AircraftScript.SpeedType?)null));
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			bool flag = base.TargetValue + base.TargetValueTolerance < 1f;
			switch (base.ComparisonOperator)
			{
			case ComparisonOperatorType.GreaterThan:
			case ComparisonOperatorType.GreaterThanOrEqual:
				return "Reach a speed of at least {0}.";
			case ComparisonOperatorType.LessThan:
			case ComparisonOperatorType.LessThanOrEqual:
				if (!flag)
				{
					return "Slow down to a speed of less than {0}.";
				}
				return "Come to a complete stop";
			case ComparisonOperatorType.Equal:
				if (!flag)
				{
					return "Maintain a speed of between {2} and {3}.";
				}
				return "Come to a complete stop";
			case ComparisonOperatorType.NotEqual:
				if (!flag)
				{
					return "Maintain a speed below {2} or above {3}.";
				}
				return "Start moving";
			default:
				throw new NotSupportedException();
			}
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			return playerAircraft.GetSpeed(SpeedType);
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes.AirSpeed200Indicator);
			HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes.AirSpeed400Indicator);
			HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes.AirSpeed600Indicator);
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			SpeedType = xml.GetEnumAttribute("speedType", AircraftScript.SpeedType.IAS);
		}
	}
}
