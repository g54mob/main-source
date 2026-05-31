using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;

namespace Photon.Realtime
{
	public class RegionHandler
	{
		public static Type PingImplementation;

		private string availableRegionCodes;

		private Region bestRegionCache;

		private readonly List<RegionPinger> pingerList;

		private Action<RegionHandler> onCompleteCall;

		private int previousPing;

		private string previousSummaryProvided;

		protected internal static ushort PortToPingOverride;

		private float rePingFactor;

		private float pingSimilarityFactor;

		public int BestRegionSummaryPingLimit;

		private MonoBehaviourEmpty emptyMonoBehavior;

		public List<Region> EnabledRegions { get; protected internal set; }

		public Region BestRegion => null;

		public string SummaryToCache => null;

		public bool IsPinging { get; private set; }

		public bool Aborted { get; private set; }

		public string GetResults()
		{
			return null;
		}

		public void SetRegions(OperationResponse opGetRegions, LoadBalancingClient loadBalancingClient = null)
		{
		}

		public RegionHandler(ushort masterServerPortOverride = 0)
		{
		}

		public bool PingMinimumOfRegions(Action<RegionHandler> onCompleteCallback, string previousSummary)
		{
			return false;
		}

		public void Abort()
		{
		}

		private void OnPreferredRegionPinged(Region preferredRegion)
		{
		}

		private bool PingEnabledRegions()
		{
			return false;
		}

		private void OnRegionDone(Region region)
		{
		}
	}
}
