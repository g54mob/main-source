using System;
using System.Runtime.InteropServices;
using System.Text;

namespace NAudio.Wave.Asio
{
	public class AsioDriver
	{
		[StructLayout((LayoutKind)0)]
		private class AsioDriverVTable
		{
			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate int ASIOInit(IntPtr _pUnknown, IntPtr sysHandle);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate void ASIOgetDriverName(IntPtr _pUnknown, StringBuilder name);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate int ASIOgetDriverVersion(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate void ASIOgetErrorMessage(IntPtr _pUnknown, StringBuilder errorMessage);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOstart(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOstop(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOgetChannels(IntPtr _pUnknown, out int numInputChannels, out int numOutputChannels);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOgetLatencies(IntPtr _pUnknown, out int inputLatency, out int outputLatency);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOgetBufferSize(IntPtr _pUnknown, out int minSize, out int maxSize, out int preferredSize, out int granularity);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOcanSampleRate(IntPtr _pUnknown, double sampleRate);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOgetSampleRate(IntPtr _pUnknown, out double sampleRate);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOsetSampleRate(IntPtr _pUnknown, double sampleRate);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOgetClockSources(IntPtr _pUnknown, out long clocks, int numSources);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOsetClockSource(IntPtr _pUnknown, int reference);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOgetSamplePosition(IntPtr _pUnknown, out long samplePos, ref Asio64Bit timeStamp);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOgetChannelInfo(IntPtr _pUnknown, ref AsioChannelInfo info);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOcreateBuffers(IntPtr _pUnknown, IntPtr bufferInfos, int numChannels, int bufferSize, IntPtr callbacks);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOdisposeBuffers(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOcontrolPanel(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOfuture(IntPtr _pUnknown, int selector, IntPtr opt);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate AsioError ASIOoutputReady(IntPtr _pUnknown);

			public ASIOInit init;

			public ASIOgetDriverName getDriverName;

			public ASIOgetDriverVersion getDriverVersion;

			public ASIOgetErrorMessage getErrorMessage;

			public ASIOstart start;

			public ASIOstop stop;

			public ASIOgetChannels getChannels;

			public ASIOgetLatencies getLatencies;

			public ASIOgetBufferSize getBufferSize;

			public ASIOcanSampleRate canSampleRate;

			public ASIOgetSampleRate getSampleRate;

			public ASIOsetSampleRate setSampleRate;

			public ASIOgetClockSources getClockSources;

			public ASIOsetClockSource setClockSource;

			public ASIOgetSamplePosition getSamplePosition;

			public ASIOgetChannelInfo getChannelInfo;

			public ASIOcreateBuffers createBuffers;

			public ASIOdisposeBuffers disposeBuffers;

			public ASIOcontrolPanel controlPanel;

			public ASIOfuture future;

			public ASIOoutputReady outputReady;
		}

		private IntPtr pAsioComObject;

		private IntPtr pinnedcallbacks;

		private AsioDriverVTable asioDriverVTable;

		private AsioDriver()
		{
		}

		public static string[] GetAsioDriverNames()
		{
			return null;
		}

		public static AsioDriver GetAsioDriverByName(string name)
		{
			return null;
		}

		public static AsioDriver GetAsioDriverByGuid(Guid guid)
		{
			return null;
		}

		public bool Init(IntPtr sysHandle)
		{
			return false;
		}

		public string GetDriverName()
		{
			return null;
		}

		public int GetDriverVersion()
		{
			return 0;
		}

		public string GetErrorMessage()
		{
			return null;
		}

		public void Start()
		{
		}

		public AsioError Stop()
		{
			return default(AsioError);
		}

		public void GetChannels(out int numInputChannels, out int numOutputChannels)
		{
			numInputChannels = default(int);
			numOutputChannels = default(int);
		}

		public AsioError GetLatencies(out int inputLatency, out int outputLatency)
		{
			inputLatency = default(int);
			outputLatency = default(int);
			return default(AsioError);
		}

		public void GetBufferSize(out int minSize, out int maxSize, out int preferredSize, out int granularity)
		{
			minSize = default(int);
			maxSize = default(int);
			preferredSize = default(int);
			granularity = default(int);
		}

		public bool CanSampleRate(double sampleRate)
		{
			return false;
		}

		public double GetSampleRate()
		{
			return 0.0;
		}

		public void SetSampleRate(double sampleRate)
		{
		}

		public void GetClockSources(out long clocks, int numSources)
		{
			clocks = default(long);
		}

		public void SetClockSource(int reference)
		{
		}

		public void GetSamplePosition(out long samplePos, ref Asio64Bit timeStamp)
		{
			samplePos = default(long);
		}

		public AsioChannelInfo GetChannelInfo(int channelNumber, bool trueForInputInfo)
		{
			return default(AsioChannelInfo);
		}

		public void CreateBuffers(IntPtr bufferInfos, int numChannels, int bufferSize, ref AsioCallbacks callbacks)
		{
		}

		public AsioError DisposeBuffers()
		{
			return default(AsioError);
		}

		public void ControlPanel()
		{
		}

		public void Future(int selector, IntPtr opt)
		{
		}

		public AsioError OutputReady()
		{
			return default(AsioError);
		}

		public void ReleaseComAsioDriver()
		{
		}

		private void HandleException(AsioError error, string methodName)
		{
		}

		private void InitFromGuid(Guid asioGuid)
		{
		}

		[PreserveSig]
		private static extern int CoCreateInstance(ref Guid clsid, IntPtr inner, uint context, ref Guid uuid, out IntPtr rReturnedComObject);
	}
}
