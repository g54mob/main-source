using System;
using System.IO;

namespace NAudio.Wave
{
	public class WaveFileWriter : Stream
	{
		private Stream outStream;

		private readonly BinaryWriter writer;

		private long dataSizePos;

		private long factSampleCountPos;

		private long dataChunkSize;

		private readonly WaveFormat format;

		private readonly string filename;

		private readonly byte[] value24;

		public string Filename => null;

		public override long Length => 0L;

		public TimeSpan TotalTime => default(TimeSpan);

		public WaveFormat WaveFormat => null;

		public override bool CanRead => false;

		public override bool CanWrite => false;

		public override bool CanSeek => false;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public static void CreateWaveFile16(string filename, ISampleProvider sourceProvider)
		{
		}

		public static void CreateWaveFile(string filename, IWaveProvider sourceProvider)
		{
		}

		public static void WriteWavFileToStream(Stream outStream, IWaveProvider sourceProvider)
		{
		}

		public WaveFileWriter(Stream outStream, WaveFormat format)
		{
		}

		public WaveFileWriter(string filename, WaveFormat format)
		{
		}

		private void WriteDataChunkHeader()
		{
		}

		private void CreateFactChunk()
		{
		}

		private bool HasFactChunk()
		{
			return false;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		[Obsolete("Use Write instead")]
		public void WriteData(byte[] data, int offset, int count)
		{
		}

		public override void Write(byte[] data, int offset, int count)
		{
		}

		public void WriteSample(float sample)
		{
		}

		public void WriteSamples(float[] samples, int offset, int count)
		{
		}

		[Obsolete("Use WriteSamples instead")]
		public void WriteData(short[] samples, int offset, int count)
		{
		}

		public void WriteSamples(short[] samples, int offset, int count)
		{
		}

		public override void Flush()
		{
		}

		protected override void Dispose(bool disposing)
		{
		}

		protected virtual void UpdateHeader(BinaryWriter writer)
		{
		}

		private void UpdateDataChunk(BinaryWriter writer)
		{
		}

		private void UpdateRiffChunk(BinaryWriter writer)
		{
		}

		private void UpdateFactChunk(BinaryWriter writer)
		{
		}

		~WaveFileWriter()
		{
		}
	}
}
