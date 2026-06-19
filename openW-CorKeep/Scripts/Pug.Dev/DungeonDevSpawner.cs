using System.Collections.Generic;
using Pug.Conversion;
using Pug.Properties;
using Pug.UnityExtensions;
using PugTilemap;
using PugWorldGen;
using Unity.Entities;
using UnityEngine;

[ExecuteInEditMode]
public class DungeonDevSpawner : MonoBehaviour
{
	private const string RESEED_DUNGEON_SETTING_NAME = "DungeonDev.ReseedDungeon";

	public GameObject dungeon;

	public MultiPugMap map;

	public PugDatabaseAuthoring database;

	public List<GameObject> convertPrefabs;

	private BlobAssetStore _blobAssetStore;

	private World _world;

	public static bool ReseedDungeon
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnValidate()
	{
	}

	public void GenerateDungeon(bool randomizeSeed = false)
	{
		PlatformConfiguration.Init();
		if (dungeon == null)
		{
			Debug.LogError(base.name + " has no dungeon set!");
			return;
		}
		if (dungeon.GetComponent<DungeonAuthoring>() == null && dungeon.GetComponent<SingleCustomSceneDungeonAuthoring>() == null)
		{
			Debug.LogError(dungeon.name + " has no DungeonAuthoring or SingleCustomSceneDungeonAuthoring component!");
			return;
		}
		if (database == null)
		{
			Debug.LogError("No PugDatabaseAuthoring set!");
			return;
		}
		PugDatabase.inited = false;
		SimpleEditorProgressBar simpleEditorProgressBar = new SimpleEditorProgressBar("Generating dungeon", 5);
		try
		{
			simpleEditorProgressBar.Update("Cleanup existing dungeon");
			if (_world != null)
			{
				ScriptBehaviourUpdateOrder.RemoveWorldFromCurrentPlayerLoop(_world);
				_world.Dispose();
				_world = null;
			}
			if (_blobAssetStore.IsCreated)
			{
				_blobAssetStore.Dispose();
				_blobAssetStore = default(BlobAssetStore);
			}
			map.ClearAllMaps();
			simpleEditorProgressBar.Update("Rebuild static database");
			PugDatabase.UpdateEntityMonos(database.prefabList);
			simpleEditorProgressBar.Update("Prepare editor world");
			_world = DefaultWorldInitialization.Initialize(dungeon.name + " DungeonDev World", editorWorld: true);
			ScriptBehaviourUpdateOrder.AppendWorldToCurrentPlayerLoop(_world);
			_blobAssetStore = new BlobAssetStore(1024);
			using ConversionManager conversionManager = new ConversionManager(new ConversionManager.ConversionParameters
			{
				BlobAssetStore = _blobAssetStore,
				TargetWorld = _world,
				PropertyBuilder = new PropertyLookupBuilder(),
				GhostConfigOverride = new GhostConfigFromIMonoBehaviourData(),
				ReservedObjectIndices = ECSManager.CalculateReservedObjectIndices(),
				UseCasualModeSettings = false,
				UseHardModeSettings = false,
				IsServer = true
			});
			conversionManager.AddPostConverter(new CustomScenePostConverter());
			conversionManager.AddPostConverter(new PugDatabasePostConverter());
			List<GameObject> list = new List<GameObject>();
			list.Add(database.gameObject);
			list.AddRange(convertPrefabs);
			list.Add(dungeon);
			foreach (GameObject item in list)
			{
				conversionManager.EnqueueGameObjectHierarchy(item);
			}
			simpleEditorProgressBar.Update("Convert prefabs");
			conversionManager.ConvertEnqueuedObjectsImmediately();
			if (randomizeSeed)
			{
				Entity entity = conversionManager.GetEntity(dungeon);
				uint num = (uint)Random.Range(0, 10000);
				Debug.Log($"Using randomized seed {num} for dungeon {dungeon.name}");
				DungeonAreaCD componentData = _world.EntityManager.GetComponentData<DungeonAreaCD>(entity);
				componentData.seed = num;
				_world.EntityManager.SetComponentData(entity, componentData);
			}
			foreach (GameObject item2 in list)
			{
				Entity entity2 = conversionManager.GetEntity(item2);
				if (_world.EntityManager.HasComponent<Prefab>(entity2))
				{
					_world.EntityManager.Instantiate(entity2);
				}
			}
		}
		finally
		{
			simpleEditorProgressBar.Finish();
		}
	}
}
