using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenBLive.Runtime.Data;
using OpenBLive.Runtime.Utilities;

namespace OpenBLive.Runtime
{
	public abstract class BLiveClient : IDisposable
	{
		private Timer m_Timer;

		protected string token;

		public event ReceiveDanmakuEvent OnDanmaku;

		public event ReceiveGiftEvent OnGift;

		public event ReceiveGuardBuyEvent OnGuardBuy;

		public event ReceiveSuperChatEvent OnSuperChat;

		public event ReceiveSuperChatDelEvent OnSuperChatDel;

		public event ReceiveLikeEvent OnLike;

		public event ReceiveRawNotice ReceiveNotice;

		public event EventHandler<int> UpdatePopularity;

		public event EventHandler Open;

		public abstract void Connect();

		public abstract void Connect(TimeSpan timeSpan, int count);

		public abstract void Disconnect();

		public abstract void Dispose();

		public abstract void Send(byte[] packet);

		public abstract Task SendAsync(byte[] packet);

		public abstract void Send(Packet packet);

		protected abstract Task SendAsync(Packet packet);

		protected virtual void OnOpen()
		{
			SendAsync(Packet.Authority(token));
			m_Timer?.Dispose();
			m_Timer = new Timer(delegate(object e)
			{
				((BLiveClient)e)?.SendAsync(Packet.HeartBeat());
			}, this, 0, 30000);
		}

		protected void ProcessPacket(ReadOnlySpan<byte> bytes)
		{
			ProcessPacketAsync(new Packet(bytes));
		}

		private void ProcessPacketAsync(Packet packet)
		{
			PacketHeader header = packet.Header;
			switch (header.ProtocolVersion)
			{
			case ProtocolVersion.Zlib:
				break;
			case ProtocolVersion.Brotli:
				break;
			default:
				throw new NotSupportedException("New bilibili danmaku protocol appears, please contact the author if you see this Exception.");
			case ProtocolVersion.UnCompressed:
			case ProtocolVersion.HeartBeat:
				switch (header.Operation)
				{
				case Operation.AuthorityResponse:
					this.Open?.Invoke(this, null);
					break;
				case Operation.HeartBeatResponse:
				{
					Array.Reverse(packet.PacketBody);
					int e = BitConverter.ToInt32(packet.PacketBody);
					this.UpdatePopularity?.Invoke(this, e);
					break;
				}
				case Operation.ServerNotify:
					ProcessNotice(Encoding.UTF8.GetString(packet.PacketBody));
					break;
				case Operation.HeartBeat:
				case (Operation)4:
				case (Operation)6:
				case Operation.Authority:
					break;
				}
				break;
			}
		}

		private void ProcessNotice(string rawMessage)
		{
			JObject jObject = JObject.Parse(rawMessage);
			this.ReceiveNotice?.Invoke(rawMessage, jObject);
			string value = jObject["data"].ToString();
			try
			{
				switch (jObject["cmd"]?.ToString())
				{
				case "LIVE_OPEN_PLATFORM_DM":
				{
					Dm dm = JsonConvert.DeserializeObject<Dm>(value);
					this.OnDanmaku?.Invoke(dm);
					break;
				}
				case "LIVE_OPEN_PLATFORM_SUPER_CHAT":
				{
					SuperChat e2 = JsonConvert.DeserializeObject<SuperChat>(value);
					this.OnSuperChat?.Invoke(e2);
					break;
				}
				case "LIVE_OPEN_PLATFORM_SUPER_CHAT_DEL":
				{
					SuperChatDel e = JsonConvert.DeserializeObject<SuperChatDel>(value);
					this.OnSuperChatDel?.Invoke(e);
					break;
				}
				case "LIVE_OPEN_PLATFORM_SEND_GIFT":
				{
					SendGift sendGift = JsonConvert.DeserializeObject<SendGift>(value);
					this.OnGift?.Invoke(sendGift);
					break;
				}
				case "LIVE_OPEN_PLATFORM_GUARD":
				{
					Guard guard = JsonConvert.DeserializeObject<Guard>(value);
					this.OnGuardBuy?.Invoke(guard);
					break;
				}
				case "LIVE_OPEN_PLATFORM_LIKE":
				{
					Like like = JsonConvert.DeserializeObject<Like>(value);
					this.OnLike?.Invoke(like);
					break;
				}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("json数据解析异常 rawMessage: " + rawMessage + ex.Message);
			}
		}
	}
}
