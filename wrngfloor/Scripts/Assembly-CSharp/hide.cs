using System.Collections;
using UnityEngine;

public class hide : MonoBehaviour
{
	public GameObject pl;

	public GameObject campl;

	public GameObject campos;

	public bool h;

	public bool cor;

	public bool t2b;

	public int x;

	private void Start()
	{
		campl = pl.GetComponent<pl>().cam;
	}

	private void Update()
	{
		if (h)
		{
			campl.transform.position = Vector3.Lerp(campl.transform.position, campos.transform.position, Time.deltaTime * 5f);
			if (cor)
			{
				campl.transform.eulerAngles = new Vector3(Mathf.LerpAngle(campl.transform.eulerAngles.x, 0f, Time.deltaTime * 2.5f), Mathf.LerpAngle(campl.transform.eulerAngles.y, 72f, Time.deltaTime * 2.5f), Mathf.LerpAngle(campl.transform.eulerAngles.z, 0f, Time.deltaTime * 2.5f));
			}
			else if (t2b)
			{
				if (Input.GetButtonDown("use") && x <= 0)
				{
					x = 3;
					cor = true;
					campos.GetComponent<Animator>().SetBool("hide", value: false);
					StartCoroutine(t());
				}
				campl.transform.eulerAngles += new Vector3(0f - Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * pl.GetComponent<pl>().sens;
				if (campl.transform.localEulerAngles.y < 260f && campl.transform.localEulerAngles.y > 180f)
				{
					campl.transform.localEulerAngles = new Vector3(campl.transform.localEulerAngles.x, 260f, campl.transform.localEulerAngles.z);
				}
				if (campl.transform.localEulerAngles.y > 10f && campl.transform.localEulerAngles.y <= 180f)
				{
					campl.transform.localEulerAngles = new Vector3(campl.transform.localEulerAngles.x, 10f, campl.transform.localEulerAngles.z);
				}
				if (campl.transform.localEulerAngles.x > 20f && campl.transform.localEulerAngles.x < 180f)
				{
					campl.transform.localEulerAngles = new Vector3(20f, campl.transform.localEulerAngles.y, campl.transform.localEulerAngles.z);
				}
				if (campl.transform.localEulerAngles.x < 340f && campl.transform.localEulerAngles.x > 180f)
				{
					campl.transform.localEulerAngles = new Vector3(-20f, campl.transform.localEulerAngles.y, campl.transform.localEulerAngles.z);
				}
			}
			else
			{
				campl.transform.eulerAngles = new Vector3(Mathf.LerpAngle(campl.transform.eulerAngles.x, campos.transform.eulerAngles.x, Time.deltaTime * 8f), Mathf.LerpAngle(campl.transform.eulerAngles.y, campos.transform.eulerAngles.y, Time.deltaTime * 8f), Mathf.LerpAngle(campl.transform.eulerAngles.z, campos.transform.eulerAngles.z, Time.deltaTime * 8f));
			}
		}
		if (x > 0)
		{
			x--;
		}
	}

	private void use()
	{
		if (x <= 0)
		{
			x = 3;
			campl.transform.SetParent(base.transform);
			campos.SetActive(value: true);
			campos.GetComponent<Animator>().SetBool("hide", value: true);
			pl.SetActive(value: false);
			h = true;
			pl.GetComponent<pl>().camm.GetComponent<Animator>().enabled = false;
			pl.GetComponent<pl>().camm.GetComponent<cam>().enabled = false;
			StartCoroutine(t2());
		}
	}

	public IEnumerator t2()
	{
		yield return new WaitForSeconds(2.8f);
		t2b = true;
	}

	public IEnumerator t()
	{
		yield return new WaitForSeconds(2.2f);
		x = 3;
		h = false;
		cor = false;
		campos.SetActive(value: false);
		pl.SetActive(value: true);
		pl.transform.position = new Vector3(-0.9f, 6.896f, -6f);
		pl.transform.eulerAngles = new Vector3(pl.transform.eulerAngles.x, campl.transform.eulerAngles.y);
		campl.transform.SetParent(pl.transform);
		pl.GetComponent<pl>().MX = 72f;
		pl.GetComponent<pl>().MY = 0f;
		pl.GetComponent<pl>().MZ = 0f;
		pl.GetComponent<pl>().camm.GetComponent<Animator>().enabled = true;
		pl.GetComponent<pl>().camm.GetComponent<cam>().enabled = true;
		t2b = false;
	}
}
