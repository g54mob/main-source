using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.Heat
{
	public class SocialsWidget : MonoBehaviour
	{
		public enum UpdateMode
		{
			DeltaTime = 0,
			UnscaledTime = 1
		}

		[Serializable]
		public class Item
		{
			public string socialID = "News title";

			public Sprite icon;

			public Color backgroundTint = new Color(255f, 255f, 255f, 255f);

			[TextArea]
			public string description = "News description";

			public string link;

			public UnityEvent onClick = new UnityEvent();

			[Header("Localization")]
			public string descriptionKey = "DescriptionKey";
		}

		public List<Item> socials = new List<Item>();

		private List<ButtonManager> buttons = new List<ButtonManager>();

		[SerializeField]
		private GameObject itemPreset;

		[SerializeField]
		private Transform itemParent;

		[SerializeField]
		private GameObject buttonPreset;

		[SerializeField]
		private Transform buttonParent;

		[SerializeField]
		private Image background;

		public bool allowTransition = true;

		public bool useLocalization = true;

		[Range(1f, 30f)]
		public float timer = 4f;

		[Range(0.1f, 3f)]
		public float tintSpeed = 0.5f;

		[SerializeField]
		private AnimationCurve tintCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 1f));

		[SerializeField]
		private UpdateMode updateMode;

		private int currentSliderIndex;

		private float timerCount;

		private bool isInitialized;

		private bool updateTimer;

		private bool isTransitionInProgress;

		private Animator currentItemObject;

		private LocalizedObject localizedObject;

		private Image raycastImg;

		private void OnEnable()
		{
			if (!isInitialized)
			{
				InitializeItems();
			}
			else
			{
				StartCoroutine(InitCurrentItem());
			}
		}

		private void Update()
		{
			if (isInitialized && updateTimer && allowTransition)
			{
				if (updateMode == UpdateMode.UnscaledTime)
				{
					timerCount += Time.unscaledDeltaTime;
				}
				else
				{
					timerCount += Time.deltaTime;
				}
				if (timerCount > timer)
				{
					SetSocialByTimer();
					timerCount = 0f;
				}
			}
		}

		public void InitializeItems()
		{
			if (useLocalization)
			{
				localizedObject = base.gameObject.GetComponent<LocalizedObject>();
				if (localizedObject == null || !localizedObject.CheckLocalizationStatus())
				{
					useLocalization = false;
				}
			}
			foreach (Transform item in itemParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in buttonParent)
			{
				UnityEngine.Object.Destroy(item2.gameObject);
			}
			for (int i = 0; i < socials.Count; i++)
			{
				int tempIndex = i;
				GameObject gameObject = UnityEngine.Object.Instantiate(itemPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(itemParent, worldPositionStays: false);
				gameObject.gameObject.name = socials[i].socialID;
				gameObject.SetActive(value: false);
				TextMeshProUGUI itemDescription = gameObject.transform.GetComponentInChildren<TextMeshProUGUI>();
				if (!useLocalization || string.IsNullOrEmpty(socials[i].descriptionKey))
				{
					itemDescription.text = socials[i].description;
				}
				else
				{
					LocalizedObject tempLoc = itemDescription.GetComponent<LocalizedObject>();
					if (tempLoc != null)
					{
						tempLoc.tableIndex = localizedObject.tableIndex;
						tempLoc.localizationKey = socials[i].descriptionKey;
						tempLoc.onLanguageChanged.AddListener(delegate
						{
							itemDescription.text = tempLoc.GetKeyOutput(tempLoc.localizationKey);
						});
						tempLoc.InitializeItem();
						tempLoc.UpdateItem();
					}
				}
				GameObject gameObject2 = UnityEngine.Object.Instantiate(buttonPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject2.transform.SetParent(buttonParent, worldPositionStays: false);
				gameObject2.gameObject.name = socials[i].socialID;
				ButtonManager btn = gameObject2.GetComponent<ButtonManager>();
				buttons.Add(btn);
				btn.SetIcon(socials[i].icon);
				btn.onClick.AddListener(delegate
				{
					socials[tempIndex].onClick.Invoke();
					if (!string.IsNullOrEmpty(socials[tempIndex].link))
					{
						Application.OpenURL(socials[tempIndex].link);
					}
				});
				btn.onHover.AddListener(delegate
				{
					foreach (ButtonManager button in buttons)
					{
						if (!(button == btn))
						{
							button.Interactable(value: false);
							button.UpdateState();
							StopCoroutine("SetSocialByHover");
							StartCoroutine("SetSocialByHover", tempIndex);
						}
					}
				});
				btn.onLeave.AddListener(delegate
				{
					updateTimer = true;
					foreach (ButtonManager button2 in buttons)
					{
						if (button2 == btn)
						{
							button2.StartCoroutine("SetHighlight");
						}
						else
						{
							button2.Interactable(value: true);
							button2.UpdateState();
						}
					}
				});
				btn.onSelect.AddListener(delegate
				{
					foreach (ButtonManager button3 in buttons)
					{
						if (!(button3 == btn))
						{
							button3.overrideInteractable = true;
							button3.Interactable(value: false);
							button3.UpdateState();
							StopCoroutine("SetSocialByHover");
							StartCoroutine("SetSocialByHover", tempIndex);
						}
					}
				});
				btn.onDeselect.AddListener(delegate
				{
					updateTimer = true;
					foreach (ButtonManager button4 in buttons)
					{
						if (button4 == btn)
						{
							button4.StartCoroutine("SetHighlight");
						}
						else
						{
							button4.overrideInteractable = false;
							button4.Interactable(value: true);
							button4.UpdateState();
						}
					}
				});
			}
			StartCoroutine(InitCurrentItem());
			isInitialized = true;
			if (raycastImg == null)
			{
				raycastImg = base.gameObject.AddComponent<Image>();
				raycastImg.color = new Color(0f, 0f, 0f, 0f);
			}
		}

		public void SetSocialByTimer()
		{
			if (socials.Count > 1 && currentItemObject != null)
			{
				currentItemObject.enabled = true;
				currentItemObject.Play("Out");
				buttons[currentSliderIndex].UpdateState();
				if (currentSliderIndex == socials.Count - 1)
				{
					currentSliderIndex = 0;
				}
				else
				{
					currentSliderIndex++;
				}
				currentItemObject = itemParent.GetChild(currentSliderIndex).GetComponent<Animator>();
				currentItemObject.gameObject.SetActive(value: true);
				currentItemObject.enabled = true;
				currentItemObject.Play("In");
				buttons[currentSliderIndex].StartCoroutine("SetHighlight");
				StopCoroutine("DisableItemAnimators");
				StartCoroutine("DisableItemAnimators");
				if (background != null)
				{
					StopCoroutine("DoBackgroundColorLerp");
					StartCoroutine("DoBackgroundColorLerp");
				}
			}
		}

		public void AllowTransition(bool canSwitch)
		{
			allowTransition = canSwitch;
		}

		private IEnumerator InitCurrentItem()
		{
			if (updateMode == UpdateMode.UnscaledTime)
			{
				yield return new WaitForSecondsRealtime(0.02f);
			}
			else
			{
				yield return new WaitForSeconds(0.02f);
			}
			currentItemObject = itemParent.GetChild(currentSliderIndex).GetComponent<Animator>();
			currentItemObject.gameObject.SetActive(value: true);
			currentItemObject.enabled = true;
			currentItemObject.Play("In");
			buttons[currentSliderIndex].StartCoroutine("SetHighlight");
			StopCoroutine("DisableItemAnimators");
			StartCoroutine("DisableItemAnimators");
			if (background != null)
			{
				StopCoroutine("DoBackgroundColorLerp");
				StartCoroutine("DoBackgroundColorLerp");
			}
			timerCount = 0f;
			updateTimer = true;
		}

		private IEnumerator SetSocialByHover(int index)
		{
			updateTimer = false;
			timerCount = 0f;
			if (currentSliderIndex == index)
			{
				yield break;
			}
			if (isTransitionInProgress)
			{
				if (updateMode == UpdateMode.UnscaledTime)
				{
					yield return new WaitForSecondsRealtime(0.15f);
				}
				else
				{
					yield return new WaitForSeconds(0.15f);
				}
				isTransitionInProgress = false;
			}
			isTransitionInProgress = true;
			currentItemObject.enabled = true;
			currentItemObject.Play("Out");
			currentSliderIndex = index;
			currentItemObject = itemParent.GetChild(currentSliderIndex).GetComponent<Animator>();
			currentItemObject.gameObject.SetActive(value: true);
			currentItemObject.enabled = true;
			currentItemObject.Play("In");
			StopCoroutine("DisableItemAnimators");
			StartCoroutine("DisableItemAnimators");
			if (background != null)
			{
				StopCoroutine("DoBackgroundColorLerp");
				StartCoroutine("DoBackgroundColorLerp");
			}
		}

		private IEnumerator DoBackgroundColorLerp()
		{
			float elapsedTime = 0f;
			while (background.color != socials[currentSliderIndex].backgroundTint)
			{
				elapsedTime = ((updateMode != UpdateMode.UnscaledTime) ? (elapsedTime + Time.deltaTime) : (elapsedTime + Time.unscaledDeltaTime));
				background.color = Color.Lerp(background.color, socials[currentSliderIndex].backgroundTint, tintCurve.Evaluate(elapsedTime * tintSpeed));
				yield return null;
			}
			background.color = socials[currentSliderIndex].backgroundTint;
		}

		private IEnumerator DisableItemAnimators()
		{
			if (updateMode == UpdateMode.UnscaledTime)
			{
				yield return new WaitForSecondsRealtime(0.6f);
			}
			else
			{
				yield return new WaitForSeconds(0.6f);
			}
			for (int i = 0; i < socials.Count; i++)
			{
				if (i != currentSliderIndex)
				{
					itemParent.GetChild(i).gameObject.SetActive(value: false);
				}
				itemParent.GetChild(i).GetComponent<Animator>().enabled = false;
			}
		}
	}
}
