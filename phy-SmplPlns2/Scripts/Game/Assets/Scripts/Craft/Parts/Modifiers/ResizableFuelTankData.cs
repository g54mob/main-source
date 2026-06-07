using System.Xml.Linq;
using Assets.Scripts.Design;
using Assets.Scripts.Design.PartProperties.Attributes;
using Jundroo.Common.Math;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	[PartModifierDesignerHeader("Fuel Tank")]
	public class ResizableFuelTankData : FuelTankData
	{
		private float _baseCapacity;

		private ResizableFuelTankScript _script;

		[DesignerPropertySlider(0.5f, 2.5f, 201, Label = "Size", Order = 0)]
		private float _size = 1f;

		public float Size => _size;

		public ResizableFuelTankData(XElement element)
			: base(element)
		{
			_baseCapacity = element.GetFloatAttribute("capacity", 100f);
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.Add(new XAttribute("size", _size));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_size")
			{
				return string.Format("{0:P0} ({1})", sliderValue, base.Capacity.Format(UnitType.Volume, solo: false, longName: false, "n1"));
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override PartModifierScript Initialize(GameObject parentGameObject, PartData.PartCreationInfo partCreationInfo, AircraftScript aircraftScript)
		{
			_script = parentGameObject.GetComponent<ResizableFuelTankScript>();
			_script.FuelTank = this;
			_script.ResizableFuelTank = this;
			return _script;
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_size")
			{
				base.Capacity = _baseCapacity * Mathf.Pow(_size, 3f);
				base.Fuel = base.Capacity;
				_script.UpdateSize();
				Designer.Instance.SetAircraftStructureChanged();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_size = stateElement.GetFloatAttribute("size", 1f);
		}

		protected override float CalculateMass()
		{
			float num = 10f * Mathf.Pow(_size, 2.2f);
			return (base.Fuel * 0.804f + num) * 0.01f;
		}
	}
}
