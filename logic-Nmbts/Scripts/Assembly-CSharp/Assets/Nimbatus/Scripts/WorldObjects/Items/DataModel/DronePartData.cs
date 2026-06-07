using System;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel
{
	[Serializable]
	public class DronePartData : NimbatusItemData
	{
		public Vector3 CurrentPosition { get; set; }

		public Quaternion CurrentRotation { get; set; }

		public Vector3 OriginalPosition { get; set; }

		public Quaternion OriginalRotation { get; set; }

		public int SkinRotation { get; set; }

		public string SkinId { get; set; }

		public bool SkinFlippedY { get; set; }

		public bool SkinFlippedX { get; set; }

		public float SkinPivotY { get; set; }

		public float SkinPivotX { get; set; }

		public float SkinZOrder { get; set; }

		public List<DronePartData> Children { get; set; }

		public int GetNumberOfParts(string id)
		{
			return this.GetNumberOfDroneParts((DronePartData p) => p.PrefabId == id);
		}

		public int GetNumberOfParts<T>() where T : DronePartData
		{
			return this.GetNumberOfDroneParts((DronePartData p) => p is T);
		}

		public void FillUsedWeapons(ref List<string> retval)
		{
			if (this is WeaponData && !retval.Contains(base.PrefabId))
			{
				retval.Add(base.PrefabId);
			}
			foreach (DronePartData child in Children)
			{
				child.FillUsedWeapons(ref retval);
			}
		}

		public void FillUsedParts(ref Dictionary<string, int> retval)
		{
			if (!retval.ContainsKey(base.PrefabId))
			{
				retval.Add(base.PrefabId, 1);
			}
			else
			{
				retval[base.PrefabId]++;
			}
			foreach (DronePartData child in Children)
			{
				child.FillUsedParts(ref retval);
			}
		}

		public void ReplaceId(string oldId, string newId)
		{
			if (base.PrefabId == oldId)
			{
				base.PrefabId = newId;
			}
			foreach (DronePartData child in Children)
			{
				child.ReplaceId(oldId, newId);
			}
		}
	}
}
