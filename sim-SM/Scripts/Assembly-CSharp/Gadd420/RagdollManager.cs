using UnityEngine;

namespace Gadd420
{
	public class RagdollManager : MonoBehaviour
	{
		private Collider[] colliders;

		private Rigidbody[] rbs;

		private IK[] ikScripts;

		private RB_Controller rbScript;

		private Rigidbody bikeRB;

		private bool velocitySet;

		[HideInInspector]
		public bool resetRider;

		private void Start()
		{
		}

		private void Update()
		{
		}
	}
}
