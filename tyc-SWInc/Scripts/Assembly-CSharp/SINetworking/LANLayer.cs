using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;

namespace SINetworking
{
	public class LANLayer : NetworkLayer
	{
		[NonSerialized]
		private UdpClient _lobbyClient;

		[NonSerialized]
		private UdpClient _lobbyListener;

		[NonSerialized]
		private UdpClient _lobbyListenerv6;

		private static List<System.Net.NetworkInformation.Ping> _pings = new List<System.Net.NetworkInformation.Ping>();

		private void OnDestroy()
		{
			UdpClient lobbyClient = _lobbyClient;
			if (lobbyClient != null)
			{
				lobbyClient.Close();
			}
			UdpClient lobbyListener = _lobbyListener;
			if (lobbyListener != null)
			{
				lobbyListener.Close();
			}
		}

		public static ValueTuple<string, int> ParseConnection(string input, int defaultPort)
		{
			if (input[0] == '[')
			{
				int num = input.IndexOf(']');
				if (num > 0)
				{
					string item = input.Substring(1, num - 1);
					if (num + 1 < input.Length)
					{
						string text = input.Substring(num + 1, input.Length - (num + 1));
						int result;
						if (text[0] == ':' && int.TryParse(text.Substring(1), out result))
						{
							return new ValueTuple<string, int>(item, result);
						}
					}
					return new ValueTuple<string, int>(item, defaultPort);
				}
			}
			else
			{
				int num2 = input.IndexOf(':');
				int result2;
				if (num2 >= 0 && int.TryParse(input.Substring(num2 + 1), out result2))
				{
					return new ValueTuple<string, int>(input.Substring(0, num2), result2);
				}
			}
			return new ValueTuple<string, int>(input, defaultPort);
		}

		public static string GetIP4Address()
		{
			if (!string.IsNullOrWhiteSpace(Options.ForcedIP))
			{
				return Options.ForcedIP;
			}
			try
			{
				IPAddress[] hostAddresses = Dns.GetHostAddresses(Dns.GetHostName());
				foreach (IPAddress iPAddress in hostAddresses)
				{
					if (iPAddress.AddressFamily.Equals(AddressFamily.InterNetwork))
					{
						return iPAddress.ToString();
					}
				}
			}
			catch (Exception)
			{
				string text = FallbackAddress();
				if (text != null)
				{
					return text;
				}
			}
			return "127.0.0.1";
		}

		private static string FallbackAddress()
		{
			NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface networkInterface in allNetworkInterfaces)
			{
				if (networkInterface.OperationalStatus != OperationalStatus.Up || (networkInterface.NetworkInterfaceType != NetworkInterfaceType.Ethernet && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Wireless80211))
				{
					continue;
				}
				foreach (UnicastIPAddressInformation unicastAddress in networkInterface.GetIPProperties().UnicastAddresses)
				{
					if (unicastAddress.Address.AddressFamily == AddressFamily.InterNetwork)
					{
						return unicastAddress.Address.ToString();
					}
				}
			}
			return null;
		}

		public override void SetLobbyMeta(NetworkLobby lobby, string var, string value)
		{
		}

		public override void CreateLobby(NetworkLobby lobby)
		{
			CurrentLobby = lobby;
			IPAddress iPAddress = IPAddress.Parse(GetIP4Address());
			if (iPAddress.AddressFamily == AddressFamily.InterNetworkV6)
			{
				_lobbyClient = new UdpClient(new IPEndPoint(IPAddress.IPv6Any, Options.LobbyPort));
			}
			else
			{
				_lobbyClient = new UdpClient(new IPEndPoint(iPAddress, Options.LobbyPort))
				{
					EnableBroadcast = true
				};
			}
			TcpListener tcpListener = new TcpListener(iPAddress, Options.GamePort);
			NetworkManager.Self.ConnectionObject = tcpListener;
			tcpListener.Start();
			InvokeLobbyCreated();
		}

