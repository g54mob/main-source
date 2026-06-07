using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class POVCamera : MonoBehaviour
	{
		[SerializeField]
		private CinemachineCamera m_camera;

		[SerializeField]
		private CinemachinePanTilt m_panTilt;

		[SerializeField]
		private CameraInputAxisController m_inputAxisController;

		public CinemachineCamera CinemachineCamera => m_camera;

		public CinemachinePanTilt PanTilt => m_panTilt;

		public CameraInputAxisController InputAxisController => m_inputAxisController;

		public void SetEnable(bool enable)
		{
			if (enable)
			{
				OnSetEnable();
			}
			else
			{
				OnSetDisable();
			}
			m_inputAxisController.enabled = enable;
			UpdateCameraFovBaseOnApplicationOptions();
		}

		protected virtual void OnSetEnable()
		{
			GraphicsApplicationOptions.FieldOfView.OnValueChanged += OnFieldOfViewValueChanged_UpdateCameraFov;
		}

		protected virtual void OnSetDisable()
		{
			GraphicsApplicationOptions.FieldOfView.OnValueChanged -= OnFieldOfViewValueChanged_UpdateCameraFov;
		}

		private void OnFieldOfViewValueChanged_UpdateCameraFov(float value)
		{
			UpdateCameraFovBaseOnApplicationOptions();
		}

		private void UpdateCameraFovBaseOnApplicationOptions()
		{
			LensSettings lens = m_camera.Lens;
			lens.FieldOfView = GraphicsApplicationOptions.FieldOfView;
			m_camera.Lens = lens;
		}
	}
}
