using UltimateReplay;

public class MultiCameraReplay : ReplayBehaviour
{
	private MultiCamera multiCamera;

	public override void Awake()
	{
		base.Awake();
		multiCamera = GetComponent<MultiCamera>();
	}

	public override void OnReplayStart()
	{
		base.OnReplayStart();
		multiCamera.enabled = true;
	}

	public override void OnReplayEnd()
	{
		base.OnReplayEnd();
		multiCamera.SetCameraOff();
	}
}
