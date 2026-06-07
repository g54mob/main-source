using System;
using Enviro;
using UnityEngine;

[Serializable]
public struct ActiveContractData : IEquatable<ActiveContractData>
{
	public string activeId;

	public string listingId;

	public string contractId;

	public string propertyConfigId;

	public string companyName;

	public int agreedPrice;

	public int deliveryDays;

	public string[] materialIds;

	public int[] materialCounts;

	public int[] deliveredCounts;

	public int acceptedDay;

	public int deadlineDay;

	public ActiveContractState state;

	public int contractNumber;

	public bool IsValid
	{
		get
		{
			if (!string.IsNullOrEmpty(activeId))
			{
				return state != ActiveContractState.None;
			}
			return false;
		}
	}

	public bool IsActive => state == ActiveContractState.InProgress;

	public bool IsExpired
	{
		get
		{
			if (DayNightManager.Instance == null)
			{
				return false;
			}
			return DayNightManager.Instance.CurrentGameDay > deadlineDay;
		}
	}

	public bool IsCompleted => AllMaterialsDelivered();

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

	public int RemainingDays
	{
		get
		{
			if (DayNightManager.Instance == null)
			{
				return 0;
			}
			int num = deadlineDay - DayNightManager.Instance.CurrentGameDay;
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}
	}

	public float TimeProgress
	{
		get
		{
			int num = deadlineDay - acceptedDay;
			if (num <= 0)
			{
				return 1f;
			}
			if (DayNightManager.Instance == null)
			{
				return 0f;
			}
			return Mathf.Clamp01((float)(DayNightManager.Instance.CurrentGameDay - acceptedDay) / (float)num);
		}
	}

	public static ActiveContractData CreateFromListing(ContractListingData listing, int negotiatedPrice)
	{
		int num = ((!(DayNightManager.Instance != null)) ? 1 : DayNightManager.Instance.CurrentGameDay);
		int num2 = num + listing.deliveryDays;
		int[] array = listing.materialCounts;
		int[] array2 = new int[(array != null) ? array.Length : 0];
		return new ActiveContractData
		{
			activeId = GenerateActiveId(),
			listingId = listing.listingId,
			contractId = listing.contractId,
			propertyConfigId = listing.propertyConfigId,
			companyName = listing.companyName,
			agreedPrice = negotiatedPrice,
			deliveryDays = listing.deliveryDays,
			materialIds = ((listing.materialIds != null) ? ((string[])listing.materialIds.Clone()) : new string[0]),
			materialCounts = ((listing.materialCounts != null) ? ((int[])listing.materialCounts.Clone()) : new int[0]),
			deliveredCounts = array2,
			acceptedDay = num,
			deadlineDay = num2,
			state = ActiveContractState.InProgress,
			contractNumber = listing.contractNumber
		};
	}

	public float GetMaterialProgress(int index)
	{
		if (materialCounts == null || deliveredCounts == null || index < 0 || index >= materialCounts.Length || index >= deliveredCounts.Length)
		{
			return 0f;
		}
		if (materialCounts[index] <= 0)
		{
			return 1f;
		}
		return Mathf.Clamp01((float)deliveredCounts[index] / (float)materialCounts[index]);
	}

	public bool TryGetMaterialProgress(int index, out int delivered, out int required)
	{
		if (materialCounts != null && deliveredCounts != null && index >= 0 && index < materialCounts.Length && index < deliveredCounts.Length)
		{
			delivered = deliveredCounts[index];
			required = materialCounts[index];
			return true;
		}
		delivered = 0;
		required = 0;
		return false;
	}

	public bool AllMaterialsDelivered()
	{
		if (materialCounts == null || deliveredCounts == null)
		{
			return false;
		}
		if (materialCounts.Length != deliveredCounts.Length)
		{
			return false;
		}
		for (int i = 0; i < materialCounts.Length; i++)
		{
			if (deliveredCounts[i] < materialCounts[i])
			{
				return false;
			}
		}
		return true;
	}

	public float GetTotalProgress()
	{
		if (materialCounts == null || deliveredCounts == null || materialCounts.Length == 0)
		{
			return 0f;
		}
		int num = 0;
		int num2 = 0;
		for (int i = 0; i < materialCounts.Length; i++)
		{
			num += materialCounts[i];
			if (i < deliveredCounts.Length)
			{
				num2 += Mathf.Min(deliveredCounts[i], materialCounts[i]);
			}
		}
		if (num <= 0)
		{
			return 1f;
		}
		return Mathf.Clamp01((float)num2 / (float)num);
	}

	public ActiveContractData DeliverMaterial(int materialIndex, int amount)
	{
		ActiveContractData result = this;
		if (result.state != ActiveContractState.InProgress)
		{
			Debug.LogWarning("[ActiveContractData] Contract aktif değil, malzeme teslim edilemez!");
			return result;
		}
		if (materialIndex < 0 || materialIndex >= result.deliveredCounts.Length)
		{
			Debug.LogWarning($"[ActiveContractData] Geçersiz material index: {materialIndex}");
			return result;
		}
		result.deliveredCounts = (int[])result.deliveredCounts.Clone();
		result.deliveredCounts[materialIndex] += amount;
		if (result.deliveredCounts[materialIndex] > result.materialCounts[materialIndex])
		{
			result.deliveredCounts[materialIndex] = result.materialCounts[materialIndex];
		}
		if (result.AllMaterialsDelivered())
		{
			result.state = ActiveContractState.Completed;
		}
		return result;
	}

	public ActiveContractData MarkAsFailed()
	{
		ActiveContractData result = this;
		result.state = ActiveContractState.Failed;
		return result;
	}

	public ActiveContractData Cancel()
	{
		ActiveContractData result = this;
		result.state = ActiveContractState.Cancelled;
		return result;
	}

	private static string GenerateActiveId()
	{
		return $"AC_{DateTime.UtcNow.Ticks:X}_{UnityEngine.Random.Range(1000, 9999)}";
	}

	public bool Equals(ActiveContractData other)
	{
		return activeId == other.activeId;
	}

	public override bool Equals(object obj)
	{
		if (obj is ActiveContractData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return activeId?.GetHashCode() ?? 0;
	}

	public static bool operator ==(ActiveContractData left, ActiveContractData right)
	{
		return left.Equals(right);
	}

	public static bool operator !=(ActiveContractData left, ActiveContractData right)
	{
		return !left.Equals(right);
	}
}
