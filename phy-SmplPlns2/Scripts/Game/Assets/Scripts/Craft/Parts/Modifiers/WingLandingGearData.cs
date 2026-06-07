using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Landing Gear")]
	public class WingLandingGearData : LandingGearData
	{
		public WingLandingGearData(XElement element)
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
			GameObject gameObject = new GameObject(typeof(WingLandingGearData).Name);
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			WingLandingGearScript wingLandingGearScript = gameObject.AddComponent<WingLandingGearScript>();
			wingLandingGearScript.Initialize(this);
			return wingLandingGearScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
		}
	}
}
