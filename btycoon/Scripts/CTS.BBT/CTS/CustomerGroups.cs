using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class CustomerGroups : CTSSingleton<CustomerGroups>
	{
		private readonly Stack<CustomerGroupData> _groupPool = new Stack<CustomerGroupData>();

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}

		public static CustomerGroupData GetOrCreateGroup()
		{
			return CTSSingleton<CustomerGroups>.Instance.GetOrCreateGroup_Instance();
		}

		public static void Push(CustomerGroupData groupData)
		{
			for (int num = groupData.Members.Length - 1; num >= 0; num--)
			{
				Customer customer = groupData.Members[num];
				if ((bool)customer && !(customer.GroupData != groupData))
				{
					customer.SeparateFromGroup();
				}
			}
			groupData.Members = null;
			groupData.gameObject.SetActive(value: false);
			CTSSingleton<CustomerGroups>.Instance._groupPool.Push(groupData);
		}

		private CustomerGroupData GetOrCreateGroup_Instance()
		{
			CustomerGroupData customerGroupData;
			if (_groupPool.Count > 0)
			{
				customerGroupData = _groupPool.Pop();
			}
			else
			{
				GameObject obj = new GameObject("Group Data");
				obj.transform.SetParent(base.transform);
				customerGroupData = obj.AddComponent<CustomerGroupData>();
			}
			customerGroupData.gameObject.SetActive(value: true);
			return customerGroupData;
		}
	}
}
