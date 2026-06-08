using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Huey.Game
{
	public class MainMenuFade : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		private IEnumerator Start()
		{
			canvasGroup.alpha = 1f;
			yield return new WaitUntil(() => SceneManager.GetActiveScene().name != "Loading");
			while (canvasGroup.alpha > 0f)
			{
				float value = (canvasGroup.alpha -= Time.deltaTime * 0.5f);
				canvasGroup.alpha = Mathf.Clamp(value, 0f, 1f);
				yield return null;
			}
			Object.Destroy(this);
		}
	}
}
