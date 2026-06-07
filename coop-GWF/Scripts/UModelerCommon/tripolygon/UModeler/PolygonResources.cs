using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public abstract class PolygonResources
	{
		[SerializeField]
		private List<PolygonAndID> polygonsAndIDs_ = new List<PolygonAndID>();

		[SerializeField]
		private ulong instanceID_ = ((UMContext.activeModeler != null) ? UModeler.GenerateID() : 0);

		private bool cacheEnable;

		private Dictionary<ulong, PolygonAndID> polygonsCache = new Dictionary<ulong, PolygonAndID>();

		public ulong instanceID => instanceID_;

		public int GetPolygonCount()
		{
			return polygonsAndIDs_.Count;
		}

		public SimplePolygon GetPolygon(int index)
		{
			return polygonsAndIDs_[index].polygon;
		}

		public void ValidateInstanceID()
		{
			if (instanceID_ == 0L)
			{
				instanceID_ = UModeler.GenerateID();
			}
		}

		public void RegenerateInstanceID()
		{
			instanceID_ = UModeler.GenerateID();
		}

		public void SetDirtyCache()
		{
			cacheEnable = false;
		}

		public void RefreshCache()
		{
			if (cacheEnable)
			{
				return;
			}
			cacheEnable = true;
			polygonsCache.Clear();
			foreach (PolygonAndID item in polygonsAndIDs_)
			{
				polygonsCache.Add(item.id, item);
			}
		}

		public virtual void Read(BinaryReader binaryReader)
		{
			int num = binaryReader.ReadInt32();
			polygonsAndIDs_.Clear();
			polygonsAndIDs_.Capacity = num;
			for (int i = 0; i < num; i++)
			{
				PolygonAndID polygonAndID = new PolygonAndID();
				polygonAndID.polygonID = binaryReader.ReadUInt64();
				polygonsAndIDs_.Add(polygonAndID);
			}
			instanceID_ = binaryReader.ReadUInt64();
			SetDirtyCache();
			RefreshCache();
		}

		public virtual void Write(BinaryWriter binaryWriter)
		{
			binaryWriter.Write(polygonsAndIDs_.Count);
			for (int i = 0; i < polygonsAndIDs_.Count; i++)
			{
				binaryWriter.Write(polygonsAndIDs_[i].id);
			}
			binaryWriter.Write(instanceID_);
		}

		public virtual void Refresh()
		{
			for (int i = 0; i < polygonsAndIDs_.Count; i++)
			{
				polygonsAndIDs_[i].Refresh();
			}
			Invalidate();
		}

		public bool IsEquivalent(PolygonResources island)
		{
			if (this == island)
			{
				return true;
			}
			if (island.GetPolygonCount() != GetPolygonCount())
			{
				return false;
			}
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				if (GetPolygon(i).instanceID != island.GetPolygon(i).instanceID)
				{
					return false;
				}
			}
			return true;
		}

		public virtual PolygonResources Clone(Dictionary<SimplePolygon, SimplePolygon> originalToClone)
		{
			PolygonResources polygonResources = CreateResources();
			for (int i = 0; i < polygonsAndIDs_.Count; i++)
			{
				polygonResources.AddPolygon(polygonsAndIDs_[i].Clone(originalToClone).polygon);
			}
			return polygonResources;
		}

		public virtual void AddPolygon(SimplePolygon polygon)
		{
			if (!Contains(polygon))
			{
				RefreshCache();
				PolygonAndID polygonAndID = new PolygonAndID(polygon);
				polygonsAndIDs_.Add(polygonAndID);
				polygonsCache.Add(polygonAndID.id, polygonAndID);
				Invalidate();
			}
		}

		public bool Contains(SimplePolygon polygon)
		{
			RefreshCache();
			if (polygonsCache.ContainsKey(polygon.instanceID))
			{
				return true;
			}
			return false;
		}

		public void Set(int index, SimplePolygon polygon)
		{
			polygonsAndIDs_[index].polygon = polygon;
			Refresh();
		}

		public bool RemoveUnused()
		{
			if (polygonsAndIDs_.RemoveAll(IsUnusedPolygon) > 0)
			{
				SetDirtyCache();
				RefreshCache();
				Refresh();
				return true;
			}
			return false;
		}

		public bool IsUnusedPolygon(PolygonAndID polygonAndID)
		{
			return FindPolygonInEdMesh(polygonAndID.id) == null;
		}

		public bool RemovePolygon(SimplePolygon polygon)
		{
			if (polygonsCache.TryGetValue(polygon.instanceID, out var value))
			{
				polygonsCache.Remove(polygon.instanceID);
				polygonsAndIDs_.Remove(value);
			}
			return false;
		}

		public Vector3 ComputeAverageNormal()
		{
			Vector3 zero = Vector3.zero;
			for (int i = 0; i < GetPolygonCount(); i++)
			{
				zero += GetPolygon(i).plane.normal;
			}
			return zero.normalized;
		}

		private SimplePolygon FindPolygonInEdMesh(ulong polygonId)
		{
			SimplePolygon simplePolygon = null;
			using (new ShelfHolder())
			{
				UMContext.activeModeler.editableMesh.shelf = 0;
				simplePolygon = UMContext.activeModeler.editableMesh.FindPolygon(polygonId);
				if (simplePolygon == null)
				{
					UMContext.activeModeler.editableMesh.shelf = 1;
					simplePolygon = UMContext.activeModeler.editableMesh.FindPolygon(polygonId);
				}
			}
			return simplePolygon;
		}

		public abstract void Invalidate();

		protected abstract PolygonResources CreateResources();
	}
}
