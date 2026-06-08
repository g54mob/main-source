using Timberborn.Localization;
using Timberborn.SliderToggleSystem;
using UnityEngine.UIElements;

namespace Timberborn.WaterBuildingsUI
{
	internal class SluiceToggleFactory
	{
		private readonly SliderToggleFactory _sliderToggleFactory;

		private readonly ILoc _loc;

		public SluiceToggleFactory(SliderToggleFactory sliderToggleFactory, ILoc loc)
		{
			_sliderToggleFactory = sliderToggleFactory;
			_loc = loc;
		}

		public SluiceToggle Create(VisualElement parent)
		{
			SluiceToggle sluiceToggle = new SluiceToggle(_sliderToggleFactory, _loc);
			sluiceToggle.Initialize(parent);
			return sluiceToggle;
		}
	}
}
