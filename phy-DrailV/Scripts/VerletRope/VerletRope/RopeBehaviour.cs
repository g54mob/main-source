using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Profiling;
using UnityEngine;

namespace VerletRope
{
	public class RopeBehaviour : MonoBehaviour
	{
		public VerletSolver solver;

		public RopeMeshGenerator meshGenerator;

		public RopeParams ropeParams = new RopeParams
		{
			ropeLength = 1f,
			numPoints = 14,
			gravity = new Vector3(0f, -0.2f, 0f),
			friction = 0.96f,
			floorFriction = 0.5f,
			floorBendingScale = 0.1f,
			bendingCorrectionFactor = 0.35f,
			solverIterations = 100
		};

		public List<Pin> pins = new List<Pin>();

		internal Rope rope;

		private bool initializeOnAwake = true;

		private static readonly ProfilerMarker prof_Split = new ProfilerMarker("VRLT split ropes");

		private void Awake()
		{
			if (initializeOnAwake)
			{
				InitializeRope();
			}
		}

		private void OnEnable()
		{
			if (solver != null && rope != null && !rope.InSolver)
			{
				rope.AddToSolver(solver);
			}
		}

		private void OnDisable()
		{
			if (rope != null && rope.InSolver)
			{
				rope.RemoveFromSolver();
			}
		}

		private void OnDestroy()
		{
			DeinitializeRope();
		}

		private void InitializeRope()
		{
			DeinitializeRope();
			(Point[], Stick[]) tuple = MakeRope(ropeParams.ropeLength, ropeParams.numPoints, base.transform.forward);
			Point[] item = tuple.Item1;
			Stick[] item2 = tuple.Item2;
			NativeArray<Point> points = new NativeArray<Point>(item, Allocator.Persistent);
			NativeArray<Stick> sticks = new NativeArray<Stick>(item2, Allocator.Persistent);
			rope = new Rope(points, sticks, pins, ropeParams, this);
			if ((bool)solver)
			{
				rope.AddToSolver(solver);
			}
		}

		private void DeinitializeRope()
		{
			if (rope != null)
			{
				rope.Dispose();
				rope = null;
				if ((bool)meshGenerator)
				{
					meshGenerator.Deinitialize();
				}
			}
		}

		public void Split(int splitAtIndex)
		{
			rope.RemoveFromSolver();
			GameObject gameObject = new GameObject("[temp RopeBehavior split container]");
			gameObject.SetActive(value: false);
			gameObject.transform.SetParent(base.transform.parent);
			RopeBehaviour ropeBehaviour = CloneSelf(gameObject.transform);
			RopeBehaviour ropeBehaviour2 = CloneSelf(gameObject.transform);
			using (prof_Split.Auto())
			{
				if (splitAtIndex < 1 || splitAtIndex > rope.points.Length - 2)
				{
					throw new ArgumentOutOfRangeException($"split index must be between \"1\" and \"numPoints - 2\" ({rope.points.Length}), got {splitAtIndex}");
				}
				NativeSlice<Point> nativeSlice = rope.points.Slice(0, splitAtIndex + 1);
				NativeSlice<Point> nativeSlice2 = rope.points.Slice(splitAtIndex);
				NativeArray<Point> nativeArray = new NativeArray<Point>(nativeSlice.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				NativeArray<Point> nativeArray2 = new NativeArray<Point>(nativeSlice2.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				nativeSlice.CopyTo(nativeArray);
				nativeSlice2.CopyTo(nativeArray2);
				NativeSlice<Stick> nativeSlice3 = rope.sticks.Slice(0, splitAtIndex);
				NativeSlice<Stick> nativeSlice4 = rope.sticks.Slice(splitAtIndex);
				NativeArray<Stick> nativeArray3 = new NativeArray<Stick>(nativeSlice3.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				NativeArray<Stick> nativeArray4 = new NativeArray<Stick>(nativeSlice4.Length, Allocator.Persistent, NativeArrayOptions.UninitializedMemory);
				nativeSlice3.CopyTo(nativeArray3);
				nativeSlice4.CopyTo(nativeArray4);
				for (int i = 0; i < nativeArray4.Length; i++)
				{
					Stick value = nativeArray4[i];
					value.p1 -= nativeArray.Length - 1;
					value.p2 -= nativeArray.Length - 1;
					nativeArray4[i] = value;
				}
				List<Pin> list = ropeBehaviour.pins;
				List<Pin> list2 = ropeBehaviour2.pins;
				for (int num = list.Count - 1; num >= 0; num--)
				{
					if (list[num].pointIndex >= nativeArray.Length)
					{
						list.RemoveAt(num);
					}
				}
				for (int num2 = list2.Count - 1; num2 >= 0; num2--)
				{
					if (list2[num2].pointIndex < nativeArray.Length)
					{
						list2.RemoveAt(num2);
					}
					else
					{
						Pin value2 = list2[num2];
						value2.pointIndex -= nativeArray.Length - 1;
						list2[num2] = value2;
					}
				}
				RopeParams ropeParams = ropeBehaviour.ropeParams;
				RopeParams ropeParams2 = ropeBehaviour2.ropeParams;
				ropeBehaviour.rope = new Rope(nativeArray, nativeArray3, ropeBehaviour.pins, ropeParams, ropeBehaviour);
				ropeBehaviour2.rope = new Rope(nativeArray2, nativeArray4, ropeBehaviour2.pins, ropeParams2, ropeBehaviour2);
			}
			ropeBehaviour.transform.SetParent(gameObject.transform.parent);
			ropeBehaviour2.transform.SetParent(gameObject.transform.parent);
			UnityEngine.Object.Destroy(gameObject);
			UnityEngine.Object.Destroy(base.gameObject);
		}

		private RopeBehaviour CloneSelf(Transform container)
		{
			RopeBehaviour componentInChildren = UnityEngine.Object.Instantiate(base.gameObject, container.transform).GetComponentInChildren<RopeBehaviour>(includeInactive: true);
			componentInChildren.DeinitializeRope();
			componentInChildren.initializeOnAwake = false;
			return componentInChildren;
		}

		public (NativeArray<Point>, NativeArray<Stick>) GetArrays()
		{
			return (rope.points, rope.sticks);
		}

		public Rope GetRope()
		{
			return rope;
		}

		private static (Point[], Stick[]) MakeRope(float ropeLength, int numPoints, Vector3 direction)
		{
			List<Point> list = new List<Point>();
			List<Stick> list2 = new List<Stick>();
			direction = direction.normalized;
			for (int i = 0; i < numPoints; i++)
			{
				float num = (float)i / (float)(numPoints - 1);
				Vector3 vector = direction * ropeLength * num;
				Point item = new Point
				{
					curPos = vector,
					oldPos = vector
				};
				list.Add(item);
			}
			for (int j = 1; j < list.Count; j++)
			{
				list2.Add(new Stick
				{
					p1 = j - 1,
					p2 = j,
					length = Vector3.Distance(list[j - 1].curPos, list[j].curPos)
				});
			}
			return (list.ToArray(), list2.ToArray());
		}
	}
}
