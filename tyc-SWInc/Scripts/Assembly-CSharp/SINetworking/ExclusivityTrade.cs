using System.IO;

namespace SINetworking
{
	public class ExclusivityTrade : NetworkTrade<SoftwareProduct>
	{
		public SDateTime End;

		public ExclusivityTrade(uint id, NetworkPlayer sender, NetworkPlayer receiver, SoftwareProduct resource, float offer, SDateTime end)
			: base(id, sender, receiver, resource, offer)
		{
			End = end;
		}

		public override float GetBaseWorth()
		{
			Company senderCompany = SenderCompany;
			if (((senderCompany != null) ? senderCompany.Distribution : null) != null)
			{
				return (float)ExclusivityDealWindow.GetExpectedPriceForExclusive(Resource, senderCompany.Distribution, SDateTime.GetMonthsFlat(SDateTime.Now(), End));
			}
			return 0f;
		}

		public override void AcceptTrade()
		{
			if (End > SDateTime.Now())
			{
				Company senderCompany = SenderCompany;
				if (((senderCompany != null) ? senderCompany.Distribution : null) != null)
				{
					NetworkMessaging.SendExclusiveStore(Resource.ID, senderCompany.Distribution.Software.ID, End, NetworkMessaging.MessageTarget.Everyone, 0);
					ReceiverCompany.MakeTransaction(Offer, Company.TransactionCategory.Deals, "Trade");
					senderCompany.MakeTransaction(0f - Offer, Company.TransactionCategory.Deals, "Trade");
				}
			}
		}

		public override byte TypeID()
		{
			return 4;
		}

		public override void Focus()
		{
			HUD.Instance.GetProductWindow(null).ShowProductDetails(Resource);
		}

		public override string Description()
		{
			return "ExclusivityTrade".Loc(Resource.Name, End.ToCompactString());
		}

		public override void WriteSubData(Stream st)
		{
			st.WriteUInt(Resource.ID);
			End.WriteData(st);
		}
	}
}
