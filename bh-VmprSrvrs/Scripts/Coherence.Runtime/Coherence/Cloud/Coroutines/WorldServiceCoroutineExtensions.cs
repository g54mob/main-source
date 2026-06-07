using System.Collections.Generic;

namespace Coherence.Cloud.Coroutines
{
	public static class WorldServiceCoroutineExtensions
	{
		public static WaitForPredicate WaitForLogin(this WorldsService worldsService)
		{
			return null;
		}

		public static WaitForRequestResponse<IReadOnlyList<WorldData>> WaitForFetchWorlds(this WorldsService worldsService, string region = "", string simSlug = "")
		{
			return null;
		}
	}
}
