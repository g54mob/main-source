using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarSpecialPatternAuto : MonoBehaviour
	{
		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue = 100f;

		[SerializeField]
		[Range(0f, 1f)]
		private float loadSpeed = 0.1f;

		[SerializeField]
		private bool forward = true;

		[SerializeField]
		private bool loop = true;

		[SerializeField]
		private bool hasText = true;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private RectTransform foreground;

		[SerializeField]
		private RectTransform foregroundArea;

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

		private float currentValue;

		private bool bDelayedUpdate;

		public float MinValue
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
			if (minValue < 0f)
			{
				minValue = 0f;
			}
			currentValue = Mathf.Clamp(minValue, 0f, maxValue);
			Rect uvRect = patternImage.uvRect;
			uvRect.width = currentValue / maxValue * patternScale;
			patternImage.uvRect = uvRect;
			UpdateGUI();
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
			UpdateGUI();
		}

		private void Update()
		{
			if (Application.isPlaying)
			{
				if (forward)
				{
					if (currentValue < maxValue)
					{
						currentValue += loadSpeed * (Time.deltaTime * 100f);
						if (currentValue >= maxValue)
						{
							currentValue = maxValue;
						}
						UpdateGUI();
					}
					if (loop && currentValue >= maxValue)
					{
						currentValue = minValue;
					}
					return;
				}
				if (currentValue > minValue)
				{
					currentValue -= loadSpeed * (Time.deltaTime * 100f);
					if (currentValue <= minValue)
					{
						currentValue = minValue;
					}
					UpdateGUI();
				}
				if (loop && currentValue <= minValue)
				{
					currentValue = maxValue;
				}
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
			float width = foregroundArea.rect.width;
			Vector2 offsetMax = foreground.offsetMax;
			offsetMax.x = 0f - (width - width * (currentValue / maxValue));
			foreground.offsetMax = offsetMax;
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
				text.text = Mathf.Floor(currentValue) + "/" + Mathf.Floor(maxValue);
			}
		}
	}
}
