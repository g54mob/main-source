using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Landing Gear")]
	public class WheelData : LandingGearData
	{
		public WheelData(XElement partType)
			: base(partType)
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
			GameObject gameObject = new GameObject(typeof(WheelData).Name);
			gameObject.transform.parent = parentGameObject.transform;
			gameObject.transform.localPosition = Vector3.zero;
			gameObject.transform.localRotation = Quaternion.identity;
			WheelScript wheelScript = gameObject.AddComponent<WheelScript>();
			if (partCreationInfo.CreateRigidBody)
			{
				Transform transform = wheelScript.transform.GetComponentInParent<PartScript>(includeInactive: true).transform.Find("EditorColliders");
				if (transform != null)
				{
					Object.Destroy(transform.gameObject);
				}
			}
			wheelScript.Initialize(this);
			return wheelScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
		}
	}
}
