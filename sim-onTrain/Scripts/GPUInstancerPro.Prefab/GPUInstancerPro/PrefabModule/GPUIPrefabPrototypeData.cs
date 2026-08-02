using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Jobs;

namespace GPUInstancerPro.PrefabModule
{
	[Serializable]
	public class GPUIPrefabPrototypeData : GPUIPrototypeData
	{
		[Serializable]
		public class GPUIPrefabInstances
		{
			public GameObject[] prefabInstances;
		}

		private class IntInverseComparer : IComparer<int>
		{
			public int Compare(int x, int y)
			{
				return y.CompareTo(x);
			}
		}

		[SerializeField]
		public bool isAutoUpdateTransformData;

		[SerializeField]
		public GPUIPrefabInstances registeredInstances;

		[NonSerialized]
		public NativeArray<Matrix4x4> matrixArray;

		[NonSerialized]
		public Transform[] instanceTransforms;

		[NonSerialized]
		public TransformAccessArray transformAccessArray;

		[NonSerialized]
		public bool isTransformReferencesModified;

		[NonSerialized]
		public int prefabID;

		[NonSerialized]
		public List<GPUIPrefab> instancesToAdd;

		[NonSerialized]
		public SortedSet<int> indexesToRemove;

		[NonSerialized]
		public bool isMatrixArrayModified;

		[NonSerialized]
		internal int instanceCount;

		public override bool Initialize(GPUIPrototype prototype)
		{
			if (base.Initialize(prototype))
			{
				if (instancesToAdd == null)
				{
					instancesToAdd = new List<GPUIPrefab>();
				}
				if (indexesToRemove == null)
				{
					indexesToRemove = new SortedSet<int>(new IntInverseComparer());
				}
				prefabID = GPUIPrefabManager.GetPrefabID(prototype);
				matrixArray = new NativeArray<Matrix4x4>(0, Allocator.Persistent);
				return true;
			}
			return false;
		}

		public override void Dispose()
		{
			base.Dispose();
			instanceCount = 0;
		}

		public override void ReleaseBuffers()
		{
			base.ReleaseBuffers();
			if (matrixArray.IsCreated)
			{
				matrixArray.Dispose();
			}
			if (transformAccessArray.isCreated)
			{
				transformAccessArray.Dispose();
			}
		}

		public int GetRegisteredInstanceCount()
		{
			if (registeredInstances != null && registeredInstances.prefabInstances != null)
			{
				return registeredInstances.prefabInstances.Length;
			}
			return 0;
		}
	}
}
