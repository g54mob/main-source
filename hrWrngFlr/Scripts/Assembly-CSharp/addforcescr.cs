using System.Collections;
using UnityEngine;

public class addforcescr : MonoBehaviour
{
	public GameObject dv;

	public GameObject l;

	public Camera cam;

	public int force;

	public int x;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			dv.GetComponent<Rigidbody>().isKinematic = false;
			dv.GetComponent<Rigidbody>().AddForce(-Vector3.forward * force);
			base.gameObject.GetComponent<AudioSource>().Play();
			base.gameObject.GetComponent<BoxCollider>().enabled = false;
			l.SetActive(value: true);
			StartCoroutine(d());
			StartCoroutine(f());
			cam.fieldOfView = 40f;
		}
	}

	private IEnumerator f()
	{
		yield return new WaitForSeconds(0.03f);
		if (x == 0)
		{
			cam.fieldOfView = 80f;
		}
		else if (x == 1)
		{
			cam.fieldOfView = 40f;
		}
		else if (x == 2)
		{
			cam.fieldOfView = 80f;
		}
		else if (x == 3)
		{
			cam.fieldOfView = 40f;
		}
		x++;
		if (x < 4)
		{
			StartCoroutine(f());
		}
	}

	private IEnumerator d()
	{
		yield return new WaitForSeconds(0.7f);
		if (dv != null)
		{
			Object.Destroy(dv);
		}
		if (!base.gameObject.GetComponent<AudioSource>().isPlaying)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			StartCoroutine(d());
		}
	}
}
