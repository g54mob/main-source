using System;
using NAudio.MediaFoundation;

namespace NAudio.Wave
{
	public class MediaFoundationEncoder : IDisposable
	{
		private readonly MediaType outputMediaType;

		private bool disposed;

		public static int[] GetEncodeBitrates(Guid audioSubtype, int sampleRate, int channels)
		{
			return null;
		}

		public static MediaType[] GetOutputMediaTypes(Guid audioSubtype)
		{
			return null;
		}

		public static void EncodeToWma(IWaveProvider inputProvider, string outputFile, int desiredBitRate = 192000)
		{
		}

		public static void EncodeToMp3(IWaveProvider inputProvider, string outputFile, int desiredBitRate = 192000)
		{
		}

		public static void EncodeToAac(IWaveProvider inputProvider, string outputFile, int desiredBitRate = 192000)
		{
		}

		public static MediaType SelectMediaType(Guid audioSubtype, WaveFormat inputFormat, int desiredBitRate)
		{
			return null;
		}

		public MediaFoundationEncoder(MediaType outputMediaType)
		{
		}

		public void Encode(string outputFile, IWaveProvider inputProvider)
		{
		}

		private static IMFSinkWriter CreateSinkWriter(string outputFile)
		{
			return null;
		}

		private void PerformEncode(IMFSinkWriter writer, int streamIndex, IWaveProvider inputProvider)
		{
		}

		private static long BytesToNsPosition(int bytes, WaveFormat waveFormat)
		{
			return 0L;
		}

		private long ConvertOneBuffer(IMFSinkWriter writer, int streamIndex, IWaveProvider inputProvider, long position, byte[] managedBuffer)
		{
			return 0L;
		}

		protected void Dispose(bool disposing)
		{
		}

		public void Dispose()
		{
		}

		~MediaFoundationEncoder()
		{
		}
	}
}
