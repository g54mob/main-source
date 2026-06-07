using System;
using DV.Utils;
using JetBrains.Annotations;
using UnityEngine;

namespace DV.Platform.GeForceNOW
{
	public class DVGeForceNOW : SingletonBehaviour<DVGeForceNOW>
	{
		private bool initialized;

		public static bool IsRunningInCloud { get; private set; }

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void StaticReload()
		{
			IsRunningInCloud = false;
		}

		protected override void Awake()
		{
			base.Awake();
			UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
			if (BuildInfo.BUILD_DESTINATION != "steam")
			{
				return;
			}
			try
			{
				int num = GfnRuntimeSdk.InitializeRuntimeSdk();
				if (GfnRuntimeSdk.IsError(num))
				{
					Debug.LogError($"Failed to initialize GFN SDK: {num}");
					return;
				}
				initialized = true;
				IsRunningInCloud = GfnRuntimeSdk.IsRunningInCloud();
			}
			catch (Exception exception)
			{
				Debug.LogError("Failed to initialize the GFN SDK! GeForce NOW integration will not be available.");
				Debug.LogException(exception);
			}
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (initialized)
			{
				GfnRuntimeSdk.ShutdownRuntimeSdk();
			}
		}

		[UsedImplicitly]
		public new static string AllowAutoCreate()
		{
			return "[DVGeForceNOW]";
		}
	}
}
