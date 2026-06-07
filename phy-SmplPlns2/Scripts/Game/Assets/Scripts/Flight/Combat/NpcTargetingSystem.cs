using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Flight.Combat.Events;
using Assets.Scripts.Flight.Combat.Teams;
using UnityEngine;

namespace Assets.Scripts.Flight.Combat
{
	public class NpcTargetingSystem
	{
		private TeamAggressionManager _aggressionManager;

		private List<TrackedTarget> _targets = new List<TrackedTarget>();

		public TrackedTarget CurrentTarget { get; set; }

		public float MaxRange { get; set; }

		public IEnumerable<TrackedTarget> Targets => _targets;

		public ushort TeamId { get; set; }

		public NpcTargetingSystem(ushort teamId)
		{
			TeamId = teamId;
			_aggressionManager = FlightSceneScript.Instance.TeamAggressionManager;
			FlightSceneScript.Instance.TargetRegistry.TargetRegistered += OnTargetRegistered;
			FlightSceneScript.Instance.TargetRegistry.TargetUnregistered += OnTargetUnregistered;
			foreach (Target target in FlightSceneScript.Instance.TargetRegistry.Targets)
			{
				AddTarget(target);
			}
		}

		public TrackedTarget AddTarget(Target target)
		{
			if (target != null)
			{
				AggressionLevel aggressionLevel = _aggressionManager.GetAggressionLevel(TeamId, target.TeamId);
				TrackedTarget trackedTarget = new TrackedTarget(target, aggressionLevel);
				_targets.Add(trackedTarget);
				return trackedTarget;
			}
			return null;
		}

		public TrackedTarget FindTrackedTarget(Target target)
		{
			return _targets.Where((TrackedTarget x) => x.Target == target).FirstOrDefault();
		}

		public void OnDestroy()
		{
			FlightSceneScript.Instance.TargetRegistry.TargetRegistered -= OnTargetRegistered;
			FlightSceneScript.Instance.TargetRegistry.TargetUnregistered -= OnTargetUnregistered;
		}

		public void Update(Vector3 position)
		{
			TrackedTarget currentTarget = null;
			float num = float.MaxValue;
			foreach (TrackedTarget target in _targets)
			{
				target.AggressionLevel = _aggressionManager.GetAggressionLevel(TeamId, target.Target.TeamId);
				if (target.AggressionLevel != AggressionLevel.Hostile)
				{
					if (CurrentTarget == target)
					{
						CurrentTarget = null;
					}
					continue;
				}
				target.Distance = (target.Target.Position - position).magnitude;
				UpdateOcclusionStatus(target, position);
				if (target.Distance < num)
				{
					currentTarget = target;
					num = target.Distance;
				}
			}
			if (CurrentTarget != null && CurrentTarget.Target.IsDead)
			{
				CurrentTarget = null;
			}
			if (CurrentTarget == null)
			{
				CurrentTarget = currentTarget;
			}
		}

		private static void UpdateOcclusionStatus(TrackedTarget trackedTarget, Vector3 position)
		{
			Vector3 position2 = trackedTarget.Target.Position;
			Vector3 vector = position2 - position;
			Ray ray = new Ray(position, vector.normalized);
			float num = position2.y - GameWorld.Instance.FloatingOriginSeaLevel.GetValueOrDefault();
			trackedTarget.Occluded = Physics.Raycast(ray, vector.magnitude - 10f, 1048576) || num < 0f;
		}

		private void OnTargetRegistered(object sender, TargetEventArgs e)
		{
			AddTarget(e.Target);
		}

		private void OnTargetUnregistered(object sender, TargetEventArgs e)
		{
			TrackedTarget trackedTarget = FindTrackedTarget(e.Target);
			if (trackedTarget != null)
			{
				_targets.Remove(trackedTarget);
				if (CurrentTarget == trackedTarget)
				{
					CurrentTarget = null;
				}
			}
		}
	}
}
