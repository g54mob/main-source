using System;
using System.IO;
using System.Threading;

namespace GAudio
{
	public class GATAsyncWavWriter : IDisposable
	{
		public readonly int WriteChunkFrames;

		private const int RESCALE_FACTOR = 32767;

		private bool _disposed;

		private float[] _inputBuffer;

		private short[] _intBuffer;

		private byte[] _bytesBuffer;

		private volatile bool _vDoWrite;

		private volatile int _vReceivedFrames;

		private int _writtenFrames;

		private Thread _thread;

		private FileStream _fs;

		private int _numChannels;

		private string _path;

		private int _nextInputOffset;

		private int _nextWriteOffset;

		private int _inputBufferSize;

		public GATAsyncWavWriter(string filePath, int numChannels, bool overwrite)
		{
			int num = GATInfo.AudioBufferSizePerChannel * numChannels;
			_inputBufferSize = num * 4;
			_inputBuffer = new float[_inputBufferSize];
			_intBuffer = new short[num];
			_bytesBuffer = new byte[num * 2];
			_numChannels = numChannels;
			WriteChunkFrames = GATInfo.AudioBufferSizePerChannel;
			_path = filePath;
			_fs = new FileStream(_path, FileMode.Create, FileAccess.Write);
		}

		public void PrepareToWrite()
		{
			_vDoWrite = true;
			_thread = new Thread(AsyncWriteLoop);
			_thread.Start();
		}

		public void WriteStreamAsync(float[] data, int offset, int numFrames)
		{
			if (_vDoWrite)
			{
				int num = numFrames * _numChannels;
				int num2 = num;
				if (offset + num2 > data.Length)
				{
					throw new GATException("Cannot write, out of range!");
				}
				if (num2 + _nextInputOffset >= _inputBufferSize)
				{
					num2 = _inputBufferSize - _nextInputOffset;
					Array.Copy(data, offset, _inputBuffer, _nextInputOffset, num2);
					offset += num2;
					num2 = num - num2;
					_nextInputOffset = 0;
				}
				Array.Copy(data, offset, _inputBuffer, _nextInputOffset, num2);
				_vReceivedFrames += numFrames;
				_nextInputOffset += num2;
			}
		}

		public void StopAndFinalize()
		{
			_vDoWrite = false;
		}

		public void Dispose()
		{
			Dispose(explicitly: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool explicitly)
		{
			if (!_disposed)
			{
				_vDoWrite = false;
				_disposed = true;
			}
		}

		~GATAsyncWavWriter()
		{
			Dispose(explicitly: false);
		}

		private void AsyncWriteLoop()
		{
			_fs.Seek(GATWavHelper.headerSize, SeekOrigin.Begin);
			int num = 0;
			int millisecondsTimeout = (int)(GATInfo.AudioBufferDuration * 2000.0 / 3.0);
			while (_vDoWrite)
			{
				num = _vReceivedFrames;
				if (num >= _writtenFrames + WriteChunkFrames)
				{
					ConvertAndWriteChunk(WriteChunkFrames);
				}
				else
				{
					Thread.Sleep(millisecondsTimeout);
				}
			}
			while (num > _writtenFrames)
			{
				if (num < WriteChunkFrames)
				{
					ConvertAndWriteChunk(num - _writtenFrames);
				}
				else
				{
					ConvertAndWriteChunk(WriteChunkFrames);
				}
			}
			byte[] array = null;
			array = GATWavHelper.GetHeader(_numChannels, GATInfo.OutputSampleRate, (int)_fs.Length);
			_fs.Seek(0L, SeekOrigin.Begin);
			_fs.Write(array, 0, array.Length);
			_fs.Close();
		}

		private void ConvertAndWriteChunk(int numFrames)
		{
			int num = numFrames * _numChannels;
			int num2 = 0;
			int num3 = _nextWriteOffset;
			while (num2 < num)
			{
				_intBuffer[num2] = (short)(_inputBuffer[num3] * 32767f);
				num2++;
				num3++;
			}
			Buffer.BlockCopy(_intBuffer, 0, _bytesBuffer, 0, num * 2);
			_fs.Write(_bytesBuffer, 0, num * 2);
			_nextWriteOffset = (_nextWriteOffset + num) % _inputBufferSize;
			_writtenFrames += numFrames;
		}
	}
}
