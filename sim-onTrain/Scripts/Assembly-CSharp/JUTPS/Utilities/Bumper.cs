using UnityEngine;

namespace JUTPS.Utilities
{
	public class Bumper : MonoBehaviour
	{
		public float Force;

		private void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.TryGetComponent<Rigidbody>(out var component))
			{
				component.velocity = base.transform.up * Force;
			}
		}
	}
}
