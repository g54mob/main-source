using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[Serializable]
[AltDeprecate("ID", typeof(uint))]
public class PrintJob : IReferenceFix
{
	public uint? DealID;

	public uint? Limit;

	public uint? Maximum;

	public int AssemblyLines;

	public float Priority = 1f;

	public bool Hardware;

	public IStockable Target;

	[NonSerialized]
	public int? ManufacturePerMonth;

	[NonSerialized]
	public uint _dirtyKey;

	public uint[] ComponentCount;

	public string CompanyName
	{
		get
		{
			return Target.GetCompanyName();
		}
	}

	public uint PhysicalCopies
	{
		get
		{
			return Target.PhysicalCopies;
		}
	}

	public PrintJob()
	{
	}

	public PrintJob(IStockable target)
	{
		Target = target;
		DealID = null;
		Hardware = Target.Manufacturing.IsHardware();
		InitHardware();
	}

	public PrintJob(IStockable target, float priority)
	{
		Target = target;
		Priority = priority;
		DealID = null;
		Hardware = Target.Manufacturing.IsHardware();
		InitHardware();
	}

	public PrintJob(IStockable target, uint dealID)
	{
		Target = target;
		DealID = dealID;
		Hardware = Target.Manufacturing.IsHardware();
		InitHardware();
	}

	public void RecountLines()
	{
		AssemblyLines = 0;
		List<AssemblyLine> assemblyLinesUnsafe = GameSettings.Instance.GetAssemblyLinesUnsafe();
		for (int i = 0; i < assemblyLinesUnsafe.Count; i++)
		{
			if (assemblyLinesUnsafe[i].HasTask(this))
			{
				AssemblyLines++;
			}
		}
	}

	public bool FixComponentCount(TransportBox[] boxes, StringBuilder sb)
	{
		if (Hardware)
		{
			uint[] componentCount = ComponentCount;
			uint num = 0u;
			lock (ComponentCount)
			{
				ComponentCount = new uint[ComponentCount.Length];
			}
			lock (ComponentCount)
			{
				for (int i = 0; i < ComponentCount.Length; i++)
				{
					ComponentCount[i] = 0u;
				}
				for (int j = 0; j < GameSettings.Instance.ProductPrinters.Count; j++)
				{
					ProductPrinter productPrinter = GameSettings.Instance.ProductPrinters[j];
					if (productPrinter.Type == ProductPrinter.PrinterType.Assembly && productPrinter.TargetProcess != null && productPrinter.TargetProcess.Parent.Category == Target.Manufacturing)
					{
						lock (productPrinter.ManufactureQueue)
						{
							for (int k = 0; k < productPrinter.ManufactureQueue.Count; k++)
							{
								ManufactureOrder manufactureOrder = productPrinter.ManufactureQueue[k];
								if (manufactureOrder.Target == Target)
								{
									manufactureOrder.CountComponents(ComponentCount);
								}
							}
						}
					}
					for (int l = 0; l < productPrinter.LocalOrders.Count; l++)
					{
						ManufactureOrder manufactureOrder2;
						if ((manufactureOrder2 = productPrinter.LocalOrders[l] as ManufactureOrder) != null && manufactureOrder2.Target == Target)
						{
							manufactureOrder2.CountComponents(ComponentCount);
						}
					}
				}
				for (int m = 0; m < boxes.Length; m++)
				{
					ManufactureOrder manufactureOrder3;
					if ((manufactureOrder3 = boxes[m].Order as ManufactureOrder) != null && manufactureOrder3.Target == Target)
					{
						manufactureOrder3.CountComponents(ComponentCount);
					}
				}
				if (sb != null)
				{
					for (int n = 0; n < ComponentCount.Length; n++)
					{
						if (ComponentCount[n] > componentCount[n])
						{
							num += ComponentCount[n] - componentCount[n];
						}
						else if (ComponentCount[n] < componentCount[n])
						{
							num += componentCount[n] - ComponentCount[n];
						}
					}
				}
			}
			if (num != 0)
			{
				sb.AppendLine(Target.GetIdentifyingName() + " changed by " + num + " components");
				return true;
			}
		}
		return false;
	}

