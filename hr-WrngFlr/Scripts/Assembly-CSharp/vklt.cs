using UnityEngine;

public class vklt : MonoBehaviour
{
	public Animator an;

	public GameObject l;

	public GameObject d;

	public GameObject vikl;

	private void Start()
	{
		vikl.transform.localEulerAngles = new Vector3(vikl.transform.localEulerAngles.x, vikl.transform.localEulerAngles.y, 17f);
	}

	public void use()
	{
		base.gameObject.GetComponent<AudioSource>().Play();
		if (vikl.transform.localEulerAngles.z == 17f)
		{
			vikl.transform.localEulerAngles = new Vector3(vikl.transform.localEulerAngles.x, vikl.transform.localEulerAngles.y, -17f);
		}
		else
		{
			vikl.transform.localEulerAngles = new Vector3(vikl.transform.localEulerAngles.x, vikl.transform.localEulerAngles.y, 17f);
		}
		l.SetActive(value: true);
	}

	private void Update()
	{
		if (l.active && d.transform.eulerAngles.y < 165f)
		{
			an.enabled = true;
			base.gameObject.GetComponent<vklt>().enabled = false;
		}
	}
}
