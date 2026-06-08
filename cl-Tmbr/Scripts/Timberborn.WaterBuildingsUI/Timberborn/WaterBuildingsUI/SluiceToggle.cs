using Timberborn.Localization;
using Timberborn.SliderToggleSystem;
using Timberborn.WaterBuildings;
using UnityEngine.UIElements;

namespace Timberborn.WaterBuildingsUI
{
	internal class SluiceToggle
	{
		private static readonly string AutoClass = "sluice-toggle__icon--auto";

		private static readonly string OpenClass = "sluice-toggle__icon--open";

		private static readonly string CloseClass = "sluice-toggle__icon--close";

		private static readonly string AutoLocKey = "Building.Sluice.Mode.Auto";

		private static readonly string OpenLocKey = "Building.Sluice.Mode.Open";

		private static readonly string ClosedLocKey = "Building.Sluice.Mode.Closed";

		private readonly SliderToggleFactory _sliderToggleFactory;

		private readonly ILoc _loc;

		private SluiceState _sluiceState;

		private SliderToggle _sliderToggle;

		public SluiceToggle(SliderToggleFactory sliderToggleFactory, ILoc loc)
		{
			_sliderToggleFactory = sliderToggleFactory;
			_loc = loc;
		}

		public void Initialize(VisualElement parent)
		{
			SliderToggleItem sliderToggleItem = SliderToggleItem.Create(() => _loc.T(AutoLocKey), AutoClass, delegate
			{
				_sluiceState.SetAuto();
			}, () => _sluiceState.AutoMode);
			SliderToggleItem sliderToggleItem2 = SliderToggleItem.Create(() => _loc.T(OpenLocKey), OpenClass, delegate
			{
				_sluiceState.Open();
			}, () => !_sluiceState.AutoMode && _sluiceState.IsOpen);
			SliderToggleItem sliderToggleItem3 = SliderToggleItem.Create(() => _loc.T(ClosedLocKey), CloseClass, delegate
			{
				_sluiceState.Close();
			}, () => !_sluiceState.AutoMode && !_sluiceState.IsOpen);
			_sliderToggle = _sliderToggleFactory.Create(parent, sliderToggleItem, sliderToggleItem2, sliderToggleItem3);
		}

		public void Show(SluiceState sluiceState)
		{
			_sluiceState = sluiceState;
		}

		public void Update()
		{
			if ((bool)_sluiceState)
			{
				_sliderToggle.Update();
			}
		}

		public void Clear()
		{
			_sluiceState = null;
		}
	}
}
