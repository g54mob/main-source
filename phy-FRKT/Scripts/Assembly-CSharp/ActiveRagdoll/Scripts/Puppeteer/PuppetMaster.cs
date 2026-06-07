using UnityEngine;

namespace ActiveRagdoll.Scripts.Puppeteer
{
	public class PuppetMaster : MonoBehaviour
	{
		[SerializeField]
		private Transform m_pelvis;

		[SerializeField]
		private Transform m_puppetPelvis;

		[SerializeField]
		private MeshRenderer[] m_meshRenderers;

		[SerializeField]
		private float m_allowedDistanceToGround;

		[SerializeField]
		private float m_allowedDistanceToGroundForPuppet;

		private bool pie;

		public void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
