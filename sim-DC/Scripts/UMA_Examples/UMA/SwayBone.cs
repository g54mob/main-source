using UnityEngine;

namespace UMA
{
	public class SwayBone : MonoBehaviour
	{
		[Range(0f, 1f)]
		[Tooltip("How much inertia each bone has - makes it more bouncy")]
		public float inertia;

		[Range(1f, 2f)]
		[Tooltip("How far something can stretch - 1.0 = no stretch")]
		public float limit;

		[Range(1f, 4f)]
		[Tooltip("How much it can pull away during movement")]
		public float elasticity;

		[Tooltip("Only rotate. Not supported in v1")]
		public bool OrientOnly;

		[Tooltip("Also reorient bones")]
		public bool Reorient;

		protected Vector3 LastWorldPos;

		protected Vector3 localRestingPos;

		protected Vector3 currentForce;

		protected Vector3 localTarget;

		private Vector3 targetvector;

		protected Quaternion localOrientation;

		protected float MaxDistance;

		public float frameInertia;

		public bool isTopLevel;

		public Vector3 ViewLocalOrientation;

		public Vector3 ViewInverseLocalOrientation;

		public Vector3 ViewLocalRotation;

		public Vector3 ViewInverseLocalRotation;

		public Vector3 ViewRotation;

		public Vector3 ViewInverseRotation;

		public void Initialize()
		{
		}

		public void DoUpdate(float step)
		{
		}
	}
}
