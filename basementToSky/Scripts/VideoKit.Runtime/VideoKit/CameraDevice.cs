using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AOT;
using UnityEngine;
using VideoKit.Internal;

namespace VideoKit
{
	public sealed class CameraDevice : MediaDevice
	{
		public enum ExposureMode
		{
			Continuous = 0,
			Locked = 1,
			Manual = 2
		}

		public enum FlashMode
		{
			Off = 0,
			On = 1,
			Auto = 2
		}

		public enum FocusMode
		{
			Continuous = 0,
			Locked = 1
		}

		public enum TorchMode
		{
			Off = 0,
			Maximum = 100
		}

		public enum VideoStabilizationMode
		{
			Off = 0,
			Standard = 1
		}

		public enum WhiteBalanceMode
		{
			Continuous = 0,
			Locked = 1
		}

		public bool frontFacing
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok)
				{
					return flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.FrontFacing);
				}
				return false;
			}
		}

		public bool flashSupported
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok)
				{
					return flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.Flash);
				}
				return false;
			}
		}

		public bool torchSupported
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok)
				{
					return flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.Torch);
				}
				return false;
			}
		}

		public bool exposurePointSupported
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok)
				{
					return flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.ExposurePoint);
				}
				return false;
			}
		}

		public bool focusPointSupported
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok)
				{
					return flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.FocusPoint);
				}
				return false;
			}
		}

		public bool depthStreamingSupported
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok)
				{
					return flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.Depth);
				}
				return false;
			}
		}

		public (float width, float height) fieldOfView
		{
			get
			{
				if (handle.GetCameraDeviceFieldOfView(out var x, out var y) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return default((float, float));
				}
				return (width: x, height: y);
			}
		}

		public (float min, float max) exposureBiasRange
		{
			get
			{
				if (handle.GetCameraDeviceExposureBiasRange(out var min, out var max) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return default((float, float));
				}
				return (min: min, max: max);
			}
		}

		public (float min, float max) exposureDurationRange
		{
			get
			{
				if (handle.GetCameraDeviceExposureDurationRange(out var min, out var max) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return default((float, float));
				}
				return (min: min, max: max);
			}
		}

		public (float min, float max) ISORange
		{
			get
			{
				if (handle.GetCameraDeviceISORange(out var min, out var max) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return default((float, float));
				}
				return (min: min, max: max);
			}
		}

		public (float min, float max) zoomRange
		{
			get
			{
				if (handle.GetCameraDeviceZoomRange(out var min, out var max) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return (min: 1f, max: 1f);
				}
				return (min: min, max: max);
			}
		}

		public (int width, int height) previewResolution
		{
			get
			{
				if (handle.GetCameraDevicePreviewResolution(out var width, out var height).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return default((int, int));
				}
				return (width: width, height: height);
			}
			set
			{
				handle.SetCameraDevicePreviewResolution(value.width, value.height);
			}
		}

		public (int width, int height) photoResolution
		{
			get
			{
				if (handle.GetCameraDevicePhotoResolution(out var width, out var height) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return default((int, int));
				}
				return (width: width, height: height);
			}
			set
			{
				handle.SetCameraDevicePhotoResolution(value.width, value.height);
			}
		}

		public float frameRate
		{
			get
			{
				if (handle.GetCameraDeviceFrameRate(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0f;
				}
				return result;
			}
			set
			{
				handle.SetCameraDeviceFrameRate(value);
			}
		}

		public ExposureMode exposureMode
		{
			get
			{
				if (handle.GetCameraDeviceExposureMode(out var mode) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return ExposureMode.Continuous;
				}
				return mode;
			}
			set
			{
				handle.SetCameraDeviceExposureMode(value).Throw();
			}
		}

		public float exposureBias
		{
			get
			{
				if (handle.GetCameraDeviceExposureBias(out var bias) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0f;
				}
				return bias;
			}
			set
			{
				handle.SetCameraDeviceExposureBias(value).Throw();
			}
		}

		public float exposureDuration
		{
			get
			{
				if (handle.GetCameraDeviceExposureDuration(out var duration) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0f;
				}
				return duration;
			}
		}

		public float ISO
		{
			get
			{
				if (handle.GetCameraDeviceISO(out var ISO) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0f;
				}
				return ISO;
			}
		}

		public FlashMode flashMode
		{
			get
			{
				if (handle.GetCameraDeviceFlashMode(out var mode) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return FlashMode.Off;
				}
				return mode;
			}
			set
			{
				handle.SetCameraDeviceFlashMode(value).Throw();
			}
		}

		public FocusMode focusMode
		{
			get
			{
				if (handle.GetCameraDeviceFocusMode(out var mode) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return FocusMode.Continuous;
				}
				return mode;
			}
			set
			{
				handle.SetCameraDeviceFocusMode(value).Throw();
			}
		}

		public TorchMode torchMode
		{
			get
			{
				if (handle.GetCameraDeviceTorchMode(out var mode) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return TorchMode.Off;
				}
				return mode;
			}
			set
			{
				handle.SetCameraDeviceTorchMode(value).Throw();
			}
		}

		public WhiteBalanceMode whiteBalanceMode
		{
			get
			{
				if (handle.GetCameraDeviceWhiteBalanceMode(out var mode) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return WhiteBalanceMode.Continuous;
				}
				return mode;
			}
			set
			{
				handle.SetCameraDeviceWhiteBalanceMode(value).Throw();
			}
		}

		public VideoStabilizationMode videoStabilizationMode
		{
			get
			{
				if (handle.GetCameraDeviceVideoStabilizationMode(out var mode) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return VideoStabilizationMode.Off;
				}
				return mode;
			}
			set
			{
				handle.SetCameraDeviceVideoStabilizationMode(value).Throw();
			}
		}

		public float zoomRatio
		{
			get
			{
				if (handle.GetCameraDeviceZoomRatio(out var zoom) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0f;
				}
				return zoom;
			}
			set
			{
				handle.SetCameraDeviceZoomRatio(value).Throw();
			}
		}

		private int priority
		{
			get
			{
				int num = 0;
				if (!defaultForMediaType)
				{
					num++;
				}
				if (location == Location.External)
				{
					num += 10;
				}
				if (location == Location.Unknown)
				{
					num += 100;
				}
				return num;
			}
		}

		public bool IsExposureModeSupported(ExposureMode mode)
		{
			VideoKit.Internal.VideoKit.MediaDeviceFlags flags;
			VideoKit.Internal.VideoKit.MediaDeviceFlags flags2;
			VideoKit.Internal.VideoKit.MediaDeviceFlags flags3;
			return mode switch
			{
				ExposureMode.Continuous => handle.GetMediaDeviceFlags(out flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.ExposureContinuous), 
				ExposureMode.Locked => handle.GetMediaDeviceFlags(out flags2).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flags2.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.ExposureLock), 
				ExposureMode.Manual => handle.GetMediaDeviceFlags(out flags3).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flags3.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.ExposureManual), 
				_ => false, 
			};
		}

		public bool IsFocusModeSupported(FocusMode mode)
		{
			VideoKit.Internal.VideoKit.MediaDeviceFlags flags;
			VideoKit.Internal.VideoKit.MediaDeviceFlags flags2;
			return mode switch
			{
				FocusMode.Continuous => handle.GetMediaDeviceFlags(out flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.FocusContinuous), 
				FocusMode.Locked => handle.GetMediaDeviceFlags(out flags2).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flags2.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.FocusLock), 
				_ => false, 
			};
		}

		public bool IsWhiteBalanceModeSupported(WhiteBalanceMode mode)
		{
			VideoKit.Internal.VideoKit.MediaDeviceFlags flags;
			VideoKit.Internal.VideoKit.MediaDeviceFlags flags2;
			return mode switch
			{
				WhiteBalanceMode.Continuous => handle.GetMediaDeviceFlags(out flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.WhiteBalanceContinuous), 
				WhiteBalanceMode.Locked => handle.GetMediaDeviceFlags(out flags2).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flags2.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.WhiteBalanceLock), 
				_ => false, 
			};
		}

		public bool IsVideoStabilizationModeSupported(VideoStabilizationMode mode)
		{
			VideoKit.Internal.VideoKit.MediaDeviceFlags flags;
			return mode switch
			{
				VideoStabilizationMode.Off => true, 
				VideoStabilizationMode.Standard => handle.GetMediaDeviceFlags(out flags).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.VideoStabilization), 
				_ => false, 
			};
		}

		public void SetExposureDuration(float duration, float ISO)
		{
			handle.SetCameraDeviceExposureDuration(duration, ISO).Throw();
		}

		public void SetExposurePoint(float x, float y)
		{
			handle.SetCameraDeviceExposurePoint(x, y).Throw();
		}

		public void SetFocusPoint(float x, float y)
		{
			handle.SetCameraDeviceFocusPoint(x, y).Throw();
		}

		public void StartRunning(Action<PixelBuffer> handler)
		{
			StartRunning(delegate(IntPtr sampleBuffer)
			{
				handler(new PixelBuffer(sampleBuffer));
			});
		}

		public void CapturePhoto(Action<PixelBuffer> handler)
		{
			GCHandle gCHandle = GCHandle.Alloc(handler, GCHandleType.Normal);
			handle.CapturePhoto(OnCapturePhoto, (IntPtr)gCHandle).Throw();
		}

		public static Task<PermissionStatus> CheckPermissions(bool request = true)
		{
			return MediaDevice.CheckPermissions(VideoKit.Internal.VideoKit.PermissionType.Camera, request);
		}

		public static async Task<CameraDevice[]> Discover()
		{
			await VideoKitClient.Instance.CheckSession();
			TaskCompletionSource<CameraDevice[]> taskCompletionSource = new TaskCompletionSource<CameraDevice[]>();
			GCHandle handle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				VideoKit.Internal.VideoKit.DiscoverCameraDevices(OnDiscoverDevices, (IntPtr)handle).Throw();
				return await taskCompletionSource.Task;
			}
			catch
			{
				handle.Free();
				throw;
			}
		}

		internal CameraDevice(IntPtr device, bool strong = true)
			: base(device, strong)
		{
		}

		public override string ToString()
		{
			return "CameraDevice(uniqueId=\"" + base.uniqueId + "\", name=\"" + base.name + "\")";
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaDeviceDiscoveryHandler))]
		private unsafe static void OnDiscoverDevices(IntPtr context, IntPtr devices, int count)
		{
			try
			{
				if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
				{
					GCHandle gCHandle = (GCHandle)context;
					TaskCompletionSource<CameraDevice[]> obj = gCHandle.Target as TaskCompletionSource<CameraDevice[]>;
					gCHandle.Free();
					CameraDevice[] result = (from idx in Enumerable.Range(0, count)
						select ((IntPtr*)(void*)devices)[idx] into device
						select new CameraDevice(device) into device
						orderby device.priority
						select device).ToArray();
					obj?.SetResult(result);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.SampleBufferHandler))]
		private static void OnCapturePhoto(IntPtr context, IntPtr sampleBuffer)
		{
			try
			{
				if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
				{
					GCHandle gCHandle = (GCHandle)context;
					Action<PixelBuffer> obj = gCHandle.Target as Action<PixelBuffer>;
					gCHandle.Free();
					obj?.Invoke(new PixelBuffer(sampleBuffer));
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}
}
