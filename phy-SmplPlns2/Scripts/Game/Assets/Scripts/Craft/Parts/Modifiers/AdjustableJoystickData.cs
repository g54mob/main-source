using System;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Joystick")]
	public class AdjustableJoystickData : PartModifierData
	{
		[DesignerPropertySlider(Label = "Height", MinValue = 0f, MaxValue = 0.5f, NumberOfSteps = 21)]
		private float _height;

		public string ColliderPath { get; private set; }

		public string CylinderPath { get; private set; }

		public string[] HeadPaths { get; private set; }

		public float Height => _height;

		public event Action<float> OnHeightChanged;

		public AdjustableJoystickData(XElement element)
			: base(element)
		{
			ColliderPath = ((string)element.Attribute("colliderPath")) ?? "Collider";
			CylinderPath = ((string)element.Attribute("cylinderPath")) ?? "Shaft";
			HeadPaths = (((string)element.Attribute("headPaths")) ?? "Joystick").Split(',');
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("height", _height);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_height")
			{
				return $"{sliderValue:##0.0#}m";
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			AdjustableJoystickScript adjustableJoystickScript = parentGameObject.AddComponent<AdjustableJoystickScript>();
			adjustableJoystickScript.Initialise(this);
			return adjustableJoystickScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_height")
			{
				this.OnHeightChanged?.Invoke(_height);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_height = ((float?)stateElement.Attribute("height")).GetValueOrDefault();
		}
	}
}
