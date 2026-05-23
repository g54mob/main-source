using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarPattern : MonoBehaviour
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
		private RawImage patternImage;

		[SerializeField]
		private RectTransform patternRect;

		[SerializeField]
		private bool patternPlay = true;

		[SerializeField]
		private float patternSpeed = 0.5f;

		[SerializeField]
		private bool patternForward = true;

		[SerializeField]
		private float patternScale = 5f;

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

		public bool PatternPlay
		{
			get
			{
				return patternPlay;
			}
			set
			{
				patternPlay = value;
			}
		}

		public float PatternSpeed
		{
			get
			{
				return patternSpeed;
			}
			set
			{
				patternSpeed = value;
			}
		}

		public bool PatternForward
		{
			get
			{
				return patternForward;
			}
			set
			{
				patternForward = value;
			}
		}

		public float PatternScale
		{
			get
			{
				return patternScale;
			}
			set
			{
				patternScale = value;
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
			Rect uvRect = patternImage.uvRect;
			uvRect.width = currentValue / maxValue * patternScale;
			patternImage.uvRect = uvRect;
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
			UpdateForegroundAndPattern();
			UpdateText();
		}

		private void UpdateForegroundAndPattern()
		{
			foreground.fillAmount = currentValue / maxValue;
			float width = foreground.GetComponent<RectTransform>().rect.width;
			Vector2 offsetMax = patternRect.offsetMax;
			offsetMax.x = 0f - (width - width * (currentValue / maxValue));
			patternRect.offsetMax = offsetMax;
			if (patternPlay)
			{
				Rect uvRect = patternImage.uvRect;
				if (patternForward)
				{
					uvRect.x -= Time.deltaTime * patternSpeed;
				}
				else
				{
					uvRect.x += Time.deltaTime * patternSpeed;
				}
				uvRect.width = currentValue / maxValue * patternScale;
				patternImage.uvRect = uvRect;
			}
			else
			{
				Rect uvRect2 = patternImage.uvRect;
				uvRect2.width = currentValue / maxValue * patternScale;
				patternImage.uvRect = uvRect2;
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
				text.text = (int)(currentValue / maxValue * 100f) + "%";
			}
		}
	}
}
