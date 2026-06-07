using System;
using UnityEngine;

namespace PajamaLlama.Fltsm
{
	public abstract class DietVital : Vital
	{
		public Diet Diet { get; private set; }

		public int Amount { get; private set; }

		public int Limit { get; protected set; }

		public DietVital(Vitals vitals)
			: base(vitals)
		{
			Diet = Diet.GetInstance(this);
		}

		public override void Reset()
		{
			while (Amount > 0)
			{
				DecreaseAmount();
			}
		}

		public void IncreaseAmount(bool noDeath)
		{
			if (!noDeath || Amount != Limit - 1)
			{
				if (Amount >= Limit)
				{
					Amount = Limit + 1;
				}
				else
				{
					Amount++;
				}
				base.Updated.Invoke();
				GameManager.AgentManager.SendVitalsEvent();
			}
		}

		public void DecreaseAmount()
		{
			if (Amount != 0)
			{
				Amount--;
				base.Updated.Invoke();
				GameManager.AgentManager.SendVitalsEvent();
			}
		}

		public bool TryInstantiateProject(bool noDeath = false)
		{
			if (base.Project != null)
			{
				Debug.LogException(new Exception($"'{base.Agent.Name}' was unable to start a vital project of type '{VitalType}' because it has an active vital project of that type! The drifter is probably stuck!"));
				Diet.ClearItemToConsume();
				return true;
			}
			if (!Diet.HasItemToConsume && base.Vitals.IsGoingToDieOfAnyOther(this))
			{
				return false;
			}
			if (InstantiateProject())
			{
				return true;
			}
			IncreaseAmount(noDeath);
			new AgentEvent(Diet.FailedEvent, base.Agent).Dispatch();
			return false;
		}

		public override bool RetryInstantiateProject()
		{
			if (CanRetryFailedStartProject() && Diet.TryReserveItemToConsume(AssignmentPriority.Lowest))
			{
				return InstantiateProject();
			}
			return false;
		}

		private bool InstantiateProject()
		{
			if (Diet.TryReturnAndClearItemToConsume(out var itemToConsume))
			{
				using (ListPool<Item>.List items = ListPool<Item>.Get(itemToConsume))
				{
					InstantiateProject(Diet.ConsumeProjectProperties, base.Agent.gameObject, items);
					return true;
				}
			}
			Diet.ClearItemToConsume();
			return false;
		}

		public override void OnDayStarted()
		{
			Diet.OnDayStarted();
		}

		public bool IsInDangerOfDying()
		{
			if (Amount == Limit - 1)
			{
				return base.Project == null;
			}
			return false;
		}

		public bool IsGoingToDie()
		{
			if (IsInDangerOfDying())
			{
				return Diet.GetConsumableCount() == 0;
			}
			return false;
		}

		public bool IsCauseOfDeath()
		{
			return Amount >= Limit;
		}

		private bool CanRetryFailedStartProject()
		{
			int consumableCount = Diet.GetConsumableCount();
			if (consumableCount == 0)
			{
				return false;
			}
			int num = 0;
			foreach (Agent agent in base.Agent.Community.Agents)
			{
				if (Amount < agent.Vitals.ReturnVitalAmount(VitalType))
				{
					num++;
				}
			}
			return num < consumableCount;
		}

		public void Restore(int amount, Diet.PD dietData = null)
		{
			Amount = Mathf.Clamp(amount, 0, Limit);
			Diet.Restore(dietData);
		}
	}
}
