using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using UnityEngine;
using UnityEngine.Scripting;

public static class InventoryAuxDataSystemExtensions
{
	[Serializable]
	private struct JsonTypeData
	{
		public ulong stableTypeHash;

		public List<string> data;
	}

	[Serializable]
	private struct JsonPrefabData
	{
		public uint prefabHash;

		public List<JsonTypeData> types;
	}

	[Serializable]
	private struct JsonData
	{
		public List<JsonPrefabData> prefabs;
	}

	[ClearOnReload(true)]
	private static readonly Dictionary<Type, MethodInfo> GenericGetMethodCache = new Dictionary<Type, MethodInfo>();

	[ClearOnReload(true)]
	private static readonly Dictionary<Type, MethodInfo> GenericSetMethodCache = new Dictionary<Type, MethodInfo>();

	private static readonly Dictionary<int, IPugJsonSerializer> SerializerFromRuntimeType = new Dictionary<int, IPugJsonSerializer>();

	private static readonly Dictionary<ulong, IPugJsonSerializer> SerializerFromSerializedType = new Dictionary<ulong, IPugJsonSerializer>();

	internal static void InitSerializers()
	{
		SerializerFromRuntimeType.Clear();
		SerializerFromSerializedType.Clear();
		foreach (Type item in from p in AppDomain.CurrentDomain.GetAssemblies().SelectMany((Assembly s) => s.GetTypes())
			where !p.IsAbstract && !p.IsInterface && typeof(IPugJsonSerializer).IsAssignableFrom(p)
			select p)
		{
			IPugJsonSerializer pugJsonSerializer = (IPugJsonSerializer)Activator.CreateInstance(item);
			SerializerFromRuntimeType.Add(pugJsonSerializer.RuntimeTypeIndex, pugJsonSerializer);
			SerializerFromSerializedType.Add(pugJsonSerializer.SerializedTypeHash, pugJsonSerializer);
		}
	}

	public static InventoryAuxDataAccessor GetAccessor(this InventoryAuxDataSystemDataCD systemData)
	{
		return new InventoryAuxDataAccessor(systemData);
	}

	public static int GetNewIndex(this InventoryAuxDataSystemDataCD systemData)
	{
		if (systemData._freeIndicesList.Length > 0)
		{
			ref NativeList<int> freeIndicesList = ref systemData._freeIndicesList;
			int result = freeIndicesList[freeIndicesList.Length - 1];
			systemData._freeIndicesList.RemoveAt(systemData._freeIndicesList.Length - 1);
			return result;
		}
		return ++systemData._indexCounter.Value;
	}

	public static bool TryGetEntity<T>(this InventoryAuxDataSystemDataCD systemData, int index, out Entity entity, out uint typeHash, out UnsafeList<Entity> lookup)
	{
		TypeIndex typeIndex = TypeManager.GetTypeIndex<T>();
		return systemData.TryGetEntity(index, typeIndex, out entity, out typeHash, out lookup);
	}

	public static bool TryGetEntity(this InventoryAuxDataSystemDataCD systemData, int index, int typeIndex, out Entity entity, out uint typeHash, out UnsafeList<Entity> lookup)
	{
		entity = Entity.Null;
		typeHash = 0u;
		lookup = default(UnsafeList<Entity>);
		if (!systemData._typeIndexToTypeHash.TryGetValue(typeIndex, out typeHash) || !systemData._typeHashToLookup.TryGetValue(typeHash, out lookup))
		{
			return false;
		}
		if (index <= 0 || index >= lookup.Length)
		{
			return false;
		}
		entity = lookup[index];
		return entity != Entity.Null;
	}

	public static bool TryGetEntity<T>(this InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, ref int index, out Entity entity, bool allocate)
	{
		TypeIndex typeIndex = TypeManager.GetTypeIndex<T>();
		if (!systemData.TryGetEntity(index, typeIndex, out entity, out var typeHash, out var lookup))
		{
			if (typeHash == 0)
			{
				Debug.LogError($"tried to get component not in inventory aux system or not created: {typeof(T)}");
				return false;
			}
			if (!allocate)
			{
				return false;
			}
			if (index == 0)
			{
				index = systemData.GetNewIndex();
				foreach (KeyValue<uint, UnsafeList<Entity>> item in systemData._typeHashToLookup)
				{
					for (int i = item.Value.Length; i <= index; i++)
					{
						item.Value.Add(Entity.Null);
					}
					if (item.Key == typeHash)
					{
						lookup = item.Value;
					}
				}
			}
			if (!lookup.IsCreated)
			{
				Debug.LogError("lookup not created");
				return false;
			}
			Entity srcEntity = systemData._typeHashToPrefabEntity[typeHash];
			entity = entityManager.Instantiate(srcEntity);
			entityManager.SetComponentData(entity, new InventoryAuxDataCD
			{
				Index = index
			});
			lookup[index] = entity;
		}
		if (!entityManager.HasComponent<T>(entity))
		{
			return false;
		}
		return true;
	}

