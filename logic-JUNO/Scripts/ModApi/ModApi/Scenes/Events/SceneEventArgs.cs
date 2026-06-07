using System;

namespace ModApi.Scenes.Events
{
	public class SceneEventArgs : EventArgs
	{
		public string Scene { get; private set; }

		public SceneEventArgs(string scene)
		{
			Scene = scene;
		}
	}
}
