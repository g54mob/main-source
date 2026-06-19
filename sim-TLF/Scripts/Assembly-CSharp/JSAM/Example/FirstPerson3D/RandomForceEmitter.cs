using UnityEngine;

namespace JSAM.Example.FirstPerson3D
{
	public class RandomForceEmitter : MonoBehaviour
	{
		[SerializeField]
		private float upWardsForce = 1f;

		[SerializeField]
		private float jumpCooldown = 2.5f;

		private Rigidbody rb;

		private void Awake()
		{
			rb = GetComponent<Rigidbody>();
		}

		private void Start()
		{
			InvokeRepeating("AddForceForNoReason", 0f, jumpCooldown);
		}

		private void AddForceForNoReason()
		{
			rb.AddForce(Vector3.up * upWardsForce);
		}
	}
}
