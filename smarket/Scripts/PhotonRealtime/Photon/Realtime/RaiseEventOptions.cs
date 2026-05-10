using System;

namespace Photon.Realtime
{
	public class RaiseEventOptions
	{
		public static readonly RaiseEventOptions Default;

		public EventCaching CachingOption;

		public byte InterestGroup;

		public int[] TargetActors;

		public ReceiverGroup Receivers;

		[Obsolete("Not used where SendOptions are a parameter too. Use SendOptions.Channel instead.")]
		public byte SequenceChannel;

		public WebFlags Flags;
	}
}
