using Dhs5.Utility.Settings;
using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Player/Camera", Scope.Project)]
	public class CameraSettings : CustomSettings<CameraSettings>
	{
		[Header("Camera Transitions")]
		[SerializeField]
		[CinemachineEmbeddedAssetProperty(false)]
		private CinemachineBlenderSettings m_blendSettings;

		[Header("POV Camera Settings")]
		[SerializeField]
		private POVCameraPrefabSettings m_playerCamera;

		[SerializeField]
		private POVCameraPrefabSettings m_cashRegisterCamera;
	}
}
