using FluffyUnderware.DevTools;
using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.Curvy.Examples
{
	[ExecuteAlways]
	public class ChaseCam : MonoBehaviour
	{
		public Transform LookAt;

		public Transform MoveTo;

		public Transform RollTo;

		[Positive]
		public float ChaseTime;

		private Vector3 mVelocity;

		private Vector3 mRollVelocity;

		[UsedImplicitly]
		private void LateUpdate()
		{
		}
	}
}
