using Photon.Pun;
using __Project__.Scripts.Data;
using __Project__.Scripts.WholeSale;

namespace __Project__.Scripts.Multiplayer
{
	public class NetworkWholeSaleManager : NoktaSingletonPunCallbacks<NetworkWholeSaleManager>
	{
		private WholeSaleManager m_WholeSaleManager;

		private void Start()
		{
		}

		private void OnSyncRequest(string invokerUserID)
		{
		}

		public void NetworkOnWholeSaleOfferAccepted_Broadcast()
		{
		}

		[PunRPC]
		public void NetworkOnDelayedPopupAccepted_RPC()
		{
		}

		public void NetworkOnWholeSaleOfferDeclined_Broadcast()
		{
		}

		[PunRPC]
		public void NetworkOnDelayedPopupDeclined_RPC()
		{
		}

		public void NetworkOnWholeSaleOfferCancelled_Broadcast()
		{
		}

		[PunRPC]
		public void NetworkOnDelayedPopupCancelled_RPC()
		{
		}

		public void NetworkOnDelayedPopupStarted_Broadcast()
		{
		}

		[PunRPC]
		public void NetworkOnDelayedPopupStarted_RPC()
		{
		}

		public void NetworkOnDelayedPopupCompleted_Broadcast()
		{
		}

		[PunRPC]
		public void NetworkOnDelayedPopupCompleted_RPC()
		{
		}

		public void NetworkRequestOfferData_Broadcast()
		{
		}

		[PunRPC]
		public void NetworkRequestOfferData_RPC()
		{
		}

		public void NetworkGenerateBuyOffer_Broadcast(bool m_IsPurchase, bool CanAcceptOffer, int m_RandomProductCount, int m_RandomProductID, float m_FinalPrice, int stockCount, float AvgCost, float BoxMarketPrice, float m_InitialPrice)
		{
		}

		[PunRPC]
		public void NetworkGenerateBuyOffer_RPC(bool m_IsPurchase, bool CanAcceptOffer, int m_RandomProductCount, int m_RandomProductID, float m_FinalPrice, int stockCount, float AvgCost, float BoxMarketPrice, float m_InitialPrice)
		{
		}

		public void NetworkGenerateSellOffer_Broadcast(bool m_IsPurchase, bool CanAcceptOffer, int piecesCount, int m_RandomProductID, float m_FinalPrice, int stockCount, float AvgCost, float SalesPrice)
		{
		}

		[PunRPC]
		public void NetworkGenerateSellOffer_RPC(bool m_IsPurchase, bool CanAcceptOffer, int piecesCount, int m_RandomProductID, float m_FinalPrice, int stockCount, float AvgCost, float SalesPrice)
		{
		}

		public void NetworkOnWholesaleOffer_Broadcast(CategorySignData categorySignData, int displayViewId)
		{
		}

		[PunRPC]
		public void NetworkOnWholesaleOffer_RPC(string CategorySignData, int displayViewId)
		{
		}
	}
}
