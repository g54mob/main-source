using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Weapon")]
	public class SelectedWeaponRequirement : TutorialRequirement
	{
		[field: SerializeField]
		public string Weapon { get; set; }

		public SelectedWeaponRequirement()
		{
		}

		public SelectedWeaponRequirement(string weapon)
		{
			Weapon = weapon;
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("id", Weapon);
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			return "Select the '" + Weapon + "' weapon system.";
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightInteractablePartsByInput("PreviousWeapon");
			HighlightInteractablePartsByInput("NextWeapon");
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			if (!(playerAircraft.TargetingSystem.SelectedWeaponSystem?.WeaponPartName == Weapon))
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			Weapon = (string)xml.Attribute("id");
		}
	}
}
