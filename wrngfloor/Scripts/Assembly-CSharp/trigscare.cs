using System.Collections;
using UnityEngine;

public class trigscare : MonoBehaviour
{
	public int x;

	public GameObject chel;

	public GameObject v;

	public GameObject c;

	public GameObject l;

	public GameObject s;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && v.GetComponent<vkl>().on)
		{
			if (x == 0)
			{
				x = 1;
				v.GetComponent<vkl>().use();
				c.GetComponent<cam>().dist = 0.6f;
				base.transform.localPosition = new Vector3(-1.7f, -2.02f, 2.56f);
				base.gameObject.GetComponent<AudioSource>().Play();
				s.SetActive(value: false);
			}
			else
			{
				base.gameObject.GetComponent<BoxCollider>().enabled = false;
				c.GetComponent<cam>().dist = 1.2f;
				chel.GetComponent<Animator>().enabled = true;
				l.SetActive(value: true);
				StartCoroutine(fov());
			}
		}
	}

	private void Update()
	{
		if (x == 1 && v.GetComponent<vkl>().on)
		{
			s.SetActive(value: true);
		}
	}

	private IEnumerator fov()
	{
		yield return new WaitForSeconds(0.1f);
		c.GetComponent<Camera>().fieldOfView = 50f;
	}
}
