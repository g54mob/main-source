using System;
using System.Globalization;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SessionQuestFulfilledFX : MonoBehaviour
{
	private Camera mainCamera;

	private UniversalAdditionalCameraData cameraData;

	private Tile previewTile;

	[SerializeField]
	private SessionQuest DEBUG_dummySessionQuest;

	[SerializeField]
	private Camera fxCamera;

	[SerializeField]
	private Transform tileAnchor;

	[SerializeField]
	private TextMeshPro tileUnlockedText;

	[SerializeField]
	private TextMeshPro tileNameText;

	[SerializeField]
	private Button claimButton;

	[SerializeField]
	private SaveGameLoadingInitiator saveGameLoader;

	[SerializeField]
	private GameMode classicMode;

	[FormerlySerializedAs("claimPlayButton")]
	[SerializeField]
	private Button startGameButton;

	[SerializeField]
	private Transform fxContainer;

	[SerializeField]
	private GameObject fxBackgroundTileUnlocked;

	[SerializeField]
	private GameObject fxBackgroundChallengeUnlocked;

	[SerializeField]
	private SessionQuestMenuCard menuCard;

	[SerializeField]
	private float tileSizeScalingFactor;

	[SerializeField]
	private float tileSizeScalingDuration = 1f;

	[SerializeField]
	private float tileRotationSpeed = 30f;

	[SerializeField]
	private float tileUnlockedTextDelay = 0.5f;

	[SerializeField]
	private float tileNameTextDelay = 0.7f;

	[SerializeField]
	private TileFactory tileFactory;

	private SessionQuestFxType fxType;

	private SessionQuest sessionQuest;

	private SessionQuestReward unlockReward;

	private Button confirmButton;

	public event Action OnHidden;

	public void Awake()
	{
		tileNameText.transform.localScale = Vector3.zero;
		tileUnlockedText.transform.localScale = Vector3.zero;
		claimButton.transform.localScale = Vector3.zero;
		startGameButton.transform.localScale = Vector3.zero;
	}

	public void SetupMenuCard(SessionQuest sessionQuest)
	{
		menuCard.gameObject.SetActive(value: true);
		if ((bool)sessionQuest.compositeParentQuest)
		{
			sessionQuest = sessionQuest.compositeParentQuest;
		}
		menuCard.Setup(null, sessionQuest, Singleton<RewardTileViewerManager>.Instance.GetTileViewer(sessionQuest));
		tileUnlockedText.text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue("unlocked_newChallenge"));
		tileNameText.text = sessionQuest.GetTitle(0, showLevel: false);
		TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(menuCard.transform, 1f, tileSizeScalingDuration), 0f), Ease.InOutElastic);
		fxBackgroundTileUnlocked.SetActive(value: false);
		fxBackgroundChallengeUnlocked.SetActive(value: true);
	}

	public void Setup(SessionQuest sessionQuest, int fulfilledLevel, SessionQuestFxType type)
	{
		this.sessionQuest = sessionQuest;
		fxType = type;
		mainCamera = Camera.main;
		cameraData = CameraExtensions.GetUniversalAdditionalCameraData(mainCamera);
		cameraData.cameraStack.Add(fxCamera);
		unlockReward = sessionQuest.GetLevel(fulfilledLevel).reward;
		switch (type)
		{
		case SessionQuestFxType.ChallengeFulfilled:
			SetupTile(unlockReward);
			break;
		case SessionQuestFxType.ChallengeUnlocked:
			SetupMenuCard(sessionQuest);
			break;
		}
		UpdateText();
		LocalizationManager.Instance.OnLanguageChanged += UpdateText;
		TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(tileUnlockedText.transform, Vector3.one, 1f), Vector3.zero), Ease.InOutElastic), tileUnlockedTextDelay);
		confirmButton = (OverwritingSingleton<GameSession>.Instance.GameMode.IsTutorial ? startGameButton : claimButton);
		TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(tileNameText.transform, Vector3.one, 1f), Vector3.zero), Ease.InOutElastic), tileNameTextDelay);
		TweenSettingsExtensions.SetDelay(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(confirmButton.transform, 1f, 0.3f), Vector3.zero), 1.5f);
		confirmButton.Select();
	}

	private void UpdateText()
	{
		tileUnlockedText.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.H1);
		string key = ((fxType == SessionQuestFxType.ChallengeFulfilled) ? unlockReward.GetUnlockTypeKey() : "unlocked_newChallenge");
		tileUnlockedText.text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue(key));
		tileNameText.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.H1);
		tileNameText.text = ((fxType == SessionQuestFxType.ChallengeFulfilled) ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(LocalizationManager.Instance.GetLocalizedValue(unlockReward.unlockObjectKey)) : "");
	}

	private void SetupTile(SessionQuestReward unlockedReward)
	{
		previewTile = UnityEngine.Object.Instantiate(unlockedReward.displayTile, tileAnchor.position, Quaternion.identity, tileAnchor);
		previewTile.transform.localRotation = Quaternion.AngleAxis(unlockedReward.displayRotation, Vector3.up);
		previewTile.InitializeSeed(unlockedReward.seed);
		tileFactory.InitializePrebuiltTile(previewTile);
		BiomeManager.ApplyBiomeToTile(previewTile, unlockedReward.displayBiome, unlockedReward);
		previewTile.ChangeTileState(TileState.stackPreview);
		previewTile.SetLayer(13);
		fxBackgroundTileUnlocked.SetActive(value: true);
		fxBackgroundChallengeUnlocked.SetActive(value: false);
		previewTile.transform.localScale = Vector3.zero;
		TweenSettingsExtensions.SetEase(TweenSettingsExtensions.From(ShortcutExtensions.DOScale(previewTile.transform, Vector3.one * tileSizeScalingFactor, tileSizeScalingDuration), Vector3.zero), Ease.InOutElastic);
	}

	private void Update()
	{
		if ((bool)previewTile)
		{
			previewTile.transform.Rotate(Vector3.up * tileRotationSpeed * Time.deltaTime, Space.Self);
		}
	}

	public void Hide()
	{
		if ((bool)previewTile)
		{
			TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScale(previewTile.transform, 0f, 0.5f), Ease.OutCubic);
		}
		if (menuCard.gameObject.activeInHierarchy)
		{
			TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScale(menuCard.transform, 0f, 0.5f), Ease.OutCubic);
		}
		TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScale(tileUnlockedText.transform, 0f, 0.5f), Ease.OutCubic);
		TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScale(tileNameText.transform, 0f, 0.5f), Ease.OutCubic);
		TweenSettingsExtensions.OnComplete(TweenSettingsExtensions.SetEase(ShortcutExtensions.DOScale(fxContainer, 0f, 0.5f), Ease.OutCubic), HiddenCallback);
		confirmButton.interactable = false;
		confirmButton.gameObject.SetActive(value: false);
	}

	public void HideAndStartStartClassicMode()
	{
		Hide();
		TweenSettingsExtensions.OnComplete(TweenSettingsExtensions.AppendInterval(DOTween.Sequence(), 0.75f), StartClassicMode);
	}

	private void StartClassicMode()
	{
		saveGameLoader.SetSelectedGameMode(classicMode);
		saveGameLoader.LoadAutosaveInSelectedGameMode();
	}

	private void HiddenCallback()
	{
		this.OnHidden?.Invoke();
		UnityEngine.Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		if ((bool)cameraData)
		{
			cameraData.cameraStack.Remove(fxCamera);
		}
		if ((bool)LocalizationManager.Instance)
		{
			LocalizationManager.Instance.OnLanguageChanged -= UpdateText;
		}
	}

	public void SelectDefault()
	{
		confirmButton.Select();
	}
}
