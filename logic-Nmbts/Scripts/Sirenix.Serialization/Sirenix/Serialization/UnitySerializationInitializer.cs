using Sirenix.Utilities;
using UnityEngine;

namespace Sirenix.Serialization
{
	public static class UnitySerializationInitializer
	{
		private static readonly object LOCK = new object();

		private static bool initialized = false;

		public static bool Initialized
		{
			get
			{
				return initialized;
			}
		}

		public static RuntimePlatform CurrentPlatform { get; private set; }

		public static void Initialize()
		{
			if (initialized)
			{
				return;
			}
			lock (LOCK)
			{
				if (initialized)
				{
					return;
				}
				GlobalConfig<GlobalSerializationConfig>.LoadInstanceIfAssetExists();
				initialized = true;
				CurrentPlatform = Application.platform;
				if (Application.isEditor)
				{
					return;
				}
				if (CurrentPlatform == RuntimePlatform.Android)
				{
					using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("java.lang.System"))
					{
						string isOnAndroid = androidJavaClass.CallStatic<string>("getProperty", new object[1] { "os.arch" });
						ArchitectureInfo.SetIsOnAndroid(isOnAndroid);
						return;
					}
				}
				ArchitectureInfo.SetIsNotOnAndroid();
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void InitializeRuntime()
		{
			Initialize();
		}

		private static void InitializeEditor()
		{
			Initialize();
		}
	}
}
