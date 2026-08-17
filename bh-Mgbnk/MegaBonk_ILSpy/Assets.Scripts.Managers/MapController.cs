using System;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Other;
using Cpp2ILInjected;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers;

public class MapController
{
	private static PlayerInventory inventory;

	public static int index = 0;

	private static MapData _003CcurrentMap_003Ek__BackingField;

	private static StageData _003CcurrentStage_003Ek__BackingField;

	private static bool isFinalBossStage = false;

	private const string finalBossMapName = "FinalBossMap";

	private static bool reseting = false;

	public static Action A_NewRunStarted;

	public static RunConfig runConfig;

	private static string mainMenuSceneName = "MainMenu";

	public static MapData currentMap
	{
		get
		{
			return _003CcurrentMap_003Ek__BackingField;
		}
		private set
		{
			_003CcurrentMap_003Ek__BackingField = value;
		}
	}

	public static StageData currentStage
	{
		get
		{
			return _003CcurrentStage_003Ek__BackingField;
		}
		private set
		{
			_003CcurrentStage_003Ek__BackingField = value;
		}
	}

	public static void RestartRun()
	{
		//IL_00aa: Expected I4, but got I8
		reseting = true;
		if (inventory != null)
		{
			inventory.Cleanup();
		}
		inventory = null;
		MapController.runConfig = MapController.runConfig;
		RunConfig runConfig = MapController.runConfig;
		_003CcurrentMap_003Ek__BackingField = runConfig.mapData;
		index = -1;
		isFinalBossStage = false;
		LoadNextStage();
		Action a_NewRunStarted = A_NewRunStarted;
		if (A_NewRunStarted != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v223.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	public static void StartNewMap(RunConfig newRunConfig)
	{
		//IL_0095: Expected I4, but got I8
		if (inventory != null)
		{
			inventory.Cleanup();
		}
		inventory = null;
		MapController.runConfig = newRunConfig;
		RunConfig runConfig = MapController.runConfig;
		_003CcurrentMap_003Ek__BackingField = runConfig.mapData;
		index = -1;
		isFinalBossStage = false;
		LoadNextStage();
		Action a_NewRunStarted = A_NewRunStarted;
		if (A_NewRunStarted != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v185.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private static void TryCleanupInventory()
	{
		if (inventory != null)
		{
			inventory.Cleanup();
		}
	}

	public static void LoadNextStage()
	{
		if (!reseting && MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.inventory != null)
			{
				PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
				inventory = playerInventory;
			}
		}
		reseting = false;
		int num = index + 1;
		index = num;
		MapData mapData = _003CcurrentMap_003Ek__BackingField;
		StageData[] stages = mapData.stages;
		int num2 = index;
		_003CcurrentStage_003Ek__BackingField = stages[num2];
		TransitionUI.Instance.StartLoadingMap("LoadingScreen");
	}

	public static void LoadFinalStage()
	{
		if (!reseting && MyPlayer.Instance != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			if (instance.inventory != null)
			{
				PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
				inventory = playerInventory;
			}
		}
		reseting = false;
		isFinalBossStage = true;
		TransitionUI.Instance.StartLoadingMap("LoadingScreen");
	}

	public static bool IsFirstStage()
	{
		return index == 0;
	}

	public static int GetStageIndex()
	{
		return index;
	}

	public static bool IsLastStage()
	{
		//IL_0074: Expected I4, but got O
		//IL_0044: Expected O, but got I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		MapData mapData = _003CcurrentMap_003Ek__BackingField;
		if ((object)_003CcurrentMap_003Ek__BackingField != null)
		{
			StageData[] stages = mapData.stages;
			if (mapData.stages != null)
			{
				object obj = stages.Length - 1;
				object obj2 = index - obj;
				return obj2 == null;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static bool IsFinalBossStage()
	{
		return isFinalBossStage;
	}

	public static void TestFinalBoss()
	{
		isFinalBossStage = true;
		index = 2;
	}

	public static bool IsTierFinalStage()
	{
		//IL_003a: Expected I4, but got O
		//IL_0018: Expected O, but got I4
		RunConfig runConfig = MapController.runConfig;
		if (MapController.runConfig != null)
		{
			object obj = index - runConfig.mapTierIndex;
			return obj == null;
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static PlayerInventory GetPlayerInventory(CharacterData data)
	{
		//IL_0098: Expected I, but got O
		//IL_0072: Expected I, but got O
		bool flag = inventory != null;
		nint num = (nint)typeof(MapController);
		if (!flag)
		{
			PlayerInventory playerInventory = new PlayerInventory(data);
			inventory = playerInventory;
			num = (nint)typeof(MapController);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v73 @ rcx_v4 (Il2CppClass<Assets.Scripts.Managers.MapController>)+E4]");
		if ((nint)0 == 0)
		{
			return inventory;
		}
		return inventory;
	}

	public static bool HasPlayerInventory()
	{
		bool flag = (nint)inventory < 0;
		bool flag2 = inventory == null;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	public static void TestMap(MapData mapData, StageData stageData)
	{
		_003CcurrentMap_003Ek__BackingField = mapData;
		_003CcurrentStage_003Ek__BackingField = stageData;
		int num = 0;
		int num2 = 0;
		while (true)
		{
			StageData[] stages = mapData.stages;
			if (num2 >= stages.Length)
			{
				break;
			}
			if (stages[num] == stageData)
			{
				index = num;
			}
			num++;
			num2 = num;
		}
		RunConfig runConfig = new RunConfig();
		runConfig.mapData = mapData;
		runConfig.stageData = stageData;
		runConfig.mapTierIndex = 2;
		MapController.runConfig = runConfig;
	}

	public static void TestMap(RunConfig testConfig)
	{
		CharacterData characterData = DataManager.Instance.GetCharacterData(CharacterMenu.selectedCharacter);
		PlayerInventory playerInventory = new PlayerInventory(characterData);
		inventory = playerInventory;
		index = 2;
		isFinalBossStage = true;
		MapController.runConfig = testConfig;
		RunConfig runConfig = MapController.runConfig;
		_003CcurrentMap_003Ek__BackingField = runConfig.mapData;
		RunConfig runConfig2 = MapController.runConfig;
		_003CcurrentStage_003Ek__BackingField = runConfig2.stageData;
	}

	public static bool IsMainMenu()
	{
		Scene activeScene = SceneManager.GetActiveScene();
		Scene scene = default(Scene);
		string name = scene.name;
		bool flag = name == mainMenuSceneName;
		bool flag2 = !flag;
		return !flag2;
	}
}
