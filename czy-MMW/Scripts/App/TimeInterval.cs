public class TimeInterval
{
	public float UnsyncedDelta { get; set; }

	public float Delta { get; set; }

	public float ScaledDelta
	{
		get
		{
			if (!IsPaused)
			{
				return UnpausedScaledDelta;
			}
			return 0f;
		}
	}

	public float UnpausedScaledDelta => Scale.ScaleTime(Delta);

	public TimeScale Scale { get; set; } = TimeScale.Single;

	public bool IsPaused { get; set; }
}
