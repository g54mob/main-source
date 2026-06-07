using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Beacon Light")]
	public class BeaconLightData : PartModifierData
	{
		protected const string DefaultBlinkProgram = "Steady";

		protected const string DesignerActivationGroupAlwaysOnText = "All";

		private const float DefaultIntensity = 2.5f;

		private List<float> _blinkProgram;

		[DesignerPropertyToggleButton(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 1)]
		private string _designerActivationGroup = "All";

		[DesignerPropertyToggleButton(new string[] { "Steady", "Slow Blink", "Quick Blink" }, Label = "Blink Style", Order = 2)]
		private string _designerBlinkProgram = "Steady";

		[DesignerPropertySlider(0.25f, 2.5f, 226, Label = "Size", Order = 0)]
		private float _size = 1f;

		[DesignerPropertySlider(Label = "Intensity", MinValue = 0f, MaxValue = 5f, NumberOfSteps = 51)]
		private float _intensity = 2.5f;

		public int ActivationGroup { get; private set; }

		public string Input { get; set; }

		public float Intensity => _intensity;

		public bool ShowHalo { get; set; }

		public BeaconLightData(XElement element)
			: base(element)
		{
			ActivationGroup = ((int?)element.Attribute("activationGroup")).GetValueOrDefault();
			_designerActivationGroup = ((ActivationGroup == 0) ? "All" : ActivationGroup.ToString());
			Input = "None";
			ShowHalo = true;
			_blinkProgram = null;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup.ToString()));
			xElement.Add(new XAttribute("designerBlinkProgram", _designerBlinkProgram));
			xElement.Add(new XAttribute("input", Input));
			xElement.SetAttributeValue("intensity", _intensity);
			if (_blinkProgram != null)
			{
				string text = string.Empty;
				foreach (float item in _blinkProgram)
				{
					text = text + item + ",";
				}
				text = text.TrimEnd(new char[1] { ',' });
				xElement.Add(new XAttribute("blinkProgram", text));
			}
			return xElement;
		}

		public float GetDurationForBlinkProgramStep(int step)
		{
			if (_blinkProgram != null)
			{
				int index = step % _blinkProgram.Count;
				return _blinkProgram[index];
			}
			return float.MaxValue;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_size")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			BeaconLightScript beaconLightScript = parentGameObject.AddComponent<BeaconLightScript>();
			beaconLightScript.BeaconLight = this;
			return beaconLightScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_size":
				base.Part.PartScale = Vector3.one * _size;
				base.Part.MassScale = Mathf.Pow(_size, 2.2f);
				if (base.Part.PartScale.HasValue)
				{
					base.Part.PartScript.transform.localScale = base.Part.PartScale.Value;
				}
				Designer.Instance.SetAircraftStructureChanged();
				break;
			case "_designerActivationGroup":
				if (value != _designerActivationGroup)
				{
					Debug.LogError("What? Uh oh...");
				}
				ActivationGroup = ((!(value == "All")) ? int.Parse(value) : 0);
				break;
			case "_designerBlinkProgram":
				SetDesignerBlinkProgram(value);
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			if (stateElement == null)
			{
				return;
			}
			base.RestoreFromState(stateElement);
			_size = base.Part.PartScale?.y ?? 1f;
			ActivationGroup = ((int?)stateElement.Attribute("activationGroup")).GetValueOrDefault();
			_designerActivationGroup = ((ActivationGroup == 0) ? "All" : ActivationGroup.ToString());
			_designerBlinkProgram = stateElement.GetStringAttribute("designerBlinkProgram", "Steady");
			_intensity = stateElement.GetFloatAttribute("intensity", 2.5f);
			Input = stateElement.GetStringAttribute("input", "None");
			ShowHalo = stateElement.GetBoolAttribute("showHalo", defaultValue: true);
			XAttribute xAttribute = stateElement.Attribute("blinkProgram");
			if (xAttribute == null)
			{
				return;
			}
			try
			{
				string[] array = xAttribute.Value.Split(new char[1] { ',' });
				_blinkProgram = new List<float>();
				string[] array2 = array;
				foreach (string s in array2)
				{
					_blinkProgram.Add(float.Parse(s));
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Failed to load blink program for light: " + ex.ToString());
				_blinkProgram = null;
			}
		}

		private void SetDesignerBlinkProgram(string value)
		{
			switch (value)
			{
			case "Steady":
				_blinkProgram = null;
				break;
			case "Slow Blink":
				_blinkProgram = new List<float>();
				_blinkProgram.Add(0.5f);
				_blinkProgram.Add(2f);
				break;
			case "Quick Blink":
				_blinkProgram = new List<float>();
				_blinkProgram.Add(0.5f);
				_blinkProgram.Add(0.5f);
				break;
			}
		}
	}
}
