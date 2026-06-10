using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
	public static SceneTransitionManager Instance;

	[Header("UI References")]
	public RectTransform topImage;

	public RectTransform bottomImage;

	public CanvasGroup canvasGroup;

	[Header("Animation Settings")]
	public float transitionDuration = 0.7f;

	public Ease easeIn = Ease.OutCubic;

	public Ease easeOut = Ease.InCubic;

	[Range(0f, 1f)]
	public float overshootAmount = 0.4f;

	[Tooltip("Wait this long after scene load before revealing screen to hide lag spikes.")]
	public float delayBeforeReveal = 0.3f;

	[Header("Loading Text Settings")]
	public SuperTextMesh messageText;

	public CanvasGroup messageCanvasGroup;

	private string loadingMessageStyle = "<w=sassy> <drawAnim=Grow>";

	private bool isFirstLoad = true;

	private float _lastHeight;

	public bool IsTransitioning { get; private set; }

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			if (topImage != null)
			{
				topImage.pivot = new Vector2(0.5f, 0f);
			}
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		float num = (_lastHeight = ((RectTransform)base.transform).rect.height);
		if (topImage != null)
		{
			float num2 = num * overshootAmount;
			topImage.sizeDelta = new Vector2(topImage.sizeDelta.x, topImage.sizeDelta.y + num2);
		}
		if (messageCanvasGroup != null)
		{
			messageCanvasGroup.alpha = 0f;
			messageCanvasGroup.interactable = false;
			messageCanvasGroup.blocksRaycasts = false;
		}
		if (isFirstLoad)
		{
			isFirstLoad = false;
			topImage.anchoredPosition = Vector2.zero;
			StartCoroutine(InitialAnimateOut());
		}
	}

	private IEnumerator InitialAnimateOut()
	{
		IsTransitioning = true;
		yield return null;
		yield return new WaitForSecondsRealtime(0.2f);
		float num = (_lastHeight = ((RectTransform)base.transform).rect.height);
		float num2 = num * overshootAmount;
		topImage.sizeDelta = new Vector2(topImage.sizeDelta.x, num + num2);
		AnimateOut();
	}

	private void Update()
	{
		float height = ((RectTransform)base.transform).rect.height;
		if (Mathf.Approximately(_lastHeight, height))
		{
			return;
		}
		_lastHeight = height;
		if (!(topImage == null))
		{
			if (!IsTransitioning)
			{
				topImage.DOKill();
				topImage.anchoredPosition = new Vector2(topImage.anchoredPosition.x, height);
			}
			else
			{
				float num = height * overshootAmount;
				topImage.sizeDelta = new Vector2(topImage.sizeDelta.x, height + num);
			}
		}
	}

	public void TransitionToScene(string sceneName)
	{
		if (!IsTransitioning)
		{
			Debug.Log("[SceneTransition] TransitionToScene('" + sceneName + "') called from:\n" + Environment.StackTrace);
			StartCoroutine(TransitionSequence(sceneName));
		}
	}

	private IEnumerator TransitionSequence(string sceneName)
	{
		IsTransitioning = true;
		canvasGroup.blocksRaycasts = true;
		float currentHeight = ((RectTransform)base.transform).rect.height;
		if (PauseMenuManager.Instance != null)
		{
			PauseMenuManager.Instance.ResumeGame();
		}
		SoundManager.PlaySoundOneShot("Transition_Scene");
		yield return topImage.DOAnchorPosY((0f - currentHeight) * overshootAmount, transitionDuration).SetEase(easeIn).SetUpdate(isIndependentUpdate: true)
			.WaitForCompletion();
		if (messageCanvasGroup != null)
		{
			if (messageText != null)
			{
				LocalizedString localizedString = new LocalizedString("Skills", "#ui.lodaing.text");
				string text = loadingMessageStyle + localizedString.GetLocalizedString();
				messageText.text = text;
				messageText.Read();
			}
			yield return messageCanvasGroup.DOFade(1f, 0.3f).SetUpdate(isIndependentUpdate: true).WaitForCompletion();
		}
		AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
		asyncLoad.allowSceneActivation = false;
		while (asyncLoad.progress < 0.9f)
		{
			yield return null;
		}
		asyncLoad.allowSceneActivation = true;
		yield return new WaitForSeconds(delayBeforeReveal);
		if (messageCanvasGroup != null)
		{
			yield return messageCanvasGroup.DOFade(0f, 0.2f).SetUpdate(isIndependentUpdate: true).WaitForCompletion();
		}
		SoundManager.PlaySoundOneShot("Transition_Scene");
		topImage.DOAnchorPosY(currentHeight, transitionDuration).SetEase(easeOut).SetUpdate(isIndependentUpdate: true)
			.OnComplete(delegate
			{
				canvasGroup.blocksRaycasts = false;
				IsTransitioning = false;
			});
	}

	private void AnimateOut()
	{
		float height = ((RectTransform)base.transform).rect.height;
		canvasGroup.blocksRaycasts = false;
		if (messageCanvasGroup != null)
		{
			messageCanvasGroup.alpha = 0f;
		}
		topImage.DOAnchorPosY(height, transitionDuration).SetEase(easeOut).SetUpdate(isIndependentUpdate: true)
			.OnComplete(delegate
			{
				IsTransitioning = false;
			});
	}
}
