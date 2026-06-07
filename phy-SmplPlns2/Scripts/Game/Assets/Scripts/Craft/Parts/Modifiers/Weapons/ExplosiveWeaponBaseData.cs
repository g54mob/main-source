using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Flight.Combat;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public abstract class ExplosiveWeaponBaseData : PartModifierData
	{
		protected const string DesignerActivationGroupAlwaysArmedText = "All";

		[DesignerPropertyToggleButton(new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Armed Group", Order = 1, AllowFunkyInput = true)]
		private string _activationGroup = "0";

		public string ActivationGroup => _activationGroup;

		public string CustomName { get; set; }

		public float DefaultDetachForce { get; private set; }

		public float DetonationExplosiveForce { get; private set; }

		public float DetonationImpactForce { get; private set; }

		public string ExplosionPrefabName { get; private set; }

		public float ExplosionScale { get; set; }

		public float FireDelay { get; set; }

		public bool IsLaserGuided { get; }

		public TargetingStyle TargetingStyle { get; private set; }

		protected virtual float DefaultFiringDelay => 1f;

		public ExplosiveWeaponBaseData(XElement element)
			: base(element)
		{
			_activationGroup = ((string)element.Attribute("activationGroup")) ?? "0";
			CustomName = ((string)element.Attribute("name")) ?? null;
			ExplosionScale = ((float?)element.Attribute("explosionScale")) ?? 1f;
			ExplosionPrefabName = (string)element.Attribute("explosionPrefab");
			DefaultDetachForce = ((float?)element.Attribute("defaultDetachForce")).GetValueOrDefault();
			DetonationExplosiveForce = ((float?)element.Attribute("detonationExplosiveForce")) ?? 50f;
			DetonationImpactForce = ((float?)element.Attribute("detonationImpactForce")) ?? 5f;
			TargetingStyle = element.GetEnumAttribute("targetingStyle", TargetingStyle.None);
			IsLaserGuided = element.GetBoolAttribute("laserGuided");
			FireDelay = element.GetFloatAttribute("firingDelay", DefaultFiringDelay);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup));
			xElement.Add(new XAttribute("explosionScale", ExplosionScale));
			if (!Mathf.Approximately(FireDelay, DefaultFiringDelay))
			{
				xElement.Add(new XAttribute("firingDelay", FireDelay.ToString()));
			}
			if (CustomName != null)
			{
				xElement.Add(new XAttribute("name", CustomName));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			if (propertyName == "_activationGroup" && value == "0")
			{
				return "All";
			}
			return base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value);
		}

		public override void RestoreFromState(XElement stateElement)
		{
			if (stateElement != null)
			{
				base.RestoreFromState(stateElement);
				_activationGroup = ((string)stateElement.Attribute("activationGroup")) ?? "0";
				CustomName = ((string)stateElement.Attribute("name")) ?? null;
				FireDelay = stateElement.GetFloatAttribute("firingDelay", DefaultFiringDelay);
				ExplosionScale = stateElement.GetFloatAttribute("explosionScale", ExplosionScale);
			}
		}
	}
}
