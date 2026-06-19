using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NativeWebSocket;
using OpenBLive.Runtime.Data;
using OpenBLive.Runtime.Utilities;

namespace OpenBLive.Runtime
{
	public class WebSocketBLiveClient : BLiveClient
	{
		public IList<string> WssLink;

		public WebSocket ws;

		public WebSocketBLiveClient(AppStartInfo info)
		{
			AppStartWebsocketInfo websocketInfo = info.Data.WebsocketInfo;
			WssLink = websocketInfo.WssLink;
			token = websocketInfo.AuthBody;
		}

		public WebSocketBLiveClient(IList<string> wssLink, string authBody)
		{
			WssLink = wssLink;
			token = authBody;
		}

		public override async void Connect()
		{
			string url = WssLink.FirstOrDefault();
			if (string.IsNullOrEmpty(url))
			{
				throw new Exception("wsslink is invalid");
			}
			if (ws != null && ws.State != WebSocketState.Closed)
			{
				await ws.Close();
			}
			ws = new WebSocket(url);
			ws.OnOpen += OnOpen;
			ws.OnMessage += delegate(byte[] data)
			{
				ProcessPacket(data);
			};
			ws.OnError += delegate(string msg)
			{
				Logger.LogError("WebSocket Error Message: " + msg);
			};
			ws.OnClose += delegate(WebSocketCloseCode code)
			{
				Logger.Log("WebSocket Close: " + code);
			};
			await ws.Connect();
		}

		public override async void Connect(TimeSpan timeSpan, int count)
		{
			string url = WssLink.FirstOrDefault();
			if (string.IsNullOrEmpty(url))
			{
				throw new Exception("wsslink is invalid");
			}
			if (ws != null && ws.State != WebSocketState.Closed)
			{
				await ws.Close();
			}
			ws = new WebSocket(url);
			ws.OnOpen += OnOpen;
			ws.OnMessage += delegate(byte[] data)
			{
				ProcessPacket(data);
			};
			ws.OnError += delegate(string msg)
			{
				Logger.LogError("WebSocket Error Message: " + msg);
			};
			ws.OnClose += delegate(WebSocketCloseCode code)
			{
				Logger.Log("WebSocket Close: " + code);
			};
			await ws.Connect(timeSpan, count);
		}

		public override void Disconnect()
		{
			ws?.Close();
			ws = null;
		}

		public override void Dispose()
		{
			Disconnect();
			GC.SuppressFinalize(this);
		}

		public override void Send(byte[] packet)
		{
			if (ws.State == WebSocketState.Open)
			{
				ws.Send(packet);
			}
		}

		public override void Send(Packet packet)
		{
			Send(packet.ToBytes);
		}

		public override Task SendAsync(byte[] packet)
		{
			return Task.Run(delegate
			{
				Send(packet);
			});
		}

		protected override Task SendAsync(Packet packet)
		{
			return SendAsync(packet.ToBytes);
		}
	}
}
