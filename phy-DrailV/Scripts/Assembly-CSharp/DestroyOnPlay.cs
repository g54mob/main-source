using UnityEngine;

public class DestroyOnPlay : MonoBehaviour
{
	private void Awake()
	{
		Object.Destroy(base.gameObject);
	}
}
