using DV.Utils;
using UnityEngine;

namespace DV.VFX
{
	public class DerailedParticleSystem : SingletonBehaviour<DerailedParticleSystem>
	{
		public Vector2 dragWetnessThresholds = new Vector2(0.3f, 0.5f);

		public Vector2 dragSpeedThresholds = new Vector2(4f, 25f);

		public Vector2 impactForceThresholds = new Vector2(1000000f, 10000000f);

		public int dragFramesBetweenParticleSpawn = 4;

		public float dragDirectionRandomness = 20f;

		public float dragPositionRandomness = 0.3f;

		public float dragVelocityInherit = 0.8f;

		public float dragSideForce = 0.2f;

		public float impactVelocityInherit = 1f;

		public float particleSpawnHeight = 0.6f;

		private ParticleSystem ps;

		protected override void Awake()
		{
			base.Awake();
			ps = GetComponentInChildren<ParticleSystem>();
		}

		public void SpawnParticle(Vector3 position, Vector3 velocity)
		{
			ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
			{
				position = position,
				velocity = velocity
			};
			ps.Emit(emitParams, 1);
		}
	}
}
