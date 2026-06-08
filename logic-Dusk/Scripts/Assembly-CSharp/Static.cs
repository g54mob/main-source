using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/Cale/Static")]
public class Static : ImageEffectBase
{
	public Texture staticMap;

	public float strength = 0.1f;

	public float sample;

	public float samplePerSecond;

	public float y;

	public float yPerSecond;

	public float StrengthFactor { get; set; }

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		if (StrengthFactor != 0f)
		{
			strength *= StrengthFactor;
		}
		sample += samplePerSecond * Time.deltaTime;
		y += yPerSecond * Time.deltaTime;
		base.material.SetTexture("_StaticTex", staticMap);
		base.material.SetVector("_x", new Vector4(sample, y, strength, 0f));
		Graphics.Blit(source, destination, base.material);
	}
}
