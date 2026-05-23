using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
	public float destroyAfter = 5f;

	private void Update()
	{
		destroyAfter -= Time.deltaTime;
		if (destroyAfter <= 0f)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
