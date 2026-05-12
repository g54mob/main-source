using System.Collections;
using UnityEngine;

public class wfscare2 : MonoBehaviour
{
	public GameObject pl;

	public GameObject cam;

	public GameObject poc;

	public GameObject d;

	public GameObject d2;

	public GameObject lamp;

	public float timer;

	public int a;

	private void Update()
	{
		if (a == 0)
		{
			if (pl.transform.position.z < 3.5f)
			{
				poc.SetActive(value: true);
				a = 1;
				lamp.GetComponent<lampa>().x = 2;
			}
		}
		else if (a == 1)
		{
			if (Physics.Raycast(new Ray(cam.transform.position, cam.transform.forward), out var hitInfo, 100f) && hitInfo.transform.tag == "wflook")
			{
				timer += Time.deltaTime;
			}
			if (pl.transform.position.z > 4f || timer > 3f)
			{
				poc.GetComponent<Animator>().SetTrigger("A");
				a = 2;
				StartCoroutine(cor());
			}
		}
	}

	private IEnumerator cor()
	{
		yield return new WaitForSeconds(1f);
		d.SetActive(value: false);
		d2.SetActive(value: true);
		Object.Destroy(base.gameObject);
	}
}
