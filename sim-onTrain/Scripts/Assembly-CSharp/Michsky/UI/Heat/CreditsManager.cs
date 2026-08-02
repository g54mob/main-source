using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	[RequireComponent(typeof(CanvasGroup))]
	public class CreditsManager : MonoBehaviour
	{
		[SerializeField]
		private CreditsPreset creditsPreset;

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private VerticalLayoutGroup creditsListParent;

		[SerializeField]
		private Scrollbar scrollHelper;

		[SerializeField]
		private GameObject creditsSectionPreset;

		[SerializeField]
		private GameObject creditsMentionPreset;

		[SerializeField]
		private bool closeAutomatically = true;

		[SerializeField]
		[Range(1f, 15f)]
		private float fadingMultiplier = 4f;

		[SerializeField]
		[Range(0f, 10f)]
		private float scrollDelay = 1.25f;

		[Range(0f, 0.5f)]
		public float scrollSpeed = 0.05f;

		[Range(1.1f, 15f)]
		public float boostValue = 3f;

		[SerializeField]
		private InputAction boostHotkey;

		public UnityEvent onOpen = new UnityEvent();

		public UnityEvent onClose = new UnityEvent();

		public UnityEvent onCreditsEnd = new UnityEvent();

		private bool isOpen;

		private bool enableScrolling;

		private bool invokedEndEvents;

		private void Awake()
		{
			InitCredits();
			boostHotkey.Enable();
			if (closeAutomatically)
			{
				onCreditsEnd.AddListener(delegate
				{
					ClosePanel();
				});
			}
		}

		private void OnEnable()
		{
			StartScrolling();
		}

		private void OnDisable()
		{
			invokedEndEvents = false;
			enableScrolling = false;
		}

		private void Update()
		{
			if (enableScrolling)
			{
				if (boostHotkey.IsInProgress())
				{
					scrollHelper.value -= scrollSpeed * boostValue * Time.deltaTime;
				}
				else
				{
					scrollHelper.value -= scrollSpeed * Time.deltaTime;
				}
				if (scrollHelper.value <= 0.005f && !invokedEndEvents)
				{
					onCreditsEnd.Invoke();
					invokedEndEvents = true;
				}
				if (scrollHelper.value <= 0f)
				{
					enableScrolling = false;
					onCreditsEnd.Invoke();
				}
			}
		}

		private void InitCredits()
		{
			if (creditsPreset == null)
			{
				Debug.LogWarning("'Credits Preset' is missing.", this);
				return;
			}
			backgroundImage.sprite = creditsPreset.backgroundSprite;
			foreach (Transform item in creditsListParent.transform)
			{
				if (item.GetComponent<CreditsSectionItem>() != null || item.GetComponent<CreditsMentionItem>() != null)
				{
					Object.Destroy(item.gameObject);
				}
			}
			for (int i = 0; i < creditsPreset.credits.Count; i++)
			{
				GameObject obj = Object.Instantiate(creditsSectionPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj.transform.SetParent(creditsListParent.transform, worldPositionStays: false);
				obj.name = creditsPreset.credits[i].headerTitle;
				CreditsSectionItem component = obj.GetComponent<CreditsSectionItem>();
				component.preset = creditsPreset;
				component.SetHeader(creditsPreset.credits[i].headerTitle);
				if (creditsPreset.credits[i].items.Count < 2)
				{
					component.headerLayout.padding.bottom = 0;
				}
				if (!string.IsNullOrEmpty(creditsPreset.credits[i].headerTitleKey))
				{
					component.CheckForLocalization(creditsPreset.credits[i].headerTitleKey);
				}
				foreach (string item2 in creditsPreset.credits[i].items)
				{
					component.AddNameToList(item2);
				}
				Object.Destroy(component.namePreset);
				component.UpdateLayout();
			}
			for (int j = 0; j < creditsPreset.mentions.Count; j++)
			{
				GameObject obj2 = Object.Instantiate(creditsMentionPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				obj2.transform.SetParent(creditsListParent.transform, worldPositionStays: false);
				obj2.name = creditsPreset.mentions[j].ID;
				CreditsMentionItem component2 = obj2.GetComponent<CreditsMentionItem>();
				component2.preset = creditsPreset;
				component2.UpdateLayout(creditsPreset.mentions[j].layoutSpacing, creditsPreset.mentions[j].descriptionSpacing);
				if (j == 0)
				{
					component2.listLayout.padding.top = component2.listLayout.padding.top * 2;
				}
				component2.SetIcon(creditsPreset.mentions[j].icon);
				component2.SetDescription(creditsPreset.mentions[j].description);
				if (!string.IsNullOrEmpty(creditsPreset.mentions[j].descriptionKey))
				{
					component2.CheckForLocalization(creditsPreset.mentions[j].descriptionKey);
				}
			}
			creditsListParent.padding.bottom = (int)((float)Screen.currentResolution.height / 1.26f);
			StartCoroutine("FixListLayout");
		}

		private void StartScrolling()
		{
			if (!enableScrolling)
			{
				StopCoroutine("StartTimer");
				enableScrolling = false;
				scrollHelper.value = 1f;
				if (scrollDelay != 0f)
				{
					StartCoroutine("StartTimer");
				}
				else
				{
					enableScrolling = true;
				}
			}
		}

		public void OpenPanel()
		{
			if (!isOpen)
			{
				canvasGroup.alpha = 0f;
				base.gameObject.SetActive(value: true);
				isOpen = true;
				onOpen.Invoke();
				StopCoroutine("SetInvisible");
				StartCoroutine("SetVisible");
			}
		}

		public void ClosePanel()
		{
			if (isOpen)
			{
				onClose.Invoke();
				isOpen = false;
				StopCoroutine("SetVisible");
				StartCoroutine("SetInvisible");
			}
		}

		public void EnableScrolling(bool state)
		{
			if (!state)
			{
				enableScrolling = false;
			}
			else
			{
				enableScrolling = true;
			}
		}

		private IEnumerator StartTimer()
		{
			yield return new WaitForSeconds(scrollDelay);
			enableScrolling = true;
		}

		private IEnumerator FixListLayout()
		{
			yield return new WaitForSecondsRealtime(0.025f);
			LayoutRebuilder.ForceRebuildLayoutImmediate(creditsListParent.GetComponent<RectTransform>());
		}

		private IEnumerator SetVisible()
		{
			StopCoroutine("SetInvisible");
			while (canvasGroup.alpha < 0.99f)
			{
				canvasGroup.alpha += Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			canvasGroup.alpha = 1f;
		}

		private IEnumerator SetInvisible()
		{
			StopCoroutine("SetVisible");
			while (canvasGroup.alpha > 0.01f)
			{
				canvasGroup.alpha -= Time.unscaledDeltaTime * fadingMultiplier;
				yield return null;
			}
			canvasGroup.alpha = 0f;
			scrollHelper.value = 1f;
			base.gameObject.SetActive(value: false);
		}
	}
}
