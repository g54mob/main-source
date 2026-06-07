using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Pedal")]
	public class PedalData : PartModifierData
	{
		[DesignerPropertySlider(Label = "Full Angle", MinValue = -10f, MaxValue = 90f, NumberOfSteps = 101, Order = 20)]
		private float _fullAngle = 20f;

		private bool _refreshUI;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Style", Tooltip = "Changes the style.", Order = 5)]
		private string _style;

		[DesignerPropertySlider(Label = "Zero Angle", MinValue = -10f, MaxValue = 90f, NumberOfSteps = 101, Order = 50)]
		private float _zeroAngle = 50f;

		public float? DisplayTargetAngle { get; set; }

		public float FullAngle => 0f - _fullAngle;

		public string Input { get; private set; }

		public PedalPrefabs.PedalPrefab PedalPrefab { get; private set; }

		public PedalScript Script { get; private set; }

		public PedalPrefabs Styles { get; }

		public float ZeroAngle => 0f - _zeroAngle;

		public PedalData(XElement element)
			: base(element)
		{
			Input = element.GetStringAttribute("input", "none");
			_fullAngle = element.GetFloatAttribute("fullAngle", 20f);
			_zeroAngle = element.GetFloatAttribute("zeroAngle", 50f);
			Styles = Game.Instance.CraftResourceData.PedalPrefabs;
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("style", PedalPrefab.Id));
			xElement.Add(new XAttribute("fullAngle", _fullAngle));
			xElement.Add(new XAttribute("zeroAngle", _zeroAngle));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_zeroAngle" || propertyName == "_fullAngle")
			{
				return sliderValue.ToString("0");
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			if (propertyName == "_style")
			{
				return PedalPrefab.name;
			}
			return base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			PedalScript pedalScript = parentGameObject.AddComponent<PedalScript>();
			pedalScript.Initialize(this);
			Script = pedalScript;
			return pedalScript;
		}

		public override void OnGenericDesignerPropertiesUpdate(IGenericPartProperties genericPartProperties)
		{
			base.OnGenericDesignerPropertiesUpdate(genericPartProperties);
			if (_refreshUI)
			{
				_refreshUI = false;
				genericPartProperties.RefreshUI();
			}
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			ToggleButtonProperty property = genericPartPropertiesScript.GetProperty<ToggleButtonProperty>("_style");
			property.ButtonAttribute.Values.Clear();
			property.ButtonAttribute.Values.AddRange(from x in Styles.Pedals
				orderby x.Id
				select x.Id);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			switch (propertyName)
			{
			case "_zeroAngle":
			case "_fullAngle":
			{
				if (float.TryParse(value, out var result))
				{
					DisplayTargetAngle = 0f - result;
				}
				break;
			}
			case "_style":
				SetPrefab(_style);
				break;
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_style = stateElement.GetStringAttribute("style", Styles.Pedals.FirstOrDefault()?.Id);
			_fullAngle = stateElement.GetFloatAttribute("fullAngle", _fullAngle);
			_zeroAngle = stateElement.GetFloatAttribute("zeroAngle", _zeroAngle);
			SetPrefab(_style);
		}

		private void SetPrefab(string id)
		{
			PedalPrefabs.PedalPrefab pedalPrefab = PedalPrefab;
			PedalPrefab = Styles.GetPedal(id);
			if (pedalPrefab != null && pedalPrefab.swapAngles != PedalPrefab.swapAngles)
			{
				float fullAngle = _fullAngle;
				float zeroAngle = _zeroAngle;
				_zeroAngle = fullAngle;
				_fullAngle = zeroAngle;
				_refreshUI = true;
			}
			AttachPointData attachPointData = base.Part.AttachPoints[0];
			attachPointData.Normal = PedalPrefab.attachPointNormal;
			if (Script != null)
			{
				if (attachPointData.AttachPointScript?.transform != null)
				{
					attachPointData.AttachPointScript.transform.localRotation = Quaternion.FromToRotation(Vector3.forward, attachPointData.Normal);
				}
				Script.SetupPrefab(PedalPrefab);
			}
		}
	}
}
