using UnityEngine;

namespace Player
{
	public class ItemBobIK : MonoBehaviour
	{
		[Header("Bobbing (Animation Curves)")]
		public AnimationCurve bobCurveX = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		public AnimationCurve bobCurveY = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

		public AnimationCurve bobCurveZ = AnimationCurve.EaseInOut(0f, 0f, 1f, 0f);

		public float bobSpeed = 1f;

		public float bobAmount = 0.05f;

		[Header("Sway Settings")]
		public float velocitySwayWeight = 0.002f;

		public float lookSwayWeight = 0.02f;

		public float swaySmoothness = 6f;

		[Header("References")]
		public CharacterController controller;

		public Transform ikTarget;

		private Vector3 initialIKLocalPos;

		private Vector3 swayVelocityOffset;

		private Vector3 swayLookOffset;

		private float bobTimer;

		private float curveLength = 1f;

		private void Start()
		{
			if (ikTarget == null)
			{
				Debug.LogWarning("ItemBobIK: IK target not assigned.");
				base.enabled = false;
				return;
			}
			initialIKLocalPos = ikTarget.localPosition;
			if (bobCurveX.length > 0)
			{
				curveLength = bobCurveX[bobCurveX.length - 1].time;
			}
		}

		private void Update()
		{
			Vector3 velocity = controller.velocity;
			ApplyVelocitySway(velocity);
			ApplyLookSway();
			ApplyBobbing(velocity);
		}

		private void ApplyBobbing(Vector3 velocity)
		{
			if (new Vector2(velocity.x, velocity.z).magnitude > 0.1f && controller.isGrounded)
			{
				bobTimer += Time.deltaTime * bobSpeed;
				float time = bobTimer % curveLength;
				float x = bobCurveX.Evaluate(time) * bobAmount;
				float y = bobCurveY.Evaluate(time) * bobAmount;
				float z = bobCurveZ.Evaluate(time) * bobAmount;
				Vector3 vector = new Vector3(x, y, z) + swayVelocityOffset + swayLookOffset;
				ikTarget.localPosition = Vector3.Lerp(ikTarget.localPosition, initialIKLocalPos + vector, Time.deltaTime * 10f);
			}
			else
			{
				Vector3 vector = swayVelocityOffset + swayLookOffset;
				ikTarget.localPosition = Vector3.Lerp(ikTarget.localPosition, initialIKLocalPos + vector, Time.deltaTime * 6f);
			}
		}

		private void ApplyVelocitySway(Vector3 velocity)
		{
			Vector3 b = new Vector3(0f - velocity.x, 0f - velocity.y, 0f - velocity.z) * velocitySwayWeight;
			swayVelocityOffset = Vector3.Lerp(swayVelocityOffset, b, Time.deltaTime * swaySmoothness);
		}

		private void ApplyLookSway()
		{
			float axis = Input.GetAxis("Mouse X");
			float axis2 = Input.GetAxis("Mouse Y");
			Vector3 b = new Vector3(0f - axis, 0f - axis2, 0f) * lookSwayWeight;
			swayLookOffset = Vector3.Lerp(swayLookOffset, b, Time.deltaTime * swaySmoothness);
		}
	}
}
