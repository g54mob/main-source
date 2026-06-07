using UnityEngine;

public class FPS60 : MonoBehaviour
{
	private void Awake()
	{
		if (Application.isMobilePlatform)
		{
			Application.targetFrameRate = 300;
		}
	}
}
