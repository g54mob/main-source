using System.Linq;
using UnityEngine;

namespace DV.Rain
{
	public class RotaryWiperDriver : WiperDriver
	{
		public Transform[] rotationaryTransforms;

		public Transform stationaryTransform;

		public float maxAngle;

		public AnimationCurve speedCurve;

		private float[] initialAngle;

		private Vector3 initialStationary;

		private void Start()
		{
			if (rotationaryTransforms == null || rotationaryTransforms.Length == 0)
			{
				Debug.LogError("rotationaryTransforms not set, disabling!");
				base.enabled = false;
				return;
			}
			initialAngle = rotationaryTransforms.Select((Transform rt) => (Quaternion.Inverse(base.transform.rotation) * rt.rotation).eulerAngles.z).ToArray();
			if ((bool)stationaryTransform)
			{
				initialStationary = rotationaryTransforms[0].InverseTransformPoint(stationaryTransform.position);
			}
		}

		protected override void FixedUpdate()
		{
			base.FixedUpdate();
			for (int i = 0; i < rotationaryTransforms.Length; i++)
			{
				Transform obj = rotationaryTransforms[i];
				float z = Mathf.Lerp(initialAngle[i], initialAngle[i] + maxAngle, speedCurve.Evaluate(currentPos));
				obj.rotation = base.transform.rotation * Quaternion.Euler(0f, 0f, z);
			}
			if ((bool)stationaryTransform)
			{
				stationaryTransform.position = rotationaryTransforms[0].TransformPoint(initialStationary);
			}
		}
	}
}
