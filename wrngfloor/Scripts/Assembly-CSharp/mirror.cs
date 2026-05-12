using UnityEngine;

public class mirror : MonoBehaviour
{
	public GameObject pl;

	public GameObject pl2;

	public GameObject dver;

	public GameObject dver2;

	public GameObject rychka1;

	public GameObject rychka2;

	public GameObject fl;

	public GameObject fl2;

	private Animator an2;

	private Animator an;

	private void Start()
	{
		an = pl.GetComponent<Animator>();
		an2 = pl2.GetComponent<Animator>();
	}

	private void Update()
	{
		pl2.transform.position = new Vector3(pl.transform.position.x, pl.transform.position.y, base.transform.position.z - pl.transform.position.z + base.transform.position.z);
		pl2.transform.eulerAngles = new Vector3(0f, 0f - pl.transform.eulerAngles.y + 180f, 0f);
		an2.SetFloat("dz", an.GetFloat("dz"));
		an2.SetFloat("dx", an.GetFloat("dx"));
		an2.SetInteger("walk", an.GetInteger("walk"));
		dver2.transform.eulerAngles = new Vector3(0f, 0f - dver.transform.eulerAngles.y + 180f, 0f);
		fl2.GetComponent<Light>().intensity = fl.GetComponent<Light>().intensity;
		fl2.transform.position = new Vector3(fl.transform.position.x, fl.transform.position.y, base.transform.position.z * 2f - fl.transform.position.z);
		fl2.transform.eulerAngles = new Vector3(fl.transform.eulerAngles.x, 0f - fl.transform.eulerAngles.y + 180f);
		rychka1.transform.localEulerAngles = rychka2.transform.localEulerAngles;
	}
}
