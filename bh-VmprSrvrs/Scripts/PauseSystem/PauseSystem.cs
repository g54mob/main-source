public static class PauseSystem
{
	private static bool _paused;

	public static float? DesynchronizedTimeInSeconds;

	public static bool Paused => false;

	public static float DeltaTime => 0f;

	public static float DeltaTimeMillis => 0f;

	public static float Time => 0f;

	public static void Pause()
	{
	}

	public static void Resume()
	{
	}
}
