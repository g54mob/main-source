using Cinemachine;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
	public CinemachineVirtualCamera fpsCamera;

	public CinemachineVirtualCamera tpsCamera;

	public bool isFPS = true;

	private void Awake()
	{
		ChangeCamera();
	}

	private void Update()
	{
	}

	private void ChangeCamera()
	{
		isFPS = !isFPS;
		if (isFPS)
		{
			fpsCamera.gameObject.SetActive(value: true);
			tpsCamera.gameObject.SetActive(value: false);
		}
		else
		{
			fpsCamera.gameObject.SetActive(value: false);
			tpsCamera.gameObject.SetActive(value: true);
		}
	}
}
