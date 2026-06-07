using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("LandingGear")]
	public class LandingGearRequirement : TutorialRequirement
	{
		[field: SerializeField]
		public bool TargetState { get; set; }

		public LandingGearRequirement()
		{
		}

		public LandingGearRequirement(bool targetState)
		{
			TargetState = targetState;
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			HighlightInteractablePartsByInput("LandingGear");
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("state", TargetState);
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			if (!TargetState)
			{
				return "Raise the landing gear";
			}
			return "Lower the landing gear";
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			if (playerAircraft.Controls.LandingGearDown != TargetState)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			TargetState = (bool)xml.Attribute("state");
		}
	}
}
