using Unity.Burst;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

namespace DV.VFX
{
	public class ParticleVelocityAdd : MonoBehaviour
	{
		[BurstCompile]
		private struct UpdateParticlesJob : IJobParticleSystemParallelFor
		{
			public Vector3 velocity;

			public void Execute(ParticleSystemJobData particles, int index)
			{
				if (particles.positions.x.Length > index)
				{
					ParticleSystemNativeArray3 velocities = particles.velocities;
					velocities[index] += velocity;
				}
			}
		}

		private Vector3 velocity;

		private UpdateParticlesJob job;

		private ParticleSystem ps;

		private void Awake()
		{
			ps = GetComponent<ParticleSystem>();
		}

		private void OnDisable()
		{
			velocity = Vector3.zero;
		}

		public void AddVelocityToSystem(Vector3 vel)
		{
			velocity += vel;
		}

		private void OnParticleUpdateJobScheduled()
		{
			if (!(velocity == Vector3.zero))
			{
				job.velocity = velocity;
				velocity = Vector3.zero;
				job.Schedule(ps, 64);
			}
		}
	}
}
