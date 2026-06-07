using System;
using System.Collections.Generic;
using Achievements;
using UnityEngine;

public class ProductPrinter : Writeable, IManufacturingConverter
{
	public enum PrinterType
	{
		Product = 0,
		Component = 1,
		Assembly = 2
	}

	public const int AssemblerMaxQueue = 20;

	public PrinterType Type;

	public float PrintPrice = 0.1f;

	public float PrintSpeed;

	public int PrintAmount;

	[NonSerialized]
	public bool MissingRecycler;

	[NonSerialized]
	public bool InvalidOutput;

	[NonSerialized]
	public float NextPrint;

	public Furniture Furn;

	[NonSerialized]
	public List<IProductOrder> LocalOrders = new List<IProductOrder>();

	[NonSerialized]
	public ComponentProcess TargetProcess;

	[NonSerialized]
	public HardwareComponent TargetComponent;

	[NonSerialized]
	public List<ManufactureOrder> PushOut = new List<ManufactureOrder>();

	[NonSerialized]
	public List<ManufactureOrder> ManufactureQueue = new List<ManufactureOrder>();

	public MeshRenderer[] ComponentStickers;

	[NonSerialized]
	private bool _skipAssemblers;

	private float _wasActive = 1f;

	private float _isActive;

	private float _actualRun;

	private float _firstAge;

	[NonSerialized]
	public AssemblyLine Group;

	[NonSerialized]
	private PrintJob _activeJob;

	[NonSerialized]
	private int _printAmount;

	[NonSerialized]
	private bool _wasStalled;

	[NonSerialized]
	public float OwedWatt;

	private static List<PrintJob> _eligibleForPrint = new List<PrintJob>();

	private bool _lastToggle;

	private bool _assemblyChange = true;

	[NonSerialized]
	public SDateTime LastBlockTime;

	[NonSerialized]
	private string _targetComponentType;

	[NonSerialized]
	private string _targetComponentCategory;

	[NonSerialized]
	private string _targetComponent;

	public void AddOwedWatt(float months)
	{
		OwedWatt += Furn.Wattage * 0.03f * 24f * months;
	}

	public float GetEffectiveness()
	{
		if (_actualRun > 0f)
		{
			return Mathf.Lerp(_wasActive, _isActive / _actualRun, _actualRun / 60f);
		}
		return _wasActive;
	}

	public void PassHour()
	{
		_wasActive = ((_actualRun > 0f) ? Mathf.Clamp01(_isActive / _actualRun) : 1f);
		_isActive = 0f;
		_actualRun = 0f;
	}

	public bool IsProducing(HardwareComponent c, bool print)
	{
		if (print && Type == PrinterType.Component && TargetComponent == c)
		{
			return true;
		}
		if (!print && Type == PrinterType.Assembly && TargetProcess != null && TargetProcess.Output == c)
		{
			return true;
		}
		return false;
	}

	public bool IsAssigned()
	{
		if (Type == PrinterType.Component && TargetComponent != null)
		{
			return true;
		}
		if (Type == PrinterType.Assembly && TargetProcess != null)
		{
			return true;
		}
		return false;
	}

	public Manufacturing GetManufacturing()
	{
		if (Type == PrinterType.Component && TargetComponent != null)
		{
			return TargetComponent.Parent;
		}
		if (Type == PrinterType.Assembly && TargetProcess != null)
		{
			return TargetProcess.Parent;
		}
		return null;
	}

	public bool IsManufacturing()
	{
		if (Type != PrinterType.Assembly)
		{
			return Type == PrinterType.Component;
		}
		return true;
	}

	public float GetPrintPrice()
	{
		if (Type == PrinterType.Component)
		{
			if (TargetComponent != null)
			{
				return TargetComponent.Price;
			}
			return 0f;
		}
		if (Type == PrinterType.Assembly)
		{
			return 0f;
		}
		return PrintPrice;
	}

	public float GetPrintTime()
	{
		switch (Type)
		{
		case PrinterType.Component:
			if (TargetComponent != null)
			{
				return (float)TargetComponent.Time / 60f;
			}
			return 1f;
		case PrinterType.Assembly:
			if (TargetProcess != null)
			{
				return (float)(TargetProcess.Final ? TargetProcess.Parent.FinalTime : TargetProcess.Output.Time) / 60f;
			}
			return 1f;
		default:
			return 1f / PrintSpeed;
		}
	}

	public bool CheckSame(ProductPrinter other)
	{
		if (Type == other.Type)
		{
			switch (Type)
			{
			case PrinterType.Product:
				return true;
			case PrinterType.Component:
				return other.TargetComponent == TargetComponent;
			case PrinterType.Assembly:
				return other.TargetProcess == TargetProcess;
			}
		}
		return false;
	}

