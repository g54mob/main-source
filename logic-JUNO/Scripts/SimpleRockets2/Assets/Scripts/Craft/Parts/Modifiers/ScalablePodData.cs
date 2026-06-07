using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Parts.Modifiers.Eva;
using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
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
	[DesignerPartModifier("Pod Scale")]
	public class ScalablePodData : PartModifierData<ScalablePodScript>
	{
		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _baseScale = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _engineBurnTime = 7f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private bool _engineEnabled;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _engineIsp = 225f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _enginePrice;

		private float _engineTwr = 3f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _height = 1.27f;

		[SerializeField]
		[DesignerPropertySlider(0.75f, 1.25f, 17, Label = "Height", Order = 16, Tooltip = "How stretched the pod is in the vertical axis.")]
		private float _heightStretch = 1f;

		private float _lastScale;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _mass;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _radiusBottom = 0.8f;

		[SerializeField]
		[DesignerPropertySlider(0.5f, 2.5f, 41, Label = "Radius", Order = 15, Tooltip = "The radius of the pod base.", TechTreeIdForMaxValue = "MaxSize.Capsule")]
		private float _radiusPercent = 1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _radiusTop = 0.416f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _requiredAreaPerAstronaut = 1.5f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private Vector3 _unscaledCenterOfMass = new Vector3(0f, -0.1f, 0f);

		public bool EngineEnabled
		{
			get
			{
				return _engineEnabled;
			}
			set
			{
				_engineEnabled = value;
			}
		}

		public override float MassDry => _mass;

		public float Height => _heightStretch;

		public override long Price => Mathf.CeilToInt((float)base.Part.PartType.Price * ScaledSize * Height - (float)base.Part.PartType.Price + _enginePrice);

		public float ScaledSize => _radiusPercent * _baseScale;

		public override float Scale
		{
			get
			{
				return _radiusPercent;
			}
			set
			{
				_radiusPercent = value;
			}
		}

		public override string ScaleCareerID => "MaxSize.Capsule";

		public float TotalVolume => CalculateVolume(0f);

		public Vector3 UnscaledCenterOfMass => _unscaledCenterOfMass;

		public void UpdateOtherModifiersAndStuff()
		{
			UpdateCoM();
			float num = ScaledSize * ScaledSize * ScaledSize * Height;
			List<FuelTankData> list = new List<FuelTankData>();
			base.Part.GetModifiers(list);
			FuelTankData fuelTankData = list.FirstOrDefault((FuelTankData x) => x.FuelType == FuelType.Battery);
			fuelTankData.Capacity = 2494.8 * (double)num;
			fuelTankData.Fuel = fuelTankData.Capacity;
			base.Part.GetModifier<GyroscopeData>()?.SetBasePowerAndMass(50f * num, 0f);
			CrewCompartmentData modifier = base.Part.GetModifier<CrewCompartmentData>();
			float num2 = CalculateVolume(_radiusBottom * 0.05f);
			float num3 = CalculateVolume(0f);
			_mass = (num3 - num2) * 3000f * 0.01f;
			float num4 = 0.85f;
			float num5 = MathF.PI * Mathf.Pow(_radiusBottom * ScaledSize * num4, 2f);
			modifier.Capacity = Mathf.FloorToInt(num5 / _requiredAreaPerAstronaut);
			modifier.CrewExitPosition *= ScaledSize / _lastScale;
			_lastScale = ScaledSize;
			float num6 = modifier.Script.Crew.Count - modifier.Capacity;
			for (int num7 = 0; (float)num7 < num6; num7++)
			{
				EvaScript evaScript = modifier.Script.Crew[modifier.Script.Crew.Count - 1];
				foreach (PartConnection partConnectionsBetweenPart in PartConnection.GetPartConnectionsBetweenParts(base.Part, evaScript.PartScript.Data))
				{
					foreach (PartConnection symmetricPartConnection in Symmetry.GetSymmetricPartConnections(base.Part.PartScript, partConnectionsBetweenPart, includeSourcePart: false))
					{
						symmetricPartConnection.DestroyConnection();
					}
					partConnectionsBetweenPart.DestroyConnection();
				}
			}
			UpdateEngineConfiguration(list);
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			base.OnDesignerInitialization(d);
			d.OnValueLabelRequested(() => _radiusPercent, (float x) => $"{Utilities.FormatPercentage(x)} ({x * _radiusBottom * _baseScale:0.00}m)");
			d.OnPropertyChanged(() => _radiusPercent, delegate
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ScalablePodData modifier)
				{
					modifier.Script.UpdateScale(ScaledSize, repositionAttachedParts: true, Height);
				});
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
			d.OnValueLabelRequested(() => _heightStretch, (float x) => Utilities.FormatPercentage(x) ?? "");
			d.OnPropertyChanged(() => _heightStretch, delegate
			{
				Symmetry.SynchronizePartModifiers(base.Part.PartScript);
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ScalablePodData modifier)
				{
					modifier.Script.UpdateScale(ScaledSize, repositionAttachedParts: true, Height);
				});
				base.Script.PartScript.CraftScript.SetStructureChanged();
			});
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			_lastScale = ScaledSize;
		}

		private float CalculateVolume(float shellThickness)
		{
			float num = _radiusTop * ScaledSize - shellThickness;
			float num2 = _radiusBottom * ScaledSize - shellThickness;
			float num3 = MathF.PI * num * num;
			float num4 = MathF.PI * num2 * num2;
			float num5 = _height * ScaledSize * Height - shellThickness;
			return 1f / 3f * num5 * (num3 + num4 + Mathf.Sqrt(num3 * num4));
		}

		private void UpdateCoM()
		{
			base.Part.Config.CenterOfMass = UnscaledCenterOfMass * ScaledSize;
		}

		private void UpdateEngineConfiguration(List<FuelTankData> fuels)
		{
			FuelTankData fuelTankData = fuels.FirstOrDefault((FuelTankData x) => x.FuelType.Id == "LOX/RP1");
			EngineData modifier = base.Part.GetModifier<EngineData>();
			if (modifier != null && fuelTankData != null)
			{
				fuelTankData.Capacity = 0.0;
				fuelTankData.Fuel = 0.0;
				float engineTwr = _engineTwr;
				float engineIsp = _engineIsp;
				float engineBurnTime = _engineBurnTime;
				float num = base.Part.Mass * 100f * engineTwr / (engineIsp - engineBurnTime * engineTwr);
				float num2 = num / fuelTankData.FuelType.Density;
				float num3 = engineIsp * num * 9.80665f;
				fuelTankData.Fuel = engineBurnTime * num2;
				fuelTankData.Capacity = fuelTankData.Fuel;
				modifier.SetBaseFuelConsumption(num2);
				modifier.SetBaseThrust(num3);
				_enginePrice = num3 * 10f;
			}
			else
			{
				_enginePrice = 0f;
			}
		}
	}
}
