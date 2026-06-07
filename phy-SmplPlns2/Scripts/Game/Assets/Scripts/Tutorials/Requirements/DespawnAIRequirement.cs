using System;
using System.Xml.Linq;
using Assets.Scripts.Flight.AI;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("DespawnAI")]
	public class DespawnAIRequirement : TutorialRequirement
	{
		public string Name { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public DespawnAIRequirement()
		{
		}

		public DespawnAIRequirement(string name)
		{
			Name = name;
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			bool flag = string.IsNullOrWhiteSpace(Name);
			foreach (AiControlledAircraftScript item in AiManagerScript.Instance.AiAircraft)
			{
				if (flag || item.AiAircraftScript.Aircraft.Name == Name)
				{
					AiManagerScript.Instance.DespawnAircraft(item, 0f);
				}
			}
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("name", Name);
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			Name = (string)xml.Attribute("name");
		}
	}
}
