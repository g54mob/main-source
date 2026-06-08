using System;
using System.Collections.Generic;
using System.Linq;
using Controllers;
using Kitchen.NetworkSupport;
using Platforms;
using UnityEngine;

namespace Kitchen
{
	public class NetworkRouter : IViewRouter, ILiveness, ILateUpdateRouter
	{
		private const float PacketSendInterval = 0.02f;

		public const int MaxPacketSize = 2000;

		private float TimeSinceLastSend;

		private bool IsInNetworkedMode;

		public bool IsValid = true;

		public List<INetworkTransport> Transports;

		private INetworkSerializer<List<INetworkData>> Serializer;

		private IViewRouter PassTo;

		private MessageQueue PendingMessages = new MessageQueue();

		private float LastTransmitTime;

		private List<INetworkTarget> SeenTargets = new List<INetworkTarget>();

		private readonly NestedNetworkLiveness Liveness = new NestedNetworkLiveness();

		private HashSet<INetworkTransport> ReadyTransports = new HashSet<INetworkTransport>();

		public bool HasTransports => Transports.Any();

		public bool IsLive => Liveness.IsLive;

		public bool IsGoodQuality => Liveness.IsGoodQuality;

		public event Action OnRequestReconnection = delegate
		{
		};

		public NetworkRouter(List<INetworkTransport> transports, IViewRouter pass_to, INetworkSerializer<List<INetworkData>> serializer)
		{
			Transports = new List<INetworkTransport>();
			PassTo = pass_to;
			Serializer = serializer;
			AddNewTransports(transports);
		}

		public void AddNewTransports(List<INetworkTransport> transports)
		{
			Transports.AddRange(transports);
			foreach (INetworkTransport transport in transports)
			{
				transport.OnReceive += delegate(INetworkTarget target, byte[] bytes)
				{
					OnReceive(transport, target, bytes);
				};
				Liveness.Add(transport);
			}
		}

		public void RemoveTransports()
		{
			foreach (INetworkTransport transport in Transports)
			{
				try
				{
					transport.Dispose();
				}
				catch (Exception ex)
				{
					EventLog.Networking.Report(NetworkEvent.ErrorWhileRemovingTransports, ex);
				}
			}
			Transports.Clear();
		}

		public void Update()
		{
			if (!IsValid)
			{
				return;
			}
			for (int num = SeenTargets.Count - 1; num >= 0; num--)
			{
				CheckForDisconnectedClient(SeenTargets[num]);
			}
			IsInNetworkedMode = Session.NetworkedPlayState.IsNetworked();
			foreach (INetworkTransport transport in Transports)
			{
				bool shouldBeActive = transport.ShouldBeActive;
				if (!shouldBeActive || !IsInNetworkedMode)
				{
					transport.RequestSuspend();
				}
				if (shouldBeActive && IsInNetworkedMode)
				{
					transport.RequestUnsuspend();
				}
				if (shouldBeActive && IsInNetworkedMode)
				{
					transport.Update();
				}
			}
		}

		public void LateUpdate()
		{
			if (IsValid && IsInNetworkedMode)
			{
				TimeSinceLastSend += Time.unscaledDeltaTime;
				if (TimeSinceLastSend > 0.02f)
				{
					TimeSinceLastSend -= 0.02f;
					TimeSinceLastSend = Mathf.Clamp(TimeSinceLastSend, 0f, 0.06f);
					SendPendingMessages();
				}
			}
		}

		public void BroadcastUpdate<T>(ViewIdentifier id, T data, MessageType type = MessageType.ViewUpdate) where T : IViewData
		{
			if (IsValid && IsInNetworkedMode)
			{
				PendingMessages.Add(new EntityUpdate
				{
					Identifier = id,
					Data = data,
					Type = type
				});
			}
		}

		public void BroadcastCommand<T>(T update) where T : ICommandUpdate
		{
			if (IsValid && IsInNetworkedMode)
			{
				PendingMessages.Add(new CommandUpdate
				{
					Command = update
				});
			}
		}

