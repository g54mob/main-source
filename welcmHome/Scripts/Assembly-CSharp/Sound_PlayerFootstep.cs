using FMODUnity;
using UnityEngine;

public class Sound_PlayerFootstep : MonoBehaviour
{
	public GameObject footStepEmitter;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
		{
			footStepEmitter.GetComponent<StudioEventEmitter>().Play();
		}
	}
}
