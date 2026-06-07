using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Landing Gear")]
	public class RetractableLandingGearData : LandingGearData
	{
		public RetractableLandingGearScript RetractableLandingGearScript { get; private set; }

		public RetractableLandingGearData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(GetStateAttributes());
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject(typeof(RetractableLandingGearData).Name);
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			RetractableLandingGearScript = gameObject.AddComponent<RetractableLandingGearScript>();
			RetractableLandingGearScript.Initialize(this);
			return RetractableLandingGearScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "Flipped")
			{
				RetractableLandingGearScript.UpdateFlipConfiguration();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
		}
	}
}
