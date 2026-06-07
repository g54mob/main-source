using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.Combat;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("TargetingMode")]
	public class TargetingModeRequirement : TutorialRequirement
	{
		[field: SerializeField]
		public TargetingSystem.TargetingSystemMode Mode { get; set; }

		public TargetingModeRequirement()
		{
		}

		public TargetingModeRequirement(TargetingSystem.TargetingSystemMode mode)
		{
			Mode = mode;
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("mode", Mode);
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			return "Select the '" + Mode.DisplayName() + "' targeting mode.";
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightInteractablePartsByInput("CycleTargetingMode");
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			if (Mode != playerAircraft.TargetingSystem.Mode)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			Mode = xml.GetEnumAttributeOrNull<TargetingSystem.TargetingSystemMode>("mode") ?? throw new Exception("Unable to parse targeting mode.");
		}
	}
}
