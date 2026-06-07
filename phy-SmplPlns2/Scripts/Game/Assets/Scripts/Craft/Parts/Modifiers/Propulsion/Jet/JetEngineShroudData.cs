using System;
using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion.Jet
{
	[Serializable]
	[PartModifierDesignerHeader("Jet Engine Shroud")]
	public class JetEngineShroudData : PartModifierData
	{
		private bool _connectedToEngine;

		[DesignerPropertySlider(0.75f, 1.25f, 51, Label = "Length", Order = 1, Tooltip = "Changes the length of the shroud.")]
		private float _length = 1f;

		[DesignerPropertyButton(Label = "Select Engine", Order = 200, Tooltip = "Select the engine inside of this shroud.")]
		private bool _selectEngine;

		[DesignerPropertyToggleButton(new string[] { "None" }, Label = "Shroud Style", Order = 150)]
		private string _shroudStyleID;

		public JetEngineType JetEngineType { get; set; } = JetEngineType.Civilian;

		public float Length => _length;

		public float Radius { get; set; } = 1f;

		public JetEngineShroudScript Script { get; private set; }

		public JetEnginePrefabs.ShroudPrefab ShroudPrefab { get; private set; }

		private JetEnginePrefabs Prefabs => Game.Instance.CraftResourceData.JetEnginePrefabs;

		public JetEngineShroudData(XElement element)
			: base(element)
		{
		}

		public JetEngineData FindConnectedEngine()
		{
			return (from x in base.Part.PartConnections
				select x.GetOtherPart(base.Part)?.GetModifier<JetEngineData>() into x
				where x != null
				select x).FirstOrDefault();
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("jetEngineType", JetEngineType), new XAttribute("style", ShroudPrefab.Id), new XAttribute("radius", Radius), new XAttribute("length", _length));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_length")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override string GetGenericDesignerPropertyToggleButtonValueLabel(string propertyName, string value)
		{
			if (propertyName == "_shroudStyleID")
			{
				return ShroudPrefab.name;
			}
			return base.GetGenericDesignerPropertyToggleButtonValueLabel(propertyName, value);
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			if (property.Member.Name == "_selectEngine")
			{
				return () => _connectedToEngine;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<JetEngineShroudScript>();
			Script.Data = this;
			return Script;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			JetEnginePrefabs.JetEnginePrefab[] shrouds = Prefabs.Shrouds;
			ConfigureToggleButton(genericPartPropertiesScript, "_shroudStyleID", shrouds);
			_connectedToEngine = FindConnectedEngine() != null;
		}

		public override void OnGenericDesignerPropertyButtonClicked(IConfigurableProperty property)
		{
			base.OnGenericDesignerPropertyButtonClicked(property);
			if (property.Member.Name == "_selectEngine")
			{
				JetEngineData jetEngineData = FindConnectedEngine();
				if (jetEngineData != null)
				{
					Designer.Instance.SelectedPart = jetEngineData.Part.PartScript;
				}
			}
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_shroudStyleID")
			{
				ShroudPrefab = Prefabs.GetShroud(_shroudStyleID, JetEngineType);
			}
			Script.UpdateStyles();
			Designer.Instance.SetAircraftStructureChanged();
		}

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
			Script.OnModifiersCreated();
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			JetEngineType = stateElement.GetEnumAttribute("jetEngineType", JetEngineType.Civilian);
			_length = stateElement.GetFloatAttribute("length", _length);
			Radius = stateElement.GetFloatAttribute("radius", Radius);
			string stringAttribute = stateElement.GetStringAttribute("style");
			ShroudPrefab = Prefabs.GetShroud(stringAttribute, JetEngineType);
			_shroudStyleID = ShroudPrefab.Id;
		}

		protected override float CalculateMass()
		{
			return Radius * Radius * 200f * Length * 0.01f;
		}

		private void ConfigureToggleButton(IGenericPartProperties genericPartPropertiesScript, string propertyName, JetEnginePrefabs.JetEnginePrefab[] prefabs)
		{
			ToggleButtonProperty property = genericPartPropertiesScript.GetProperty<ToggleButtonProperty>(propertyName);
			property.ButtonAttribute.Values.Clear();
			property.ButtonAttribute.Values.AddRange(from x in prefabs
				where x.supportedJetEngineTypes.HasFlag(JetEngineType)
				orderby x.Id
				select x.Id);
		}
	}
}
