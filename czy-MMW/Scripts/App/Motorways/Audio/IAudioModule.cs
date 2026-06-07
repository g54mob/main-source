namespace Motorways.Audio
{
	public interface IAudioModule
	{
		void Activate(AudioEnvironment environment);

		void Deactivate();

		void Release();

		void UpdateModule();
	}
}
