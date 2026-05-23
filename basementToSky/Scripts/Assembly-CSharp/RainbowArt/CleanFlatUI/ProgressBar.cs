using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	[ExecuteAlways]
	public class ProgressBar : MonoBehaviour
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
			StartCoroutine(DelayedUpdateGUI());
		}

		private IEnumerator DelayedUpdateGUI()
		{
			yield return new WaitForEndOfFrame();
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
