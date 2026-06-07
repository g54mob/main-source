using System;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Attributes;
using ModApi.Design.PartProperties;
using ModApi.Math;
using ModApi.Scripts.State.Validation;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	[Serializable]
	[DesignerPartModifier("Jet Engine")]
	public class JetEngineData : PartModifierData<JetEngineScript>
	{
		public const float MinBypassRatio = 0f;

		public const float MinCompressionRatio = 1f;

		[SerializeField]
		[DesignerPropertySlider(0f, 0.95f, 20, Label = "Afterburner Throttle", Order = 6, Tooltip = "This is the throttle at which the afterburner will kick in.")]
		private float _afterburnerThrottleStart = 0.8f;

		[SerializeField]
		[DesignerPropertySlider(0f, 7f, 141, Label = "Bypass Ratio", Order = 2, Tooltip = "The amount of air that bypasses the core. This can greatly increase fuel efficiency. All the cool engineers are doing it these days.", TechTreeIdForMaxValue = "JetEngine.BypassRatio")]
		private float _bypassRatio = 0.5f;

		[SerializeField]
		[DesignerPropertySlider(1f, 30f, 59, Label = "Compression Ratio", Order = 3, Tooltip = "Increasing compression can increase fuel efficiency (and thrust up to a point), but also increases the length and weight of the core.", TechTreeIdForMaxValue = "JetEngine.CompressionRatio")]
		private float _compressionRatio = 7f;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Afterburner", Order = 5, Tooltip = "It greatly increases the power of the engine but it decreases efficiency.")]
		private bool _hasAfterburner;

		[SerializeField]
		[DesignerPropertyToggleButton(Label = "Reverse Thrust", Order = 4, Tooltip = "Allows the engine to push air forward to slow down the craft.")]
		private bool _hasReverseThrust = true;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _mass;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _overrideAfterBurnerTemp = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _overrideBurnerTemp = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private float _overrideFanPressureRatio = -1f;

		[SerializeField]
		[PartModifierProperty(true, false)]
		private int _price;

		[SerializeField]
		[DesignerPropertySlider(0f, 1f, 101, Label = "Shroud Curvature", Order = 5, Tooltip = "The amount of curvature the shroud should use. Only usable with a non-zero bypass ratio. This is cosmetic only and does not affect performance.")]
		private float _shroudCurvature = 0.6f;

		[SerializeField]
		[DesignerPropertySlider(0.1f, 1.5f, 141, Label = "Shroud Length", Order = 5, Tooltip = "The length of the shroud. This is cosmetic only and does not affect performance.")]
		private float _shroudLength = 1f;

		[SerializeField]
		[DesignerPropertySlider(0.25f, 4f, 251, Label = "Size", Order = 1, Tooltip = "Changes the overall size of the jet engine.", TechTreeIdForMaxValue = "MaxSize.JetEngine")]
		private float _size = 1f;

		public float AfterburnerThrottleStart => _afterburnerThrottleStart;

		public float BypassRatio
		{
			get
			{
				return _bypassRatio;
			}
			set
			{
				_bypassRatio = value;
			}
		}

		public float CompressionRatio
		{
			get
			{
				return _compressionRatio;
			}
			set
			{
				_compressionRatio = value;
			}
		}

		public float CompressorLength => _compressionRatio * 0.1f + 0.1f;

		public float CoreRadius => Mathf.Sqrt(FanRadius * FanRadius / (BypassRatio + 1f));

		public float FanArea => MathF.PI * FanRadius * FanRadius;

		public float FanRadius => _size * 0.5f;

		public bool HasAfterburner
		{
			get
			{
				return _hasAfterburner;
			}
			set
			{
				_hasAfterburner = value;
			}
		}

		public bool HasReverseThrust
		{
			get
			{
				return _hasReverseThrust;
			}
			set
			{
				_hasReverseThrust = value;
			}
		}

		public override float MassDry => _mass;

		public float OverrideAfterBurnerTemp => _overrideAfterBurnerTemp;

		public float OverrideBurnerTemp => _overrideBurnerTemp;

		public float OverrideFanPressureRatio => _overrideFanPressureRatio;

		public override long Price => _price;

		public float ShroudCurvature => _shroudCurvature;

		public float ShroudLength => _shroudLength;

		public override float Scale
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public override string ScaleCareerID => "MaxSize.JetEngine";

		public float ThrottleResponse => Mathf.Clamp(0.1f / CoreRadius, 0.1f, 2f);

		public void CalculateMassAndPrice()
		{
			float size = _size;
			float coreRadius = CoreRadius;
			float coreRadius2 = CoreRadius;
			float num = MathF.PI * coreRadius * coreRadius;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = FanArea * 0.5f * size;
			num2 += num4 * 500f;
			num3 += num4 * 500000f * (float)((!HasReverseThrust) ? 1 : 4);
			float num5 = num * (3.276f + CompressorLength) * coreRadius2;
			num2 += num5 * 450f;
			num3 += num5 * 2000000f;
			if (HasAfterburner)
			{
				float num6 = num * 2.364f * coreRadius2;
				num2 += num6 * 200f;
				num3 += num6 * 500000f;
			}
			float num7 = num * 2.155f * coreRadius2;
			num2 += num7 * 200f;
			num3 += num7 * 500000f;
			_mass = num2 * 0.01f;
			_price = (int)num3;
		}

		protected override void OnDesignerInitialization(IDesignerPartPropertiesModifierInterface d)
		{
			IGameStateValidator validator = Game.Instance.GameState.Validator;
			d.OnPropertyChanged(() => _compressionRatio, delegate
			{
				UpdateAndSyncComponents();
			});
			d.OnPropertyChanged(() => _bypassRatio, delegate
			{
				UpdateAndSyncComponents();
			});
			d.OnPropertyChanged(() => _size, delegate
			{
				UpdateAndSyncComponents();
			});
			d.OnPropertyChanged(() => _shroudCurvature, delegate
			{
				UpdateAndSyncComponents();
			});
			d.OnPropertyChanged(() => _shroudLength, delegate
			{
				UpdateAndSyncComponents();
			});
			d.OnPropertyChanged(() => _hasAfterburner, delegate
			{
				if (!validator.IsItemAvailable("JetEngine.Afterburner") && _hasAfterburner)
				{
					_hasAfterburner = false;
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You haven't unlocked the afterburner yet. You can unlock it in the Tech Tree.";
				}
				UpdateAndSyncComponents();
			});
			d.OnPropertyChanged(() => _hasReverseThrust, delegate
			{
				if (!validator.IsItemAvailable("JetEngine.Reverse") && _hasReverseThrust)
				{
					_hasReverseThrust = false;
					Game.Instance.UserInterface.CreateMessageDialog().MessageText = "You haven't unlocked the reverse thrust yet. You can unlock it in the Tech Tree.";
					base.Script.PartScript.CraftScript.SetStructureChanged();
				}
				base.Script.VisibilityBrake(HasReverseThrust);
				CalculateMassAndPrice();
				d.Manager.Flyout.RefreshUI();
			});
			d.OnValueLabelRequested(() => _size, (float x) => Units.GetPercentageString(x));
			d.OnValueLabelRequested(() => _bypassRatio, (float x) => Units.GetRatioString(x));
			d.OnValueLabelRequested(() => _compressionRatio, (float x) => Units.GetRatioString(x));
			d.OnValueLabelRequested(() => _afterburnerThrottleStart, (float x) => Units.GetPercentageString(x));
			d.OnValueLabelRequested(() => _shroudCurvature, (float x) => Units.GetPercentageString(x));
			d.OnValueLabelRequested(() => _shroudLength, (float x) => Units.GetPercentageString(x));
			d.OnPartStyleChanged(delegate
			{
				OnPartStyleChanged();
			});
			d.OnActivated(delegate
			{
				base.Script.PreviewExhaust = true;
			});
			d.OnDeactivated(delegate
			{
				if (!base.Part.IsDestroyed)
				{
					base.Script.PreviewExhaust = false;
				}
			});
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			CalculateMassAndPrice();
		}

		private void OnPartStyleChanged()
		{
			UpdateAndSyncComponents(updateStyles: true);
		}

		private void UpdateAndSyncComponents(bool updateStyles = false)
		{
			base.Script.CalculateDesignerPerformance();
			CalculateMassAndPrice();
			base.Script.UpdateComponentsInDesigner(updateStyles);
			base.Script.PartScript.CraftScript.SetStructureChanged();
		}
	}
}
