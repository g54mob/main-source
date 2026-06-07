using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Inlet")]
	public class InletData : PartModifierData
	{
		public float AirIntakeMultiplier { get; set; }

		public InletData(XElement element)
			: base(element)
		{
			AirIntakeMultiplier = float.Parse(element.Attribute("airIntakeMultiplier").Value);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("Inlet");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			InletScript inletScript = gameObject.AddComponent<InletScript>();
			inletScript.Inlet = this;
			return inletScript;
		}
	}
}
