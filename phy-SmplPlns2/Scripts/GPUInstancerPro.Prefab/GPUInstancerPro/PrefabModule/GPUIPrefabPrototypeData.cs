using System;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
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
		private NativeArray<Matrix4x4> _matrixArray;

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

		[NonSerialized]
		internal bool hasOptionalRenderers;

		[NonSerialized]
		internal NativeArray<uint> optionalRendererStatusData;

		[NonSerialized]
		internal bool isOptionalRendererStatusModified;

		[NonSerialized]
		public NativeArray<int> isModifiedArray;

		[NonSerialized]
		internal int minModifiedIndex;

		[NonSerialized]
		internal int maxModifiedIndex;

		[NonSerialized]
		internal GPUIAutoUpdateTransformsJob autoUpdateTransformsJob;

		[NonSerialized]
		internal bool _isAutoUpdateTransformJobsStarted;

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
				_matrixArray = new NativeArray<Matrix4x4>(0, Allocator.Persistent);
				isModifiedArray = new NativeArray<int>(0, Allocator.Persistent);
				hasOptionalRenderers = prototype.prefabObject.HasComponentInChildrenExceptParent<GPUIOptionalRenderer>();
				if (hasOptionalRenderers)
				{
					optionalRendererStatusData = new NativeArray<uint>(0, Allocator.Persistent);
				}
				minModifiedIndex = int.MaxValue;
				maxModifiedIndex = -1;
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
			if (_matrixArray.IsCreated)
			{
				_matrixArray.Dispose();
			}
			if (isModifiedArray.IsCreated)
			{
				isModifiedArray.Dispose();
			}
			if (transformAccessArray.isCreated)
			{
				transformAccessArray.Dispose();
			}
			if (optionalRendererStatusData.IsCreated)
			{
				optionalRendererStatusData.Dispose();
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

		public override NativeArray<Matrix4x4> GetTransformationMatrixArray()
		{
			return _matrixArray;
		}

		internal void UpdateTransformAccessArray()
		{
			if (isTransformReferencesModified)
			{
				if (transformAccessArray.isCreated)
				{
					transformAccessArray.Dispose();
				}
				TransformAccessArray.Allocate(instanceTransforms.Length, -1, out transformAccessArray);
				for (int i = 0; i < instanceCount; i++)
				{
					transformAccessArray.Add(instanceTransforms[i]);
				}
				isTransformReferencesModified = false;
			}
		}

		public bool HasMatrixArray()
		{
			return _matrixArray.IsCreated;
		}

		internal unsafe void* GetMatrixArrayUnsafePtr()
		{
			return _matrixArray.GetUnsafePtr();
		}

		internal void ResizeMatrixArray(int newSize)
		{
			GPUIUtility.ResizeNativeArray(ref _matrixArray, newSize, Allocator.Persistent);
			GPUIUtility.ResizeNativeArray(ref isModifiedArray, newSize, Allocator.Persistent);
		}

		public int GetMatrixLength()
		{
			return _matrixArray.Length;
		}

		public void SetMatrix(int index, Matrix4x4 matrix)
		{
			_matrixArray[index] = matrix;
			minModifiedIndex = Mathf.Min(index, minModifiedIndex);
			maxModifiedIndex = Mathf.Max(index, maxModifiedIndex);
		}

		public void SetMatrixModified(int index)
		{
			minModifiedIndex = Mathf.Min(index, minModifiedIndex);
			maxModifiedIndex = Mathf.Max(index, maxModifiedIndex);
		}

		public void SetAllMatricesModified()
		{
			isMatrixArrayModified = true;
			minModifiedIndex = 0;
			maxModifiedIndex = int.MaxValue;
		}

		public Matrix4x4 GetMatrix(int index)
		{
			return _matrixArray[index];
		}
	}
}
