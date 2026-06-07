using System;
using ModApi.Flight.GameView;
using ModApi.Flight.Sim;
using ModApi.Planet;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.PlanetStudio.PlanetObjects
{
	public interface IPlanetObject
	{
		bool CanDragInTreeView { get; }

		bool Collapsed { get; set; }

		string Icon { get; }

		string Name { get; set; }

		Vector3d PlanetPosition { get; }

		string TypeName { get; }

		void Delete(PlanetDataScript planetData, CelestialBodyViewerScript viewer);

		void GenerateModel(InspectorModel model, Action refreshUI);

		Quaternion GetMoveToolRotation(IReferenceFrame referenceFrame, IPlanetNode planetNode);

		bool OnReceiveDropInTreeView(IPlanetObject planetObject, IPlanetObject insertBefore);

		void SetPlanetPosition(Vector3d p, bool adjustElevation);

		void UpdateGameViewObject(CelestialBodyViewerScript viewer);
	}
}
