using System;
using System.Collections.Generic;
using Assets.Scripts.PlanetStudio.Flyouts;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.State;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.PlanetObjects
{
	public abstract class SurfaceObject : IPlanetObject
	{
		public abstract AltitudeType AltitudeType { get; }

		public virtual bool CanDragInTreeView => false;

		public virtual bool Collapsed { get; set; }

		public abstract double Elevation { get; set; }

		public PlanetObjectsFlyoutScript Flyout { get; }

		public abstract double Heading { get; set; }

		public abstract string Icon { get; }

		public abstract double Latitude { get; set; }

		public abstract double Longitude { get; set; }

		public abstract string Name { get; set; }

		public Vector3d PlanetPosition
		{
			get
			{
				IPlanetNode planetNode = Flyout.CelestialBodyViewer.PlanetScript.PlanetNode;
				Vector3d surfacePosition = planetNode.GetSurfacePosition(Latitude * 0.01745329, Longitude * 0.01745329, AltitudeType, Elevation);
				return planetNode.SurfaceVectorToPlanetVector(surfacePosition);
			}
		}

		public Quaterniond PlanetRotation => LaunchLocation.CalculateHeading(Heading, (float)Latitude, (float)Longitude);

		public abstract string TypeName { get; }

		public SurfaceObject(PlanetObjectsFlyoutScript flyout)
		{
			Flyout = flyout;
		}

		public abstract void Delete(PlanetDataScript planetData, CelestialBodyViewerScript viewer);

		public virtual void GenerateModel(InspectorModel model, Action refreshUI)
		{
			Action<object> update = delegate
			{
				Flyout.OnObjectMovedExternally(this);
			};
			foreach (NumericInputModel item in new List<NumericInputModel>
			{
				new NumericInputModel("Latitude", () => Latitude, delegate(double x)
				{
					Action<object> action = update;
					double num = (Latitude = x);
					action(num);
				}, -90.0, 90.0),
				new NumericInputModel("Longitude", () => Longitude, delegate(double x)
				{
					Action<object> action = update;
					double num = (Longitude = x);
					action(num);
				}, -360.0, 360.0),
				new NumericInputModel("Elevation", () => Elevation, delegate(double x)
				{
					Action<object> action = update;
					double num = (Elevation = x);
					action(num);
				}),
				new NumericInputModel("Heading", () => Heading, delegate(double x)
				{
					Action<object> action = update;
					double num = (Heading = x);
					action(num);
				})
			})
			{
				item.DisplayFormatter = (double d) => d.ToString("F8");
				model.Add(item);
			}
		}

		public Quaternion GetMoveToolRotation(IReferenceFrame referenceFrame, IPlanetNode planetNode)
		{
			return referenceFrame.PlanetToFrameRotation(planetNode.Rotation * PlanetRotation);
		}

		public virtual bool OnReceiveDropInTreeView(IPlanetObject planetObject, IPlanetObject insertBefore)
		{
			return false;
		}

		public void SetPlanetPosition(Vector3d p, bool adjustElevation)
		{
			IPlanetNode planetNode = Flyout.CelestialBodyViewer.PlanetScript.PlanetNode;
			Vector3d surfacePosition = planetNode.PlanetVectorToSurfaceVector(p);
			double latitude = 0.0;
			double longitude = 0.0;
			planetNode.GetSurfaceCoordinates(surfacePosition, out latitude, out longitude);
			if (adjustElevation)
			{
				if (AltitudeType == AltitudeType.AboveGroundLevel)
				{
					double num = planetNode.GetTerrainHeight(p);
					if (planetNode.PlanetData.HasWater && num < (double)planetNode.PlanetData.SeaLevel)
					{
						num = planetNode.PlanetData.SeaLevel;
					}
					Elevation = surfacePosition.magnitude - (planetNode.PlanetData.Radius + num);
				}
				else if (AltitudeType == AltitudeType.AboveSeaLevel)
				{
					Elevation = surfacePosition.magnitude - (planetNode.PlanetData.Radius + (double)planetNode.PlanetData.SeaLevel);
				}
				else if (AltitudeType == AltitudeType.AboveSeaFloorLevel)
				{
					throw new NotImplementedException("AboveSeaFloorLevel is not supported");
				}
			}
			else
			{
				Latitude = latitude * 57.29578;
				Longitude = longitude * 57.29578;
			}
		}

		public abstract void UpdateGameViewObject(CelestialBodyViewerScript viewer);
	}
}
