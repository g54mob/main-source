using System;
using System.Collections.Generic;
using System.Reflection;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.Serialization;
using Unity.IO.LowLevel.Unsafe;
using Unity.Serialization.Binary;
using UnityEngine;

namespace Pug.ECS.Serialization.DOTS100
{
	public static class SerializeUtility
	{
		internal struct Settings
		{
			internal static readonly Settings Default = new Settings
			{
				SerializeComponentTypeNames = true,
				PrefabRoot = Entity.Null
			};

			internal bool SerializeComponentTypeNames;

			internal Entity PrefabRoot;

			internal bool RequiresDebugSection => SerializeComponentTypeNames;
		}

		private class ManagedObjectWriterAdapter : IBinaryAdapter<Entity>, IBinaryAdapter, IBinaryAdapter<BlobAssetReferenceData>, IBinaryAdapter<UntypedWeakReferenceId>
		{
			private unsafe readonly EntityRemapUtility.EntityRemapInfo* m_EntityRemapInfo;

			private readonly NativeParallelHashMap<BlobAssetPtr, int> m_BlobAssetMap;

			private readonly NativeParallelHashSet<UntypedWeakReferenceId> m_WeakAssetRefs;

			private readonly NativeArray<int> m_BlobAssetOffsets;

			public bool SerializeEntityReferences { get; set; }

			public unsafe ManagedObjectWriterAdapter(EntityRemapUtility.EntityRemapInfo* entityRemapInfo, NativeParallelHashMap<BlobAssetPtr, int> blobAssetMap, NativeArray<int> blobAssetOffsets, NativeParallelHashSet<UntypedWeakReferenceId> weakAssetRefs)
			{
				SerializeEntityReferences = true;
				m_EntityRemapInfo = entityRemapInfo;
				m_BlobAssetMap = blobAssetMap;
				m_BlobAssetOffsets = blobAssetOffsets;
				m_WeakAssetRefs = weakAssetRefs;
			}

			unsafe void IBinaryAdapter<Entity>.Serialize(in BinarySerializationContext<Entity> context, Entity value)
			{
				if (SerializeEntityReferences)
				{
					value = EntityRemapUtility.RemapEntity(m_EntityRemapInfo, value);
					context.Writer->Add(value.Index);
					context.Writer->Add(value.Version);
					return;
				}
				throw new ArgumentException("Tried to serialized an Entity reference however entity reference serialization has been explicitly disabled.");
			}

			unsafe void IBinaryAdapter<BlobAssetReferenceData>.Serialize(in BinarySerializationContext<BlobAssetReferenceData> context, BlobAssetReferenceData value)
			{
				int value2 = -1;
				if (value.m_Ptr != null)
				{
					if (!m_BlobAssetMap.TryGetValue(new BlobAssetPtr(value.Header), out var item))
					{
						throw new InvalidOperationException("Trying to serialize a BlobAssetReference but the asset has not been included in the batch.");
					}
					value2 = m_BlobAssetOffsets[item];
				}
				context.Writer->Add(value2);
			}

			unsafe void IBinaryAdapter<UntypedWeakReferenceId>.Serialize(in BinarySerializationContext<UntypedWeakReferenceId> context, UntypedWeakReferenceId value)
			{
				if (m_WeakAssetRefs.IsCreated)
				{
					m_WeakAssetRefs.Add(value);
				}
				context.Writer->Add(value);
			}

			Entity IBinaryAdapter<Entity>.Deserialize(in BinaryDeserializationContext<Entity> context)
			{
				throw new InvalidOperationException("ManagedObjectWriterAdapter should only be used for writing and never for reading!");
			}

			BlobAssetReferenceData IBinaryAdapter<BlobAssetReferenceData>.Deserialize(in BinaryDeserializationContext<BlobAssetReferenceData> context)
			{
				throw new InvalidOperationException("ManagedObjectWriterAdapter should only be used for writing and never for reading!");
			}

			UntypedWeakReferenceId IBinaryAdapter<UntypedWeakReferenceId>.Deserialize(in BinaryDeserializationContext<UntypedWeakReferenceId> context)
			{
				throw new InvalidOperationException("ManagedObjectWriterAdapter should only be used for writing and never for reading!");
			}
		}

		private class ManagedObjectReaderAdapter : IBinaryAdapter<Entity>, IBinaryAdapter, IBinaryAdapter<BlobAssetReferenceData>
		{
			private unsafe readonly byte* m_BlobAssetBatch;

			public unsafe ManagedObjectReaderAdapter(byte* blobAssetBatch)
			{
				m_BlobAssetBatch = blobAssetBatch;
			}

