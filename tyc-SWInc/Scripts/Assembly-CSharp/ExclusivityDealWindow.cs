using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class ExclusivityDealWindow : MonoBehaviour
{
	public GUIWindow Window;

	public DatePicker datePicker;

	public Text LengthText;

	public Text PriceText;

	[NonSerialized]
	private Dictionary<Company, double> _costs = new Dictionary<Company, double>();

	[NonSerialized]
	private List<SoftwareProduct> _products;

	private int _lastRange = 6;

	public void Show(List<SoftwareProduct> ps)
	{
		float num = (float)GameSettings.Instance.MyCompany.Distribution.ActualUsers / (float)MarketSimulation.Population;
		HashSet<Company> hashSet = new HashSet<Company>();
		for (int i = 0; i < ps.Count; i++)
		{
			SoftwareProduct softwareProduct = ps[i];
			if (hashSet.Contains(softwareProduct.DevCompany))
			{
				ps.RemoveAt(i);
				i--;
			}
			else if (softwareProduct.DevCompany != GameSettings.Instance.MyCompany && softwareProduct.DevCompany.OwnerCompany != GameSettings.Instance.MyCompany)
			{
				float num2 = SDateTime.GetMonths(softwareProduct.DevCompany.Founded, SDateTime.Now()).MapRange(0f, 120f, 0.05f, 0.45f, true);
				if (num < num2)
				{
					hashSet.Add(softwareProduct.DevCompany);
					ps.RemoveAt(i);
					i--;
				}
			}
		}
		if (ps.Count == 0)
		{
			if (hashSet.Count > 0)
			{
				WindowManager.Instance.ShowMessageBox("ExclusivityDealReject".Loc(hashSet.ToList()), true, DialogWindow.DialogType.Warning);
			}
		}
		else
		{
			GameSettings.ForcePause = true;
			datePicker.UpdateCombos();
			datePicker.CurrentDate = SDateTime.Now() + _lastRange;
			_products = ps;
			Window.Show();
			DateChanged();
		}
	}

	public void DateChanged()
	{
		if (datePicker.CurrentDate > SDateTime.Now())
		{
			int monthsFlat = SDateTime.GetMonthsFlat(SDateTime.Now(), datePicker.CurrentDate);
			_costs.Clear();
			for (int i = 0; i < _products.Count; i++)
			{
				SoftwareProduct softwareProduct = _products[i];
				if (!softwareProduct.CanMakeExclusive())
				{
					_products.RemoveAt(i);
					i--;
				}
				else if (softwareProduct.DevCompany != GameSettings.Instance.MyCompany && softwareProduct.DevCompany.OwnerCompany != GameSettings.Instance.MyCompany)
				{
					_costs.AddUp(softwareProduct.DevCompany, GetExpectedPriceForExclusive(softwareProduct, GameSettings.Instance.MyCompany.Distribution, monthsFlat));
				}
			}
			LengthText.text = SDateTime.DateDiff(SDateTime.Now(), datePicker.CurrentDate + 1);
			PriceText.text = "Cost".Loc() + ": " + _costs.SumSafe((KeyValuePair<Company, double> x) => x.Value).Currency();
		}
		else
		{
			LengthText.text = "";
			PriceText.text = "Cost".Loc() + ": " + "NotApplicableAbbr".Loc();
		}
	}

	public void Accept()
	{
		if (!(datePicker.CurrentDate > SDateTime.Now()))
		{
			return;
		}
		DateChanged();
		foreach (KeyValuePair<Company, double> cost in _costs)
		{
			GameSettings.Instance.MyCompany.MakeTransaction(0.0 - cost.Value, Company.TransactionCategory.Deals, true, "ExclusivityDeal");
			cost.Key.MakeTransaction(cost.Value, Company.TransactionCategory.Deals, true);
		}
		SDateTime sDateTime = datePicker.CurrentDate + new SDateTime(1, 0, 0);
		DistributionPlatform distribution = GameSettings.Instance.MyCompany.Distribution;
		foreach (SoftwareProduct product in _products)
		{
			product.ExclusiveStore = distribution;
			product.ExclusiveEnd = sDateTime;
			NetworkMessaging.SendExclusiveStore(product.ID, distribution.Software.ID, sDateTime, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
		}
		_lastRange = SDateTime.GetMonthsFlat(SDateTime.Now(), datePicker.CurrentDate);
		Window.Close();
	}

	public static double GetExpectedPriceForExclusive(SoftwareProduct p, DistributionPlatform dp, int months)
	{
		float num = p.Category.Retention - SDateTime.GetMonths(p.Release, SDateTime.Now());
		float num2 = 0f;
		foreach (SoftwareProduct item in from x in MarketSimulation.Active.GetAllProducts(true)
			where x.Category == p.Category
			select x)
		{
			if ((float)item.UnitSum > num2)
			{
				num2 = item.UnitSum;
			}
		}
		if (num2 == 0f)
		{
			num2 = (float)p.GetReach() * 0.25f;
		}
		num2 *= 0.125f;
		double num3 = p.RealQuality * p.CreativityScore * (double)num2 * (double)p.Price;
		float num4 = ((float)dp.ActualUsers / (float)MarketSimulation.Population).MapRange(0f, 1f, 1f, 0.75f, true);
		if (p.SubscriptionBased)
		{
			num3 /= 0.08;
		}
		double num5 = Math.Max(num3 - p.Sum * 0.5, 500000.0);
		double num6 = num5 * 0.5;
		if (num > 0f)
		{
			float num7 = 1f - num / p.Category.Retention;
			for (int num8 = 0; num8 < months; num8++)
			{
				double num9 = num5 - num6;
				if (num9 < 50000.0)
				{
					num6 = num5;
					break;
				}
				num6 += num9 * (double)num7;
			}
		}
		else
		{
			int num10 = Mathf.CeilToInt(0f - num);
			if (num10 > 1)
			{
				num6 *= (double)Mathf.Pow(0.75f, num10);
			}
		}
		return (Math.Max(20000.0, num6) + (double)(months * 5000)) * 1.25 * (double)num4;
	}

	private void Start()
	{
		Window.OnClose = delegate
		{
			GameSettings.ForcePause = false;
		};
	}
}
