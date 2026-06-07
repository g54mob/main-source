using System;
using UnityEngine;

[Serializable]
public struct StockDemandData : IEquatable<StockDemandData>
{
	public string demandId;

	public string itemId;

	public string companyId;

	public string companyName;

	public int demandedAmount;

	public int pricePerUnit;

	public float demandMultiplier;

	public double createdTime;

	public bool IsValid
	{
		get
		{
			if (!string.IsNullOrEmpty(demandId) && !string.IsNullOrEmpty(itemId) && !string.IsNullOrEmpty(companyId))
			{
				return demandedAmount > 0;
			}
			return false;
		}
	}

	public int TotalPrice => demandedAmount * pricePerUnit;

	public static StockDemandData Create(T_ItemSO item, CompanySO company, int amount, int pricePerUnit, float demandMultiplier = 1f)
	{
		if (item == null || company == null)
		{
			Debug.LogWarning("[StockDemandData] Item veya Company null!");
			return default(StockDemandData);
		}
		return new StockDemandData
		{
			demandId = GenerateDemandId(),
			itemId = item.GetItemID(),
			companyId = company.CompanyId,
			companyName = company.companyName,
			demandedAmount = amount,
			pricePerUnit = pricePerUnit,
			demandMultiplier = demandMultiplier,
			createdTime = NetworkTimeHelper.GetNetworkTime()
		};
	}

	public static StockDemandData Create(string itemId, CompanySO company, int amount, int pricePerUnit, float demandMultiplier = 1f)
	{
		if (string.IsNullOrEmpty(itemId) || company == null)
		{
			Debug.LogWarning("[StockDemandData] ItemId boş veya Company null!");
			return default(StockDemandData);
		}
		return new StockDemandData
		{
			demandId = GenerateDemandId(),
			itemId = itemId,
			companyId = company.CompanyId,
			companyName = company.companyName,
			demandedAmount = amount,
			pricePerUnit = pricePerUnit,
			demandMultiplier = demandMultiplier,
			createdTime = NetworkTimeHelper.GetNetworkTime()
		};
	}

	private static string GenerateDemandId()
	{
		return $"SD_{DateTime.UtcNow.Ticks:X}_{UnityEngine.Random.Range(1000, 9999)}";
	}

	public bool Equals(StockDemandData other)
	{
		if (demandId == other.demandId && itemId == other.itemId && companyId == other.companyId && companyName == other.companyName && demandedAmount == other.demandedAmount && pricePerUnit == other.pricePerUnit && Mathf.Approximately(demandMultiplier, other.demandMultiplier))
		{
			return createdTime == other.createdTime;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is StockDemandData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (((17 * 31 + (demandId?.GetHashCode() ?? 0)) * 31 + demandedAmount) * 31 + pricePerUnit) * 31 + demandMultiplier.GetHashCode();
	}

	public static bool operator ==(StockDemandData left, StockDemandData right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(StockDemandData left, StockDemandData right)
	{
		return !left.Equals(right);
	}
}
