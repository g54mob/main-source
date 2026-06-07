using System;

namespace GAudio
{
	public interface IGATAudioThreadStream
	{
		int NbOfChannels { get; }

		int BufferSizePerChannel { get; }

		IntPtr BufferPointer { get; }

		int BufferOffset { get; }

		string StreamName { get; }

		void AddAudioThreadStreamClient(IGATAudioThreadStreamClient client);

		void RemoveAudioThreadStreamClient(IGATAudioThreadStreamClient client);
	}
}
