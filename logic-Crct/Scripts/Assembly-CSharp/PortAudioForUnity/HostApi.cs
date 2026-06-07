namespace PortAudioForUnity
{
	public enum HostApi : uint
	{
		InDevelopment = 0u,
		DirectSound = 1u,
		MME = 2u,
		ASIO = 3u,
		SoundManager = 4u,
		CoreAudio = 5u,
		OSS = 7u,
		ALSA = 8u,
		AL = 9u,
		BeOS = 10u,
		WDMKS = 11u,
		JACK = 12u,
		WASAPI = 13u,
		AudioScienceHPI = 14u
	}
}
