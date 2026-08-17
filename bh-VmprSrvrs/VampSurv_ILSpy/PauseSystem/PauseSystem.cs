using Cpp2ILInjected;

public static class PauseSystem
{
	private static bool _paused;

	public static float? DesynchronizedTimeInSeconds;

	public static bool Paused => _paused;

	public static float DeltaTime
	{
		get
		{
			//IL_0024: Expected I, but got O
			//IL_0011: Expected O, but got I
			//IL_000b: Expected F4, but got I4
			nint num = (nint)typeof(PauseSystem);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<PauseSystem>)+B8]");
			nint num2 = 0;
			if (!_paused)
			{
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ rax_v4 (should have been resolved before IL gen)");
				/*Error: End of method reached without returning.*/;
			}
			return 0f;
		}
	}

	public static float DeltaTimeMillis
	{
		get
		{
			float deltaTime = DeltaTime;
			return deltaTime * 1000f;
		}
	}

	public static float Time
	{
		get
		{
			//IL_0024: Expected I, but got O
			//IL_0011: Expected O, but got I
			//IL_000b: Expected F4, but got I4
			nint num = (nint)typeof(PauseSystem);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<PauseSystem>)+B8]");
			nint num2 = 0;
			if (!_paused)
			{
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v56 @ rax_v4 (should have been resolved before IL gen)");
				/*Error: End of method reached without returning.*/;
			}
			return 0f;
		}
	}

	public static void Pause()
	{
		_paused = true;
	}

	public static void Resume()
	{
		_paused = false;
	}
}
