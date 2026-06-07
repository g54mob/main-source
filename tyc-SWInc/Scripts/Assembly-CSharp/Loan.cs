using System;

[Serializable]
public class Loan : IReferenceFix
{
	public int Months;

	public readonly float Interest;

	public readonly float MonthlyInterest;

	[AltWasFloat(0)]
	public readonly double Monthly;

	[AltWasFloat(0)]
	public readonly double Principal;

	public Company Payee;

	public Loan()
	{
	}

	public Loan(int months, double monthly, float interest, float monthlyInterest, Company payee = null)
	{
		Months = months;
		Monthly = monthly;
		Interest = interest;
		MonthlyInterest = monthlyInterest;
		Principal = (double)months * monthly - (double)((float)months * monthlyInterest);
		Payee = payee;
	}

	public IReferenceFix FixReferences()
	{
		if (Payee != null)
		{
			string name = Payee.Name;
			Payee = MarketSimulation.Active.GetCompany(Payee.ID);
			if (Payee != null)
			{
				return this;
			}
			SelectorController.MissingDataHost.Add(name);
			return null;
		}
		return this;
	}
}
