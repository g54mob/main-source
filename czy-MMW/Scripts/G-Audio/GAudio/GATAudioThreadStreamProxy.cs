using System;

namespace GAudio
{
	public class GATAudioThreadStreamProxy : IGATAudioThreadStream
	{
		private OnAudioThreadStream _onAudioThreadStream;

		private int _nbOfChannels;

		private int _bufferSizePerChannel;

		private IntPtr _bufferPointer;

		private int _bufferOffset;

		private string _streamName;

		public bool HasClient => _onAudioThreadStream != null;

		int IGATAudioThreadStream.NbOfChannels => _nbOfChannels;

		int IGATAudioThreadStream.BufferSizePerChannel => _bufferSizePerChannel;

		IntPtr IGATAudioThreadStream.BufferPointer => _bufferPointer;

		int IGATAudioThreadStream.BufferOffset => _bufferOffset;

		string IGATAudioThreadStream.StreamName => _streamName;

		public GATAudioThreadStreamProxy(int bufferSizePerChannel, int nbOfChannels, IntPtr bufferPointer, int bufferOffset, string streamName = null)
		{
			_bufferSizePerChannel = bufferSizePerChannel;
			_nbOfChannels = nbOfChannels;
			_bufferPointer = bufferPointer;
			_bufferOffset = bufferOffset;
			_streamName = streamName;
		}

		public void BroadcastStream(float[] data, int offset, bool isEmptyData)
		{
			if (_onAudioThreadStream != null)
			{
				_onAudioThreadStream(data, offset, isEmptyData, this);
			}
		}

		public void AddAudioThreadStreamClient(IGATAudioThreadStreamClient client)
		{
			_onAudioThreadStream = (OnAudioThreadStream)Delegate.Combine(_onAudioThreadStream, new OnAudioThreadStream(client.HandleAudioThreadStream));
		}

		public void RemoveAudioThreadStreamClient(IGATAudioThreadStreamClient client)
		{
			if (_onAudioThreadStream != null)
			{
				_onAudioThreadStream = (OnAudioThreadStream)Delegate.Remove(_onAudioThreadStream, new OnAudioThreadStream(client.HandleAudioThreadStream));
			}
		}
	}
}
