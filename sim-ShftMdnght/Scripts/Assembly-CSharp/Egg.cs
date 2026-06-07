using UnityEngine;

public class Egg : MonoBehaviour
{
	public EggDiffuser eggDiffuser;

	public GameObject curGrabItemTooltip;

	public GameObject grabItemTooltip;

	private void Start()
	{
		if (PlayerPrefs.GetInt("Pulverized") != 1)
		{
			curGrabItemTooltip = Object.Instantiate(grabItemTooltip, base.transform.position, Quaternion.identity);
		}
	}

	private void FixedUpdate()
	{
		if ((bool)curGrabItemTooltip)
		{
			curGrabItemTooltip.transform.position = Vector3.Lerp(curGrabItemTooltip.transform.position, base.transform.position, Time.deltaTime * 5f);
		}
	}

	public void OnDisable()
	{
		if ((bool)curGrabItemTooltip)
		{
			Object.Destroy(curGrabItemTooltip);
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("EggDiffuser"))
		{
			eggDiffuser = other.gameObject.GetComponent<EggDiffuser>();
			other.gameObject.GetComponent<EggDiffuser>().Egg(base.gameObject);
		}
	}
}
