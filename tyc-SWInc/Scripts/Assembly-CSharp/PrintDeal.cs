using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[Serializable]
[AltDeprecate("PID", typeof(uint))]
public class PrintDeal : Deal
{
	public float PerCopy;

	public float Price = 2f;

	public bool Hardware;

	public uint Goal;

	public uint CurrentAmount;

	public IStockable Target;

	public SDateTime EndDate;

	public SDateTime StartDate;

	public PrintDeal(SimulatedCompany company, SimulatedCompany.ProductPrototype product, float offer, float price, uint goal)
		: base(company)
	{
		Target = product;
		Hardware = product.Category.Hardware;
		Price = price;
		PerCopy = offer;
		Goal = goal;
		EndDate = product.ReleaseDate;
	}

	public PrintDeal(SimulatedCompany company, SimulatedCompany.ProductPrototype product, float offer, float price, uint goal, uint id)
		: base(company, id)
	{
		Target = product;
		Hardware = product.Category.Hardware;
		Price = price;
		PerCopy = offer;
		Goal = goal;
		EndDate = product.ReleaseDate;
	}

	public static ValueTuple<float, float> GetOfferAndPrice(SoftwareCategory category, float hardwarePrice)
	{
		float playerWorth = Deal.GetPlayerWorth(0.15f, 0.2f);
		float num = MarketSimulation.PhysicalCopyPrice;
		if (category.Hardware)
		{
			num = hardwarePrice * MarketSimulation.HardwareCopyPriceFactor;
			playerWorth = hardwarePrice * (1f + playerWorth);
		}
		else
		{
			playerWorth *= num;
		}
		return new ValueTuple<float, float>(playerWorth, num);
	}

	public PrintDeal()
	{
	}

	public override string ReputationCategory()
	{
		return null;
	}

	public override void Accept(Company company)
	{
		PrintJob printJob = new PrintJob(Target, ID);
		GameSettings.Instance.AddPrintOrder(printJob, false);
		if (printJob.Hardware)
		{
			GameSettings.Instance.PromptPrintAssignment(printJob);
		}
		HUD.Instance.distributionWindow.Show(printJob);
		StartDate = SDateTime.Now();
		base.Accept(company);
	}

	public override void RecalculateWorth()
	{
		PerCopy = GetOfferAndPrice(Target.SWCat, Target.HardwarePrice).Item1;
	}

	public override float Worth()
	{
		return PerCopy;
	}

	public override float Payout()
	{
		return 0f;
	}

	public override float ReputationEffect(bool ending)
	{
		return 0f;
	}

	public override string Description()
	{
		if (Target == null)
		{
			return "";
		}
		if (!Hardware)
		{
			return "PrintDealTitle".Loc(Target.GetName());
		}
		return "ManufacturingDealTitle".Loc(Target.GetName());
	}

	public override string Title()
	{
		if (!Hardware)
		{
			return "Printing";
		}
		return "Manufacturing";
	}

	public override void HandleUpdate()
	{
	}

	public override bool StillValid(bool active)
	{
		if (base.StillValid(active) && Target != null)
		{
			if (!active)
			{
				if (SDateTime.GetMonths(SDateTime.Now(), EndDate) > 1f)
				{
					return GameSettings.Instance.GetPrintJob(Target) == null;
				}
				return false;
			}
			return true;
		}
		return false;
	}

	public override SDateTime? GetTime()
	{
		return EndDate;
	}

	public void FinalizeDeal()
	{
		if (CurrentAmount < Goal)
		{
			float num = Mathf.Max(0f, SDateTime.GetMonths(SDateTime.Now(), EndDate));
			float num2 = Mathf.Max(0f, SDateTime.GetMonths(StartDate, EndDate));
			float num3 = (float)Goal / num2;
			string bill = Title();
			uint num4 = Goal - CurrentAmount;
			float num5 = (float)num4 - num3 * num;
			if (num5 > 0f)
			{
				float num6 = num5 * Price * 0.1f;
				base.Company.MakeTransaction(0f - num6, Company.TransactionCategory.Deals, true, bill);
				if (num5 > 1000f)
				{
					base.Company.ChangeBusinessRep(-0.25f, "Printing");
				}
				Company client = base.Client;
				if (client != null)
				{
					client.MakeTransaction(num6, Company.TransactionCategory.Deals, true, bill);
				}
				NotificationManager.AddNotification("PrintDealFail2".Loc(num4.ToString("N0"), (client == null) ? "N/A" : client.Name, num6.Currency(), Mathf.FloorToInt(num)), "Box", NotificationManager.NotificationType.Warning);
			}
		}
		else
		{
			base.Company.ChangeBusinessRep((float)Goal / 100000000f, "Printing");
		}
		HUD.Instance.dealWindow.CancelDeal(this, false);
	}

	public override bool Cancel()
	{
		if (!base.Cancel())
		{
			return false;
		}
		if (Target != null)
		{
			GameSettings.Instance.CancelPrintOrder(Target, false);
		}
		return true;
	}

	public override void GetDetailedDescription(List<string> vars, List<string> values)
	{
		vars.AddRange("Amount".Loc(), "Percopy".Loc(), "Expires".Loc());
		values.AddRange(Goal.ToString("N0"), PerCopy.Currency(), EndDate.ToCompactString());
	}

	public override bool MatchSWFilter(SoftwareType t, SoftwareCategory c)
	{
		if (t == null || t == Target.SWType)
		{
			if (c != null)
			{
				return c == Target.SWCat;
			}
			return true;
		}
		return false;
	}

	public override byte GetTypeID()
	{
		return 0;
	}

	public override void WriteTypeData(Stream st)
	{
		st.WriteUInt((Target as SimulatedCompany.ProductPrototype).ForceID());
		st.WriteFloat(PerCopy);
		st.WriteFloat(Price);
		st.WriteUInt(Goal);
	}

	public override IReferenceFix FixReferences()
	{
		if (base.FixReferences() == null || Target == null)
		{
			return null;
		}
		IStockable target = Target;
		Target = Target.FixReferences() as IStockable;
		if (Target == null && target != null)
		{
			GameSettings.Instance.CancelPrintOrder(target, false);
			return null;
		}
		return this;
	}
}
