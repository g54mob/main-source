using UnityEngine;

public class LimitedLifetime : MonoBehaviour
{
	public float liftetime = 5f;

	private void Start()
	{
		Object.Destroy(base.gameObject, liftetime);
	}
}
