using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Jundroo.Common.Math;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Altitude")]
	public class AltitudeRequirement : TargetValueRequirement
	{
		public bool UseRelativeAltitude { get; set; }

		protected override UnitType? UnitType => Jundroo.Common.Math.UnitType.ShortDistance;

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			if (UseRelativeAltitude)
			{
				base.TargetValue += base.PlayerAircraft.Altitude;
				RefreshTargetLimits();
			}
		}

		protected override void GenerateXml(XElement xml)
		{
			if (UseRelativeAltitude)
			{
				xml.SetAttributeValue("relative", UseRelativeAltitude);
			}
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			switch (base.ComparisonOperator)
			{
			case ComparisonOperatorType.GreaterThan:
			case ComparisonOperatorType.GreaterThanOrEqual:
				return "Reach an altitude of at least {0}.";
			case ComparisonOperatorType.LessThan:
			case ComparisonOperatorType.LessThanOrEqual:
				return "Descend to an altitude of less than {0}.";
			case ComparisonOperatorType.Equal:
				return "Maintain an altitude between {2} and {3}.";
			case ComparisonOperatorType.NotEqual:
				return "Maintain an altitude below {2} or above {3}.";
			default:
				throw new NotSupportedException();
			}
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			return playerAircraft.Altitude;
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes.AltimeterIndicator);
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			UseRelativeAltitude = (bool?)xml.Attribute("relative") == true;
		}
	}
}
