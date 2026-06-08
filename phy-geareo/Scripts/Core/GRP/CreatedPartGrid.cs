using UnityEngine;

namespace GRP
{
	public class CreatedPartGrid : MonoBehaviour
	{
		public Transform target;

		public Transform rotate;

		public Transform pointer;

		public LineRenderer pointerLine;

		public float smooth;

		public AnimationCurve alpha;

		public Renderer[] renderers;

		private float flashTime;

		public void Flash()
		{
		}

		public void Hide()
		{
		}

		private void Update()
		{
		}

		private void LateUpdate()
		{
		}

		public void UpdateRotation(Quaternion rotation)
		{
		}
	}
}
