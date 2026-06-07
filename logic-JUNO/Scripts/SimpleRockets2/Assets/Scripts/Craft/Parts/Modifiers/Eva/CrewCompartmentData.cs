using System;
using Assets.Scripts.Design.PartProperties;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Eva
{
	[Serializable]
	[DesignerPartModifier("Crew Compartment", typeof(CrewCompartmentPartProperties))]
	[PartModifierTypeId("CrewCompartment")]
	public class CrewCompartmentData : PartModifierData<CrewCompartmentScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _capacity = 3;

		[SerializeField]
		[DesignerPropertyLabel]
		private string _capacityLabel = string.Empty;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _commandPodEnabledInCompartment;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _crewExitPosition = Vector3.zero;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _crewExitRotation = Vector3.zero;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxPressure = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _minPressure = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _visibleInCompartment;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _volumePerIndividual = 3f;

		public int Capacity
		{
			get
			{
				return _capacity;
			}
			set
			{
				_capacity = value;
			}
		}

		public bool CommandPodEnabledInCompartment
		{
			get
			{
				return _commandPodEnabledInCompartment;
			}
			set
			{
				_commandPodEnabledInCompartment = value;
			}
		}

		public Vector3 CrewExitPosition
		{
			get
			{
				return _crewExitPosition;
			}
			set
			{
				_crewExitPosition = value;
			}
		}

		public Vector3 CrewExitRotation
		{
			get
			{
				return _crewExitRotation;
			}
			set
			{
				_crewExitRotation = value;
			}
		}

		public float MaxPressure => _maxPressure;

		public float MinPressure => _minPressure;

		public float Radius => CrewExitPosition.magnitude;

		public bool VisibleInCompartment
		{
			get
			{
				return _visibleInCompartment;
			}
			set
			{
				_visibleInCompartment = value;
			}
		}

		public float VolumePerIndividual
		{
			get
			{
				return _volumePerIndividual;
			}
			set
			{
				_volumePerIndividual = value;
			}
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnValueLabelRequested(() => _capacityLabel, (string x) => $"Capacity: {_capacity}, Available: {_capacity - base.Script.Crew.Count}");
		}
	}
}
