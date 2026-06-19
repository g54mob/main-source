using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class SwitchManager : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, ISelectHandler, IDeselectHandler, ISubmitHandler
	{
		[Serializable]
		public class SwitchEvent : UnityEvent<bool>
		{
		}

		[SerializeField]
		private Animator switchAnimator;

		[SerializeField]
		private CanvasGroup highlightCG;

		public bool saveValue;

		public string saveKey = "My Switch";

		public DreamOSDataManager.DataCategory dataCategory = DreamOSDataManager.DataCategory.Apps;

		public bool isOn = true;

		public bool isInteractable = true;

		public bool invokeAtStart = true;

		[SerializeField]
		private bool useEventTrigger = true;

		public bool useSounds = true;

		public bool useUINavigation;

		[Range(0f, 15f)]
		public float fadingMultiplier = 8f;

		[SerializeField]
		public SwitchEvent onValueChanged = new SwitchEvent();

		public UnityEvent onEvents;

		public UnityEvent offEvents;

		private bool isInitialized;

		private void Awake()
		{
			if (saveValue)
			{
				GetSavedData();
			}
			else if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				switchAnimator.enabled = true;
				if (isOn)
				{
					switchAnimator.Play("On Instant");
				}
				else
				{
					switchAnimator.Play("Off Instant");
				}
			}
			if (useEventTrigger && base.gameObject.GetComponent<EventTrigger>() == null)
			{
				base.gameObject.AddComponent<EventTrigger>();
			}
			if (base.gameObject.GetComponent<Image>() == null)
			{
				Image image = base.gameObject.AddComponent<Image>();
				image.color = new Color(0f, 0f, 0f, 0f);
				image.raycastTarget = true;
			}
			if (useUINavigation)
			{
				AddUINavigation();
			}
			if (highlightCG == null)
			{
				highlightCG = new GameObject().AddComponent<CanvasGroup>();
				highlightCG.transform.SetParent(base.transform);
				highlightCG.gameObject.name = "Highlighted";
			}
			if (invokeAtStart && isOn)
			{
				onEvents.Invoke();
				onValueChanged.Invoke(isOn);
			}
			else if (invokeAtStart && !isOn)
			{
				offEvents.Invoke();
				onValueChanged.Invoke(isOn);
			}
			isInitialized = true;
		}

		private void OnEnable()
		{
			if (isInitialized)
			{
				UpdateUI();
			}
		}

		private void GetSavedData()
		{
			if (!DreamOSDataManager.ContainsJsonKey(dataCategory, saveKey))
			{
				if (isOn)
				{
					DreamOSDataManager.WriteBooleanData(dataCategory, saveKey, value: true);
				}
				else
				{
					DreamOSDataManager.WriteBooleanData(dataCategory, saveKey, value: false);
				}
			}
			else if (DreamOSDataManager.ReadBooleanData(dataCategory, saveKey))
			{
				isOn = true;
			}
			else if (!DreamOSDataManager.ReadBooleanData(dataCategory, saveKey))
			{
				isOn = false;
			}
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				switchAnimator.enabled = true;
				if (isOn)
				{
					switchAnimator.Play("On");
				}
				else
				{
					switchAnimator.Play("Off");
				}
			}
		}

		public void AddUINavigation()
		{
			Button button = base.gameObject.AddComponent<Button>();
			button.transition = Selectable.Transition.None;
			button.navigation = new Navigation
			{
				mode = Navigation.Mode.Automatic
			};
		}

		public void AnimateSwitch()
		{
			if (isOn)
			{
				SetOff();
			}
			else
			{
				SetOn();
			}
		}

		public void SetOn(bool notifyEvents = true)
		{
			if (saveValue)
			{
				DreamOSDataManager.WriteBooleanData(dataCategory, saveKey, value: true);
			}
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				switchAnimator.enabled = true;
				switchAnimator.Play("On");
			}
			isOn = true;
			if (notifyEvents)
			{
				onEvents.Invoke();
				onValueChanged.Invoke(arg0: true);
			}
		}

		public void SetOff(bool notifyEvents = true)
		{
			if (saveValue)
			{
				DreamOSDataManager.WriteBooleanData(dataCategory, saveKey, value: false);
			}
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				switchAnimator.enabled = true;
				switchAnimator.Play("Off");
			}
			isOn = false;
			if (notifyEvents)
			{
				offEvents.Invoke();
				onValueChanged.Invoke(arg0: false);
			}
		}

		public void UpdateUI()
		{
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				switchAnimator.enabled = true;
				if (isOn)
				{
					switchAnimator.Play("On Instant");
				}
				else
				{
					switchAnimator.Play("Off Instant");
				}
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (isInteractable && eventData.button == PointerEventData.InputButton.Left)
			{
				if (AudioManager.instance != null && useSounds)
				{
					AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.clickSound);
				}
				AnimateSwitch();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (AudioManager.instance != null && useSounds)
			{
				AudioManager.instance.audioSource.PlayOneShot(AudioManager.instance.UIManagerAsset.hoverSound);
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

		public void OnSubmit(BaseEventData eventData)
		{
			if (isInteractable)
			{
				AnimateSwitch();
				StartCoroutine("SetNormal");
			}
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(0.5f);
			switchAnimator.enabled = false;
		}

		private IEnumerator SetNormal()
		{
			StopCoroutine("SetHighlight");
			if (fadingMultiplier == 0f)
			{
				highlightCG.alpha = 0f;
			}
			else
			{
				while (highlightCG.alpha > 0.01f)
				{
					highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
					yield return null;
				}
			}
			highlightCG.alpha = 0f;
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetNormal");
			if (fadingMultiplier == 0f)
			{
				highlightCG.alpha = 1f;
			}
			else
			{
				while (highlightCG.alpha < 0.99f)
				{
					highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
					yield return null;
				}
			}
			highlightCG.alpha = 1f;
		}
	}
}
