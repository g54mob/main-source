using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class LevelGenerator : MonoBehaviour, ISavable
{
	[SerializeField]
	private LTGameManager_Campaign campaignGameManagerPrefab;

	[SerializeField]
	private LTGameManager_Endless endlessGameManagerPrefab;

	[SerializeField]
	private LevelSpawnersGenerator levelSpawnersGeneratorPrefab;

	[SerializeField]
	private SpawnersManager spawnersManagerPrefab;

	[SerializeField]
	private LTAudioSystem audioSystemPrefab;

	[Savable("levelData", true, false)]
	private string levelDataID;

	[Savable("mapSize", true, false)]
	private EMapSize mapSize;

	public IEnumerator GenerateLevel(bool newGame, LevelData levelData, EMapSize mapSize)
	{
		Object.DontDestroyOnLoad(base.gameObject);
		if (newGame)
		{
			levelDataID = levelData.Id;
			this.mapSize = mapSize;
		}
		else
		{
			levelData = LTFunctionLibrary.GetLevelsProgressionManager().LevelProgressionInfos.First((LevelsProgressionManager.FLevelProgressionInfo x) => x.LevelData.Id == levelDataID).LevelData;
			MatchInfo.instance.CurrentLevelData = levelData;
		}
		MapGenerator mapGenerator = Object.Instantiate(levelData.GetMapGenerator(this.mapSize), base.gameObject.transform).GetComponent<MapGenerator>();
		yield return mapGenerator.GenerateMapCoroutine();
		DayNightCycle component = Object.Instantiate(levelData.DayNightCyclePrefab, base.gameObject.transform).GetComponent<DayNightCycle>();
		Volume volume = new GameObject("PostProcessingVolume").AddComponent<Volume>();
		volume.transform.SetParent(base.gameObject.transform);
		volume.profile = levelData.PostProcessingProfile;
		volume.isGlobal = true;
		SpawnersManager spawnersManager = Object.Instantiate(spawnersManagerPrefab, base.gameObject.transform);
		spawnersManager.FirstPathTile = mapGenerator.PathGenerator.LastPathTile.Key;
		spawnersManager.SpawnPathTile = mapGenerator.PathGenerator.LastPathTile.Key;
		LTGameManager lTGameManager = Object.Instantiate(MatchInfo.instance.CurrentMatchMode switch
		{
			EMatchMode.Campaign => campaignGameManagerPrefab, 
			EMatchMode.Endless => endlessGameManagerPrefab, 
			_ => campaignGameManagerPrefab, 
		}, base.gameObject.transform);
		lTGameManager.PlayerTower = mapGenerator.EnvironmentGenerator.PlayerTower;
		lTGameManager.EnemyTower = mapGenerator.EnvironmentGenerator.EnemyTower;
		lTGameManager.EnemyTower.SetDamageCostAmount(levelData.CrystalsToWin);
		switch (MatchInfo.instance.CurrentMatchMode)
		{
		case EMatchMode.Campaign:
			spawnersManager.LevelSpanwers = levelData.LevelSpawners;
			break;
		case EMatchMode.Endless:
		{
			LevelSpawnersGenerator component2 = Object.Instantiate(levelSpawnersGeneratorPrefab, base.gameObject.transform).GetComponent<LevelSpawnersGenerator>();
			component2.GetComponent<SaveComponent>().ForceStartLoad();
			spawnersManager.LevelSpanwers = component2.GenerateLevelSpawners();
			break;
		}
		default:
			spawnersManager.LevelSpanwers = levelData.LevelSpawners;
			break;
		}
		lTGameManager.ScenePlayerBuildings = new GameplayObject[1] { mapGenerator.EnvironmentGenerator.PlayerTower };
		LTLevelController component3 = Object.Instantiate(levelData.LevelControllerPrefab, base.gameObject.transform).GetComponent<LTLevelController>();
		Transform transform = new GameObject("SpawnTransform").transform;
		transform.SetParent(component3.transform);
		transform.position = mapGenerator.EnvironmentGenerator.PlayerTower.transform.position + Vector3.back * 1f + Vector3.left * 1f;
		component3.SpawnTransform = transform;
		component3.PostProcessingProfile = volume;
		component3.LevelSizeX = mapGenerator.Grid.GetGridSize().x;
		component3.LevelSizeZ = mapGenerator.Grid.GetGridSize().y;
		component3.Grid = mapGenerator.Grid;
		component3.DayNightCycle = component;
		component3.CrystalAltars = mapGenerator.EnvironmentGenerator.CrystalAltars.ConvertAll((GameObject x) => x.GetComponent<CrystalAltar>()).ToArray();
		LTAudioSystem lTAudioSystem = Object.Instantiate(audioSystemPrefab, base.gameObject.transform);
		lTAudioSystem.GetComponent<AmbienceManager>().AmbienceDayClip = levelData.DayAmbience;
		lTAudioSystem.GetComponent<AmbienceManager>().AmbienceNightClip = levelData.NightAmbience;
		lTAudioSystem.GetComponent<MusicManager>().RoundMusic = levelData.DayMusic;
		lTAudioSystem.GetComponent<MusicManager>().WaveMusic = levelData.NightMusic;
		SceneManager.activeSceneChanged += OnActiveSceneChanged;
	}

	private void OnActiveSceneChanged(Scene current, Scene next)
	{
		SceneManager.activeSceneChanged -= OnActiveSceneChanged;
		SceneManager.MoveGameObjectToScene(base.gameObject, next);
		for (int num = base.gameObject.transform.childCount - 1; num >= 0; num--)
		{
			base.gameObject.transform.GetChild(num).SetParent(null);
		}
		LTFunctionLibrary.GetLTGameManager().SpawnPlayer();
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnSave()
	{
	}
}
