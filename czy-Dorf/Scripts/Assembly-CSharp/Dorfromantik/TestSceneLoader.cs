using UnityEngine;
using UnityEngine.SceneManagement;

namespace Dorfromantik
{
	public class TestSceneLoader : MonoBehaviour
	{
		[SerializeField]
		private SceneLoader sceneLoader;

		[SerializeField]
		private KeyCode sceneLoadKeyCode;

		[SerializeField]
		private string sceneName;

		[SerializeField]
		private LoadSceneMode loadSceneMode;

		private void Update()
		{
			if (Input.GetKeyDown(sceneLoadKeyCode))
			{
				sceneLoader.LoadScene(sceneName, loadSceneMode);
			}
		}
	}
}
