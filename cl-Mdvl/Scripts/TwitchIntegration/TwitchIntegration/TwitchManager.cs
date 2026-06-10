using System;
using UnityEngine;

namespace TwitchIntegration
{
	public static class TwitchManager
	{
		private static TwitchCommandManager commandManager;

		public static bool IsAuthenticated => Authenticator.IsAuthenticated;

		public static bool IsInitialized => TwitchCommandManager.IsInitialized;

		public static TwitchAuthenticator Authenticator { get; private set; }

		public static event Action OnTwitchClientJoinedChat;

		public static event Action<TwitchUser, string> OnTwitchMessageReceived;

		public static event Action<TwitchUser, TwitchCommand> OnTwitchCommandReceived;

		public static event Action OnTwitchClientFailedToConnect;

		public static void Authenticate(string username, string channelName, Action<bool> onComplete = null)
		{
			Authenticator.TryAuthenticate(username, channelName, onComplete);
		}

		[RuntimeInitializeOnLoadMethod]
		private static void CreateInstance()
		{
			GameObject gameObject = new GameObject("TwitchManager");
			Authenticator = gameObject.AddComponent<TwitchAuthenticator>();
			commandManager = gameObject.AddComponent<TwitchCommandManager>();
			UnityEngine.Object.DontDestroyOnLoad(Authenticator);
		}

		public static void Deauth()
		{
			Authenticator.Deauth();
		}

		internal static void OnJoinedToChat()
		{
			TwitchManager.OnTwitchClientJoinedChat?.Invoke();
		}

		internal static void OnMessageReceived(TwitchUser user, string message)
		{
			TwitchManager.OnTwitchMessageReceived?.Invoke(user, message);
		}

		internal static void OnCommandReceived(TwitchUser user, TwitchCommand command)
		{
			TwitchManager.OnTwitchCommandReceived?.Invoke(user, command);
		}

		internal static void OnFailedToConnect()
		{
			TwitchManager.OnTwitchClientFailedToConnect?.Invoke();
		}
	}
}
