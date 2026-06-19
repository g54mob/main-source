using UnityEngine;

public class FPSSetting : MonoBehaviour
{
	private void Start()
	{
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 300;
	}
}
