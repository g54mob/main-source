using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class EngineNozzleFlapsData : PartModifierData
	{
		public override bool UsedInPropMode => true;

		public EngineNozzleFlapsData(XElement element)
			: base(element)
		{
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			EngineNozzleFlapsScript engineNozzleFlapsScript = parentGameObject.AddComponent<EngineNozzleFlapsScript>();
			engineNozzleFlapsScript.Initialize(this);
			return engineNozzleFlapsScript;
		}
	}
}
