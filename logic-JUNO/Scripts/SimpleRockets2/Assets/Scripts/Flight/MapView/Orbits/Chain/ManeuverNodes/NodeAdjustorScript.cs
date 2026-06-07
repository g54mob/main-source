using System;
using System.Collections.Generic;
using Assets.Scripts.Flight.MapView.Interfaces;
using Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes.Interfaces;
using Assets.Scripts.Flight.MapView.UI;
using Assets.Scripts.Ui;
using ModApi;
using ModApi.Flight.MapView;
using ModApi.Ioc;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Vectrosity;

namespace Assets.Scripts.Flight.MapView.Orbits.Chain.ManeuverNodes
{
	public class NodeAdjustorScript : MonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler, IBeginDragHandler, IDisposable, ICanvasScaleChangeHandler
	{
		public delegate void AdjustorChangeDelegate(NodeAdjustorScript source);

		private enum DragState
		{
			Drag = 0,
			End = 1
		}

		private const float SelectionChangedAnimDuration = 0.15f;

		private float _adjustorExtensionPercent;

		private Canvas _canvas;

		private VectorLine _connectingLine;

		private Color _connectingLineColor;

		private Vector2 _currentMousePos;

		private bool _dragging;

		private DragState _dragState = DragState.End;

		private Vector2 _dragVec;

		private IDrawModeProvider _drawModeProvider;

		private Image _icon;

		private Color _iconColor;

		private float _iconSize;

		private double _lineScaleBaseSize;

		private Vector3 _maneuverScreenVec;

		private Func<Vector3d> _maneuverVecFunc;

		private IMapOptions _mapOptions;

		private IManeuverNodePositionProvider _positionProvider;

		private bool _selected;

		private float _selectionChangedTime;

		private bool _selectionChanging;

		private Vector2 _startingMousePos;

		public Vector2 CurrentDragPos => _currentMousePos;

		public bool DisableDraggingWhenFacingCamera { get; set; } = true;

		public bool ExtensionEnabled { get; set; } = true;

		public bool IsDragging => _dragging;

		public bool IsSelected => _selected;

		public IManeuverNode ManeuverNode { get; private set; }

		protected Vector3d ManeuverVec { get; private set; }

		public event AdjustorChangeDelegate ManeuverNodeAdjustmentChangeBeginEvent;

		public event AdjustorChangeDelegate ManeuverNodeAdjustmentChangeEndEvent;

		public event AdjustorChangeDelegate ManeuverNodeAdjustmentChangingEvent;

		public static T Create<T>(IIocContainer ioc, Canvas canvas, Transform parent, Func<Vector3d> maneuverVec, IManeuverNode node, IManeuverNodePositionProvider positionProvider, IDrawModeProvider drawModeProvider, string name, string iconName, Color lineColor) where T : NodeAdjustorScript
		{
			T val = new GameObject(name).AddComponent<T>();
			val.transform.SetParent(parent);
			val.Initialize(ioc, canvas, maneuverVec, node, positionProvider, drawModeProvider, name, iconName, lineColor);
			return val;
		}

		public void CompletePendingAnimations()
		{
			DoSelectionChangingAnimations(completeImmediately: true);
		}

		public virtual void Dispose()
		{
			this.ManeuverNodeAdjustmentChangeBeginEvent = null;
			this.ManeuverNodeAdjustmentChangeEndEvent = null;
			this.ManeuverNodeAdjustmentChangingEvent = null;
		}

		public void ForceStopDrag()
		{
			StopDrag();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				_dragging = true;
				_startingMousePos = eventData.position;
				this.ManeuverNodeAdjustmentChangeBeginEvent?.Invoke(this);
			}
		}

		public void OnCanvasScaleChanged(float canvasScaleFactor)
		{
			CreateConnectingLine();
		}

		public void OnDrag(PointerEventData eventData)
		{
			_currentMousePos = eventData.position;
			_dragVec = _startingMousePos - _currentMousePos;
			_dragState = DragState.Drag;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			StopDrag();
		}

		public void UpdateVector()
		{
			ManeuverVec = _maneuverVecFunc();
		}

		internal void OnDeselected()
		{
			_selected = false;
			_selectionChanging = true;
			_selectionChangedTime = Time.unscaledTime;
		}

		internal void OnSelected()
		{
			_selected = true;
			_selectionChanging = true;
			_selectionChangedTime = Time.unscaledTime;
			_icon.gameObject.SetActive(value: true);
			_connectingLine.rectTransform.gameObject.SetActive(value: true);
		}

		protected virtual void Awake()
		{
			double num = 4 * ((!Game.Instance.Device.IsMobileBuild) ? 1 : 2);
			double d = 0.01745329 * num;
			_lineScaleBaseSize = Mathd.Tan(d);
		}

