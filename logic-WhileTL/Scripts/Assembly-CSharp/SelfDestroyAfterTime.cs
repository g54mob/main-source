using UnityEngine;

public class SelfDestroyAfterTime : MonoBehaviour
{
	public float destroyTime;

	public float destroyTimeNintendo;

	public float destroyTimePS;

	private void Start()
	{
		Object.Destroy(base.gameObject, destroyTime);
	}
}
