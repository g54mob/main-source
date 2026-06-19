using UnityEngine;

[ExecuteInEditMode]
public class PP_Brightness : PP_Base
{
	public static readonly int SHADER_VARIABLE_ID_BRIGHTNESS = Shader.PropertyToID("_Brightness");

	[Range(0f, 1f)]
	public float brightness;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (Mathf.Approximately(1f, brightness))
		{
			Graphics.Blit(source, destination);
			return;
		}
		base.material.SetFloat(SHADER_VARIABLE_ID_BRIGHTNESS, brightness);
		Graphics.Blit(source, destination, base.material);
	}
}
