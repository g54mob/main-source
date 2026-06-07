using UnityEngine;

public class GammaSaturation : MonoBehaviour
{
	[Range(0f, 1f)]
	public float Gamma = 0.5f;

	[Range(0f, 5f)]
	public float Saturation = 1f;

	private Material _gammaSat;

	public void CheckResources()
	{
		if (_gammaSat == null)
		{
			_gammaSat = new Material(Shader.Find("Hidden/GammaSaturation"));
			_gammaSat.hideFlags = HideFlags.DontSave;
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		CheckResources();
		_gammaSat.SetFloat("_Gamma", Gamma);
		_gammaSat.SetFloat("_Saturation", Saturation);
		Graphics.Blit(source, destination, _gammaSat);
	}
}
