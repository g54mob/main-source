using UnityEngine;

public class DisableCameraShadowRendering : MonoBehaviour
{
	private ShadowQuality defaultSetting;

	private void Start()
	{
		if (base.gameObject.GetComponent<Camera>() == null)
		{
			Debug.Log("No Camera Found");
		}
	}

	private void OnPreRender()
	{
		defaultSetting = QualitySettings.shadows;
		QualitySettings.shadows = ShadowQuality.Disable;
	}

	private void OnPostRender()
	{
		QualitySettings.shadows = defaultSetting;
	}
}
