using UnityEngine;

[ExecuteInEditMode]
public class PP_FishEye : PP_Base
{
	private static readonly int SHADER_VARIABLE_ID_PLAYER_X = Shader.PropertyToID("_PlayerX");

	private static readonly int SHADER_VARIABLE_ID_PLAYER_Y = Shader.PropertyToID("_PlayerY");

	private static readonly int SHADER_VARIABLE_ID_SCALE = Shader.PropertyToID("_Scale");

	private float _scale;

	public float scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale = value;
			base.enabled = !((double)_scale < 0.0001);
		}
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (scale < Mathf.Epsilon || scale > 1f - Mathf.Epsilon)
		{
			Graphics.Blit(source, destination);
			return;
		}
		base.material.SetFloat(SHADER_VARIABLE_ID_SCALE, scale);
		Graphics.Blit(source, destination, base.material);
	}

	public void UpdateShaderValues(float _centerX, float _centerY)
	{
		base.material.SetFloat(SHADER_VARIABLE_ID_PLAYER_X, _centerX);
		base.material.SetFloat(SHADER_VARIABLE_ID_PLAYER_Y, _centerY);
	}
}
