using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using ModApi;
using ModApi.Common.Extensions;
using ModApi.Craft.Program;
using ModApi.Craft.Program.Craft;
using ModApi.Flight.GameView;
using ModApi.GameLoop;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class WidgetScript : MonoBehaviourBase, IMfdWidget, IGameViewPointerEventHandler
	{
		public class WidgetEventHandler
		{
			public string Data { get; set; }

			public string Message { get; set; }
		}

		private Camera _camera;

		private Dictionary<GameViewPointerEventType, WidgetEventHandler> _eventHandlers = new Dictionary<GameViewPointerEventType, WidgetEventHandler>();

		private MfdScript _mfdScript;

		private IMfdWidget _parent;

		private RectTransform _rt;

		public virtual Vector2 AnchoredPosition
		{
			get
			{
				return Transform.anchoredPosition;
			}
			set
			{
				Transform.anchoredPosition = value;
			}
		}

		public virtual Vector2 AnchorMax
		{
			get
			{
				return Transform.anchorMax;
			}
			set
			{
				Transform.anchorMax = value;
			}
		}

		public virtual Vector2 AnchorMin
		{
			get
			{
				return Transform.anchorMin;
			}
			set
			{
				Transform.anchorMin = value;
			}
		}

		public Vector3 Color
		{
			get
			{
				Color widgetColor = WidgetColor;
				return new Vector3(widgetColor.r, widgetColor.g, widgetColor.b);
			}
			set
			{
				WidgetColor = new Color(value.x, value.y, value.z, Opacity);
			}
		}

		public virtual Vector2 LocalPosition
		{
			get
			{
				return _rt.localPosition;
			}
			set
			{
				_rt.localPosition = value;
			}
		}

		public virtual float LocalRotation
		{
			get
			{
				return _rt.localRotation.eulerAngles.z;
			}
			set
			{
				_rt.localRotation = Quaternion.Euler(0f, 0f, value);
			}
		}

		public string Name { get; private set; }

		public float Opacity
		{
			get
			{
				return WidgetColor.a;
			}
			set
			{
				Color widgetColor = WidgetColor;
				widgetColor.a = value;
				WidgetColor = widgetColor;
			}
		}

		public virtual IMfdWidget Parent => _parent;

		public Vector2 Pivot
		{
			get
			{
				return _rt.pivot;
			}
			set
			{
				_rt.pivot = value;
			}
		}

		public virtual Vector2 Scale
		{
			get
			{
				return Transform.localScale;
			}
			set
			{
				Transform.localScale = new Vector3(value.x, value.y, 1f);
			}
		}

		public virtual Vector2 Size
		{
			get
			{
				return _rt.rect.size;
			}
			set
			{
				_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, value.x);
				_rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, value.y);
			}
		}

		public RectTransform Transform => _rt;

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public MfdWidgetType WidgetType { get; private set; }

		protected virtual Color WidgetColor { get; set; }

		public static string ProcessNewlines(string text)
		{
			return text.Replace("\\n", "\n");
		}

		public Vector3 ConvertDisplayToLocal(Vector3 position)
		{
			return Transform.InverseTransformPoint(_mfdScript.Canvas.transform.TransformPoint(position));
		}

		public Vector3 ConvertLocalToDisplay(Vector3 position)
		{
			return _mfdScript.Canvas.transform.InverseTransformPoint(Transform.TransformPoint(position));
		}

		public virtual void Destroy()
		{
			IMfdWidget[] componentsInChildren = GetComponentsInChildren<IMfdWidget>(includeInactive: true);
			foreach (IMfdWidget widget in componentsInChildren)
			{
				_mfdScript.RemoveWidget(widget);
			}
			Object.Destroy(base.gameObject);
		}

		public string GetEventHandler(GameViewPointerEventType eventType)
		{
			if (_eventHandlers.TryGetValue(eventType, out var value))
			{
				return value.Message;
			}
			return null;
		}

		public IGameViewPointerEventHandler HandleGameViewPointerEvent(GameViewPointerEvent pointerEvent)
		{
			IGameViewPointerEventHandler result = null;
			if (_eventHandlers.TryGetValue(pointerEvent.EventType, out var value))
			{
				_ = pointerEvent.EventData.position;
				RectTransformUtility.ScreenPointToLocalPointInRectangle(_rt, pointerEvent.EventData.position, _camera, out var localPoint);
				ExpressionResult expressionResult = new ExpressionResult();
				List<ExpressionListItem> listForModification = expressionResult.GetListForModification();
				listForModification.Add(value.Data);
				listForModification.Add(Name);
				listForModification.Add(Utilities.Vector2ToString(localPoint));
				expressionResult.OnListModified();
				_mfdScript.FlightProgram.BroadcastMessage(BroadcastScope.Program, value.Message, expressionResult);
				if (pointerEvent.EventType != GameViewPointerEventType.PointerUp && pointerEvent.EventType != GameViewPointerEventType.PointerClick)
				{
					result = this;
				}
				pointerEvent.MarkAsHandled();
			}
			return result;
		}

		public virtual void Initialize(MfdScript mfdScript, string name, MfdWidgetType widgetType)
		{
			Name = name;
			base.gameObject.name = name;
			_camera = Game.Instance.FlightScene.ViewManager.GameView.GameCamera.NearCamera;
			_mfdScript = mfdScript;
			WidgetType = widgetType;
			_rt = GetComponent<RectTransform>();
		}

		public virtual void RestoreFromXml(XElement xml)
		{
			Color = xml.GetVector3Attribute("color", Vector3.one);
			AnchorMin = xml.GetVector2Attribute("anchorMin");
			AnchorMax = xml.GetVector2Attribute("anchorMax");
			AnchoredPosition = xml.GetVector2Attribute("anchoredPosition");
			Opacity = xml.GetFloatAttribute("opacity");
			Pivot = xml.GetVector2Attribute("pivot");
			LocalRotation = xml.GetFloatAttribute("localRotation");
			Size = xml.GetVector2Attribute("size");
			Visible = xml.GetBoolAttribute("visible");
			IEnumerable<XElement> enumerable = xml.Element("Events")?.Elements();
			if (enumerable == null)
			{
				return;
			}
			foreach (XElement item in enumerable)
			{
				GameViewPointerEventType enumAttribute = Utilities.GetEnumAttribute(item, "type", GameViewPointerEventType.PointerClick);
				string stringAttribute = item.GetStringAttribute("message");
				string stringAttribute2 = item.GetStringAttribute("data");
				SetEventHandler(enumAttribute, stringAttribute, stringAttribute2);
			}
		}

		public virtual void SaveXml(XElement xml)
		{
			SetAttribute(xml, "type", WidgetType);
			SetAttribute(xml, "name", Name);
			SetAttribute(xml, "color", Utilities.Vector3ToString(Color));
			SetAttribute(xml, "anchorMin", Utilities.Vector2ToString(AnchorMin));
			SetAttribute(xml, "anchorMax", Utilities.Vector2ToString(AnchorMax));
			SetAttribute(xml, "anchoredPosition", Utilities.Vector2ToString(AnchoredPosition));
			SetAttribute(xml, "opacity", Opacity);
			SetAttribute(xml, "pivot", Utilities.Vector2ToString(Pivot));
			SetAttribute(xml, "localRotation", LocalRotation);
			SetAttribute(xml, "size", Utilities.Vector2ToString(Size));
			SetAttribute(xml, "visible", Visible);
			SetAttribute(xml, "parent", Parent?.Name);
			if (_eventHandlers.Count <= 0)
			{
				return;
			}
			XElement xElement = new XElement("Events");
			xml.Add(xElement);
			foreach (KeyValuePair<GameViewPointerEventType, WidgetEventHandler> eventHandler in _eventHandlers)
			{
				xElement.Add(new XElement("Event", new XAttribute("type", eventHandler.Key.ToString()), new XAttribute("message", eventHandler.Value.Message), new XAttribute("data", eventHandler.Value.Data)));
			}
		}

		public virtual void SetAnchor(ElementAlignment alignment)
		{
			switch (alignment)
			{
			case ElementAlignment.Left:
				Transform.anchorMin = new Vector2(0f, 0.5f);
				Transform.anchorMax = new Vector2(0f, 0.5f);
				break;
			case ElementAlignment.Center:
				Transform.anchorMin = new Vector2(0.5f, 0.5f);
				Transform.anchorMax = new Vector2(0.5f, 0.5f);
				break;
			case ElementAlignment.Right:
				Transform.anchorMin = new Vector2(1f, 0.5f);
				Transform.anchorMax = new Vector2(1f, 0.5f);
				break;
			case ElementAlignment.TopLeft:
				Transform.anchorMin = new Vector2(0f, 1f);
				Transform.anchorMax = new Vector2(0f, 1f);
				break;
			case ElementAlignment.TopCenter:
				Transform.anchorMin = new Vector2(0.5f, 1f);
				Transform.anchorMax = new Vector2(0.5f, 1f);
				break;
			case ElementAlignment.TopRight:
				Transform.anchorMin = new Vector2(1f, 1f);
				Transform.anchorMax = new Vector2(1f, 1f);
				break;
			case ElementAlignment.BottomLeft:
				Transform.anchorMin = new Vector2(0f, 0f);
				Transform.anchorMax = new Vector2(0f, 0f);
				break;
			case ElementAlignment.BottomCenter:
				Transform.anchorMin = new Vector2(0.5f, 0f);
				Transform.anchorMax = new Vector2(0.5f, 0f);
				break;
			case ElementAlignment.BottomRight:
				Transform.anchorMin = new Vector2(1f, 0f);
				Transform.anchorMax = new Vector2(1f, 0f);
				break;
			}
		}

		public void SetEventHandler(GameViewPointerEventType eventType, string messageName, string data)
		{
			_eventHandlers[eventType] = new WidgetEventHandler
			{
				Message = messageName,
				Data = data
			};
			if (eventType == GameViewPointerEventType.Drag && !_eventHandlers.ContainsKey(GameViewPointerEventType.PointerDown))
			{
				SetEventHandler(GameViewPointerEventType.PointerDown, messageName, data);
			}
			SetRaycastTarget(_eventHandlers.Values.Count((WidgetEventHandler x) => x != null) > 0);
		}

		public virtual void SetParent(IMfdWidget parent, bool worldPositionStays)
		{
			if (this != parent)
			{
				_parent = parent;
				if (parent == null)
				{
					Transform.SetParent(_mfdScript.Canvas.transform, worldPositionStays);
				}
				else
				{
					Transform.SetParent(parent.Transform, worldPositionStays);
				}
			}
		}

		public virtual void SetWidgetOrder(IMfdWidget target, bool front)
		{
			if (target == null)
			{
				if (front)
				{
					Transform.SetAsLastSibling();
				}
				else
				{
					Transform.SetAsFirstSibling();
				}
			}
			else if (target.Transform.parent == Transform.parent)
			{
				int siblingIndex = target.Transform.GetSiblingIndex();
				int num = ((Transform.GetSiblingIndex() < siblingIndex) ? (-1) : 0);
				if (front)
				{
					Transform.SetSiblingIndex(siblingIndex + 1 + num);
				}
				else
				{
					Transform.SetSiblingIndex(siblingIndex + num);
				}
			}
		}

		protected static void SetAttribute(XElement xml, string attribute, object value)
		{
			if (value != null)
			{
				xml.Add(new XAttribute(attribute, value));
			}
		}

		protected virtual void SetRaycastTarget(bool enabled)
		{
		}
	}
}
