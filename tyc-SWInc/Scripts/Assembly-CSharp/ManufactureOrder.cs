using System;
using System.Linq;
using UnityEngine;

[Serializable]
public class ManufactureOrder : IProductOrder, IReferenceFix, IFormatColorObject
{
	public IStockable Target;

	public uint Copies;

	public int Mask;

	public float Price;

	public HardwareComponent LastComp;

	public ComponentProcess CurrentProcess;

	public const uint CopiesPerBox = 1000u;

	private byte _componentCount;

	public byte ComponentCount
	{
		get
		{
			if (_componentCount == 0)
			{
				RecountComponents();
			}
			return _componentCount;
		}
	}

	public ManufactureOrder()
	{
	}

	public ManufactureOrder(IStockable p, HardwareComponent c, uint copies)
	{
		Target = p;
		Copies = copies;
		Mask = c.Mask;
		LastComp = c;
		CurrentProcess = GetProcess(c, Target.HardwareMask);
		Price = c.Price;
		_componentCount = 1;
		AlterStorage((int)copies);
	}

	private void RecountComponents()
	{
		int num = Mask;
		int num2 = 0;
		_componentCount = 0;
		while (num != 0)
		{
			int num3 = 1 << num2;
			if ((num & num3) != 0)
			{
				_componentCount++;
			}
			num &= ~num3;
			num2++;
		}
	}

	private static ComponentProcess GetProcess(HardwareComponent c, int mask)
	{
		ComponentProcess inputProcess = c.InputProcess;
		while (inputProcess != null && !inputProcess.Final && (inputProcess.Output.Mask & mask) == 0)
		{
			inputProcess = inputProcess.Output.InputProcess;
		}
		return inputProcess;
	}

	public float GetAssemblyTime()
	{
		return CurrentProcess.Final ? CurrentProcess.Parent.FinalTime : CurrentProcess.Output.Time;
	}

	public bool IsDone()
	{
		return (Target.HardwareMask & CurrentProcess.InputMask & ~Mask) == 0;
	}

	public bool CanMerge(ManufactureOrder other)
	{
		if (Target == other.Target && CurrentProcess == other.CurrentProcess)
		{
			if ((Mask & other.Mask) == 0)
			{
				return true;
			}
			if ((Mask | other.Mask) > Mask)
			{
				return true;
			}
		}
		return false;
	}

	public bool Merge(ManufactureOrder other)
	{
		if ((Mask & other.Mask) == 0)
		{
			Price += other.Price;
			Mask |= other.Mask;
			_componentCount += other._componentCount;
			return true;
		}
		int mask = Mask | other.Mask;
		other.Mask &= Mask;
		Mask = mask;
		float price = other.Price;
		other.RecalculatePrice();
		Price = Price - other.Price + price;
		RecountComponents();
		other.RecountComponents();
		return false;
	}

	private void RecalculatePrice()
	{
		Price = 0f;
		int num = Mask & Target.HardwareInputMask;
		int num2 = 0;
		while (num != 0)
		{
			int num3 = 1 << num2;
			if ((num & num3) != 0)
			{
				Price += Target.Manufacturing.GetManufacturing().Components[num2].Price;
			}
			num &= ~num3;
			num2++;
		}
	}

	public static ProductPrintOrder PromoteProduct(IStockable target, uint copies)
	{
		ProductPrintOrder productPrintOrder = new ProductPrintOrder(target, copies);
		productPrintOrder.AddToStorage();
		return productPrintOrder;
	}

	public IProductOrder Promote()
	{
		if (CurrentProcess.Final)
		{
			IProductOrder result = Target.PromoteHardware(Copies);
			RemoveFromStorage();
			PrintJob printJob = GameSettings.Instance.GetPrintJob(Target.DeferStock);
			if (printJob != null && printJob.Limit.HasValue)
			{
				if (Copies >= printJob.Limit.Value)
				{
					printJob.Limit = 0u;
					GameSettings.Instance.BoxController.FinishedJobs.AddThreaded(printJob);
					return result;
				}
				printJob.Limit = printJob.Limit.Value - Copies;
			}
			return result;
		}
		Mask |= CurrentProcess.Output.Mask;
		LastComp = CurrentProcess.Output;
		CurrentProcess = GetProcess(LastComp, Target.HardwareMask);
		return null;
	}

	public void Recycle()
	{
		int num = Mask & Target.HardwareInputMask;
		int num2 = 0;
		while (num != 0)
		{
			int num3 = 1 << num2;
			if ((num & num3) != 0)
			{
				Target.Manufacturing.GetManufacturing().Components[num2].Recycled++;
			}
			num &= ~num3;
			num2++;
		}
		RemoveFromStorage();
	}

	public void RemoveFromStorage()
	{
		AlterStorage((int)(0L - (long)Copies));
	}

	public void AlterStorage(int amount)
	{
		PrintJob printJob = GameSettings.Instance.GetPrintJob(Target.DeferStock);
		if (printJob == null)
		{
			return;
		}
		lock (printJob.ComponentCount)
		{
			int num = Mask & Target.HardwareInputMask;
			int num2 = 0;
			while (num != 0)
			{
				int num3 = 1 << num2;
				if ((num & num3) != 0)
				{
					if (amount < 0)
					{
						if (-amount >= printJob.ComponentCount[num2])
						{
							printJob.ComponentCount[num2] = 0u;
						}
						else
						{
							printJob.ComponentCount[num2] = (uint)(printJob.ComponentCount[num2] + amount);
						}
					}
					else
					{
						printJob.ComponentCount[num2] += (uint)amount;
					}
				}
				num &= ~num3;
				num2++;
			}
		}
	}

	public void CountComponents(uint[] componentCount)
	{
		for (int i = 0; i < componentCount.Length; i++)
		{
			if ((Mask & Target.HardwareInputMask & (1 << i)) != 0)
			{
				componentCount[i] += Copies;
			}
		}
	}

	public int GetAtlasIndex()
	{
		if (Target == GameSettings.Instance.BoxController.Highlight)
		{
			return LastComp.AtlasIndex + 1000;
		}
		return LastComp.AtlasIndex;
	}

	public string GetActualString()
	{
		return Target.GetName();
	}

	public IReferenceFix FixReferences()
	{
		string name = Target.GetName();
		Target = Target.FixReferences() as IStockable;
		if (Target == null)
		{
			SelectorController.MissingDataHost.Add(name);
			return null;
		}
		if (CurrentProcess != null)
		{
			IManufacturable manufacturable;
			if ((manufacturable = CurrentProcess.Parent.Category.FixReferences() as IManufacturable) != null)
			{
				CurrentProcess = manufacturable.GetManufacturing().Processes.First((ComponentProcess x) => x.Mask == CurrentProcess.Mask);
			}
			else
			{
				CurrentProcess = null;
			}
			if (CurrentProcess == null)
			{
				Debug.LogError("Failed finding process when fixing references for manufacture order");
			}
		}
		if (LastComp != null)
		{
			IManufacturable manufacturable2;
			if ((manufacturable2 = LastComp.Parent.Category.FixReferences() as IManufacturable) != null)
			{
				LastComp = manufacturable2.GetManufacturing().Components.First((HardwareComponent x) => x.Index == LastComp.Index);
			}
			else
			{
				LastComp = null;
			}
			if (LastComp == null)
			{
				Debug.LogError("Failed finding component when fixing references for manufacture order");
			}
		}
		return this;
	}
}