	private string CheckComponentCount()
	{
		uint[] array = new uint[ComponentCount.Length];
		foreach (ProductPrinter productPrinter in GameSettings.Instance.ProductPrinters)
		{
			if (productPrinter.Type != ProductPrinter.PrinterType.Assembly || productPrinter.TargetProcess == null || productPrinter.TargetProcess.Parent.Category != Target.Manufacturing)
			{
				continue;
			}
			lock (productPrinter.ManufactureQueue)
			{
				for (int i = 0; i < productPrinter.ManufactureQueue.Count; i++)
				{
					ManufactureOrder manufactureOrder = productPrinter.ManufactureQueue[i];
					if (manufactureOrder.Target != Target)
					{
						continue;
					}
					for (int j = 0; j < array.Length; j++)
					{
						if ((manufactureOrder.Mask & (1 << j)) != 0)
						{
							array[j] += manufactureOrder.Copies;
						}
					}
				}
			}
		}
		StringBuilder stringBuilder = new StringBuilder();
		Manufacturing manufacturing = Target.Manufacturing.GetManufacturing();
		for (int k = 0; k < array.Length; k++)
		{
			HardwareComponent hardwareComponent = manufacturing.Components[k];
			stringBuilder.AppendLine(hardwareComponent.Name + ": " + ComponentCount[k] + "/" + array[k]);
		}
		return stringBuilder.ToString();
	}

	private void InitHardware()
	{
		if (Hardware)
		{
			int num = Target.HardwareInputMask;
			int num2 = 0;
			while (num != 0)
			{
				num2++;
				num >>= 1;
			}
			ComponentCount = new uint[num2];
		}
	}

	public uint CountComponents(HardwareComponent c)
	{
		if (c.Index >= ComponentCount.Length)
		{
			return 0u;
		}
		return ComponentCount[c.Index];
	}

	public bool CompatibleWith(HardwareComponent component)
	{
		return Target.CompatibleWith(component);
	}

	public int PrintPerMonth()
	{
		if (Hardware)
		{
			if (!ManufacturePerMonth.HasValue || _dirtyKey != DistributionWindow.PrintDirty)
			{
				_dirtyKey = DistributionWindow.PrintDirty;
				ManufacturePerMonth = Mathf.RoundToInt(DistributionWindow.GetPrintsPerMonth(this));
			}
			return ManufacturePerMonth.Value;
		}
		if (IsPrintDone())
		{
			return 0;
		}
		return Mathf.RoundToInt(HUD.Instance.distributionWindow.PrintSpeed * (Priority / HUD.Instance.distributionWindow.PrioritySum));
	}

	public bool ReachedGoal()
	{
		uint? goalNum = GetGoalNum();
		if (goalNum.HasValue)
		{
			return GetPrinted() + GameSettings.Instance.GetPrintsInStorage(Target) >= goalNum.Value;
		}
		return false;
	}

	public bool IsActive()
	{
		if (Maximum.HasValue)
		{
			return Maximum.Value > GameSettings.Instance.GetPrintsInStorage(Target, true);
		}
		return true;
	}

	public bool IsPrintDone()
	{
		if (IsActive())
		{
			return ReachedGoal();
		}
		return true;
	}

	public string PrintPerMonthLabel()
	{
		int num = PrintPerMonth();
		string text = num.ToString("N0");
		uint? goalNum = GetGoalNum();
		if (!goalNum.HasValue)
		{
			return text;
		}
		string text2 = "#00AA00FF";
		uint num2 = GetPrinted() + GameSettings.Instance.GetPrintsInStorage(Target);
		if (num2 < goalNum.Value)
		{
			uint num3 = goalNum.Value - num2;
			if (!GetDeadlineDate().HasValue || !(SDateTime.GetMonths(SDateTime.Now(), GetDeadlineDate().Value) * (float)num < (float)num3))
			{
				return text;
			}
			text2 = "#AA0000FF";
		}
		return "<color=" + text2 + ">" + text + "</color>";
	}

