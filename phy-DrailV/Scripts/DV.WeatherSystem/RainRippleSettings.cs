using UnityEngine;

[CreateAssetMenu(fileName = "RainRippleSettings", menuName = "DV/Rain/Ripple Settings", order = 1)]
public class RainRippleSettings : ScriptableObject
{
	[Header("Parameters")]
	public float rippleIntensity = 5f;

	public float rippleScale = 0.4f;

	public float flowIntensity = 1f;

	public float flowScale = 1.15f;

	public float rippleTimescale = 0.3f;

	public float flowTimescale = 0.3f;

	public float albedoDarken;

	public float roughnessDecrease;

	[Header("Resources")]
	public Texture rippleTexture;

	public RenderTexture rippleRT;

	public Texture flowTexture;

	public Shader rippleNormalsShader;

	public Shader screenPassShader;
}
