using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FishNet.Connection;
using FishNet.Managing;
using FishNet.Managing.Server;
using FishNet.Object;
using FishNet.Observing;
using UnityEngine;

namespace FishNet.Component.Observing
{
	[CreateAssetMenu(menuName = "FishNet/Observers/Match Condition", fileName = "New Match Condition")]
	public class MatchCondition : ObserverCondition
	{
		public class ConditionCollections
		{
			public Dictionary<int, HashSet<NetworkConnection>> MatchConnections;

			public Dictionary<NetworkConnection, HashSet<int>> ConnectionMatches;

			public Dictionary<int, HashSet<NetworkObject>> MatchObjects;

			public Dictionary<NetworkObject, HashSet<int>> ObjectMatches;
		}

		private static Dictionary<NetworkManager, ConditionCollections> _collections;

		[Obsolete("Use GetMatchConnections(NetworkManager).")]
		public static Dictionary<int, HashSet<NetworkConnection>> MatchConnections => null;

		[Obsolete("Use GetConnectionMatches(NetworkManager).")]
		public static Dictionary<NetworkConnection, HashSet<int>> ConnectionMatch => null;

		[Obsolete("Use GetMatchObjects(NetworkManager).")]
		public static Dictionary<int, HashSet<NetworkObject>> MatchObject => null;

		[Obsolete("Use GetObjectMatches(NetworkManager).")]
		public static Dictionary<NetworkObject, HashSet<int>> ObjectMatch => null;

		internal static void StoreCollections(NetworkManager manager)
		{
		}

		private static ConditionCollections GetCollections(NetworkManager manager = null)
		{
			return null;
		}

		public static Dictionary<int, HashSet<NetworkConnection>> GetMatchConnections(NetworkManager manager = null)
		{
			return null;
		}

		public static Dictionary<NetworkConnection, HashSet<int>> GetConnectionMatches(NetworkManager manager = null)
		{
			return null;
		}

		public static Dictionary<int, HashSet<NetworkObject>> GetMatchObjects(NetworkManager manager = null)
		{
			return null;
		}

		public static Dictionary<NetworkObject, HashSet<int>> GetObjectMatches(NetworkManager manager = null)
		{
			return null;
		}

		public void ConditionConstructor()
		{
		}

		private static bool AddToMatch(int match, NetworkConnection conn, NetworkManager manager, bool replaceMatch, bool rebuild)
		{
			return false;
		}

		public static void AddToMatch(int match, NetworkConnection conn, NetworkManager manager = null, bool replaceMatch = false)
		{
		}

		private static void AddToConnectionMatches(NetworkConnection conn, int match, NetworkManager manager)
		{
		}

		public static void AddToMatch(int match, NetworkConnection[] conns, NetworkManager manager = null, bool replaceMatch = false)
		{
		}

		public static void AddToMatch(int match, List<NetworkConnection> conns, NetworkManager manager = null, bool replaceMatch = false)
		{
		}

		private static bool AddToMatch(int match, NetworkObject nob, NetworkManager manager, bool replaceMatch, bool rebuild)
		{
			return false;
		}

		public static void AddToMatch(int match, NetworkObject nob, NetworkManager manager = null, bool replaceMatch = false)
		{
		}

		public static void AddToMatch(int match, NetworkObject[] nobs, NetworkManager manager = null, bool replaceMatch = false)
		{
		}

		public static void AddToMatch(int match, List<NetworkObject> nobs, NetworkManager manager = null, bool replaceMatch = false)
		{
		}

		private static void TryRemoveKey(Dictionary<int, HashSet<NetworkObject>> dict, int key, HashSet<NetworkObject> value)
		{
		}

		private static void TryRemoveKey(Dictionary<int, HashSet<NetworkObject>> dict, int key)
		{
		}

		private static void TryRemoveKey(Dictionary<NetworkObject, HashSet<int>> dict, NetworkObject key, HashSet<int> value)
		{
		}

		private static void TryRemoveKey(Dictionary<NetworkObject, HashSet<int>> dict, NetworkObject key)
		{
		}

		private static void TryRemoveKey(Dictionary<int, HashSet<NetworkConnection>> dict, int key, HashSet<NetworkConnection> value)
		{
		}

		private static void TryRemoveKey(Dictionary<int, HashSet<NetworkConnection>> dict, int key)
		{
		}

		private static void TryRemoveKey(Dictionary<NetworkConnection, HashSet<int>> dict, NetworkConnection key, HashSet<int> value)
		{
		}

		private static void TryRemoveKey(Dictionary<NetworkConnection, HashSet<int>> dict, NetworkConnection key)
		{
		}

		internal static bool RemoveFromMatchesWithoutRebuild(NetworkConnection conn, NetworkManager manager)
		{
			return false;
		}

		public static void RemoveFromMatch(NetworkConnection conn, NetworkManager manager)
		{
		}

		private static bool RemoveFromMatch(int match, NetworkConnection conn, NetworkManager manager, bool rebuild)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool RemoveFromMatch(int match, NetworkConnection conn, NetworkManager manager = null)
		{
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RemoveFromMatch(int match, NetworkConnection[] conns, NetworkManager manager)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RemoveFromMatch(int match, List<NetworkConnection> conns, NetworkManager manager)
		{
		}

		internal static bool RemoveFromMatchWithoutRebuild(NetworkObject nob, NetworkManager manager)
		{
			return false;
		}

		public static bool RemoveFromMatch(NetworkObject nob, NetworkManager manager = null)
		{
			return false;
		}

		public static void RemoveFromMatch(NetworkObject[] nobs, NetworkManager manager = null)
		{
		}

		public static void RemoveFromMatch(List<NetworkObject> nobs, NetworkManager manager = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RemoveFromMatch(int match, NetworkObject nob, NetworkManager manager = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RemoveFromMatch(int match, NetworkObject[] nobs, NetworkManager manager = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void RemoveFromMatch(int match, List<NetworkObject> nobs, NetworkManager manager = null)
		{
		}

		public override bool ConditionMet(NetworkConnection connection, bool currentlyAdded, out bool notProcessed)
		{
			notProcessed = default(bool);
			return false;
		}

		private static ServerObjects GetServerObjects(NetworkManager manager)
		{
			return null;
		}

		public override ObserverConditionType GetConditionType()
		{
			return default(ObserverConditionType);
		}

		public override ObserverCondition Clone()
		{
			return null;
		}
	}
}
