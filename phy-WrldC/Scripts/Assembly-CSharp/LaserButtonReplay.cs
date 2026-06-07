using UltimateReplay;
using UnityEngine;

public class LaserButtonReplay : ReplayBehaviour
{
	private LaserButton laserButton;

	private Collider laserTriggerZone;

	public override void Awake()
	{
		base.Awake();
		laserButton = GetComponent<LaserButton>();
		laserTriggerZone = base.transform.FindComponent<Collider>("LaserTriggerZone", isRecursively: true);
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		laserTriggerZone.enabled = true;
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(laserButton.IsOn);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		laserButton.SetLedOnOff(state.ReadBool());
	}
}
