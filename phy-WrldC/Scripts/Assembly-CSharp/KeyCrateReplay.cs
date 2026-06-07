using UltimateReplay;

public class KeyCrateReplay : ReplayBehaviour
{
	private KeyCrate keyCrate;

	public override void Awake()
	{
		base.Awake();
		keyCrate = GetComponent<KeyCrate>();
	}

	public override void OnReplaySerialize(UltimateReplay.ReplayState state)
	{
		state.Write(keyCrate.IsOn);
	}

	public override void OnReplayDeserialize(UltimateReplay.ReplayState state)
	{
		keyCrate.SetHighlightVisibility(state.ReadBool());
	}
}
