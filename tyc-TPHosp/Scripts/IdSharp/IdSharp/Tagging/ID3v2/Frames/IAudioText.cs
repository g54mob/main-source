using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IAudioText : IFrame, INotifyPropertyChanged, ITextEncoding
	{
		string MimeType { get; set; }

		string EquivalentText { get; set; }

		void SetAudioData(string mimeType, byte[] audioData, bool isMpegOrAac);

		byte[] GetAudioData(AudioScramblingMode audioScramblingMode);
	}
}
