using System;
using System.Collections.Generic;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;

namespace FishNet.Utility.Performance
{
	[Obsolete("ListCache has been discovered potentially contain a small memory leak depending on the type being cached. Use ObjectCaches, ResettableObjectCaches, CollectionCaches, ResettableCollectionCaches instead.")]
	public static class ListCaches
	{
		private static Stack<ListCache<NetworkObject>> _networkObjectCaches;

		private static Stack<ListCache<NetworkBehaviour>> _networkBehaviourCaches;

		private static Stack<ListCache<Transform>> _transformCaches;

		private static Stack<ListCache<NetworkConnection>> _networkConnectionCaches;

		private static Stack<ListCache<int>> _intCaches;

		[Obsolete("Use RetrieveNetworkObjectCache().")]
		public static ListCache<NetworkObject> GetNetworkObjectCache()
		{
			return null;
		}

		public static ListCache<NetworkObject> RetrieveNetworkObjectCache()
		{
			return null;
		}

		[Obsolete("Use RetrieveNetworkConnectionCache().")]
		public static ListCache<NetworkConnection> GetNetworkConnectionCache()
		{
			return null;
		}

		public static ListCache<NetworkConnection> RetrieveNetworkConnectionCache()
		{
			return null;
		}

		[Obsolete("Use RetrieveTransformCache().")]
		public static ListCache<Transform> GetTransformCache()
		{
			return null;
		}

		public static ListCache<Transform> RetrieveTransformCache()
		{
			return null;
		}

		[Obsolete("Use RetrieveNetworkBehaviourCache().")]
		public static ListCache<NetworkBehaviour> GetNetworkBehaviourCache()
		{
			return null;
		}

		public static ListCache<NetworkBehaviour> RetrieveNetworkBehaviourCache()
		{
			return null;
		}

		[Obsolete("Use RetrieveGetIntCache().")]
		public static ListCache<int> GetIntCache()
		{
			return null;
		}

		public static ListCache<int> RetrieveIntCache()
		{
			return null;
		}

		public static void StoreCache(ListCache<NetworkObject> cache)
		{
		}

		public static void StoreCache(ListCache<NetworkConnection> cache)
		{
		}

		public static void StoreCache(ListCache<Transform> cache)
		{
		}

		public static void StoreCache(ListCache<NetworkBehaviour> cache)
		{
		}

		public static void StoreCache(ListCache<int> cache)
		{
		}
	}
}
