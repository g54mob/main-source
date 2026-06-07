using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/UI/Stat Unit")]
	public class StatUnit : MonoBehaviour
	{
		[Tooltip("Fill Image of the Stat")]
		public Image Full;

		[Tooltip("Background image of the Stat")]
		public Image Background;

		public MonoBehaviour Scaler;

		private Vector3 FullScale;

		private Vector3 BGScale;

		private void Awake()
		{
			FullScale = Full.transform.localScale;
			BGScale = Background.transform.localScale;
		}

		internal void ResetScale()
		{
			Full.transform.localScale = FullScale;
			Background.transform.localScale = BGScale;
		}

		public void SetScaler(bool va)
		{
			if (Scaler != null)
			{
				Scaler.enabled = va;
			}
		}

		public void SetFillValue(float value, float time)
		{
			if (value == 0f)
			{
				ResetScale();
				if ((bool)Scaler)
				{
					Scaler.enabled = false;
				}
			}
			if (time == 0f)
			{
				Full.fillAmount = value;
				return;
			}
			StopAllCoroutines();
			StartCoroutine(FillValue(value, time));
		}

		private IEnumerator FillValue(float newValue, float time)
		{
			float elapsedTime = 0f;
			float startValue = Full.fillAmount;
			while (time > 0f && elapsedTime <= time)
			{
				float t = elapsedTime / time;
				Full.fillAmount = Mathf.Lerp(startValue, newValue, t);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			Full.fillAmount = newValue;
			yield return null;
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}
	}
}
