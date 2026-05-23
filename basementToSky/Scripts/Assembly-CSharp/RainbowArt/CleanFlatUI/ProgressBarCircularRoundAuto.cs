using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarCircularRoundAuto : MonoBehaviour
	{
		public enum Origin
		{
			Bottom = 0,
			Right = 1,
			Top = 2,
			Left = 3
		}

		[SerializeField]
		private float minValue;

		[SerializeField]
		private float maxValue = 100f;

		private float currentValue;

		[SerializeField]
		[Range(0f, 1f)]
		private float loadSpeed = 0.1f;

		[SerializeField]
		private bool clockwise = true;

		[SerializeField]
		private bool loop = true;

		[SerializeField]
		private bool hasText = true;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private Image foreground;

		[SerializeField]
		private RectTransform roundArea;

		[SerializeField]
		private Image roundImage;

		[SerializeField]
		private Origin origin;

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

		public bool Clockwise
		{
			get
			{
				return clockwise;
			}
			set
			{
				clockwise = value;
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

		public Origin CurOrigin
		{
			get
			{
				return origin;
			}
			set
			{
				origin = value;
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
			if (clockwise)
			{
				currentValue = minValue;
			}
			else
			{
				currentValue = maxValue;
			}
		}

		private void InitRoundImage()
		{
			if (currentValue <= 0f)
			{
				roundArea.gameObject.SetActive(value: false);
			}
			else
			{
				roundArea.gameObject.SetActive(value: true);
			}
		}

		private void Start()
		{
			InitValue();
			InitRoundImage();
			UpdateGUI();
		}

		private void Update()
		{
			if (Application.isPlaying)
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
			}
			else if (bDelayedUpdate)
			{
				bDelayedUpdate = false;
				OnValueChanged();
			}
		}

		public void UpdateGUI()
		{
			UpdateForeground();
			UpdateRoundArea();
			UpdateText();
		}

		private void UpdateForeground()
		{
			foreground.fillAmount = currentValue / maxValue;
			foreground.fillMethod = Image.FillMethod.Radial360;
			foreground.fillOrigin = (int)origin;
			foreground.fillClockwise = clockwise;
			if (clockwise)
			{
				roundImage.fillOrigin = 1;
			}
			else
			{
				roundImage.fillOrigin = 3;
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

		private void UpdateRoundArea()
		{
			if (currentValue <= 0f)
			{
				roundArea.gameObject.SetActive(value: false);
				return;
			}
			roundArea.gameObject.SetActive(value: true);
			Vector3 zero = Vector3.zero;
			switch (origin)
			{
			case Origin.Top:
				if (clockwise)
				{
					zero.z = 360f * (1f - foreground.fillAmount);
				}
				else
				{
					zero.z = 360f * foreground.fillAmount;
				}
				break;
			case Origin.Bottom:
				if (clockwise)
				{
					zero.z = 360f * (1f - foreground.fillAmount) + 180f;
				}
				else
				{
					zero.z = 360f * foreground.fillAmount - 180f;
				}
				break;
			case Origin.Right:
				if (clockwise)
				{
					zero.z = 360f * (1f - foreground.fillAmount) + 270f;
				}
				else
				{
					zero.z = 360f * foreground.fillAmount + 270f;
				}
				break;
			case Origin.Left:
				if (clockwise)
				{
					zero.z = 360f * (1f - foreground.fillAmount) + 90f;
				}
				else
				{
					zero.z = 360f * foreground.fillAmount + 90f;
				}
				break;
			}
			zero.z %= 360f;
			roundArea.localEulerAngles = zero;
		}
	}
}
