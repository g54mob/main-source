using UnityEngine;

public class SceneLoader : MonoBehaviour
{
	public string _strSceneToLoad;

	public void LoadScene()
	{
		Application.LoadLevel(_strSceneToLoad);
	}
}
