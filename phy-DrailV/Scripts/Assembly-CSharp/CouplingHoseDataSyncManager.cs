using System.Collections;
using DV.Utils;
using Unity.Collections;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;
using VerletRope;

public class CouplingHoseDataSyncManager
{
	private const int NUM_FREE_ROPE_POINTS = 7;

	private const float SEDATE_SOLVER_OVERRIDE = 0.025f;

	private const float SEDATE_SOLVER_DURATION = 0.2f;

	private readonly CouplingHoseRig rig;

	private NativeArray<Point> points;

	private static readonly ProfilerMarker prof_CopyDataFrom = new ProfilerMarker("VRLT CopyDataFromRope");

	private static readonly ProfilerMarker prof_CopyDataTo = new ProfilerMarker("VRLT CopyDataToRope");

	private static readonly ProfilerMarker prof_InitArrays = new ProfilerMarker("VRLT initialize NativeArrays");

	public CouplingHoseDataSyncManager(CouplingHoseRig rig)
	{
		this.rig = rig;
	}

	public void OnDestroy()
	{
		if (points.IsCreated)
		{
			points.Dispose();
		}
	}

	public void HandleLoaded(CouplingHoseRopeInstance ropeInstance, bool isConnectedRope, bool scheduleJob)
	{
		if (!ropeInstance || !points.IsCreated)
		{
			return;
		}
		CopyDataToRope(ropeInstance, isConnectedRope);
		if (scheduleJob)
		{
			VerletSolver solver = CouplingHoseSolverManager.Solver;
			Rope rope = ropeInstance.GetRopeBehaviour().GetRope();
			solver.Schedule(rope);
			if (isConnectedRope)
			{
				SingletonBehaviour<CoroutineManager>.Instance.Run(SedateHose(solver));
			}
		}
	}

	public void HandleUnloaded(CouplingHoseRopeInstance ropeInstance)
	{
		CopyDataFromRope(ropeInstance);
	}

	private void CopyDataFromRope(CouplingHoseRopeInstance ropeInstance)
	{
		NativeArray<Point> item = ropeInstance.GetRopeBehaviour().GetArrays().Item1;
		if (!points.IsCreated)
		{
			using (prof_InitArrays.Auto())
			{
				points = new NativeArray<Point>(7, Allocator.Persistent);
			}
		}
		using (prof_CopyDataFrom.Auto())
		{
			item.Slice(0, 7).CopyTo(points);
		}
	}

	private void CopyDataToRope(CouplingHoseRopeInstance targetHose, bool copyingToConnected)
	{
		if (targetHose == null)
		{
			return;
		}
		using (prof_CopyDataTo.Auto())
		{
			NativeArray<Point> item = targetHose.GetRopeBehaviour().GetArrays().Item1;
			if (copyingToConnected && !rig.ConnectionManager.IsMaster)
			{
				for (int i = 0; i < points.Length; i++)
				{
					int index = item.Length - i - 1;
					Point point = points[i];
					Point value = item[index];
					float3 curPos = point.curPos;
					float3 oldPos = point.oldPos;
					Transform transform = rig.transform;
					Transform transform2 = rig.ConnectionManager.ConnectedTo.transform;
					curPos = transform2.InverseTransformPoint(transform.TransformPoint(curPos));
					oldPos = transform2.InverseTransformPoint(transform.TransformPoint(oldPos));
					value.curPos = curPos;
					value.oldPos = oldPos;
					item[index] = value;
				}
			}
			else
			{
				for (int j = 0; j < points.Length; j++)
				{
					Point point2 = points[j];
					Point value2 = item[j];
					value2.curPos = point2.curPos;
					value2.oldPos = point2.oldPos;
					item[j] = value2;
				}
			}
		}
	}

	private IEnumerator SedateHose(VerletSolver solver)
	{
		float oldVal = 0f;
		if (solver.clampConstrainResolutionVelocityTo != 0.025f)
		{
			oldVal = solver.clampConstrainResolutionVelocityTo;
		}
		solver.clampConstrainResolutionVelocityTo = 0.025f;
		yield return WaitFor.Seconds(0.2f);
		if (oldVal != 0f)
		{
			solver.clampConstrainResolutionVelocityTo = oldVal;
		}
	}
}
