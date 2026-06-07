using UnityEngine;

public class klych : MonoBehaviour
{
	public AudioClip aud;

	public GameObject[] sat;

	public GameObject[] saf;

	public void use()
	{
		for (int i = 0; i < sat.Length; i++)
		{
			sat[i].SetActive(value: true);
		}
		for (int j = 0; j < saf.Length; j++)
		{
			saf[j].SetActive(value: false);
		}
		if (aud != null)
		{
			AudioSource.PlayClipAtPoint(aud, base.transform.position);
		}
	}
}
