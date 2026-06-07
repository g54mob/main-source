using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Airbrake")]
	public class AirBrakeData : PartModifierData
	{
		public int AttachPointIndex { get; set; }

		public float Drag { get; set; }

		public float MaxSpeed { get; set; }

		public float Range { get; set; }

		public float Speed { get; set; }

		public AirBrakeData(XElement element)
			: base(element)
		{
			Drag = element.GetFloatAttribute("drag", 1f);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("AirBrake");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			AirBrakeScript airBrakeScript = gameObject.AddComponent<AirBrakeScript>();
			airBrakeScript.AirBrake = this;
			return airBrakeScript;
		}
	}
}
