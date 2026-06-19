using UnityEngine;

public class PlantTree : MonoBehaviour
{
	private void Awake()
	{
		UpdateCollisions();
	}

	private void UpdateCollisions()
	{
		Collider[] componentsInChildren = base.transform.parent.GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Collider[] componentsInChildren2 = base.transform.parent.GetComponentsInChildren<Collider>();
			foreach (Collider collider2 in componentsInChildren2)
			{
				if (collider != collider2)
				{
					Physics.IgnoreCollision(collider, collider2);
				}
			}
		}
	}
}