	public static bool TryGetEntity<T>(this InventoryAuxDataSystemDataCD systemData, EntityCommandBuffer ecb, ref int index, out Entity entity, bool allocate)
	{
		TypeIndex typeIndex = TypeManager.GetTypeIndex<T>();
		if (!systemData.TryGetEntity(index, typeIndex, out entity, out var typeHash, out var lookup))
		{
			if (typeHash == 0)
			{
				Debug.LogError("tried to get component not in inventory aux system or not created");
				return false;
			}
			if (!allocate)
			{
				return false;
			}
			if (index == 0)
			{
				index = systemData.GetNewIndex();
				foreach (KeyValue<uint, UnsafeList<Entity>> item in systemData._typeHashToLookup)
				{
					for (int i = item.Value.Length; i <= index; i++)
					{
						item.Value.Add(Entity.Null);
					}
					if (item.Key == typeHash)
					{
						lookup = item.Value;
					}
				}
			}
			if (!lookup.IsCreated)
			{
				Debug.LogError("lookup not created");
				return false;
			}
			Entity e = systemData._typeHashToPrefabEntity[typeHash];
			entity = ecb.Instantiate(e);
			ecb.SetComponent(entity, new InventoryAuxDataCD
			{
				Index = index
			});
			lookup[index] = entity;
		}
		return true;
	}

	public static void SetOrAllocateComponentData<T>(this InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, ref int index, T data) where T : unmanaged, IComponentData
	{
		if (systemData.TryGetEntity<T>(entityManager, ref index, out var entity, allocate: true))
		{
			entityManager.SetComponentData(entity, data);
		}
	}

	public static void SetOrAllocateComponentDataWithECB<T>(this InventoryAuxDataSystemDataCD systemData, EntityCommandBuffer ecb, ref int index, T data) where T : unmanaged, IComponentData
	{
		if (systemData.TryGetEntity<T>(ecb, ref index, out var entity, allocate: true))
		{
			ecb.SetComponent(entity, data);
		}
	}

	public static DynamicBuffer<T> GetOrAllocateBuffer<T>(this InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, ref int index, bool readOnly = false) where T : unmanaged, IBufferElementData
	{
		if (!systemData.TryGetEntity<T>(entityManager, ref index, out var entity, allocate: true))
		{
			return default(DynamicBuffer<T>);
		}
		return entityManager.GetBuffer<T>(entity);
	}

	public static bool TryGetExtraInventoryData<T>(this InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, int index, out T data) where T : unmanaged, IComponentData
	{
		data = default(T);
		if (!systemData.TryGetEntity<T>(entityManager, ref index, out var entity, allocate: false))
		{
			return false;
		}
		data = entityManager.GetComponentData<T>(entity);
		return true;
	}

	public static bool TryGetExtraInventoryBufferData<T>(this InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, int index, out DynamicBuffer<T> data) where T : unmanaged, IBufferElementData
	{
		data = default(DynamicBuffer<T>);
		if (!systemData.TryGetEntity<T>(entityManager, ref index, out var entity, allocate: false))
		{
			return false;
		}
		data = entityManager.GetBuffer<T>(entity, isReadOnly: true);
		return true;
	}

	public static void SetOrAllocateBuffer<T>(this InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, ref int index, IEnumerable<object> contents) where T : unmanaged, IBufferElementData
	{
		DynamicBuffer<T> orAllocateBuffer = systemData.GetOrAllocateBuffer<T>(entityManager, ref index);
		if (!orAllocateBuffer.IsCreated)
		{
			return;
		}
		orAllocateBuffer.Clear();
		foreach (object content in contents)
		{
			orAllocateBuffer.Add((T)content);
		}
	}

