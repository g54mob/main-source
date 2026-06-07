using Assets.Scripts.Craft;
using Assets.Scripts.UI;
using Assets.Scripts.UI.Controls;
using Jundroo.Common.Math;

namespace Assets.Scripts.Design.UI
{
	public class CraftPropertiesPanelScript : DesignerPanelScript
	{
		private ControlGroup _controls;

		private bool _update;

		public AircraftScript Aircraft => base.Designer.Aircraft;

		public override void InitializeDesignerPanel(DesignerUIScript designerUI)
		{
			base.InitializeDesignerPanel(designerUI);
			_controls = new ControlGroup(base.Widget.Context, base.Widget.FindWidget("list-item-parent"));
			ControlGroup controlGroup = _controls.CreateSubGroup("General");
			controlGroup.CreateText("Wingspan", () => GetStat(AircraftScript.AircraftStats.WingSpan).Format(UnitType.ShortDistance, solo: false, longName: false, "0.0"));
			controlGroup.CreateText("Length", () => GetStat(AircraftScript.AircraftStats.Length).Format(UnitType.ShortDistance, solo: false, longName: false, "0.0"));
			controlGroup.CreateText("Height", () => GetStat(AircraftScript.AircraftStats.Height).Format(UnitType.ShortDistance, solo: false, longName: false, "0.0"));
			controlGroup.CreateText("Empty Weight", () => GetStat(AircraftScript.AircraftStats.EmptyWeight).Format(UnitType.Mass));
			controlGroup.CreateText("Loaded Weight", () => GetStat(AircraftScript.AircraftStats.LoadedWeight).Format(UnitType.Mass));
			ControlGroup controlGroup2 = _controls.CreateSubGroup("Performance");
			controlGroup2.CreateText("HP/Weight Ratio", () => GetStat(AircraftScript.AircraftStats.HorsePowerToWeightRatio).ToString("n3"));
			controlGroup2.CreateText("Power/Weight Ratio", () => GetStat(AircraftScript.AircraftStats.PowerToWeightRatio).ToString("n3"));
			controlGroup2.CreateText("Wing Loading", () => GetStat(AircraftScript.AircraftStats.WingLoading).Format(UnitType.WingLoading, solo: false, longName: false, "0.0"));
			controlGroup2.CreateText("Wing Area", () => GetStat(AircraftScript.AircraftStats.WingArea).Format(UnitType.Area, solo: false, longName: false, "0.0"));
			controlGroup2.CreateText("Drag Points", () => GetStat(AircraftScript.AircraftStats.Drag).ToString("n0"));
			ControlGroup controlGroup3 = _controls.CreateSubGroup("Parts");
			controlGroup3.CreateText("Part Count", () => GetStat(AircraftScript.AircraftStats.PartCount).ToString("n0"));
			controlGroup3.CreateText("Control Surfaces", () => GetStat(AircraftScript.AircraftStats.ControlSurfaceCount).ToString("n0"));
			controlGroup3.CreateText("Performance Cost", () => GetStat(AircraftScript.AircraftStats.PerformanceCost).ToString("n0"));
			controlGroup3.CreateText("Selected Part Cost", () => PerformanceCost.CalculateCost(base.Designer.SelectedPart?.Part).ToString("n1"));
			base.Flyout.Opened += OnFlyoutOpened;
			_update = true;
			base.Designer.AircraftStructureChangedEvent += OnAircraftStructureChangedEvent;
		}

		protected virtual void Update()
		{
			if (_update)
			{
				_update = false;
				_controls.Update();
			}
		}

		private float GetStat(AircraftScript.AircraftStats stat)
		{
			return Aircraft.GetStats(stat);
		}

		private void OnAircraftStructureChangedEvent()
		{
			_update = true;
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			_update = true;
		}
	}
}
