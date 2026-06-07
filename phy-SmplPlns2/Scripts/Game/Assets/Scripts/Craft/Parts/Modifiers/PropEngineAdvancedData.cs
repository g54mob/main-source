using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Propeller Engine")]
	public class PropEngineAdvancedData : BladedEngineData
	{
		[DesignerPropertySlider(0f, 1f, 100, Label = "Pitch Range", Order = 9)]
		private float _bladePitchScale;

		[DesignerPropertyToggleButton(new string[] { "Scimitar", "Warbird", "Cessna" }, Label = "Blade Style", Order = 5)]
		private string _bladeStyle;

		[DesignerPropertyToggleButton(new string[] { "False", "True" }, Label = "Reverse Rotation", Order = 6)]
		private bool _reverseRotation;

		public override string BladeStyle
		{
			get
			{
				return _bladeStyle;
			}
			set
			{
				_bladeStyle = value;
			}
		}

		public bool LegacyCotPos { get; private set; }

		public override float PerformanceCost => (float)Mathf.Max(0, base.BladeCount - 2) * 3f;

		public override float PropellerPitchScale
		{
			get
			{
				return _bladePitchScale;
			}
			set
			{
				_bladePitchScale = value;
			}
		}

		public override bool ReverseRotation
		{
			get
			{
				return _reverseRotation;
			}
			set
			{
				_reverseRotation = value;
			}
		}

		public PropEngineAdvancedData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("legacyCotPos", LegacyCotPos));
			return xElement;
		}

		public override void OnGenericDesignerPropertiesVisible(IGenericPartProperties genericPartPropertiesScript)
		{
			base.OnGenericDesignerPropertiesVisible(genericPartPropertiesScript);
			ISliderProperty property = genericPartPropertiesScript.GetProperty<ISliderProperty>("_diameter");
			property.SliderAttribute.MinValue = MinDiameter;
			property.SliderAttribute.MaxValue = MaxDiameter;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			LegacyCotPos = stateElement.GetBoolAttribute("legacyCotPos", defaultValue: true);
		}

		protected override BladedEngineScript AddBladedEngineModifier(GameObject gameObject)
		{
			return gameObject.AddComponent<PropEngineAdvancedScript>();
		}
	}
}
