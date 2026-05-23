using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBarCircularMove : MonoBehaviour
	{
		public enum Origin
		{
			Bottom = 0,
			Top = 1,
			Left = 2,
			Right = 3
		}

		public enum PatternOriginVertical
		{
			Bottom = 0,
			Top = 1
		}

		public enum PatternOriginHorizontal
		{
			Left = 0,
			Right = 1
		}

		[SerializeField]
		public float currentValue;

		[SerializeField]
		public float maxValue = 100f;

		[SerializeField]
		public bool hasText = true;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private RectTransform foregroundArea;

		[SerializeField]
		private RawImage patternImage;

		[SerializeField]
		private RectTransform patternRect;

		[SerializeField]
		private Origin origin;

		[SerializeField]
		private bool patternPlay = true;

		[SerializeField]
		private float patternSpeed = 1.5f;

		[SerializeField]
		private int patternOrigin;

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

		public int PatternOrigin
		{
			get
			{
				return patternOrigin;
			}
			set
			{
				patternOrigin = value;
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
			UpdatePattern();
			UpdateText();
		}

		private void UpdatePattern()
		{
			if (!patternPlay || !Application.isPlaying)
			{
				return;
			}
			switch (origin)
			{
			case Origin.Bottom:
			case Origin.Top:
			{
				Rect uvRect2 = patternImage.uvRect;
				if (patternOrigin == 0)
				{
					uvRect2.x -= Time.deltaTime * patternSpeed;
				}
				else
				{
					uvRect2.x += Time.deltaTime * patternSpeed;
				}
				patternImage.uvRect = uvRect2;
				break;
			}
			case Origin.Left:
			case Origin.Right:
			{
				Rect uvRect = patternImage.uvRect;
				if (patternOrigin == 0)
				{
					uvRect.y -= Time.deltaTime * patternSpeed;
				}
				else
				{
					uvRect.y += Time.deltaTime * patternSpeed;
				}
				patternImage.uvRect = uvRect;
				break;
			}
			}
		}

		private void UpdateForeground()
		{
			if (currentValue == 0f)
			{
				foregroundArea.gameObject.SetActive(value: false);
				return;
			}
			foregroundArea.gameObject.SetActive(value: true);
			ResetForegroundOrigon();
			switch (origin)
			{
			case Origin.Bottom:
				UpdateForegroundFromBottom();
				break;
			case Origin.Top:
				UpdateForegroundFromTop();
				break;
			case Origin.Left:
				UpdateForegroundFromLeft();
				break;
			case Origin.Right:
				UpdateForegroundFromRight();
				break;
			}
		}

		private void ResetForegroundOrigon()
		{
			patternRect.offsetMax = Vector2.zero;
			patternRect.offsetMin = Vector2.zero;
		}

		private void UpdateForegroundFromBottom()
		{
			float height = foregroundArea.rect.height;
			Vector2 offsetMax = patternRect.offsetMax;
			offsetMax.y = 0f - (height - height * (currentValue / maxValue));
			Vector2 offsetMin = patternRect.offsetMin;
			offsetMin.y = 0f - (height - height * (currentValue / maxValue));
			patternRect.offsetMax = offsetMax;
			patternRect.offsetMin = offsetMin;
		}

		private void UpdateForegroundFromTop()
		{
			float height = foregroundArea.rect.height;
			Vector2 offsetMax = patternRect.offsetMax;
			offsetMax.y = height - height * (currentValue / maxValue);
			Vector2 offsetMin = patternRect.offsetMin;
			offsetMin.y = height - height * (currentValue / maxValue);
			patternRect.offsetMax = offsetMax;
			patternRect.offsetMin = offsetMin;
		}

		private void UpdateForegroundFromLeft()
		{
			float width = foregroundArea.rect.width;
			Vector2 offsetMax = patternRect.offsetMax;
			offsetMax.x = 0f - (width - width * (currentValue / maxValue));
			Vector2 offsetMin = patternRect.offsetMin;
			offsetMin.x = 0f - (width - width * (currentValue / maxValue));
			patternRect.offsetMax = offsetMax;
			patternRect.offsetMin = offsetMin;
		}

		private void UpdateForegroundFromRight()
		{
			float width = foregroundArea.rect.width;
			Vector2 offsetMax = patternRect.offsetMax;
			offsetMax.x = width - width * (currentValue / maxValue);
			Vector2 offsetMin = patternRect.offsetMin;
			offsetMin.x = width - width * (currentValue / maxValue);
			patternRect.offsetMax = offsetMax;
			patternRect.offsetMin = offsetMin;
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
