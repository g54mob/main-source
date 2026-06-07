using System;

namespace RenderHeads.Media.AVProMovieCapture
{
	[Flags]
	public enum MicrophoneRecordingOptions
	{
		Defaults = 0,
		MixWithOthers = 1,
		DefaultToSpeaker = 2,
		AllowBluetoothMicrophone = 4
	}
}
