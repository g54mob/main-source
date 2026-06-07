using UltimateReplay;

public class GrabberReplay : ReplayBehaviour
{
	private Grabber grabber;

	public override void Awake()
	{
		base.Awake();
		grabber = GetComponent<Grabber>();
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(grabber.IsGrabberOn);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		grabber.SetMaterialEmission(state.ReadBool());
	}
}
