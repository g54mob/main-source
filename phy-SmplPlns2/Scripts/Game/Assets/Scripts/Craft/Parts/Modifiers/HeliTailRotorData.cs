using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Tail Rotor")]
	public class HeliTailRotorData : BladedEngineData
	{
		public enum TailModeType
		{
			HeadingHold = 0,
			Rate = 1,
			Manual = 2
		}

		private const string GyroGainScalarFieldName = "_pidGainScalar";

		private const string LinkageSpeedAttributeName = "linkageSpeed";

		private const string LinkageSpeedFieldName = "_linkageSpeed";

		private const float MaxPidGain = 2f;

		private const float MinPidGain = 0f;

		private const string PidGainsHeadingHoldAttributeName = "pidGainsHeadingHold";

		private const string PidGainsRateAttributeName = "pidGainsRate";

		private const string TailModeAttributeName = "tailMode";

		private const string TailSpeedAttributeName = "tailSpeed";

		private const string TailSpeedFieldName = "_tailSpeed";

		private const string TrimScaleAttributeName = "trimScale";

		private const string TrimScaleFieldName = "_trimScalePercent";

		private float _bladePitchScale;

		[DesignerPropertyToggleButton(new string[] { "Cropped", "Rounded", "Swept", "Tapered" }, Label = "Blade Style", Order = 5)]
		private string _bladeStyle;

		private Vector3 _defaultHeadingHoldPidGains = new Vector3(1f, 1f, 0.01f);

		private Vector3 _defaultRatePidGains = new Vector3(0f, 0.5f, 0f);

		[DesignerPropertySlider(0f, 1f, 101, Label = "Linkage Speed (s)")]
		private float _linkageSpeed;

		[DesignerPropertySlider(0f, 2f, 41, Label = "Gyro Gain")]
		private float _pidGainScalar;

		[DesignerPropertyToggleButton(new string[] { "False", "True" }, Label = "Reverse Rotation")]
		private bool _reverseRotation;

		[DesignerPropertyToggleButton(new string[] { "Head Hold", "Rate", "Manual" }, Label = "Mode")]
		private TailModeType _tailMode;

		[DesignerPropertySlider(0f, MathF.PI * 2f, 73, Label = "Gyro Speed")]
		private float _tailSpeed;

		[DesignerPropertySlider(0f, 2f, 21, Label = "Trim Scale")]
		private float _trimScalePercent = 1f;

		public override string BladeStyle
		{
			get
			{
				return "HB-" + _bladeStyle;
			}
			set
			{
				_bladeStyle = value.Replace("HB-", string.Empty);
			}
		}

		public float LinkageSpeed
		{
			get
			{
				return _linkageSpeed;
			}
			private set
			{
				_linkageSpeed = value;
			}
		}

		public override float MaxDiameter => 5f;

		public override float MinDiameter => 1f;

		public override float PerformanceCost => (float)Mathf.Max(0, base.BladeCount - 2) * 16f;

		public Vector3 PidGainsHeadingHold { get; private set; }

		public Vector3 PidGainsRate { get; private set; }

		public override float PropellerPitchScale
		{
			get
			{
				return _bladePitchScale;
			}
			set
			{
				_bladePitchScale = value;
			}
		}

		public override bool ReverseRotation
		{
			get
			{
				return _reverseRotation;
			}
			set
			{
				_reverseRotation = value;
			}
		}

		public TailModeType TailMode
		{
			get
			{
				return _tailMode;
			}
			set
			{
				_tailMode = value;
			}
		}

		public float TailSpeed
		{
			get
			{
				return _tailSpeed;
			}
			set
			{
				_tailSpeed = value;
			}
		}

		public float TrimScale { get; private set; }

		public HeliTailRotorData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("pidGainsHeadingHold", PidGainsHeadingHold.ToXAttributeValue()));
			xElement.Add(new XAttribute("pidGainsRate", PidGainsRate.ToXAttributeValue()));
			xElement.Add(new XAttribute("tailSpeed", TailSpeed.ToString()));
			xElement.Add(new XAttribute("linkageSpeed", LinkageSpeed.ToString()));
			xElement.Add(new XAttribute("tailMode", TailMode.ToString()));
			xElement.Add(new XAttribute("trimScale", _trimScalePercent.ToString()));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			return propertyName switch
			{
				"_pidGainScalar" => $"{(int)(_pidGainScalar * 100f):0}%", 
				"_linkageSpeed" => $"{Mathf.Round(_linkageSpeed * 100f) / 100f:0.00}(s)", 
				"_tailSpeed" => $"{_tailSpeed * 57.29578f:0}deg/sec", 
				"_trimScalePercent" => $"{(int)(_trimScalePercent * 100f):0}%", 
				_ => base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue), 
			};
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			return property.Member.Name switch
			{
				"_throttleGovernorEngagePercent" => () => true, 
				"_throttleGovernorDesignerToggle" => () => false, 
				"_bladePitch" => () => false, 
				"_bladePitchScale" => () => false, 
				"_pitchControlType" => () => false, 
				_ => base.GetGenericDesignerPropertyVisibilityCallback(property), 
			};
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			_pidGainScalar = PidGainsHeadingHold.x;
			genericPartPropertiesScript.GetProperty<ISliderProperty>("_pidGainScalar").Value = (_pidGainScalar - 0f) / 2f;
			ISliderProperty property = genericPartPropertiesScript.GetProperty<ISliderProperty>("_diameter");
			property.SliderAttribute.MinValue = MinDiameter;
			property.SliderAttribute.MaxValue = MaxDiameter;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_pidGainScalar")
			{
				PidGainsHeadingHold = _defaultHeadingHoldPidGains * _pidGainScalar;
				PidGainsRate = _defaultRatePidGains * _pidGainScalar;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			TailSpeed = stateElement.GetFloatAttribute("tailSpeed", MathF.PI / 3f);
			LinkageSpeed = stateElement.GetFloatAttribute("linkageSpeed", 0.2f);
			TailMode = stateElement.GetEnumAttribute("tailMode", TailModeType.HeadingHold);
			PidGainsHeadingHold = stateElement.GetVector3Attribute("pidGainsHeadingHold", _defaultHeadingHoldPidGains);
			PidGainsRate = stateElement.GetVector3Attribute("pidGainsRate", _defaultRatePidGains);
			_trimScalePercent = stateElement.GetFloatAttribute("trimScale", 1f);
			TrimScale = 0.15f * _trimScalePercent;
		}

		protected override BladedEngineScript AddBladedEngineModifier(GameObject gameObject)
		{
			return gameObject.AddComponent<HeliTailRotorScript>();
		}
	}
}
