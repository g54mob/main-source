using CTS.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using CTS.Utilities;
using UnityEngine;
using UnityEngine.AI;

namespace CTS.BBT.AI
{
	public sealed class ContextualStateDead : ContextualState
	{
		private readonly bool _createBloodPool;

		private EDeathChore _currentChoreType = EDeathChore.Body;

		public static Resource<MonoTimer> DeathVFXPrefab = new Resource<MonoTimer>("Prefabs/VFX/Pfb_VFX_VampireDeath");

		public WorkerChoreHub RemoveBodyChore { get; private set; }

		public static Addressable<JunkObjectParameters> PfbBloodPuddle { get; } = new Addressable<JunkObjectParameters>("Assets/Scriptables/JunkObjects/FreshBlood.asset");

		public static Addressable<JunkObjectParameters> PfbAshPuddle { get; } = new Addressable<JunkObjectParameters>("Assets/Scriptables/JunkObjects/AshPuddle.asset");

		private ContextualStateDead()
			: base(0f)
		{
		}

		public ContextualStateDead(bool createBloodPool = true)
			: base(0f)
		{
			_createBloodPool = createBloodPool;
		}

		public override void OnEnterFromSave()
		{
			base.OnEnterFromSave();
			if (base.parent.IsHuman)
			{
				base.parent.Animator.PlayPunctual(AgentAnim.Death);
			}
			else
			{
				base.parent.Animator.PlayPunctual(AgentAnim.FallDeath);
			}
			base.parent.AgentFSM.enabled = false;
			bool flag = !base.parent.IsHuman;
			if (base.parent is Customer customer)
			{
				customer.ClearLivingState();
				if (!flag)
				{
					customer.SetCrimeState(p_active: true);
				}
			}
			if (base.parent.ContextualFSM.enabled && !flag)
			{
				CreateBodyCleaningChore();
			}
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
			base.parent.Movement.Velocity = Vector3.zero;
			if (base.parent.IsHuman)
			{
				base.parent.Animator.PlayPunctual(AgentAnim.Death);
			}
			else
			{
				base.parent.Animator.PlayPunctual(AgentAnim.FallDeath);
			}
			base.parent.AgentFSM.enabled = false;
			if (base.parent.ObjectHolding.IsCurrentlyHolding)
			{
				Item currentHeld = base.parent.ObjectHolding.CurrentHeld;
				base.parent.ObjectHolding.DropObject();
				if (NavMesh.SamplePosition(base.parent.transform.position + base.parent.transform.forward, out var hit, 1.5f, AgentsMover.AllAreas))
				{
					currentHeld.transform.SetPositionAndRotation(hit.position, Quaternion.Euler(0f, Random.value * 360f, 0f));
				}
				else
				{
					currentHeld.Clear();
				}
			}
			bool flag = !base.parent.IsHuman;
			if (flag)
			{
				if (base.parent.Statistics.TryGetNumericStatistic(EAgentStatistics.DeathPrestigeLoss, out var numericStatistic))
				{
					Prestige.AddVampireKilledScore((int)(0f - numericStatistic.InitializationRange.RandomInRange()));
				}
				MonoTimer monoTimer = Pooler.Pull(DeathVFXPrefab.Value);
				monoTimer.transform.position = base.parent.transform.position;
				if (monoTimer.TryGetComponent<RoomObject>(out var component))
				{
					component.SetParent(base.parent.RoomObject);
				}
				if (monoTimer.TryGetComponent<VFXBehavior>(out var component2))
				{
					foreach (AgentVisualUpdater item in component2.Updaters<AgentVisualUpdater>())
					{
						item.SetAgent(base.parent);
					}
				}
				monoTimer.Play();
			}
			if (base.parent is Customer customer)
			{
				customer.ClearLivingState();
				if (!flag)
				{
					customer.SetCrimeState(p_active: true);
				}
				if ((bool)customer.ControllingVampire)
				{
					customer.ClearControllingVampire();
				}
				CreateBodyCleaningChore();
			}
			if (_createBloodPool)
			{
				if (flag)
				{
					JunkObject.Spawn(PfbAshPuddle.Value, base.parent.transform.position, Quaternion.Euler(0f, Random.value * 360f, 0f));
				}
				else
				{
					CreateBloodPool();
				}
			}
		}

		public void CreateBodyCleaningChore()
		{
			ClearChore();
			if (base.parent is Customer customer)
			{
				RemoveBodyChore = new WorkerChoreHubDiscardBody(new ActionHubDisposeBody(customer, allowMorgue: true));
				RemoveBodyChore.SetCooldownFromNow(2f);
				MonoSingleton<ChoreList>.Instance.AddToList(RemoveBodyChore);
			}
		}

		public void TransferChore(BodyBag bag)
		{
			if (RemoveBodyChore != null && RemoveBodyChore.Status != AgentAction.EStatus.Completed)
			{
				bag.CurrentChore = RemoveBodyChore;
				RemoveBodyChore = null;
			}
		}

		public void ClearChore()
		{
			RemoveBodyChore?.DestroyChore();
			RemoveBodyChore = null;
		}

		public override void OnStateExit()
		{
			if (base.parent is Customer customer)
			{
				customer.SetCrimeState(p_active: false);
			}
			if (RemoveBodyChore != null && !RemoveBodyChore.ActionAgent)
			{
				ClearChore();
			}
		}

		private void CreateBloodPool()
		{
			Transform transform = base.parent.transform;
			Vector3 pos = transform.position + transform.forward * 0.25f;
			JunkObject.Spawn(PfbBloodPuddle, pos, transform.rotation);
		}
	}
}
