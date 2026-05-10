using System.Collections.Generic;
using System.Linq;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public class SaveCustomerGroups : SaveContainer
	{
		private static readonly HashSet<(int, CustomerGroupData)> _loadedGroups = new HashSet<(int, CustomerGroupData)>();

		public override void Save(ES3Settings settings)
		{
			List<CustomerGroupData> list = GameObject.Find("CustomerGroups").GetComponentsInChildren<CustomerGroupData>().ToList();
			for (int num = list.Count - 1; num >= 0; num--)
			{
				CustomerGroupData customerGroupData = list[num];
				if (!customerGroupData.gameObject.activeSelf)
				{
					list.RemoveAt(num);
				}
				else
				{
					bool flag = false;
					Customer[] members = customerGroupData.Members;
					for (int i = 0; i < members.Length; i++)
					{
						if (SaveCustomers.CanCustomerBeSaved(members[i]))
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list.RemoveAt(num);
					}
				}
			}
			ES3.Save("CustomerGroupsCount", list.Count, settings);
			for (int j = 0; j < list.Count; j++)
			{
				ES3.Save("CustomerGroupData" + j, list[j], settings);
			}
		}

		public override void LoadInit(ES3Settings settings)
		{
			_loadedGroups.Clear();
			int num = ES3.Load("CustomerGroupsCount", 0, settings);
			for (int i = 0; i < num; i++)
			{
				CustomerGroupData orCreateGroup = CustomerGroups.GetOrCreateGroup();
				_loadedGroups.Add((i, orCreateGroup));
				LoadInto("CustomerGroupData" + i, orCreateGroup, settings);
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			foreach (var (num, obj) in _loadedGroups)
			{
				LoadInto("CustomerGroupData" + num, obj, settings);
			}
			_loadedGroups.Clear();
		}
	}
}
