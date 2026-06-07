using UnityEngine;

namespace KevinIglesias
{
	public class BowLoadScript : MonoBehaviour
	{
		public Transform bow;

		public Transform arrowHandRetargeter;

		public Transform bowHandRetargeter;

		private SkinnedMeshRenderer bowSkinnedMeshRenderer;

		public bool arrowOnHand;

		public Transform arrowToDraw;

		public Transform arrowToShoot;

		private void Awake()
		{
		}

		private void Update()
		{
		}
	}
}
