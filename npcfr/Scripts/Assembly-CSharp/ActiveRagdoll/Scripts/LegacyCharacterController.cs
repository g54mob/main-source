using ActiveRagdoll.Scripts.Muscle;
using UnityEngine;

namespace ActiveRagdoll.Scripts
{
	public class LegacyCharacterController : MonoBehaviour
	{
		[SerializeField]
		private float m_startMass;

		[SerializeField]
		private float m_positionSpring;

		[SerializeField]
		private float m_positionDamper;

		[SerializeField]
		private LegacyMuscle m_pelvis;

		[SerializeField]
		private MeshRenderer[] m_meshRenderers;

		[SerializeField]
		private float m_testRotationSpeed;

		private void Update()
		{
		}
	}
}
