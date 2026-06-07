using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AOT;
using UnityEngine;
using VideoKit.Internal;

namespace VideoKit
{
	public abstract class MediaDevice
	{
		public enum Location
		{
			Unknown = 0,
			Internal = 1,
			External = 2
		}

		public enum PermissionStatus
		{
			Unknown = 0,
			Denied = 2,
			Authorized = 3
		}

		protected readonly IntPtr handle;

		protected readonly GCHandle weakSelf;

		private readonly bool strong;

		private GCHandle streamHandle;

		public string uniqueId { get; protected set; }

		public string name { get; protected set; }

		public virtual Location location
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return Location.Unknown;
				}
				return (Location)(flags & (VideoKit.Internal.VideoKit.MediaDeviceFlags.Internal | VideoKit.Internal.VideoKit.MediaDeviceFlags.External));
			}
		}

		public virtual bool defaultForMediaType
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return false;
				}
				return flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.Default);
			}
		}

		public virtual bool running
		{
			get
			{
				if (handle.GetMediaDeviceIsRunning(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return false;
				}
				return result;
			}
		}

		public event Action? onDisconnected;

		public virtual void StopRunning()
		{
			if (running)
			{
				handle.StopRunning().Throw();
			}
			if (streamHandle != default(GCHandle))
			{
				streamHandle.Free();
			}
			streamHandle = default(GCHandle);
		}

		internal MediaDevice(IntPtr handle, bool strong = true)
		{
			this.handle = handle;
			this.strong = strong;
			weakSelf = GCHandle.Alloc(this, GCHandleType.Weak);
			StringBuilder stringBuilder = new StringBuilder(2048);
			handle.GetMediaDeviceUniqueID(stringBuilder, stringBuilder.Capacity);
			uniqueId = stringBuilder.ToString();
			stringBuilder.Clear();
			handle.GetMediaDeviceName(stringBuilder, stringBuilder.Capacity);
			name = stringBuilder.ToString();
			handle.SetDisconnectHandler(OnDeviceDisconnect, (IntPtr)weakSelf);
		}

		~MediaDevice()
		{
			if (strong)
			{
				handle.ReleaseMediaDevice();
			}
			weakSelf.Free();
		}

		protected virtual void StartRunning(Action<IntPtr> handler)
		{
			streamHandle = GCHandle.Alloc(handler, GCHandleType.Normal);
			try
			{
				handle.StartRunning(OnSampleBuffer, (IntPtr)streamHandle).Throw();
			}
			catch
			{
				streamHandle.Free();
				streamHandle = default(GCHandle);
				throw;
			}
		}

		protected static Task<PermissionStatus> CheckPermissions(VideoKit.Internal.VideoKit.PermissionType type, bool request)
		{
			TaskCompletionSource<PermissionStatus> taskCompletionSource = new TaskCompletionSource<PermissionStatus>();
			GCHandle gCHandle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				VideoKit.Internal.VideoKit.CheckPermissions(type, request, OnPermissionResult, (IntPtr)gCHandle).Throw();
			}
			catch (Exception exception)
			{
				gCHandle.Free();
				taskCompletionSource.SetException(exception);
			}
			return taskCompletionSource.Task;
		}

		public static implicit operator IntPtr(MediaDevice device)
		{
			return device.handle;
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaDeviceDisconnectHandler))]
		private static void OnDeviceDisconnect(IntPtr context, IntPtr _)
		{
			if (!VideoKit.Internal.VideoKit.IsAppDomainLoaded)
			{
				return;
			}
			try
			{
				(((GCHandle)context).Target as MediaDevice)?.onDisconnected?.Invoke();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaDevicePermissionResultHandler))]
		private static void OnPermissionResult(IntPtr context, PermissionStatus status)
		{
			if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
			{
				TaskCompletionSource<PermissionStatus> taskCompletionSource;
				try
				{
					GCHandle gCHandle = (GCHandle)context;
					taskCompletionSource = gCHandle.Target as TaskCompletionSource<PermissionStatus>;
					gCHandle.Free();
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					return;
				}
				taskCompletionSource?.SetResult(status);
			}
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.SampleBufferHandler))]
		private static void OnSampleBuffer(IntPtr context, IntPtr sampleBuffer)
		{
			if (!VideoKit.Internal.VideoKit.IsAppDomainLoaded)
			{
				return;
			}
			try
			{
				(((GCHandle)context).Target as Action<IntPtr>)?.Invoke(sampleBuffer);
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
