using System;

namespace Assets.Scripts.Scenes.Events
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
