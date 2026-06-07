using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class CircadianLighting : IBlendableVisual
{
	[SerializeField]
	[FormerlySerializedAs("Light")]
	private Light _light;

	[SerializeField]
	private Gradient _color;

	[SerializeField]
	private LerpedFloat _intensity;

	[SerializeField]
	private LerpedFloat _bounceIntensity;

	[SerializeField]
	private LerpedFloat _range;

	public void Blend(float blendProgress)
	{
		_light.color = _color.Evaluate(blendProgress);
		_light.intensity = _intensity.Lerp(blendProgress);
		_light.bounceIntensity = _bounceIntensity.Lerp(blendProgress);
		_light.range = _range.Lerp(blendProgress);
	}
}
