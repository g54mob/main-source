using System;
using System.Collections.Generic;
using Enviro;
using UnityEngine;

[Serializable]
public struct ContractListingData : IEquatable<ContractListingData>
{
	public string listingId;

	public string contractId;

	public string propertyConfigId;

	public string companyName;

	public int price;

	public int deliveryDays;

	public string[] materialIds;

	public int[] materialCounts;

	public ContractSourceType sourceType;

	public int logoIndex;

	public int backgroundIndex;

	public double listedTime;

	public int listedDay;

	public int contractNumber;

	public int requiredLevel;

	public bool IsValid
	{
		get
		{
			if (!string.IsNullOrEmpty(listingId))
			{
				return !string.IsNullOrEmpty(contractId);
			}
			return false;
		}
	}

	public bool IsLocked
	{
		get
		{
			int num = FactoryManager.Instance?.Level ?? 1;
			return requiredLevel > num;
		}
	}

	public int MaterialCount
	{
		get
		{
			string[] array = materialIds;
			if (array == null)
			{
				return 0;
			}
			return array.Length;
		}
	}

	public static ContractListingData CreateFromConfig(ContractSO contractConfig, PropertyConfigSO propertyConfig, ContractSourceType sourceType)
	{
		return CreateFromConfig(contractConfig, propertyConfig, sourceType, null);
	}

	public static ContractListingData CreateFromConfig(ContractSO contractConfig, PropertyConfigSO propertyConfig, ContractSourceType sourceType, IEnumerable<ContractListingData> existingListings)
	{
		return CreateFromConfig(contractConfig, propertyConfig, sourceType, existingListings, null);
	}

	public static ContractListingData CreateFromConfig(ContractSO contractConfig, PropertyConfigSO propertyConfig, ContractSourceType sourceType, IEnumerable<ContractListingData> existingListings, IEnumerable<ActiveContractData> activeContracts)
	{
		if (contractConfig == null)
		{
			Debug.LogWarning("ContractListingData: ContractConfig null!");
			return default(ContractListingData);
		}
		if (propertyConfig == null)
		{
			Debug.LogWarning("ContractListingData: PropertyConfig null!");
			return default(ContractListingData);
		}
		if (!contractConfig.HasValidMaterials())
		{
			Debug.LogWarning("ContractListingData: Contract '" + contractConfig.company?.companyName + "' has no valid materials!");
			return default(ContractListingData);
		}
		List<string> list = new List<string>();
		List<int> list2 = new List<int>();
		foreach (ContractSO.ContractMaterial requiredMaterial in contractConfig.requiredMaterials)
		{
			if (requiredMaterial != null && requiredMaterial.item != null)
			{
				list.Add(requiredMaterial.item.GetItemID());
				list2.Add(requiredMaterial.count);
			}
		}
		if (IsContractAlreadyExists(contractConfig.ContractId, existingListings, activeContracts))
		{
			Debug.Log("ContractListingData: Contract '" + contractConfig.company?.companyName + "' (ID: " + contractConfig.ContractId + ") zaten mevcut, atlanıyor.");
			return default(ContractListingData);
		}
		string text = contractConfig.company?.companyName ?? "Unknown";
		int num = ((!(DayNightManager.Instance != null)) ? 1 : DayNightManager.Instance.CurrentGameDay);
		int randomDeliveryDays = contractConfig.GetRandomDeliveryDays();
		return new ContractListingData
		{
			listingId = GenerateListingId(),
			contractId = contractConfig.ContractId,
			propertyConfigId = propertyConfig.ConfigId,
			companyName = text,
			price = contractConfig.GetRandomPrice(),
			deliveryDays = randomDeliveryDays,
			materialIds = list.ToArray(),
			materialCounts = list2.ToArray(),
			sourceType = sourceType,
			logoIndex = 0,
			backgroundIndex = 0,
			listedTime = NetworkTimeHelper.GetNetworkTime(),
			listedDay = num,
			contractNumber = GenerateUniqueContractNumber(existingListings, activeContracts),
			requiredLevel = contractConfig.requiredLevel
		};
	}

	public Sprite GetLogo(ContractSO config)
	{
		if (config == null)
		{
			return null;
		}
		return config.company?.companyLogo;
	}

	public Sprite GetBackground(ContractSO config)
	{
		if (config == null)
		{
			return null;
		}
		return config.company?.companyBackground;
	}

	public bool TryGetMaterial(int index, out string itemId, out int count)
	{
		if (materialIds != null && materialCounts != null && index >= 0 && index < materialIds.Length && index < materialCounts.Length)
		{
			itemId = materialIds[index];
			count = materialCounts[index];
			return true;
		}
		itemId = null;
		count = 0;
		return false;
	}

	private static string GenerateListingId()
	{
		return $"CL_{DateTime.UtcNow.Ticks:X}_{UnityEngine.Random.Range(1000, 9999)}";
	}

	private static int GenerateUniqueContractNumber(IEnumerable<ContractListingData> existingListings, IEnumerable<ActiveContractData> activeContracts)
	{
		HashSet<int> hashSet = new HashSet<int>();
		if (existingListings != null)
		{
			foreach (ContractListingData existingListing in existingListings)
			{
				if (existingListing.contractNumber >= 100 && existingListing.contractNumber <= 999)
				{
					hashSet.Add(existingListing.contractNumber);
				}
			}
		}
		if (activeContracts != null)
		{
			foreach (ActiveContractData activeContract in activeContracts)
			{
				if (activeContract.contractNumber >= 100 && activeContract.contractNumber <= 999)
				{
					hashSet.Add(activeContract.contractNumber);
				}
			}
		}
		if (hashSet.Count >= 900)
		{
			Debug.LogWarning("[ContractListingData] Tüm contract numaraları kullanımda! Rastgele numara atanıyor.");
			return UnityEngine.Random.Range(100, 1000);
		}
		int num = 0;
		int num2 = 100;
		int num3;
		do
		{
			num3 = UnityEngine.Random.Range(100, 1000);
			num++;
		}
		while (hashSet.Contains(num3) && num < num2);
		return num3;
	}

	private static bool IsContractAlreadyExists(string contractId, IEnumerable<ContractListingData> existingListings, IEnumerable<ActiveContractData> activeContracts)
	{
		if (string.IsNullOrEmpty(contractId))
		{
			return false;
		}
		if (existingListings != null)
		{
			foreach (ContractListingData existingListing in existingListings)
			{
				if (existingListing.contractId == contractId)
				{
					return true;
				}
			}
		}
		if (activeContracts != null)
		{
			foreach (ActiveContractData activeContract in activeContracts)
			{
				if (activeContract.contractId == contractId)
				{
					return true;
				}
			}
		}
		return false;
	}

	public bool Equals(ContractListingData other)
	{
		return listingId == other.listingId;
	}

	public override bool Equals(object obj)
	{
		if (obj is ContractListingData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return listingId?.GetHashCode() ?? 0;
	}

	public static bool operator ==(ContractListingData left, ContractListingData right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ContractListingData left, ContractListingData right)
	{
		return !left.Equals(right);
	}
}
