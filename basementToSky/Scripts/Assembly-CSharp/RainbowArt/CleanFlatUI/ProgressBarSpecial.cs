using TMPro;
using UnityEngine;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarSpecial : MonoBehaviour
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
		private RectTransform foreground;

		[SerializeField]
		private RectTransform foregroundArea;

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
			UpdateGUI();
		}

		private void Update()
		{
			if (Application.isPlaying)
			{
				UpdateGUI();
			}
			else if (bDelayedUpdate)
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
			float width = foregroundArea.rect.width;
			Vector2 offsetMax = foreground.offsetMax;
			offsetMax.x = 0f - (width - width * (currentValue / maxValue));
			foreground.offsetMax = offsetMax;
		}

		private void UpdateText()
		{
			if (text != null && text.gameObject.activeSelf != hasText)
			{
				text.gameObject.SetActive(hasText);
			}
			if (hasText && text != null)
			{
				text.text = Mathf.Floor(currentValue) + "/" + Mathf.Floor(maxValue);
			}
		}
	}
}
