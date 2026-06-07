using Assets.Dev.Philip.UiTesting.Scripts;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Interfaces.Contexts;
using Assets.Scripts.Flight.MapView.Orbits.DrawModes.Interfaces.IDrawMode;
using Assets.Scripts.Flight.MapView.Orbits.Interfaces;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using ModApi.Ui.Inspector;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class MapDebugModel
	{
		private IMapOptions _mapOptions;

		private INavigationTargetProvider _navigationTargetProvider;

		private IOrbitLineManager _orbitLineManager;

		private TextButtonModel _pinEncounterButton;

		public GroupModel Group { get; set; }

		public MapDebugModel(IIocContainer ioc, IMapViewContext mapViewContext)
		{
			Group = new GroupModel("Debug");
			_mapOptions = ioc.Resolve<IMapOptions>();
			_navigationTargetProvider = ioc.Resolve<INavigationTargetProvider>(mapViewContext);
			_orbitLineManager = ioc.Resolve<IOrbitLineManager>(mapViewContext);
			SliderModel encounterDistanceSlider = new SliderModel("Encounter Distance", () => (float)(_mapOptions.Targeting.CraftSoiDistance / 5000000.0 * 2.0), delegate(float x)
			{
				_mapOptions.Targeting.CraftSoiDistance = (double)x * 5000000.0 / 2.0;
			});
			encounterDistanceSlider.ValueFormatter = (float x) => $"{(int)((double)encounterDistanceSlider.Value * 5000000.0 / 1000.0)}km";
			SliderModel item = new SliderModel("Local Minima Modifier", () => (float)_mapOptions.Targeting.SoiEntryLocalMinimaModifier, delegate(float x)
			{
				_mapOptions.Targeting.SoiEntryLocalMinimaModifier = x;
			}, 0.25f, 10f);
			SliderModel maxBurnTimeSlider = new SliderModel("Max Burn Time (s)", () => (float)_mapOptions.NodeNav.MaxBurnTimePerPass, delegate(float x)
			{
				_mapOptions.NodeNav.MaxBurnTimePerPass = x;
			}, 5f, 120f);
			maxBurnTimeSlider.ValueFormatter = (float x) => $"{maxBurnTimeSlider.Value}s";
			_pinEncounterButton = new TextButtonModel(GetPinnedButtonText(), delegate
			{
				PinCurrentEncounter();
			});
			Group.Add(encounterDistanceSlider);
			Group.Add(item);
			Group.Add(maxBurnTimeSlider);
			Group.Add(new EnumDropdownModel<ModeType>("Orbit Draw mode", () => _orbitLineManager.Drawmode)).ValueChanged += OnDrawModeValueChanged;
			Group.Add(new ToggleModel("BinarySearch", () => _mapOptions.Targeting.UseBinarySearch, delegate(bool x)
			{
				_mapOptions.Targeting.UseBinarySearch = x;
			}));
			Group.Add(new ToggleModel("SearchWholeOrbit", () => _mapOptions.Targeting.SearchWholeOrbit, delegate(bool x)
			{
				_mapOptions.Targeting.SearchWholeOrbit = x;
			}));
			Group.Add(new ToggleModel("ShowBurnAccuracyGizmos", () => _mapOptions.ManeuverNodes.ShowBurnAccuracyDebugGizmos, delegate(bool x)
			{
				_mapOptions.ManeuverNodes.ShowBurnAccuracyDebugGizmos = x;
			}));
			Group.Add(_pinEncounterButton);
			Group.Add(new TextButtonModel("Debug", delegate
			{
				InfoPanel.ToggleVisibility();
			}));
		}

		private string GetPinnedButtonText()
		{
			if (!_navigationTargetProvider.Pinned)
			{
				return "Pin";
			}
			return "Unpin";
		}

		private void OnDrawModeValueChanged(ModeType newVal, ModeType oldVal)
		{
			_orbitLineManager.SetOrbitDrawMode(newVal, craftOnly: false);
		}

		private void PinCurrentEncounter()
		{
			_navigationTargetProvider.SetPinned(!_navigationTargetProvider.Pinned);
			_pinEncounterButton.Label = GetPinnedButtonText();
		}
	}
}
