using System;
using System.Collections.Generic;
using Assets.Scripts.Craft.Wings.ControlSurfaces;
using Assets.Scripts.Craft.Wings.Physics;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Assets.Scripts.Craft.Wings.Runtime
{
	public struct WingRuntimeOutput : IDisposable
	{
		public NativeArray<SliceData> PhysicsSlices;

		public List<IntPtr> MallocPtrs;

		public ControlSurface[] ControlSurfaces;

		public Transform[] ControlSurfaceTransforms;

		public bool IsFlipped;

		public WingBuildOutput MeshOutput;

		public readonly IControlSurfaceRuntimeData[] MakeRuntimeData()
		{
			IControlSurfaceRuntimeData[] array = new IControlSurfaceRuntimeData[ControlSurfaces.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ControlSurfaces[i].GetRuntimeData(IsFlipped);
			}
			return array;
		}

		public unsafe void Dispose()
		{
			PhysicsSlices.Dispose();
			foreach (IntPtr mallocPtr in MallocPtrs)
			{
				UnsafeUtility.Free((void*)mallocPtr, Allocator.Persistent);
			}
			MallocPtrs.Clear();
			this = default(WingRuntimeOutput);
		}
	}
}
