using System;
using Unity.Cinemachine;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Serializable]
	public class POVCameraPrefabSettings
	{
		[SerializeField]
		private GameObject m_prefab;

		[SerializeField]
		private CinemachinePanTilt m_panTilt;

		[SerializeField]
		private CameraInputAxisController m_inputAxisController;
	}
}
