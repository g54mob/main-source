using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AOT;
using UnityEngine;
using VideoKit.Internal;

namespace VideoKit
{
	public sealed class MultiCameraDevice : MediaDevice
	{
		public readonly CameraDevice[] cameras;

		public float? hardwareCost
		{
			get
			{
				float cost;
				return (handle.GetMultiCameraDeviceHardwareCost(out cost) == VideoKit.Internal.VideoKit.Status.Ok) ? cost : 0f;
			}
		}

		public float? systemPressureCost
		{
			get
			{
				float cost;
				return (handle.GetMultiCameraDeviceSystemPressureCost(out cost) == VideoKit.Internal.VideoKit.Status.Ok) ? cost : 0f;
			}
		}

		public event Action? onSystemPressureChange;

		public bool IsRunning(CameraDevice camera)
		{
			bool flag;
			return handle.GetMultiCameraDeviceIsRunning(camera, out flag).Throw() == VideoKit.Internal.VideoKit.Status.Ok && flag;
		}

		public void StartRunning(Action<CameraDevice, PixelBuffer> handler)
		{
			StartRunning(delegate(IntPtr sampleBuffer)
			{
				sampleBuffer.GetMultiCameraPixelBufferCamera(out var rawCamera).Throw();
				CameraDevice arg = cameras.First((CameraDevice cam) => cam == rawCamera);
				PixelBuffer arg2 = new PixelBuffer(sampleBuffer);
				handler(arg, arg2);
			});
		}

		public void StartRunning(CameraDevice camera)
		{
			handle.StartRunning(camera).Throw();
		}

		public void StopRunning(CameraDevice camera)
		{
			handle.StopRunning(camera).Throw();
		}

		public static Task<PermissionStatus> CheckPermissions(bool request = true)
		{
			return CameraDevice.CheckPermissions(request);
		}

		public static async Task<MultiCameraDevice[]> Discover()
		{
			await VideoKitClient.Instance.CheckSession();
			TaskCompletionSource<MultiCameraDevice[]> taskCompletionSource = new TaskCompletionSource<MultiCameraDevice[]>();
			GCHandle handle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				VideoKit.Internal.VideoKit.DiscoverMultiCameraDevices(OnDiscoverDevices, (IntPtr)handle).Throw();
				return await taskCompletionSource.Task;
			}
			catch
			{
				handle.Free();
				throw;
			}
		}

		internal MultiCameraDevice(IntPtr device)
			: base(device)
		{
			device.GetMultiCameraDeviceCameraCount(out var count).Throw();
			cameras = (from idx in Enumerable.Range(0, count)
				select (device.GetMultiCameraDeviceCamera(idx, out var camera).Throw() != VideoKit.Internal.VideoKit.Status.Ok) ? ((IntPtr)0) : camera into camera
				select new CameraDevice(camera, strong: false)).ToArray();
			device.SetMultiCameraDeviceSystemPressureChangeHandler(OnSystemPressureChange, (IntPtr)weakSelf);
		}

		public override string ToString()
		{
			return "MultiCameraDevice(uniqueId=\"" + base.uniqueId + "\", name=\"" + base.name + "\")";
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaDeviceDiscoveryHandler))]
		private unsafe static void OnDiscoverDevices(IntPtr context, IntPtr devices, int count)
		{
			try
			{
				if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
				{
					GCHandle gCHandle = (GCHandle)context;
					TaskCompletionSource<MultiCameraDevice[]> obj = gCHandle.Target as TaskCompletionSource<MultiCameraDevice[]>;
					gCHandle.Free();
					MultiCameraDevice[] result = (from idx in Enumerable.Range(0, count)
						select ((IntPtr*)(void*)devices)[idx] into device
						select new MultiCameraDevice(device)).ToArray();
					obj?.SetResult(result);
				}
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MultiCameraDeviceSystemPressureHandler))]
		private static void OnSystemPressureChange(IntPtr context)
		{
			(((GCHandle)context).Target as MultiCameraDevice)?.onSystemPressureChange?.Invoke();
		}
	}
}
