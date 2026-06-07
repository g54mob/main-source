using Coherence.Common;

namespace Coherence.Cloud
{
	public class SelfHostedRoomCreationOptions : RoomCreationOptions
	{
		public int UniqueId;

		public int CleanupTimeout;

		public int MaxEntities;

		public string Secret;

		public string ProjectId;

		public string[] Schemas;

		public HostAuthority HostAuthority;

		public bool UseDebugStreams;

		public new static SelfHostedRoomCreationOptions Default => null;

		internal static SelfHostedRoomCreationOptions FromRoomCreationOptions(RoomCreationOptions roomCreationOptions)
		{
			return null;
		}

		internal LocalRoomCreationRequest ToRequest()
		{
			return default(LocalRoomCreationRequest);
		}
	}
}
