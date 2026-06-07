using System;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	[Serializable]
	public struct SceneData
	{
		public string sceneName;

		public int sceneIndex;
	}

	public List<SceneData> sceneList;

	private void OnGUI()
	{
	}
}
