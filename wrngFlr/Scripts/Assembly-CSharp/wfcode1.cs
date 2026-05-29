using UnityEngine;

public class wfcode1 : MonoBehaviour
{
	public GameObject pl;

	public GameObject aud;

	public GameObject ys;

	public GameObject stuki;

	public GameObject vib;

	public GameObject shagi;

	public GameObject dver;

	public GameObject col;

	public GameObject du;

	public GameObject amb;

	public GameObject fx;

	public float t;

	public float tm;

	public int on;

	private void Update()
	{
		if (on == 0 && pl.transform.position.x > 22.8f)
		{
			if (!aud.active)
			{
				aud.SetActive(value: true);
				amb.SetActive(value: false);
			}
			if (pl.transform.position.z < 6.5f)
			{
				on = 1;
				stuki.SetActive(value: true);
				ys.SetActive(value: true);
			}
		}
		if (on == 1 && pl.transform.position.x < 22f)
		{
			col.SetActive(value: true);
			on = 2;
		}
		if (on == 2 && !ys.GetComponent<AudioSource>().isPlaying)
		{
			ys.SetActive(value: false);
			stuki.SetActive(value: false);
			shagi.SetActive(value: true);
			vib.SetActive(value: true);
			dver.SetActive(value: false);
			on = 3;
		}
		if (on != 3)
		{
			return;
		}
		shagi.transform.position -= new Vector3(0f, 0f, Time.deltaTime);
		if (shagi.transform.position.z < 5.5f)
		{
			if (pl.transform.position.x < 19.1f)
			{
				du.GetComponent<dver>().use();
			}
			fx.SetActive(value: true);
			Object.Destroy(base.gameObject);
		}
	}
}
