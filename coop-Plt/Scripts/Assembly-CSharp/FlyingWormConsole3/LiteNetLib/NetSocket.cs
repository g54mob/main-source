using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FlyingWormConsole3.LiteNetLib
{
	internal sealed class NetSocket
	{
		public const int ReceivePollingTime = 500000;

		private Socket _udpSocketv4;

		private Socket _udpSocketv6;

		private Thread _threadv4;

		private Thread _threadv6;

		private IPEndPoint _bufferEndPointv4;

		private IPEndPoint _bufferEndPointv6;

		private readonly NetManager _listener;

		private const int SioUdpConnreset = -1744830452;

		private static readonly IPAddress MulticastAddressV6;

		internal static readonly bool IPv6Support;

		public volatile bool IsRunning;

		public int LocalPort { get; private set; }

		public short Ttl
		{
			get
			{
				if (_udpSocketv4.AddressFamily == AddressFamily.InterNetworkV6)
				{
					return (short)_udpSocketv4.GetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.HopLimit);
				}
				return _udpSocketv4.Ttl;
			}
			set
			{
				if (_udpSocketv4.AddressFamily == AddressFamily.InterNetworkV6)
				{
					_udpSocketv4.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.HopLimit, value);
				}
				else
				{
					_udpSocketv4.Ttl = value;
				}
			}
		}

		static NetSocket()
		{
			MulticastAddressV6 = IPAddress.Parse("ff02::1");
			IPv6Support = Socket.OSSupportsIPv6;
		}

		public NetSocket(NetManager listener)
		{
			_listener = listener;
		}

		private bool IsActive()
		{
			return IsRunning;
		}

		private bool ProcessError(SocketException ex, EndPoint bufferEndPoint)
		{
			switch (ex.SocketErrorCode)
			{
			case SocketError.Interrupted:
			case SocketError.NotSocket:
				return true;
			default:
				NetDebug.WriteError("[R]Error code: {0} - {1}", (int)ex.SocketErrorCode, ex.ToString());
				_listener.OnMessageReceived(null, ex.SocketErrorCode, (IPEndPoint)bufferEndPoint);
				break;
			case SocketError.MessageSize:
			case SocketError.ConnectionReset:
			case SocketError.TimedOut:
				break;
			}
			return false;
		}

		public void ManualReceive()
		{
			ManualReceive(_udpSocketv4, _bufferEndPointv4);
			if (_udpSocketv6 != null && _udpSocketv6 != _udpSocketv4)
			{
				ManualReceive(_udpSocketv6, _bufferEndPointv6);
			}
		}

		private bool ManualReceive(Socket socket, EndPoint bufferEndPoint)
		{
			try
			{
				int num = socket.Available;
				if (num == 0)
				{
					return false;
				}
				while (num > 0)
				{
					NetPacket packet = _listener.NetPacketPool.GetPacket(NetConstants.MaxPacketSize);
					packet.Size = socket.ReceiveFrom(packet.RawData, 0, NetConstants.MaxPacketSize, SocketFlags.None, ref bufferEndPoint);
					_listener.OnMessageReceived(packet, SocketError.Success, (IPEndPoint)bufferEndPoint);
					num -= packet.Size;
				}
			}
			catch (SocketException ex)
			{
				return ProcessError(ex, bufferEndPoint);
			}
			catch (ObjectDisposedException)
			{
				return true;
			}
			return false;
		}

		private void ReceiveLogic(object state)
		{
			Socket socket = (Socket)state;
			EndPoint remoteEP = new IPEndPoint((socket.AddressFamily == AddressFamily.InterNetwork) ? IPAddress.Any : IPAddress.IPv6Any, 0);
			while (IsActive())
			{
				NetPacket packet;
				try
				{
					if (socket.Available == 0 && !socket.Poll(500000, SelectMode.SelectRead))
					{
						continue;
					}
					packet = _listener.NetPacketPool.GetPacket(NetConstants.MaxPacketSize);
					packet.Size = socket.ReceiveFrom(packet.RawData, 0, NetConstants.MaxPacketSize, SocketFlags.None, ref remoteEP);
					goto IL_0083;
				}
				catch (SocketException ex)
				{
					if (ProcessError(ex, remoteEP))
					{
						break;
					}
				}
				catch (ObjectDisposedException)
				{
					break;
				}
				continue;
				IL_0083:
				_listener.OnMessageReceived(packet, SocketError.Success, (IPEndPoint)remoteEP);
			}
		}

		public bool Bind(IPAddress addressIPv4, IPAddress addressIPv6, int port, bool reuseAddress, IPv6Mode ipv6Mode, bool manualMode)
		{
			if (IsActive())
			{
				return false;
			}
			bool flag = ipv6Mode == IPv6Mode.DualMode && IPv6Support;
			_udpSocketv4 = new Socket(flag ? AddressFamily.InterNetworkV6 : AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
			if (!BindSocket(_udpSocketv4, new IPEndPoint(flag ? addressIPv6 : addressIPv4, port), reuseAddress, ipv6Mode))
			{
				return false;
			}
			LocalPort = ((IPEndPoint)_udpSocketv4.LocalEndPoint).Port;
			if (flag)
			{
				_udpSocketv6 = _udpSocketv4;
			}
			IsRunning = true;
			if (!manualMode)
			{
				_threadv4 = new Thread(ReceiveLogic)
				{
					Name = "SocketThreadv4(" + LocalPort + ")",
					IsBackground = true
				};
				_threadv4.Start(_udpSocketv4);
			}
			else
			{
				_bufferEndPointv4 = new IPEndPoint(IPAddress.Any, 0);
			}
			if (!IPv6Support || ipv6Mode != IPv6Mode.SeparateSocket)
			{
				return true;
			}
			_udpSocketv6 = new Socket(AddressFamily.InterNetworkV6, SocketType.Dgram, ProtocolType.Udp);
			if (BindSocket(_udpSocketv6, new IPEndPoint(addressIPv6, LocalPort), reuseAddress, ipv6Mode))
			{
				if (manualMode)
				{
					_bufferEndPointv6 = new IPEndPoint(IPAddress.IPv6Any, 0);
				}
				else
				{
					_threadv6 = new Thread(ReceiveLogic)
					{
						Name = "SocketThreadv6(" + LocalPort + ")",
						IsBackground = true
					};
					_threadv6.Start(_udpSocketv6);
				}
			}
			return true;
		}

		private bool BindSocket(Socket socket, IPEndPoint ep, bool reuseAddress, IPv6Mode ipv6Mode)
		{
			socket.ReceiveTimeout = 500;
			socket.SendTimeout = 500;
			socket.ReceiveBufferSize = 1048576;
			socket.SendBufferSize = 1048576;
			try
			{
				socket.IOControl(-1744830452, new byte[1], null);
			}
			catch
			{
			}
			try
			{
				socket.ExclusiveAddressUse = !reuseAddress;
				socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, reuseAddress);
			}
			catch
			{
			}
			if (socket.AddressFamily == AddressFamily.InterNetwork)
			{
				Ttl = 255;
				try
				{
					socket.DontFragment = true;
				}
				catch (SocketException ex)
				{
					NetDebug.WriteError("[B]DontFragment error: {0}", ex.SocketErrorCode);
				}
				try
				{
					socket.EnableBroadcast = true;
				}
				catch (SocketException ex2)
				{
					NetDebug.WriteError("[B]Broadcast error: {0}", ex2.SocketErrorCode);
				}
			}
			else if (ipv6Mode == IPv6Mode.DualMode)
			{
				try
				{
					socket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, optionValue: false);
				}
				catch (Exception ex3)
				{
					NetDebug.WriteError("[B]Bind exception (dualmode setting): {0}", ex3.ToString());
				}
			}
			try
			{
				socket.Bind(ep);
				_ = socket.AddressFamily;
				_ = 23;
			}
			catch (SocketException ex4)
			{
				switch (ex4.SocketErrorCode)
				{
				case SocketError.AddressAlreadyInUse:
					if (socket.AddressFamily == AddressFamily.InterNetworkV6 && ipv6Mode != IPv6Mode.DualMode)
					{
						try
						{
							socket.SetSocketOption(SocketOptionLevel.IPv6, SocketOptionName.IPv6Only, optionValue: true);
							socket.Bind(ep);
						}
						catch (SocketException ex5)
						{
							NetDebug.WriteError("[B]Bind exception: {0}, errorCode: {1}", ex5.ToString(), ex5.SocketErrorCode);
							return false;
						}
						return true;
					}
					break;
				case SocketError.AddressFamilyNotSupported:
					return true;
				}
				NetDebug.WriteError("[B]Bind exception: {0}, errorCode: {1}", ex4.ToString(), ex4.SocketErrorCode);
				return false;
			}
			return true;
		}

		public bool SendBroadcast(byte[] data, int offset, int size, int port)
		{
			if (!IsActive())
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			try
			{
				flag = _udpSocketv4.SendTo(data, offset, size, SocketFlags.None, new IPEndPoint(IPAddress.Broadcast, port)) > 0;
				if (_udpSocketv6 != null)
				{
					flag2 = _udpSocketv6.SendTo(data, offset, size, SocketFlags.None, new IPEndPoint(MulticastAddressV6, port)) > 0;
				}
			}
			catch (Exception ex)
			{
				NetDebug.WriteError("[S][MCAST]" + ex);
				return flag;
			}
			return flag || flag2;
		}

		public int SendTo(byte[] data, int offset, int size, IPEndPoint remoteEndPoint, ref SocketError errorCode)
		{
			if (!IsActive())
			{
				return 0;
			}
			try
			{
				Socket socket = _udpSocketv4;
				if (remoteEndPoint.AddressFamily == AddressFamily.InterNetworkV6 && IPv6Support)
				{
					socket = _udpSocketv6;
				}
				return socket.SendTo(data, offset, size, SocketFlags.None, remoteEndPoint);
			}
			catch (SocketException ex)
			{
				switch (ex.SocketErrorCode)
				{
				case SocketError.Interrupted:
				case SocketError.NoBufferSpaceAvailable:
					return 0;
				default:
					NetDebug.WriteError("[S]" + ex);
					break;
				case SocketError.MessageSize:
					break;
				}
				errorCode = ex.SocketErrorCode;
				return -1;
			}
			catch (Exception ex2)
			{
				NetDebug.WriteError("[S]" + ex2);
				return -1;
			}
		}

		public void Close(bool suspend)
		{
			if (!suspend)
			{
				IsRunning = false;
			}
			if (_udpSocketv4 == _udpSocketv6)
			{
				_udpSocketv6 = null;
			}
			if (_udpSocketv4 != null)
			{
				_udpSocketv4.Close();
			}
			if (_udpSocketv6 != null)
			{
				_udpSocketv6.Close();
			}
			_udpSocketv4 = null;
			_udpSocketv6 = null;
			if (_threadv4 != null && _threadv4 != Thread.CurrentThread)
			{
				_threadv4.Join();
			}
			if (_threadv6 != null && _threadv6 != Thread.CurrentThread)
			{
				_threadv6.Join();
			}
			_threadv4 = null;
			_threadv6 = null;
		}
	}
}
