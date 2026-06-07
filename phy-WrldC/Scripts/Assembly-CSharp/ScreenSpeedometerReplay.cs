using UltimateReplay;
using UnityEngine;

public class ScreenSpeedometerReplay : ReplayBehaviour
{
	private ScreenSpeedometer screenSpeedometer;

	private GameObject screenSpeedometerCanvas;

	public override void Awake()
	{
		base.Awake();
		screenSpeedometer = GetComponent<ScreenSpeedometer>();
		screenSpeedometerCanvas = screenSpeedometer.transform.Find("ScreenSpeedometerCanvas").gameObject;
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(screenSpeedometer.CurrentVelocity);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		screenSpeedometer.SetScreenVelocityText(state.ReadFloat());
	}

	public override void OnReplayStart()
	{
		Behaviour[] componentsInChildren = screenSpeedometerCanvas.GetComponentsInChildren<Behaviour>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].enabled = true;
		}
	}
}
