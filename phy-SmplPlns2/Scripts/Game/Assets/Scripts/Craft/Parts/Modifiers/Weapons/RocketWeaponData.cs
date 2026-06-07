using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	[PartModifierDesignerHeader("Rocket")]
	public class RocketWeaponData : PartModifierData
	{
		public enum FinMode
		{
			Static = 0,
			Deployed = 1,
			None = 2
		}

		public const float DefaultBurnTimer = 2f;

		protected const string DesignerActivationGroupAlwaysArmedText = "All";

		private const float DefaultSelfDestructTimer = 10f;

		private float _burnTimer = 2f;

		[DesignerPropertyToggleButton(new string[] { "All", "1", "2", "3", "4", "5", "6", "7", "8" }, Label = "Armed Group", Order = 1, AllowFunkyInput = true)]
		private string _designerActivationGroup = "All";

		[DesignerPropertyToggleButton(new string[] { "Static", "Deployed", "None" }, Label = "Fin Mode", Order = 3)]
		private string _finMode = "Static";

		[DesignerPropertySlider(0.1f, 2f, 20, Label = "Firing Delay", Order = 2)]
		private float _firingDelay = 0.4f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Laser Guided", Order = 5, Tooltip = "When enabled, the rocket will attempt to guide itself to the current laser target.")]
		private bool _laserGuided;

		private RocketWeaponScript _script;

		private float _selfDestructTimer = 10f;

		public string ActivationGroup { get; private set; }

		public float BurnTimer => _burnTimer;

		public string CustomName { get; private set; }

		public float ExplosionScale { get; private set; }

		public FinMode Fins { get; set; }

		public float FireDelay
		{
			get
			{
				return _firingDelay;
			}
			set
			{
				_firingDelay = value;
			}
		}

		public bool IsLaserGuided => _laserGuided;

		public float SelfDestructTimer => _selfDestructTimer;

		public RocketWeaponData(XElement element)
			: base(element)
		{
			ActivationGroup = ((string)element.Attribute("activationGroup")) ?? "0";
			CustomName = ((string)element.Attribute("name")) ?? null;
			ExplosionScale = ((float?)element.Attribute("explosionScale")) ?? 1f;
			_designerActivationGroup = ((ActivationGroup == "0") ? "All" : ActivationGroup);
			_firingDelay = element.GetFloatAttribute("firingDelay", 0.4f);
			_finMode = element.GetStringAttribute("finMode", "Static");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("activationGroup", ActivationGroup.ToString()));
			xElement.Add(new XAttribute("firingDelay", _firingDelay.ToString()));
			xElement.Add(new XAttribute("finMode", _finMode));
			xElement.Add(new XAttribute("laserGuided", _laserGuided));
			if (CustomName != null)
			{
				xElement.Add(new XAttribute("name", CustomName));
			}
			if (!Mathf.Approximately(_selfDestructTimer, 10f))
			{
				xElement.Add(new XAttribute("selfDestructTimer", _selfDestructTimer.ToString()));
			}
			if (!Mathf.Approximately(_burnTimer, 2f))
			{
				xElement.Add(new XAttribute("burnTimer", _burnTimer.ToString()));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_firingDelay")
			{
				return sliderValue.ToString("0.00") + "s";
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			_script = parentGameObject.AddComponent<RocketWeaponScript>();
			switch (_finMode)
			{
			case "Static":
				Fins = FinMode.Static;
				_script.transform.Find("Mesh/Fins").gameObject.SetActive(value: true);
				break;
			case "Deployed":
				Fins = FinMode.Deployed;
				_script.transform.Find("Mesh/Fins").gameObject.SetActive(value: false);
				break;
			case "None":
				Fins = FinMode.None;
				_script.transform.Find("Mesh/Fins").gameObject.SetActive(value: false);
				break;
			}
			return _script;
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
			if (propertyName == "_finMode")
			{
				switch (value)
				{
				case "Static":
					Fins = FinMode.Static;
					_script.transform.Find("Mesh/Fins").gameObject.SetActive(value: true);
					break;
				case "Deployed":
					Fins = FinMode.Deployed;
					_script.transform.Find("Mesh/Fins").gameObject.SetActive(value: false);
					break;
				case "None":
					Fins = FinMode.None;
					_script.transform.Find("Mesh/Fins").gameObject.SetActive(value: false);
					break;
				}
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			if (stateElement != null)
			{
				base.RestoreFromState(stateElement);
				ActivationGroup = ((string)stateElement.Attribute("activationGroup")) ?? "0";
				CustomName = ((string)stateElement.Attribute("name")) ?? null;
				_designerActivationGroup = ((ActivationGroup == "0") ? "All" : ActivationGroup.ToString());
				_firingDelay = stateElement.GetFloatAttribute("firingDelay", 0.4f);
				_finMode = stateElement.GetStringAttribute("finMode", "Static");
				_selfDestructTimer = stateElement.GetFloatAttribute("selfDestructTimer", 10f);
				_burnTimer = stateElement.GetFloatAttribute("burnTimer", 2f);
				_laserGuided = stateElement.GetBoolAttribute("laserGuided", _laserGuided);
			}
		}
	}
}
