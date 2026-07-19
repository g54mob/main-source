using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Splash")]
	public class Splash : MonoBehaviour
	{
		[Header("Components")]
		public Image background;

		public RawImage image;

		[Header("Settings")]
		public string completeScene;

		public Slide[] slides;

		private int currentSlide;

		private float wait;

		private void Awake()
		{
			Color color = image.color;
			color.a = 0f;
			image.color = color;
			FadeIn();
		}

		private void Update()
		{
			if (slides[currentSlide].skip && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2) || Input.anyKeyDown))
			{
				Skip();
			}
			if (wait > 0f)
			{
				wait -= Time.deltaTime;
				if (wait <= 0f)
				{
					FadeOut();
				}
			}
		}

		private void Skip()
		{
			iTween.Stop();
			wait = 0f;
			Color color = image.color;
			color.a = 0f;
			image.color = color;
			FadeOutComplete();
		}

		private void FadeIn()
		{
			image.texture = slides[currentSlide].image;
			image.SetNativeSize();
			Color color = background.color;
			color = slides[currentSlide].color;
			color.a = 0f;
			background.color = color;
			iTween.ValueTo(base.gameObject, iTween.Hash("from", 0, "to", 1, "time", 1f, "easetype", "easeInOutSine", "onupdate", "SetAlpha", "oncomplete", "FadeInComplete"));
		}

		private void FadeInComplete()
		{
			wait = slides[currentSlide].time;
		}

		private void FadeOut()
		{
			iTween.ValueTo(base.gameObject, iTween.Hash("from", 1, "to", 0, "time", 1f, "easetype", "easeInOutSine", "onupdate", "SetAlpha", "oncomplete", "FadeOutComplete"));
		}

		private void FadeOutComplete()
		{
			if (currentSlide < slides.Length - 1)
			{
				currentSlide++;
				FadeIn();
			}
			else
			{
				SceneManager.LoadScene(completeScene);
			}
		}

		private void SetAlpha(float a)
		{
			Color color = background.color;
			color.a = a;
			background.color = color;
			Color color2 = image.color;
			color2.a = a;
			image.color = color2;
		}
	}
}
