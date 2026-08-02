using UnityEngine;

namespace Dreamteck.Splines.Examples
{
	public class CameraSmoothRotation : MonoBehaviour
	{
		public float damp;

		private SplineFollower follower;

		private Transform trs;

		private void Start()
		{
			trs = base.transform;
			follower = GetComponent<SplineFollower>();
		}

		private void Update()
		{
			if (damp <= 0f)
			{
				follower.motion.applyRotation = true;
				return;
			}
			follower.motion.applyRotation = false;
			trs.rotation = Quaternion.Slerp(trs.rotation, follower.modifiedResult.rotation, Time.deltaTime / damp);
		}
	}
}
