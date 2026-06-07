using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Refuel Probe")]
	public class RefuelProbeData : PartModifierData
	{
		private Vector3 _probeOffset = Vector3.zero;

		public RefuelProbeData(XElement element)
			: base(element)
		{
			_probeOffset = element.GetVector2Attribute("offset", Vector2.zero);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			RefuelProbeScript refuelProbeScript = parentGameObject.AddComponent<RefuelProbeScript>();
			refuelProbeScript.Offset = _probeOffset;
			return refuelProbeScript;
		}
	}
}
