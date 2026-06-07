using System;
using System.Xml.Linq;
using Assets.Scripts.Craft;
using Assets.Scripts.Tutorials.Requirements.Attributes;
using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Tutorials.Requirements
{
	[Serializable]
	[TutorialRequirement("PositionInRadius")]
	public class PositionInRadiusRequirement : TutorialRequirement
	{
		private float _remainingDistanceToPosition;

		private float _remainingDistanceToRadius;

		public bool Invert { get; set; }

		public float Radius { get; set; }

		public float? X { get; set; }

		public float? Y { get; set; }

		public float? Z { get; set; }

		protected override float DefaultRequiredMetDuration => 0f;

		public PositionInRadiusRequirement()
		{
		}

		public PositionInRadiusRequirement(float? x, float? y, float? z, float radius)
		{
			X = x;
			Y = y;
			Z = z;
			Radius = radius;
		}

		public override void OnStepStarted()
		{
			base.OnStepStarted();
			_remainingDistanceToPosition = 0f;
			_remainingDistanceToRadius = 0f;
			Transform transform = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
			transform.name = "Debug Target Position";
			transform.GetComponent<MeshRenderer>().material.color = Color.red;
			transform.localScale = Vector3.one * Radius;
			transform.position = GameWorld.Instance.FloatingOriginOffset + new Vector3(X.GetValueOrDefault(), Y ?? 1000f, Z.GetValueOrDefault());
		}

		protected override string FormatMessage(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				return message;
			}
			return string.Format(message, _remainingDistanceToRadius.Format(UnitType.ShortDistance), _remainingDistanceToRadius, _remainingDistanceToPosition.Format(UnitType.ShortDistance), _remainingDistanceToPosition);
		}

		protected override void GenerateXml(XElement xml)
		{
			xml.SetAttributeValue("x", X);
			xml.SetAttributeValue("y", Y);
			xml.SetAttributeValue("z", Z);
			xml.SetAttributeValue("radius", Radius);
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
			Vector3 vector = new Vector3((!X.HasValue) ? 0f : (X.Value - globalPosition.x), (!Y.HasValue) ? 0f : (Y.Value - globalPosition.y), (!Z.HasValue) ? 0f : (Z.Value - globalPosition.z));
			_remainingDistanceToPosition = vector.magnitude;
			_remainingDistanceToRadius = _remainingDistanceToPosition - Radius;
			if (!(Invert ? (_remainingDistanceToPosition > Radius) : (_remainingDistanceToPosition <= Radius)))
			{
				return TutorialRequirementState.RequirementNotMet;
			}
			return TutorialRequirementState.RequirementMet;
		}

		protected override void RestoreFromXml(XElement xml)
		{
			base.RestoreFromXml(xml);
			X = (float?)xml.Attribute("x");
			Y = (float?)xml.Attribute("y");
			Z = (float?)xml.Attribute("z");
			Radius = (float)xml.Attribute("radius");
			Invert = (bool?)xml.Attribute("invert") == true;
		}
	}
}
