using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class SmoothingGroupManager
	{
		[SerializeField]
		private List<SmoothingGroup> smoothing_groups_ = new List<SmoothingGroup>();

		[SerializeField]
		private byte[] smoothingGroupStream_;

		private List<SmoothingGroup> smoothing_groupsList_ = new List<SmoothingGroup>();

		public SmoothingGroup AddSmoothingGroup(string name)
		{
			SmoothingGroup smoothingGroup = new SmoothingGroup();
			smoothingGroup.name = name;
			smoothing_groupsList_.Add(smoothingGroup);
			return smoothingGroup;
		}

		public SmoothingGroup FindSmoothingGroup(string name)
		{
			int num = FindSmoothingGroupIndex(name);
			if (num != -1)
			{
				return smoothing_groupsList_[num];
			}
			return null;
		}

		public int FindSmoothingGroupIndex(string name)
		{
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				if (GetSmoothingGroup(i).name == name)
				{
					return i;
				}
			}
			return -1;
		}

		public SmoothingGroup FindSmoothingGroupIncludingPolygon(SimplePolygon polygon)
		{
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				SmoothingGroup smoothingGroup = GetSmoothingGroup(i);
				if (smoothingGroup.Contains(polygon))
				{
					return smoothingGroup;
				}
			}
			return null;
		}

		public int FindSmoothingGroupIndexIncludingPolygon(SimplePolygon polygon)
		{
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				if (GetSmoothingGroup(i).Contains(polygon))
				{
					return i;
				}
			}
			return -1;
		}

		public bool RemovePolygon(SimplePolygon polygon)
		{
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				if (GetSmoothingGroup(i).RemovePolygon(polygon))
				{
					return true;
				}
			}
			return false;
		}

		public int Contains(SimplePolygon polygon)
		{
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				if (GetSmoothingGroup(i).Contains(polygon))
				{
					return i;
				}
			}
			return -1;
		}

		public int GetSmoothingGroupCount()
		{
			return smoothing_groupsList_.Count;
		}

		public SmoothingGroup GetSmoothingGroup(int idx)
		{
			return smoothing_groupsList_[idx];
		}

		public int GetSmoothingGroupIndex(SmoothingGroup group)
		{
			return smoothing_groups_.IndexOf(group);
		}

		public Dictionary<SmoothingGroup, List<ulong>> GetSmoothingGroupDictionary(List<SimplePolygon> polygons)
		{
			return (from a in polygons
				group a by FindSmoothingGroupIncludingPolygon(a) into a
				where a.Key != null
				select a).ToDictionary((IGrouping<SmoothingGroup, SimplePolygon> a) => a.Key, (IGrouping<SmoothingGroup, SimplePolygon> a) => a.Select((SimplePolygon b) => b.instanceID).ToList());
		}

		public void RemoveGroup(int idx)
		{
			smoothing_groupsList_.RemoveAt(idx);
		}

		public void SetName(int idx, string name)
		{
			smoothing_groupsList_[idx].name = name;
		}

		public string[] GetNames()
		{
			if (smoothing_groupsList_.Count == 0)
			{
				return null;
			}
			string[] array = new string[smoothing_groupsList_.Count];
			for (int i = 0; i < smoothing_groupsList_.Count; i++)
			{
				array[i] = smoothing_groupsList_[i].name;
			}
			return array;
		}

		public void Clear()
		{
			smoothing_groupsList_.Clear();
		}

		public SmoothingGroupManager Clone(Dictionary<SimplePolygon, SimplePolygon> originalToClone)
		{
			SmoothingGroupManager smoothingGroupManager = new SmoothingGroupManager();
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				smoothingGroupManager.smoothing_groupsList_.Add(GetSmoothingGroup(i).Clone(originalToClone) as SmoothingGroup);
			}
			return smoothingGroupManager;
		}

		public void Invalidate()
		{
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				GetSmoothingGroup(i).Invalidate();
			}
		}

		public void Refresh()
		{
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				SmoothingGroup smoothingGroup = GetSmoothingGroup(i);
				if (!smoothingGroup.RemoveUnused())
				{
					smoothingGroup.Refresh();
				}
			}
		}

		public void RemoveAllEmpty()
		{
			smoothing_groupsList_.RemoveAll(IsSmoothingGroupEmpty);
		}

		public void RemoveAll()
		{
			smoothing_groupsList_.Clear();
		}

		private bool IsSmoothingGroupEmpty(SmoothingGroup group)
		{
			return group.GetPolygonCount() == 0;
		}

		private void RemoveUnused()
		{
			for (int i = 0; i < GetSmoothingGroupCount(); i++)
			{
				GetSmoothingGroup(i).RemoveUnused();
			}
			RemoveAllEmpty();
		}

		public ulong CollectLatestID()
		{
			ulong num = 0uL;
			for (int i = 0; i < smoothing_groupsList_.Count; i++)
			{
				if (smoothing_groupsList_[i].instanceID > num)
				{
					num = smoothing_groupsList_[i].instanceID;
				}
			}
			return num;
		}

		public void CheckInstanceID(List<ulong> instanceIDs)
		{
			for (int i = 0; i < smoothing_groupsList_.Count; i++)
			{
				if (instanceIDs.IndexOf(smoothing_groupsList_[i].instanceID) != -1)
				{
					smoothing_groupsList_[i].RegenerateInstanceID();
				}
				instanceIDs.Add(smoothing_groupsList_[i].instanceID);
			}
		}

		public void BeforeSerialize(int editMeshVersion)
		{
		}

		public void AfterDeserialize(int editMeshVersion)
		{
			if (smoothingGroupStream_ != null && smoothingGroupStream_.Length != 0)
			{
				MemoryStream memoryStream = new MemoryStream(smoothingGroupStream_);
				BinaryReader binaryReader = new BinaryReader(memoryStream);
				binaryReader.ReadInt32();
				int num = binaryReader.ReadInt32();
				smoothing_groups_.Clear();
				smoothing_groups_.Capacity = num;
				for (int i = 0; i < num; i++)
				{
					SmoothingGroup smoothingGroup = new SmoothingGroup();
					smoothingGroup.Read(binaryReader);
					smoothing_groups_.Add(smoothingGroup);
				}
				binaryReader.Close();
				memoryStream.Close();
				smoothingGroupStream_ = null;
			}
			smoothing_groupsList_ = smoothing_groups_;
			for (int j = 0; j < smoothing_groupsList_.Count; j++)
			{
				smoothing_groupsList_[j].SetDirtyCache();
			}
		}

		public void InitCommon(int editMeshVersion)
		{
			smoothing_groupsList_ = smoothing_groups_;
		}

		public void ConvertStream(int editMeshVersion)
		{
		}
	}
}
