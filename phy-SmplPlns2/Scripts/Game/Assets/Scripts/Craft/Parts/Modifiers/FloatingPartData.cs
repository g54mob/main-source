using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Misc.SimpleBehaviours;
using BuoyancyToolkit;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Floating Part")]
	public class FloatingPartData : PartModifierData
	{
		private static GameObject _impactVelocityAdjustmentCurves;

		public bool Enabled { get; set; }

		public string ImpactVelocityAdjustment { get; set; }

		public bool ReduceBuoyancyIfBySelf { get; set; }

		public float WeightFactor { get; set; }

		public FloatingPartData(XElement element)
			: base(element)
		{
			Enabled = true;
			WeightFactor = float.Parse(element.Attribute("weightFactor").Value);
			ReduceBuoyancyIfBySelf = bool.Parse(element.Attribute("reduceBuoyancyIfBySelf").Value);
			ImpactVelocityAdjustment = element.Attribute("impactVelocityAdjustment").Value;
		}

		public static AnimationCurve GetImpactVelocityAdjustmentCurve(string impactVelocityAdjustment)
		{
			AnimationCurve result = null;
			if (float.TryParse(impactVelocityAdjustment, out var result2))
			{
				result = new AnimationCurve(new Keyframe(0f, result2), new Keyframe(1f, result2));
			}
			else
			{
				if (_impactVelocityAdjustmentCurves == null)
				{
					_impactVelocityAdjustmentCurves = Resources.Load<GameObject>("Data/Water/ImpactVelocityAdjustmentCurves");
				}
				try
				{
					result = _impactVelocityAdjustmentCurves.transform.Find(impactVelocityAdjustment).GetComponent<AnimationCurveScript>().AnimationCurve;
				}
				catch (Exception)
				{
					Debug.LogError("FloatingPartModifier : Could not load impact velocity adjustment curve : " + impactVelocityAdjustment);
				}
			}
			return result;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("enabled", Enabled));
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			if (aircraftScript.LoadContext != CraftLoadContext.Flight)
			{
				return null;
			}
			Collider componentInChildren = parentGameObject.transform.GetComponentInChildren<Collider>();
			if (componentInChildren == null)
			{
				Debug.LogError($"Part with FloatingPart modifier doesn't have a collider...they need a collider:  Name: {parentGameObject.name}, Id: {parentGameObject.GetInstanceID()}");
			}
			else if (Enabled)
			{
				BuoyancyForce buoyancyForce = componentInChildren.gameObject.AddComponent<BuoyancyForce>();
				buoyancyForce.Quality = BuoyancyQuality.Low;
				buoyancyForce.UseWeighting = true;
				buoyancyForce.WeightFactor = WeightFactor;
				buoyancyForce.ImpactVelocityAdjustment = GetImpactVelocityAdjustmentCurve(ImpactVelocityAdjustment);
				buoyancyForce.ReduceBuoyancyIfBySelf = ReduceBuoyancyIfBySelf;
			}
			return null;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			Enabled = stateElement.GetBoolAttribute("enabled", defaultValue: true);
		}
	}
}
