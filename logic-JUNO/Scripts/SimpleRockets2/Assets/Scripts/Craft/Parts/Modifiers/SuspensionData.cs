using System;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Suspension", PanelOrder = 2000)]
	public class SuspensionData : PartModifierData<SuspensionScript>
	{
		private const float DefaultDamper = 1f;

		private const float DefaultSpring = 1f;

		private const float Density = 1550f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Damper", Order = 4, Tooltip = "Higher damper settings can help to reduce oscillation. Lower damper settings allow more oscillation.")]
		private float _damper = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _preventBreaking;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Order = 1, Tooltip = "Changes the overall size of the shock.", TechTreeIdForMaxValue = "MaxSize.Shock")]
		private float _size = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 2.5f, 25, Label = "Spring Strength", Order = 3, Tooltip = "Changes the strength of the spring.")]
		private float _spring = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 21, Label = "Thickness", Order = 2, Tooltip = "Changes the thickness of the part.")]
		private float _thickness = 1f;

		public int AttachPointIndex { get; set; }

		public float Damper => _damper;

		public override float MassDry => ((float)((base.Version == 1) ? 25 : 0) + CalculateVolume() * 1550f) * 0.01f;

		public bool PreventBreaking => _preventBreaking;

		public override long Price => (long)(1000f * _size * _thickness * _thickness);

		public override float Scale
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
				base.Script?.UpdateScale(repositionAttachedParts: true);
			}
		}

		public override string ScaleCareerID => "MaxSize.Shock";

		public Vector3 Size => new Vector3(_size * _thickness, _size, _size * _thickness);

		public float Spring => _spring;

		public float Thickness
		{
			get
			{
				return _thickness;
			}
			private set
			{
				_thickness = value;
				base.Script?.UpdateScale();
			}
		}

		public float CalculateVolume()
		{
			float num = 0.5f * _size;
			float num2 = 0.05f * _size * Thickness;
			return MathF.PI * (num2 * num2) * num;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _damper, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _spring, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _size, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _thickness, (float x) => Utilities.FormatPercentage(x));
			d.OnPropertyChanged(() => _size, delegate
			{
				DesignerScaleChanged();
			});
			d.OnPropertyChanged(() => _thickness, delegate
			{
				DesignerScaleChanged();
			});
		}

		private void DesignerScaleChanged()
		{
			base.Script?.UpdateScale(repositionAttachedParts: true);
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
