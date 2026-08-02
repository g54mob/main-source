using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(Slider))]
	public class SliderManager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler
	{
		[Serializable]
		public class SliderEvent : UnityEvent<float>
		{
		}

		public Slider mainSlider;

		[SerializeField]
		private TextMeshProUGUI valueText;

		[SerializeField]
		private CanvasGroup highlightCG;

		public bool saveValue;

		public bool invokeOnAwake = true;

		public string saveKey = "My Slider";

		public bool isInteractable = true;

		public bool usePercent;

		public bool showValue = true;

		public bool showPopupValue = true;

		public bool useRoundValue;

		public bool useSounds = true;

		[Range(1f, 15f)]
		public float fadingMultiplier = 8f;

		[SerializeField]
		public SliderEvent onValueChanged = new SliderEvent();

		private void Awake()
		{
			if (highlightCG == null)
			{
				highlightCG = new GameObject().AddComponent<CanvasGroup>();
				highlightCG.gameObject.AddComponent<RectTransform>();
				highlightCG.transform.SetParent(base.transform);
				highlightCG.gameObject.name = "Highlight";
			}
			if (mainSlider == null)
			{
				mainSlider = base.gameObject.GetComponent<Slider>();
			}
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			highlightCG.alpha = 0f;
			highlightCG.gameObject.SetActive(value: false);
			float value = mainSlider.value;
			if (saveValue)
			{
				if (PlayerPrefs.HasKey("Slider_" + saveKey))
				{
					value = PlayerPrefs.GetFloat("Slider_" + saveKey);
				}
				else
				{
					PlayerPrefs.SetFloat("Slider_" + saveKey, value);
				}
				mainSlider.value = value;
				mainSlider.onValueChanged.AddListener(delegate
				{
					PlayerPrefs.SetFloat("Slider_" + saveKey, mainSlider.value);
				});
			}
			mainSlider.onValueChanged.AddListener(delegate
			{
				onValueChanged.Invoke(mainSlider.value);
				UpdateUI();
			});
			if (invokeOnAwake)
			{
				onValueChanged.Invoke(mainSlider.value);
			}
			UpdateUI();
		}

		private void Start()
		{
			if (UIManagerAudio.instance == null)
			{
				useSounds = false;
			}
		}

		public void Interactable(bool value)
		{
			isInteractable = value;
			mainSlider.interactable = isInteractable;
		}

		public void AddUINavigation()
		{
			Navigation navigation = new Navigation
			{
				mode = Navigation.Mode.Automatic
			};
			mainSlider.navigation = navigation;
		}

		public void UpdateUI()
		{
			if (valueText == null)
			{
				return;
			}
			if (useRoundValue)
			{
				if (usePercent && valueText != null)
				{
					valueText.text = Mathf.Round(mainSlider.value * 1f) + "%";
				}
				else if (valueText != null)
				{
					valueText.text = Mathf.Round(mainSlider.value * 1f).ToString();
				}
			}
			else if (usePercent && valueText != null)
			{
				valueText.text = mainSlider.value.ToString("F1") + "%";
			}
			else if (valueText != null)
			{
				valueText.text = mainSlider.value.ToString("F1");
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (useSounds)
			{
				UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
			}
			if (isInteractable)
			{
				StartCoroutine("SetHighlight");
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (isInteractable)
			{
				StartCoroutine("SetNormal");
			}
		}

		public void OnSelect(BaseEventData eventData)
		{
			if (isInteractable)
			{
				StartCoroutine("SetHighlight");
			}
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (isInteractable)
			{
				StartCoroutine("SetNormal");
			}
		}

		private IEnumerator SetNormal()
		{
			StopCoroutine("SetHighlight");
			while (highlightCG.alpha > 0.01f)
			{
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 0f;
			highlightCG.gameObject.SetActive(value: false);
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetNormal");
			highlightCG.gameObject.SetActive(value: true);
			while (highlightCG.alpha < 0.99f)
			{
				highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 1f;
		}
	}
}
