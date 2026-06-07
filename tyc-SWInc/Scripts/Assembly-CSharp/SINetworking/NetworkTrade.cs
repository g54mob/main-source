using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SINetworking
{
	[Serializable]
	public abstract class NetworkTrade : IByteData
	{
		public enum Status
		{
			Waiting = 0,
			Accepted = 1,
			Rejected = 2,
			Cancelled = 3
		}

		public readonly uint ID;

		private readonly byte _sender;

		private readonly byte _receiver;

		[NonSerialized]
		private NetworkPlayer _cachedSender;

		[NonSerialized]
		private NetworkPlayer _cachedReceiver;

		public Company SenderCompany;

		public Company ReceiverCompany;

		public readonly float Offer;

		public Status State;

		public byte SenderID
		{
			get
			{
				return _sender;
			}
		}

		public byte ReceiverID
		{
			get
			{
				return _receiver;
			}
		}

		public bool IsSender
		{
			get
			{
				return _sender == NetworkManager.LocalPlayerID;
			}
		}

		public bool IsReceiver
		{
			get
			{
				return _receiver == NetworkManager.LocalPlayerID;
			}
		}

		public NetworkPlayer Sender
		{
			get
			{
				if (_cachedSender == null || !_cachedSender.Connected)
				{
					_cachedSender = NetworkManager.GetPlayer(_sender);
				}
				return _cachedSender;
			}
		}

		public NetworkPlayer Receiver
		{
			get
			{
				if (_cachedReceiver == null || !_cachedReceiver.Connected)
				{
					_cachedReceiver = NetworkManager.GetPlayer(_receiver);
				}
				return _cachedReceiver;
			}
		}

		public NetworkPlayer OtherPlayer
		{
			get
			{
				if (!IsSender)
				{
					return Sender;
				}
				return Receiver;
			}
		}

		public virtual bool KeepOnAccept
		{
			get
			{
				return false;
			}
		}

		public virtual bool CancelForSender
		{
			get
			{
				return false;
			}
		}

		public virtual bool CancelOnDisconnect
		{
			get
			{
				return true;
			}
		}

		public NetworkTrade()
		{
		}

		protected NetworkTrade(uint id, NetworkPlayer sender, NetworkPlayer receiver, float offer)
		{
			ID = id;
			_sender = sender.ID;
			_cachedSender = sender;
			_receiver = receiver.ID;
			_cachedReceiver = receiver;
			SenderCompany = sender.GetPlayerCompany();
			ReceiverCompany = receiver.GetPlayerCompany();
			Offer = offer;
		}

		public abstract T GetResourceGen<T>() where T : class;

		public abstract object GetResource();

		public abstract bool UsingResource(object r);

		public abstract float GetBaseWorth();

		public abstract void AcceptTrade();

		public virtual void AcceptTradeSender()
		{
		}

		public virtual void OnCancelled()
		{
		}

		public abstract byte TypeID();

		public abstract void Focus();

		public virtual string GetReceiveMessage()
		{
			return "TradeReceiveMessage".LocColorAll(Sender, Description(), GetBaseWorth().Currency(), Offer.Currency());
		}

		public virtual string GetSendMessage()
		{
			return "TradeSendMessage".LocColorAll(Receiver, Description(), GetBaseWorth().Currency(), Offer.Currency());
		}

		public abstract string Description();

		public void WriteData(Stream st)
		{
			st.WriteUInt(ID);
			st.WriteByte(TypeID());
			st.WriteByte(Sender.ID);
			st.WriteByte(Receiver.ID);
			st.WriteFloat(Offer);
			WriteSubData(st);
		}

		public abstract void WriteSubData(Stream st);

		private static string TypeDescription(byte type)
		{
			switch (type)
			{
			case 1:
				return "Stock";
			case 2:
				return "Plot";
			case 3:
				return "IP";
			case 4:
				return "Exclusivity";
			case 5:
				return "Work deal";
			case 6:
				return "Loan";
			default:
				return "Missing";
			}
		}

		public static NetworkTrade ReadData(Stream st)
		{
			uint num = st.ReadUInt();
			if (num == uint.MaxValue)
			{
				return null;
			}
			byte b = (byte)st.ReadByte();
			byte b2 = (byte)st.ReadByte();
			byte b3 = (byte)st.ReadByte();
			NetworkPlayer player = NetworkManager.GetPlayer(b2);
			NetworkPlayer player2 = NetworkManager.GetPlayer(b3);
			float num2 = st.ReadFloat();
			if (player == null || player2 == null)
			{
				Debug.Log(string.Concat(str1: (player == null && player2 == null) ? "sender and receiver" : ((player != null) ? "receiver" : "sender"), str0: string.Format("Trade {0} of type {1}, from {2} to {3} was missing ", num, TypeDescription(b), b2, b3)));
				return null;
			}
			switch (b)
			{
			case 1:
				return new StockTrade(num, player, player2, StockTrade.GetResource(st), num2, st.ReadUInt());
			case 2:
			{
				uint num3 = st.ReadUInt();
				PlotArea plot = GameSettings.Instance.GetPlot(num3);
				if (plot == null)
				{
					Debug.Log(string.Format("Trade {0} of type {1}, from {2} to {3} had non-existent plot ", num, TypeDescription(b), b2, b3) + num3);
					return null;
				}
				return new PlotTrade(num, player, player2, plot, num2);
			}
			case 3:
			{
				uint num5 = st.ReadUInt();
				SoftwareProduct product2 = MarketSimulation.Active.GetProduct(num5, false);
				if (product2 == null)
				{
					Debug.Log(string.Format("Trade {0} of type {1}, from {2} to {3} had non-existent product ", num, TypeDescription(b), b2, b3) + num5);
					return null;
				}
				return new IPTrade(num, player, player2, product2, num2);
			}
			case 4:
			{
				uint num4 = st.ReadUInt();
				SoftwareProduct product = MarketSimulation.Active.GetProduct(num4, false);
				if (product == null)
				{
					Debug.Log(string.Format("Trade {0} of type {1}, from {2} to {3} had non-existent product ", num, TypeDescription(b), b2, b3) + num4);
					return null;
				}
				return new ExclusivityTrade(num, player, player2, product, num2, SDateTime.ReadData(st));
			}
			case 5:
			{
				uint workItemID = st.ReadUInt();
				string workName = st.ReadStringUTF8();
				string unitName = st.ReadStringUTF8();
				float onComplete = st.ReadFloat();
				float perUnit = st.ReadFloat();
				float royalty = st.ReadFloat();
				uint limit = st.ReadUInt();
				SDateTime? endDate = null;
				if (st.ReadBool())
				{
					endDate = SDateTime.ReadData(st);
				}
				List<KeyValuePair<string, string>> info = st.ReadList((Stream s) => new KeyValuePair<string, string>(s.ReadStringUTF8(), s.ReadStringUTF8()));
				return new NetworkDeal(num, player, player2, workItemID, num2, onComplete, perUnit, royalty, limit, endDate, workName, unitName, info);
			}
			case 6:
			{
				float interest = st.ReadFloat();
				int months = st.ReadInt();
				return new LoanRequest(num, player, player2, num2, interest, months);
			}
			case 7:
			{
				NetworkPrintDeal resource = NetworkPrintDeal.ReadData(st);
				return new PrintTrade(num, player, player2, resource, num2);
			}
			default:
				Debug.Log(string.Format("Trade {0} of from {1} did not have recognizable type {2}", num, player.Name, b));
				return null;
			}
		}
	}
	public abstract class NetworkTrade<T> : NetworkTrade where T : class
	{
		public readonly T Resource;

		public NetworkTrade()
		{
		}

		protected NetworkTrade(uint id, NetworkPlayer sender, NetworkPlayer receiver, T resource, float offer)
			: base(id, sender, receiver, offer)
		{
			Resource = resource;
		}

		public override bool UsingResource(object r)
		{
			return Resource.Equals(r);
		}

		public override T1 GetResourceGen<T1>()
		{
			return Resource as T1;
		}

		public override object GetResource()
		{
			return Resource;
		}
	}
}
