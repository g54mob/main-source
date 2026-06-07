using UnityEngine;

public class golova : MonoBehaviour
{
	public GameObject pl;

	public GameObject plcam;

	public GameObject campos;

	public GameObject cam;

	public GameObject glaz;

	public bool A;

	private int x;

	private void Update()
	{
		if (x > 0)
		{
			x--;
		}
		if (A)
		{
			cam.transform.position = Vector3.Lerp(cam.transform.position, campos.transform.position, Time.deltaTime * 2f);
			cam.transform.eulerAngles = new Vector3(Mathf.LerpAngle(cam.transform.eulerAngles.x, campos.transform.eulerAngles.x, Time.deltaTime * 1f), Mathf.LerpAngle(cam.transform.eulerAngles.y, campos.transform.eulerAngles.y, Time.deltaTime * 1f), Mathf.LerpAngle(cam.transform.eulerAngles.z, campos.transform.eulerAngles.z, Time.deltaTime * 1f));
			if (Input.GetButtonDown("use") && x <= 0)
			{
				x = 3;
				plcam.transform.position = cam.transform.position;
				pl.SetActive(value: true);
				cam.SetActive(value: false);
				A = false;
				glaz.GetComponent<lookat>().pl = plcam;
			}
		}
	}

	private void use()
	{
		pl.SetActive(value: false);
		cam.transform.position = plcam.transform.position;
		cam.transform.eulerAngles = plcam.transform.eulerAngles;
		cam.SetActive(value: true);
		x = 3;
		A = true;
		glaz.GetComponent<lookat>().pl = cam;
	}
}