			void IBinaryAdapter<Entity>.Serialize(in BinarySerializationContext<Entity> context, Entity value)
			{
				throw new InvalidOperationException("ManagedObjectReaderAdapter should only be used for reading and never for writing!");
			}

			void IBinaryAdapter<BlobAssetReferenceData>.Serialize(in BinarySerializationContext<BlobAssetReferenceData> context, BlobAssetReferenceData value)
			{
				throw new InvalidOperationException("ManagedObjectReaderAdapter should only be used for reading and never for writing!");
			}

			unsafe Entity IBinaryAdapter<Entity>.Deserialize(in BinaryDeserializationContext<Entity> context)
			{
				context.Reader->ReadNext(out int value);
				context.Reader->ReadNext(out int value2);
				return new Entity
				{
					Index = value,
					Version = value2
				};
			}

			unsafe BlobAssetReferenceData IBinaryAdapter<BlobAssetReferenceData>.Deserialize(in BinaryDeserializationContext<BlobAssetReferenceData> context)
			{
				context.Reader->ReadNext(out int value);
				if (value != -1)
				{
					return new BlobAssetReferenceData
					{
						m_Ptr = m_BlobAssetBatch + value
					};
				}
				return default(BlobAssetReferenceData);
			}
		}

		internal struct BufferPatchRecord
		{
			public int ChunkOffset;

			public int AllocSizeBytes;
		}

		internal struct BlobAssetRefPatchRecord
		{
			public int ChunkOffset;

			public int BlobDataOffset;
		}

		internal struct SharedComponentRecord
		{
			public ulong StableTypeHash;

			public int ComponentSize;
		}

		internal struct MegaChunkInfo
		{
			public int MegaChunkSize;

			public ChunkIndex MegaChunkIndex;

			public MegaChunkInfo(ChunkIndex fistChunkIndex, int chunkCount)
			{
				MegaChunkSize = chunkCount;
				MegaChunkIndex = fistChunkIndex;
			}
		}

		internal struct WorldDeserializationStatus
		{
			internal UnsafeList<MegaChunkInfo> MegaChunkInfoList;

			public DotsSerializationReader.NodeHandle.PrefetchState ArchetypePrefetchState;

			[NativeDisableUnsafePtrRestriction]
			public unsafe void* BlobAssetBuffer;

			public int BlobAssetSize;

			public DotsSerializationReader.NodeHandle.PrefetchState SharedComponentPrefetchState;

			public DotsSerializationReader.NodeHandle.PrefetchState EnabledBitsPrefetchState;

			public DotsSerializationReader.NodeHandle.PrefetchState BufferElementPrefetchState;

			public DotsSerializationReader.NodeHandle.PrefetchState PrefabPrefetchState;

			public int TotalChunkCount;

			public unsafe void Dispose()
			{
				MegaChunkInfoList.Dispose();
				ArchetypePrefetchState.Dispose();
				SharedComponentPrefetchState.Dispose();
				EnabledBitsPrefetchState.Dispose();
				BufferElementPrefetchState.Dispose();
				PrefabPrefetchState.Dispose();
				UnsafeUtility.Free(BlobAssetBuffer, Allocator.Persistent);
			}
		}

		internal struct WorldDeserializationResult
		{
			internal Entity PrefabRoot;
		}

		public const int CurrentFileFormatVersion = 76;

		internal const int MaxSubsceneHeaderSize = 65536;

		internal const string k_ExportedTypesDebugLogFileName = "ExportedTypes.log";

		internal static Unity.Entities.Hash128 WorldFileType = new Unity.Entities.Hash128("7F090F7311DF4BA5BA3094AA33D0FAA7");

		internal static Unity.Entities.Hash128 WorldNodeType = new Unity.Entities.Hash128("E9FDFDEB4775443ABB236D4858232894");

		internal static Unity.Entities.Hash128 DebugSectionNodeType = new Unity.Entities.Hash128("582BAFE96EC44A72ACD9CCBC850FDBC4");

		internal static Unity.Entities.Hash128 TypesNameStringTableNodeType = new Unity.Entities.Hash128("4847374145504072849AAC7B1921E7FD");

		internal static Unity.Entities.Hash128 TypesNameNodeType = new Unity.Entities.Hash128("828510FAD38F4EA78CD908D4D780388B");

		internal static Unity.Entities.Hash128 ArchetypesNodeType = new Unity.Entities.Hash128("F5364E1CCB62466A9883F6F9554D4F0C");

