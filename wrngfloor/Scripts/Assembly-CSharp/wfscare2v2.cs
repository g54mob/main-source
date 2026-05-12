using UnityEngine;

public class wfscare2v2 : MonoBehaviour
{
	public GameObject pl;

	public GameObject chel;

	public GameObject fl;

	public GameObject head;

	public GameObject aud;

	public Camera cam;

	public float timer;

	private bool on;

	private void Update()
	{
		if (timer >= 1f)
		{
			pl.GetComponent<pl>().MX = 270f;
			pl.GetComponent<pl>().MY = 10f;
			fl.transform.LookAt(head.transform.position);
			fl.transform.position = fl.GetComponent<fl>().pos.position;
			if (timer > 1.1f && cam.fieldOfView > 65f)
			{
				aud.SetActive(value: true);
				cam.fieldOfView = 40f;
			}
			timer += Time.deltaTime;
			if (timer > 1.3f)
			{
				fl.GetComponent<fl>().enabled = true;
				Object.Destroy(base.gameObject);
			}
		}
		if (pl.transform.position.x > 17.5f && pl.transform.position.z < 1f && pl.transform.eulerAngles.y > 210f && pl.transform.eulerAngles.y < 330f && timer == 0f && on)
		{
			fl.GetComponent<fl>().enabled = false;
			chel.SetActive(value: true);
			timer = 1f;
		}
		if (pl.transform.position.x > 18f)
		{
			on = true;
		}
	}
}
