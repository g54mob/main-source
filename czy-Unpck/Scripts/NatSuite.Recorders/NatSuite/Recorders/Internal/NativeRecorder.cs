using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AOT;

namespace NatSuite.Recorders.Internal
{
	public abstract class NativeRecorder : IMediaRecorder
	{
		private readonly IntPtr recorder;

		public virtual (int width, int height) frameSize
		{
			get
			{
				recorder.FrameSize(out var width, out var height);
				return (width: width, height: height);
			}
		}

		public unsafe virtual void CommitFrame<T>(T[] pixelBuffer, long timestamp) where T : unmanaged
		{
			fixed (T* nativeBuffer = pixelBuffer)
			{
				CommitFrame(nativeBuffer, timestamp);
			}
		}

		public unsafe virtual void CommitFrame(void* nativeBuffer, long timestamp)
		{
			recorder.CommitFrame(nativeBuffer, timestamp);
		}

		public unsafe virtual void CommitSamples(float[] sampleBuffer, long timestamp)
		{
			fixed (float* nativeBuffer = sampleBuffer)
			{
				CommitSamples(nativeBuffer, sampleBuffer.Length, timestamp);
			}
		}

		public unsafe virtual void CommitSamples(float* nativeBuffer, int sampleCount, long timestamp)
		{
			recorder.CommitSamples(nativeBuffer, sampleCount, timestamp);
		}

		public unsafe virtual Task<string> FinishWriting()
		{
			TaskCompletionSource<string> taskCompletionSource = new TaskCompletionSource<string>();
			Bridge.FinishWriting(context: (void*)(IntPtr)GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal), recorder: recorder, callback: OnRecording);
			return taskCompletionSource.Task;
		}

		protected NativeRecorder(IntPtr recorder)
		{
			this.recorder = recorder;
		}

		[MonoPInvokeCallback(typeof(Bridge.RecordingHandler))]
		private unsafe static void OnRecording(void* context, char* path)
		{
			GCHandle gCHandle = (GCHandle)(IntPtr)context;
			TaskCompletionSource<string> taskCompletionSource = gCHandle.Target as TaskCompletionSource<string>;
			gCHandle.Free();
			if (path != null)
			{
				taskCompletionSource.SetResult(Marshal.PtrToStringAnsi((IntPtr)path));
			}
			else
			{
				taskCompletionSource.SetException(new Exception("Recorder failed to finish writing"));
			}
		}
	}
}
