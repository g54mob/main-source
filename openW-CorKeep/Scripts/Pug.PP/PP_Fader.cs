using UnityEngine;

[ExecuteInEditMode]
public class PP_Fader : PP_Base
{
	[Range(-1f, 1f)]
	public float brightness;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (Mathf.Approximately(0f, brightness))
		{
			Graphics.Blit(source, destination);
			return;
		}
		base.material.SetFloat("_Brightness", brightness);
		Graphics.Blit(source, destination, base.material);
	}
}
