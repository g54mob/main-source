using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Gyroscope")]
	public class GyroscopeData : PartModifierData
	{
		private const float MagicSpeedMultiplier = 25f;

		private const float MagicStabilityModifier = 12.5f;

		private const float MagicYawPowerMultiplier = 125f;

		private const float MaxSpeed = 2.5f;

		private const float MaxStability = 2.5f;

		private const float MaxYawPower = 2.5f;

		private const float MinSpeed = 0f;

		private const float MinStability = 0f;

		private const float MinYawPower = 0f;

		[DesignerPropertyToggleButton(new string[] { "None", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 0, AllowFunkyInput = true)]
		private string _activationGroup = "8";

		[DesignerPropertyToggleButton(new string[] { "Disabled", "Enabled" }, Label = "Auto Orient", Order = 4)]
		private bool _autoOrient = true;

		[DesignerPropertySlider(0f, 180f, 36, Label = "Pitch Range", Order = 5)]
		private float _pitchRange = 45f;

		[DesignerPropertySlider(0f, 180f, 36, Label = "Roll Range", Order = 6)]
		private float _rollRange = 45f;

		[DesignerPropertySlider(0f, 2.5f, 51, Label = "Gyroscopic Speed", Order = 2)]
		private float _speed = 1f;

		[DesignerPropertySlider(0f, 2.5f, 51, Label = "Gyroscopic Stability", Order = 3)]
		private float _stability = 1f;

		[DesignerPropertySlider(0f, 2.5f, 51, Label = "Yaw Power", Order = 7)]
		private float _yawPower = 1f;

		public string ActivationGroup
		{
			get
			{
				if (!(_activationGroup == "None"))
				{
					return _activationGroup;
				}
				return "0";
			}
		}

		public bool AutoOrient => _autoOrient;

		public override bool EnabledForRemoteAircraft => false;

		public bool PitchEnabled => _pitchRange > 0f;

		public float PitchRange
		{
			get
			{
				return _pitchRange;
			}
			set
			{
				_pitchRange = value;
			}
		}

		public bool RollEnabled => _rollRange > 0f;

		public float RollRange
		{
			get
			{
				return _rollRange;
			}
			set
			{
				_rollRange = value;
			}
		}

		public float Speed => _speed * 25f;

		public float Stability => _stability * 12.5f;

		public float YawPower => _yawPower * 125f;

		public GyroscopeData(XElement partType)
			: base(partType)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", _activationGroup));
			xElement.Add(new XAttribute("autoOrient", _autoOrient));
			xElement.Add(new XAttribute("stability", _stability.ToString()));
			xElement.Add(new XAttribute("speed", _speed.ToString()));
			xElement.Add(new XAttribute("yawPower", _yawPower.ToString()));
			xElement.Add(new XAttribute("pitchRange", _pitchRange.ToString()));
			xElement.Add(new XAttribute("rollRange", _rollRange.ToString()));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_speed":
			case "_stability":
			case "_yawPower":
				return Utilities.FormatPercentage(sliderValue);
			case "_rollRange":
			case "_pitchRange":
				return Mathf.RoundToInt(sliderValue / 5f) * 5 + "°";
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GyroscopeScript gyroscopeScript = parentGameObject.AddComponent<GyroscopeScript>();
			gyroscopeScript.Initialize(this);
			return gyroscopeScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_rollRange")
			{
				_rollRange = Mathf.Round(float.Parse(value) / 5f) * 5f;
			}
			else if (propertyName == "_pitchRange")
			{
				_pitchRange = Mathf.Round(float.Parse(value) / 5f) * 5f;
			}
			base.OnGenericDesignerPropertyChanged(propertyName, value);
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			if (!float.TryParse(stateElement.Attribute("stability").Value, out _stability))
			{
				_stability = 1f;
			}
			if (!float.TryParse(stateElement.Attribute("speed").Value, out _speed))
			{
				_speed = 1f;
			}
			_autoOrient = stateElement.GetBoolAttribute("autoOrient", defaultValue: true);
			_yawPower = stateElement.GetFloatAttribute("yawPower");
			_pitchRange = stateElement.GetFloatAttribute("pitchRange");
			_rollRange = stateElement.GetFloatAttribute("rollRange");
			_activationGroup = stateElement.GetStringAttribute("activationGroup", "8");
		}
	}
}
