using ModApi.Craft.Parts;
using ModApi.Flight.Sim;
using ModApi.Planet;
using UnityEngine;

namespace ModApi.Flight.GameView
{
	public interface IGameView
	{
		Vector3d CameraSolarSystemPosition { get; }

		Quaterniond CameraSolarSystemRotation { get; }

		IGameCamera GameCamera { get; }

		IPlanet Planet { get; }

		IPlanetNode PlanetNode { get; }

		IReferenceFrame ReferenceFrame { get; }

		bool RenderView { get; set; }

		IPartScript SelectedPart { get; set; }

		Light SunLight { get; }

		event ReferenceFrameRecenteredDelegate ReferenceFrameRecentered;

		event SelectedPartChanged SelectedPartChanged;

		Transform AddGameViewObject(IGameViewObject gameViewObject);

		void RecenterReferenceFrame();

		void RemoveGameViewObject(IGameViewObject gameViewObject, bool flightEnd);
	}
}
