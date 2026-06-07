namespace GAudio
{
	public interface IGATPulseSender
	{
		IGATPulseInfo PulseInfo { get; }

		IGATPulseInfo MasterPulseInfo { get; }
	}
}
