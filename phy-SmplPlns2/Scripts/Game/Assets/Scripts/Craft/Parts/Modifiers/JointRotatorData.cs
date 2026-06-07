using System;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Rotator")]
	public class JointRotatorData : PartModifierData, IModifierWithOutputs
	{
		[DesignerPropertyToggleButton(new string[] { }, Label = "Disable Base", Order = 30)]
		private bool _disableBaseMesh;

		[DesignerPropertySlider(0f, 1f, 31, Label = "Range", Order = 10)]
		private float _range;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Speed", Order = 20)]
		private float _speed;

		[DesignerPropertySlider(0.25f, 2.5f, 226, Label = "Size", Order = 0)]
		private float _size = 1f;

		private bool _supportsDisableBaseMesh;

		public bool AllowFreeSpin { get; set; }

		public int AttachPointIndex { get; set; }

		public bool AudioEnabled { get; set; } = true;

		public float DamperMultiplier { get; set; }

		public bool DisableBaseMesh => _disableBaseMesh;

		public Vector3 HingeOffset { get; set; }

		public int MaxRange { get; set; }

		public float MaxSpeed { get; set; }

		public int MinRange { get; set; }

		public Type ModifierScriptType => typeof(JointRotatorScript);

		public float Range
		{
			get
			{
				return _range;
			}
			set
			{
				_range = value;
			}
		}

		public bool ShortestAngle { get; set; }

		public float Speed
		{
			get
			{
				return _speed;
			}
			set
			{
				_speed = value;
			}
		}

		public JointRotatorData(XElement element)
			: base(element)
		{
			AttachPointIndex = element.GetIntAttribute("attachPoint");
			MaxSpeed = element.GetFloatAttribute("maxSpeed", 20f);
			MinRange = element.GetIntAttribute("minRange");
			MaxRange = element.GetIntAttribute("maxRange");
			AllowFreeSpin = element.GetBoolAttribute("allowFreeSpin");
			ShortestAngle = element.GetBoolAttribute("shortestAngle");
			AudioEnabled = element.GetBoolAttribute("audio", defaultValue: true);
			_supportsDisableBaseMesh = element.GetBoolAttribute("supportsDisableBaseMesh", defaultValue: true);
			Range = 90f;
			Speed = 60f;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("range", _range.ToString()));
			xElement.Add(new XAttribute("speed", _speed.ToString()));
			if (DamperMultiplier != 1f)
			{
				xElement.Add(new XAttribute("damperMultiplier", DamperMultiplier.ToString()));
			}
			if (_disableBaseMesh)
			{
				xElement.Add(new XAttribute("disableBaseMesh", _disableBaseMesh.ToString().ToLower()));
			}
			if (HingeOffset != Vector3.zero)
			{
				xElement.Add(new XAttribute("hingeOffset", HingeOffset.ToXAttributeValue()));
			}
			if (ShortestAngle)
			{
				xElement.Add(new XAttribute("shortestAngle", ShortestAngle.ToString().ToLower()));
			}
			if (!AudioEnabled)
			{
				xElement.Add(new XAttribute("audio", AudioEnabled.ToString().ToLower()));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_range":
				if (sliderValue == 0f)
				{
					return "Free Spin";
				}
				return $"{sliderValue:n0}*";
			case "_speed":
				if (sliderValue == 0f)
				{
					return "Floppy";
				}
				return Utilities.FormatPercentage(sliderValue);
			case "_size":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			if (property.Member.Name == "_disableBaseMesh")
			{
				return () => _supportsDisableBaseMesh;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_size")
			{
				PartScaleHelper.ApplyScaleWithAnchor(base.Part, _size, 1f);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("JointRotator");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			JointRotatorScript jointRotatorScript = gameObject.AddComponent<JointRotatorScript>();
			jointRotatorScript.JointRotator = this;
			return jointRotatorScript;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			ISliderProperty property = genericPartPropertiesScript.GetProperty<ISliderProperty>("_range");
			property.SliderAttribute.MinValue = 0f;
			property.SliderAttribute.MaxValue = MaxRange;
			property.SliderAttribute.NumberOfSteps = MaxRange / 5 + 1;
			property.Value = _range;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_size = base.Part.PartScale?.y ?? 1f;
			_range = stateElement.GetFloatAttribute("range", 90f);
			_speed = stateElement.GetFloatAttribute("speed", 60f);
			DamperMultiplier = stateElement.GetFloatAttribute("damperMultiplier", 1f);
			_disableBaseMesh = stateElement.GetBoolAttribute("disableBaseMesh");
			HingeOffset = stateElement.GetVector3Attribute("hingeOffset", Vector3.zero);
			ShortestAngle = stateElement.GetBoolAttribute("shortestAngle");
			AudioEnabled = stateElement.GetBoolAttribute("audio", defaultValue: true);
		}
	}
}
