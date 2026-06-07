using Assets.Scripts.Design.PartProperties.Attributes;
using Assets.Scripts.UI.Controls;

namespace Assets.Scripts.Design.UI.PartProperties
{
	public interface ISliderProperty : IConfigurableProperty
	{
		SliderControl Slider { get; }

		DesignerPropertySliderAttribute SliderAttribute { get; }

		float Value { get; set; }
	}
}
