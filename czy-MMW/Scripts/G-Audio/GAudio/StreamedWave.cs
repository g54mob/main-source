using System;
using System.IO;
using System.Text;

namespace GAudio
{
	public class StreamedWave
	{
		private int _sampleRate;

		private int _channelCount;

		private Stream _wavStream;

		private int _length;

		private byte[] _buffer;

		public StreamedWave(int sampleRate, int channelCount)
		{
			_sampleRate = sampleRate;
			_channelCount = channelCount;
		}

		public void WritePCM(float[] data)
		{
			_length += data.Length;
			if (_wavStream == null)
			{
				string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "lineout.wav");
				if (text == null)
				{
					return;
				}
				_wavStream = File.Open(text, FileMode.Create, FileAccess.Write);
				WriteHeader();
			}
			else
			{
				RewriteHeader();
			}
			if (_buffer == null || _buffer.Length < data.Length * 4)
			{
				_buffer = new byte[data.Length * 4];
			}
			Buffer.BlockCopy(data, 0, _buffer, 0, data.Length * 4);
			_wavStream.Write(_buffer, 0, data.Length * 4);
		}

		private void WriteHeader()
		{
			int num = 32;
			bool flag = true;
			_wavStream.Position = 0L;
			_wavStream.Write(Encoding.ASCII.GetBytes("RIFF"), 0, 4);
			_wavStream.Write(BitConverter.GetBytes(num / 8 * _length + 36), 0, 4);
			_wavStream.Write(Encoding.ASCII.GetBytes("WAVE"), 0, 4);
			_wavStream.Write(Encoding.ASCII.GetBytes("fmt "), 0, 4);
			_wavStream.Write(BitConverter.GetBytes(16), 0, 4);
			_wavStream.Write(BitConverter.GetBytes((ushort)((!flag) ? 1u : 3u)), 0, 2);
			_wavStream.Write(BitConverter.GetBytes(_channelCount), 0, 2);
			_wavStream.Write(BitConverter.GetBytes(_sampleRate), 0, 4);
			_wavStream.Write(BitConverter.GetBytes(_sampleRate * _channelCount * (num / 8)), 0, 4);
			_wavStream.Write(BitConverter.GetBytes((ushort)_channelCount * (num / 8)), 0, 2);
			_wavStream.Write(BitConverter.GetBytes(num), 0, 2);
			_wavStream.Write(Encoding.ASCII.GetBytes("data"), 0, 4);
			_wavStream.Write(BitConverter.GetBytes(num / 8 * _length), 0, 4);
		}

		private void RewriteHeader()
		{
			int num = 32;
			long position = _wavStream.Position;
			_wavStream.Position = 4L;
			_wavStream.Write(BitConverter.GetBytes(num / 8 * _length + 36), 0, 4);
			_wavStream.Position = 40L;
			_wavStream.Write(BitConverter.GetBytes(num / 8 * _length), 0, 4);
			_wavStream.Position = position;
		}
	}
}