		internal static Unity.Entities.Hash128 SharedAndManagedComponentsNodeType = new Unity.Entities.Hash128("D565355C5CF34C0DBBD4A06ADDA948B1");

		internal static Unity.Entities.Hash128 EnabledBitsNodeType = new Unity.Entities.Hash128("5846E500EA614C1DA94AFB85AFD8F4F4");

		internal static Unity.Entities.Hash128 BlobAssetsNodeType = new Unity.Entities.Hash128("9A26954FF1ED4CC5A64E8AAD4F64773A");

		internal static Unity.Entities.Hash128 ChunksNodeType = new Unity.Entities.Hash128("2EA7CE3325F04D7A84CEAB46790C628A");

		internal static Unity.Entities.Hash128 BufferDataNodeType = new Unity.Entities.Hash128("E33124BFAC2649D792DE36E4611DDD70");

		internal static Unity.Entities.Hash128 PrefabNodeType = new Unity.Entities.Hash128("2A84A183583A4FAD8CB7105AE3C47598");

		private unsafe static UnsafeList<EntityArchetype> ReadArchetypes(BinaryReader reader, NativeArray<TypeIndex> types, ExclusiveEntityTransaction entityManager, out int totalEntityCount)
		{
			int num = reader.ReadInt();
			UnsafeList<EntityArchetype> result = new UnsafeList<EntityArchetype>(num, Allocator.Temp);
			totalEntityCount = 0;
			NativeList<ComponentType> list = new NativeList<ComponentType>(Allocator.Temp);
			for (int i = 0; i < num; i++)
			{
				int num2 = reader.ReadInt();
				totalEntityCount += num2;
				int num3 = reader.ReadInt();
				list.Clear();
				for (int j = 0; j < num3; j++)
				{
					TypeIndex typeIndex = new TypeIndex
					{
						Value = reader.ReadInt()
					};
					int index = typeIndex.Index;
					TypeIndex typeIndex2 = types[index];
					if (TypeManager.IsChunkComponent(typeIndex))
					{
						typeIndex2 = TypeManager.MakeChunkComponentTypeIndex(typeIndex2);
					}
					list.Add(ComponentType.FromTypeIndex(typeIndex2));
				}
				result.Add(entityManager.EntityManager.CreateArchetypeWithoutSimulateComponent(list.GetUnsafePtr(), list.Length));
			}
			list.Dispose();
			return result;
		}

		private static NativeArray<TypeIndex> ReadTypeArray(BinaryReader reader, DotsSerializationReader dotsReader)
		{
			bool isNameLoaded = false;
			bool hasTypesName = false;
			UnsafeParallelHashMap<ulong, int> namesFromStableHash = default(UnsafeParallelHashMap<ulong, int>);
			StringTableReaderHandle stringStable = default(StringTableReaderHandle);
			int num = reader.ReadInt();
			NativeArray<TypeIndex> result = new NativeArray<TypeIndex>(num, Allocator.Temp);
			for (int i = 0; i < num; i++)
			{
				ulong num2 = reader.ReadULong();
				TypeIndex typeIndex = TypeManager.GetTypeIndex(StableTypeHash.GetTypeFromTypeHash(num2));
				if (typeIndex == TypeIndex.Null)
				{
					if (!GetTypeName(num2, out var name))
					{
						throw new ArgumentException("Cannot find TypeIndex for type hash " + num2 + ". Check in the debug file ExportedTypes.log of your project Logs folder (<projectName>/Logs) the corresponding Component type name for the type hash " + num2 + ". And ensure your runtime depends on all assemblies defining the Component types your data uses.");
					}
					throw new ArgumentException($"Cannot find Type {name} for type hash {num2.ToString()}. Ensure your runtime depends on all assemblies defining the Component types your data uses.");
				}
				result[i] = typeIndex;
			}
			if (hasTypesName)
			{
				namesFromStableHash.Dispose();
				stringStable.Dispose();
			}
			return result;
			bool GetTypeName(ulong stableHash, out FixedString512Bytes reference)
			{
				if (!isNameLoaded)
				{
					isNameLoaded = true;
					DotsSerializationReader.NodeHandle nodeHandle = dotsReader.RootNode.FindNode(DebugSectionNodeType, 2);
					if (nodeHandle.IsValid)
					{
						hasTypesName = true;
						stringStable = dotsReader.OpenStringTableNode(nodeHandle.FindNode<Unity.Entities.Serialization.DotsSerialization.StringTableNode>());
						DotsSerializationReader.NodeHandle nodeHandle2 = nodeHandle.FindNode<Unity.Entities.Serialization.DotsSerialization.TypeNamesNode>();
						int typeCount = nodeHandle2.As<Unity.Entities.Serialization.DotsSerialization.TypeNamesNode>().TypeCount;
						namesFromStableHash = new UnsafeParallelHashMap<ulong, int>(typeCount, Allocator.Temp);
						using DotsSerializationReader.ReaderHandle readerHandle = nodeHandle2.GetReaderHandle();
						BinaryReader reader2 = readerHandle.Reader;
						for (int j = 0; j < typeCount; j++)
						{
							namesFromStableHash.Add(reader2.ReadULong(), reader2.ReadInt());
						}
					}
				}
				if (!hasTypesName)
				{
					reference = default(FixedString512Bytes);
					return false;
				}
				reference = stringStable.GetString512(namesFromStableHash[stableHash]);
				return true;
			}
		}

