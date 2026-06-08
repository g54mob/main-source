using UnityEngine;
using UnityEngine.SceneManagement;

namespace GRP
{
	public class PhysicsPiece : MonoBehaviour
	{
		public Rigidbody rb;

		public int order;

		public PhysicsController controller;

		private Transform startParent;

		private Vector3 startPosition;

		private Quaternion startRotation;

		private Scene startScene;

		private bool isKinematic;

		private void Awake()
		{
		}

		public void Attach(PhysicsController controller)
		{
		}

		public void Detach()
		{
		}

		private void Reset()
		{
		}
	}
}
