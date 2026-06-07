using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarCircularRound : MonoBehaviour
	{
		public enum Origin
		{
			Bottom = 0,
			Right = 1,
			Top = 2,
			Left = 3
		}

		[SerializeField]
		private float currentValue;

		[SerializeField]
		private float maxValue = 100f;

		[SerializeField]
		private bool hasText = true;

		[SerializeField]
		public TextMeshProUGUI text;

		[SerializeField]
		private Image foreground;

		[SerializeField]
		private RectTransform roundArea;

		[SerializeField]
		private Image roundImage;

		[SerializeField]
		private bool clockwise = true;

		[SerializeField]
		private Origin origin;

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

		public bool Clockwise
		{
			get
			{
				return clockwise;
			}
			set
			{
				if (clockwise != value)
				{
					clockwise = value;
					UpdateGUI();
				}
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
				if (origin != value)
				{
					origin = value;
					UpdateGUI();
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
			InitRoundImage();
			UpdateGUI();
		}

		private void Update()
		{
			if (bDelayedUpdate)
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
