using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
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

		public bool isOn = true;

		public bool isInteractable = true;

		public bool invokeOnEnable = true;

		public bool useSounds = true;

		public bool useUINavigation;

		[Range(1f, 15f)]
		public float fadingMultiplier = 8f;

		[SerializeField]
		public SwitchEvent onValueChanged = new SwitchEvent();

		public UnityEvent onEvents = new UnityEvent();

		public UnityEvent offEvents = new UnityEvent();

		private bool isInitialized;

		private void Awake()
		{
			if (saveValue)
			{
				GetSavedData();
			}
			else
			{
				if (base.gameObject.activeInHierarchy)
				{
					StopCoroutine("DisableAnimator");
					StartCoroutine("DisableAnimator");
				}
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
			if (invokeOnEnable && isOn)
			{
				onEvents.Invoke();
				onValueChanged.Invoke(isOn);
			}
			else if (invokeOnEnable && !isOn)
			{
				offEvents.Invoke();
				onValueChanged.Invoke(isOn);
			}
			isInitialized = true;
		}

		private void OnEnable()
		{
			if (UIManagerAudio.instance == null)
			{
				useSounds = false;
			}
			if (isInitialized)
			{
				UpdateUI();
			}
		}

		private void GetSavedData()
		{
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
			}
			switchAnimator.enabled = true;
			if (PlayerPrefs.GetString("Switch_" + saveKey) == "" || !PlayerPrefs.HasKey("Switch_" + saveKey))
			{
				if (isOn)
				{
					switchAnimator.Play("Off");
					PlayerPrefs.SetString("Switch_" + saveKey, "true");
				}
				else
				{
					switchAnimator.Play("Off");
					PlayerPrefs.SetString("Switch_" + saveKey, "false");
				}
			}
			else if (PlayerPrefs.GetString("Switch_" + saveKey) == "true")
			{
				switchAnimator.Play("Off");
				isOn = true;
			}
			else if (PlayerPrefs.GetString("Switch_" + saveKey) == "false")
			{
				switchAnimator.Play("Off");
				isOn = false;
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
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
			}
			switchAnimator.enabled = true;
			if (isOn)
			{
				switchAnimator.Play("Off");
				isOn = false;
				offEvents.Invoke();
				if (saveValue)
				{
					PlayerPrefs.SetString("Switch_" + saveKey, "false");
				}
			}
			else
			{
				switchAnimator.Play("On");
				isOn = true;
				onEvents.Invoke();
				if (saveValue)
				{
					PlayerPrefs.SetString("Switch_" + saveKey, "true");
				}
			}
			onValueChanged.Invoke(isOn);
		}

		public void SetOn()
		{
			if (saveValue)
			{
				PlayerPrefs.SetString("Switch_" + saveKey, "true");
			}
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
			}
			switchAnimator.enabled = true;
			switchAnimator.Play("On");
			isOn = true;
			onEvents.Invoke();
			onValueChanged.Invoke(arg0: true);
		}

		public void SetOff()
		{
			if (saveValue)
			{
				PlayerPrefs.SetString("Switch_" + saveKey, "false");
			}
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
			}
			switchAnimator.enabled = true;
			switchAnimator.Play("Off");
			isOn = false;
			offEvents.Invoke();
			onValueChanged.Invoke(arg0: false);
		}

		public void UpdateUI()
		{
			if (base.gameObject.activeInHierarchy)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
			}
			switchAnimator.enabled = true;
			if (isOn && switchAnimator.gameObject.activeInHierarchy)
			{
				switchAnimator.Play("On Instant");
			}
			else if (!isOn && switchAnimator.gameObject.activeInHierarchy)
			{
				switchAnimator.Play("Off Instant");
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			if (isInteractable && eventData.button == PointerEventData.InputButton.Left)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
				}
				AnimateSwitch();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (isInteractable)
			{
				if (useSounds)
				{
					UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
				}
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
			while (highlightCG.alpha > 0.01f)
			{
				highlightCG.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 0f;
		}

		private IEnumerator SetHighlight()
		{
			StopCoroutine("SetNormal");
			while (highlightCG.alpha < 0.99f)
			{
				highlightCG.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			highlightCG.alpha = 1f;
		}
	}
}
