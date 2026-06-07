using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class BoxController : MonoBehaviour
{
	public const float ConveyorSpeedFactor = 1.5f;

	[NonSerialized]
	private Dictionary<int, List<TransportBox>> _boxes = new Dictionary<int, List<TransportBox>>();

	[NonSerialized]
	private ObjectPool<TransportBox> _boxPool = new ObjectPool<TransportBox>(() => new TransportBox(), delegate(TransportBox x)
	{
		x.Clear();
	}, delegate(TransportBox x)
	{
		x.Clear();
	});

	[NonSerialized]
	private Matrix4x4[] _transforms = new Matrix4x4[512];

	[NonSerialized]
	private float[] _atlas;

	[NonSerialized]
	private MaterialPropertyBlock _block;

	public Material BoxMat;

	public Mesh BoxMesh;

	public Vector3 Scale;

	[NonSerialized]
	public Thread MainThread;

	[NonSerialized]
	public bool IsAlive = true;

	[NonSerialized]
	public bool IsPaused;

	[NonSerialized]
	public bool ForceAssemblyCheck;

	private ReaderWriterLockSlim _boxLock = new ReaderWriterLockSlim();

	[NonSerialized]
	private float _skippedMinutes;

	[NonSerialized]
	public List<PrintJob> FinishedJobs = new List<PrintJob>();

	[NonSerialized]
	public List<Furniture> TurnOn = new List<Furniture>();

	[NonSerialized]
	public List<Furniture> TurnOff = new List<Furniture>();

	[NonSerialized]
	public List<Furniture> UpdatePallet = new List<Furniture>();

	[NonSerialized]
	public List<ProductPrinter> DidPrint = new List<ProductPrinter>();

	[NonSerialized]
	public List<KeyValuePair<int, ProductPrintOrder>> ApplyQueue = new List<KeyValuePair<int, ProductPrintOrder>>();

	[NonSerialized]
	public List<int> DidPrintAmount = new List<int>();

	[NonSerialized]
	private HashSet<Conveyor> _dirtyConveyors = new HashSet<Conveyor>();

	public float HourAccum;

	public TiledBox BoxPrefab;

	public Helicopter HelicopterPrefab;

	[NonSerialized]
	private ObjectPool<TiledBox> _tiledBoxPool;

	[NonSerialized]
	private ObjectPool<Helicopter> _helicopterBoxPool;

	[NonSerialized]
	private List<HelicopterData> _activeHelicopters = new List<HelicopterData>();

	public int BoxesShipped;

	public int BoxesShippedLast;

	[NonSerialized]
	private IStockable _highlight;

	private HashSet<PrintJob> _finished = new HashSet<PrintJob>();

	private static HashSet<Conveyor> _deemedValid = new HashSet<Conveyor>();

	public IStockable Highlight
	{
		get
		{
			return _highlight;
		}
		set
		{
			_highlight = value;
			if (!GameSettings.Instance.IsReferenceNull())
			{
				GameSettings.Instance.ProductPallets.ForEach(delegate(ProductPallet x)
				{
					x.RefreshBoxes();
				});
			}
		}
	}

	public void SendHelicopter(ProductPallet target)
	{
		if (!target.BeingFetched)
		{
			lock (_activeHelicopters)
			{
				_activeHelicopters.Add(new HelicopterData(target));
			}
			target.BeingFetched = true;
		}
	}

	public void CreateHelicopterRep(HelicopterData d)
	{
		if (_helicopterBoxPool == null)
		{
			_helicopterBoxPool = new ObjectPool<Helicopter>(() => UnityEngine.Object.Instantiate(HelicopterPrefab), delegate(Helicopter x)
			{
				x.gameObject.SetActive(true);
			}, delegate(Helicopter x)
			{
				x.gameObject.SetActive(false);
			});
		}
		Helicopter helicopter = _helicopterBoxPool.Get();
		helicopter.Init(d);
		d.IsRepped = true;
		d.Actual = helicopter;
	}

	public void ReleaseHelicopter(Helicopter c)
	{
		_helicopterBoxPool.Release(c);
	}

	public TiledBox GetBox()
	{
		if (_tiledBoxPool == null)
		{
			_tiledBoxPool = new ObjectPool<TiledBox>(() => UnityEngine.Object.Instantiate(BoxPrefab), delegate(TiledBox x)
			{
				x.gameObject.SetActive(true);
			}, delegate(TiledBox x)
			{
				x.transform.SetParent(null);
				x.transform.rotation = Quaternion.identity;
				x.transform.localScale = Vector3.one;
				x.gameObject.SetActive(false);
			});
		}
		return _tiledBoxPool.Get();
	}

	public void ReleaseBox(TiledBox box)
	{
		_tiledBoxPool.Release(box);
	}

	public void AddConveyorForOutputAnalysis(Conveyor c)
	{
		lock (_dirtyConveyors)
		{
			_dirtyConveyors.Add(c);
		}
	}

	public void AddSkippedMinutes(float amount)
	{
		lock (this)
		{
			_skippedMinutes += amount;
		}
	}

	public void CreateBox(IProductOrder order, Conveyor from, int point)
	{
		TransportBox transportBox;
		lock (_boxPool)
		{
			transportBox = _boxPool.Get();
		}
		transportBox.LastFloor = from.Floor;
		transportBox.Order = order;
		transportBox.From = from;
		transportBox.CPoint = point;
		transportBox.PutOnConveyor(from, transportBox.GetNextPoint());
		_boxes.Append(from.Floor, transportBox, _boxLock);
	}

	public IEnumerable<TransportBox> GetBoxes()
	{
		using (new ReadWriteLockUse(_boxLock, true))
		{
			foreach (KeyValuePair<int, List<TransportBox>> box in _boxes)
			{
				for (int i = 0; i < box.Value.Count; i++)
				{
					yield return box.Value[i];
				}
			}
		}
	}

	public void FixBoxReferences()
	{
		using (new ReadWriteLockUse(_boxLock, true))
		{
			foreach (KeyValuePair<int, List<TransportBox>> box in _boxes)
			{
				for (int i = 0; i < box.Value.Count; i++)
				{
					TransportBox transportBox = box.Value[i];
					if (transportBox.Order != null)
					{
						transportBox.Order = transportBox.Order.FixReferences() as IProductOrder;
						if (transportBox.Order == null)
						{
							box.Value.RemoveAt(i);
							i--;
						}
					}
				}
			}
		}
	}

	public void CreateBox(IProductOrder order, Conveyor from, Conveyor to)
	{
		TransportBox transportBox;
		lock (_boxPool)
		{
			transportBox = _boxPool.Get();
		}
		transportBox.Order = order;
		transportBox.From = from;
		transportBox.To = to;
		transportBox.LastFloor = from.Floor;
		transportBox.CPoint = from.CurrentBoxes.Length - 1;
		transportBox.PutOnConveyor(to, 0);
		_boxes.Append(from.Floor, transportBox, _boxLock);
	}

	public void DestroyBox(TransportBox box)
	{
		box.ClearOrder();
		box.ClearConveyors();
		List<TransportBox> orNull;
		using (new ReadWriteLockUse(_boxLock))
		{
			orNull = _boxes.GetOrNull(box.LastFloor);
		}
		bool flag = false;
		if (orNull != null)
		{
			lock (orNull)
			{
				flag = orNull.Remove(box);
			}
		}
		if (!flag)
		{
			using (new ReadWriteLockUse(_boxLock))
			{
				foreach (List<TransportBox> value in _boxes.Values)
				{
					lock (value)
					{
						value.Remove(box);
					}
				}
			}
		}
		lock (box)
		{
			box.From = null;
			box.To = null;
		}
		if (!box.Destroyed)
		{
			lock (_boxPool)
			{
				_boxPool.Release(box);
			}
			box.Destroyed = true;
		}
	}

	public void InitThread()
	{
		MainThread = new Thread(ThreadUpdate);
		MainThread.IsBackground = true;
		MainThread.Start(this);
		_atlas = new float[_transforms.Length];
		for (int i = 0; i < _transforms.Length; i++)
		{
			_atlas[i] = -1f;
		}
		_block = new MaterialPropertyBlock();
	}

	public void RegisterPrint(ProductPrinter printer, int amount = 0)
	{
		lock (DidPrint)
		{
			DidPrint.Add(printer);
			DidPrintAmount.Add(amount);
		}
	}

	public void FixedUpdate()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		lock (_activeHelicopters)
		{
			for (int i = 0; i < _activeHelicopters.Count; i++)
			{
				if (!_activeHelicopters[i].IsRepped && GameSettings.Instance.ActiveFloor >= _activeHelicopters[i].StartFloor)
				{
					CreateHelicopterRep(_activeHelicopters[i]);
				}
			}
		}
		lock (ApplyQueue)
		{
			for (int j = 0; j < ApplyQueue.Count; j++)
			{
				ApplyQueue[j].Value.Apply();
				BoxesShipped += ApplyQueue[j].Key;
				GameSettings.Instance.RegisterStat("PrintsShipped", ApplyQueue[j].Value.TotalCopies);
				GameSettings.Instance.MyCompany.MakeTransaction(-6500.0, Company.TransactionCategory.Bills, true, "Helicopter");
			}
			ApplyQueue.Clear();
		}
		lock (FinishedJobs)
		{
			for (int k = 0; k < FinishedJobs.Count; k++)
			{
				PrintJob printJob = FinishedJobs[k];
				if (_finished.Add(printJob))
				{
					SoftwareProduct softwareProduct = printJob.Target as SoftwareProduct;
					if (softwareProduct == null)
					{
						NotificationManager.AddNotification(new NotificationMessage("FinishedPrintingJob".LocColor(printJob.Target), "Box", SDateTime.Now(), NotificationManager.NotificationType.Good));
					}
					else
					{
						NotificationManager.AddNotification(new ProductDetailNotification(softwareProduct, "FinishedPrintingJob".LocColor(printJob.Target), "Box", SDateTime.Now(), NotificationManager.NotificationType.Good));
					}
				}
			}
			FinishedJobs.Clear();
			DistributionWindow.RefreshHardwareStats();
		}
		if (_finished.Count > 0)
		{
			foreach (PrintJob item in _finished)
			{
				GameSettings.Instance.CancelPrintOrder(item, false);
			}
			_finished.Clear();
			HUD.Instance.distributionWindow.RefreshOrders();
		}
		lock (TurnOn)
		{
			for (int l = 0; l < TurnOn.Count; l++)
			{
				Furniture furniture = TurnOn[l];
				if (furniture != null && !furniture.upg.Broken)
				{
					furniture.IsOn = true;
					furniture.Printer.PrinterPowerToggled(true);
				}
			}
			TurnOn.Clear();
		}
		lock (DidPrint)
		{
			float num = 1f / 24f;
			for (int m = 0; m < DidPrint.Count; m++)
			{
				ProductPrinter productPrinter = DidPrint[m];
				if (productPrinter != null)
				{
					if (DidPrintAmount[m] > 0)
					{
						float num2 = (float)DidPrintAmount[m] * productPrinter.GetPrintPrice();
						GameSettings.Instance.MyCompany.MakeTransaction(0f - num2, Company.TransactionCategory.Bills, true, "Printing");
					}
					float months = num * productPrinter.GetPrintTime();
					productPrinter.Furn.upg.DegradeMonths(months);
					productPrinter.AddOwedWatt(months);
				}
			}
			DidPrint.Clear();
			DidPrintAmount.Clear();
		}
		lock (TurnOff)
		{
			for (int n = 0; n < TurnOff.Count; n++)
			{
				if (TurnOff[n] != null)
				{
					TurnOff[n].IsOn = false;
					TurnOff[n].Printer.PrinterPowerToggled(false);
				}
			}
			TurnOff.Clear();
		}
		lock (UpdatePallet)
		{
			for (int num3 = 0; num3 < UpdatePallet.Count; num3++)
			{
				if (UpdatePallet[num3] != null)
				{
					UpdatePallet[num3].Pallet.RefreshBoxes();
				}
			}
			UpdatePallet.Clear();
		}
	}

	private void OnPreCull()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		List<TransportBox> orNull;
		using (new ReadWriteLockUse(_boxLock))
		{
			orNull = _boxes.GetOrNull(GameSettings.Instance.ActiveFloor);
		}
		if (orNull == null)
		{
			return;
		}
		int num = 0;
		lock (orNull)
		{
			for (int i = 0; i < orNull.Count; i++)
			{
				TransportBox transportBox = orNull[i];
				lock (transportBox)
				{
					if ((transportBox.From != null && transportBox.From.Parent.Colorable[0].isVisible) || (transportBox.To != null && transportBox.To.Parent.Colorable[0].isVisible))
					{
						_transforms[num] = Matrix4x4.TRS(transportBox.GetPosition(), transportBox.Rotation, Scale);
						_atlas[num] = ((transportBox.Order == null) ? (-1) : transportBox.Order.GetAtlasIndex());
						num++;
						if (num == _transforms.Length)
						{
							break;
						}
					}
				}
			}
		}
		if (num <= 0)
		{
			return;
		}
		if (!SystemInfo.supportsInstancing)
		{
			for (int j = 0; j < num; j++)
			{
				_block.SetFloat("_AtlasIndex", _atlas[j]);
				Graphics.DrawMesh(BoxMesh, _transforms[j], BoxMat, 0, CameraScript.Instance.mainCam, 0, _block, ShadowCastingMode.Off);
			}
		}
		else
		{
			_block.SetFloatArray("_AtlasIndex", _atlas);
			Graphics.DrawMeshInstanced(BoxMesh, 0, BoxMat, _transforms, num, _block, ShadowCastingMode.Off);
		}
	}

	private void OnApplicationPause(bool pauseStatus)
	{
		IsPaused = pauseStatus;
	}

	private void OnApplicationQuit()
	{
		IsAlive = false;
	}

	private static bool CanContinue(Conveyor c)
	{
		if (!c.Recycler)
		{
			if (!(c.Parent.Printer == null))
			{
				return c.Parent.Printer.Type == ProductPrinter.PrinterType.Component;
			}
			return true;
		}
		return false;
	}

	private static bool FindAllConnected(Conveyor from, HashSet<Conveyor> output, List<Conveyor> starts, bool back, bool hasRecycler)
	{
		if (from != null)
		{
			if (output.Add(from))
			{
				bool flag = (from.HadRecycler = from.Recycler || (back && hasRecycler));
				if (!from.Recycler)
				{
					for (int i = 0; i < from.OutputLength; i++)
					{
						Conveyor output2 = from.GetOutput(i);
						flag |= FindAllConnected(output2, output, starts, false, false);
					}
				}
				if (from.Parent.Printer != null && from.Parent.Printer.Type == ProductPrinter.PrinterType.Assembly)
				{
					from.Parent.Printer.MissingRecycler = !flag;
					from.HadRecycler = flag;
					flag = true;
				}
				else
				{
					from.HadRecycler = flag;
				}
				bool flag2 = false;
				lock (from.Inputs)
				{
					foreach (Conveyor input in from.Inputs)
					{
						FindAllConnected(input, output, starts, true, flag);
						flag2 = true;
					}
				}
				if (!flag2)
				{
					starts.Add(from);
				}
				return flag;
			}
			if (back && hasRecycler && !from.HadRecycler)
			{
				if (from.Parent.Printer != null && from.Parent.Printer.Type == ProductPrinter.PrinterType.Assembly)
				{
					from.Parent.Printer.MissingRecycler = false;
				}
				from.HadRecycler = true;
				lock (from.Inputs)
				{
					foreach (Conveyor input2 in from.Inputs)
					{
						FindAllConnected(input2, output, starts, true, true);
					}
				}
			}
			if (!from.Recycler)
			{
				return from.HadRecycler;
			}
			return true;
		}
		return false;
	}

	private static int Propagate(Conveyor from, int mask, HashSet<Conveyor> visited)
	{
		if (from.Parent.Printer != null && from.Parent.Printer.IsManufacturing())
		{
			mask |= from.Parent.Printer.GetMask();
		}
		if (CanContinue(from))
		{
			if (visited.Add(from))
			{
				int mask2 = mask;
				for (int i = 0; i < from.OutputLength; i++)
				{
					Conveyor output = from.GetOutput(i);
					if (output != null)
					{
						int num = Propagate(output, mask2, visited);
						mask |= num;
						from.OutputMasks[i] = num;
					}
					else
					{
						from.OutputMasks[i] = 0;
					}
				}
			}
			else
			{
				for (int j = 0; j < from.OutputLength; j++)
				{
					mask |= from.OutputMasks[j];
				}
			}
		}
		return mask;
	}

	private static ProductPrinter FindAssemblyGroups(Conveyor from, ProductPrinter main, HashSet<Conveyor> visited, HashSet<Conveyor> grouped, List<ProductPrinter> result)
	{
		if (from != null && visited.Add(from))
		{
			if (from.Recycler)
			{
				return main;
			}
			if (grouped.Contains(from))
			{
				return main;
			}
			ProductPrinter printer = from.Parent.Printer;
			if (printer != null && printer.IsManufacturing())
			{
				if (!printer.IsAssigned())
				{
					if (printer.Group != null)
					{
						AssemblyLine assemblyLine = printer.Group;
						printer.Group.RemovePrinter(printer);
						assemblyLine.RefreshMask();
					}
					return main;
				}
				if (main != null && printer.GetManufacturing() != main.GetManufacturing())
				{
					return main;
				}
				if (printer.IsAssigned())
				{
					if (main == null)
					{
						main = printer;
						result.Add(printer);
					}
					else
					{
						result.Add(printer);
					}
				}
			}
			lock (from.Inputs)
			{
				foreach (Conveyor input in from.Inputs)
				{
					main = FindAssemblyGroups(input, main, visited, grouped, result);
				}
			}
			Conveyor palletOutput = from.GetPalletOutput();
			if (palletOutput != null)
			{
				main = FindAssemblyGroups(palletOutput, main, visited, grouped, result);
			}
			Conveyor parentConveyor = from.GetParentConveyor();
			if (parentConveyor != null)
			{
				main = FindAssemblyGroups(parentConveyor, main, visited, grouped, result);
			}
			for (int i = 0; i < from.OutputLength; i++)
			{
				Conveyor output = from.GetOutput(i);
				if (output != null)
				{
					main = FindAssemblyGroups(output, main, visited, grouped, result);
				}
			}
		}
		return main;
	}

	private static bool GroupAssemblies(List<ProductPrinter> printers, HashSet<Conveyor> grouped, List<Conveyor> dirty, HashSet<AssemblyLine> groups)
	{
		groups.Clear();
		for (int i = 0; i < printers.Count; i++)
		{
			ProductPrinter productPrinter = printers[i];
			if (productPrinter.Group != null)
			{
				groups.Add(productPrinter.Group);
			}
		}
		if (groups.Count == 0)
		{
			AssemblyLine assemblyLine = new AssemblyLine(printers);
			GameSettings.Instance.AddAssemblyLine(assemblyLine);
			assemblyLine.RefreshMask();
			return true;
		}
		if (groups.Count == 1)
		{
			AssemblyLine g = groups.First();
			if (g.Printers.Count == printers.Count && printers.All((ProductPrinter x) => g.Printers.Contains(x)))
			{
				int hardwareMask = g.HardwareMask;
				int hardwareInputMask = g.HardwareInputMask;
				g.RefreshMask();
				if (hardwareMask == g.HardwareMask)
				{
					return hardwareInputMask != g.HardwareInputMask;
				}
				return true;
			}
		}
		IManufacturable cat = printers[0].GetManufacturing().Category;
		AssemblyLine assemblyLine2 = groups.Where((AssemblyLine x) => x.Category == cat).MaxInstance((AssemblyLine x) => (x.PlayerEdited ? 100 : 0) + printers.Count((ProductPrinter y) => x.Printers.Contains(y)));
		if (assemblyLine2 != null && printers.Count > assemblyLine2.Printers.Count / 2)
		{
			AssemblyLine assemblyLine3 = new AssemblyLine(assemblyLine2.Category);
			lock (assemblyLine2.Printers)
			{
				assemblyLine3.Printers.AddRange(assemblyLine2.Printers);
			}
			for (int num = 0; num < printers.Count; num++)
			{
				assemblyLine3.Printers.Remove(printers[num]);
				assemblyLine2.AddPrinter(printers[num]);
			}
			if (assemblyLine3.Printers.Count > 0)
			{
				assemblyLine3.InitName();
				foreach (ProductPrinter printer in assemblyLine3.Printers)
				{
					assemblyLine2.RemovePrinter(printer);
					printer.Group = assemblyLine3;
				}
				GameSettings.Instance.AddAssemblyLine(assemblyLine3);
				DirtyAssemblyLine(assemblyLine3, grouped, dirty);
				assemblyLine3.RefreshMask();
			}
			assemblyLine2.RefreshMask();
		}
		else
		{
			AssemblyLine line = new AssemblyLine(printers);
			GameSettings.Instance.AddAssemblyLine(line);
			foreach (AssemblyLine group in groups)
			{
				DirtyAssemblyLine(group, grouped, dirty);
				group.RefreshMask();
			}
		}
		return true;
	}

	private static void DirtyAssemblyLine(AssemblyLine g, HashSet<Conveyor> grouped, List<Conveyor> dirty)
	{
		lock (g.Printers)
		{
			foreach (ProductPrinter printer in g.Printers)
			{
				if (!grouped.Contains(printer.Furn.Conveyor))
				{
					dirty.Add(printer.Furn.Conveyor);
				}
			}
		}
	}

	private static bool CheckValid(Conveyor from, ProductPrinter start, HashSet<Conveyor> visited)
	{
		bool valid = false;
		if (from != null)
		{
			if (!visited.Add(from))
			{
				if (!_deemedValid.Contains(from))
				{
					if (!from.Recycler)
					{
						return from.Parent.Printer == null;
					}
					return false;
				}
				return true;
			}
			for (int i = 0; i < from.OutputLength; i++)
			{
				if (!CheckSubValid(from.GetOutput(i), start, visited, ref valid))
				{
					return false;
				}
			}
		}
		if (valid)
		{
			_deemedValid.Add(from);
		}
		return valid;
	}

	private static bool CheckSubValid(Conveyor o, ProductPrinter start, HashSet<Conveyor> visited, ref bool valid)
	{
		if (o != null)
		{
			int num = CheckCompatibility(o, start);
			switch (num)
			{
			case 0:
				return false;
			case 1:
				if (!CheckValid(o, start, visited))
				{
					return false;
				}
				valid = true;
				break;
			}
			if (num == 2)
			{
				valid = true;
			}
		}
		return true;
	}

	private static int CheckCompatibility(Conveyor c, ProductPrinter p)
	{
		if (c.Parent.Printer != null)
		{
			if (!ManufactureOverlay.CheckValid(p.GetHardwareComponent(), c.Parent.Printer.GetHardwareProcess()))
			{
				return 0;
			}
			return 2;
		}
		if (c.Recycler)
		{
			return 0;
		}
		return 1;
	}

	private static void CheckSplitters(HashSet<Conveyor> from, HashSet<Conveyor> output, List<Conveyor> starts, bool forceCheck)
	{
		output.Clear();
		starts.Clear();
		lock (from)
		{
			starts.AddRange(from);
		}
		if (starts.Count > 0)
		{
			bool flag = false;
			HashSet<Conveyor> hashSet = new HashSet<Conveyor>();
			List<ProductPrinter> list = new List<ProductPrinter>();
			List<ProductPrinter> list2 = new List<ProductPrinter>();
			HashSet<AssemblyLine> groups = new HashSet<AssemblyLine>();
			for (int i = 0; i < starts.Count; i++)
			{
				Conveyor conveyor = starts[i];
				if (output.Contains(conveyor))
				{
					continue;
				}
				hashSet.Clear();
				list.Clear();
				FindAssemblyGroups(conveyor, null, hashSet, output, list);
				if (list.Count > 0)
				{
					list2.AddRange(list);
					output.AddRange(list.Select((ProductPrinter x) => x.Furn.Conveyor));
					flag |= GroupAssemblies(list, output, starts, groups);
				}
			}
			for (int num = 0; num < list2.Count; num++)
			{
				ProductPrinter productPrinter = list2[num];
				if (!productPrinter.IsFinalAssembly())
				{
					if (productPrinter.IsAssigned())
					{
						hashSet.Clear();
						_deemedValid.Clear();
						productPrinter.InvalidOutput = !CheckValid(productPrinter.Furn.Conveyor, productPrinter, hashSet);
					}
					else
					{
						productPrinter.InvalidOutput = false;
					}
				}
			}
			if (flag)
			{
				List<AssemblyLine> assemblyLinesUnsafe = GameSettings.Instance.GetAssemblyLinesUnsafe();
				lock (assemblyLinesUnsafe)
				{
					for (int num2 = 0; num2 < assemblyLinesUnsafe.Count; num2++)
					{
						AssemblyLine assemblyLine = assemblyLinesUnsafe[num2];
						bool flag2;
						lock (assemblyLine.Printers)
						{
							flag2 = assemblyLine.Printers.Count == 0 || assemblyLine.Printers.Count((ProductPrinter x) => x != null) == 0;
						}
						if (flag2)
						{
							assemblyLine.ClearTasks(false);
							assemblyLinesUnsafe.RemoveAt(num2);
							num2--;
						}
						else
						{
							assemblyLine.AutoAssign();
						}
					}
				}
				forceCheck = false;
				if (AssemblyLineWindow.Instance != null)
				{
					AssemblyLineWindow.Instance.Dirty = true;
				}
				GameSettings.Instance.PrinterChanged();
			}
		}
		if (forceCheck)
		{
			List<AssemblyLine> assemblyLinesUnsafe2 = GameSettings.Instance.GetAssemblyLinesUnsafe();
			bool flag3 = false;
			lock (assemblyLinesUnsafe2)
			{
				for (int num3 = 0; num3 < assemblyLinesUnsafe2.Count; num3++)
				{
					AssemblyLine assemblyLine2 = assemblyLinesUnsafe2[num3];
					bool flag4;
					lock (assemblyLine2.Printers)
					{
						flag4 = assemblyLine2.Printers.Count == 0 || assemblyLine2.Printers.Count((ProductPrinter x) => x != null) == 0;
					}
					if (flag4)
					{
						assemblyLine2.ClearTasks(false);
						assemblyLinesUnsafe2.RemoveAt(num3);
						flag3 = true;
						num3--;
					}
				}
			}
			if (flag3)
			{
				if (AssemblyLineWindow.Instance != null)
				{
					AssemblyLineWindow.Instance.Dirty = true;
				}
				GameSettings.Instance.PrinterChanged();
			}
		}
		output.Clear();
		starts.Clear();
		lock (from)
		{
			if (from.Count > 0)
			{
				Conveyor conveyor2 = from.First();
				from.Remove(conveyor2);
				FindAllConnected(conveyor2, output, starts, false, false);
				foreach (Conveyor item in output)
				{
					from.Remove(item);
				}
			}
		}
		if (starts.Count > 0)
		{
			for (int num4 = 0; num4 < starts.Count; num4++)
			{
				output.Clear();
				Propagate(starts[num4], 0, output);
			}
		}
	}

	public IEnumerable<ProductPrintOrder> GetHelicopterStorage()
	{
		lock (_activeHelicopters)
		{
			for (int i = 0; i < _activeHelicopters.Count; i++)
			{
				HelicopterData helicopterData = _activeHelicopters[i];
				if (helicopterData.Order != null)
				{
					yield return helicopterData.Order;
				}
			}
		}
	}

	private static void ThreadUpdate(object controller)
	{
		new System.Random();
		BoxController boxController = (BoxController)controller;
		List<TransportBox> list = new List<TransportBox>();
		Stopwatch stopwatch = Stopwatch.StartNew();
		Stopwatch stopwatch2 = Stopwatch.StartNew();
		HashSet<Conveyor> output = new HashSet<Conveyor>();
		List<Conveyor> starts = new List<Conveyor>();
		while (boxController.IsAlive)
		{
			Thread.Sleep(16);
			using (new ReadWriteLockUse(GameReader.SaveLock))
			{
				try
				{
					CheckSplitters(boxController._dirtyConveyors, output, starts, boxController.ForceAssemblyCheck);
					boxController.ForceAssemblyCheck = false;
				}
				catch (Exception ex)
				{
					if (!boxController.IsAlive || GameSettings.Instance.IsReferenceNull() || HUD.Instance == null)
					{
						break;
					}
					ErrorLogging.AddException(ex);
				}
				if (!boxController.IsAlive)
				{
					break;
				}
				stopwatch.Stop();
				float num = (float)stopwatch.Elapsed.TotalSeconds;
				stopwatch.Restart();
				num = ((!boxController.IsPaused) ? (num * GameSettings.GameSpeed) : 0f);
				lock (boxController)
				{
					num += boxController._skippedMinutes;
					boxController._skippedMinutes = 0f;
				}
				if (num == 0f)
				{
					continue;
				}
				stopwatch2.Restart();
				double num2 = 0.0;
				while (num > 0f)
				{
					stopwatch2.Stop();
					double totalMilliseconds = stopwatch2.Elapsed.TotalMilliseconds;
					num2 += totalMilliseconds;
					double num3 = 1000.0 - num2;
					float num4 = ((!(totalMilliseconds > 200.0) && !(totalMilliseconds * (double)(num / 0.05f) > 10000.0)) ? 0.05f : ((num3 > 0.0) ? Mathf.Clamp((float)((double)num / (num3 / totalMilliseconds)), 0.05f, num) : num));
					stopwatch2.Restart();
					float num5 = Mathf.Min(num4, num);
					num -= num4;
					boxController.HourAccum += num5;
					if (boxController.HourAccum >= 60f)
					{
						try
						{
							boxController.HourAccum %= 60f;
							lock (GameSettings.Instance.Recyclers)
							{
								for (int i = 0; i < GameSettings.Instance.Recyclers.Count; i++)
								{
									Conveyor conveyor = GameSettings.Instance.Recyclers[i];
									if (conveyor != null)
									{
										conveyor.NextHour();
									}
								}
							}
							lock (GameSettings.Instance.ProductPrinters)
							{
								for (int j = 0; j < GameSettings.Instance.ProductPrinters.Count; j++)
								{
									ProductPrinter productPrinter = GameSettings.Instance.ProductPrinters[j];
									if (productPrinter != null)
									{
										productPrinter.PassHour();
									}
								}
							}
						}
						catch (Exception ex2)
						{
							if (!boxController.IsAlive || GameSettings.Instance.IsReferenceNull() || HUD.Instance == null)
							{
								break;
							}
							ErrorLogging.AddException(ex2);
						}
					}
					try
					{
						lock (boxController._activeHelicopters)
						{
							for (int k = 0; k < boxController._activeHelicopters.Count; k++)
							{
								if (boxController._activeHelicopters[k].UpdateMe(num5, boxController))
								{
									boxController._activeHelicopters.RemoveAt(k);
									k--;
								}
							}
						}
						lock (GameSettings.Instance.ProductPrinters)
						{
							for (int l = 0; l < GameSettings.Instance.ProductPrinters.Count; l++)
							{
								ProductPrinter productPrinter2 = GameSettings.Instance.ProductPrinters[l];
								if (productPrinter2 != null)
								{
									productPrinter2.ThreadTick(num5);
								}
							}
						}
						lock (GameSettings.Instance.ProductPallets)
						{
							for (int m = 0; m < GameSettings.Instance.ProductPallets.Count; m++)
							{
								ProductPallet productPallet = GameSettings.Instance.ProductPallets[m];
								if (productPallet != null)
								{
									productPallet.Tick(num5);
								}
							}
						}
						lock (GameSettings.Instance.FoodAssemblers)
						{
							for (int n = 0; n < GameSettings.Instance.FoodAssemblers.Count; n++)
							{
								FoodAssemblyInput foodAssemblyInput = GameSettings.Instance.FoodAssemblers[n];
								if (foodAssemblyInput != null)
								{
									foodAssemblyInput.UpdateMe();
								}
							}
						}
						using (new ReadWriteLockUse(boxController._boxLock))
						{
							foreach (KeyValuePair<int, List<TransportBox>> box in boxController._boxes)
							{
								List<TransportBox> value = box.Value;
								lock (value)
								{
									for (int num6 = 0; num6 < value.Count; num6++)
									{
										TransportBox transportBox = value[num6];
										int floor = transportBox.GetFloor();
										bool flag;
										lock (transportBox)
										{
											flag = transportBox.Update(num5);
										}
										if (flag)
										{
											transportBox.ClearConveyors();
											if (!transportBox.Destroyed)
											{
												lock (boxController._boxPool)
												{
													boxController._boxPool.Release(transportBox);
												}
												transportBox.Destroyed = true;
											}
											value.RemoveAt(num6);
											num6--;
										}
										else if (floor != transportBox.LastFloor)
										{
											transportBox.LastFloor = floor;
											list.Add(transportBox);
											value.RemoveAt(num6);
											num6--;
										}
									}
								}
							}
						}
						if (list.Count <= 0)
						{
							continue;
						}
						for (int num7 = 0; num7 < list.Count; num7++)
						{
							if (!list[num7].Destroyed)
							{
								boxController._boxes.Append(list[num7].LastFloor, list[num7], boxController._boxLock);
							}
						}
						list.Clear();
					}
					catch (Exception ex3)
					{
						if (!boxController.IsAlive || GameSettings.Instance.IsReferenceNull() || HUD.Instance == null)
						{
							break;
						}
						ErrorLogging.AddException(ex3);
					}
				}
			}
		}
	}

	public List<TransportBox.SaveBox> Serialize()
	{
		List<TransportBox.SaveBox> list = new List<TransportBox.SaveBox>();
		foreach (KeyValuePair<int, List<TransportBox>> box in _boxes)
		{
			list.AddRange(box.Value.Select((TransportBox x) => x.ToSerializable()));
		}
		return list;
	}

	public List<HelicopterData> GetHelicopterData()
	{
		return _activeHelicopters;
	}

	public void Deserialize(List<TransportBox.SaveBox> boxes, List<HelicopterData> helicopters)
	{
		if (helicopters != null)
		{
			_activeHelicopters.AddRange(helicopters);
			for (int i = 0; i < helicopters.Count; i++)
			{
				Furniture furniture = Writeable.STGetDeserializedObject(helicopters[i].TargetDID) as Furniture;
				if (furniture != null)
				{
					helicopters[i].Target = furniture.Pallet;
				}
			}
		}
		if (boxes == null)
		{
			return;
		}
		for (int j = 0; j < boxes.Count; j++)
		{
			TransportBox.SaveBox saveBox = boxes[j];
			if (saveBox.Order == null)
			{
				continue;
			}
			Furniture furniture2 = null;
			Furniture furniture3 = null;
			if (saveBox.From != 0)
			{
				furniture2 = Writeable.STGetDeserializedObject(saveBox.From) as Furniture;
			}
			if (saveBox.To != 0)
			{
				furniture3 = Writeable.STGetDeserializedObject(saveBox.To) as Furniture;
			}
			if (furniture2 != null || furniture3 != null)
			{
				if (furniture3 != null && furniture3.Conveyor.CurrentBoxes[saveBox.APoint] != null)
				{
					saveBox.Order.RemoveFromStorage();
					continue;
				}
				if (furniture2 != null && furniture2.Conveyor.CurrentBoxes[saveBox.APoint] != null)
				{
					saveBox.Order.RemoveFromStorage();
					continue;
				}
				TransportBox transportBox = _boxPool.Get();
				transportBox.From = (((object)furniture2 != null) ? furniture2.Conveyor : null);
				transportBox.To = (((object)furniture3 != null) ? furniture3.Conveyor : null);
				transportBox.Order = saveBox.Order;
				transportBox.Progress = saveBox.Progress;
				transportBox.CPoint = saveBox.Point;
				transportBox.APoint = saveBox.APoint;
				transportBox.Speed = saveBox.Speed;
				if (furniture3 != null)
				{
					furniture3.Conveyor.CurrentBoxes[transportBox.APoint] = transportBox;
				}
				else
				{
					furniture2.Conveyor.CurrentBoxes[transportBox.APoint] = transportBox;
				}
				_boxes.Append(transportBox.GetFloor(), transportBox);
			}
			else
			{
				saveBox.Order.RemoveFromStorage();
			}
		}
	}

	public void StopThread()
	{
		IsAlive = false;
	}

	private void OnDestroy()
	{
		IsAlive = false;
	}
}