		protected virtual void LateUpdate()
		{
			if (_dragVec != Vector2.zero && !Utilities.Input.AnyMouseButton())
			{
				Debug.LogWarning("dragVec is nonzero yet no mouse buttons are down...OnDragEnd wasn't called when mouse was released.");
				OnEndDrag(null);
			}
			if (_selectionChanging)
			{
				DoSelectionChangingAnimations(completeImmediately: false);
			}
			if (!_selectionChanging && !_selected)
			{
				return;
			}
			float uiScale = Game.UiScale;
			Vector3d nodeWorldPosition = _positionProvider.NodeWorldPosition;
			double num = _lineScaleBaseSize * _positionProvider.CameraDistance * (double)_adjustorExtensionPercent * (double)uiScale;
			Vector3d vector3d = nodeWorldPosition + Vector3d.Scale(ManeuverVec.normalized, Vector3d.one * num);
			Vector2 vector = Utilities.GameWorldToScreenPoint(_canvas.worldCamera, (Vector3)vector3d);
			Vector2 vector2 = _positionProvider.NodeScreenPosition;
			_maneuverScreenVec = (vector - vector2).normalized;
			Vector2 vector3 = vector;
			if (_dragging || _dragState == DragState.End)
			{
				if (ExtensionEnabled && !_selectionChanging)
				{
					float num2 = Vector2.Distance(_positionProvider.NodeScreenPosition, vector);
					float num3 = Vector2.Dot(_currentMousePos - vector, _maneuverScreenVec);
					if (num2 != 0f && num3 != 0f)
					{
						float num4 = num2 * (float)((num3 >= 0f) ? 3 : (-1));
						float num5 = num2 * ((num3 >= 0f) ? 0f : 0.1f);
						float value = Mathf.Sign(num3) * (Mathf.Max(0f, Math.Abs(num3) - num5) / Math.Max(0f, Math.Abs(num4) - num5));
						value = Mathf.Clamp(value, -1f, 1f);
						vector3 += (Vector2)(_maneuverScreenVec * ((num3 >= 0f) ? Mathf.Min(num3, num4) : Mathf.Max(num3, num4)));
						float gizmoPercent = value * _mapOptions.ManeuverNodes.MaxGizmoMultiplier * ((value >= 0f) ? 1f : 0.25f);
						OnGizmoDragged(gizmoPercent);
					}
				}
				switch (_dragState)
				{
				case DragState.Drag:
					this.ManeuverNodeAdjustmentChangingEvent?.Invoke(this);
					break;
				case DragState.End:
					this.ManeuverNodeAdjustmentChangeEndEvent?.Invoke(this);
					_dragState = DragState.Drag;
					break;
				default:
					throw new InvalidOperationException("Unsupported drag state");
				}
			}
			_icon.transform.position = vector3;
			float num6 = Mathf.Min(GetIconTransparency(vector3d), 0.8f);
			_iconColor.a = num6;
			_icon.color = _iconColor;
			if (DisableDraggingWhenFacingCamera)
			{
				_icon.raycastTarget = (double)num6 > 0.4;
			}
			else
			{
				_icon.raycastTarget = true;
			}
			Vector3 vector4 = _connectingLine.rectTransform.InverseTransformPoint(vector2);
			Vector3 localPosition = _icon.transform.localPosition;
			Vector3 vector5 = localPosition - vector4;
			localPosition = vector4 + vector5.normalized * (vector5.magnitude - _iconSize * 0.5f * uiScale);
			_connectingLine.points2[0] = vector4;
			_connectingLine.points2[1] = localPosition;
			_connectingLineColor.a = num6;
			_connectingLine.color = _connectingLineColor;
			_connectingLine.Draw();
		}

		protected virtual void OnGizmoDragged(float gizmoPercent)
		{
		}

		private void CreateConnectingLine()
		{
			if (_connectingLine != null)
			{
				VectorLine.Destroy(ref _connectingLine);
			}
			_connectingLine = new VectorLine(base.name + "_line", new List<Vector2>(2), 2f);
			_connectingLine.rectTransform.gameObject.layer = base.gameObject.layer;
			_connectingLine.rectTransform.gameObject.transform.SetParent(base.transform.parent, worldPositionStays: false);
			_connectingLine.color = _connectingLineColor;
		}

		private void DoSelectionChangingAnimations(bool completeImmediately)
		{
			if (!_selectionChanging)
			{
				return;
			}
			if (completeImmediately || _selectionChangedTime + 0.15f <= Time.unscaledTime)
			{
				_selectionChanging = false;
				if (_selected)
				{
					_adjustorExtensionPercent = 1f;
					return;
				}
				_icon.gameObject.SetActive(value: false);
				_connectingLine.rectTransform.gameObject.SetActive(value: false);
				_adjustorExtensionPercent = 0f;
			}
			else
			{
				float num = Time.unscaledTime - _selectionChangedTime;
				if (_selected)
				{
					_adjustorExtensionPercent = Mathf.Lerp(0f, 1f, num / 0.15f);
				}
				else
				{
					_adjustorExtensionPercent = Mathf.Lerp(1f, 0f, num / 0.15f);
				}
			}
		}

		private float GetIconTransparency(Vector3d worldSpaceAdjustorPosition)
		{
			Vector3d normalized = (worldSpaceAdjustorPosition - _positionProvider.NodeWorldPosition).normalized;
			return Mathf.Pow(1f - Mathf.Abs(Vector3.Dot(_canvas.worldCamera.transform.forward, (Vector3)normalized)), 0.5f);
		}

		private void Initialize(IIocContainer ioc, Canvas canvas, Func<Vector3d> maneuverVec, IManeuverNode node, IManeuverNodePositionProvider positionProvider, IDrawModeProvider drawModeProvider, string name, string iconName, Color lineColor)
		{
			_canvas = canvas;
			_maneuverVecFunc = maneuverVec;
			_mapOptions = ioc.Resolve<IMapOptions>();
			ManeuverNode = node;
			_drawModeProvider = drawModeProvider;
			_positionProvider = positionProvider;
			UpdateVector();
			_icon = base.gameObject.AddComponent<Image>();
			_icon.gameObject.layer = base.gameObject.layer;
			_icon.sprite = UiUtils.LoadIconSprite(iconName);
			_icon.transform.localScale = Vector3.one * 0.25f;
			_iconSize = _icon.rectTransform.sizeDelta.x * _icon.transform.localScale.x;
			_iconColor = Color.white;
			_connectingLineColor = lineColor;
			CreateConnectingLine();
		}

		private void OnDestroy()
		{
			Dispose();
		}

		private void StopDrag()
		{
			_dragVec = Vector2.zero;
			_dragging = false;
			_dragState = DragState.End;
		}
	}
}