		public override void CleanPlayer(NetworkPlayer player)
		{
			object connectionObject = player.ConnectionObject;
			if (connectionObject != null)
			{
				TcpClient tcpClient;
				if ((tcpClient = connectionObject as TcpClient) == null)
				{
					TcpListener tcpListener;
					if ((tcpListener = connectionObject as TcpListener) != null)
					{
						TcpListener tcpListener2 = tcpListener;
						if (tcpListener2.Server.IsBound)
						{
							tcpListener2.Stop();
						}
					}
				}
				else
				{
					TcpClient tcpClient2 = tcpClient;
					if (tcpClient2.Connected)
					{
						tcpClient2.Close();
					}
				}
			}
			player.ConnectionObject = null;
		}

		public override void JoinLobby(NetworkLobby lobby)
		{
			try
			{
				IPEndPoint iPEndPoint = (IPEndPoint)lobby.ConnectionObject;
				TcpClient tcpClient = new TcpClient(iPEndPoint.AddressFamily);
				NetworkPlayer networkPlayer = (NetworkManager.Instance.HostPlayer = new NetworkPlayer(tcpClient));
				networkPlayer.Host = true;
				networkPlayer.ID = 1;
				NetworkManager.Instance.Players.Add(networkPlayer);
				tcpClient.Connect(iPEndPoint);
				InvokeLobbyJoined(lobby);
				CurrentLobby = lobby;
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
				NetworkManager.Instance.CleanUpEverything(true);
				InvokeLobbyJoined(null);
				WindowManager.Instance.ShowMessageBox("FailedJoiningGame".Loc(), true, DialogWindow.DialogType.Error);
			}
		}

		public override void LeaveLobby()
		{
			if (CurrentLobby != null)
			{
				if (_lobbyClient != null)
				{
					_lobbyClient.Close();
					_lobbyClient = null;
				}
				InvokeLobbyJoined(null);
			}
		}

		public override void UpdateNewPlayer(NetworkPlayer player)
		{
		}

		public override bool SendData(NetworkPlayer player, byte[] data, bool now)
		{
			TcpClient tcpClient = (TcpClient)player.ConnectionObject;
			lock (tcpClient)
			{
				tcpClient.Client.Send(data);
			}
			return false;
		}

		public override byte[] ReceiveData(out NetworkPlayer from)
		{
			from = null;
			for (int i = 0; i < NetworkManager.Instance.Players.Count; i++)
			{
				NetworkPlayer networkPlayer = NetworkManager.Instance.Players[i];
				TcpClient tcpClient;
				if (!networkPlayer.Self && (tcpClient = networkPlayer.ConnectionObject as TcpClient) != null && tcpClient.Available > ((networkPlayer.BufferLength == 0) ? 3 : 0))
				{
					lock (tcpClient)
					{
						from = networkPlayer;
						byte[] array = new byte[tcpClient.Available];
						tcpClient.Client.Receive(array);
						return array;
					}
				}
			}
			return null;
		}

		public override int GetMaxPacketSize()
		{
			return 8192;
		}

		public override string Diagnostics(NetworkPlayer player)
		{
			TcpClient tcpClient;
			if ((tcpClient = player.ConnectionObject as TcpClient) != null)
			{
				return "Remote: " + tcpClient.Client.RemoteEndPoint.ToString() + ", local: " + tcpClient.Client.LocalEndPoint.ToString();
			}
			return "N/A";
		}

		private string GetLanIdentifier()
		{
			return SystemInfo.deviceUniqueIdentifier;
		}

		public override ValueTuple<string, string> GetNameAndIdentifier()
		{
			string text = SystemInfo.deviceName;
			if (File.Exists("LanName.txt"))
			{
				text = File.ReadAllText("LanName.txt");
				int num = text.IndexOf('\r');
				if (num < 0)
				{
					num = text.IndexOf('\n');
				}
				if (num >= 0)
				{
					text = text.Substring(0, num);
				}
			}
			return new ValueTuple<string, string>(text, GetLanIdentifier());
		}

