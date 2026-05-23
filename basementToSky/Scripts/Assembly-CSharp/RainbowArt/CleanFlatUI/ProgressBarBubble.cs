using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarBubble : MonoBehaviour
	{
		[SerializeField]
		private float currentValue;

		[SerializeField]
		private float maxValue = 100f;

		[SerializeField]
		private bool hasText = true;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private Image foreground;

		[SerializeField]
		private RectTransform bubble;

		private bool bDelayedUpdate;

		public float CurrentValue
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
				}
			}
		}

		public float MaxValue
		{
			get
			{
				return maxValue;
			}
			set
			{
				if (maxValue != value)
				{
					maxValue = value;
					OnValueChanged();
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
			if (maxValue < 0f)
			{
				maxValue = 100f;
			}
			if (currentValue < 0f)
			{
				currentValue = 0f;
			}
			currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
			UpdateGUI();
		}

		private void Start()
		{
			OnValueChanged();
		}

		private void OnEnable()
		{
			OnValueChanged();
		}

		private void Update()
		{
			if (bDelayedUpdate)
			{
				bDelayedUpdate = false;
				OnValueChanged();
			}
		}

		private void UpdateGUI()
		{
			UpdateForeground();
			UpdateText();
		}

		private void UpdateForeground()
		{
			foreground.fillAmount = currentValue / maxValue;
		}

		private void UpdateText()
		{
			if (bubble != null && bubble.gameObject.activeSelf != hasText)
			{
				bubble.gameObject.SetActive(hasText);
			}
			if (hasText && text != null && bubble != null)
			{
				text.text = (int)(currentValue / maxValue * 100f) + "%";
				float width = foreground.rectTransform.rect.width;
				float num = width * foreground.fillAmount;
				float x = (0f - width) / 2f + num;
				Vector3 anchoredPosition3D = bubble.anchoredPosition3D;
				anchoredPosition3D.x = x;
				bubble.anchoredPosition3D = anchoredPosition3D;
			}
		}
	}
}
