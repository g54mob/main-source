using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Huey.Game
{
	public class LoadingScreen : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Image foregroundLogo;

		private static string queuedSceneName = "Scene";

		private static bool isInitialLoad = true;

		public static string QueuedScene => queuedSceneName;

		public static bool Initialised { get; private set; } = false;

		public static void LoadScene(string sceneName)
		{
			queuedSceneName = sceneName;
			SceneLoader.Load("Loading");
		}

		private void Awake()
		{
			foregroundLogo.fillAmount = 0f;
			canvasGroup.alpha = 0f;
		}

		private void Start()
		{
			if (isInitialLoad)
			{
				queuedSceneName = "Scene";
				isInitialLoad = false;
			}
			StartCoroutine(LoadSequence());
		}

		private IEnumerator FadeCanvasGroup(bool fadeIn)
		{
			if (fadeIn)
			{
				while (canvasGroup.alpha < 1f)
				{
					float value = (canvasGroup.alpha += Time.deltaTime * 2f);
					canvasGroup.alpha = Mathf.Clamp(value, 0f, 1f);
					yield return null;
				}
				yield break;
			}
			while (foregroundLogo.fillAmount < 1f)
			{
				foregroundLogo.fillAmount = Mathf.Clamp(foregroundLogo.fillAmount += Time.deltaTime, 0f, 1f);
				yield return null;
			}
			while (canvasGroup.alpha > 0f)
			{
				float value2 = (canvasGroup.alpha -= Time.deltaTime * 2f);
				canvasGroup.alpha = Mathf.Clamp(value2, 0f, 1f);
				yield return null;
			}
		}

		private IEnumerator LoadSequence()
		{
			yield return FadeCanvasGroup(fadeIn: true);
			AsyncOperation asyncOp = null;
			asyncOp = SceneLoader.StartAsyncLoad(queuedSceneName);
			asyncOp.allowSceneActivation = false;
			while (asyncOp.progress < 0.9f)
			{
				foregroundLogo.fillAmount = Mathf.Lerp(0f, 1f, asyncOp.progress);
				yield return null;
			}
			yield return FadeCanvasGroup(fadeIn: false);
			SceneLoader.CompleteAsyncLoad(asyncOp);
			if (asyncOp.allowSceneActivation)
			{
				Initialised = true;
			}
			yield return new WaitUntil(() => asyncOp.isDone);
		}
	}
}
