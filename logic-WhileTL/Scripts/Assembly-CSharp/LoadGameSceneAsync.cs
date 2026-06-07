using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameSceneAsync : MonoBehaviour
{
	private AsyncOperation AO;

	public bool reload = true;

	private IEnumerator Start()
	{
		ActiveComponent.ResetGeneralComponents();
		_ = reload;
		int i = 0;
		while (i < 30)
		{
			i++;
			yield return new WaitForEndOfFrame();
		}
		Resources.UnloadUnusedAssets();
		AO = SceneManager.LoadSceneAsync("art");
		AO.allowSceneActivation = false;
		while (AO.progress < 0.9f)
		{
			yield return new WaitForEndOfFrame();
		}
		AO.allowSceneActivation = true;
		while (!AO.isDone)
		{
			yield return new WaitForEndOfFrame();
		}
	}
}
