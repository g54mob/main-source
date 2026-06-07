using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Tasks_for_levels
{
	public class TaskUI : MonoBehaviour
	{
		[SerializeField]
		private Image arrow;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private TextMeshProUGUI taskCount;

		[SerializeField]
		private TextMeshProUGUI taskPrize;

		[SerializeField]
		private List<Image> fillImages;

		[SerializeField]
		private Slider strikeThroughLinePrefab;

		private float animationDuration = 0.4f;

		private const float FILL_SPEED = 0.05f;

		private const float sliderWidth = 270f;

		private const float sliderHight = 5f;

		private List<Slider> strikeThroughLines = new List<Slider>();

		private bool taskCountExist;

		private Action onTaskCompletedCallback;

		private void Start()
		{
			if (taskCount != null)
			{
				taskCountExist = true;
			}
			GenerateStrikeThroughLines();
		}

		public void TaskDone(Action onTaskCompleted)
		{
			onTaskCompletedCallback = onTaskCompleted;
			arrow.gameObject.SetActive(value: true);
			StartCoroutine(AnimateStrikeThrough());
		}

		public void SlowShowTask()
		{
			StartCoroutine(Show());
		}

		public void InstantShowTask()
		{
			text.alpha = 1f;
			if (taskCountExist)
			{
				taskCount.alpha = 1f;
			}
			foreach (Image fillImage in fillImages)
			{
				Color color = fillImage.color;
				color.a = 1f;
				fillImage.color = color;
			}
		}

		public void UpdateTaskPrize(int prize)
		{
			taskPrize.text = prize.ToString();
		}

		public void UpdateTaskCount(string update)
		{
			if (!taskCount.gameObject.activeInHierarchy)
			{
				taskCount.gameObject.SetActive(value: true);
			}
			taskCount.text = update;
		}

		private IEnumerator Show()
		{
			while (text.alpha < 1f)
			{
				text.alpha += 0.05f;
				if (taskCountExist)
				{
					taskCount.alpha += 0.05f;
				}
				foreach (Image fillImage in fillImages)
				{
					if (!(fillImage.color.a >= 1f))
					{
						Color color = fillImage.color;
						color.a += 0.05f;
						fillImage.color = color;
					}
				}
				yield return new WaitForSeconds(0.03f);
			}
		}

		public void GenerateStrikeThroughLines()
		{
			foreach (Slider strikeThroughLine in strikeThroughLines)
			{
				UnityEngine.Object.Destroy(strikeThroughLine.gameObject);
			}
			strikeThroughLines.Clear();
			TMP_TextInfo textInfo = text.textInfo;
			text.ForceMeshUpdate();
			for (int i = 0; i < textInfo.lineCount; i++)
			{
				TMP_LineInfo tMP_LineInfo = textInfo.lineInfo[i];
				float y = (tMP_LineInfo.ascender + tMP_LineInfo.descender) / 2f;
				Slider component = UnityEngine.Object.Instantiate(strikeThroughLinePrefab, text.transform).GetComponent<Slider>();
				component.GetComponent<RectTransform>().sizeDelta = new Vector2(270f, 5f);
				component.GetComponent<RectTransform>().anchoredPosition = new Vector2(25f, y);
				Image component2 = component.fillRect.GetComponent<Image>();
				fillImages.Add(component2);
				component.value = 0f;
				strikeThroughLines.Add(component);
			}
		}

		private IEnumerator AnimateStrikeThrough()
		{
			arrow.gameObject.SetActive(value: true);
			foreach (Slider line in strikeThroughLines)
			{
				float elapsedTime = 0f;
				while (elapsedTime < animationDuration)
				{
					float t = elapsedTime / animationDuration;
					line.value = Mathf.Lerp(0f, 1f, t);
					elapsedTime += Time.deltaTime;
					yield return null;
				}
				line.value = 1f;
			}
			StartCoroutine(FadeTextAndImages());
		}

		private IEnumerator FadeTextAndImages()
		{
			fillImages.RemoveAll((Image img) => img == null);
			while (text.alpha > 0f)
			{
				text.alpha -= 0.05f;
				taskPrize.alpha -= 0.05f;
				if (taskCountExist)
				{
					taskCount.alpha -= 0.05f;
				}
				foreach (Image fillImage in fillImages)
				{
					Color color = fillImage.color;
					color.a -= 0.05f;
					fillImage.color = color;
				}
				yield return new WaitForSeconds(0.03f);
			}
			onTaskCompletedCallback?.Invoke();
		}
	}
}
