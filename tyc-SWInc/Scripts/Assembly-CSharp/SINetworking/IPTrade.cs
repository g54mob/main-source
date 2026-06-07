using System.IO;

namespace SINetworking
{
	public class IPTrade : NetworkTrade<SoftwareProduct>
	{
		public IPTrade(uint id, NetworkPlayer sender, NetworkPlayer receiver, SoftwareProduct resource, float offer)
			: base(id, sender, receiver, resource, offer)
		{
		}

		public override float GetBaseWorth()
		{
			return IPDeal.GetWorth(Resource);
		}

		public override void AcceptTrade()
		{
			new IPDeal(Resource, Offer).Accept(SenderCompany);
		}

		public override byte TypeID()
		{
			return 3;
		}

		public override void Focus()
		{
			if (base.Receiver.Self)
			{
				HUD.Instance.ShowMyReleases();
				HUD.Instance.PlayerProductWindow.ModeToggles[0].isOn = true;
				HUD.Instance.PlayerProductWindow.InitMode(0);
				HUD.Instance.PlayerProductWindow.SetContent(IPDeal.GetIP(Resource));
			}
			else
			{
				HUD.Instance.GetProductWindow(null).ShowProductDetails(Resource);
			}
		}

		public override string Description()
		{
			return "IPDeal".Loc(Resource.Name);
		}

		public override void WriteSubData(Stream st)
		{
			st.WriteUInt(Resource.ID);
		}
	}
}
