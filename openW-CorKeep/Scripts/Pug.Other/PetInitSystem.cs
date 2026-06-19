using System.Runtime.CompilerServices;
using PlayerCommand;
using Pug.UnityExtensions;
using Unity.Collections;
using Unity.Entities;
using Unity.Entities.Internal;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Scripting;

[WorldSystemFilter(WorldSystemFilterFlags.ServerSimulation, WorldSystemFilterFlags.Default)]
[UpdateInGroup(typeof(RunSimulationSystemGroup))]
[UpdateAfter(typeof(ServerSystem))]
public class PetInitSystem : SystemBase
{
	private struct TypeHandle
	{
		[ReadOnly]
		public ComponentLookup<PetInitializeAuxDataCD> __PetInitializeAuxDataCD_RO_ComponentLookup;

		[ReadOnly]
		public EntityStorageInfoLookup __EntityStorageInfoLookup;

		[ReadOnly]
		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RO_BufferLookup;

		public BufferLookup<ContainedObjectsBuffer> __ContainedObjectsBuffer_RW_BufferLookup;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void __AssignHandles(ref SystemState state)
		{
			__PetInitializeAuxDataCD_RO_ComponentLookup = state.GetComponentLookup<PetInitializeAuxDataCD>(isReadOnly: true);
			__EntityStorageInfoLookup = state.GetEntityStorageInfoLookup();
			__ContainedObjectsBuffer_RO_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>(isReadOnly: true);
			__ContainedObjectsBuffer_RW_BufferLookup = state.GetBufferLookup<ContainedObjectsBuffer>();
		}
	}

	private InventoryAuxDataSystem _inventoryAuxDataSystem;

	private TypeHandle __TypeHandle;

	private EntityQuery __query_982453269_0;

	private EntityQuery __query_982453269_1;

	[Preserve]
	protected override void OnCreate()
	{
		_inventoryAuxDataSystem = base.World.GetExistingSystemManaged<InventoryAuxDataSystem>();
		RequireForUpdate<PugDatabase.DatabaseBankCD>();
	}

	[Preserve]
	protected override void OnUpdate()
	{
		using NativeArray<Entity> entities = __query_982453269_0.ToEntityArray(Allocator.Temp);
		if (entities.Length == 0)
		{
			return;
		}
		Unity.Mathematics.Random rng = PugRandom.GetRng();
		InventoryAuxDataSystemDataCD systemData = _inventoryAuxDataSystem.SystemData;
		BlobAssetReference<PugDatabase.PugDatabaseBank> databaseBankBlob = __query_982453269_1.GetSingleton<PugDatabase.DatabaseBankCD>().databaseBankBlob;
		foreach (Entity item in entities)
		{
			Entity entityContainingPet = InternalCompilerInterface.GetComponentAfterCompletingDependency(ref __TypeHandle.__PetInitializeAuxDataCD_RO_ComponentLookup, ref base.CheckedStateRef, item).EntityContainingPet;
			if (!InternalCompilerInterface.DoesEntityExist(ref __TypeHandle.__EntityStorageInfoLookup, ref base.CheckedStateRef, entityContainingPet))
			{
				Debug.LogError($"Cannot find entity {entityContainingPet} for pet init");
				continue;
			}
			if (!InternalCompilerInterface.HasBufferAfterCompletingDependency(ref __TypeHandle.__ContainedObjectsBuffer_RO_BufferLookup, ref base.CheckedStateRef, entityContainingPet))
			{
				Debug.LogError("Cannot find inventory for pet init");
				continue;
			}
			DynamicBuffer<ContainedObjectsBuffer> bufferAfterCompletingDependency = InternalCompilerInterface.GetBufferAfterCompletingDependency(ref __TypeHandle.__ContainedObjectsBuffer_RW_BufferLookup, ref base.CheckedStateRef, entityContainingPet);
			for (int i = 0; i < bufferAfterCompletingDependency.Length; i++)
			{
				ContainedObjectsBuffer value = bufferAfterCompletingDependency[i];
				if (value.objectID == ObjectID.None || value.auxDataIndex != 0 || PugDatabase.GetObjectInfo(value.objectID, value.variation).objectType != ObjectType.Pet)
				{
					continue;
				}
				DynamicBuffer<PetTalentBuffer> orAllocateBuffer = systemData.GetOrAllocateBuffer<PetTalentBuffer>(base.EntityManager, ref value.auxDataIndex);
				if (!orAllocateBuffer.IsCreated)
				{
					Debug.LogError("Couldn't initialize pet; no talent buffer");
					continue;
				}
				Entity primaryPrefabEntity = PugDatabase.GetPrimaryPrefabEntity(value.objectID, databaseBankBlob, value.variation);
				DynamicBuffer<PetTalentPoolBuffer> buffer = base.EntityManager.GetBuffer<PetTalentPoolBuffer>(primaryPrefabEntity);
				for (int j = 0; j < 9; j++)
				{
					orAllocateBuffer.Add(new PetTalentBuffer
					{
						petTalentID = buffer[rng.NextInt(buffer.Length)].petTalentID
					});
				}
				int maxSkins = base.EntityManager.GetComponentData<PetCD>(primaryPrefabEntity).maxSkins;
				systemData.SetOrAllocateComponentData(base.EntityManager, ref value.auxDataIndex, new PetSkinCD
				{
					skinIndex = rng.NextInt(maxSkins)
				});
				systemData.SetOrAllocateComponentData(base.EntityManager, ref value.auxDataIndex, default(NameCD));
				bufferAfterCompletingDependency[i] = value;
			}
		}
		base.EntityManager.DestroyEntity(entities);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private void __AssignQueries(ref SystemState state)
	{
		EntityQueryBuilder entityQueryBuilder = new EntityQueryBuilder(Allocator.Temp);
		EntityQueryBuilder entityQueryBuilder2 = entityQueryBuilder.WithAll<PetInitializeAuxDataCD>();
		__query_982453269_0 = entityQueryBuilder2.Build(ref state);
		entityQueryBuilder.Reset();
		entityQueryBuilder2 = entityQueryBuilder.WithAll<PugDatabase.DatabaseBankCD>();
		entityQueryBuilder2 = entityQueryBuilder2.WithOptions(EntityQueryOptions.IncludeSystems);
		__query_982453269_1 = entityQueryBuilder2.Build(ref state);
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
	public PetInitSystem()
	{
	}
}
