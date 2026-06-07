using System;
using Photon.Realtime;

namespace Photon.Pun
{
	public struct PhotonMessageInfo
	{
		private readonly int timeInt;

		public readonly Player Sender;

		public readonly PhotonView photonView;

		[Obsolete("Use SentServerTime instead.")]
		public double timestamp => 0.0;

		public double SentServerTime => 0.0;

		public int SentServerTimestamp => 0;

		public PhotonMessageInfo(Player player, int timestamp, PhotonView view)
		{
			timeInt = 0;
			Sender = null;
			photonView = null;
		}

		public override string ToString()
		{
			return null;
		}
	}
}
