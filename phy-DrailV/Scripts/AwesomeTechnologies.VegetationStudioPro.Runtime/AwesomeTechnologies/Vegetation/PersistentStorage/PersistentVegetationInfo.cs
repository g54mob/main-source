using System;
using System.Collections.Generic;
using AwesomeTechnologies.Utility;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.PersistentStorage
{
	[Serializable]
	public class PersistentVegetationInfo
	{
		public string VegetationItemID;

		[SerializeField]
		public List<PersistentVegetationItem> VegetationItemList = new List<PersistentVegetationItem>();

		[NonSerialized]
		public NativeArray<PersistentVegetationItem> NativeVegetationItemArray;

		public List<SourceCount> SourceCountList = new List<SourceCount>();

		public void CopyToNativeArray()
		{
			NativeVegetationItemArray = new NativeArray<PersistentVegetationItem>(VegetationItemList.Count, Allocator.Persistent);
			NativeVegetationItemArray.CopyFromFast(VegetationItemList);
		}

		public void ClearCell()
		{
			VegetationItemList.Clear();
			SourceCountList.Clear();
		}

		public void AddPersistentVegetationItemInstance(ref PersistentVegetationItem persistentVegetationItem)
		{
			IncreaseSourceCount(persistentVegetationItem.VegetationSourceID);
			VegetationItemList.Add(persistentVegetationItem);
		}

		public void RemovePersistentVegetationItemInstance(ref PersistentVegetationItem persistentVegetationItem)
		{
			DecreaseSourceCount(persistentVegetationItem.VegetationSourceID);
			VegetationItemList.Remove(persistentVegetationItem);
		}

		public void RemovePersistentVegetationInstanceAtIndex(int index)
		{
			if (index < VegetationItemList.Count)
			{
				DecreaseSourceCount(VegetationItemList[index].VegetationSourceID);
				VegetationItemList.RemoveAt(index);
			}
		}

		public void UpdatePersistentVegetationItemInstanceSourceId(ref PersistentVegetationItem persistentVegetationItem, byte newSourceID)
		{
			if (persistentVegetationItem.VegetationSourceID != newSourceID)
			{
				DecreaseSourceCount(persistentVegetationItem.VegetationSourceID);
				persistentVegetationItem.VegetationSourceID = newSourceID;
				IncreaseSourceCount(persistentVegetationItem.VegetationSourceID);
			}
		}

		private void IncreaseSourceCount(byte vegetationSourceID)
		{
			SourceCount sourceCount = GetSourceCount(vegetationSourceID);
			if (sourceCount == null)
			{
				sourceCount = new SourceCount
				{
					VegetationSourceID = vegetationSourceID
				};
				SourceCountList.Add(sourceCount);
			}
			sourceCount.Count++;
		}

		private SourceCount GetSourceCount(byte vegetationSourceID)
		{
			for (int i = 0; i <= SourceCountList.Count - 1; i++)
			{
				if (SourceCountList[i].VegetationSourceID == vegetationSourceID)
				{
					return SourceCountList[i];
				}
			}
			return null;
		}

		private void DecreaseSourceCount(byte vegetationSourceID)
		{
			SourceCount sourceCount = GetSourceCount(vegetationSourceID);
			if (sourceCount != null)
			{
				sourceCount.Count--;
				if (sourceCount.Count == 0)
				{
					SourceCountList.Remove(sourceCount);
				}
			}
		}

		public void Dispose()
		{
			if (NativeVegetationItemArray.IsCreated)
			{
				NativeVegetationItemArray.Dispose();
			}
		}
	}
}
