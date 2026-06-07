using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Cockpit")]
	public class CockpitData : PartModifierData, IModifierWithOutputs
	{
		private static readonly Vector2 DefaultLookBackTranslation = new Vector2(0.3f, 0f);

		[DesignerPropertyToggleButton(new string[] { "Disabled", "Enabled" }, Label = "Camera")]
		private bool _hasCameraDefault;

		[DesignerPropertyToggleButton(new string[] { "Set", "Is Primary" }, Label = "Set As Main")]
		private bool _primaryCockpit;

		private CockpitScript _script;

		public bool HasCamera { get; set; }

		public Vector2 LookBackTranslation { get; set; }

		public Type ModifierScriptType => typeof(CockpitScript);

		public bool PrimaryCockpit
		{
			get
			{
				return _primaryCockpit;
			}
			set
			{
				_primaryCockpit = value;
			}
		}

		public CockpitData(XElement element)
			: base(element)
		{
			HasCamera = (_hasCameraDefault = element.GetBoolAttribute("hasCamera", defaultValue: true));
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("primaryCockpit", PrimaryCockpit.ToString()));
			xElement.Add((LookBackTranslation == DefaultLookBackTranslation) ? null : new XAttribute("lookBackTranslation", LookBackTranslation.ToXAttributeValue()));
			xElement.Add((HasCamera == _hasCameraDefault) ? null : new XAttribute("hasCamera", HasCamera));
			return xElement;
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			if (property.Member.Name == "_primaryCockpit")
			{
				return () => !_primaryCockpit;
			}
			if (property.Member.Name == "_hasCameraDefault")
			{
				return () => _primaryCockpit;
			}
			return base.GetGenericDesignerPropertyVisibilityCallback(property);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			_script = parentGameObject.AddComponent<CockpitScript>();
			_script.Initialize(this);
			return _script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_primaryCockpit")
			{
				_script.PrimaryCockpit = _primaryCockpit;
			}
		}

		public override void OnPartCloned(PartData sourcePart)
		{
			base.OnPartCloned(sourcePart);
			_primaryCockpit = false;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			PrimaryCockpit = stateElement.GetBoolAttribute("primaryCockpit");
			LookBackTranslation = stateElement.GetVector2Attribute("lookBackTranslation", DefaultLookBackTranslation);
			HasCamera = stateElement.GetBoolAttribute("hasCamera", HasCamera);
		}
	}
}
