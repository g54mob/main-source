using UnityEngine;

namespace TH20
{
	public class CameraLookAtPOISourceComponent : LookAtPOISourceComponent
	{
		private TopDownCameraLogic _cameraLogic;

		public void SetCamera(TopDownCameraLogic cameraLogic)
		{
			_cameraLogic = cameraLogic;
		}

		public override Vector3 LookAtPosition()
		{
			if (_cameraLogic == null)
			{
				return Vector3.zero;
			}
			return _cameraLogic.CameraComponent.transform.position;
		}

		public override Room GetRoomIn()
		{
			return null;
		}
	}
}
