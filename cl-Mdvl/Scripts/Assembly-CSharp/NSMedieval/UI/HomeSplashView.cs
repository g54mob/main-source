using System.Collections;
using UnityEngine;

namespace NSMedieval.UI
{
	public class HomeSplashView : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float fadeStep = 0.3f;

		public static HomeSplashView Instance { get; private set; }

		public void HomeSceneLoaded()
		{
			StartCoroutine(FadeOut());
		}

		private void Awake()
		{
			if (Instance != null && Instance.gameObject.name.Equals(base.gameObject.name))
			{
				Object.DestroyImmediate(base.gameObject);
				return;
			}
			Instance = this;
			Object.DontDestroyOnLoad(base.gameObject);
		}

		private IEnumerator FadeOut()
		{
			yield return new WaitForSecondsRealtime(1f);
			while (canvasGroup.alpha > 0f)
			{
				canvasGroup.alpha -= fadeStep;
				yield return new WaitForSecondsRealtime(0.001f);
			}
			yield return new WaitForSecondsRealtime(0.01f);
			Object.Destroy(base.gameObject);
		}
	}
}
