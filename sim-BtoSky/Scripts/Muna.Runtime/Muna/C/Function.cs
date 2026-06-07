using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Muna.C
{
	internal static class Function
	{
		public enum Status
		{
			Ok = 0,
			InvalidArgument = 1,
			InvalidOperation = 2,
			NotImplemented = 3
		}

		public const string Assembly = "Function";

		[DllImport("Function", EntryPoint = "FXNValueRelease")]
		public static extern Status ReleaseValue(this IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueGetData")]
		public static extern Status GetValueData(this IntPtr value, out IntPtr data);

		[DllImport("Function", EntryPoint = "FXNValueGetType")]
		public static extern Status GetValueType(this IntPtr value, out Dtype type);

		[DllImport("Function", EntryPoint = "FXNValueGetDimensions")]
		public static extern Status GetValueDimensions(this IntPtr value, out int dimensions);

		[DllImport("Function", EntryPoint = "FXNValueGetShape")]
		public static extern Status GetValueShape(this IntPtr value, [Out] int[] shape, int shapeLen);

		[DllImport("Function", EntryPoint = "FXNValueCreateArray")]
		public unsafe static extern Status CreateArrayValue(void* data, [In] int[]? shape, int dims, Dtype dtype, Value.Flags flags, out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueCreateString")]
		public static extern Status CreateStringValue([MarshalAs(UnmanagedType.LPUTF8Str)] string data, out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueCreateList")]
		public static extern Status CreateListValue([MarshalAs(UnmanagedType.LPUTF8Str)] string data, out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueCreateDict")]
		public static extern Status CreateDictValue([MarshalAs(UnmanagedType.LPUTF8Str)] string data, out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueCreateImage")]
		public unsafe static extern Status CreateImageValue(byte* pixelBuffer, int width, int height, int channels, Value.Flags flags, out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueCreateBinary")]
		public static extern Status CreateBinaryValue([In] byte[] buffer, int bufferLen, Value.Flags flags, out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueCreateNull")]
		public static extern Status CreateNullValue(out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueCreateImageList")]
		public unsafe static extern Status CreateImageListValue([In] byte*[] pixelBuffers, int* widths, int* heights, int* channels, int count, Value.Flags flags, out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueCreateSerializedValue")]
		public static extern Status CreateSerializedValue(IntPtr value, [MarshalAs(UnmanagedType.LPUTF8Str)] string? mime, out IntPtr result);

		[DllImport("Function", EntryPoint = "FXNValueCreateFromSerializedValue")]
		public static extern Status CreateValueFromSerializedValue(IntPtr value, [MarshalAs(UnmanagedType.LPUTF8Str)] string mime, out IntPtr result);

		[DllImport("Function", EntryPoint = "FXNValueMapCreate")]
		public static extern Status CreateValueMap(out IntPtr map);

		[DllImport("Function", EntryPoint = "FXNValueMapRelease")]
		public static extern Status ReleaseValueMap(this IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueMapGetSize")]
		public static extern Status GetValueMapSize(this IntPtr map, out int size);

		[DllImport("Function", EntryPoint = "FXNValueMapGetKey")]
		public static extern Status GetValueMapKey(this IntPtr map, int index, [Out][MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder key, int size);

		[DllImport("Function", EntryPoint = "FXNValueMapGetValue")]
		public static extern Status GetValueMapValue(this IntPtr map, [MarshalAs(UnmanagedType.LPUTF8Str)] string key, out IntPtr value);

		[DllImport("Function", EntryPoint = "FXNValueMapSetValue")]
		public static extern Status SetValueMapValue(this IntPtr map, [MarshalAs(UnmanagedType.LPUTF8Str)] string key, IntPtr value);

		[DllImport("Function", EntryPoint = "FXNConfigurationGetUniqueID")]
		public static extern Status GetConfigurationUniqueID([Out][MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder identifier, int size);

		[DllImport("Function", EntryPoint = "FXNConfigurationGetClientID")]
		public static extern Status GetConfigurationClientID([Out][MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder identifier, int size);

		[DllImport("Function", EntryPoint = "FXNConfigurationCreate")]
		public static extern Status CreateConfiguration(out IntPtr configuration);

		[DllImport("Function", EntryPoint = "FXNConfigurationRelease")]
		public static extern Status ReleaseConfiguration(this IntPtr configuration);

		[DllImport("Function", EntryPoint = "FXNConfigurationGetTag")]
		public static extern Status GetConfigurationTag(this IntPtr configuration, [Out][MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder tag, int size);

		[DllImport("Function", EntryPoint = "FXNConfigurationSetTag")]
		public static extern Status SetConfigurationTag(this IntPtr configuration, [MarshalAs(UnmanagedType.LPUTF8Str)] string? tag);

		[DllImport("Function", EntryPoint = "FXNConfigurationGetToken")]
		public static extern Status GetConfigurationToken(this IntPtr configuration, [Out][MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder token, int size);

		[DllImport("Function", EntryPoint = "FXNConfigurationSetToken")]
		public static extern Status SetConfigurationToken(this IntPtr configuration, [MarshalAs(UnmanagedType.LPUTF8Str)] string? token);

		[DllImport("Function", EntryPoint = "FXNConfigurationGetAcceleration")]
		public static extern Status GetConfigurationAcceleration(this IntPtr configuration, out Acceleration acceleration);

		[DllImport("Function", EntryPoint = "FXNConfigurationSetAcceleration")]
		public static extern Status SetConfigurationAcceleration(this IntPtr configuration, Acceleration acceleration);

		[DllImport("Function", EntryPoint = "FXNConfigurationSetDevice")]
		public static extern Status SetConfigurationDevice(this IntPtr configuration, IntPtr device);

		[DllImport("Function", EntryPoint = "FXNConfigurationGetDevice")]
		public static extern Status GetConfigurationDevice(this IntPtr configuration, out IntPtr device);

		[DllImport("Function", EntryPoint = "FXNConfigurationAddResource")]
		public static extern Status AddConfigurationResource(this IntPtr configuration, [MarshalAs(UnmanagedType.LPUTF8Str)] string type, [MarshalAs(UnmanagedType.LPUTF8Str)] string path);

		[DllImport("Function", EntryPoint = "FXNPredictionRelease")]
		public static extern Status ReleasePrediction(this IntPtr prediction);

		[DllImport("Function", EntryPoint = "FXNPredictionGetID")]
		public static extern Status GetPredictionID(this IntPtr prediction, [Out][MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder id, int size);

		[DllImport("Function", EntryPoint = "FXNPredictionGetLatency")]
		public static extern Status GetPredictionLatency(this IntPtr prediction, out double latency);

		[DllImport("Function", EntryPoint = "FXNPredictionGetResults")]
		public static extern Status GetPredictionResults(this IntPtr prediction, out IntPtr map);

		[DllImport("Function", EntryPoint = "FXNPredictionGetError")]
		public static extern Status GetPredictionError(this IntPtr prediction, [Out][MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder error, int size);

		[DllImport("Function", EntryPoint = "FXNPredictionGetLogs")]
		public static extern Status GetPredictionLogs(this IntPtr prediction, [Out][MarshalAs(UnmanagedType.LPUTF8Str)] StringBuilder logs, int size);

		[DllImport("Function", EntryPoint = "FXNPredictionGetLogLength")]
		public static extern Status GetPredictionLogLength(this IntPtr prediction, out int size);

		[DllImport("Function", EntryPoint = "FXNPredictionStreamRelease")]
		public static extern Status ReleasePredictionStream(this IntPtr stream);

		[DllImport("Function", EntryPoint = "FXNPredictionStreamReadNext")]
		public static extern Status ReadNextPrediction(this IntPtr stream, out IntPtr prediction);

		[DllImport("Function", EntryPoint = "FXNPredictorCreate")]
		public static extern Status CreatePredictor(IntPtr configuration, out IntPtr predictor);

		[DllImport("Function", EntryPoint = "FXNPredictorRelease")]
		public static extern Status ReleasePredictor(this IntPtr predictor);

		[DllImport("Function", EntryPoint = "FXNPredictorCreatePrediction")]
		public static extern Status CreatePrediction(this IntPtr predictor, IntPtr inputs, out IntPtr prediction);

		[DllImport("Function", EntryPoint = "FXNPredictorStreamPrediction")]
		public static extern Status StreamPrediction(this IntPtr predictor, IntPtr inputs, out IntPtr stream);

		[DllImport("Function", EntryPoint = "FXNGetVersion")]
		public static extern IntPtr GetVersion();

		public static Status Throw(this Status status)
		{
			return status switch
			{
				Status.Ok => status, 
				Status.InvalidArgument => throw new ArgumentException(), 
				Status.InvalidOperation => throw new InvalidOperationException(), 
				Status.NotImplemented => throw new NotImplementedException(), 
				_ => throw new InvalidOperationException(), 
			};
		}
	}
}
