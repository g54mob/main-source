using UnityEngine;

namespace Sirenix.Serialization
{
	public static class UnitySerializationInitializer
	{
		private static readonly object LOCK;

		private static bool initialized;

		public static bool Initialized => false;

		public static RuntimePlatform CurrentPlatform { get; private set; }

		public static void Initialize()
		{
		}

		[RuntimeInitializeOnLoadMethod]
		private static void InitializeRuntime()
		{
		}
	}
}
