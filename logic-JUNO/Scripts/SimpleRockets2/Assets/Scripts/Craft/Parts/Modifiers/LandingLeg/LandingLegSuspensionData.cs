using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.LandingLeg
{
	[Serializable]
	[DesignerPartModifier("Landing Leg Suspension")]
	[PartModifierTypeId("LandingLegSuspension")]
	public class LandingLegSuspensionData : PartModifierData<LandingLegSuspensionScript>
	{
		public enum LandingLegSuspensionType
		{
			Auto = 0,
			Manual = 1,
			Rigid = 2
		}

		[SerializeField]
		[DesignerPropertySlider(0.25f, 5f, 96, Label = "Damper", Order = 15, Tooltip = "Higher damper settings can help to reduce oscillation. Lower damper settings allow more oscillation.")]
		private float _damper = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _maxSuspensionDistance = 1.5f;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 1f, 19, Label = "Length", Order = 1, PreserveStateMode = PartModifierPropertyStatePreservationMode.SaveAlways, Tooltip = "Changes the length of the suspension.")]
		private float _maxSuspensionScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _minSuspensionDistance;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 5f, 96, Label = "Suspension Strength", Order = 10, Tooltip = "Changes the strength of the spring force in the suspension.")]
		private float _spring = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _suspensionCompression;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _suspensionDistance;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Suspension Type", Order = 5, Tooltip = "Auto will automatically configure the spring strength to target the specified level of compression. Manual allows setting the spring strength directly. Rigid has no spring suspension.")]
		private LandingLegSuspensionType _suspensionType;

		[SerializeField]
		[DesignerPropertySlider(0.15f, 0.5f, 46, Label = "Target Compression", Order = 10, Tooltip = "The amount of compression to target. Lower values for a stiffer suspension and higher values for a softer suspension.")]
		private float _targetCompression = 0.25f;

		public float Damper => _damper;

		public float MaxSuspensionDistance => _minSuspensionDistance + (_maxSuspensionDistance - _minSuspensionDistance) * _maxSuspensionScale;

		public float MinSuspensionDistance => _minSuspensionDistance;

		public float Spring => _spring;

		public float SuspensionCompression
		{
			get
			{
				return _suspensionCompression;
			}
			set
			{
				_suspensionCompression = value;
			}
		}

		public float SuspensionDistance
		{
			get
			{
				return _suspensionDistance;
			}
			set
			{
				_suspensionDistance = value;
			}
		}

		public LandingLegSuspensionType SuspensionType => _suspensionType;

		public float TargetCompression => _targetCompression;

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _maxSuspensionScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _damper, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _spring, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _targetCompression, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _maxSuspensionScale, delegate
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			});
			d.OnVisibilityRequested(() => _spring, (bool x) => _suspensionType == LandingLegSuspensionType.Manual);
			d.OnVisibilityRequested(() => _damper, (bool x) => _suspensionType != LandingLegSuspensionType.Rigid);
			d.OnVisibilityRequested(() => _targetCompression, (bool x) => _suspensionType == LandingLegSuspensionType.Auto);
		}
	}
}
