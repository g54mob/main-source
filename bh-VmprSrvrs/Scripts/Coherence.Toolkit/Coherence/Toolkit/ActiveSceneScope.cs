using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Coherence.Toolkit
{
	public struct ActiveSceneScope : IDisposable
	{
		public readonly Scene currentScene;

		public readonly Scene activeScene;

		public ActiveSceneScope(Component component)
		{
			currentScene = default(Scene);
			activeScene = default(Scene);
		}

		public ActiveSceneScope(GameObject gameObject)
		{
			currentScene = default(Scene);
			activeScene = default(Scene);
		}

		public ActiveSceneScope(Scene scene)
		{
			currentScene = default(Scene);
			activeScene = default(Scene);
		}

		public void Dispose()
		{
		}
	}
}
