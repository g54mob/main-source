using System.Collections;
using UnityEngine;

public class wfcolis : MonoBehaviour
{
	public GameObject p;

	public float t;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player" && !p.active)
		{
			p.SetActive(value: true);
			StartCoroutine(cor());
		}
	}

	private IEnumerator cor()
	{
		yield return new WaitForSeconds(t);
		p.SetActive(value: false);
	}
}
