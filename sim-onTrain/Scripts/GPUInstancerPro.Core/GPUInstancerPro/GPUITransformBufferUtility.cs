using System.Collections.Generic;
using UnityEngine;

namespace GPUInstancerPro
{
	public static class GPUITransformBufferUtility
	{
		public static void RemoveInstancesInsideCollider(GPUIManager gpuiManager, Collider collider, float offset = 0f, List<int> prototypeIndexFilter = null)
		{
			if (!Application.isPlaying)
			{
				Debug.LogError("RemoveInstances method can not be used in Edit Mode!");
			}
			else if (collider is BoxCollider boxCollider)
			{
				RemoveInstancesInsideBoxCollider(gpuiManager, boxCollider, offset, prototypeIndexFilter);
			}
			else if (collider is SphereCollider sphereCollider)
			{
				RemoveInstancesInsideSphereCollider(gpuiManager, sphereCollider, offset, prototypeIndexFilter);
			}
			else if (collider is CapsuleCollider capsuleCollider)
			{
				RemoveInstancesInsideCapsuleCollider(gpuiManager, capsuleCollider, offset, prototypeIndexFilter);
			}
			else
			{
				RemoveInstancesInsideBounds(gpuiManager, collider.bounds, offset, prototypeIndexFilter);
			}
		}

		public static void RemoveInstancesInsideBounds(GPUIManager gpuiManager, Bounds bounds, float offset = 0f, List<int> prototypeIndexFilter = null)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			Vector3 center = bounds.center;
			Vector3 extents = bounds.extents + Vector3.one * offset;
			for (int i = 0; i < prototypeCount; i++)
			{
				if ((prototypeIndexFilter == null || prototypeIndexFilter.Contains(i)) && GPUIRenderingSystem.TryGetTransformBuffer(gpuiManager.GetRenderKey(i), out GPUIShaderBuffer shaderBuffer, out int bufferStartIndex, out int bufferSize, (GPUICameraData)null, true))
				{
					RemoveInstancesInsideBounds(shaderBuffer, bufferStartIndex, bufferSize, center, extents);
				}
			}
		}

