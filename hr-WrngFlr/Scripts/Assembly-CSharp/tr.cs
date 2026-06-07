using UnityEngine;

public class tr : MonoBehaviour
{
	public GameObject sat;

	private void Update()
	{
		if (base.gameObject.GetComponent<vkl>().on)
		{
			sat.SetActive(value: true);
			base.gameObject.GetComponent<tr>().enabled = false;
		}
	}
}
