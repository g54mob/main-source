using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ManufacturingPanel : MaskableGraphic, ILayoutElement
{
	public class PseudoProcess
	{
		public PseudoProcess Output;

		public List<PseudoProcess> Inputs = new List<PseudoProcess>();

		public HardwareComponent Component;

		public ManufacturingItem GUIItem;

		public bool Final;

		public bool Optional;

		public float x;

		public float y;

		public float LineOff = 0.5f;

		public int Optimal = 1;

		public int Has;

		public int SubNeed = 1;

		public float GetOptimalValue(int mult)
		{
			int num = mult * Optimal;
			if (Has > num)
			{
				return (float)num / (float)Has;
			}
			if (num > Has)
			{
				return (float)Has / (float)num;
			}
			return 1f;
		}

		public PseudoProcess(ComponentProcess process, PseudoProcess parent)
		{
			if (process.Final)
			{
				Final = true;
			}
			else
			{
				Component = process.Output;
			}
			Optional = false;
			Output = parent;
			if (parent != null)
			{
				parent.Inputs.Add(this);
			}
		}

		public PseudoProcess(HardwareComponent c, PseudoProcess parent)
		{
			Component = c;
			Output = parent;
			Optional = !string.IsNullOrEmpty(c.DependsOn);
			if (parent != null)
			{
				parent.Inputs.Add(this);
			}
		}

		public void InitializeGUI(IManufacturable cat, ManufacturingItem prefab, float maxTime, bool interactable)
		{
			GUIItem = UnityEngine.Object.Instantiate(prefab);
			GUIItem.Init(this, cat, maxTime, interactable);
		}
	}

	private class LineOverlap
	{
		public List<PseudoProcess> P = new List<PseudoProcess>();

		public float A;

		public float B;

		public LineOverlap(PseudoProcess p, float a, float b)
		{
			P.Add(p);
			A = a;
			B = b;
		}

		public void Add(PseudoProcess p, float a, float b)
		{
			P.Add(p);
			A = Mathf.Min(A, a);
			B = Mathf.Max(B, b);
		}

		public bool Overlap(float a, float b)
		{
			return Utilities.Overlap(A, B, a, b);
		}

		public void Apply(float min, float max)
		{
			if (P.Count == 1)
			{
				P[0].LineOff = 0.5f;
				return;
			}
			bool flag = P[0].Output != null && P[0].Output.GUIItem.RTransform.anchoredPosition.x < P[0].GUIItem.RTransform.anchoredPosition.x;
			for (int i = 0; i < P.Count; i++)
			{
				P[i].LineOff = Mathf.Lerp(flag ? max : min, flag ? min : max, (float)i / (float)(P.Count - 1));
			}
		}
	}

	[NonSerialized]
	public PseudoProcess Root;

	[NonSerialized]
	public IManufacturable Cat;

	public ManufacturingItem ItemPrefab;

	public ManufacturingItem ButtonPrefab;

	[NonSerialized]
	private List<PseudoProcess> _processes = new List<PseudoProcess>();

	[NonSerialized]
	private Dictionary<HardwareComponent, PseudoProcess> _map = new Dictionary<HardwareComponent, PseudoProcess>();

	public int Width;

	public int Height;

	public Gradient AmountGradient;

	public float Cost;

	public Text InfoLabel;

	public Text CompatibleAssemblyText;

	public Toggle Average;

	public Toggle Maximum;

	public Toggle Specific;

	public InputField TargetCopies;

	private bool _initialized;

	public int Multiplier = 1;

	public bool Ready;

	public bool Interactive;

	public bool Assembly;

	public GUIWindow Window;

	public GUICombobox CategoryCombo;

	public RectOffset Padding;

	[NonSerialized]
	private Action<object> _onAction;

	public Texture2D MainTex;

	public GUILegend Legend;

	public GameObject CompatibleAssemblyWarning;

	public GameObject ManageAssemblyButton;

	public RectTransform LegendPanel;

	public RectTransform LegendToggle;

	public RectTransform LegendArrow;

	[NonSerialized]
	public List<AssemblyLine> CompatibleLines = new List<AssemblyLine>();

	[NonSerialized]
	public int HardwareMask;

	[NonSerialized]
	public int HardwareInputMask;

	private uint _printerChangeCounter;

	private bool _disableLegendUpdate;

	private float _extraSpacing;

	public Vector2 Size = new Vector2(256f, 256f);

	public Vector2 Spacing = new Vector2(16f, 16f);

	public Vector2 ArrowVerticalSpacing = new Vector2(0.25f, 0.75f);

	public override Texture mainTexture
	{
		get
		{
			return MainTex;
		}
	}

	public float minWidth { get; private set; }

	public float preferredWidth
	{
		get
		{
			return GetWidth(Width);
		}
	}

	public float flexibleWidth { get; private set; }

	public float minHeight { get; private set; }

	public float preferredHeight
	{
		get
		{
			return GetHeight(Height);
		}
	}

	public float flexibleHeight { get; private set; }

	public int layoutPriority { get; private set; }

	public void Scroll(BaseEventData ev)
	{
		PointerEventData pointerEventData = ev as PointerEventData;
		if (pointerEventData != null)
		{
			RefreshScale(pointerEventData.scrollDelta.y);
		}
	}

	public void RefreshScale(float change)
	{
		RectTransform rectTransform = base.rectTransform;
		RectTransform component = base.transform.parent.GetComponent<RectTransform>();
		float num = Mathf.Min(1f, component.rect.width / rectTransform.rect.width, component.rect.height / rectTransform.rect.height);
		float num2 = Mathf.Clamp(rectTransform.localScale.x + change * (1f - num) / 5f, num, 1f);
		rectTransform.localScale = new Vector3(num2, num2, 1f);
	}

	public void ToggleLegend()
	{
		ShowLegend(!LegendPanel.gameObject.activeSelf);
	}

	public void ShowLegend(bool show)
	{
		if (show)
		{
			LegendPanel.gameObject.SetActive(true);
			LegendToggle.anchoredPosition = new Vector2(0f - LegendPanel.sizeDelta.x - 1f, LegendToggle.anchoredPosition.y);
			LegendArrow.rotation = Quaternion.Euler(0f, 0f, 180f);
		}
		else
		{
			LegendPanel.gameObject.SetActive(false);
			LegendToggle.anchoredPosition = new Vector2(0f, LegendToggle.anchoredPosition.y);
			LegendArrow.rotation = Quaternion.Euler(0f, 0f, 0f);
		}
	}

	protected override void Start()
	{
		if (Application.isPlaying && Legend != null)
		{
			Legend.OnToggle = OnLegendToggle;
		}
	}

	public void OnLegendToggle()
	{
		if (!_disableLegendUpdate)
		{
			RefreshCounts();
		}
	}

	public void Show(bool assembly, IManufacturable def, Action<object> onAction)
	{
		if (!_initialized)
		{
			CategoryCombo.UpdateContent(MarketSimulation.Active.SoftwareTypes.Values.SelectMany((SoftwareType x) => (from y in x.Categories.Values.OfType<IManufacturable>()
				where y.IsHardware()
				select y).Concat(x.AddOns.Values.Where((SoftwareAddOn y) => y.Hardware))));
			_initialized = true;
		}
		if (CategoryCombo.Items.Count > 0)
		{
			Window.Show();
			_onAction = delegate(object x)
			{
				onAction(x);
				Window.Close();
			};
			Assembly = assembly;
			if (def != null && CategoryCombo.Items.Contains(def))
			{
				CategoryCombo.SelectedItem = def;
			}
			ComboChange();
		}
	}

	public void ComboChange()
	{
		Initialize((IManufacturable)CategoryCombo.SelectedItem, null, null, null, null);
	}

	public void Show(IManufacturable cat, IList<FeatureBase> features, IList<uint> factors, int? optimalCount = null)
	{
		Window.Show();
		Initialize(cat, features, factors, optimalCount, null);
	}

	public void ResetButton()
	{
		_onAction(null);
	}

	private void FixedUpdate()
	{
		if (!Interactive && Ready && Application.isPlaying && GameSettings.Instance.PrinterChangeCounter != _printerChangeCounter)
		{
			_printerChangeCounter = GameSettings.Instance.PrinterChangeCounter;
			RefreshAssemblyLines(null);
			RefreshCounts();
		}
	}

	public void OptToggled()
	{
		RefreshCounts();
	}

	private void RefreshCounts()
	{
		if (Root == null || Interactive)
		{
			return;
		}
		for (int i = 0; i < _processes.Count; i++)
		{
			_processes[i].Has = 0;
		}
		if (CompatibleLines.Count == 0)
		{
			for (int j = 0; j < GameSettings.Instance.ProductPrinters.Count; j++)
			{
				ProductPrinter productPrinter = GameSettings.Instance.ProductPrinters[j];
				if (productPrinter.Type == ProductPrinter.PrinterType.Assembly)
				{
					if (productPrinter.TargetProcess == null || productPrinter.TargetProcess.Parent != Cat.GetManufacturing())
					{
						continue;
					}
					if (productPrinter.TargetProcess.Final)
					{
						Root.Has++;
						continue;
					}
					PseudoProcess orDefault = _map.GetOrDefault(productPrinter.TargetProcess.Output);
					if (orDefault != null && orDefault.Inputs.Count > 0)
					{
						orDefault.Has++;
					}
				}
				else if (productPrinter.Type == ProductPrinter.PrinterType.Component && productPrinter.TargetComponent != null && productPrinter.TargetComponent.Parent == Cat.GetManufacturing())
				{
					PseudoProcess orDefault2 = _map.GetOrDefault(productPrinter.TargetComponent);
					if (orDefault2 != null && orDefault2.Inputs.Count == 0)
					{
						orDefault2.Has++;
					}
				}
			}
		}
		else
		{
			for (int k = 0; k < CompatibleLines.Count; k++)
			{
				if (!Legend.IsOn(k))
				{
					continue;
				}
				HashSet<ProductPrinter> printers = CompatibleLines[k].Printers;
				lock (printers)
				{
					foreach (ProductPrinter item in printers)
					{
						if (item.Type == ProductPrinter.PrinterType.Assembly)
						{
							if (item.TargetProcess == null)
							{
								continue;
							}
							if (item.TargetProcess.Final)
							{
								Root.Has++;
								continue;
							}
							PseudoProcess orDefault3 = _map.GetOrDefault(item.TargetProcess.Output);
							if (orDefault3 != null && orDefault3.Inputs.Count > 0)
							{
								orDefault3.Has++;
							}
						}
						else if (item.Type == ProductPrinter.PrinterType.Component && item.TargetComponent != null)
						{
							PseudoProcess orDefault4 = _map.GetOrDefault(item.TargetComponent);
							if (orDefault4 != null && orDefault4.Inputs.Count == 0)
							{
								orDefault4.Has++;
							}
						}
					}
				}
			}
		}
		float num = 0f;
		for (int l = 0; l < _processes.Count; l++)
		{
			PseudoProcess pseudoProcess = _processes[l];
			num = ((!Maximum.isOn) ? (num + (float)pseudoProcess.Has / (float)pseudoProcess.Optimal) : Mathf.Max(num, (float)pseudoProcess.Has / (float)pseudoProcess.Optimal));
		}
		if (Maximum.isOn)
		{
			Multiplier = Mathf.Max(1, Mathf.CeilToInt(num));
		}
		else if (Specific.isOn)
		{
			int num2 = Mathf.Max(1, TargetCopies.text.Replace(",", "").ConvertToIntDef(1));
			float lowTime = GetLowTime(Root);
			float num3 = 60f / lowTime * 24f * 1000f;
			Multiplier = Mathf.CeilToInt((float)num2 / num3);
		}
		else
		{
			num /= (float)_processes.Count;
			Multiplier = Mathf.Max(1, Mathf.RoundToInt(num));
		}
		for (int m = 0; m < _processes.Count; m++)
		{
			_processes[m].GUIItem.RefreshCounts(Multiplier);
		}
		int num4 = Mathf.FloorToInt(GetLowestOutputPerHour(Root, (PseudoProcess x) => x.Has) * 24f * 1000f);
		int num5 = Mathf.FloorToInt(GetLowestOutputPerHour(Root, (PseudoProcess x) => x.Optimal * Multiplier) * 24f * 1000f);
		InfoLabel.text = string.Format("{0}\n{1} ({2}: {3})", "PricePerCopy".Loc(Cost.Currency()), "CopyPerMonth".Loc(num4.ToString("N0")), "Optimal".Loc(), num5.ToString("N0"));
		SetVerticesDirty();
	}

	private float GetLowTime(PseudoProcess p)
	{
		float num = (p.Final ? Cat.GetManufacturing().FinalTime : p.Component.Time);
		for (int i = 0; i < p.Inputs.Count; i++)
		{
			num = Mathf.Min(num, GetLowTime(p.Inputs[i]));
		}
		return num;
	}

	public float GetLowestOutputPerHour(PseudoProcess p, Func<PseudoProcess, int> getAmount)
	{
		float num = 60f / (float)(p.Final ? Cat.GetManufacturing().FinalTime : p.Component.Time) * (float)getAmount(p);
		if (p.Inputs.Count > 0)
		{
			if (num == 0f)
			{
				return 0f;
			}
			for (int i = 0; i < p.Inputs.Count; i++)
			{
				num = Mathf.Min(num, GetLowestOutputPerHour(p.Inputs[i], getAmount));
			}
		}
		return num;
	}

	public float GetOutputPerHour(PseudoProcess p, Func<PseudoProcess, int> getAmount)
	{
		float num = 60f / (float)(p.Final ? Cat.GetManufacturing().FinalTime : p.Component.Time) * (float)getAmount(p);
		if (p.Inputs.Count > 0)
		{
			if (num == 0f)
			{
				return 0f;
			}
			float num2 = float.MaxValue;
			for (int i = 0; i < p.Inputs.Count; i++)
			{
				num2 = Mathf.Min(num2, GetOutputPerHour(p.Inputs[i], getAmount));
			}
			if (num2 == 0f)
			{
				return 0f;
			}
			return num * num2 / (num + num2);
		}
		return num;
	}

	public void Clear()
	{
		Ready = false;
		for (int i = 0; i < _processes.Count; i++)
		{
			UnityEngine.Object.Destroy(_processes[i].GUIItem.gameObject);
		}
		_processes.Clear();
		_map.Clear();
		if (Legend != null)
		{
			Legend.Items.Clear();
			ShowLegend(false);
			SetCompatibleAssemblyWarning(false);
			ManageAssemblyButton.SetActive(false);
			CompatibleLines.Clear();
		}
		Cost = 0f;
		Width = 1;
		Height = 1;
		if (!Interactive)
		{
			InfoLabel.text = "";
		}
		Root = null;
		SetVerticesDirty();
		SetLayoutDirty();
	}

	public void RefreshAssemblyLines(PrintJob job)
	{
		HashSet<AssemblyLine> newLines = (from x in GameSettings.Instance.GetAssemblyLines()
			where x.IsCompatible(Cat, HardwareMask, HardwareInputMask) > 0
			select x).ToHashSet();
		if (newLines.Count != 0 && newLines.Count == CompatibleLines.Count && !CompatibleLines.Any((AssemblyLine x) => !newLines.Contains(x)))
		{
			return;
		}
		CompatibleLines.Clear();
		CompatibleLines.AddRange(newLines);
		if (CompatibleLines.Count > 0)
		{
			Legend.Colors.Clear();
			Legend.Colors.AddRange(CompatibleLines.Select((AssemblyLine x) => x.AColor));
			Legend.Items.Clear();
			Legend.Items.AddRange(CompatibleLines.Select((AssemblyLine x) => x.Name));
			Legend.gameObject.SetActive(true);
			SetCompatibleAssemblyWarning(false);
			ManageAssemblyButton.SetActive(true);
			Legend.UpdateItems();
			if (job != null)
			{
				_disableLegendUpdate = true;
				for (int num = 0; num < CompatibleLines.Count; num++)
				{
					AssemblyLine assemblyLine = CompatibleLines[num];
					Legend.SetOn(num, assemblyLine.HasTask(job));
				}
				_disableLegendUpdate = false;
			}
		}
		else
		{
			Legend.gameObject.SetActive(false);
			SetCompatibleAssemblyWarning(true);
			ManageAssemblyButton.SetActive(false);
		}
	}

	public void SetCompatibleAssemblyWarning(bool en)
	{
		if (en)
		{
			bool flag = false;
			HashSet<HardwareComponent> hashSet = null;
			HashSet<HardwareComponent> hashSet2 = null;
			bool flag2 = false;
			foreach (AssemblyLine assemblyLine in GameSettings.Instance.GetAssemblyLines())
			{
				if (assemblyLine.Category != Cat)
				{
					continue;
				}
				int num = HardwareInputMask & ~assemblyLine.HardwareInputMask;
				int num2 = HardwareMask & ~assemblyLine.HardwareMask;
				HashSet<HardwareComponent> hashSet3 = new HashSet<HardwareComponent>();
				HashSet<HardwareComponent> hashSet4 = new HashSet<HardwareComponent>();
				bool flag3 = !assemblyLine.HasFinal;
				for (int i = 0; i < 32; i++)
				{
					int num3 = 1 << i;
					if ((num3 & num) != 0)
					{
						hashSet3.Add(Cat.GetManufacturing().Components[i]);
					}
					else if ((num3 & num2) != 0)
					{
						hashSet4.Add(Cat.GetManufacturing().Components[i]);
					}
				}
				if (hashSet == null || hashSet3.Count + hashSet4.Count + (flag3 ? 1 : 0) < hashSet.Count + hashSet2.Count)
				{
					hashSet = hashSet3;
					hashSet2 = hashSet4;
					flag2 = flag3;
				}
				flag = true;
			}
			if (!flag)
			{
				CompatibleAssemblyText.text = "NoValidAssemblyLinesType".Loc(Cat.GetPrettyName());
			}
			else
			{
				List<string> list = new List<string>();
				if (flag2)
				{
					list.Add("FinalAssemblyName".Loc() + " " + "Assemblers".Loc().ToLower());
				}
				foreach (HardwareComponent c in hashSet)
				{
					string text = c.GetBaseName() + " " + "Printers".Loc().ToLower();
					if (GameSettings.Instance.ProductPrinters.Any((ProductPrinter x) => x.IsProducing(c, false)))
					{
						text = text + " (" + "NotThis".Loc("Assemblers".Loc().ToLower()) + ")";
					}
					list.Add(text);
				}
				foreach (HardwareComponent c2 in hashSet2)
				{
					string text2 = c2.GetBaseName() + " " + "Assemblers".Loc().ToLower();
					if (GameSettings.Instance.ProductPrinters.Any((ProductPrinter x) => x.IsProducing(c2, true)))
					{
						text2 = text2 + " (" + "NotThis".Loc("Printers".Loc().ToLower()) + ")";
					}
					list.Add(text2);
				}
				CompatibleAssemblyText.text = "NoValidAssemblyLinesComponent".Loc(Newspaper.MakeList(list));
			}
			CompatibleAssemblyWarning.SetActive(true);
		}
		else
		{
			CompatibleAssemblyWarning.SetActive(false);
		}
	}

	public void OpenAssemblyWindow()
	{
		AssemblyLineWindow.Instance.Toggle();
	}

	public void Initialize(IManufacturable cat, IList<FeatureBase> features, IList<uint> factors, int? optimalCount, PrintJob job, bool tutorial = true)
	{
		bool flag = LegendPanel != null && LegendPanel.gameObject.activeSelf;
		Clear();
		if (!Interactive)
		{
			if (optimalCount.HasValue)
			{
				TargetCopies.text = optimalCount.Value.ToString("N0");
				Specific.isOn = true;
			}
			else
			{
				Average.isOn = true;
			}
		}
		IManufacturable cat2 = Cat;
		Cat = cat;
		if (features != null)
		{
			float price;
			Cat.GetManufacturing().GetProcessInfo(features, factors, out price, out HardwareMask, out HardwareInputMask);
			RefreshAssemblyLines(job);
			if (flag || CompatibleAssemblyWarning.activeSelf || Cat != cat2)
			{
				ShowLegend(true);
			}
		}
		Root = BuildTree(cat.GetManufacturing().FinalProcess, features, factors, null);
		if (!Interactive)
		{
			GetOptimal2(Root, GetMinTime(Root));
		}
		OrderInputs(Root);
		List<int> itemDepth = GetItemDepth(Root, new List<int>());
		_extraSpacing = (float)Mathf.Max(0, Width - 6) * 24f;
		PositionItems(Root, 0, itemDepth, GetMaxTime(Root));
		FixLineOverlap(itemDepth.Count);
		RefreshCounts();
		SetVerticesDirty();
		SetLayoutDirty();
		LayoutRebuilder.ForceRebuildLayoutImmediate(base.rectTransform);
		RefreshScale(0f);
		Ready = true;
		_printerChangeCounter = GameSettings.Instance.PrinterChangeCounter;
		if (tutorial)
		{
			TutorialSystem.Instance.StartTutorial("Manufacturing");
		}
	}

	private int GetMinTime(PseudoProcess p)
	{
		int num = (p.Final ? Cat.GetManufacturing().FinalTime : p.Component.Time);
		for (int i = 0; i < p.Inputs.Count; i++)
		{
			num = Mathf.Min(num, GetMinTime(p.Inputs[i]));
		}
		return num;
	}

	private int GetMaxTime(PseudoProcess p)
	{
		int num = (p.Final ? Cat.GetManufacturing().FinalTime : p.Component.Time);
		for (int i = 0; i < p.Inputs.Count; i++)
		{
			num = Mathf.Max(num, GetMaxTime(p.Inputs[i]));
		}
		return num;
	}

	private void GetOptimal2(PseudoProcess p, int min)
	{
		int num = (p.Final ? Cat.GetManufacturing().FinalTime : p.Component.Time);
		p.Optimal = Mathf.RoundToInt((float)num / (float)min);
		for (int i = 0; i < p.Inputs.Count; i++)
		{
			GetOptimal2(p.Inputs[i], min);
		}
		if (p.Inputs.Count == 0)
		{
			Cost += p.Component.Price;
		}
	}

	private void GetOptimal(PseudoProcess p, int mult, out int needed)
	{
		needed = 1;
		if (p.Inputs.Count > 0)
		{
			int num = (p.Final ? Cat.GetManufacturing().FinalTime : p.Component.Time);
			for (int i = 0; i < p.Inputs.Count; i++)
			{
				int time = p.Inputs[i].Component.Time;
				if (time < num)
				{
					needed = Mathf.Max(needed, Mathf.RoundToInt((float)num / (float)time));
				}
			}
			int num2 = 1;
			for (int j = 0; j < p.Inputs.Count; j++)
			{
				PseudoProcess pseudoProcess = p.Inputs[j];
				int time2 = pseudoProcess.Component.Time;
				int num3 = 1;
				if (time2 > num)
				{
					num3 = Mathf.RoundToInt((float)time2 / (float)num) * needed;
				}
				GetOptimal(pseudoProcess, num3 * mult, out pseudoProcess.SubNeed);
				num2 = Mathf.Max(num2, pseudoProcess.SubNeed);
			}
			needed *= num2;
			p.Optimal = mult * needed;
		}
		else
		{
			p.Optimal = mult;
			Cost += p.Component.Price;
		}
	}

	private void MultOpt(PseudoProcess p, int mult)
	{
		p.Optimal *= mult;
		for (int i = 0; i < p.Inputs.Count; i++)
		{
			MultOpt(p.Inputs[i], mult);
		}
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (Root != null)
		{
			DrawDependencies(Root, vh);
		}
	}

	private void DrawDependencies(PseudoProcess pp, VertexHelper vh)
	{
		if (pp.GUIItem == null)
		{
			return;
		}
		Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(base.transform, pp.GUIItem.RTransform);
		float y = bounds.max.y;
		int num = pp.Inputs.Count;
		if (pp.Inputs.Count > 1)
		{
			num = 0;
			float x = pp.GUIItem.RTransform.anchoredPosition.x;
			for (int i = 0; i < pp.Inputs.Count && pp.Inputs[i].GUIItem.RTransform.anchoredPosition.x <= x; i++)
			{
				num = i + 1;
			}
		}
		if (pp.Inputs.Count > 0 && num == 1 && pp.Inputs[0].GUIItem.RTransform.anchoredPosition.x.Appx(pp.GUIItem.RTransform.anchoredPosition.x))
		{
			num = 0;
		}
		for (int j = 0; j < pp.Inputs.Count; j++)
		{
			PseudoProcess pseudoProcess = pp.Inputs[j];
			Bounds bounds2 = RectTransformUtility.CalculateRelativeRectTransformBounds(base.transform, pseudoProcess.GUIItem.RTransform);
			float x2 = bounds2.center.x;
			float y2 = bounds2.min.y;
			float num2 = bounds.min.x + ((float)j + 1f) / ((float)pp.Inputs.Count + 1f) * bounds.size.x;
			float lineOff = pseudoProcess.LineOff;
			float num3 = Mathf.Lerp(y, y2, lineOff);
			Color color = new Color(Interactive ? 1f : pseudoProcess.GetOptimalValue(Multiplier), 0f, 0f, 1f);
			if (num2 == x2)
			{
				vh.DrawLine(new Vector2(num2, y), new Vector2(num2, y2), 12f, color);
			}
			else
			{
				int num4 = ((num2 > x2) ? (-6) : 6);
				vh.DrawLine(new Vector2(x2, num3 + 6f), new Vector2(x2, y2), 12f, color);
				vh.DrawLine(new Vector2(num2 + (float)num4, num3), new Vector2(x2 + (float)num4, num3), 12f, color);
				vh.DrawLine(new Vector2(num2, y), new Vector2(num2, num3 + 6f), 12f, color);
			}
			DrawDependencies(pseudoProcess, vh);
		}
	}

	private List<int> GetItemDepth(PseudoProcess p, List<int> depths, int d = 0)
	{
		p.x = 0f;
		p.y = d;
		if (d >= depths.Count)
		{
			depths.Add(1);
			Height = depths.Count;
		}
		else
		{
			p.x = depths[d];
			depths[d]++;
			Width = Mathf.Max(Width, depths[d]);
		}
		for (int i = 0; i < p.Inputs.Count; i++)
		{
			GetItemDepth(p.Inputs[i], depths, d + 1);
		}
		return depths;
	}

	private void FixLineOverlap(int lines)
	{
		List<List<LineOverlap>> list = new List<List<LineOverlap>>();
		for (int i = 0; i < lines; i++)
		{
			list.Add(new List<LineOverlap>());
		}
		CheckOverlap(Root, list, 0);
		for (int j = 0; j < list.Count; j++)
		{
			List<LineOverlap> list2 = list[j];
			for (int k = 0; k < list2.Count; k++)
			{
				list2[k].Apply(ArrowVerticalSpacing.x, ArrowVerticalSpacing.y);
			}
		}
	}

	private void CheckLap(PseudoProcess p, List<LineOverlap> lap, float b)
	{
		float num = p.GUIItem.RTransform.anchoredPosition.x + p.GUIItem.RTransform.rect.width / 2f;
		if (num > b)
		{
			float num2 = num;
			num = b;
			b = num2;
		}
		num -= 6f;
		b += 6f;
		if (lap.Count == 0)
		{
			lap.Add(new LineOverlap(p, num, b));
			return;
		}
		for (int i = 0; i < lap.Count; i++)
		{
			if (lap[i].Overlap(num, b))
			{
				lap[i].Add(p, num, b);
				return;
			}
		}
		lap.Add(new LineOverlap(p, num, b));
	}

	private void CheckOverlap(PseudoProcess p, List<List<LineOverlap>> laps, int d, float? b = null)
	{
		if (b.HasValue)
		{
			CheckLap(p, laps[d], b.Value);
		}
		float x = p.GUIItem.RTransform.anchoredPosition.x;
		float width = p.GUIItem.RTransform.rect.width;
		for (int i = 0; i < p.Inputs.Count; i++)
		{
			CheckOverlap(p.Inputs[i], laps, d + 1, x + ((float)i + 1f) / ((float)p.Inputs.Count + 1f) * width);
		}
	}

	private void PositionItems(PseudoProcess p, int idx, List<int> depths, float maxTime, int d = 0)
	{
		for (int i = 0; i < p.Inputs.Count; i++)
		{
			PositionItems(p.Inputs[i], i, depths, maxTime, d + 1);
		}
		p.InitializeGUI(Cat, Interactive ? ButtonPrefab : ItemPrefab, maxTime, Interactive);
		if (Interactive)
		{
			p.GUIItem.InitializeAction(_onAction, Assembly);
		}
		p.GUIItem.RTransform.SetParent(base.transform, false);
		float num2;
		if (p.Inputs.Count == 0 || (d + 1 < depths.Count && depths[d] > depths[d + 1]))
		{
			float num = GetWidth(depths[d]) - (float)Padding.right;
			num2 = preferredWidth / 2f - num / 2f + p.x * (Size.x + Spacing.x) + Size.x / 2f;
		}
		else
		{
			float num3 = float.MaxValue;
			float num4 = float.MinValue;
			for (int j = 0; j < p.Inputs.Count; j++)
			{
				RectTransform rTransform = p.Inputs[j].GUIItem.RTransform;
				num3 = Mathf.Min(rTransform.anchoredPosition.x, num3);
				num4 = Mathf.Max(rTransform.anchoredPosition.x + rTransform.rect.width, num4);
			}
			num2 = (num3 + num4) * 0.5f - Size.x / 2f;
		}
		if (idx > 0 && p.Output != null)
		{
			RectTransform rTransform2 = p.Output.Inputs[idx - 1].GUIItem.RTransform;
			num2 = Mathf.Max(num2, rTransform2.anchoredPosition.x + rTransform2.rect.width + Spacing.x);
		}
		int items = depths.Count - d;
		float num5 = GetHeight(items) - (float)Padding.bottom;
		p.GUIItem.RTransform.anchoredPosition = new Vector2(num2, 0f - num5);
	}

	private void OrderInputs(PseudoProcess p)
	{
		List<PseudoProcess> inputs = p.Inputs;
		for (int i = 0; i < inputs.Count; i++)
		{
			OrderInputs(inputs[i]);
		}
		if (inputs.Count <= 2)
		{
			return;
		}
		List<PseudoProcess> list = inputs.OrderByDescending((PseudoProcess x) => x.Inputs.Count).ToList();
		inputs.Clear();
		bool flag = false;
		for (int num = 0; num < list.Count; num++)
		{
			if (flag)
			{
				inputs.Insert(0, list[num]);
			}
			else
			{
				inputs.Add(list[num]);
			}
			flag = !flag;
		}
	}

	private PseudoProcess BuildTree(ComponentProcess process, IList<FeatureBase> features, IList<uint> factors, PseudoProcess parent)
	{
		bool num = process.Final || features == null || process.Output.Valid(features, factors);
		PseudoProcess pseudoProcess = parent;
		if (num)
		{
			pseudoProcess = new PseudoProcess(process, parent);
			_processes.Add(pseudoProcess);
			if (!pseudoProcess.Final)
			{
				_map[pseudoProcess.Component] = pseudoProcess;
			}
		}
		for (int i = 0; i < process.Inputs.Length; i++)
		{
			HardwareComponent hardwareComponent = process.Inputs[i];
			if (hardwareComponent.OutputProcess != null)
			{
				BuildTree(hardwareComponent.OutputProcess, features, factors, pseudoProcess);
			}
			else if (features == null || hardwareComponent.Valid(features, factors))
			{
				PseudoProcess pseudoProcess2 = new PseudoProcess(hardwareComponent, pseudoProcess);
				_processes.Add(pseudoProcess2);
				_map[pseudoProcess2.Component] = pseudoProcess2;
			}
		}
		return pseudoProcess;
	}

	public void CalculateLayoutInputHorizontal()
	{
	}

	public void CalculateLayoutInputVertical()
	{
	}

	private float GetWidth(int items)
	{
		return (float)items * Size.x + (float)Mathf.Max(0, items - 1) * Spacing.x + (float)Padding.horizontal;
	}

	private float GetHeight(int items)
	{
		return (float)items * Size.y + (float)Mathf.Max(0, items - 1) * (Spacing.y + _extraSpacing) + (float)Padding.vertical;
	}
}
