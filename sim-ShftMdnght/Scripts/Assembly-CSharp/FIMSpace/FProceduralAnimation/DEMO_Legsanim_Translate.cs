using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	public class DEMO_Legsanim_Translate : MonoBehaviour
	{
		public Vector3 LocalOffset = Vector3.zero;

		private Rigidbody rig;

		private void Start()
		{
			rig = GetComponent<Rigidbody>();
		}

		private void Update()
		{
			if (!(rig != null))
			{
				base.transform.position += base.transform.TransformVector(LocalOffset * Time.deltaTime);
			}
		}

		private void FixedUpdate()
		{
			if (!(rig == null))
			{
				Vector3 velocity = base.transform.TransformVector(LocalOffset);
				velocity.y = rig.velocity.y;
				rig.velocity = velocity;
			}
		}
	}
}
