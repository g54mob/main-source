using System.Collections;
using CTS.Utilities;
using UnityEngine;

namespace CTS.BBT.AI
{
	public class AgentActionVomit : AgentAction<Agent>
	{
		public static Addressable<JunkObjectParameters> PfbBarfPuddle { get; } = new Addressable<JunkObjectParameters>("Assets/Scriptables/JunkObjects/BarfPuddle.asset");

		public static Addressable<JunkObjectParameters> PfbBloodPuddle { get; } = new Addressable<JunkObjectParameters>("Assets/Scriptables/JunkObjects/FreshBlood.asset");

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
			yield break;
		}

		public override IEnumerator ActionRoutine()
		{
			base.ActionAgent.Animator.Events.SpawnedVomit += OnSpawnVomit;
			yield return base.ActionAgent.Animator.PlayPunctual(AgentAnim.Vomit);
		}

		protected virtual void VomitAtPosition(Vector3 pos)
		{
			base.ActionAgent.Animator.Events.TriggerVFX("Vomit");
			JunkObject.Spawn(PfbBarfPuddle, pos, Quaternion.Euler(0f, Random.value * 360f, 1f));
		}

		private void OnSpawnVomit()
		{
			base.ActionAgent.Animator.Events.SpawnedVomit -= OnSpawnVomit;
			Vector3 pos = base.ActionAgent.transform.position + base.ActionAgent.transform.forward * 0.4f;
			VomitAtPosition(pos);
		}

		public override void OnComplete()
		{
			base.OnComplete();
			base.ActionAgent.Statistics.AddToStatistic(EAgentStatistics.Alcohol, -10f);
		}

		protected override void OnStopped()
		{
			if ((bool)base.ActionAgent)
			{
				base.ActionAgent.Animator.Events.SpawnedVomit -= OnSpawnVomit;
			}
		}

		public override void OnCancel()
		{
		}
	}
}
