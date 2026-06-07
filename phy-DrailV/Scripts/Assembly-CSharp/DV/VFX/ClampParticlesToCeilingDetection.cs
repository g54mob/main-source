using DV.Utils;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

namespace DV.VFX
{
	public class ClampParticlesToCeilingDetection : MonoBehaviour
	{
		[BurstCompile]
		private struct UpdateParticlesJob : IJobParticleSystemParallelFor
		{
			[ReadOnly]
			public Vector3 positionOffset;

			[ReadOnly]
			public CeilingDetection.WorldPositionedArray worldArray;

			[ReadOnly]
			public NativeArray<RaycastHit> raycastHits;

			public void Execute(ParticleSystemJobData particles, int index)
			{
				if (particles.positions.x.Length <= index)
				{
					return;
				}
				Vector3 vector = particles.positions[index];
				vector += positionOffset;
				int index2 = worldArray.GetIndex(vector);
				if (index2 >= 0)
				{
					RaycastHit raycastHit = raycastHits[index2];
					if (!(vector.y > raycastHit.point.y))
					{
						ParticleSystemNativeArray3 sizes = particles.sizes;
						sizes[index] = float3.zero;
					}
				}
			}
		}

		public float respawnHeightOffset;

		private ParticleSystem ps;

		private UpdateParticlesJob job;

		private void Awake()
		{
			ps = GetComponent<ParticleSystem>();
			if (!SingletonBehaviour<CeilingDetection>.Instance)
			{
				Debug.LogError("Missing CeilingDetection!, deleting");
				Object.Destroy(this);
			}
		}

		private void OnParticleUpdateJobScheduled()
		{
			job.raycastHits = SingletonBehaviour<CeilingDetection>.Instance.copiedResults;
			job.worldArray = SingletonBehaviour<CeilingDetection>.Instance.worldPositionedArray;
			job.positionOffset = WorldMover.currentMove;
			job.Schedule(ps, 64);
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.DrawCube(base.transform.position + Vector3.up * respawnHeightOffset, new Vector3(100f, 0.01f, 100f));
		}
	}
}