		internal unsafe static UnsafePtrList<Archetype> GetAllArchetypes(EntityComponentStore* entityComponentStore, AllocatorManager.AllocatorHandle allocator)
		{
			int num = 0;
			for (int i = 0; i < entityComponentStore->m_Archetypes.Length; i++)
			{
				Archetype* ptr = entityComponentStore->m_Archetypes.Ptr[i];
				if (ptr->EntityCount > 0 && !ptr->HasSystemInstanceComponents)
				{
					num++;
				}
			}
			UnsafePtrList<Archetype> result = new UnsafePtrList<Archetype>(num, allocator);
			result.Resize(num);
			num = 0;
			for (int j = 0; j < entityComponentStore->m_Archetypes.Length; j++)
			{
				Archetype* ptr2 = entityComponentStore->m_Archetypes.Ptr[j];
				if (ptr2->EntityCount > 0 && !ptr2->HasSystemInstanceComponents)
				{
					result.Ptr[num++] = entityComponentStore->m_Archetypes.Ptr[j];
				}
			}
			NativeSortExtension.Sort((IntPtr*)result.Ptr, result.Length, default(StableArchetypeCompare));
			return result;
		}

		public static Entity GetSceneSectionEntity(int sectionIndex, EntityManager manager, ref EntityQuery cachedSceneSectionEntityQuery, bool createIfMissing = true)
		{
			if (cachedSceneSectionEntityQuery == default(EntityQuery))
			{
				cachedSceneSectionEntityQuery = manager.CreateEntityQuery(new EntityQueryBuilder(Allocator.Temp).WithAll<SectionMetadataSetup>());
			}
			SectionMetadataSetup sectionMetadataSetup = new SectionMetadataSetup
			{
				SceneSectionIndex = sectionIndex
			};
			cachedSceneSectionEntityQuery.SetSharedComponentFilter(sectionMetadataSetup);
			using NativeArray<Entity> nativeArray = cachedSceneSectionEntityQuery.ToEntityArray(Allocator.TempJob);
			if (nativeArray.Length == 0)
			{
				if (!createIfMissing)
				{
					return Entity.Null;
				}
				Entity entity = manager.CreateEntity();
				manager.AddSharedComponent(entity, sectionMetadataSetup);
				return entity;
			}
			if (nativeArray.Length == 1)
			{
				return nativeArray[0];
			}
			throw new InvalidOperationException($"Multiple scene section entities with section index {sectionIndex} found");
		}

