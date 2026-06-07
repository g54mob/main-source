using UltimateReplay;
using UnityEngine;

public class LedReplay : ReplayBehaviour
{
	private Led led;

	private Light ledLight;

	public override void Awake()
	{
		base.Awake();
		led = GetComponent<Led>();
		ledLight = led.transform.GetComponentInChildren<Light>();
	}

	public override void OnReplayStart()
	{
		ledLight.enabled = true;
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(led.CurrentIntensity);
		state.Write((short)led.ColorIndex);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		float num = state.ReadFloat();
		short colorIndex = state.Read16();
		led.SetMaterialEmission(num * led.MaxIntensity, led.GetColor(colorIndex));
	}
}
