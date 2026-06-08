using System.Collections.Generic;
using UnityEngine;

namespace GRP
{
	public class CameraSim : MonoBehaviour
	{
		public OrbitCameraController camera;

		public List<CameraPartSim> allCameraParts;

		private CameraPartSim currentCamera;

		private List<CameraPartSim> requestedCameras;

		private ProjectSim project;

		public void Init(ProjectSim project)
		{
		}

		public void Clear()
		{
		}

		public void Tick()
		{
		}

		public void ToggleCamera(CameraPartSim cameraPart)
		{
		}
	}
}
