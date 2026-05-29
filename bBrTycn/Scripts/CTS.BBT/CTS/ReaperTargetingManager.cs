using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class ReaperTargetingManager : CTSBehaviour
	{
		private HashSet<Customer> _targetedCustomers = new HashSet<Customer>();

		public static event Action<Customer> HostileMarked;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			CustomerManager.OnCustomerLeavesBar += OnCustomerLeaveBar;
			Agent.Died += OnAgentDied;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			CustomerManager.OnCustomerLeavesBar -= OnCustomerLeaveBar;
			Agent.Died -= OnAgentDied;
		}

		private void Update()
		{
			if (CTSSingleton<HostileCharacterSpawner>.TryGetInstance(out var outInstance))
			{
				HandleList(outInstance.CurrentHunters);
				HandleList(outInstance.CurrentInvestigators);
			}
			void HandleList(ReadOnlyHashSet<Customer> list)
			{
				foreach (Customer item in list)
				{
					if (!_targetedCustomers.Contains(item) && !item.IsDead)
					{
						Vector3 position = item.transform.position;
						foreach (Worker item2 in Collections<Worker>.Filter(WorkerList.All, WorkerList.HasPower, WorkerPowerFeature.e_PowerFeatures.Reaper))
						{
							if (item2.Statistics.TryGetStatisticValue(EAgentStatistics.HostileDetectionDistance, out var statisticValue))
							{
								if (item2.Statistics.TryGetStatisticValue(EAgentStatistics.HostileDetectionDistanceLeveling, out var statisticValue2))
								{
									statisticValue += (float)(item2.Level.CurrentLevel - 1) * statisticValue2;
								}
								if (!(Vector3.Distance(item2.transform.position, position) > statisticValue))
								{
									AddTarget(item);
									break;
								}
							}
						}
					}
				}
			}
		}

		private void OnAgentDied(Agent agent)
		{
			if (agent is Customer customer)
			{
				RemoveTarget(customer);
			}
		}

		private void OnCustomerLeaveBar(Customer obj)
		{
			RemoveTarget(obj);
		}

		private void AddTarget(Customer customer)
		{
			if (_targetedCustomers.Add(customer))
			{
				customer.ReaperTarget.VFX.Play(withChildren: false);
				ReaperTargetingManager.HostileMarked?.Invoke(customer);
			}
		}

		private void RemoveTarget(Customer customer)
		{
			if (_targetedCustomers.Remove(customer))
			{
				customer.ReaperTarget.VFX.Stop(withChildren: false);
			}
		}
	}
}
