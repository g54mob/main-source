using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class SliderManager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Serializable]
		public class SliderEvent : UnityEvent<float>
		{
		}

		public Slider mainSlider;

		public TextMeshProUGUI valueText;

		public TextMeshProUGUI popupValueText;

		public bool enableSaving;

		public string sliderTag = "Tag Text";

		public bool usePercent;

		public bool showValue = true;

		public bool showPopupValue = true;

		public bool useRoundValue;

		[SerializeField]
		public SliderEvent onValueChanged = new SliderEvent();

		public SliderEvent sliderEvent;

		public Animator sliderAnimator;

		public float saveValue;

		private void Start()
		{
			try
			{
				sliderAnimator = base.gameObject.GetComponent<Animator>();
				if (enableSaving)
				{
					if (!PlayerPrefs.HasKey(sliderTag + "SliderValue"))
					{
						saveValue = mainSlider.value;
					}
					else
					{
						saveValue = PlayerPrefs.GetFloat(sliderTag + "SliderValue");
					}
					mainSlider.value = saveValue;
					mainSlider.onValueChanged.AddListener(delegate
					{
						saveValue = mainSlider.value;
						PlayerPrefs.SetFloat(sliderTag + "SliderValue", saveValue);
					});
				}
				mainSlider.onValueChanged.AddListener(delegate
				{
					sliderEvent.Invoke(mainSlider.value);
				});
			}
			catch
			{
				Debug.LogError("Slider - Cannot initalize the object due to missing components.");
			}
		}

		private void Update()
		{
			if (useRoundValue)
			{
				if (usePercent)
				{
					if (valueText != null)
					{
						valueText.text = Mathf.Round(mainSlider.value * 1f) + "%";
					}
					if (popupValueText != null)
					{
						popupValueText.text = Mathf.Round(mainSlider.value * 1f) + "%";
					}
				}
				else
				{
					if (valueText != null)
					{
						valueText.text = Mathf.Round(mainSlider.value * 1f).ToString();
					}
					if (popupValueText != null)
					{
						popupValueText.text = Mathf.Round(mainSlider.value * 1f).ToString();
					}
				}
			}
			else if (usePercent)
			{
				if (valueText != null)
				{
					valueText.text = mainSlider.value.ToString("F1") + "%";
				}
				if (popupValueText != null)
				{
					popupValueText.text = mainSlider.value.ToString("F1") + "%";
				}
			}
			else
			{
				if (valueText != null)
				{
					valueText.text = mainSlider.value.ToString("F1");
				}
				if (popupValueText != null)
				{
					popupValueText.text = mainSlider.value.ToString("F1");
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (showPopupValue)
			{
				sliderAnimator.Play("Value In");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (showPopupValue)
			{
				sliderAnimator.Play("Value Out");
			}
		}

		private void _003CStart_003Eb__14_0(float _003Cp0_003E)
		{
			saveValue = mainSlider.value;
			PlayerPrefs.SetFloat(sliderTag + "SliderValue", saveValue);
		}

		private void _003CStart_003Eb__14_1(float _003Cp0_003E)
		{
			sliderEvent.Invoke(mainSlider.value);
		}
	}
}
