using UnityEngine;
using UnityEngine.Events;

namespace GPUInstancerPro
{
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#Face_Camera_Event")]
	public class GPUIEventFaceCamera : MonoBehaviour
	{
		public GPUIManager gpuiManager;

		public int prototypeIndex;

		public bool isFaceCameraPos;

		private void OnEnable()
		{
			GPUIRenderingSystem.InitializeRenderingSystem();
			GPUIRenderingSystem.Instance.OnPreCull.AddListener(isFaceCameraPos ? new UnityAction<GPUICameraData>(TransformFaceCameraPos) : new UnityAction<GPUICameraData>(TransformFaceCameraView));
		}

		private void OnDisable()
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(isFaceCameraPos ? new UnityAction<GPUICameraData>(TransformFaceCameraPos) : new UnityAction<GPUICameraData>(TransformFaceCameraView));
			}
		}

		public void TransformFaceCameraView(GPUICameraData cameraData)
		{
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			if (cameraData.TryGetShaderBuffer(gpuiManager, prototypeIndex, out var shaderBuffer))
			{
				cS_TransformModifications.SetBuffer(6, GPUIConstants.PROP_gpuiTransformBuffer, shaderBuffer.Buffer);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, shaderBuffer.BufferSize);
				cS_TransformModifications.SetMatrix(GPUIConstants.PROP_matrix44, cameraData.ActiveCamera.cameraToWorldMatrix);
				cS_TransformModifications.DispatchX(6, shaderBuffer.BufferSize);
			}
		}

		public void TransformFaceCameraPos(GPUICameraData cameraData)
		{
			ComputeShader cS_TransformModifications = GPUIConstants.CS_TransformModifications;
			if (cameraData.TryGetShaderBuffer(gpuiManager, prototypeIndex, out var shaderBuffer))
			{
				cS_TransformModifications.SetBuffer(7, GPUIConstants.PROP_gpuiTransformBuffer, shaderBuffer.Buffer);
				cS_TransformModifications.SetInt(GPUIConstants.PROP_bufferSize, shaderBuffer.BufferSize);
				cS_TransformModifications.SetVector(GPUIConstants.PROP_position, cameraData.ActiveCamera.transform.position);
				cS_TransformModifications.DispatchX(7, shaderBuffer.BufferSize);
			}
		}
	}
}
