using UnityEngine;

public class AddForceComponent : MonoBehaviour
{
	public float forceAmount = 100f;

	public void AddForceToRigidbodyOnCollision(Collider collidedObject)
	{
		if (collidedObject.TryGetComponent<Rigidbody>(out var component))
		{
			Vector3 normalized = (collidedObject.transform.position - base.transform.position).normalized;
			component.AddForce(normalized * forceAmount, ForceMode.Impulse);
		}
		else if (collidedObject.transform.parent.TryGetComponent<Rigidbody>(out component))
		{
			Vector3 normalized2 = (collidedObject.transform.position - base.transform.position).normalized;
			normalized2 += Vector3.up;
			normalized2.Normalize();
			component.AddForce(normalized2 * forceAmount, ForceMode.Impulse);
		}
		else
		{
			Debug.LogWarning("The collided object does not have a Rigidbody component.");
		}
	}
}
