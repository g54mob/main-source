using System;
using System.Collections.Generic;
using Dorfromantik;
using Dorfromantik.UI;
using Dorfromantik.UI.Components;
using Dorfromantik.UI.Ingame;
using LeTai.Asset.TranslucentImage;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class IngameUi : OverwritingSingleton<IngameUi>
{
	[SerializeField]
	private List<GameObject> uiObjects;

	public Camera mainCamera;

	public Camera uiCamera;

	public TranslucentImageSource translucentImageSource;

	public UiIconButton menuButton;

	public BiomeManager biomeManager;

	public World world;

	public TilePlacer tilePlacer;

	public TileSlotPreviewer tileSlotPreviewer;

	[SerializeField]
	private UiGameOverScreen uiGameOverScreen;

	public GameObject cameraContainer;

	public SaveLoadSystem saveLoadSystem;

	[SerializeField]
	private List<HorizontalOrVerticalLayoutGroup> layoutGroupsToUpdateOnShowUi;

	[SerializeField]
	private InputRouter inputRouter;

	[SerializeField]
	private RewardSystem rewardSystem;

	[SerializeField]
	private SceneLoader sceneLoader;

	[SerializeField]
	public SettingsRouter settingsRouter;

	[SerializeField]
	private LoadingProgressRouter loadingProgressRouter;

	private bool uiShown = true;

	private bool shouldUpdateCameraVolumeStack;

	public static event Action<IngameUi> OnSceneChanged;

	protected override void Awake()
	{
		base.Awake();
		IngameUi.OnSceneChanged?.Invoke(this);
		rewardSystem.OnGameOver += ShowGameOverScreen;
		rewardSystem.OnUndoGameOver += HideGameOverScreen;
		if (loadingProgressRouter.IsLoading)
		{
			ShowUi(shouldShow: false);
		}
		loadingProgressRouter.OnCompleted += ShowUiIfNotInMenu;
	}

	private void ShowUiIfNotInMenu()
	{
		if (Singleton<MainMenuUi>.Instance.ActiveScreen == MainMenuScreenType.None)
		{
			ShowUi(shouldShow: true);
		}
	}

	public void ShowUi(bool shouldShow)
	{
		foreach (GameObject uiObject in uiObjects)
		{
			HideableUi component = uiObject.GetComponent<HideableUi>();
			if ((bool)component)
			{
				component.Show(shouldShow);
			}
			else
			{
				uiObject.SetActive(shouldShow);
			}
		}
		if (layoutGroupsToUpdateOnShowUi.Count > 0)
		{
			UiUtility.RebuildHorizontalOrVerticalLayoutGroups(layoutGroupsToUpdateOnShowUi);
		}
		uiShown = shouldShow;
	}

	public void ShowGameOverScreen(bool animate, bool setHighscore)
	{
		uiGameOverScreen.Show(shouldShow: true, animate);
	}

	private void HideGameOverScreen()
	{
		uiGameOverScreen.Show(shouldShow: false);
	}

	protected override void OnDestroy()
	{
		rewardSystem.OnGameOver -= ShowGameOverScreen;
		rewardSystem.OnUndoGameOver -= HideGameOverScreen;
		loadingProgressRouter.OnCompleted -= ShowUiIfNotInMenu;
	}

	public void UpdateCameraVolumeStack()
	{
		shouldUpdateCameraVolumeStack = true;
	}

	private void LateUpdate()
	{
		if (shouldUpdateCameraVolumeStack)
		{
			CameraExtensions.UpdateVolumeStack(mainCamera);
			shouldUpdateCameraVolumeStack = false;
		}
	}

	public void SelectGameOverScreenDefault()
	{
		uiGameOverScreen.SelectDefault();
	}
}
