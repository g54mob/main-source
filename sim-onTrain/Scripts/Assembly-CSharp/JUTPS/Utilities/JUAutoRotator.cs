using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.Utilities
{
	[AddComponentMenu("JU TPS/Utilities/Auto Rotator")]
	public class JUAutoRotator : MonoBehaviour
	{
		[JUHeader("Auto Rotate")]
		public float Speed = 1f;

		public Vector3 RotateAxis;

		public Space Space;

		private void Update()
		{
			base.transform.Rotate(RotateAxis * Speed * Time.deltaTime, Space);
		}
	}
}