		private unsafe static void FillReadCommands(DotsSerializationReader dotsReader, UnsafeList<ReadCommand>* readCommands, out WorldDeserializationStatus status)
		{
			status = default(WorldDeserializationStatus);
			DotsSerializationReader.NodeHandle nodeHandle = dotsReader.RootNode.FindNode(WorldNodeType);
			DotsSerializationReader.NodeHandle nodeHandle2 = nodeHandle.FindNode(ArchetypesNodeType);
			if (!nodeHandle2.IsValid)
			{
				throw new InvalidOperationException("Binary entity scene file must contain a ArchetypesNodeType");
			}
			status.ArchetypePrefetchState = nodeHandle2.PrefetchRawDataRead(out var readCommand);
			readCommands->Add(in readCommand);
			if (nodeHandle.TryFindNode(BlobAssetsNodeType, out var node))
			{
				status.BlobAssetSize = (int)node.DataSize;
				status.BlobAssetBuffer = UnsafeUtility.Malloc(status.BlobAssetSize, 16, Allocator.Persistent);
				ReadCommand value = new ReadCommand
				{
					Buffer = status.BlobAssetBuffer,
					Offset = node.DataStartingOffset,
					Size = status.BlobAssetSize
				};
				readCommands->Add(in value);
			}
			DotsSerializationReader.NodeHandle nodeHandle3 = nodeHandle.FindNode(SharedAndManagedComponentsNodeType);
			if (!nodeHandle3.IsValid)
			{
				throw new InvalidOperationException("Binary entity scene file must contain a SharedAndManagedComponentsNodeType");
			}
			status.SharedComponentPrefetchState = nodeHandle3.PrefetchRawDataRead(out var readCommand2);
			readCommands->Add(in readCommand2);
			DotsSerializationReader.NodeHandle nodeHandle4 = nodeHandle.FindNode(EnabledBitsNodeType);
			if (!nodeHandle4.IsValid)
			{
				throw new InvalidOperationException("Binary entity scene file must contain an EnabledBitsNodeType");
			}
			status.EnabledBitsPrefetchState = nodeHandle4.PrefetchRawDataRead(out var readCommand3);
			readCommands->Add(in readCommand3);
			DotsSerializationReader.NodeHandle nodeHandle5 = nodeHandle.FindNode(ChunksNodeType);
			if (!nodeHandle5.IsValid)
			{
				throw new InvalidOperationException("Binary entity scene file must contain a ChunksNodeType");
			}
			int num = (int)(nodeHandle5.DataSize / 16384);
			long dataStartingOffset = nodeHandle5.DataStartingOffset;
			UnsafeList<MegaChunkInfo> megaChunkInfoList = new UnsafeList<MegaChunkInfo>(8, Allocator.Persistent);
			if (SerializeUtilityInterop.AllocAndQueueReadChunkCommands(dataStartingOffset, num, &megaChunkInfoList, readCommands) != num)
			{
				throw new Exception("Contiguous Chunk allocation failed");
			}
			status.MegaChunkInfoList = megaChunkInfoList;
			status.TotalChunkCount = num;
			DotsSerializationReader.NodeHandle nodeHandle6 = nodeHandle.FindNode(BufferDataNodeType);
			if (!nodeHandle6.IsValid)
			{
				throw new InvalidOperationException("Binary entity scene file must contain a BufferDataNodeType");
			}
			status.BufferElementPrefetchState = nodeHandle6.PrefetchRawDataRead(out var readCommand4);
			readCommands->Add(in readCommand4);
			if (nodeHandle.TryFindNode(PrefabNodeType, out var node2))
			{
				status.PrefabPrefetchState = node2.PrefetchRawDataRead(out var readCommand5);
				readCommands->Add(in readCommand5);
			}
		}

		internal unsafe static ReadHandle BeginDeserializeWorld(string serializationFilePathName, DotsSerializationReader dotsReader, out WorldDeserializationStatus status, out UnsafeList<ReadCommand> readCommands)
		{
			UnsafeList<ReadCommand> unsafeList = new UnsafeList<ReadCommand>(1, Allocator.Persistent);
			FillReadCommands(dotsReader, &unsafeList, out status);
			readCommands = unsafeList;
			return AsyncReadManager.Read(serializationFilePathName, readCommands.Ptr, (uint)readCommands.Length, "", 0uL);
		}

