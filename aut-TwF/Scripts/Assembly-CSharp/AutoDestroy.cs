using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
	[SerializeField]
	private float timeToDestroy = 1f;

	private void Start()
	{
		Object.Destroy(base.gameObject, timeToDestroy);
	}
}
