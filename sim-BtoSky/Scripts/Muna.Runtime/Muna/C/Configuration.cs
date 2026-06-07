using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Muna.C
{
	public sealed class Configuration : IDisposable
	{
		private readonly IntPtr configuration;

		public string tag
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(2048);
				configuration.GetConfigurationTag(stringBuilder, stringBuilder.Capacity).Throw();
				return stringBuilder.ToString();
			}
			set
			{
				configuration.SetConfigurationTag(value).Throw();
			}
		}

		public string token
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(2048);
				configuration.GetConfigurationToken(stringBuilder, stringBuilder.Capacity).Throw();
				return stringBuilder.ToString();
			}
			set
			{
				configuration.SetConfigurationToken(value).Throw();
			}
		}

		public Acceleration acceleration
		{
			get
			{
				if (configuration.GetConfigurationAcceleration(out var result).Throw() != Function.Status.Ok)
				{
					return Acceleration.Auto;
				}
				return result;
			}
			set
			{
				configuration.SetConfigurationAcceleration(value).Throw();
			}
		}

		public IntPtr device
		{
			get
			{
				if (configuration.GetConfigurationDevice(out var result).Throw() != Function.Status.Ok)
				{
					return (IntPtr)0;
				}
				return result;
			}
			set
			{
				configuration.SetConfigurationDevice(value).Throw();
			}
		}

		public static string ConfigurationId
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(2048);
				Function.GetConfigurationUniqueID(stringBuilder, stringBuilder.Capacity).Throw();
				return stringBuilder.ToString();
			}
		}

		public static string ClientId
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder(64);
				Function.GetConfigurationClientID(stringBuilder, stringBuilder.Capacity).Throw();
				return stringBuilder.ToString();
			}
		}

		public static Task InitializationTask => Task.CompletedTask;

		public Configuration()
		{
			Function.CreateConfiguration(out var intPtr).Throw();
			configuration = intPtr;
		}

		public Task AddResource(string type, string path)
		{
			try
			{
				configuration.AddConfigurationResource(type, path).Throw();
				return Task.CompletedTask;
			}
			catch (Exception exception)
			{
				return Task.FromException(exception);
			}
		}

		public void Dispose()
		{
			configuration.ReleaseConfiguration();
		}

		public static implicit operator IntPtr(Configuration configuration)
		{
			return configuration.configuration;
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr>))]
		private static void OnFunctionInitialized(IntPtr context)
		{
			GCHandle gCHandle = (GCHandle)context;
			TaskCompletionSource<bool> obj = gCHandle.Target as TaskCompletionSource<bool>;
			gCHandle.Free();
			obj?.SetResult(result: true);
		}

		[MonoPInvokeCallback(typeof(Action<IntPtr, Function.Status>))]
		private static void OnAddConfigurationResource(IntPtr context, Function.Status status)
		{
			GCHandle gCHandle = (GCHandle)context;
			TaskCompletionSource<bool> taskCompletionSource = gCHandle.Target as TaskCompletionSource<bool>;
			gCHandle.Free();
			try
			{
				status.Throw();
				taskCompletionSource?.SetResult(result: true);
			}
			catch (Exception exception)
			{
				taskCompletionSource?.SetException(exception);
			}
		}
	}
}