	private static bool TryGetData(InventoryAuxDataSystemDataCD systemData, EntityManager entitymanager, Type type, int index, out object data)
	{
		data = null;
		if (typeof(IComponentData).IsAssignableFrom(type))
		{
			if (!GenericGetMethodCache.ContainsKey(type))
			{
				MethodInfo value = typeof(InventoryAuxDataSystemExtensions).GetMethod("TryGetExtraInventoryData").MakeGenericMethod(type);
				GenericGetMethodCache[type] = value;
			}
		}
		else
		{
			if (!typeof(IBufferElementData).IsAssignableFrom(type))
			{
				throw new InvalidOperationException($"type {type} is not IComponentData or IBufferElementData");
			}
			if (!GenericGetMethodCache.ContainsKey(type))
			{
				MethodInfo value2 = typeof(InventoryAuxDataSystemExtensions).GetMethod("TryGetExtraInventoryBufferData").MakeGenericMethod(type);
				GenericGetMethodCache[type] = value2;
			}
		}
		MethodInfo methodInfo = GenericGetMethodCache[type];
		object[] array = new object[4] { systemData, entitymanager, index, data };
		bool flag = false;
		try
		{
			flag = (bool)methodInfo.Invoke(null, array);
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		if (flag)
		{
			data = array[3];
		}
		return flag;
	}

	private static void SetData(InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, Type type, ref int index, object data)
	{
		if (typeof(IComponentData).IsAssignableFrom(type))
		{
			if (!GenericSetMethodCache.ContainsKey(type))
			{
				MethodInfo value = typeof(InventoryAuxDataSystemExtensions).GetMethod("SetOrAllocateComponentData").MakeGenericMethod(type);
				GenericSetMethodCache[type] = value;
			}
		}
		else
		{
			if (!typeof(IBufferElementData).IsAssignableFrom(type))
			{
				throw new InvalidOperationException($"type {type} is not IComponentData or IBufferElementData");
			}
			if (!GenericSetMethodCache.ContainsKey(type))
			{
				MethodInfo value2 = typeof(InventoryAuxDataSystemExtensions).GetMethod("SetOrAllocateBuffer").MakeGenericMethod(type);
				GenericSetMethodCache[type] = value2;
			}
		}
		MethodInfo methodInfo = GenericSetMethodCache[type];
		object[] array = new object[4] { systemData, entityManager, index, data };
		methodInfo.Invoke(null, array);
		index = (int)array[2];
	}

	private static void ProcessBufferGeneric<T>(object buffer, Action<object> callback) where T : unmanaged
	{
		if (!(buffer is DynamicBuffer<T> dynamicBuffer))
		{
			return;
		}
		foreach (T item in dynamicBuffer)
		{
			callback(item);
		}
	}

	public static string GetDataAsJson(this InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, int index)
	{
		if (!systemData._typeIndexToTypeHash.IsCreated)
		{
			return null;
		}
		JsonData jsonData = new JsonData
		{
			prefabs = new List<JsonPrefabData>()
		};
		foreach (KeyValue<int, uint> item in systemData._typeIndexToTypeHash)
		{
			UnsafeList<Entity> unsafeList = systemData._typeHashToLookup[item.Value];
			if (unsafeList.Length <= index || unsafeList[index] == Entity.Null)
			{
				continue;
			}
			int i;
			for (i = 0; i < jsonData.prefabs.Count && jsonData.prefabs[i].prefabHash != item.Value; i++)
			{
			}
			if (i == jsonData.prefabs.Count)
			{
				jsonData.prefabs.Add(new JsonPrefabData
				{
					prefabHash = item.Value,
					types = new List<JsonTypeData>()
				});
			}
			TypeManager.TypeInfo typeInfo = TypeManager.GetTypeInfo(item.Key);
			if (!SerializerFromRuntimeType.TryGetValue(typeInfo.TypeIndex, out var serializer))
			{
				Debug.LogError($"no serializer for {typeInfo.Type} ({typeInfo.TypeIndex})");
				continue;
			}
			if (!TryGetData(systemData, entityManager, typeInfo.Type, index, out var data))
			{
				Debug.LogError($"failed to get type {typeInfo.Type} at index {index}");
				continue;
			}
			JsonTypeData jsonTypeData = new JsonTypeData
			{
				stableTypeHash = serializer.SerializedTypeHash,
				data = new List<string>()
			};
			jsonData.prefabs[i].types.Add(jsonTypeData);
			if (typeof(IBufferElementData).IsAssignableFrom(typeInfo.Type))
			{
				typeof(InventoryAuxDataSystemExtensions).GetMethod("ProcessBufferGeneric", BindingFlags.Static | BindingFlags.NonPublic).MakeGenericMethod(typeInfo.Type).Invoke(null, new object[2]
				{
					data,
					new Action<object>(ProcessElement)
				});
			}
			else
			{
				jsonTypeData.data.Add(serializer.SerializeToJson(data));
			}
			void ProcessElement(object o)
			{
				jsonTypeData.data.Add(serializer.SerializeToJson(o));
			}
		}
		return JsonUtility.ToJson(jsonData);
	}

	public static int SetDataFromJson(this InventoryAuxDataSystemDataCD systemData, EntityManager entityManager, string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			return 0;
		}
		JsonData jsonData = new JsonData
		{
			prefabs = new List<JsonPrefabData>()
		};
		JsonUtility.FromJsonOverwrite(json, jsonData);
		if (jsonData.prefabs == null)
		{
			Debug.LogError("bad json: " + json);
			return 0;
		}
		int index = 0;
		foreach (JsonPrefabData prefab in jsonData.prefabs)
		{
			foreach (JsonTypeData type2 in prefab.types)
			{
				if (type2.data == null || type2.data.Count == 0)
				{
					Debug.LogError($"got type with hash {type2.stableTypeHash}, but no data");
					continue;
				}
				if (!SerializerFromSerializedType.TryGetValue(type2.stableTypeHash, out var value))
				{
					Debug.LogError($"no serializer for hash {type2.stableTypeHash}");
					continue;
				}
				Type type = TypeManager.GetType(value.RuntimeTypeIndex);
				if (typeof(IBufferElementData).IsAssignableFrom(type))
				{
					object[] array = new object[type2.data.Count];
					for (int i = 0; i < type2.data.Count; i++)
					{
						array[i] = value.DeserializeFromJson(type2.data[i]);
					}
					SetData(systemData, entityManager, type, ref index, array);
				}
				else
				{
					SetData(systemData, entityManager, type, ref index, value.DeserializeFromJson(type2.data[0]));
				}
			}
		}
		return index;
	}

