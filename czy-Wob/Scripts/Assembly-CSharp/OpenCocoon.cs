using UnityEngine;

public class OpenCocoon : MonoBehaviour
{
	public GameObject colliderObjectA;

	public GameObject colliderObjectB;

	private void Awake()
	{
		IgnoreCollisions();
	}

	private void IgnoreCollisions()
	{
		Collider[] componentsInChildren = colliderObjectA.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Collider[] componentsInChildren2 = colliderObjectB.GetComponentsInChildren<Collider>();
			foreach (Collider collider2 in componentsInChildren2)
			{
				Physics.IgnoreCollision(collider, collider2);
			}
		}
	}
}
