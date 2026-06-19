using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AOT;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.IO.LowLevel.Unsafe;

namespace Pug.ECS.Serialization.DOTS100
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[BurstCompile]
	internal struct SerializeUtilityInterop
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void AllocateConsecutiveEntitiesForLoading_0000007F_0024PostfixBurstDelegate(EntityComponentStore* store, int entityCount);

		internal static class AllocateConsecutiveEntitiesForLoading_0000007F_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<AllocateConsecutiveEntitiesForLoading_0000007F_0024PostfixBurstDelegate>(AllocateConsecutiveEntitiesForLoading).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(EntityComponentStore* store, int entityCount)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<EntityComponentStore*, int, void>)functionPointer)(store, entityCount);
						return;
					}
				}
				AllocateConsecutiveEntitiesForLoading_0024BurstManaged(store, entityCount);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate int AllocAndQueueReadChunkCommands_00000080_0024PostfixBurstDelegate(long readOffset, int totalChunkCount, UnsafeList<SerializeUtility.MegaChunkInfo>* megaChunkInfo, UnsafeList<ReadCommand>* readCommands);

		internal static class AllocAndQueueReadChunkCommands_00000080_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<AllocAndQueueReadChunkCommands_00000080_0024PostfixBurstDelegate>(AllocAndQueueReadChunkCommands).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static int Invoke(long readOffset, int totalChunkCount, UnsafeList<SerializeUtility.MegaChunkInfo>* megaChunkInfo, UnsafeList<ReadCommand>* readCommands)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						return ((delegate* unmanaged[Cdecl]<long, int, UnsafeList<SerializeUtility.MegaChunkInfo>*, UnsafeList<ReadCommand>*, int>)functionPointer)(readOffset, totalChunkCount, megaChunkInfo, readCommands);
					}
				}
				return AllocAndQueueReadChunkCommands_0024BurstManaged(readOffset, totalChunkCount, megaChunkInfo, readCommands);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void AddExistingChunk_00000081_0024PostfixBurstDelegate(Archetype* archetype, ChunkIndex chunk, int* sharedComponentIndices, byte* enabledBitsValuesForChunk, int* perComponentDisabledBitCount);

		internal static class AddExistingChunk_00000081_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<AddExistingChunk_00000081_0024PostfixBurstDelegate>(AddExistingChunk).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(Archetype* archetype, ChunkIndex chunk, int* sharedComponentIndices, byte* enabledBitsValuesForChunk, int* perComponentDisabledBitCount)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<Archetype*, ChunkIndex, int*, byte*, int*, void>)functionPointer)(archetype, chunk, sharedComponentIndices, enabledBitsValuesForChunk, perComponentDisabledBitCount);
						return;
					}
				}
				AddExistingChunk_0024BurstManaged(archetype, chunk, sharedComponentIndices, enabledBitsValuesForChunk, perComponentDisabledBitCount);
			}
		}

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		internal unsafe delegate void ImportChunks_00000082_0024PostfixBurstDelegate(SerializeUtility.WorldDeserializationStatus* status, ref BurstableMemoryBinaryReader bufferReader, UnsafeList<EntityArchetype>* archetypes, int* sharedComponentArray, int numSharedComponents, int* sharedComponentRemap, UnsafeList<ArchetypeChunk>* blobAssetRefChunks, byte* componentEnabledBits, int* enabledBitsHierarchicalData, EntityComponentStore* ecs, ref NativeArray<int> instanceIds, UnsafeList<ArchetypeChunk>* chunksWithMetaChunkEntities, Entity* externalEntitiesReferences, int externalEntitiesRefCount, ref Entity prefabRoot);

		internal static class ImportChunks_00000082_0024BurstDirectCall
		{
			private static IntPtr Pointer;

			[BurstDiscard]
			private unsafe static void GetFunctionPointerDiscard(ref IntPtr P_0)
			{
				if (Pointer == (IntPtr)0)
				{
					Pointer = BurstCompiler.CompileFunctionPointer<ImportChunks_00000082_0024PostfixBurstDelegate>(ImportChunks).Value;
				}
				P_0 = Pointer;
			}

			private static IntPtr GetFunctionPointer()
			{
				nint result = 0;
				GetFunctionPointerDiscard(ref result);
				return result;
			}

			public unsafe static void Invoke(SerializeUtility.WorldDeserializationStatus* status, ref BurstableMemoryBinaryReader bufferReader, UnsafeList<EntityArchetype>* archetypes, int* sharedComponentArray, int numSharedComponents, int* sharedComponentRemap, UnsafeList<ArchetypeChunk>* blobAssetRefChunks, byte* componentEnabledBits, int* enabledBitsHierarchicalData, EntityComponentStore* ecs, ref NativeArray<int> instanceIds, UnsafeList<ArchetypeChunk>* chunksWithMetaChunkEntities, Entity* externalEntitiesReferences, int externalEntitiesRefCount, ref Entity prefabRoot)
			{
				if (BurstCompiler.IsEnabled)
				{
					IntPtr functionPointer = GetFunctionPointer();
					if (functionPointer != (IntPtr)0)
					{
						((delegate* unmanaged[Cdecl]<SerializeUtility.WorldDeserializationStatus*, ref BurstableMemoryBinaryReader, UnsafeList<EntityArchetype>*, int*, int, int*, UnsafeList<ArchetypeChunk>*, byte*, int*, EntityComponentStore*, ref NativeArray<int>, UnsafeList<ArchetypeChunk>*, Entity*, int, ref Entity, void>)functionPointer)(status, ref bufferReader, archetypes, sharedComponentArray, numSharedComponents, sharedComponentRemap, blobAssetRefChunks, componentEnabledBits, enabledBitsHierarchicalData, ecs, ref instanceIds, chunksWithMetaChunkEntities, externalEntitiesReferences, externalEntitiesRefCount, ref prefabRoot);
						return;
					}
				}
				ImportChunks_0024BurstManaged(status, ref bufferReader, archetypes, sharedComponentArray, numSharedComponents, sharedComponentRemap, blobAssetRefChunks, componentEnabledBits, enabledBitsHierarchicalData, ecs, ref instanceIds, chunksWithMetaChunkEntities, externalEntitiesReferences, externalEntitiesRefCount, ref prefabRoot);
			}
		}

		[BurstCompile]
		[AOT.MonoPInvokeCallback(typeof(Pug_002EECS_002ESerialization_002EDOTS100_002EAllocateConsecutiveEntitiesForLoading_0000007F_0024PostfixBurstDelegate))]
		internal unsafe static void AllocateConsecutiveEntitiesForLoading(EntityComponentStore* store, int entityCount)
		{
			AllocateConsecutiveEntitiesForLoading_0000007F_0024BurstDirectCall.Invoke(store, entityCount);
		}

		[BurstCompile]
		[AOT.MonoPInvokeCallback(typeof(Pug_002EECS_002ESerialization_002EDOTS100_002EAllocAndQueueReadChunkCommands_00000080_0024PostfixBurstDelegate))]
		internal unsafe static int AllocAndQueueReadChunkCommands(long readOffset, int totalChunkCount, UnsafeList<SerializeUtility.MegaChunkInfo>* megaChunkInfo, UnsafeList<ReadCommand>* readCommands)
		{
			return AllocAndQueueReadChunkCommands_00000080_0024BurstDirectCall.Invoke(readOffset, totalChunkCount, megaChunkInfo, readCommands);
		}

		[BurstCompile]
		[AOT.MonoPInvokeCallback(typeof(Pug_002EECS_002ESerialization_002EDOTS100_002EAddExistingChunk_00000081_0024PostfixBurstDelegate))]
		internal unsafe static void AddExistingChunk(Archetype* archetype, ChunkIndex chunk, int* sharedComponentIndices, byte* enabledBitsValuesForChunk, int* perComponentDisabledBitCount)
		{
			AddExistingChunk_00000081_0024BurstDirectCall.Invoke(archetype, chunk, sharedComponentIndices, enabledBitsValuesForChunk, perComponentDisabledBitCount);
		}

		[BurstCompile]
		[AOT.MonoPInvokeCallback(typeof(Pug_002EECS_002ESerialization_002EDOTS100_002EImportChunks_00000082_0024PostfixBurstDelegate))]
		internal unsafe static void ImportChunks(SerializeUtility.WorldDeserializationStatus* status, ref BurstableMemoryBinaryReader bufferReader, UnsafeList<EntityArchetype>* archetypes, int* sharedComponentArray, int numSharedComponents, int* sharedComponentRemap, UnsafeList<ArchetypeChunk>* blobAssetRefChunks, byte* componentEnabledBits, int* enabledBitsHierarchicalData, EntityComponentStore* ecs, ref NativeArray<int> instanceIds, UnsafeList<ArchetypeChunk>* chunksWithMetaChunkEntities, Entity* externalEntitiesReferences, int externalEntitiesRefCount, ref Entity prefabRoot)
		{
			ImportChunks_00000082_0024BurstDirectCall.Invoke(status, ref bufferReader, archetypes, sharedComponentArray, numSharedComponents, sharedComponentRemap, blobAssetRefChunks, componentEnabledBits, enabledBitsHierarchicalData, ecs, ref instanceIds, chunksWithMetaChunkEntities, externalEntitiesReferences, externalEntitiesRefCount, ref prefabRoot);
		}

		private unsafe static void RemapSharedComponentIndices(int* destValues, Archetype* archetype, int* remappedIndices, int* sourceValues)
		{
			int num = 0;
			for (int i = 1; i < archetype->TypesCount; i++)
			{
				int num2 = archetype->TypeMemoryOrderIndexToIndexInArchetype[i] - archetype->FirstSharedComponent;
				if (0 <= num2 && num2 < archetype->NumSharedComponents)
				{
					destValues[num2] = remappedIndices[sourceValues[num++]];
				}
			}
		}

		private unsafe static byte* OffsetFromPointer(void* ptr, int offset)
		{
			return (byte*)ptr + offset;
		}

		private unsafe static void PatchBlobAssetsInChunkAfterLoad(Archetype* archetype, byte* chunkBuffer, int entityCount, byte* allBlobAssetData)
		{
			int typesCount = archetype->TypesCount;
			for (int i = 0; i < typesCount; i++)
			{
				int num = archetype->TypeMemoryOrderIndexToIndexInArchetype[i];
				ComponentTypeInArchetype componentTypeInArchetype = archetype->Types[num];
				if (componentTypeInArchetype.IsZeroSized)
				{
					continue;
				}
				ref readonly TypeManager.TypeInfo typeInfo = ref TypeManager.GetTypeInfo(componentTypeInArchetype.TypeIndex);
				int blobAssetRefOffsetCount = typeInfo.BlobAssetRefOffsetCount;
				if (blobAssetRefOffsetCount == 0)
				{
					continue;
				}
				TypeManager.EntityOffsetInfo* blobAssetRefOffsets = TypeManager.GetBlobAssetRefOffsets(in typeInfo);
				int offset = archetype->Offsets[num];
				byte* ptr = OffsetFromPointer(chunkBuffer, offset);
				if (componentTypeInArchetype.IsBuffer)
				{
					BufferHeader* ptr2 = (BufferHeader*)ptr;
					int offset2 = archetype->SizeOfs[num];
					int elementSize = typeInfo.ElementSize;
					for (int j = 0; j < entityCount; j++)
					{
						byte* elementPointer = BufferHeader.GetElementPointer(ptr2);
						for (int k = 0; k < ptr2->Length; k++)
						{
							byte* ptr3 = elementPointer + k * elementSize;
							for (int l = 0; l < blobAssetRefOffsetCount; l++)
							{
								int offset3 = blobAssetRefOffsets[l].Offset;
								BlobAssetReferenceData* ptr4 = (BlobAssetReferenceData*)(ptr3 + offset3);
								int num2 = (int)ptr4->m_Ptr;
								byte* ptr5 = null;
								if (num2 != -1)
								{
									ptr5 = allBlobAssetData + num2;
								}
								ptr4->m_Ptr = ptr5;
							}
						}
						ptr2 = (BufferHeader*)OffsetFromPointer(ptr2, offset2);
					}
				}
				else
				{
					if (blobAssetRefOffsetCount <= 0)
					{
						continue;
					}
					int num3 = archetype->SizeOfs[num];
					byte* ptr6 = ptr + num3 * entityCount;
					for (byte* ptr7 = ptr; ptr7 < ptr6; ptr7 += num3)
					{
						for (int m = 0; m < blobAssetRefOffsetCount; m++)
						{
							int offset4 = blobAssetRefOffsets[m].Offset;
							BlobAssetReferenceData* ptr8 = (BlobAssetReferenceData*)(ptr7 + offset4);
							int num4 = (int)ptr8->m_Ptr;
							byte* ptr9 = null;
							if (num4 != -1)
							{
								ptr9 = allBlobAssetData + num4;
							}
							ptr8->m_Ptr = ptr9;
						}
					}
				}
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal unsafe static void AllocateConsecutiveEntitiesForLoading_0024BurstManaged(EntityComponentStore* store, int entityCount)
		{
			store->AllocateConsecutiveEntitiesForLoading(entityCount);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal unsafe static int AllocAndQueueReadChunkCommands_0024BurstManaged(long readOffset, int totalChunkCount, UnsafeList<SerializeUtility.MegaChunkInfo>* megaChunkInfo, UnsafeList<ReadCommand>* readCommands)
		{
			int num = 0;
			ReadCommand value = default(ReadCommand);
			while (totalChunkCount != num)
			{
				if (EntityComponentStore.AllocateContiguousChunk(totalChunkCount - num, out var chunk, out var actualCount) != 0)
				{
					return totalChunkCount;
				}
				value.Buffer = chunk.GetPtr();
				value.Offset = readOffset;
				value.Size = 16384 * actualCount;
				readCommands->Add(in value);
				megaChunkInfo->Add(new SerializeUtility.MegaChunkInfo(chunk, actualCount));
				num += actualCount;
				readOffset += 16384 * actualCount;
			}
			return totalChunkCount;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal unsafe static void AddExistingChunk_0024BurstManaged(Archetype* archetype, ChunkIndex chunk, int* sharedComponentIndices, byte* enabledBitsValuesForChunk, int* perComponentDisabledBitCount)
		{
			ChunkDataUtility.AddExistingChunk(archetype, chunk, sharedComponentIndices, enabledBitsValuesForChunk, perComponentDisabledBitCount);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		[BurstCompile]
		internal unsafe static void ImportChunks_0024BurstManaged(SerializeUtility.WorldDeserializationStatus* status, ref BurstableMemoryBinaryReader bufferReader, UnsafeList<EntityArchetype>* archetypes, int* sharedComponentArray, int numSharedComponents, int* sharedComponentRemap, UnsafeList<ArchetypeChunk>* blobAssetRefChunks, byte* componentEnabledBits, int* enabledBitsHierarchicalData, EntityComponentStore* ecs, ref NativeArray<int> instanceIds, UnsafeList<ArchetypeChunk>* chunksWithMetaChunkEntities, Entity* externalEntitiesReferences, int externalEntitiesRefCount, ref Entity prefabRoot)
		{
			int num = bufferReader.ReadInt();
			int totalChunkCount = status->TotalChunkCount;
			int blobAssetSize = status->BlobAssetSize;
			void* blobAssetBuffer = status->BlobAssetBuffer;
			if (status->TotalChunkCount != num)
			{
				throw new InvalidOperationException("Internal deserialization error: total chunk count doesn't match");
			}
			int num2 = 0;
			UnsafeList<SerializeUtility.MegaChunkInfo> megaChunkInfoList = status->MegaChunkInfoList;
			int length = megaChunkInfoList.Length;
			for (int i = 0; i < length; i++)
			{
				int megaChunkSize = megaChunkInfoList[i].MegaChunkSize;
				ChunkIndex megaChunkIndex = megaChunkInfoList[i].MegaChunkIndex;
				Chunk* ptr = megaChunkIndex.GetPtr();
				for (int j = 0; j < megaChunkSize; j++)
				{
					ChunkOld chunkOld = *(ChunkOld*)ptr;
					ptr->CountForSerialization = chunkOld.CountForSerialization;
					ptr->ListWithEmptySlotsIndex = chunkOld.ListWithEmptySlotsIndex;
					ptr->Flags = chunkOld.Flags;
					UnsafeUtility.MemSet((byte*)ptr + 40, 0, 24L);
					new ChunkIndex((int)megaChunkIndex + j);
					ptr = (Chunk*)((byte*)ptr + 16384);
				}
			}
			for (int k = 0; k < length; k++)
			{
				int megaChunkSize2 = megaChunkInfoList[k].MegaChunkSize;
				ChunkIndex megaChunkIndex2 = megaChunkInfoList[k].MegaChunkIndex;
				Chunk* ptr2 = megaChunkIndex2.GetPtr();
				for (int l = 0; l < megaChunkSize2; l++)
				{
					ChunkIndex chunkIndex = new ChunkIndex((int)megaChunkIndex2 + l);
					int num3 = (chunkIndex.Count = ptr2->CountForSerialization);
					ptr2 = (Chunk*)((byte*)ptr2 + 16384);
					num2 += num3;
				}
			}
			int num4 = 0;
			UnsafeList<SerializeUtility.MegaChunkInfo> megaChunkInfoList2 = status->MegaChunkInfoList;
			int num5 = megaChunkInfoList2[0].MegaChunkSize;
			ChunkIndex chunkIndex2 = megaChunkInfoList2[0].MegaChunkIndex;
			int num6 = 0;
			byte* ptr3 = componentEnabledBits;
			int* ptr4 = enabledBitsHierarchicalData;
			int* ptr5 = stackalloc int[16];
			for (int m = 0; m < totalChunkCount; m++)
			{
				Archetype* archetype = archetypes->ElementAt(chunkIndex2.GetPtr()->ArchetypeIndexForSerialization).Archetype;
				ecs->SetArchetype(chunkIndex2, archetype);
				int numSharedComponents2 = archetype->NumSharedComponents;
				int* ptr6 = sharedComponentArray + num6;
				for (int n = 0; n < numSharedComponents2; n++)
				{
					if (ptr6[n] > numSharedComponents)
					{
						throw new ArgumentException($"Archetype uses shared component at index {ptr6[n]} but only {numSharedComponents} are available, check if the shared scene has been properly loaded.");
					}
				}
				RemapSharedComponentIndices(ptr5, archetype, sharedComponentRemap, ptr6);
				num6 += numSharedComponents2;
				int num7 = bufferReader.ReadInt();
				if (num7 > 0)
				{
					for (int num8 = 0; num8 < num7; num8++)
					{
						int offset = bufferReader.ReadInt();
						int num9 = bufferReader.ReadInt();
						BufferHeader* ptr7 = (BufferHeader*)OffsetFromPointer(chunkIndex2.Buffer, offset);
						ptr7->Pointer = (byte*)UnsafeUtility.Malloc(num9, 8, Allocator.Persistent);
						bufferReader.ReadBytes(ptr7->Pointer, num9);
					}
				}
				if (blobAssetSize != 0 && archetype->HasBlobAssetRefs)
				{
					blobAssetRefChunks->Add(new ArchetypeChunk(chunkIndex2, ecs));
					PatchBlobAssetsInChunkAfterLoad(archetype, chunkIndex2.Buffer, chunkIndex2.Count, (byte*)blobAssetBuffer);
				}
				chunkIndex2.SequenceNumber = ecs->AllocateSequenceNumber();
				AddExistingChunk(archetype, chunkIndex2, ptr5, ptr3, ptr4);
				ptr3 += archetype->Chunks.ComponentEnabledBitsSizeTotalPerChunk;
				ptr4 += archetype->TypesCount;
				if (chunkIndex2.MetaChunkEntity != Entity.Null)
				{
					chunksWithMetaChunkEntities->Add(new ArchetypeChunk(chunkIndex2, ecs));
				}
				if (--num5 == 0 && m + 1 != totalChunkCount)
				{
					chunkIndex2 = megaChunkInfoList2[++num4].MegaChunkIndex;
					num5 = megaChunkInfoList2[num4].MegaChunkSize;
				}
				else
				{
					chunkIndex2 = new ChunkIndex((int)chunkIndex2 + 1);
				}
			}
		}
	}
}
