public static class InstrumentStateExtensions
{
	private const int OCTAVE_NOTE = 31;

	private const int MAX_NOTES = 24;

	private static readonly PlayerInput.InputType[] KEY_INPUTS = new PlayerInput.InputType[24]
	{
		PlayerInput.InputType.C1_NOTE,
		PlayerInput.InputType.C1S_NOTE,
		PlayerInput.InputType.D1_NOTE,
		PlayerInput.InputType.D1S_NOTE,
		PlayerInput.InputType.E1_NOTE,
		PlayerInput.InputType.F1_NOTE,
		PlayerInput.InputType.F1S_NOTE,
		PlayerInput.InputType.G1_NOTE,
		PlayerInput.InputType.G1S_NOTE,
		PlayerInput.InputType.A1_NOTE,
		PlayerInput.InputType.A1S_NOTE,
		PlayerInput.InputType.B1_NOTE,
		PlayerInput.InputType.C2_NOTE,
		PlayerInput.InputType.C2S_NOTE,
		PlayerInput.InputType.D2_NOTE,
		PlayerInput.InputType.D2S_NOTE,
		PlayerInput.InputType.E2_NOTE,
		PlayerInput.InputType.F2_NOTE,
		PlayerInput.InputType.F2S_NOTE,
		PlayerInput.InputType.G2_NOTE,
		PlayerInput.InputType.G2S_NOTE,
		PlayerInput.InputType.A2_NOTE,
		PlayerInput.InputType.A2S_NOTE,
		PlayerInput.InputType.B2_NOTE
	};

	public static void SetKey(this ref PlayedNotes playedNotes, int key)
	{
		playedNotes.Value |= 1 << key;
	}

	public static bool GetKeyPressed(this PlayedNotes playedNotes, PlayedNotes previousPlayedNotes, int key)
	{
		if ((playedNotes.Value & (1 << key)) != 0)
		{
			return (previousPlayedNotes.Value & (1 << key)) == 0;
		}
		return false;
	}

	public static bool GetKey(this PlayedNotes playedNotes, int key)
	{
		return (playedNotes.Value & (1 << key)) != 0;
	}

	public static void SetOctave(this ref PlayedNotes playedNotes, bool value = true)
	{
		if (value)
		{
			playedNotes.Value |= int.MinValue;
		}
		else
		{
			playedNotes.Value &= int.MaxValue;
		}
	}

	public static bool GetOctave(this PlayedNotes playedNotes)
	{
		return (playedNotes.Value & int.MinValue) != 0;
	}
}
