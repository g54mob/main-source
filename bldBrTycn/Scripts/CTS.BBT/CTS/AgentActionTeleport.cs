using System;
using System.Collections;
using CTS.AI;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

namespace CTS
{
	public class AgentActionTeleport : AgentAction<Agent>
	{
		private bool _visualActive = true;

		private static readonly Resource<MonoTimer> LeaveVFXPrefab = new Resource<MonoTimer>("Prefabs/VFX/Pfb_VFX_VampireDespawn");

		private static readonly Resource<MonoTimer> SpawnVFXPrefab = new Resource<MonoTimer>("Prefabs/VFX/Pfb_VFX_VampireSpawn");

		public Vector3 TeleportPosition { get; set; }

		public Quaternion? TeleportRotation { get; set; }

		public static event Action<Agent> BlinkPower;

		public AgentActionTeleport(Vector3 teleportPosition, Quaternion? teleportRotation = null)
		{
			TeleportPosition = teleportPosition;
			TeleportRotation = teleportRotation;
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			return agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
		}

		public override void OnStart()
		{
			_visualActive = true;
		}

		public override IEnumerator WaitForRoutine()
		{
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			if (NavMesh.SamplePosition(TeleportPosition, out var hit, 5f, AgentsMover.AllAreas))
			{
				TeleportPosition = hit.position;
			}
			yield return Despawn();
			yield return Coroutines.WaitForSeconds(1f);
			yield return Teleport();
		}

		private IEnumerator Despawn()
		{
			base.ActionAgent.Animator.PlayPunctual(AgentAnim.Spin);
			AgentActionTeleport.BlinkPower?.Invoke(base.ActionAgent);
			yield return Coroutines.WaitForSeconds(0.6f);
			MonoTimer monoTimer = CTSFactory.Instantiate(LeaveVFXPrefab.Value, false);
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
			monoTimer.Play();
			yield return Coroutines.WaitForSeconds(0.4f);
			base.ActionAgent.SetVisualActive(value: false);
			_visualActive = false;
		}

		private IEnumerator Teleport()
		{
			base.ActionAgent.transform.position = TeleportPosition;
			if (TeleportRotation.HasValue)
			{
				base.ActionAgent.transform.rotation = TeleportRotation.Value;
			}
			AgentActionTeleport.BlinkPower?.Invoke(base.ActionAgent);
			base.ActionAgent.Cooldowns.StartCooldown(BBTAgentTags.CD_Teleport);
			MonoTimer monoTimer = CTSFactory.Instantiate(SpawnVFXPrefab.Value, false);
			monoTimer.transform.position = TeleportPosition;
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
			monoTimer.Play();
			yield return Coroutines.WaitForSeconds(1f);
			LocalKeyword keyword = AgentVisual.Keyword("EMISSIVE_MASK_ON");
			base.ActionAgent.Material.SetKeyword(in keyword, value: true);
			base.ActionAgent.SetVisualActive(value: true);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.VampireSpawn);
			base.ActionAgent.Material.SetKeyword(in keyword, value: false);
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
			if (!_visualActive)
			{
				LocalKeyword keyword = AgentVisual.Keyword("EMISSIVE_MASK_ON");
				base.ActionAgent.Material.SetKeyword(in keyword, value: false);
				base.ActionAgent.SetVisualActive(value: true);
			}
			_visualActive = true;
		}
	}
}