	public SDateTime? GetDeadlineDate()
	{
		ContractWork contractWork;
		if ((contractWork = Target as ContractWork) != null)
		{
			return contractWork.Deadline;
		}
		PrintDeal deal = GetDeal();
		if (deal != null)
		{
			return deal.EndDate;
		}
		NetworkPrintDeal networkPrintDeal;
		if ((networkPrintDeal = Target as NetworkPrintDeal) != null)
		{
			return networkPrintDeal.Deadline;
		}
		return null;
	}

	public uint GetPrinted()
	{
		ContractWork contractWork;
		if ((contractWork = Target as ContractWork) != null)
		{
			return contractWork.PhysicalCopies;
		}
		PrintDeal deal = GetDeal();
		if (deal != null)
		{
			return deal.CurrentAmount;
		}
		NetworkPrintDeal networkPrintDeal;
		if ((networkPrintDeal = Target as NetworkPrintDeal) != null)
		{
			return networkPrintDeal.PhysicalCopies;
		}
		return 0u;
	}

	public uint? GetGoalNum()
	{
		ContractWork contractWork;
		if ((contractWork = Target as ContractWork) != null)
		{
			return contractWork.Goal;
		}
		PrintDeal deal = GetDeal();
		if (deal != null)
		{
			return deal.Goal;
		}
		NetworkPrintDeal networkPrintDeal;
		if ((networkPrintDeal = Target as NetworkPrintDeal) != null && networkPrintDeal.MaxCopies != 0)
		{
			return networkPrintDeal.MaxCopies;
		}
		return null;
	}

	public PrintDeal GetDeal()
	{
		Deal value;
		PrintDeal result;
		if (DealID.HasValue && HUD.Instance.dealWindow.AllDeals.TryGetValue(DealID.Value, out value) && (result = value as PrintDeal) != null)
		{
			return result;
		}
		return null;
	}

	public string GetGoal()
	{
		if (Limit.HasValue)
		{
			return Limit.Value.ToString("N0");
		}
		if (Maximum.HasValue)
		{
			return "<" + Maximum.Value.ToString("N0");
		}
		uint? goalNum = GetGoalNum();
		if (goalNum.HasValue)
		{
			uint printed = GetPrinted();
			if (printed > goalNum.Value)
			{
				return "+" + (printed - goalNum.Value).ToString("N0");
			}
			return (goalNum.Value - printed).ToString("N0");
		}
		return "NotApplicableAbbr".Loc();
	}

	public float GetGoalSort()
	{
		if (Limit.HasValue)
		{
			return Limit.Value;
		}
		if (Maximum.HasValue)
		{
			return Maximum.Value;
		}
		uint? goalNum = GetGoalNum();
		if (goalNum.HasValue)
		{
			return goalNum.Value - GetPrinted();
		}
		return 0f;
	}

	public string GetDeadline()
	{
		SDateTime? deadlineDate = GetDeadlineDate();
		if (!deadlineDate.HasValue)
		{
			return "NotApplicableAbbr".Loc();
		}
		return deadlineDate.Value.ToCompactString2();
	}

	public int GetDeadlineOrder()
	{
		SDateTime? deadlineDate = GetDeadlineDate();
		if (!deadlineDate.HasValue)
		{
			return -1;
		}
		return deadlineDate.Value.ToInt();
	}

	public override string ToString()
	{
		return Target.GetIdentifyingName();
	}

	public IReferenceFix FixReferences()
	{
		string name = Target.GetName();
		Target = Target.FixReferences() as IStockable;
		if (Target != null)
		{
			return this;
		}
		SelectorController.MissingDataHost.Add(name);
		return null;
	}
}
