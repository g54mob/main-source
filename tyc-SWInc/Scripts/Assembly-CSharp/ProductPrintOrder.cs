using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[AltDeprecate("ProductIDs", typeof(uint[]))]
public class ProductPrintOrder : IProductOrder, IReferenceFix, IFormatColorObject
{
	public uint TotalCopies;

	public IStockable[] Stockables;

	public uint[] Copies;

	public ProductPrintOrder()
	{
		TotalCopies = 0u;
		Stockables = Array.Empty<IStockable>();
		Copies = Array.Empty<uint>();
	}

	public ProductPrintOrder(IStockable st, uint copies)
	{
		Stockables = new IStockable[1] { st.DeferStock };
		Copies = new uint[1] { copies };
		TotalCopies = copies;
	}

	public ProductPrintOrder(IList<IStockable> st, IList<uint> copies)
	{
		int num = Mathf.Min(st.Count, copies.Count);
		Stockables = new IStockable[num];
		Copies = new uint[num];
		for (int i = 0; i < num; i++)
		{
			Stockables[i] = st[i].DeferStock;
			Copies[i] = copies[i];
			TotalCopies += copies[i];
		}
	}

	public ProductPrintOrder(Dictionary<IStockable, uint> orders)
	{
		Stockables = new IStockable[orders.Count];
		Copies = new uint[orders.Count];
		int num = 0;
		foreach (KeyValuePair<IStockable, uint> order in orders)
		{
			Stockables[num] = order.Key.DeferStock;
			Copies[num] = order.Value;
			TotalCopies += order.Value;
			num++;
		}
	}

	public void Apply()
	{
		RemoveFromStorage();
		for (int i = 0; i < Stockables.Length; i++)
		{
			IStockable stockable = Stockables[i];
			uint num = Copies[i];
			ContractWork contractWork;
			if ((contractWork = stockable as ContractWork) != null && SDateTime.Now() < contractWork.Deadline)
			{
				uint num2 = 0u;
				if (contractWork.Goal > stockable.DeferStock.PhysicalCopies)
				{
					num2 = contractWork.Goal - stockable.DeferStock.PhysicalCopies;
				}
				if (num2 > num)
				{
					num2 = num;
				}
				GameSettings.Instance.MyCompany.MakeTransaction((float)num2 * (contractWork.PerPrintFactor + contractWork.HardwarePrice), Company.TransactionCategory.Contracts, true);
				contractWork.LastPrinted = stockable.DeferStock.PhysicalCopies + num;
			}
			stockable.DeferStock.PhysicalCopies += num;
			PrintJob printJob = GameSettings.Instance.GetPrintJob(stockable);
			Deal value;
			PrintDeal printDeal;
			if (printJob != null && printJob.DealID.HasValue && HUD.Instance.dealWindow.AllDeals.TryGetValue(printJob.DealID.Value, out value) && (printDeal = value as PrintDeal) != null)
			{
				printDeal.CurrentAmount += num;
				Company company = value.Company;
				Company client = value.Client;
				if (company != null && client != null)
				{
					float num3 = value.Worth() * (float)num;
					stockable.AddLoss(num3, SoftwareProduct.LossType.Copies, false);
					string bill = printDeal.Title();
					company.MakeTransaction(num3, Company.TransactionCategory.Deals, true, bill);
					client.MakeTransaction(0f - num3, Company.TransactionCategory.Distribution, true, "Copy order");
				}
				if (printDeal.CurrentAmount >= printDeal.Goal)
				{
					printDeal.FinalizeDeal();
				}
			}
		}
	}

	public void RemoveFromStorage()
	{
		for (int i = 0; i < Stockables.Length; i++)
		{
			IStockable stockable = Stockables[i];
			uint amount = Copies[i];
			GameSettings.Instance.SetPrintsToStorage(stockable.DeferStock, amount, false);
		}
	}

	public int GetAtlasIndex()
	{
		if (GameSettings.Instance.BoxController.Highlight != null && Stockables.Contains(GameSettings.Instance.BoxController.Highlight))
		{
			return 999;
		}
		return -1;
	}

