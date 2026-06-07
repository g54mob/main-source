using System.Collections.Generic;
using UnityEngine;

namespace Coherence.Cloud
{
	internal class CloudUniqueIdPool
	{
		private static Dictionary<string, CloudUniqueIdPool> idPoolsForProject;

		private List<string> allIdsPool;

		private Stack<string> inUseIdsPool;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
		private static void ResetPoolInUnity()
		{
		}

		public static CloudUniqueId Get(string projectId)
		{
			return default(CloudUniqueId);
		}

		internal static bool TryGet(string projectId, out string uniqueId)
		{
			uniqueId = null;
			return false;
		}

		public static void Release(string projectId, string idToRelease)
		{
		}

		internal static void RemoveProjectPool(string projectId)
		{
		}

		private static CloudUniqueIdPool GetIdPoolForProject(string projectId)
		{
			return null;
		}

		private static void InitializeIdPool(string projectId, CloudUniqueIdPool idPool)
		{
		}

		private static string GenerateNewId(string projectId, CloudUniqueIdPool idPool)
		{
			return null;
		}

		private static string GetKeyForProject(string projectId)
		{
			return null;
		}
	}
}
