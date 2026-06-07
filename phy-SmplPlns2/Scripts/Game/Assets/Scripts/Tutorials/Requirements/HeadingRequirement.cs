using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Craft.Parts.Modifiers;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Heading")]
	public class HeadingRequirement : TutorialRequirement
	{
		public float DistanceToTarget { get; private set; }

		[field: SerializeField]
		public float TargetValue { get; protected set; }

		[field: SerializeField]
		public float TargetValueTolerance { get; private set; }

		public HeadingRequirement()
		{
		}

		public HeadingRequirement(float targetValue, float targetValueTolerance)
		{
			TargetValue = targetValue;
			TargetValueTolerance = targetValueTolerance;
		}

		protected override string FormatMessage(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				return message;
			}
			return string.Format(message, TargetValue, TargetValueTolerance, DistanceToTarget, DistanceToTarget + TargetValueTolerance);
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("value", TargetValue);
			xml.SetAttributeValue("tolerance", (TargetValueTolerance != 0f) ? new float?(TargetValueTolerance) : ((float?)null));
			base.GenerateXml(xml);
		}

		protected override string GetDefaultRequirementNotMetMessage(bool vr)
		{
			return "Adjust your heading to {0:F0} degrees";
		}

		protected override void OnHighlightDefaultParts()
		{
			base.OnHighlightDefaultParts();
			HighlightGaugeByFaceType(GaugeData.GaugeFaceTypes.HeadingIndicator);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			float y = playerAircraft.Rotation.y;
			DistanceToTarget = Mathf.Abs(Mathf.DeltaAngle(y, TargetValue));
			if (!(DistanceToTarget <= TargetValueTolerance))
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			TargetValue = ((float?)xml.Attribute("value")).GetValueOrDefault();
			TargetValueTolerance = ((float?)xml.Attribute("tolerance")).GetValueOrDefault();
		}
	}
}
