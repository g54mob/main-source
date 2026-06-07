using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
	public enum State
	{
		Normal = 0,
		SelectWorker = 1,
		TeachWorker = 2,
		Edit = 3,
		Planning = 4,
		BuildingSelect = 5,
		Inventory = 6,
		DragInventorySlot = 7,
		CheatTools = 8,
		CreativeTools = 9,
		Paused = 10,
		PlatformPaused = 11,
		Save = 12,
		Load = 13,
		Confirm = 14,
		Settings = 15,
		About = 16,
		SelectObject = 17,
		FreeCam = 18,
		PlayCameraSequence = 19,
		BackupRestore = 20,
		RenameSign = 21,
		Loading = 22,
		CreateWorld = 23,
		Ceremony = 24,
		NewGame = 25,
		Terraform = 26,
		EditArea = 27,
		Error = 28,
		OK = 29,
		Badges = 30,
		Industry = 31,
		Evolution = 32,
		Academy = 33,
		Research = 34,
		Autopedia = 35,
		Drag = 36,
		Stats = 37,
		AnyKey = 38,
		Arcade = 39,
		MissionEditor = 40,
		MissionList = 41,
		ObjectSelect = 42,
		SetTargetTile = 43,
		SetSpacePort = 44,
		Start = 45,
		MainMenuCreate = 46,
		MainMenu = 47,
		LanguageSelect = 48,
		ModsPanel = 49,
		ModsUploadConfirm = 50,
		ModsError = 51,
		ModsOptions = 52,
		ModsAnyKey = 53,
		ModsPopup = 54,
		ModsPopupConfirm = 55,
		PlaybackLoading = 56,
		Playback = 57,
		SceneChange = 58,
		Total = 59
	}

	public static GameStateManager Instance;

	private string[] m_PrefabNames = new string[59]
	{
		"GameStateNormal", "GameStateSelectWorker", "GameStateTeachWorker2", "GameStateEdit", "GameStatePlanning", "GameStateBuildingSelect", "GameStateInventory", "GameStateDragInventorySlot", "GameStateCheatTools", "GameStateCreativeTools",
		"GameStatePaused", "GameStatePlatformPaused", "GameStateSave", "GameStateLoad", "GameStateConfirm", "GameStateSettings", "GameStateAbout", "GameStateSelectObject", "GameStateFreeCam", "GameStatePlayCameraSequence",
		"GameStateBackupRestore", "GameStateRenameSign", "GameStateLoading", "GameStateCreateWorld", "GameStateCeremony", "GameStateNewGame", "GameStateTerraform", "GameStateEditArea", "GameStateError", "GameStateOK",
		"GameStateBadges", "GameStateIndustry", "GameStateEvolution", "GameStateAcademy", "GameStateResearch", "GameStateAutopedia", "GameStateDrag", "GameStateStats", "GameStateAnyKey", "GameStateArcade",
		"GameStateMissionEditor", "GameStateMissionList", "GameStateObjectSelect", "GameStateSetTargetTile", "GameStateSetSpacePort", "GameStateStart", "GameStateMainMenuCreate", "GameStateMainMenu", "GameStateLanguageSelect", "GameStateModsPanel",
		"GameStateModsUploadConfirm", "GameStateModsError", "GameStateModsOptions", "GameStateModsAnyKey", "GameStateModsPopup", "GameStateModsPopupConfirm", "GameStatePlaybackLoading", "GameStatePlayback", "GameStateSceneChange"
	};

	private List<GameStateBase> m_StateStack;

	private bool m_FirstTimeInit;

	private State m_CurrentState;

	public State m_OldState;

	private void Awake()
	{
		Instance = this;
		m_StateStack = new List<GameStateBase>();
		m_FirstTimeInit = true;
	}

	protected void OnDestroy()
	{
		DestroyStack(true);
	}

	private void DestroyStopState(bool Immediate)
	{
		Immediate = true;
		m_StateStack[m_StateStack.Count - 1].ShutDown();
		if (Immediate)
		{
			Object.DestroyImmediate(m_StateStack[m_StateStack.Count - 1].gameObject);
		}
		else
		{
			Object.Destroy(m_StateStack[m_StateStack.Count - 1].gameObject);
		}
		m_StateStack.RemoveAt(m_StateStack.Count - 1);
	}

	private void DestroyStack(bool Immediate = false)
	{
		while (m_StateStack.Count != 0)
		{
			DestroyStopState(Immediate);
		}
	}

	public void PushState(State NewState)
	{
		if (m_StateStack.Count > 0)
		{
			if (m_StateStack[m_StateStack.Count - 1].m_BaseState == NewState)
			{
				return;
			}
			m_StateStack[m_StateStack.Count - 1].Pushed(NewState);
		}
		if (NewState != State.Total)
		{
			GameStateBase component = Object.Instantiate((GameObject)Resources.Load("Prefabs/GameStates/" + m_PrefabNames[(int)NewState], typeof(GameObject)), new Vector3(0f, 0f, 0f), Quaternion.identity, null).GetComponent<GameStateBase>();
			component.m_BaseState = NewState;
			m_StateStack.Add(component);
		}
	}

	public void PopState(bool Immediate = false)
	{
		m_OldState = m_StateStack[m_StateStack.Count - 1].m_BaseState;
		DestroyStopState(Immediate);
		if (m_StateStack.Count > 0)
		{
			m_StateStack[m_StateStack.Count - 1].Popped(m_OldState);
		}
		else
		{
			SetState(State.Normal);
		}
	}

	public void SetState(State NewState)
	{
		DestroyStack();
		PushState(NewState);
	}

	public void StartWardrobe(Wardrobe NewWardrobe)
	{
		PushState(State.Inventory);
		List<BaseClass> players = CollectionManager.Instance.GetPlayers();
		Instance.GetCurrentState().GetComponent<GameStateInventory>().SetInfo(players[0].GetComponent<FarmerPlayer>(), NewWardrobe);
	}

	public void StartAquarium(Aquarium NewAquarium)
	{
		PushState(State.Inventory);
		List<BaseClass> players = CollectionManager.Instance.GetPlayers();
		Instance.GetCurrentState().GetComponent<GameStateInventory>().SetInfo(players[0].GetComponent<FarmerPlayer>(), NewAquarium);
	}

	public void StartCatapult(Catapult NewCatapult)
	{
		PushState(State.SetTargetTile);
		List<BaseClass> players = CollectionManager.Instance.GetPlayers();
		Instance.GetCurrentState().GetComponent<GameStateSetTargetTile>().SetInfo(players[0].GetComponent<FarmerPlayer>(), NewCatapult);
	}

	public void StartSelectBuilding(Building NewBuilding)
	{
		if (NewBuilding.m_TypeIdentifier != ObjectType.BotServer)
		{
			GameStateNormal component = GetCurrentState().GetComponent<GameStateNormal>();
			if ((bool)component)
			{
				component.ClearSelectedWorkers();
			}
		}
		PushState(State.BuildingSelect);
		m_StateStack[m_StateStack.Count - 1].GetComponent<GameStateBuildingSelect>().SetBuilding(NewBuilding);
	}

	public void StartRenameSign(Sign NewSign)
	{
		PushState(State.RenameSign);
		m_StateStack[m_StateStack.Count - 1].GetComponent<GameStateRenameSign>().SetSign(NewSign);
	}

	public void StartSpacePort(SpacePort NewSpacePort)
	{
		PushState(State.SetSpacePort);
		List<BaseClass> players = CollectionManager.Instance.GetPlayers();
		Instance.GetCurrentState().GetComponent<GameStateSetSpacePort>().SetInfo(players[0].GetComponent<FarmerPlayer>(), NewSpacePort);
	}

	public GameStateBase GetCurrentState()
	{
		if (m_StateStack.Count == 0)
		{
			return null;
		}
		return m_StateStack[m_StateStack.Count - 1];
	}

	public GameStateBase GetState(State NewState)
	{
		foreach (GameStateBase item in m_StateStack)
		{
			if (item.m_BaseState == NewState)
			{
				return item;
			}
		}
		return null;
	}

	public State GetActualState()
	{
		if (m_StateStack.Count == 0)
		{
			return State.Total;
		}
		return m_StateStack[m_StateStack.Count - 1].m_BaseState;
	}

	private void Update()
	{
		if (m_FirstTimeInit)
		{
			m_FirstTimeInit = false;
			if ((bool)CameraManager.Instance)
			{
				CameraManager.Instance.UpdateInput();
			}
		}
		if (Application.isEditor && Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
		{
			SteamTest.Instance.TestToggleOverlay();
		}
		else if ((new Rect(0f, 0f, Screen.width, Screen.height).Contains(Input.mousePosition) || (SaveLoadManager.m_Video && SaveLoadManager.m_TestBuild)) && m_StateStack.Count != 0)
		{
			GameStateBase gameStateBase = m_StateStack[m_StateStack.Count - 1];
			if ((bool)gameStateBase)
			{
				gameStateBase.UpdateState();
			}
		}
	}
}
