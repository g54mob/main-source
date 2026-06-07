using System;
using System.Collections.Generic;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Propulsion;
using ModApi.Design.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Generator")]
	public class GeneratorData : PartModifierData<GeneratorScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _baseFuelFlow = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _baseMass = 100f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _baseScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _consumptionOverride = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _costPerWatt = 1500000f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _efficiency = 0.3f;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 1f, 20, Label = "Power Generation", Tooltip = "Allows increasing the maximum power of the generator.")]
		private float _fuelConsumptionScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _fuelSourceAttachPoint;

		[SerializeField]
		[DesignerPropertySpinner(Label = "Fuel Type", Order = 2, Tooltip = "The type of fuel stored in this fuel tank.")]
		private string _fuelType = "LOX/RP1";

		private FuelType _fuelTypeModifier;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _generationOverride = 1f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Hide Base", Order = 12, Tooltip = "Toggles the RTG base on/off.")]
		private bool _hideBase;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Size", Tooltip = "Defines the scale of the generator.")]
		private float _scale = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 2f, 41, Label = "Length", Tooltip = "Stretches the RTG to change its length.")]
		private float _stretch = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 21, Label = "Sound", Tooltip = "Changes how loud the part is.")]
		private float _soundVolume = -1f;

		public float FuelFlow => _baseFuelFlow * Scale * Scale * (1f + Stretch) * ((base.Version == 1) ? Scale : 1f) * ((base.Version < 3) ? 0.001f : 1f);

		public float FuelConsumptionScale => _fuelConsumptionScale;

		public int FuelSourceAttachPoint => _fuelSourceAttachPoint;

		public FuelType FuelType
		{
			get
			{
				if (_consumptionOverride != 0f)
				{
					return _fuelTypeModifier;
				}
				return null;
			}
			private set
			{
				_fuelTypeModifier = value;
			}
		}

		public bool HideBase => _hideBase;

		public override float MassDry => _baseMass * Scale * Scale * Scale * (1f + Stretch) * 0.01f;

		public override long Price => (long)(MaxPowerGenerated(FuelFlow) * _costPerWatt);

		public override float Scale
		{
			get
			{
				return _scale * _baseScale;
			}
			set
			{
				_scale = value;
				base.Script.UpdateScale();
			}
		}

		public float Stretch => _stretch;

		public float SoundVolume => _soundVolume;

		public float MaxPowerGenerated(float fuelAmount)
		{
			float num = ((FuelType == null) ? 1f : (FuelType.Density * FuelType.Gamma * FuelType.CombustionTemperature));
			return fuelAmount * _generationOverride * _efficiency * num * 1000f;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnVisibilityRequested(() => _fuelConsumptionScale, (bool x) => _consumptionOverride != 0f);
			d.OnVisibilityRequested(() => _fuelType, (bool x) => _consumptionOverride != 0f);
			d.OnVisibilityRequested(() => _stretch, (bool x) => base.Part.PartType.Id == "Generator2");
			d.OnVisibilityRequested(() => _hideBase, (bool x) => base.Part.PartType.Id == "Generator2");
			d.OnVisibilityRequested(() => _soundVolume, (bool x) => _soundVolume >= 0f);
			d.OnValueLabelRequested(() => _fuelConsumptionScale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _scale, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _stretch, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _soundVolume, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _fuelType, (string x) => FuelType?.Name ?? string.Empty);
			d.OnSpinnerValuesRequested(() => _fuelType, GetSpinnerValues);
			d.OnPropertyChanged(() => _fuelConsumptionScale, delegate
			{
				OnFuelConsumptionChanged();
			});
			d.OnPropertyChanged(() => _fuelType, delegate
			{
				OnPropertyChangedInDesigner(updateFuelType: true);
			});
			d.OnPropertyChanged(() => _scale, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateScale();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnPropertyChanged(() => _stretch, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateStretch();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnPropertyChanged(() => _hideBase, delegate
			{
				d.Manager.RefreshUI();
				base.Script.UpdateBase();
				Symmetry.SynchronizePartModifiers(base.Script.PartScript);
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			UpdateFuelType();
		}

		private void GetSpinnerValues(List<string> fuelTypes)
		{
			fuelTypes.Clear();
			foreach (FuelType fuel in Game.Instance.PropulsionData.Fuels)
			{
				if (fuel.DisplayInDesigner && fuel.CombustionTemperature > 2500f && fuel.ExplosivePower > 0f)
				{
					fuelTypes.Add(fuel.Id);
				}
			}
		}

		private void OnFuelConsumptionChanged()
		{
			Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}

		private void OnPropertyChangedInDesigner(bool updateFuelType)
		{
			Symmetry.SynchronizePartModifiers(base.Part.PartScript);
			if (updateFuelType)
			{
				UpdateFuelType();
			}
			base.Part.PartScript.CraftScript.SetStructureChanged();
		}

		private void UpdateFuelType()
		{
			FuelType = Game.Instance.PropulsionData.GetFuelType(_fuelType);
		}
	}
}
