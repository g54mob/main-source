using System;
using System.Collections.Generic;
using System.Linq;
using I2.Loc;
using UnityEngine;

[Serializable]
public struct PropertyListingData : IEquatable<PropertyListingData>
{
	public string listingId;

	public string configId;

	public string propertyName;

	public string address;

	public PropertyType propertyType;

	public int propertyLevel;

	public int basePrice;

	public int size;

	public string linkedSceneName;

	public int visualIndex;

	public int spawnProfileIndex;

	public double listedTime;

	public bool IsValid
	{
		get
		{
			if (!string.IsNullOrEmpty(listingId))
			{
				return !string.IsNullOrEmpty(configId);
			}
			return false;
		}
	}

	public string LocalizedName
	{
		get
		{
			if (string.IsNullOrEmpty(propertyName))
			{
				return string.Empty;
			}
			string translation = LocalizationManager.GetTranslation(propertyName);
			if (string.IsNullOrEmpty(translation))
			{
				return propertyName;
			}
			return translation;
		}
	}

	public string LocalizedAddress
	{
		get
		{
			if (string.IsNullOrEmpty(address))
			{
				return string.Empty;
			}
			string translation = LocalizationManager.GetTranslation(address);
			if (string.IsNullOrEmpty(translation))
			{
				return address;
			}
			return translation;
		}
	}

	public static PropertyListingData CreateFromConfig(PropertyConfigSO config)
	{
		return CreateFromConfig(config, null);
	}

	public static PropertyListingData CreateFromConfig(PropertyConfigSO config, IEnumerable<PropertyListingData> existingListings)
	{
		if (config == null)
		{
			Debug.LogWarning("PropertyListingData: Config null!");
			return default(PropertyListingData);
		}
		HashSet<string> hashSet = new HashSet<string>();
		HashSet<string> hashSet2 = new HashSet<string>();
		HashSet<int> hashSet3 = new HashSet<int>();
		HashSet<int> hashSet4 = new HashSet<int>();
		if (existingListings != null)
		{
			foreach (PropertyListingData existingListing in existingListings)
			{
				if (existingListing.configId == config.ConfigId)
				{
					if (!string.IsNullOrEmpty(existingListing.propertyName))
					{
						hashSet.Add(existingListing.propertyName);
					}
					if (!string.IsNullOrEmpty(existingListing.address))
					{
						hashSet2.Add(existingListing.address);
					}
					hashSet3.Add(existingListing.visualIndex);
					hashSet4.Add(existingListing.size);
				}
			}
		}
		string value = GetUniqueRandomItem(config.propertyNames, hashSet);
		if (string.IsNullOrEmpty(value))
		{
			value = $"Emlak #{UnityEngine.Random.Range(1, 1000)}";
		}
		string value2 = GetUniqueRandomItem(config.propertyAddresses, hashSet2);
		if (string.IsNullOrEmpty(value2))
		{
			value2 = $"Bilinmeyen Adres #{UnityEngine.Random.Range(1, 100)}";
		}
		int uniqueRandomIndex = GetUniqueRandomIndex(config.propertyVisuals?.Count ?? 0, hashSet3);
		int num = GetUniqueRandomIntItem(config.propertySizes, hashSet4);
		if (num <= 0)
		{
			num = 100;
		}
		int num2 = 0;
		if (config.itemSpawnProfiles != null && config.itemSpawnProfiles.Count > 0)
		{
			num2 = UnityEngine.Random.Range(0, config.itemSpawnProfiles.Count);
		}
		return new PropertyListingData
		{
			listingId = GenerateListingId(),
			configId = config.ConfigId,
			propertyName = value,
			address = value2,
			propertyType = config.propertyType,
			propertyLevel = config.propertyLevel,
			basePrice = config.GetRandomPrice(),
			size = num,
			linkedSceneName = config.linkedSceneName,
			visualIndex = uniqueRandomIndex,
			spawnProfileIndex = num2,
			listedTime = NetworkTimeHelper.GetNetworkTime()
		};
	}

	private static string GetUniqueRandomItem(List<string> items, HashSet<string> usedItems)
	{
		if (items == null || items.Count == 0)
		{
			return null;
		}
		List<string> list = items.Where((string i) => !usedItems.Contains(i)).ToList();
		if (list.Count == 0)
		{
			list = items;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	private static int GetUniqueRandomIntItem(List<int> items, HashSet<int> usedItems)
	{
		if (items == null || items.Count == 0)
		{
			return 0;
		}
		List<int> list = items.Where((int i) => !usedItems.Contains(i)).ToList();
		if (list.Count == 0)
		{
			list = items;
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	private static int GetUniqueRandomIndex(int count, HashSet<int> usedIndices)
	{
		if (count <= 0)
		{
			return 0;
		}
		List<int> list = new List<int>();
		for (int i = 0; i < count; i++)
		{
			if (!usedIndices.Contains(i))
			{
				list.Add(i);
			}
		}
		if (list.Count == 0)
		{
			return UnityEngine.Random.Range(0, count);
		}
		return list[UnityEngine.Random.Range(0, list.Count)];
	}

	public Sprite GetVisual(PropertyConfigSO config)
	{
		if (config == null || config.propertyVisuals == null || config.propertyVisuals.Count == 0)
		{
			return null;
		}
		if (visualIndex < 0 || visualIndex >= config.propertyVisuals.Count)
		{
			return config.propertyVisuals[0];
		}
		return config.propertyVisuals[visualIndex];
	}

	public T_ItemSpawnProfile GetSpawnProfile(PropertyConfigSO config)
	{
		if (config == null || config.itemSpawnProfiles == null || config.itemSpawnProfiles.Count == 0)
		{
			return null;
		}
		if (spawnProfileIndex < 0 || spawnProfileIndex >= config.itemSpawnProfiles.Count)
		{
			return config.itemSpawnProfiles[0];
		}
		return config.itemSpawnProfiles[spawnProfileIndex];
	}

	private static string GenerateListingId()
	{
		return $"PL_{DateTime.UtcNow.Ticks:X}_{UnityEngine.Random.Range(1000, 9999)}";
	}

	public bool Equals(PropertyListingData other)
	{
		return listingId == other.listingId;
	}

	public override bool Equals(object obj)
	{
		if (obj is PropertyListingData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return listingId?.GetHashCode() ?? 0;
	}

	public static bool operator ==(PropertyListingData left, PropertyListingData right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(PropertyListingData left, PropertyListingData right)
	{
		return !left.Equals(right);
	}
}
