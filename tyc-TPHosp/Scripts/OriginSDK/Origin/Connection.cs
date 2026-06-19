using System;
using System.Net;
using System.Net.Sockets;

namespace Origin
{
	internal class Connection
	{
		public delegate void DisconnectedEvent();

		private MessageBuffer readBuffer = new MessageBuffer(1024);

		private MessageBuffer writeBuffer = new MessageBuffer(1024);

		private Socket client;

		public MessageBuffer ReadBuffer => readBuffer;

		public MessageBuffer WriteBuffer => writeBuffer;

		public bool IsConnected
		{
			get
			{
				if (client != null)
				{
					return client.Connected;
				}
				return false;
			}
		}

		public event DisconnectedEvent Disconnected;

		public bool Connect(string ip, int port)
		{
			client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			try
			{
				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse(ip), port);
				client.Connect(remoteEP);
				SocketConnected();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Connection::Connect An exception occurred during connection attempt: " + ex.Message);
				Disconnect();
				if (this.Disconnected != null)
				{
					this.Disconnected();
				}
				return false;
			}
			writeBuffer.MessageAvailable += SendMessage;
			return true;
		}

		private void SendMessage()
		{
			if (client != null)
			{
				SocketAsyncEventArgs e = new SocketAsyncEventArgs();
				e.Completed += SendCompleted;
				byte[] array = writeBuffer.Pop(MessageBuffer.SeparatorMode.LeaveSeparator);
				e.SetBuffer(array, 0, array.Length);
				client.SendAsync(e);
			}
		}

		private void SendCompleted(object sender, SocketAsyncEventArgs e)
		{
			if (e.SocketError != SocketError.Success)
			{
				Disconnect();
				if (this.Disconnected != null)
				{
					this.Disconnected();
				}
			}
		}

		private void SocketConnected()
		{
			SocketAsyncEventArgs e = new SocketAsyncEventArgs();
			e.Completed += ReceiveAsyncEvent;
			e.SetBuffer(new byte[4096], 0, 4096);
			if (!client.ReceiveAsync(e))
			{
				ReceiveAsyncEvent(null, e);
			}
		}

		private void ReceiveAsyncEvent(object sender, SocketAsyncEventArgs e)
		{
			if (e.SocketError == SocketError.Success && e.BytesTransferred > 0)
			{
				readBuffer.Push(e.Buffer, e.BytesTransferred, MessageBuffer.SeparatorMode.LeaveSeparator);
				if (client != null)
				{
					e.SetBuffer(new byte[4096], 0, 4096);
					client.ReceiveAsync(e);
				}
			}
			else if (e.BytesTransferred == 0)
			{
				Disconnect();
				if (this.Disconnected != null)
				{
					this.Disconnected();
				}
			}
		}

		internal void Disconnect()
		{
			if (client != null)
			{
				if (client.Connected)
				{
					client.Disconnect(reuseSocket: false);
				}
				client = null;
			}
		}
	}
}
