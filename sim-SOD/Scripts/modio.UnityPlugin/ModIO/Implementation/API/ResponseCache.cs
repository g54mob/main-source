using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ModIO.Implementation.API.Objects;

namespace ModIO.Implementation.API
{
	internal static class ResponseCache
	{
		[Serializable]
		private class CachedPageSearch
		{
			public Dictionary<int, long> mods;

			public long resultCount;
		}

		[Serializable]
		private class CachedModProfile
		{
			public ModProfile profile;

			public bool extendLifetime;
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetImageFromCache_003Ed__34 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<byte[]>> _003C_003Et__builder;

			public string url;

			private ResultAnd<byte[]> _003Cresult_003E5__2;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CGetImageFromCache_003Ed__35 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<ResultAnd<byte[]>> _003C_003Et__builder;

			public DownloadReference downloadReference;

			private TaskAwaiter<ResultAnd<byte[]>> _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CClearModFromCacheAfterDelay_003Ed__41 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ModId modId;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CClearModsFromCacheAfterDelay_003Ed__42 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public List<ModId> modIds;

			private List<ModId> _003CmodIdsToClear_003E5__2;

			private TaskAwaiter _003C_003Eu__1;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		public static bool logCacheMessages;

		public static long maxCacheSize;

		private const int minCacheSize = 10485760;

		private const int absoluteCacheSizeLimit = 1073741924;

		private const int modLifetimeInCache = 60000;

		public static TermsHash termsHash;

		private static Dictionary<string, CachedPageSearch> modPages;

		private static Dictionary<long, CachedModProfile> mods;

		private static Dictionary<string, CommentPage> commentObjectsCache;

		private static Dictionary<long, ModDependencies[]> modsDependencies;

		private static Dictionary<long, Rating> currentUserRatings;

		private static bool currentRatingsCached;

		private static KeyValuePair<string, TermsOfUse>? termsOfUse;

		private static TagCategory[] gameTags;

		private static UserProfile? currentUser;

		public static int CacheSize => 0;

		public static void AddModsToCache(string url, int offset, ModPage modPage)
		{
		}

		public static void AddModCommentsToCache(string url, CommentPage commentPage)
		{
		}

		public static void RemoveModCommentFromCache(long id)
		{
		}

		public static void AddModToCache(ModProfile mod)
		{
		}

		public static void AddUserToCache(UserProfile profile)
		{
		}

		public static void AddTagsToCache(TagCategory[] tags)
		{
		}

		public static void AddTermsToCache(string url, TermsOfUse terms)
		{
		}

		public static void AddModDependenciesToCache(ModId modId, ModDependencies[] modDependencies)
		{
		}

		public static void AddCurrentUserRating(long modId, Rating rating)
		{
		}

		public static void ReplaceCurrentUserRatings(Rating[] ratings)
		{
		}

		public static bool GetModsFromCache(string url, int offset, int limit, out ModPage modPage)
		{
			modPage = default(ModPage);
			return false;
		}

		public static bool GetModFromCache(ModId modId, out ModProfile modProfile)
		{
			modProfile = default(ModProfile);
			return false;
		}

		public static bool GetUserProfileFromCache(out UserProfile userProfile)
		{
			userProfile = default(UserProfile);
			return false;
		}

		public static bool GetTagsFromCache(out TagCategory[] tags)
		{
			tags = null;
			return false;
		}

		public static bool GetModCommentsFromCache(string url, out CommentPage commentObjs)
		{
			commentObjs = default(CommentPage);
			return false;
		}

		[AsyncStateMachine(typeof(_003CGetImageFromCache_003Ed__34))]
		public static Task<ResultAnd<byte[]>> GetImageFromCache(string url)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetImageFromCache_003Ed__35))]
		public static Task<ResultAnd<byte[]>> GetImageFromCache(DownloadReference downloadReference)
		{
			return null;
		}

		public static bool GetTermsFromCache(string url, out TermsOfUse terms)
		{
			terms = default(TermsOfUse);
			return false;
		}

		public static bool GetModDependenciesCache(ModId modId, out ModDependencies[] modDependencies)
		{
			modDependencies = null;
			return false;
		}

		public static bool GetCurrentUserRatingsCache(out Rating[] ratings)
		{
			ratings = null;
			return false;
		}

		public static bool GetCurrentUserRatingFromCache(ModId modId, out ModRating modRating)
		{
			modRating = default(ModRating);
			return false;
		}

		public static bool HaveRatingsBeenCachedThisSession()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CClearModFromCacheAfterDelay_003Ed__41))]
		private static void ClearModFromCacheAfterDelay(ModId modId)
		{
		}

		[AsyncStateMachine(typeof(_003CClearModsFromCacheAfterDelay_003Ed__42))]
		private static void ClearModsFromCacheAfterDelay(List<ModId> modIds)
		{
		}

		public static void ClearUserFromCache()
		{
		}

		public static void ClearCache()
		{
		}

		private static void EnsureCacheSize(object obj)
		{
		}

		private static void ForceClearCache(long numberOfBytesToClear)
		{
		}

		private static long GetCacheSizeEstimate()
		{
			return 0L;
		}

		private static long GetModsByteSize()
		{
			return 0L;
		}

		private static long GetByteSizeForObject(object obj)
		{
			return 0L;
		}
	}
}
