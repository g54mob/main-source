using System.Collections;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Utilities;

namespace CTS
{
	public class AgentActionUseStationNeedFill : AgentAction<Agent>
	{
		private SoftReference<StationNeedFill> _station;

		public StationNeedFill Station
		{
			get
			{
				return _station;
			}
			set
			{
				_station = SoftReference.Create(value);
			}
		}

		public override bool CanBePerformed(Agent agentRef)
		{
			StationNeedFill station = Station;
			if (station == null)
			{
				return false;
			}
			if (!station.CanBeUsed(agentRef))
			{
				return false;
			}
			if (!agentRef.Statistics.HasStatistic(station.Data.Stat))
			{
				return false;
			}
			if (agentRef.ObjectHolding.IsCurrentlyHolding)
			{
				return false;
			}
			return agentRef.ContextualFSM.CurrentStateEquals<ContextualStateNormal>();
		}

		public override void OnStart()
		{
			SyncWithFurniture(Station);
			base.ActionAgent.FurnitureAssignment.StartUsing(Station);
		}

		public override IEnumerator WaitForRoutine()
		{
			yield return MoveToActor(Station, EInteractionKey.RegularUsage);
		}

		public override IEnumerator ActionRoutine()
		{
			StationNeedFill station = Station;
			yield return base.ActionAgent.Animator.PlayPunctual(station.Data.PossibleAnimations.GetRandom());
			base.ActionAgent.Statistics.AddToStatisticUnitInterval(station.Data.Stat, station.Data.ValueIncrease.RandomInRange());
		}

		protected override void OnStopped()
		{
		}

		public override void OnCancel()
		{
		}

		protected internal override void OnRemovedFromQueue()
		{
			base.OnRemovedFromQueue();
			base.ActionAgent.FurnitureAssignment.StopUsing();
		}
	}
}
