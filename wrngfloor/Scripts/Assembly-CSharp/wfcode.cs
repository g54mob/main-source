using UnityEngine;

public class wfcode : MonoBehaviour
{
	public GameObject pl;

	public GameObject caman;

	public GameObject fl;

	public GameObject dver;

	public Transform cam;

	public Transform pos;

	public Transform pos2;

	private int y;

	private int x;

	private float bt;

	public int[] ch;

	public GameObject[] cyl;

	public Material em;

	public Material nem;

	private bool on;

	private bool en;

	public AudioClip aud;

	public AudioClip aud2;

	private void Update()
	{
		if (y > 0)
		{
			y--;
		}
		if (!on)
		{
			return;
		}
		cam.position = Vector3.Lerp(cam.position, pos.position, Time.deltaTime);
		cam.eulerAngles = new Vector3(Mathf.LerpAngle(cam.eulerAngles.x, pos.eulerAngles.x, Time.deltaTime * 5f), Mathf.LerpAngle(cam.eulerAngles.y, pos.eulerAngles.y, Time.deltaTime * 5f), Mathf.LerpAngle(cam.eulerAngles.z, pos.eulerAngles.z, Time.deltaTime * 5f));
		fl.transform.position = Vector3.Lerp(fl.transform.position, pos2.position, Time.deltaTime * 1.6f);
		fl.transform.eulerAngles = new Vector3(Mathf.LerpAngle(fl.transform.eulerAngles.x, pos2.eulerAngles.x, Time.deltaTime * 7f), Mathf.LerpAngle(fl.transform.eulerAngles.y, pos2.eulerAngles.y, Time.deltaTime * 7f), Mathf.LerpAngle(fl.transform.eulerAngles.z, pos2.eulerAngles.z, Time.deltaTime * 7f));
		if (bt <= 0f && (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f))
		{
			if (Input.GetAxisRaw("Horizontal") != 0f)
			{
				base.gameObject.GetComponent<AudioSource>().PlayOneShot(aud);
			}
			bt = 0.15f;
			x -= (int)Input.GetAxisRaw("Vertical");
			if (x > 3)
			{
				x = 0;
			}
			if (x < 0)
			{
				x = 3;
			}
			ch[x] += (int)Input.GetAxisRaw("Horizontal");
			if (ch[x] > 9)
			{
				ch[x] = 0;
			}
			if (ch[x] < 0)
			{
				ch[x] = 9;
			}
			cyl[x].GetComponent<MeshRenderer>().material = em;
			for (int i = 0; i < cyl.Length; i++)
			{
				if (i != x)
				{
					cyl[i].GetComponent<MeshRenderer>().material = nem;
				}
			}
		}
		bt -= Time.deltaTime;
		for (int j = 0; j < cyl.Length; j++)
		{
			cyl[j].transform.localEulerAngles = new Vector3(-180f, 0f, ch[j] * 36 + 72);
		}
		if (ch[0] == 1 && ch[1] == 9 && ch[2] == 9 && ch[3] == 0)
		{
			dver.GetComponent<Rigidbody>().isKinematic = false;
			dver.GetComponent<dver>().enabled = true;
			AudioSource.PlayClipAtPoint(aud2, base.transform.position, 0.4f);
			on = false;
			ext();
			Object.Destroy(base.gameObject);
		}
		if (Input.GetButtonDown("use") && y <= 0)
		{
			for (int k = 0; k < cyl.Length; k++)
			{
				cyl[k].transform.localEulerAngles = new Vector3(-180f, 0f, ch[k] * 36 + 72);
			}
			cyl[x].GetComponent<MeshRenderer>().material = nem;
			y = 3;
			on = false;
			ext();
		}
	}

	public void use()
	{
		if (y <= 0 && fl.active)
		{
			cyl[x].GetComponent<MeshRenderer>().material = em;
			y = 3;
			on = true;
			ext();
		}
	}

	private void ext()
	{
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
	}
}
