using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.Design.UI.PartProperties;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Seat")]
	public class SeatData : PartModifierData
	{
		private string _animation = "Characters/Animations/Controllers/SeatCockpit";

		[DesignerPropertyVector(0.01, -7.922816251426433E+28, 7.922816251426433E+28, Label = "Exit Position", Order = 30)]
		private Vector3 _exitPosition = Vector3.zero;

		[DesignerPropertyVector(5, int.MinValue, int.MaxValue, Label = "Exit Rotation", Order = 40)]
		private Vector3 _exitRotation = Vector3.zero;

		[DesignerPropertyToggleButton(new string[] { "Set", "Is Primary" }, Label = "Set As Main", Order = 20)]
		private bool _primarySeat;

		[DesignerPropertySlider(MinValue = 0f, MaxValue = 90f, NumberOfSteps = 91, Label = "Reclination", Order = 25)]
		private float _reclination;

		private string _reclinerPath;

		private SeatScript _script;

		private Vector3 _seatedPosition = Vector3.zero;

		private Vector3 _seatedRotation = Vector3.zero;

		private Vector3 _stockSeatedPosition;

		private Vector3 _stockSeatedRotation;

		public string Animation => _animation;

		public Vector3 ExitPosition
		{
			get
			{
				return _exitPosition;
			}
			set
			{
				_exitPosition = value;
			}
		}

		public Vector3 ExitRotation
		{
			get
			{
				return _exitRotation;
			}
			set
			{
				_exitRotation = value;
			}
		}

		public Type ModifierScriptType => typeof(SeatScript);

		public bool PrimarySeat
		{
			get
			{
				return _primarySeat;
			}
			set
			{
				_primarySeat = value;
			}
		}

		public float Reclination => _reclination;

		public string ReclinerPath => _reclinerPath;

		public Vector3 SeatedPosition
		{
			get
			{
				return _seatedPosition;
			}
			set
			{
				_seatedPosition = value;
			}
		}

		public Vector3 SeatedRotation
		{
			get
			{
				return _seatedRotation;
			}
			set
			{
				_seatedRotation = value;
			}
		}

		public SeatData(XElement element)
			: base(element)
		{
			_animation = element.GetStringAttribute("animation", _animation);
			_stockSeatedPosition = element.GetVector3Attribute("seatedPosition", Vector3.zero);
			_seatedPosition = _stockSeatedPosition;
			_stockSeatedRotation = element.GetVector3Attribute("seatedRotation", Vector3.zero);
			_seatedRotation = _stockSeatedRotation;
			_reclination = element.GetFloatAttribute("reclination");
			_reclinerPath = element.GetStringAttributeOrNullIfWhitespace("reclinerPath");
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("primarySeat", PrimarySeat.ToString()), new XAttribute("reclination", _reclination.ToString("n1")), new XAttribute("exitPosition", _exitPosition.ToXAttributeValue()), new XAttribute("exitRotation", _exitRotation.ToXAttributeValue()));
			if (_seatedPosition != _stockSeatedPosition)
			{
				xElement.Add(new XAttribute("seatedPosition", _seatedPosition.ToXAttributeValue()));
			}
			if (_seatedRotation != _stockSeatedRotation)
			{
				xElement.Add(new XAttribute("seatedPosition", _seatedRotation.ToXAttributeValue()));
			}
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_reclination")
			{
				return sliderValue.ToString("n0") + "°";
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override Func<bool> GetGenericDesignerPropertyVisibilityCallback(IConfigurableProperty property)
		{
			string name = property.Member.Name;
			if (!(name == "_primarySeat"))
			{
				if (name == "_reclination")
				{
					return () => !string.IsNullOrEmpty(_reclinerPath) && _script?.ReclinerTransform != null;
				}
				return base.GetGenericDesignerPropertyVisibilityCallback(property);
			}
			return () => !_primarySeat;
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			_script = parentGameObject.AddComponent<SeatScript>();
			_script.Initialize(this);
			return _script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_primarySeat")
			{
				_script.PrimarySeat = _primarySeat;
			}
			if (propertyName == "_reclination" && _script != null)
			{
				_script.UpdateReclination();
			}
		}

		public override void OnPartCloned(PartData sourcePart)
		{
			base.OnPartCloned(sourcePart);
			_primarySeat = false;
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			PrimarySeat = stateElement.GetBoolAttribute("primarySeat");
			_reclination = stateElement.GetFloatAttribute("reclination", _reclination);
			_exitPosition = stateElement.GetVector3Attribute("exitPosition", Vector3.zero);
			_exitRotation = stateElement.GetVector3Attribute("exitRotation", Vector3.zero);
			_seatedPosition = stateElement.GetVector3Attribute("seatedPosition", _stockSeatedPosition);
			_seatedRotation = stateElement.GetVector3Attribute("seatedRotation", _stockSeatedRotation);
		}
	}
}
