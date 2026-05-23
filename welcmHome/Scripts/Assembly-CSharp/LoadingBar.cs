using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{
	public GameObject globalUiObject;

	private float timeToLoad;

	private string sceneToChangeTo;

	private void Start()
	{
		StaticStateManager component = globalUiObject.GetComponent<StaticStateManager>();
		sceneToChangeTo = component.getSceneToChangeTo();
		timeToLoad = component.getTimeToLoad();
		StartCoroutine(LoadScene(timeToLoad));
	}

	private IEnumerator LoadScene(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene(sceneToChangeTo);
	}
}
