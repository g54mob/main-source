using System.Collections;
using UnityEngine;

public class wfscare1 : MonoBehaviour
{
	public GameObject cam;

	public GameObject aud;

	public GameObject pl;

	public GameObject heart;

	public GameObject dr;

	public float sp;

	public float sp2;

	public float timer;

	public float tmax;

	private bool x;

	private void Start()
	{
		base.gameObject.GetComponent<Animator>().speed = 0f;
	}

	private void Update()
	{
		if (timer == 0f)
		{
			if (Physics.Raycast(new Ray(base.transform.position, -base.transform.position + cam.transform.position), out var hitInfo, 10f) && hitInfo.transform.tag == "Player")
			{
				base.gameObject.GetComponent<Animator>().speed = sp;
				timer = 1f;
			}
			return;
		}
		base.transform.position += new Vector3(Time.deltaTime * sp2, 0f, 0f);
		timer += Time.deltaTime;
		if (timer > tmax)
		{
			heart.SetActive(value: false);
			dr.SetActive(value: true);
			Object.Destroy(base.gameObject);
		}
		if (timer > 1.75f && !aud.active)
		{
			cam.GetComponent<Camera>().fieldOfView = 40f;
			aud.SetActive(value: true);
			pl.GetComponent<pl>().MX = -90f;
			pl.GetComponent<pl>().MY = 10f;
			StartCoroutine(cor());
		}
	}

	private IEnumerator cor()
	{
		yield return new WaitForSeconds(0.07f);
		if (!x)
		{
			cam.GetComponent<Camera>().fieldOfView = 70f;
			StartCoroutine(cor());
		}
		else
		{
			cam.GetComponent<Camera>().fieldOfView = 40f;
		}
		x = true;
	}
}
