using System.Collections;
using UnityEngine;

public class key : MonoBehaviour
{
	public float t;

	public GameObject cam;

	public GameObject pl;

	public GameObject gg;

	public GameObject dv;

	public GameObject shagi;

	public GameObject an;

	private void use()
	{
		base.gameObject.GetComponent<BoxCollider>().enabled = false;
		base.gameObject.GetComponent<AudioSource>().Play();
		StartCoroutine(a());
		cam.GetComponent<Animator>().enabled = false;
		pl.GetComponent<pl>().enabled = false;
		gg.GetComponent<Animator>().enabled = false;
		shagi.GetComponent<AudioSource>().volume = 0f;
		an.GetComponent<Animator>().enabled = true;
	}

	public IEnumerator a()
	{
		yield return new WaitForSeconds(t);
		base.gameObject.SetActive(value: false);
		dv.GetComponent<dver>().enabled = true;
		dv.GetComponent<Rigidbody>().isKinematic = false;
		cam.GetComponent<Animator>().enabled = true;
		pl.GetComponent<pl>().enabled = true;
		gg.GetComponent<Animator>().enabled = true;
	}
}
