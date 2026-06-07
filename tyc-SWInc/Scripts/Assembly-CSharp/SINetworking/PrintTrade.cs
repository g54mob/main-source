using System.IO;
using System.Text;

namespace SINetworking
{
	public class PrintTrade : NetworkTrade<NetworkPrintDeal>
	{
		public PrintTrade(uint id, NetworkPlayer sender, NetworkPlayer receiver, NetworkPrintDeal resource, float offer)
			: base(id, sender, receiver, resource, offer)
		{
		}

		public override float GetBaseWorth()
		{
			return 0f;
		}

		public override void AcceptTrade()
		{
			GameSettings.Instance.NetworkPrintOrders[ID] = Resource;
			PrintJob printJob = new PrintJob(Resource);
			if (Resource.PerDay != 0)
			{
				printJob.Maximum = Resource.PerDay;
			}
			GameSettings.Instance.AddPrintOrder(printJob, true);
			HUD.Instance.distributionWindow.Show(printJob);
		}

		public override byte TypeID()
		{
			return 7;
		}

		public override void AcceptTradeSender()
		{
			GameSettings.Instance.NetworkPrintOrders[ID] = Resource;
			HUD.Instance.distributionWindow.RefreshDeals();
		}

		public override void OnCancelled()
		{
			GameSettings.Instance.CancelPrintOrder(Resource, false);
			GameSettings.Instance.NetworkPrintOrders.Remove(ID);
			HUD.Instance.distributionWindow.RefreshDeals();
			HUD.Instance.distributionWindow.RefreshOrders();
		}

		private static string GetPrintType(NetworkPrintDeal deal)
		{
			if (!deal.Manufacturing.IsHardware())
			{
				return "Software".Loc();
			}
			return deal.Manufacturing.GetPrettyName();
		}

		public override string GetReceiveMessage()
		{
			StringBuilder stringBuilder = new StringBuilder();
			if (Resource.PerDay != 0)
			{
				stringBuilder.Append("NetworkDealPrintIntro2".Loc(base.Sender.Name, Resource.Cost.Currency(), Resource.PerDay.ToString("N0"), Resource.ProductName + " (" + GetPrintType(Resource) + ")"));
			}
			else
			{
				stringBuilder.Append("NetworkDealPrintIntro1".Loc(base.Sender.Name, Resource.Cost.Currency(), Resource.MaxCopies.ToString("N0"), Resource.ProductName) + " (" + GetPrintType(Resource) + "), ");
				bool flag = false;
				if (Resource.OnCompletion > 0f)
				{
					stringBuilder.Append("NetworkDealCompletion".Loc(Resource.OnCompletion.Currency()));
					flag = true;
				}
				if (Resource.Penalty > 0f)
				{
					stringBuilder.Append(flag ? "AndSeperator".Loc() : " ");
					stringBuilder.Append("NetworkDealPenalty".Loc(Resource.Penalty.Currency()) + " ");
				}
				if (Resource.Deadline.HasValue)
				{
					if (flag)
					{
						stringBuilder.Append(" ");
					}
					stringBuilder.Append("NetworkDealDeadline".Loc(Resource.Deadline.Value.ToCompactString2()));
				}
			}
			return stringBuilder.ToString().TrimEnd();
		}

		public override string GetSendMessage()
		{
			return GetReceiveMessage();
		}

		public override void Focus()
		{
			if (Resource.Manufacturing.IsHardware())
			{
				HUD.Instance.ManufacturingWindow.Show(Resource.Manufacturing, Resource.Features, Resource.FeatureFactors);
			}
		}

		public override string Description()
		{
			return null;
		}

		public override void WriteSubData(Stream st)
		{
			Resource.WriteData(st);
		}
	}
}
