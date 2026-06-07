using System;
using System.Xml.Linq;
using Assets.Scripts.Design.PartProperties.Attributes;

namespace Assets.Scripts.Craft.Parts.Modifiers.CarverParts
{
	public abstract class SimpleProceduralMeshModifierBaseData : ScalableMeshModifierBaseData
	{
		[DesignerPropertySlider(Label = "Corner Radius", MinValue = 0f, MaxValue = 1f, NumberOfSteps = 51)]
		private float _cornerRadius;

		public float CornerRadius
		{
			get
			{
				return _cornerRadius;
			}
			set
			{
				_cornerRadius = value;
				RaiseOnShapeChanged();
			}
		}

		protected SimpleProceduralMeshModifierBaseData(XElement element)
			: base(element)
		{
		}

		public override XElement GenerateStateXml()
		{
			XElement xElement = base.GenerateStateXml();
			xElement.SetAttributeValue("cornerRadius", DataIO.ToString(_cornerRadius));
			return xElement;
		}

		public override string GetGenericDesignerPropertySliderValueLabel(string propertyName, float sliderValue)
		{
			if (propertyName == "_cornerRadius")
			{
				return sliderValue.ToString("P0");
			}
			return base.GetGenericDesignerPropertySliderValueLabel(propertyName, sliderValue);
		}

		public override void OnGenericDesignerPropertyChanged(string propertyName, string value)
		{
			base.OnGenericDesignerPropertyChanged(propertyName, value);
			if (propertyName == "_cornerRadius")
			{
				RaiseOnShapeChanged();
			}
		}

		public override void RestoreFromState(XElement stateElement)
		{
			base.RestoreFromState(stateElement);
			_cornerRadius = stateElement.GetFloatAttribute("cornerRadius", 0.2f);
		}
	}
}
