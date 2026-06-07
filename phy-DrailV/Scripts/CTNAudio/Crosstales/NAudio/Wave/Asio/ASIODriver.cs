using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.Win32;

namespace Crosstales.NAudio.Wave.Asio
{
	internal class ASIODriver
	{
		[StructLayout(LayoutKind.Sequential, Pack = 2)]
		private class ASIODriverVTable
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
			public delegate ASIOError ASIOstart(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOstop(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOgetChannels(IntPtr _pUnknown, out int numInputChannels, out int numOutputChannels);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOgetLatencies(IntPtr _pUnknown, out int inputLatency, out int outputLatency);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOgetBufferSize(IntPtr _pUnknown, out int minSize, out int maxSize, out int preferredSize, out int granularity);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOcanSampleRate(IntPtr _pUnknown, double sampleRate);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOgetSampleRate(IntPtr _pUnknown, out double sampleRate);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOsetSampleRate(IntPtr _pUnknown, double sampleRate);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOgetClockSources(IntPtr _pUnknown, out long clocks, int numSources);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOsetClockSource(IntPtr _pUnknown, int reference);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOgetSamplePosition(IntPtr _pUnknown, out long samplePos, ref ASIO64Bit timeStamp);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOgetChannelInfo(IntPtr _pUnknown, ref ASIOChannelInfo info);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOcreateBuffers(IntPtr _pUnknown, IntPtr bufferInfos, int numChannels, int bufferSize, IntPtr callbacks);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOdisposeBuffers(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOcontrolPanel(IntPtr _pUnknown);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOfuture(IntPtr _pUnknown, int selector, IntPtr opt);

			[UnmanagedFunctionPointer(CallingConvention.ThisCall)]
			public delegate ASIOError ASIOoutputReady(IntPtr _pUnknown);

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

		private IntPtr pASIOComObject;

		private IntPtr pinnedcallbacks;

		private ASIODriverVTable asioDriverVTable;

		private ASIODriver()
		{
		}

		public static string[] GetASIODriverNames()
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\ASIO");
			string[] result = new string[0];
			if (registryKey != null)
			{
				result = registryKey.GetSubKeyNames();
				registryKey.Close();
			}
			return result;
		}

		public static ASIODriver GetASIODriverByName(string name)
		{
			return GetASIODriverByGuid(new Guid((Registry.LocalMachine.OpenSubKey("SOFTWARE\\ASIO\\" + name) ?? throw new ArgumentException($"Driver Name {name} doesn't exist")).GetValue("CLSID").ToString()));
		}

		public static ASIODriver GetASIODriverByGuid(Guid guid)
		{
			ASIODriver aSIODriver = new ASIODriver();
			aSIODriver.initFromGuid(guid);
			return aSIODriver;
		}

		public bool init(IntPtr sysHandle)
		{
			return asioDriverVTable.init(pASIOComObject, sysHandle) == 1;
		}

		public string getDriverName()
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			asioDriverVTable.getDriverName(pASIOComObject, stringBuilder);
			return stringBuilder.ToString();
		}

		public int getDriverVersion()
		{
			return asioDriverVTable.getDriverVersion(pASIOComObject);
		}

		public string getErrorMessage()
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			asioDriverVTable.getErrorMessage(pASIOComObject, stringBuilder);
			return stringBuilder.ToString();
		}

		public void start()
		{
			handleException(asioDriverVTable.start(pASIOComObject), "start");
		}

		public ASIOError stop()
		{
			return asioDriverVTable.stop(pASIOComObject);
		}

		public void getChannels(out int numInputChannels, out int numOutputChannels)
		{
			handleException(asioDriverVTable.getChannels(pASIOComObject, out numInputChannels, out numOutputChannels), "getChannels");
		}

		public ASIOError GetLatencies(out int inputLatency, out int outputLatency)
		{
			return asioDriverVTable.getLatencies(pASIOComObject, out inputLatency, out outputLatency);
		}

		public void getBufferSize(out int minSize, out int maxSize, out int preferredSize, out int granularity)
		{
			handleException(asioDriverVTable.getBufferSize(pASIOComObject, out minSize, out maxSize, out preferredSize, out granularity), "getBufferSize");
		}

