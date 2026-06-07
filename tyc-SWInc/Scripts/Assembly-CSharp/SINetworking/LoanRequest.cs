using System.IO;

namespace SINetworking
{
	public class LoanRequest : NetworkTrade
	{
		public float Interest;

		public int Months;

		public LoanRequest(uint id, NetworkPlayer sender, NetworkPlayer receiver, float offer, float interest, int months)
			: base(id, sender, receiver, offer)
		{
			Interest = interest;
			Months = months;
		}

		public override T GetResourceGen<T>()
		{
			return null;
		}

		public override object GetResource()
		{
			return null;
		}

		public override bool UsingResource(object r)
		{
			return false;
		}

		public override float GetBaseWorth()
		{
			return Offer;
		}

		public override void AcceptTrade()
		{
		}

		public override byte TypeID()
		{
			return 6;
		}

		public override void Focus()
		{
		}

		public override string GetReceiveMessage()
		{
			return "LoanRequest".LocColorAll(base.Sender, Offer.Currency(), Interest.ToPercent(), SDateTime.DateDiff(Months * GameSettings.DaysPerMonth));
		}

		public override string GetSendMessage()
		{
			return GetReceiveMessage();
		}

		public override string Description()
		{
			return "Loan".Loc();
		}

		public override void WriteSubData(Stream st)
		{
			st.WriteFloat(Interest);
			st.WriteInt(Months);
		}

		public override void AcceptTradeSender()
		{
			float num = (Interest * Offer + Offer) / (float)Months;
			float monthlyInterest = Interest * Offer / (float)Months;
			GameSettings.Instance.Loans.Add(new Loan(Months, num, Interest, monthlyInterest, ReceiverCompany));
			HUD.Instance.loanWindow.UpdateLoans();
			SenderCompany.MakeTransaction(Offer, Company.TransactionCategory.Loan, false);
			ReceiverCompany.MakeTransaction(0f - Offer, Company.TransactionCategory.Loan, SenderCompany.Name);
			GameSettings.Instance.TransmitExtraWorth();
		}
	}
}
