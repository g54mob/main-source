using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[PartModifierDesignerHeader("Torpedo")]
	public class TorpedoData : PartModifierData
	{
		public TorpedoData(XElement element)
			: base(element)
		{
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			TorpedoScript torpedoScript = parentGameObject.AddComponent<TorpedoScript>();
			torpedoScript.Initialize();
			return torpedoScript;
		}
	}
}
