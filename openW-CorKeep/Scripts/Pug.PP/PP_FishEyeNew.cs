using System;
using UnityEngine.Rendering.PostProcessing;

[Serializable]
[PostProcess(typeof(PP_FishEyeNewRenderer), PostProcessEvent.AfterStack, "Custom/PP_FishEyeNew", true)]
public sealed class PP_FishEyeNew : PostProcessEffectSettings
{
	public FloatParameter _scale = new FloatParameter
	{
		value = 1.2f
	};

	public FloatParameter playerX = new FloatParameter
	{
		value = 0f
	};

	public FloatParameter playerY = new FloatParameter
	{
		value = 0f
	};

	public float scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale.value = value;
			enabled.value = !((double)_scale.value < 0.0001);
		}
	}

	public void UpdateShaderValues(float _centerX, float _centerY)
	{
		playerX.value = _centerX;
		playerY.value = _centerY;
	}
}
