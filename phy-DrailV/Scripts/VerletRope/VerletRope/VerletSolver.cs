using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;
using VerletRope.Thirdparty;

namespace VerletRope
{
	public class VerletSolver : MonoBehaviour
	{
		public float simulationSpeedup = 1f;

		public float receiveForcesMultiplier = 1f;

		public Camera camera;

		[Header("Tweaking")]
		public float clampConstrainResolutionVelocityTo = 0.1f;

		[Header("Debug")]
		public bool flushJobs = true;

		public bool useLateUpdate;

		internal readonly List<Rope> registered = new List<Rope>();

		internal readonly Queue<Rope> scheduled = new Queue<Rope>();

		private bool scheduleAtEndOfFrame = true;

		private readonly Plane[] cameraPlanes = new Plane[6];

		private NativeArray<BurstPlane> cameraPlanesNA;

		public bool HasQueuedJobs => scheduled.Count != 0;

		public bool ScheduleAtEndOfFrame => scheduleAtEndOfFrame;

		private void Awake()
		{
			cameraPlanesNA = new NativeArray<BurstPlane>(6, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
		}

		private void OnEnable()
		{
			if (scheduleAtEndOfFrame && !useLateUpdate)
			{
				StartCoroutine(UpdateAtEndOfFrame());
			}
		}

		private void OnDisable()
		{
			StopAllCoroutines();
		}

		private void OnDestroy()
		{
			Complete();
			cameraPlanesNA.Dispose();
		}

		private IEnumerator UpdateAtEndOfFrame()
		{
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			while (scheduleAtEndOfFrame && !useLateUpdate)
			{
				yield return waitForEndOfFrame;
				if (scheduleAtEndOfFrame && !useLateUpdate)
				{
					DoUpdate();
				}
			}
		}

		private void DoUpdate()
		{
			if (Time.deltaTime == 0f || registered.Count == 0 || HasQueuedJobs)
			{
				return;
			}
			GeometryUtility.CalculateFrustumPlanes(camera, cameraPlanes);
			NativeArrayCopyUtils.CopyToNativeArray(cameraPlanes, cameraPlanesNA);
			foreach (Rope item in registered)
			{
				Schedule(item);
			}
			if (flushJobs)
			{
				JobHandle.ScheduleBatchedJobs();
			}
		}

		public void Schedule(Rope rope)
		{
			rope.UpdatePins();
			rope.Schedule(cameraPlanesNA, clampConstrainResolutionVelocityTo, simulationSpeedup, receiveForcesMultiplier);
			scheduled.Enqueue(rope);
		}

		public void Complete()
		{
			while (scheduled.Count != 0)
			{
				scheduled.Dequeue().Complete();
			}
		}

		private void Update()
		{
			if (!scheduleAtEndOfFrame)
			{
				DoUpdate();
			}
		}

		private void LateUpdate()
		{
			if (scheduleAtEndOfFrame && useLateUpdate)
			{
				DoUpdate();
			}
			Complete();
		}

		public List<Rope> GetRegisteredRopes()
		{
			return registered;
		}
	}
}
