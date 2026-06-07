using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndPanel : Panel
{
	[SerializeField]
	private Image _image;

	[SerializeField]
	private float _duration = 1f;

	public override bool Open(PanelID id, IPanelContext context = null)
	{
		if (base.Open(id, context))
		{
			GameManager.UIManager.PauseGame();
			StartCoroutine(LoadEndSceneRoutine());
			return true;
		}
		return false;
	}

	private IEnumerator LoadEndSceneRoutine()
	{
		float time = 0f;
		Color from = _image.color;
		Color to = from;
		to.a = 1f;
		for (; time < _duration; time += GameSpeedManager.UnscaledDeltaTime)
		{
			_image.color = Color.Lerp(from, to, time / _duration);
			yield return null;
		}
		_image.color = to;
		Scene activeScene = SceneManager.GetActiveScene();
		SceneManager.LoadScene("_03_Ending", LoadSceneMode.Additive);
		yield return null;
		SceneManager.UnloadSceneAsync(activeScene);
	}
}
