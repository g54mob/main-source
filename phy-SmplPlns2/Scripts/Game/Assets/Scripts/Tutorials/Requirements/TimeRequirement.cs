using System;
using System.Xml.Linq;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Time")]
	public class TimeRequirement : TutorialRequirement
	{
		private float _elapsedTime;

		public float Duration { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public TimeRequirement()
		{
		}

		public TimeRequirement(float duration)
		{
			Duration = duration;
		}

		public TimeRequirement(float duration, string message)
		{
			Duration = duration;
			base.RequirementNotMetMessage = message;
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			_elapsedTime = 0f;
		}

		protected override string FormatMessage(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				return message;
			}
			return string.Format(message, Duration, Duration - _elapsedTime, _elapsedTime);
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("duration", Duration);
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			_elapsedTime += Time.unscaledDeltaTime;
			if (!(_elapsedTime >= Duration))
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			Duration = (float)xml.Attribute("duration");
		}
	}
}
