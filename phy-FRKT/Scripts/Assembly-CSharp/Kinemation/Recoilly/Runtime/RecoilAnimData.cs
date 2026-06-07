using UnityEngine;

namespace Kinemation.Recoilly.Runtime
{
	[CreateAssetMenu(fileName = "NewRecoilAnimData", menuName = "RecoilAnimData")]
	public class RecoilAnimData : ScriptableObject
	{
		public Vector2 pitch;

		public Vector4 roll;

		public Vector4 yaw;

		public Vector2 kickback;

		public Vector2 kickUp;

		public Vector2 kickRight;

		public Vector3 aimRot;

		public Vector3 aimLoc;

		public Vector3 smoothRot;

		public Vector3 smoothLoc;

		public Vector3 extraRot;

		public Vector3 extraLoc;

		public Vector2 noiseX;

		public Vector2 noiseY;

		public Vector2 noiseAccel;

		public Vector2 noiseDamp;

		public float noiseScalar;

		public float pushAmount;

		public float pushAccel;

		public float pushDamp;

		public bool smoothRoll;

		public float playRate;

		public RecoilCurves recoilCurves;
	}
}