	private void Start()
	{
		if (GameSettings.Instance.IsReferenceNull() || Furn.Map != null)
		{
			return;
		}
		lock (GameSettings.Instance.ProductPrinters)
		{
			GameSettings.Instance.ProductPrinters.Add(this);
			GameSettings.Instance.PrinterChanged();
			DistributionWindow.RefreshHardwareStats();
		}
		if (!Deserialized)
		{
			DID = Furn.DID;
			if (IsManufacturing())
			{
				TutorialSystem.Instance.StartTutorial("Manufacturing");
				GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(Furn.Conveyor);
			}
			else
			{
				TutorialSystem.Instance.StartTutorial("Physical distribution");
			}
		}
	}

	private void OnDestroy()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		lock (GameSettings.Instance.ProductPrinters)
		{
			GameSettings.Instance.ProductPrinters.Remove(this);
		}
		GameSettings.Instance.PrinterChanged();
		if (Type == PrinterType.Assembly)
		{
			ComponentProcess targetProcess = TargetProcess;
			if (targetProcess != null)
			{
				targetProcess.ActiveAssemblers.Remove(this);
			}
			lock (ManufactureQueue)
			{
				for (int i = 0; i < ManufactureQueue.Count; i++)
				{
					ManufactureQueue[i].RemoveFromStorage();
				}
			}
		}
		for (int j = 0; j < LocalOrders.Count; j++)
		{
			LocalOrders[j].RemoveFromStorage();
		}
		if (HUD.Instance != null)
		{
			DistributionWindow.RefreshHardwareStats();
		}
		AssemblyLine assemblyLine = Group;
		if (assemblyLine != null)
		{
			assemblyLine.RemovePrinter(this);
		}
	}

	private bool AnyOrders(bool hardware)
	{
		if (hardware)
		{
			if (Group == null)
			{
				return false;
			}
			List<PrintJob> tasksUnsafe = Group.GetTasksUnsafe();
			lock (tasksUnsafe)
			{
				for (int i = 0; i < tasksUnsafe.Count; i++)
				{
					PrintJob printJob = tasksUnsafe[i];
					if (printJob.Priority > 0f && printJob.IsActive())
					{
						return true;
					}
				}
			}
		}
		else
		{
			lock (GameSettings.Instance.PrintOrders)
			{
				for (int j = 0; j < GameSettings.Instance.PrintOrders.Count; j++)
				{
					PrintJob printJob2 = GameSettings.Instance.PrintOrders[j];
					if (printJob2.Priority > 0f && !printJob2.Hardware && printJob2.IsActive())
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	public bool IsFinalAssembly()
	{
		if (Type == PrinterType.Assembly && TargetProcess != null)
		{
			return TargetProcess.Final;
		}
		return false;
	}

	public void SetTargetProcess(ComponentProcess p)
	{
		if (TargetProcess != null)
		{
			TargetProcess.ActiveAssemblers.Remove(this);
		}
		lock (this)
		{
			TargetProcess = p;
		}
		UpdateSticker((TargetProcess == null) ? (-1) : (TargetProcess.Final ? MarketSimulation.Active.GetManufacturingIndex("Final") : TargetProcess.Output.AtlasIndex));
		if (TargetProcess != null)
		{
			TargetProcess.ActiveAssemblers.Add(this);
			if (TargetProcess.Final)
			{
				InvalidOutput = false;
			}
		}
		else
		{
			InvalidOutput = false;
		}
		GameSettings.Instance.PrinterChanged();
		DistributionWindow.RefreshHardwareStats();
		GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(Furn.Conveyor);
	}

	public void SetTargetComponent(HardwareComponent p)
	{
		lock (this)
		{
			TargetComponent = p;
		}
		UpdateSticker((TargetComponent != null) ? TargetComponent.AtlasIndex : (-1));
		if (TargetComponent == null)
		{
			InvalidOutput = false;
		}
		GameSettings.Instance.PrinterChanged();
		DistributionWindow.RefreshHardwareStats();
		GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(Furn.Conveyor);
	}

	public int GetStickerIndex()
	{
		if (Type == PrinterType.Assembly)
		{
			if (TargetProcess == null)
			{
				return -1;
			}
			if (!TargetProcess.Final)
			{
				return TargetProcess.Output.AtlasIndex;
			}
			return MarketSimulation.Active.GetManufacturingIndex("Final");
		}
		if (Type == PrinterType.Component)
		{
			if (TargetComponent == null)
			{
				return -1;
			}
			return TargetComponent.AtlasIndex;
		}
		return -1;
	}

	public void UpdateSticker()
	{
		if (IsManufacturing())
		{
			UpdateSticker(GetStickerIndex());
		}
	}

	public HardwareComponent GetHardwareComponent()
	{
		if (Type == PrinterType.Assembly)
		{
			ComponentProcess targetProcess = TargetProcess;
			if (targetProcess == null)
			{
				return null;
			}
			return targetProcess.Output;
		}
		if (Type == PrinterType.Component)
		{
			return TargetComponent;
		}
		return null;
	}

	public ComponentProcess GetHardwareProcess()
	{
		if (Type == PrinterType.Assembly)
		{
			return TargetProcess;
		}
		return null;
	}

	private void UpdateSticker(int atlasIndex)
	{
		if (atlasIndex == -1)
		{
			for (int i = 0; i < ComponentStickers.Length; i++)
			{
				ComponentStickers[i].gameObject.SetActive(false);
			}
			return;
		}
		int num = atlasIndex % MarketSimulation.Active.ManAtlasWidth;
		int num2 = MarketSimulation.Active.ManAtlasHeight - 1 - atlasIndex / MarketSimulation.Active.ManAtlasWidth;
		float num3 = 1f / (float)MarketSimulation.Active.ManAtlasWidth;
		float num4 = 1f / (float)MarketSimulation.Active.ManAtlasHeight;
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		materialPropertyBlock.SetVector("_Offset", new Vector4((float)num * num3, (float)num2 * num4, num3, num4));
		for (int j = 0; j < ComponentStickers.Length; j++)
		{
			ComponentStickers[j].gameObject.SetActive(true);
			ComponentStickers[j].SetPropertyBlock(materialPropertyBlock);
		}
	}

	private ManufactureOrder GenerateHardwareOrder(out bool stall)
	{
		stall = false;
		if (Group == null)
		{
			return null;
		}
		PrintJob printJob = _activeJob;
		if (printJob == null || (float)_printAmount >= printJob.Priority)
		{
			PrintJob printJob2 = null;
			List<PrintJob> tasksUnsafe = Group.GetTasksUnsafe();
			lock (tasksUnsafe)
			{
				if (tasksUnsafe.Count > 0)
				{
					int num = 0;
					if (printJob != null)
					{
						int num2 = tasksUnsafe.IndexOf(printJob);
						if (num2 >= 0)
						{
							num = num2 + 1;
						}
						else
						{
							printJob = null;
						}
					}
					for (int i = 0; i < tasksUnsafe.Count; i++)
					{
						int index = (i + num) % tasksUnsafe.Count;
						PrintJob printJob3 = tasksUnsafe[index];
						if (printJob3 == printJob || !printJob3.Hardware || !printJob3.IsActive() || printJob3.Priority <= 0f)
						{
							continue;
						}
						uint? goalNum = printJob3.GetGoalNum();
						if ((!goalNum.HasValue || printJob3.GetPrinted() + GameSettings.Instance.GetPrintsInStorage(printJob3.Target) + printJob3.CountComponents(TargetComponent) < goalNum.Value) && (!printJob3.Limit.HasValue || printJob3.CountComponents(TargetComponent) < printJob3.Limit.Value) && (!printJob3.Maximum.HasValue || GameSettings.Instance.GetPrintsInStorage(printJob3.Target, true) + printJob3.CountComponents(TargetComponent) < printJob3.Maximum.Value))
						{
							printJob2 = printJob3;
							if (!printJob3.CompatibleWith(TargetComponent))
							{
								stall = true;
							}
							break;
						}
					}
				}
			}
			if (printJob2 != printJob)
			{
				_printAmount = 0;
			}
			printJob = printJob2 ?? printJob;
			if (printJob != null)
			{
				if (printJob.Priority <= 0f)
				{
					printJob = null;
				}
				else if (printJob.Limit.HasValue && printJob.CountComponents(TargetComponent) >= printJob.Limit.Value)
				{
					printJob = null;
				}
				else if (printJob.Maximum.HasValue && GameSettings.Instance.GetPrintsInStorage(printJob.Target, true) + printJob.CountComponents(TargetComponent) >= printJob.Maximum.Value)
				{
					printJob = null;
				}
				else
				{
					uint? goalNum2 = printJob.GetGoalNum();
					if (goalNum2.HasValue && printJob.GetPrinted() + GameSettings.Instance.GetPrintsInStorage(printJob.Target) + printJob.CountComponents(TargetComponent) >= goalNum2.Value)
					{
						printJob = null;
					}
				}
			}
		}
		if (printJob != null && GameSettings.Instance.HasPrintJob(printJob))
		{
			_activeJob = printJob;
		}
		else
		{
			_activeJob = null;
		}
		if (printJob != null && !printJob.CompatibleWith(TargetComponent))
		{
			stall = true;
		}
		if (stall)
		{
			_printAmount++;
			return null;
		}
		if (printJob != null)
		{
			_printAmount++;
			if (TargetComponent.Recycled > 0)
			{
				TargetComponent.Recycled--;
			}
			else
			{
				GameSettings.Instance.BoxController.RegisterPrint(this, (int)printJob.Target.CopiesPerBox);
				if (!printJob.DealID.HasValue)
				{
					printJob.Target.AddLoss((float)printJob.Target.CopiesPerBox * TargetComponent.Price, SoftwareProduct.LossType.Printing, false);
				}
			}
			return new ManufactureOrder(printJob.Target, TargetComponent, printJob.Target.CopiesPerBox);
		}
		_printAmount = 0;
		return null;
	}

	public bool TakeComponent(ManufactureOrder order, TransportBox box)
	{
		if (order.CurrentProcess == TargetProcess)
		{
			_skipAssemblers = false;
			lock (ManufactureQueue)
			{
				ManufactureQueue.Add(order);
				if (ManufactureQueue.Count > 20)
				{
					if (TargetProcess != null)
					{
						for (int i = 0; i < TargetProcess.ActiveAssemblers.Count; i++)
						{
							ProductPrinter productPrinter = TargetProcess.ActiveAssemblers[i];
							if (!(productPrinter != null) || !(productPrinter != this) || productPrinter.Group != Group)
							{
								continue;
							}
							lock (productPrinter.ManufactureQueue)
							{
								if (productPrinter.ManufactureQueue.Count < 15)
								{
									productPrinter.ManufactureQueue.Add(ManufactureQueue[0]);
									ManufactureQueue.RemoveAt(0);
									return true;
								}
							}
						}
					}
					int index;
					if (LocalOrders.Count == 0)
					{
						int num = -1;
						for (int j = 0; j < ManufactureQueue.Count - 1; j++)
						{
							if (order.CanMerge(ManufactureQueue[j]))
							{
								num = j;
								break;
							}
						}
						index = ((num < 0) ? ManufactureQueue.GetMinIndex((ManufactureOrder x) => x.ComponentCount) : ((num == 0) ? 1 : 0));
					}
					else
					{
						index = ManufactureQueue.GetMinIndex((ManufactureOrder x) => x.ComponentCount);
					}
					box.Order = ManufactureQueue[index];
					ManufactureQueue.RemoveAt(index);
					HintController.Show(HintController.Hints.HintManufacturingSpace);
					return false;
				}
			}
			return true;
		}
		return false;
	}

	private ProductPrintOrder GenerateOrder()
	{
		Dictionary<IStockable, uint> dictionary = new Dictionary<IStockable, uint>();
		_eligibleForPrint.Clear();
		int left = PrintAmount;
		DictionaryList<IStockable, PrintJob> printOrders = GameSettings.Instance.PrintOrders;
		lock (printOrders)
		{
			float num = 0f;
			for (int i = 0; i < printOrders.Count; i++)
			{
				if (!printOrders[i].Hardware && printOrders[i].IsActive())
				{
					num += printOrders[i].Priority;
				}
			}
			for (int j = 0; j < printOrders.Count; j++)
			{
				DoDigitalPrint(printOrders[j], dictionary, num, 0u, _eligibleForPrint, PrintAmount, ref left);
				if (left == 0)
				{
					break;
				}
			}
		}
		if (left == PrintAmount)
		{
			_eligibleForPrint.Clear();
			return null;
		}
		if (left > 0 && _eligibleForPrint.Count > 0)
		{
			float prioritySum = _eligibleForPrint.SumSafe((PrintJob x) => x.Priority);
			int printAmount = left;
			for (int num2 = 0; num2 < _eligibleForPrint.Count; num2++)
			{
				PrintJob printJob = _eligibleForPrint[num2];
				DoDigitalPrint(printJob, dictionary, prioritySum, dictionary.GetOrDefault(printJob.Target, 0u), null, printAmount, ref left);
				if (left == 0)
				{
					break;
				}
			}
		}
		GameSettings.Instance.BoxController.RegisterPrint(this, PrintAmount - left);
		ProductPrintOrder productPrintOrder = new ProductPrintOrder(dictionary);
		productPrintOrder.AddToStorage();
		_eligibleForPrint.Clear();
		return productPrintOrder;
	}

	private void DoDigitalPrint(PrintJob order, Dictionary<IStockable, uint> res, float prioritySum, uint alreadyPrinted, List<PrintJob> eligibleForPrint, int printAmount, ref int left)
	{
		if (order.Hardware || !order.IsActive() || order.Priority == 0f)
		{
			return;
		}
		uint? goalNum = order.GetGoalNum();
		int num = left;
		if (goalNum.HasValue)
		{
			uint num2 = order.GetPrinted() + GameSettings.Instance.GetPrintsInStorage(order.Target) + alreadyPrinted;
			if (num2 >= goalNum.Value)
			{
				return;
			}
			uint num3 = goalNum.Value - num2;
			if (num3 < num)
			{
				num = (int)num3;
			}
		}
		int num4 = Mathf.Min(num, Mathf.RoundToInt(order.Priority / prioritySum * (float)printAmount));
		if (order.Limit.HasValue)
		{
			if (order.Limit.Value == 0)
			{
				return;
			}
			if (num4 >= order.Limit.Value)
			{
				GameSettings.Instance.BoxController.FinishedJobs.AddThreaded(order);
				num4 = (int)order.Limit.Value;
				order.Limit = 0u;
			}
			else
			{
				order.Limit -= (uint)num4;
				if (eligibleForPrint != null)
				{
					eligibleForPrint.Add(order);
				}
			}
		}
		else if (eligibleForPrint != null)
		{
			eligibleForPrint.Add(order);
		}
		left -= num4;
		if (num4 > 0)
		{
			float cost = (float)num4 * PrintPrice;
			if (!order.DealID.HasValue)
			{
				order.Target.AddLoss(cost, SoftwareProduct.LossType.Printing, false);
			}
			res.AddUp(order.Target, (uint)num4);
		}
		AchievementController.SetInteraction(AchievementController.Mechanics.Printing);
	}

	public float ActualPrintSpeed()
	{
		if (!Furn.upg.Broken && Furn.IsPlayerOwned())
		{
			return PrintSpeed / (float)GameSettings.DaysPerMonth;
		}
		return 0f;
	}

	private void PushLocalOrders(bool all)
	{
		bool wasBlocked;
		PushLocalOrders(all, out wasBlocked);
	}

	private void PushLocalOrders(bool all, out bool wasBlocked)
	{
		wasBlocked = false;
		if (LocalOrders.Count > ((!all) ? 1 : 0))
		{
			int num = Furn.Conveyor.CurrentBoxes.Length - 1;
			Conveyor conveyor = ((Furn.Conveyor.CurrentBoxes[num] != null) ? null : Furn.Conveyor.GetOutput(LocalOrders[0], 0, false, out wasBlocked));
			if (conveyor != null)
			{
				GameSettings.Instance.BoxController.CreateBox(LocalOrders[0], Furn.Conveyor, conveyor);
				LocalOrders.RemoveAt(0);
				Furn.StartInteraction = true;
			}
		}
	}

	public bool AcceptInput()
	{
		if (Type == PrinterType.Assembly)
		{
			if (LocalOrders.Count > ((NextPrint > 0f) ? 1 : 0))
			{
				return false;
			}
			return true;
		}
		return true;
	}

	public void PrinterPowerToggled(bool on)
	{
		lock (this)
		{
			_lastToggle = on;
		}
	}

	private void ToggleOn(bool on)
	{
		bool flag;
		lock (this)
		{
			flag = _lastToggle != on;
			_lastToggle = on;
		}
		if (flag)
		{
			if (on)
			{
				GameSettings.Instance.BoxController.TurnOn.AddThreaded(Furn);
			}
			else
			{
				GameSettings.Instance.BoxController.TurnOff.AddThreaded(Furn);
			}
		}
	}

	private void FinishOrder(ManufactureOrder order)
	{
		NextPrint += order.GetAssemblyTime() / 60f;
		IProductOrder item = order.Promote() ?? order;
		LocalOrders.Add(item);
	}

	public void ThreadTick(float delta)
	{
		_actualRun += delta;
		switch (Type)
		{
		case PrinterType.Assembly:
			lock (PushOut)
			{
				if (PushOut.Count > 0)
				{
					for (int i = 0; i < PushOut.Count; i++)
					{
						int num = ManufactureQueue.IndexOf(PushOut[i]);
						if (num >= 0 && !LocalOrders.Contains(PushOut[i]))
						{
							LocalOrders.Add(ManufactureQueue[num]);
							ManufactureQueue.RemoveAt(num);
						}
					}
					PushOut.Clear();
				}
			}
			if (ManufactureQueue.Count > 0)
			{
				_firstAge += delta;
			}
			else
			{
				_firstAge = 0f;
			}
			if (NextPrint > 0f)
			{
				NextPrint -= Utilities.PerHour(ActualPrintSpeed(), delta, false);
				if (NextPrint > 0f)
				{
					PushLocalOrders(false);
					ToggleOn(true);
					if (!Furn.upg.Broken)
					{
						_isActive += delta;
					}
					break;
				}
			}
			PushLocalOrders(true);
			if (!_skipAssemblers && LocalOrders.Count < 5)
			{
				bool flag = false;
				_skipAssemblers = true;
				lock (ManufactureQueue)
				{
					bool flag2 = false;
					for (int j = 0; j < ManufactureQueue.Count; j++)
					{
						if (ManufactureQueue[j].IsDone())
						{
							if (j == 0)
							{
								_firstAge = 0f;
							}
							AchievementController.SetInteraction(AchievementController.Mechanics.Printing | AchievementController.Mechanics.Manufacturing);
							FinishOrder(ManufactureQueue[j]);
							flag = true;
							ManufactureQueue.RemoveAt(j);
							ToggleOn(true);
							_skipAssemblers = false;
							break;
						}
						for (int k = j + 1; k < ManufactureQueue.Count; k++)
						{
							if (ManufactureQueue[j].CanMerge(ManufactureQueue[k]))
							{
								if (j == 0)
								{
									_firstAge = 0f;
								}
								if (ManufactureQueue[j].Merge(ManufactureQueue[k]))
								{
									ManufactureQueue.RemoveAt(k);
								}
								_skipAssemblers = false;
								if (ManufactureQueue[j].IsDone())
								{
									GameSettings.Instance.BoxController.RegisterPrint(this);
									AchievementController.SetInteraction(AchievementController.Mechanics.Printing | AchievementController.Mechanics.Manufacturing);
									FinishOrder(ManufactureQueue[j]);
									flag = true;
									ManufactureQueue.RemoveAt(j);
									ToggleOn(true);
									break;
								}
								k--;
							}
						}
						if (flag)
						{
							break;
						}
						if (j == 0 && _firstAge > ManufactureQueue[0].GetAssemblyTime() * 4f * (float)GameSettings.DaysPerMonth)
						{
							_firstAge = 0f;
							PrintJob printJob = GameSettings.Instance.GetPrintJob(ManufactureQueue[0].Target.DeferStock);
							if (printJob != null && (Group == null || Group.HasTask(printJob)))
							{
								_skipAssemblers = false;
								flag2 = true;
								break;
							}
							LocalOrders.Add(ManufactureQueue[0]);
							ManufactureQueue.RemoveAt(0);
							j--;
						}
					}
					if (!flag && TargetProcess != null && ManufactureQueue.Count > 0)
					{
						for (int l = 0; l < TargetProcess.ActiveAssemblers.Count; l++)
						{
							ProductPrinter productPrinter = TargetProcess.ActiveAssemblers[l];
							if (productPrinter != null && productPrinter != this)
							{
								for (int m = 0; m < ManufactureQueue.Count; m++)
								{
									lock (productPrinter.ManufactureQueue)
									{
										for (int n = 0; n < productPrinter.ManufactureQueue.Count; n++)
										{
											if (ManufactureQueue[m].CanMerge(productPrinter.ManufactureQueue[n]))
											{
												if (l == 0)
												{
													_firstAge = 0f;
												}
												_skipAssemblers = false;
												productPrinter._skipAssemblers = false;
												if (ManufactureQueue[m].Merge(productPrinter.ManufactureQueue[n]))
												{
													productPrinter.ManufactureQueue.RemoveAt(n);
												}
												if (ManufactureQueue[m].IsDone())
												{
													GameSettings.Instance.BoxController.RegisterPrint(this);
													AchievementController.SetInteraction(AchievementController.Mechanics.Printing | AchievementController.Mechanics.Manufacturing);
													FinishOrder(ManufactureQueue[m]);
													ManufactureQueue.RemoveAt(m);
													flag = true;
													ToggleOn(true);
													break;
												}
												n--;
											}
										}
										if (flag)
										{
											break;
										}
									}
									if (flag2)
									{
										break;
									}
								}
							}
							if (flag)
							{
								break;
							}
						}
					}
				}
				if (!flag)
				{
					ToggleOn(false);
					if (ManufactureQueue.Count == 0 && !Furn.upg.Broken)
					{
						_isActive += delta;
					}
				}
				else
				{
					_skipAssemblers = false;
					if (!Furn.upg.Broken)
					{
						_isActive += delta;
					}
				}
			}
			else
			{
				if (LocalOrders.Count < 5 && ManufactureQueue.Count == 0 && !Furn.upg.Broken)
				{
					_isActive += delta;
				}
				ToggleOn(false);
			}
			break;
		case PrinterType.Component:
		{
			HardwareComponent targetComponent;
			lock (this)
			{
				targetComponent = TargetComponent;
			}
			PrinterTick(delta, true, targetComponent);
			break;
		}
		case PrinterType.Product:
			PrinterTick(delta, false, null);
			break;
		}
	}

	private void PrinterTick(float delta, bool hardware, HardwareComponent targetComp)
	{
		if (NextPrint > 0f)
		{
			NextPrint -= Utilities.PerHour(ActualPrintSpeed(), delta, false);
			if (NextPrint > 0f)
			{
				PushLocalOrders(false);
				if (!_wasStalled && !Furn.upg.Broken)
				{
					_isActive += delta;
				}
				return;
			}
		}
		bool wasBlocked;
		PushLocalOrders(true, out wasBlocked);
		if (wasBlocked && hardware)
		{
			lock (HUD.Instance.PrinterBlocked)
			{
				HUD.Instance.PrinterBlocked.Add(this);
			}
		}
		if (LocalOrders.Count >= ((!hardware) ? 1 : 5))
		{
			ToggleOn(false);
			return;
		}
		if ((hardware && targetComp == null) || !AnyOrders(hardware))
		{
			if (!Furn.upg.Broken)
			{
				_isActive += delta;
			}
			ToggleOn(false);
			return;
		}
		_wasStalled = false;
		IProductOrder productOrder2;
		if (!hardware)
		{
			IProductOrder productOrder = GenerateOrder();
			productOrder2 = productOrder;
		}
		else
		{
			IProductOrder productOrder = GenerateHardwareOrder(out _wasStalled);
			productOrder2 = productOrder;
		}
		IProductOrder productOrder3 = productOrder2;
		if (productOrder3 != null)
		{
			LocalOrders.Add(productOrder3);
			ToggleOn(true);
			NextPrint += (hardware ? ((float)targetComp.Time / 60f) : 1f);
		}
		else if (_wasStalled && !wasBlocked)
		{
			ToggleOn(false);
			NextPrint += (float)targetComp.Time / 60f;
		}
		else
		{
			ToggleOn(false);
		}
		if (!_wasStalled && !Furn.upg.Broken)
		{
			_isActive += delta;
		}
	}

	public void FixReferences()
	{
		PostDeserialize();
		LocalOrders.FixMyReferences(true);
		ManufactureQueue.FixMyReferences(true);
		if (_activeJob != null)
		{
			_activeJob = GameSettings.Instance.GetPrintJob(_activeJob.Target);
		}
	}

	public override void PostDeserialize()
	{
		base.PostDeserialize();
		_lastToggle = Furn.IsOn;
		if (_targetComponent == null)
		{
			return;
		}
		SoftwareType orDefault = MarketSimulation.Active.SoftwareTypes.GetOrDefault(_targetComponentType);
		IManufacturable manufacturable = null;
		if (orDefault != null)
		{
			IManufacturable orDefault2 = orDefault.Categories.GetOrDefault(_targetComponentCategory);
			manufacturable = orDefault2 ?? orDefault.AddOns.GetOrDefault(_targetComponentCategory);
		}
		if (((manufacturable != null) ? manufacturable.GetManufacturing() : null) == null)
		{
			return;
		}
		switch (Type)
		{
		case PrinterType.Assembly:
		{
			lock (this)
			{
				if (_targetComponent.Equals("Final"))
				{
					TargetProcess = manufacturable.GetManufacturing().FinalProcess;
				}
				else
				{
					HardwareComponent hardwareComponent = manufacturable.GetManufacturing().Components.FirstOrDefault((HardwareComponent x) => x.Name.Equals(_targetComponent));
					if (hardwareComponent != null)
					{
						TargetProcess = hardwareComponent.OutputProcess;
					}
				}
			}
			ComponentProcess targetProcess = TargetProcess;
			if (targetProcess != null)
			{
				targetProcess.ActiveAssemblers.Add(this);
			}
			UpdateSticker();
			GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(Furn.Conveyor);
			break;
		}
		case PrinterType.Component:
			lock (this)
			{
				TargetComponent = manufacturable.GetManufacturing().Components.FirstOrDefault((HardwareComponent x) => x.Name.Equals(_targetComponent));
			}
			UpdateSticker();
			GameSettings.Instance.BoxController.AddConveyorForOutputAnalysis(Furn.Conveyor);
			break;
		}
	}

	protected override object DeserializeMe(WriteDictionary dictionary, bool loading, LoadType networkMode)
	{
		if (loading)
		{
			IProductOrder productOrder = dictionary.Get<IProductOrder>("PrinterOrder", null);
			LocalOrders = dictionary.Get("PrinterOrders", LocalOrders);
			if (productOrder != null)
			{
				LocalOrders.Add(productOrder);
			}
			NextPrint = dictionary.Get("NextPrint", 1f);
			if (Type == PrinterType.Assembly)
			{
				ManufactureQueue = dictionary.Get("ManufactureQueue", ManufactureQueue);
			}
			_firstAge = dictionary.Get("FirstAge", 0f);
			if (IsManufacturing())
			{
				_activeJob = dictionary.Get<PrintJob>("ActiveJob", null);
				_printAmount = dictionary.Get("PrintAmount", 0);
			}
		}
		_wasActive = dictionary.Get("WasActive", 1f);
		if (loading)
		{
			Group = dictionary.Get<AssemblyLine>("AssemblyLine", null);
			if (Group != null)
			{
				Group.Printers.Add(this);
			}
			OwedWatt = dictionary.Get("OwedWatt", 0f);
		}
		if (dictionary.Contains("TargetComponent"))
		{
			_targetComponentType = dictionary.Get<string>("TargetComponentType");
			_targetComponentCategory = dictionary.Get<string>("TargetComponentCategory");
			_targetComponent = dictionary.Get<string>("TargetComponent");
		}
		return this;
	}

	public void SetOutput(string path)
	{
		if (path == null)
		{
			return;
		}
		string[] p = path.Split('/');
		if (p.Length != 3)
		{
			return;
		}
		SoftwareType orNull = MarketSimulation.Active.SoftwareTypes.GetOrNull(p[0]);
		IManufacturable manufacturable = null;
		if (orNull != null)
		{
			IManufacturable orNull2 = orNull.Categories.GetOrNull(p[1]);
			manufacturable = orNull2 ?? orNull.AddOns.GetOrNull(p[1]);
		}
		if (manufacturable == null || !manufacturable.IsHardware())
		{
			return;
		}
		switch (Type)
		{
		case PrinterType.Assembly:
		{
			if ("Final".Equals(p[2]))
			{
				SetTargetProcess(manufacturable.GetManufacturing().FinalProcess);
				break;
			}
			HardwareComponent hardwareComponent2 = manufacturable.GetManufacturing().Components.FirstOrDefault((HardwareComponent x) => x.Name.Equals(p[2]));
			if (hardwareComponent2 != null)
			{
				SetTargetProcess(hardwareComponent2.OutputProcess);
			}
			break;
		}
		case PrinterType.Component:
		{
			HardwareComponent hardwareComponent = manufacturable.GetManufacturing().Components.FirstOrDefault((HardwareComponent x) => x.Name.Equals(p[2]));
			if (hardwareComponent != null)
			{
				SetTargetComponent(hardwareComponent);
			}
			break;
		}
		}
	}

	protected override void SerializeMe(WriteDictionary dictionary, GameReader.NewLoadMode mode, LoadType networkMode, bool checkDIDs)
	{
		if (mode == GameReader.NewLoadMode.Full)
		{
			dictionary["PrinterOrders"] = LocalOrders;
			dictionary["NextPrint"] = NextPrint;
			dictionary["WasActive"] = _wasActive;
			dictionary["OwedWatt"] = OwedWatt;
		}
		if (Type == PrinterType.Assembly)
		{
			if (mode == GameReader.NewLoadMode.Full)
			{
				dictionary["ManufactureQueue"] = ManufactureQueue;
				dictionary["FirstAge"] = _firstAge;
			}
			if (TargetProcess != null)
			{
				dictionary["TargetComponentType"] = TargetProcess.Parent.Type.Name;
				dictionary["TargetComponentCategory"] = TargetProcess.Parent.Category.GetActualName();
				dictionary["TargetComponent"] = (TargetProcess.Final ? "Final" : TargetProcess.Output.Name);
			}
		}
		else if (Type == PrinterType.Component && TargetComponent != null)
		{
			dictionary["TargetComponentType"] = TargetComponent.Parent.Type.Name;
			dictionary["TargetComponentCategory"] = TargetComponent.Parent.Category.GetActualName();
			dictionary["TargetComponent"] = TargetComponent.Name;
		}
		if (IsManufacturing())
		{
			dictionary["AssemblyLine"] = Group;
			dictionary["ActiveJob"] = _activeJob;
			dictionary["PrintAmount"] = _printAmount;
		}
	}

	public int GetMask()
	{
		if (Type == PrinterType.Component)
		{
			if (TargetComponent != null)
			{
				return TargetComponent.Mask;
			}
		}
		else if (Type == PrinterType.Assembly && TargetProcess != null)
		{
			return TargetProcess.InputMask;
		}
		return 0;
	}

	protected override bool WriteDID()
	{
		return false;
	}

	public bool TakeOrder(TransportBox box)
	{
		ManufactureOrder order;
		if ((order = box.Order as ManufactureOrder) != null)
		{
			return TakeComponent(order, box);
		}
		return false;
	}
}
