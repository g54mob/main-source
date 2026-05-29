using System;
using System.Collections;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class AgentActionDestroyMachine : AgentAction<Agent>
	{
		private readonly float _actionDuration;

		public Furniture FurnitureToDestroy { get; set; }

		public static Addressable<JunkObjectParameters> PfbAshPuddleLarge { get; } = new Addressable<JunkObjectParameters>("Assets/Scriptables/JunkObjects/AshPuddle_Large.asset");

		public static Resource<MonoRoutine> PfbVFXBomb { get; } = new Resource<MonoRoutine>("Prefabs/VFX/pfb_VFX_BombGround");

		public static event Action<Agent> ExplodeHunter;

		public AgentActionDestroyMachine(float actionDuration)
		{
			_actionDuration = actionDuration;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (!FurnitureToDestroy)
			{
				return false;
			}
			if (!base.IsPlaying && FurnitureToDestroy.HasTag(BBTAgentTags.HunterTarget))
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			return agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal, ContextualStatePanicking>();
		}

		public override void OnStart()
		{
			FurnitureToDestroy.AddTag(BBTAgentTags.HunterTarget);
			if (FurnitureToDestroy.TryGetComponent<FurnitureInteractor>(out var component))
			{
				SyncWithFurniture(component);
			}
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToLookAt(FurnitureToDestroy.transform, 0.4f, 2f, 0.5f, AgentsMover.AllAreas);
		}

		public override IEnumerator ActionRoutine()
		{
			AgentActionDestroyMachine.ExplodeHunter?.Invoke(base.ActionAgent);
			yield return base.ActionAgent.Animator.PlayTimedLoop(AgentAnim.Sabotage, _actionDuration);
			StopFurnitureSyncing();
			base.ActionAgent.Cooldowns.StartCooldown(BBTAgentTags.DestroyedMachine);
			JunkObject.Spawn(PfbAshPuddleLarge, FurnitureToDestroy.transform.position, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f));
			CTSFactory.Instantiate(PfbVFXBomb.Value, FurnitureToDestroy.transform.position, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 0f), true);
			UnityEngine.Object.Destroy(FurnitureToDestroy.gameObject);
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			FurnitureToDestroy?.RemoveTag(BBTAgentTags.HunterTarget);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}
	}
}
