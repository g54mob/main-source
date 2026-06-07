using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	public static class Social
	{
		[PreserveSig]
		public static extern int XblSocialGetSocialRelationshipsAsync(IntPtr xboxLiveContext, ulong xboxUserId, XblSocialRelationshipFilter socialRelationshipFilter, SizeT startIndex, SizeT maxItems, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblSocialGetSocialRelationshipsResult(XAsyncBlockPtr async, IntPtr* handle);

		[PreserveSig]
		public unsafe static extern int XblSocialRelationshipResultGetRelationships(IntPtr resultHandle, XblSocialRelationship** relationships, SizeT* relationshipsCount);

		[PreserveSig]
		public unsafe static extern int XblSocialRelationshipResultHasNext(IntPtr resultHandle, bool* hasNext);

		[PreserveSig]
		public unsafe static extern int XblSocialRelationshipResultGetTotalCount(IntPtr resultHandle, SizeT* totalCount);

		[PreserveSig]
		public static extern int XblSocialRelationshipResultGetNextAsync(IntPtr xboxLiveContext, IntPtr resultHandle, SizeT maxItems, XAsyncBlockPtr async);

		[PreserveSig]
		public unsafe static extern int XblSocialRelationshipResultGetNextResult(XAsyncBlockPtr async, IntPtr* handle);

		[PreserveSig]
		public unsafe static extern int XblSocialRelationshipResultDuplicateHandle(IntPtr handle, IntPtr* duplicatedHandle);

		[PreserveSig]
		public static extern void XblSocialRelationshipResultCloseHandle(IntPtr handle);

		[PreserveSig]
		public static extern int XblSocialAddSocialRelationshipChangedHandler(IntPtr xboxLiveContext, XblSocialRelationshipChangedHandler handler, IntPtr handlerContext);

		[PreserveSig]
		public static extern int XblSocialRemoveSocialRelationshipChangedHandler(IntPtr xboxLiveContext, int handlerFunctionContext);
	}
}
