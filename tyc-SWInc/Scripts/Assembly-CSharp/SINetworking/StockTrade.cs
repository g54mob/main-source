using System.IO;

namespace SINetworking
{
	public class StockTrade : NetworkTrade<NewStock>
	{
		public readonly uint Shares;

		public StockTrade(uint id, NetworkPlayer sender, NetworkPlayer receiver, NewStock resource, float offer, uint shares)
			: base(id, sender, receiver, resource, offer)
		{
			Shares = shares;
		}

		public static NewStock GetResource(Stream st)
		{
			uint id = st.ReadUInt();
			uint buyer = st.ReadUInt();
			Company company = MarketSimulation.Active.GetCompany(id);
			if (company == null)
			{
				return null;
			}
			return company.NewStock.FirstOrDefault((NewStock x) => x.Buyer.ID == buyer);
		}

		public override void WriteSubData(Stream st)
		{
			st.WriteUInt(Resource.Seller.ID);
			st.WriteUInt(Resource.Buyer.ID);
			st.WriteUInt(Shares);
		}

		public override void AcceptTrade()
		{
			Resource.Seller.TradeStock(SenderCompany, Shares, SDateTime.Now(), Offer, Resource);
			if (Resource.Seller.TakeOver.HasValue && Resource.Seller.GetShare() >= 0.75)
			{
				NetworkMessaging.SendBeginTakeover(Resource.Seller.ID, 0u, NetworkMessaging.MessageTarget.Everyone, 0);
			}
		}

		public override byte TypeID()
		{
			return 1;
		}

		public override void Focus()
		{
			HUD.Instance.companyWindow.ShowCompanyDetails(Resource.Seller);
		}

		public override string Description()
		{
			return "TradeShares".Loc(Shares, Resource.Seller.Name);
		}

		public override float GetBaseWorth()
		{
			return (float)(Resource.ShareWorth * (double)Shares);
		}
	}
}
