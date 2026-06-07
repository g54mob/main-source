using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using ModApi.Ui.Inspector;

namespace Assets.Scripts.Flight.MapView.UI.Inspector
{
	public class OptionsModel
	{
		private IMapOptions _mapOptions;

		private MapViewInspectorScript _mapViewInspector;

		private LabelButtonModel _orbitLineVisibilityButton;

		public GroupModel Group { get; set; }

		public OptionsModel(IIocContainer ioc, MapViewInspectorScript mapViewInspector)
		{
			_mapOptions = ioc.Resolve<IMapOptions>();
			_mapViewInspector = mapViewInspector;
			SliderModel item = new SliderModel("Gizmo Sensitivity (Global)", () => (float)_mapOptions.ManeuverNodes.SensitivityLinear, delegate(float x)
			{
				_mapOptions.ManeuverNodes.SensitivityLinear = x;
			}, 0.01f)
			{
				ManualInputMinValue = 0.001f,
				ManualInputMaxValue = 2f,
				Tooltip = "Adjusts the global sensitivity of planned burn node delta-v adjustment gizmos. This is applied globally and in addition to the per-node sensitivity settings. Lower sensitivity results in smaller delta-v changes when interacting with the planned burn gizmos."
			};
			Group = new GroupModel("Map Options");
			Group.Add(item);
			Group.Add(new EnumDropdownModel<OrbitUiVerbosity>("UI Verbosity", () => _mapOptions.OrbitUiVerbosity)).ValueChanged += OnApsidesVilibilityChanged;
			Group.Add(new EnumDropdownModel<MapViewFontSize>("UI Font Size", () => _mapOptions.FontSize)).ValueChanged += OnFontSizeChanged;
			Group.Add(new EnumDropdownModel<GizmoAlignmentType>("Gizmo Align", () => _mapOptions.BurnGizmoAlignment, "Determines how the burn gizmo is aligned.  It can be statically aligned with the reference orbit, or change dynamically to align with the orbit resulting from the burn.  Switching between options does not alter the existing burn vector.")).ValueChanged += OnBurnGizmoAlignmentValueChanged;
			Group.Add(new TextButtonModel("Defaults", delegate
			{
				ResetToDefaults();
			}));
		}

		private void OnApsidesVilibilityChanged(OrbitUiVerbosity newVal, OrbitUiVerbosity oldVal)
		{
			_mapOptions.OrbitUiVerbosity = newVal;
		}

		private void OnBurnGizmoAlignmentValueChanged(GizmoAlignmentType newVal, GizmoAlignmentType oldVal)
		{
			_mapOptions.BurnGizmoAlignment = newVal;
			ManeuverNodeScript maneuverNodeScript = _mapViewInspector.PlayerCraft.ChainNodeSelection.Selected as ManeuverNodeScript;
			if (maneuverNodeScript != null)
			{
				maneuverNodeScript.OnBurnGizmoAlignmentChanged();
			}
		}

		private void OnFontSizeChanged(MapViewFontSize newVal, MapViewFontSize oldVal)
		{
			_mapOptions.FontSize = newVal;
		}

		private void ResetToDefaults()
		{
			_mapOptions.ResetDefaults();
		}
	}
}
