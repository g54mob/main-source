using System;
using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	[Serializable]
	public class PolygonGroupManager
	{
		[SerializeField]
		private List<PolygonGroup> polygonGroups_ = new List<PolygonGroup>();

		public string GetActiveGroupName()
		{
			PolygonGroup polygonGroup = FindPolygonGroup(UMContext.activeModeler.editableMesh.activePolygonGroupId);
			if (polygonGroup != null)
			{
				return polygonGroup.name;
			}
			return string.Empty;
		}

		public PolygonGroup AddGroup(string name)
		{
			PolygonGroup polygonGroup = FindPolygonGroup(name);
			if (polygonGroup != null)
			{
				return polygonGroup;
			}
			PolygonGroup polygonGroup2 = new PolygonGroup();
			polygonGroup2.name = name;
			polygonGroups_.Add(polygonGroup2);
			return polygonGroup2;
		}

		public PolygonGroup FindPolygonGroup(string name)
		{
			int num = FindPolygonGroupIndex(name);
			if (num != -1)
			{
				return polygonGroups_[num];
			}
			return null;
		}

		public PolygonGroup FindPolygonGroup(ulong instanceID)
		{
			for (int i = 0; i < GetPolygonGroupCount(); i++)
			{
				if (GetPolygonGroup(i).instanceID == instanceID)
				{
					return GetPolygonGroup(i);
				}
			}
			return null;
		}

		public int FindPolygonGroupIndex(string name)
		{
			for (int i = 0; i < GetPolygonGroupCount(); i++)
			{
				if (GetPolygonGroup(i).name == name)
				{
					return i;
				}
			}
			return -1;
		}

		public void RemovePolygon(SimplePolygon polygon)
		{
			polygon.groupID = 0uL;
		}

		public bool Contains(SimplePolygon polygon)
		{
			return polygon.groupID != 0;
		}

		public int GetPolygonGroupCount()
		{
			return polygonGroups_.Count;
		}

		public PolygonGroup GetPolygonGroup(int idx)
		{
			return polygonGroups_[idx];
		}

		public void RemoveGroup(int idx)
		{
			polygonGroups_.RemoveAt(idx);
		}

		public int FindPolygonGroupIndex(ulong instanceID)
		{
			for (int i = 0; i < polygonGroups_.Count; i++)
			{
				if (polygonGroups_[i].instanceID == instanceID)
				{
					return i;
				}
			}
			return -1;
		}

		public string[] GetNames()
		{
			if (polygonGroups_.Count == 0)
			{
				return null;
			}
			string[] array = new string[polygonGroups_.Count];
			for (int i = 0; i < polygonGroups_.Count; i++)
			{
				array[i] = polygonGroups_[i].name;
			}
			return array;
		}

		public void Clear()
		{
			polygonGroups_.Clear();
		}

		public PolygonGroupManager Clone()
		{
			PolygonGroupManager polygonGroupManager = new PolygonGroupManager();
			for (int i = 0; i < GetPolygonGroupCount(); i++)
			{
				polygonGroupManager.polygonGroups_.Add(GetPolygonGroup(i).Clone());
			}
			return polygonGroupManager;
		}

		public List<string> GetGroupNameList()
		{
			List<string> list = new List<string>();
			for (int i = 0; i < polygonGroups_.Count; i++)
			{
				list.Add(polygonGroups_[i].name);
			}
			return list;
		}

		public void RemoveAllEmpty()
		{
			polygonGroups_.RemoveAll(IsPolygonGroupEmpty);
		}

		private bool IsPolygonGroupEmpty(PolygonGroup group)
		{
			if (UMContext.activeModeler == null)
			{
				return true;
			}
			EditableMesh editableMesh = UMContext.activeModeler.editableMesh;
			int num = 0;
			using (new ShelfHolder())
			{
				for (int i = 0; i < 2; i++)
				{
					editableMesh.shelf = i;
					for (int j = 0; j < editableMesh.GetPolygonCount(); j++)
					{
						if (editableMesh.GetPolygon(j).groupID == group.instanceID)
						{
							num++;
						}
					}
				}
			}
			return num == 0;
		}
	}
}
