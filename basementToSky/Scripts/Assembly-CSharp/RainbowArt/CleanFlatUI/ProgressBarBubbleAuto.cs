using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarBubbleAuto : MonoBehaviour
	{
		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue = 100f;

		private float currentValue;

		[Range(0f, 1f)]
		[SerializeField]
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
		private Image foreground;

		[SerializeField]
		private RectTransform bubble;

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

		private void OnEnable()
		{
			InitValue();
		}

		private void Start()
		{
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
