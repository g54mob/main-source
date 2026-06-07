using UnityEngine;

public class DestroyIfNotMac : MonoBehaviour
{
	private void Start()
	{
		Object.Destroy(base.gameObject);
	}
}
