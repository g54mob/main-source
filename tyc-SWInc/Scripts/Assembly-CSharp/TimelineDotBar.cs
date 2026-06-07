using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimelineDotBar : MaskableGraphic, IPointerEnterHandler, IEventSystemHandler, IPointerDownHandler
{
	public float DataDensity = 16f;

	public float SliceMargin = 0.25f;

	public int ThemeColor = 3;

	public Sprite Texture;

	private float _dataSize = 1f;

	[NonSerialized]
	private List<MarketEvent> _events = new List<MarketEvent>();

	[NonSerialized]
	private int _start;

	[NonSerialized]
	private int _finish;

	[NonSerialized]
	private Dictionary<int, List<MarketEvent>> _data = new Dictionary<int, List<MarketEvent>>();

	[NonSerialized]
	private bool _toolTip;

	[NonSerialized]
	private int _lastTip = -1;

	[NonSerialized]
	private MarketEvent.Filter _timelineFilter = MarketEvent.AllFilters;

	public override Texture mainTexture
	{
		get
		{
			if (!(Texture != null))
			{
				return base.mainTexture;
			}
			return Texture.texture;
		}
	}

	public void SetEvents(IEnumerable<MarketEvent> events, SDateTime start, SDateTime finish)
	{
		_events.Clear();
		_events.AddRange(events);
		_start = MarketEvent.ConvertDate(start);
		_finish = MarketEvent.ConvertDate(finish);
		RefreshData();
	}

	private void RefreshData()
	{
		_data.Clear();
		int num = Mathf.Min(_finish - _start - 1, Mathf.FloorToInt(base.rectTransform.rect.width / DataDensity));
		if (num <= 0)
		{
			SetVerticesDirty();
			return;
		}
		_dataSize = base.rectTransform.rect.width / (float)num;
		float num2 = _finish - _start - 1;
		foreach (MarketEvent item in from x in _events
			where x.CheckFilter(_timelineFilter)
			orderby x.DateInt
			select x)
		{
			if (item.DateInt >= _start)
			{
				if (item.DateInt >= _finish - 1)
				{
					break;
				}
				int key = Mathf.FloorToInt((float)(item.DateInt - _start) / num2 * (float)num);
				_data.Append(key, item);
			}
		}
		SetVerticesDirty();
	}

	protected override void OnRectTransformDimensionsChange()
	{
		RefreshData();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		Vector2 vector = Vector2.zero - base.rectTransform.pivot;
		Vector2 vector2 = Vector2.one - base.rectTransform.pivot;
		vector = new Vector2(vector.x * base.rectTransform.rect.width, vector.y * base.rectTransform.rect.height);
		vector2 = new Vector2(vector2.x * base.rectTransform.rect.width, vector2.y * base.rectTransform.rect.height);
		if (Application.isPlaying)
		{
			bool flag = true;
			int num = 0;
			{
				foreach (KeyValuePair<int, List<MarketEvent>> datum in _data)
				{
					bool flag2 = ++num == _data.Count;
					float num2 = vector.x + (float)datum.Key * _dataSize;
					DrawRect(new Vector2(num2 + (float)((!flag) ? 1 : 0), vector.y), new Vector2(num2 + _dataSize - (float)((!flag2) ? 1 : 0), vector2.y), datum.Value[0].GetColor(), vh);
					flag = false;
				}
				return;
			}
		}
		int num3 = Mathf.FloorToInt(base.rectTransform.rect.width / DataDensity);
		float num4 = base.rectTransform.rect.width / (float)num3;
		for (int i = 0; i < num3; i++)
		{
			float num5 = vector.x + (float)i * num4;
			DrawRect(new Vector2(num5, vector.y), new Vector2(num5 + num4 - 1f, vector2.y), HUD.GetThemeColor(ThemeColor), vh);
		}
	}

	public void DrawRect(Vector2 p1, Vector2 p2, Color col, VertexHelper vh)
	{
		if (p2.x - p1.x > DataDensity * 2f)
		{
			float num = DataDensity * SliceMargin;
			float x = 1f - SliceMargin;
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					color = col,
					position = new Vector3(p1.x, p1.y, 0f),
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p1.x + num, p1.y, 0f),
					uv0 = new Vector2(SliceMargin, 0f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p1.x + num, p2.y, 0f),
					uv0 = new Vector2(SliceMargin, 1f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p1.x, p2.y, 0f),
					uv0 = new Vector2(0f, 1f)
				}
			});
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					color = col,
					position = new Vector3(p1.x + num, p1.y, 0f),
					uv0 = new Vector2(SliceMargin, 0f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p2.x - num, p1.y, 0f),
					uv0 = new Vector2(x, 0f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p2.x - num, p2.y, 0f),
					uv0 = new Vector2(x, 1f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p1.x + num, p2.y, 0f),
					uv0 = new Vector2(SliceMargin, 1f)
				}
			});
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					color = col,
					position = new Vector3(p2.x - num, p1.y, 0f),
					uv0 = new Vector2(x, 0f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p2.x, p1.y, 0f),
					uv0 = new Vector2(1f, 0f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p2.x, p2.y, 0f),
					uv0 = new Vector2(1f, 1f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p2.x - num, p2.y, 0f),
					uv0 = new Vector2(x, 1f)
				}
			});
		}
		else
		{
			vh.AddUIVertexQuad(new UIVertex[4]
			{
				new UIVertex
				{
					color = col,
					position = new Vector3(p1.x, p1.y, 0f),
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p2.x, p1.y, 0f),
					uv0 = new Vector2(1f, 0f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p2.x, p2.y, 0f),
					uv0 = new Vector2(1f, 1f)
				},
				new UIVertex
				{
					color = col,
					position = new Vector3(p1.x, p2.y, 0f),
					uv0 = new Vector2(0f, 1f)
				}
			});
		}
	}

	private void Update()
	{
		if (!Application.isPlaying || !_toolTip)
		{
			return;
		}
		if (Tooltip.IsShowing && Tooltip.CurrentRect != base.rectTransform)
		{
			_toolTip = false;
			_lastTip = -1;
			return;
		}
		if (_data.Count == 0 || !RectTransformUtility.RectangleContainsScreenPoint(base.rectTransform, Input.mousePosition, UICamSize.GetUICam()))
		{
			_toolTip = false;
			_lastTip = -1;
			Tooltip.Hide();
			return;
		}
		Vector2 localPoint;
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, Input.mousePosition, UICamSize.GetUICam(), out localPoint);
		int num = Mathf.FloorToInt((localPoint.x + base.rectTransform.pivot.x * base.rectTransform.rect.width) / _dataSize);
		if (num != _lastTip)
		{
			_lastTip = num;
			List<MarketEvent> value;
			if (_data.TryGetValue(num, out value))
			{
				StringBuilder stringBuilder = new StringBuilder();
				int num2 = -1;
				foreach (MarketEvent item in value)
				{
					string description = item.GetDescription();
					if (description != null)
					{
						if (item.DateInt != num2)
						{
							num2 = item.DateInt;
							stringBuilder.AppendLine(item.Date.ToCompactString().FontBold());
						}
						stringBuilder.AppendLine(" -" + description);
					}
				}
				Tooltip.SetToolTip(null, stringBuilder.ToString().TrimEnd(), base.rectTransform);
			}
			else
			{
				Tooltip.Hide();
			}
		}
		List<MarketEvent> value2;
		if (!Input.GetMouseButtonDown(0) || !_data.TryGetValue(num, out value2))
		{
			return;
		}
		foreach (MarketEvent item2 in value2)
		{
			Action action = item2.GetAction();
			if (action != null)
			{
				action();
				break;
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (_data.Count > 0)
		{
			_toolTip = true;
			_lastTip = -1;
			Tooltip.SetToolTip(null, " ", base.rectTransform);
		}
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		if (eventData.button != PointerEventData.InputButton.Right)
		{
			return;
		}
		MarketEvent.Filter[] filters = (from x in Enum.GetValues(typeof(MarketEvent.Filter)).OfType<MarketEvent.Filter>()
			where x != MarketEvent.Filter.None
			select x).ToArray();
		bool[] selected = filters.SelectInPlace((MarketEvent.Filter x) => _timelineFilter.HasFlag(x));
		WindowManager.Instance.MultiWindow.ShowMulti("Filter".Loc(), filters.Select((MarketEvent.Filter x) => x.ToString().Loc()), selected, delegate(int[] xs)
		{
			_timelineFilter = MarketEvent.Filter.None;
			for (int i = 0; i < xs.Length; i++)
			{
				_timelineFilter |= filters[xs[i]];
			}
			RefreshData();
		});
	}
}
