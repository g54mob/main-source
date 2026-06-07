using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Magnet")]
	public class MagnetData : PartModifierData
	{
		[DesignerPropertyToggleButton(new string[] { "None", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 1, AllowFunkyInput = true)]
		private string _designerActivationGroup = "1";

		[DesignerPropertySlider(0.1f, 2.5f, 25, Label = "Power", Order = 1)]
		private float _power;

		public string ActivationGroup { get; private set; }

		public float Power => _power;

		public MagnetData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup));
			xElement.Add(new XAttribute("power", _power.ToString()));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_power")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("Magnet");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			MagnetScript magnetScript = gameObject.AddComponent<MagnetScript>();
			magnetScript.Magnet = this;
			return magnetScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_designerActivationGroup")
			{
				ActivationGroup = ((string.IsNullOrEmpty(value) && value == "None") ? "0" : value);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			ActivationGroup = ((string)stateElement.Attribute("activationGroup")) ?? "1";
			if (ActivationGroup == "0")
			{
				_designerActivationGroup = "None";
			}
			else
			{
				_designerActivationGroup = ActivationGroup;
			}
			_power = stateElement.GetFloatAttribute("power", 1f);
		}
	}
}
