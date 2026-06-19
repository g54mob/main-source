using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Pug.ECS.Serialization.DOTS100;
using Pug.Properties;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Entities.LowLevel.Unsafe;
using UnityEngine;

public static class SerializedWorldPatchFileLoader
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct DeserializeTargetTempChunkTag : IComponentData, IQueryTypeParameter
	{
	}

	public static bool TryLoadPatchedWorld(string filePath, World targetWorld)
	{
		if (!File.Exists(filePath))
		{
			Debug.LogError("File to load not found for patching: " + filePath);
			return false;
		}
		try
		{
			using FileStream fileStream = new FileStream(filePath, FileMode.Open);
			using System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fileStream);
			ReadBinary(targetWorld, binaryReader);
			fileStream.Close();
			binaryReader.Close();
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
			return false;
		}
		return true;
	}

	private unsafe static void ReadBinary(World targetWorld, System.IO.BinaryReader reader)
	{
		EntityManager entityManager = targetWorld.EntityManager;
		if (reader.ReadInt32() != PatcherCommon.PatcherVersion)
		{
			throw new Exception("Version mismatch");
		}
		int num = reader.ReadInt32();
		for (int i = 0; i < num; i++)
		{
			ReadChunkFromBinary(targetWorld, entityManager, reader);
		}
		int num2 = reader.ReadInt32();
		Dictionary<int, BlobAssetReference<PropertyLookupBlob>> dictionary = new Dictionary<int, BlobAssetReference<PropertyLookupBlob>>();
		for (int j = 0; j < num2; j++)
		{
			int key = reader.ReadInt32();
			int num3 = reader.ReadInt32();
			BlobAssetReference<PropertyLookupBlob> value = BlobAssetExtensions.CreateUninitializedBlobAsset<PropertyLookupBlob>(num3, Allocator.Persistent);
			Span<byte> buffer = new Span<byte>(value.GetUnsafePtr(), num3);
			reader.Read(buffer);
			dictionary.Add(key, value);
		}
		ReplaceBlobAssets(entityManager, dictionary);
	}

	private unsafe static void ReplaceBlobAssets(EntityManager entityManager, Dictionary<int, BlobAssetReference<PropertyLookupBlob>> blobLookup)
	{
		using (EntityQuery entityQuery = entityManager.CreateEntityQuery(typeof(ObjectPropertiesSerializedCD)))
		{
			using NativeArray<Entity> nativeArray = entityQuery.ToEntityArray(Allocator.Temp);
			for (int i = 0; i < nativeArray.Length; i++)
			{
				ObjectPropertiesSerializedCD componentData = entityManager.GetComponentData<ObjectPropertiesSerializedCD>(nativeArray[i]);
				int num = (int)componentData.ObjectPropertyLookup.GetPropertyLookup().m_data.m_Ptr;
				if (blobLookup.TryGetValue(num, out var value))
				{
					componentData.ObjectPropertyLookup = new PropertyLookup(value);
					entityManager.SetComponentData(nativeArray[i], componentData);
				}
				else if (num != 0)
				{
					Debug.LogError("Could not find pointer to lookup");
				}
			}
		}
		using EntityQuery entityQuery2 = entityManager.CreateEntityQuery(typeof(RemovedObjectPropertiesSerializedCD));
		using NativeArray<Entity> nativeArray2 = entityQuery2.ToEntityArray(Allocator.Temp);
		for (int j = 0; j < nativeArray2.Length; j++)
		{
			RemovedObjectPropertiesSerializedCD componentData2 = entityManager.GetComponentData<RemovedObjectPropertiesSerializedCD>(nativeArray2[j]);
			int num2 = (int)componentData2.ObjectPropertyLookup.GetPropertyLookup().m_data.m_Ptr;
			if (blobLookup.TryGetValue(num2, out var value2))
			{
				componentData2.ObjectPropertyLookup = new PropertyLookup(value2);
				entityManager.SetComponentData(nativeArray2[j], componentData2);
			}
			else if (num2 != 0)
			{
				Debug.LogError("Could not find pointer to lookup");
			}
		}
	}

	private static void ReadChunkFromBinary(World targetWorld, EntityManager entityManager, System.IO.BinaryReader reader)
	{
		int num = reader.ReadInt32();
		int num2 = reader.ReadInt32();
		NativeArray<ComponentType> types = new NativeArray<ComponentType>(num2 + 1, Allocator.Temp);
		for (int i = 0; i < num2; i++)
		{
			ComponentType value = ComponentType.FromTypeIndex(TypeManager.GetTypeIndex(StableTypeHash.GetTypeFromTypeHash(reader.ReadUInt64())));
			if (value.GetManagedType() == null)
			{
				throw new Exception("Cannot lookup component type");
			}
			types[i] = value;
		}
		types[num2] = typeof(DeserializeTargetTempChunkTag);
		EntityArchetype archetype = entityManager.CreateArchetype(types);
		entityManager.CreateEntity(archetype, num, Allocator.Temp);
		EntityQuery entityQuery = entityManager.CreateEntityQuery(types.ToArray());
		NativeArray<ArchetypeChunk> targetChunks = entityQuery.CreateArchetypeChunkArray(Allocator.Temp);
		for (int j = 0; j < num2; j++)
		{
			ComponentType componentType = types[j];
			if (componentType.IsBuffer)
			{
				ReadBufferData(componentType, entityManager, num, reader, targetChunks);
			}
			else if (!componentType.IsZeroSized)
			{
				ReadComponentData(componentType, entityManager, num, reader, targetChunks);
			}
			else if (!componentType.IsZeroSized)
			{
				Debug.LogError($"Unsupported type {componentType}");
			}
		}
		entityManager.RemoveComponent<DeserializeTargetTempChunkTag>(entityQuery);
	}

	private unsafe static void ReadBufferData(ComponentType componentType, EntityManager entityManager, int totalEntities, System.IO.BinaryReader reader, NativeArray<ArchetypeChunk> targetChunks)
	{
		int elementSize = TypeManager.GetTypeInfo(componentType.TypeIndex).ElementSize;
		DynamicComponentTypeHandle chunkBufferTypeHandle = entityManager.GetDynamicComponentTypeHandle(componentType);
		int num = 0;
		for (int i = 0; i < targetChunks.Length; i++)
		{
			ArchetypeChunk archetypeChunk = targetChunks[i];
			int count = archetypeChunk.Count;
			for (int j = 0; j < count; j++)
			{
				int num2 = reader.ReadInt32();
				UnsafeUntypedBufferAccessor untypedBufferAccessor = archetypeChunk.GetUntypedBufferAccessor(ref chunkBufferTypeHandle);
				untypedBufferAccessor.ResizeUninitialized(j, num2);
				void* unsafePtr = untypedBufferAccessor.GetUnsafePtr(j);
				Span<byte> buffer = new Span<byte>(unsafePtr, num2 * elementSize);
				if (reader.Read(buffer) != buffer.Length)
				{
					throw new Exception("Error reading length");
				}
				num++;
			}
		}
		if (totalEntities != num)
		{
			throw new Exception("Error reading length");
		}
	}

	private unsafe static void ReadComponentData(ComponentType componentType, EntityManager entityManager, int totalEntities, System.IO.BinaryReader reader, NativeArray<ArchetypeChunk> targetChunks)
	{
		int elementSize = TypeManager.GetTypeInfo(componentType.TypeIndex).ElementSize;
		int num = elementSize * totalEntities;
		for (int i = 0; i < targetChunks.Length; i++)
		{
			ArchetypeChunk archetypeChunk = targetChunks[i];
			DynamicComponentTypeHandle dynamicComponentTypeHandle = entityManager.GetDynamicComponentTypeHandle(componentType);
			NativeArray<byte> dynamicComponentDataArrayReinterpret = archetypeChunk.GetDynamicComponentDataArrayReinterpret<byte>(dynamicComponentTypeHandle, elementSize);
			Span<byte> buffer = new Span<byte>(dynamicComponentDataArrayReinterpret.GetUnsafePtr(), dynamicComponentDataArrayReinterpret.Length);
			int num2 = reader.Read(buffer);
			if (num2 != buffer.Length)
			{
				throw new Exception("Error reading length");
			}
			num -= num2;
		}
		if (num != 0)
		{
			throw new Exception("Error reading length");
		}
	}
}
