using System.Collections;
using UnityEngine;

public class vkl : MonoBehaviour
{
	public int t;

	public float t2;

	public bool on;

	public GameObject vikl;

	public GameObject[] ind;

	public GameObject[] noind;

	private void Start()
	{
		StartCoroutine(m());
		vikl.transform.localEulerAngles = new Vector3(vikl.transform.localEulerAngles.x, vikl.transform.localEulerAngles.y, 17f);
	}

	public void use()
	{
		base.gameObject.GetComponent<AudioSource>().Play();
		if (on)
		{
			on = false;
			for (int i = 0; i < ind.Length; i++)
			{
				ind[i].SetActive(value: false);
				noind[i].SetActive(value: true);
			}
			vikl.transform.localEulerAngles = new Vector3(vikl.transform.localEulerAngles.x, vikl.transform.localEulerAngles.y, 17f);
		}
		else
		{
			on = true;
			for (int j = 0; j < ind.Length; j++)
			{
				ind[j].SetActive(value: true);
				noind[j].SetActive(value: false);
			}
			vikl.transform.localEulerAngles = new Vector3(vikl.transform.localEulerAngles.x, vikl.transform.localEulerAngles.y, -17f);
		}
	}

	private IEnumerator m()
	{
		yield return new WaitForSeconds(t);
		StartCoroutine(v());
		t = Random.Range(1, 20);
		if (on)
		{
			for (int i = 0; i < ind.Length; i++)
			{
				ind[i].SetActive(value: false);
				noind[i].SetActive(value: true);
			}
			t2 = Random.RandomRange(0.02f, 0.2f);
		}
	}

	private IEnumerator v()
	{
		yield return new WaitForSeconds(t2);
		StartCoroutine(m());
		if (on)
		{
			for (int i = 0; i < ind.Length; i++)
			{
				ind[i].SetActive(value: true);
				noind[i].SetActive(value: false);
			}
		}
	}
}
