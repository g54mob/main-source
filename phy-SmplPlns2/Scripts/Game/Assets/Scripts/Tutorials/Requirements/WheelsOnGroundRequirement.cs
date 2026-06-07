using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("WheelsOnGround")]
	public class WheelsOnGroundRequirement : TutorialRequirement
	{
		public bool Grounded { get; set; }

		public int? MinimumWheelCount { get; set; }

		public WheelsOnGroundRequirement()
		{
		}

		public WheelsOnGroundRequirement(bool grounded, int? minWheelCount = null)
		{
			Grounded = grounded;
			MinimumWheelCount = minWheelCount;
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("grounded", Grounded);
			xml.SetAttributeValue("minCount", MinimumWheelCount);
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			string text = (MinimumWheelCount.HasValue ? $"At least {MinimumWheelCount.Value}" : "All");
			if (!Grounded)
			{
				return text + " wheels must be off the ground.";
			}
			return text + " wheels must be touching the ground.";
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			int num = MinimumWheelCount ?? playerAircraft.WheelParts.Count;
			if ((Grounded ? playerAircraft.WheelParts.Count((IWheelPart x) => x.IsGrounded) : playerAircraft.WheelParts.Count((IWheelPart x) => !x.IsGrounded)) < num)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			Grounded = ((bool?)xml.Attribute("grounded")) ?? true;
			MinimumWheelCount = (int?)xml.Attribute("minCount");
		}
	}
}
