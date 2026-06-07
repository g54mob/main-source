using FMOD;

namespace Logic.Audio
{
	public interface IAudioManagerQueuedEvent
	{
		GUID GUID { get; }

		float Priority { get; }

		void Start(AudioManagerPlayer pool);
	}
}
