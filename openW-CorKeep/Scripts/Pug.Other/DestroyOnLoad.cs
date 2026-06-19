using UnityEngine;

public class DestroyOnLoad : MonoBehaviour
{
	private void Awake()
	{
		Object.Destroy(base.gameObject);
	}
}
