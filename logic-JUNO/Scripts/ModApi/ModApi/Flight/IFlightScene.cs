using System;
using System.Collections.Generic;
using ModApi.Audio;
using ModApi.Common.Events;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.Events;
using ModApi.Flight.UI;
using ModApi.GameLoop.Interfaces;
using ModApi.Ioc;
using ModApi.Planet;
using UnityEngine;

namespace ModApi.Flight
{
	public interface IFlightScene
	{
		PositionBiomeData CraftBiomeData { get; }

		ICraftNode CraftNode { get; }

		IFlightSceneUI FlightSceneUI { get; }

		IFlightState FlightState { get; }

		IFlightGameLoop GameLoop { get; }

		GameObject GameObject { get; }

		IIocContainer IocContainer { get; }

		ISingleSoundManager SingleSoundManager { get; }

		ITimeManager TimeManager { get; }

		bool VaporTrailsVisible { get; }

		IViewManager ViewManager { get; }

		event FlightSceneCraftHandler ActiveCommandPodChanged;

		event FlightSceneCraftHandler ActiveCommandPodStateChanged;

		event FlightSceneCraftHandler CraftChanged;

		event SimpleNotificationDelegate CraftStructureChanged;

		event EventHandler<FlightEndedEventArgs> FlightEnded;

		event InitializedHandler<IFlightScene> Initialized;

		event PlayerChangedSoiHandler PlayerChangedSoi;

		bool ChangePlayersActiveCommandPodImmediate(ICommandPod commandPod, ICraftNode craftNode, bool ignoreDistance = false);

		void ChangePlayersActiveCraftNode(ICraftNode craftNode);

		void CreateExplosion(IEnumerable<PartData> parts, Vector3 position, Vector3 velocity, float magnitude, float magnitudeFromFuel);

		void ExitFlightScene(bool saveFlightState, FlightSceneExitReason exitReason = FlightSceneExitReason.Unknown, string sceneName = null);

		void RaiseActiveCommandPodStateChanged();

		void SaveLaunchLocationPrompt();

		void SetPlayerSpeed();

		void TeleportPlayer();

		void UpdateActiveControlMaps(ICraftNode craftNode);
	}
}
