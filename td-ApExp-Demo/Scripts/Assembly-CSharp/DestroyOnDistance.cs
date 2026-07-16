using UnityEngine;

public class DestroyOnDistance : MonoBehaviour
{
	private float destroyDst = 10f;

	private void Update()
	{
		if (base.transform.position.x < 0f - destroyDst)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
