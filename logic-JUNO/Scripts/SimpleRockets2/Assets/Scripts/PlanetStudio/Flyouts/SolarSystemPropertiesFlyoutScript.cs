using System.Globalization;
using ModApi;
using ModApi.Common.Events;
using ModApi.Flight.Sim;
using ModApi.Math;
using ModApi.Planet;
using ModApi.Ui;
using ModApi.Ui.Inspector;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.PlanetStudio.Flyouts
{
	public class SolarSystemPropertiesFlyoutScript : PlanetStudioFlyoutScript
	{
		private bool _requireReload;

		public PlanetDataScript PlanetData => base.PlanetStudioUI.PlanetStudioScript?.CelestialBodyDesignerScript?.CurrentCelestialBody;

		private PlanetAtmosphereData AtmosphereData => PlanetData.AtmosphereData;

		protected override void OnInitialized(PlanetStudioUIScript planetStudioUI)
		{
			base.OnInitialized(planetStudioUI);
			base.Flyout.Opened += OnFlyoutOpened;
			base.Flyout.Closed += OnFlyoutClosed;
		}

		private void OnFlyoutClosed(IFlyout flyout)
		{
			SolarSystemDataScript solarSystemDataScript = PlanetStudioScript.Instance?.PlanetarySystemDesigner?.CurrentPlanetarySystem;
			if (solarSystemDataScript != null)
			{
				PlanetarySystemDesignerScript.Instance.MapViewManager.MapView.MaxZoomDistance = solarSystemDataScript.MaximumMapViewZoom;
			}
			if (_requireReload)
			{
				Game.Instance.UserInterface.CreateMessageDialog("The system must be saved and re-loaded for changes to take effect");
			}
			ClearModelElements();
		}

		private void OnFlyoutOpened(IFlyout flyout)
		{
			_requireReload = false;
			InspectorModel inspectorModel = new InspectorModel("Properties", "Properties");
			GroupModel groupModel = new GroupModel("Metadata");
			SolarSystemDataScript ps = PlanetStudioScript.Instance?.PlanetarySystemDesigner?.CurrentPlanetarySystem;
			TextInputModel item = new TextInputModel("Name", () => ps.Name, delegate(string s)
			{
				ps.Name = s;
			});
			TextInputModel item2 = new TextInputModel("Version", () => ps.Version.ToString(), delegate(string s)
			{
				ps.Version = Utilities.FormatVersion(s, ps.Version);
			});
			TextInputModel item3 = new TextInputModel("Version Tag", () => ps.VersionTag, delegate(string s)
			{
				ps.VersionTag = s;
			});
			TextInputModel textInputModel = new TextInputModel(string.Empty, () => ps.Description, delegate(string s)
			{
				ps.Description = s;
			});
			NumericInputModel numericInputModel = new NumericInputModel("Max Zoom", () => ps.MaximumMapViewZoom, delegate(double x)
			{
				ps.MaximumMapViewZoom = x;
			}, 0.0);
			NumericInputModel numericInputModel2 = new NumericInputModel("Map Scale", () => ps.MapViewScale, null, 0.0);
			numericInputModel2.ValueSetter = delegate(double x)
			{
				ps.MapViewScale = x;
				_requireReload = true;
			};
			numericInputModel.Tooltip = "The maximum zooom distance for map-view";
			numericInputModel2.Tooltip = "The amount to scale distance from in-game distances to map-view space. It does not change the apparent/relative size/distances. The default value should work for most systems.  For very large, or very small systems, the value may need to change.  It will always be a trade-off between the two extremes.  For instance, decreasing the value will allow for larger systems, but may result in camera jitter when viewing a small planet up close.  Increasing the value will allow for more stable viewing of smaller planets, but camera rendering may become unstable at very large viewing distances.";
			numericInputModel.DisplayFormatter = DistanceFormatter;
			numericInputModel2.DisplayFormatter = DistanceFormatter;
			textInputModel.Alignment = ElementAlignment.TopLeft;
			textInputModel.EnableWordWrapping = true;
			textInputModel.MultiLine = true;
			textInputModel.NavigationMode = Navigation.Mode.None;
			groupModel.Add(item);
			groupModel.Add(item2);
			groupModel.Add(item3);
			groupModel.Add(numericInputModel);
			groupModel.Add(numericInputModel2);
			groupModel.Add(new LabelModel("Description"));
			TableRowModel tableRowModel = new TableRowModel();
			tableRowModel.Add(textInputModel);
			tableRowModel.PreferredHeight = 300;
			groupModel.Add(tableRowModel);
			inspectorModel.AddGroup(groupModel);
			GroupModel groupModel2 = new GroupModel("Misc");
			TextButtonModel textButtonModel = new TextButtonModel("Tare Time", delegate
			{
				PlanetarySystemDesignerScript.Instance.TareTime();
			});
			textButtonModel.Tooltip = "Set the time to zero, while keeping all planets in their current position";
			groupModel2.Add(textButtonModel);
			TextButtonModel textButtonModel2 = new TextButtonModel("Zero Time", delegate
			{
				PlanetarySystemDesignerScript.Instance.MapViewManager.Ioc.Resolve<IGameTime>().Time = 0.0;
			});
			textButtonModel2.Tooltip = "Sets the time to zero";
			groupModel2.Add(textButtonModel2);
			TextButtonModel textButtonModel3 = new TextButtonModel("Validate Orbits", delegate
			{
				OnValidateClicked();
			});
			textButtonModel3.Tooltip = "Validates all orbits, and colors orbits red if any fails validation.  Orbits which are not colored red have passed validation.";
			groupModel2.Add(textButtonModel3);
			ColorModel colorModel = new ColorModel("Star Flare Color", () => ps.FlareColor, delegate(Color x)
			{
				ps.FlareColor = x;
			}, allowTransparency: false, callbackOnPreviewColorChange: true);
			colorModel.Tooltip = "Changes the color of the flares seen when the camera is pointed at the main star of the system.";
			groupModel2.Add(colorModel);
			inspectorModel.AddGroup(groupModel2);
			BuildFromModel(inspectorModel);
			static string DistanceFormatter(double val)
			{
				return Mathd.Max(val, 0.0).ToString("0.###e-0", CultureInfo.InvariantCulture);
			}
		}

		private void OnValidateClicked()
		{
			float maxValidationTime = PlanetarySystemDesignerScript.Instance.GetMaxValidationTime();
			MessageDialogScript timeWarningDialog = Game.Instance.UserInterface.CreateMessageDialog(MessageDialogType.NoButtons, null, fadeIn: false);
			timeWarningDialog.MessageText = "Validating planetary system. Depending on the configuration, and how many planets there are this can take a while.  Planets which have a high probability of having an encounter, will take longer to validate.  It should take a maximum of " + Units.GetRelativeTimeString(maxValidationTime);
			UnityEventDispatcher.Instance.ExecuteYield<WaitForEndOfFrame>(delegate(int? x)
			{
				if (x == 0)
				{
					PlanetarySystemDesignerScript.Instance.ValidatePlanetOrbits();
					timeWarningDialog.Close();
				}
			}, 2);
		}
	}
}
