using UnityEngine;

public class DeskFanController : SwitchSyncBehaviour
{
	public InteractableController ic;

	public Transform fanBlade;

	public float speedProgress;

	public float fanSpeed;

	public override void SetOn(bool val)
	{
	}

	private void Update()
	{
	}
}
