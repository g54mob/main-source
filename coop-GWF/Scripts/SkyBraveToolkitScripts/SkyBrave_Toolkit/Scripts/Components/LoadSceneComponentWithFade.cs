using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SkyBrave_Toolkit.Scripts.Components
{
	public class LoadSceneComponentWithFade : MonoBehaviour
	{
		private Texture2D fadeTexture;

		public float fadeSpeed = 0.8f;

		private int drawDepth = -1000;

		private float alpha = 1f;

		private int fadeDirection = -1;

		private bool fadingOut = true;

		private void Start()
		{
			fadeTexture = new Texture2D(1, 1);
			fadeTexture.SetPixel(0, 0, Color.black);
			fadeTexture.Apply();
			StartCoroutine(Fade(0f));
		}

		private void OnGUI()
		{
			GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
			GUI.depth = drawDepth;
			GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), fadeTexture);
		}

		private IEnumerator Fade(float targetAlpha)
		{
			float startTime = Time.time;
			float startAlpha = alpha;
			while (Time.time - startTime < fadeSpeed)
			{
				alpha = Mathf.Lerp(startAlpha, targetAlpha, (Time.time - startTime) / fadeSpeed);
				yield return null;
			}
			alpha = targetAlpha;
			if (targetAlpha == 0f)
			{
				fadingOut = false;
			}
		}

		private void Update()
		{
			if (fadingOut)
			{
				alpha += (float)fadeDirection * fadeSpeed * Time.deltaTime;
				alpha = Mathf.Clamp01(alpha);
				if (alpha == 0f || alpha == 1f)
				{
					fadeDirection = -fadeDirection;
				}
			}
		}

		private IEnumerator FadeAndLoadScene(int sceneIndexToLoad)
		{
			yield return Fade(1f);
			SceneManager.LoadScene(sceneIndexToLoad);
		}

		public void ReLoadCurrentUnityScene()
		{
			StartCoroutine(FadeAndLoadScene(SceneManager.GetActiveScene().buildIndex));
		}

		public void LoadNextUnityScene()
		{
			int sceneIndexToLoad = Mathf.Clamp(SceneManager.GetActiveScene().buildIndex + 1, 0, SceneManager.sceneCountInBuildSettings - 1);
			StartCoroutine(FadeAndLoadScene(sceneIndexToLoad));
		}

		public void LoadPreviousUnityScene()
		{
			int sceneIndexToLoad = Mathf.Clamp(SceneManager.GetActiveScene().buildIndex - 1, 0, SceneManager.sceneCountInBuildSettings - 1);
			StartCoroutine(FadeAndLoadScene(sceneIndexToLoad));
		}

		public void LoadUnitySceneWithIndex(int sceneIndexToLoad)
		{
			StartCoroutine(FadeAndLoadScene(sceneIndexToLoad));
		}

		public Scene GetCurrentUnityScene()
		{
			return SceneManager.GetActiveScene();
		}

		public void QuitGameWithFade()
		{
			StartCoroutine(FadeAndQuitGame());
		}

		private IEnumerator FadeAndQuitGame()
		{
			yield return Fade(1f);
			Application.Quit();
		}
	}
}
