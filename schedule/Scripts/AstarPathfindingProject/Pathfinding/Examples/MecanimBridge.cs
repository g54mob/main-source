using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_mecanim_bridge.php")]
	public class MecanimBridge : VersionedMonoBehaviour
	{
		public float velocitySmoothing;

		private IAstarAI ai;

		private Animator anim;

		private Transform tr;

		private Vector3 smoothedVelocity;

		private Vector3[] prevFootPos;

		private Transform[] footTransforms;

		protected override void Awake()
		{
		}

		private void Update()
		{
		}

		private Vector3 CalculateBlendPoint()
		{
			return default(Vector3);
		}

		private void OnAnimatorMove()
		{
		}

		private static Vector3 RotatePointAround(Vector3 point, Vector3 around, Quaternion rotation)
		{
			return default(Vector3);
		}

		protected virtual Quaternion RotateTowards(Vector3 direction, float maxDegrees)
		{
			return default(Quaternion);
		}
	}
}
