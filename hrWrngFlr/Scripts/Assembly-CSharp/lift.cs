using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class lift : MonoBehaviour
{
	public GameObject zvyk;

	public GameObject dver1;

	public GameObject dver2;

	public GameObject col;

	public GameObject pl;

	public GameObject cam;

	public GameObject potolok;

	public GameObject l;

	public GameObject l8;

	public GameObject l1;

	public GameObject lb;

	public GameObject lv;

	public GameObject darkrrom;

	public GameObject misc;

	public GameObject poc1;

	public GameObject poc2;

	public GameObject poc3;

	public GameObject kn;

	public GameObject konnad;

	public int x;

	public bool db;

	public float timer;

	public AudioClip kon;

	public AudioClip nach;

	public AudioClip aud;

	public AudioClip power;

	public AudioClip sw;

	public Volume vol;

	private void Update()
	{
		if (x == 1)
		{
			if (zvyk.transform.position.y < 3.33242f)
			{
				zvyk.transform.position += new Vector3(0f, Time.deltaTime, 0f);
			}
			else
			{
				zvyk.transform.position = new Vector3(zvyk.transform.position.x, 3.33242f, zvyk.transform.position.z);
				zvyk.GetComponent<AudioSource>().Stop();
				zvyk.GetComponent<AudioSource>().PlayOneShot(kon);
				x = 2;
			}
		}
		if (x == 2)
		{
			dver1.transform.localPosition = Vector3.Lerp(dver1.transform.localPosition, new Vector3(0.35f, dver1.transform.localPosition.y, dver1.transform.localPosition.z), Time.deltaTime * 2f);
			dver2.transform.localPosition = Vector3.Lerp(dver2.transform.localPosition, new Vector3(-0.35f, dver2.transform.localPosition.y, dver2.transform.localPosition.z), Time.deltaTime * 2f);
		}
		if (x == 3)
		{
			if (!(pl.transform.position.x < 13.3f) || !(pl.transform.position.z > 7.48f) || !(pl.transform.position.x > 11.76f) || !(pl.transform.position.z < 8.9f))
			{
				pl.transform.position = new Vector3(12.6f, 4.5f, 8.25f);
			}
			dver1.transform.localPosition = Vector3.Lerp(dver1.transform.localPosition, new Vector3(0f, dver1.transform.localPosition.y, dver1.transform.localPosition.z), Time.deltaTime * 2f);
			dver2.transform.localPosition = Vector3.Lerp(dver2.transform.localPosition, new Vector3(0f, dver2.transform.localPosition.y, dver2.transform.localPosition.z), Time.deltaTime * 2f);
			if (dver1.transform.localPosition.x < 0.002f && dver2.transform.localPosition.x > -0.002f)
			{
				x = 4;
				dver2.transform.localPosition = new Vector3(-0.001f, dver2.transform.localPosition.y, dver2.transform.localPosition.z);
				dver1.transform.localPosition = new Vector3(0.001f, dver1.transform.localPosition.y, dver1.transform.localPosition.z);
				col.SetActive(value: true);
				l8.SetActive(value: false);
				zvyk.GetComponent<AudioSource>().clip = nach;
				zvyk.GetComponent<AudioSource>().Play();
			}
		}
		if (x == 4)
		{
			base.transform.position -= new Vector3(0f, Time.deltaTime, 0f);
			pl.transform.position = new Vector3(pl.transform.position.x, base.transform.position.y + 0.8f, pl.transform.position.z);
			if (base.transform.position.y < -3f)
			{
				base.transform.position = new Vector3(base.transform.position.x, -3f, base.transform.position.z);
				x = 5;
				cam.GetComponent<cam>().dist = 1.5f;
				l1.SetActive(value: true);
				lb.SetActive(value: true);
				zvyk.GetComponent<AudioSource>().Stop();
				zvyk.GetComponent<AudioSource>().PlayOneShot(kon);
				darkrrom.SetActive(value: false);
			}
		}
		if (x == 5)
		{
			timer += Time.deltaTime;
			dver1.transform.localPosition = Vector3.Lerp(dver1.transform.localPosition, new Vector3(0.3f, dver1.transform.localPosition.y, dver1.transform.localPosition.z), Time.deltaTime * 2f);
			dver2.transform.localPosition = Vector3.Lerp(dver2.transform.localPosition, new Vector3(-0.3f, dver2.transform.localPosition.y, dver2.transform.localPosition.z), Time.deltaTime * 2f);
			if (timer > 8f)
			{
				x = 6;
				zvyk.GetComponent<AudioSource>().PlayOneShot(aud);
			}
		}
		if (x == 6)
		{
			base.transform.position -= new Vector3(0f, Time.deltaTime * 3f, 0f);
			pl.transform.position = new Vector3(pl.transform.position.x, base.transform.position.y + 0.8f, pl.transform.position.z);
			if (base.transform.position.y < -4.73f)
			{
				base.transform.position = new Vector3(base.transform.position.x, -4.73f, base.transform.position.z);
				potolok.SetActive(value: true);
				l1.SetActive(value: false);
				misc.SetActive(value: true);
				x = 8;
			}
		}
		if (x == 8 && pl.transform.position.x > 14.75f)
		{
			x = 9;
			AudioSource.PlayClipAtPoint(sw, base.transform.position - Vector3.forward * 4f);
			timer = 0f;
		}
		if (x == 9)
		{
			if (timer >= 0f)
			{
				timer += Time.deltaTime;
			}
			if (timer > 0.35f)
			{
				zvyk.GetComponent<AudioSource>().PlayOneShot(kon);
				zvyk.GetComponent<AudioSource>().PlayOneShot(power);
				timer = -10f;
			}
			dver1.transform.localPosition = Vector3.Lerp(dver1.transform.localPosition, new Vector3(0f, dver1.transform.localPosition.y, dver1.transform.localPosition.z), Time.deltaTime * 5f);
			dver2.transform.localPosition = Vector3.Lerp(dver2.transform.localPosition, new Vector3(0f, dver2.transform.localPosition.y, dver2.transform.localPosition.z), Time.deltaTime * 5f);
			if (dver1.transform.localPosition.x < 0.01f && dver2.transform.localPosition.x > -0.01f)
			{
				x = 10;
				l.SetActive(value: false);
				lv.SetActive(value: true);
				dver2.transform.localPosition = new Vector3(0f, dver2.transform.localPosition.y, dver2.transform.localPosition.z);
				dver1.transform.localPosition = new Vector3(0f, dver1.transform.localPosition.y, dver1.transform.localPosition.z);
			}
		}
		if (x == 20)
		{
			zvyk.transform.position -= new Vector3(0f, Time.deltaTime * 0.7f, 0f);
			if (zvyk.transform.position.y < -4.73f)
			{
				zvyk.transform.position = new Vector3(zvyk.transform.position.x, -4.73f, zvyk.transform.position.z);
				zvyk.GetComponent<AudioSource>().Stop();
				zvyk.GetComponent<AudioSource>().PlayOneShot(kon);
				x = 21;
				l.SetActive(value: true);
			}
			if (zvyk.transform.position.y < 3f && poc2.active)
			{
				poc2.SetActive(value: false);
				poc3.SetActive(value: true);
				pl.GetComponent<pl>().cam.GetComponent<tryaska>().enabled = true;
			}
		}
		if (x == 21)
		{
			dver1.transform.localPosition = Vector3.Lerp(dver1.transform.localPosition, new Vector3(0.35f, dver1.transform.localPosition.y, dver1.transform.localPosition.z), Time.deltaTime * 2f);
			dver2.transform.localPosition = Vector3.Lerp(dver2.transform.localPosition, new Vector3(-0.35f, dver2.transform.localPosition.y, dver2.transform.localPosition.z), Time.deltaTime * 2f);
		}
		if (x == 22)
		{
			dver1.transform.localPosition = Vector3.Lerp(dver1.transform.localPosition, new Vector3(0f, dver1.transform.localPosition.y, dver1.transform.localPosition.z), Time.deltaTime * 2f);
			dver2.transform.localPosition = Vector3.Lerp(dver2.transform.localPosition, new Vector3(0f, dver2.transform.localPosition.y, dver2.transform.localPosition.z), Time.deltaTime * 2f);
		}
		if (x == 23)
		{
			vol.weight += Time.deltaTime * 0.5f;
			konnad.SetActive(value: true);
		}
	}

	public void a()
	{
		if (x == 0)
		{
			zvyk.GetComponent<AudioSource>().enabled = true;
			x = 1;
		}
		if (x == 2)
		{
			x = 3;
		}
		if (x == 10)
		{
			zvyk.transform.position = new Vector3(base.transform.position.x, 10f, base.transform.position.z);
			zvyk.GetComponent<AudioSource>().Play();
			zvyk.GetComponent<AudioSource>().volume = 0.85f;
			poc1.SetActive(value: false);
			poc2.SetActive(value: true);
			kn.GetComponent<BoxCollider>().enabled = true;
			x = 20;
			cam.GetComponent<cam>().dist = 0.7f;
		}
		if (x == 21)
		{
			StartCoroutine(end());
			x = 22;
		}
	}

	private IEnumerator end()
	{
		yield return new WaitForSeconds(3f);
		pl.GetComponent<pl>().cam.GetComponent<tryaska>().enabled = false;
		poc3.SetActive(value: false);
		x = 23;
	}
}
