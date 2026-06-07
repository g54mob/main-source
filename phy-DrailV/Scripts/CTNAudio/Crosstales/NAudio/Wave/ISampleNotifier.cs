using System;

namespace Crosstales.NAudio.Wave
{
	public interface ISampleNotifier
	{
		event EventHandler<SampleEventArgs> Sample;
	}
}
