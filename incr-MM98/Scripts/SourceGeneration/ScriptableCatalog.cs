using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using ZLinq;
using ZLinq.Linq;

public abstract class ScriptableCatalog<TData, TType> : IDisposable where TData : ScriptableData<TType> where TType : struct, Enum
{
	public readonly string CatalogName;

	private readonly Dictionary<TType, TData> _byId = new Dictionary<TType, TData>();

	private AsyncOperationHandle<IList<TData>> _loadHandle;

	public IEnumerable<TData> Collection => _byId.Values;

	public int Count => _byId.Count;

	protected ScriptableCatalog(string name)
	{
		CatalogName = name;
	}

	public async UniTask InitializeAsync()
	{
		_byId.Clear();
		_loadHandle = Addressables.LoadAssetsAsync<TData>(AddressableLabels(), null, Addressables.MergeMode.Intersection);
		await _loadHandle.ToUniTask();
		foreach (TData item in _loadHandle.Result)
		{
			if (!_byId.TryAdd(item.ID, item))
			{
				throw new ArgumentException($"Duplicate entry {item.ID} found in catalog '{CatalogName}'.");
			}
		}
	}

	public void Dispose()
	{
		Addressables.Release(_loadHandle);
	}

	public virtual void Validate()
	{
		ValueEnumerable<Select<FromEnumerable<TData>, TData, TType>, TType> source = from x in Collection.AsValueEnumerable()
			select x.ID;
		if (source.Count() == source.Distinct().Count())
		{
			return;
		}
		throw new ArgumentException(CatalogName + " has duplicate entries.");
	}

	public TData Get(TType type)
	{
		if (!TryGet(type, out var result))
		{
			throw new KeyNotFoundException($"Entry {type} not found in catalog '{CatalogName}'.");
		}
		return result;
	}

	public bool TryGet(TType type, out TData result)
	{
		return _byId.TryGetValue(type, out result);
	}

	private static string[] AddressableLabels()
	{
		string[] array = new string[2] { "Full", null };
		if (typeof(TData) == typeof(UpgradeNodeData))
		{
			array[1] = "Upgrades";
		}
		else if (typeof(TData) == typeof(ResearchNodeData))
		{
			array[1] = "Research";
		}
		else if (typeof(TData) == typeof(OperationData))
		{
			array[1] = "Operations";
		}
		else if (typeof(TData) == typeof(DatacenterData))
		{
			array[1] = "Datacenters";
		}
		else if (typeof(TData) == typeof(GnormanActionData))
		{
			array[1] = "Gnorman";
		}
		else if (typeof(TData) == typeof(AchievementData))
		{
			array[1] = "Achievements";
		}
		else
		{
			array[1] = string.Empty;
		}
		return array;
	}
}
