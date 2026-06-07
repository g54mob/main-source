using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Math;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Car
{
	[PartModifierDesignerHeader("Wheel Suspension")]
	public class JWheelSuspensionData : PartModifierData
	{
		private const float BaseSize = 0.5f;

		private const float BaseSuspensionLength = 0.25f;

		private const float DefaultDamper = 1f;

		private const float DefaultStiffness = 1f;

		[DesignerPropertySlider(0f, 2.5f, 51, Label = "Damper", Order = 20)]
		private float _damper = 1f;

		[DesignerPropertySlider(1f, 2f, 21, Label = "Extension", Order = 6)]
		private float _extension = 1f;

		[DesignerPropertySlider(0f, 2f, 201, Label = "Ride Height", Order = 8)]
		private float _rideHeight = 1f;

		[DesignerPropertySlider(-1f, 1f, 101, Label = "Shock Position", Order = 25, Tooltip = "The position of the shock. Purely cosmetic.")]
		private float _shockPosition = 1f;

		[DesignerPropertySlider(0.5f, 2.5f, 41, Label = "Size", Order = 5)]
		private float _size = 1f;

		[DesignerPropertySlider(0.1f, 2.5f, 49, Label = "Stiffness", Order = 15)]
		private float _stiffness = 1f;

		[DesignerPropertySlider(0f, 2f, 201, Label = "Suspension Travel", Order = 10, Header = "Suspension")]
		private float _suspensionLength = 1f;

		public float Damper => _damper;

		public float Extension => _extension;

		public float RideHeight => 0.25f * Size * _rideHeight;

		public float RideHeightScale => _rideHeight;

		public JWheelSuspensionScript Script { get; private set; }

		public float ShockPosition
		{
			get
			{
				return _shockPosition;
			}
			set
			{
				_shockPosition = value;
			}
		}

		public float Size => 0.5f * _size;

		public float Stiffness => _stiffness;

		public float SuspensionLength => 0.25f * Size * _suspensionLength;

		public JWheelSuspensionData(XElement partType)
			: base(partType)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("damper", _damper);
			xElement.SetAttributeValue("extension", _extension);
			xElement.SetAttributeValue("rideHeight", _rideHeight);
			xElement.SetAttributeValue("shockPosition", _shockPosition);
			xElement.SetAttributeValue("size", _size);
			xElement.SetAttributeValue("stiffness", _stiffness);
			xElement.SetAttributeValue("suspensionLength", _suspensionLength);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_damper":
			case "_shockPosition":
			case "_stiffness":
			case "_size":
				return Utilities.FormatPercentage(sliderValue);
			case "_rideHeight":
				return Utilities.FormatPercentage(sliderValue) + " (" + RideHeight.Format(UnitType.TinyDistance, solo: false, longName: false, "n1") + ")";
			case "_suspensionLength":
				return Utilities.FormatPercentage(sliderValue) + " (" + SuspensionLength.Format(UnitType.TinyDistance, solo: false, longName: false, "n1") + ")";
			case "_extension":
				return Utilities.FormatPercentage(_extension - 1f);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.AddComponent<JWheelSuspensionScript>();
			Script.Initialize(this);
			return Script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			Script.OnPropertiesChanged();
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_damper = stateElement.GetFloatAttribute("damper", _damper);
			_extension = Mathf.Clamp(stateElement.GetFloatAttribute("extension", _extension), 1f, 5f);
			_shockPosition = stateElement.GetFloatAttribute("shockPosition", _shockPosition);
			_size = stateElement.GetFloatAttribute("size", _size);
			_stiffness = stateElement.GetFloatAttribute("stiffness", _stiffness);
			_suspensionLength = stateElement.GetFloatAttribute("suspensionLength", _suspensionLength);
			_rideHeight = stateElement.GetFloatAttribute("rideHeight", _suspensionLength);
		}

		protected override float CalculateMass()
		{
			return Mathf.Pow(Size * 0.5f, 3f) * 5000f * 0.15f * Extension * 0.01f;
		}
	}
}
