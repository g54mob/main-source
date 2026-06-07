using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	public sealed class SessionSearch : Handle
	{
		public const int SessionsearchCopysearchresultbyindexApiLatest = 1;

		public const int SessionsearchFindApiLatest = 2;

		public const int SessionsearchGetsearchresultcountApiLatest = 1;

		public const int SessionsearchRemoveparameterApiLatest = 1;

		public const int SessionsearchSetmaxsearchresultsApiLatest = 1;

		public const int SessionsearchSetparameterApiLatest = 1;

		public const int SessionsearchSetsessionidApiLatest = 1;

		public const int SessionsearchSettargetuseridApiLatest = 1;

		public SessionSearch()
		{
		}

		public SessionSearch(IntPtr innerHandle)
		{
		}

		public Result CopySearchResultByIndex(SessionSearchCopySearchResultByIndexOptions options, out SessionDetails outSessionHandle)
		{
			outSessionHandle = null;
			return default(Result);
		}

		public void Find(SessionSearchFindOptions options, object clientData, SessionSearchOnFindCallback completionDelegate)
		{
		}

		public uint GetSearchResultCount(SessionSearchGetSearchResultCountOptions options)
		{
			return 0u;
		}

		public void Release()
		{
		}

		public Result RemoveParameter(SessionSearchRemoveParameterOptions options)
		{
			return default(Result);
		}

		public Result SetMaxResults(SessionSearchSetMaxResultsOptions options)
		{
			return default(Result);
		}

		public Result SetParameter(SessionSearchSetParameterOptions options)
		{
			return default(Result);
		}

		public Result SetSessionId(SessionSearchSetSessionIdOptions options)
		{
			return default(Result);
		}

		public Result SetTargetUserId(SessionSearchSetTargetUserIdOptions options)
		{
			return default(Result);
		}

		internal static void OnFindCallbackInternalImplementation(IntPtr data)
		{
		}

		[PreserveSig]
		internal static extern Result EOS_SessionSearch_CopySearchResultByIndex(IntPtr handle, IntPtr options, ref IntPtr outSessionHandle);

		[PreserveSig]
		internal static extern void EOS_SessionSearch_Find(IntPtr handle, IntPtr options, IntPtr clientData, SessionSearchOnFindCallbackInternal completionDelegate);

		[PreserveSig]
		internal static extern uint EOS_SessionSearch_GetSearchResultCount(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern void EOS_SessionSearch_Release(IntPtr sessionSearchHandle);

		[PreserveSig]
		internal static extern Result EOS_SessionSearch_RemoveParameter(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_SessionSearch_SetMaxResults(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_SessionSearch_SetParameter(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_SessionSearch_SetSessionId(IntPtr handle, IntPtr options);

		[PreserveSig]
		internal static extern Result EOS_SessionSearch_SetTargetUserId(IntPtr handle, IntPtr options);
	}
}
