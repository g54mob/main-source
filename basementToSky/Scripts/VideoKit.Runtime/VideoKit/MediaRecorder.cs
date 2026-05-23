using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AOT;
using UnityEngine;
using VideoKit.Internal;

namespace VideoKit
{
	public class MediaRecorder
	{
		public enum Format
		{
			MP4 = 0,
			HEVC = 1,
			WEBM = 2,
			GIF = 3,
			JPEG = 4,
			WAV = 5,
			AV1 = 6,
			ProRes4444 = 7
		}

		private readonly IntPtr handle;

		private static string directory = string.Empty;

		public virtual Format format
		{
			get
			{
				if (handle.GetMediaRecorderFormat(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return Format.MP4;
				}
				return result;
			}
		}

		public virtual int width
		{
			get
			{
				if (handle.GetMediaRecorderWidth(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public virtual int height
		{
			get
			{
				if (handle.GetMediaRecorderHeight(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public virtual int sampleRate
		{
			get
			{
				if (handle.GetMediaRecorderSampleRate(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public virtual int channelCount
		{
			get
			{
				if (handle.GetMediaRecorderChannelCount(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
		}

		public virtual bool canAppendPixelBuffer
		{
			get
			{
				bool result;
				return handle.CanAppendPixelBuffer(out result).Throw() == VideoKit.Internal.VideoKit.Status.Ok && result;
			}
		}

		public virtual bool canAppendAudioBuffer
		{
			get
			{
				bool result;
				return handle.CanAppendAudioBuffer(out result).Throw() == VideoKit.Internal.VideoKit.Status.Ok && result;
			}
		}

		public virtual void Append(PixelBuffer pixelBuffer)
		{
			handle.AppendPixelBuffer(pixelBuffer).Throw();
		}

		public virtual void Append(AudioBuffer audioBuffer)
		{
			handle.AppendSampleBuffer(audioBuffer).Throw();
		}

		public virtual Task<MediaAsset> FinishWriting()
		{
			TaskCompletionSource<MediaAsset> taskCompletionSource = new TaskCompletionSource<MediaAsset>();
			GCHandle gCHandle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				handle.FinishWriting(OnFinishWriting, (IntPtr)gCHandle).Throw();
			}
			catch (Exception exception)
			{
				gCHandle.Free();
				taskCompletionSource.SetException(exception);
			}
			return taskCompletionSource.Task;
		}

		public static async Task<MediaRecorder> Create(Format format, int width = 0, int height = 0, float frameRate = 0f, int sampleRate = 0, int channelCount = 0, int videoBitRate = 20000000, int keyframeInterval = 2, float compressionQuality = 0.8f, int audioBitRate = 64000, string? prefix = null)
		{
			await VideoKitClient.Instance.CheckSession();
			IntPtr recorder = IntPtr.Zero;
			return format switch
			{
				Format.MP4 => new MediaRecorder((VideoKit.Internal.VideoKit.CreateMP4Recorder(CreatePath(".mp4", prefix), width, height, frameRate, sampleRate, channelCount, videoBitRate, keyframeInterval, audioBitRate, out recorder).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? recorder : ((IntPtr)0)), 
				Format.HEVC => new MediaRecorder((VideoKit.Internal.VideoKit.CreateHEVCRecorder(CreatePath(".mp4", prefix), width, height, frameRate, sampleRate, channelCount, videoBitRate, keyframeInterval, audioBitRate, out recorder).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? recorder : ((IntPtr)0)), 
				Format.GIF => new MediaRecorder((VideoKit.Internal.VideoKit.CreateGIFRecorder(CreatePath(".gif", prefix), width, height, 1f / frameRate, out recorder).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? recorder : ((IntPtr)0)), 
				Format.WAV => new MediaRecorder((VideoKit.Internal.VideoKit.CreateWAVRecorder(CreatePath(".wav", prefix), sampleRate, channelCount, out recorder).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? recorder : ((IntPtr)0)), 
				Format.WEBM => new MediaRecorder((VideoKit.Internal.VideoKit.CreateWEBMRecorder(CreatePath(".webm", prefix), width, height, frameRate, sampleRate, channelCount, videoBitRate, keyframeInterval, audioBitRate, out recorder).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? recorder : ((IntPtr)0)), 
				Format.JPEG => new MediaRecorder((VideoKit.Internal.VideoKit.CreateJPEGRecorder(CreatePath(null, prefix), width, height, compressionQuality, out recorder).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? recorder : ((IntPtr)0)), 
				Format.AV1 => new MediaRecorder((VideoKit.Internal.VideoKit.CreateAV1Recorder(CreatePath(".mp4", prefix), width, height, frameRate, sampleRate, channelCount, videoBitRate, keyframeInterval, audioBitRate, out recorder).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? recorder : ((IntPtr)0)), 
				Format.ProRes4444 => new MediaRecorder((VideoKit.Internal.VideoKit.CreateProRes4444Recorder(CreatePath(".mov", prefix), width, height, sampleRate, channelCount, audioBitRate, out recorder).Throw() == VideoKit.Internal.VideoKit.Status.Ok) ? recorder : ((IntPtr)0)), 
				_ => throw new InvalidOperationException($"Cannot create media recorder because format is not supported: {format}"), 
			};
		}

		public static bool IsFormatSupported(Format format)
		{
			return VideoKit.Internal.VideoKit.IsMediaRecorderFormatSupported(format) == VideoKit.Internal.VideoKit.Status.Ok;
		}

		protected MediaRecorder(IntPtr handle)
		{
			this.handle = handle;
		}

		public static implicit operator IntPtr(MediaRecorder recorder)
		{
			return recorder.handle;
		}

		public static implicit operator Action<PixelBuffer>(MediaRecorder recorder)
		{
			return recorder.Append;
		}

		public static implicit operator Action<AudioBuffer>(MediaRecorder recorder)
		{
			return recorder.Append;
		}

		protected static string CreatePath(string? extension = null, string? prefix = null)
		{
			string obj = ((!string.IsNullOrEmpty(prefix)) ? Path.Combine(directory, prefix) : directory);
			Directory.CreateDirectory(obj);
			string text = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fff");
			string path = "recording_" + text + (extension ?? string.Empty);
			return Path.Combine(obj, path);
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
		private static void OnInitialize()
		{
			directory = (Application.isEditor ? Directory.GetCurrentDirectory() : Application.persistentDataPath);
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaAssetHandler))]
		private static void OnFinishWriting(IntPtr context, IntPtr asset)
		{
			if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
			{
				TaskCompletionSource<MediaAsset> taskCompletionSource;
				try
				{
					GCHandle gCHandle = (GCHandle)context;
					taskCompletionSource = gCHandle.Target as TaskCompletionSource<MediaAsset>;
					gCHandle.Free();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					return;
				}
				if (asset != IntPtr.Zero)
				{
					taskCompletionSource?.SetResult(new MediaAsset(asset));
				}
				else
				{
					taskCompletionSource?.SetException(new Exception("Recorder failed to finish writing"));
				}
			}
		}
	}
}
