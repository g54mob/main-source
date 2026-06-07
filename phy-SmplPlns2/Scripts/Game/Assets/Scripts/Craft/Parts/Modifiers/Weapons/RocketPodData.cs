using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[PartModifierDesignerHeader("Rocket Pod")]
	public class RocketPodData : PartModifierData
	{
		protected const string DesignerActivationGroupAlwaysArmedText = "All";

		[DesignerPropertyToggleButton(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Armed Group", Order = 1, AllowFunkyInput = true)]
		private string _designerActivationGroup = "All";

		[DesignerPropertyToggleButton(new string[] { }, Label = "Laser Guided", Order = 2, Tooltip = "When enabled, the rocket will attempt to guide itself to the current laser target.")]
		private bool _laserGuided;

		public string ActivationGroup { get; private set; }

		public string CustomName { get; private set; }

		public float ExplosionScale { get; private set; }

		public float FireDelay { get; set; }

		public bool IsLaserGuided => _laserGuided;

		public RocketPodData(XElement element)
			: base(element)
		{
			ActivationGroup = ((string)element.Attribute("activationGroup")) ?? "0";
			CustomName = ((string)element.Attribute("name")) ?? null;
			ExplosionScale = ((float?)element.Attribute("explosionScale")) ?? 1f;
			_designerActivationGroup = ((ActivationGroup == "0") ? "All" : ActivationGroup);
			FireDelay = element.GetFloatAttribute("firingDelay", 0.4f);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup.ToString()));
			xElement.Add(new XAttribute("laserGuided", _laserGuided));
			if (!Mathf.Approximately(FireDelay, 0.4f))
			{
				xElement.Add(new XAttribute("firingDelay", FireDelay.ToString()));
			}
			if (CustomName != null)
			{
				xElement.Add(new XAttribute("name", CustomName));
			}
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			return parentGameObject.AddComponent<RocketPodScript>();
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_designerActivationGroup")
			{
				if (value != _designerActivationGroup)
				{
					Debug.LogError("What? Uh oh...");
				}
				ActivationGroup = ((value == "All") ? "0" : value);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			if (stateElement != null)
			{
				base.RestoreFromState(stateElement);
				ActivationGroup = ((string)stateElement.Attribute("activationGroup")) ?? "0";
				CustomName = ((string)stateElement.Attribute("name")) ?? null;
				_designerActivationGroup = ((ActivationGroup == "0") ? "All" : ActivationGroup);
				FireDelay = stateElement.GetFloatAttribute("firingDelay", 0.4f);
				_laserGuided = stateElement.GetBoolAttribute("laserGuided", _laserGuided);
			}
		}
	}
}
