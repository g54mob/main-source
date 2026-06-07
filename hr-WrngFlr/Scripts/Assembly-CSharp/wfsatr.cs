using UnityEngine;

public class wfsatr : MonoBehaviour
{
	public GameObject[] sat;

	public GameObject[] saf;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			for (int i = 0; i < sat.Length; i++)
			{
				sat[i].SetActive(value: true);
			}
			for (int j = 0; j < saf.Length; j++)
			{
				saf[j].SetActive(value: false);
			}
		}
	}
}
