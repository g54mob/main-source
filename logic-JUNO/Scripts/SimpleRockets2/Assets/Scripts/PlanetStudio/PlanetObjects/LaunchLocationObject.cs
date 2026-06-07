using System;
using Assets.Scripts.Flight.GameView;
using Assets.Scripts.PlanetStudio.Flyouts;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.State;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.PlanetObjects
{
	public class LaunchLocationObject : SurfaceObject
	{
		private LaunchLocation _launchLocation;

		public override AltitudeType AltitudeType => AltitudeType.AboveGroundLevel;

		public override double Elevation
		{
			get
			{
				return _launchLocation.AltitudeAboveGroundLevel;
			}
			set
			{
				_launchLocation.AltitudeAboveGroundLevel = value;
			}
		}

		public override double Heading
		{
			get
			{
				return _launchLocation.HeadingSimple.GetValueOrDefault();
			}
			set
			{
				_launchLocation.HeadingSimple = value;
			}
		}

		public override string Icon => "icon-location";

		public override double Latitude
		{
			get
			{
				return _launchLocation.Latitude;
			}
			set
			{
				_launchLocation.Latitude = value;
			}
		}

		public override double Longitude
		{
			get
			{
				return _launchLocation.Longitude;
			}
			set
			{
				_launchLocation.Longitude = value;
			}
		}

		public override string Name
		{
			get
			{
				return _launchLocation.Name;
			}
			set
			{
				_launchLocation.Name = value;
			}
		}

		public override string TypeName => "Launch Location";

		public LaunchLocationObject(LaunchLocation launchLocation, PlanetObjectsFlyoutScript flyout)
			: base(flyout)
		{
			_launchLocation = launchLocation;
		}

		public override void Delete(PlanetDataScript planetData, CelestialBodyViewerScript viewer)
		{
			planetData.DefaultLaunchLocations.Remove(_launchLocation);
		}

		public override void GenerateModel(InspectorModel model, Action refreshUI)
		{
			base.GenerateModel(model, refreshUI);
			model.Add(new TextButtonModel("Snap to Structure", delegate
			{
				if ((base.PlanetPosition - base.Flyout.CelestialBodyViewer.CameraPlanetPosition).magnitude < 2500.0)
				{
					ReferenceFrame referenceFrame = base.Flyout.CelestialBodyViewer.ReferenceFrame;
					Vector3 direction = referenceFrame.PlanetToFrameVector(-base.PlanetPosition.normalized);
					if (Physics.Raycast(new Ray(referenceFrame.PlanetToFramePosition(base.PlanetPosition), direction), out var hitInfo, 10000f, 603979776))
					{
						SetPlanetPosition(referenceFrame.FrameToPlanetPosition(hitInfo.point), adjustElevation: true);
						base.Flyout.OnObjectMovedExternally(this);
					}
					else
					{
						Game.Instance.UserInterface.CreateMessageDialog("No structure was found below the launch location at its current position.");
					}
				}
				else
				{
					Game.Instance.UserInterface.CreateMessageDialog("You are too far from the launch location to snap a structure. Please move closer.");
				}
			}));
		}

		public override void UpdateGameViewObject(CelestialBodyViewerScript viewer)
		{
		}
	}
}
