using UnityEngine;
using UnityEngine.AI;

public class wfkill : MonoBehaviour
{
	public GameObject pl;

	public GameObject fl;

	public GameObject cam;

	public GameObject head;

	public GameObject cam2;

	public GameObject amb;

	private bool a;

	private void Update()
	{
		if (!a)
		{
			if (Physics.Raycast(new Ray(base.transform.position, pl.transform.position - base.transform.position), out var hitInfo, 1f) && hitInfo.transform.tag == "Player")
			{
				base.gameObject.GetComponent<NavMeshAgent>().enabled = false;
				base.gameObject.GetComponent<nm>().enabled = false;
				base.transform.LookAt(new Vector3(pl.transform.position.x, base.transform.position.y, pl.transform.position.z));
				pl.SetActive(value: false);
				cam.SetActive(value: true);
				base.gameObject.GetComponent<Animator>().SetTrigger("kill");
				a = true;
				Invoke("kill", 0.6f);
			}
		}
		else
		{
			cam.transform.LookAt(head.transform.position);
		}
	}

	public void kill()
	{
		cam2.SetActive(value: true);
		amb.SetActive(value: false);
		Object.Destroy(pl);
		Object.Destroy(fl);
		Object.Destroy(base.gameObject);
	}
}
