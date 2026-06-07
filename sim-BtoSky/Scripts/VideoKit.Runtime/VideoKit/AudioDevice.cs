using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using AOT;
using UnityEngine;
using VideoKit.Internal;

namespace VideoKit
{
	public sealed class AudioDevice : MediaDevice
	{
		public bool echoCancellationSupported
		{
			get
			{
				if (handle.GetMediaDeviceFlags(out var flags).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return false;
				}
				return flags.HasFlag(VideoKit.Internal.VideoKit.MediaDeviceFlags.EchoCancellation);
			}
		}

		public bool echoCancellation
		{
			get
			{
				if (handle.GetAudioDeviceEchoCancellation(out var result) != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return false;
				}
				return result;
			}
			set
			{
				handle.SetAudioDeviceEchoCancellation(value);
			}
		}

		public int sampleRate
		{
			get
			{
				if (handle.GetAudioDeviceSampleRate(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
			set
			{
				handle.SetAudioDeviceSampleRate(value).Throw();
			}
		}

		public int channelCount
		{
			get
			{
				if (handle.GetAudioDeviceChannelCount(out var result).Throw() != VideoKit.Internal.VideoKit.Status.Ok)
				{
					return 0;
				}
				return result;
			}
			set
			{
				handle.SetAudioDeviceChannelCount(value).Throw();
			}
		}

		private int priority
		{
			get
			{
				Location location = this.location;
				if (!defaultForMediaType)
				{
					return location switch
					{
						Location.External => -1, 
						Location.Internal => 0, 
						Location.Unknown => 1, 
						_ => 2, 
					};
				}
				return -1000;
			}
		}

		public void StartRunning(Action<AudioBuffer> handler)
		{
			StartRunning(delegate(IntPtr sampleBuffer)
			{
				handler(new AudioBuffer(sampleBuffer));
			});
		}

		public static Task<PermissionStatus> CheckPermissions(bool request = true)
		{
			return MediaDevice.CheckPermissions(VideoKit.Internal.VideoKit.PermissionType.Microphone, request);
		}

		public static async Task<AudioDevice[]> Discover(bool configureAudioSession = true)
		{
			await VideoKitClient.Instance.CheckSession();
			if (configureAudioSession)
			{
				VideoKit.Internal.VideoKit.ConfigureAudioSession();
			}
			TaskCompletionSource<AudioDevice[]> taskCompletionSource = new TaskCompletionSource<AudioDevice[]>();
			GCHandle handle = GCHandle.Alloc(taskCompletionSource, GCHandleType.Normal);
			try
			{
				VideoKit.Internal.VideoKit.DiscoverAudioDevices(OnDiscoverDevices, (IntPtr)handle).Throw();
				return await taskCompletionSource.Task;
			}
			catch
			{
				handle.Free();
				throw;
			}
		}

		internal AudioDevice(IntPtr device, bool strong = true)
			: base(device, strong)
		{
		}

		public override string ToString()
		{
			return "AudioDevice(uniqueId=\"" + base.uniqueId + "\", name=\"" + base.name + "\")";
		}

		[MonoPInvokeCallback(typeof(VideoKit.Internal.VideoKit.MediaDeviceDiscoveryHandler))]
		private unsafe static void OnDiscoverDevices(IntPtr context, IntPtr devices, int count)
		{
			try
			{
				if (VideoKit.Internal.VideoKit.IsAppDomainLoaded)
				{
					GCHandle gCHandle = (GCHandle)context;
					TaskCompletionSource<AudioDevice[]> obj = gCHandle.Target as TaskCompletionSource<AudioDevice[]>;
					gCHandle.Free();
					AudioDevice[] result = (from idx in Enumerable.Range(0, count)
						select ((IntPtr*)(void*)devices)[idx] into device
						select new AudioDevice(device) into device
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
	}
}
