using System.IO;

namespace SINetworking
{
	public class PlotTrade : NetworkTrade<PlotArea>
	{
		public PlotTrade(uint id, NetworkPlayer sender, NetworkPlayer receiver, PlotArea resource, float offer)
			: base(id, sender, receiver, resource, offer)
		{
		}

		public override float GetBaseWorth()
		{
			return Resource.Price;
		}

		public override void AcceptTrade()
		{
			if (Resource.MonthsLeft > 0)
			{
				ReceiverCompany.MakeTransaction((float)(-Resource.MonthsLeft) * Resource.Monthly, Company.TransactionCategory.Construction, false, "Plot");
				Resource.MonthsLeft = 0;
			}
			ReceiverCompany.MakeTransaction(Offer, Company.TransactionCategory.Deals, "Trade");
			SenderCompany.MakeTransaction(0f - Offer, Company.TransactionCategory.Deals, "Trade");
			NetworkMessaging.SendPlotOwner(Resource.ID, base.Sender.ID, false, NetworkMessaging.MessageTarget.Everyone, 0);
		}

		public override byte TypeID()
		{
			return 2;
		}

		public override void Focus()
		{
			HUD.Instance.BuildMode = true;
			PlotController.Instance.gameObject.SetActive(true);
			CameraScript.Instance.MoveTo(Resource.Center.ToVector3().FlattenVector3(), 0);
		}

		public override string Description()
		{
			return "SinglePlot".Loc();
		}

		public override void WriteSubData(Stream st)
		{
			st.WriteUInt(Resource.ID);
		}
	}
}
