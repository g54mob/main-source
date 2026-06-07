namespace GAudio
{
	public interface IGATPulseClient
	{
		void OnPulse(IGATPulseInfo pulseInfo);

		void PulseStepsDidChange(bool[] newSteps);
	}
}