		public static void RemoveInstancesInsideBounds(GPUIShaderBuffer shaderBuffer, int bufferStartIndex, int bufferSize, Vector3 center, Vector3 extents)
		{
			if (bufferSize != 0 && shaderBuffer.Buffer != null)
			{
				ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
				int kernelIndex = 2;
				cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, shaderBuffer.Buffer);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
				cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsCenter, center);
				cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsExtents, extents);
				cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				shaderBuffer.OnDataModified();
			}
		}

		private static void RemoveInstancesInsideBoxCollider(GPUIManager gpuiManager, BoxCollider boxCollider, float offset = 0f, List<int> prototypeIndexFilter = null)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			Vector3 center = boxCollider.center;
			Vector3 extents = boxCollider.size / 2f + Vector3.one * offset;
			Matrix4x4 localToWorldMatrix = boxCollider.transform.localToWorldMatrix;
			for (int i = 0; i < prototypeCount; i++)
			{
				if ((prototypeIndexFilter == null || prototypeIndexFilter.Contains(i)) && GPUIRenderingSystem.TryGetTransformBuffer(gpuiManager.GetRenderKey(i), out GPUIShaderBuffer shaderBuffer, out int bufferStartIndex, out int bufferSize, (GPUICameraData)null, true))
				{
					RemoveInstancesInsideBoxCollider(shaderBuffer, bufferStartIndex, bufferSize, center, extents, localToWorldMatrix);
				}
			}
		}

		private static void RemoveInstancesInsideBoxCollider(GPUIShaderBuffer shaderBuffer, int bufferStartIndex, int bufferSize, Vector3 center, Vector3 extents, Matrix4x4 modifierTransform)
		{
			if (bufferSize != 0 && shaderBuffer.Buffer != null)
			{
				ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
				int kernelIndex = 3;
				cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, shaderBuffer.Buffer);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
				cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsCenter, center);
				cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsExtents, extents);
				cS_TransformModifications.SetMatrix(GPUIConstants.PROP_modifierTransform, modifierTransform);
				cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				shaderBuffer.OnDataModified();
			}
		}

		private static void RemoveInstancesInsideSphereCollider(GPUIManager gpuiManager, SphereCollider sphereCollider, float offset = 0f, List<int> prototypeIndexFilter = null)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			Vector3 center = sphereCollider.center + sphereCollider.transform.position;
			Vector3 localScale = sphereCollider.transform.localScale;
			float radius = sphereCollider.radius * Mathf.Max(Mathf.Max(localScale.x, localScale.y), localScale.z) + offset;
			for (int i = 0; i < prototypeCount; i++)
			{
				if ((prototypeIndexFilter == null || prototypeIndexFilter.Contains(i)) && GPUIRenderingSystem.TryGetTransformBuffer(gpuiManager.GetRenderKey(i), out GPUIShaderBuffer shaderBuffer, out int bufferStartIndex, out int bufferSize, (GPUICameraData)null, true))
				{
					RemoveInstancesInsideSphereCollider(shaderBuffer, bufferStartIndex, bufferSize, center, radius);
				}
			}
		}

		private static void RemoveInstancesInsideSphereCollider(GPUIShaderBuffer shaderBuffer, int bufferStartIndex, int bufferSize, Vector3 center, float radius)
		{
			if (bufferSize != 0 && shaderBuffer.Buffer != null)
			{
				ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
				int kernelIndex = 4;
				cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, shaderBuffer.Buffer);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
				cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsCenter, center);
				cS_TransformModifications.SetFloat(GPUIConstants.PROP_modifierRadius, radius);
				cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				shaderBuffer.OnDataModified();
			}
		}

		private static void RemoveInstancesInsideCapsuleCollider(GPUIManager gpuiManager, CapsuleCollider capsuleCollider, float offset = 0f, List<int> prototypeIndexFilter = null)
		{
			int prototypeCount = gpuiManager.GetPrototypeCount();
			Vector3 center = capsuleCollider.center;
			Vector3 localScale = capsuleCollider.transform.localScale;
			float radius = capsuleCollider.radius * Mathf.Max(Mathf.Max((capsuleCollider.direction == 0) ? 0f : localScale.x, (capsuleCollider.direction == 1) ? 0f : localScale.y), (capsuleCollider.direction == 2) ? 0f : localScale.z) + offset;
			float height = capsuleCollider.height * ((capsuleCollider.direction == 0) ? localScale.x : ((capsuleCollider.direction == 1) ? localScale.y : ((capsuleCollider.direction == 2) ? localScale.z : 0f)));
			for (int i = 0; i < prototypeCount; i++)
			{
				if ((prototypeIndexFilter == null || prototypeIndexFilter.Contains(i)) && GPUIRenderingSystem.TryGetTransformBuffer(gpuiManager.GetRenderKey(i), out GPUIShaderBuffer shaderBuffer, out int bufferStartIndex, out int bufferSize, (GPUICameraData)null, true))
				{
					RemoveInstancesInsideCapsuleCollider(shaderBuffer, bufferStartIndex, bufferSize, center, radius, height);
				}
			}
		}

		private static void RemoveInstancesInsideCapsuleCollider(GPUIShaderBuffer shaderBuffer, int bufferStartIndex, int bufferSize, Vector3 center, float radius, float height)
		{
			if (bufferSize != 0 && shaderBuffer.Buffer != null)
			{
				ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
				int kernelIndex = 5;
				cS_TransformModifications.SetBuffer(kernelIndex, GPUIConstants.PROP_gpuiTransformBuffer, shaderBuffer.Buffer);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
				cS_TransformModifications.SetVector(GPUIConstants.PROP_boundsCenter, center);
				cS_TransformModifications.SetFloat(GPUIConstants.PROP_modifierRadius, radius);
				cS_TransformModifications.SetFloat(GPUIConstants.PROP_modifierHeight, height);
				cS_TransformModifications.DispatchX(kernelIndex, bufferSize);
				shaderBuffer.OnDataModified();
			}
		}

		public static void ApplyMatrixOffsetToTransforms(GPUIManager manager, Matrix4x4 matrixOffset)
		{
			int prototypeCount = manager.GetPrototypeCount();
			for (int i = 0; i < prototypeCount; i++)
			{
				ApplyMatrixOffsetToTransforms(manager.GetRenderKey(i), matrixOffset);
			}
		}

		public static void ApplyMatrixOffsetToTransforms(int renderKey, Matrix4x4 matrixOffset)
		{
			if (renderKey != 0 && GPUIRenderingSystem.TryGetTransformBuffer(renderKey, out GPUIShaderBuffer shaderBuffer, out int bufferStartIndex, out int bufferSize, (GPUICameraData)null, true))
			{
				ApplyMatrixOffsetToTransforms(shaderBuffer, bufferStartIndex, bufferSize, matrixOffset);
			}
		}

		public static void ApplyMatrixOffsetToTransforms(GPUIShaderBuffer shaderBuffer, int bufferStartIndex, int bufferSize, Matrix4x4 matrixOffset)
		{
			if (bufferSize != 0 && shaderBuffer.Buffer != null)
			{
				ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
				cS_TransformModifications.SetBuffer(1, GPUIConstants.PROP_gpuiTransformBuffer, shaderBuffer.Buffer);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_startIndex, bufferStartIndex);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, bufferSize);
				cS_TransformModifications.SetMatrix(GPUIConstants.PROP_matrix44, matrixOffset);
				cS_TransformModifications.DispatchX(1, bufferSize);
				shaderBuffer.OnDataModified();
			}
		}
	}
}
