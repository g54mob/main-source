using System;
using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;
using UnityEngine;

namespace CTS
{
	public class AgentActionPeeAccident : AgentAction<Agent>
	{
		private static StringKey _stringKeyPeedHimself = "PeedHimself";

		public static Addressable<JunkObjectParameters> PfbPeePuddle { get; } = new Addressable<JunkObjectParameters>("Assets/Scriptables/JunkObjects/PeePuddle.asset");

		public static event Action<Agent> PeeingHimself;

		public static event Action<Agent> PeedHimself;

		public static event Action<Agent> PeeDance;

		public override bool CanBePerformed(Agent agentRef)
		{
			return true;
		}

		public override void OnStart()
		{
			SeatCheck();
		}

		public override IEnumerator WaitForRoutine()
		{
			base.ActionAgent.Animator.StartLoop(AgentAnim.PeeDance);
			AgentActionPeeAccident.PeeDance?.Invoke(base.ActionAgent);
			if (!base.ActionAgent.Statistics.TryGetNumericStatistic(EAgentStatistics.Bladder, out var bladder))
			{
				CancelAction("No Bladder.");
				yield break;
			}
			while (bladder.Value > 0f)
			{
				if (CTSSingleton<LevelParameters>.Instance.Furnitures.TryGetNearestInteractor(base.ActionAgent.RoomObject, out Toilet outFurniture, out float _, (Func<Toilet, Customer, bool>)AutonomousActionToilet.IsToiletCorrect, base.ActionAgent as Customer))
				{
					base.ActionAgent.ActionPlayer.ForceAction(new AgentActionToilet(outFurniture), Priority);
					CancelAction("");
					break;
				}
				yield return null;
			}
		}

		public override IEnumerator ActionRoutine()
		{
			AgentActionPeeAccident.PeeingHimself?.Invoke(base.ActionAgent);
			PeeAtPosition(base.ActionAgent.transform.position);
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.PeeHimself);
		}

		protected virtual void PeeAtPosition(Vector3 pos)
		{
			if (PfbPeePuddle != null)
			{
				JunkObject.Spawn(PfbPeePuddle, pos, Quaternion.Euler(0f, UnityEngine.Random.value * 360f, 1f));
			}
		}

		private void OnSpawnPee()
		{
			base.ActionAgent.Animator.Events.SpawnedVomit -= OnSpawnPee;
			Vector3 pos = base.ActionAgent.transform.position + base.ActionAgent.transform.forward * 0.4f;
			PeeAtPosition(pos);
		}

		public override void OnComplete()
		{
			base.OnComplete();
			AgentActionPeeAccident.PeedHimself?.Invoke(base.ActionAgent);
			base.ActionAgent.Statistics.SetStatisticFromUnitInterval(EAgentStatistics.Bladder, 0.5f);
			base.ActionAgent.Satisfaction.AddFlatValue(_stringKeyPeedHimself);
		}

		protected override void OnStopped()
		{
			if ((bool)base.ActionAgent)
			{
				base.ActionAgent.Animator.Events.SpawnedVomit -= OnSpawnPee;
			}
		}

		public override void OnCancel()
		{
			base.ActionAgent.Animator.ReturnToIdle();
		}
	}
}
