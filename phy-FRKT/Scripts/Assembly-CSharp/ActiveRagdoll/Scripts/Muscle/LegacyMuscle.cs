using UnityEngine;

namespace ActiveRagdoll.Scripts.Muscle
{
	[RequireComponent(typeof(Rigidbody))]
	public class LegacyMuscle : MonoBehaviour
	{
		[SerializeField]
		private ConfigurableJoint m_joint;

		[SerializeField]
		private Transform m_target;

		public ConfigurableJoint wtt => null;

		public Transform wtu => null;
	}
}
