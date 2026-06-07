using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public abstract class LandingGearData : PartModifierData
	{
		private float _baseBrakeTorque;

		[DesignerPropertySlider(0.1f, 2.5f, 25, Label = "Brake Torque", Order = 10)]
		private float _brakeTorquePercentage = 1f;

		[DesignerPropertySlider(0f, 2.5f, 26, Label = "Damper", Order = 5)]
		private float _damper = 1f;

		[DesignerPropertySlider(0f, 1f, 11, Label = "Turn Sensitivity", Order = 3)]
		private float _sensitivity = 1f;

		[DesignerPropertySlider(0.5f, 2.5f, 201, Label = "Size", Order = 0)]
		private float _size = 1f;

		[DesignerPropertySlider(0.5f, 2.5f, 21, Label = "Suspension Strength", Order = 4)]
		private float _spring = 1f;

		private float _suspensionStiffness;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Turnable", Order = 1)]
		private bool _turningEnabled;

		public float BrakeTorque => _baseBrakeTorque * _brakeTorquePercentage;

		public bool CanFlip { get; set; }

		public float Damper => _damper;

		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Flipped", Order = 2)]
		public bool Flipped { get; set; }

		public float Sensitivity
		{
			get
			{
				return _sensitivity;
			}
			set
			{
				_sensitivity = value;
			}
		}

		public float Spring => _spring;

		public float SuspensionDistance { get; set; }

		public float SuspensionStiffness
		{
			get
			{
				return _suspensionStiffness;
			}
			set
			{
				_suspensionStiffness = Mathf.Clamp(value, 0f, 0.99f);
			}
		}

		public bool Turnable { get; set; }

		public bool TurningEnabled
		{
			get
			{
				return _turningEnabled;
			}
			set
			{
				_turningEnabled = value;
			}
		}

		public LandingGearData(XElement element)
			: base(element)
		{
			Turnable = bool.Parse(element.Attribute("turnable").Value);
			TurningEnabled = false;
			SuspensionStiffness = element.GetFloatAttribute("suspensionStiffness", 0.915f);
			SuspensionDistance = element.GetFloatAttribute("suspensionDistance", 0.3f);
			_baseBrakeTorque = element.GetFloatAttribute("brakeTorque", 500f);
			CanFlip = element.GetBoolAttribute("canFlip");
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_sensitivity":
			case "_spring":
			case "_damper":
			case "_brakeTorquePercentage":
			case "_size":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			if (property.Member.Name == "Flipped")
			{
				return () => CanFlip;
			}
			if (property.Member.Name == "_turningEnabled")
			{
				return () => Turnable;
			}
			if (property.Member.Name == "_sensitivity")
			{
				return () => Turnable;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override object GetSymmetricValue(string propertyName, int symmetricPartCount, PartModifierData sourceModifier, object sourceValue)
		{
			if (symmetricPartCount == 2 && propertyName == "Flipped")
			{
				return !(bool)sourceValue;
			}
			return base.GetSymmetricValue(propertyName, symmetricPartCount, sourceModifier, sourceValue);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_size")
			{
				base.Part.PartScale = Vector3.one * _size;
				base.Part.MassScale = Mathf.Pow(_size, 2.2f);
				if (base.Part.PartScale.HasValue)
				{
					base.Part.PartScript.transform.localScale = base.Part.PartScale.Value;
				}
				Designer.Instance.SetAircraftStructureChanged();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_size = base.Part.PartScale?.y ?? 1f;
			Sensitivity = stateElement.GetFloatAttribute("sensitivity", 1f);
			TurningEnabled = stateElement.GetBoolAttribute("turningEnabled");
			Flipped = stateElement.GetBoolAttribute("flipped");
			_damper = stateElement.GetFloatAttribute("damper", 1f);
			_spring = stateElement.GetFloatAttribute("spring", 1f);
			_brakeTorquePercentage = stateElement.GetFloatAttribute("brakeTorque", _brakeTorquePercentage);
			if (_spring < 0f)
			{
				_spring = 0.01f;
			}
			if (_damper < 0f)
			{
				_damper = 0f;
			}
			if (stateElement.Parent != null)
			{
				XElement xElement = stateElement.Parent.Element("Rotator.State");
				if (xElement != null && xElement.GetBoolAttribute("enabled"))
				{
					TurningEnabled = true;
				}
			}
		}

		protected List<XAttribute> GetStateAttributes()
		{
			return new List<XAttribute>
			{
				new XAttribute("sensitivity", Sensitivity.ToString()),
				new XAttribute("turningEnabled", TurningEnabled.ToString().ToLower()),
				new XAttribute("flipped", Flipped.ToString().ToLower()),
				new XAttribute("damper", _damper),
				new XAttribute("spring", _spring),
				new XAttribute("brakeTorque", _brakeTorquePercentage)
			};
		}
	}
}
