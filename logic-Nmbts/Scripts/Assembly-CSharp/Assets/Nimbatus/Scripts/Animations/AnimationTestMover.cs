using UnityEngine;

namespace Assets.Nimbatus.Scripts.Animations
{
	public class AnimationTestMover : MonoBehaviour
	{
		public AnimationCurve xMovement;

		public AnimationCurve yMovement;

		public AnimationCurve scaleMovement;

		public float xAmplitude = 1f;

		public float yAmplitude = 1f;

		public float scaleAmplitude = 1f;

		public float animationSpeed = 1f;

		public Transform target;

		public float angleOffset;

		private float currentTime;

		private void Start()
		{
		}

		private void Update()
		{
			if (target != null)
			{
				currentTime += Time.deltaTime * animationSpeed;
				float num = xMovement.Evaluate(currentTime) * xAmplitude;
				float num2 = yMovement.Evaluate(currentTime) * yAmplitude;
				float num3 = scaleMovement.Evaluate(currentTime) * scaleAmplitude;
				float time = currentTime + 0.01f;
				float num4 = xMovement.Evaluate(time) * xAmplitude;
				float z = Mathf.Atan2(yMovement.Evaluate(time) * yAmplitude - num2, num4 - num) * 57.29578f + angleOffset;
				target.position = new Vector3(num, num2, target.position.z) + base.transform.position;
				target.eulerAngles = new Vector3(0f, 0f, z);
				target.localScale = new Vector3(num3, num3, num3);
			}
		}
	}
}
