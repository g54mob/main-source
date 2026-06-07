using System;
using System.Collections.Generic;
using Assets.Scripts.Design;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Craft.Parts.Styles;
using ModApi.Design.PartProperties;
using ModApi.Math;
using ModApi.Planet;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Serializable]
	[DesignerPartModifier("Parachute")]
	public class ParachuteData : PartModifierData<ParachuteScript>
	{
		[SerializeField]
		[DesignerPropertyToggleButton(Label = "ASL Based Triggers", Order = 100, Tooltip = "Determines if the parachute triggers are altitude (enabled) or atmosphere density (disabled) based.")]
		private bool _aslBased;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _autocutASL = -1f;

		[SerializeField]
		[DesignerPropertySlider(1f, 0.01f, 100, Label = "Auto-cut Air Density", Order = 17, Tooltip = "Changes the density at which the parachute is automatically cut.")]
		private float _autocutDensity;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 76, Label = "Base Size", Order = 10, Tooltip = "Changes the scale of the parachute base.", TechTreeIdForMaxValue = "MaxSize.Parachute")]
		private float _baseSize = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 1f, 25, Label = "Parachute Height", Order = 12, Tooltip = "Changes the curvature of the parachute.")]
		private float _chuteHeight = 1f;

		[SerializeField]
		[DesignerPropertySlider(2f, 10f, 61, Label = "Inflated Radius", Order = 13, Tooltip = "Changes the radius of the parachute.", TechTreeIdForMaxValue = "Chute.Radius")]
		private float _chuteRadius = 4f;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 1f, 61, Label = "Deflated Radius", Order = 14, Tooltip = "Changes the radius the parachute will have after being deployed while it isn't inflated.")]
		private float _chuteRadiusDeflated = 0.2f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 10f, 77, Label = "Cord Length", Order = 11, Tooltip = "Changes the length of the parachute cord.", TechTreeIdForMaxValue = "Chute.Length")]
		private float _cordLength = 2f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _deploymentASL = -1f;

		[SerializeField]
		[DesignerPropertySlider(1f, 0.01f, 100, Label = "Deployment Air Density", Order = 15, Tooltip = "Changes the density at which the parachute is allowed to be deployed.")]
		private float _deploymentDensity = 0.5f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _inflationASL = -1f;

		[SerializeField]
		[DesignerPropertySlider(1f, 0.01f, 100, Label = "Inflation Air Density", Order = 16, Tooltip = "Changes the density at which the parachute is inflated to its full size.")]
		private float _inflationDensity = 0.5f;

		[SerializeField]
		[DesignerPropertySlider(0f, 3000f, 76, Label = "Max Deployment Speed", Order = 18, Tooltip = "Defines the max speed at which parachutes can be deployed.")]
		private float _maxDeploymentSpeed = 1000f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _referenceDensity;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _snapThresholdMultiplier = 1f;

		public float ASLDeployment
		{
			get
			{
				if (Game.InDesignerScene && !_aslBased)
				{
					AtmosphereSample atmosphereSample = Game.Instance.Designer.PerformanceAnalysis.AtmosphereSample;
					if (atmosphereSample.SurfaceAirDensity > 0.0)
					{
						_deploymentASL = (float)PlanetAtmosphereData.CalculateAtmosphereHeight(atmosphereSample.ScaleHeight, ReferenceDensity, _deploymentDensity);
					}
				}
				if (!_aslBased && !Game.InDesignerScene)
				{
					return -1f;
				}
				return _deploymentASL;
			}
		}

		public float ASLInflation
		{
			get
			{
				if (Game.InDesignerScene && !_aslBased)
				{
					AtmosphereSample atmosphereSample = Game.Instance.Designer.PerformanceAnalysis.AtmosphereSample;
					if (atmosphereSample.SurfaceAirDensity > 0.0)
					{
						_inflationASL = (float)PlanetAtmosphereData.CalculateAtmosphereHeight(atmosphereSample.ScaleHeight, ReferenceDensity, _inflationDensity);
					}
				}
				if (!_aslBased && !Game.InDesignerScene)
				{
					return -1f;
				}
				return _inflationASL;
			}
		}

		public float ASLCut
		{
			get
			{
				if (Game.InDesignerScene && !_aslBased)
				{
					if (_autocutDensity == 1f)
					{
						_autocutASL = -1f;
					}
					else
					{
						AtmosphereSample atmosphereSample = Game.Instance.Designer.PerformanceAnalysis.AtmosphereSample;
						if (atmosphereSample.SurfaceAirDensity > 0.0)
						{
							_autocutASL = (float)PlanetAtmosphereData.CalculateAtmosphereHeight(atmosphereSample.ScaleHeight, ReferenceDensity, _autocutDensity);
						}
					}
				}
				if ((!_aslBased && !Game.InDesignerScene) || !((double)_autocutDensity < 1.0))
				{
					return -1f;
				}
				return _autocutASL;
			}
		}

		public float ChuteHeight => _chuteHeight * ChuteRadius;

		public float ChuteRadius => _chuteRadius * 0.285f;

		public float ChuteRadiusDeflated => Mathf.Clamp01(_chuteRadiusDeflated);

		public float CordLength => _cordLength;

		public float CutDensity
		{
			get
			{
				if (!(ReferenceDensity < 0f))
				{
					if (_autocutDensity != 1f)
					{
						return Mathf.Max(_autocutDensity * ReferenceDensity, InflationDensity);
					}
					return 1000000f * ReferenceDensity;
				}
				return -1f;
			}
		}

		public float DeploymentDensity
		{
			get
			{
				if (!(ReferenceDensity < 0f))
				{
					return _deploymentDensity * ReferenceDensity;
				}
				return -1f;
			}
		}

		public float Drag => 30f;

		public float InflationDensity
		{
			get
			{
				if (!(ReferenceDensity < 0f))
				{
					return Mathf.Max(_inflationDensity, _deploymentDensity) * ReferenceDensity;
				}
				return -1f;
			}
		}

		public override float MassDry => (_chuteRadius * _chuteRadius * 5f + _baseSize * 70f) * _baseSize * _baseSize * 0.01f;

		public float MaxDeploymentSpeed => _maxDeploymentSpeed;

		public override long Price => Mathf.RoundToInt(_chuteRadius * _chuteRadius * _baseSize * _baseSize * 1000f);

		public float ReferenceDensity
		{
			get
			{
				_referenceDensity = (float)(Game.Instance.Designer?.PerformanceAnalysis?.AtmosphereSample.SurfaceAirDensity ?? ((double)_referenceDensity));
				return _referenceDensity;
			}
		}

		public override float Scale
		{
			get
			{
				return _baseSize;
			}
			set
			{
				_baseSize = value;
			}
		}

		public override string ScaleCareerID => "MaxSize.Parachute";

		public float SnapThresholdMultiplier => _snapThresholdMultiplier;

		public float CalculateChuteArea()
		{
			return MathF.PI * (ChuteRadius * ChuteRadius * Scale * Scale);
		}

		public string GetStyleMeshName()
		{
			IReadOnlyList<PartStyleData> styles = base.Part.Styles;
			if (styles.Count < 2)
			{
				return "ParachuteStripedHorizontal";
			}
			return styles[1].Style.Id;
		}

		public void RefreshPartProperties()
		{
			double scaleHeight = Game.Instance.Designer.PerformanceAnalysis?.AtmosphereSample.ScaleHeight ?? 1.0;
			if (_deploymentASL < 0f || _inflationASL < 0f || _autocutASL < 0f)
			{
				_deploymentASL = (float)PlanetAtmosphereData.CalculateAtmosphereHeight(scaleHeight, ReferenceDensity, _deploymentDensity);
				_inflationASL = (float)PlanetAtmosphereData.CalculateAtmosphereHeight(scaleHeight, ReferenceDensity, _inflationDensity);
				_autocutASL = (float)PlanetAtmosphereData.CalculateAtmosphereHeight(scaleHeight, ReferenceDensity, _autocutDensity);
			}
			else if (_aslBased)
			{
				double num = Game.Instance.Designer.PerformanceAnalysis?.AtmosphereSample.SurfaceAirDensity ?? 1.0;
				if (num > 0.0)
				{
					_deploymentDensity = (float)(PlanetAtmosphereData.CalculateAirDensity(_deploymentASL, scaleHeight, num) / num);
					_inflationDensity = (float)(PlanetAtmosphereData.CalculateAirDensity(_inflationASL, scaleHeight, num) / num);
					_autocutDensity = (float)(PlanetAtmosphereData.CalculateAirDensity(_autocutASL, scaleHeight, num) / num);
				}
			}
			base.DesignerPartProperties?.Manager?.RefreshUI();
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			d.OnValueLabelRequested(() => _deploymentDensity, (float x) => (_aslBased ? string.Empty : (Math.Round(ReferenceDensity * x, 2) + "kg/m3 | ")) + Units.GetDistanceString(Math.Max(0, (int)ASLDeployment)));
			d.OnValueLabelRequested(() => _inflationDensity, (float x) => (_aslBased ? string.Empty : (Math.Round(InflationDensity, 2) + "kg/m3 | ")) + Units.GetDistanceString(Math.Max(0, (int)ASLInflation)));
			d.OnValueLabelRequested(() => _autocutDensity, (float x) => (_autocutDensity != 1f) ? ((_aslBased ? string.Empty : (Math.Round(CutDensity, 2) + "kg/m3 | ")) + Units.GetDistanceString(Math.Max(0f, _autocutASL))) : "Disabled");
			d.OnValueLabelRequested(() => _maxDeploymentSpeed, (float x) => (int)x + "m/s");
			d.OnValueLabelRequested(() => _cordLength, (float x) => Math.Round(5f * _cordLength * _baseSize, 2) + "m");
			d.OnVisibilityRequested(() => _aslBased, (bool x) => true);
			d.OnValueLabelRequested(() => _baseSize, (float x) => Utilities.FormatPercentage(x));
			d.OnValueLabelRequested(() => _chuteRadius, (float x) => Math.Round(_chuteRadius * _baseSize, 2) + "m");
			d.OnValueLabelRequested(() => _chuteRadiusDeflated, (float x) => Math.Round(_chuteRadiusDeflated * _chuteRadius * _baseSize, 2) + "m");
			d.OnValueLabelRequested(() => _chuteHeight, (float x) => Math.Round(_chuteHeight * _baseSize, 2) + "m");
			d.OnPropertyChanged(() => _baseSize, delegate
			{
				d.Manager.RefreshUI();
				UpdateScaleProperty();
			});
			d.OnPropertyChanged(() => _cordLength, delegate
			{
				UpdateScaleProperty();
			});
			d.OnPropertyChanged(() => _chuteHeight, delegate
			{
				UpdateScaleProperty();
			});
			d.OnPropertyChanged(() => _chuteRadius, delegate
			{
				d.Manager.RefreshUI();
				UpdateScaleProperty();
			});
			d.OnPropertyChanged(() => _autocutDensity, delegate
			{
				_autocutDensity = Mathf.Max(_inflationDensity, _autocutDensity);
				_ = ASLCut;
				d.Manager.RefreshUI();
			});
			d.OnPropertyChanged(() => _inflationDensity, delegate
			{
				_ = ReferenceDensity;
				_inflationDensity = Mathf.Max(_deploymentDensity, _inflationDensity);
				_autocutDensity = Mathf.Max(_inflationDensity, _autocutDensity);
				d.Manager.RefreshUI();
			});
			d.OnPropertyChanged(() => _deploymentDensity, delegate
			{
				_ = ReferenceDensity;
				_inflationDensity = Mathf.Max(_deploymentDensity, _inflationDensity);
				_autocutDensity = Mathf.Max(_inflationDensity, _autocutDensity);
				d.Manager.RefreshUI();
			});
			d.OnPropertyChanged(() => _maxDeploymentSpeed, delegate
			{
				_ = ReferenceDensity;
				d.Manager.RefreshUI();
			});
			d.OnPartStyleChanged(delegate
			{
				UpdateScaleProperty();
			});
			d.OnActivated(delegate
			{
				Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ParachuteData x)
				{
					x.Script.ShowParachute(active: true);
				});
				base.Part.PartScript.CraftScript.SetStructureChanged();
				base.Script.UpdateDensity = true;
			});
			d.OnDeactivated(delegate
			{
				base.Script.UpdateDensity = false;
				if (!base.Part.IsDestroyed)
				{
					Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ParachuteData x)
					{
						x.Script.ShowParachute(active: false);
					});
					base.Part.PartScript.CraftScript.SetStructureChanged();
				}
			});
		}

		private void UpdateScaleProperty()
		{
			Symmetry.SynchronizePartModifiers(base.Script.PartScript);
			Symmetry.ExecuteOnSymmetricPartModifiers(this, includeSourceModifier: true, delegate(ParachuteData m)
			{
				m.Script.RebuildChute();
			});
			base.Part.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
