using UnityEngine;

[AddComponentMenu("")]
public class CubeKiller : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Object.Destroy(other.gameObject);
	}
}
