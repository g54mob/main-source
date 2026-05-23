using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RainbowArt.CleanFlatUI
{
	public class ProgressBarGridCircular : MonoBehaviour
	{
		[SerializeField]
		private int currentValue;

		[SerializeField]
		private int maxValue = 10;

		[SerializeField]
		private bool hasText = true;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private RectTransform background;

		[SerializeField]
		private RectTransform foreground;

		[SerializeField]
		private RectTransform bgTemplate;

		[SerializeField]
		private RectTransform fgTemplate;

		private List<RectTransform> bgList = new List<RectTransform>();

		private List<RectTransform> fgList = new List<RectTransform>();

		public int CurrentValue
		{
			get
			{
				return currentValue;
			}
			set
			{
				if (currentValue != value)
				{
					currentValue = value;
					OnValueChanged();
					UpdateGUI();
				}
			}
		}

		public bool HasText
		{
			get
			{
				return hasText;
			}
			set
			{
				if (hasText != value)
				{
					hasText = value;
					UpdateText();
				}
			}
		}

		private void OnValueChanged()
		{
			if (currentValue < 0)
			{
				currentValue = 0;
			}
			if (maxValue < 0)
			{
				maxValue = 10;
			}
			if (currentValue > maxValue)
			{
				currentValue = maxValue;
			}
		}

		private void Start()
		{
			OnValueChanged();
			CreateList(bgList, background, bgTemplate);
			CreateList(fgList, foreground, fgTemplate);
			UpdateGUI();
		}

		private void UpdateGUI()
		{
			UpdateForeground();
			UpdateText();
		}

		private void CreateList(List<RectTransform> list, RectTransform rectParent, RectTransform template)
		{
			template.gameObject.SetActive(value: false);
			float num = 360f / (float)maxValue;
			for (int i = 0; i < maxValue; i++)
			{
				RectTransform rectTransform = CreateItem(rectParent, template, i);
				list.Add(rectTransform);
				rectTransform.localEulerAngles = new Vector3(0f, 0f, (0f - num) * (float)i);
			}
		}

		private RectTransform CreateItem(RectTransform rectParent, RectTransform template, int index)
		{
			GameObject obj = Object.Instantiate(template.gameObject, rectParent);
			obj.gameObject.SetActive(value: true);
			obj.gameObject.name = "item" + (index + 1);
			RectTransform component = obj.GetComponent<RectTransform>();
			component.localScale = Vector3.one;
			component.localEulerAngles = Vector3.zero;
			component.anchoredPosition3D = Vector3.zero;
			return component;
		}

		private void UpdateForeground()
		{
			for (int i = 0; i < fgList.Count; i++)
			{
				RectTransform rectTransform = fgList[i];
				if (i < currentValue)
				{
					rectTransform.gameObject.SetActive(value: true);
				}
				else
				{
					rectTransform.gameObject.SetActive(value: false);
				}
			}
		}

		private void UpdateText()
		{
			if (text != null && text.gameObject.activeSelf != hasText)
			{
				text.gameObject.SetActive(hasText);
			}
			if (hasText && text != null)
			{
				float num = (float)currentValue / (float)maxValue;
				text.text = Mathf.FloorToInt(num * 100f) + "%";
			}
		}
	}
}
