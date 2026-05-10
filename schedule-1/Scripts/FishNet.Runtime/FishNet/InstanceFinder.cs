using System;
using FishNet.Component.ColliderRollback;
using FishNet.Managing;
using FishNet.Managing.Client;
using FishNet.Managing.Predicting;
using FishNet.Managing.Scened;
using FishNet.Managing.Server;
using FishNet.Managing.Statistic;
using FishNet.Managing.Timing;
using FishNet.Managing.Transporting;
using UnityEngine;

namespace FishNet
{
	public static class InstanceFinder
	{
		private static NetworkManager _networkManager;

		public static NetworkManager NetworkManager => null;

		public static ServerManager ServerManager => null;

		public static ClientManager ClientManager => null;

		public static TransportManager TransportManager => null;

		public static TimeManager TimeManager => null;

		public static SceneManager SceneManager => null;

		public static RollbackManager RollbackManager => null;

		public static PredictionManager PredictionManager => null;

		public static StatisticsManager StatisticsManager => null;

		public static bool IsServer => false;

		public static bool IsServerOnly => false;

		public static bool IsClient => false;

		public static bool IsClientOnly => false;

		public static bool IsHost => false;

		public static bool IsOffline => false;

		public static void RegisterInvokeOnInstance<T>(Action<UnityEngine.Component> handler) where T : UnityEngine.Component
		{
		}

		public static void UnregisterInvokeOnInstance<T>(Action<UnityEngine.Component> handler) where T : UnityEngine.Component
		{
		}

		public static T GetInstance<T>() where T : UnityEngine.Component
		{
			return null;
		}

		public static bool HasInstance<T>() where T : UnityEngine.Component
		{
			return false;
		}

		public static void RegisterInstance<T>(T component, bool replace = true) where T : UnityEngine.Component
		{
		}

		public static bool TryRegisterInstance<T>(T component) where T : UnityEngine.Component
		{
			return false;
		}

		public static bool TryGetInstance<T>(out T component) where T : UnityEngine.Component
		{
			component = null;
			return false;
		}

		public static void UnregisterInstance<T>() where T : UnityEngine.Component
		{
		}
	}
}
