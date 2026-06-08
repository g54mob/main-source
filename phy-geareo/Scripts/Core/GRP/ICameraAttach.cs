using UnityEngine;

namespace GRP
{
	public interface ICameraAttach
	{
		void CameraAttach(OrbitCameraController camera, WorldPointerScan target, Vector3 relativePosition);
	}
}
