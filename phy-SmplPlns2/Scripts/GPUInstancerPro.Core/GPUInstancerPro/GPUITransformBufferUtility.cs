using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public static class GPUITransformBufferUtility
	{
		public static void CullInstancesInsideBounds(Bounds bounds, float offset = 0f)
		{
			foreach (GPUIRenderSourceGroup value in GPUIRenderingSystem.Instance.RenderSourceGroupProvider.Values)
			{
				if (value.TransformBufferData != null)
				{
					CullInstancesInsideBounds(value.TransformBufferData, 0, value.BufferSize, bounds, offset);
				}
			}
		}

		public static void CullInstancesInsideBounds(GPUIManager gpuiManager, Bounds bounds, List<int> prototypeIndexFilter = null, float offset = 0f)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				if (prototypeIndexFilter == null || prototypeIndexFilter.Contains(i))
				{
					CullInstancesInsideBounds(gpuiManager.GetRenderKey(i), bounds, offset);
				}
			}
		}

		public static void CullInstancesInsideBounds(int renderKey, Bounds bounds, float offset = 0f)
		{
			if (GPUIRenderingSystem.TryGetTransformBufferData(renderKey, out var transformBufferData, out var bufferStartIndex, out var bufferSize, resetCrossFade: false))
			{
				CullInstancesInsideBounds(transformBufferData, bufferStartIndex, bufferSize, bounds, offset);
			}
		}

		public static void CullInstancesInsideBounds(GPUITransformBufferData transformBufferData, int bufferStartIndex, int bufferSize, Bounds bounds, float offset = 0f)
		{
			if (bufferSize == 0)
			{
				return;
			}
			Dictionary<int, GPUIShaderBuffer>.ValueCollection transformBufferValues = transformBufferData.TransformBufferValues;
			if (transformBufferValues == null)
			{
				return;
			}
			Vector3 center = bounds.center;
			Vector3 vector = bounds.extents + Vector3.one * offset;
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			int kernelIndex = 2;
			foreach (GPUIShaderBuffer item in transformBufferValues)
			{
				if (item != null && item.Buffer != null)
				{
					cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, item.Buffer);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
					cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsCenter, center);
					cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsExtents, vector);
					cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				}
			}
		}

		public static void CullInstancesInsideCollider(Collider collider, float offset = 0f)
		{
			if (!GPUIRenderingSystem.IsActive)
			{
				return;
			}
			foreach (GPUIRenderSourceGroup value in GPUIRenderingSystem.Instance.RenderSourceGroupProvider.Values)
			{
				if (value.TransformBufferData != null)
				{
					CullInstancesInsideCollider(value.TransformBufferData, 0, value.BufferSize, collider, offset);
				}
			}
		}

		public static void CullInstancesInsideCollider(GPUIManager gpuiManager, Collider collider, List<int> prototypeIndexFilter = null, float offset = 0f)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				if (prototypeIndexFilter == null || prototypeIndexFilter.Contains(i))
				{
					CullInstancesInsideCollider(gpuiManager.GetRenderKey(i), collider, offset);
				}
			}
		}

		public static void CullInstancesInsideCollider(int renderKey, Collider collider, float offset = 0f)
		{
			if (GPUIRenderingSystem.TryGetTransformBufferData(renderKey, out var transformBufferData, out var bufferStartIndex, out var bufferSize, resetCrossFade: false))
			{
				CullInstancesInsideCollider(transformBufferData, bufferStartIndex, bufferSize, collider, offset);
			}
		}

		public static void CullInstancesInsideCollider(GPUITransformBufferData transformBufferData, int bufferStartIndex, int bufferSize, Collider collider, float offset = 0f)
		{
			if (!(collider == null) && bufferSize != 0)
			{
				if (collider is BoxCollider boxCollider)
				{
					CullInstancesInsideBoxCollider(transformBufferData, bufferStartIndex, bufferSize, boxCollider, offset);
				}
				else if (collider is SphereCollider sphereCollider)
				{
					CullInstancesInsideSphereCollider(transformBufferData, bufferStartIndex, bufferSize, sphereCollider, offset);
				}
				else if (collider is CapsuleCollider capsuleCollider)
				{
					CullInstancesInsideCapsuleCollider(transformBufferData, bufferStartIndex, bufferSize, capsuleCollider, offset);
				}
				else
				{
					CullInstancesInsideBounds(transformBufferData, bufferStartIndex, bufferSize, collider.bounds, offset);
				}
			}
		}

		public static void CullInstancesInsideBoxCollider(GPUIManager gpuiManager, BoxCollider boxCollider, List<int> prototypeIndexFilter = null, float offset = 0f)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				if (prototypeIndexFilter == null || prototypeIndexFilter.Contains(i))
				{
					CullInstancesInsideBoxCollider(gpuiManager.GetRenderKey(i), boxCollider, offset);
				}
			}
		}

		public static void CullInstancesInsideBoxCollider(int renderKey, BoxCollider boxCollider, float offset = 0f)
		{
			if (GPUIRenderingSystem.TryGetTransformBufferData(renderKey, out var transformBufferData, out var bufferStartIndex, out var bufferSize, resetCrossFade: false))
			{
				CullInstancesInsideBoxCollider(transformBufferData, bufferStartIndex, bufferSize, boxCollider, offset);
			}
		}

		public static void CullInstancesInsideBoxCollider(GPUITransformBufferData transformBufferData, int bufferStartIndex, int bufferSize, BoxCollider boxCollider, float offset = 0f)
		{
			if (bufferSize == 0)
			{
				return;
			}
			Dictionary<int, GPUIShaderBuffer>.ValueCollection transformBufferValues = transformBufferData.TransformBufferValues;
			if (transformBufferValues == null)
			{
				return;
			}
			Vector3 center = boxCollider.center;
			Vector3 vector = boxCollider.size / 2f + Vector3.one * offset;
			Matrix4x4 localToWorldMatrix = boxCollider.transform.localToWorldMatrix;
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			int kernelIndex = 3;
			foreach (GPUIShaderBuffer item in transformBufferValues)
			{
				if (item != null && item.Buffer != null)
				{
					cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, item.Buffer);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
					cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsCenter, center);
					cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsExtents, vector);
					cS_TransformModifications.SetMatrix(GPUIConstants.PROP_modifierTransform, localToWorldMatrix);
					cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				}
			}
		}

		public static void CullInstancesInsideSphereCollider(GPUIManager gpuiManager, SphereCollider sphereCollider, List<int> prototypeIndexFilter = null, float offset = 0f)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				if (prototypeIndexFilter == null || prototypeIndexFilter.Contains(i))
				{
					CullInstancesInsideSphereCollider(gpuiManager.GetRenderKey(i), sphereCollider, offset);
				}
			}
		}

		public static void CullInstancesInsideSphereCollider(int renderKey, SphereCollider sphereCollider, float offset = 0f)
		{
			if (GPUIRenderingSystem.TryGetTransformBufferData(renderKey, out var transformBufferData, out var bufferStartIndex, out var bufferSize, resetCrossFade: false))
			{
				CullInstancesInsideSphereCollider(transformBufferData, bufferStartIndex, bufferSize, sphereCollider, offset);
			}
		}

		public static void CullInstancesInsideSphereCollider(GPUITransformBufferData transformBufferData, int bufferStartIndex, int bufferSize, SphereCollider sphereCollider, float offset = 0f)
		{
			if (bufferSize == 0)
			{
				return;
			}
			Dictionary<int, GPUIShaderBuffer>.ValueCollection transformBufferValues = transformBufferData.TransformBufferValues;
			if (transformBufferValues == null)
			{
				return;
			}
			Vector3 vector = sphereCollider.center + sphereCollider.transform.position;
			Vector3 localScale = sphereCollider.transform.localScale;
			float val = sphereCollider.radius * Mathf.Max(Mathf.Max(localScale.x, localScale.y), localScale.z) + offset;
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			int kernelIndex = 4;
			foreach (GPUIShaderBuffer item in transformBufferValues)
			{
				if (item != null && item.Buffer != null)
				{
					cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, item.Buffer);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
					cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsCenter, vector);
					cS_TransformModifications.SetFloat(GPUIConstants.PROP_modifierRadius, val);
					cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				}
			}
		}

		public static void CullInstancesInsideCapsuleCollider(GPUIManager gpuiManager, CapsuleCollider capsuleCollider, List<int> prototypeIndexFilter = null, float offset = 0f)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				if (prototypeIndexFilter == null || prototypeIndexFilter.Contains(i))
				{
					CullInstancesInsideCapsuleCollider(gpuiManager.GetRenderKey(i), capsuleCollider, offset);
				}
			}
		}

		public static void CullInstancesInsideCapsuleCollider(int renderKey, CapsuleCollider capsuleCollider, float offset = 0f)
		{
			if (GPUIRenderingSystem.TryGetTransformBufferData(renderKey, out var transformBufferData, out var bufferStartIndex, out var bufferSize, resetCrossFade: false))
			{
				CullInstancesInsideCapsuleCollider(transformBufferData, bufferStartIndex, bufferSize, capsuleCollider, offset);
			}
		}

		public static void CullInstancesInsideCapsuleCollider(GPUITransformBufferData transformBufferData, int bufferStartIndex, int bufferSize, CapsuleCollider capsuleCollider, float offset = 0f)
		{
			if (bufferSize == 0)
			{
				return;
			}
			Dictionary<int, GPUIShaderBuffer>.ValueCollection transformBufferValues = transformBufferData.TransformBufferValues;
			if (transformBufferValues == null)
			{
				return;
			}
			Vector3 center = capsuleCollider.center;
			Vector3 localScale = capsuleCollider.transform.localScale;
			float val = capsuleCollider.radius * Mathf.Max(Mathf.Max((capsuleCollider.direction == 0) ? 0f : localScale.x, (capsuleCollider.direction == 1) ? 0f : localScale.y), (capsuleCollider.direction == 2) ? 0f : localScale.z) + offset;
			float val2 = capsuleCollider.height * ((capsuleCollider.direction == 0) ? localScale.x : ((capsuleCollider.direction == 1) ? localScale.y : ((capsuleCollider.direction == 2) ? localScale.z : 0f)));
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			int kernelIndex = 5;
			foreach (GPUIShaderBuffer item in transformBufferValues)
			{
				if (item != null && item.Buffer != null)
				{
					cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, item.Buffer);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
					cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsCenter, center);
					cS_TransformModifications.SetFloat(GPUIConstants.PROP_modifierRadius, val);
					cS_TransformModifications.SetFloat(GPUIConstants.PROP_modifierHeight, val2);
					cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				}
			}
		}

		public static void ResetAllCulledInstances()
		{
			if (!GPUIRenderingSystem.IsActive)
			{
				return;
			}
			foreach (GPUIRenderSourceGroup value in GPUIRenderingSystem.Instance.RenderSourceGroupProvider.Values)
			{
				if (value.TransformBufferData != null)
				{
					ResetCulledInstances(value.TransformBufferData, 0, value.BufferSize);
				}
			}
		}

		public static void ResetCulledInstances(GPUIManager gpuiManager, List<int> prototypeIndexFilter = null)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				if (prototypeIndexFilter == null || prototypeIndexFilter.Contains(i))
				{
					ResetCulledInstances(gpuiManager.GetRenderKey(i));
				}
			}
		}

		public static void ResetCulledInstances(int renderKey)
		{
			if (GPUIRenderingSystem.TryGetTransformBufferData(renderKey, out var transformBufferData, out var bufferStartIndex, out var bufferSize, resetCrossFade: false))
			{
				ResetCulledInstances(transformBufferData, bufferStartIndex, bufferSize);
			}
		}

		public static void ResetCulledInstances(GPUITransformBufferData transformBufferData, int bufferStartIndex, int bufferSize)
		{
			if (bufferSize == 0)
			{
				return;
			}
			Dictionary<int, GPUIShaderBuffer>.ValueCollection transformBufferValues = transformBufferData.TransformBufferValues;
			if (transformBufferValues == null)
			{
				return;
			}
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			int kernelIndex = 9;
			foreach (GPUIShaderBuffer item in transformBufferValues)
			{
				if (item != null && item.Buffer != null)
				{
					cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, item.Buffer);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
					cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				}
			}
			transformBufferData.OnTransformDataModified();
		}

		public static void ApplyMatrixOffsetToTransforms(GPUIManager gpuiManager, Matrix4x4 matrixOffset)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				ApplyMatrixOffsetToTransforms(gpuiManager.GetRenderKey(i), matrixOffset);
			}
		}

		public static void ApplyMatrixOffsetToTransforms(int renderKey, Matrix4x4 matrixOffset)
		{
			if (GPUIRenderingSystem.TryGetTransformBufferData(renderKey, out var transformBufferData, out var bufferStartIndex, out var bufferSize, resetCrossFade: false))
			{
				ApplyMatrixOffsetToTransforms(transformBufferData, bufferStartIndex, bufferSize, matrixOffset);
			}
		}

		public static void ApplyMatrixOffsetToTransforms(GPUITransformBufferData transformBufferData, int bufferStartIndex, int bufferSize, Matrix4x4 matrixOffset)
		{
			if (bufferSize == 0)
			{
				return;
			}
			Dictionary<int, GPUIShaderBuffer>.ValueCollection transformBufferValues = transformBufferData.TransformBufferValues;
			if (transformBufferValues == null)
			{
				return;
			}
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			foreach (GPUIShaderBuffer item in transformBufferValues)
			{
				if (item != null && item.Buffer != null)
				{
					cS_TransformModifications.SetBuffer(1, GPUIConstants.PROP_gpuiTransformBuffer, item.Buffer);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
					cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
					cS_TransformModifications.SetMatrix(GPUIConstants.PROP_matrix44, matrixOffset);
					cS_TransformModifications.DispatchX(1, bufferSize);
				}
			}
			transformBufferData.OnTransformDataModified();
		}
	}
}
