using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RainbowArt.CleanFlatUI
{
	public class ProgressBarGridLinearAuto : MonoBehaviour
	{
		[SerializeField]
		private int minValue;

		[SerializeField]
		private int maxValue = 10;

		private int currentValue;

		[SerializeField]
		private float spacing = 10f;

		[SerializeField]
		[Range(0f, 1f)]
		private float loadSpeed = 0.2f;

		[SerializeField]
		private bool forward = true;

		[SerializeField]
		private bool loop = true;

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

		private float totalTime;

		public int MinValue
		{
			get
			{
				return minValue;
			}
			set
			{
				if (minValue != value)
				{
					minValue = value;
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

		public float LoadSpeed
		{
			get
			{
				return loadSpeed;
			}
			set
			{
				loadSpeed = value;
			}
		}

		public bool Forward
		{
			get
			{
				return forward;
			}
			set
			{
				forward = value;
			}
		}

		public bool Loop
		{
			get
			{
				return loop;
			}
			set
			{
				loop = value;
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

		private void InitValue()
		{
			if (forward)
			{
				currentValue = minValue;
			}
			else
			{
				currentValue = maxValue;
			}
		}

		private void Start()
		{
			InitValue();
			OnValueChanged();
			CreateList(bgList, background, bgTemplate);
			CreateList(fgList, foreground, fgTemplate);
			UpdateGUI();
		}

		private void Update()
		{
			if (forward)
			{
				totalTime += loadSpeed * (Time.deltaTime * 10f);
				if (totalTime >= 1f)
				{
					currentValue++;
					totalTime = 0f;
					if (currentValue >= maxValue)
					{
						currentValue = maxValue;
					}
					UpdateGUI();
					if (loop && currentValue >= maxValue)
					{
						currentValue = minValue - 1;
					}
				}
				return;
			}
			totalTime += loadSpeed * (Time.deltaTime * 10f);
			if (totalTime >= 1f)
			{
				currentValue--;
				totalTime = 0f;
				if (currentValue <= minValue)
				{
					currentValue = minValue;
				}
				UpdateGUI();
				if (loop && currentValue <= minValue)
				{
					currentValue = maxValue + 1;
				}
			}
		}

		private void UpdateGUI()
		{
			UpdateForeground();
			UpdateText();
		}

		private void CreateList(List<RectTransform> list, RectTransform rectParent, RectTransform template)
		{
			template.gameObject.SetActive(value: false);
			float num = 0f;
			float width = template.rect.width;
			for (int i = 0; i < maxValue; i++)
			{
				RectTransform rectTransform = CreateItem(rectParent, template);
				list.Add(rectTransform);
				Vector3 anchoredPosition3D = rectTransform.anchoredPosition3D;
				anchoredPosition3D.x = num;
				rectTransform.anchoredPosition3D = anchoredPosition3D;
				num += width + spacing;
			}
		}

		private RectTransform CreateItem(RectTransform rectParent, RectTransform template)
		{
			GameObject obj = Object.Instantiate(template.gameObject, rectParent);
			obj.gameObject.SetActive(value: true);
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
