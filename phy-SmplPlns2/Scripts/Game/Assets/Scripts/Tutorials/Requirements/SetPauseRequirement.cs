using System;
using System.Xml.Linq;
using Assets.Scripts.Flight;
using Assets.Scripts.Tutorials.Requirements.Attributes;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("SetPause")]
	public class SetPauseRequirement : TutorialRequirement
	{
		public bool AsUser { get; set; }

		public bool Pause { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public SetPauseRequirement()
		{
		}

		public SetPauseRequirement(bool pause, bool asUser)
		{
			Pause = pause;
			AsUser = asUser;
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			PauseManager.RequestPauseChange(Pause, AsUser);
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("pause", Pause);
			xml.SetAttributeValue("asUser", AsUser);
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			Pause = (bool)xml.Attribute("pause");
			AsUser = (bool)xml.Attribute("asUser");
		}
	}
}
