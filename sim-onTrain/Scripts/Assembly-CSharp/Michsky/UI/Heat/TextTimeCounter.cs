using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(TextMeshProUGUI))]
	[AddComponentMenu("Heat UI/Misc/Text Time Counter")]
	public class TextTimeCounter : MonoBehaviour
	{
		private TextMeshProUGUI tmpText;

		private RectTransform tmpRect;

		private int minutes;

		private float seconds;

		private void OnEnable()
		{
			if (tmpText == null)
			{
				tmpText = GetComponent<TextMeshProUGUI>();
			}
			if (tmpRect == null)
			{
				tmpRect = tmpText.GetComponent<RectTransform>();
			}
			ResetTimer();
		}

		public void ResetTimer()
		{
			minutes = 0;
			seconds = 0f;
			tmpText.text = "0:00";
			StopCoroutine("Count");
			StartCoroutine("Count");
		}

		private IEnumerator Count()
		{
			while (true)
			{
				if (seconds == 60f)
				{
					seconds = 0f;
					minutes++;
				}
				if (seconds < 10f)
				{
					tmpText.text = minutes + ":0" + seconds.ToString("F0");
				}
				else
				{
					tmpText.text = minutes + ":" + seconds.ToString("F0");
				}
				LayoutRebuilder.ForceRebuildLayoutImmediate(tmpRect);
				seconds += 1f;
				yield return new WaitForSeconds(1f);
			}
		}
	}
}
