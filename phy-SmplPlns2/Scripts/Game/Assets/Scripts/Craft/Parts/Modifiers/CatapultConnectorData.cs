using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Catapult Connector")]
	public class CatapultConnectorData : PartModifierData
	{
		[DesignerPropertySlider(MinValue = 0.1f, MaxValue = 2f, NumberOfSteps = 20, Label = "Catapult Acceleration")]
		private float _catapultAcceleration = 1f;

		[DesignerPropertySlider(MinValue = 100f, MaxValue = 250f, NumberOfSteps = 31, Label = "Target Launch Speed")]
		private float _targetLaunchSpeed = 175f;

		public float CatapultAcceleration => _catapultAcceleration;

		public float TargetLaunchSpeed => _targetLaunchSpeed;

		public CatapultConnectorData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("catapultAcceleration", _catapultAcceleration));
			xElement.Add(new XAttribute("targetLaunchSpeed", _targetLaunchSpeed));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_catapultAcceleration")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			if (propertyName == "_targetLaunchSpeed")
			{
				return (_targetLaunchSpeed / 2.23694f).Format(UnitType.Speed);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			CatapultConnectorScript catapultConnectorScript = parentGameObject.AddComponent<CatapultConnectorScript>();
			catapultConnectorScript.Initialize(this);
			return catapultConnectorScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_catapultAcceleration = stateElement.GetFloatAttribute("catapultAcceleration", 1f);
			_targetLaunchSpeed = stateElement.GetFloatAttribute("targetLaunchSpeed", 175f);
		}
	}
}
