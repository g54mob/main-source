using System;
using System.Collections.Generic;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.PersistentStorage
{
	[Serializable]
	public class PersistentVegetationCell
	{
		public List<PersistentVegetationInfo> PersistentVegetationInfoList = new List<PersistentVegetationInfo>();

		public void Dispose()
		{
			for (int i = 0; i <= PersistentVegetationInfoList.Count - 1; i++)
			{
				PersistentVegetationInfoList[i].Dispose();
			}
		}

		public void AddVegetationItemInstance(string vegetationItemID, Vector3 position, Vector3 scale, Quaternion rotation, byte vegetationSourceID, float distanceFalloff)
		{
			PersistentVegetationInfo persistentVegetationInfo = GetPersistentVegetationInfo(vegetationItemID);
			if (persistentVegetationInfo == null)
			{
				persistentVegetationInfo = new PersistentVegetationInfo
				{
					VegetationItemID = vegetationItemID
				};
				PersistentVegetationInfoList.Add(persistentVegetationInfo);
			}
			PersistentVegetationItem persistentVegetationItem = new PersistentVegetationItem
			{
				Position = position,
				Rotation = rotation,
				Scale = scale,
				VegetationSourceID = vegetationSourceID,
				DistanceFalloff = distanceFalloff
			};
			persistentVegetationInfo.AddPersistentVegetationItemInstance(ref persistentVegetationItem);
		}

		public void RemoveVegetationItemInstance(string vegetationItemID, Vector3 position, float minimumDistance)
		{
			PersistentVegetationInfo persistentVegetationInfo = GetPersistentVegetationInfo(vegetationItemID);
			if (persistentVegetationInfo == null)
			{
				return;
			}
			for (int num = persistentVegetationInfo.VegetationItemList.Count - 1; num >= 0; num--)
			{
				if (Vector3.Distance(persistentVegetationInfo.VegetationItemList[num].Position, position) < minimumDistance)
				{
					persistentVegetationInfo.VegetationItemList.RemoveAt(num);
				}
			}
		}

		public void RemoveVegetationItemInstance2D(string vegetationItemID, Vector3 position, float minimumDistance)
		{
			PersistentVegetationInfo persistentVegetationInfo = GetPersistentVegetationInfo(vegetationItemID);
			if (persistentVegetationInfo == null)
			{
				return;
			}
			for (int num = persistentVegetationInfo.VegetationItemList.Count - 1; num >= 0; num--)
			{
				if (Vector2.Distance(new Vector2(persistentVegetationInfo.VegetationItemList[num].Position.x, persistentVegetationInfo.VegetationItemList[num].Position.z), new Vector2(position.x, position.z)) < minimumDistance)
				{
					persistentVegetationInfo.VegetationItemList.RemoveAt(num);
				}
			}
		}

		public void AddVegetationItemInstanceEx(string vegetationItemID, Vector3 position, Vector3 scale, Quaternion rotation, byte vegetationSourceID, float minimumDistance, float distanceFalloff)
		{
			PersistentVegetationInfo persistentVegetationInfo = GetPersistentVegetationInfo(vegetationItemID);
			if (persistentVegetationInfo == null)
			{
				persistentVegetationInfo = new PersistentVegetationInfo
				{
					VegetationItemID = vegetationItemID
				};
				PersistentVegetationInfoList.Add(persistentVegetationInfo);
			}
			if (!(CalculateClosestItemDistance(position, persistentVegetationInfo.VegetationItemList) < minimumDistance))
			{
				PersistentVegetationItem persistentVegetationItem = new PersistentVegetationItem
				{
					Position = position,
					Rotation = rotation,
					Scale = scale,
					VegetationSourceID = vegetationSourceID,
					DistanceFalloff = distanceFalloff
				};
				persistentVegetationInfo.AddPersistentVegetationItemInstance(ref persistentVegetationItem);
			}
		}

		private float CalculateClosestItemDistance(Vector3 position, List<PersistentVegetationItem> instanceList)
		{
			float num = float.PositiveInfinity;
			Vector3 a = Vector3.zero;
			for (int i = 0; i < instanceList.Count; i++)
			{
				float sqrMagnitude = (instanceList[i].Position - position).sqrMagnitude;
				if (sqrMagnitude < num)
				{
					num = sqrMagnitude;
					a = instanceList[i].Position;
				}
			}
			return Vector3.Distance(a, position);
		}

		public void ClearCell()
		{
			PersistentVegetationInfoList.Clear();
		}

		public PersistentVegetationInfo GetPersistentVegetationInfo(string vegetationItemID)
		{
			for (int i = 0; i <= PersistentVegetationInfoList.Count - 1; i++)
			{
				if (PersistentVegetationInfoList[i].VegetationItemID == vegetationItemID)
				{
					return PersistentVegetationInfoList[i];
				}
			}
			return null;
		}

		public void RemoveVegetationItemInstances(string vegetationItemID)
		{
			PersistentVegetationInfo persistentVegetationInfo = GetPersistentVegetationInfo(vegetationItemID);
			if (persistentVegetationInfo != null)
			{
				PersistentVegetationInfoList.Remove(persistentVegetationInfo);
			}
		}

		public void RemoveVegetationItemInstances(string vegetationItemID, byte vegetationSourceID)
		{
			PersistentVegetationInfo persistentVegetationInfo = GetPersistentVegetationInfo(vegetationItemID);
			if (persistentVegetationInfo == null)
			{
				return;
			}
			for (int num = persistentVegetationInfo.VegetationItemList.Count - 1; num >= 0; num--)
			{
				if (persistentVegetationInfo.VegetationItemList[num].VegetationSourceID == vegetationSourceID)
				{
					persistentVegetationInfo.RemovePersistentVegetationInstanceAtIndex(num);
				}
			}
			if (persistentVegetationInfo.VegetationItemList.Count == 0)
			{
				PersistentVegetationInfoList.Remove(persistentVegetationInfo);
			}
		}
	}
}
