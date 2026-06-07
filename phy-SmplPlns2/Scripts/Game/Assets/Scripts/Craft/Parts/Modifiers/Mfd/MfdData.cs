using System;
using System.Reflection;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	[Obfuscation(Exclude = true)]
	[PartModifierDesignerHeader("MFD")]
	public class MfdData : PartModifierData, ISelectPartPropertyModifier
	{
		[DesignerPropertyPartId(Label = "Targeting Pod", Order = 1, MustBeConnected = true, StartMessage = "Select the targeting pod.", NoOptionsMessage = "No targeting pods available.", Tooltip = "Links this MFD to a specific Targeting Pod. If None, the system auto-assigns the first one it can find.")]
		private int _targetingPod;

		public Type ModifierScriptType => typeof(MfdScript);

		public int TargetingPod => _targetingPod;

		public MfdData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("targetingPod", _targetingPod);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			MfdScript mfdScript = parentGameObject.AddComponent<MfdScript>();
			mfdScript.Data = this;
			return mfdScript;
		}

		public void OnPartSelectionToolClosed(string fieldName, PartData part)
		{
		}

		public bool OnPartSelectionToolFilterPart(string fieldName, PartData part)
		{
			return part.GetModifier<TargetingPodData>() != null;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_targetingPod = stateElement.GetIntAttribute("targetingPod");
		}
	}
}
