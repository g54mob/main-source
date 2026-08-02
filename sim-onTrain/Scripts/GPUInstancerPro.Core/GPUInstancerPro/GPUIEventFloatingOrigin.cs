using System;
using UnityEngine;

namespace GPUInstancerPro
{
	[HelpURL("https://wiki.gurbu.com/index.php?title=GPU_Instancer_Pro:GettingStarted#Floating_Origin_Event")]
	public class GPUIEventFloatingOrigin : MonoBehaviour
	{
		[SerializeField]
		public Transform floatingOrigin;

		[SerializeField]
		public GPUIManager manager;

		[NonSerialized]
		private Matrix4x4 _previousMatrix;

		private void OnEnable()
		{
			if (!(manager == null) && !(floatingOrigin == null))
			{
				_previousMatrix = floatingOrigin.localToWorldMatrix;
				GPUIRenderingSystem.InitializeRenderingSystem();
				GPUIRenderingSystem.Instance.OnPreCull.AddListener(HandleFloatingOrigin);
			}
		}

		private void OnDisable()
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem.Instance.OnPreCull.RemoveListener(HandleFloatingOrigin);
			}
		}

		public void HandleFloatingOrigin(GPUICameraData cameraData)
		{
			Matrix4x4 localToWorldMatrix = floatingOrigin.localToWorldMatrix;
			if (localToWorldMatrix != _previousMatrix)
			{
				Matrix4x4 matrixOffset = localToWorldMatrix * _previousMatrix.inverse;
				GPUITransformBufferUtility.ApplyMatrixOffsetToTransforms(manager, matrixOffset);
				_previousMatrix = localToWorldMatrix;
			}
		}
	}
}
