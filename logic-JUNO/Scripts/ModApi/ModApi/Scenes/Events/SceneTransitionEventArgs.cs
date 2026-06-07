using System;

namespace ModApi.Scenes.Events
{
	public class SceneTransitionEventArgs : EventArgs
	{
		public string TransitionFromScene { get; private set; }

		public string TransitionToScene { get; private set; }

		public SceneTransitionEventArgs(string transitionFromScene, string transitionToScene)
		{
			TransitionFromScene = transitionFromScene;
			TransitionToScene = transitionToScene;
		}
	}
}
