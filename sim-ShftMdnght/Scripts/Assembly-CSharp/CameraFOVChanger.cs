using UnityEngine;

public class CameraFOVChanger : MonoBehaviour
{
	private void OnEnable()
	{
		GetComponent<Camera>().fieldOfView = PlayerPrefs.GetFloat("FOV", 70f);
	}
}
