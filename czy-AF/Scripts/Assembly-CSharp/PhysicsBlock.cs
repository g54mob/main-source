using UnityEngine;

public class PhysicsBlock : MonoBehaviour
{
	private bool infected;

	private void Awake()
	{
		if (!GetComponent<Rigidbody>())
		{
			GetComponent<MeshCollider>().convex = true;
			base.gameObject.AddComponent<Rigidbody>();
			Object.Destroy(base.gameObject, 4f);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (!infected && collision.relativeVelocity.magnitude > 2f && (bool)collision.transform.GetComponent<BlockComponent>())
		{
			collision.transform.gameObject.AddComponent<PhysicsBlock>();
			infected = true;
		}
	}
}
