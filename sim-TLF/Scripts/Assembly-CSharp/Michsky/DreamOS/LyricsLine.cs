using System.Collections;
using TMPro;
using UnityEngine;

namespace Michsky.DreamOS
{
	public class LyricsLine : MonoBehaviour
	{
		[Header("Resources")]
		public TextMeshProUGUI textObject;

		public CanvasGroup itemCG;

		public RectTransform itemRT;

		[Header("Settings")]
		[Range(0f, 1f)]
		public float upcomingAlpha = 0.15f;

		public float transitionMultiplier = 5f;

		public float smoothness = 15f;

		private float tempY;

		private bool isCurrent;

		private bool isIn;

		public void SetIn()
		{
			if (base.gameObject.activeInHierarchy)
			{
				tempY = itemRT.sizeDelta.y;
				itemRT.sizeDelta = new Vector2(itemRT.sizeDelta.x, 0f);
				itemCG.alpha = 0f;
				if (!isIn)
				{
					StartCoroutine("ItemIn");
					isIn = true;
				}
			}
		}

		public void SetCurrent()
		{
			if (!isCurrent && base.gameObject.activeInHierarchy)
			{
				StartCoroutine("ItemCurrent");
				isCurrent = true;
			}
		}

		public void SetOut()
		{
			if (base.gameObject.activeInHierarchy)
			{
				textObject.enableAutoSizing = false;
				StopCoroutine("ItemIn");
				StopCoroutine("ItemCurrent");
				StartCoroutine("ItemOut");
			}
		}

		private IEnumerator ItemIn()
		{
			while (itemRT.sizeDelta.y < tempY - 0.1f)
			{
				if (itemCG.alpha < upcomingAlpha)
				{
					itemCG.alpha += Time.deltaTime * transitionMultiplier;
				}
				itemRT.sizeDelta = Vector2.Lerp(itemRT.sizeDelta, new Vector2(itemRT.sizeDelta.x, tempY), Time.deltaTime * smoothness);
				yield return null;
			}
			StopCoroutine("ItemIn");
		}

		private IEnumerator ItemCurrent()
		{
			while (itemCG.alpha < 1f)
			{
				itemCG.alpha += Time.deltaTime * transitionMultiplier;
				yield return null;
			}
			StopCoroutine("ItemCurrent");
		}

		private IEnumerator ItemOut()
		{
			while (itemCG.alpha > 0f)
			{
				itemCG.alpha -= Time.deltaTime * transitionMultiplier;
				itemRT.sizeDelta = Vector2.Lerp(itemRT.sizeDelta, new Vector2(itemRT.sizeDelta.x, 0f), Time.deltaTime * smoothness);
				yield return null;
			}
			Object.Destroy(base.gameObject);
			StopCoroutine("ItemOut");
		}
	}
}
