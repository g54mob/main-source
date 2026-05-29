using UnityEngine;

namespace Gadd420
{
	public class TriggerToCollider : MonoBehaviour
	{
		[Header("Make Sure All GameObjects on this bike use this tag")]
		public string dontCollideWithTag;

		private RB_Controller rbScript;

		private RagdollManager ragdollManager;

		private Collider theCollider;

		private void Start()
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}
	}
}
