using CTS.Core;
using Eflatun.SceneReference;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS.Utilities
{
	public class DisableInScene : CTSBehaviour
	{
		[SerializeField]
		private SceneReference _sceneRef;

		[SerializeField]
		private GameObject[] _objectsToDisable;

		protected override void OnAwake()
		{
			base.OnAwake();
			Scene loadedScene = _sceneRef.LoadedScene;
			if (base.gameObject.scene != loadedScene)
			{
				return;
			}
			GameObject[] objectsToDisable = _objectsToDisable;
			foreach (GameObject gameObject in objectsToDisable)
			{
				if (gameObject != null)
				{
					gameObject.SetActive(value: false);
				}
			}
		}
	}
}
