using UnityEngine;

namespace ActiveRagdoll.Scripts
{
	[RequireComponent(typeof(Rigidbody), typeof(ConfigurableJoint))]
	public class Pelvis : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody m_rb;

		[SerializeField]
		private ConfigurableJoint m_joint;

		public Rigidbody wtr => null;

		public ConfigurableJoint wts => null;

		private void Update()
		{
		}
	}
}
