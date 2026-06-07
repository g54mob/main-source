using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Jundroo.Common.Math;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("TargetDistance")]
	public class TargetDistanceRequirement : TargetValueRequirement
	{
		public string TargetName { get; set; }

		protected override UnitType? UnitType => Jundroo.Common.Math.UnitType.ShortDistance;

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("targetName", TargetName);
			base.GenerateXml(xml);
		}

		protected override float? GetValue(AircraftScript playerAircraft)
		{
			TrackedTarget currentTrackedTarget = playerAircraft.TargetingSystem.CurrentTrackedTarget;
			if (currentTrackedTarget == null)
			{
				return null;
			}
			if (!string.IsNullOrEmpty(TargetName) && currentTrackedTarget.Target.Name != TargetName)
			{
				return null;
			}
			return currentTrackedTarget.Distance;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			TargetName = (string)xml.Attribute("targetName");
		}
	}
}
