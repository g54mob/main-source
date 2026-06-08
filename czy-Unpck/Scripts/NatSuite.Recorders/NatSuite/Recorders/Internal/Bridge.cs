using System;
using System.Runtime.InteropServices;

namespace NatSuite.Recorders.Internal
{
	public static class Bridge
	{
		public unsafe delegate void RecordingHandler(void* context, char* path);

		private const string Assembly = "NatCorder";

		[DllImport("NatCorder", EntryPoint = "NCCreateMP4Recorder")]
		public static extern void CreateMP4Recorder([MarshalAs(UnmanagedType.LPStr)] string path, int width, int height, float frameRate, int sampleRate, int channelCount, int videoBitrate, int keyframeInterval, int audioBitRate, out IntPtr recorder);

		[DllImport("NatCorder", EntryPoint = "NCCreateHEVCRecorder")]
		public static extern void CreateHEVCRecorder([MarshalAs(UnmanagedType.LPStr)] string path, int width, int height, float frameRate, int sampleRate, int channelCount, int videoBitRate, int keyframeInterval, int audioBitRate, out IntPtr recorder);

		[DllImport("NatCorder", EntryPoint = "NCCreateGIFRecorder")]
		public static extern void CreateGIFRecorder([MarshalAs(UnmanagedType.LPStr)] string path, int width, int height, float frameDuration, out IntPtr recorder);

		[DllImport("NatCorder", EntryPoint = "NCRecorderFrameSize")]
		public static extern void FrameSize(this IntPtr recorder, out int width, out int height);

		[DllImport("NatCorder", EntryPoint = "NCRecorderCommitFrame")]
		public unsafe static extern void CommitFrame(this IntPtr recorder, void* pixelBuffer, long timestamp);

		[DllImport("NatCorder", EntryPoint = "NCRecorderCommitSamples")]
		public unsafe static extern void CommitSamples(this IntPtr recorder, float* sampleBuffer, int sampleCount, long timestamp);

		[DllImport("NatCorder", EntryPoint = "NCRecorderFinishWriting")]
		public unsafe static extern void FinishWriting(this IntPtr recorder, RecordingHandler callback, void* context);
	}
}
