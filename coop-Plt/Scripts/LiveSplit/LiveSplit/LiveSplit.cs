using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LiveSplit
{
	public static class LiveSplit
	{
		public const string LiveSplitServer = "127.0.0.1";

		public const int LiveSplitPort = 16834;

		public static bool IsConnected;

		public static Socket Socket;

		public static async Task Connect()
		{
			try
			{
				Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				IPEndPoint remoteEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 16834);
				await Socket.ConnectAsync(remoteEP);
				IsConnected = true;
			}
			catch (SocketException ex)
			{
				if (Socket != null)
				{
					Disconnect(force: true);
				}
				Debug.LogWarning(ex.Message);
			}
		}

		public static void Disconnect(bool force = false)
		{
			if (!force && (Socket == null || !IsConnected))
			{
				return;
			}
			IsConnected = false;
			try
			{
				Socket?.Shutdown(SocketShutdown.Both);
				Socket?.Dispose();
			}
			catch (SocketException ex)
			{
				Debug.LogWarning(ex.Message);
			}
		}

		public static async Task SendStart()
		{
			await Send("reset");
			await Send("starttimer");
		}

		public static Task SendSplit()
		{
			return Send("split");
		}

		public static Task SendPause()
		{
			return Send("pause");
		}

		public static async Task<long?> GetFinalTime()
		{
			string text = await SendWithReply("getfinaltime");
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			try
			{
				return (long)TimeSpan.Parse(text).TotalMilliseconds;
			}
			catch
			{
				Debug.LogWarning("Failed to parse time: " + text);
				return null;
			}
		}

		private static async Task Send(string message)
		{
			if (!IsConnected)
			{
				return;
			}
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(message + "\r\n");
				await Socket.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
			}
			catch (SocketException ex)
			{
				if (Socket != null)
				{
					Disconnect(force: true);
				}
				Debug.LogWarning(ex.Message);
			}
		}

		private static async Task<string> SendWithReply(string message)
		{
			if (!IsConnected)
			{
				return null;
			}
			try
			{
				byte[] bytes = Encoding.ASCII.GetBytes(message + "\r\n");
				await Socket.SendAsync(new ArraySegment<byte>(bytes), SocketFlags.None);
				byte[] recv_buffer = new byte[1024];
				int count = await Socket.ReceiveAsync(new ArraySegment<byte>(recv_buffer), SocketFlags.None);
				return Encoding.ASCII.GetString(recv_buffer, 0, count).Trim();
			}
			catch (SocketException ex)
			{
				if (Socket != null)
				{
					Disconnect(force: true);
				}
				Debug.LogWarning(ex.Message);
				return null;
			}
		}
	}
}
