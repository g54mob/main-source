using System.Threading;
using System.Threading.Tasks;
using TwitchSDK;
using TwitchSDK.Interop;
using UnityEngine;

internal class UnityTwitch : TwitchSDKApi
{
	private class UnityPAL : ManagedPAL
	{
		private TaskCompletionSource<string> FileIOBasePathTCS = new TaskCompletionSource<string>();

		protected override string HttpUserAgent => "Twitch-Route-66-Unity";

		static UnityPAL()
		{
			TaskScheduler.UnobservedTaskException += delegate(object a, UnobservedTaskExceptionEventArgs exc)
			{
				if (exc.Exception.InnerException.GetType() == typeof(CoreLibraryException))
				{
					Debug.LogWarning("Unhandled Twitch Exception: " + exc.Exception.InnerException);
				}
			};
		}

		public void Start()
		{
			FileIOBasePathTCS.SetResult(Application.persistentDataPath);
		}

		protected override Task Log(LogRequest req)
		{
			switch (req.Level)
			{
			case LogLevel.Warning:
				Debug.LogWarning(req.Message);
				break;
			case LogLevel.Error:
				Debug.LogError(req.Message);
				break;
			default:
				Debug.Log(req.Message);
				break;
			case LogLevel.Debug:
				break;
			}
			return Task.CompletedTask;
		}

		protected override Task<string> GetFileIOBasePath(CancellationToken _)
		{
			return FileIOBasePathTCS.Task;
		}
	}

	private UnityPAL PAL;

	public UnityTwitch(string clientId, bool useESProxy)
		: base(clientId, useESProxy)
	{
	}

	public void InitializeInternally()
	{
		PAL.Start();
	}

	protected override PlatformAbstractionLayer CreatePAL()
	{
		return PAL = new UnityPAL();
	}
}
