using System;

namespace NAudio.Wave.Asio
{
	public class AsioDriverExt
	{
		private readonly AsioDriver driver;

		private AsioCallbacks callbacks;

		private AsioDriverCapability capability;

		private AsioBufferInfo[] bufferInfos;

		private bool isOutputReadySupported;

		private IntPtr[] currentOutputBuffers;

		private IntPtr[] currentInputBuffers;

		private int numberOfOutputChannels;

		private int numberOfInputChannels;

		private AsioFillBufferCallback fillBufferCallback;

		private int bufferSize;

		private int outputChannelOffset;

		private int inputChannelOffset;

		public AsioDriver Driver => null;

		public AsioFillBufferCallback FillBufferCallback
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AsioDriverCapability Capabilities => null;

		public AsioDriverExt(AsioDriver driver)
		{
		}

		public void SetChannelOffset(int outputChannelOffset, int inputChannelOffset)
		{
		}

		public void Start()
		{
		}

		public void Stop()
		{
		}

		public void ShowControlPanel()
		{
		}

		public void ReleaseDriver()
		{
		}

		public bool IsSampleRateSupported(double sampleRate)
		{
			return false;
		}

		public void SetSampleRate(double sampleRate)
		{
		}

		public int CreateBuffers(int numberOfOutputChannels, int numberOfInputChannels, bool useMaxBufferSize)
		{
			return 0;
		}

		private void BuildCapabilities()
		{
		}

		private void BufferSwitchCallBack(int doubleBufferIndex, bool directProcess)
		{
		}

		private void SampleRateDidChangeCallBack(double sRate)
		{
		}

		private int AsioMessageCallBack(AsioMessageSelector selector, int value, IntPtr message, IntPtr opt)
		{
			return 0;
		}

		private IntPtr BufferSwitchTimeInfoCallBack(IntPtr asioTimeParam, int doubleBufferIndex, bool directProcess)
		{
			return (IntPtr)0;
		}
	}
}
