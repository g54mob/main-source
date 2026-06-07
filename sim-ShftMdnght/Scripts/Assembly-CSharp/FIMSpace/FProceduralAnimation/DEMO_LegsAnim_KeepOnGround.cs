using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_LegsAnim_KeepOnGround : MonoBehaviour
	{
		public LayerMask mask;

		public float raycastRange = 0.1f;

		private Rigidbody rig;

		private void Start()
		{
			rig = GetComponent<Rigidbody>();
		}

		private void FixedUpdate()
		{
			if (!(rig == null) && Physics.Raycast(base.transform.position + Vector3.up * raycastRange * 0.5f, Vector3.down, out var hitInfo, raycastRange * 0.5f + raycastRange, mask, QueryTriggerInteraction.Ignore))
			{
				rig.MovePosition(hitInfo.point);
			}
		}
	}
}
