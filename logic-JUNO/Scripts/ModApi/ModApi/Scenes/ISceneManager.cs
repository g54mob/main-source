using System;
using ModApi.Scenes.Events;
using ModApi.Scenes.Parameters;

namespace ModApi.Scenes
{
	public interface ISceneManager
	{
		string CurrentScene { get; }

		DesignSceneLoadParameters DesignSceneLoadParameters { get; }

		FlightSceneLoadParameters FlightSceneLoadParameters { get; }

		bool InDesignerScene { get; }

		bool InFlightScene { get; }

		bool InMenuScene { get; }

		bool InPlanetStudioScene { get; }

		bool InTechTreeScene { get; }

		MenuSceneLoadParameters MenuSceneLoadParameters { get; }

		SceneTransitionState SceneTransitionState { get; }

		event EventHandler<SceneEventArgs> SceneLoaded;

		event EventHandler<SceneEventArgs> SceneLoading;

		event EventHandler<SceneTransitionEventArgs> SceneTransitionCompleted;

		event EventHandler<SceneTransitionEventArgs> SceneTransitionStarted;

		event EventHandler<SceneEventArgs> SceneUnloaded;

		event EventHandler<SceneEventArgs> SceneUnloading;

		void DeactivateCurrentScene();

		void LoadDesigner();

		void LoadDesigner(DesignSceneLoadParameters loadParameters = null);

		void LoadFlight(FlightSceneLoadParameters loadParameters = null);

		void LoadMenu(MenuSceneLoadParameters loadParameters = null);

		void LoadPlanetStudio();

		void LoadPreviousScene();

		void LoadScene(string sceneName);

		void LoadTechTree();

		void RegisterLoadingScreenTextureProvider(ILoadingScreenTextureProvider provider, int priority);

		void ReloadCurrentScene();
	}
}
