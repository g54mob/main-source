using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;

namespace CTS
{
	public class CameraUtilities : MonoBehaviour
	{
		public static float GetDistanceFromCam(Camera p_cam, Vector3 p_target)
		{
			return Vector3.Dot(p_target - p_cam.transform.position, p_cam.transform.forward);
		}

		public static Vector3 GetMouseWorldPositionXZ(Camera p_cam, float p_distanceFromCam = 0f, float p_YOffset = 0f)
		{
			Vector2 vector = Mouse.current.position.ReadValue();
			Vector3 vector2 = p_cam.ScreenToWorldPoint(new Vector3(vector.x, vector.y, p_distanceFromCam));
			return new Vector3(vector2.x, p_YOffset, vector2.z);
		}

		public static Vector3 GetTouchWorldPositionXZ(Camera p_cam, float p_distanceFromCam = 0f, float p_YOffset = 0f)
		{
			Vector3 position = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches[0].screenPosition;
			position.z = p_distanceFromCam;
			Vector3 vector = p_cam.ScreenToWorldPoint(position);
			return new Vector3(vector.x, 0f, vector.z);
		}
	}
}
