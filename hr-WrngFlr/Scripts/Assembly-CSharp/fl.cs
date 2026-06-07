using UnityEngine;

public class fl : MonoBehaviour
{
	public Transform pos;

	public Transform cam;

	public Animator an;

	public GameObject f;

	public GameObject f2;

	public GameObject gg;

	public pl pl;

	public Light fl2;

	public float plavn;

	public float fx;

	public float fy;

	public float run;

	private void Start()
	{
		an = gg.GetComponent<Animator>();
	}

	private void Update()
	{
		if (Input.GetButtonDown("flashlight"))
		{
			F();
		}
		if (gg.active)
		{
			base.transform.position = pos.position;
			fy += Input.GetAxis("Mouse Y") * pl.sens * 0.3f;
			fx += Input.GetAxis("Mouse X") * pl.sens * 0.3f;
			if (an.GetInteger("walk") == 2)
			{
				run += Time.deltaTime * 50f;
			}
			else
			{
				run -= Time.deltaTime * 40f;
			}
			if (run > 28f)
			{
				run = 28f;
			}
			if (run < 0f)
			{
				run = 0f;
			}
			base.transform.eulerAngles = new Vector3(pl.MY - fy + run, pl.MX - 5f + fx);
			if (base.transform.eulerAngles.x > 60f && base.transform.eulerAngles.x < 180f)
			{
				base.transform.eulerAngles = new Vector3(60f, base.transform.eulerAngles.y, base.transform.eulerAngles.z);
				fy = 0f;
			}
		}
		else
		{
			base.transform.position = Vector3.Lerp(cam.transform.position, base.transform.position, Time.deltaTime * 5f);
			base.transform.rotation = cam.transform.rotation;
		}
	}

	private void FixedUpdate()
	{
		fy *= 0.95f;
		fx *= 0.95f;
	}

	public void F()
	{
		base.gameObject.GetComponent<AudioSource>().Play();
		if (base.gameObject.GetComponent<Light>().enabled)
		{
			base.gameObject.GetComponent<Light>().enabled = false;
			f.SetActive(value: false);
		}
		else
		{
			base.gameObject.GetComponent<Light>().enabled = true;
			f.SetActive(value: true);
		}
	}
}
