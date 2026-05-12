using UnityEngine;

public class pl : MonoBehaviour
{
	public GameObject cam;

	public GameObject camm;

	public GameObject gg;

	public GameObject shagi;

	private Vector3 d;

	public bool shake;

	public float sens;

	public float plavn;

	public float spead;

	public float MX;

	public float MY;

	public float MZ;

	public float shagitimer;

	private Animator cammanim;

	private Animator gganim;

	private Camera cammcam;

	private AudioSource shagiaud;

	private Rigidbody gorig;

	private void Start()
	{
		cammanim = camm.GetComponent<Animator>();
		gganim = gg.GetComponent<Animator>();
		cammcam = camm.GetComponent<Camera>();
		shagiaud = shagi.GetComponent<AudioSource>();
		gorig = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.Space))
		{
			Application.targetFrameRate = 15;
		}
		else
		{
			Application.targetFrameRate = 100;
		}
		shagitimer -= Time.deltaTime * 2f;
		d = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")).normalized;
		if (d == Vector3.zero)
		{
			cammanim.SetInteger("walk", 0);
			cammanim.speed = 1f;
			gganim.SetInteger("walk", 0);
			gg.transform.localPosition = Vector3.Lerp(gg.transform.localPosition, new Vector3(0f, -0.876f, -0.15f), Time.deltaTime * 10f);
		}
		else
		{
			shagitimer = 1f;
			if (Input.GetButton("run") && d.z > 0f)
			{
				cammanim.SetInteger("walk", 1);
				cammanim.speed = 2f;
				gganim.SetInteger("walk", 2);
				gg.transform.localPosition = Vector3.Lerp(gg.transform.localPosition, new Vector3(0f, -0.876f, -0.4f), Time.deltaTime * 10f);
				shagiaud.pitch = 1.4f;
				spead = 15f;
			}
			else
			{
				cammanim.SetInteger("walk", 1);
				cammanim.speed = 1f;
				gganim.SetInteger("walk", 1);
				gganim.SetFloat("dx", Input.GetAxis("Horizontal"));
				gganim.SetFloat("dz", Input.GetAxis("Vertical"));
				gg.transform.localPosition = Vector3.Lerp(gg.transform.localPosition, new Vector3(0f, -0.876f, -0.25f), Time.deltaTime * 10f);
				shagiaud.pitch = 0.85f;
				spead = 6f;
			}
		}
		shagiaud.volume = shagitimer;
		d = base.transform.TransformDirection(d);
		gorig.AddForce(d * spead * Time.deltaTime * 50f);
		MX += Input.GetAxis("Mouse X") * sens;
		MY -= Input.GetAxis("Mouse Y") * sens;
		if (MY > 85f)
		{
			MY = 85f;
		}
		else if (MY < -85f)
		{
			MY = -85f;
		}
		base.transform.localEulerAngles = new Vector3(0f, Mathf.LerpAngle(base.transform.localEulerAngles.y, MX, Time.deltaTime * plavn), 0f);
		MZ -= Input.GetAxis("Mouse X") * sens;
		if (MZ > 7f)
		{
			MZ = 7f;
		}
		else if (MZ < -7f)
		{
			MZ = -7f;
		}
		cam.transform.localEulerAngles = new Vector3(Mathf.LerpAngle(cam.transform.localEulerAngles.x, MY, Time.deltaTime * plavn), 0f, Mathf.LerpAngle(cam.transform.localEulerAngles.z, MZ, Time.deltaTime * 5f));
		cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, new Vector3(0f, 0.68f, 0.1f), Time.deltaTime * 3f);
		MZ += (0f - MZ) * Time.deltaTime * 5f;
		if (Input.GetButton("look"))
		{
			if (cammcam.fieldOfView > 30f)
			{
				cammcam.fieldOfView -= Time.deltaTime * 1.7f * (cammcam.fieldOfView - 30f);
			}
			else
			{
				cammcam.fieldOfView = 20f;
			}
		}
		else if (cammcam.fieldOfView < 70f)
		{
			cammcam.fieldOfView += Time.deltaTime * 1.7f * (500f / (cammcam.fieldOfView - 20f));
		}
		else
		{
			cammcam.fieldOfView = 70f;
		}
		if (!shake)
		{
			cam.transform.localEulerAngles = new Vector3(MY, 0f, 0f);
			base.transform.localEulerAngles = new Vector3(0f, MX, 0f);
			cammanim.SetInteger("walk", 2);
			camm.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
			camm.transform.localPosition = new Vector3(0f, 0f, 0f);
		}
	}
}
