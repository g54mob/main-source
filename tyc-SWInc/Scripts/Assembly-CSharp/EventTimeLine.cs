using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EventTimeLine : MaskableGraphic, IScrollHandler, IEventSystemHandler
{
	public struct MarketEventData
	{
		public string Desc;

		public string Icon;

		public Color MColor;

		public Action MAction;

		public float YOffset;

		public float Height;

		public MarketEventData(string desc, MarketEvent ev)
		{
			Desc = desc;
			YOffset = 0f;
			Height = 0f;
			Icon = ev.GetIcon();
			MColor = ev.GetColor();
			MAction = ev.GetAction();
		}

		public MarketEventData(MarketEventData d, float yOffset, float height)
		{
			Desc = d.Desc;
			YOffset = yOffset;
			Height = height;
			Icon = d.Icon;
			MColor = d.MColor;
			MAction = d.MAction;
		}
	}

	public GameObject DatePrefab;

	public TimeLineLabel LabelPrefab;

	public GUIWindow Window;

	public Text LabelEx;

	public Scrollbar Scroll;

	public RectTransform FilterBar;

	public Toggle FilterPrefab;

	[NonSerialized]
	private List<ValueTuple<MarketEvent.Filter, Toggle>> _toggles = new List<ValueTuple<MarketEvent.Filter, Toggle>>();

	public Vector2 LabelMargins;

	public Vector2 DateLabelSize;

	public bool Interactable = true;

	public float LabelYPadding = 8f;

	public float LabelDateDistance = 8f;

	private float _fullHeight;

	[NonSerialized]
	private List<MarketEvent> _events = new List<MarketEvent>();

	private List<ValueTuple<SDateTime, List<MarketEventData>>> _data = new List<ValueTuple<SDateTime, List<MarketEventData>>>();

	private ObjectPool<GameObject> _datePool;

	private ObjectPool<TimeLineLabel> _labelPool;

	[NonSerialized]
	private bool _init;

	[NonSerialized]
	private bool _dirty;

	[NonSerialized]
	private SDateTime _shown;

	[NonSerialized]
	private Company _company;

	[NonSerialized]
	private MarketEvent.Filter _filter = MarketEvent.AllFilters;

	private List<ValueTuple<float, bool>> _yLines = new List<ValueTuple<float, bool>>();

	private float _labelWidth
	{
		get
		{
			return base.rectTransform.rect.width / 2f - DateLabelSize.x / 2f - LabelDateDistance;
		}
	}

	protected override void Start()
	{
		base.Start();
		if (Application.isPlaying)
		{
			Init();
		}
	}

	private void Init()
	{
		if (_init)
		{
			return;
		}
		_datePool = new ObjectPool<GameObject>(delegate
		{
			GameObject obj = UnityEngine.Object.Instantiate(DatePrefab);
			obj.transform.SetParent(base.transform, false);
			return obj;
		}, delegate(GameObject x)
		{
			x.SetActive(true);
		}, delegate(GameObject x)
		{
			x.SetActive(false);
		});
		_labelPool = new ObjectPool<TimeLineLabel>(delegate
		{
			TimeLineLabel timeLineLabel = UnityEngine.Object.Instantiate(LabelPrefab);
			timeLineLabel.transform.SetParent(base.transform, false);
			return timeLineLabel;
		}, delegate(TimeLineLabel x)
		{
			x.gameObject.SetActive(true);
		}, delegate(TimeLineLabel x)
		{
			x.gameObject.SetActive(false);
		});
		_init = true;
		foreach (MarketEvent.Filter item in from x in Enum.GetValues(typeof(MarketEvent.Filter)).OfType<MarketEvent.Filter>()
			where x != MarketEvent.Filter.None
			select x)
		{
			Toggle toggle = UnityEngine.Object.Instantiate(FilterPrefab);
			toggle.GetComponentInChildren<Text>().text = item.ToString().Loc();
			toggle.isOn = true;
			_toggles.Add(new ValueTuple<MarketEvent.Filter, Toggle>(item, toggle));
			toggle.onValueChanged.AddListener(delegate
			{
				UpdateFilter();
			});
			toggle.transform.SetParent(FilterBar, false);
		}
	}

	private void UpdateFilter()
	{
		_filter = MarketEvent.Filter.None;
		for (int i = 0; i < _toggles.Count; i++)
		{
			ValueTuple<MarketEvent.Filter, Toggle> valueTuple = _toggles[i];
			if (valueTuple.Item2.isOn)
			{
				_filter |= valueTuple.Item1;
			}
		}
		RefreshEvents();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Vector2 vector = Vector2.zero - base.rectTransform.pivot;
		Vector2 vector2 = Vector2.one - base.rectTransform.pivot;
		vector = new Vector2(vector.x * base.rectTransform.rect.width, vector.y * base.rectTransform.rect.height);
		vector2 = new Vector2(vector2.x * base.rectTransform.rect.width, vector2.y * base.rectTransform.rect.height);
		float x = (vector.x + vector2.x) / 2f;
		vh.DrawLine(new Vector2(x, vector.y), new Vector2(x, vector2.y), 4f, new Color32(50, 50, 50, byte.MaxValue));
		for (int i = 0; i < _yLines.Count; i++)
		{
			ValueTuple<float, bool> valueTuple = _yLines[i];
			vh.DrawLine(new Vector2(x, 0f - valueTuple.Item1), new Vector2(valueTuple.Item2 ? vector.x : vector2.x, 0f - valueTuple.Item1), 4f, new Color32(50, 50, 50, byte.MaxValue));
		}
	}

	public void RefreshEvents()
	{
		_data.Clear();
		MarketEvent.Filter filters = MarketEvent.Filter.None;
		foreach (IGrouping<ushort, MarketEvent> item in from x in _events
			group x by x.DateInt into x
			orderby x.Key
			select x)
		{
			List<MarketEventData> list = new List<MarketEventData>();
			foreach (MarketEvent item2 in item)
			{
				MarketEvent.Filter filter = item2.GetFilter();
				filters |= filter;
				if (_filter.HasFlag(filter))
				{
					string description = item2.GetDescription();
					if (description != null)
					{
						list.Add(new MarketEventData(description, item2));
					}
				}
			}
			if (list.Count > 0)
			{
				_data.Add(new ValueTuple<SDateTime, List<MarketEventData>>(MarketEvent.ConvertDate(item.Key), list));
			}
		}
		_toggles.ForEach(delegate(ValueTuple<MarketEvent.Filter, Toggle> x)
		{
			x.Item2.gameObject.SetActive(filters.HasFlag(x.Item1));
		});
		RefreshHeights();
	}

	public void RefreshHeights()
	{
		_fullHeight = 0f;
		SDateTime start = ((_data.Count == 0) ? default(SDateTime) : _data[0].Item1);
		for (int i = 0; i < _data.Count; i++)
		{
			ValueTuple<SDateTime, List<MarketEventData>> valueTuple = _data[i];
			int monthsFlat = SDateTime.GetMonthsFlat(start, valueTuple.Item1);
			if (monthsFlat > 1)
			{
				_fullHeight += (monthsFlat - 1) * 8;
			}
			float num = 0f;
			for (int j = 0; j < valueTuple.Item2.Count; j++)
			{
				MarketEventData d = valueTuple.Item2[j];
				TextGenerationSettings generationSettings = LabelEx.GetGenerationSettings(new Vector2(_labelWidth - LabelMargins.x - 25f - (float)((d.MAction != null) ? 25 : 0), 0f));
				float b = LabelEx.cachedTextGeneratorForLayout.GetPreferredHeight(d.Desc, generationSettings) / Options.UISize + LabelYPadding;
				b = Mathf.Max(26f, b);
				valueTuple.Item2[j] = new MarketEventData(d, _fullHeight, b);
				num += b + LabelMargins.y;
				_fullHeight += b + LabelMargins.y;
			}
			float num2 = DateLabelSize.y * 2f + 8f - num;
			if (num2 > 0f)
			{
				MarketEventData d2 = valueTuple.Item2[valueTuple.Item2.Count - 1];
				valueTuple.Item2[valueTuple.Item2.Count - 1] = new MarketEventData(d2, d2.YOffset, d2.Height + num2);
				_fullHeight += num2;
			}
			start = valueTuple.Item1;
		}
		RefreshScrollBar();
	}

	public void RefreshScrollBar()
	{
		Scroll.size = Mathf.Clamp01(base.rectTransform.rect.height / _fullHeight);
		RefreshContent();
	}

	protected override void OnRectTransformDimensionsChange()
	{
		if (Application.isPlaying)
		{
			_dirty = true;
		}
	}

	private void SetTextAndPos(GameObject o, string t, Rect pos, bool bold = false)
	{
		Text componentInChildren = o.GetComponentInChildren<Text>();
		componentInChildren.text = t;
		componentInChildren.fontStyle = (bold ? FontStyle.Bold : FontStyle.Normal);
		RectTransform component = o.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(pos.x, 0f - pos.y);
		component.sizeDelta = pos.size;
	}

	private void SetPos(GameObject o, Rect pos)
	{
		RectTransform component = o.GetComponent<RectTransform>();
		component.anchoredPosition = new Vector2(pos.x, 0f - pos.y);
		component.sizeDelta = pos.size;
	}

	public void RefreshContent()
	{
		_yLines.Clear();
		Init();
		_datePool.ReleaseAll();
		_labelPool.ReleaseAll();
		float num = (1f - Scroll.value) * Mathf.Max(0f, _fullHeight - base.rectTransform.rect.height);
		int num2 = -1;
		for (int i = 0; i < _data.Count; i++)
		{
			bool flag = false;
			ValueTuple<SDateTime, List<MarketEventData>> valueTuple = _data[i];
			bool flag2 = (i & 1) == 0;
			for (int j = 0; j < valueTuple.Item2.Count; j++)
			{
				MarketEventData data = valueTuple.Item2[j];
				if (data.YOffset >= num + base.rectTransform.rect.height)
				{
					break;
				}
				if (data.YOffset + data.Height > num)
				{
					float num3 = Mathf.Max(0f, data.YOffset - num);
					float num4 = 0f;
					if (num2 != valueTuple.Item1.Year)
					{
						SetTextAndPos(_datePool.Get(), (valueTuple.Item1.Year + 1900).ToString(), new Rect(base.rectTransform.rect.width / 2f - DateLabelSize.x / 2f, num3, DateLabelSize.x, DateLabelSize.y), true);
						num2 = valueTuple.Item1.Year;
						num3 += DateLabelSize.y + 2f;
						num4 += DateLabelSize.y + 2f;
					}
					if (!flag)
					{
						SetTextAndPos(_datePool.Get(), SDateTime.Months[valueTuple.Item1.Month].Loc(), new Rect(base.rectTransform.rect.width / 2f - DateLabelSize.x / 2f, num3, DateLabelSize.x, DateLabelSize.y));
						flag = true;
					}
					if (j == 0)
					{
						_yLines.Add(new ValueTuple<float, bool>(data.YOffset - num + DateLabelSize.y / 2f + num4, flag2));
					}
					TimeLineLabel timeLineLabel = _labelPool.Get();
					SetPos(timeLineLabel.gameObject, new Rect(flag2 ? 0f : (base.rectTransform.rect.width / 2f + DateLabelSize.x / 2f + LabelDateDistance), data.YOffset - num, _labelWidth, data.Height));
					timeLineLabel.Set(data, Interactable);
				}
			}
		}
		SetVerticesDirty();
		_dirty = false;
	}

	private void Update()
	{
		if (Application.isPlaying)
		{
			SDateTime sDateTime = SDateTime.Now();
			if (!_shown.Equals(sDateTime, true))
			{
				RefreshCompany();
				_shown = sDateTime;
			}
			if (_dirty)
			{
				RefreshHeights();
			}
		}
	}

	public void Show(Company c, bool modal = false, GUIWindow parent = null, bool interactable = true)
	{
		Interactable = interactable;
		Window.Modal = modal;
		if (modal && parent != null)
		{
			Window.SetParentWindow(parent);
		}
		if (c != _company)
		{
			_events.Clear();
			Window.Show();
			Scroll.value = 1f;
		}
		else if (Window.Shown)
		{
			if (!Window.ToggleReturn())
			{
				return;
			}
		}
		else
		{
			Window.Show();
		}
		_shown = SDateTime.Now();
		_company = c;
		Window.NonLocTitle = c.Name;
		RefreshCompany();
	}

	private void RefreshCompany()
	{
		_events.Clear();
		_events.AddRange(_company.MarketEvents);
		RefreshEvents();
	}

	public void OnScroll(PointerEventData eventData)
	{
		float num = _fullHeight - base.rectTransform.rect.height;
		if (num > 0f)
		{
			Scroll.value += eventData.scrollDelta.y / num * 32f;
		}
	}
}
