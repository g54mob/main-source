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
	public class ReactionControlNozzleData : PartModifierData<ReactionControlNozzleScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _fuelConsumptionRate = 0.4f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Manual Input", Order = 3, Tooltip = "Determines if the rcn uses an Input Controller to determine its throttle or does it automatically.")]
		private bool _manualInput;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Gimbaled", Order = 4, Tooltip = "Determines if the rcn includes a gimbal.")]
		private bool _multiDirection;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _power = 10000f;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 1f, 37, Order = 2, Label = "Power", Tooltip = "Changes the power of the nozzle and its fuel usage.")]
		private float _powerScale = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Order = 1, Label = "Size", Tooltip = "Changes the overall size of the RCS, affecting its max thrust, price and mass.", TechTreeIdForMaxValue = "MaxSize.RCS")]
		private float _scale = 1f;

		public float FuelConsumptionRate => _fuelConsumptionRate * _powerScale * _scale;

		public bool ManualInput => _manualInput;

		public bool MultiDirection => _multiDirection;

		public override long Price => (long)(100000f * _scale * _scale * Mathf.Lerp(0.2f, 1f, _powerScale) * (_multiDirection ? 4f : 1f));

		public override float MassDry => _scale * _scale * _scale * (_multiDirection ? 50f : 10f) * 0.01f;

		public float Power => _power * _powerScale * _scale * 0.01f;

		public override float Scale
		{
			get
			{
				return _scale;
			}
			set
			{
				_scale = value;
			}
		}

		public override string ScaleCareerID => "MaxSize.RCS";

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _powerScale, (float x) => $"{x * 100f:n0}%");
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnVisibilityRequested(() => _multiDirection, (bool x) => base.Part.PartType.Id == "RCSNozzle2");
			d.OnPropertyChanged(() => _scale, delegate
			{
				base.Script.UpdateScale();
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				d.Manager.RefreshUI();
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnPropertyChanged(() => _powerScale, delegate
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				d.Manager.RefreshUI();
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnPropertyChanged(() => _manualInput, delegate
			{
				base.Script.VisibilityThrottle(_manualInput);
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				d.Manager.Flyout.RefreshUI();
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				d.Manager.Flyout.RefreshUI();
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnActivated(delegate
			{
				base.Script.ToggleParticles(active: true);
			});
			d.OnDeactivated(delegate
			{
				if (!base.Part.IsDestroyed)
				{
					base.Script.ToggleParticles(active: false);
				}
			});
		}
	}
}
