using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTop : MonoBehaviour
{
	[SerializeField]
	private string sceneNameToLoad;

	private void Start()
	{
		LoadScene();
	}

	public void LoadScene()
	{
		if (!string.IsNullOrEmpty(sceneNameToLoad))
		{
			SceneManager.LoadScene(sceneNameToLoad, LoadSceneMode.Additive);
		}
		else
		{
			Debug.LogError("Scene name is not specified. Please provide a valid scene name.");
		}
	}
}
