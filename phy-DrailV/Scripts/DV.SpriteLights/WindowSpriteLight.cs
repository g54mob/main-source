using UnityEngine;

public class WindowSpriteLight : SpriteLight
{
	private readonly SpriteLights.LightData WINDOWS_LIGHT = new SpriteLights.LightData
	{
		frontColor = Color.white,
		brightness = 1f
	};

	[Header("Window light")]
	public float windowSizeX = 1f;

	public float windowSizeY = 1f;

	public override SpriteLightType LightType => SpriteLightType.WindowSpriteLight;

	public override bool ShouldGenerateRealLight => false;

	public override bool RealtimeEffectsEntry => false;

	public override void FillLights(LightBakeContainer container)
	{
		SpriteLights.LightData wINDOWS_LIGHT = WINDOWS_LIGHT;
		wINDOWS_LIGHT.position = base.transform.position;
		wINDOWS_LIGHT.rotation = base.transform.rotation;
		wINDOWS_LIGHT.size = 1.2f * Mathf.Max(windowSizeX, windowSizeY) * 1f;
		container.windowLights.Add(wINDOWS_LIGHT);
	}

	private void OnDrawGizmosSelected()
	{
		Gizmos.matrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.lossyScale);
		Gizmos.DrawWireCube(Vector3.zero, new Vector3(windowSizeX, windowSizeY, 0.2f));
	}
}
