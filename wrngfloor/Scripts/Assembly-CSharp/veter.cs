using UnityEngine;

public class veter : MonoBehaviour
{
	public Transform pl;

	private AudioSource aud;

	private void Start()
	{
		aud = base.gameObject.GetComponent<AudioSource>();
	}

	private void Update()
	{
		base.transform.position = new Vector3(base.transform.position.x, base.transform.position.y, pl.position.z);
		if (Vector3.Distance(base.transform.position, new Vector3(-3.8f, 7.5f, -3f)) < 1f)
		{
			aud.pitch = 1f;
		}
		else
		{
			aud.pitch = 0.65f;
		}
	}
}
