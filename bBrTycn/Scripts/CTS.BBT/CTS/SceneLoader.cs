using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CTS
{
	[DefaultExecutionOrder(-1000)]
	public class SceneLoader : MonoBehaviour
	{
		[SerializeField]
		[Scene]
		private int _sceneToLoad;

		private void Awake()
		{
			SceneManager.LoadScene(_sceneToLoad, LoadSceneMode.Additive);
		}

		private void Start()
		{
			SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(_sceneToLoad));
		}
	}
}
