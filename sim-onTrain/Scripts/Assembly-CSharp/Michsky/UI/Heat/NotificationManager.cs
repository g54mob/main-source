using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(Animator))]
	public class NotificationManager : MonoBehaviour
	{
		public enum DefaultState
		{
			Minimized = 0,
			Expanded = 1
		}

		public enum AfterMinimize
		{
			Disable = 0,
			Destroy = 1
		}

		public Sprite icon;

		[TextArea]
		public string notificationText = "Notification Text";

		public string localizationKey;

		public AudioClip customSFX;

		[SerializeField]
		private Animator itemAnimator;

		[SerializeField]
		private Image iconObj;

		[SerializeField]
		private TextMeshProUGUI textObj;

		public bool useLocalization = true;

		[SerializeField]
		private bool updateOnAnimate = true;

		[Range(0f, 10f)]
		public float minimizeAfter = 3f;

		public DefaultState defaultState;

		public AfterMinimize afterMinimize;

		public UnityEvent onDestroy = new UnityEvent();

		private bool isOn;

		private LocalizedObject localizedObject;

		private void Start()
		{
			if (itemAnimator == null)
			{
				itemAnimator = GetComponent<Animator>();
			}
			if (useLocalization)
			{
				localizedObject = textObj.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
				else if (localizedObject != null && !string.IsNullOrEmpty(localizationKey))
				{
					notificationText = localizedObject.GetKeyOutput(localizationKey);
					localizedObject.onLanguageChanged.AddListener(delegate
					{
						notificationText = localizedObject.GetKeyOutput(localizationKey);
						UpdateUI();
					});
				}
			}
			if (defaultState == DefaultState.Minimized)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (defaultState == DefaultState.Expanded)
			{
				ExpandNotification();
			}
			UpdateUI();
		}

		public void UpdateUI()
		{
			iconObj.sprite = icon;
			textObj.text = notificationText;
		}

		public void AnimateNotification()
		{
			ExpandNotification();
		}

		public void ExpandNotification()
		{
			if (isOn)
			{
				StopCoroutine("DisableAnimator");
				StartCoroutine("DisableAnimator");
				if (minimizeAfter != 0f)
				{
					StopCoroutine("MinimizeItem");
					StartCoroutine("MinimizeItem");
				}
				return;
			}
			isOn = true;
			base.gameObject.SetActive(value: true);
			itemAnimator.enabled = true;
			itemAnimator.Play("In");
			if (updateOnAnimate)
			{
				UpdateUI();
			}
			if (minimizeAfter != 0f)
			{
				StopCoroutine("MinimizeItem");
				StartCoroutine("MinimizeItem");
			}
			if (customSFX != null && UIManagerAudio.instance != null)
			{
				UIManagerAudio.instance.audioSource.PlayOneShot(customSFX);
			}
			else if (UIManagerAudio.instance != null && UIManagerAudio.instance.UIManagerAsset.notificationSound != null)
			{
				UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.notificationSound);
			}
			StopCoroutine("DisableAnimator");
			StartCoroutine("DisableAnimator");
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
		}

		public void MinimizeNotification()
		{
			if (isOn)
			{
				StopCoroutine("DisableAnimator");
				itemAnimator.enabled = true;
				itemAnimator.Play("Out");
				StopCoroutine("DisableItem");
				StartCoroutine("DisableItem");
			}
		}

		public void DestroyNotification()
		{
			onDestroy.Invoke();
			Object.Destroy(base.gameObject);
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(HeatUIInternalTools.GetAnimatorClipLength(itemAnimator, "Notification_In"));
			itemAnimator.enabled = false;
		}

		private IEnumerator DisableItem()
		{
			yield return new WaitForSeconds(HeatUIInternalTools.GetAnimatorClipLength(itemAnimator, "Notification_Out"));
			isOn = false;
			if (afterMinimize == AfterMinimize.Disable)
			{
				base.gameObject.SetActive(value: false);
			}
			else if (afterMinimize == AfterMinimize.Destroy)
			{
				DestroyNotification();
			}
		}

		private IEnumerator MinimizeItem()
		{
			yield return new WaitForSeconds(minimizeAfter);
			MinimizeNotification();
		}
	}
}
