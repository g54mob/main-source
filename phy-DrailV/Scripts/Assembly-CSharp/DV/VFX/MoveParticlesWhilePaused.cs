using DV.Utils;
using Unity.Burst;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;

namespace DV.VFX
{
	public class MoveParticlesWhilePaused : MonoBehaviour
	{
		[BurstCompile]
		private struct UpdateParticlesJob : IJobParticleSystemParallelFor
		{
			public Vector3 moveDir;

			public void Execute(ParticleSystemJobData particles, int index)
			{
				ParticleSystemNativeArray3 positions = particles.positions;
				Vector3 value = positions[index];
				value += moveDir;
				positions[index] = value;
			}
		}

		private ParticleSystem ps;

		private UpdateParticlesJob job;

		private Vector3 localPosition;

		private Vector3 pastWorldPosition;

		private void Awake()
		{
			ps = GetComponent<ParticleSystem>();
			SingletonBehaviour<AppUtil>.Instance.GamePaused += GamePaused;
			SingletonBehaviour<AppUtil>.Instance.GameUnpaused += GameUnpaused;
			if (!SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
			{
				base.enabled = false;
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<AppUtil>.Instance.GamePaused -= GamePaused;
				SingletonBehaviour<AppUtil>.Instance.GameUnpaused -= GameUnpaused;
			}
		}

		private void GamePaused()
		{
			base.enabled = true;
			localPosition = PlayerManager.ActiveCamera.transform.InverseTransformPoint(base.transform.position);
			pastWorldPosition = PlayerManager.ActiveCamera.transform.TransformPoint(localPosition);
		}

		private void GameUnpaused()
		{
			base.enabled = false;
		}

		private void Update()
		{
			Vector3 vector = PlayerManager.ActiveCamera.transform.TransformPoint(localPosition);
			job.moveDir = vector - pastWorldPosition;
			pastWorldPosition = vector;
		}

		private void OnParticleUpdateJobScheduled()
		{
			if (!SingletonBehaviour<AppUtil>.Instance.IsPauseMenuOpen && SingletonBehaviour<AppUtil>.Instance.IsTimePaused)
			{
				job.Schedule(ps, 64);
			}
		}
	}
}