		internal unsafe static void EndDeserializeWorld(ExclusiveEntityTransaction manager, DotsSerializationReader dotsReader, ref WorldDeserializationStatus status, out WorldDeserializationResult deserializationResult, object[] unityObjects = null)
		{
			deserializationResult = default(WorldDeserializationResult);
			EntityDataAccess* checkedEntityDataAccess = manager.EntityManager.GetCheckedEntityDataAccess();
			EntityComponentStore* entityComponentStore = checkedEntityDataAccess->EntityComponentStore;
			ManagedComponentStore managedComponentStore = checkedEntityDataAccess->ManagedComponentStore;
			if (entityComponentStore->CountEntities() != 0)
			{
				using (EntityQuery entityQuery = manager.EntityManager.CreateEntityQuery(ComponentType.ReadWrite<SystemInstance>()))
				{
					if (!entityQuery.IsEmptyIgnoreFilter)
					{
						throw new ArgumentException("DeserializeWorld can only be used on completely empty World. Please create a new empty World and add Systems after loading is complete instead.");
					}
				}
				if (entityComponentStore->CountEntities() != 0)
				{
					throw new ArgumentException("DeserializeWorld can only be used on completely empty EntityManager. Please create a new empty World and use EntityManager.MoveEntitiesFrom to move the loaded entities into the destination world instead.");
				}
			}
			NativeList<int> nativeList = new NativeList<int>(Allocator.Temp);
			BlobAssetOwner componentData = default(BlobAssetOwner);
			NativeArray<TypeIndex> types;
			UnsafeList<EntityArchetype> unsafeList;
			int totalEntityCount;
			using (MemoryBinaryReader reader = status.ArchetypePrefetchState.CreateStream())
			{
				types = ReadTypeArray(reader, dotsReader);
				unsafeList = ReadArchetypes(reader, types, manager, out totalEntityCount);
			}
			int blobAssetSize = status.BlobAssetSize;
			void* blobAssetBuffer = status.BlobAssetBuffer;
			if (blobAssetSize != 0)
			{
				componentData = new BlobAssetOwner(blobAssetBuffer, status.BlobAssetSize);
			}
			UnsafeList<ArchetypeChunk> unsafeList2 = new UnsafeList<ArchetypeChunk>(32, Allocator.Temp);
			MemoryBinaryReader memoryBinaryReader = status.SharedComponentPrefetchState.CreateStream();
			int num = memoryBinaryReader.ReadInt();
			NativeArray<int> nativeArray = new NativeArray<int>(num, Allocator.Temp);
			memoryBinaryReader.ReadArray(nativeArray, num);
			nativeList.Add(0);
			int num2 = ReadUnmanagedSharedComponents(manager, memoryBinaryReader, nativeList);
			int num3 = ReadManagedSharedComponents(manager, memoryBinaryReader, nativeList, unityObjects, blobAssetBuffer);
			int num4 = num2 + num3;
			memoryBinaryReader.Dispose();
			byte* buffer = (byte*)status.EnabledBitsPrefetchState._buffer;
			int num5 = *(int*)buffer;
			buffer += 4;
			int* enabledBitsHierarchicalData = (int*)(buffer + num5) + 1;
			SerializeUtilityInterop.AllocateConsecutiveEntitiesForLoading(entityComponentStore, totalEntityCount);
			int totalChunkCount = status.TotalChunkCount;
			UnsafeList<ArchetypeChunk> unsafeList3 = new UnsafeList<ArchetypeChunk>(totalChunkCount, Allocator.Temp);
			using (BurstableMemoryBinaryReader burstableMemoryBinaryReader = (BurstableMemoryBinaryReader)status.BufferElementPrefetchState.CreateStream())
			{
				BurstableMemoryBinaryReader bufferReader = burstableMemoryBinaryReader;
				NativeArray<int> instanceIds = new NativeArray<int>(0, Allocator.Temp);
				NativeArray<Entity> nativeArray2 = default(NativeArray<Entity>);
				SerializeUtilityInterop.ImportChunks((WorldDeserializationStatus*)UnsafeUtility.AddressOf(ref status), ref bufferReader, &unsafeList, (int*)nativeArray.GetUnsafePtr(), num4, nativeList.GetUnsafePtr(), &unsafeList2, buffer, enabledBitsHierarchicalData, entityComponentStore, ref instanceIds, &unsafeList3, (Entity*)(nativeArray2.IsCreated ? nativeArray2.GetUnsafePtr() : null), nativeArray2.Length, ref deserializationResult.PrefabRoot);
				instanceIds.Dispose();
				status.BlobAssetBuffer = null;
				for (int i = 0; i < unsafeList3.Length; i++)
				{
					manager.SetComponentData(unsafeList3[i].m_Chunk.MetaChunkEntity, new ChunkHeader
					{
						ArchetypeChunk = unsafeList3[i]
					});
				}
				unsafeList3.Dispose();
				unsafeList.Dispose();
			}
			managedComponentStore.Playback(ref entityComponentStore->ManagedChangesTracker);
			entityComponentStore->InvalidateChunkListCacheForChangedArchetypes();
			if (blobAssetSize != 0)
			{
				NativeArray<ArchetypeChunk> nativeArray3 = new NativeArray<ArchetypeChunk>(unsafeList2.Length, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
				UnsafeUtility.MemCpy(nativeArray3.GetUnsafePtr(), unsafeList2.Ptr, sizeof(ArchetypeChunk) * unsafeList2.Length);
				manager.AddSharedComponent(nativeArray3, componentData);
				unsafeList2.Dispose();
				nativeArray3.Dispose();
			}
			if (status.PrefabPrefetchState._buffer != null)
			{
				if (status.PrefabPrefetchState._size != sizeof(Entity))
				{
					throw new InvalidOperationException($"Internal deserialization error: Unexpected size of PrefabPrefetchState Expected:{sizeof(Entity)} Actual:{status.PrefabPrefetchState._size}");
				}
				deserializationResult.PrefabRoot = *(Entity*)status.PrefabPrefetchState._buffer;
			}
			status.Dispose();
			componentData.Release();
			types.Dispose();
			for (int j = 0; j < num4; j++)
			{
				int sharedComponentIndex = nativeList[j + 1];
				checkedEntityDataAccess->RemoveSharedComponentReference(sharedComponentIndex);
			}
			nativeList.Dispose();
		}

		public static void DeserializeWorld(ExclusiveEntityTransaction manager, BinaryReader reader, object[] unityObjects = null)
		{
			DeserializeWorldInternal(manager, reader, out var _, unityObjects);
		}

		internal unsafe static void DeserializeWorldInternal(ExclusiveEntityTransaction manager, BinaryReader reader, out WorldDeserializationResult deserializationResult, object[] unityObjects = null)
		{
			if (reader is StreamBinaryReader)
			{
				using (DotsSerializationReader dotsReader = DotsSerialization.CreateReader(reader))
				{
					BeginDeserializeWorld(((StreamBinaryReader)reader).FilePath, dotsReader, out var status, out var readCommands).JobHandle.Complete();
					readCommands.Dispose();
					EndDeserializeWorld(manager, dotsReader, ref status, out deserializationResult, unityObjects);
					return;
				}
			}
			using DotsSerializationReader dotsReader2 = DotsSerialization.CreateReader(reader);
			UnsafeList<ReadCommand> unsafeList = new UnsafeList<ReadCommand>(1, Allocator.Temp);
			FillReadCommands(dotsReader2, &unsafeList, out var status2);
			for (int i = 0; i < unsafeList.Length; i++)
			{
				reader.Position = unsafeList[i].Offset;
				reader.ReadBytes(unsafeList[i].Buffer, (int)unsafeList[i].Size);
			}
			EndDeserializeWorld(manager, dotsReader2, ref status2, out deserializationResult, unityObjects);
		}

		private unsafe static int ReadUnmanagedSharedComponents(ExclusiveEntityTransaction manager, BinaryReader reader, NativeList<int> sharedComponentRemap)
		{
			NativeArray<SharedComponentRecord> sharedComponentRecordArray;
			int result = ReadSharedComponentMetadata(reader, out sharedComponentRecordArray);
			int num = reader.ReadInt();
			UnsafeAppendBuffer unsafeAppendBuffer = new UnsafeAppendBuffer(num, 16, Allocator.Temp);
			try
			{
				unsafeAppendBuffer.ResizeUninitialized(num);
				reader.ReadBytes(unsafeAppendBuffer.Ptr, num);
				UnsafeAppendBuffer.Reader reader2 = unsafeAppendBuffer.AsReader();
				EntityDataAccess* checkedEntityDataAccess = manager.EntityManager.GetCheckedEntityDataAccess();
				for (int i = 0; i < sharedComponentRecordArray.Length; i++)
				{
					SharedComponentRecord sharedComponentRecord = sharedComponentRecordArray[i];
					TypeIndex typeIndexFromStableTypeHash = TypeManager.GetTypeIndexFromStableTypeHash(sharedComponentRecord.StableTypeHash);
					void* ptr = reader2.ReadNext(sharedComponentRecord.ComponentSize);
					int hashCode = TypeManager.GetHashCode(ptr, typeIndexFromStableTypeHash);
					sharedComponentRemap.Add(checkedEntityDataAccess->EntityComponentStore->InsertSharedComponent_Unmanaged(typeIndexFromStableTypeHash, hashCode, ptr, null));
				}
				return result;
			}
			finally
			{
				((IDisposable)unsafeAppendBuffer/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private unsafe static int ReadManagedSharedComponents(ExclusiveEntityTransaction manager, BinaryReader reader, NativeList<int> sharedComponentRemap, object[] unityObjects, void* blobAssetBuffer)
		{
			EntityDataAccess* checkedEntityDataAccess = manager.EntityManager.GetCheckedEntityDataAccess();
			EntityComponentStore* entityComponentStore = checkedEntityDataAccess->EntityComponentStore;
			ManagedComponentStore managedComponentStore = checkedEntityDataAccess->ManagedComponentStore;
			NativeArray<SharedComponentRecord> sharedComponentRecordArray;
			int result = ReadSharedComponentMetadata(reader, out sharedComponentRecordArray);
			int num = reader.ReadInt();
			int num2 = reader.ReadInt();
			UnsafeAppendBuffer unsafeAppendBuffer = new UnsafeAppendBuffer(num, 16, Allocator.Temp);
			unsafeAppendBuffer.ResizeUninitialized(num);
			reader.ReadBytes(unsafeAppendBuffer.Ptr, num);
			UnsafeAppendBuffer.Reader reader2 = unsafeAppendBuffer.AsReader();
			ManagedObjectBinaryReader managedObjectBinaryReader = new ManagedObjectBinaryReader(&reader2, (UnityEngine.Object[])unityObjects);
			managedObjectBinaryReader.AddAdapter(new ManagedObjectReaderAdapter((byte*)blobAssetBuffer));
			ReadSharedComponents(manager, ref reader2, managedObjectBinaryReader, num, sharedComponentRemap, sharedComponentRecordArray);
			managedComponentStore.ResetManagedComponentStoreForDeserialization(num2, ref *entityComponentStore);
			for (int i = 0; i < num2; i++)
			{
				Type type = TypeManager.GetTypeInfo(TypeManager.GetTypeIndexFromStableTypeHash(reader2.ReadNext<ulong>())).Type;
				object componentObject = managedObjectBinaryReader.ReadObject(type);
				managedComponentStore.SetManagedComponentValue(i + 1, componentObject);
			}
			unsafeAppendBuffer.Dispose();
			return result;
		}

		private unsafe static void ReadSharedComponents(ExclusiveEntityTransaction manager, ref UnsafeAppendBuffer.Reader reader, ManagedObjectBinaryReader managedDataReader, int expectedReadSize, NativeList<int> sharedComponentRemap, NativeArray<SharedComponentRecord> sharedComponentRecordArray)
		{
			EntityDataAccess* checkedEntityDataAccess = manager.EntityManager.GetCheckedEntityDataAccess();
			for (int i = 0; i < sharedComponentRecordArray.Length; i++)
			{
				TypeIndex typeIndex = TypeManager.GetTypeIndex(StableTypeHash.GetTypeFromTypeHash(sharedComponentRecordArray[i].StableTypeHash));
				ref readonly TypeManager.TypeInfo typeInfo = ref TypeManager.GetTypeInfo(typeIndex);
				object obj = managedDataReader.ReadObject(typeInfo.Type);
				int hashCode = TypeManager.GetHashCode(obj, typeInfo.TypeIndex);
				sharedComponentRemap.Add(checkedEntityDataAccess->InsertSharedComponentAssumeNonDefault(typeIndex, hashCode, obj));
			}
		}

		private static bool IsTypeValidForSerialization(Type type, HashSet<Type> validTypes)
		{
			if (validTypes.Contains(type))
			{
				return true;
			}
			if (type.GetCustomAttribute<ChunkSerializableAttribute>() != null)
			{
				return true;
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			foreach (FieldInfo fieldInfo in fields)
			{
				if (!fieldInfo.IsStatic)
				{
					if (fieldInfo.FieldType.IsPointer || fieldInfo.FieldType == typeof(UIntPtr) || fieldInfo.FieldType == typeof(IntPtr))
					{
						return false;
					}
					if (fieldInfo.FieldType.IsValueType && !fieldInfo.FieldType.IsPrimitive && !fieldInfo.FieldType.IsEnum && !IsTypeValidForSerialization(fieldInfo.FieldType, validTypes))
					{
						return false;
					}
				}
			}
			validTypes.Add(type);
			return true;
		}

		[BurstDiscard]
		private static void ValidateTypeForSerialization(TypeManager.TypeInfo typeInfo)
		{
			if (typeInfo.TypeIndex.IsChunkSerializable)
			{
				return;
			}
			if (typeInfo.Category == TypeManager.TypeCategory.ISharedComponentData && typeInfo.TypeIndex.HasEntityReferences)
			{
				throw new ArgumentException($"Shared component type '{typeInfo.Type}' might contain a (potentially nested) Entity field. " + "Serializing of shared components with Entity fields is not supported as Entity references are not patched when deserializing. If for whatever reason this component should still be serialized, add the [ChunkSerializable] attribute to your type to bypass this error.");
			}
			throw new ArgumentException($"Blittable component type '{typeInfo.Type}' contains a (potentially nested) pointer field. " + "Serializing bare pointers will likely lead to runtime errors. Remove this field and consider serializing the data it points to another way such as by using a BlobAssetReference or a [Serializable] ISharedComponent. If for whatever reason the pointer field should in fact be serialized, add the [ChunkSerializable] attribute to your type to bypass this error.");
		}

		private static int ReadSharedComponentMetadata(BinaryReader reader, out NativeArray<SharedComponentRecord> sharedComponentRecordArray)
		{
			int num = reader.ReadInt();
			sharedComponentRecordArray = new NativeArray<SharedComponentRecord>(num, Allocator.Temp);
			reader.ReadArray(sharedComponentRecordArray, num);
			return num;
		}
	}
}
