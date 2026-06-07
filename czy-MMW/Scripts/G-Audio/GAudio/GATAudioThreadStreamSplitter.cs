using System;
using UnityEngine;

namespace GAudio
{
	public class GATAudioThreadStreamSplitter : IGATAudioThreadStreamClient, IGATAudioThreadStreamOwner, IDisposable
	{
		private GATAudioThreadStreamProxy[] _streamProxies;

		private GATData _sharedBuffer;

		private float[] _sharedBufferArray;

		private IntPtr _sharedBufferPointer;

		private int _memOffset;

		private int _sharedBufferSize;

		private int _sourceStreamChannels;

		private IGATAudioThreadStream _sourceStream;

		private bool _disposed;

		public int NbOfStreams => _sourceStreamChannels;

		public GATAudioThreadStreamSplitter(IGATAudioThreadStream stream, GATDataAllocationMode bufferAllocationMode)
		{
			_sourceStreamChannels = stream.NbOfChannels;
			if (_sourceStreamChannels < 2)
			{
				Debug.LogWarning("source stream is mono: " + stream.StreamName);
			}
			IntPtr bufferPointer = IntPtr.Zero;
			_sharedBufferSize = stream.BufferSizePerChannel;
			if (bufferAllocationMode == GATDataAllocationMode.Unmanaged)
			{
				_sharedBufferArray = new float[_sharedBufferSize];
				_sharedBuffer = new GATData(_sharedBufferArray);
			}
			else
			{
				if (bufferAllocationMode == GATDataAllocationMode.Fixed)
				{
					_sharedBuffer = GATManager.GetFixedDataContainer(_sharedBufferSize, "StreamSplitter buffer");
				}
				else
				{
					_sharedBuffer = GATManager.GetDataContainer(_sharedBufferSize);
				}
				_sharedBufferArray = _sharedBuffer.ParentArray;
				bufferPointer = _sharedBuffer.GetPointer();
			}
			_memOffset = _sharedBuffer.MemOffset;
			_streamProxies = new GATAudioThreadStreamProxy[_sourceStreamChannels];
			for (int i = 0; i < _sourceStreamChannels; i++)
			{
				_streamProxies[i] = new GATAudioThreadStreamProxy(_sharedBufferSize, 1, bufferPointer, _sharedBuffer.MemOffset, stream.StreamName + " split " + i);
			}
			stream.AddAudioThreadStreamClient(this);
			_sourceStream = stream;
		}

		void IGATAudioThreadStreamClient.HandleAudioThreadStream(float[] data, int offset, bool isEmptyData, IGATAudioThreadStream stream)
		{
			for (int i = 0; i < _sourceStreamChannels; i++)
			{
				GATAudioThreadStreamProxy gATAudioThreadStreamProxy = _streamProxies[i];
				if (gATAudioThreadStreamProxy.HasClient && !isEmptyData)
				{
					int num = offset + i;
					int num2 = _memOffset;
					int num3 = num2 + _sharedBufferSize;
					while (num2 < num3)
					{
						_sharedBufferArray[num2] = data[num];
						num2++;
						num += _sourceStreamChannels;
					}
				}
				gATAudioThreadStreamProxy.BroadcastStream(_sharedBufferArray, _memOffset, isEmptyData);
			}
		}

		public void Dispose()
		{
			Dispose(explicitely: true);
			GC.SuppressFinalize(this);
		}

		protected void Dispose(bool explicitely)
		{
			if (!_disposed)
			{
				_sourceStream.RemoveAudioThreadStreamClient(this);
				_sourceStream = null;
				_sharedBuffer.Release();
				_sharedBuffer = null;
				_disposed = true;
			}
		}

		~GATAudioThreadStreamSplitter()
		{
			Dispose(explicitely: false);
		}

		public IGATAudioThreadStream GetAudioThreadStream(int index = 0)
		{
			if (index >= _sourceStreamChannels)
			{
				return null;
			}
			return _streamProxies[index];
		}
	}
}
