using System.Collections.Generic;

namespace ModApi.Audio
{
	public interface IMusicPlayer
	{
		float Intensity { get; }

		bool IsPlaying { get; }

		List<MusicTrack> MusicTracks { get; }
	}
}
