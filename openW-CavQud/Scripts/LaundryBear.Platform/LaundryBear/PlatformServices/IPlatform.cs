namespace LaundryBear.PlatformServices
{
	public interface IPlatform : IService
	{
		bool SupportsAchievements { get; }

		bool SupportsRichPresence { get; }

		bool SupportsUsers { get; }

		bool AllowsUserWindowModification { get; }

		bool SupportsQuit { get; }

		event PlatformSuspendEventHandler SuspendEvent;

		event PlatformResumeEventHandler ResumeEvent;

		event PlatformShutdownEventHandler ShutdownEvent;

		void SetupRequiredData(object data);

		string GetSystemLanguage();

		void Quit();
	}
}
