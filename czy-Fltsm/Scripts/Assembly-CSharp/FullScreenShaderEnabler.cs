using UnityEngine;
using UnityEngine.Rendering.Universal;

public class FullScreenShaderEnabler : MonoBehaviour
{
	[SerializeField]
	private ScriptableRendererFeature _rendererFeature;

	private void OnEnable()
	{
		if (_rendererFeature != null)
		{
			_rendererFeature.SetActive(active: true);
		}
	}

	private void OnDisable()
	{
		if (_rendererFeature != null)
		{
			_rendererFeature.SetActive(active: false);
		}
	}
}
