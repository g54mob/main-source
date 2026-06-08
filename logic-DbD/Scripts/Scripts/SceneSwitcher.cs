using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
	public const float WAIT_TIME = 3f;

	public void SwitchToStart(Panel panel, Transcript transcript)
	{
		StartCoroutine(StartLoading(transcript));
		StartCoroutine(ClosePopup(panel, 3f));
		StartCoroutine(SwitchScene(5f));
	}

	private IEnumerator StartLoading(Transcript transcript)
	{
		float currentTime = 0f;
		float waitDuration = 0.5f;
		while (currentTime <= 3f)
		{
			yield return new WaitForSeconds(waitDuration);
			currentTime += waitDuration;
			int num = (int)((currentTime - waitDuration) / waitDuration) % 3;
			MonoBehaviour.print($"{currentTime} currentTime, {waitDuration} waitDuration");
			MonoBehaviour.print($"{num} periods");
			string text = "";
			for (int i = 0; i <= num; i++)
			{
				text += ".";
			}
			transcript.SetTranscript("Destroying everything" + text);
			yield return null;
		}
	}

	private IEnumerator ClosePopup(Panel popup, float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		popup.ClosePanel();
	}

	private IEnumerator SwitchScene(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		SceneManager.LoadScene("Splash");
	}
}