		public override bool IsLobbyValid()
		{
			TcpClient tcpClient;
			if (CurrentLobby != null && !NetworkManager.IsHost && (tcpClient = NetworkManager.Instance.HostPlayer.ConnectionObject as TcpClient) != null)
			{
				return tcpClient.Connected;
			}
			return true;
		}

		public override Texture2D GetPlayerAvatar(NetworkPlayer player, out bool completed)
		{
			completed = true;
			return null;
		}

		public override NetworkPlayer HandleReconnection(NetworkPlayer player, byte id)
		{
			NetworkManager.Instance.Players.Remove(player);
			NetworkPlayer player2 = NetworkManager.GetPlayer(id);
			player2.ConnectionObject = player.ConnectionObject;
			NetworkManager.Instance.ResetIDMap();
			return player2;
		}

		public override void UpdatePing(NetworkPlayer player)
		{
			TcpClient tcpClient;
			if (!player.Self && (NetworkManager.IsHost || player.Host) && (tcpClient = player.ConnectionObject as TcpClient) != null)
			{
				IPAddress address = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address;
				if (address.AddressFamily == AddressFamily.InterNetwork)
				{
					try
					{
						System.Net.NetworkInformation.Ping ping;
						lock (_pings)
						{
							if (_pings.Count > 0)
							{
								ping = _pings[0];
								_pings.RemoveAt(0);
							}
							else
							{
								ping = new System.Net.NetworkInformation.Ping();
								ping.PingCompleted += P_PingCompleted;
							}
						}
						ping.SendAsync(address, 1000, new ValueTuple<System.Net.NetworkInformation.Ping, NetworkPlayer>(ping, player));
						return;
					}
					catch (Exception)
					{
					}
				}
			}
			player.Ping = null;
		}

		private void P_PingCompleted(object sender, PingCompletedEventArgs e)
		{
			ValueTuple<System.Net.NetworkInformation.Ping, NetworkPlayer> obj = (ValueTuple<System.Net.NetworkInformation.Ping, NetworkPlayer>)e.UserState;
			System.Net.NetworkInformation.Ping item = obj.Item1;
			NetworkPlayer item2 = obj.Item2;
			if (e.Reply != null && e.Reply.Status == IPStatus.Success)
			{
				item2.Ping = e.Reply.RoundtripTime;
			}
			else
			{
				item2.Ping = null;
			}
			lock (_pings)
			{
				_pings.Add(item);
			}
		}

		public override string GetBanInfo(NetworkPlayer player)
		{
			TcpClient tcpClient;
			if ((tcpClient = player.ConnectionObject as TcpClient) != null)
			{
				return ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
			}
			return null;
		}

		public override string FilterMessage(string message, NetworkPlayer player)
		{
			return message;
		}

		public override string FilterName(string name, NetworkPlayer player)
		{
			return name;
		}

		public override bool FilterName(string name)
		{
			return true;
		}

		public override void QueryLobbies()
		{
			base.QueryLobbies();
			if (_lobbyListener == null)
			{
				_lobbyListener = new UdpClient
				{
					EnableBroadcast = true
				};
			}
			if (_lobbyListenerv6 == null)
			{
				_lobbyListenerv6 = new UdpClient(AddressFamily.InterNetworkV6);
			}
			try
			{
				_lobbyListener.SendString("SwincQuery" + Versioning.SimpleNetworkVersionString, new IPEndPoint(IPAddress.Broadcast, Options.LobbyPort));
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
			}
			try
			{
				_lobbyListenerv6.SendString("SwincQuery" + Versioning.SimpleNetworkVersionString, new IPEndPoint(IPAddress.Parse("ff02::1"), Options.LobbyPort));
			}
			catch (Exception ex2)
			{
				Debug.Log(ex2.ToString());
			}
		}

