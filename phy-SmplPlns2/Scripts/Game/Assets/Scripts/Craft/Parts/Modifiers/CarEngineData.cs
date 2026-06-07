using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Car Engine")]
	public class CarEngineData : PartModifierData, IModifierWithOutputs
	{
		private const float DefaultPower = 200f;

		[DesignerPropertySlider(50f, 600f, 23, Label = "Power")]
		private float _power = 200f;

		public float FuelConsumptionRate { get; set; }

		public Type ModifierScriptType => typeof(CarEngineScript);

		public float Power => _power;

		public float ThrottleResponse { get; set; }

		public CarEngineData(XElement element)
			: base(element)
		{
			ThrottleResponse = float.Parse(element.Attribute("throttleResponse").Value);
			FuelConsumptionRate = float.Parse(element.Attribute("fuelConsumptionRate").Value);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("power", _power.ToString()));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_power")
			{
				return (int)sliderValue + "HP";
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("CarEngine");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			CarEngineScript carEngineScript = gameObject.AddComponent<CarEngineScript>();
			carEngineScript.CarEngine = this;
			return carEngineScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_power = stateElement.GetFloatAttribute("power", 200f);
		}
	}
}
