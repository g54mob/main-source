using System;
using UnityEngine;

namespace CloudOnce.Internal
{
	public static class ConflictResolver
	{
		public static SyncableItem ResolveConflict(SyncableItem localItem, SyncableItem otherItem)
		{
			if (localItem.Metadata.PersistenceType != otherItem.Metadata.PersistenceType)
			{
				Debug.LogWarning("Tried to resolve data conflict, but the two items did not have the same PersistenceType! Will use local data.");
				return localItem;
			}
			if (localItem.Metadata.DataType != otherItem.Metadata.DataType)
			{
				Debug.LogWarning("Tried to resolve data conflict, but the two items did not have the same DataType! Will use local data.");
				return localItem;
			}
			return localItem.Metadata.PersistenceType switch
			{
				PersistenceType.Latest => MergeLatest(localItem, otherItem), 
				PersistenceType.Highest => MergeHighest(localItem, otherItem), 
				PersistenceType.Lowest => MergeLowest(localItem, otherItem), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}

		private static SyncableItem MergeLatest(SyncableItem localItem, SyncableItem otherItem)
		{
			if (localItem.Metadata.Timestamp.CompareTo(otherItem.Metadata.Timestamp) <= 0)
			{
				return otherItem;
			}
			return localItem;
		}

		private static SyncableItem MergeHighest(SyncableItem localItem, SyncableItem otherItem)
		{
			switch (localItem.Metadata.DataType)
			{
			case DataType.Bool:
			{
				if (int.TryParse(otherItem.ValueString, out var result))
				{
					if (result != 1)
					{
						return localItem;
					}
					return otherItem;
				}
				if (!Convert.ToBoolean(otherItem.ValueString))
				{
					return localItem;
				}
				return otherItem;
			}
			case DataType.Double:
				if (!(Convert.ToDouble(localItem.ValueString) > Convert.ToDouble(otherItem.ValueString)))
				{
					return otherItem;
				}
				return localItem;
			case DataType.Float:
				if (!(Convert.ToSingle(localItem.ValueString) > Convert.ToSingle(otherItem.ValueString)))
				{
					return otherItem;
				}
				return localItem;
			case DataType.Int:
				if (Convert.ToInt32(localItem.ValueString) <= Convert.ToInt32(otherItem.ValueString))
				{
					return otherItem;
				}
				return localItem;
			case DataType.String:
				if (localItem.ValueString.Length <= otherItem.ValueString.Length)
				{
					return otherItem;
				}
				return localItem;
			case DataType.UInt:
				if (Convert.ToUInt32(localItem.ValueString) <= Convert.ToUInt32(otherItem.ValueString))
				{
					return otherItem;
				}
				return localItem;
			case DataType.Long:
				if (Convert.ToInt64(localItem.ValueString) <= Convert.ToInt64(otherItem.ValueString))
				{
					return otherItem;
				}
				return localItem;
			case DataType.Decimal:
				if (!(Convert.ToDecimal(localItem.ValueString) > Convert.ToDecimal(otherItem.ValueString)))
				{
					return otherItem;
				}
				return localItem;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}

		private static SyncableItem MergeLowest(SyncableItem localItem, SyncableItem otherItem)
		{
			switch (localItem.Metadata.DataType)
			{
			case DataType.Bool:
			{
				if (int.TryParse(otherItem.ValueString, out var result))
				{
					if (result != 0)
					{
						return localItem;
					}
					return otherItem;
				}
				if (Convert.ToBoolean(otherItem.ValueString))
				{
					return localItem;
				}
				return otherItem;
			}
			case DataType.Double:
				if (!(Convert.ToDouble(localItem.ValueString) < Convert.ToDouble(otherItem.ValueString)))
				{
					return otherItem;
				}
				return localItem;
			case DataType.Float:
				if (!(Convert.ToSingle(localItem.ValueString) < Convert.ToSingle(otherItem.ValueString)))
				{
					return otherItem;
				}
				return localItem;
			case DataType.Int:
				if (Convert.ToInt32(localItem.ValueString) >= Convert.ToInt32(otherItem.ValueString))
				{
					return otherItem;
				}
				return localItem;
			case DataType.String:
				if (localItem.ValueString.Length >= otherItem.ValueString.Length)
				{
					return otherItem;
				}
				return localItem;
			case DataType.UInt:
				if (Convert.ToUInt32(localItem.ValueString) >= Convert.ToUInt32(otherItem.ValueString))
				{
					return otherItem;
				}
				return localItem;
			case DataType.Long:
				if (Convert.ToInt64(localItem.ValueString) >= Convert.ToInt64(otherItem.ValueString))
				{
					return otherItem;
				}
				return localItem;
			case DataType.Decimal:
				if (!(Convert.ToDecimal(localItem.ValueString) < Convert.ToDecimal(otherItem.ValueString)))
				{
					return otherItem;
				}
				return localItem;
			default:
				throw new ArgumentOutOfRangeException();
			}
		}
	}
}
