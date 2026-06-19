using System;
using PlayFab.Multiplayer.Interop;

namespace PlayFab.Multiplayer.InteropWrapper
{
	public class PFLobbyConsts
	{
		public const uint LobbyMaxMemberCountLowerLimit = 2u;

		public const uint LobbyMaxMemberCountUpperLimit = 128u;

		public const uint LobbyMaxSearchPropertyCount = 30u;

		public const uint LobbyMaxLobbyPropertyCount = 30u;

		public const uint LobbyMaxMemberPropertyCount = 30u;

		public const uint LobbyClientRequestedSearchResultCountUpperLimit = 50u;

		public static readonly string LobbyMemberCountSearchKey = ConvertReadOnlySpanToString(Methods.PFLobbyMemberCountSearchKey);

		public static readonly string LobbyMemberCountRemainingSearchKey = ConvertReadOnlySpanToString(Methods.PFLobbyMemberCountRemainingSearchKey);

		public static readonly string LobbyAmMemberSearchKey = ConvertReadOnlySpanToString(Methods.PFLobbyAmMemberSearchKey);

		public static readonly string LobbyAmOwnerSearchKey = ConvertReadOnlySpanToString(Methods.PFLobbyAmOwnerSearchKey);

		public static readonly string LobbyMembershipLockSearchKey = ConvertReadOnlySpanToString(Methods.PFLobbyMembershipLockSearchKey);

		public static readonly string LobbyAmServerSearchKey = ConvertReadOnlySpanToString(Methods.PFLobbyAmServerSearchKey);

		private static string ConvertReadOnlySpanToString(ReadOnlySpan<byte> span)
		{
			return Converters.ByteArrayToString(span.ToArray());
		}
	}
}
