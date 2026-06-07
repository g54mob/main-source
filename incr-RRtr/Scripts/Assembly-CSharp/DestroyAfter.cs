using UnityEngine;

public class DestroyAfter : MonoBehaviour
{
	[SerializeField]
	private float seconds;

	private void Start()
	{
		if (seconds <= 0f)
		{
			Object.Destroy(base.gameObject);
		}
		if (seconds > 0f)
		{
			Object.Destroy(base.gameObject, seconds);
		}
	}
}
