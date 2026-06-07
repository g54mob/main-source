using UnityEngine;

public class UniqueSpriteLight : SpriteLight
{
	private const float BRIGHTNESS_SCALE = 1f;

	private const float SIZE_SCALE = 1f;

	[Header("Unique light")]
	public Color color = Color.white;

	public float brightness = 1f;

	public float size = 0.2f;

	private readonly SpriteLights.LightData STREET_LAMP_LIGHT = new SpriteLights.LightData
	{
		frontColor = Color.white,
		size = 0.2f,
		brightness = 1f,
		rotation = Quaternion.Euler(-90f, 0f, 0f)
	};

	public override SpriteLightType LightType => SpriteLightType.UniqueSpriteLight;

	public override bool ShouldGenerateRealLight => true;

	public override LightType GeneratedLightType => UnityEngine.LightType.Point;

	public override float LightIntensity => 1f;

	public override float LightRange => 6f;

	public override Color LightColor => color;

	public override void FillLights(LightBakeContainer container)
	{
		SpriteLights.LightData sTREET_LAMP_LIGHT = STREET_LAMP_LIGHT;
		sTREET_LAMP_LIGHT.frontColor = color;
		sTREET_LAMP_LIGHT.position = base.transform.position - mergeOffset;
		sTREET_LAMP_LIGHT.brightness = brightness * 1f;
		sTREET_LAMP_LIGHT.size = size * 1f;
		container.uniqueLights.Add(sTREET_LAMP_LIGHT);
	}
}
