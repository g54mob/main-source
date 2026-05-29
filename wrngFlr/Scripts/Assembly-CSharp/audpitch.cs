using UnityEngine;

public class audpitch : MonoBehaviour
{
	public GameObject pl;

	public float x;

	private AudioSource a;

	private void Start()
	{
		a = base.gameObject.GetComponent<AudioSource>();
	}

	private void Update()
	{
		a.pitch = Vector3.Distance(pl.transform.position, base.transform.position) * x + 0.2f;
	}
}
