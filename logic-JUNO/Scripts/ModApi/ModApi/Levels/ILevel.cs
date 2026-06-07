using System;
using System.Collections.Generic;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight;
using ModApi.Levels.Events;
using ModApi.Levels.Requirements;
using ModApi.Scenes;
using ModApi.Scenes.Parameters;
using ModApi.State;
using UnityEngine;

namespace ModApi.Levels
{
	public interface ILevel
	{
		bool DisplayCraftFuelInDesigner { get; }

		IFlightScene FlightScene { get; }

		float FuelUsed { get; }

		GameObject GameObject { get; }

		LaunchLocation LaunchLocation { get; }

		ILevelData LevelData { get; }

		IReadOnlyList<ILevelRequirement> LevelRequirements { get; }

		ICraftScript PlayerCraft { get; }

		LevelTimer Timer { get; }

		ILevelUI UI { get; }

		event EventHandler<LevelEventArgs> LevelEnded;

		event EventHandler<LevelCompletedEventArgs> LevelFailed;

		event EventHandler<LevelCompletedEventArgs> LevelPassed;

		void Cleanup();

		string GetPersistentMessage();

		string GetUIXml();

		bool HasRequiredParts(ICraftScript craft, out string missingPartsMessage);

		void Initialize(ILevelUI levelUI);

		void Initialize(ILevelData levelData, ISceneManager sceneManager);

		bool IsLegalCraft(ICraftScript craft);

		bool IsLegalCraftPart(PartData part);

		bool IsLevelScene(string sceneName);

		bool IsPartTypeAllowed(PartType partType);

		void OnFixedUpdate();

		void OnLateUpdate();

		void OnUpdate();

		void OverrideFlightSceneLoadParameters(FlightSceneLoadParameters loadParameters);
	}
}
