using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Pug.Platform;
using Pug.UnityExtensions;
using PugWorldGen;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public class SetServerDefaultsSystem : SystemBase
{
	private struct TypeHandle
	{
		[ReadOnly]
		public BufferLookup<ActivatedContentBundlesBuffer> __ActivatedContentBundlesBuffer_RO_BufferLookup;

		public BufferLookup<ActivatedContentBundlesBuffer> __ActivatedContentBundlesBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__ActivatedContentBundlesBuffer_RO_BufferLookup = state.GetBufferLookup<ActivatedContentBundlesBuffer>(isReadOnly: true);
			__ActivatedContentBundlesBuffer_RW_BufferLookup = state.GetBufferLookup<ActivatedContentBundlesBuffer>();
		}
	}

	private static readonly DataBlockAddress ClassicBundle = new DataBlockAddress("7507d88e-fd7a-7444-1b18-3816c6fbe382");

	private static readonly DataBlockAddress FullReleaseBundle = new DataBlockAddress("46418d34-550b-7504-7970-e202973b089b");

	private TypeHandle __TypeHandle;

	private EntityQuery __query_700005153_0;

	private EntityQuery __query_700005153_1;

	private EntityQuery __query_700005153_2;

	private EntityQuery __query_700005153_3;

	private EntityQuery __query_700005153_4;

	private EntityQuery __query_700005153_5;

	[Preserve]
	protected override void OnCreate()
	{
		RequireForUpdate<WorldHasBeenDeserializedCD>();
		RequireForUpdate<PugPrefabBuffer>();
		base.OnCreate();
	}

	[Preserve]
	protected override void OnStartRunning()
	{
		Entity entity = base.EntityManager.CreateEntity();
		WorldInfo worldInfo = Manager.saves.GetWorldInfo();
		bool flag;
		if (GetEntityQuery(typeof(ServerGuidCD)).IsEmpty)
		{
			flag = true;
			Unity.Entities.Hash128 hash = PugRandom.GenerateGuid();
			base.EntityManager.AddComponentData(entity, new ServerGuidCD
			{
				Value = hash
			});
			Debug.Log($"starting a new world : {hash}");
		}
		else
		{
			flag = false;
		}
		EntityQuery entityQuery = GetEntityQuery(typeof(ServerSeedCD));
		uint num;
		if (entityQuery.IsEmpty)
		{
			if (!string.IsNullOrWhiteSpace(worldInfo.seedString))
			{
				worldInfo.seed = (uint)Animator.StringToHash(worldInfo.seedString);
				Debug.Log($"Hashed string seed {worldInfo.seedString} -> {worldInfo.seed}");
			}
			else if (worldInfo.seed != 0)
			{
				worldInfo.seedString = "OVERRIDDEN";
				Debug.Log($"Using explicitly provided hashed seed {worldInfo.seed}");
			}
			else
			{
				worldInfo.seedString = PugRandom.GenerateWorldSeed();
				worldInfo.seed = (uint)Animator.StringToHash(worldInfo.seedString);
				Debug.Log($"No seed string provided, using random string: {worldInfo.seedString} hashed to {worldInfo.seed}");
			}
			num = worldInfo.seed;
			base.EntityManager.AddComponentData(entity, new ServerSeedCD
			{
				Value = num
			});
			FilesystemManager.File file = new FilesystemManager.File(FilesystemManager.FileID.ServerMapParts, Manager.saves.GetWorldId());
			if (Manager.filesystemManager.FileExists(file))
			{
				Debug.LogWarning("Deleting server map file that didn't have a corresponding world file.");
				Manager.filesystemManager.Delete(file);
			}
		}
		else
		{
			num = entityQuery.GetSingleton<ServerSeedCD>().Value;
			if (num != worldInfo.seed)
			{
				Debug.LogWarning($"Seed mismatch between world info ({worldInfo.seed}) and world ({num}). Only the world seed will be used.");
			}
		}
		Debug.Log($"Using seed {num}");
		if (GetEntityQuery(typeof(WorldVersionSerializedCD)).IsEmpty)
		{
			base.EntityManager.AddComponentData(base.EntityManager.CreateEntity(), new WorldVersionSerializedCD
			{
				Version = 12
			});
		}
		EntityQuery entityQuery2 = GetEntityQuery(typeof(WorldGenerationTypeCD));
		WorldGenerationType worldGenerationType;
		if (entityQuery2.IsEmpty)
		{
			if (flag)
			{
				worldGenerationType = worldInfo.worldGenerationType;
				if (worldGenerationType == WorldGenerationType.Undefined)
				{
					worldGenerationType = WorldGenerationType.FullRelease;
				}
			}
			else
			{
				worldGenerationType = ((worldInfo.mode == WorldMode.Creative) ? WorldGenerationType.Creative : WorldGenerationType.Classic);
			}
			Debug.Log($"Starting new world with generation type {worldGenerationType}");
			base.EntityManager.AddComponentData(entity, new WorldGenerationTypeCD
			{
				Value = worldGenerationType
			});
			Manager.saves.SetWorldGenerationType(worldGenerationType);
		}
		else
		{
			worldGenerationType = entityQuery2.GetSingleton<WorldGenerationTypeCD>().Value;
			Debug.Log($"World uses generation type {worldGenerationType}");
		}
		if (worldGenerationType != WorldGenerationType.FullRelease && __query_700005153_0.IsEmpty)
		{
			base.EntityManager.CreateSingleton<WorldGenerationParametersSerializedCD>();
		}
		if (worldGenerationType == WorldGenerationType.FullRelease)
		{
			CoreKeeperWorldParameters worldGenerationParametersReference = Manager.saves.GetWorldGenerationParametersReference();
			CoreKeeperGenerationSettings.ApplyToParameters(worldInfo.worldGenerationSettings, worldGenerationParametersReference);
			if (!__query_700005153_1.TryGetSingleton<WorldGenerationParametersSerializedCD>(out var value) || !value.PackedJsonData.IsCreated)
			{
				worldGenerationParametersReference.globalSeed = (int)num;
			}
			else
			{
				JsonUtility.FromJsonOverwrite(BlobByteArray.DataToString(value.PackedJsonData), worldGenerationParametersReference);
			}
			BlobAssetReference<BlobByteArray> blobAsset = BlobByteArray.CreateFromString(JsonUtility.ToJson(worldGenerationParametersReference));
			Manager.ecs.BlobAssetStore.TryAdd(ref blobAsset);
			if (__query_700005153_1.HasSingleton<WorldGenerationParametersSerializedCD>())
			{
				__query_700005153_2.SetSingleton(new WorldGenerationParametersSerializedCD
				{
					PackedJsonData = blobAsset
				});
			}
			else
			{
				base.EntityManager.CreateSingleton(new WorldGenerationParametersSerializedCD
				{
					PackedJsonData = blobAsset
				});
			}
			Manager.saves.UpdateWorldGenerationParameters(__query_700005153_1.GetSingleton<WorldGenerationParametersSerializedCD>());
			Manager.worldGen.PreparePugWorld();
		}
		float value2 = ((worldGenerationType == WorldGenerationType.FullRelease) ? Manager.saves.GetWorldGenerationParametersReference().worldScale : 1f);
		base.EntityManager.AddComponentData(entity, new WorldScaleCD
		{
			Value = value2
		});
		IReadOnlyList<ContentBundleDataBlock> dataBlocks = ScriptableData.GetDataBlocks<ContentBundleDataBlock>();
		DynamicBuffer<PugPrefabBuffer> singletonBuffer = __query_700005153_3.GetSingletonBuffer<PugPrefabBuffer>();
		if (!__query_700005153_4.TryGetSingletonBuffer(out DynamicBuffer<ActivatedContentBundlesBuffer> value3, false))
		{
			HashSet<DataBlockAddress> hashSet = new HashSet<DataBlockAddress>();
			AddDefaultContentBundles(hashSet, worldGenerationType);
			if (flag)
			{
				AddAutomaticallyEnabledContentBundles(hashSet, dataBlocks);
				AddSeedBasedContentBundles(worldInfo.seedString, hashSet, dataBlocks);
			}
			Entity entity2 = Entity.Null;
			for (int i = 0; i < singletonBuffer.Length; i++)
			{
				if (InternalCompilerInterface.HasBufferAfterCompletingDependency(ref __TypeHandle.__ActivatedContentBundlesBuffer_RO_BufferLookup, ref base.CheckedStateRef, singletonBuffer[i].Value))
				{
					entity2 = base.EntityManager.Instantiate(singletonBuffer[i].Value);
					break;
				}
			}
			value3 = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__ActivatedContentBundlesBuffer_RW_BufferLookup, ref base.CheckedStateRef, entity2);
			foreach (DataBlockAddress item in hashSet)
			{
				value3.Add(new ActivatedContentBundlesBuffer
				{
					ContentBundle = item
				});
			}
		}
		if (!__query_700005153_5.HasSingleton<WorldCreationVersionSerializedCD>())
		{
			WorldCreationVersion worldCreationVersion = WorldCreationVersion.Unknown;
			if (flag || worldGenerationType == WorldGenerationType.Creative)
			{
				worldCreationVersion = WorldCreationVersion.Ck121;
			}
			else
			{
				switch (worldGenerationType)
				{
				case WorldGenerationType.FullRelease:
					worldCreationVersion = WorldCreationVersion.Ck10x;
					break;
				case WorldGenerationType.Classic:
					worldCreationVersion = WorldCreationVersion.EarlyAccess;
					break;
				}
			}
			Debug.Log($"Initialized world creation version to {worldCreationVersion}");
			base.EntityManager.CreateSingleton(new WorldCreationVersionSerializedCD
			{
				Value = worldCreationVersion
			});
		}
		Debug.Log($"World creation version is {__query_700005153_5.GetSingleton<WorldCreationVersionSerializedCD>().Value}");
		List<DataBlockAddress> list = new List<DataBlockAddress>();
		GetContentBundlesFromWorldInfo(list);
		GetContentBundlesFromCommandLine(list, dataBlocks);
		foreach (DataBlockAddress item2 in list)
		{
			ActivatedContentBundlesBuffer activatedContentBundlesBuffer = new ActivatedContentBundlesBuffer
			{
				ContentBundle = item2
			};
			if (!value3.Contains(activatedContentBundlesBuffer))
			{
				value3.Add(activatedContentBundlesBuffer);
				Debug.Log("Activated new content bundle " + ContentBundleDataBlock.GetBundleName(item2));
			}
		}
		LogActivatedContentBundles(value3);
		using (EntityQuery entityQuery3 = base.EntityManager.CreateEntityQuery(typeof(TheCoreCD)))
		{
			if (entityQuery3.CalculateEntityCount() > 1)
			{
				EntityCommandBuffer entityCommandBuffer = base.World.GetExistingSystemManaged<BeginSimulationEntityCommandBufferSystem>().CreateCommandBuffer();
				Debug.Log("Cleaning up extra cores");
				using NativeArray<Entity> nativeArray = entityQuery3.ToEntityArray(Allocator.Temp);
				SetComponent(nativeArray[0], LocalTransform.FromPosition(new float3(0f, 0f, 4f)));
				for (int j = 1; j < nativeArray.Length; j++)
				{
					entityCommandBuffer.DestroyEntity(nativeArray[j]);
				}
			}
		}
		base.OnStartRunning();
	}

	private static void AddDefaultContentBundles(HashSet<DataBlockAddress> contentBundles, WorldGenerationType worldGenerationType)
	{
		ContentBundleDataBlock dataBlock = ScriptableData.GetDataBlock<ContentBundleDataBlock>(ClassicBundle);
		ContentBundleDataBlock dataBlock2 = ScriptableData.GetDataBlock<ContentBundleDataBlock>(FullReleaseBundle);
		switch (worldGenerationType)
		{
		case WorldGenerationType.Classic:
			Debug.Log($"Adding content bundle {dataBlock} as default for world generation type {WorldGenerationType.Classic}");
			AddContentBundleWithDependencies(dataBlock, contentBundles);
			break;
		case WorldGenerationType.FullRelease:
			Debug.Log($"Adding content bundle {dataBlock2} as default for world generation type {WorldGenerationType.FullRelease}");
			AddContentBundleWithDependencies(dataBlock2, contentBundles);
			break;
		}
	}

	private static void AddAutomaticallyEnabledContentBundles(HashSet<DataBlockAddress> contentBundles, IReadOnlyList<ContentBundleDataBlock> allContentBundles)
	{
		foreach (ContentBundleDataBlock allContentBundle in allContentBundles)
		{
			if (allContentBundle.automaticallyAddedToNewWorlds)
			{
				Debug.Log($"Automatically adding content bundle {allContentBundle} to new world");
				AddContentBundleWithDependencies(allContentBundle, contentBundles);
			}
		}
	}

	private static void AddSeedBasedContentBundles(string seedString, HashSet<DataBlockAddress> contentBundles, IReadOnlyList<ContentBundleDataBlock> allContentBundles)
	{
		foreach (ContentBundleDataBlock allContentBundle in allContentBundles)
		{
			if (allContentBundle.enabledIfSeedContainsString.hasValue && !string.IsNullOrEmpty(allContentBundle.enabledIfSeedContainsString.value) && seedString.Contains(allContentBundle.enabledIfSeedContainsString.value, StringComparison.InvariantCultureIgnoreCase))
			{
				Debug.Log($"Adding content bundle {allContentBundle} because seed string `{seedString}` contains `{allContentBundle.enabledIfSeedContainsString.value}`");
				AddContentBundleWithDependencies(allContentBundle, contentBundles);
				break;
			}
		}
	}

	private static void AddContentBundleWithDependencies(ContentBundleDataBlock bundle, HashSet<DataBlockAddress> contentBundles)
	{
		contentBundles.Add(bundle.address);
		foreach (DataBlockRef<ContentBundleDataBlock> dependency in bundle.dependencies)
		{
			if (!contentBundles.Contains(dependency))
			{
				if (!dependency.TryGet(out var dataBlock))
				{
					Debug.LogError($"Failed to load content bundle dependency {dependency} of {bundle}");
					continue;
				}
				Debug.Log($"Adding content bundle {dataBlock} as dependency of {bundle}");
				AddContentBundleWithDependencies(dataBlock, contentBundles);
			}
		}
	}

	private static void LogActivatedContentBundles(DynamicBuffer<ActivatedContentBundlesBuffer> activeContentBundles)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append($"Has {activeContentBundles.Length} activated content bundles: ");
		for (int i = 0; i < activeContentBundles.Length; i++)
		{
			stringBuilder.Append(ContentBundleDataBlock.GetBundleName(activeContentBundles[i].ContentBundle));
			if (i < activeContentBundles.Length - 1)
			{
				stringBuilder.Append(", ");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	[Preserve]
	protected override void OnUpdate()
	{
	}

	private static void GetContentBundlesFromWorldInfo(List<DataBlockAddress> bundles)
	{
		foreach (DataBlockAddress activatedContentBundle in Manager.saves.GetWorldInfo().ActivatedContentBundles)
		{
			if (!ScriptableData.TryGetDataBlock<ContentBundleDataBlock>(activatedContentBundle, out var dataBlock))
			{
				Debug.LogError($"Ignoring invalid content bundle {activatedContentBundle} from world info");
			}
			else if (dataBlock.canBeActivatedByPlayer)
			{
				bundles.Add(activatedContentBundle);
			}
		}
	}

	private void GetContentBundlesFromCommandLine(List<DataBlockAddress> bundles, IReadOnlyList<ContentBundleDataBlock> allContentBundles)
	{
		if (CommandLineArgs.Has("-activateallcontent"))
		{
			foreach (ContentBundleDataBlock allContentBundle in allContentBundles)
			{
				if (allContentBundle.canBeActivatedByPlayer)
				{
					bundles.Add(allContentBundle.address);
				}
			}
			return;
		}
		if (!CommandLineArgs.TryGetParam("-activatecontent", out var param))
		{
			return;
		}
		string[] array = param.Split(',');
		foreach (string text in array)
		{
			ContentBundleDataBlock result;
			if (string.IsNullOrEmpty(text))
			{
				Debug.LogWarning("Ignoring empty content bundle argument");
			}
			else if (!TryGetBundleByName(text, allContentBundles, out result))
			{
				Debug.LogWarning("Ignoring invalid content bundle name " + text);
			}
			else if (!result.canBeActivatedByPlayer)
			{
				Debug.LogWarning("Ignoring content bundle " + text + ". This bundle cannot be activated after the world has already been created.");
			}
			else
			{
				bundles.Add(result.address);
			}
		}
	}

	private static bool TryGetBundleByName(string name, IReadOnlyList<ContentBundleDataBlock> allContentBundles, out ContentBundleDataBlock result)
	{
		foreach (ContentBundleDataBlock allContentBundle in allContentBundles)
		{
			if (allContentBundle.name.Equals(name, StringComparison.InvariantCultureIgnoreCase))
			{
				result = allContentBundle;
				return true;
			}
		}
		result = null;
		return false;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationParametersSerializedCD>();
		__query_700005153_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldGenerationParametersSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_700005153_1 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<WorldGenerationParametersSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_700005153_2 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<PugPrefabBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_700005153_3 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAllRW<ActivatedContentBundlesBuffer>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_700005153_4 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<WorldCreationVersionSerializedCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_700005153_5 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder.Dispose();
	}

	protected override void OnCreateForCompiler()
	{
		base.OnCreateForCompiler();
		__AssignQueries(ref base.CheckedStateRef);
		__TypeHandle.__AssignHandles(ref base.CheckedStateRef);
	}

	[Preserve]
	public SetServerDefaultsSystem()
	{
	}
}
