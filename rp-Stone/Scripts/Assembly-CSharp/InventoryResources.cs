using System;
using System.Collections.Generic;
using SafeTypes;

public class InventoryResources
{
	private const int MAX_VALUE = 999999999;

	private Dictionary<int, long> resources = new Dictionary<int, long>();

	private Dictionary<int, SafeLong> _resources = new Dictionary<int, SafeLong>();

	private static InventoryResources _instance;

	public static InventoryResources singleton
	{
		get
		{
			if (_instance == null)
			{
				_instance = new InventoryResources();
			}
			return _instance;
		}
	}

	public event Action<Data.Resource, int> OnResourceAdded;

	public void ClearProgress()
	{
		resources.Clear();
		_resources.Clear();
	}

	public long GetResourceOfType(Data.Resource resourceType)
	{
		EnsureResource(resourceType);
		return resources[(int)resourceType];
	}

	public void AddResourceOfType(Data.Resource resourceType, long amount)
	{
		EnsureResource(resourceType);
		if (amount < 0)
		{
			Utils.LogError("Invalid parameter. Use positive values to add a resource.");
			return;
		}
		bool flag = false;
		if (!SaveFiles.singleton.isLoading && resourceType == Data.Resource.Xi && EventController.singleton.IsEventActive("2xKi"))
		{
			flag = true;
			amount *= 2;
		}
		long cipheredResource = GetCipheredResource(resourceType);
		long num = cipheredResource + amount;
		if (num < 0 || num < cipheredResource || num > 999999999)
		{
			num = 999999999L;
		}
		SetCipheredResource(resourceType, num);
		resources[(int)resourceType] = num;
		this.OnResourceAdded?.Invoke(resourceType, (int)amount);
		if (num <= int.MaxValue)
		{
			AchievementController.singleton.ReportResourceChanged(resourceType, (int)num);
		}
		if (flag)
		{
			amount /= 2;
		}
		OfflineFarmController.singleton.ReportResourceGained(resourceType, (int)amount);
	}

	public void RemoveResourceOfType(Data.Resource resourceType, long amount)
	{
		EnsureResource(resourceType);
		if (amount < 0)
		{
			Utils.LogError("Invalid parameter. Use positive values to remove a resource.");
			return;
		}
		long cipheredResource = GetCipheredResource(resourceType);
		long num = cipheredResource - amount;
		if (num < 0 || num > cipheredResource)
		{
			num = 0L;
		}
		SetCipheredResource(resourceType, num);
		resources[(int)resourceType] = num;
	}

	private long GetCipheredResource(Data.Resource resourceType)
	{
		return _resources[(int)resourceType].GetValue();
	}

	private void SetCipheredResource(Data.Resource resourceType, long value)
	{
		_resources[(int)resourceType] = new SafeLong(value);
	}

	private uint RotateLeft(uint original, int bits)
	{
		return (original << bits) | (original >> 32 - bits);
	}

	private uint RotateRight(uint original, int bits)
	{
		return (original >> bits) | (original << 32 - bits);
	}

	private void EnsureResource(Data.Resource resourceType)
	{
		if (!resources.ContainsKey((int)resourceType))
		{
			resources.Add((int)resourceType, 0L);
			_resources.Add((int)resourceType, default(SafeLong));
		}
	}

	public void Serialize()
	{
		foreach (KeyValuePair<int, SafeLong> resource in _resources)
		{
			SlimJson.AddProperty(((Data.Resource)resource.Key/*cast due to .constrained prefix*/).ToString(), resource.Value.GetValue());
		}
	}

	public static Data.Resource ParseResource(string s)
	{
		if (!Enum.TryParse<Data.Resource>(s, ignoreCase: true, out var result))
		{
			throw new Exception("\"" + s + "\" is not a valid resource.");
		}
		return result;
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		for (Data.Resource resource = Data.Resource.Stone; resource <= Data.Resource.Gold; resource++)
		{
			long num = SlimJson.ParseLong(sjson, resource.ToString(), -1L);
			if (num > 0)
			{
				AddResourceOfType(resource, num);
			}
		}
	}
}
