using UnityEngine;

public class SplashScreenCheck : MonoBehaviour
{
	public GameObject disabledCamera;

	private void Awake()
	{
		if (Camera.main == null)
		{
			disabledCamera.SetActive(value: true);
			Object.Destroy(this);
		}
	}
}
