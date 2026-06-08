using Dorfromantik;
using UnityEngine;

public class _DemoSceneLoader : MonoBehaviour
{
	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	private string tutorialScene;

	[SerializeField]
	private string demoScene;

	private void Awake()
	{
		if (PlayerPrefsAccessor.GetInt("TutorialPlayed", 0) == 1)
		{
			sceneLoader.LoadScene(demoScene);
		}
		else
		{
			sceneLoader.LoadScene(tutorialScene);
		}
	}
}
