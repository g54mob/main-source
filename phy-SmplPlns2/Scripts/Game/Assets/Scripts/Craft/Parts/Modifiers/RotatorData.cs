using System.Xml.Linq;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class RotatorData : PartModifierData
	{
		public bool Enabled { get; set; }

		public string InputX { get; private set; }

		public string InputY { get; private set; }

		public string InputZ { get; private set; }

		public string Target { get; private set; }

		public RotatorData(XElement element)
			: base(element)
		{
			Target = element.Attribute("target").Value;
			InputX = element.GetStringAttribute("inputX", "none");
			InputY = element.GetStringAttribute("inputY", "none");
			InputZ = element.GetStringAttribute("inputZ", "none");
			XAttribute xAttribute = element.Attribute("enabledByDefault");
			if (xAttribute != null)
			{
				Enabled = bool.Parse(xAttribute.Value);
			}
			else
			{
				Enabled = true;
			}
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("enabled", Enabled.ToString()));
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			RotatorScript rotatorScript = parentGameObject.AddComponent<RotatorScript>();
			rotatorScript.Initialize(this);
			return rotatorScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			Enabled = bool.Parse(stateElement.Attribute("enabled").Value);
		}
	}
}
