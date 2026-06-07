using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Detacher")]
	public class DetacherData : PartModifierData
	{
		public enum DetacherDirection
		{
			Default = 0,
			Forward = 1
		}

		[DesignerPropertySlider(0.25f, 2.5f, 226, Label = "Size", Order = 0)]
		private float _size = 1f;

		[DesignerPropertySlider(0f, 5f, 51, Label = "Delay", Order = 10)]
		private float _delay;

		[DesignerPropertyToggleButton(new string[] { "Disabled", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 15, AllowFunkyInput = true)]
		private string _designerActivationGroup = "1";

		[DesignerPropertySlider(0f, 1f, 21, Label = "Detach Force", Order = 5)]
		private float _designerForce = 1f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Detach Direction", Order = 1, AllowFunkyInput = true)]
		private DetacherDirection _direction;

		public List<int> AttachPointsToDetach { get; private set; }

		public float Delay => _delay;

		public float DetacherForce { get; set; }

		public float DesignerForce => _designerForce;

		public float DetacherUiMaxForce { get; private set; }

		public DetacherDirection Direction => _direction;

		public bool Enabled { get; set; }

		public string Group
		{
			get
			{
				if (!(_designerActivationGroup == "Disabled"))
				{
					return _designerActivationGroup;
				}
				return "0";
			}
		}

		public DetacherData(XElement element)
			: base(element)
		{
			Enabled = false;
			DetacherForce = 1000f;
			DetacherUiMaxForce = 10000f;
			AttachPointsToDetach = new List<int>();
			string[] array = Regex.Replace(element.Attribute("attachPointsToDetach").Value, "\\s+", string.Empty).Split(',');
			foreach (string s in array)
			{
				AttachPointsToDetach.Add(int.Parse(s));
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("enabled", Enabled.ToString()));
			xElement.Add(new XAttribute("group", Group.ToString()));
			xElement.Add(new XAttribute("delay", _delay.ToString()));
			xElement.Add(new XAttribute("direction", _direction.ToString()));
			xElement.Add(new XAttribute("detachForce", DetacherForce.ToString()));
			xElement.Add(new XAttribute("detacherUiMaxForce", DetacherUiMaxForce.ToString()));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			return propertyName switch
			{
				"_size" => Utilities.FormatPercentage(sliderValue), 
				"_designerForce" => Utilities.FormatPercentage(sliderValue), 
				"_delay" => $"{sliderValue:n1} seconds", 
				_ => base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue), 
			};
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			DetacherScript detacherScript = parentGameObject.AddComponent<DetacherScript>();
			detacherScript.Initialize(this);
			return detacherScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_size")
			{
				PartScaleHelper.ApplyScaleWithAnchor(base.Part, _size, 1f);
			}
			else if (propertyName == "_designerForce")
			{
				float result = 0f;
				if (!float.TryParse(value, out result))
				{
					result = 0f;
				}
				DetacherForce = result * result * DetacherUiMaxForce;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_size = base.Part.PartScale?.y ?? 1f;
			Enabled = bool.Parse(stateElement.Attribute("enabled").Value);
			if (Enabled)
			{
				_direction = stateElement.GetEnumAttribute("direction", _direction);
				DetacherForce = float.Parse(stateElement.Attribute("detachForce").Value);
				string text = ((string)stateElement.Attribute("group")) ?? "1";
				_designerActivationGroup = ((text == "0") ? "Disabled" : text);
				DetacherUiMaxForce = float.Parse(stateElement.Attribute("detacherUiMaxForce").Value);
				_delay = stateElement.GetFloatAttribute("delay");
			}
			try
			{
				_designerForce = Mathf.Sqrt(DetacherForce / DetacherUiMaxForce);
			}
			catch (Exception)
			{
				_designerForce = 1f;
			}
		}
	}
}
