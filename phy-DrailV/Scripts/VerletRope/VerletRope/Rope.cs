using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;

namespace VerletRope
{
	public class Rope
	{
		public NativeArray<Point> points;

		public NativeArray<Stick> sticks;

		public RopeParams param;

		public List<Pin> pins;

		public RopeBehaviour behaviour;

		private VerletSolver solver;

		private bool alreadyDisposed;

		private Transform prevReceiveForcesFrom;

		private Vector3 prevReceiveForcesFromPos;

		private bool wasVerletJobScheduled;

		private bool wasMeshGenJobScheduled;

		private VerletRopeJob job;

		private JobHandle handle;

		private NativeArray<bool> isMeshInFrustum;

		private static readonly ProfilerMarker prof_VerletComplete = new ProfilerMarker("VRLT verlet job .Complete()");

		private static readonly ProfilerMarker prof_MeshComplete = new ProfilerMarker("VRLT mesh gen job .Complete()");

		public bool InSolver => solver != null;

		public Rope(NativeArray<Point> points, NativeArray<Stick> sticks, List<Pin> pins, RopeParams ropeParams, RopeBehaviour behaviour)
		{
			this.points = points;
			this.sticks = sticks;
			this.pins = pins;
			param = ropeParams;
			this.behaviour = behaviour;
			isMeshInFrustum = new NativeArray<bool>(1, Allocator.Persistent);
			if ((bool)behaviour.meshGenerator)
			{
				if (behaviour.meshGenerator.rope != null)
				{
					Debug.LogWarning("RopeMeshGenerator already had a Rope assigned, it will be overwritten.", behaviour.meshGenerator);
				}
				behaviour.meshGenerator.rope = this;
			}
		}

		internal void UpdatePins()
		{
			Transform transform = behaviour.transform;
			for (int i = 0; i < pins.Count; i++)
			{
				Pin pin = pins[i];
				if (pin.active)
				{
					if ((bool)pin.pinnedToTransform)
					{
						pin.pinLocalPos = transform.InverseTransformPoint(pin.pinnedToTransform.position);
					}
					Point value = points[pin.pointIndex];
					value.pinned = true;
					value.pinLocalPos = pin.pinLocalPos;
					value.addedBendingCorrection = pin.addedBendingCorrection;
					points[pin.pointIndex] = value;
				}
			}
		}

		public void UpdatePin(int i, bool pinned, Vector3 pinLocalPos)
		{
			Point value = points[i];
			value.pinned = pinned;
			value.pinLocalPos = pinLocalPos;
			points[i] = value;
		}

		internal void Dispose()
		{
			if (!alreadyDisposed)
			{
				alreadyDisposed = true;
				RemoveFromSolver();
				points.Dispose();
				sticks.Dispose();
				isMeshInFrustum.Dispose();
			}
		}

		internal void AddToSolver(VerletSolver newSolver)
		{
			if (alreadyDisposed)
			{
				Debug.LogError("Attempted to add a disposed rope to solver");
				return;
			}
			if (newSolver == null)
			{
				Debug.LogError("Given solver is null");
				return;
			}
			if (solver != null)
			{
				RemoveFromSolver();
			}
			solver = newSolver;
			newSolver.registered.Add(this);
		}

		internal void RemoveFromSolver()
		{
			Complete();
			if ((bool)solver)
			{
				solver.registered.Remove(this);
			}
			solver = null;
		}

		internal void Schedule(NativeArray<BurstPlane> cameraPlanes, float maxV, float simulationSpeedup, float receiveForcesMultiplier)
		{
			if (alreadyDisposed)
			{
				Debug.LogError("Attempted to schedule a Verlet job with a disposed rope");
				return;
			}
			if (wasVerletJobScheduled)
			{
				Debug.LogError("Attempted to schedule a Verlet job that has already been scheduled");
				return;
			}
			wasVerletJobScheduled = true;
			wasMeshGenJobScheduled = false;
			float dt = Time.deltaTime * simulationSpeedup;
			Transform transform = behaviour.transform;
			Vector3 vector = transform.InverseTransformVector(param.gravity);
			if ((bool)param.receiveForcesFrom)
			{
				Vector3 position = param.receiveForcesFrom.position;
				if (param.receiveForcesFrom == prevReceiveForcesFrom)
				{
					Vector3 vector2 = transform.InverseTransformVector(prevReceiveForcesFromPos - position);
					vector += vector2 * receiveForcesMultiplier;
				}
				prevReceiveForcesFromPos = position;
			}
			prevReceiveForcesFrom = param.receiveForcesFrom;
			job = new VerletRopeJob(points, sticks, param.solverIterations, param.bendingCorrectionFactor, dt, maxV, param.friction, param.floorLevel, param.floorFriction, param.floorBendingScale, vector, transform.localRotation, cameraPlanes, transform.localToWorldMatrix, isMeshInFrustum);
			handle = job.Schedule();
			if ((bool)behaviour.meshGenerator)
			{
				handle = behaviour.meshGenerator.Schedule(handle, isMeshInFrustum);
				wasMeshGenJobScheduled = true;
			}
		}

		internal void Complete()
		{
			if (!wasVerletJobScheduled)
			{
				return;
			}
			wasVerletJobScheduled = false;
			using (prof_VerletComplete.Auto())
			{
				handle.Complete();
			}
			if (!wasMeshGenJobScheduled || !behaviour.meshGenerator)
			{
				return;
			}
			using (prof_MeshComplete.Auto())
			{
				behaviour.meshGenerator.UpdateMeshAndDispose();
			}
		}
	}
}
