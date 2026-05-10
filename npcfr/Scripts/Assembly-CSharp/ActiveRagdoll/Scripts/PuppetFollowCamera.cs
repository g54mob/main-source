using UnityEngine;

namespace ActiveRagdoll.Scripts
{
	public class PuppetFollowCamera : MonoBehaviour
	{
		[SerializeField]
		private Transform m_puppet;

		private Camera pia;

		private Transform pib;

		private Vector3 pic;

		private Vector3 pid;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
