using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIColumn : MonoBehaviour
{
	public enum ColumnType
	{
		Label = 0,
		Action = 1,
		Slider = 2,
		Stars = 3,
		Role = 4,
		WarningIcon = 5,
		Color = 6,
		Toggle = 7,
		Trait = 8,
		Logo = 9,
		PlusMinus = 10,
		ProgressBar = 11,
		Stars5 = 12
	}

	[Flags]
	public enum TotalType
	{
		None = 0,
		Sum = 1,
		MathMean = 2,
		Median = 4,
		Minimum = 8,
		Maximum = 0x10,
		Range = 0x20,
		All = 0x3F,
		Averages = 6,
		NoSum = 0x3E,
		NoRange = 0x1F,
		Ranges = 0x38
	}

	public ColumnType Type;

	public GameObject[] ItemPrefab;

	public GUIListView Parent;

	public GameObject ContentPanel;

	public RectTransform SortIcon;

	public Action<object> Action;

	public Action<object, object> SetVariable;

	public Func<object, object> Label;

	public Comparison<object> Comparison;

	public Func<object, object> GetFilterValue;

	[NonSerialized]
	public Func<object, double> Total;

	[NonSerialized]
	public Func<double, object> TotalLabel;

	[NonSerialized]
	public TotalType TotalFunc;

	[NonSerialized]
	public TotalType TotalValid;

	public GUIListView.FilterType Filter;

	public bool FilterActive;

	public double[] FilterNumber = new double[2];

	public HashSet<string> FilterName = new HashSet<string>();

	public InputField FilterQuery;

	public int FilterMask = int.MaxValue;

	[NonSerialized]
	public Employee.Trait TraitMask;

	[NonSerialized]
	public bool RequireAllTraits;

	public bool FilterBool;

	public List<GUIListItem> Items = new List<GUIListItem>();

	public Text Header;

	public string HeaderValue;

	public bool SortAsc;

	public bool ContinuallyUpdate;

	public bool ForceFilter;

	public bool PlayerDisabled;

	public bool GameDisabled;

	public float mouseX;

	public float initWidth;

	public RectTransform rectTransform;

	public LayoutElement layoutElement;

	[NonSerialized]
	private bool _isDragging;

	[NonSerialized]
	private bool _isMoving;

	private float lastHeaderClick;

	public Image FilterIcon;

	public Image PanelImage;

	public Color DefaultPanelColor;

	public Color FilteredPanelColor;

	public GUIToolTipper TipPanel;

	public bool TotalDirty = true;

	public bool ReverseHide;

	[NonSerialized]
	private object _totalCached;

	private static List<ValueTuple<int, float>> _columnX = new List<ValueTuple<int, float>>();

	[NonSerialized]
	private int _updateOffset;

	public void LoadActiveState()
	{
		if (!GameSettings.Instance.IsReferenceNull())
		{
			PlayerDisabled = GameSettings.Instance.ColumnsDisabled.Contains(Parent.SpecialID + base.name) ^ ReverseHide;
		}
		base.gameObject.SetActive(!GameDisabled && !PlayerDisabled);
	}

	public void ToggleActive(bool player, bool active)
	{
		if (!GameSettings.Instance.IsReferenceNull() && player)
		{
			if (active ^ ReverseHide)
			{
				GameSettings.Instance.ColumnsDisabled.Remove(Parent.SpecialID + base.name);
			}
			else
			{
				GameSettings.Instance.ColumnsDisabled.Add(Parent.SpecialID + base.name);
			}
		}
		if (!GameSettings.Instance.IsReferenceNull() && !player && !PlayerDisabled && (GameSettings.Instance.ColumnsDisabled.Contains(Parent.SpecialID + base.name) ^ ReverseHide))
		{
			PlayerDisabled = true;
		}
		if (active && player && GameDisabled)
		{
			PlayerDisabled = false;
			return;
		}
		if (active && !player && PlayerDisabled)
		{
			GameDisabled = false;
			return;
		}
		if (!active)
		{
			PlayerDisabled |= player;
			GameDisabled |= !player;
		}
		else
		{
			GameDisabled = false;
			PlayerDisabled = false;
		}
		base.gameObject.SetActive(active);
	}

	public void BeginMove()
	{
		_columnX.Clear();
		float num = 0f;
		foreach (GUIColumn item in Parent.GUIColumns.OrderBy((GUIColumn x) => x.transform.GetSiblingIndex()))
		{
			if (item.gameObject.activeSelf)
			{
				_columnX.Add(new ValueTuple<int, float>(item.transform.GetSiblingIndex(), num));
				num += item.rectTransform.sizeDelta.x;
			}
		}
		if (_columnX.Count > 1)
		{
			_isMoving = true;
		}
	}

	public void PickTotalType()
	{
		List<TotalType> flags = TotalValid.GetFlagSplit((TotalType x, TotalType y) => y != TotalType.None && y != TotalType.All && y != TotalType.NoSum && y != TotalType.Averages && y != TotalType.NoRange && y != TotalType.Ranges && x.HasFlag(y));
		if (flags.Count > 1)
		{
			WindowManager.Instance.MultiWindow.Show("", flags.Select((TotalType x) => x.ToString().Loc()), delegate(int i)
			{
				TotalFunc = flags[i];
				TotalDirty = true;
				UpdateElements();
			}, false);
		}
	}

	public void CalculateTotal()
	{
		switch (TotalFunc)
		{
		case TotalType.Sum:
			_totalCached = TotalLabel(Parent.ActualItems.SumSafe(delegate(object x)
			{
				double num12 = Total(x);
				return (!double.IsNaN(num12)) ? num12 : 0.0;
			}));
			break;
		case TotalType.MathMean:
		{
			double num8 = 0.0;
			int num9 = 0;
			for (int num10 = 0; num10 < Parent.ActualItems.Count; num10++)
			{
				double num11 = Total(Parent.ActualItems[num10]);
				if (!double.IsNaN(num11))
				{
					num8 += num11;
					num9++;
				}
			}
			_totalCached = TotalLabel((num9 == 0) ? 0.0 : (num8 / (double)num9));
			break;
		}
		case TotalType.Median:
			_totalCached = TotalLabel(Parent.ActualItems.Median((object x) => Total(x)));
			break;
		case TotalType.Minimum:
		{
			double num4 = double.PositiveInfinity;
			bool flag2 = false;
			for (int j = 0; j < Parent.ActualItems.Count; j++)
			{
				double num5 = Total(Parent.ActualItems[j]);
				if (!double.IsNaN(num5))
				{
					num4 = Math.Min(num4, num5);
					flag2 = true;
				}
			}
			_totalCached = (flag2 ? TotalLabel(num4) : TotalLabel(0.0));
			break;
		}
		case TotalType.Maximum:
		{
			double num6 = double.NegativeInfinity;
			bool flag3 = false;
			for (int k = 0; k < Parent.ActualItems.Count; k++)
			{
				double num7 = Total(Parent.ActualItems[k]);
				if (!double.IsNaN(num7))
				{
					num6 = Math.Max(num6, num7);
					flag3 = true;
				}
			}
			_totalCached = (flag3 ? TotalLabel(num6) : TotalLabel(0.0));
			break;
		}
		case TotalType.Range:
		{
			bool flag = false;
			double num = double.PositiveInfinity;
			double num2 = double.NegativeInfinity;
			for (int i = 0; i < Parent.ActualItems.Count; i++)
			{
				double num3 = Total(Parent.ActualItems[i]);
				if (!double.IsNaN(num3))
				{
					num = Math.Min(num, num3);
					num2 = Math.Max(num2, num3);
					flag = true;
				}
			}
			if (flag)
			{
				object obj = TotalLabel(num2);
				object obj2 = TotalLabel(num);
				if (obj.Equals(obj2))
				{
					_totalCached = obj;
				}
				else
				{
					_totalCached = string.Concat(obj2, " - ", obj);
				}
			}
			else
			{
				_totalCached = TotalLabel(0.0);
			}
			break;
		}
		}
	}

	public void UpdateElements()
	{
		if ((Parent.CreatedInGame && GameSettings.Instance.IsReferenceNull()) || Parent == null)
		{
			return;
		}
		if (!Utilities.Overlap(rectTransform.anchoredPosition.x, rectTransform.anchoredPosition.x + rectTransform.sizeDelta.x, 0f - Parent.ContentRect.anchoredPosition.x, 0f - Parent.ContentRect.anchoredPosition.x + Parent.rectTransform.rect.width))
		{
			ContentPanel.SetActive(false);
			return;
		}
		ContentPanel.SetActive(true);
		int num = Mathf.Min(Parent.ActualItems.Count + 1, Mathf.FloorToInt(base.transform.parent.GetComponent<RectTransform>().rect.height / 24f));
		if (Items.Count < num)
		{
			int num2 = num - Items.Count;
			for (int i = 0; i < num2; i++)
			{
				ColumnType columnType = Type;
				if (columnType == ColumnType.Stars5)
				{
					columnType = ColumnType.Stars;
				}
				GameObject obj = UnityEngine.Object.Instantiate(ItemPrefab[(int)columnType]);
				GUIListItem component = obj.GetComponent<GUIListItem>();
				component.Odd = Items.Count % 2 == 1;
				component.Parent = this;
				component.Idx = Items.Count;
				obj.transform.SetParent(ContentPanel.transform, false);
				Items.Add(component);
				if (Type == ColumnType.Action)
				{
					component.SetValue(Parent.IgnoreTranslation ? HeaderValue.LocDef(HeaderValue) : HeaderValue.LocNoColor());
				}
				else if (Type == ColumnType.Toggle)
				{
					component.GetComponent<GUIToolTipper>().ToolTipValue = HeaderValue;
				}
			}
		}
		for (int j = 0; j < Items.Count; j++)
		{
			int num3 = j + Parent.Scroll;
			if (num3 > -1 && j < num && num3 <= Parent.ActualItems.Count)
			{
				if (num3 < Parent.ActualItems.Count)
				{
					if (Type != ColumnType.Action)
					{
						Items[j].SetValue(Label(Parent.ActualItems[num3]));
					}
					if (!Items[j].gameObject.activeSelf)
					{
						Items[j].gameObject.SetActive(true);
					}
				}
				else if (Total != null && Parent.ActualItems.Count > 1)
				{
					UpdateTotalValue(Items[j]);
					if (!Items[j].gameObject.activeSelf)
					{
						Items[j].gameObject.SetActive(true);
					}
				}
				else
				{
					Items[j].gameObject.SetActive(false);
				}
			}
			else if (Items[j].gameObject.activeSelf)
			{
				Items[j].gameObject.SetActive(false);
			}
		}
	}

	private void UpdateTotalValue(GUIListItem item)
	{
		if (TotalDirty || _totalCached == null)
		{
			TotalDirty = false;
			CalculateTotal();
		}
		item.SetValue(_totalCached);
	}

	public void UpdateSelected()
	{
		switch (Type)
		{
		case ColumnType.Label:
		case ColumnType.Stars:
		case ColumnType.Role:
		case ColumnType.WarningIcon:
		case ColumnType.Trait:
		case ColumnType.Logo:
		case ColumnType.PlusMinus:
		case ColumnType.Stars5:
		{
			for (int i = 0; i < Items.Count; i++)
			{
				if (i + Parent.Scroll == Parent.ActualItems.Count)
				{
					Items[i].Highlight(true, true);
				}
				else
				{
					Items[i].Highlight(Parent.Selected.Contains(i + Parent.Scroll));
				}
			}
			break;
		}
		case ColumnType.Action:
		case ColumnType.Slider:
		case ColumnType.Color:
		case ColumnType.Toggle:
		case ColumnType.ProgressBar:
			break;
		}
	}

	public void HeaderPressed(BaseEventData e)
	{
		if (_isMoving)
		{
			return;
		}
		if (((PointerEventData)e).button == PointerEventData.InputButton.Right)
		{
			GUIColumn[] columns = Parent.GUIColumns.Where((GUIColumn x) => !x.GameDisabled).ToArray();
			WindowManager.Instance.MultiWindow.ShowMulti("", columns.Select((GUIColumn x) => (!Parent.IgnoreTranslation) ? x.HeaderValue.LocNoColor() : x.HeaderValue.LocDef(x.HeaderValue)), columns.SelectInPlace((GUIColumn x) => x.gameObject.activeSelf), delegate(int[] xs)
			{
				if (xs.Length != 0)
				{
					HashSet<int> hashSet = xs.ToHashSet();
					for (int i = 0; i < columns.Length; i++)
					{
						columns[i].ToggleActive(true, hashSet.Contains(i));
					}
				}
			});
		}
		else
		{
			switch (Type)
			{
			case ColumnType.Label:
			case ColumnType.Slider:
			case ColumnType.Stars:
			case ColumnType.Role:
			case ColumnType.WarningIcon:
			case ColumnType.Color:
			case ColumnType.Trait:
			case ColumnType.PlusMinus:
			case ColumnType.ProgressBar:
			case ColumnType.Stars5:
				Parent.LastSort = this;
				ListViewFocus.ActiveListView = Parent;
				Sort(SortAsc);
				break;
			case ColumnType.Action:
			case ColumnType.Toggle:
			case ColumnType.Logo:
				break;
			}
		}
	}

	public void SetSort(bool en, bool asc)
	{
		SortIcon.gameObject.SetActive(en);
		if (en)
		{
			SortIcon.rotation = Quaternion.Euler(0f, 0f, asc ? (-90) : 90);
		}
	}

	public void Sort(bool asc, bool update = true)
	{
		List<object> l = Parent.Selected.WhereSelect((int x) => x < Parent.ActualItems.Count, (int i) => Parent.ActualItems[i]).ToList();
		Parent.ResetSortHeaders();
		SetSort(true, asc);
		List<KeyValuePair<int, object>> list = Parent.ActualItems.Select((object x, int i) => new KeyValuePair<int, object>(i, x)).ToList();
		list.Sort(delegate(KeyValuePair<int, object> x, KeyValuePair<int, object> y)
		{
			int num2 = (asc ? Comparison(x.Value, y.Value) : Comparison(y.Value, x.Value));
			return (num2 == 0) ? x.Key.CompareTo(y.Key) : num2;
		});
		for (int num = 0; num < list.Count; num++)
		{
			Parent.ActualItems[num] = list[num].Value;
		}
		SortAsc = !asc;
		Action onChange = Parent.Selected.OnChange;
		Parent.Selected.OnChange = null;
		Parent.Selected.Clear();
		Parent.Selected.AddRange(from x in l
			select Parent.ActualItems.IndexOf(x) into x
			where x > -1
			select x);
		Parent.Selected.OnChange = onChange;
		if (update)
		{
			Parent.UpdateElements(false);
		}
	}

	public void OnHoverAction(int i, GUIListItem caller)
	{
		if (Parent.Scroll + i >= Parent.ActualItems.Count && Total != null)
		{
			Tooltip.SetToolTip(TotalFunc.ToString().Loc(), null, caller.GetComponent<RectTransform>());
		}
	}

	public void OnClickAction(int i)
	{
		if (Parent.Scroll + i >= Parent.ActualItems.Count)
		{
			if (Total != null)
			{
				PickTotalType();
			}
			return;
		}
		switch (Type)
		{
		case ColumnType.Label:
		case ColumnType.Stars:
		case ColumnType.Role:
		case ColumnType.WarningIcon:
		case ColumnType.Color:
		case ColumnType.Trait:
		case ColumnType.Logo:
		case ColumnType.PlusMinus:
		case ColumnType.ProgressBar:
		case ColumnType.Stars5:
			Parent.LastSelectDirect = true;
			ListViewFocus.ActiveListView = Parent;
			Parent.Select(Parent.Scroll + i);
			break;
		case ColumnType.Action:
		{
			int num = Parent.Scroll + i;
			if (num < Parent.ActualItems.Count)
			{
				Action(Parent.ActualItems[num]);
			}
			break;
		}
		case ColumnType.Slider:
		case ColumnType.Toggle:
			break;
		}
	}

	public void BeginDrag()
	{
		if (Time.realtimeSinceStartup - lastHeaderClick < 0.5f)
		{
			if (Items.Any())
			{
				float preferredWidth = Items.Max((GUIListItem x) => x.PreferredWidth) + 12f;
				layoutElement.preferredWidth = preferredWidth;
				Options.AddColumnWidth(Parent.SpecialID + base.name, layoutElement.preferredWidth);
			}
		}
		else
		{
			initWidth = rectTransform.rect.width;
			mouseX = Input.mousePosition.x / Options.UISize;
			_isDragging = true;
		}
		lastHeaderClick = Time.realtimeSinceStartup;
	}

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		layoutElement = GetComponent<LayoutElement>();
	}

	private void OnEnable()
	{
		if (Parent != null)
		{
			Parent.ColumnConfDirty = 2;
		}
	}

	private void OnDisable()
	{
		if (Parent != null)
		{
			Parent.ColumnConfDirty = 2;
		}
	}

	private void FixedUpdate()
	{
		if ((Parent.CreatedInGame && GameSettings.Instance.IsReferenceNull()) || Type == ColumnType.Action || !ContinuallyUpdate)
		{
			return;
		}
		bool flag = TotalDirty && Total != null && Parent.ActualItems.Count > 1;
		int num = Mathf.Min(Items.Count, Parent.ActualItems.Count - Parent.Scroll + (flag ? 1 : 0));
		if (num <= 0)
		{
			return;
		}
		_updateOffset = (_updateOffset + 1) % num;
		int num2 = Utilities.MapToShuffledIndex(_updateOffset, num);
		if (num2 + Parent.Scroll >= Parent.ActualItems.Count)
		{
			if (TotalDirty)
			{
				UpdateTotalValue(Items[num2]);
			}
		}
		else
		{
			Items[num2].SetValue(Label(Parent.ActualItems[num2 + Parent.Scroll]));
		}
	}

	private void Update()
	{
		if (_isDragging)
		{
			layoutElement.preferredWidth = Mathf.Max(8f, initWidth + Input.mousePosition.x / Options.UISize - mouseX);
			if (Input.GetMouseButtonUp(0))
			{
				_isDragging = false;
				Options.AddColumnWidth(Parent.SpecialID + base.name, layoutElement.preferredWidth);
			}
		}
		if (!_isMoving)
		{
			return;
		}
		RectTransform component = base.transform.parent.GetComponent<RectTransform>();
		Vector2 localPoint;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(component, Input.mousePosition, UICamSize.GetUICam(), out localPoint))
		{
			float num = localPoint.x + component.rect.width * component.pivot.x;
			int index = _columnX.Count - 1;
			for (int i = 0; i < _columnX.Count; i++)
			{
				if (num < _columnX[i].Item2)
				{
					index = Mathf.Max(0, i - 1);
					break;
				}
			}
			base.transform.SetSiblingIndex(_columnX[index].Item1);
		}
		if (Input.GetMouseButtonUp(0))
		{
			_isMoving = false;
			Parent.SaveColumnOrder();
		}
	}

	public void ActivateFilter()
	{
		if (!FilterActive)
		{
			FilterActive = true;
			FilterIcon.color = new Color32(62, 212, 82, byte.MaxValue);
			Parent.UpdateActiveList();
			PanelImage.color = FilteredPanelColor;
		}
	}

	public void DeactivateFilter()
	{
		if (FilterActive)
		{
			FilterActive = false;
			FilterIcon.color = Color.black;
			Parent.UpdateActiveList();
			PanelImage.color = DefaultPanelColor;
			if (Filter == GUIListView.FilterType.Query)
			{
				FilterQuery.text = "";
				FilterQuery.gameObject.SetActive(false);
			}
		}
	}

	private void SetParent(GUIWindow w)
	{
		GUIWindow gUIWindow = Parent.FindParentWindow();
		if (gUIWindow != null)
		{
			w.SetParentWindow(gUIWindow);
		}
	}

	public void ToggleFilter()
	{
		if (!FilterActive)
		{
			switch (Filter)
			{
			case GUIListView.FilterType.Bool:
				WindowManager.Instance.MultiWindow.Show("", new string[2]
				{
					"Yes".Loc(),
					"No".Loc()
				}, delegate(int sel)
				{
					FilterBool = sel == 0;
					ActivateFilter();
				}, false);
				SetParent(WindowManager.Instance.MultiWindow.Window);
				break;
			case GUIListView.FilterType.Date:
			{
				List<int> list = Parent.ActualItems.Select((object x) => ((SDateTime)((GetFilterValue == null) ? x : GetFilterValue(x))).ToInt()).ToList();
				int d = list.MinSafeInt((int x) => x);
				int d2 = list.MaxSafeInt((int x) => x);
				HUD.Instance.dateRangeWindow.Show(SDateTime.FromInt(d), SDateTime.FromInt(d2), delegate(SDateTime f, SDateTime t)
				{
					FilterNumber[0] = f.ToInt();
					FilterNumber[1] = (float)t.ToInt() + 1439f;
					ActivateFilter();
				});
				SetParent(HUD.Instance.dateRangeWindow.Window);
				break;
			}
			case GUIListView.FilterType.Number:
				if (Parent.ActualItems.Count > 0)
				{
					List<double> source = ((!(((GetFilterValue == null) ? Parent.ActualItems[0] : GetFilterValue(Parent.ActualItems[0])) is float)) ? Parent.ActualItems.Select((object x) => (double)((GetFilterValue == null) ? x : GetFilterValue(x))).ToList() : ((IList<object>)Parent.ActualItems).Select((Func<object, double>)((object x) => (float)((GetFilterValue == null) ? x : GetFilterValue(x)))).ToList());
					double num = source.Min((double x) => x);
					double to = source.Max((double x) => x);
					HUD.Instance.numberRangeWindow.Show(num, to, delegate(double f, double t)
					{
						FilterNumber[0] = f;
						FilterNumber[1] = t;
						ActivateFilter();
					});
					SetParent(HUD.Instance.numberRangeWindow.Window);
				}
				break;
			case GUIListView.FilterType.Name:
			{
				Dictionary<string, uint> dictionary2 = new Dictionary<string, uint>();
				foreach (object actualItem in Parent.ActualItems)
				{
					string key = ((GetFilterValue == null) ? Label(actualItem) : GetFilterValue(actualItem)).ToString();
					dictionary2.AddUp(key, 1u);
				}
				List<KeyValuePair<string, uint>> names2 = dictionary2.OrderBy((KeyValuePair<string, uint> x) => x.Key).ToList();
				if (names2.Count <= 1)
				{
					break;
				}
				WindowManager.Instance.MultiWindow.ShowMulti("", names2.Select((KeyValuePair<string, uint> x) => x.Key + "(" + x.Value + ")"), null, delegate(int[] sel)
				{
					if (sel.Length != 0)
					{
						FilterName = sel.Select((int x) => names2[x].Key).ToHashSet();
						ActivateFilter();
					}
				});
				SetParent(WindowManager.Instance.MultiWindow.Window);
				break;
			}
			case GUIListView.FilterType.Bitmask:
			{
				object obj = Parent.ActualItems.FirstOrDefault();
				if (obj == null)
				{
					break;
				}
				string[] values = (from object x in Enum.GetValues(GetFilterValue(obj).GetType())
					where (int)x > 0 && Mathf.IsPowerOfTwo((int)x)
					orderby (int)x
					select x.ToString().Loc()).ToArray();
				WindowManager.Instance.MultiWindow.ShowMulti("", values, null, delegate(int[] sel)
				{
					if (sel.Length != 0)
					{
						int num2 = 0;
						foreach (int num3 in sel)
						{
							num2 |= Mathf.RoundToInt(Mathf.Pow(2f, num3));
						}
						FilterMask = num2;
						ActivateFilter();
					}
				});
				SetParent(WindowManager.Instance.MultiWindow.Window);
				break;
			}
			case GUIListView.FilterType.Trait:
				HUD.Instance.traitFilterWindow.Show(Employee.Trait.None, delegate(Employee.Trait sel, bool all)
				{
					if (sel != Employee.Trait.None)
					{
						TraitMask = sel;
						RequireAllTraits = all;
						ActivateFilter();
					}
				});
				SetParent(HUD.Instance.traitFilterWindow.Window);
				break;
			case GUIListView.FilterType.Query:
				FilterQuery.gameObject.SetActive(true);
				FilterQuery.ActivateInputField();
				ActivateFilter();
				break;
			case GUIListView.FilterType.RoomGroup:
			{
				Dictionary<string, uint> nameDict = new Dictionary<string, uint>();
				Dictionary<string, string> dictionary = new Dictionary<string, string>();
				foreach (string roomGroup2 in GameSettings.Instance.GetRoomGroups(true))
				{
					RoomGroup roomGroup = GameSettings.Instance.GetRoomGroup(roomGroup2);
					dictionary[roomGroup2] = roomGroup.Name;
					nameDict[roomGroup2] = 0u;
				}
				foreach (object actualItem2 in Parent.ActualItems)
				{
					Actor actor;
					if ((object)(actor = actualItem2 as Actor) == null)
					{
						continue;
					}
					foreach (string assignedRoomGroup in actor.AssignedRoomGroups)
					{
						nameDict.AddUp(assignedRoomGroup, 1u);
					}
				}
				List<ValueTuple<string, string, uint>> names = (from x in dictionary
					orderby x.Value
					select new ValueTuple<string, string, uint>(x.Key, x.Value, nameDict[x.Key])).ToList();
				if (names.Count <= 1)
				{
					break;
				}
				WindowManager.Instance.MultiWindow.ShowMulti("", names.Select(([TupleElementNames(new string[] { "Key", "Value", null })] ValueTuple<string, string, uint> x) => x.Item2 + "(" + x.Item3 + ")"), null, delegate(int[] sel)
				{
					if (sel.Length != 0)
					{
						FilterName = sel.Select((int x) => names[x].Item1).ToHashSet();
						ActivateFilter();
					}
				});
				SetParent(WindowManager.Instance.MultiWindow.Window);
				break;
			}
			}
		}
		else
		{
			DeactivateFilter();
		}
	}

	public void RefreshQuery()
	{
		Parent.NextRefresh = 0f;
	}

	public void SetValue(int i, object value)
	{
		int num = Parent.Scroll + i;
		if (num >= 0 && num < Parent.ActualItems.Count)
		{
			SetVariable(Parent.ActualItems[num], value);
			if (i >= 0 && i < Items.Count && num < Parent.ActualItems.Count)
			{
				Items[i].SetValue(Label(Parent.ActualItems[num]));
			}
		}
	}
}
