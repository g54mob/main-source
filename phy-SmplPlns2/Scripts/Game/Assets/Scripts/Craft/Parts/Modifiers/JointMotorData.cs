using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Joint Motor")]
	public class JointMotorData : PartModifierData
	{
		public int AttachPointIndex { get; set; }

		public JointMotorData(XElement element)
			: base(element)
		{
			AttachPointIndex = element.GetIntAttribute("attachPoint");
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			GameObject gameObject = new GameObject("JointMotor");
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = default(Vector3);
			gameObject.transform.localRotation = Quaternion.identity;
			gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			JointMotorScript jointMotorScript = gameObject.AddComponent<JointMotorScript>();
			jointMotorScript.JointMotor = this;
			return jointMotorScript;
		}
	}
}
