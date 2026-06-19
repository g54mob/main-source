using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class ScriptableData
{
	private static bool s_isLoading;

	private static bool s_isLoaded;

	private static int s_loadIndex = 0;

	private static Dictionary<Guid, ScriptableDataBlock> s_dataBlockLookup = new Dictionary<Guid, ScriptableDataBlock>();

	private static Dictionary<Type, List<ScriptableDataBlock>> s_runtimeLists = new Dictionary<Type, List<ScriptableDataBlock>>();

	private static Dictionary<Type, IList> s_runtimeListsT = new Dictionary<Type, IList>();

	private static Dictionary<Type, Dictionary<ScriptableDataBlock, int>> s_runtimeLookups = new Dictionary<Type, Dictionary<ScriptableDataBlock, int>>();

	private static Dictionary<string, List<ScriptableDataBlock>> s_dataBlockSets = new Dictionary<string, List<ScriptableDataBlock>>();

	private static Dictionary<string, IScriptableDataLoader> s_dataBlockLoaders = new Dictionary<string, IScriptableDataLoader>();

	private static MD5 s_md5 = MD5.Create();

	private static FieldInfo s_headerField = typeof(ScriptableDataBlock).GetField("m_header", BindingFlags.Instance | BindingFlags.NonPublic);

	public static bool isInitializingCollections { get; private set; } = false;

	public static int loadedDataBlockCount => s_dataBlockLookup.Count;

	public static bool isLoading => s_isLoading;

	public static bool isLoaded => s_isLoaded;

	public static float loadPercentage
	{
		get
		{
			float num = 0f;
			foreach (KeyValuePair<string, IScriptableDataLoader> s_dataBlockLoader in s_dataBlockLoaders)
			{
				num += s_dataBlockLoader.Value.LoadCompletedPercentage / (float)s_dataBlockLoaders.Count;
			}
			return num;
		}
	}

	public static int globalLoadID
	{
		get
		{
			if (!isLoaded)
			{
				return 0;
			}
			return s_loadIndex;
		}
	}

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
	private static void Reset()
	{
		s_dataBlockLoaders.Clear();
		s_dataBlockSets.Clear();
		ClearLookups();
		s_isLoading = false;
		s_isLoaded = false;
		s_loadIndex = 0;
	}

	public static void AddDataBlocksLoader(string name, IScriptableDataLoader loader)
	{
		if (s_dataBlockLoaders.ContainsKey(name))
		{
			UnityEngine.Debug.LogError("Data block loader already added for key " + name);
		}
		else
		{
			s_dataBlockLoaders.Add(name, loader);
		}
	}

	public static void RemoveDataBlocksLoader(string name)
	{
		if (!s_dataBlockLoaders.Remove(name))
		{
			UnityEngine.Debug.LogError("Data block loader not added for key " + name);
		}
		s_dataBlockSets.Remove(name);
	}

	public static async Task LoadAsync()
	{
		s_isLoading = true;
		Stopwatch timer = new Stopwatch();
		foreach (KeyValuePair<string, IScriptableDataLoader> dataBlockLoader in s_dataBlockLoaders)
		{
			timer.Restart();
			if (dataBlockLoader.Value.LoadCompleted)
			{
				if (!dataBlockLoader.Value.HasDataBlockChanges)
				{
					UnityEngine.Debug.Log("loaded and no changes, skip " + dataBlockLoader.Key);
					continue;
				}
				dataBlockLoader.Value.Unload();
			}
			Task<IEnumerable<ScriptableDataBlock>> loadTask = dataBlockLoader.Value.LoadAsync();
			await loadTask;
			List<ScriptableDataBlock> list = new List<ScriptableDataBlock>(loadTask.Result);
			s_dataBlockSets[dataBlockLoader.Key] = list;
			timer.Stop();
			UnityEngine.Debug.Log($"Loaded (async) {list.Count} data blocks from {dataBlockLoader.Key} in {timer.Elapsed.TotalSeconds} s");
		}
		Initialize();
	}

	public static void Load()
	{
		s_isLoading = true;
		Stopwatch stopwatch = new Stopwatch();
		foreach (KeyValuePair<string, IScriptableDataLoader> s_dataBlockLoader in s_dataBlockLoaders)
		{
			stopwatch.Restart();
			if (s_dataBlockLoader.Value.LoadCompleted)
			{
				if (!s_dataBlockLoader.Value.HasDataBlockChanges)
				{
					UnityEngine.Debug.Log("loaded and no changes, skip " + s_dataBlockLoader.Key);
					continue;
				}
				s_dataBlockLoader.Value.Unload();
			}
			List<ScriptableDataBlock> list = new List<ScriptableDataBlock>(s_dataBlockLoader.Value.Load());
			s_dataBlockSets[s_dataBlockLoader.Key] = list;
			stopwatch.Stop();
			UnityEngine.Debug.Log($"Loaded {list.Count} data blocks from {s_dataBlockLoader.Key} in {stopwatch.Elapsed.TotalSeconds} s");
		}
		Initialize();
	}

	private static ScriptableDataBlock ProcessOverload(ScriptableDataBlock original, ScriptableDataBlock overload)
	{
		return overload;
	}

	private static void Initialize()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		ClearLookups();
		Dictionary<DataBlockAddress, List<ScriptableDataBlock>> overloadedDataBlocks = new Dictionary<DataBlockAddress, List<ScriptableDataBlock>>();
		List<ScriptableDataBlock> list = new List<ScriptableDataBlock>();
		foreach (KeyValuePair<string, List<ScriptableDataBlock>> s_dataBlockSet in s_dataBlockSets)
		{
			HandleLoadedDataBlocks(s_dataBlockSet.Value, s_dataBlockSet.Key, list, overloadedDataBlocks);
		}
		foreach (ScriptableDataBlock item in list)
		{
			ResolveOverloadRecursive(item, item.address, s_dataBlockLookup, overloadedDataBlocks);
		}
		Dictionary<Guid, ScriptableDataBlock>.ValueCollection values = s_dataBlockLookup.Values;
		isInitializingCollections = true;
		foreach (ScriptableDataBlock item2 in values)
		{
			if (item2 is DataBlockCollection dataBlockCollection)
			{
				dataBlockCollection.Initialize(values);
			}
		}
		isInitializingCollections = false;
		s_isLoaded = true;
		s_isLoading = false;
		s_loadIndex++;
		UnityEngine.Debug.Log($"Initialized {values.Count} data blocks in {stopwatch.Elapsed.TotalSeconds} s");
		if (Application.isPlaying)
		{
			InvokeRuntimeOnLoadMethods();
		}
		static ScriptableDataBlock ResolveOverloadRecursive(ScriptableDataBlock dataBlock, DataBlockAddress startingDataBlockAddress, Dictionary<Guid, ScriptableDataBlock> resolvedDataBlocks, Dictionary<DataBlockAddress, List<ScriptableDataBlock>> dictionary)
		{
			if (resolvedDataBlocks.TryGetValue(dataBlock.address, out var value))
			{
				return value;
			}
			if (!dictionary.TryGetValue(dataBlock.address, out var value2))
			{
				resolvedDataBlocks.Add(dataBlock.address, dataBlock);
				return dataBlock;
			}
			value = dataBlock;
			foreach (ScriptableDataBlock item3 in value2)
			{
				if (item3.address == startingDataBlockAddress)
				{
					UnityEngine.Debug.LogError("circular dependency among overloads for " + dataBlock.name);
				}
				else
				{
					value = ProcessOverload(value, ResolveOverloadRecursive(item3, startingDataBlockAddress, resolvedDataBlocks, dictionary));
				}
			}
			UnityEngine.Debug.Log("data block " + dataBlock.name + " resolved to " + value.name);
			resolvedDataBlocks.Add(dataBlock.address, value);
			return value;
		}
	}

	private static void ClearLookups()
	{
		s_dataBlockLookup.Clear();
		s_runtimeLists.Clear();
		s_runtimeListsT.Clear();
		s_runtimeLookups.Clear();
	}

	private static void HandleLoadedDataBlocks(IEnumerable<ScriptableDataBlock> dataBlocks, string name, List<ScriptableDataBlock> allDataBlocks, Dictionary<DataBlockAddress, List<ScriptableDataBlock>> overloadedDataBlocks)
	{
		UnityEngine.Debug.Log("Handling loaded data blocks: " + name);
		foreach (ScriptableDataBlock dataBlock in dataBlocks)
		{
			allDataBlocks.Add(dataBlock);
			if (dataBlock.m_overload.hasAddress)
			{
				if (!overloadedDataBlocks.TryGetValue(dataBlock.m_overload.address, out var value))
				{
					value = new List<ScriptableDataBlock>();
					overloadedDataBlocks.Add(dataBlock.m_overload.address, value);
				}
				value.Add(dataBlock);
			}
			Type type = dataBlock.GetType();
			while (true)
			{
				if (!s_runtimeLists.TryGetValue(type, out var value2))
				{
					value2 = new List<ScriptableDataBlock>();
					s_runtimeLists.Add(type, value2);
				}
				if (!s_runtimeListsT.TryGetValue(type, out var value3))
				{
					value3 = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
					s_runtimeListsT.Add(type, value3);
				}
				if (!s_runtimeLookups.TryGetValue(type, out var value4))
				{
					value4 = new Dictionary<ScriptableDataBlock, int>();
					s_runtimeLookups.Add(type, value4);
				}
				value4.Add(dataBlock, value2.Count);
				value2.Add(dataBlock);
				value3.Add(dataBlock);
				if (type == typeof(ScriptableDataBlock))
				{
					break;
				}
				type = type.BaseType;
			}
		}
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetDataBlocks(Type type, out IReadOnlyList<ScriptableDataBlock> dataBlocks)
	{
		List<ScriptableDataBlock> value;
		bool result = s_runtimeLists.TryGetValue(type, out value);
		dataBlocks = value;
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetDataBlocks<T>(out IReadOnlyList<T> dataBlocks) where T : ScriptableDataBlock
	{
		Type typeFromHandle = typeof(T);
		IList value;
		bool result = s_runtimeListsT.TryGetValue(typeFromHandle, out value);
		dataBlocks = value as IReadOnlyList<T>;
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IReadOnlyList<T> GetDataBlocks<T>() where T : ScriptableDataBlock
	{
		TryGetDataBlocks(out IReadOnlyList<T> dataBlocks);
		return dataBlocks;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetRuntimeID(ScriptableDataBlock dataBlock, Type type, out int runtimeID)
	{
		int value = -1;
		if (s_runtimeLookups.TryGetValue(type, out var value2))
		{
			value2.TryGetValue(dataBlock, out value);
		}
		runtimeID = value + 1;
		return value >= 0;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetRuntimeID<T>(ScriptableDataBlock dataBlock, out int runtimeID) where T : ScriptableDataBlock
	{
		if (dataBlock == null)
		{
			runtimeID = 0;
			return false;
		}
		return TryGetRuntimeID(dataBlock, typeof(T), out runtimeID);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetRuntimeID(this ScriptableDataBlock dataBlock)
	{
		TryGetRuntimeID(dataBlock, dataBlock.GetType(), out var runtimeID);
		return runtimeID;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetRuntimeID<T>(this ScriptableDataBlock dataBlock)
	{
		TryGetRuntimeID(dataBlock, typeof(T), out var runtimeID);
		return runtimeID;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int GetRuntimeID<T>(this ScriptableDataBlock dataBlock, Type type)
	{
		TryGetRuntimeID(dataBlock, type, out var runtimeID);
		return runtimeID;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetDataBlock(int runtimeID, Type type, out ScriptableDataBlock dataBlock)
	{
		int num = runtimeID - 1;
		if (!TryGetDataBlocks(type, out var dataBlocks) || num < 0 || num >= dataBlocks.Count)
		{
			dataBlock = null;
			return false;
		}
		dataBlock = dataBlocks[num];
		return true;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ScriptableDataBlock GetDataBlock(int runtimeID, Type type)
	{
		TryGetDataBlock(runtimeID, type, out var dataBlock);
		return dataBlock;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetDataBlock<T>(int runtimeID, out T dataBlock) where T : ScriptableDataBlock
	{
		ScriptableDataBlock dataBlock2;
		bool result = TryGetDataBlock(runtimeID, typeof(T), out dataBlock2);
		dataBlock = dataBlock2 as T;
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetDataBlock<T>(int runtimeID) where T : ScriptableDataBlock
	{
		TryGetDataBlock<T>(runtimeID, out var dataBlock);
		return dataBlock;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool TryGetDataBlock<T>(DataBlockAddress address, out T dataBlock) where T : ScriptableDataBlock
	{
		ScriptableDataBlock value;
		bool result = s_dataBlockLookup.TryGetValue(address, out value);
		dataBlock = value as T;
		return result;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static T GetDataBlock<T>(DataBlockAddress address) where T : ScriptableDataBlock
	{
		TryGetDataBlock<T>(address, out var dataBlock);
		return dataBlock;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static ScriptableDataBlock GetDataBlock(DataBlockAddress address)
	{
		return GetDataBlock<ScriptableDataBlock>(address);
	}

	private static void InvokeRuntimeOnLoadMethods()
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		Type typeFromHandle = typeof(RuntimeInitializeOnScriptableDataLoadAttribute);
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			if (!IsOrReferencesScriptableData(assembly))
			{
				continue;
			}
			foreach (TypeInfo definedType in assembly.DefinedTypes)
			{
				if (!HasAttribute(definedType, typeFromHandle))
				{
					continue;
				}
				MethodInfo[] methods = definedType.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (MethodInfo methodInfo in methods)
				{
					if (HasAttribute(methodInfo, typeFromHandle))
					{
						methodInfo.Invoke(null, null);
					}
				}
			}
		}
		MethodInfo method = typeof(ScriptableDataBlock).GetMethod("OnStart", BindingFlags.Instance | BindingFlags.NonPublic);
		foreach (ScriptableDataBlock value in s_dataBlockLookup.Values)
		{
			method.Invoke(value, null);
		}
		UnityEngine.Debug.Log($"Ran post data block load callbacks in {stopwatch.Elapsed.TotalSeconds} s");
	}

	private static bool IsOrReferencesScriptableData(Assembly assembly)
	{
		if (assembly.FullName.Contains("ScriptableData"))
		{
			return true;
		}
		AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
		for (int i = 0; i < referencedAssemblies.Length; i++)
		{
			if (referencedAssemblies[i].FullName.Contains("ScriptableData"))
			{
				return true;
			}
		}
		return false;
	}

	private static bool HasAttribute(Type type, Type attributeType)
	{
		foreach (CustomAttributeData customAttribute in type.CustomAttributes)
		{
			if (customAttribute.AttributeType == attributeType)
			{
				return true;
			}
		}
		return false;
	}

	private static bool HasAttribute(MethodInfo method, Type attributeType)
	{
		foreach (CustomAttributeData customAttribute in method.CustomAttributes)
		{
			if (customAttribute.AttributeType == attributeType)
			{
				return true;
			}
		}
		return false;
	}

	public static ulong GenerateChecksum(this ScriptableDataBlock dataBlock)
	{
		string value = (string)s_headerField.GetValue(dataBlock);
		s_headerField.SetValue(dataBlock, string.Empty);
		string s = JsonUtility.ToJson(dataBlock);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		ulong result = BitConverter.ToUInt64(s_md5.ComputeHash(bytes), 0);
		s_headerField.SetValue(dataBlock, value);
		return result;
	}
}
