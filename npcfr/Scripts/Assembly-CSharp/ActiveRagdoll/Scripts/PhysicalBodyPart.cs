using UnityEngine;

namespace ActiveRagdoll.Scripts
{
	public class PhysicalBodyPart : MonoBehaviour
	{
		[SerializeField]
		private Transform m_target;

		private ConfigurableJoint phx;

		private Quaternion phy;

		private Rigidbody phz;

		private void Start()
		{
		}

		private void FixedUpdate()
		{
		}
	}
}