		public void Dispose()
		{
			PendingMessages.Clear();
			BroadcastCommand(new ControlCommand
			{
				SourceIdentifier = InputSourceIdentifier.Identifier,
				Type = CommandType.Disconnecting
			});
			SendPendingMessages();
			foreach (INetworkTransport transport in Transports)
			{
				try
				{
					Liveness.Remove(transport);
					transport.Dispose();
				}
				catch (Exception ex)
				{
					EventLog.Networking.Report(NetworkEvent.ErrorWhileDisposingRouter, ex);
				}
			}
			Transports.Clear();
		}

		public void StartServer(bool networked)
		{
			RefreshLiveness();
			IsInNetworkedMode = networked;
			foreach (INetworkTransport transport in Transports)
			{
				transport.RequestStartServer();
			}
		}

		public void JoinServer(INetworkTarget target)
		{
			RefreshLiveness();
			IsInNetworkedMode = true;
			using List<INetworkTransport>.Enumerator enumerator = Transports.GetEnumerator();
			while (enumerator.MoveNext() && !enumerator.Current.RequestJoinServer(target))
			{
			}
		}

		public NetworkInviteData GetInviteData()
		{
			NetworkInviteData invite_data = default(NetworkInviteData);
			bool flag = false;
			foreach (INetworkTransport transport in Transports)
			{
				transport.SupplyInviteData(ref invite_data);
				flag |= transport.IsHosting;
			}
			if (flag)
			{
				invite_data.Identifier = InputSourceIdentifier.Identifier.ToString();
			}
			else
			{
				invite_data.Identifier = Session.HostIdentifier.ToString();
			}
			return invite_data;
		}

		public bool IsConnectedTo(INetworkTarget target)
		{
			foreach (INetworkTransport transport in Transports)
			{
				if (transport.IsTargetConnected(target))
				{
					return true;
				}
			}
			return false;
		}

		public void GetConnectedPlayers(ref List<NetworkTargetDescription> users)
		{
			foreach (INetworkTransport transport in Transports)
			{
				transport.GetConnectedPlayers(ref users);
			}
		}

		public void RefreshLiveness()
		{
			Liveness.RefreshLiveness();
		}

		public bool IsActivelyInSession()
		{
			foreach (INetworkTransport transport in Transports)
			{
				if (transport.ConnectionStatus == TransportConnectionStatus.ActiveClient)
				{
					return true;
				}
				if (transport.ConnectionStatus == TransportConnectionStatus.ActiveHosting)
				{
					return true;
				}
			}
			return true;
		}

		private bool GetReadyTransports(ref HashSet<INetworkTransport> transports)
		{
			transports.Clear();
			if (IsInNetworkedMode)
			{
				foreach (INetworkTransport transport in Transports)
				{
					if (transport.SendStatus == TransportSendStatus.Ready)
					{
						ReadyTransports.Add(transport);
					}
				}
			}
			return transports.Count > 0;
		}

		private void RemoveClient(INetworkTarget target, SourceIdentifier identifier)
		{
			SeenTargets.Remove(target);
			foreach (INetworkTransport transport in Transports)
			{
				if (transport.SendStatus == TransportSendStatus.Ready)
				{
					transport.RequestKickUser(target);
				}
			}
			PassTo.BroadcastCommand(new ControlCommand
			{
				SourceIdentifier = identifier,
				Type = CommandType.Disconnecting
			});
		}

