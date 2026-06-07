using DV.Utils;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

namespace DV.VFX
{
	[ExecuteAlways]
	public class KeepParticleNearCamJob : MonoBehaviour
	{
		[BurstCompile]
		private struct UpdateParticlesJob : IJobParticleSystemParallelFor
		{
			public Vector3 trackerPos;

			public float distance;

			public float minHeight;

			public float maxHeight;

			public void Execute(ParticleSystemJobData particles, int index)
			{
				if (particles.positions.x.Length > index)
				{
					ParticleSystemNativeArray3 positions = particles.positions;
					float b = maxHeight - minHeight;
					Vector3 vector = positions[index];
					Vector3 vector2 = vector - trackerPos;
					vector2.x = Mod(vector2.x + distance, distance * 2f) - distance;
					vector2.y = Mod(vector2.y - minHeight, b) + minHeight;
					vector2.z = Mod(vector2.z + distance, distance * 2f) - distance;
					vector = trackerPos + vector2;
					positions[index] = vector;
				}
			}

			private float Mod(float a, float b)
			{
				return a - b * math.floor(a / b);
			}
		}

		public float distance;

		public float minHeight;

		public float maxHeight;

		private ParticleSystem ps;

		private UpdateParticlesJob job;

		private void Awake()
		{
			ps = GetComponent<ParticleSystem>();
		}

		private void OnParticleUpdateJobScheduled()
		{
			float num = LevelInfo.WaterLevel - base.transform.position.y;
			Vector3 vector = Vector3.zero;
			if (ps.main.simulationSpace == ParticleSystemSimulationSpace.Custom)
			{
				vector = ((SingletonBehaviour<WorldMover>.Instance != null) ? WorldMover.currentMove : Vector3.zero);
			}
			job.trackerPos = base.transform.position - vector;
			job.distance = distance;
			job.minHeight = Mathf.Max(minHeight, num);
			job.maxHeight = Mathf.Max(maxHeight, num + maxHeight - minHeight);
			job.Schedule(ps, 64);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.DrawWireCube(base.transform.position + Vector3.up * Mathf.Lerp(minHeight, maxHeight, 0.5f), new Vector3(distance * 2f, maxHeight - minHeight, distance * 2f));
		}
	}
}
