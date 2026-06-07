using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	[PartModifierDesignerHeader("Procedural Window")]
	public class ProceduralWindowData : TrapezoidMeshModifierData
	{
		[DesignerPropertyToggleButton(new string[] { "No", "Yes" }, Label = "Hide Glass", AllowFunkyInput = false)]
		private bool _hideGlass;

		public bool HideGlass
		{
			get
			{
				return _hideGlass;
			}
			set
			{
				_hideGlass = value;
				RaiseOnShapeChanged();
			}
		}

		public ProceduralWindowData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttribute("hideGlass", _hideGlass);
			return xElement;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			ProceduralWindowScript proceduralWindowScript = parentGameObject.AddComponent<ProceduralWindowScript>();
			proceduralWindowScript.Initialize(this);
			return proceduralWindowScript;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_hideGlass")
			{
				RaiseOnShapeChanged();
			}
			else
			{
				base.OnGenericDesignerPropertyChanged(propertyName, value);
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_hideGlass = stateElement.GetBoolAttribute("hideGlass");
		}
	}
}
