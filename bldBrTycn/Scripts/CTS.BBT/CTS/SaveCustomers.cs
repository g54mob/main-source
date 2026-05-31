using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using UnityEngine;

namespace CTS
{
	public class SaveCustomers : SaveContainer
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		public struct SaveData
		{
		}

		[SerializeField]
		private Customer _customerPrefab;

		[SerializeField]
		private Customer _investigatorPrefab;

		[SerializeField]
		private Customer _hunterPrefab;

		private static readonly HashSet<(int, Customer)> _loadedCustomers = new HashSet<(int, Customer)>();

		private static readonly HashSet<(int, Customer)> _loadedInvestigators = new HashSet<(int, Customer)>();

		private static readonly HashSet<(int, Customer)> _loadedHunters = new HashSet<(int, Customer)>();

		private static readonly Dictionary<Customer, SaveData> _loadedSave = new Dictionary<Customer, SaveData>();

		public static SaveData Get(Customer customer)
		{
			if (_loadedSave.TryGetValue(customer, out var value))
			{
				return value;
			}
			SaveData saveData = default(SaveData);
			_loadedSave[customer] = saveData;
			return saveData;
		}

		public static void Set(Customer customer, SaveData saveData)
		{
			_loadedSave[customer] = saveData;
		}

		public override void Save(ES3Settings settings)
		{
			List<Customer> list = new List<Customer>();
			List<Customer> list2 = new List<Customer>();
			List<Customer> list3 = new List<Customer>();
			foreach (Customer allCustomer in CustomerManager.GetAllCustomers())
			{
				if (CanCustomerBeSaved(allCustomer))
				{
					if (allCustomer.Tags.HasTag(EAgentTag.Investigator))
					{
						list2.Add(allCustomer);
					}
					else if (allCustomer.Tags.HasTag(EAgentTag.Hunter))
					{
						list3.Add(allCustomer);
					}
					else
					{
						list.Add(allCustomer);
					}
				}
			}
			if (list.Count > 0)
			{
				ES3.Save("CustomerCount", list.Count, settings);
				for (int i = 0; i < list.Count; i++)
				{
					ES3.Save("Customer" + i, list[i].gameObject, settings);
				}
			}
			if (list2.Count > 0)
			{
				ES3.Save("InvestigatorCount", list2.Count, settings);
				for (int j = 0; j < list2.Count; j++)
				{
					ES3.Save("Investigator" + j, list2[j].gameObject, settings);
				}
			}
			if (list3.Count > 0)
			{
				ES3.Save("HunterCount", list3.Count, settings);
				for (int k = 0; k < list3.Count; k++)
				{
					ES3.Save("Hunter" + k, list3[k].gameObject, settings);
				}
			}
		}

		public static bool CanCustomerBeSaved(Customer customer)
		{
			if (!customer)
			{
				return false;
			}
			if (!customer.gameObject.activeSelf)
			{
				return false;
			}
			if (customer.IsDead)
			{
				return true;
			}
			if (!customer.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if (customer.Tags.HasTag(EAgentTag.Leaving) && customer.RoomObject.CurrentRoom.RoomIndex == 0)
			{
				return false;
			}
			return true;
		}

		public override void Clear()
		{
			CustomerManager.Clear();
		}

		public override void LoadInit(ES3Settings settings)
		{
			_loadedCustomers.Clear();
			_loadedInvestigators.Clear();
			_loadedHunters.Clear();
			_loadedSave.Clear();
			LoadList("CustomerCount", "Customer", _customerPrefab, _loadedCustomers);
			LoadList("InvestigatorCount", "Investigator", _investigatorPrefab, _loadedInvestigators);
			LoadList("HunterCount", "Hunter", _hunterPrefab, _loadedHunters);
			foreach (var loadedInvestigator in _loadedInvestigators)
			{
				Customer item = loadedInvestigator.Item2;
				CTSSingleton<HostileCharacterSpawner>.Instance.AddInvestigatorToList(item);
			}
			foreach (var loadedHunter in _loadedHunters)
			{
				Customer item2 = loadedHunter.Item2;
				CTSSingleton<HostileCharacterSpawner>.Instance.AddHunterToList(item2);
			}
			void LoadList(string countKey, string nameKey, Customer prefab, HashSet<(int, Customer)> loadedEntities)
			{
				int num = ES3.Load(countKey, 0, settings);
				for (int i = 0; i < num; i++)
				{
					try
					{
						Customer customer = Pooler.Pull(prefab, active: true);
						ES3.LoadInto(nameKey + i, customer.gameObject, settings);
						loadedEntities.Add((i, customer));
						CustomerManager.AddCustomer(customer);
						CTSSingleton<CustomerSpawner>.Instance.AddCustomerToSpawnList(customer);
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
		}

		public override void LoadPost(ES3Settings settings)
		{
			LoadIntoList(_loadedCustomers, "Customer");
			LoadIntoList(_loadedInvestigators, "Investigator");
			LoadIntoList(_loadedHunters, "Hunter");
			foreach (KeyValuePair<Customer, SaveData> item2 in _loadedSave)
			{
				item2.Deconstruct(out var _, out var _);
			}
			foreach (var loadedHunter in _loadedHunters)
			{
				loadedHunter.Item2.GetComponentInChildren<Crossbow>(includeInactive: true).SetAtRest();
			}
			_loadedCustomers.Clear();
			_loadedHunters.Clear();
			_loadedInvestigators.Clear();
			_loadedSave.Clear();
			void LoadIntoList(HashSet<(int, Customer)> list, string nameKey)
			{
				foreach (var (num, customer) in list)
				{
					ES3.LoadInto(nameKey + num, customer.gameObject, settings);
					if ((bool)customer.FurnitureAssignment.CurrentSeat)
					{
						customer.Animator.SetIdleAndPlay(AgentAnim.SitHighIdle);
					}
				}
				foreach (var item3 in list)
				{
					Customer item = item3.Item2;
					if (item.Health.CurrentHealth <= 0)
					{
						item.Health.ForceDeath();
					}
				}
			}
		}
	}
}
