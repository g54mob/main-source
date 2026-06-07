using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("Refuel Drouge")]
	public class RefuelDrogueData : PartModifierData
	{
		[SerializeField]
		[DesignerPropertyToggleButton(new string[] { "None", "0", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", AllowFunkyInput = true)]
		private string _activationString = "7";

		[SerializeField]
		private float _angularDragPower;

		[SerializeField]
		private float _angularStabPower;

		public string ActivationString => _activationString;

		public float AngularDragPower => _angularDragPower;

		public float AngularStabPower => _angularStabPower;

		public float TransferRate { get; private set; }

		public string TriggerColliderPath { get; private set; }

		public RefuelDrogueData(XElement xml)
			: base(xml)
		{
			TriggerColliderPath = (string)xml.Attribute("triggerColliderPath");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("transferRate", TransferRate);
			xElement.SetAttributeValue("activationGroup", _activationString);
			xElement.SetAttributeValue("angularDragPower", _angularDragPower);
			xElement.SetAttributeValue("angularStabPower", _angularStabPower);
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			if (string.IsNullOrWhiteSpace(TriggerColliderPath))
			{
				return null;
			}
			Transform transform = parentGameObject.transform.Find(TriggerColliderPath);
			if (transform == null)
			{
				return null;
			}
			RefuelDrogueScript refuelDrogueScript = transform.gameObject.AddComponent<RefuelDrogueScript>();
			refuelDrogueScript.Modifier = this;
			return refuelDrogueScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			TransferRate = ((float?)stateElement.Attribute("transferRate")) ?? 50f;
			_activationString = ((string)stateElement.Attribute("activationGroup")) ?? "8";
			_angularStabPower = ((float?)stateElement.Attribute("angularStabPower")) ?? 8f;
			_angularDragPower = ((float?)stateElement.Attribute("angularDragPower")) ?? 50f;
		}
	}
}
