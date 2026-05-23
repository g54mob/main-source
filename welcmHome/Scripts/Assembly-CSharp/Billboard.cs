using UnityEngine;

public class Billboard : MonoBehaviour
{
	private Transform playerCamera;

	private void Start()
	{
		playerCamera = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().GetCamera();
	}

	private void LateUpdate()
	{
		if (playerCamera != null)
		{
			base.transform.LookAt(base.transform.position + playerCamera.forward);
		}
		else
		{
			Debug.LogWarning("Player Camera is not assigned to the Billboard script!");
		}
	}
}
