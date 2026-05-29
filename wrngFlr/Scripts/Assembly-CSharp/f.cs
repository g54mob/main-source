using UnityEngine;

public class f : MonoBehaviour
{
	public int x;

	private bool a;

	private bool trig;

	public GameObject[] nad;

	public GameObject fl;

	public GameObject f2;

	private void Update()
	{
		if (!trig)
		{
			return;
		}
		if (!fl.GetComponent<Light>().enabled)
		{
			a = true;
		}
		else if (x < 4 && a)
		{
			nad[x].SetActive(value: true);
			a = false;
			x++;
			if (x == 4)
			{
				f2.SetActive(value: true);
				base.gameObject.SetActive(value: false);
			}
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			trig = true;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			trig = false;
		}
	}
}
