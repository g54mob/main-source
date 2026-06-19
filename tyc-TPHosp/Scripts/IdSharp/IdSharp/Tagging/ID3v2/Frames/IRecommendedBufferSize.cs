using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IRecommendedBufferSize : IFrame, INotifyPropertyChanged
	{
		int BufferSize { get; set; }

		bool EmbeddedInfo { get; set; }

		int? OffsetToNextTag { get; set; }
	}
}
