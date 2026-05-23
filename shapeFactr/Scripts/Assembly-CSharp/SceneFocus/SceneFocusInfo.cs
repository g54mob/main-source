using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SceneFocus
{
	[Serializable]
	public class SceneFocusInfo
	{
		public Scene scene;

		public Camera camera;

		public Canvas canvas;

		public AudioListener audioListener;
	}
}
