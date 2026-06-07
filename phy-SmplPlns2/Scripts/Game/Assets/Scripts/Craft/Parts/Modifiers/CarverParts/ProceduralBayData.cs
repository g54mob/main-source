using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	[PartModifierDesignerHeader("Procedural Bay")]
	public class ProceduralBayData : SimpleProceduralMeshModifierBaseData
	{
		private DoorStyle _doorStyle;

		private bool _startOpen;

		public bool StartOpen => _startOpen;

		public DoorStyle DoorStyle => _doorStyle;

		public event Action OnDoorSettingsChanged;

		public ProceduralBayData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("doorStyle", _doorStyle);
			xElement.SetAttributeValue("startOpen", _startOpen);
			return xElement;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (!(propertyName == "_startOpen"))
			{
				if (propertyName == "_doorStyle")
				{
					RaiseOnShapeChanged();
				}
				else
				{
					base.OnGenericDesignerPropertyChanged(propertyName, value);
				}
			}
			else
			{
				this.OnDoorSettingsChanged?.Invoke();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_doorStyle = stateElement.GetEnumAttribute("doorStyle", DoorStyle.None);
			_startOpen = stateElement.GetBoolAttribute("startOpen");
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			ProceduralBayScript proceduralBayScript = parentGameObject.AddComponent<ProceduralBayScript>();
			proceduralBayScript.Initialize(this);
			return proceduralBayScript;
		}
	}
}
