namespace Alekrus.UnivarsalPlatform
{
	public interface IInitializable
	{
		bool IsInitialized { get; }

		event InitializedEventHandler Initialized;

		event ShutdownedEventHandler Shutdowned;

		bool Initialize();

		bool Shutdown();
	}
}
