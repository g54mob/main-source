using System;
using ModApi.Audio;
using ModApi.CelestialData;
using ModApi.Craft.Parts.Styles;
using ModApi.Craft.Propulsion;
using ModApi.Design;
using ModApi.DevConsole;
using ModApi.Flight;
using ModApi.Input;
using ModApi.Mods;
using ModApi.Scenes;
using ModApi.Services.Purchasing;
using ModApi.Settings;
using ModApi.State;
using ModApi.Ui;

namespace ModApi
{
	public interface IGame
	{
		IAudioPlayer AudioPlayer { get; }

		CelestialDatabase CelestialDatabase { get; }

		IDesigner Designer { get; }

		IDevConsole DevConsole { get; }

		IDevice Device { get; }

		IFlightScene FlightScene { get; }

		IGameState GameState { get; }

		IPurchaseService InAppPurchases { get; }

		IGameInputs Inputs { get; }

		IModManager ModManager { get; }

		IPartStyleManager PartStyleManager { get; }

		PropulsionData PropulsionData { get; }

		IGameQualitySettings QualitySettings { get; }

		float ResolutionScale { get; }

		IResourceLoader ResourceLoader { get; }

		ISceneManager SceneManager { get; }

		IApplicationSettings Settings { get; }

		DateTime StartTime { get; }

		IUserInterface UserInterface { get; }

		Version Version { get; }
	}
}
