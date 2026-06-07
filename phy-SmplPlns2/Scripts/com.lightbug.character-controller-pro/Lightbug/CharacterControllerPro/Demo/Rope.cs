using Lightbug.Utilities;
using UnityEngine;

namespace Lightbug.CharacterControllerPro.Demo
{
	public class Rope : MonoBehaviour
	{
		[Header("Debug")]
		[SerializeField]
		private bool showGizmos = true;

		[Header("Properties")]
		[SerializeField]
		private Vector3 topLocalPosition = Vector3.zero;

		[SerializeField]
		private Vector3 bottomLocalPosition = Vector3.zero;

		public Vector3 TopPosition => base.transform.position + base.transform.TransformVectorUnscaled(topLocalPosition);

		public Vector3 BottomPosition => base.transform.position + base.transform.TransformVectorUnscaled(bottomLocalPosition);

		public Vector3 BottomToTop => TopPosition - BottomPosition;

		public bool IsInRange(Vector3 referencePosition)
		{
			Vector3 to = referencePosition - BottomPosition;
			if (Vector3.Angle(BottomToTop, to) > 90f)
			{
				return false;
			}
			Vector3 to2 = referencePosition - TopPosition;
			if (Vector3.Angle(BottomToTop, to2) < 90f)
			{
				return false;
			}
			return true;
		}

		private void OnDrawGizmos()
		{
			if (showGizmos)
			{
				Gizmos.color = new Color(0f, 1f, 0f, 0.2f);
				Gizmos.DrawSphere(TopPosition, 0.25f);
				Gizmos.color = new Color(0f, 0f, 1f, 0.2f);
				Gizmos.DrawSphere(BottomPosition, 0.25f);
			}
		}
	}
}
