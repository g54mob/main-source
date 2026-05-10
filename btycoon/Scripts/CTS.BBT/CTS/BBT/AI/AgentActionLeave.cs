using System;
using System.Collections;
using CTS.AI;
using CTS.Core;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace CTS.BBT.AI
{
	public class AgentActionLeave : AgentAction<Agent>
	{
		private ECriminalActs _criminalAct;

		private const float Distance = 4f;

		private bool _hasBittenSomeone;

		private static Resource<MonoTimer> LeaveVFXPrefab = new Resource<MonoTimer>("Prefabs/VFX/Pfb_VFX_VampireDespawn");

		private static Addressable<PrestigeUIStatsSO> _withnessesEscapedStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/WithnessesEscaped.asset");

		public static event Action<Agent> VampireLeaving;

		public static event Action<Customer> CustomerLeftBar;

		public override bool CanBePerformed(Agent agentRef)
		{
			return CTSSingleton<LevelParameters>.Instance.ExitTarget;
		}

		private static bool IsHumanAvailableToKill(Customer customer)
		{
			if (customer.IsVampire)
			{
				return false;
			}
			if (customer.Tags.HasTag(EAgentTag.Leaving))
			{
				return false;
			}
			if (customer.Business.ObjectLock.IsLocked())
			{
				return false;
			}
			if (customer.RoomObject.CurrentRoom.NavArea != 3)
			{
				return false;
			}
			if (!customer.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>())
			{
				return false;
			}
			if (customer.ActionPlayer.ActionQueue.Count > 1)
			{
				return false;
			}
			return true;
		}

		public override void OnStart()
		{
			base.ActionAgent.Statistics.Paused = true;
			if (base.ActionAgent.ObjectHolding.IsHolding<Drink>())
			{
				AgentActionClearDrink action = new AgentActionClearDrink();
				PlayActionAndResumeThis(action, Priority);
			}
			else
			{
				if (SeatCheck() || !(base.ActionAgent is Customer customer))
				{
					return;
				}
				customer.ClearLivingState();
				if (customer.IsVampire && !_hasBittenSomeone && customer.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.Satisfaction, out var statisticValue) && statisticValue < 0.2f)
				{
					Customer nearestAvailable = CustomerManager.GetNearestAvailable(customer, IsHumanAvailableToKill);
					if ((bool)nearestAvailable)
					{
						AgentActionSuckBlood action2 = new AgentActionSuckBlood(nearestAvailable);
						_hasBittenSomeone = true;
						PlayActionAndResumeThis(action2);
					}
				}
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			if (!base.ActionAgent.IsHuman)
			{
				yield return VampireLeave();
				yield break;
			}
			Customer customerCast = base.ActionAgent as Customer;
			MoveTarget target = (customerCast ? customerCast.SpawnPoint.GetGroupDestination() : CTSSingleton<LevelParameters>.Instance.ExitTarget);
			PathingTracker moveTo = MoveToTarget(target);
			bool left = false;
			float nextNavCheck = Time.time;
			while (!moveTo.IsCompleted)
			{
				if (left)
				{
					yield return null;
					continue;
				}
				if ((bool)customerCast && customerCast.Business.ObjectLock.IsLocked())
				{
					CancelAction("");
					break;
				}
				if (Time.time >= nextNavCheck)
				{
					if (NavMesh.SamplePosition(base.ActionAgent.transform.position, out var _, 0.25f, AgentsMover.StreetLayer))
					{
						OnLeave();
						left = true;
					}
					nextNavCheck = Time.time + 0.2f;
				}
				yield return null;
			}
		}

		private IEnumerator VampireLeave()
		{
			OnLeave();
			base.ActionAgent.Animator.PlayPunctual(AgentAnim.Spin);
			yield return Coroutines.WaitForSeconds(0.6f);
			MonoTimer monoTimer = UnityEngine.Object.Instantiate((MonoTimer)LeaveVFXPrefab);
			monoTimer.gameObject.SetActive(value: false);
			if (monoTimer.TryGetComponent<RoomObject>(out var component))
			{
				component.SetParent(base.ActionAgent.RoomObject);
			}
			if (monoTimer.TryGetComponent<VFXBehavior>(out var component2))
			{
				foreach (AgentVisualUpdater item in component2.Updaters<AgentVisualUpdater>())
				{
					item.SetAgent(base.ActionAgent);
				}
			}
			monoTimer.transform.SetPositionAndRotation(base.ActionAgent.transform);
			monoTimer.gameObject.SetActive(value: true);
			AgentActionLeave.VampireLeaving?.Invoke(base.ActionAgent);
			monoTimer.Play();
			yield return Coroutines.WaitForSeconds(0.4f);
		}

		private void OnLeave()
		{
			base.ActionAgent.UpdateLighting(1f);
			base.ActionAgent.SetLeaveBarTag();
			base.ActionAgent.Selection.Selectable = false;
			if (!(base.ActionAgent is Customer customer))
			{
				return;
			}
			AgentActionLeave.CustomerLeftBar?.Invoke(customer);
			if (customer.IsVigilant)
			{
				int vigilanceForLeaving = customer.VigilanceMultipliersData.GetVigilanceForLeaving(customer);
				if (vigilanceForLeaving != 0)
				{
					MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy(vigilanceForLeaving, base.ActionAgent, EBone.HeadTop, Vector3.right * 0.5f);
					_withnessesEscapedStat.Value.AddToCurrentValue(vigilanceForLeaving);
				}
			}
			CustomerManager.RemoveCustomer(customer);
		}

		public override IEnumerator ActionRoutine()
		{
			LocalKeyword keyword = AgentVisual.Keyword("EMISSIVE_MASK_ON");
			base.ActionAgent.Material.SetKeyword(in keyword, value: false);
			base.ActionAgent.Statistics.Paused = false;
			base.ActionAgent.ClearObject();
			yield break;
		}

		protected override void OnStopped()
		{
			base.ActionAgent.Statistics.Paused = false;
		}

		public override void OnCancel()
		{
		}
	}
}
