using System.Threading;

namespace ExitGames.Client.Photon
{
	public class NetworkSimulationSet
	{
		private bool isSimulationEnabled;

		private int outgoingLag;

		private int outgoingJitter;

		private int outgoingLossPercentage;

		private int incomingLag;

		private int incomingJitter;

		private int incomingLossPercentage;

		internal PeerBase peerBase;

		private Thread netSimThread;

		protected internal readonly ManualResetEvent NetSimManualResetEvent;

		protected internal bool IsSimulationEnabled
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int OutgoingLag
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int OutgoingJitter
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int OutgoingLossPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int IncomingLag
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int IncomingJitter
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int IncomingLossPercentage
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int LostPackagesOut { get; internal set; }

		public int LostPackagesIn { get; internal set; }

		public override string ToString()
		{
			return null;
		}
	}
}
