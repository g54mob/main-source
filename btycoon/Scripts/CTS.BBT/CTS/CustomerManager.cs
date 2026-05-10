using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT.AI;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public static class CustomerManager
	{
		private static readonly HashSet<Customer> _vampireList = new HashSet<Customer>();

		private static readonly HashSet<Customer> _humansList = new HashSet<Customer>();

		private static readonly List<Customer> _tempList = new List<Customer>();

		private static HashSet<Customer> _filteredCustomers = new HashSet<Customer>();

		private static HashSet<Customer> _customerSet = new HashSet<Customer>();

		public static int HumanCount => _humansList.Count;

		public static int VampireCount => _vampireList.Count;

		public static int CustomersCount => HumanCount + VampireCount;

		public static ReadOnlyHashSet<Customer> HumansList => _humansList;

		public static ReadOnlyHashSet<Customer> VampireList => _vampireList;

		public static Func<Customer, bool> IsAvailable { get; } = delegate(Customer customer)
		{
			if (customer.Business.IsLocked)
			{
				return false;
			}
			return customer.Tags.HasTag(EAgentTag.IsInside) ? true : false;
		};

		public static event Action CustomerCountUpdated;

		public static event Action<Customer> OnCustomerEnterBar;

		public static event Action<Customer> OnCustomerLeavesBar;

		public static void Clear()
		{
			foreach (Customer item in _vampireList.ToList())
			{
				if ((bool)item)
				{
					UnityEngine.Object.Destroy(item.gameObject);
				}
			}
			foreach (Customer item2 in _humansList.ToList())
			{
				if ((bool)item2)
				{
					UnityEngine.Object.Destroy(item2.gameObject);
				}
			}
			_vampireList.Clear();
			_humansList.Clear();
		}

		internal static void AddCustomer(Customer p_customer)
		{
			int num = 0;
			int num2 = 0;
			if (p_customer.IsVampire)
			{
				num = VampireCount;
				_vampireList.Add(p_customer);
				num2 = VampireCount;
			}
			else
			{
				num = HumanCount;
				_humansList.Add(p_customer);
				num2 = HumanCount;
			}
			if (num != num2)
			{
				CustomerManager.CustomerCountUpdated?.Invoke();
				CustomerManager.OnCustomerEnterBar?.Invoke(p_customer);
			}
		}

		public static void PutHumanAtEndOfList(Customer customer)
		{
			if (customer.IsVampire)
			{
				throw new Exception("Cannot put vampire in the human list");
			}
			if (!_humansList.Contains(customer))
			{
				AddCustomer(customer);
				return;
			}
			_humansList.Remove(customer);
			_humansList.Add(customer);
		}

		internal static void RemoveCustomer(Customer p_customer)
		{
			int num = 0;
			int num2 = 0;
			if (p_customer.IsVampire)
			{
				num = VampireCount;
				_vampireList.Remove(p_customer);
				num2 = VampireCount;
			}
			else
			{
				num = HumanCount;
				_humansList.Remove(p_customer);
				num2 = HumanCount;
			}
			if (num != num2)
			{
				CustomerManager.CustomerCountUpdated?.Invoke();
				CustomerManager.OnCustomerLeavesBar?.Invoke(p_customer);
			}
		}

		public static int GetRoamingCustomerCount()
		{
			int num = 0;
			foreach (Customer vampire in _vampireList)
			{
				if (!vampire.GroupData.AssignedTable)
				{
					num++;
				}
			}
			foreach (Customer humans in _humansList)
			{
				if (!humans.GroupData.AssignedTable)
				{
					num++;
				}
			}
			return num;
		}

		internal static bool TryGetAnyVampire(out Customer outCustomer)
		{
			return TryGetAny(_vampireList, out outCustomer);
		}

		internal static bool TryGetAnyHuman(out Customer outCustomer)
		{
			return TryGetAny(_humansList, out outCustomer);
		}

		private static bool TryGetAny(ICollection<Customer> list, out Customer outCustomer)
		{
			if (list.Count <= 0)
			{
				outCustomer = null;
				return false;
			}
			outCustomer = list.ElementAt(UnityEngine.Random.Range(0, list.Count));
			return true;
		}

		public static bool TryGetAnyVampireInBar(out Customer outCustomer)
		{
			return TryGetAnyInBar(_vampireList, out outCustomer);
		}

		public static bool TryGetAnyHumanInBar(out Customer outCustomer)
		{
			return TryGetAnyInBar(_humansList, out outCustomer);
		}

		public static bool TryGetAnySpecificInBar(CustomerParameters customerParameters, out Customer outCustomer)
		{
			return TryGetAnyInBar((customerParameters.IsVampire ? _vampireList : _humansList).Where((Customer x) => x.SpawnParameters == customerParameters).ToHashSet(), out outCustomer);
		}

		private static bool TryGetAnyInBar(ICollection<Customer> list, out Customer outCustomer)
		{
			if (list.Count <= 0)
			{
				outCustomer = null;
				return false;
			}
			outCustomer = list.Where((Customer x) => x.Tags.HasTag(EAgentTag.IsInside)).ElementAt(UnityEngine.Random.Range(0, list.Count));
			return outCustomer;
		}

		internal static bool IsAnyAvailable(Customer excluded, Func<Customer, bool> filter)
		{
			if (IsAnyAvailable(_humansList))
			{
				return true;
			}
			return IsAnyAvailable(_vampireList);
			bool IsAnyAvailable(HashSet<Customer> list)
			{
				foreach (Customer item in list)
				{
					if (!(item == excluded) && item.Tags.HasTag(EAgentTag.IsInside) && item.ContextualFSM.CurrentStateEquals<ContextualStateNormal>() && filter(item))
					{
						return true;
					}
				}
				return false;
			}
		}

		internal static bool IsAnyAvailable<TArg1>(Customer excluded, Func<Customer, TArg1, bool> filter, TArg1 arg1)
		{
			if (IsAnyAvailable(_humansList))
			{
				return true;
			}
			return IsAnyAvailable(_vampireList);
			bool IsAnyAvailable(HashSet<Customer> list)
			{
				foreach (Customer item in list)
				{
					if (!(item == excluded) && item.Tags.HasTag(EAgentTag.IsInside) && item.ContextualFSM.CurrentStateEquals<ContextualStateNormal>() && filter(item, arg1))
					{
						return true;
					}
				}
				return false;
			}
		}

		internal static Customer GetNearestAvailable(Customer excluded, Func<Customer, bool> filter)
		{
			Vector3 pos = excluded.transform.position;
			Customer bestCustomer = null;
			float bestDistance = float.MaxValue;
			bestCustomer = GetNearest(_humansList);
			if ((object)bestCustomer != null)
			{
				return bestCustomer;
			}
			return GetNearest(_vampireList);
			Customer GetNearest(HashSet<Customer> list)
			{
				foreach (Customer item in list)
				{
					if (!(item == excluded) && item.Tags.HasTag(EAgentTag.IsInside) && item.ContextualFSM.CurrentStateEquals<ContextualStateNormal>() && filter(item))
					{
						float num = Vector3.SqrMagnitude((pos - item.transform.position).MulY(10f));
						if (num < bestDistance)
						{
							bestDistance = num;
							bestCustomer = item;
						}
					}
				}
				return bestCustomer;
			}
		}

		internal static Customer GetNearestAvailable<TArg1>(Customer excluded, Func<Customer, TArg1, bool> filter, TArg1 arg1)
		{
			Vector3 pos = excluded.transform.position;
			Customer bestCustomer = null;
			float bestDistance = float.MaxValue;
			bestCustomer = GetNearest(_humansList);
			if ((object)bestCustomer != null)
			{
				return bestCustomer;
			}
			return GetNearest(_vampireList);
			Customer GetNearest(HashSet<Customer> list)
			{
				foreach (Customer item in list)
				{
					if (!(item == excluded) && item.Tags.HasTag(EAgentTag.IsInside) && item.ContextualFSM.CurrentStateEquals<ContextualStateNormal>() && filter(item, arg1))
					{
						float num = Vector3.SqrMagnitude((pos - item.transform.position).MulY(10f));
						if (num < bestDistance)
						{
							bestDistance = num;
							bestCustomer = item;
						}
					}
				}
				return bestCustomer;
			}
		}

		internal static List<Customer> GetFreeHumanList()
		{
			List<Customer> list = new List<Customer>();
			foreach (Customer humans in _humansList)
			{
				if (IsAgentFreeHuman(humans))
				{
					list.Add(humans);
				}
			}
			return list;
		}

		internal static void GetFreeHumanList(List<Customer> list)
		{
			list.Clear();
			foreach (Customer humans in _humansList)
			{
				if (IsAgentFreeHuman(humans))
				{
					list.Add(humans);
				}
			}
		}

		internal static void GetFreeHumanList(List<Customer> list, Func<Customer, bool> filter)
		{
			list.Clear();
			foreach (Customer humans in _humansList)
			{
				if (IsAgentFreeHuman(humans) && filter(humans))
				{
					list.Add(humans);
				}
			}
		}

		internal static void GetFreeHumanList<TArg>(List<Customer> list, Func<Customer, TArg, bool> filter, TArg arg)
		{
			list.Clear();
			foreach (Customer humans in _humansList)
			{
				if (IsAgentFreeHuman(humans) && filter(humans, arg))
				{
					list.Add(humans);
				}
			}
		}

		internal static void GetFreeHumanList<TArg1, TArg2>(List<Customer> list, Func<Customer, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
		{
			list.Clear();
			foreach (Customer humans in _humansList)
			{
				if (IsAgentFreeHuman(humans) && filter(humans, arg1, arg2))
				{
					list.Add(humans);
				}
			}
		}

		internal static Customer GetRandomAvailableHuman()
		{
			GetFreeHumanList(_tempList);
			return _tempList.GetRandom();
		}

		internal static Customer GetRandomAvailableHuman(Func<Customer, bool> filter)
		{
			GetFreeHumanList(_tempList, filter);
			return _tempList.GetRandom();
		}

		internal static Customer GetRandomAvailableHuman<TArg>(Func<Customer, TArg, bool> filter, TArg arg)
		{
			GetFreeHumanList(_tempList, filter, arg);
			return _tempList.GetRandom();
		}

		internal static Customer GetRandomAvailableHuman<TArg1, TArg2>(Func<Customer, TArg1, TArg2, bool> filter, TArg1 arg1, TArg2 arg2)
		{
			GetFreeHumanList(_tempList, filter, arg1, arg2);
			return _tempList.GetRandom();
		}

		public static bool IsAgentFreeHuman(Customer customer)
		{
			if (customer.IsVampire || customer.Business.IsLocked || !customer.Tags.HasTag(EAgentTag.IsInside))
			{
				return false;
			}
			if (customer.Tags.HasTag(EAgentTag.WentInMachine))
			{
				return false;
			}
			if (!customer.ContextualFSM.CurrentStateEquals<ContextualStateNormal>())
			{
				return false;
			}
			return true;
		}

		internal static int GetCountHumanAlive()
		{
			int num = 0;
			foreach (Customer humans in _humansList)
			{
				if (!humans.IsVampire && !humans.Business.IsLocked)
				{
					num++;
				}
			}
			return num;
		}

		public static ReadOnlyHashSet<Customer> GetAllCustomers()
		{
			_filteredCustomers.Clear();
			Add(_humansList);
			Add(_vampireList);
			return _filteredCustomers;
			static void Add(HashSet<Customer> list)
			{
				foreach (Customer item in list)
				{
					_filteredCustomers.Add(item);
				}
			}
		}

		public static ReadOnlyHashSet<Customer> GetAllAvailableCustomers()
		{
			Collections<Customer>.Filter(GetAllCustomers(), _customerSet, IsAvailable);
			return _customerSet;
		}

		public static ReadOnlyHashSet<Customer> GetAllAvailableHumans()
		{
			Collections<Customer>.Filter(_humansList, _customerSet, IsAvailable);
			return _customerSet;
		}

		public static ReadOnlyHashSet<Customer> GetAllAvailableVampires()
		{
			Collections<Customer>.Filter(_vampireList, _customerSet, IsAvailable);
			return _customerSet;
		}
	}
}
