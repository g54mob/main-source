using UnityEngine;

public class NewPathController : MonoBehaviour
{
	[SerializeField]
	private GameObject paths;

	[SerializeField]
	private GameObject objectInTrigger;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Path")
		{
			paths.SetActive(value: true);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Path")
		{
			paths.SetActive(value: false);
		}
	}
}
