namespace GAudio
{
	public interface IGATPulseInfo
	{
		double PulseDspTime { get; }

		double PulseDuration { get; }

		int StepIndex { get; }

		int NbOfSteps { get; }

		bool PulseDidChange { get; }

		IGATPulseSender PulseSender { get; }
	}
}