		private void SendPendingMessages()
		{
			foreach (SourceIdentifier kickRequest in Session.KickRequests)
			{
				if (Session.GetPeerInfo(kickRequest, out var result))
				{
					EventLog.Networking.Report(NetworkEvent.RouterClientBeingKicked, kickRequest.ToString());
					RemoveClient(result.Target, kickRequest);
				}
			}
			Session.KickRequests.Clear();
			ReadyTransports.Clear();
			if (Time.realtimeSinceStartup - LastTransmitTime > 5f)
			{
				PendingMessages.Add(new CommandUpdate
				{
					Command = new ControlCommand
					{
						Type = CommandType.KeepAlive,
						SourceIdentifier = InputSourceIdentifier.Identifier
					}
				});
			}
			if (PendingMessages.Count == 0)
			{
				return;
			}
			if (!GetReadyTransports(ref ReadyTransports))
			{
				PendingMessages.Clear();
				return;
			}
			LastTransmitTime = Time.realtimeSinceStartup;
			List<INetworkData> list = PendingMessages.RollUpMessages();
			byte[] array = Serializer.Serialize(list);
			if (array.Length > 2000 && PlatformSettings.LargeMessageBehaviour != LargeMessageBehaviour.SendAsOne)
			{
				switch (PlatformSettings.LargeMessageBehaviour)
				{
				case LargeMessageBehaviour.SplitOverFrames:
				{
					list = PendingMessages.GetAllMessages();
					int num = SendMessageListInParts(list, delegate(byte[] data)
					{
						foreach (INetworkTransport readyTransport in ReadyTransports)
						{
							TransportSendResult transportSendResult3 = readyTransport.Send(data);
							if (transportSendResult3 != TransportSendResult.Success)
							{
								Debug.LogWarning($"{readyTransport} failed to send with error {transportSendResult3}");
							}
							EventLog.Networking.Report(NetworkEvent.SendingPartialPacket, data.Length);
						}
					}, limit_to_one_part: true);
					EventLog.Networking.Report(NetworkEvent.SentPartialPacketList, $"Sent {num} of {list.Count}");
					PendingMessages.RemoveCount(num);
					break;
				}
				case LargeMessageBehaviour.SplitIntoFewPackets:
					SendMessageListInParts(list, delegate(byte[] data)
					{
						foreach (INetworkTransport readyTransport2 in ReadyTransports)
						{
							TransportSendResult transportSendResult3 = readyTransport2.Send(data);
							if (transportSendResult3 != TransportSendResult.Success)
							{
								Debug.LogWarning($"{readyTransport2} failed to send with error {transportSendResult3}");
							}
							EventLog.Networking.Report(NetworkEvent.SendingPartialPacket, data.Length);
						}
					});
					PendingMessages.Clear();
					break;
				case LargeMessageBehaviour.SplitIntoManyPackets:
				{
					EventLog.Networking.Report(NetworkEvent.SendingPacketsIndividually, $"{array.Length} bytes splitting into {list.Count} packets");
					List<INetworkData> list2 = new List<INetworkData>();
					foreach (INetworkData item in list)
					{
						list2.Clear();
						list2.Add(item);
						array = Serializer.Serialize(list2);
						foreach (INetworkTransport readyTransport3 in ReadyTransports)
						{
							TransportSendResult transportSendResult = readyTransport3.Send(array);
							if (transportSendResult != TransportSendResult.Success)
							{
								Debug.LogWarning($"{readyTransport3} failed to send with error {transportSendResult}");
							}
						}
					}
					PendingMessages.Clear();
					break;
				}
				}
				return;
			}
			if (array.Length > 2000)
			{
				EventLog.Networking.Report(NetworkEvent.SendingLargePacket, $"{list.Count} messages, {array.Length} bytes");
			}
			StatTracker.Main.Report(StatType.NetworkSerialisationSize, LastTransmitTime, (float)array.Length);
			foreach (INetworkTransport readyTransport4 in ReadyTransports)
			{
				TransportSendResult transportSendResult2 = readyTransport4.Send(array);
				if (transportSendResult2 != TransportSendResult.Success)
				{
					Debug.LogWarning($"{readyTransport4} failed to send with error {transportSendResult2}");
				}
			}
			PendingMessages.Clear();
		}

