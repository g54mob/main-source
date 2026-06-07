using UnityEngine;

public class WhiteSpriteLight : SpriteLight
{
	[Header("Spotlight")]
	public bool overrideSpotAngle;

	public float spotAngle;

	private readonly SpriteLights.LightData STREET_LAMP_LIGHT = new SpriteLights.LightData
	{
		frontColor = new Color(0.91f, 0.93f, 0.88f),
		size = 0.5f,
		brightness = 1f,
		rotation = Quaternion.Euler(-90f, 0f, 0f)
	};

	public override SpriteLightType LightType => SpriteLightType.WhiteSpriteLight;

	public override LightType GeneratedLightType => UnityEngine.LightType.Spot;

	public override float LightIntensity => 3f;

	public override float LightRange => 10f;

	public override Color LightColor => new Color(0.91f, 0.93f, 0.88f);

	public override void FillLights(LightBakeContainer container)
	{
		SpriteLights.LightData sTREET_LAMP_LIGHT = STREET_LAMP_LIGHT;
		sTREET_LAMP_LIGHT.position = base.transform.position - mergeOffset;
		container.whiteLights.Add(sTREET_LAMP_LIGHT);
	}

	protected override void SetupLight(Light light)
	{
		base.SetupLight(light);
		light.transform.rotation = Quaternion.LookRotation(Vector3.down, Vector3.forward);
		light.spotAngle = (overrideSpotAngle ? spotAngle : 100f);
	}
}
