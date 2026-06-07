using System;
using System.Runtime.InteropServices;

namespace XGamingRuntime.Interop
{
	public static class Matchmaking
	{
		[PreserveSig]
		public unsafe static extern int XblMatchmakingCreateMatchTicketAsync(IntPtr xboxLiveContext, XblMultiplayerSessionReference ticketSessionReference, sbyte* matchmakingServiceConfigurationId, sbyte* hopperName, ulong ticketTimeout, XblPreserveSessionMode preserveSession, sbyte* ticketAttributesJson, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		public unsafe static extern int XblMatchmakingCreateMatchTicketResult(XAsyncBlockPtr asyncBlock, XblCreateMatchTicketResponse* resultPtr);

		[PreserveSig]
		public unsafe static extern int XblMatchmakingDeleteMatchTicketAsync(IntPtr xboxLiveContext, sbyte* serviceConfigurationId, sbyte* hopperName, sbyte* ticketId, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		public unsafe static extern int XblMatchmakingGetMatchTicketDetailsAsync(IntPtr xboxLiveContext, sbyte* serviceConfigurationId, sbyte* hopperName, sbyte* ticketId, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		public unsafe static extern int XblMatchmakingGetMatchTicketDetailsResultSize(XAsyncBlockPtr asyncBlock, SizeT* resultSizeInBytes);

		[PreserveSig]
		public unsafe static extern int XblMatchmakingGetMatchTicketDetailsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, XblMatchTicketDetailsResponse** ptrToBuffer, SizeT* bufferUsed);

		[PreserveSig]
		public unsafe static extern int XblMatchmakingGetHopperStatisticsAsync(IntPtr xboxLiveContext, sbyte* serviceConfigurationId, sbyte* hopperName, XAsyncBlockPtr asyncBlock);

		[PreserveSig]
		public unsafe static extern int XblMatchmakingGetHopperStatisticsResultSize(XAsyncBlockPtr asyncBlock, SizeT* resultSizeInBytes);

		[PreserveSig]
		public unsafe static extern int XblMatchmakingGetHopperStatisticsResult(XAsyncBlockPtr asyncBlock, SizeT bufferSize, IntPtr buffer, XblHopperStatisticsResponse** ptrToBuffer, SizeT* bufferUsed);
	}
}
