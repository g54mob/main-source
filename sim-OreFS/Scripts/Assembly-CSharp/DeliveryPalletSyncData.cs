using System;
using System.Collections.Generic;

[Serializable]
public struct DeliveryPalletSyncData : IEquatable<DeliveryPalletSyncData>
{
	public string activeContractId;

	public string[] itemIds;

	public int[] itemCounts;

	public int[] maxCounts;

	public bool IsEmpty
	{
		get
		{
			if (itemCounts == null || itemCounts.Length == 0)
			{
				return true;
			}
			int[] array = itemCounts;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] > 0)
				{
					return false;
				}
			}
			return true;
		}
	}

	public int TotalItemCount
	{
		get
		{
			if (itemCounts == null)
			{
				return 0;
			}
			int num = 0;
			int[] array = itemCounts;
			foreach (int num2 in array)
			{
				num += num2;
			}
			return num;
		}
	}

	public int TotalMaxCount
	{
		get
		{
			if (maxCounts == null)
			{
				return 0;
			}
			int num = 0;
			int[] array = maxCounts;
			foreach (int num2 in array)
			{
				num += num2;
			}
			return num;
		}
	}

	public bool Equals(DeliveryPalletSyncData other)
	{
		if (activeContractId != other.activeContractId)
		{
			return false;
		}
		if (!ArrayEquals(itemIds, other.itemIds))
		{
			return false;
		}
		if (!ArrayEquals(itemCounts, other.itemCounts))
		{
			return false;
		}
		if (!ArrayEquals(maxCounts, other.maxCounts))
		{
			return false;
		}
		return true;
	}

	private bool ArrayEquals<T>(T[] a, T[] b)
	{
		if (a == null && b == null)
		{
			return true;
		}
		if (a == null || b == null)
		{
			return false;
		}
		if (a.Length != b.Length)
		{
			return false;
		}
		for (int i = 0; i < a.Length; i++)
		{
			if (!EqualityComparer<T>.Default.Equals(a[i], b[i]))
			{
				return false;
			}
		}
		return true;
	}

	public override bool Equals(object obj)
	{
		if (obj is DeliveryPalletSyncData other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		int num = (17 * 31 + (activeContractId?.GetHashCode() ?? 0)) * 31;
		string[] array = itemIds;
		return (num + ((array != null) ? array.Length : 0)) * 31 + TotalItemCount;
	}
}
