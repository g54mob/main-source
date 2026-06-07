using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("AIDamaged")]
	internal class AIDamagedRequirement : TutorialRequirement
	{
		public float DamageThreshold { get; set; }

		public bool Destroyed { get; set; }

		public string TargetName { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public AIDamagedRequirement()
		{
		}

		public AIDamagedRequirement(string targetName, bool destroyed)
		{
			TargetName = targetName;
			Destroyed = destroyed;
			DamageThreshold = 0f;
		}

		public AIDamagedRequirement(string targetName, float damageThreshold)
		{
			TargetName = targetName;
			Destroyed = false;
			DamageThreshold = damageThreshold;
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("targetName", TargetName);
			xml.SetAttributeValue("destroyed", Destroyed ? new bool?(true) : ((bool?)null));
			xml.SetAttributeValue("damageThreshold", Destroyed ? ((float?)null) : new float?(DamageThreshold));
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AiControlledAircraftScript aiControlledAircraftScript = AiManagerScript.Instance.AiAircraft.FirstOrDefault((AiControlledAircraftScript x) => x.AiAircraftScript.Aircraft.Name == TargetName);
			if (aiControlledAircraftScript == null)
			{
				return TutorialRequirementState.RequirementMet;
			}
			AircraftScript aircraftScript = aiControlledAircraftScript?.AiAircraftScript;
			if (aircraftScript == null)
			{
				return TutorialRequirementState.RequirementMet;
			}
			if (Destroyed)
			{
				if (aircraftScript.MainCockpit == null || aircraftScript.CriticallyDamaged || aircraftScript.MainCockpit.EstimateOfUnderwaterPercent >= 0.9f)
				{
					return TutorialRequirementState.RequirementMet;
				}
			}
			else if (aircraftScript.Damage > DamageThreshold)
			{
				return TutorialRequirementState.RequirementMet;
			}
			return TutorialRequirementState.RequirementNotMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			TargetName = (string)xml.Attribute("targetName");
			Destroyed = (bool?)xml.Attribute("destroyed") == true;
			DamageThreshold = ((float?)xml.Attribute("damageThreshold")).GetValueOrDefault();
		}
	}
}
