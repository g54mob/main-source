using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuState : State<GameManager>
{
	private MainMenuView mainMenuView;

	private OrbitCamera orbitCamera;

	private CreationController mainMenuCreationController;

	private Coroutine spwanCreationsCoroutine;

	private WaitForSeconds wait12Seconds = new WaitForSeconds(12f);

	private WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();

	private MainMenuManager.MainMenuType mainMenuType;

	public static MenuState Instance { get; }

	public event Action OnSpawnCreationStartingEvent;

	public event Action OnSpawnCreationEndingEvent;

	static MenuState()
	{
		Instance = new MenuState();
	}

	private MenuState()
	{
	}

	public override void Start(GameManager GAME)
	{
		mainMenuView = GAME.GUIManager.MainMenuView;
		orbitCamera = GAME.CameraManager.OrbitCamera;
		mainMenuView.SetGameVersion(GAME.GameStylesData.gameVersion);
		SceneManager.sceneLoaded += OnLevelLoadedHandler;
	}

	public override void Enter(GameManager GAME)
	{
		mainMenuView.SetVisibility(isVisible: true);
		GAME.CameraManager.SetLockMainCamera(isLocked: true);
		SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
		GAME.MusicManager.PlayMusic(GAME.GameStylesData.musicStylesData.mainMenuClip, GAME.GameStylesData.volumeStylesData.musicVolume);
		if (SteamManager.Initialized)
		{
			bool isWorkshopTrendsPanelVisible = GAME.OptionsModel.IsWorkshopTrendsPanelVisible;
			mainMenuView.SetWorkshopTrendsVisibility(isWorkshopTrendsPanelVisible, !isWorkshopTrendsPanelVisible);
			mainMenuView.SetBestPlayersButtonVisibility(isVisible: true);
		}
		else
		{
			mainMenuView.SetWorkshopTrendsVisibility(isPanelVisible: false, isButtonVisible: false);
			mainMenuView.SetBestPlayersButtonVisibility(isVisible: false);
		}
	}

	public override void Execute(GameManager GAME)
	{
		if (!Input.GetKey(KeyCode.LeftShift) || !Input.GetKey(KeyCode.LeftControl) || !Input.GetKeyDown(KeyCode.C) || GAME.CheatModel.IsAllLevelsEnabled)
		{
			return;
		}
		foreach (LevelModel allItem in GAME.CampaignLevelModelCollection.GetAllItems())
		{
			if (allItem.BestTime == float.PositiveInfinity)
			{
				allItem.BestTime = 300f;
			}
		}
		GAME.GroupCampaignModel.UpdateGroupAndLevelStatus();
		GAME.CheatModel.IsAllLevelsEnabled = true;
		GAME.UIAudioEffectsManager.PlayAudio(GAME.GameStylesData.toolKeyPressedClip, GAME.GameStylesData.volumeStylesData.uiVolume);
	}

	public override void Exit(GameManager GAME)
	{
		if (spwanCreationsCoroutine != null)
		{
			GAME.StopCoroutine(spwanCreationsCoroutine);
		}
		if (SteamManager.Initialized)
		{
			mainMenuView.SetWorkshopTrendsVisibility(isPanelVisible: false, isButtonVisible: false);
		}
		mainMenuView.SetVisibility(isVisible: false);
		GAME.MusicManager.StopMusic();
		mainMenuCreationController?.StopRebuildCreationAsync();
		mainMenuCreationController?.SetModel(new CreationModel("", "", ""));
		SceneManager.UnloadSceneAsync("MainMenu");
	}

	private void OnLevelLoadedHandler(Scene scene, LoadSceneMode mode)
	{
		if (!(scene.name != "MainMenu"))
		{
			bool shouldReturnFirstTypeOnly = GameManager.Instance.UserProfileModel.CampaignLevelStatusList.Count == 0;
			mainMenuType = MainMenuManager.Instance.GetRandomMainMenuType(shouldReturnFirstTypeOnly);
			GameObject cameraFocusPoint = mainMenuType.cameraFocusPoint;
			orbitCamera.SetTarget(cameraFocusPoint.transform);
			orbitCamera.SetAngles(25f, 45f, isMoveImmediately: true);
			orbitCamera.SetZoomDistance(-12f);
			GameObject creationBuildingPoint = mainMenuType.creationBuildingPoint;
			if (GameManager.Instance.SavedCreationsModel.CreationModelCount() + GameManager.Instance.CreationCollectionsManager.MenuCreationModelCollection.CreationModelCount() > 0)
			{
				mainMenuCreationController = CreationControllerBuilder.BuildRigidController(new CreationModel("", "", ""), isGroupCentered: true, creationBuildingPoint.transform);
				mainMenuCreationController.IsAsyncBuild = true;
				mainMenuCreationController.OnSyncViewWithModelCompleted += OnSyncViewWithModelCompletedHandler;
				mainMenuCreationController.view.SetEditableAndPlayable(isEditable: false, isPlayable: false);
				spwanCreationsCoroutine = GameManager.Instance.StartCoroutine(SpawnCreations());
			}
			GUIManager.Instance.FadeOutFromBlack();
		}
	}

	private void OnSyncViewWithModelCompletedHandler()
	{
		int num = UnityEngine.Random.Range(0, 360);
		int num2 = UnityEngine.Random.Range(0, 360);
		int num3 = UnityEngine.Random.Range(0, 360);
		GameObject creationSpawnPoint = mainMenuType.creationSpawnPoint;
		mainMenuCreationController.view.transform.SetParent(creationSpawnPoint.transform, worldPositionStays: false);
		mainMenuCreationController.view.transform.eulerAngles = (mainMenuType.isRandomOrientation ? new Vector3(num, num2, num3) : creationSpawnPoint.transform.eulerAngles);
		float y = CreationUtil.CreationBounds(mainMenuCreationController.view).extents.y;
		mainMenuCreationController.view.transform.Translate(new Vector3(0f, y, 0f));
		mainMenuCreationController.view.ActiveCreation();
		this.OnSpawnCreationStartingEvent?.Invoke();
	}

	private IEnumerator SpawnCreations()
	{
		List<CreationModel> allCreationsModel = new List<CreationModel>();
		allCreationsModel.AddRange(GameManager.Instance.CreationCollectionsManager.MenuCreationModelCollection.GetAllCreationModels());
		allCreationsModel.AddRange(GameManager.Instance.SavedCreationsModel.GetAllCreationModels());
		while (true)
		{
			CreationModel model = allCreationsModel[UnityEngine.Random.Range(0, allCreationsModel.Count)];
			mainMenuCreationController.view.transform.SetParent(mainMenuType.creationBuildingPoint.transform, worldPositionStays: false);
			mainMenuCreationController.SetModel(model);
			yield return wait12Seconds;
			mainMenuCreationController.view.MakeCreationTransparent();
			mainMenuCreationController.view.SetCreationTransparency(1f);
			float transparency = 1f;
			while (transparency > 0f)
			{
				transparency -= Time.deltaTime * 3f;
				mainMenuCreationController.view.SetCreationTransparency(transparency);
				yield return waitForEndOfFrame;
			}
			this.OnSpawnCreationEndingEvent?.Invoke();
		}
	}
}
