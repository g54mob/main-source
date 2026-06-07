using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class FireParticleCollisionDetector : AttachedBehaviour
	{
		private ParticleSystem _part;

		private GameObjectX _gox;

		public float FireChanceMultiplier;

		public float StartingFireTempBoost;

		public override void Start()
		{
		}

		private void OnParticleCollision(GameObject other)
		{
		}

		public static GameObjectX GetOtherGox(GameObjectX own, GameObject other, List<ParticleCollisionEvent> collisionEvents)
		{
			return null;
		}
	}
}