	public static string PatchIncorrectPetTalents(PetTalent oldTalent, PetTalent newTalent, string json)
	{
		if (string.IsNullOrEmpty(json))
		{
			return json;
		}
		JsonData jsonData = new JsonData
		{
			prefabs = new List<JsonPrefabData>()
		};
		JsonUtility.FromJsonOverwrite(json, jsonData);
		if (jsonData.prefabs == null)
		{
			return json;
		}
		TalentsSerializedCD talentsSerializedCD = default(TalentsSerializedCD);
		foreach (JsonPrefabData prefab in jsonData.prefabs)
		{
			foreach (JsonTypeData type in prefab.types)
			{
				if (type.data == null || type.data.Count == 0)
				{
					Debug.LogError($"got type with hash {type.stableTypeHash}, but no data");
				}
				else
				{
					if (type.stableTypeHash != talentsSerializedCD.SerializedTypeHash)
					{
						continue;
					}
					for (int i = 0; i < type.data.Count; i++)
					{
						PetTalentBuffer petTalentBuffer = (PetTalentBuffer)talentsSerializedCD.DeserializeFromJson(type.data[i]);
						if (petTalentBuffer.petTalentID == oldTalent)
						{
							petTalentBuffer.petTalentID = newTalent;
							type.data[i] = talentsSerializedCD.SerializeToJson(petTalentBuffer);
						}
					}
				}
			}
		}
		return JsonUtility.ToJson(jsonData);
	}

	[Preserve]
	private static void Dummy()
	{
		new InventoryAuxDataSystem();
		int index = 0;
		default(InventoryAuxDataSystemDataCD).SetOrAllocateBuffer<PetTalentBuffer>(default(EntityManager), ref index, null);
		default(InventoryAuxDataSystemDataCD).GetOrAllocateBuffer<PetTalentBuffer>(default(EntityManager), ref index);
		ProcessBufferGeneric<PetTalentBuffer>(null, null);
		ProcessBufferGeneric<TalentsSerializedCD>(null, null);
		default(InventoryAuxDataSystemDataCD).TryGetExtraInventoryBufferData(default(EntityManager), index, out DynamicBuffer<PetTalentBuffer> _);
		default(InventoryAuxDataSystemDataCD).TryGetExtraInventoryData<NameCD>(default(EntityManager), index, out var _);
		default(InventoryAuxDataSystemDataCD).TryGetExtraInventoryData<PetSkinCD>(default(EntityManager), index, out var _);
		default(InventoryAuxDataSystemDataCD).TryGetExtraInventoryData<MealsEatenCD>(default(EntityManager), index, out var _);
		default(InventoryAuxDataSystemDataCD).SetOrAllocateComponentData(default(EntityManager), ref index, default(NameCD));
		default(InventoryAuxDataSystemDataCD).SetOrAllocateComponentData(default(EntityManager), ref index, default(PetSkinCD));
		default(InventoryAuxDataSystemDataCD).SetOrAllocateComponentData(default(EntityManager), ref index, default(MealsEatenCD));
	}
}
