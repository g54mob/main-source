using UnityEngine;
using UnityEngine.UI;

namespace Kengine
{
	[AddComponentMenu("Kengine/Modifier/Transition")]
	public class Transition : MonoBehaviour
	{
		private Image image;

		[Header("Settings")]
		public float delay;

		public Fade fade;

		[Header("On Complete")]
		public GameObject onCompleteObject;

		public string onCompleteFunction;

		public string onCompleteParameter;

		private void Awake()
		{
			image = GetComponent<Image>();
		}

		private void Start()
		{
			if (fade == Fade.FadeIn)
			{
				Color color = image.color;
				color.a = 0f;
				image.color = color;
			}
			if (fade == Fade.FadeOut)
			{
				Color color2 = image.color;
				color2.a = 1f;
				image.color = color2;
			}
			Invoke("FadeStart", delay);
		}

		public void FadeStart()
		{
			if (fade == Fade.FadeIn)
			{
				FadeIn();
			}
			if (fade == Fade.FadeOut)
			{
				FadeOut();
			}
		}

		public void FadeIn(float speed = 1f)
		{
			iTween.ValueTo(base.gameObject, iTween.Hash("from", 0, "to", 1, "time", speed, "easetype", "easeInOutSine", "onupdate", "SetAlpha", "oncomplete", "FadeComplete"));
		}

		public void FadeOut(float speed = 1f)
		{
			iTween.ValueTo(base.gameObject, iTween.Hash("from", 1, "to", 0, "time", speed, "easetype", "easeInOutSine", "onupdate", "SetAlpha", "oncomplete", "FadeComplete"));
		}

		public void SetAlpha(float a)
		{
			Color color = image.color;
			color.a = a;
			image.color = color;
		}

		public void FadeComplete()
		{
			if (onCompleteObject != null)
			{
				onCompleteObject.SendMessage(onCompleteFunction, onCompleteParameter);
				onCompleteObject = null;
			}
		}

		public void OnFadeComplete(GameObject _onCompleteObject, string _onCompleteFunction, string _onCompleteParameter)
		{
			onCompleteObject = _onCompleteObject;
			onCompleteFunction = _onCompleteFunction;
			onCompleteParameter = _onCompleteParameter;
		}
	}
}
