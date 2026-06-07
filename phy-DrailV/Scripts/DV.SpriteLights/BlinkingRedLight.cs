using UnityEngine;

public class BlinkingRedLight : SpriteLight
{
	private readonly SpriteLights.LightData BLINKING_LIGHT = new SpriteLights.LightData
	{
		frontColor = Color.blue,
		size = 0.5f,
		brightness = 1f,
		rotation = Quaternion.Euler(-90f, 0f, 0f)
	};

	[Header("Strobing")]
	[Range(0f, 4f)]
	public int strobeIDStart;

	[Range(0f, 4f)]
	public int strobeIDEnd;

	public float strobeGroupID;

	public override SpriteLightType LightType => SpriteLightType.BlinkingRedLight;

	public override LightType GeneratedLightType => UnityEngine.LightType.Point;

	public override float LightIntensity => 0.5f;

	public override float LightRange => 15f;

	public override Color LightColor => new Color(1f, 0.2f, 0.2f);

	public override void FillLights(LightBakeContainer container)
	{
		for (int i = strobeIDStart; i <= strobeIDEnd; i++)
		{
			SpriteLights.LightData bLINKING_LIGHT = BLINKING_LIGHT;
			bLINKING_LIGHT.position = base.transform.position - mergeOffset;
			bLINKING_LIGHT.strobeID = (float)i / 5f;
			bLINKING_LIGHT.strobeGroupID = strobeGroupID;
			container.blinkingRedLights.Add(bLINKING_LIGHT);
		}
	}
}
