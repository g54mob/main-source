using UnityEngine;

public class wfzap : MonoBehaviour
{
	public GameObject pl;

	public GameObject caman;

	public GameObject fl;

	public GameObject kod;

	public Transform cam;

	public Transform pos;

	public Transform pos2;

	public Transform pos3;

	public Transform la;

	private int y;

	private bool on;

	private void Update()
	{
		if (y > 0)
		{
			y--;
		}
		if (on)
		{
			cam.position = Vector3.Lerp(cam.position, pos.position, Time.deltaTime);
			cam.eulerAngles = new Vector3(Mathf.LerpAngle(cam.eulerAngles.x, pos.eulerAngles.x, Time.deltaTime * 5f), Mathf.LerpAngle(cam.eulerAngles.y, pos.eulerAngles.y, Time.deltaTime * 5f), Mathf.LerpAngle(cam.eulerAngles.z, pos.eulerAngles.z, Time.deltaTime * 5f));
			fl.transform.position = Vector3.Lerp(fl.transform.position, pos3.position, Time.deltaTime * 1.6f);
			pos2.position = fl.transform.position;
			pos2.LookAt(la.position);
			fl.transform.eulerAngles = new Vector3(Mathf.LerpAngle(fl.transform.eulerAngles.x, pos2.eulerAngles.x, Time.deltaTime * 7f), Mathf.LerpAngle(fl.transform.eulerAngles.y, pos2.eulerAngles.y, Time.deltaTime * 7f), Mathf.LerpAngle(fl.transform.eulerAngles.z, pos2.eulerAngles.z, Time.deltaTime * 7f));
			if (Input.GetButtonDown("use") && y <= 0)
			{
				ext();
			}
		}
	}

	public void use()
	{
		if (y <= 0 && fl.active)
		{
			ext();
			kod.SetActive(value: true);
		}
	}

	private void ext()
	{
		on = !on;
		if (on)
		{
			cam.SetParent(base.transform);
		}
		else
		{
			cam.SetParent(pl.transform);
		}
		pl.SetActive(!on);
		caman.GetComponent<Animator>().enabled = !on;
		base.gameObject.GetComponent<Animator>().SetBool("on", on);
		fl.GetComponent<fl>().enabled = !on;
		y = 3;
	}
}
