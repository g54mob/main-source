using System;
using System.Collections.Generic;
using NAudio.Wave;

namespace NAudio.Dmo
{
	public class MediaObject : IDisposable
	{
		private IMediaObject mediaObject;

		private readonly int inputStreams;

		private readonly int outputStreams;

		public int InputStreamCount => 0;

		public int OutputStreamCount => 0;

		internal MediaObject(IMediaObject mediaObject)
		{
		}

		public DmoMediaType? GetInputType(int inputStream, int inputTypeIndex)
		{
			return null;
		}

		public DmoMediaType? GetOutputType(int outputStream, int outputTypeIndex)
		{
			return null;
		}

		public DmoMediaType GetOutputCurrentType(int outputStreamIndex)
		{
			return default(DmoMediaType);
		}

		public IEnumerable<DmoMediaType> GetInputTypes(int inputStreamIndex)
		{
			return null;
		}

		public IEnumerable<DmoMediaType> GetOutputTypes(int outputStreamIndex)
		{
			return null;
		}

		public bool SupportsInputType(int inputStreamIndex, DmoMediaType mediaType)
		{
			return false;
		}

		private bool SetInputType(int inputStreamIndex, DmoMediaType mediaType, DmoSetTypeFlags flags)
		{
			return false;
		}

		public void SetInputType(int inputStreamIndex, DmoMediaType mediaType)
		{
		}

		public void SetInputWaveFormat(int inputStreamIndex, WaveFormat waveFormat)
		{
		}

		public bool SupportsInputWaveFormat(int inputStreamIndex, WaveFormat waveFormat)
		{
			return false;
		}

		private DmoMediaType CreateDmoMediaTypeForWaveFormat(WaveFormat waveFormat)
		{
			return default(DmoMediaType);
		}

		public bool SupportsOutputType(int outputStreamIndex, DmoMediaType mediaType)
		{
			return false;
		}

		public bool SupportsOutputWaveFormat(int outputStreamIndex, WaveFormat waveFormat)
		{
			return false;
		}

		private bool SetOutputType(int outputStreamIndex, DmoMediaType mediaType, DmoSetTypeFlags flags)
		{
			return false;
		}

		public void SetOutputType(int outputStreamIndex, DmoMediaType mediaType)
		{
		}

		public void SetOutputWaveFormat(int outputStreamIndex, WaveFormat waveFormat)
		{
		}

		public MediaObjectSizeInfo GetInputSizeInfo(int inputStreamIndex)
		{
			return null;
		}

		public MediaObjectSizeInfo GetOutputSizeInfo(int outputStreamIndex)
		{
			return null;
		}

		public void ProcessInput(int inputStreamIndex, IMediaBuffer mediaBuffer, DmoInputDataBufferFlags flags, long timestamp, long duration)
		{
		}

		public void ProcessOutput(DmoProcessOutputFlags flags, int outputBufferCount, DmoOutputDataBuffer[] outputBuffers)
		{
		}

		public void AllocateStreamingResources()
		{
		}

		public void FreeStreamingResources()
		{
		}

		public long GetInputMaxLatency(int inputStreamIndex)
		{
			return 0L;
		}

		public void Flush()
		{
		}

		public void Discontinuity(int inputStreamIndex)
		{
		}

		public bool IsAcceptingData(int inputStreamIndex)
		{
			return false;
		}

		public void Dispose()
		{
		}
	}
}
