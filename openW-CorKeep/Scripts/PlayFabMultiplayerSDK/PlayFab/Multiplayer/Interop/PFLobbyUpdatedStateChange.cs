using System.Runtime.InteropServices;

namespace PlayFab.Multiplayer.Interop
{
	[StructLayout(LayoutKind.Explicit)]
	public struct PFLobbyUpdatedStateChange
	{
		[FieldOffset(0)]
		public PFLobbyStateChange __AnonymousBase_1;

		[FieldOffset(8)]
		public unsafe PFLobby* lobby;

		[FieldOffset(16)]
		public bool ownerUpdated;

		[FieldOffset(17)]
		public bool maxMembersUpdated;

		[FieldOffset(18)]
		public bool accessPolicyUpdated;

		[FieldOffset(19)]
		public bool membershipLockUpdated;

		[FieldOffset(20)]
		public uint updatedSearchPropertyCount;

		[FieldOffset(24)]
		public unsafe sbyte** updatedSearchPropertyKeys;

		[FieldOffset(32)]
		public uint updatedLobbyPropertyCount;

		[FieldOffset(40)]
		public unsafe sbyte** updatedLobbyPropertyKeys;

		[FieldOffset(48)]
		public uint memberUpdateCount;

		[FieldOffset(56)]
		public unsafe PFLobbyMemberUpdateSummary* memberUpdates;

		[FieldOffset(64)]
		public bool serverUpdated;

		[FieldOffset(68)]
		public uint updatedServerPropertyCount;

		[FieldOffset(72)]
		public unsafe sbyte** updatedServerPropertyKeys;

		[FieldOffset(80)]
		public bool serverConnectionStatusUpdated;
	}
}
