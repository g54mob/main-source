using UnityEngine;

[ExecuteInEditMode]
public class PP_MaskEye : PP_Base
{
	private Texture2D _previousMaskTexture;

	public Texture2D maskTexture;

	private static readonly int SHADER_VARIABLE_ID_PLAYER_X = Shader.PropertyToID("_PlayerX");

	private static readonly int SHADER_VARIABLE_ID_PLAYER_Y = Shader.PropertyToID("_PlayerY");

	private static readonly int SHADER_VARIABLE_ID_SCALE = Shader.PropertyToID("_Scale");

	private static readonly int SHADER_VARIABLE_ID_MASK_TEX = Shader.PropertyToID("_MaskTex");

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
		}
	}

	private float AdjustedScaleValue()
	{
		return 0.1f / Mathf.Clamp(Mathf.Pow(scale, 2f), 0f, 1f);
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if ((double)scale >= 1.0 - (double)Mathf.Epsilon)
		{
			Graphics.Blit(source, destination);
			return;
		}
		if (maskTexture != _previousMaskTexture)
		{
			ReuploadMaskTexture();
		}
		base.material.SetFloat(SHADER_VARIABLE_ID_SCALE, AdjustedScaleValue());
		Graphics.Blit(source, destination, base.material);
	}

	public void ReuploadMaskTexture()
	{
		_previousMaskTexture = maskTexture;
		base.material.SetTexture(SHADER_VARIABLE_ID_MASK_TEX, maskTexture);
	}

	public void UpdateShaderValues(float _centerX, float _centerY)
	{
		base.material.SetFloat(SHADER_VARIABLE_ID_PLAYER_X, _centerX);
		base.material.SetFloat(SHADER_VARIABLE_ID_PLAYER_Y, _centerY);
	}
}
