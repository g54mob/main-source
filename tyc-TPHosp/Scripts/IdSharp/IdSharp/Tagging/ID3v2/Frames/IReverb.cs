using System.ComponentModel;

namespace IdSharp.Tagging.ID3v2.Frames
{
	public interface IReverb : IFrame, INotifyPropertyChanged
	{
		short ReverbLeftMilliseconds { get; set; }

		short ReverbRightMilliseconds { get; set; }

		byte ReverbBouncesLeft { get; set; }

		byte ReverbBouncesRight { get; set; }

		byte ReverbFeedbackLeftToLeft { get; set; }

		byte ReverbFeedbackLeftToRight { get; set; }

		byte ReverbFeedbackRightToRight { get; set; }

		byte ReverbFeedbackRightToLeft { get; set; }

		byte PremixLeftToRight { get; set; }

		byte PremixRightToLeft { get; set; }
	}
}
