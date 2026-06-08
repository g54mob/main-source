using Controllers;
using MessagePack;

namespace Kitchen
{
	[MessagePackObject(false)]
	public struct KickUserData : ICommandData
	{
		[Key(0)]
		public KickReason Reason;

		[Key(1)]
		public SourceIdentifier Target;
	}
}
