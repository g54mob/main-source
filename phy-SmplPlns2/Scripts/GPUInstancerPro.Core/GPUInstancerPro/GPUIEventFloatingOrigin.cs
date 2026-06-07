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
				GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
				instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(HandleFloatingOrigin));
				GPUIRenderingSystem instance2 = GPUIRenderingSystem.Instance;
				instance2.OnPreCull = (Action<GPUICameraData>)Delegate.Combine(instance2.OnPreCull, new Action<GPUICameraData>(HandleFloatingOrigin));
			}
		}

		private void OnDisable()
		{
			if (GPUIRenderingSystem.IsActive)
			{
				GPUIRenderingSystem instance = GPUIRenderingSystem.Instance;
				instance.OnPreCull = (Action<GPUICameraData>)Delegate.Remove(instance.OnPreCull, new Action<GPUICameraData>(HandleFloatingOrigin));
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
