using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
	public GameObject slids;

	public GameObject slida;

	public GameObject pl;

	public GameObject mn;

	public GameObject wf;

	public GameObject cam1;

	public GameObject cam2;

	public GameObject dt;

	public GameObject poc;

	public GameObject[] ru;

	public GameObject[] eng;

	public bool pause;

	private void Awake()
	{
		slids.GetComponent<Slider>().value = 5f / 12f;
		pl.GetComponent<pl>().sens = 2.5f;
		slida.GetComponent<Slider>().value = 1f;
		AudioListener.volume = 1f;
		paus();
	}

	private void Update()
	{
		if (Input.GetButtonDown("pause"))
		{
			paus();
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			if (!cam2.active)
			{
				poc.SetActive(value: true);
				Invoke("poc2", 5f);
				cam1.GetComponent<Camera>().enabled = false;
				cam2.SetActive(value: true);
			}
			else
			{
				poc.SetActive(value: false);
				cam1.GetComponent<Camera>().enabled = true;
				cam2.SetActive(value: false);
			}
		}
	}

	public void s(Slider a)
	{
		pl.GetComponent<pl>().sens = a.value * 6f;
	}

	public void a(Slider a)
	{
		AudioListener.volume = a.value;
	}

	public void cs(Toggle a)
	{
		pl.GetComponent<pl>().shake = a.isOn;
	}

	public void d(Toggle a)
	{
		dt.SetActive(a.isOn);
	}

	public void ex()
	{
		Application.Quit();
	}

	public void lang(Slider a)
	{
		if (a.value != 0f && a.value != 1f)
		{
			if (a.value > 0.3f)
			{
				a.value = 1f;
			}
			else if (a.value < 0.7f)
			{
				a.value = 0f;
			}
		}
		bool flag = false;
		if (a.value == 1f)
		{
			flag = true;
		}
		for (int i = 0; i < eng.Length; i++)
		{
			eng[i].SetActive(!flag);
			ru[i].SetActive(flag);
		}
	}

	public void paus()
	{
		if (pause)
		{
			pause = false;
			mn.SetActive(value: false);
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			wf.SetActive(value: false);
			StartCoroutine(cor());
			pl.GetComponent<pl>().shagi.GetComponent<AudioSource>().enabled = true;
		}
		else
		{
			pause = true;
			mn.SetActive(value: true);
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			wf.SetActive(value: true);
			pl.GetComponent<pl>().shagi.GetComponent<AudioSource>().enabled = false;
		}
	}

	private IEnumerator cor()
	{
		yield return new WaitForSeconds(0.2f);
		pl.GetComponent<pl>().enabled = true;
	}

	public void poc2()
	{
		poc.SetActive(value: false);
	}
}
