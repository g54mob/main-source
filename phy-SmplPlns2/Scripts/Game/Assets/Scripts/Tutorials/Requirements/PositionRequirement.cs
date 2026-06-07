using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("Position")]
	public class PositionRequirement : TutorialRequirement
	{
		private float _remainingDistance;

		public bool Invert { get; set; }

		public float? XMax { get; set; }

		public float? XMin { get; set; }

		public float? YMax { get; set; }

		public float? YMin { get; set; }

		public float? ZMax { get; set; }

		public float? ZMin { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public PositionRequirement()
		{
		}

		public PositionRequirement(float? xmin, float? xmax, float? ymin, float? ymax, float? zmin, float? zmax)
		{
			XMin = xmin;
			XMax = xmax;
			YMin = ymin;
			YMax = ymax;
			ZMin = zmin;
			ZMax = zmax;
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			_remainingDistance = 0f;
		}

		protected override string FormatMessage(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				return message;
			}
			return string.Format(message, _remainingDistance.Format(UnitType.ShortDistance), _remainingDistance);
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("xmin", XMin);
			xml.SetAttributeValue("xmax", XMax);
			xml.SetAttributeValue("ymin", YMin);
			xml.SetAttributeValue("ymax", YMax);
			xml.SetAttributeValue("zmin", ZMin);
			xml.SetAttributeValue("zmax", ZMax);
			if (Invert)
			{
				xml.SetAttributeValue("invert", Invert);
			}
			base.GenerateXml(xml);
		}

		protected override TutorialRequirementState OnRequirementUpdate()
		{
			AircraftScript playerAircraft = base.PlayerAircraft;
			if (playerAircraft == null)
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			Vector3 globalPosition = playerAircraft.GlobalPosition;
			Vector3 zero = Vector3.zero;
			if (XMin.HasValue && globalPosition.x < XMin.Value)
			{
				zero.x = XMin.Value - globalPosition.x;
			}
			if (XMax.HasValue && globalPosition.x > XMax.Value)
			{
				zero.x = globalPosition.x - XMax.Value;
			}
			if (YMin.HasValue && globalPosition.y < YMin.Value)
			{
				zero.y = YMin.Value - globalPosition.y;
			}
			if (YMax.HasValue && globalPosition.y > YMax.Value)
			{
				zero.y = globalPosition.y - YMax.Value;
			}
			if (ZMin.HasValue && globalPosition.z < ZMin.Value)
			{
				zero.z = ZMin.Value - globalPosition.z;
			}
			if (ZMax.HasValue && globalPosition.z > ZMax.Value)
			{
				zero.z = globalPosition.z - ZMax.Value;
			}
			_remainingDistance = zero.magnitude;
			if (!(Invert ? (_remainingDistance > Mathf.Epsilon) : (_remainingDistance <= Mathf.Epsilon)))
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			XMin = (float?)xml.Attribute("xmin");
			XMax = (float?)xml.Attribute("xmax");
			YMin = (float?)xml.Attribute("ymin");
			YMax = (float?)xml.Attribute("ymax");
			ZMin = (float?)xml.Attribute("zmin");
			ZMax = (float?)xml.Attribute("zmax");
			Invert = (bool?)xml.Attribute("invert") == true;
		}
	}
}
