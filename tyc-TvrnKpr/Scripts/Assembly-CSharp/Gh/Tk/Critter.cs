using UnityEngine;

namespace Gh.Tk
{
	public class Critter : Actor, IActorColliderInteraction
	{
		[PersistenceOptIn]
		public CritterData CritterData
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		[PersistenceOptIn]
		public int TargetRoomId { get; set; }

		public override void Init()
		{
		}

		protected override Job GetNextJob()
		{
			return null;
		}

		public static void SpawnCritter(Vector3 position, Quaternion rotation, int targetRoomId = 0)
		{
		}

		public void OnActorEnteredCollider(Actor actor)
		{
		}

		public void OnActorLeftCollider(Actor actor)
		{
		}
	}
}