		public override string GetLocalConnectionData()
		{
			return GetIP4Address();
		}

		public override bool TryReconnection(NetworkPlayer newHost)
		{
			TcpClient tcpClient = new TcpClient();
			try
			{
				NetworkPlayer networkPlayer = (NetworkManager.Instance.HostPlayer = newHost);
				networkPlayer.Host = true;
				tcpClient.Connect(new IPEndPoint(IPAddress.Parse(newHost.ReconnectionData), Options.GamePort));
				networkPlayer.ConnectionObject = tcpClient;
				NetworkMessaging.ReconnectMessage(newHost);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.ToString());
				try
				{
					tcpClient.Close();
				}
				catch (Exception)
				{
				}
				return false;
			}
			return true;
		}

		public override void MakeHost()
		{
			Thread.Sleep(500);
			_lobbyClient = new UdpClient(new IPEndPoint(IPAddress.Parse(GetIP4Address()), Options.LobbyPort))
			{
				EnableBroadcast = true
			};
			TcpListener tcpListener = new TcpListener(IPAddress.Parse(GetIP4Address()), Options.GamePort);
			NetworkManager.Self.ConnectionObject = tcpListener;
			tcpListener.Start();
		}

		private void Update()
		{
			if (_lobbyClient != null && _lobbyClient.Available > 0)
			{
				IPEndPoint remoteEndPoint = new IPEndPoint(0L, 0);
				if (_lobbyClient.ReceiveString(ref remoteEndPoint).StartsWith("SwincQuery") && NetworkManager.Instance.Players.Count < 4)
				{
					_lobbyClient.SendString(CurrentLobby.GetMeta(), remoteEndPoint);
				}
			}
			if (_lobbyListener != null && _lobbyListener.Available > 0)
			{
				IPEndPoint remoteEndPoint2 = new IPEndPoint(0L, 0);
				string text = _lobbyListener.ReceiveString(ref remoteEndPoint2);
				if (text.StartsWith("QUERY"))
				{
					NetworkLobby item = NetworkLobby.ReceiveMeta(text, Options.LobbyPort, remoteEndPoint2);
					Lobbies.Add(item);
					InvokeLobbyQuery();
				}
			}
			if (_lobbyListenerv6 != null && _lobbyListenerv6.Available > 0)
			{
				IPEndPoint remoteEndPoint3 = new IPEndPoint(0L, 0);
				string text2 = _lobbyListenerv6.ReceiveString(ref remoteEndPoint3);
				if (text2.StartsWith("QUERY"))
				{
					NetworkLobby item2 = NetworkLobby.ReceiveMeta(text2, Options.LobbyPort, remoteEndPoint3);
					Lobbies.Add(item2);
					InvokeLobbyQuery();
				}
			}
			TcpListener tcpListener = (TcpListener)NetworkManager.Self.ConnectionObject;
			if (tcpListener == null)
			{
				return;
			}
			while (tcpListener.Pending())
			{
				TcpClient tcpClient = tcpListener.AcceptTcpClient();
				IPEndPoint iPEndPoint;
				if ((iPEndPoint = tcpClient.Client.RemoteEndPoint as IPEndPoint) != null && !GameSettings.Instance.IsReferenceNull() && GameSettings.Instance.BanList.Contains(iPEndPoint.Address.ToString()))
				{
					tcpClient.Close();
					continue;
				}
				NetworkPlayer item3 = new NetworkPlayer(tcpClient);
				NetworkManager.Instance.Players.Add(item3);
				NetworkManager.SetLobbyMetaData("Players", NetworkManager.Instance.Players.Count.ToString());
				NetworkManager.SetLobbyMetaData("AvailableSpots", NetworkManager.Instance.GetAvailableSpots().ToString());
			}
		}
	}
}
