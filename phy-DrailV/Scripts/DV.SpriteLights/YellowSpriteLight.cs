using UnityEngine;

public class YellowSpriteLight : SpriteLight
{
	private readonly SpriteLights.LightData YELLOW_LIGHT = new SpriteLights.LightData
	{
		frontColor = Color.white,
		size = 0.5f,
		brightness = 1f,
		rotation = Quaternion.Euler(-90f, 0f, 0f)
	};

	public override SpriteLightType LightType => SpriteLightType.YellowSpriteLight;

	public override LightType GeneratedLightType => UnityEngine.LightType.Point;

	public override float LightIntensity => 1f;

	public override float LightRange => 10f;

	public override Color LightColor => new Color(1f, 0.8f, 0.1f);

	public override void FillLights(LightBakeContainer container)
	{
		SpriteLights.LightData yELLOW_LIGHT = YELLOW_LIGHT;
		yELLOW_LIGHT.position = base.transform.position - mergeOffset;
		container.yellowLights.Add(yELLOW_LIGHT);
	}
}
