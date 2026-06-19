using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	public class GameHubManager : MonoBehaviour
	{
		public enum WindowMode
		{
			Dynamic = 0,
			FullscreenOnly = 1
		}

		[Serializable]
		public class GameItem
		{
			public string gameTitle = "Game Title";

			[TextArea(2, 6)]
			public string gameDescription = "Description";

			public Sprite gameIcon;

			public Sprite gameBanner;

			public GameObject gamePrefab;

			public WindowMode windowMode;

			public bool addToSlider = true;

			[Header("Localization")]
			public string descriptionKey;
		}

		public List<GameItem> games = new List<GameItem>();

		[SerializeField]
		private GameObject gameContent;

		[SerializeField]
		private Transform gameParent;

		[SerializeField]
		private ImageFading gameTransition;

		[SerializeField]
		private GameObject sliderIndicator;

		[SerializeField]
		private Transform sliderIndicatorParent;

		[SerializeField]
		private GameObject libraryPreset;

		[SerializeField]
		private Transform libraryParent;

		[SerializeField]
		private Image transitionHelper;

		[SerializeField]
		private Image sliderBanner;

		[SerializeField]
		private Image sliderIcon;

		[SerializeField]
		private TextMeshProUGUI sliderDescription;

		[SerializeField]
		private ButtonManager sliderPlayButton;

		[SerializeField]
		private Canvas targetCanvas;

		[SerializeField]
		private bool useLocalization = true;

		[Range(2f, 30f)]
		public float sliderTimer = 4f;

		[Range(0.05f, 1f)]
		public float sliderScaleSpeed = 0.1f;

		[Range(1f, 10f)]
		public float transitionSpeed = 4f;

		private int currentSliderIndex;

		private float sliderTimerBar;

		private bool isInTransition;

		private GameObject currentGame;

		private GameHubSliderIndicatorItem currentIndicator;

		private List<GameHubSliderIndicatorItem> sliderIndicators = new List<GameHubSliderIndicatorItem>();

		private void Awake()
		{
			Initialize();
			transitionHelper.color = new Color(transitionHelper.color.r, transitionHelper.color.g, transitionHelper.color.b, 0f);
		}

		private void OnEnable()
		{
			ResetSlider();
			UpdateSliderInfo();
		}

		private void Update()
		{
			if (sliderTimerBar <= sliderTimer && !isInTransition && currentIndicator.gameObject.activeInHierarchy)
			{
				sliderTimerBar += Time.deltaTime;
				currentIndicator.bar.fillAmount = sliderTimerBar / sliderTimer;
				if (currentIndicator.bar.fillAmount >= 1f)
				{
					NextSliderItem();
				}
			}
			sliderBanner.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * sliderScaleSpeed * Time.deltaTime;
		}

		private void Initialize()
		{
			foreach (Transform item in sliderIndicatorParent)
			{
				UnityEngine.Object.Destroy(item.gameObject);
			}
			foreach (Transform item2 in libraryParent)
			{
				UnityEngine.Object.Destroy(item2.gameObject);
			}
			for (int i = 0; i < games.Count; i++)
			{
				int gameIndex = i;
				GameObject gameObject = UnityEngine.Object.Instantiate(libraryPreset, new Vector3(0f, 0f, 0f), Quaternion.identity);
				gameObject.transform.SetParent(libraryParent, worldPositionStays: false);
				gameObject.gameObject.name = games[i].gameTitle;
				GameHubLibraryItem itemComp = gameObject.GetComponent<GameHubLibraryItem>();
				itemComp.gameIndex = gameIndex;
				itemComp.SetIcon(games[i].gameIcon);
				itemComp.SetBanner(games[i].gameBanner);
				itemComp.playButton.onClick.AddListener(delegate
				{
					LaunchGame(itemComp.gameIndex);
				});
				if (games[i].addToSlider)
				{
					GameObject inGo = UnityEngine.Object.Instantiate(sliderIndicator, new Vector3(0f, 0f, 0f), Quaternion.identity);
					inGo.transform.SetParent(sliderIndicatorParent, worldPositionStays: false);
					inGo.gameObject.name = games[i].gameTitle;
					GameHubSliderIndicatorItem component = inGo.GetComponent<GameHubSliderIndicatorItem>();
					component.gameIndex = gameIndex;
					component.animator.enabled = false;
					component.button.onClick.AddListener(delegate
					{
						SetSliderItem(inGo.transform.GetSiblingIndex());
					});
					sliderIndicators.Add(component);
				}
			}
		}

		public void LaunchGame(int index)
		{
			if (currentGame != null)
			{
				return;
			}
			if (gameTransition == null)
			{
				LaunchGameHelper(index);
				return;
			}
			gameTransition.onFadeInEnd.RemoveAllListeners();
			gameTransition.onFadeInEnd.AddListener(delegate
			{
				LaunchGameHelper(index);
				gameTransition.gameObject.SetActive(value: false);
			});
			gameTransition.FadeIn();
		}

		private void LaunchGameHelper(int index)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate(games[index].gamePrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
			gameObject.transform.SetParent(gameParent, worldPositionStays: false);
			currentGame = gameObject;
			GameHubGameContent component = gameObject.GetComponent<GameHubGameContent>();
			component.manager = this;
			component.gameIndex = index;
			gameContent.SetActive(value: true);
			if (games[index].windowMode == WindowMode.FullscreenOnly)
			{
				if (targetCanvas == null)
				{
					targetCanvas = GetComponentInParent<Canvas>();
				}
				gameObject.transform.SetParent(targetCanvas.transform, worldPositionStays: false);
				RectTransform component2 = gameObject.GetComponent<RectTransform>();
				component2.offsetMin = new Vector2(0f, 0f);
				component2.offsetMax = new Vector2(0f, 0f);
			}
		}

		public void ExitGame()
		{
			gameContent.SetActive(value: false);
			UnityEngine.Object.Destroy(currentGame);
			currentGame = null;
			if (gameTransition != null)
			{
				gameTransition.onFadeOutEnd.RemoveAllListeners();
				gameTransition.onFadeOutEnd.AddListener(delegate
				{
					gameTransition.gameObject.SetActive(value: false);
				});
				gameTransition.FadeOut();
			}
		}

		public void NextSliderItem()
		{
			if (currentSliderIndex == sliderIndicators.Count - 1)
			{
				currentSliderIndex = 0;
			}
			else
			{
				currentSliderIndex++;
			}
			SetSliderItem(currentSliderIndex);
		}

		public void SetSliderItem(int index)
		{
			currentSliderIndex = index;
			if (currentIndicator != null && currentIndicator.gameObject.activeInHierarchy)
			{
				currentIndicator.animator.enabled = true;
				currentIndicator.animator.Play("Out");
			}
			sliderTimerBar = 0f;
			currentIndicator.bar.fillAmount = 0f;
			currentIndicator = sliderIndicators[currentSliderIndex];
			currentIndicator.animator.enabled = true;
			currentIndicator.animator.Play("In");
			StopCoroutine("DisableIndicatorAnimators");
			StopCoroutine("SliderTransitionIn");
			StopCoroutine("SliderTransitionOut");
			StartCoroutine("DisableIndicatorAnimators");
			StartCoroutine("SliderTransitionIn");
		}

		public void UpdateSliderInfo()
		{
			sliderBanner.sprite = games[currentIndicator.gameIndex].gameBanner;
			sliderIcon.sprite = games[currentIndicator.gameIndex].gameIcon;
			LocalizedObject component = sliderDescription.gameObject.GetComponent<LocalizedObject>();
			if (!useLocalization || string.IsNullOrEmpty(games[currentIndicator.gameIndex].descriptionKey) || component == null || !component.CheckLocalizationStatus())
			{
				sliderDescription.text = games[currentIndicator.gameIndex].gameDescription;
			}
			else if (component != null)
			{
				sliderDescription.text = component.GetKeyOutput(games[currentIndicator.gameIndex].descriptionKey);
			}
			sliderPlayButton.onClick.RemoveAllListeners();
			sliderPlayButton.onClick.AddListener(delegate
			{
				LaunchGame(currentIndicator.gameIndex);
			});
			LayoutRebuilder.ForceRebuildLayoutImmediate(sliderDescription.GetComponent<RectTransform>());
			LayoutRebuilder.MarkLayoutForRebuild(sliderDescription.GetComponent<RectTransform>());
		}

		public void ResetSlider()
		{
			sliderTimerBar = 0f;
			if (currentIndicator != null)
			{
				currentIndicator.bar.fillAmount = 0f;
			}
			currentIndicator = sliderIndicators[currentSliderIndex];
			if (currentIndicator.gameObject.activeInHierarchy)
			{
				currentIndicator.animator.enabled = true;
				currentIndicator.animator.Play("In");
			}
			StopCoroutine("DisableIndicatorAnimators");
			StartCoroutine("DisableIndicatorAnimators");
		}

		private IEnumerator SliderTransitionIn()
		{
			isInTransition = true;
			while (transitionHelper.color.a < 1f)
			{
				float a = transitionHelper.color.a;
				a += Time.deltaTime * transitionSpeed;
				transitionHelper.color = new Color(transitionHelper.color.r, transitionHelper.color.g, transitionHelper.color.b, a);
				yield return null;
			}
			isInTransition = false;
			transitionHelper.color = new Color(transitionHelper.color.r, transitionHelper.color.g, transitionHelper.color.b, 1f);
			sliderBanner.transform.localScale = new Vector3(1f, 1f, 1f);
			UpdateSliderInfo();
			StartCoroutine("SliderTransitionOut");
		}

		private IEnumerator SliderTransitionOut()
		{
			while (transitionHelper.color.a > 0f)
			{
				float a = transitionHelper.color.a;
				a -= Time.deltaTime * transitionSpeed;
				transitionHelper.color = new Color(transitionHelper.color.r, transitionHelper.color.g, transitionHelper.color.b, a);
				yield return null;
			}
			transitionHelper.color = new Color(transitionHelper.color.r, transitionHelper.color.g, transitionHelper.color.b, 0f);
		}

		private IEnumerator DisableIndicatorAnimators()
		{
			yield return new WaitForSeconds(0.55f);
			for (int i = 0; i < sliderIndicators.Count; i++)
			{
				sliderIndicators[i].animator.enabled = false;
			}
		}
	}
}
