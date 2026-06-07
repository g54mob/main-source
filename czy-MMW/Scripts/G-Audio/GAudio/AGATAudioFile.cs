using System;
using System.IO;
using NVorbis;

namespace GAudio
{
	public abstract class AGATAudioFile : IDisposable
	{
		private class OggFile : AGATAudioFile
		{
			private VorbisReader _reader;

			public override int Channels => _reader.Channels;

			public override int SampleRate => _reader.SampleRate;

			public override int NumFrames => (int)_reader.TotalSamples;

			public override int ReadPosition
			{
				get
				{
					return (int)_reader.DecodedPosition;
				}
				set
				{
					_reader.DecodedPosition = value;
				}
			}

			public OggFile(Stream stream)
			{
				_reader = new VorbisReader(stream, closeStreamOnDispose: true);
			}

			protected override void FreeResources()
			{
				_reader.Dispose();
			}

			public override int ReadNextChunk(float[] target, int offset, int numFrames)
			{
				if (_reader.DecodedPosition + numFrames > _reader.TotalSamples)
				{
					numFrames = (int)(_reader.TotalSamples - _reader.DecodedPosition);
				}
				return _reader.ReadSamples(target, offset, numFrames * Channels) / Channels;
			}
		}

		private class WavFile : AGATAudioFile
		{
			private const int BUFFER_LENGTH = 16384;

			private const int BYTES_BUFFER_LENGTH = 32768;

			private const int CONVERSION_FACTOR = 32767;

			private static short[] __intBuf;

			private static byte[] __bytesBuf;

			private int _eofPosition;

			private Stream _stream;

			private int _channels;

			private int _sampleRate;

			private int _numFrames;

			private int _readPos;

			private int _blockAlign;

			private int _headerSize;

			public override int Channels => _channels;

			public override int SampleRate => _sampleRate;

			public override int NumFrames => _numFrames;

			public override int ReadPosition
			{
				get
				{
					return ((int)_stream.Position - _headerSize) / _blockAlign;
				}
				set
				{
					value = value * _blockAlign + _headerSize;
					_stream.Seek(value, SeekOrigin.Begin);
				}
			}

			public WavFile(string path)
				: base(path)
			{
				if (__intBuf == null)
				{
					__intBuf = new short[16384];
					__bytesBuf = new byte[32768];
				}
				_stream = File.OpenRead(filePath);
				_headerSize = GATWavHelper.headerSize;
				ParseHeader();
			}

			public WavFile(Stream stream)
			{
				if (__intBuf == null)
				{
					__intBuf = new short[16384];
					__bytesBuf = new byte[32768];
				}
				_stream = stream;
				_headerSize = GATWavHelper.headerSize;
				ParseHeader();
			}

			protected override void FreeResources()
			{
				_stream.Close();
				_stream.Dispose();
			}

			private void ParseHeader()
			{
				BinaryReader binaryReader = new BinaryReader(_stream);
				byte[] bytes = binaryReader.ReadBytes(4);
				if (!bytes.IsEqualTo(GATWavHelper.riffBytes))
				{
					throw new GATException("File is not 'RIFF'");
				}
				binaryReader.ReadInt32();
				bytes = binaryReader.ReadBytes(4);
				if (!bytes.IsEqualTo(GATWavHelper.waveBytes))
				{
					throw new GATException("File is not 'WAVE'");
				}
				bytes = binaryReader.ReadBytes(4);
				if (!bytes.IsEqualTo(GATWavHelper.fmtBytes))
				{
					throw new GATException("Header error (subchunk1_ID is not 'fmt ' )");
				}
				int num = binaryReader.ReadInt32();
				if (num != 16 && num != 18)
				{
					throw new GATException("Header error: fmt size is not 16 or 18.");
				}
				if (binaryReader.ReadInt16() != 1)
				{
					throw new GATException("Compressed wav files not supported.");
				}
				_channels = binaryReader.ReadInt16();
				if (_channels > GATInfo.MaxIOChannels)
				{
					throw new GATException("File has more channels than than set in GATManager.MaxIOChannels");
				}
				_sampleRate = binaryReader.ReadInt32();
				binaryReader.ReadInt32();
				_blockAlign = binaryReader.ReadInt16();
				if (binaryReader.ReadInt16() != 16)
				{
					throw new GATException("Only 16 bit wav files are supported.");
				}
				if (num == 18)
				{
					binaryReader.ReadInt16();
					_headerSize += 2;
				}
				bytes = binaryReader.ReadBytes(4);
				while (!bytes.IsEqualTo(GATWavHelper.dataBytes))
				{
					int num2 = binaryReader.ReadInt32();
					_headerSize += 8 + num2;
					_stream.Seek(num2, SeekOrigin.Current);
					bytes = binaryReader.ReadBytes(4);
				}
				int num3 = binaryReader.ReadInt32();
				_eofPosition = _headerSize + num3;
				_numFrames = num3 / _blockAlign;
			}

			public override int ReadNextChunk(float[] target, int offset, int numFrames)
			{
				int num = numFrames * _blockAlign;
				int num2 = 0;
				int num3 = 0;
				if (_stream.Position + num > _eofPosition)
				{
					num = _eofPosition - (int)_stream.Position;
				}
				int num4 = ((num < 32768) ? num : 32768);
				while (num2 < num)
				{
					num3 = _stream.Read(__bytesBuf, 0, num4);
					num2 += num3;
					if (num2 > num)
					{
						num3 -= num2 - num;
						num2 = num;
					}
					Buffer.BlockCopy(__bytesBuf, 0, __intBuf, 0, num3);
					int num5 = num3 / 2;
					for (int i = 0; i < num5; i++)
					{
						target[offset] = (float)__intBuf[i] / 32767f;
						offset++;
					}
					if (num3 < num4)
					{
						break;
					}
				}
				return num2 / _blockAlign;
			}
		}

		public readonly string filePath;

		protected int _readChunkSize;

		private bool _disposed;

		public string FileName => Path.GetFileName(filePath);

		public abstract int Channels { get; }

		public abstract int SampleRate { get; }

		public abstract int NumFrames { get; }

		public abstract int ReadPosition { get; set; }

		public static AGATAudioFile OpenAudioFileAtPath(string path)
		{
			string text = Path.GetExtension(path).ToLower();
			if (text != ".wav" && text != ".ogg")
			{
				throw new GATException("Unrecognized extension: " + text);
			}
			if (!File.Exists(path))
			{
				throw new GATException("No such file!");
			}
			if (text == ".wav")
			{
				return new WavFile(path);
			}
			return new OggFile(File.OpenRead(path));
		}

		public static AGATAudioFile OpenAudioFileFromStream(Stream stream, string format)
		{
			if (format != "wav" && format != "ogg")
			{
				throw new GATException("Unrecognized format: " + format);
			}
			if (format == "wav")
			{
				return new WavFile(stream);
			}
			return new OggFile(stream);
		}

		public abstract int ReadNextChunk(float[] target, int offset, int numFrames);

		protected AGATAudioFile(string path)
		{
			filePath = path;
		}

		protected AGATAudioFile()
		{
		}

		public void Dispose()
		{
			Dispose(explicitly: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool explicitly)
		{
			if (!_disposed)
			{
				if (explicitly)
				{
					FreeResources();
				}
				_disposed = true;
			}
		}

		~AGATAudioFile()
		{
			Dispose(explicitly: false);
		}

		protected abstract void FreeResources();
	}
}
