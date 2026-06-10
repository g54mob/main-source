using NSEipix.Base;
using NSMedieval.Manager;
using NSMedieval.Map;
using NSMedieval.State;
using NSMedieval.Village.Map.Pathfinding;

namespace NSMedieval.Goap
{
	public class PreferredReservableHandler
	{
		private volatile IGoapTargetable target;

		private TargetObject targetObject;

		private IGoapAgentOwner agentOwner;

		private bool preferLastReserved;

		public PreferredReservableHandler(IGoapAgentOwner agentOwner, bool preferLastReserved = true)
		{
			this.agentOwner = agentOwner;
			this.preferLastReserved = preferLastReserved;
		}

		public void SetPreferLastReserved(bool value)
		{
			preferLastReserved = value;
		}

		public ThreadSequenceStep GetInitSequenceStep<T>(bool preferLastTarget = true) where T : IGoapTargetable
		{
			return new ThreadSequenceStep(delegate
			{
				preferLastReserved = preferLastTarget;
				Prepare<T>();
				return true;
			}, delegate
			{
				SetTargetIfReachable();
				return true;
			});
		}

		public bool HasTarget()
		{
			return target != null;
		}

		public TargetObject GetTarget()
		{
			return targetObject;
		}

		public void ClearTarget()
		{
			target = null;
		}

		private void Prepare<T>() where T : IGoapTargetable
		{
			target = null;
			IReservable reservable = MonoSingleton<ReservationManager>.Instance.GetPreferedReservable(agentOwner);
			if (reservable == null)
			{
				if (!preferLastReserved)
				{
					return;
				}
				reservable = MonoSingleton<ReservationManager>.Instance.GetLastReleased(agentOwner);
			}
			if (reservable is T && (MonoSingleton<ReservationManager>.Instance.CanReserve(reservable, agentOwner) || MonoSingleton<ReservationManager>.Instance.IsReservedBy(reservable, agentOwner)))
			{
				target = reservable as IGoapTargetable;
			}
		}

		private void SetTargetIfReachable()
		{
			if (target != null)
			{
				if (!PathfinderUtil.IsPathPossible((IPathfindingAgent)agentOwner, target, preferEmptyNodes: false, WorldDirection.None, out var reachedPosition))
				{
					target = null;
					targetObject = default(TargetObject);
				}
				else
				{
					targetObject = new TargetObject(target, reachedPosition);
				}
			}
		}
	}
}
