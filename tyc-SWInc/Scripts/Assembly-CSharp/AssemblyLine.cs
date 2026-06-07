using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AssemblyLine : IReferenceFix
{
	public string Name;

	public Color AColor;

	public int HardwareInputMask;

	public int HardwareMask;

	public bool PlayerEdited;

	public bool HasFinal;

	private List<PrintJob> _tasks = new List<PrintJob>();

	public HashSet<PrintJob> PlayerAssigned = new HashSet<PrintJob>();

	public IManufacturable Category;

	[NonSerialized]
	public HashSet<ProductPrinter> Printers = new HashSet<ProductPrinter>();

	[NonSerialized]
	private float _lastEff = 1f;

	[NonSerialized]
	private float _lastEffTime;

	private static float[] _avgs = new float[32];

	private static int[] _counts = new int[32];

	public AssemblyLine()
	{
	}

	public float GetEffectiveness()
	{
		if (Time.realtimeSinceStartup - _lastEffTime > 1f)
		{
			int num = 0;
			int num2 = 0;
			lock (_tasks)
			{
				if (_tasks.Count == 0)
				{
					_lastEff = 1f;
					_lastEffTime = Time.realtimeSinceStartup;
					return 1f;
				}
				for (int i = 0; i < _tasks.Count; i++)
				{
					PrintJob printJob = _tasks[i];
					if (CheckJob(printJob))
					{
						num |= printJob.Target.HardwareMask & ~printJob.Target.HardwareInputMask;
						num2 |= printJob.Target.HardwareInputMask;
					}
				}
			}
			if (num == 0)
			{
				_lastEff = 1f;
				_lastEffTime = Time.realtimeSinceStartup;
				return 1f;
			}
			for (int j = 0; j < 32; j++)
			{
				_avgs[j] = 0f;
				_counts[j] = 0;
			}
			int num3 = 0;
			lock (Printers)
			{
				foreach (ProductPrinter printer in Printers)
				{
					HardwareComponent hardwareComponent = printer.GetHardwareComponent();
					if (hardwareComponent != null && ((printer.Type == ProductPrinter.PrinterType.Assembly && (hardwareComponent.Mask & num) > 0) || (printer.Type == ProductPrinter.PrinterType.Component && (hardwareComponent.Mask & num2) > 0)))
					{
						int index = hardwareComponent.Index;
						num3 = Mathf.Max(index, num3);
						_avgs[index] += printer.GetEffectiveness();
						_counts[index]++;
					}
				}
			}
			_lastEff = 1f;
			for (int k = 0; k < num3; k++)
			{
				if (_counts[k] > 0)
				{
					_lastEff = Mathf.Min(_lastEff, _avgs[k] / (float)_counts[k]);
				}
			}
			_lastEffTime = Time.realtimeSinceStartup;
			return _lastEff;
		}
		return _lastEff;
	}

	private bool CheckJob(PrintJob job)
	{
		if (!job.IsActive() || job.Priority <= 0f)
		{
			return false;
		}
		uint? goalNum = job.GetGoalNum();
		if (goalNum.HasValue && job.GetPrinted() + GameSettings.Instance.GetPrintsInStorage(job.Target) >= goalNum.Value)
		{
			return false;
		}
		if (job.Limit.HasValue && GameSettings.Instance.GetPrintsInStorage(job.Target) >= job.Limit.Value)
		{
			return false;
		}
		if (job.Maximum.HasValue && GameSettings.Instance.GetPrintsInStorage(job.Target, true) >= job.Maximum.Value)
		{
			return false;
		}
		return true;
	}

	public void AddTask(PrintJob task, bool playerAssigned)
	{
		lock (_tasks)
		{
			if (!_tasks.Contains(task))
			{
				_tasks.Add(task);
				task.AssemblyLines++;
			}
			if (playerAssigned)
			{
				PlayerAssigned.Add(task);
			}
		}
		DirtyTaskPrintRate();
	}

	public void RemoveTask(PrintJob task, bool playerAssigned)
	{
		lock (_tasks)
		{
			if (_tasks.Contains(task))
			{
				_tasks.Remove(task);
				task.AssemblyLines--;
				task.ManufacturePerMonth = null;
			}
			if (playerAssigned)
			{
				PlayerAssigned.Add(task);
			}
		}
		DirtyTaskPrintRate();
	}

	public void DeleteTask(PrintJob task)
	{
		lock (_tasks)
		{
			if (_tasks.Contains(task))
			{
				_tasks.Remove(task);
				task.AssemblyLines--;
				task.ManufacturePerMonth = null;
			}
			PlayerAssigned.Remove(task);
		}
		DirtyTaskPrintRate();
	}

	public void DirtyTaskPrintRate()
	{
		lock (_tasks)
		{
			for (int i = 0; i < _tasks.Count; i++)
			{
				_tasks[i].ManufacturePerMonth = null;
			}
		}
	}

	public void ClearTasks(bool includePlayerAssigned)
	{
		lock (_tasks)
		{
			if (includePlayerAssigned || PlayerAssigned.Count == 0)
			{
				for (int i = 0; i < _tasks.Count; i++)
				{
					_tasks[i].AssemblyLines--;
					_tasks[i].ManufacturePerMonth = null;
				}
				_tasks.Clear();
			}
			else
			{
				for (int j = 0; j < _tasks.Count; j++)
				{
					if (!PlayerAssigned.Contains(_tasks[j]))
					{
						_tasks[j].AssemblyLines--;
						_tasks[j].ManufacturePerMonth = null;
						_tasks.RemoveAt(j);
						j--;
					}
					else if (IsCompatible(_tasks[j]) == 0)
					{
						_tasks[j].AssemblyLines--;
						_tasks[j].ManufacturePerMonth = null;
						PlayerAssigned.Remove(_tasks[j]);
						_tasks.RemoveAt(j);
						j--;
					}
				}
			}
		}
		DirtyTaskPrintRate();
	}

	public bool HasTask(PrintJob task)
	{
		lock (_tasks)
		{
			return _tasks.Contains(task);
		}
	}

	public List<PrintJob> GetTasksUnsafe()
	{
		return _tasks;
	}

	private static string PickName()
	{
		HashSet<string> hashSet = (from x in GameSettings.Instance.GetAssemblyLinesUnsafe()
			select x.Name).ToHashSet();
		int num = 0;
		string text = "AssemblyLine".Loc() + " ";
		string text2 = text + num;
		while (hashSet.Contains(text2))
		{
			num++;
			text2 = text + num;
		}
		return text2;
	}

	public AssemblyLine(List<ProductPrinter> printers)
	{
		InitName();
		AColor = ServerGroup.CreateColor(GameSettings.Instance.GetAssemblyLineColors());
		Category = printers[0].GetManufacturing().Category;
		for (int i = 0; i < printers.Count; i++)
		{
			AddPrinter(printers[i]);
		}
	}

	public AssemblyLine(IManufacturable cat)
	{
		Name = "NA";
		AColor = ServerGroup.CreateColor(GameSettings.Instance.GetAssemblyLineColors());
		Category = cat;
	}

	public void InitName()
	{
		Name = PickName();
	}

	public void RefreshMask()
	{
		HardwareInputMask = 0;
		HardwareMask = 0;
		HasFinal = false;
		lock (Printers)
		{
			foreach (ProductPrinter printer in Printers)
			{
				if (!printer.IsAssigned())
				{
					continue;
				}
				if (printer.Type == ProductPrinter.PrinterType.Assembly)
				{
					if (printer.TargetProcess.Final)
					{
						HasFinal = true;
					}
					else
					{
						HardwareMask |= printer.TargetProcess.Output.Mask;
					}
				}
				else
				{
					HardwareInputMask |= printer.TargetComponent.Mask;
				}
			}
		}
		HardwareMask |= HardwareInputMask;
	}

	public void AddPrinter(ProductPrinter p)
	{
		if (p.Group != null)
		{
			if (p.Group == this)
			{
				return;
			}
			p.Group.RemovePrinter(p);
		}
		lock (Printers)
		{
			Printers.Add(p);
		}
		p.Group = this;
	}

	public int IsCompatible(PrintJob job)
	{
		if (!HasFinal)
		{
			return 0;
		}
		if (job.Hardware && job.Target.Manufacturing == Category)
		{
			return IsCompatible(job.Target.HardwareMask, job.Target.HardwareInputMask);
		}
		return 0;
	}

	public int IsCompatible(IManufacturable c, int hardwareMask, int hardwareInputMask)
	{
		if (!HasFinal)
		{
			return 0;
		}
		if (c == Category)
		{
			return IsCompatible(hardwareMask, hardwareInputMask);
		}
		return 0;
	}

	private int IsCompatible(int hardwareMask, int hardwareInputMask)
	{
		if ((hardwareMask & HardwareMask) == hardwareMask && (hardwareInputMask & HardwareInputMask) == hardwareInputMask)
		{
			if ((HardwareInputMask & ~hardwareInputMask) == 0)
			{
				return 2;
			}
			return 1;
		}
		return 0;
	}

	public void AutoAssign()
	{
		ClearTasks(false);
		DictionaryList<IStockable, PrintJob> printOrders = GameSettings.Instance.PrintOrders;
		lock (printOrders)
		{
			for (int i = 0; i < printOrders.Count; i++)
			{
				PrintJob printJob = printOrders[i];
				if (!PlayerAssigned.Contains(printJob) && IsCompatible(printJob) > 0)
				{
					AddTask(printJob, false);
					printJob.ManufacturePerMonth = null;
				}
			}
		}
	}

	public void RemovePrinter(ProductPrinter p)
	{
		lock (Printers)
		{
			if (Printers.Remove(p))
			{
				p.Group = null;
			}
		}
	}

	public void CleanUp()
	{
		lock (_tasks)
		{
			for (int i = 0; i < _tasks.Count; i++)
			{
				PrintJob p = _tasks[i];
				if (!GameSettings.Instance.HasPrintJob(p))
				{
					_tasks.RemoveAt(i);
					i--;
				}
			}
		}
	}

	public override string ToString()
	{
		return Name + ": " + Category.GetPrettyName();
	}

	public IReferenceFix FixReferences()
	{
		Category = Category.FixReferences() as IManufacturable;
		return this;
	}
}
