using UltimateReplay;

public class PressureButtonReplay : ReplayBehaviour
{
	private PressureButton pressureButton;

	public override void Awake()
	{
		base.Awake();
		pressureButton = GetComponent<PressureButton>();
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(pressureButton.IsOn);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		pressureButton.SetHighlightVisibility(state.ReadBool());
	}
}
