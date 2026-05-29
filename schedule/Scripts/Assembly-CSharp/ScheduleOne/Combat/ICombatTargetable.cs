using FishNet.Object;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Vision;
using UnityEngine;

namespace ScheduleOne.Combat
{
	public interface ICombatTargetable : IDamageable, ISightable
	{
		new NetworkObject NetworkObject { get; }

		Vector3 CenterPoint => default(Vector3);

		Transform CenterPointTransform { get; }

		Vector3 LookAtPoint { get; }

		bool IsCurrentlyTargetable { get; }

		float RangedHitChanceMultiplier { get; }

		Vector3 Velocity { get; }

		bool IsPlayer => false;

		Player AsPlayer => null;

		void RecordLastKnownPosition(bool resetTimeSinceLastSeen);

		float GetSearchTime();

		bool IsNull()
		{
			return false;
		}
	}
}