	public void AddToStorage()
	{
		for (int i = 0; i < Stockables.Length; i++)
		{
			IStockable st = Stockables[i];
			uint amount = Copies[i];
			GameSettings.Instance.SetPrintsToStorage(st, amount, true);
		}
	}

	public void MergeWith(params ProductPrintOrder[] orders)
	{
		if (orders.Length == 0 || (orders.Length == 1 && orders[0] == null))
		{
			return;
		}
		Dictionary<IStockable, uint> dictionary = new Dictionary<IStockable, uint>();
		for (int i = 0; i < Stockables.Length; i++)
		{
			dictionary[Stockables[i]] = Copies[i];
		}
		bool flag = false;
		bool flag2 = false;
		foreach (ProductPrintOrder productPrintOrder in orders)
		{
			if (productPrintOrder != null)
			{
				for (int k = 0; k < productPrintOrder.Stockables.Length; k++)
				{
					flag2 = true;
					flag |= dictionary.AddUp(productPrintOrder.Stockables[k], productPrintOrder.Copies[k]);
				}
			}
		}
		if (!flag2)
		{
			return;
		}
		if (flag)
		{
			Stockables = new IStockable[dictionary.Count];
			Copies = new uint[dictionary.Count];
		}
		TotalCopies = 0u;
		int num = 0;
		foreach (KeyValuePair<IStockable, uint> item in dictionary)
		{
			Stockables[num] = item.Key.DeferStock;
			Copies[num] = item.Value;
			TotalCopies += item.Value;
			num++;
		}
	}

	public static ProductPrintOrder Merge(IList<ProductPrintOrder> orders)
	{
		if (orders.Count == 1)
		{
			return orders[0];
		}
		Dictionary<IStockable, uint> dictionary = new Dictionary<IStockable, uint>();
		for (int i = 0; i < orders.Count; i++)
		{
			ProductPrintOrder productPrintOrder = orders[i];
			if (productPrintOrder != null)
			{
				for (int j = 0; j < productPrintOrder.Stockables.Length; j++)
				{
					dictionary.AddUp(productPrintOrder.Stockables[j], productPrintOrder.Copies[j]);
				}
			}
		}
		for (int k = 0; k < orders.Count; k++)
		{
			ProductPrintOrder productPrintOrder2 = orders[k];
			if (productPrintOrder2.Stockables.Length != dictionary.Count)
			{
				continue;
			}
			productPrintOrder2.TotalCopies = 0u;
			int num = 0;
			foreach (KeyValuePair<IStockable, uint> item in dictionary)
			{
				productPrintOrder2.Stockables[num] = item.Key.DeferStock;
				productPrintOrder2.Copies[num] = item.Value;
				productPrintOrder2.TotalCopies += item.Value;
				num++;
			}
			return orders[k];
		}
		return new ProductPrintOrder(dictionary);
	}

	public string GetActualString()
	{
		return Stockables[0].GetName();
	}

	public IReferenceFix FixReferences()
	{
		List<ValueTuple<IStockable, uint>> list = new List<ValueTuple<IStockable, uint>>();
		TotalCopies = 0u;
		bool flag = false;
		for (int i = 0; i < Stockables.Length; i++)
		{
			string name = Stockables[i].GetName();
			Stockables[i] = Stockables[i].FixReferences() as IStockable;
			if (Stockables[i] != null)
			{
				list.Add(new ValueTuple<IStockable, uint>(Stockables[i], Copies[i]));
				TotalCopies += Copies[i];
			}
			else
			{
				SelectorController.MissingDataHost.Add(name);
				flag = true;
			}
		}
		if (flag)
		{
			if (list.Count == 0)
			{
				return null;
			}
			Stockables = list.SelectInPlace((ValueTuple<IStockable, uint> x) => x.Item1);
			Copies = list.SelectInPlace((ValueTuple<IStockable, uint> x) => x.Item2);
		}
		return this;
	}
}
