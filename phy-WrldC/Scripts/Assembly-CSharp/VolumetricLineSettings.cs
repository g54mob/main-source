using UnityEngine;

public class VolumetricLineSettings : MonoBehaviour
{
	[SerializeField]
	private bool m_disableFieldOfViewScaling;

	private void Awake()
	{
		if (m_disableFieldOfViewScaling)
		{
			Shader.EnableKeyword("FOV_SCALING_OFF");
		}
		else
		{
			Shader.DisableKeyword("FOV_SCALING_OFF");
		}
	}
}
