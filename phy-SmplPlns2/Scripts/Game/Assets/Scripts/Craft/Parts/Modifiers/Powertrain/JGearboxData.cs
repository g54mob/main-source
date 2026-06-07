using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[PartModifierDesignerHeader("Gearbox")]
	public class JGearboxData : PartModifierData
	{
		private const float BaseSize = 0.75f;

		[DesignerPropertySlider(0f, 4f, 81, Label = "Gear Ratio", Order = 1, Tooltip = "Gear ratio of 2 would double the output torque and halve the RPM.")]
		private float _gearRatio = 1f;

		[DesignerPropertyToggleButton(new string[] { }, Label = "Reverse Output", Order = 30, Tooltip = "Reverses the direction of the output shaft.")]
		private bool _reversed;

		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Size", Order = 1)]
		private float _size = 1f;

		public float GearRatio => _gearRatio;

		public bool IsReversed => _reversed;

		public JGearboxScript Script { get; private set; }

		public float Size => 0.75f * _size;

		public float SizePercentage
		{
			get
			{
				return _size;
			}
			set
			{
				_size = value;
			}
		}

		public JGearboxData(XElement partType)
			: base(partType)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("size", _size);
			xElement.SetAttributeValue("reversed", _reversed);
			xElement.SetAttributeValue("gearRatio", _gearRatio);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_size")
			{
				return Utilities.FormatPercentage(sliderValue);
			}
			if (propertyName == "_gearRatio")
			{
				return $"{_gearRatio:n2}";
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.GetComponent<JGearboxScript>();
			Script.Initialize(this);
			return Script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			if (propertyName == "_size")
			{
				Script.UpdateScale();
				Designer.Instance.SetAircraftStructureChanged();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_size = stateElement.GetFloatAttribute("size", _size);
			_reversed = stateElement.GetBoolAttribute("reversed", _reversed);
			_gearRatio = stateElement.GetFloatAttribute("gearRatio", _gearRatio);
		}

		protected override float CalculateMass()
		{
			return 12.5f * Mathf.Pow(_size, 2.4f) * 0.01f;
		}
	}
}
