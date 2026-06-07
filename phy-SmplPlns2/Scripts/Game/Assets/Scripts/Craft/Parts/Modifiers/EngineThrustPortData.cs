using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Thrust Port")]
	public class EngineThrustPortData : PartModifierData
	{
		public Vector3 ExhaustScale { get; private set; }

		public Color? ExhaustStartColorOverridePrimary { get; set; }

		public EngineThrustPortData(XElement element)
			: base(element)
		{
			ExhaustScale = Vector3.one;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("exhaustScale", ExhaustScale.ToXAttributeValue()));
			if (ExhaustStartColorOverridePrimary.HasValue)
			{
				xElement.Add(new XAttribute("exhaustStartColorOverridePrimary", ColorUtility.ToHtmlStringRGBA(ExhaustStartColorOverridePrimary.Value)));
			}
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			EngineThrustPortScript engineThrustPortScript = parentGameObject.AddComponent<EngineThrustPortScript>();
			engineThrustPortScript.Initialize(this);
			return engineThrustPortScript;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			ExhaustScale = stateElement.GetVector3Attribute("exhaustScale", Vector3.one);
			ExhaustStartColorOverridePrimary = stateElement.GetHtmlColorAttributeOrNull("exhaustStartColorOverridePrimary");
		}
	}
}
