using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FishNet.Managing.Statistic;
using Jundroo.Juicy;
using Jundroo.Juicy.Widgets;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Assets.Scripts.Multiplayer.Utils
{
	public class NetworkProfilerWindow : WidgetScript
	{
		private Color _backgroundColor = new Color(0.1f, 0.1f, 0.1f);

		private RawImage _graphImage;

		private Texture2D _graphTexture;

		private Color _gridColor = new Color(0.3f, 0.3f, 0.3f);

		private NetworkEventHistory _history;

		private Color _inboundColor;

		private Color _outboundColor;

		private Color32[] _pixels32;

		private List<Widget> _rows = new List<Widget>();

		private int _selectedFrameIndex = -1;

		[SerializeField]
		private Color _selectionColor = Color.white;

		public bool IsPaused
		{
			get
			{
				return _history.IsPaused;
			}
			set
			{
				if (!value)
				{
					_selectedFrameIndex = -1;
					UpdateDetailText();
				}
				_history.SetPaused(value);
			}
		}

		public int SearchResultsBytes { get; private set; }

		public int SearchResultsFrames { get; private set; }

		public int SearchResultsMessages { get; private set; }

		public string SearchText { get; set; }

		public int SelectedFrameIndex => _selectedFrameIndex;

		public void AdvanceFrame(int direction)
		{
			IsPaused = true;
			if (_history == null || _history.History.Count == 0)
			{
				return;
			}
			int count = _history.History.Count;
			int selectedFrameIndex = _selectedFrameIndex;
			selectedFrameIndex = ((selectedFrameIndex != -1) ? (selectedFrameIndex + direction) : ((direction <= 0) ? (count - 1) : 0));
			for (int i = 0; i < count; i++)
			{
				int num = (selectedFrameIndex + i * direction + count) % count;
				if (IsMatch(_history.History[num], SearchText))
				{
					SelectFrameIndex(num);
					break;
				}
			}
		}

		public void ClearHistory()
		{
			_history.ClearHistory();
			IsPaused = false;
			UpdateDetailText();
		}

		public void InitializeProfiler(NetworkEventHistory history)
		{
			_history = history;
		}

		public override void OnWidgetInitialized(Widget widget)
		{
			base.OnWidgetInitialized(widget);
			_graphImage = widget.FindWidget<RawImageWidget>("graph").Image;
		}

		public void SelectFrameIndex(int frameIndex)
		{
			_selectedFrameIndex = frameIndex;
			UpdateDetailText();
		}

		protected void Start()
		{
			string constant = base.Widget.Stylesheet.GetConstant("ColorOutbound");
			string constant2 = base.Widget.Stylesheet.GetConstant("ColorInbound");
			ColorUtility.TryParseHtmlString(constant, out _outboundColor);
			ColorUtility.TryParseHtmlString(constant2, out _inboundColor);
			_graphTexture = new Texture2D(512, 128, TextureFormat.RGBA32, mipChain: false);
			_graphImage.texture = _graphTexture;
			_pixels32 = new Color32[_graphTexture.width * _graphTexture.height];
			EventTrigger obj = _graphImage.gameObject.GetComponent<EventTrigger>() ?? _graphImage.gameObject.AddComponent<EventTrigger>();
			obj.triggers.Clear();
			EventTrigger.Entry entry = new EventTrigger.Entry
			{
				eventID = EventTriggerType.PointerClick
			};
			entry.callback.AddListener(delegate(BaseEventData data)
			{
				OnGraphClicked((PointerEventData)data);
			});
			obj.triggers.Add(entry);
			EventTrigger.Entry entry2 = new EventTrigger.Entry
			{
				eventID = EventTriggerType.PointerDown
			};
			entry2.callback.AddListener(delegate(BaseEventData data)
			{
				OnGraphClicked((PointerEventData)data);
			});
			obj.triggers.Add(entry2);
			EventTrigger.Entry entry3 = new EventTrigger.Entry
			{
				eventID = EventTriggerType.Drag
			};
			entry3.callback.AddListener(delegate(BaseEventData data)
			{
				OnGraphDragged((PointerEventData)data);
			});
			obj.triggers.Add(entry3);
		}

		protected void Update()
		{
			DrawGraph();
			if (!IsPaused)
			{
				return;
			}
			if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
			{
				SelectFrameIndex(Mathf.Max(0, _selectedFrameIndex - 1));
			}
			else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
			{
				SelectFrameIndex(Mathf.Min(_history.History.Count - 1, _selectedFrameIndex + 1));
			}
			else
			{
				if (!UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
				{
					return;
				}
				TickData tickData = _history.History[_selectedFrameIndex];
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Inbound");
				stringBuilder.Append('\t');
				stringBuilder.Append(tickData.TotalInboundBytes);
				stringBuilder.Append('\n');
				foreach (MessageData inboundMessage in tickData.InboundMessages)
				{
					stringBuilder.Append(inboundMessage.Category);
					stringBuilder.Append('\t');
					stringBuilder.Append(inboundMessage.Name);
					stringBuilder.Append('\t');
					stringBuilder.Append(inboundMessage.Bytes);
					stringBuilder.Append('\t');
					stringBuilder.Append(inboundMessage.Count);
					stringBuilder.Append('\n');
				}
				stringBuilder.Append("Outbound");
				stringBuilder.Append('\t');
				stringBuilder.Append(tickData.TotalOutboundBytes);
				stringBuilder.Append('\n');
				foreach (MessageData outboundMessage in tickData.OutboundMessages)
				{
					stringBuilder.Append(outboundMessage.Category);
					stringBuilder.Append('\t');
					stringBuilder.Append(outboundMessage.Name);
					stringBuilder.Append('\t');
					stringBuilder.Append(outboundMessage.Bytes);
					stringBuilder.Append('\t');
					stringBuilder.Append(outboundMessage.Count);
					stringBuilder.Append('\n');
				}
				Debug.Log(stringBuilder.ToString());
			}
		}

		private static bool IsMatch(TickData tickData, string searchText)
		{
			if (!string.IsNullOrWhiteSpace(searchText) && !tickData.InboundMessages.Any((MessageData x) => IsMatch(x, searchText)))
			{
				return tickData.OutboundMessages.Any((MessageData x) => IsMatch(x, searchText));
			}
			return true;
		}

		private static bool IsMatch(MessageData msg, string searchText)
		{
			return msg.Name.Contains(searchText, StringComparison.OrdinalIgnoreCase);
		}

		private void BuildCorrectedCategoryRows(string title, ulong totalBytes, List<MessageData> messages, string rowClass)
		{
			if (messages.Count == 0)
			{
				return;
			}
			CreateRow("profiler-frame-group", title, NetworkTrafficStatistics.FormatBytesToLargest(totalBytes), 0).AddClass(rowClass);
			MessageData messageData = messages.FirstOrDefault((MessageData m) => m.Category == "Internal / Unset");
			long num = 0L;
			if (messageData.Name != null)
			{
				num = (long)(messageData.Bytes - totalBytes);
			}
			foreach (IGrouping<string, MessageData> item in from m in messages
				where m.Category != "Internal / Unset"
				group m by m.Category into g
				orderby g.Sum((MessageData m) => (long)m.Bytes) descending
				select g)
			{
				CreateRow("profiler-frame-group", item.Key, NetworkTrafficStatistics.FormatBytesToLargest((ulong)item.Sum((MessageData m) => (long)m.Bytes)), 0);
				foreach (MessageData item2 in item.OrderByDescending((MessageData m) => m.Bytes))
				{
					if (!(item2.Name == item2.Category))
					{
						Widget widget = CreateRow("profiler-frame-row", item2.Name, $"{item2.Bytes} B", item2.Count);
						if (!string.IsNullOrWhiteSpace(SearchText) && IsMatch(item2, SearchText))
						{
							widget.AddClass("search-match");
						}
					}
				}
			}
			if (num > 0)
			{
				CreateRow("profiler-frame-group", "Network Overhead", $"{num} B", 0);
			}
		}

		private Widget CreateRow(string template, string title, string size, int numCalls)
		{
			Widget widget = base.Widget.FindWidget("profiler-rows");
			if (widget == null)
			{
				return null;
			}
			Widget widget2 = base.Widget.Context.CreateWidgetFromTemplate(template, widget);
			widget2.FindWidget<TextWidget>("name").Text = title;
			widget2.FindWidget<TextWidget>("size").Text = size;
			TextWidget textWidget = widget2.FindWidget<TextWidget>("num-calls");
			if (textWidget != null)
			{
				textWidget.Text = ((numCalls > 0) ? $"{numCalls}" : string.Empty);
			}
			_rows.Add(widget2);
			return widget2;
		}

		private void DrawGraph()
		{
			if (_history == null || _pixels32 == null)
			{
				return;
			}
			Color32[] pixels = _pixels32;
			Color32 color = _backgroundColor;
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i] = color;
			}
			List<TickData> history = _history.History;
			if (history.Count == 0)
			{
				_graphTexture.SetPixels32(pixels);
				_graphTexture.Apply();
				return;
			}
			ulong num = 100uL;
			foreach (TickData item in history)
			{
				ulong num2 = item.TotalInboundBytes + item.TotalOutboundBytes;
				if (num2 > num)
				{
					num = num2;
				}
			}
			Color32 color2 = _gridColor;
			for (int j = 1; j < 4; j++)
			{
				int num3 = j * _graphTexture.height / 4;
				for (int k = 0; k < _graphTexture.width; k++)
				{
					pixels[k + num3 * _graphTexture.width] = color2;
				}
			}
			SearchResultsFrames = 0;
			SearchResultsMessages = 0;
			SearchResultsBytes = 0;
			for (int l = 0; l < history.Count; l++)
			{
				int num4 = (int)((float)l / (float)history.Count * (float)_graphTexture.width);
				Color32 color3 = _outboundColor;
				Color32 color4 = _inboundColor;
				float num5 = 1f;
				history[l].IsMatch = false;
				if (!string.IsNullOrEmpty(SearchText))
				{
					List<MessageData> list = new List<MessageData>();
					list.AddRange(history[l].InboundMessages.Where((MessageData x) => IsMatch(x, SearchText)).ToList());
					list.AddRange(history[l].OutboundMessages.Where((MessageData x) => IsMatch(x, SearchText)).ToList());
					if (list.Count > 0)
					{
						history[l].IsMatch = true;
						num5 = 0.2f;
						SearchResultsFrames++;
						SearchResultsMessages += list.Count;
						SearchResultsBytes += list.Sum((MessageData x) => (int)x.Bytes);
					}
					num5 = (IsMatch(history[l], SearchText) ? 1f : 0.2f);
					color3.a = (byte)(255f * num5);
					color4.a = (byte)(255f * num5);
				}
				int num6 = (int)((float)history[l].TotalOutboundBytes / (float)num * (float)(_graphTexture.height - 1));
				int num7 = (int)((float)history[l].TotalInboundBytes / (float)num * (float)(_graphTexture.height - 1));
				for (int num8 = 0; num8 <= num6; num8++)
				{
					pixels[num4 + num8 * _graphTexture.width] = color3;
				}
				for (int num9 = num6 + 1; num9 <= num6 + num7; num9++)
				{
					if (num9 < _graphTexture.height)
					{
						pixels[num4 + num9 * _graphTexture.width] = color4;
					}
				}
			}
			if (_selectedFrameIndex != -1)
			{
				Color32 color5 = _selectionColor;
				int num10 = (int)((float)_selectedFrameIndex / (float)history.Count * (float)_graphTexture.width);
				if (num10 >= 0 && num10 < _graphTexture.width)
				{
					for (int num11 = 0; num11 < _graphTexture.height; num11++)
					{
						pixels[num10 + num11 * _graphTexture.width] = color5;
					}
				}
			}
			_graphTexture.SetPixels32(pixels);
			_graphTexture.Apply();
		}

		private void OnGraphClicked(PointerEventData data)
		{
			if (!(_history == null))
			{
				IsPaused = true;
				OnGraphDragged(data);
			}
		}

		private void OnGraphDragged(PointerEventData data)
		{
			if (!(_history == null) && IsPaused && RectTransformUtility.ScreenPointToLocalPointInRectangle(_graphImage.rectTransform, data.position, data.pressEventCamera, out var localPoint))
			{
				int num = Mathf.Clamp((int)(Mathf.InverseLerp(_graphImage.rectTransform.rect.xMin, _graphImage.rectTransform.rect.xMax, localPoint.x) * (float)(_history.History.Count - 1)), 0, (_history.History.Count > 0) ? (_history.History.Count - 1) : 0);
				if (num != _selectedFrameIndex)
				{
					SelectFrameIndex(num);
				}
			}
		}

		private void UpdateDetailText()
		{
			foreach (Widget row in _rows)
			{
				row.Destroy();
			}
			_rows.Clear();
			if (!(_history == null) && _selectedFrameIndex >= 0 && _selectedFrameIndex < _history.History.Count)
			{
				TickData tickData = _history.History[_selectedFrameIndex];
				CreateRow("profiler-frame-group", $"Tick {tickData.Tick}", NetworkTrafficStatistics.FormatBytesToLargest(tickData.TotalInboundBytes + tickData.TotalOutboundBytes), 0);
				BuildCorrectedCategoryRows("INBOUND", tickData.TotalInboundBytes, tickData.InboundMessages, "inbound-row");
				BuildCorrectedCategoryRows("OUTBOUND", tickData.TotalOutboundBytes, tickData.OutboundMessages, "outbound-row");
			}
		}
	}
}
