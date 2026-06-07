using System.Collections.Generic;
using System.Linq;
using FishNet.Editing;
using FishNet.Managing;
using FishNet.Managing.Statistic;
using FishNet.Transporting;
using UnityEngine;

namespace Assets.Scripts.Multiplayer.Utils
{
	public class NetworkEventHistory : MonoBehaviour
	{
		public delegate void CorrectedTrafficUpdateHandler(uint tick, ulong clientIn, ulong clientOut, ulong serverIn, ulong serverOut);

		public enum ProfilerMode
		{
			Client = 0,
			Server = 1
		}

		[SerializeField]
		private int _historyLength = 512;

		private NetworkManager _networkManager;

		private NetworkTrafficStatistics _trafficStatistics;

		public ProfilerMode CurrentMode { get; private set; }

		public List<TickData> History { get; private set; } = new List<TickData>();

		public bool IsPaused { get; private set; }

		public event CorrectedTrafficUpdateHandler OnCorrectedTrafficUpdate;

		public void ClearHistory()
		{
			History.Clear();
		}

		public void SetMode(ProfilerMode mode)
		{
			if (CurrentMode != mode)
			{
				CurrentMode = mode;
			}
		}

		public void SetPaused(bool paused)
		{
			IsPaused = paused;
		}

		protected void OnDestroy()
		{
			if (_trafficStatistics != null)
			{
				_trafficStatistics.OnNetworkTraffic -= OnNetworkTraffic;
			}
		}

		protected void Start()
		{
			_networkManager = Object.FindFirstObjectByType<NetworkManager>();
			if (_networkManager == null || !_networkManager.StatisticsManager.TryGetNetworkTrafficStatistics(out _trafficStatistics))
			{
				Debug.LogError("Profiler could not initialize. Disabling.");
				base.enabled = false;
			}
			else
			{
				_trafficStatistics.OnNetworkTraffic += OnNetworkTraffic;
			}
		}

		private void OnNetworkTraffic(uint tick, BidirectionalNetworkTraffic serverTraffic, BidirectionalNetworkTraffic clientTraffic)
		{
			(ulong, List<MessageData>) tuple = ProcessAndCorrectTraffic(clientTraffic.InboundTraffic?.PacketGroups);
			(ulong, List<MessageData>) tuple2 = ProcessAndCorrectTraffic(clientTraffic.OutboundTraffic?.PacketGroups);
			(ulong, List<MessageData>) tuple3 = ProcessAndCorrectTraffic(serverTraffic.InboundTraffic?.PacketGroups);
			(ulong, List<MessageData>) tuple4 = ProcessAndCorrectTraffic(serverTraffic.OutboundTraffic?.PacketGroups);
			if (!IsPaused)
			{
				(ulong, List<MessageData>) tuple5 = ((CurrentMode == ProfilerMode.Client) ? tuple : tuple3);
				(ulong, List<MessageData>) tuple6 = ((CurrentMode == ProfilerMode.Client) ? tuple2 : tuple4);
				TickData item = new TickData
				{
					Tick = tick,
					TotalInboundBytes = tuple5.Item1,
					InboundMessages = tuple5.Item2,
					TotalOutboundBytes = tuple6.Item1,
					OutboundMessages = tuple6.Item2
				};
				History.Add(item);
				if (History.Count > _historyLength)
				{
					History.RemoveAt(0);
				}
			}
			this.OnCorrectedTrafficUpdate?.Invoke(tick, tuple.Item1, tuple2.Item1, tuple3.Item1, tuple4.Item1);
			static (ulong TotalBytes, List<MessageData> Messages) ProcessAndCorrectTraffic(Dictionary<PacketId, NetworkTraffic.PacketGroup> packetGroups)
			{
				List<MessageData> list = new List<MessageData>();
				if (packetGroups == null)
				{
					return (TotalBytes: 0uL, Messages: list);
				}
				Dictionary<string, (ulong, int, string)> dictionary = new Dictionary<string, (ulong, int, string)>();
				foreach (NetworkTraffic.PacketGroup value in packetGroups.Values)
				{
					if (value.Packets.Count != 0)
					{
						string packetCategory = ProfilerUtils.GetPacketCategory(value.PacketId);
						foreach (NetworkTraffic.Packet packet in value.Packets)
						{
							string key = (string.IsNullOrEmpty(packet.Details) ? value.PacketId.ToString() : packet.Details);
							if (!dictionary.ContainsKey(key))
							{
								dictionary[key] = (0uL, 0, packetCategory);
							}
							(ulong, int, string) tuple7 = dictionary[key];
							dictionary[key] = (tuple7.Item1 + packet.Bytes, tuple7.Item2 + 1, packetCategory);
						}
					}
				}
				foreach (KeyValuePair<string, (ulong, int, string)> item2 in dictionary)
				{
					list.Add(new MessageData
					{
						Name = item2.Key,
						Bytes = item2.Value.Item1,
						Count = item2.Value.Item2,
						Category = item2.Value.Item3
					});
				}
				ulong num = (ulong)list.Where((MessageData m) => m.Category != "Internal / Unset").Sum((MessageData m) => (long)m.Bytes);
				if (num == 0L)
				{
					MessageData messageData = list.FirstOrDefault((MessageData m) => m.Category == "Internal / Unset");
					if (messageData.Name != null)
					{
						num = messageData.Bytes;
					}
				}
				return (TotalBytes: num, Messages: list);
			}
		}
	}
}
