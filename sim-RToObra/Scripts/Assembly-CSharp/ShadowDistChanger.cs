using UnityEngine;

public class ShadowDistChanger : MonoBehaviour
{
	public float shadowDistance;

	private float defaultShadowDistance = -1f;

	private void OnEnable()
	{
		if (defaultShadowDistance < 0f)
		{
			defaultShadowDistance = QualitySettings.shadowDistance;
		}
		QualitySettings.shadowDistance = shadowDistance;
	}

	private void OnDisable()
	{
		QualitySettings.shadowDistance = defaultShadowDistance;
	}
}
