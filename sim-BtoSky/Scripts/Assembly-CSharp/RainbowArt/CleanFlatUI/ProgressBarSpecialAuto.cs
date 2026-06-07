using TMPro;
using UnityEngine;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarSpecialAuto : MonoBehaviour
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
