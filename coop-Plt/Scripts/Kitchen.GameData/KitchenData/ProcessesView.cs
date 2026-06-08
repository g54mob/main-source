using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace KitchenData
{
	public class ProcessesView : DataView
	{
		private NativeMultiHashMap<ItemProcessPair, int> ItemProcessMap;

		private Dictionary<int, List<int>> ApplianceProcesses;

		private NativeHashMap<ApplianceItemPair, ApplianceProcessPair> ApplianceItemProcessMap;

		public override void Initialise(GameData data)
		{
			base.Initialise(data);
			ItemProcessMap = new NativeMultiHashMap<ItemProcessPair, int>(1000, Allocator.Persistent);
			ApplianceItemProcessMap = new NativeHashMap<ApplianceItemPair, ApplianceProcessPair>(1000, Allocator.Persistent);
			ApplianceProcesses = new Dictionary<int, List<int>>();
			List<Item> list = data.Get<Item>().ToList();
			IEnumerable<Appliance> enumerable = data.Get<Appliance>();
			foreach (Item item2 in list)
			{
				try
				{
					if (item2.DerivedProcesses == null)
					{
						continue;
					}
					foreach (Item.ItemProcess derivedProcess in item2.DerivedProcesses)
					{
						ItemProcessPair key = new ItemProcessPair(item2.ID, derivedProcess.Process.ID, derivedProcess.RequiresWrapper);
						ItemProcessMap.Add(key, (!(derivedProcess.Result == null)) ? derivedProcess.Result.ID : 0);
					}
				}
				catch
				{
					Debug.LogError($"Failed to process item {item2}");
					throw;
				}
			}
			foreach (Appliance item3 in enumerable)
			{
				try
				{
					if (item3.Processes == null)
					{
						continue;
					}
					ApplianceProcesses[item3.ID] = (from i in item3.Processes
						where i.Validity != ProcessValidity.DoesNotRegister
						select i.Process.ID).ToList();
					foreach (Item item4 in list)
					{
						if (item4.DerivedProcesses == null)
						{
							continue;
						}
						ApplianceProcessPair item = default(ApplianceProcessPair);
						foreach (Appliance.ApplianceProcesses process in item3.Processes)
						{
							if (process.Validity == ProcessValidity.OnlyForRegistration)
							{
								continue;
							}
							foreach (Item.ItemProcess derivedProcess2 in item4.DerivedProcesses)
							{
								if (process.Process.ID == derivedProcess2.Process.ID && !derivedProcess2.RequiresWrapper)
								{
									item = new ApplianceProcessPair(process.Process.ID, process.IsAutomatic, process.Speed / derivedProcess2.Duration, derivedProcess2.IsBad);
									break;
								}
							}
							if (item.Process != 0)
							{
								break;
							}
						}
						if (item.Process != 0)
						{
							ApplianceItemProcessMap.Add(new ApplianceItemPair(item4.ID, item3.ID), item);
						}
					}
				}
				catch
				{
					Debug.LogError($"Failed to process appliance {item3}");
					throw;
				}
			}
		}

		public override void Dispose()
		{
			if (ItemProcessMap.IsCreated)
			{
				ItemProcessMap.Dispose();
			}
			if (ApplianceItemProcessMap.IsCreated)
			{
				ApplianceItemProcessMap.Dispose();
			}
		}

		public bool GetResultOfProcess(int item, int process, out int result, bool allow_wrapped_only = false)
		{
			ItemProcessPair key = new ItemProcessPair(item, process, only_when_wrapped: false);
			if (ItemProcessMap.TryGetFirstValue(key, out result, out var it))
			{
				return true;
			}
			if (allow_wrapped_only)
			{
				key = new ItemProcessPair(item, process, only_when_wrapped: true);
				return ItemProcessMap.TryGetFirstValue(key, out result, out it);
			}
			return false;
		}

		public bool GetRelevantProcess(int item, int appliance, out ApplianceProcessPair process)
		{
			ApplianceItemPair key = new ApplianceItemPair(item, appliance);
			return ApplianceItemProcessMap.TryGetValue(key, out process);
		}

		public List<int> GetApplianceProcesses(int appliance)
		{
			return ApplianceProcesses[appliance];
		}
	}
}
