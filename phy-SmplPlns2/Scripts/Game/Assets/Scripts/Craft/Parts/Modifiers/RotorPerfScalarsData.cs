using System.Xml.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.BladedEngineScripts;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Advanced Performance Scalars")]
	public class RotorPerfScalarsData : PartModifierData
	{
		[DesignerPropertySlider(0f, 4f, 21, Label = "Collective Drag")]
		private float _collectiveDrag = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Collective Torque")]
		private float _collectiveTorque = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Cyclic Motor Drag")]
		private float _cyclicMotorDragTorque = 1f;

		[DesignerPropertySlider(0f, 2f, 21, Label = "Cyclic Pitch Expo")]
		private float _cyclicPitchInputExpo = 1f;

		[DesignerPropertySlider(0f, 2f, 21, Label = "Cyclic Roll Expo")]
		private float _cyclicRollInputExpo = 1f;

		[DesignerPropertySlider(0f, 2f, 21, Label = "Cyclic RPM Falloff Expo")]
		private float _cyclicRpmFalloffExpo = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Cyclic Strength")]
		private float _cyclicStrength = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Ground Effect")]
		private float _groundEffect = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Gyroscopic Lag")]
		private float _gyroscopicLag = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Gyroscopic Stability")]
		private float _gyroscopicStabilization = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Rel Wind Lift")]
		private float _relativeWindPassiveLift = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Rel Wind Motor Torque")]
		private float _relativeWindPassiveTorque = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Rel Wind - Peak Speed")]
		private float _relativeWindPeakSpeed = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Rotor Tensor")]
		private float _rotorTensor = 1f;

		[DesignerPropertySlider(0f, 4f, 21, Label = "Translational Lift")]
		private float _translationalLift = 1f;

		public float CollectiveDrag
		{
			get
			{
				return _collectiveDrag;
			}
			internal set
			{
				_collectiveDrag = value;
			}
		}

		public float CollectiveLift { get; internal set; } = 1f;

		public float CollectiveTorque
		{
			get
			{
				return _collectiveTorque;
			}
			internal set
			{
				_collectiveTorque = value;
			}
		}

		public float CyclicMotorDragTorque
		{
			get
			{
				return _cyclicMotorDragTorque;
			}
			internal set
			{
				_cyclicMotorDragTorque = value;
			}
		}

		public float CyclicPitchInputExpo
		{
			get
			{
				return _cyclicPitchInputExpo;
			}
			internal set
			{
				_cyclicPitchInputExpo = value;
			}
		}

		public float CyclicRollInputExpo
		{
			get
			{
				return _cyclicRollInputExpo;
			}
			internal set
			{
				_cyclicRollInputExpo = value;
			}
		}

		public float CyclicRpmFalloffExpo
		{
			get
			{
				return _cyclicRpmFalloffExpo;
			}
			internal set
			{
				_cyclicRpmFalloffExpo = value;
			}
		}

		public float CyclicStrength
		{
			get
			{
				return _cyclicStrength;
			}
			internal set
			{
				_cyclicStrength = value;
			}
		}

		public float GroundEffect
		{
			get
			{
				return _groundEffect;
			}
			internal set
			{
				_groundEffect = value;
			}
		}

		public float GyroscopicLag
		{
			get
			{
				return _gyroscopicLag;
			}
			set
			{
				_gyroscopicLag = value;
			}
		}

		public float GyroscopicStabilization
		{
			get
			{
				return _gyroscopicStabilization;
			}
			internal set
			{
				_gyroscopicStabilization = value;
			}
		}

		public float RelativeWindPassiveLift
		{
			get
			{
				return _relativeWindPassiveLift;
			}
			internal set
			{
				_relativeWindPassiveLift = value;
			}
		}

		public float RelativeWindPassiveTorque
		{
			get
			{
				return _relativeWindPassiveTorque;
			}
			internal set
			{
				_relativeWindPassiveTorque = value;
			}
		}

		public float RelativeWindPeakSpeed
		{
			get
			{
				return _relativeWindPeakSpeed;
			}
			internal set
			{
				_relativeWindPeakSpeed = value;
			}
		}

		public float RotorTensor
		{
			get
			{
				return _rotorTensor;
			}
			internal set
			{
				_rotorTensor = value;
			}
		}

		public float TranslationalLift
		{
			get
			{
				return _translationalLift;
			}
			internal set
			{
				_translationalLift = value;
			}
		}

		public RotorPerfScalarsData(XElement element)
			: base(element)
		{
		}

		public RotorPerfScalarsData()
			: base(null)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("collectiveDrag", CollectiveDrag.ToString()), new XAttribute("collectiveLift", CollectiveLift.ToString()), new XAttribute("collectiveTorque", CollectiveTorque.ToString()), new XAttribute("cyclicMotorDragTorque", CyclicMotorDragTorque.ToString()), new XAttribute("cyclicPitchInputExpo", CyclicPitchInputExpo.ToString()), new XAttribute("cyclicRollInputExpo", CyclicRollInputExpo.ToString()), new XAttribute("cyclicRpmFalloffExpo", CyclicRpmFalloffExpo.ToString()), new XAttribute("cyclicStrength", CyclicStrength.ToString()), new XAttribute("groundEffect", GroundEffect.ToString()), new XAttribute("gyroscopicLag", GyroscopicLag.ToString()), new XAttribute("gyroscopicStabilization", GyroscopicStabilization.ToString()), new XAttribute("relativeWindPassiveLift", RelativeWindPassiveLift.ToString()), new XAttribute("relativeWindPassiveTorque", RelativeWindPassiveTorque.ToString()), new XAttribute("relativeWindPeakSpeed", RelativeWindPeakSpeed.ToString()), new XAttribute("rotorTensor", RotorTensor.ToString()), new XAttribute("translationalLift", TranslationalLift.ToString()));
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			RotorPerfScalarsScript rotorPerfScalarsScript = parentGameObject.GetComponentInChildren<HeliMainRotorScript>().gameObject.AddComponent<RotorPerfScalarsScript>();
			rotorPerfScalarsScript.OnModifierInitialized(this);
			return rotorPerfScalarsScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			CollectiveDrag = stateElement.GetFloatAttribute("collectiveDrag", 1f);
			CollectiveLift = stateElement.GetFloatAttribute("collectiveLift", 1f);
			CollectiveTorque = stateElement.GetFloatAttribute("collectiveTorque", 1f);
			CyclicMotorDragTorque = stateElement.GetFloatAttribute("cyclicMotorDragTorque", 1f);
			CyclicPitchInputExpo = stateElement.GetFloatAttribute("cyclicPitchInputExpo", 1f);
			CyclicRollInputExpo = stateElement.GetFloatAttribute("cyclicRollInputExpo", 1f);
			CyclicRpmFalloffExpo = stateElement.GetFloatAttribute("cyclicRpmFalloffExpo", 1f);
			CyclicStrength = stateElement.GetFloatAttribute("cyclicStrength", 1f);
			GroundEffect = stateElement.GetFloatAttribute("groundEffect", 1f);
			GyroscopicLag = stateElement.GetFloatAttribute("gyroscopicLag", 1f);
			GyroscopicStabilization = stateElement.GetFloatAttribute("gyroscopicStabilization", 1f);
			RelativeWindPassiveLift = stateElement.GetFloatAttribute("relativeWindPassiveLift", 1f);
			RelativeWindPassiveTorque = stateElement.GetFloatAttribute("relativeWindPassiveTorque", 1f);
			RelativeWindPeakSpeed = stateElement.GetFloatAttribute("relativeWindPeakSpeed", 1f);
			RotorTensor = stateElement.GetFloatAttribute("rotorTensor", 1f);
			TranslationalLift = stateElement.GetFloatAttribute("translationalLift", 1f);
		}
	}
}
