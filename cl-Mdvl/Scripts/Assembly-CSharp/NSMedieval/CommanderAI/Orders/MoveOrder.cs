using NSMedieval.State;
using NSMedieval.Village.Map;
using UnityEngine;

namespace NSMedieval.CommanderAI.Orders
{
	public class MoveOrder : OrderBase
	{
		public readonly Vector3 Destination;

		public readonly Vector3 LookAtPoint;

		public readonly CreatureBase FollowCreature;

		public readonly float GuardModeRadius;

		public MoveOrder(Vector3 destination, float guardModeRadius = 10f)
		{
			Destination = destination;
			GuardModeRadius = guardModeRadius;
		}

		public MoveOrder(MapNode node, float guardModeRadius = 10f)
		{
			Destination = node.WorldPosition;
			GuardModeRadius = guardModeRadius;
		}

		public MoveOrder(CreatureBase followCreature, float guardModeRadius = 10f)
		{
			FollowCreature = followCreature;
			GuardModeRadius = guardModeRadius;
		}

		public MoveOrder(Vector3 destination, Vector3 lookAtPoint, float guardModeRadius = 10f)
		{
			Destination = destination;
			LookAtPoint = lookAtPoint;
			GuardModeRadius = guardModeRadius;
		}

		public static MoveOrder Stop(CommanderAIUnit unit)
		{
			Transform transform = unit.Humanoid.GetTransform();
			return new MoveOrder(unit.Humanoid.GetPosition(), ((object)transform == null) ? Vector3.zero : (transform.position + transform.forward));
		}

		public override string ToString()
		{
			return string.Format("{0} ({1}: {2}, {3}: {4}, {5}: {6})", "MoveOrder", "Destination", Destination, "LookAtPoint", LookAtPoint, "FollowCreature", FollowCreature);
		}

		public override bool Equals(OrderBase order)
		{
			if (!(order is MoveOrder moveOrder))
			{
				return false;
			}
			if (Mathf.Approximately(GuardModeRadius, moveOrder.GuardModeRadius) && Destination == moveOrder.Destination && LookAtPoint == moveOrder.LookAtPoint)
			{
				return FollowCreature == moveOrder.FollowCreature;
			}
			return false;
		}
	}
}