		public bool canSampleRate(double sampleRate)
		{
			ASIOError aSIOError = asioDriverVTable.canSampleRate(pASIOComObject, sampleRate);
			switch (aSIOError)
			{
			case ASIOError.ASE_NoClock:
				return false;
			case ASIOError.ASE_OK:
				return true;
			default:
				handleException(aSIOError, "canSampleRate");
				return false;
			}
		}

		public double getSampleRate()
		{
			handleException(asioDriverVTable.getSampleRate(pASIOComObject, out var sampleRate), "getSampleRate");
			return sampleRate;
		}

		public void setSampleRate(double sampleRate)
		{
			handleException(asioDriverVTable.setSampleRate(pASIOComObject, sampleRate), "setSampleRate");
		}

		public void getClockSources(out long clocks, int numSources)
		{
			handleException(asioDriverVTable.getClockSources(pASIOComObject, out clocks, numSources), "getClockSources");
		}

		public void setClockSource(int reference)
		{
			handleException(asioDriverVTable.setClockSource(pASIOComObject, reference), "setClockSources");
		}

		public void getSamplePosition(out long samplePos, ref ASIO64Bit timeStamp)
		{
			handleException(asioDriverVTable.getSamplePosition(pASIOComObject, out samplePos, ref timeStamp), "getSamplePosition");
		}

		public ASIOChannelInfo getChannelInfo(int channelNumber, bool trueForInputInfo)
		{
			ASIOChannelInfo info = new ASIOChannelInfo
			{
				channel = channelNumber,
				isInput = trueForInputInfo
			};
			handleException(asioDriverVTable.getChannelInfo(pASIOComObject, ref info), "getChannelInfo");
			return info;
		}

		public void createBuffers(IntPtr bufferInfos, int numChannels, int bufferSize, ref ASIOCallbacks callbacks)
		{
			pinnedcallbacks = Marshal.AllocHGlobal(Marshal.SizeOf((object)callbacks));
			Marshal.StructureToPtr((object)callbacks, pinnedcallbacks, false);
			handleException(asioDriverVTable.createBuffers(pASIOComObject, bufferInfos, numChannels, bufferSize, pinnedcallbacks), "createBuffers");
		}

		public ASIOError disposeBuffers()
		{
			ASIOError result = asioDriverVTable.disposeBuffers(pASIOComObject);
			Marshal.FreeHGlobal(pinnedcallbacks);
			return result;
		}

		public void controlPanel()
		{
			handleException(asioDriverVTable.controlPanel(pASIOComObject), "controlPanel");
		}

		public void future(int selector, IntPtr opt)
		{
			handleException(asioDriverVTable.future(pASIOComObject, selector, opt), "future");
		}

		public ASIOError outputReady()
		{
			return asioDriverVTable.outputReady(pASIOComObject);
		}

		public void ReleaseComASIODriver()
		{
			Marshal.Release(pASIOComObject);
		}

		private void handleException(ASIOError error, string methodName)
		{
			if (error != ASIOError.ASE_OK && error != ASIOError.ASE_SUCCESS)
			{
				throw new ASIOException($"Error code [{ASIOException.getErrorName(error)}] while calling ASIO method <{methodName}>, {getErrorMessage()}")
				{
					Error = error
				};
			}
		}

		private void initFromGuid(Guid ASIOGuid)
		{
			int num = CoCreateInstance(ref ASIOGuid, IntPtr.Zero, 1u, ref ASIOGuid, out pASIOComObject);
			if (num != 0)
			{
				throw new COMException("Unable to instantiate ASIO. Check if STAThread is set", num);
			}
			IntPtr ptr = Marshal.ReadIntPtr(pASIOComObject);
			asioDriverVTable = new ASIODriverVTable();
			FieldInfo[] fields = typeof(ASIODriverVTable).GetFields();
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo fieldInfo = fields[i];
				object delegateForFunctionPointer = Marshal.GetDelegateForFunctionPointer(Marshal.ReadIntPtr(ptr, (i + 3) * IntPtr.Size), fieldInfo.FieldType);
				fieldInfo.SetValue(asioDriverVTable, delegateForFunctionPointer);
			}
		}

		[DllImport("ole32.Dll")]
		private static extern int CoCreateInstance(ref Guid clsid, IntPtr inner, uint context, ref Guid uuid, out IntPtr rReturnedComObject);
	}
}
