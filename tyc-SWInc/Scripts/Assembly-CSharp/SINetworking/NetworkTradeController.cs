using System;
using System.Collections.Generic;
using System.Linq;

namespace SINetworking
{
	public class NetworkTradeController
	{
		public Dictionary<uint, NetworkTrade> Trades = new Dictionary<uint, NetworkTrade>();

		public uint NextTradeID = 1u;

		private static List<NetworkTrade> _deleteCache = new List<NetworkTrade>();

		public void Reset()
		{
			Trades.Values.ForEachEnum(delegate(NetworkTrade x)
			{
				x.State = NetworkTrade.Status.Cancelled;
			});
			Trades.Clear();
			NextTradeID = 1u;
		}

		public uint GetTradeID()
		{
			uint nextTradeID = NextTradeID;
			NextTradeID++;
			return nextTradeID;
		}

		public void CancelAllTradesFor(object r, NetworkTrade excluding = null, bool rejected = false)
		{
			if (r == null)
			{
				return;
			}
			_deleteCache.Clear();
			_deleteCache.AddRange(Trades.Values);
			for (int i = 0; i < _deleteCache.Count; i++)
			{
				NetworkTrade networkTrade = _deleteCache[i];
				if (networkTrade != excluding && networkTrade.UsingResource(r))
				{
					CancelTrade(networkTrade, rejected);
				}
			}
			_deleteCache.Clear();
		}

		public void CancelAllTradesFor(NetworkPlayer player, bool disconnect)
		{
			_deleteCache.Clear();
			_deleteCache.AddRange(Trades.Values);
			for (int i = 0; i < _deleteCache.Count; i++)
			{
				NetworkTrade networkTrade = _deleteCache[i];
				if ((networkTrade.Sender == player || networkTrade.Receiver == player) && (networkTrade.CancelOnDisconnect || !disconnect))
				{
					CancelTrade(networkTrade, false);
				}
			}
			_deleteCache.Clear();
		}

		public void SendTrade(NetworkTrade trade)
		{
			NetworkMeta.CheckDirty();
			Trades[trade.ID] = trade;
			ChatWindow.ReceiveMessage(trade.Receiver, true, false, trade.GetSendMessage(), trade);
			NetworkMessaging.SendNewTrade(trade, NetworkMessaging.MessageTarget.Specifically, trade.Receiver.ID);
		}

		public void CancelTrade(NetworkTrade trade, bool rejected)
		{
			trade.State = (rejected ? NetworkTrade.Status.Rejected : NetworkTrade.Status.Cancelled);
			NetworkPlayer networkPlayer = ((trade.Sender == NetworkManager.Self) ? trade.Receiver : trade.Sender);
			trade.OnCancelled();
			if (networkPlayer != null)
			{
				NetworkMessaging.SendTradeState(trade.ID, trade.State, NetworkMessaging.MessageTarget.Specifically, networkPlayer.ID);
			}
			Trades.Remove(trade.ID);
		}

		public void AcceptTrade(NetworkTrade trade)
		{
			object resource = trade.GetResource();
			CancelAllTradesFor(resource, trade, true);
			NetworkMessaging.SendTradeState(trade.ID, NetworkTrade.Status.Accepted, NetworkMessaging.MessageTarget.Specifically, trade.Sender.ID);
			trade.AcceptTrade();
			trade.State = NetworkTrade.Status.Accepted;
			if (!trade.KeepOnAccept)
			{
				Trades.Remove(trade.ID);
			}
		}

		public void CreateOffer(NetworkPlayer target, float defaultAmount, Func<uint, float, NetworkTrade> create, object resource)
		{
			if (Trades.Values.Any((NetworkTrade x) => x.UsingResource(resource)))
			{
				return;
			}
			WindowManager.SpawnInputDialog("OfferTrade".Loc(target.Name), "Trade".Loc(), defaultAmount.Currency(false), delegate(string x)
			{
				float value;
				if (x.Replace(".", "").ConvertToFloatTry(out value))
				{
					NetworkMessaging.GetGlobalNetworkID(delegate(uint id)
					{
						SendTrade(create(id, value.FromCurrency()));
					}, NetworkManager.NetworkIDType.Trade);
				}
			});
		}

		public void CreateOffer(Func<uint, NetworkTrade> create)
		{
			NetworkMessaging.GetGlobalNetworkID(delegate(uint id)
			{
				SendTrade(create(id));
			}, NetworkManager.NetworkIDType.Trade);
		}
	}
}
