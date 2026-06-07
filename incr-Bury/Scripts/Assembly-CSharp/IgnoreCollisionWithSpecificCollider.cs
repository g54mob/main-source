using UnityEngine;

public class IgnoreCollisionWithSpecificCollider : MonoBehaviour
{
	[SerializeField]
	private Collider ourCol;

	[SerializeField]
	private Collider[] ignoreThese;

	private void Start()
	{
		IgnoreCollisions();
	}

	private void IgnoreCollisions()
	{
		Collider[] array = ignoreThese;
		foreach (Collider collider in array)
		{
			Physics.IgnoreCollision(ourCol, collider, ignore: true);
		}
	}
}
