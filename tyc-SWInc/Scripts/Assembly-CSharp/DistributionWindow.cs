using System;
using System.Collections.Generic;
using System.Linq;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class DistributionWindow : MonoBehaviour
{
	public GUIWindow Window;

	public UIPrintMarkup PrintMarkupPrefab;

	public Transform PrintMarkupPanel;

	public GUIListView OrderList;

	public GUIListView HWOrderList;

	public GUIListView DealList;

	public ManufacturingPanel ManPanel;

	public VarValueSheet PrintSheet;

	public VarValueSheet ManufactureSheet;

	public int CurrentTab;

	public GameObject[] Tabs;

	public Image[] TabImages;

	public Color ActiveColor;

	public float PrintSpeed;

	public float PrioritySum = 1f;

	private static Dictionary<HardwareComponent, float> _printerCache = new Dictionary<HardwareComponent, float>();

	private static Dictionary<string, PrintJob> _orderCache = new Dictionary<string, PrintJob>();

	public static uint PrintDirty;

	private bool _first = true;

	public static float GetPrintsPerMonth(PrintJob p)
	{
		if (p.Priority == 0f || p.IsPrintDone())
		{
			return 0f;
		}
		_orderCache.Clear();
		lock (GameSettings.Instance.PrintOrders)
		{
			bool flag = false;
			for (int i = 0; i < GameSettings.Instance.PrintOrders.Count; i++)
			{
				PrintJob printJob = GameSettings.Instance.PrintOrders[i];
				if (printJob.Hardware)
				{
					flag = flag || printJob == p;
					_orderCache[printJob.Target.GetIdentifyingName()] = printJob;
				}
			}
			if (!flag)
			{
				return 0f;
			}
		}
		_printerCache.Clear();
		int num = 0;
		List<AssemblyLine> assemblyLinesUnsafe = GameSettings.Instance.GetAssemblyLinesUnsafe();
		lock (assemblyLinesUnsafe)
		{
			for (int j = 0; j < assemblyLinesUnsafe.Count; j++)
			{
				AssemblyLine assemblyLine = assemblyLinesUnsafe[j];
				if (!assemblyLine.HasTask(p))
				{
					continue;
				}
				foreach (ProductPrinter printer in assemblyLine.Printers)
				{
					if (printer.Type != ProductPrinter.PrinterType.Component || printer.TargetComponent == null || !p.CompatibleWith(printer.TargetComponent))
					{
						continue;
					}
					int num2 = 0;
					List<PrintJob> tasksUnsafe = assemblyLine.GetTasksUnsafe();
					lock (tasksUnsafe)
					{
						for (int k = 0; k < tasksUnsafe.Count; k++)
						{
							if (!tasksUnsafe[k].IsPrintDone())
							{
								num2 += Mathf.RoundToInt(tasksUnsafe[k].Priority);
							}
						}
					}
					float value = p.Priority / (float)num2;
					_printerCache.AddUp(printer.TargetComponent, value);
					num |= printer.TargetComponent.Mask;
				}
			}
		}
		if ((num & p.Target.HardwareInputMask) != p.Target.HardwareInputMask)
		{
			return 0f;
		}
		float num3 = 0f;
		foreach (KeyValuePair<HardwareComponent, float> item in _printerCache)
		{
			num3 = Mathf.Max((float)item.Key.Time / item.Value, num3);
		}
		return 60f / num3 * 24f * 1000f;
	}

	public static void RefreshHardwareStats()
	{
		PrintDirty++;
	}

	public void ChangeTab(int i)
	{
		CurrentTab = i;
		for (int j = 0; j < Tabs.Length; j++)
		{
			Tabs[j].SetActive(j == i);
			TabImages[j].color = ((j == i) ? ActiveColor : Color.white);
		}
		switch (CurrentTab)
		{
		case 0:
			Window.ChangeAssociatedTutorial("Physical distribution");
			break;
		case 1:
			Window.ChangeAssociatedTutorial("Manufacturing");
			break;
		case 2:
			Window.ChangeAssociatedTutorial(null);
			break;
		}
		if (Window.AssociatedTutorial != null)
		{
			TutorialSystem.Instance.StartTutorial(Window.AssociatedTutorial);
		}
	}

	public void LimitSelected(bool hw)
	{
		List<PrintJob> sel = (from x in (hw ? HWOrderList : OrderList).GetSelected<PrintJob>()
			where !x.DealID.HasValue && !x.Target.IsReadOnlyJob
			select x).ToList();
		if (sel.Count <= 0)
		{
			return;
		}
		uint? num = null;
		foreach (PrintJob item in sel)
		{
			if (item.Limit.HasValue && (!num.HasValue || item.Limit.Value > num.Value))
			{
				num = item.Limit.Value;
			}
		}
		WindowManager.SpawnInputDialog("LimitCopyPrompt".Loc(), "Maximumcopies".Loc(), num.HasValue ? num.Value.ToString("N0") : "-1", delegate(string x)
		{
			if (x.Trim().Equals("-1"))
			{
				foreach (PrintJob item2 in sel)
				{
					item2.Limit = null;
				}
				return;
			}
			try
			{
				uint value = Convert.ToUInt32(x.Replace(",", ""));
				foreach (PrintJob item3 in sel)
				{
					item3.Limit = value;
					item3.Maximum = null;
				}
			}
			catch (Exception)
			{
			}
		});
	}

	public void MaximumSelected(bool hw)
	{
		List<PrintJob> sel = (from x in (hw ? HWOrderList : OrderList).GetSelected<PrintJob>()
			where !x.DealID.HasValue && !x.Target.IsReadOnlyJob
			select x).ToList();
		if (sel.Count <= 0)
		{
			return;
		}
		uint? num = null;
		foreach (PrintJob item in sel)
		{
			if (item.Maximum.HasValue && (!num.HasValue || item.Maximum.Value > num.Value))
			{
				num = item.Maximum.Value;
			}
		}
		WindowManager.SpawnInputDialog("MaximumCopyPrompt".Loc(), "Maximumcopies".Loc(), num.HasValue ? num.Value.ToString("N0") : "-1", delegate(string x)
		{
			if (x.Trim().Equals("-1"))
			{
				foreach (PrintJob item2 in sel)
				{
					item2.Maximum = null;
				}
				return;
			}
			try
			{
				uint value = Convert.ToUInt32(x.Replace(",", ""));
				foreach (PrintJob item3 in sel)
				{
					item3.Maximum = value;
					item3.Limit = null;
				}
			}
			catch (Exception)
			{
			}
		});
	}

	public void CancelSelected(bool hw)
	{
		PrintJob[] selected = (hw ? HWOrderList : OrderList).GetSelected<PrintJob>();
		if (selected.Length != 0)
		{
			for (int i = 0; i < selected.Length; i++)
			{
				GameSettings.Instance.CancelPrintOrder(selected[i], true);
			}
			RefreshOrders();
		}
	}

	public void Show()
	{
		Show(null);
	}

	public void Show(PrintJob order)
	{
		if (Window.Shown && order == null)
		{
			Window.Close();
			return;
		}
		Window.Show();
		if (order != null)
		{
			ChangeTab(order.Hardware ? 1 : 0);
		}
		else if (_first)
		{
			ChangeTab(0);
		}
		if (_first)
		{
			HWOrderList.OnSelectChange = delegate
			{
				PrintJob[] selected = HWOrderList.GetSelected<PrintJob>();
				if (selected.Length != 0)
				{
					PrintJob printJob = selected[0];
					int? optimalCount = null;
					uint? goalNum = printJob.GetGoalNum();
					SDateTime? deadlineDate = printJob.GetDeadlineDate();
					if (goalNum.HasValue && deadlineDate.HasValue)
					{
						optimalCount = (int)(goalNum.Value / Mathf.Max(1, SDateTime.GetMonthsFlat(SDateTime.Now(), deadlineDate.Value)));
					}
					ManPanel.Initialize(printJob.Target.Manufacturing, printJob.Target.FeaturesBases, printJob.Target.GetFeaturesFactors(), optimalCount, printJob);
				}
				else
				{
					ManPanel.Clear();
				}
			};
			HWOrderList.Initialize();
		}
		_first = false;
		RefreshOrders();
		RefreshDeals();
		if (order != null)
		{
			GUIListView gUIListView = (order.Hardware ? HWOrderList : OrderList);
			int num = gUIListView.ActualItems.IndexOf(order);
			if (num >= 0)
			{
				gUIListView.ClearSelected();
				gUIListView.Select(num);
				gUIListView.KeepIdxInView(num);
			}
		}
		RefreshHardwareStats();
	}

	private void Start()
	{
		UpdateOrders();
		if (GameSettings.Instance.IsNetworkMode)
		{
			AddPrintMarkup(true, null);
			foreach (KeyValuePair<string, SoftwareType> softwareType in MarketSimulation.Active.SoftwareTypes)
			{
				if (softwareType.Value.OneClient)
				{
					continue;
				}
				foreach (SoftwareCategory value in softwareType.Value.Categories.Values)
				{
					if (value.Hardware)
					{
						AddPrintMarkup(false, value);
					}
				}
				foreach (SoftwareAddOn value2 in softwareType.Value.AddOns.Values)
				{
					if (value2.Hardware)
					{
						AddPrintMarkup(false, value2);
					}
				}
			}
		}
		TabImages[2].gameObject.SetActive(GameSettings.Instance.IsNetworkMode);
		PrintSheet.SetData(new string[3]
		{
			"Printingcapacity".Loc(),
			"Shippingcapacity".Loc(),
			"Lastmonth".Loc()
		}, Array.Empty<string>());
		ManufactureSheet.SetData(new string[4]
		{
			"Manufacturing".Loc(),
			"Shippingcapacity".Loc(),
			"Lastmonth".Loc(),
			"RecycleEffeciency".Loc()
		}, Array.Empty<string>());
		ManufactureSheet.ToolTips = new string[4]
		{
			"*" + "UnitsPerBox".Loc(1000u),
			null,
			null,
			"RecycleEffeciencyTip"
		};
	}

	private void Update()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			UpdateOrders();
		}
	}

	private void UpdateOrders()
	{
		float num = 0f;
		PrintSpeed = 0f;
		for (int i = 0; i < GameSettings.Instance.ProductPrinters.Count; i++)
		{
			ProductPrinter productPrinter = GameSettings.Instance.ProductPrinters[i];
			if (!productPrinter.IsManufacturing())
			{
				float num2 = productPrinter.ActualPrintSpeed() * 24f * (float)GameSettings.DaysPerMonth;
				num += num2;
				PrintSpeed += num2 * (float)productPrinter.PrintAmount;
			}
		}
		int num3 = GameSettings.Instance.sActorManager.Staff.Count((Actor x) => !x.OnCall && x.AItype == AI.AIType.Courier) * AI.MaxBoxesDPM;
		num3 += GameSettings.Instance.ProductPallets.SumSafe((ProductPallet x) => (x.Furn.IsPlayerOwned() && !x.StaticBox) ? 1440 : 0);
		BoxController boxController = GameSettings.Instance.BoxController;
		int num4 = Mathf.Max(boxController.BoxesShipped, boxController.BoxesShippedLast);
		string text = "PerMonth".Loc();
		int num5 = GameSettings.Instance.sActorManager.Staff.SumSafe((Actor x) => (!x.OnCall && x.AItype == AI.AIType.Courier) ? (Mathf.Max(x.LastBoxesShipped, x.BoxesShipped) * GameSettings.DaysPerMonth) : 0) + num4;
		PrintSheet.UpdateValues(new string[3]
		{
			"CopiesPostfix".Loc(Mathf.RoundToInt(PrintSpeed).ToString("N0")) + text + " / " + "BoxPostfix".Loc(num.ToString("N0")) + text,
			"BoxPostfix".Loc(num3.ToString("N0")) + text,
			"BoxPostfix".Loc(num5.ToString("N0"))
		});
		float value = 1f;
		float num6 = 0f;
		float num7 = 0f;
		lock (GameSettings.Instance.Recyclers)
		{
			for (int num8 = 0; num8 < GameSettings.Instance.Recyclers.Count; num8++)
			{
				Conveyor conveyor = GameSettings.Instance.Recyclers[num8];
				if (conveyor != null && conveyor.Recycled != null)
				{
					num6 += (float)conveyor.Recycled.SumSafe((int x) => x);
					num7 += (float)conveyor.NonRecycled.SumSafe((int x) => x);
				}
			}
		}
		if (num6 > 0f)
		{
			value = num7 / (num6 + num7);
		}
		int num9 = 0;
		lock (GameSettings.Instance.PrintOrders)
		{
			PrioritySum = GameSettings.Instance.PrintOrders.SumSafe((PrintJob x) => (!x.IsActive() || x.ReachedGoal() || x.Hardware) ? 0f : x.Priority);
			num9 = GameSettings.Instance.PrintOrders.SumSafe((PrintJob x) => x.Hardware ? x.PrintPerMonth() : 0) / 1000;
		}
		if (PrioritySum == 0f)
		{
			PrioritySum = 1f;
		}
		ManufactureSheet.UpdateValues(new string[4]
		{
			"BoxPostfix".Loc(num9.ToString("N0")) + text,
			"BoxPostfix".Loc(num3.ToString("N0")) + text,
			"BoxPostfix".Loc(num5.ToString("N0")),
			value.ToPercent()
		});
	}

	public void RefreshDeals()
	{
		DealList.Items = GameSettings.Instance.NetworkPrintOrders.List.Where((NetworkPrintDeal x) => x.Client == NetworkManager.LocalPlayerID).Cast<object>().ToList();
	}

	public void RefreshOrders()
	{
		HashSet<PrintJob> hashSet;
		lock (GameSettings.Instance.PrintOrders)
		{
			hashSet = GameSettings.Instance.PrintOrders.ToHashSet();
		}
		for (int i = 0; i < HWOrderList.Items.Count; i++)
		{
			object obj = HWOrderList.Items[i];
			if (hashSet.Contains(obj))
			{
				hashSet.Remove(obj as PrintJob);
				continue;
			}
			HWOrderList.Items.RemoveAt(i);
			i--;
		}
		for (int j = 0; j < OrderList.Items.Count; j++)
		{
			object obj2 = OrderList.Items[j];
			if (hashSet.Contains(obj2))
			{
				hashSet.Remove(obj2 as PrintJob);
				continue;
			}
			OrderList.Items.RemoveAt(j);
			j--;
		}
		foreach (PrintJob item in hashSet)
		{
			if (item.Hardware)
			{
				HWOrderList.Items.Add(item);
			}
			else
			{
				OrderList.Items.Add(item);
			}
		}
		OrderList.UpdateElements();
		HWOrderList.UpdateElements();
	}

	public void PopOutManufacturing()
	{
		PrintJob[] selected = HWOrderList.GetSelected<PrintJob>();
		if (selected.Length != 0)
		{
			IStockable target = selected[0].Target;
			int? optimalCount = null;
			uint? goalNum = selected[0].GetGoalNum();
			SDateTime? deadlineDate = selected[0].GetDeadlineDate();
			if (goalNum.HasValue && deadlineDate.HasValue)
			{
				optimalCount = (int)(goalNum.Value / Mathf.Max(1, SDateTime.GetMonthsFlat(SDateTime.Now(), deadlineDate.Value)));
			}
			HUD.Instance.ManufacturingWindow.Show(target.Manufacturing, target.FeaturesBases, target.GetFeaturesFactors(), optimalCount);
		}
	}

	private void AddPrintMarkup(bool software, IManufacturable manufacturable)
	{
		UIPrintMarkup uIPrintMarkup = UnityEngine.Object.Instantiate(PrintMarkupPrefab);
		uIPrintMarkup.transform.SetParent(PrintMarkupPanel, false);
		uIPrintMarkup.gameObject.SetActive(true);
		uIPrintMarkup.Init(software, manufacturable);
	}
}
