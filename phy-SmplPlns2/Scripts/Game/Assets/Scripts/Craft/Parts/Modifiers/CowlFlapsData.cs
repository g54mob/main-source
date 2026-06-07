using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CowlFlapsData : PartModifierData
	{
		public bool HideCowl { get; private set; }

		public override bool UsedInPropMode => true;

		public CowlFlapsData(XElement element)
			: base(element)
		{
			HideCowl = element.GetBoolAttribute("hide");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("hide", HideCowl.ToString().ToLower()));
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			CowlFlapsScript cowlFlapsScript = parentGameObject.AddComponent<CowlFlapsScript>();
			cowlFlapsScript.Initialize(this);
			return cowlFlapsScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			HideCowl = stateElement.GetBoolAttribute("hide");
		}
	}
}
