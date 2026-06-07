using UnityEngine;

public class SpillWarning : MonoBehaviour
{
	public GameObject spillCam;

	private void Start()
	{
		InvokeRepeating("LookAtPlayer", 2f, 1f);
		Invoke("FindPlayer", 1f);
	}

	private void FindPlayer()
	{
	}

	private void Update()
	{
	}
}