		private int SendMessageListInParts(List<INetworkData> data, Action<byte[]> send, bool limit_to_one_part = false)
		{
			List<INetworkData> list = new List<INetworkData>();
			int num = 0;
			bool flag = false;
			List<INetworkData> list2 = new List<INetworkData>();
			for (int i = 0; i < data.Count; i++)
			{
				INetworkData item = data[i];
				if (limit_to_one_part && flag)
				{
					return i;
				}
				list2.Clear();
				list2.Add(item);
				byte[] array = Serializer.Serialize(list2);
				int num2 = array.Length;
				if (num2 > 2000)
				{
					byte[] obj = Serializer.Serialize(list);
					send(obj);
					num = 0;
					list.Clear();
					send(array);
					flag = true;
					continue;
				}
				list.Add(item);
				num += num2;
				if (num > 2000)
				{
					byte[] obj2 = Serializer.Serialize(list);
					send(obj2);
					num = 0;
					list.Clear();
					flag = true;
				}
			}
			return data.Count;
		}

		private bool CheckForDisconnectedClient(INetworkTarget source)
		{
			foreach (INetworkTransport transport in Transports)
			{
				if (transport.IsTargetConnected(source))
				{
					return false;
				}
			}
			EventLog.Networking.Report(NetworkEvent.RouterClientNotFoundInTransports, source.ToString());
			SeenTargets.Remove(source);
			return true;
		}

		private void CheckForNewClient(INetworkTarget source)
		{
			foreach (INetworkTarget seenTarget in SeenTargets)
			{
				if (source.IsEquivalent(seenTarget))
				{
					return;
				}
			}
			EventLog.Networking.Report(NetworkEvent.RouterNewClientSeen, $"{source} not one of {SeenTargets.Count} seen");
			SeenTargets.Add(source);
			PassTo.BroadcastCommand(new ControlCommand
			{
				SourceIdentifier = InputSourceIdentifier.Identifier,
				Type = CommandType.RequestFullRefresh
			});
		}

		private void UpdatePeerInformation(INetworkTransport transport, INetworkTarget source, CommandUpdate update)
		{
			Session.SetPeerInfo(update.Command.SourceIdentifier, source, delegate
			{
				NetworkPeerInformation result = new NetworkPeerInformation
				{
					Name = transport.GetTargetName(source),
					Connection = transport.ConnectionType,
					Target = source
				};
				EventLog.Networking.Report(NetworkEvent.PeerInfo, $"{update.Command.SourceIdentifier} => {result.Name} ({result.Target})");
				return result;
			});
		}

		private void OnReceive(INetworkTransport transport, INetworkTarget source, byte[] data)
		{
			if (!IsValid || !IsInNetworkedMode || PassTo == null)
			{
				return;
			}
			CheckForNewClient(source);
			List<INetworkData> list = null;
			try
			{
				list = Serializer.Deserialize(data);
			}
			catch (Exception message)
			{
				Debug.LogError($"Failed to deserialise message of length {data.Length}");
				Debug.LogError(message);
				if (transport.IsHosting)
				{
					Debug.LogError($"Bad message received from {source}");
				}
				else
				{
					Debug.LogError($"Reconnecting to server {source}");
					this.OnRequestReconnection();
					IsValid = false;
				}
			}
			if (list == null)
			{
				return;
			}
			foreach (INetworkData item in list)
			{
				if (item is EntityUpdate entityUpdate)
				{
					PassTo.BroadcastUpdate(entityUpdate.Identifier, entityUpdate.Data, entityUpdate.Type);
				}
				if (item is CommandUpdate update)
				{
					if (update.Command.SourceIdentifier == InputSourceIdentifier.Identifier)
					{
						Debug.LogError("Own message received");
					}
					UpdatePeerInformation(transport, source, update);
					if (!transport.IsHosting && update.Command.SourceIdentifier != 0)
					{
						Session.HostIdentifier = update.Command.SourceIdentifier;
					}
					PassTo.BroadcastCommand(update.Command);
				}
			}
		}
	}
}
