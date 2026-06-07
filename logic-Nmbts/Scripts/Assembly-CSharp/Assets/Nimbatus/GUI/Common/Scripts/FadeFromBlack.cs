using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class FadeFromBlack : MonoBehaviour
	{
		public UITexture BlackScreenImage;

		public float FadeAmount;

		public float Startdelay;

		public void Awake()
		{
			Color color = BlackScreenImage.color;
			color.a = 1f;
			BlackScreenImage.color = color;
		}

		public void Start()
		{
			StartCoroutine(FadeIn());
		}

		public IEnumerator FadeIn()
		{
			yield return new WaitForSecondsRealtime(Startdelay);
			Color color = BlackScreenImage.color;
			while (BlackScreenImage.color.a > 0f)
			{
				color.a -= FadeAmount * 0.01f;
				BlackScreenImage.color = color;
				yield return new WaitForSecondsRealtime(0.01f);
			}
		}
	}
}
