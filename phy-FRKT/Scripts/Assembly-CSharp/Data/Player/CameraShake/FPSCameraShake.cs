using Player.Cam;
using UnityEngine;

namespace Data.Player.CameraShake
{
	[CreateAssetMenu(fileName = "NewCameraShake", menuName = "FRUKT/Camera/Shake")]
	public class FPSCameraShake : ScriptableObject
	{
		public CameraVectorCurve shakeCurve;

		public Vector4 pitch;

		public Vector4 yaw;

		public Vector4 roll;

		[Min(0f)]
		public float smoothSpeed;

		[Min(0f)]
		public float playRate;

		public static float jcq(Vector4 a)
		{
			return 0f;
		}
	}
}
