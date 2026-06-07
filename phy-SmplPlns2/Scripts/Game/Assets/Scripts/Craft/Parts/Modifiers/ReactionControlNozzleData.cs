using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Reaction Control Nozzle")]
	public class ReactionControlNozzleData : PartModifierData
	{
		public enum ReactionControlNozzleType
		{
			Pitch = 0,
			Roll = 1,
			Yaw = 2
		}

		public const string DefaultActivationGroup = "8";

		protected const string DesignerActivationGroupAlwaysArmedText = "None";

		[DesignerPropertyToggleButton(new string[] { "None", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Activation Group", Order = 1)]
		private string _designerActivationGroup = "None";

		public string ActivationGroup { get; set; }

		public bool AutoAssignType { get; set; }

		public float FuelConsumptionRate { get; private set; }

		public float Power { get; private set; }

		public bool Reverse { get; set; }

		public ReactionControlNozzleType Type { get; set; }

		public ReactionControlNozzleData(XElement element)
			: base(element)
		{
			AutoAssignType = bool.Parse(element.Attribute("autoAssignType").Value);
			XAttribute xAttribute = element.Attribute("type");
			if (xAttribute != null)
			{
				Type = (ReactionControlNozzleType)Enum.Parse(typeof(ReactionControlNozzleType), xAttribute.Value);
			}
			else
			{
				Type = ReactionControlNozzleType.Pitch;
			}
			ActivationGroup = "8";
			_designerActivationGroup = ((ActivationGroup == "0") ? "None" : ActivationGroup);
			Power = float.Parse(element.Attribute("power").Value) * 0.01f;
			FuelConsumptionRate = float.Parse(element.Attribute("fuelConsumptionRate").Value);
			XAttribute xAttribute2 = element.Attribute("reverse");
			if (xAttribute2 != null)
			{
				Reverse = bool.Parse(xAttribute2.Value);
			}
			else
			{
				Reverse = false;
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("autoAssignType", AutoAssignType.ToString()));
			xElement.Add(new XAttribute("type", Type.ToString()));
			xElement.Add(new XAttribute("reverse", Reverse.ToString()));
			if (ActivationGroup != "8")
			{
				xElement.Add(new XAttribute("activationGroup", ActivationGroup.ToString()));
			}
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			if (!partCreationInfo.IsNonFlyableAircraft)
			{
				ReactionControlNozzleScript reactionControlNozzleScript = parentGameObject.AddComponent<ReactionControlNozzleScript>();
				reactionControlNozzleScript.Initialize(this);
				return reactionControlNozzleScript;
			}
			return null;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_designerActivationGroup")
			{
				if (value != _designerActivationGroup)
				{
					Debug.LogError("What? Uh oh...");
				}
				ActivationGroup = ((value == "None") ? "0" : value);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			string value = stateElement.Attribute("type").Value;
			ActivationGroup = stateElement.GetStringAttribute("activationGroup", "8");
			_designerActivationGroup = ((ActivationGroup == "0") ? "None" : ActivationGroup.ToString());
			if (value.ToUpper() == "AUTO")
			{
				Type = ReactionControlNozzleType.Pitch;
				AutoAssignType = true;
				Reverse = false;
			}
			else
			{
				Type = (ReactionControlNozzleType)Enum.Parse(typeof(ReactionControlNozzleType), value);
				AutoAssignType = bool.Parse(stateElement.Attribute("autoAssignType").Value);
				Reverse = bool.Parse(stateElement.Attribute("reverse").Value);
			}
		}
	}
}
