using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Powertrain
{
	[PartModifierDesignerHeader("Differential")]
	public class JDifferentialData : PartModifierData
	{
		private const float BaseSize = 1f;

		[DesignerPropertySlider(0f, 5f, 201, Label = "Coast Stiffness", Order = 12, Tooltip = "Adjusts the responsiveness of the differential under braking. Higher values make the lock react more quickly to slip, while lower values feel smoother and less snappy.")]
		private float _coastStiffness = 0.5f;

		[DesignerPropertySlider(0f, 1f, 21, Label = "Differential Lock", Order = 10, Tooltip = "Controls how much power is transferred to the wheel with more grip. Higher values provide more traction when accelerating but can make turning more difficult.")]
		private float _lock;

		[DesignerPropertySlider(0f, 2f, 201, Label = "Powered Stiffness", Order = 11, Tooltip = "Adjusts the responsiveness of the differential under acceleration. Higher values make the lock react more quickly to slip, while lower values feel smoother and less snappy.")]
		private float _powerStiffness = 1f;

		[DesignerPropertySlider(0.5f, 2f, 31, Label = "Size", Order = 1)]
		private float _size = 1f;

		public float CoastStiffness => _coastStiffness;

		public float DifferentialLock => _lock;

		public float PowerStiffness => _powerStiffness;

		public JDifferentialScript Script { get; private set; }

		public float Size => 1f * _size;

		public JDifferentialData(XElement partType)
			: base(partType)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("size", _size);
			xElement.SetAttributeValue("lock", _lock);
			xElement.SetAttributeValue("powerStiffness", _powerStiffness);
			xElement.SetAttributeValue("coastStiffness", _coastStiffness);
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			switch (propertyName)
			{
			case "_lock":
				if (_lock <= 0f)
				{
					return "Open";
				}
				if (_lock >= 1f)
				{
					return "Locked";
				}
				return Utilities.FormatPercentage(_lock);
			case "_size":
			case "_coastStiffness":
			case "_powerStiffness":
				return Utilities.FormatPercentage(sliderValue);
			default:
				return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
			}
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			Script = parentGameObject.GetComponent<JDifferentialScript>();
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
			_lock = stateElement.GetFloatAttribute("lock", _lock);
			_powerStiffness = stateElement.GetFloatAttribute("powerStiffness", _powerStiffness);
			_coastStiffness = stateElement.GetFloatAttribute("coastStiffness", _coastStiffness);
		}

		protected override float CalculateMass()
		{
			return 20f * Mathf.Pow(_size, 2.4f) * 0.01f;
		}
	}
}
