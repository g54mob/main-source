using System;
using UnityEngine;

[Serializable]
internal class CircadianEnvironmentColors : IBlendableVisual
{
	[SerializeField]
	[GradientUsage(true)]
	private Gradient _skyColor;

	[SerializeField]
	[GradientUsage(true)]
	private Gradient _equatorColor;

	[SerializeField]
	[GradientUsage(true)]
	private Gradient _groundColor;

	public void Blend(float blendProgress)
	{
		RenderSettings.ambientSkyColor = _skyColor.Evaluate(blendProgress);
		RenderSettings.ambientEquatorColor = _equatorColor.Evaluate(blendProgress);
		RenderSettings.ambientGroundColor = _groundColor.Evaluate(blendProgress);
	}
}
